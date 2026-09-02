using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002D67 RID: 11623
public class WorldLevelUpView : UiTickViewBase
{
	// Token: 0x0601776B RID: 96107 RVA: 0x006811F4 File Offset: 0x0067F3F4
	[NullableContext(1)]
	public WorldLevelUpView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601776C RID: 96108 RVA: 0x00681220 File Offset: 0x0067F420
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601776D RID: 96109 RVA: 0x006812AA File Offset: 0x0067F4AA
	protected override void OnStart()
	{
		this.SetLevelText();
		this.PlayWorldLevelUpEffect();
	}

	// Token: 0x0601776E RID: 96110 RVA: 0x006812B8 File Offset: 0x0067F4B8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldLevelUpViewRefresh, new Action(this.OnViewRefresh));
	}

	// Token: 0x0601776F RID: 96111 RVA: 0x006812D6 File Offset: 0x0067F4D6
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldLevelUpViewRefresh, new Action(this.OnViewRefresh));
	}

	// Token: 0x06017770 RID: 96112 RVA: 0x006812F4 File Offset: 0x0067F4F4
	private void SetLevelText()
	{
		int originWorldLevel = ModelBase<WorldLevelModel>.Instance.OriginWorldLevel;
		base.GetText(0).SetText(originWorldLevel.ToString(), true);
		WorldLevel? worldLevelConfig = ConfigBase<WorldLevelConfig>.Instance.GetWorldLevelConfig(originWorldLevel - 1);
		int? num = (worldLevelConfig != null) ? new int?(worldLevelConfig.GetValueOrDefault().PlayerLevelMax) : null;
		worldLevelConfig = ConfigBase<WorldLevelConfig>.Instance.GetWorldLevelConfig(originWorldLevel);
		int? num2 = (worldLevelConfig != null) ? new int?(worldLevelConfig.GetValueOrDefault().PlayerLevelMax) : null;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "WorldLevelTips", new <>z__ReadOnlyArray<object>(new object[]
		{
			num,
			num2
		}));
	}

	// Token: 0x06017771 RID: 96113 RVA: 0x006813C3 File Offset: 0x0067F5C3
	protected override void OnTick(float delta)
	{
		if (this.Time < 0f)
		{
			return;
		}
		this.Time += delta;
		if (this.Time > (float)this.CloseTime)
		{
			this.CloseView();
			this.Time = -1f;
		}
	}

	// Token: 0x06017772 RID: 96114 RVA: 0x00681401 File Offset: 0x0067F601
	private void OnViewRefresh()
	{
		this.SetLevelText();
	}

	// Token: 0x06017773 RID: 96115 RVA: 0x00681409 File Offset: 0x0067F609
	private void CloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x06017774 RID: 96116 RVA: 0x00681412 File Offset: 0x0067F612
	protected override void OnBeforeDestroy()
	{
		this.RecycleEffect();
	}

	// Token: 0x06017775 RID: 96117 RVA: 0x0068141C File Offset: 0x0067F61C
	private void PlayWorldLevelUpEffect()
	{
		if (Global.BaseCharacter == null)
		{
			return;
		}
		string effectPath = EffectUtil.GetEffectPath("WorldLevelUpEffect");
		if (effectPath == null || effectPath.Length == 0)
		{
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		FTransformDouble value = baseCharacter.D_GetTransform();
		float capsuleHalfHeight = baseCharacter.CapsuleComponent.CapsuleHalfHeight;
		FVectorDouble location = value.GetLocation();
		location.Z -= (double)capsuleHalfHeight;
		value.SetLocation(location);
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(value);
		this.EffectHandle = instance.SpawnUnloopedEffect(world, ftransformDouble, effectPath, "[WorldLevelUpView.PlayWorldLevelUpEffect]", null, EEffectType.Scene, null, null, null, false, false);
		Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.SelfCentered, this.EffectHandle, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
	}

	// Token: 0x06017776 RID: 96118 RVA: 0x006814C8 File Offset: 0x0067F6C8
	private void RecycleEffect()
	{
		if (Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandle, "[WorldLevelUpView.RecycleEffect]", true, null);
			this.EffectHandle = 0;
		}
	}

	// Token: 0x0400B3F7 RID: 46071
	private int EffectHandle;

	// Token: 0x0400B3F8 RID: 46072
	private float Time;

	// Token: 0x0400B3F9 RID: 46073
	private readonly int CloseTime = ConfigCommonParamById.GetIntConfig("WorldLevelDisplayTime").Value;
}
