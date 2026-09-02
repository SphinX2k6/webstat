using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002DB7 RID: 11703
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class BulletController : ControllerBase<BulletController>
{
	// Token: 0x06017993 RID: 96659 RVA: 0x00690354 File Offset: 0x0068E554
	protected override bool OnInit()
	{
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			Singleton<BulletConstant>.Instance.OpenCreateLog = true;
			Singleton<BulletConstant>.Instance.OpenActionStat = true;
		}
		BulletActionRunner.InitStat();
		if (this.ActionRunner == null)
		{
			this.ActionRunner = new BulletActionRunner();
		}
		this.ActionRunner.Init();
		BulletPool.Init();
		this.SystemList.Clear();
		this.SystemList.Add(new BulletMoveSystem());
		this.SystemList.Add(new BulletCollisionSystem());
		this.OnAddEvents();
		return true;
	}

	// Token: 0x06017994 RID: 96660 RVA: 0x006903E0 File Offset: 0x0068E5E0
	protected override void OnTick(float delta)
	{
		if (this.ActionRunner == null)
		{
			return;
		}
		this.ActionRunner.Pause();
		foreach (BulletSystemBase bulletSystemBase in this.SystemList)
		{
			bulletSystemBase.OnTick(delta);
		}
		this.ActionRunner.Resume();
		this.ActionRunner.Run(delta, false);
		ConfigBase<BulletConfig>.Instance.TickPreload();
	}

	// Token: 0x06017995 RID: 96661 RVA: 0x00690468 File Offset: 0x0068E668
	protected override void OnAfterTick(float delta)
	{
		ModelBase<BulletModel>.Instance.ProcessKuroBulletPendingOperation();
		if (this.SystemList == null || this.ActionRunner == null)
		{
			return;
		}
		this.ActionRunner.Pause();
		foreach (BulletSystemBase bulletSystemBase in this.SystemList)
		{
			bulletSystemBase.OnAfterTick(delta);
		}
		this.ActionRunner.Resume();
		this.ActionRunner.Run(delta, true);
		BulletPool.CheckAtFrameEnd();
	}

	// Token: 0x06017996 RID: 96662 RVA: 0x006904FC File Offset: 0x0068E6FC
	protected override bool OnClear()
	{
		this.ActionRunner.Clear();
		this.OnRemoveEvents();
		BulletPool.Clear();
		this.SystemList.Clear();
		return true;
	}

	// Token: 0x06017997 RID: 96663 RVA: 0x00690520 File Offset: 0x0068E720
	protected override bool OnLeaveLevel()
	{
		ConfigBase<BulletConfig>.Instance.ClearBulletDataCache();
		ConfigBase<BulletConfig>.Instance.ClearPreload();
		return true;
	}

	// Token: 0x06017998 RID: 96664 RVA: 0x00690537 File Offset: 0x0068E737
	public BulletActionCenter GetActionCenter()
	{
		return this.ActionRunner.GetActionCenter();
	}

	// Token: 0x06017999 RID: 96665 RVA: 0x00690544 File Offset: 0x0068E744
	public BulletActionRunner GetActionRunner()
	{
		return this.ActionRunner;
	}

	// Token: 0x0601799A RID: 96666 RVA: 0x0069054C File Offset: 0x0068E74C
	private void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd));
		Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		Singleton<EventSystem>.Instance.Add(EEventName.SetNiagaraQuality, new Action(this.OnSetNiagaraQuality));
	}

	// Token: 0x0601799B RID: 96667 RVA: 0x006905AC File Offset: 0x0068E7AC
	private void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd));
		Singleton<EventSystem>.Instance.Remove<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		Singleton<EventSystem>.Instance.Remove(EEventName.SetNiagaraQuality, new Action(this.OnSetNiagaraQuality));
	}

	// Token: 0x0601799C RID: 96668 RVA: 0x0069060C File Offset: 0x0068E80C
	private void OnSkillEnd(int entityId, int skillId)
	{
		if (skillId == 0)
		{
			return;
		}
		IReadOnlyCollection<BulletEntity> bulletSetByAttacker = ModelBase<BulletModel>.Instance.GetBulletSetByAttacker(entityId);
		if (bulletSetByAttacker == null)
		{
			return;
		}
		List<BulletEntity> list = new List<BulletEntity>();
		foreach (BulletEntity bulletEntity in bulletSetByAttacker)
		{
			BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
			if (skillId == bulletInfo.BulletInitParams.SkillId)
			{
				BulletDataMain bulletDataMain = bulletInfo.BulletDataMain;
				if (bulletDataMain.Move.IsDetachOnSkillEnd)
				{
					bulletInfo.Actor.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
				}
				if (bulletDataMain.Base.DestroyOnSkillEnd)
				{
					list.Add(bulletEntity);
				}
			}
		}
		foreach (BulletEntity bulletEntity2 in list)
		{
			bulletEntity2.GetBulletInfo().IsDestroyByCharSkillEnd = true;
			this.DestroyBullet(bulletEntity2.Id, false, EBulletDestroyReason.Normal, false);
		}
	}

	// Token: 0x0601799D RID: 96669 RVA: 0x0069070C File Offset: 0x0068E90C
	private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		ConfigBase<BulletConfig>.Instance.RemoveCacheBulletDataByEntityId(handle.Id);
	}

	// Token: 0x0601799E RID: 96670 RVA: 0x00690720 File Offset: 0x0068E920
	private void OnSetNiagaraQuality()
	{
		foreach (BulletEntity bulletEntity in ModelBase<BulletModel>.Instance.GetBulletEntityMap().Values)
		{
			BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
			if (!bulletInfo.NeedDestroy)
			{
				BulletStaticFunction.UpdateEffectQualityLevel(bulletInfo);
			}
		}
	}

	// Token: 0x0601799F RID: 96671 RVA: 0x00690788 File Offset: 0x0068E988
	[NullableContext(2)]
	public bool HasAuthority(Entity owner)
	{
		object obj;
		if (owner == null)
		{
			obj = null;
		}
		else
		{
			BaseActorComponent component = owner.GetComponent<BaseActorComponent>();
			obj = ((component != null) ? component.Owner : null);
		}
		object obj2 = obj;
		return obj2 != null && obj2.IsAutonomousProxy();
	}

	// Token: 0x060179A0 RID: 96672 RVA: 0x006907AD File Offset: 0x0068E9AD
	[NullableContext(2)]
	public bool HasAuthority(TsBaseCharacter owner)
	{
		return owner != null && owner.IsAutonomousProxy();
	}

	// Token: 0x060179A1 RID: 96673 RVA: 0x006907BA File Offset: 0x0068E9BA
	private void CreateBulletStatStart(string bulletRowName)
	{
	}

	// Token: 0x060179A2 RID: 96674 RVA: 0x006907BC File Offset: 0x0068E9BC
	private void CreateBulletStatSop(string bulletRowName)
	{
	}

	// Token: 0x060179A3 RID: 96675 RVA: 0x006907BE File Offset: 0x0068E9BE
	[return: Nullable(2)]
	public BulletEntity CreateBulletCustomTarget([Nullable(2)] Entity owner, string bulletRowName, FTransformDouble? initialTransform, BulletController.BulletCreateParams bulletCreateParams = null, long? contextId = null, global::EBulletCreateSource createSource = global::EBulletCreateSource.Others)
	{
		return this.CreateBulletCustomTargetInternal(owner, bulletRowName, initialTransform, bulletCreateParams, contextId, createSource);
	}

	// Token: 0x060179A4 RID: 96676 RVA: 0x006907D0 File Offset: 0x0068E9D0
	[return: Nullable(2)]
	public BulletEntity CreateBulletCustomTarget([Nullable(2)] TsBaseCharacter owner, string bulletRowName, FTransformDouble? initialTransform, BulletController.BulletCreateParams bulletCreateParams = null, long? contextId = null, global::EBulletCreateSource createSource = global::EBulletCreateSource.Others)
	{
		Entity owner2 = (owner != null) ? owner.GetEntityNoBlueprint() : null;
		return this.CreateBulletCustomTargetInternal(owner2, bulletRowName, initialTransform, bulletCreateParams, contextId, createSource);
	}

	// Token: 0x060179A5 RID: 96677 RVA: 0x006907FC File Offset: 0x0068E9FC
	[return: Nullable(2)]
	private unsafe BulletEntity CreateBulletCustomTargetInternal([Nullable(2)] Entity owner, string bulletRowName, FTransformDouble? initialTransform, BulletController.BulletCreateParams bulletCreateParams, long? contextId, global::EBulletCreateSource createSource)
	{
		if (bulletCreateParams == null)
		{
			bulletCreateParams = new BulletController.BulletCreateParams();
		}
		if (!ModelBase<GameModeModel>.Instance.WorldDone)
		{
			return null;
		}
		this.CreateBulletStatStart(bulletRowName);
		if (owner == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "创建子弹时Owner为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("rowName", bulletRowName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		if (contextId == null && !SpecialIgnoreBullet.CheckBulletInSpecialList(bulletRowName))
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Bullet;
			Entity entity = null;
			string message2 = "创建子弹时contextId为空";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("rowName", bulletRowName);
			instance2.Error(flag, entity, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.CreateBulletStatSop(bulletRowName);
			return null;
		}
		BulletDataMain bulletData = ConfigBase<BulletConfig>.Instance.GetBulletData(owner, bulletRowName, true);
		if (bulletData == null)
		{
			this.CreateBulletStatSop(bulletRowName);
			return null;
		}
		if (createSource == global::EBulletCreateSource.Skill && bulletData.Base.DestroyOnSkillEnd)
		{
			BaseSkillComponent component = owner.GetComponent<BaseSkillComponent>();
			if (component == null || !component.Valid)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Bullet;
				ELogAuthor author2 = ELogAuthor.HCW;
				string message3 = "勾选了技能结束是否销毁子弹, 技能组件不存在";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("bulletRowName", bulletRowName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SkillId", bulletCreateParams.SkillId);
				instance3.Error(module2, author2, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.CreateBulletStatSop(bulletRowName);
				return null;
			}
			Skill skill = component.GetSkill(bulletCreateParams.SkillId);
			if (skill == null || !skill.Active)
			{
				this.CreateBulletStatSop(bulletRowName);
				return null;
			}
		}
		global::EBulletSyncType ebulletSyncType = this.ModSyncType(bulletCreateParams.SyncType, bulletData);
		if (bulletCreateParams.CreateOnAuthority && ebulletSyncType == global::EBulletSyncType.SyncCreate && !this.HasAuthority(owner))
		{
			this.CreateBulletStatSop(bulletRowName);
			return null;
		}
		int valueOrDefault = bulletCreateParams.ParentVictimId.GetValueOrDefault();
		int valueOrDefault2 = bulletCreateParams.ParentTargetId.GetValueOrDefault();
		int targetId = this.GetTargetId(owner, bulletData, bulletRowName, valueOrDefault, valueOrDefault2);
		int baseVelocityId = this.GetBaseVelocityId(owner, bulletData, bulletRowName, valueOrDefault, valueOrDefault2);
		int baseTransformId = this.GetBaseTransformId(owner, bulletData, bulletRowName, valueOrDefault, valueOrDefault2);
		bulletCreateParams.SyncType = ebulletSyncType;
		bulletCreateParams.BulletData = bulletData;
		bulletCreateParams.TargetId = new int?(targetId);
		bulletCreateParams.BaseTransformId = new int?(baseTransformId);
		bulletCreateParams.BaseVelocityId = new int?(baseVelocityId);
		BulletEntity result = this.CreateBullet(owner, bulletRowName, initialTransform, bulletCreateParams, contextId, createSource);
		this.CreateBulletStatSop(bulletRowName);
		return result;
	}

	// Token: 0x060179A6 RID: 96678 RVA: 0x00690A34 File Offset: 0x0068EC34
	private int GetBaseTransformId(Entity ownerEntity, BulletDataMain data, string bulletRowName, int parentVictimId, int parentTargetId)
	{
		EPositionStandard bornPositionStandard = data.Base.BornPositionStandard;
		if (EPositionStandard.技能目标位置 == bornPositionStandard)
		{
			return this.FindSkillTarget(ownerEntity, bulletRowName);
		}
		if (EPositionStandard.自定义目标 == bornPositionStandard)
		{
			return ModelBase<BulletModel>.Instance.GetEntityIdByCustomKey(ownerEntity.Id, data.Base.BlackboardKey, bulletRowName);
		}
		if (EPositionStandard.父子弹受击者 == bornPositionStandard)
		{
			return parentVictimId;
		}
		if (EPositionStandard.父子弹目标 == bornPositionStandard)
		{
			return parentTargetId;
		}
		if (EPositionStandard.伴生物 == bornPositionStandard || EPositionStandard.伴生物位置和朝向 == bornPositionStandard)
		{
			int pos = int.Parse(data.Base.BlackboardKey);
			return this.GetCustomEntityId(ownerEntity, pos, bulletRowName);
		}
		if (EPositionStandard.攻击者锁定目标位置 == bornPositionStandard)
		{
			CharacterLockOnComponent component = ownerEntity.GetComponent<CharacterLockOnComponent>();
			EntityHandle entityHandle = (component != null) ? component.GetCurrentTarget() : null;
			if (entityHandle != null && entityHandle.Valid)
			{
				return entityHandle.Id;
			}
		}
		else if (EPositionStandard.前台角色锁定目标 == bornPositionStandard)
		{
			return this.GetCurrentRoleLockOn();
		}
		return 0;
	}

	// Token: 0x060179A7 RID: 96679 RVA: 0x00690AE4 File Offset: 0x0068ECE4
	[NullableContext(2)]
	private global::EBulletSyncType ModSyncType(global::EBulletSyncType syncType, BulletDataMain data)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti && syncType == global::EBulletSyncType.Local)
		{
			if (data.Base.SyncType == EBulletSyncTypeTs.Remote)
			{
				return global::EBulletSyncType.SyncCreate;
			}
			EPositionStandard bornPositionStandard = data.Base.BornPositionStandard;
			if (bornPositionStandard == EPositionStandard.攻击者锁定目标位置 || bornPositionStandard == EPositionStandard.前台角色锁定目标 || bornPositionStandard == EPositionStandard.伴生物)
			{
				return global::EBulletSyncType.SyncCreate;
			}
			EInitialVelocityDirection initVelocityDirStandard = data.Move.InitVelocityDirStandard;
			if (initVelocityDirStandard == EInitialVelocityDirection.前台角色锁定目标 || initVelocityDirStandard == EInitialVelocityDirection.面向发射者锁定目标)
			{
				return global::EBulletSyncType.SyncCreate;
			}
			EBulletTarget trackTarget = data.Move.TrackTarget;
			if (trackTarget == EBulletTarget.攻击者锁定目标静态 || trackTarget == EBulletTarget.攻击者锁定目标动态)
			{
				return global::EBulletSyncType.SyncCreate;
			}
			BulletDataExecution execution = data.Execution;
			execution.InitGbGroup();
			if (execution.HasRebound)
			{
				return global::EBulletSyncType.SyncCreate;
			}
			if (execution.HasCollision)
			{
				return global::EBulletSyncType.SyncCreate;
			}
		}
		return syncType;
	}

	// Token: 0x060179A8 RID: 96680 RVA: 0x00690B7C File Offset: 0x0068ED7C
	public int CreateBulletForDebug(TsBaseCharacter owner, string bulletRowName)
	{
		Entity entityNoBlueprint = owner.GetEntityNoBlueprint();
		int entityId = (entityNoBlueprint != null) ? entityNoBlueprint.Id : 0;
		long creatureDataId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(entityId);
		ChatRequest chatRequest = new ChatRequest();
		chatRequest.ChannelId = 0;
		ChatRequest chatRequest2 = chatRequest;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 2);
		defaultInterpolatedStringHandler.AppendLiteral("@gmcreatebullet ");
		defaultInterpolatedStringHandler.AppendFormatted<long>(creatureDataId);
		defaultInterpolatedStringHandler.AppendLiteral(" ");
		defaultInterpolatedStringHandler.AppendFormatted(bulletRowName);
		chatRequest2.Content = defaultInterpolatedStringHandler.ToStringAndClear();
		Singleton<Net>.Instance.Call<ChatResponse>(ERequestMessageId.ChatRequest, chatRequest, delegate(ChatResponse response, Net.CallbackStatus status)
		{
		}, 0);
		return 0;
	}

	// Token: 0x060179A9 RID: 96681 RVA: 0x00690C28 File Offset: 0x0068EE28
	private int GetTargetId(Entity owner, BulletDataMain data, string bulletRowName, int parentVictimId, int parentTargetId)
	{
		EBulletTarget trackTarget = data.Move.TrackTarget;
		if (trackTarget == EBulletTarget.攻击者锁定目标静态 || trackTarget == EBulletTarget.攻击者锁定目标动态)
		{
			CharacterLockOnComponent component = owner.GetComponent<CharacterLockOnComponent>();
			EntityHandle entityHandle = (component != null) ? component.GetCurrentTarget() : null;
			if (entityHandle != null && entityHandle.Valid)
			{
				return entityHandle.Id;
			}
		}
		else
		{
			if (trackTarget == EBulletTarget.自定义目标)
			{
				return ModelBase<BulletModel>.Instance.GetEntityIdByCustomKey(owner.Id, data.Move.TrackTargetBlackboardKey, bulletRowName);
			}
			if (trackTarget == EBulletTarget.父子弹受击者)
			{
				if (parentVictimId != 0)
				{
					return parentVictimId;
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Bullet;
				ELogAuthor author = ELogAuthor.HCW;
				string message = "父子弹受击者 VictimId为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("rowName", bulletRowName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else if (trackTarget == EBulletTarget.父子弹目标)
			{
				if (parentTargetId != 0)
				{
					return parentTargetId;
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Bullet;
				ELogAuthor author2 = ELogAuthor.HCW;
				string message2 = "父子弹目标为空";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("rowName", bulletRowName);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			else
			{
				if (trackTarget == EBulletTarget.子弹发射者)
				{
					return owner.Id;
				}
				if (trackTarget == EBulletTarget.技能目标 || trackTarget == EBulletTarget.技能目标前台)
				{
					return this.FindSkillTarget(owner, bulletRowName);
				}
				if (trackTarget == EBulletTarget.队伍角色)
				{
					if (!ModelBase<GameModeModel>.Instance.IsMulti)
					{
						return Global.BaseCharacter.GetEntityIdNoBlueprint();
					}
					CreatureDataComponent component2 = owner.GetComponent<CreatureDataComponent>();
					EntityHandle entityHandle2 = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)component2.GetPlayerId(), new GetTeamItemOptions
					{
						ParamType = ETeamParamType.PlayerId,
						IsControl = new bool?(true)
					}).EntityHandle;
					if (entityHandle2 != null && entityHandle2.Valid)
					{
						return entityHandle2.Id;
					}
				}
				else if (trackTarget == EBulletTarget.前台角色锁定目标)
				{
					return this.GetCurrentRoleLockOn();
				}
			}
		}
		return 0;
	}

	// Token: 0x060179AA RID: 96682 RVA: 0x00690D98 File Offset: 0x0068EF98
	private int FindSkillTarget(Entity owner, string rowName)
	{
		BaseSkillComponent component = owner.GetComponent<BaseSkillComponent>();
		EntityHandle entityHandle = (component != null) ? component.SkillTarget : null;
		bool openCreateLog = Singleton<BulletConstant>.Instance.OpenCreateLog;
		if (entityHandle != null && entityHandle.Valid)
		{
			return entityHandle.Id;
		}
		return 0;
	}

	// Token: 0x060179AB RID: 96683 RVA: 0x00690DD8 File Offset: 0x0068EFD8
	private int GetCurrentRoleLockOn()
	{
		CharacterLockOnComponent component = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<CharacterLockOnComponent>();
		EntityHandle entityHandle = (component != null) ? component.GetCurrentTarget() : null;
		if (entityHandle != null && entityHandle.Valid)
		{
			return entityHandle.Id;
		}
		return 0;
	}

	// Token: 0x060179AC RID: 96684 RVA: 0x00690E1C File Offset: 0x0068F01C
	private int GetBaseVelocityId(Entity owner, BulletDataMain data, string bulletRowName, int parentVictim, int parentTarget)
	{
		EInitialVelocityDirection initVelocityDirStandard = data.Move.InitVelocityDirStandard;
		if (initVelocityDirStandard == EInitialVelocityDirection.面向发射者锁定目标)
		{
			CharacterLockOnComponent component = owner.GetComponent<CharacterLockOnComponent>();
			EntityHandle entityHandle = (component != null) ? component.GetCurrentTarget() : null;
			if (entityHandle != null && entityHandle.Valid)
			{
				return entityHandle.Id;
			}
		}
		else
		{
			if (initVelocityDirStandard == EInitialVelocityDirection.面向自定义目标)
			{
				return ModelBase<BulletModel>.Instance.GetEntityIdByCustomKey(owner.Id, data.Move.TrackTargetBlackboardKey, bulletRowName);
			}
			if (initVelocityDirStandard == EInitialVelocityDirection.伴生物 || initVelocityDirStandard == EInitialVelocityDirection.伴生物朝向)
			{
				int pos = int.Parse(data.Move.InitVelocityDirParam);
				return this.GetCustomEntityId(owner, pos, bulletRowName);
			}
			if (initVelocityDirStandard == EInitialVelocityDirection.前台角色锁定目标)
			{
				return this.GetCurrentRoleLockOn();
			}
			if (initVelocityDirStandard == EInitialVelocityDirection.父子弹受击者)
			{
				return parentVictim;
			}
			if (initVelocityDirStandard == EInitialVelocityDirection.父子弹目标)
			{
				return parentTarget;
			}
		}
		return 0;
	}

	// Token: 0x060179AD RID: 96685 RVA: 0x00690EC0 File Offset: 0x0068F0C0
	[return: Nullable(2)]
	private BulletEntity CreateBullet(Entity owner, string bulletRowName, FTransformDouble? initialTransform, BulletController.BulletCreateParams bulletCreateParams, long? contextId = null, global::EBulletCreateSource createSource = global::EBulletCreateSource.Others)
	{
		bool fromRemote = bulletCreateParams.SyncType == global::EBulletSyncType.SyncFromRemote;
		BulletEntity bulletEntity = ModelBase<BulletModel>.Instance.CreateBullet(owner, bulletRowName, initialTransform, bulletCreateParams.InitTargetLocation, bulletCreateParams.SkillId, new int?(bulletCreateParams.ParentId), fromRemote, bulletCreateParams.TargetId.GetValueOrDefault(), bulletCreateParams.BaseTransformId, bulletCreateParams.BaseVelocityId, bulletCreateParams.Size, bulletCreateParams.BulletData, bulletCreateParams.SyncType, contextId, bulletCreateParams.SkillContextId, bulletCreateParams.Source, bulletCreateParams.LocationOffset, bulletCreateParams.BeginRotatorOffset, bulletCreateParams.RandomPosOffset, bulletCreateParams.RandomInitSpeedOffset, bulletCreateParams.BattleContext, bulletCreateParams.ParentIds, createSource);
		if (bulletEntity == null || !bulletEntity.Valid)
		{
			return null;
		}
		return bulletEntity;
	}

	// Token: 0x060179AE RID: 96686 RVA: 0x00690F80 File Offset: 0x0068F180
	public void DestroyBullet(int id, bool summonChild, EBulletDestroyReason destroyReason = EBulletDestroyReason.Normal, bool destroyEffectImmediately = false)
	{
		ModelBase<BulletModel>.Instance.DestroyBullet(id, summonChild, destroyReason, destroyEffectImmediately);
	}

	// Token: 0x060179AF RID: 96687 RVA: 0x00690F91 File Offset: 0x0068F191
	public void DestroyAllBullet(bool summonChild = false)
	{
		ModelBase<BulletModel>.Instance.DestroyAllBullet(summonChild);
	}

	// Token: 0x060179B0 RID: 96688 RVA: 0x00690FA0 File Offset: 0x0068F1A0
	public void DestroySpecifiedBullet(int ownerId, FName bulletName, bool summonChild = false, int includeTeammate = 0, float interval = 0f)
	{
		if (includeTeammate == 1)
		{
			bool flag = false;
			List<EntityHandle> teamEntities = ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true);
			using (List<EntityHandle>.Enumerator enumerator = teamEntities.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Id == ownerId)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				return;
			}
			using (List<EntityHandle>.Enumerator enumerator = teamEntities.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					EntityHandle entityHandle = enumerator.Current;
					this.DestroyBulletByOwnerIdAndName(entityHandle.Id, bulletName, summonChild, interval);
				}
				return;
			}
		}
		this.DestroyBulletByOwnerIdAndName(ownerId, bulletName, summonChild, interval);
	}

	// Token: 0x060179B1 RID: 96689 RVA: 0x0069105C File Offset: 0x0068F25C
	public void DestroyBulletByOwnerIdAndName(int ownerId, FName bulletName, bool summonChild = false, float interval = 0f)
	{
		IReadOnlyCollection<BulletEntity> bulletSetByAttacker = ModelBase<BulletModel>.Instance.GetBulletSetByAttacker(ownerId);
		if (bulletSetByAttacker != null)
		{
			List<BulletEntity> list = new List<BulletEntity>();
			foreach (BulletEntity bulletEntity in bulletSetByAttacker)
			{
				BulletDataMain bulletDataMain = bulletEntity.GetBulletInfo().BulletDataMain;
				if (bulletDataMain != null && bulletDataMain.BulletFName == bulletName)
				{
					list.Add(bulletEntity);
				}
			}
			if (interval <= 0f)
			{
				using (List<BulletEntity>.Enumerator enumerator2 = list.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						BulletEntity bulletEntity2 = enumerator2.Current;
						this.DestroyBullet(bulletEntity2.Id, summonChild, EBulletDestroyReason.Normal, false);
					}
					return;
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				this.DelayDestroyBullet(list[i].GetBulletInfo(), summonChild, (float)i * interval);
			}
		}
	}

	// Token: 0x060179B2 RID: 96690 RVA: 0x0069115C File Offset: 0x0068F35C
	public unsafe void DelayDestroyBullet(BulletInfo bulletInfo, bool summonChild, float delayTime)
	{
		if (delayTime <= 0f)
		{
			this.DestroyBullet(bulletInfo.BulletEntityId, summonChild, EBulletDestroyReason.Normal, false);
			return;
		}
		BulletActionInfoDelayDestroyBullet bulletActionInfoDelayDestroyBullet = this.GetActionCenter().CreateBulletActionInfo(EBulletAction.DelayDestroyBullet) as BulletActionInfoDelayDestroyBullet;
		if (bulletActionInfoDelayDestroyBullet == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "创建延迟销毁子弹Action失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BulletId", bulletInfo.BulletRowName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", bulletInfo.BulletEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("delayTime", delayTime);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		bulletActionInfoDelayDestroyBullet.DelayTime = delayTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		bulletActionInfoDelayDestroyBullet.SummonChild = summonChild;
		bulletActionInfoDelayDestroyBullet.IgnoreBulletActorTimeScale = true;
		this.GetActionRunner().AddAction(bulletInfo, bulletActionInfoDelayDestroyBullet);
	}

	// Token: 0x060179B3 RID: 96691 RVA: 0x00691248 File Offset: 0x0068F448
	public int GetSpecifiedBulletCount(int ownerId, FName bulletName)
	{
		int num = 0;
		IReadOnlyCollection<BulletEntity> bulletSetByAttacker = ModelBase<BulletModel>.Instance.GetBulletSetByAttacker(ownerId);
		if (bulletSetByAttacker != null)
		{
			foreach (BulletEntity bulletEntity in bulletSetByAttacker)
			{
				BulletDataMain bulletDataMain = bulletEntity.GetBulletInfo().BulletDataMain;
				if (bulletDataMain != null && bulletDataMain.BulletFName == bulletName)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x060179B4 RID: 96692 RVA: 0x006912BC File Offset: 0x0068F4BC
	public void AddSimpleAction(BulletInfo bulletInfo, EBulletAction bulletActionType)
	{
		BulletActionInfoBase actionInfo = this.GetActionCenter().CreateBulletActionInfo(bulletActionType);
		this.ActionRunner.AddAction(bulletInfo, actionInfo);
	}

	// Token: 0x060179B5 RID: 96693 RVA: 0x006912E4 File Offset: 0x0068F4E4
	public void SetTimeDilation(float timeDilation)
	{
		foreach (OrderedSet<BulletEntity> orderedSet in ModelBase<BulletModel>.Instance.GetAttackerBulletIterator())
		{
			foreach (BulletEntity bulletEntity in orderedSet)
			{
				bulletEntity.SetTimeDilation(timeDilation);
			}
		}
	}

	// Token: 0x060179B6 RID: 96694 RVA: 0x00691368 File Offset: 0x0068F568
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.CreateBulletNotify, true, false)]
	public static void CreateBulletNotify(Entity owner, [Nullable(1)] CreateBulletNotify data, CombatCommon combatCommon = null)
	{
		if (!ModelBase<GameModeModel>.Instance.WorldDone)
		{
			return;
		}
		if (owner == null)
		{
			return;
		}
		int skillId = (int)data.SkillId;
		string text = data.BulletId.ToString();
		long? num = (data != null) ? new long?(data.LocationEntityId) : null;
		bool flag = false;
		if (num != null)
		{
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(Singleton<MathUtils>.Instance.LongToNumber(num.Value));
			if (entity != null && entity.Valid)
			{
				if (entity.IsInit)
				{
					FTransformDouble? targetSocketTransform = SkillUtils.GetTargetSocketTransform(entity.Entity, data.HitCase, ERelativeTransformSpace.RTS_World, "子弹" + text, ESocketTransformDefault.BaseActor);
					global::Transform tempTransform = ControllerBase<BulletController>.Instance.TempTransform;
					FTransformDouble ftransformDouble = targetSocketTransform.Value;
					tempTransform.FromUeTransform(ftransformDouble);
				}
				else
				{
					CreatureDataComponent component = entity.Entity.GetComponent<CreatureDataComponent>();
					global::Transform tempTransform2 = ControllerBase<BulletController>.Instance.TempTransform;
					FTransformDouble ftransformDouble = component.D_GetTransform();
					tempTransform2.FromUeTransform(ftransformDouble);
				}
				flag = true;
			}
		}
		if (!flag)
		{
			if (((data != null) ? data.Location : null) != null || ((data != null) ? data.Rotation : null) != null)
			{
				ControllerBase<BulletController>.Instance.TempTransform.Reset();
				Aki.Protocol.Vector location = data.Location;
				Aki.Protocol.Rotator rotation = data.Rotation;
				if (rotation != null)
				{
					ControllerBase<BulletController>.Instance.TempRotator.Set(rotation.Pitch, rotation.Yaw, rotation.Roll);
					ControllerBase<BulletController>.Instance.TempRotator.Quaternion(ControllerBase<BulletController>.Instance.TempQuat);
					ControllerBase<BulletController>.Instance.TempTransform.SetRotation(ControllerBase<BulletController>.Instance.TempQuat);
				}
				if (location != null)
				{
					ControllerBase<BulletController>.Instance.TempTransform.SetLocation(location);
				}
				ControllerBase<BulletController>.Instance.TempTransform.SetScale3D(global::Vector.OneVectorProxy);
			}
			else
			{
				BaseActorComponent baseActorComponent = (owner != null) ? owner.CheckGetComponent<BaseActorComponent>() : null;
				if (baseActorComponent != null)
				{
					ControllerBase<BulletController>.Instance.TempTransform.SetLocation(baseActorComponent.ActorLocationProxy);
					ControllerBase<BulletController>.Instance.TempRotator.DeepCopy(baseActorComponent.ActorRotationProxy);
					ControllerBase<BulletController>.Instance.TempTransform.SetRotation(baseActorComponent.ActorQuatProxy);
				}
			}
		}
		int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(Singleton<MathUtils>.Instance.LongToNumber(data.SpawnEntityId));
		int entityId2 = ModelBase<CreatureModel>.Instance.GetEntityId(Singleton<MathUtils>.Instance.LongToNumber(data.SpawnVelocityEntityId));
		int entityId3 = ModelBase<CreatureModel>.Instance.GetEntityId(Singleton<MathUtils>.Instance.LongToNumber(data.TargetId));
		FVectorDouble? targetLocation = null;
		if (data.TarLocation != null)
		{
			targetLocation = new FVectorDouble?(new FVectorDouble((double)data.TarLocation.X, (double)data.TarLocation.Y, (double)data.TarLocation.Z));
		}
		BulletEntity bulletEntity = ControllerBase<BulletController>.Instance.CreateBulletRemote(owner, text, ControllerBase<BulletController>.Instance.TempTransform.ToUeTransform(), skillId, entityId, entityId2, entityId3, data.CombatCommon.MessageId, targetLocation, data.RandomInitPosOffset, data.RandomInitSpeed, data.Size);
		if (bulletEntity == null)
		{
			return;
		}
		ModelBase<BulletModel>.Instance.RegisterBullet(data.Handle, bulletEntity.Id);
		if (bulletEntity.Data.Render.HandOverParentEffect)
		{
			int idByBulletHandle = ModelBase<BulletModel>.Instance.GetIdByBulletHandle(data.ParentHandle);
			BulletEntity bulletEntityById = ModelBase<BulletModel>.Instance.GetBulletEntityById(idByBulletHandle);
			BulletInfo bulletInfo = (bulletEntityById != null) ? bulletEntityById.GetBulletInfo() : null;
			BulletInfo bulletInfo2 = bulletEntity.GetBulletInfo();
			if (bulletInfo != null && bulletInfo2 != null)
			{
				BulletStaticFunction.HandOverEffects(bulletInfo, bulletInfo2);
			}
		}
	}

	// Token: 0x060179B7 RID: 96695 RVA: 0x006916D1 File Offset: 0x0068F8D1
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.DestroyBulletNotify, true, false)]
	public static void DestroyBulletNotify(Entity entity, [Nullable(1)] DestroyBulletNotify data, CombatCommon combatCommon = null)
	{
		ModelBase<BulletModel>.Instance.DestroyBulletRemote(data.Handle, data.IsCreateSubBullet);
	}

	// Token: 0x060179B8 RID: 96696 RVA: 0x006916EC File Offset: 0x0068F8EC
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.ModifyBulletParamsNotify, true, false)]
	public static void ModifyBulletParamsNotify(Entity owner, [Nullable(1)] ModifyBulletParamsNotify data, CombatCommon combatCommon = null)
	{
		BulletModel instance = ModelBase<BulletModel>.Instance;
		ActiveBulletHandle handle;
		if (data == null)
		{
			handle = null;
		}
		else
		{
			ModifyBulletParams modifyBulletParams = data.ModifyBulletParams;
			handle = ((modifyBulletParams != null) ? modifyBulletParams.Handle : null);
		}
		int idByBulletHandle = instance.GetIdByBulletHandle(handle);
		BulletEntity bulletEntity = Singleton<EntitySystem>.Instance.Get<BulletEntity>(idByBulletHandle);
		long creatureDataId = Singleton<MathUtils>.Instance.LongToNumber(data.ModifyBulletParams.TargetId);
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
		BulletInfo bulletInfo = (bulletEntity != null) ? bulletEntity.GetBulletInfo() : null;
		if (bulletInfo != null && entity != null && entity.Valid)
		{
			bulletInfo.SetTargetById(entity.Id);
		}
	}

	// Token: 0x060179B9 RID: 96697 RVA: 0x00691770 File Offset: 0x0068F970
	[NullableContext(2)]
	private BulletEntity CreateBulletRemote([Nullable(1)] Entity owner, [Nullable(1)] string bulletRowName, FTransformDouble initialTransform, int skillId, int spawnEntityId, int spawnVelocityEntityId, int targetId, long contextId, FVectorDouble? targetLocation = null, IVector randomPosOffset = null, IVector randomInitSpeedOffset = null, IVector size = null)
	{
		this.CreateBulletStatStart(bulletRowName);
		BulletEntity result = this.CreateBullet(owner, bulletRowName, new FTransformDouble?(initialTransform), new BulletController.BulletCreateParams
		{
			SkillId = skillId,
			SyncType = global::EBulletSyncType.SyncFromRemote,
			BaseTransformId = new int?(spawnEntityId),
			BaseVelocityId = new int?(spawnVelocityEntityId),
			TargetId = new int?(targetId),
			InitTargetLocation = targetLocation,
			RandomPosOffset = randomPosOffset,
			RandomInitSpeedOffset = randomInitSpeedOffset,
			Size = ((size != null) ? global::Vector.Create(size) : null)
		}, new long?(contextId), global::EBulletCreateSource.Others);
		this.CreateBulletStatSop(bulletRowName);
		return result;
	}

	// Token: 0x060179BA RID: 96698 RVA: 0x00691808 File Offset: 0x0068FA08
	private unsafe int GetCustomEntityId(Entity owner, int pos, string bulletRowName)
	{
		if (float.IsNaN((float)pos))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "pos NAN！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bulletRowName", bulletRowName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0;
		}
		IList<long> customServerEntityIds = owner.GetComponent<CreatureDataComponent>().CustomServerEntityIds;
		if (pos > customServerEntityIds.Count || pos == 0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Bullet;
			ELogAuthor author2 = ELogAuthor.HCW;
			string message2 = "pos不合法！";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("bulletRowName", bulletRowName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("pos", pos);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("serverEntityIds", customServerEntityIds);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return 0;
		}
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(customServerEntityIds[pos - 1]);
		if (entity != null)
		{
			return entity.Id;
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.Bullet;
		ELogAuthor author3 = ELogAuthor.HCW;
		string message3 = "无法找到伴生物实体";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("bulletRowName", bulletRowName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("pos", pos);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("serverEntityIds", customServerEntityIds);
		instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		return 0;
	}

	// Token: 0x060179BB RID: 96699 RVA: 0x00691960 File Offset: 0x0068FB60
	public Stat GetBulletCreateStat(string bulletRowName)
	{
		Stat stat;
		if (!this.BulletCreateStatMap.TryGetValue(bulletRowName, out stat))
		{
			stat = null;
			this.BulletCreateStatMap[bulletRowName] = stat;
		}
		return stat;
	}

	// Token: 0x060179BC RID: 96700 RVA: 0x00691990 File Offset: 0x0068FB90
	public Stat GetBulletDestroyStat(string bulletRowName)
	{
		Stat stat;
		if (!this.BulletDestroyStatMap.TryGetValue(bulletRowName, out stat))
		{
			stat = null;
			this.BulletDestroyStatMap[bulletRowName] = stat;
		}
		return stat;
	}

	// Token: 0x060179BD RID: 96701 RVA: 0x006919C0 File Offset: 0x0068FBC0
	public Stat GetBulletMoveTickStat(string bulletRowName)
	{
		Stat stat;
		if (!this.BulletMoveTickStatMap.TryGetValue(bulletRowName, out stat))
		{
			stat = null;
			this.BulletMoveTickStatMap[bulletRowName] = stat;
		}
		return stat;
	}

	// Token: 0x060179BE RID: 96702 RVA: 0x006919F0 File Offset: 0x0068FBF0
	public Stat GetBulletCollisionTickStat(string bulletRowName)
	{
		Stat stat;
		if (!this.BulletCollisionTickStatMap.TryGetValue(bulletRowName, out stat))
		{
			stat = null;
			this.BulletCollisionTickStatMap[bulletRowName] = stat;
		}
		return stat;
	}

	// Token: 0x060179BF RID: 96703 RVA: 0x00691A20 File Offset: 0x0068FC20
	public Stat GetBulletCollisionAfterTickStat(string bulletRowName)
	{
		Stat stat;
		if (!this.BulletCollisionAfterTickStatMap.TryGetValue(bulletRowName, out stat))
		{
			stat = null;
			this.BulletCollisionAfterTickStatMap[bulletRowName] = stat;
		}
		return stat;
	}

	// Token: 0x060179C0 RID: 96704 RVA: 0x00691A4D File Offset: 0x0068FC4D
	[NullableContext(2)]
	public EntityHandle GetSceneBulletOwner()
	{
		return ModelBase<CreatureModel>.Instance.GetEntity(ModelBase<BulletModel>.Instance.SceneBulletOwnerId);
	}

	// Token: 0x060179C1 RID: 96705 RVA: 0x00691A64 File Offset: 0x0068FC64
	public void SetBulletSpeedRatio(int id, float newSpeed)
	{
		BulletEntity bulletEntityById = ModelBase<BulletModel>.Instance.GetBulletEntityById(id);
		BulletInfo bulletInfo = (bulletEntityById != null) ? bulletEntityById.GetBulletInfo() : null;
		BulletMoveInfo bulletMoveInfo = (bulletInfo != null) ? bulletInfo.MoveInfo : null;
		if (bulletMoveInfo != null)
		{
			bulletMoveInfo.BulletSpeedRatio = newSpeed;
		}
	}

	// Token: 0x060179C2 RID: 96706 RVA: 0x00691AA0 File Offset: 0x0068FCA0
	public void SetBulletLiveRatio(int id, float ratio)
	{
		BulletEntity bulletEntityById = ModelBase<BulletModel>.Instance.GetBulletEntityById(id);
		BulletInfo bulletInfo = (bulletEntityById != null) ? bulletEntityById.GetBulletInfo() : null;
		if (bulletInfo != null)
		{
			bulletInfo.LiveTimeRatio = ratio;
		}
	}

	// Token: 0x060179C3 RID: 96707 RVA: 0x00691ACF File Offset: 0x0068FCCF
	public int SpawnPattern(Entity ownerEntity, UKuroBulletPatternDataAsset patternData, FWorldEntityBulletParam extraParam)
	{
		return ModelBase<BulletModel>.Instance.SpawnPattern(ownerEntity, patternData, extraParam);
	}

	// Token: 0x060179C4 RID: 96708 RVA: 0x00691ADE File Offset: 0x0068FCDE
	public void DestroyPatternById(int patternId)
	{
		ModelBase<BulletModel>.Instance.DestroyPatternById(patternId);
	}

	// Token: 0x060179C5 RID: 96709 RVA: 0x00691AEB File Offset: 0x0068FCEB
	public void ProcessKuroBulletOperationList()
	{
		ModelBase<BulletModel>.Instance.ProcessKuroBulletOperationList();
	}

	// Token: 0x060179C6 RID: 96710 RVA: 0x00691AF7 File Offset: 0x0068FCF7
	public void ProcessKuroBulletOperation(FBulletHitWorldEntityOperation operation)
	{
		ModelBase<BulletModel>.Instance.ProcessKuroBulletOperation(operation);
	}

	// Token: 0x0400B5C5 RID: 46533
	private readonly List<BulletSystemBase> SystemList = new List<BulletSystemBase>();

	// Token: 0x0400B5C6 RID: 46534
	[Nullable(2)]
	private BulletActionRunner ActionRunner;

	// Token: 0x0400B5C7 RID: 46535
	private readonly Dictionary<string, Stat> BulletCreateStatMap = new Dictionary<string, Stat>();

	// Token: 0x0400B5C8 RID: 46536
	private readonly Dictionary<string, Stat> BulletDestroyStatMap = new Dictionary<string, Stat>();

	// Token: 0x0400B5C9 RID: 46537
	private readonly Dictionary<string, Stat> BulletMoveTickStatMap = new Dictionary<string, Stat>();

	// Token: 0x0400B5CA RID: 46538
	private readonly Dictionary<string, Stat> BulletCollisionTickStatMap = new Dictionary<string, Stat>();

	// Token: 0x0400B5CB RID: 46539
	private readonly Dictionary<string, Stat> BulletCollisionAfterTickStatMap = new Dictionary<string, Stat>();

	// Token: 0x0400B5CC RID: 46540
	private readonly Stat BulletConfigGetData = Stat.Create("BulletConfigGetData", "", "");

	// Token: 0x0400B5CD RID: 46541
	private readonly global::Transform TempTransform = global::Transform.Create();

	// Token: 0x0400B5CE RID: 46542
	private readonly global::Rotator TempRotator = global::Rotator.Create();

	// Token: 0x0400B5CF RID: 46543
	private readonly Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x02009067 RID: 36967
	[NullableContext(2)]
	[Nullable(0)]
	public class BulletCreateParams
	{
		// Token: 0x040306BC RID: 198332
		public int SkillId;

		// Token: 0x040306BD RID: 198333
		public long? SkillContextId;

		// Token: 0x040306BE RID: 198334
		public global::EBulletSyncType SyncType;

		// Token: 0x040306BF RID: 198335
		public int? ParentVictimId = new int?(0);

		// Token: 0x040306C0 RID: 198336
		public int? ParentTargetId = new int?(0);

		// Token: 0x040306C1 RID: 198337
		public int ParentId;

		// Token: 0x040306C2 RID: 198338
		public global::Vector Size;

		// Token: 0x040306C3 RID: 198339
		public FVectorDouble? InitTargetLocation;

		// Token: 0x040306C4 RID: 198340
		public Aki.Protocol.EBulletCreateSource Source;

		// Token: 0x040306C5 RID: 198341
		public FVector? LocationOffset;

		// Token: 0x040306C6 RID: 198342
		public FRotator? BeginRotatorOffset;

		// Token: 0x040306C7 RID: 198343
		public bool CreateOnAuthority = true;

		// Token: 0x040306C8 RID: 198344
		public ISkillBattleContext BattleContext;

		// Token: 0x040306C9 RID: 198345
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<string> ParentIds;

		// Token: 0x040306CA RID: 198346
		public BulletDataMain BulletData;

		// Token: 0x040306CB RID: 198347
		public int? TargetId;

		// Token: 0x040306CC RID: 198348
		public int? BaseTransformId;

		// Token: 0x040306CD RID: 198349
		public int? BaseVelocityId;

		// Token: 0x040306CE RID: 198350
		public IVector RandomPosOffset;

		// Token: 0x040306CF RID: 198351
		public IVector RandomInitSpeedOffset;
	}
}
