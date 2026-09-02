using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02000F45 RID: 3909
[NullableContext(1)]
[Nullable(0)]
public class KscSubModelBase
{
	// Token: 0x06006213 RID: 25107 RVA: 0x0018861C File Offset: 0x0018681C
	public virtual string GetSkillDtPath()
	{
		return "";
	}

	// Token: 0x06006214 RID: 25108 RVA: 0x00188623 File Offset: 0x00186823
	public virtual string GetEntityDtPath()
	{
		return "";
	}

	// Token: 0x06006215 RID: 25109 RVA: 0x0018862A File Offset: 0x0018682A
	public bool Init()
	{
		return this.OnInit();
	}

	// Token: 0x06006216 RID: 25110 RVA: 0x00188634 File Offset: 0x00186834
	public bool Clear()
	{
		this.PropertyConfigs.Clear();
		this.SkillDataDt.Clear();
		this.EntityDataDt.Clear();
		this.LogicProxy.Clear();
		this.KscEntities.Clear();
		this.DamageIds.Clear();
		this.SetKscPlayerEntity(null, 0L);
		this.KscInitState = EKscInitState.None;
		return this.OnClear();
	}

	// Token: 0x06006217 RID: 25111 RVA: 0x00188699 File Offset: 0x00186899
	protected virtual bool OnInit()
	{
		return true;
	}

	// Token: 0x06006218 RID: 25112 RVA: 0x0018869C File Offset: 0x0018689C
	protected virtual bool OnClear()
	{
		return true;
	}

	// Token: 0x1700074A RID: 1866
	// (get) Token: 0x06006219 RID: 25113 RVA: 0x0018869F File Offset: 0x0018689F
	public EKscGameplayType GameplayType
	{
		get
		{
			return this.KscGameplayType;
		}
	}

	// Token: 0x0600621A RID: 25114 RVA: 0x001886A7 File Offset: 0x001868A7
	public void SetLogicProxy(long creatureId, int kscEntityId)
	{
		this.LogicProxy[creatureId] = kscEntityId;
	}

	// Token: 0x0600621B RID: 25115 RVA: 0x001886B8 File Offset: 0x001868B8
	public int? GetLogicProxy(long creatureId)
	{
		if (this.LogicProxy == null || this.LogicProxy.Count == 0)
		{
			return null;
		}
		int value;
		if (!this.LogicProxy.TryGetValue(creatureId, out value))
		{
			return null;
		}
		return new int?(value);
	}

	// Token: 0x0600621C RID: 25116 RVA: 0x00188704 File Offset: 0x00186904
	public KscEntityHandle GetKscEntityHandle(long creatureId)
	{
		int? logicProxy = this.GetLogicProxy(creatureId);
		if (logicProxy == null)
		{
			return null;
		}
		KscEntityHandle result;
		if (!this.KscEntities.TryGetValue(logicProxy.Value, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600621D RID: 25117 RVA: 0x0018873D File Offset: 0x0018693D
	public bool RemoveLogicProxy(long creatureId)
	{
		return this.LogicProxy.Remove(creatureId);
	}

	// Token: 0x0600621E RID: 25118 RVA: 0x0018874B File Offset: 0x0018694B
	public List<long> GetAllEntityIds()
	{
		return new List<long>(this.LogicProxy.Keys);
	}

	// Token: 0x0600621F RID: 25119 RVA: 0x00188760 File Offset: 0x00186960
	public long GetEntityCreatureId(int kscEntityId)
	{
		KscEntityHandle kscEntityHandle;
		if (this.KscEntities.TryGetValue(kscEntityId, out kscEntityHandle) && kscEntityHandle != null && kscEntityHandle.Valid)
		{
			return kscEntityHandle.CreatureDataId;
		}
		return 0L;
	}

	// Token: 0x06006220 RID: 25120 RVA: 0x00188794 File Offset: 0x00186994
	public string GetEntityPathById(int id)
	{
		ValueTuple<FKSCEntityTableRow, string> valueTuple;
		if (this.EntityDataDt.TryGetValue(id, out valueTuple))
		{
			return valueTuple.Item2;
		}
		return null;
	}

	// Token: 0x06006221 RID: 25121 RVA: 0x001887BC File Offset: 0x001869BC
	public void SetKscPlayerEntity(AKSC_Entity kscPlayerEntity, long creatureDataId)
	{
		this.KscPlayerEntity = kscPlayerEntity;
		this.NextPlayerHpSyncTime = 0f;
		this.IsHpModify = false;
		if (kscPlayerEntity == null)
		{
			this.KscPlayerEntityId = 0;
			this.KscPlayerCreatureDataId = 0L;
			this.KscPlayerHeadStateData = null;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnKscPlayerHpChanged);
			return;
		}
		this.KscPlayerEntityId = kscPlayerEntity.EntityId_;
		this.KscPlayerCreatureDataId = creatureDataId;
		this.KscPlayerHeadStateData = new KscHeadStateData();
		this.KscPlayerHeadStateData.EntityId = this.KscPlayerEntityId;
		UKSC_SkillComp skillComp = kscPlayerEntity.GetSkillComp();
		TMap<EKSC_AttrType, int> tmap;
		if (skillComp == null)
		{
			tmap = null;
		}
		else
		{
			UKSC_AttrSet attrSet_ = skillComp.AttrSet_;
			tmap = ((attrSet_ != null) ? attrSet_.Attrs_ : null);
		}
		TMap<EKSC_AttrType, int> tmap2 = tmap;
		if (tmap2 != null)
		{
			this.KscPlayerHeadStateData.MaxHp = tmap2.GetValueOrDefault(EKSC_AttrType.LifeMax, 0);
			this.KscPlayerHeadStateData.Hp = tmap2.GetValueOrDefault(EKSC_AttrType.Life, 0);
			this.KscPlayerHeadStateData.Shield = tmap2.GetValueOrDefault(EKSC_AttrType.Shield, 0);
		}
		else
		{
			this.KscPlayerHeadStateData.MaxHp = 0;
			this.KscPlayerHeadStateData.Hp = 0;
			this.KscPlayerHeadStateData.Shield = 0;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnKscPlayerHpChanged);
	}

	// Token: 0x06006222 RID: 25122 RVA: 0x001888CC File Offset: 0x00186ACC
	public bool IsMapLoadOrWorldDone()
	{
		return this.KscInitState == EKscInitState.MapLoad || this.KscInitState == EKscInitState.WorldDone;
	}

	// Token: 0x06006223 RID: 25123 RVA: 0x001888E2 File Offset: 0x00186AE2
	public virtual bool IsCreatureIdValid(int creatureId)
	{
		return false;
	}

	// Token: 0x04002EEE RID: 12014
	public EKscGameplayType KscGameplayType;

	// Token: 0x04002EEF RID: 12015
	public readonly Dictionary<int, KSCBaseProperty> PropertyConfigs = new Dictionary<int, KSCBaseProperty>();

	// Token: 0x04002EF0 RID: 12016
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})]
	public readonly Dictionary<int, ValueTuple<FKSCSkillTableRow, string>> SkillDataDt = new Dictionary<int, ValueTuple<FKSCSkillTableRow, string>>();

	// Token: 0x04002EF1 RID: 12017
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})]
	public readonly Dictionary<int, ValueTuple<FKSCEntityTableRow, string>> EntityDataDt = new Dictionary<int, ValueTuple<FKSCEntityTableRow, string>>();

	// Token: 0x04002EF2 RID: 12018
	private readonly Dictionary<long, int> LogicProxy = new Dictionary<long, int>();

	// Token: 0x04002EF3 RID: 12019
	public readonly UiAsyncTaskManager EntityProcessMgr = new UiAsyncTaskManager();

	// Token: 0x04002EF4 RID: 12020
	public Dictionary<int, KscEntityHandle> KscEntities = new Dictionary<int, KscEntityHandle>();

	// Token: 0x04002EF5 RID: 12021
	public Dictionary<int, FKSCDamage> DamageIds = new Dictionary<int, FKSCDamage>();

	// Token: 0x04002EF6 RID: 12022
	[Nullable(2)]
	public UKuroFastCollisionAlgorithm KfcAlgorithm;

	// Token: 0x04002EF7 RID: 12023
	public AKSC_Entity KscPlayerEntity;

	// Token: 0x04002EF8 RID: 12024
	public long KscPlayerCreatureDataId;

	// Token: 0x04002EF9 RID: 12025
	public int KscPlayerEntityId;

	// Token: 0x04002EFA RID: 12026
	public KscHeadStateData KscPlayerHeadStateData;

	// Token: 0x04002EFB RID: 12027
	public float NextPlayerHpSyncTime;

	// Token: 0x04002EFC RID: 12028
	public bool IsHpModify;

	// Token: 0x04002EFD RID: 12029
	public EKscInitState KscInitState;
}
