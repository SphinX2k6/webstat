using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Weather;

// Token: 0x0200320F RID: 12815
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SimpleNpcController : ControllerBase<SimpleNpcController>
{
	// Token: 0x17002404 RID: 9220
	// (get) Token: 0x0601A9D9 RID: 109017 RVA: 0x007E5F16 File Offset: 0x007E4116
	private bool IsClearOut
	{
		get
		{
			return this.ClearOutFlags.Count > 0;
		}
	}

	// Token: 0x0601A9DA RID: 109018 RVA: 0x007E5F26 File Offset: 0x007E4126
	protected override bool OnInit()
	{
		this.OnAddEvents();
		return true;
	}

	// Token: 0x0601A9DB RID: 109019 RVA: 0x007E5F2F File Offset: 0x007E412F
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		return true;
	}

	// Token: 0x0601A9DC RID: 109020 RVA: 0x007E5F38 File Offset: 0x007E4138
	public void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<string, VarDefinePb>>(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar));
		Singleton<EventSystem>.Instance.Add(EEventName.WeatherChange, new Action(this.OnWeatherChange));
		Singleton<EventSystem>.Instance.Add(EEventName.SetImageQuality, new Action(this.OnImageQualityChanged));
	}

	// Token: 0x0601A9DD RID: 109021 RVA: 0x007E5F99 File Offset: 0x007E4199
	protected void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WeatherChange, new Action(this.OnWeatherChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.SetImageQuality, new Action(this.OnImageQualityChanged));
	}

	// Token: 0x0601A9DE RID: 109022 RVA: 0x007E5FD3 File Offset: 0x007E41D3
	protected override bool OnLeaveLevel()
	{
		this.SimpleNpcElements.Clear();
		this.InLogicRangeElements.Clear();
		this.PendingLoadSet.Clear();
		this.PendingUnloadSet.Clear();
		return true;
	}

	// Token: 0x0601A9DF RID: 109023 RVA: 0x007E6004 File Offset: 0x007E4204
	public void Add(TsSimpleNpc npc)
	{
		this.SimpleNpcElements.Add(npc);
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter != null)
		{
			this.UpdateNpcDistanceLogic(npc, baseCharacter.CharacterActorComponent.ActorLocationProxy, false);
		}
		this.CheckNpcShowState(npc, true, true);
		this.UpdateLodSingle(npc);
	}

	// Token: 0x0601A9E0 RID: 109024 RVA: 0x007E604A File Offset: 0x007E424A
	public void Remove(TsSimpleNpc npc)
	{
		this.SimpleNpcElements.Remove(npc);
		this.InLogicRangeElements.Remove(npc);
		this.PendingLoadSet.Remove(npc);
		this.PendingUnloadSet.Remove(npc);
	}

	// Token: 0x0601A9E1 RID: 109025 RVA: 0x007E6080 File Offset: 0x007E4280
	public void SetClearOutState(ESimpleNpcClearOutModuleDefine flag, bool isClearOut)
	{
		bool flag2 = false;
		if (isClearOut && !this.ClearOutFlags.Contains(flag))
		{
			this.ClearOutFlags.Add(flag);
			flag2 = true;
		}
		else if (!isClearOut && this.ClearOutFlags.Contains(flag))
		{
			this.ClearOutFlags.Remove(flag);
			flag2 = true;
		}
		if (flag2)
		{
			foreach (TsSimpleNpc tsSimpleNpc in this.InLogicRangeElements)
			{
				this.CheckNpcShowState(tsSimpleNpc, true, false);
				tsSimpleNpc.ChangeLogicRangeState(false);
			}
		}
	}

	// Token: 0x0601A9E2 RID: 109026 RVA: 0x007E6124 File Offset: 0x007E4324
	protected override void OnTick(float deltaTime)
	{
		this.HandleLoadingNpc(deltaTime);
		this.HandleUnloadingNpc(deltaTime);
	}

	// Token: 0x0601A9E3 RID: 109027 RVA: 0x007E6134 File Offset: 0x007E4334
	public List<TsSimpleNpc> GetSimpleNpcListByRange(float range)
	{
		List<TsSimpleNpc> list = new List<TsSimpleNpc>();
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null)
		{
			return list;
		}
		float num = range * range;
		global::Vector actorLocationProxy = baseCharacter.CharacterActorComponent.ActorLocationProxy;
		foreach (TsSimpleNpc tsSimpleNpc in this.SimpleNpcElements)
		{
			global::Vector selfLocationProxy = tsSimpleNpc.SelfLocationProxy;
			if (global::Vector.DistSquared(actorLocationProxy, selfLocationProxy) <= (double)num)
			{
				list.Add(tsSimpleNpc);
			}
		}
		return list;
	}

	// Token: 0x0601A9E4 RID: 109028 RVA: 0x007E61C4 File Offset: 0x007E43C4
	private void ExecuteInitLogic()
	{
		if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			this.CheckLogicRangeSquared = 36000000f;
		}
		else
		{
			this.CheckLogicRangeSquared = 9000000f;
		}
		this.UpdateLodSetting();
	}

	// Token: 0x0601A9E5 RID: 109029 RVA: 0x007E61F0 File Offset: 0x007E43F0
	public void UpdateDistanceLogic()
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null)
		{
			return;
		}
		if (!this.IsInit)
		{
			this.ExecuteInitLogic();
			this.IsInit = true;
		}
		global::Vector actorLocationProxy = baseCharacter.CharacterActorComponent.ActorLocationProxy;
		foreach (TsSimpleNpc npc in this.SimpleNpcElements)
		{
			this.UpdateNpcDistanceLogic(npc, actorLocationProxy, true);
		}
	}

	// Token: 0x0601A9E6 RID: 109030 RVA: 0x007E6270 File Offset: 0x007E4470
	private void UpdateNpcDistanceLogic(TsSimpleNpc npc, global::Vector playerLocation, bool checkNpcShowState = true)
	{
		if (!npc.IsNotUnload)
		{
			return;
		}
		global::Vector selfLocationProxy = npc.SelfLocationProxy;
		double num = global::Vector.DistSquared(playerLocation, selfLocationProxy);
		if (num > (double)this.CheckLogicRangeSquared)
		{
			this.SetSimpleNpcRangeLogic(npc, false, checkNpcShowState);
		}
		else
		{
			this.SetSimpleNpcRangeLogic(npc, true, checkNpcShowState);
		}
		npc.TempDistanceSquared = num;
	}

	// Token: 0x0601A9E7 RID: 109031 RVA: 0x007E62BC File Offset: 0x007E44BC
	private void SetSimpleNpcRangeLogic(TsSimpleNpc npc, bool newState, bool checkNpcShowState = true)
	{
		bool isInLogicRange = npc.IsInLogicRange;
		npc.ChangeLogicRangeState(newState);
		if (isInLogicRange != newState)
		{
			npc.SetTickEnabled(newState);
			npc.SetMainShadowEnabled(newState);
			if (!isInLogicRange && newState)
			{
				this.InLogicRangeElements.Add(npc);
				if (checkNpcShowState)
				{
					this.CheckNpcShowState(npc, false, true);
					return;
				}
			}
			else if (isInLogicRange && !newState)
			{
				this.InLogicRangeElements.Remove(npc);
			}
		}
	}

	// Token: 0x0601A9E8 RID: 109032 RVA: 0x007E631E File Offset: 0x007E451E
	private void AddToPendingLoadSet(TsSimpleNpc npc)
	{
		npc.CurDither = 0f;
		npc.IsNotUnload = true;
		npc.SetDitherEffect(0f, ECharacterDitherType.Fight);
		this.PendingLoadSet.Add(npc);
		this.PendingUnloadSet.Remove(npc);
	}

	// Token: 0x0601A9E9 RID: 109033 RVA: 0x007E6358 File Offset: 0x007E4558
	private void AddToPendingUnloadSet(TsSimpleNpc npc)
	{
		npc.CurDither = 1f;
		npc.IsNotUnload = false;
		npc.SetDitherEffect(1f, ECharacterDitherType.Fight);
		this.PendingUnloadSet.Add(npc);
		this.PendingLoadSet.Remove(npc);
	}

	// Token: 0x0601A9EA RID: 109034 RVA: 0x007E6394 File Offset: 0x007E4594
	private void HandleLoadingNpc(float deltaTime)
	{
		if (this.PendingLoadSet.Count <= 0)
		{
			return;
		}
		List<TsSimpleNpc> list = null;
		foreach (TsSimpleNpc tsSimpleNpc in this.PendingLoadSet)
		{
			tsSimpleNpc.CurDither += 0.33f * deltaTime * 0.001f;
			tsSimpleNpc.CurDither = Singleton<MathUtils>.Instance.Clamp(tsSimpleNpc.CurDither, 0f, 1f);
			tsSimpleNpc.SetDitherEffect(tsSimpleNpc.CurDither, ECharacterDitherType.Fight);
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)tsSimpleNpc.CurDither, 1.0, null))
			{
				if (list == null)
				{
					list = new List<TsSimpleNpc>();
				}
				list.Add(tsSimpleNpc);
			}
		}
		if (list != null)
		{
			foreach (TsSimpleNpc item in list)
			{
				this.PendingLoadSet.Remove(item);
			}
		}
	}

	// Token: 0x0601A9EB RID: 109035 RVA: 0x007E64BC File Offset: 0x007E46BC
	private void HandleUnloadingNpc(float deltaTime)
	{
		if (this.PendingUnloadSet.Count <= 0)
		{
			return;
		}
		List<TsSimpleNpc> list = null;
		foreach (TsSimpleNpc tsSimpleNpc in this.PendingUnloadSet)
		{
			tsSimpleNpc.CurDither -= 0.33f * deltaTime * 0.001f;
			tsSimpleNpc.CurDither = Singleton<MathUtils>.Instance.Clamp(tsSimpleNpc.CurDither, 0f, 1f);
			tsSimpleNpc.SetDitherEffect(tsSimpleNpc.CurDither, ECharacterDitherType.Fight);
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)tsSimpleNpc.CurDither, 0.0, null))
			{
				if (list == null)
				{
					list = new List<TsSimpleNpc>();
				}
				list.Add(tsSimpleNpc);
			}
		}
		if (list != null)
		{
			foreach (TsSimpleNpc item in list)
			{
				this.PendingUnloadSet.Remove(item);
			}
		}
	}

	// Token: 0x0601A9EC RID: 109036 RVA: 0x007E65E4 File Offset: 0x007E47E4
	private void SetNpcShowStateImmediately(TsSimpleNpc npc, bool showState)
	{
		npc.CurDither = (showState ? 1f : 0f);
		npc.IsNotUnload = showState;
		npc.SetDitherEffect(npc.CurDither, ECharacterDitherType.Fight);
		this.PendingLoadSet.Remove(npc);
		this.PendingUnloadSet.Remove(npc);
	}

	// Token: 0x0601A9ED RID: 109037 RVA: 0x007E6634 File Offset: 0x007E4834
	private void OnWeatherChange()
	{
		foreach (TsSimpleNpc npc in this.InLogicRangeElements)
		{
			this.CheckNpcShowState(npc, false, true);
		}
	}

	// Token: 0x0601A9EE RID: 109038 RVA: 0x007E668C File Offset: 0x007E488C
	public void CheckNpcShowState(TsSimpleNpc npc, bool isInit, bool useDitherAnimation = true)
	{
		bool flag = !this.IsClearOut && this.CheckNpcShowInWeather(npc);
		if (flag && !npc.IsLodShow)
		{
			return;
		}
		if (!useDitherAnimation)
		{
			this.SetNpcShowStateImmediately(npc, flag);
			return;
		}
		if (isInit)
		{
			if (!flag)
			{
				this.SetNpcShowStateImmediately(npc, flag);
				return;
			}
			this.AddToPendingLoadSet(npc);
			return;
		}
		else
		{
			if (npc.IsNotUnload && !flag)
			{
				this.AddToPendingUnloadSet(npc);
				return;
			}
			if (!npc.IsNotUnload && flag)
			{
				this.AddToPendingLoadSet(npc);
			}
			return;
		}
	}

	// Token: 0x0601A9EF RID: 109039 RVA: 0x007E6704 File Offset: 0x007E4904
	private bool CheckNpcShowInWeather(TsSimpleNpc npc)
	{
		WeatherModel instance = ModelBase<WeatherModel>.Instance;
		if (instance == null)
		{
			return true;
		}
		bool result = true;
		switch (instance.CurrentWeatherId)
		{
		case 1:
			if (npc.DisappearOnSunny)
			{
				result = false;
			}
			break;
		case 2:
			if (npc.DisappearOnCloudy)
			{
				result = false;
			}
			break;
		case 3:
			if (npc.DisappearOnRainy)
			{
				result = false;
			}
			break;
		case 4:
			if (npc.DisappearOnThunderRain)
			{
				result = false;
			}
			break;
		case 5:
			if (npc.DisappearOnSnowy)
			{
				result = false;
			}
			break;
		}
		return result;
	}

	// Token: 0x0601A9F0 RID: 109040 RVA: 0x007E677E File Offset: 0x007E497E
	private void OnReceivePlayerVar(IReadOnlyDictionary<string, VarDefinePb> varInfos)
	{
		this.OnChangeWorldState();
	}

	// Token: 0x0601A9F1 RID: 109041 RVA: 0x007E6788 File Offset: 0x007E4988
	private void OnChangeWorldState()
	{
		foreach (TsSimpleNpc tsSimpleNpc in this.SimpleNpcElements)
		{
			tsSimpleNpc.FilterFlowWorldState();
		}
	}

	// Token: 0x0601A9F2 RID: 109042 RVA: 0x007E67D8 File Offset: 0x007E49D8
	private void UpdateLodSetting()
	{
		foreach (TsSimpleNpc npc in this.SimpleNpcElements)
		{
			this.UpdateLodSingle(npc);
		}
	}

	// Token: 0x0601A9F3 RID: 109043 RVA: 0x007E682C File Offset: 0x007E4A2C
	private void UpdateLodSingle(TsSimpleNpc npc)
	{
		if (npc.IsLodShow)
		{
			if (!npc.IsNotUnload)
			{
				this.AddToPendingLoadSet(npc);
				return;
			}
		}
		else if (npc.IsNotUnload)
		{
			this.AddToPendingUnloadSet(npc);
			npc.ChangeLogicRangeState(false);
		}
	}

	// Token: 0x0601A9F4 RID: 109044 RVA: 0x007E685C File Offset: 0x007E4A5C
	private void OnImageQualityChanged()
	{
		this.UpdateLodSetting();
	}

	// Token: 0x0400D781 RID: 55169
	private readonly HashSet<TsSimpleNpc> SimpleNpcElements = new HashSet<TsSimpleNpc>();

	// Token: 0x0400D782 RID: 55170
	private readonly HashSet<TsSimpleNpc> InLogicRangeElements = new HashSet<TsSimpleNpc>();

	// Token: 0x0400D783 RID: 55171
	private readonly HashSet<TsSimpleNpc> PendingLoadSet = new HashSet<TsSimpleNpc>();

	// Token: 0x0400D784 RID: 55172
	private readonly HashSet<TsSimpleNpc> PendingUnloadSet = new HashSet<TsSimpleNpc>();

	// Token: 0x0400D785 RID: 55173
	private readonly HashSet<ESimpleNpcClearOutModuleDefine> ClearOutFlags = new HashSet<ESimpleNpcClearOutModuleDefine>();

	// Token: 0x0400D786 RID: 55174
	private float CheckLogicRangeSquared;

	// Token: 0x0400D787 RID: 55175
	private bool IsInit;

	// Token: 0x0400D788 RID: 55176
	private const int PC_CHECK_RANGE = 6000;

	// Token: 0x0400D789 RID: 55177
	private const int PC_CHECK_RANGE_SQUARED = 36000000;

	// Token: 0x0400D78A RID: 55178
	private const int MOBILE_CHECK_RANGE = 3000;

	// Token: 0x0400D78B RID: 55179
	private const int MOBILE_CHECK_RANGE_SQUARED = 9000000;

	// Token: 0x0400D78C RID: 55180
	private const float DITHER_STEP = 0.33f;

	// Token: 0x0400D78D RID: 55181
	private const float DITHER_MAX = 1f;

	// Token: 0x0400D78E RID: 55182
	private const float DITHER_MIN = 0f;

	// Token: 0x0400D78F RID: 55183
	private const float MILLISECOND_TO_SECOND = 0.001f;
}
