using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;
using CSharpScript.Game.World.Model;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02002E63 RID: 11875
[NullableContext(1)]
[Nullable(0)]
public class BaseDamageComponent : EntityComponent
{
	// Token: 0x170020CB RID: 8395
	// (get) Token: 0x0601863D RID: 99901 RVA: 0x006D2F69 File Offset: 0x006D1169
	[Nullable(2)]
	public CharacterBuffComponent OwnerBuffComponent
	{
		[NullableContext(2)]
		get
		{
			return this.BuffComponent;
		}
	}

	// Token: 0x0601863E RID: 99902 RVA: 0x006D2F74 File Offset: 0x006D1174
	protected override bool OnStart()
	{
		this.AttributeComponent = base.Entity.CheckGetComponent<BaseAttributeComponent>();
		this.TagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		this.BuffComponent = base.Entity.CheckGetComponent<CharacterBuffComponent>();
		this.FollowComponent = base.Entity.GetComponent<CharacterFollowComponent>();
		this.RoleGrowComponent = base.Entity.GetComponent<RoleGrowComponent>();
		this.SkillComponent = base.Entity.GetComponent<BaseSkillComponent>();
		this.ActorComponent = base.Entity.CheckGetComponent<BaseActorComponent>();
		this.CreatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		return true;
	}

	// Token: 0x0601863F RID: 99903 RVA: 0x006D300A File Offset: 0x006D120A
	protected override bool OnClear()
	{
		this.RemoveListeningRageTask();
		return true;
	}

	// Token: 0x06018640 RID: 99904 RVA: 0x006D3013 File Offset: 0x006D1213
	private void RemoveListeningRageTask()
	{
		if (this.HitInAirFinishTask != null)
		{
			this.HitInAirFinishTask.EndTask();
			this.HitInAirFinishTask = null;
		}
	}

	// Token: 0x06018641 RID: 99905 RVA: 0x006D3030 File Offset: 0x006D1230
	public unsafe BulletDamageResult ExecuteBulletDamage(int bulletEntityId, IBulletDamageParam damageParam, long contextId)
	{
		DamageModel instance = ModelBase<DamageModel>.Instance;
		DamageSnapshot damageSnapshot = (instance != null) ? instance.GetDamageSnapshotById(damageParam.DamageDataId) : null;
		BulletDamageResult bulletDamageResult = new BulletDamageResult();
		if (damageSnapshot == null)
		{
			return bulletDamageResult;
		}
		Damage config = damageSnapshot.Config;
		if (!string.IsNullOrEmpty(damageSnapshot.Condition))
		{
			BulletDamageContext bulletDamageContext = new BulletDamageContext
			{
				ContextType = EContextType.BulletDamage,
				DamageParam = damageParam,
				BulletEntityId = bulletEntityId,
				ContextId = contextId,
				Result = bulletDamageResult,
				Victim = this
			};
			ControllerBase<ExpressionTreeController>.Instance.DoDamageExpression(bulletDamageContext, config, damageParam.Attacker);
			return bulletDamageContext.Result;
		}
		BulletEntity bulletEntity = Singleton<EntitySystem>.Instance.Get<BulletEntity>(bulletEntityId);
		BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
		if (damageSnapshot.CalculateType == 0 && this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不受子弹伤害"]))
		{
			return bulletDamageResult;
		}
		RequirementPayload requirementPayload = new RequirementPayload();
		requirementPayload.BulletId = new long?(long.Parse(bulletInfo.BulletRowName));
		requirementPayload.BulletMessageId = new long?(contextId);
		requirementPayload.SkillId = new int?(bulletInfo.BulletInitParams.SkillId);
		requirementPayload.SkillMessageId = bulletInfo.BulletInitParams.SkillContextId;
		requirementPayload.SkillDamageCount = ModelBase<CombatMessageModel>.Instance.AddSkillDamageCount(bulletInfo.BulletInitParams.SkillContextId);
		requirementPayload.SkillDamageCountByVictim = ModelBase<CombatMessageModel>.Instance.AddSkillDamageCountByVictim(bulletInfo.BulletInitParams.SkillContextId, base.Entity.Id);
		requirementPayload.BulletDamageCount = ModelBase<CombatMessageModel>.Instance.AddBulletDamageCount(bulletInfo.ContextId);
		requirementPayload.BulletTags = bulletInfo.Tags;
		Partial_RequirementPayload partial_RequirementPayload = requirementPayload;
		ISkillBattleContext battleContext = bulletInfo.BulletInitParams.BattleContext;
		partial_RequirementPayload.BattleFlags = (((battleContext != null) ? battleContext.BattleFlags : null) ?? new List<string>());
		requirementPayload.PartId = new int?(damageParam.PartId);
		int? partId = requirementPayload.PartId;
		int num = 0;
		if (partId.GetValueOrDefault() >= num & partId != null)
		{
			Partial_RequirementPayload partial_RequirementPayload2 = requirementPayload;
			CharacterPart partByIndex = base.Entity.GetComponent<CharacterPartComponent>().GetPartByIndex(requirementPayload.PartId.Value);
			partial_RequirementPayload2.PartTag = ((partByIndex.PartTag != null) ? new int?(partByIndex.PartTag.GetValueOrDefault().TagId()) : null);
		}
		requirementPayload.CounterType = damageParam.CounterType;
		BaseDamageComponent baseDamageComponent = damageParam.Attacker.CheckGetComponent<BaseDamageComponent>();
		BaseBuffComponent attacker = damageParam.Attacker.CheckGetComponent<BaseBuffComponent>();
		if (baseDamageComponent == null)
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Damage;
			Entity entity = base.Entity;
			string message = "伤害结算无合法施加者";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("damageId", config.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("attacker id", damageParam.Attacker.Id);
			instance2.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return bulletDamageResult;
		}
		TDamageParam inputParam = new TDamageParam
		{
			DamageData = config,
			Attacker = baseDamageComponent,
			DirectTarget = damageParam.DirectTarget,
			SkillLevel = damageParam.SkillLevel,
			HitPosition = damageParam.HitPosition,
			IsAddEnergy = damageParam.IsAddEnergy,
			IsCounterAttack = damageParam.IsCounterAttack,
			ForceCritical = damageParam.ForceCritical,
			IsBlocked = damageParam.IsBlocked,
			ExtraRate = damageParam.ExtraRate,
			SourceType = DamageSourceType.FromBullet,
			Accumulation = ExtraEffectDamageAccumulation.GetAccumulation(bulletEntity.Id),
			Element = (ModifyDamageElement.ApplyEffects(attacker, damageSnapshot.Id) ?? ((EElementType)damageSnapshot.Element)),
			PartId = damageParam.PartId,
			RandomSeed = ModelBase<PlayerInfoModel>.Instance.GetRandomSeed(),
			ContextId = contextId,
			SkillContextId = bulletInfo.BulletInitParams.SkillContextId,
			CounterSkillMessageId = damageParam.CounterSkillMessageId
		};
		this.ReviseInputSkillLevel(inputParam);
		float toughResult = this.ProcessDamage(requirementPayload, inputParam, bulletDamageResult);
		bulletDamageResult.ToughResult = toughResult;
		return bulletDamageResult;
	}

	// Token: 0x06018642 RID: 99906 RVA: 0x006D3420 File Offset: 0x006D1620
	public unsafe float ExecuteKuroBulletDamage(IBulletDamageParam damageParam, FWorldEntityBulletParam extraParam)
	{
		DamageModel instance = ModelBase<DamageModel>.Instance;
		DamageSnapshot damageSnapshot = (instance != null) ? instance.GetDamageSnapshotById(damageParam.DamageDataId) : null;
		if (damageSnapshot == null)
		{
			return 0f;
		}
		Damage config = damageSnapshot.Config;
		BulletDamageResult bulletDamageResult = new BulletDamageResult
		{
			ToughResult = 0f,
			IsAddEnergy = false
		};
		long messageId = extraParam.MessageId;
		if (!string.IsNullOrEmpty(damageSnapshot.Condition))
		{
			BulletDamageContext context = new BulletDamageContext
			{
				ContextType = EContextType.BulletDamage,
				DamageParam = damageParam,
				ContextId = messageId,
				Result = bulletDamageResult,
				Victim = this
			};
			ControllerBase<ExpressionTreeController>.Instance.DoDamageExpression(context, config, damageParam.Attacker);
			return bulletDamageResult.ToughResult;
		}
		if (damageSnapshot.CalculateType == 0 && this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不受子弹伤害"]))
		{
			return 0f;
		}
		RequirementPayload requirementPayload = new RequirementPayload();
		requirementPayload.BulletMessageId = new long?(messageId);
		requirementPayload.SkillId = new int?(extraParam.SkillId);
		requirementPayload.SkillMessageId = new long?(extraParam.SkillMessageId);
		Partial_RequirementPayload partial_RequirementPayload = requirementPayload;
		CombatMessageModel instance2 = ModelBase<CombatMessageModel>.Instance;
		partial_RequirementPayload.SkillDamageCount = ((instance2 != null) ? instance2.AddSkillDamageCount(requirementPayload.SkillMessageId) : null);
		Partial_RequirementPayload partial_RequirementPayload2 = requirementPayload;
		CombatMessageModel instance3 = ModelBase<CombatMessageModel>.Instance;
		partial_RequirementPayload2.SkillDamageCountByVictim = ((instance3 != null) ? instance3.AddSkillDamageCountByVictim(requirementPayload.SkillMessageId, base.Entity.Id) : null);
		Partial_RequirementPayload partial_RequirementPayload3 = requirementPayload;
		CombatMessageModel instance4 = ModelBase<CombatMessageModel>.Instance;
		partial_RequirementPayload3.BulletDamageCount = ((instance4 != null) ? instance4.AddBulletDamageCount(new long?(messageId)) : null);
		requirementPayload.PartId = new int?(damageParam.PartId);
		int? partId = requirementPayload.PartId;
		int num = 0;
		if (partId.GetValueOrDefault() >= num & partId != null)
		{
			Partial_RequirementPayload partial_RequirementPayload4 = requirementPayload;
			CharacterPart partByIndex = base.Entity.GetComponent<CharacterPartComponent>().GetPartByIndex(requirementPayload.PartId.Value);
			partial_RequirementPayload4.PartTag = ((partByIndex.PartTag != null) ? new int?(partByIndex.PartTag.GetValueOrDefault().TagId()) : null);
		}
		requirementPayload.CounterType = damageParam.CounterType;
		BaseDamageComponent baseDamageComponent = damageParam.Attacker.CheckGetComponent<BaseDamageComponent>();
		BaseBuffComponent attacker = damageParam.Attacker.CheckGetComponent<BaseBuffComponent>();
		if (baseDamageComponent == null)
		{
			CombatLog instance5 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Damage;
			Entity entity = base.Entity;
			string message = "伤害结算无合法施加者";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("damageId", config.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("attacker id", damageParam.Attacker.Id);
			instance5.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return 0f;
		}
		TDamageParam inputParam = new TDamageParam
		{
			DamageData = config,
			Attacker = baseDamageComponent,
			DirectTarget = damageParam.DirectTarget,
			SkillLevel = damageParam.SkillLevel,
			HitPosition = damageParam.HitPosition,
			IsAddEnergy = damageParam.IsAddEnergy,
			IsCounterAttack = damageParam.IsCounterAttack,
			ForceCritical = damageParam.ForceCritical,
			IsBlocked = damageParam.IsBlocked,
			ExtraRate = damageParam.ExtraRate,
			SourceType = DamageSourceType.FromBullet,
			Accumulation = 0f,
			Element = (ModifyDamageElement.ApplyEffects(attacker, damageSnapshot.Id) ?? ((EElementType)damageSnapshot.Element)),
			PartId = damageParam.PartId,
			RandomSeed = ModelBase<PlayerInfoModel>.Instance.GetRandomSeed(),
			ContextId = messageId,
			SkillContextId = requirementPayload.SkillMessageId,
			CounterSkillMessageId = damageParam.CounterSkillMessageId
		};
		this.ReviseInputSkillLevel(inputParam);
		return this.ProcessDamage(requirementPayload, inputParam, null);
	}

	// Token: 0x06018643 RID: 99907 RVA: 0x006D37D4 File Offset: 0x006D19D4
	public unsafe void ExecuteBuffDamage(IBuffDamageParam damageParam, Partial_RequirementPayload payload, long contextId)
	{
		DamageSnapshot damageSnapshotById = ModelBase<DamageModel>.Instance.GetDamageSnapshotById(damageParam.DamageDataId);
		if (damageSnapshotById == null)
		{
			return;
		}
		if (!string.IsNullOrEmpty(damageSnapshotById.Condition))
		{
			BuffDamageContext context = new BuffDamageContext
			{
				ContextType = EContextType.BuffDamage,
				DamageParam = damageParam,
				Payload = payload,
				ContextId = contextId,
				Victim = this
			};
			ControllerBase<ExpressionTreeController>.Instance.DoDamageExpression(context, damageSnapshotById.Config, damageParam.Attacker);
			return;
		}
		CharacterFollowComponent component = damageParam.Attacker.GetComponent<CharacterFollowComponent>();
		damageParam.Attacker = (((component != null) ? component.GetAttributeHolder() : null) ?? damageParam.Attacker);
		RequirementPayload requirementPayload = new RequirementPayload();
		requirementPayload.PartialAssign(payload);
		BaseDamageComponent baseDamageComponent = damageParam.Attacker.CheckGetComponent<BaseDamageComponent>();
		BaseBuffComponent attacker = damageParam.Attacker.CheckGetComponent<BaseBuffComponent>();
		if (baseDamageComponent == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Damage;
			Entity entity = base.Entity;
			string message = "伤害结算无合法施加者";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("damageId", damageSnapshotById.Id);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "attacker id";
			Entity attacker2 = damageParam.Attacker;
			ptr = new ValueTuple<string, object>(item, (attacker2 != null) ? new int?(attacker2.Id) : null);
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		TDamageParam inputParam = new TDamageParam
		{
			DamageData = damageSnapshotById.Config,
			Attacker = baseDamageComponent,
			DirectTarget = base.Entity,
			SkillLevel = damageParam.SkillLevel,
			HitPosition = damageParam.HitPosition,
			SourceType = DamageSourceType.FromEffect,
			IsAddEnergy = false,
			IsCounterAttack = false,
			ForceCritical = false,
			IsBlocked = false,
			PartId = -1,
			ExtraRate = 1f,
			Accumulation = 0f,
			Element = (ModifyDamageElement.ApplyEffects(attacker, damageSnapshotById.Id) ?? ((EElementType)damageSnapshotById.Element)),
			RandomSeed = ModelBase<PlayerInfoModel>.Instance.GetRandomSeed(),
			ContextId = contextId,
			SkillContextId = null
		};
		this.ReviseInputSkillLevel(inputParam);
		this.ProcessDamage(requirementPayload, inputParam, null);
	}

	// Token: 0x06018644 RID: 99908 RVA: 0x006D3A04 File Offset: 0x006D1C04
	public unsafe void ExecuteBuffShareDamage(IBuffDamageParam damageParam, Partial_RequirementPayload payload, float extraRate, long contextId)
	{
		DamageModel instance = ModelBase<DamageModel>.Instance;
		DamageSnapshot damageSnapshot = (instance != null) ? instance.GetDamageSnapshotById((long)((int)damageParam.DamageDataId)) : null;
		if (damageSnapshot == null)
		{
			return;
		}
		if (!string.IsNullOrEmpty(damageSnapshot.Condition))
		{
			BuffShareDamageContext context = new BuffShareDamageContext
			{
				ContextType = EContextType.BuffShareDamage,
				DamageParam = damageParam,
				Payload = payload,
				ExtraRate = extraRate,
				ContextId = contextId,
				Victim = this
			};
			ControllerBase<ExpressionTreeController>.Instance.DoDamageExpression(context, damageSnapshot.Config, damageParam.Attacker);
			return;
		}
		RequirementPayload requirementPayload = new RequirementPayload();
		requirementPayload.PartialAssign(payload);
		BaseDamageComponent baseDamageComponent = damageParam.Attacker.CheckGetComponent<BaseDamageComponent>();
		BaseBuffComponent attacker = damageParam.Attacker.CheckGetComponent<BaseBuffComponent>();
		if (baseDamageComponent == null)
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Damage;
			Entity entity = base.Entity;
			string message = "伤害结算无合法施加者";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("damageId", damageSnapshot.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("attacker id", damageParam.Attacker.Id);
			instance2.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		TDamageParam inputParam = new TDamageParam
		{
			DamageData = damageSnapshot.Config,
			Attacker = baseDamageComponent,
			DirectTarget = base.Entity,
			SkillLevel = damageParam.SkillLevel,
			HitPosition = damageParam.HitPosition,
			SourceType = DamageSourceType.FromEffect,
			IsAddEnergy = false,
			IsCounterAttack = false,
			ForceCritical = false,
			IsBlocked = false,
			PartId = -1,
			ExtraRate = extraRate,
			Accumulation = 0f,
			Element = (ModifyDamageElement.ApplyEffects(attacker, damageSnapshot.Id) ?? ((EElementType)damageSnapshot.Element)),
			RandomSeed = ModelBase<PlayerInfoModel>.Instance.GetRandomSeed(),
			ContextId = contextId,
			SkillContextId = null
		};
		this.ReviseInputSkillLevel(inputParam);
		this.ProcessDamage(requirementPayload, inputParam, null);
	}

	// Token: 0x06018645 RID: 99909 RVA: 0x006D3C04 File Offset: 0x006D1E04
	public float ProcessDamage(RequirementPayload partialRequirements, TDamageParam inputParam, [Nullable(2)] BulletDamageResult result)
	{
		if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌"]) && inputParam.DamageData.ImmuneType == 0)
		{
			return 0f;
		}
		if (result != null)
		{
			result.IsAddEnergy = true;
		}
		BaseDamageComponent attacker = inputParam.Attacker;
		int? skillId = partialRequirements.SkillId;
		int num = 0;
		if (skillId.GetValueOrDefault() > num & skillId != null)
		{
			BaseSkillComponent skillComponent = attacker.SkillComponent;
			global::Skill skill = (skillComponent != null) ? skillComponent.GetSkill(partialRequirements.SkillId.Value) : null;
			TEnumAsByte<ESkillGenre>? tenumAsByte;
			if (skill == null)
			{
				tenumAsByte = null;
			}
			else
			{
				SSkillInfo skillInfo = skill.SkillInfo;
				tenumAsByte = ((skillInfo != null) ? new TEnumAsByte<ESkillGenre>?(skillInfo.SkillGenre) : null);
			}
			TEnumAsByte<ESkillGenre>? tenumAsByte2 = tenumAsByte;
			partialRequirements.SkillGenre = new int?((tenumAsByte2 != null) ? ((int)tenumAsByte2.GetValueOrDefault()) : -1);
		}
		partialRequirements.DamageId = new long?(inputParam.DamageData.Id);
		partialRequirements.DamageType = new int?(inputParam.DamageData.Type);
		partialRequirements.DamageSubTypes = inputParam.DamageData.GetSubTypeArray();
		partialRequirements.CalculateType = new int?(inputParam.DamageData.CalculateType);
		partialRequirements.SmashType = new int?(inputParam.DamageData.SmashType);
		partialRequirements.ElementType = new EElementType?(inputParam.Element);
		SnapshotPayload snapshotPayload = this.AllocateSnapshot(attacker, inputParam);
		RoleGrowComponent roleGrowComponent = snapshotPayload.Attacker.RoleGrowComponent;
		partialRequirements.WeaponType = new int?((roleGrowComponent != null) ? roleGrowComponent.GetWeaponType() : -1);
		partialRequirements.SourceType = new DamageSourceType?(inputParam.SourceType);
		this.ProcessDamageOptimize(partialRequirements, inputParam, snapshotPayload);
		CharacterPart part = null;
		if (inputParam.PartId >= 0)
		{
			CharacterPartComponent component = base.Entity.GetComponent<CharacterPartComponent>();
			part = ((component != null) ? component.GetPartByIndex(inputParam.PartId) : null);
		}
		float extraToughRate = ((partialRequirements.SkillGenre.GetValueOrDefault() == 5) ? this.GetExtraToughRate("ToughRateOnCounter") : this.GetExtraToughRate("ToughRate")) / 10000f;
		Singleton<EventSystem>.Instance.EmitWithTarget<int>(base.Entity, EEventName.MonsterDebug, attacker.Entity.Id);
		this.GetServerDamage(inputParam, partialRequirements, inputParam.ContextId, part);
		float num2 = this.CalculateToughReduce(inputParam, snapshotPayload, extraToughRate);
		num2 = DamageModifier.ApplyEffects(partialRequirements, snapshotPayload, num2);
		this.ExecToughReduceRedirection(inputParam, snapshotPayload, (double)num2);
		return num2;
	}

	// Token: 0x06018646 RID: 99910 RVA: 0x006D3E66 File Offset: 0x006D2066
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.DamageExecuteNotify, false, false)]
	public static void OnDamageExecuteNotify(Entity entity, [Nullable(1)] DamageExecuteNotify data, CombatCommon combatCommon = null)
	{
		EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(data.TargetEntityId);
		object obj;
		if (entity2 == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity3 = entity2.Entity;
			obj = ((entity3 != null) ? entity3.GetComponent<BaseDamageComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2.ProcessRemoteDamage(data);
	}

	// Token: 0x06018647 RID: 99911 RVA: 0x006D3E9C File Offset: 0x006D209C
	public unsafe void ProcessRemoteDamage(DamageExecuteNotify data)
	{
		DamageContext damageContext = data.DamageContext ?? new DamageContext();
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(Singleton<MathUtils>.Instance.LongToNumber(data.AttackerEntityId));
		long num = Singleton<MathUtils>.Instance.LongToNumber(data.DamageId);
		DamageSnapshot damageSnapshotById = ModelBase<DamageModel>.Instance.GetDamageSnapshotById(num);
		BaseDamageComponent baseDamageComponent;
		if (entity == null)
		{
			baseDamageComponent = null;
		}
		else
		{
			WorldEntity entity2 = entity.Entity;
			baseDamageComponent = ((entity2 != null) ? entity2.GetComponent<BaseDamageComponent>() : null);
		}
		BaseDamageComponent baseDamageComponent2 = baseDamageComponent;
		if (damageSnapshotById == null || entity == null || baseDamageComponent2 == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Damage;
			Entity entity3 = base.Entity;
			string message = "收到服务端伤害广播时找不到合法的攻击者或有效伤害配置";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("攻击方", data.AttackerEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("受击方", data.TargetEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("结算id", num);
			instance.Error(flag, entity3, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		Damage config = damageSnapshotById.Config;
		DamageResult damageResult = new DamageResult
		{
			ShieldCoverDamage = (float)data.ShieldCoverDamage,
			DamageData = config,
			Damage = (float)(-(float)data.Damage),
			ChangeLife = (float)data.ChangeLife,
			IsCounterAttack = false,
			IsCritical = data.IsCrit,
			IsTargetKilled = data.KilledTarget,
			KillerEntityId = data.KillerEntityId,
			IsBlocked = false,
			SourceType = (damageContext.HasSourceType ? damageContext.SourceType : DamageSourceType.FromEffect),
			IsImmune = (data.ImmuneType == EDamageImmune.BuffEffectElement),
			Element = (EElementType)data.ElementType
		};
		RequirementPayload requirementPayload = new RequirementPayload();
		requirementPayload.BulletId = new long?(damageContext.HasBulletId ? damageContext.BulletId : -1L);
		requirementPayload.SkillId = new int?(damageContext.HasSkillId ? ((int)damageContext.SkillId) : 0);
		requirementPayload.BulletTags = damageContext.BulletTags;
		requirementPayload.PartId = new int?(data.PartId);
		requirementPayload.DamageId = new long?(damageSnapshotById.Id);
		requirementPayload.DamageType = new int?(damageSnapshotById.Type);
		requirementPayload.DamageSubTypes = damageSnapshotById.SubTypes;
		requirementPayload.CalculateType = new int?(damageSnapshotById.CalculateType);
		requirementPayload.IsTargetKilled = new bool?(damageResult.IsTargetKilled);
		int? num2 = requirementPayload.SkillId;
		int num3 = 0;
		if (num2.GetValueOrDefault() > num3 & num2 != null)
		{
			BaseSkillComponent skillComponent = baseDamageComponent2.SkillComponent;
			global::Skill skill = (skillComponent != null) ? skillComponent.GetSkill(requirementPayload.SkillId.Value) : null;
			Partial_RequirementPayload partial_RequirementPayload = requirementPayload;
			TEnumAsByte<ESkillGenre>? tenumAsByte;
			if (skill == null)
			{
				tenumAsByte = null;
			}
			else
			{
				SSkillInfo skillInfo = skill.SkillInfo;
				tenumAsByte = ((skillInfo != null) ? new TEnumAsByte<ESkillGenre>?(skillInfo.SkillGenre) : null);
			}
			TEnumAsByte<ESkillGenre>? tenumAsByte2 = tenumAsByte;
			partial_RequirementPayload.SkillGenre = new int?((tenumAsByte2 != null) ? ((int)tenumAsByte2.GetValueOrDefault()) : -1);
		}
		num2 = requirementPayload.PartId;
		num3 = 0;
		if (num2.GetValueOrDefault() >= num3 & num2 != null)
		{
			CharacterPartComponent component = base.Entity.GetComponent<CharacterPartComponent>();
			Partial_RequirementPayload partial_RequirementPayload2 = requirementPayload;
			int? partTag;
			if (component == null)
			{
				partTag = null;
			}
			else
			{
				CharacterPart partByIndex = component.GetPartByIndex(requirementPayload.PartId.Value);
				partTag = ((partByIndex.PartTag != null) ? new int?(partByIndex.PartTag.GetValueOrDefault().TagId()) : null);
			}
			partial_RequirementPayload2.PartTag = partTag;
		}
		requirementPayload.IsCritical = new bool?(damageResult.IsCritical);
		requirementPayload.IsImmune = new bool?(damageResult.IsImmune);
		requirementPayload.SourceType = new DamageSourceType?(damageResult.SourceType);
		requirementPayload.ChangeWeaknessType = new EChangeWeaknessType?((EChangeWeaknessType)data.ChangeWeakness);
		FVectorDouble actorLocation = this.ActorComponent.ActorLocation;
		this.ExecDamageEvent(damageResult, new DamageEventInfo
		{
			Attacker = baseDamageComponent2,
			HitPosition = actorLocation
		}, requirementPayload);
		this.ExecPostDamageExtraEffect(damageResult, baseDamageComponent2, requirementPayload);
	}

	// Token: 0x06018648 RID: 99912 RVA: 0x006D429C File Offset: 0x006D249C
	private SnapshotPayload AllocateSnapshot(BaseDamageComponent attacker, TDamageParam inputParam)
	{
		CharacterFollowComponent followComponent = attacker.FollowComponent;
		AttributeSnapshot attackerSnapshot = (((followComponent != null) ? followComponent.GetAttributeHolder() : null) ?? attacker.Entity).GetComponent<BaseAttributeComponent>().TakeSnapshot();
		CharacterFollowComponent followComponent2 = this.FollowComponent;
		AttributeSnapshot targetSnapshot = (((followComponent2 != null) ? followComponent2.GetAttributeHolderExceptVisionSummon() : null) ?? base.Entity).GetComponent<BaseAttributeComponent>().TakeSnapshot() ?? this.AttributeComponent.TakeSnapshot();
		HashSet<Entity> hashSet = DamageTransferRecipients.ApplyEffects(inputParam.DirectTarget);
		List<DamageTransfer> list = new List<DamageTransfer>();
		foreach (Entity entity in hashSet)
		{
			if (entity.Valid)
			{
				BaseDeathComponent component = entity.GetComponent<BaseDeathComponent>();
				if (component == null || !component.IsDead())
				{
					BaseDamageComponent component2 = entity.GetComponent<BaseDamageComponent>();
					BaseAttributeComponent component3 = entity.GetComponent<BaseAttributeComponent>();
					if (component2 != null && component3 != null)
					{
						list.Add(new DamageTransfer
						{
							TransferTarget = component2,
							ToughRecoverDelayTime = component3.GetCurrentValue(EAttributeType.ToughRecoverDelayTime),
							WeakTime = component3.GetCurrentValue(EAttributeType.WeakTime)
						});
					}
				}
			}
		}
		return new SnapshotPayload
		{
			Attacker = this.ReplaceAttacker(attacker),
			AttackerSnapshot = attackerSnapshot,
			Target = this,
			TargetSnapshot = targetSnapshot,
			DamageTransfers = list,
			HasDamageTransfer = (hashSet.Count > 0)
		};
	}

	// Token: 0x06018649 RID: 99913 RVA: 0x006D4404 File Offset: 0x006D2604
	[return: Nullable(2)]
	private BaseDamageComponent ReplaceAttacker(BaseDamageComponent attacker)
	{
		if (GameplayAbilityVisionControl.VisionControlHandle == null || attacker.CreatureDataComponent.SummonType != ESummonType.ConcomitantPhantomRole)
		{
			return attacker;
		}
		WorldEntity entity = ModelBase<CreatureModel>.Instance.GetEntity(attacker.CreatureDataComponent.GetSummonerId()).Entity;
		if (entity == null)
		{
			return null;
		}
		return entity.GetComponent<BaseDamageComponent>();
	}

	// Token: 0x0601864A RID: 99914 RVA: 0x006D4444 File Offset: 0x006D2644
	private void ProcessWhenCounter(RequirementPayload partialRequirements, TDamageParam inputParam, SnapshotPayload payload)
	{
		if (inputParam.IsCounterAttack)
		{
			payload.Attacker.BuffComponent.TriggerEvents(EBuffTriggerType.ForWhenCounter, payload.Target.BuffComponent, partialRequirements);
			this.BuffComponent.TriggerEvents(EBuffTriggerType.ForWhenBeCountered, payload.Attacker.BuffComponent, partialRequirements);
		}
	}

	// Token: 0x0601864B RID: 99915 RVA: 0x006D4490 File Offset: 0x006D2690
	private unsafe void GetServerDamage(TDamageParam inputParam, RequirementPayload partialRequirements, long preContextId, [Nullable(2)] CharacterPart part)
	{
		BaseDamageComponent attacker = inputParam.Attacker;
		Damage damageData = inputParam.DamageData;
		bool isBreakWeakness = partialRequirements.SkillGenre.GetValueOrDefault() == 13 && this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.弱点机制.弱点状态"]);
		DamageExecuteRequest request = new DamageExecuteRequest();
		request.DamageId = Singleton<MathUtils>.Instance.NumberToLong(damageData.Id);
		request.SkillLevel = inputParam.SkillLevel;
		request.AttackerEntityId = Singleton<MathUtils>.Instance.NumberToLong(attacker.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId());
		request.TargetEntityId = Singleton<MathUtils>.Instance.NumberToLong(inputParam.DirectTarget.GetComponent<CreatureDataComponent>().GetCreatureDataId());
		request.IsAddEnergy = inputParam.IsAddEnergy;
		request.IsCounterAttack = inputParam.IsCounterAttack;
		request.ForceCritical = inputParam.ForceCritical;
		request.IsBlocked = inputParam.IsBlocked;
		request.PartId = inputParam.PartId;
		request.CounterSkillMessageId = ((inputParam.CounterSkillMessageId != null) ? Singleton<MathUtils>.Instance.BigIntToLong(inputParam.CounterSkillMessageId.Value) : 0L);
		DamageContext damageContext = new DamageContext();
		request.DamageContext = damageContext;
		damageContext.SourceType = inputParam.SourceType;
		damageContext.BulletId = partialRequirements.BulletId.GetValueOrDefault(-1L);
		damageContext.BulletTags.AddRange(partialRequirements.BulletTags);
		damageContext.SkillId = (long)partialRequirements.SkillId.GetValueOrDefault();
		if (inputParam.SkillContextId != null)
		{
			damageContext.SkillMessageId = inputParam.SkillContextId.Value;
		}
		request.RandomSeed = ModelBase<PlayerInfoModel>.Instance.AdvanceRandomSeed(ERandomReason.StartDamage);
		request.IsBreakWeakness = isBreakWeakness;
		bool shouldLogOnline = ModelBase<GameModeModel>.Instance.IsMulti && damageData.Id == 1505600001L;
		if (shouldLogOnline)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Damage;
			Entity entity = base.Entity;
			string message = "发起结算请求";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("攻击方", Singleton<MathUtils>.Instance.BigIntToLong(request.AttackerEntityId));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("受击方", Singleton<MathUtils>.Instance.BigIntToLong(request.TargetEntityId));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("结算id", damageData.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("BulletId", partialRequirements.BulletId.GetValueOrDefault());
			instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		Singleton<CombatNet>.Instance.Call<DamageExecuteResponse>(ERequestMessageId.DamageExecuteRequest, base.Entity, request, delegate(DamageExecuteResponse response)
		{
			if (response.ImmuneType == EDamageImmune.Invincible)
			{
				if (shouldLogOnline)
				{
					CombatLog instance2 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Damage;
					Entity entity2 = this.Entity;
					string message2 = "EDamageImmune_Invincible";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("攻击方", request.AttackerEntityId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("受击方", request.TargetEntityId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("结算id", damageData.Id);
					instance2.Info(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				}
				return;
			}
			DamageResult damageResult = new DamageResult
			{
				Damage = (float)(-(float)response.Damage),
				ChangeLife = (float)response.ChangeLife,
				ShieldCoverDamage = (float)response.ShieldCoverDamage,
				IsCritical = response.IsCrit,
				IsTargetKilled = response.KilledTarget,
				KillerEntityId = 0L,
				IsImmune = (response.ImmuneType == EDamageImmune.BuffEffectElement),
				Element = (EElementType)response.ElementType,
				DamageData = inputParam.DamageData,
				IsCounterAttack = inputParam.IsCounterAttack,
				IsBlocked = inputParam.IsBlocked,
				SourceType = inputParam.SourceType
			};
			partialRequirements.IsCritical = new bool?(damageResult.IsCritical);
			partialRequirements.IsImmune = new bool?(damageResult.IsImmune);
			partialRequirements.IsTargetKilled = new bool?(damageResult.IsTargetKilled);
			partialRequirements.ChangeWeaknessType = new EChangeWeaknessType?((EChangeWeaknessType)response.ChangeWeakness);
			if (shouldLogOnline)
			{
				CombatLog instance3 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.Damage;
				Entity entity3 = this.Entity;
				string message3 = "收到结算回包";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("攻击方", request.AttackerEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("受击方", request.TargetEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("结算id", damageData.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("伤害值", damageResult.Damage);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("errorCode", response.ErrorCode);
				instance3.Info(flag3, entity3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 5));
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				return;
			}
			this.GetServerDamageCallBack(partialRequirements, inputParam, damageResult, part);
		}, new long?(preContextId), null, null, null);
	}

	// Token: 0x0601864C RID: 99916 RVA: 0x006D4868 File Offset: 0x006D2A68
	private void GetServerDamageCallBack(RequirementPayload requirements, TDamageParam inputParam, DamageResult serverResult, [Nullable(2)] CharacterPart part)
	{
		Entity entity = base.Entity;
		if (entity != null && entity.Valid)
		{
			BaseDamageComponent attacker = inputParam.Attacker;
			bool flag;
			if (attacker == null)
			{
				flag = true;
			}
			else
			{
				Entity entity2 = attacker.Entity;
				flag = !((entity2 != null) ? new bool?(entity2.Valid) : null).GetValueOrDefault();
			}
			if (!flag)
			{
				this.ExecDamageEvent(serverResult, inputParam, requirements);
				this.ExecDamageEffect(serverResult, inputParam, requirements);
				if (part != null)
				{
					part.OnDamage(serverResult.Damage, inputParam.ForceCritical, inputParam.Attacker.Entity, false);
				}
				return;
			}
		}
	}

	// Token: 0x0601864D RID: 99917 RVA: 0x006D48FB File Offset: 0x006D2AFB
	private void ExecDamageEffect(DamageResult result, TDamageParam inputParam, RequirementPayload requirements)
	{
		this.ExecEnergyCharge(inputParam, requirements);
		this.ExecPostDamageExtraEffect(result, inputParam.Attacker, requirements);
	}

	// Token: 0x0601864E RID: 99918 RVA: 0x006D4914 File Offset: 0x006D2B14
	private void ExecDamageEvent(DamageResult damageResult, DamageEventInfo inputParam, RequirementPayload requirements)
	{
		Entity entity = inputParam.Attacker.Entity;
		Entity entity2 = base.Entity;
		if (damageResult.DamageData.CalculateType == 1)
		{
			Singleton<EventSystem>.Instance.Emit<Entity>(EEventName.FormationPanelUIShowRoleHeal, entity2);
		}
		ControllerBase<SceneTeamController>.Instance.EmitEvent<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity2, EEventName.CharBeDamage, entity, entity2, requirements, damageResult, inputParam.HitPosition);
		ControllerBase<SceneTeamController>.Instance.EmitEvent<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity, EEventName.CharDamage, entity, entity2, requirements, damageResult, inputParam.HitPosition);
		if (damageResult.IsTargetKilled)
		{
			Entity entity3;
			if (damageResult.KillerEntityId == 0L)
			{
				entity3 = null;
			}
			else
			{
				EntityHandle entity4 = ModelBase<CreatureModel>.Instance.GetEntity(damageResult.KillerEntityId);
				entity3 = ((entity4 != null) ? entity4.Entity : null);
			}
			Entity entity5 = entity3 ?? entity;
			ControllerBase<SceneTeamController>.Instance.EmitEvent<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity5, EEventName.CharKillTarget, entity5, entity2, requirements, damageResult, inputParam.HitPosition);
			ControllerBase<SceneTeamController>.Instance.EmitEvent<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity2, EEventName.CharBeKilled, entity5, entity2, requirements, damageResult, inputParam.HitPosition);
		}
		Singleton<EventSystem>.Instance.Emit<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(EEventName.GlobalCharDamage, entity, entity2, requirements, damageResult, inputParam.HitPosition);
	}

	// Token: 0x0601864F RID: 99919 RVA: 0x006D49F8 File Offset: 0x006D2BF8
	private void ExecPostDamageExtraEffect(DamageResult damageResult, BaseDamageComponent attackerDamageComp, RequirementPayload requirements)
	{
		if (this.BuffComponent == null)
		{
			return;
		}
		CharacterBuffComponent buffComponent = attackerDamageComp.BuffComponent;
		if (buffComponent != null && damageResult.SourceType != DamageSourceType.FromEffect)
		{
			buffComponent.TriggerEvents(EBuffTriggerType.ForAfterDamageAsAttacker, this.BuffComponent, requirements);
			this.BuffComponent.TriggerEvents(EBuffTriggerType.ForAfterDamageAsVictim, buffComponent, requirements);
		}
		if (damageResult.IsTargetKilled)
		{
			CharacterBuffComponent characterBuffComponent = buffComponent;
			if (damageResult.KillerEntityId != 0L)
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(damageResult.KillerEntityId);
				WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
				CharacterBuffComponent characterBuffComponent2 = (worldEntity != null) ? worldEntity.GetComponent<CharacterBuffComponent>() : null;
				if (characterBuffComponent2 != null)
				{
					characterBuffComponent = characterBuffComponent2;
				}
			}
			if (characterBuffComponent != null)
			{
				characterBuffComponent.TriggerEvents(EBuffTriggerType.ForKillingEnemy, this.BuffComponent, requirements);
			}
		}
		if (buffComponent != null)
		{
			ExtraEffectDamageAccumulation.ApplyEffects(damageResult, requirements, attackerDamageComp, this);
		}
	}

	// Token: 0x06018650 RID: 99920 RVA: 0x006D4A9C File Offset: 0x006D2C9C
	private void ExecEnergyCharge(TDamageParam inputParam, RequirementPayload requirements)
	{
		BaseDamageComponent attacker = inputParam.Attacker;
		BaseAttributeComponent baseAttributeComponent = (attacker != null) ? attacker.AttributeComponent : null;
		if (baseAttributeComponent == null || !inputParam.IsAddEnergy)
		{
			return;
		}
		int skillLevel = inputParam.SkillLevel;
		Damage damageData = inputParam.DamageData;
		int[][] array = new int[][]
		{
			damageData.SpecialEnergy1(),
			damageData.SpecialEnergy2(),
			damageData.SpecialEnergy3(),
			damageData.SpecialEnergy4(),
			damageData.SpecialEnergy5()
		};
		for (int i = 0; i < array.Length; i++)
		{
			int[] array2 = array[i];
			EAttributeType attrId = CharacterAttributeTypes.specialEnergyIds[i];
			int levelValue = AbilityUtils.GetLevelValue<int>(array2, skillLevel, 0);
			if (levelValue != 0)
			{
				BaseDamageComponent attacker2 = inputParam.Attacker;
				float num = SpecialEnergyModifier.ApplyEffects((attacker2 != null) ? attacker2.Entity : null, this.BuffComponent, attrId, requirements);
				baseAttributeComponent.AddBaseValue(attrId, (float)levelValue * (1f + num * 0.0001f));
			}
		}
	}

	// Token: 0x06018651 RID: 99921 RVA: 0x006D4B7C File Offset: 0x006D2D7C
	private float CalculateToughReduce(TDamageParam inputParam, SnapshotPayload snapshots, float extraToughRate = 1f)
	{
		AttributeSnapshot attackerSnapshot = snapshots.AttackerSnapshot;
		AttributeSnapshot targetSnapshot = snapshots.TargetSnapshot;
		int levelValue = AbilityUtils.GetLevelValue<int>(inputParam.DamageData.ToughLv(), inputParam.SkillLevel, 0);
		return Calculation.ToughCalculation(attackerSnapshot, targetSnapshot, (float)levelValue * extraToughRate);
	}

	// Token: 0x06018652 RID: 99922 RVA: 0x006D4BBC File Offset: 0x006D2DBC
	private void ExecToughReduceRedirection(TDamageParam inputParam, SnapshotPayload snapshots, double toughResult)
	{
		if (!snapshots.HasDamageTransfer)
		{
			float[] currentValues = snapshots.TargetSnapshot.CurrentValues;
			this.ExecToughReduce(inputParam, snapshots.TargetSnapshot.GetCurrentValue(EAttributeType.ToughRecoverDelayTime), snapshots.TargetSnapshot.GetCurrentValue(EAttributeType.WeakTime), (float)toughResult);
			return;
		}
		foreach (DamageTransfer damageTransfer in snapshots.DamageTransfers)
		{
			BaseDamageComponent transferTarget = damageTransfer.TransferTarget;
			if (transferTarget != null)
			{
				transferTarget.ExecToughReduce(inputParam, damageTransfer.ToughRecoverDelayTime, damageTransfer.WeakTime, (float)toughResult);
			}
		}
	}

	// Token: 0x06018653 RID: 99923 RVA: 0x006D4C64 File Offset: 0x006D2E64
	private void ExecToughReduce(TDamageParam inputParam, float toughRecoverDelayTime, float weakTime, float toughResult)
	{
		BaseDamageComponent attacker = inputParam.Attacker;
		if (toughResult != 0f)
		{
			float num = 1f;
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			if (ModelBase<GameModeModel>.Instance.IsMulti && component.IsMonster())
			{
				int currentTeamSize = ModelBase<OnlineModel>.Instance.GetCurrentTeamSize();
				if (currentTeamSize > 1)
				{
					if (currentTeamSize <= 2)
					{
						num = ConfigCommonParamById.GetFloatConfig("MutiWorldToughRatio2").Value;
					}
					else
					{
						num = ConfigCommonParamById.GetFloatConfig("MutiWorldToughRatio3").Value;
					}
				}
			}
			this.AttributeComponent.AddBaseValue(EAttributeType.Tough, -toughResult * num);
		}
		if (this.AttributeComponent.GetCurrentValue(EAttributeType.Tough) > 0f)
		{
			if (toughRecoverDelayTime > 0f && toughResult != 0f)
			{
				BaseBuffComponent buffComponent = this.BuffComponent;
				long buffId = 3024L;
				AddBuffParam addBuffParam = new AddBuffParam();
				CreatureDataComponent creatureDataComponent = attacker.CreatureDataComponent;
				addBuffParam.InstigatorId = ((creatureDataComponent != null) ? creatureDataComponent.GetCreatureDataId() : -1L);
				addBuffParam.ApplyType = new ApplyGEType?(ApplyGEType.UseExtraTime);
				addBuffParam.Reason = "韧性扣减后触发";
				buffComponent.AddBuff(buffId, addBuffParam);
				return;
			}
		}
		else if (!this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["Damage.Vulnerable"]) && weakTime > 0f)
		{
			this.RequestWeakTime(true);
			float currentValue = this.AttributeComponent.GetCurrentValue(EAttributeType.WeakTime);
			this.WeakTimer = TimerSystem.Instance.Delay(delegate(float id)
			{
				if (this.TagComponent != null)
				{
					if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.击飞"]))
					{
						this.ListenForHitInAirFinishTask();
					}
					else
					{
						this.RequestWeakTime(false);
					}
				}
				this.WeakTimer = null;
			}, currentValue, null, null, true, 1f);
			this.AttributeComponent.SetBaseValue(EAttributeType.ToughRecover, 0f);
		}
	}

	// Token: 0x06018654 RID: 99924 RVA: 0x006D4DDC File Offset: 0x006D2FDC
	private void RequestWeakTime(bool isStart)
	{
		if (isStart)
		{
			this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["Damage.Vulnerable"]));
		}
		else
		{
			this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["Damage.Vulnerable"]));
			ITagTask hitInAirFinishTask = this.HitInAirFinishTask;
			if (hitInAirFinishTask != null)
			{
				hitInAirFinishTask.EndTask();
			}
		}
		FragileChangeRequest fragileChangeRequest = FragileChangeRequest.Create();
		fragileChangeRequest.EntityId = base.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
		fragileChangeRequest.Flag = isStart;
		Singleton<CombatNet>.Instance.Call<FragileChangeResponse>(ERequestMessageId.FragileChangeRequest, base.Entity, fragileChangeRequest, new Action<FragileChangeResponse>(this.<RequestWeakTime>g__Response|50_0), null, null, null, null);
	}

	// Token: 0x06018655 RID: 99925 RVA: 0x006D4EA8 File Offset: 0x006D30A8
	private void ListenForHitInAirFinishTask()
	{
		this.HitInAirFinishTask = this.TagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.击飞"]), delegate(int tagId, bool tagExists)
		{
			if (!tagExists)
			{
				this.RequestWeakTime(false);
			}
		}, null);
	}

	// Token: 0x06018656 RID: 99926 RVA: 0x006D4EDC File Offset: 0x006D30DC
	public void TryExitWeakTime()
	{
		if (!this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["Damage.Vulnerable"]))
		{
			return;
		}
		if (this.WeakTimer != null)
		{
			TimerSystem.Instance.Remove(this.WeakTimer);
			this.WeakTimer = null;
		}
		this.RequestWeakTime(false);
	}

	// Token: 0x06018657 RID: 99927 RVA: 0x006D4F30 File Offset: 0x006D3130
	private void ReviseInputSkillLevel(TDamageParam inputParam)
	{
		long id = inputParam.DamageData.Id;
		CreatureDataComponent creatureDataComponent = inputParam.Attacker.CreatureDataComponent;
		if (creatureDataComponent != null && creatureDataComponent.IsVehicle())
		{
			int? skillLevelByDamageId = ModelBase<MotorcycleDevelopModel>.Instance.GetSkillLevelByDamageId(id);
			if (skillLevelByDamageId != null)
			{
				inputParam.SkillLevel = skillLevelByDamageId.Value;
			}
			return;
		}
		int? num = null;
		if (inputParam.Attacker.RoleGrowComponent != null)
		{
			num = new int?(inputParam.Attacker.RoleGrowComponent.GetSkillLevelByDamageId(id));
		}
		CharacterVisionComponent component = inputParam.Attacker.Entity.GetComponent<CharacterVisionComponent>();
		int? num2 = (component != null) ? new int?(component.GetVisionLevelByDamageId(id)) : null;
		int? num3 = num;
		int num4 = 0;
		if (num3.GetValueOrDefault() > num4 & num3 != null)
		{
			inputParam.SkillLevel = num.Value;
			return;
		}
		num3 = num2;
		num4 = 0;
		if (num3.GetValueOrDefault() > num4 & num3 != null)
		{
			inputParam.SkillLevel = num2.Value;
		}
	}

	// Token: 0x06018658 RID: 99928 RVA: 0x006D5034 File Offset: 0x006D3234
	public void AddToughModifier(string key, float value)
	{
		if (!this.ToughModifiers.ContainsKey(key))
		{
			this.ToughModifiers[key] = new Dictionary<float, int>();
		}
		Dictionary<float, int> dictionary = this.ToughModifiers[key];
		dictionary[value] = 1 + (dictionary.ContainsKey(value) ? dictionary[value] : 0);
	}

	// Token: 0x06018659 RID: 99929 RVA: 0x006D508C File Offset: 0x006D328C
	public void RemoveToughModifier(string key, float value)
	{
		if (!this.ToughModifiers.ContainsKey(key))
		{
			return;
		}
		Dictionary<float, int> dictionary = this.ToughModifiers[key];
		if (!dictionary.ContainsKey(value))
		{
			return;
		}
		int num = dictionary[value];
		if (num >= 1)
		{
			dictionary[value] = num - 1;
			return;
		}
		dictionary.Remove(value);
	}

	// Token: 0x0601865A RID: 99930 RVA: 0x006D50E0 File Offset: 0x006D32E0
	protected float GetExtraToughRate(string key)
	{
		if (!this.ToughModifiers.ContainsKey(key))
		{
			return 10000f;
		}
		Dictionary<float, int> dictionary = this.ToughModifiers[key];
		float num = 10000f;
		foreach (KeyValuePair<float, int> keyValuePair in dictionary)
		{
			if (keyValuePair.Value > 0)
			{
				num *= (float)Math.Pow((double)(keyValuePair.Key / 10000f), (double)keyValuePair.Value);
			}
		}
		return num;
	}

	// Token: 0x0601865B RID: 99931 RVA: 0x006D5178 File Offset: 0x006D3378
	private void ProcessDamageOptimize(RequirementPayload partialRequirements, TDamageParam inputParam, SnapshotPayload snapshots)
	{
		this.ProcessWhenCounter(partialRequirements, inputParam, snapshots);
		SnapModifier.PreCriticalModify(partialRequirements, snapshots);
		SnapModifier.PostCriticalModify(partialRequirements, snapshots);
	}

	// Token: 0x0601865C RID: 99932 RVA: 0x006D5194 File Offset: 0x006D3394
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseDamageComponent baseDamageComponent = (BaseDamageComponent)componentTemplate;
		if (base.CanResetComponentProperty("AttributeComponent"))
		{
			if (baseDamageComponent.AttributeComponent == null)
			{
				this.AttributeComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseAttributeComponent>(this.AttributeComponent), "AttributeComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (baseDamageComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffComponent"))
		{
			if (baseDamageComponent.BuffComponent == null)
			{
				this.BuffComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterBuffComponent>(this.BuffComponent), "BuffComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FollowComponent"))
		{
			if (baseDamageComponent.FollowComponent == null)
			{
				this.FollowComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterFollowComponent>(this.FollowComponent), "FollowComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("RoleGrowComponent"))
		{
			if (baseDamageComponent.RoleGrowComponent == null)
			{
				this.RoleGrowComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RoleGrowComponent>(this.RoleGrowComponent), "RoleGrowComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillComponent"))
		{
			if (baseDamageComponent.SkillComponent == null)
			{
				this.SkillComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseSkillComponent>(this.SkillComponent), "SkillComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComponent"))
		{
			if (baseDamageComponent.ActorComponent == null)
			{
				this.ActorComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComponent), "ActorComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CreatureDataComponent"))
		{
			if (baseDamageComponent.CreatureDataComponent == null)
			{
				this.CreatureDataComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HitInAirFinishTask"))
		{
			if (baseDamageComponent.HitInAirFinishTask == null)
			{
				this.HitInAirFinishTask = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.HitInAirFinishTask), "HitInAirFinishTask"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("WeakTimer"))
		{
			if (baseDamageComponent.WeakTimer == null)
			{
				this.WeakTimer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.WeakTimer), "WeakTimer"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ToughModifiers"))
		{
			if (baseDamageComponent.ToughModifiers == null)
			{
				this.ToughModifiers = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, Dictionary<float, int>>>(this.ToughModifiers), "ToughModifiers"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06018660 RID: 99936 RVA: 0x006D55C0 File Offset: 0x006D37C0
	[CompilerGenerated]
	private void <RequestWeakTime>g__Response|50_0(FragileChangeResponse response)
	{
		if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
		{
			if (this.WeakTimer != null)
			{
				TimerSystem.Instance.Remove(this.WeakTimer);
				this.WeakTimer = null;
			}
			this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["Damage.Vulnerable"]));
		}
	}

	// Token: 0x0400BB39 RID: 47929
	[Nullable(2)]
	protected BaseAttributeComponent AttributeComponent;

	// Token: 0x0400BB3A RID: 47930
	[Nullable(2)]
	protected BaseTagComponent TagComponent;

	// Token: 0x0400BB3B RID: 47931
	[Nullable(2)]
	protected CharacterBuffComponent BuffComponent;

	// Token: 0x0400BB3C RID: 47932
	[Nullable(2)]
	private CharacterFollowComponent FollowComponent;

	// Token: 0x0400BB3D RID: 47933
	[Nullable(2)]
	private RoleGrowComponent RoleGrowComponent;

	// Token: 0x0400BB3E RID: 47934
	[Nullable(2)]
	private BaseSkillComponent SkillComponent;

	// Token: 0x0400BB3F RID: 47935
	[Nullable(2)]
	public BaseActorComponent ActorComponent;

	// Token: 0x0400BB40 RID: 47936
	[Nullable(2)]
	protected CreatureDataComponent CreatureDataComponent;

	// Token: 0x0400BB41 RID: 47937
	[Nullable(2)]
	private ITagTask HitInAirFinishTask;

	// Token: 0x0400BB42 RID: 47938
	[Nullable(2)]
	private TimerHandle WeakTimer;

	// Token: 0x0400BB43 RID: 47939
	[StaticVariableRuleIgnore]
	private static readonly Stat ExecuteBulletDamageStat1 = Stat.Create("ExecuteBulletDamage1", "", "");

	// Token: 0x0400BB44 RID: 47940
	[StaticVariableRuleIgnore]
	private static readonly Stat ExecuteBulletDamageStat2 = Stat.Create("ExecuteBulletDamage2", "", "");

	// Token: 0x0400BB45 RID: 47941
	[StaticVariableRuleIgnore]
	private static readonly Stat ExecuteBulletDamageStat3 = Stat.Create("ExecuteBulletDamage3", "", "");

	// Token: 0x0400BB46 RID: 47942
	[StaticVariableRuleIgnore]
	private static readonly Stat ProcessDamageStat = Stat.Create("ProcessDamage", "", "");

	// Token: 0x0400BB47 RID: 47943
	[StaticVariableRuleIgnore]
	private static readonly Stat EventCharDamageStat = Stat.Create("EventCharDamage", "", "");

	// Token: 0x0400BB48 RID: 47944
	[StaticVariableRuleIgnore]
	private static readonly Stat PostExecDamageResultStat1 = Stat.Create("PostExecDamageResult1", "", "");

	// Token: 0x0400BB49 RID: 47945
	[StaticVariableRuleIgnore]
	private static readonly Stat PostExecDamageResultStat2 = Stat.Create("PostExecDamageResult2", "", "");

	// Token: 0x0400BB4A RID: 47946
	[StaticVariableRuleIgnore]
	private static readonly Stat PostExecDamageResultStat3 = Stat.Create("PostExecDamageResult3", "", "");

	// Token: 0x0400BB4B RID: 47947
	[StaticVariableRuleIgnore]
	private static readonly Stat ExecToughReduceStat1 = Stat.Create("ExecToughReduce1", "", "");

	// Token: 0x0400BB4C RID: 47948
	[StaticVariableRuleIgnore]
	private static readonly Stat ExecToughReduceStat2 = Stat.Create("ExecToughReduce2", "", "");

	// Token: 0x0400BB4D RID: 47949
	[StaticVariableRuleIgnore]
	private static readonly Stat ExecToughReduceStat3 = Stat.Create("ExecToughReduce3", "", "");

	// Token: 0x0400BB4E RID: 47950
	[StaticVariableRuleIgnore]
	private static readonly Stat ExecToughReduceStat4 = Stat.Create("ExecToughReduce4", "", "");

	// Token: 0x0400BB4F RID: 47951
	[StaticVariableRuleIgnore]
	private static readonly Stat DamageDamageOptimizeStat = Stat.Create("DamageDamageOptimize", "", "");

	// Token: 0x0400BB50 RID: 47952
	private const float PER_TEN_THOUSAND = 10000f;

	// Token: 0x0400BB51 RID: 47953
	private const long NULL_INSTIGATOR_ID = -1L;

	// Token: 0x0400BB52 RID: 47954
	private const int DEFAULT_WEAPON_TYPE_NOT_PASS = -1;

	// Token: 0x0400BB53 RID: 47955
	private Dictionary<string, Dictionary<float, int>> ToughModifiers = new Dictionary<string, Dictionary<float, int>>();
}
