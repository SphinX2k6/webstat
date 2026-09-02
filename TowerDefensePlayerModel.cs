using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.KuroSimpleCombat;
using UnrealEngine;

// Token: 0x02000F90 RID: 3984
[NullableContext(2)]
[Nullable(0)]
public class TowerDefensePlayerModel
{
	// Token: 0x170007DF RID: 2015
	// (get) Token: 0x06006593 RID: 26003 RVA: 0x001987EC File Offset: 0x001969EC
	public AKSC_Entity_AssistMachine PossessedFollowerKscEntity
	{
		get
		{
			KscEntityHandle possessedFollowerHandle = this.PossessedFollowerHandle;
			if (possessedFollowerHandle == null || !possessedFollowerHandle.Valid)
			{
				KscLog.EModule flag = KscLog.EModule.Common;
				ELogAuthor author = ELogAuthor.PZ;
				UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
				string log = "塔防跟随物异常";
				string item = "possessed player";
				KscEntityHandle possessedPlayerHandle = this.PossessedPlayerHandle;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (possessedPlayerHandle != null) ? possessedPlayerHandle.KscEntity : null);
				KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			AKSC_Entity_AssistMachine aksc_Entity_AssistMachine = this.PossessedFollowerHandle.KscEntity as AKSC_Entity_AssistMachine;
			if (aksc_Entity_AssistMachine == null)
			{
				KscLog.EModule flag2 = KscLog.EModule.Common;
				ELogAuthor author2 = ELogAuthor.PZ;
				UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
				string log2 = "塔防跟随物类型异常";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("possessed follower", aksc_Entity_AssistMachine);
				KscLog.Warn(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			return aksc_Entity_AssistMachine;
		}
	}

	// Token: 0x170007E0 RID: 2016
	// (get) Token: 0x06006594 RID: 26004 RVA: 0x00198890 File Offset: 0x00196A90
	public Entity PossessedFollowerEntity
	{
		get
		{
			KscEntityHandle possessedFollowerHandle = this.PossessedFollowerHandle;
			long? num = (possessedFollowerHandle != null) ? new long?(possessedFollowerHandle.CreatureDataId) : null;
			if (num == null || num.Value == 0L)
			{
				KscLog.EModule flag = KscLog.EModule.Common;
				ELogAuthor author = ELogAuthor.PZ;
				UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
				string log = "塔防跟随物实体异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("creature Id", num);
				KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num.Value);
			if (entity == null)
			{
				KscLog.EModule flag2 = KscLog.EModule.Common;
				ELogAuthor author2 = ELogAuthor.PZ;
				UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
				string log2 = "塔防跟随物实体异常";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("creature Id", num);
				KscLog.Warn(flag2, author2, kscWorld2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return null;
			}
			return entity.Entity;
		}
	}

	// Token: 0x170007E1 RID: 2017
	// (get) Token: 0x06006595 RID: 26005 RVA: 0x00198950 File Offset: 0x00196B50
	public bool PossessedFollowerEnabled
	{
		get
		{
			Entity possessedFollowerEntity = this.PossessedFollowerEntity;
			if (possessedFollowerEntity == null)
			{
				return false;
			}
			bool flag = possessedFollowerEntity.HasDisableKey(EEntityDisableKey.SetEntityEnable);
			KscLog.EModule flag2 = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.PZ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "塔防辅助机是否激活";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("disabled", flag);
			KscLog.Debug(flag2, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return !flag;
		}
	}

	// Token: 0x170007E2 RID: 2018
	// (get) Token: 0x06006596 RID: 26006 RVA: 0x001989A5 File Offset: 0x00196BA5
	public AActor PossessedFollowerActor
	{
		get
		{
			Entity possessedFollowerEntity = this.PossessedFollowerEntity;
			CharacterActorComponent characterActorComponent = (possessedFollowerEntity != null) ? possessedFollowerEntity.GetComponent<CharacterActorComponent>() : null;
			if (characterActorComponent == null)
			{
				return null;
			}
			return characterActorComponent.Actor;
		}
	}

	// Token: 0x06006597 RID: 26007 RVA: 0x001989C4 File Offset: 0x00196BC4
	public bool OnStop()
	{
		this.PendingRoleHandle = null;
		this.PossessedPlayerHandle = null;
		this.PendingFollowerCreatureId = null;
		this.PendingFollowers = null;
		this.PossessedFollowerHandle = null;
		this.PossessedFollowerProxies = null;
		this.CurrentFollowerProxyId = null;
		this.CurrentFollowerEnable = false;
		this.BindFollowerSkills = null;
		this.SkillId2SkillData = null;
		this.ChargeSkill = null;
		this.LastSkillChargeFull = false;
		this.ChargeCueHandle = 0;
		this.FollowCueHandle = null;
		this.IsInAutoCast = false;
		this.IsInCharge = false;
		this.FollowerCdCueHandle = null;
		this.FollowerState = TDPlayerDefine.EFollowerState.None;
		this.PsFeedbackId = null;
		this.TowerDefenseWorldDone = false;
		this.HasInitKSCEntity = false;
		this.AllSkillId2SkillData = null;
		this.IsInFollowerInit = false;
		return true;
	}

	// Token: 0x04003040 RID: 12352
	public static readonly int PlayerEntityKey = 1001;

	// Token: 0x04003041 RID: 12353
	public static readonly int FollowerEntityKey = 1002;

	// Token: 0x04003042 RID: 12354
	public bool TowerDefenseWorldDone;

	// Token: 0x04003043 RID: 12355
	public bool HasInitKSCEntity;

	// Token: 0x04003044 RID: 12356
	public EntityHandle PendingRoleHandle;

	// Token: 0x04003045 RID: 12357
	public KscEntityHandle PossessedPlayerHandle;

	// Token: 0x04003046 RID: 12358
	public long? PendingFollowerCreatureId;

	// Token: 0x04003047 RID: 12359
	public int[] PendingFollowers;

	// Token: 0x04003048 RID: 12360
	public KscEntityHandle PossessedFollowerHandle;

	// Token: 0x04003049 RID: 12361
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, TowerDefenseFollowerProxy> PossessedFollowerProxies;

	// Token: 0x0400304A RID: 12362
	public int? CurrentFollowerProxyId;

	// Token: 0x0400304B RID: 12363
	public bool CurrentFollowerEnable;

	// Token: 0x0400304C RID: 12364
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, TDPlayerDefine.ISkill> AllSkillId2SkillData;

	// Token: 0x0400304D RID: 12365
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Dictionary<EKSC_OperateType, List<TDPlayerDefine.ISkill>> BindFollowerSkills;

	// Token: 0x0400304E RID: 12366
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, TDPlayerDefine.ISkill> SkillId2SkillData;

	// Token: 0x0400304F RID: 12367
	public TDPlayerDefine.ISkill ChargeSkill;

	// Token: 0x04003050 RID: 12368
	public bool LastSkillChargeFull;

	// Token: 0x04003051 RID: 12369
	public int ChargeCueHandle;

	// Token: 0x04003052 RID: 12370
	public List<int> FollowCueHandle;

	// Token: 0x04003053 RID: 12371
	public List<int> FollowerCdCueHandle;

	// Token: 0x04003054 RID: 12372
	public TDPlayerDefine.EFollowerState FollowerState;

	// Token: 0x04003055 RID: 12373
	public string PsFeedbackId;

	// Token: 0x04003056 RID: 12374
	public bool IsInAutoCast;

	// Token: 0x04003057 RID: 12375
	public bool IsInCharge;

	// Token: 0x04003058 RID: 12376
	public bool IsInFollowerInit;
}
