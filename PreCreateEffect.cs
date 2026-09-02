using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.World.Define;
using UnrealEngine;

// Token: 0x02000E7D RID: 3709
[NullableContext(1)]
[Nullable(0)]
public class PreCreateEffect : IGameBudgetManagedObject, IStaticVariableResetter
{
	// Token: 0x06005A5B RID: 23131 RVA: 0x0016265C File Offset: 0x0016085C
	static PreCreateEffect()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PreCreateEffect.CreateStaticDefaultValue), new Action(PreCreateEffect.ResetStaticDefaultValue));
	}

	// Token: 0x17000678 RID: 1656
	// (get) Token: 0x06005A5C RID: 23132 RVA: 0x0016267B File Offset: 0x0016087B
	public static HashSet<string> PreCreateEffectSet
	{
		get
		{
			return PreCreateEffect._preCreateEffectSet;
		}
	}

	// Token: 0x06005A5D RID: 23133 RVA: 0x00162684 File Offset: 0x00160884
	public void Init()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		Singleton<EventSystem>.Instance.Add<CreatureDataComponent, EntityHandle>(EEventName.CreateEntity, new Action<CreatureDataComponent, EntityHandle>(this.OnCreateEntity));
		int curLruCapacity = UKuroStaticLibrary.IsLowMemoryDevice() ? 60 : 100;
		this.CurLruCapacity = curLruCapacity;
	}

	// Token: 0x06005A5E RID: 23134 RVA: 0x001626E0 File Offset: 0x001608E0
	public void Clear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.CreateEntity, new Action<CreatureDataComponent, EntityHandle>(this.OnCreateEntity));
		Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
		this.PlayerPreCreateNumberMap.Clear();
	}

	// Token: 0x06005A5F RID: 23135 RVA: 0x0016273C File Offset: 0x0016093C
	public static bool IsNeedPreCreateEffect()
	{
		return !GlobalData.IsPlayInEditor || ((ModelBase<GameModeModel>.Instance.MapId > 3000 && ModelBase<GameModeModel>.Instance.MapId < 4000) || ModelBase<GameModeModel>.Instance.MapId == 2);
	}

	// Token: 0x06005A60 RID: 23136 RVA: 0x0016277C File Offset: 0x0016097C
	private void OnCreateEntity(CreatureDataComponent creatureData, EntityHandle handle)
	{
		if (creatureData.GetEntityType() == EEntityType.Player)
		{
			this.ListenEntitySet.Add(handle.Id);
			Singleton<EventSystem>.Instance.AddWithTarget(handle.Entity, EEventName.AiHateAddOrRemove, new Action<bool, AiController>(this.AiHateAddOrRemove));
		}
		Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<ERemoveEntityType, EntityHandle>(this, handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
	}

	// Token: 0x06005A61 RID: 23137 RVA: 0x001627E4 File Offset: 0x001609E4
	private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		if (this.ListenEntitySet.Contains(handle.Id))
		{
			this.ListenEntitySet.Remove(handle.Id);
			Singleton<EventSystem>.Instance.RemoveWithTarget(handle.Entity, EEventName.AiHateAddOrRemove, new Action<bool, AiController>(this.AiHateAddOrRemove));
		}
		Singleton<EventSystem>.Instance.RemoveWithTargetUseKey(this, handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		if (this.PreCreateEffectMap.ContainsKey(handle.Id))
		{
			this.PreCreateEffectMap.Remove(handle.Id);
		}
		this.PlayerPreCreateNumberMap.Remove(handle.Id);
	}

	// Token: 0x06005A62 RID: 23138 RVA: 0x00162890 File Offset: 0x00160A90
	public void AiHateAddOrRemove(bool addOrRemove, AiController from)
	{
		if (addOrRemove)
		{
			int id = from.CharActorComp.Entity.Id;
			Queue<PreCreateEffectData> queue;
			if (this.PreCreateEffectMap.TryGetValue(id, out queue))
			{
				while (!queue.Empty)
				{
					this.CurPreCreateEffect.Push(queue.Pop());
				}
				this.PreCreateEffectMap.Remove(id);
			}
		}
	}

	// Token: 0x06005A63 RID: 23139 RVA: 0x001628EC File Offset: 0x00160AEC
	private void OnBattleStateChanged(bool isInBattleState)
	{
		if (isInBattleState)
		{
			this.InitCommonEffect();
			int curLruCapacity = UKuroStaticLibrary.IsLowMemoryDevice() ? 300 : 600;
			this.CurLruCapacity = curLruCapacity;
			return;
		}
		int curLruCapacity2 = UKuroStaticLibrary.IsLowMemoryDevice() ? 60 : 100;
		this.CurLruCapacity = curLruCapacity2;
	}

	// Token: 0x06005A64 RID: 23140 RVA: 0x00162933 File Offset: 0x00160B33
	public void Tick(double delta)
	{
		if (!PreCreateEffect.IsOpenPool)
		{
			return;
		}
		if (!this.CurPreCreateEffect.Empty && PreCreateEffect.IsNeedPreCreateEffect())
		{
			this.PreCreateEffectInternal();
		}
		this.UpdateLruCapacity();
	}

	// Token: 0x06005A65 RID: 23141 RVA: 0x00162960 File Offset: 0x00160B60
	private void UpdateLruCapacity()
	{
		int effectLruCapacity = Singleton<EffectSystem>.Instance.GetEffectLruCapacity();
		int num = this.ForceLruCapacity ?? this.CurLruCapacity;
		if (effectLruCapacity == num)
		{
			return;
		}
		if (effectLruCapacity > this.CurLruCapacity)
		{
			int num2 = Singleton<EffectSystem>.Instance.GetEffectLruSize() - 3;
			Singleton<EffectSystem>.Instance.SetEffectLruCapacity((num2 > num) ? num2 : num);
			return;
		}
		Singleton<EffectSystem>.Instance.SetEffectLruCapacity(600);
	}

	// Token: 0x06005A66 RID: 23142 RVA: 0x001629D5 File Offset: 0x00160BD5
	public void SetForceLruCapacity(int? lruCapacity)
	{
		this.ForceLruCapacity = lruCapacity;
	}

	// Token: 0x06005A67 RID: 23143 RVA: 0x001629E0 File Offset: 0x00160BE0
	private void InitCommonEffect()
	{
		foreach (string path in this.commonFightEffect)
		{
			if (Singleton<EffectSystem>.Instance.GetEffectLruCount(path) == 0)
			{
				this.CurPreCreateEffect.Push(new PreCreateEffectData(-1, path));
			}
		}
	}

	// Token: 0x06005A68 RID: 23144 RVA: 0x00162A28 File Offset: 0x00160C28
	private void AddEffect(PreCreateEffectData data)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(data.EntityId);
		bool flag;
		if (entity == null)
		{
			flag = false;
		}
		else
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			EEntityType? eentityType = (component != null) ? new EEntityType?(component.GetEntityType()) : null;
			EEntityType eentityType2 = EEntityType.Player;
			flag = (eentityType.GetValueOrDefault() == eentityType2 & eentityType != null);
		}
		if (!flag)
		{
			if (!this.PreCreateEffectMap.ContainsKey(data.EntityId))
			{
				this.PreCreateEffectMap[data.EntityId] = new Queue<PreCreateEffectData>(4);
			}
			this.PreCreateEffectMap[data.EntityId].Push(data);
			this.PreCreateEffectCountMap[data.Path] = this.PreCreateEffectCountMap.GetValueOrDefault(data.Path, 0) + 1;
			return;
		}
		int valueOrDefault = this.PlayerPreCreateNumberMap.GetValueOrDefault(data.EntityId, 0);
		if (valueOrDefault >= 150)
		{
			return;
		}
		this.PlayerPreCreateNumberMap[data.EntityId] = valueOrDefault + 1;
		this.CurPreCreateEffect.Push(data);
	}

	// Token: 0x06005A69 RID: 23145 RVA: 0x00162B24 File Offset: 0x00160D24
	[NullableContext(2)]
	public void AddPreCreateEffect(int entityId, string effectPath)
	{
		if (string.IsNullOrEmpty(effectPath) || effectPath.Contains("/Niagara") || effectPath.Contains("/MaterialController/") || effectPath.Contains("/UIResources/") || effectPath.Contains("/Aki/Character"))
		{
			return;
		}
		PreCreateEffectData data = new PreCreateEffectData(entityId, effectPath);
		if (this.PreCreateEffectCountMap.GetValueOrDefault(effectPath, 0) == 0)
		{
			this.AddEffect(data);
		}
		if (this.IsDebug)
		{
			PreCreateEffect.PreCreateEffectSet.Add(effectPath);
		}
	}

	// Token: 0x06005A6A RID: 23146 RVA: 0x00162BA0 File Offset: 0x00160DA0
	public void AddPreCreateHitEffect(int entityId, string hitEffectPath)
	{
		if (string.IsNullOrEmpty(hitEffectPath))
		{
			return;
		}
		PreCreateEffectData data = new PreCreateEffectData(entityId, hitEffectPath);
		int num = (UKuroStaticLibrary.IsLowMemoryDevice() ? 2 : 3) - Singleton<EffectSystem>.Instance.GetEffectLruCount(hitEffectPath) - this.PreCreateEffectCountMap.GetValueOrDefault(hitEffectPath, 0);
		for (int i = 0; i < num; i++)
		{
			this.AddEffect(data);
		}
		if (this.IsDebug)
		{
			PreCreateEffect.PreCreateEffectSet.Add(hitEffectPath);
		}
	}

	// Token: 0x06005A6B RID: 23147 RVA: 0x00162C0C File Offset: 0x00160E0C
	private void PreCreateEffectInternal()
	{
		PreCreateEffectData preCreateEffectData = this.CurPreCreateEffect.Pop();
		int valueOrDefault = this.PreCreateEffectCountMap.GetValueOrDefault(preCreateEffectData.Path, 0);
		if (valueOrDefault - 1 <= 0)
		{
			this.PreCreateEffectCountMap.Remove(preCreateEffectData.Path);
		}
		else
		{
			this.PreCreateEffectCountMap[preCreateEffectData.Path] = valueOrDefault - 1;
		}
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject gameInstance = GlobalData.GameInstance;
		FTransformDouble? ftransformDouble = new FTransformDouble?(this.DefaultTransform);
		int handle = instance.SpawnEffect(gameInstance, ftransformDouble, preCreateEffectData.Path, "PreCreateEffect", new EffectContext(new int?(preCreateEffectData.EntityId), null, false), EEffectType.Scene, null, null, null, true, false);
		Singleton<EffectSystem>.Instance.StopEffectById(handle, "PreCreateEffect", true, null);
		bool isDebug = this.IsDebug;
	}

	// Token: 0x06005A6C RID: 23148 RVA: 0x00162CCC File Offset: 0x00160ECC
	public void RegisterTick()
	{
		if (this.GameBudgetManagedTokenInternal != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Preload;
			ELogAuthor author = ELogAuthor.YZ;
			string message = "EffectHandle RegisterTick: 重复注册Tick";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EffectHandle", base.GetType().Name);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.UnregisterTick();
		}
		if (!this.GameBudgetGCHandle.IsAllocated)
		{
			this.GameBudgetGCHandle = GCHandle.Alloc(this, GCHandleType.Normal);
		}
		TsGameBudgetGroupConfigCache tsIdleExecConfig = Singleton<GameBudgetAllocatorConfigCreator>.Instance.TsIdleExecConfig;
		this.GameBudgetManagedTokenInternal = new uint?(Singleton<GameBudgetInterfaceController>.Instance.RegisterTick(tsIdleExecConfig.GroupName, tsIdleExecConfig.SignificanceGroup, this, null, true, true, true, true));
	}

	// Token: 0x06005A6D RID: 23149 RVA: 0x00162D68 File Offset: 0x00160F68
	public void UnregisterTick()
	{
		if (this.GameBudgetManagedTokenInternal != null)
		{
			Singleton<GameBudgetInterfaceController>.Instance.UnregisterTick(this);
			this.GameBudgetManagedTokenInternal = null;
		}
		if (this.GameBudgetGCHandle.IsAllocated)
		{
			this.GameBudgetGCHandle.Free();
		}
	}

	// Token: 0x06005A6E RID: 23150 RVA: 0x00162DA6 File Offset: 0x00160FA6
	public void ScheduledTick(float deltaSeconds, int deltaFrames, float distance)
	{
		this.Tick((double)deltaSeconds);
	}

	// Token: 0x17000679 RID: 1657
	// (get) Token: 0x06005A6F RID: 23151 RVA: 0x00162DB0 File Offset: 0x00160FB0
	public bool HasScheduledAfterTick
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700067A RID: 1658
	// (get) Token: 0x06005A70 RID: 23152 RVA: 0x00162DB3 File Offset: 0x00160FB3
	public bool HasOnEnabledChange
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700067B RID: 1659
	// (get) Token: 0x06005A71 RID: 23153 RVA: 0x00162DB6 File Offset: 0x00160FB6
	public bool HasOnWasRecentlyRenderedOnScreenChange
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06005A72 RID: 23154 RVA: 0x00162DB9 File Offset: 0x00160FB9
	public GCHandle GetGCHandle()
	{
		return this.GameBudgetGCHandle;
	}

	// Token: 0x06005A73 RID: 23155 RVA: 0x00162DC1 File Offset: 0x00160FC1
	public static void CreateStaticDefaultValue()
	{
		PreCreateEffect.IsOpenPool = true;
		PreCreateEffect._preCreateEffectSet = new HashSet<string>();
	}

	// Token: 0x06005A74 RID: 23156 RVA: 0x00162DD3 File Offset: 0x00160FD3
	public static void ResetStaticDefaultValue()
	{
		PreCreateEffect.IsOpenPool = true;
		PreCreateEffect._preCreateEffectSet = null;
	}

	// Token: 0x040029E2 RID: 10722
	private const int HIT_EFFECT_COUNT = 3;

	// Token: 0x040029E3 RID: 10723
	private const int FIGHT_EFFECT_LRU_SIZE = 600;

	// Token: 0x040029E4 RID: 10724
	private const int NORMAL_EFFECT_LRU_SIZE = 100;

	// Token: 0x040029E5 RID: 10725
	private const int CHANGE_COUNT_EVERY_TICK = 3;

	// Token: 0x040029E6 RID: 10726
	private const int LOW_MEMORY_HIT_EFFECT_COUNT = 2;

	// Token: 0x040029E7 RID: 10727
	private const int LOW_MEMORY_FIGHT_EFFECT_LRU_SIZE = 300;

	// Token: 0x040029E8 RID: 10728
	private const int LOW_MEMORY_NORMAL_EFFECT_LRU_SIZE = 60;

	// Token: 0x040029E9 RID: 10729
	private const int PLAYER_CREATE_MAX = 150;

	// Token: 0x040029EA RID: 10730
	private readonly string[] commonFightEffect = new string[]
	{
		"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_ChangeRole.DA_Fx_Group_ChangeRole",
		"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_ChangeRoleStart.DA_Fx_Group_ChangeRoleStart",
		"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_ChangeRole_Play.DA_Fx_Group_ChangeRole_Play",
		"/Game/Aki/Effect/EffectAudio/RoleCommon/DA_Au_Role_Common_Char_Change.DA_Au_Role_Common_Char_Change",
		"/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_WeaponEnd.DA_Fx_Group_WeaponEnd"
	};

	// Token: 0x040029EB RID: 10731
	private readonly FTransformDouble DefaultTransform = new FTransformDouble();

	// Token: 0x040029EC RID: 10732
	private readonly Dictionary<int, Queue<PreCreateEffectData>> PreCreateEffectMap = new Dictionary<int, Queue<PreCreateEffectData>>();

	// Token: 0x040029ED RID: 10733
	private readonly Queue<PreCreateEffectData> CurPreCreateEffect = new Queue<PreCreateEffectData>(4);

	// Token: 0x040029EE RID: 10734
	private readonly Dictionary<int, int> PlayerPreCreateNumberMap = new Dictionary<int, int>();

	// Token: 0x040029EF RID: 10735
	private readonly Dictionary<string, int> PreCreateEffectCountMap = new Dictionary<string, int>();

	// Token: 0x040029F0 RID: 10736
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static HashSet<string> _preCreateEffectSet;

	// Token: 0x040029F1 RID: 10737
	private readonly Stat PreCreateEffectStat = Stat.Create("PreCreateEffect", "", "");

	// Token: 0x040029F2 RID: 10738
	private uint? GameBudgetManagedTokenInternal;

	// Token: 0x040029F3 RID: 10739
	private int CurLruCapacity = 100;

	// Token: 0x040029F4 RID: 10740
	public int? ForceLruCapacity;

	// Token: 0x040029F5 RID: 10741
	private readonly HashSet<int> ListenEntitySet = new HashSet<int>();

	// Token: 0x040029F6 RID: 10742
	private readonly bool IsDebug = true;

	// Token: 0x040029F7 RID: 10743
	public static bool IsOpenPool;

	// Token: 0x040029F8 RID: 10744
	private GCHandle GameBudgetGCHandle;
}
