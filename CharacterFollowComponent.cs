using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.Protocol.Summon;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x0200303C RID: 12348
[NullableContext(1)]
[Nullable(0)]
public class CharacterFollowComponent : EntityComponent
{
	// Token: 0x17002210 RID: 8720
	// (get) Token: 0x0601942C RID: 103468 RVA: 0x0073ED11 File Offset: 0x0073CF11
	public List<int> AttributeSharerIds
	{
		get
		{
			return this.AttributeSharerIdsInternal;
		}
	}

	// Token: 0x0601942D RID: 103469 RVA: 0x0073ED1C File Offset: 0x0073CF1C
	protected override bool OnStart()
	{
		this.CreatureDataComponent = base.Entity.GetComponent<CreatureDataComponent>();
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.SkillComp = base.Entity.GetComponent<BaseSkillComponent>();
		return true;
	}

	// Token: 0x0601942E RID: 103470 RVA: 0x0073ED6E File Offset: 0x0073CF6E
	protected override void OnActivate()
	{
		this.InitFollowData();
	}

	// Token: 0x0601942F RID: 103471 RVA: 0x0073ED76 File Offset: 0x0073CF76
	protected override bool OnEnd()
	{
		this.RemoveFromAttributeHolder();
		return true;
	}

	// Token: 0x06019430 RID: 103472 RVA: 0x0073ED80 File Offset: 0x0073CF80
	private void SetAttributeHolderId(int id)
	{
		this.AttributeHolderId = id;
		if (this.AttributeHolderId != 0)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(this.AttributeHolderId);
			RoleGrowComponent roleGrowComponent = (entity != null) ? entity.GetComponent<RoleGrowComponent>() : null;
			if (roleGrowComponent != null)
			{
				CharacterSkillComponent component = base.Entity.GetComponent<CharacterSkillComponent>();
				if (component == null)
				{
					return;
				}
				component.ResetRoleGrowComponent(roleGrowComponent);
			}
		}
	}

	// Token: 0x06019431 RID: 103473 RVA: 0x0073EDD4 File Offset: 0x0073CFD4
	[NullableContext(2)]
	public AActor GetRoleActor()
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(this.AttributeHolderId);
		if (entity == null || !entity.Valid)
		{
			return null;
		}
		return entity.GetComponent<BaseActorComponent>().Owner;
	}

	// Token: 0x06019432 RID: 103474 RVA: 0x0073EE10 File Offset: 0x0073D010
	public TArray<AActor> GetAttributeSharerActors()
	{
		List<int> attributeSharerIdsInternal = this.AttributeSharerIdsInternal;
		TArray<AActor> tarray = new TArray<AActor>();
		foreach (int id in attributeSharerIdsInternal)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(id);
			if (entity != null && entity.Valid)
			{
				AActor owner = entity.GetComponent<BaseActorComponent>().Owner;
				if (owner != null)
				{
					tarray.Add(owner);
				}
			}
		}
		return tarray;
	}

	// Token: 0x06019433 RID: 103475 RVA: 0x0073EE9C File Offset: 0x0073D09C
	public TArray<AActor> GetFollowActor()
	{
		return this.GetAttributeSharerActors();
	}

	// Token: 0x06019434 RID: 103476 RVA: 0x0073EEA4 File Offset: 0x0073D0A4
	public void SetAttributeSharerId(int id)
	{
		if (this.AttributeSharerIdsInternal.IndexOf(id) == -1)
		{
			this.AttributeSharerIdsInternal.Add(id);
		}
	}

	// Token: 0x06019435 RID: 103477 RVA: 0x0073EEC1 File Offset: 0x0073D0C1
	public void SetFollowId(int id)
	{
		this.SetAttributeSharerId(id);
	}

	// Token: 0x06019436 RID: 103478 RVA: 0x0073EECC File Offset: 0x0073D0CC
	public void RemoveFromAttributeHolder()
	{
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.CreatureDataComponent.GetSummonerId());
		if (entity == null || !entity.Valid)
		{
			return;
		}
		CharacterFollowComponent component = entity.Entity.GetComponent<CharacterFollowComponent>();
		if (component == null)
		{
			return;
		}
		component.DeleteAttributeSharerId(base.Entity.Id);
	}

	// Token: 0x06019437 RID: 103479 RVA: 0x0073EF24 File Offset: 0x0073D124
	[NullableContext(2)]
	public unsafe Entity GetAttributeHolder()
	{
		if (this.AttributeHolderId != 0)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(this.AttributeHolderId);
			if (entity != null && entity.Valid)
			{
				return entity;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "FollowComp role is inValid";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.AttributeHolderId);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "SelfId";
			CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
			ptr = new ValueTuple<string, object>(item, (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return null;
	}

	// Token: 0x06019438 RID: 103480 RVA: 0x0073EFDB File Offset: 0x0073D1DB
	[NullableContext(2)]
	public Entity GetAttributeHolderExceptVisionSummon()
	{
		if (this.IsVisionSummon)
		{
			return null;
		}
		return this.GetAttributeHolder();
	}

	// Token: 0x06019439 RID: 103481 RVA: 0x0073EFED File Offset: 0x0073D1ED
	public void Reset(int entityId = 0)
	{
		this.DeleteAttributeSharerId(entityId);
		this.AttributeHolderId = 0;
	}

	// Token: 0x0601943A RID: 103482 RVA: 0x0073F000 File Offset: 0x0073D200
	public double GetToRoleDistance()
	{
		if (this.AttributeHolderId == 0)
		{
			return -1.0;
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(this.AttributeHolderId);
		if (entity == null || base.Entity == null)
		{
			return -1.0;
		}
		if (base.Entity.GetComponent<BaseActorComponent>() != null && entity.GetComponent<BaseActorComponent>() != null)
		{
			FVectorDouble actorLocation = base.Entity.GetComponent<BaseActorComponent>().ActorLocation;
			FVectorDouble actorLocation2 = entity.GetComponent<BaseActorComponent>().ActorLocation;
			return FVectorDouble.Dist(actorLocation, actorLocation2);
		}
		return -1.0;
	}

	// Token: 0x0601943B RID: 103483 RVA: 0x0073F08C File Offset: 0x0073D28C
	private void InitFollowData()
	{
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.CreatureDataComponent.GetSummonerId());
		if (entity == null || !entity.Valid)
		{
			return;
		}
		if (this.CreatureDataComponent.SummonType == ESummonType.ConcomitantVision)
		{
			VisionComponent visionComponent = this.CreatureDataComponent.GetVisionComponent();
			if (visionComponent != null)
			{
				SVisionData visionData = PhantomUtil.GetVisionData(visionComponent.VisionId);
				if (visionData != null)
				{
					this.IsVisionSummon = (visionData.类型 == EVisionType.召唤);
				}
			}
			this.SetRelationship(entity);
		}
		else if (this.CreatureDataComponent.SummonType == ESummonType.ConcomitantCustom && this.CreatureDataComponent.SummonCfgId != 0)
		{
			SummonCfg? config = ConfigSummonCfgById.GetConfig(this.CreatureDataComponent.SummonCfgId, true);
			if (config != null && config.GetValueOrDefault().ShareDamage)
			{
				this.SetRelationship(entity);
			}
		}
		BaseTagComponent component = base.Entity.GetComponent<BaseTagComponent>();
		if (component != null)
		{
			component.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["怪物.common.怪物类型.召唤物"]));
			CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
			ESummonType? esummonType = (creatureDataComponent != null) ? new ESummonType?(creatureDataComponent.SummonType) : null;
			if (esummonType != null)
			{
				switch (esummonType.GetValueOrDefault())
				{
				case ESummonType.ConcomitantVision:
					component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["怪物.common.怪物类型.召唤物.幻象"]));
					return;
				case ESummonType.ConcomitantCustom:
					component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["怪物.common.怪物类型.召唤物.角色召唤物"]));
					return;
				case ESummonType.ConcomitantPhantomRole:
					component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["怪物.common.怪物类型.召唤物.操控幻象"]));
					return;
				}
			}
			component.AddTag(new int?(GameplayTagDefine.EGameplayTagId["怪物.common.怪物类型.召唤物.默认"]));
		}
	}

	// Token: 0x0601943C RID: 103484 RVA: 0x0073F24C File Offset: 0x0073D44C
	private void DeleteAttributeSharerId(int entityId)
	{
		if (entityId != 0)
		{
			int num = this.AttributeSharerIdsInternal.IndexOf(entityId);
			if (num != -1)
			{
				this.AttributeSharerIdsInternal.RemoveAt(num);
				return;
			}
		}
		else
		{
			this.AttributeSharerIdsInternal = new List<int>();
		}
	}

	// Token: 0x0601943D RID: 103485 RVA: 0x0073F285 File Offset: 0x0073D485
	private void DeleteFollowId(int entityId)
	{
		this.DeleteAttributeSharerId(entityId);
	}

	// Token: 0x0601943E RID: 103486 RVA: 0x0073F28E File Offset: 0x0073D48E
	public void SetRelationship(EntityHandle summoner)
	{
		this.SetAttributeHolderId(summoner.Id);
		summoner.Entity.GetComponent<CharacterFollowComponent>().SetAttributeSharerId(base.Entity.Id);
		Singleton<EventSystem>.Instance.EmitWithTarget<int>(this, EEventName.OnCharacterSetMaster, summoner.Id);
	}

	// Token: 0x0601943F RID: 103487 RVA: 0x0073F2D0 File Offset: 0x0073D4D0
	public void ListenConcomitantInherit(IConcomitantInheritContext context)
	{
		this.CurrentConcomitantInherit = context;
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharInterruptSkill, new Action<int, int>(this.OnCharBeforeInterrupt));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharBeforeInterruptWithTarget, new Action<int, int>(this.OnCharBeforeInterruptWithTarget));
	}

	// Token: 0x06019440 RID: 103488 RVA: 0x0073F324 File Offset: 0x0073D524
	public void RemoveListenConcomitantInherit()
	{
		this.CurrentConcomitantInherit = null;
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharInterruptSkill, new Action<int, int>(this.OnCharBeforeInterrupt));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharBeforeInterruptWithTarget, new Action<int, int>(this.OnCharBeforeInterruptWithTarget));
	}

	// Token: 0x06019441 RID: 103489 RVA: 0x0073F378 File Offset: 0x0073D578
	private void OnCharBeforeInterrupt(int entityId, int interruptedSkillId)
	{
		this.CheckStartConcomitantInherit(interruptedSkillId, null);
	}

	// Token: 0x06019442 RID: 103490 RVA: 0x0073F395 File Offset: 0x0073D595
	private void OnCharBeforeInterruptWithTarget(int newSkillId, int interruptedSkillId)
	{
		this.CheckStartConcomitantInherit(interruptedSkillId, new int?(newSkillId));
	}

	// Token: 0x06019443 RID: 103491 RVA: 0x0073F3A4 File Offset: 0x0073D5A4
	private void CheckStartConcomitantInherit(int interruptedSkillId, int? newSkillId = null)
	{
		if (this.CurrentConcomitantInherit == null)
		{
			return;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.IsAutonomousProxy)
		{
			return;
		}
		Entity entity = base.Entity;
		BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
		if (baseSkillComponent == null)
		{
			return;
		}
		global::Skill currentSkill = baseSkillComponent.CurrentSkill;
		if (currentSkill == null || currentSkill.SkillId != interruptedSkillId)
		{
			return;
		}
		EEndSkillReason reason = baseSkillComponent.GetSkill(interruptedSkillId).EndSkillInfo.Reason;
		if (reason != EEndSkillReason.BeginOtherSkill)
		{
			if (reason != EEndSkillReason.BeHit)
			{
				if (!this.CurrentConcomitantInherit.OtherInterrupt)
				{
					return;
				}
			}
			else if (!this.CurrentConcomitantInherit.HitInterrupt)
			{
				return;
			}
		}
		else
		{
			if (newSkillId == null)
			{
				return;
			}
			if (!this.CurrentConcomitantInherit.SkillInterrupt)
			{
				return;
			}
			if (this.CurrentConcomitantInherit.NewSkillIds.Count > 0 && !this.CurrentConcomitantInherit.NewSkillIds.Contains((long)newSkillId.Value))
			{
				return;
			}
		}
		this.CurrentConcomitantInherit.SkillId = new int?(interruptedSkillId);
		this.StartConcomitantInherit(this.CurrentConcomitantInherit);
	}

	// Token: 0x06019444 RID: 103492 RVA: 0x0073F4A0 File Offset: 0x0073D6A0
	public void StartConcomitantInherit(IConcomitantInheritContext context)
	{
		float currentMontagePosition = this.AnimComp.MontageGetPosition();
		BaseSkillComponent skillComp = this.SkillComp;
		int num = (skillComp != null) ? skillComp.GetPlayingMontageIndex(context.SkillId.Value) : -1;
		Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Skill, base.Entity, "[伴生物继承本体技能表现]开始", default(ReadOnlySpan<ValueTuple<string, object>>));
		EntityHandle summonEntity = PhantomUtil.GetSummonedEntity(base.Entity, ESummonType.ConcomitantCustom, context.SummonIndex);
		EntityHandle summonEntity2 = summonEntity;
		if (summonEntity2 == null || !summonEntity2.Valid)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			Entity entity = base.Entity;
			string message = "[伴生物继承本体技能表现]伴生物不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SummonIndex", context.SummonIndex);
			instance.Warn(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		ControllerBase<CreatureController>.Instance.SetEntityEnable(summonEntity.Entity, true, "ConcomitantInherit", true);
		CharacterActorComponent component = summonEntity.Entity.GetComponent<CharacterActorComponent>();
		if (component != null)
		{
			component.SetActorLocationAndRotation(this.ActorComp.ActorLocation, this.ActorComp.ActorRotation, "ConcomitantInherit", false, null);
		}
		if (context.StartCue > 0L)
		{
			BaseGameplayCueComponent component2 = summonEntity.Entity.GetComponent<BaseGameplayCueComponent>();
			if (component2 != null)
			{
				component2.AddCue(context.StartCue, new GameplayCueParam?(new GameplayCueParam
				{
					Instant = true,
					Sync = new bool?(true)
				}));
			}
		}
		if (context.BuffId > 0L)
		{
			CharacterBuffComponent component3 = summonEntity.Entity.GetComponent<CharacterBuffComponent>();
			if (component3 != null)
			{
				component3.AddBuff(context.BuffId, new AddBuffParam
				{
					InstigatorId = this.CreatureDataComponent.GetCreatureDataId(),
					PreMessageId = context.PreMessage,
					Reason = "伴生物继承本体技能表现添加"
				});
			}
		}
		BaseSkillComponent component4 = summonEntity.Entity.GetComponent<BaseSkillComponent>();
		this.ConcomitantInheritMap[context.SummonIndex] = context;
		if (component4 == null)
		{
			return;
		}
		int value = context.SkillId.Value;
		SkillParam skillParam = new SkillParam();
		skillParam.MontageIndex = ((num > -1) ? new int?(num) : null);
		BaseSkillComponent skillComp2 = this.SkillComp;
		Entity target;
		if (skillComp2 == null)
		{
			target = null;
		}
		else
		{
			EntityHandle skillTarget = skillComp2.SkillTarget;
			target = ((skillTarget != null) ? skillTarget.Entity : null);
		}
		skillParam.Target = target;
		skillParam.Reason = "ConcomitantInherit";
		TTimerAction <>9__1;
		Action<UAnimMontage, bool> <>9__2;
		component4.BeginSkillAsync(value, skillParam).ContinueWith(delegate(bool result)
		{
			if (result)
			{
				CharacterAnimationComponent component5 = summonEntity.Entity.GetComponent<CharacterAnimationComponent>();
				if (component5 != null)
				{
					UAnimInstance mainAnimInstance = component5.MainAnimInstance;
					if (mainAnimInstance != null)
					{
						mainAnimInstance.ForceSetCurrentMontageBlendTime(0f, null);
					}
				}
				if (component5 != null)
				{
					component5.MontageSetPosition(currentMontagePosition);
				}
				EConcomitantDurationType concomitantDurationType = context.ConcomitantDurationType;
				if (concomitantDurationType != EConcomitantDurationType.蒙太奇结束消失)
				{
					if (concomitantDurationType == EConcomitantDurationType.固定时间)
					{
						IConcomitantInheritContext context2 = context;
						TimerSystemInstance instance2 = TimerSystem.Instance;
						TTimerAction action;
						if ((action = <>9__1) == null)
						{
							action = (<>9__1 = delegate(float _)
							{
								this.EndConcomitantInherit(context.SummonIndex);
							});
						}
						context2.TimerHandle = instance2.Delay(action, context.Duration, null, null, true, 1f);
						return;
					}
				}
				else
				{
					IConcomitantInheritContext context3 = context;
					UAnimMontage currentMontage;
					if (component5 == null)
					{
						currentMontage = null;
					}
					else
					{
						UAnimInstance mainAnimInstance2 = component5.MainAnimInstance;
						currentMontage = ((mainAnimInstance2 != null) ? mainAnimInstance2.GetCurrentActiveMontage() : null);
					}
					context3.CurrentMontage = currentMontage;
					IConcomitantInheritContext context4 = context;
					Action<UAnimMontage, bool> onMontageEnded;
					if ((onMontageEnded = <>9__2) == null)
					{
						onMontageEnded = (<>9__2 = delegate(UAnimMontage montage, bool bInterrupted)
						{
							if (montage != context.CurrentMontage)
							{
								return;
							}
							this.EndConcomitantInherit(context.SummonIndex);
						});
					}
					context4.OnMontageEnded = onMontageEnded;
					context.SummonAnimComp = component5;
					if (component5 != null)
					{
						UAnimInstance mainAnimInstance3 = component5.MainAnimInstance;
						if (mainAnimInstance3 == null)
						{
							return;
						}
						mainAnimInstance3.OnMontageEnded.Add(context.OnMontageEnded);
					}
				}
			}
		});
	}

	// Token: 0x06019445 RID: 103493 RVA: 0x0073F74C File Offset: 0x0073D94C
	public void EndConcomitantInherit(int summonIndex)
	{
		Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Skill, base.Entity, "[伴生物继承本体技能表现]结束", default(ReadOnlySpan<ValueTuple<string, object>>));
		IConcomitantInheritContext concomitantInheritContext;
		if (!this.ConcomitantInheritMap.TryGetValue(summonIndex, out concomitantInheritContext))
		{
			return;
		}
		this.ConcomitantInheritMap.Remove(summonIndex);
		TimerHandle timerHandle = concomitantInheritContext.TimerHandle;
		if (timerHandle != null)
		{
			timerHandle.Remove();
		}
		if (concomitantInheritContext.OnMontageEnded != null && concomitantInheritContext.SummonAnimComp != null)
		{
			UAnimInstance mainAnimInstance = concomitantInheritContext.SummonAnimComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.OnMontageEnded.Remove(concomitantInheritContext.OnMontageEnded);
			}
			concomitantInheritContext.OnMontageEnded = null;
		}
		EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(base.Entity, ESummonType.ConcomitantCustom, summonIndex);
		if (summonedEntity == null || !summonedEntity.Valid)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			Entity entity = base.Entity;
			string message = "[伴生物继承本体技能表现]伴生物不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SummonIndex", summonIndex);
			instance.Warn(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (concomitantInheritContext.EndCue > 0L)
		{
			BaseGameplayCueComponent component = summonedEntity.Entity.GetComponent<BaseGameplayCueComponent>();
			if (component != null)
			{
				component.AddCue(concomitantInheritContext.EndCue, new GameplayCueParam?(new GameplayCueParam
				{
					Instant = true,
					Sync = new bool?(true)
				}));
			}
		}
		if (concomitantInheritContext.BuffId > 0L)
		{
			CharacterBuffComponent component2 = summonedEntity.Entity.GetComponent<CharacterBuffComponent>();
			if (component2 != null)
			{
				component2.RemoveBuff(concomitantInheritContext.BuffId, -1, "伴生物继承本体技能表现", null, null, null);
			}
		}
		ControllerBase<CreatureController>.Instance.SetEntityEnable(summonedEntity.Entity, false, "ConcomitantInherit", true);
	}

	// Token: 0x06019446 RID: 103494 RVA: 0x0073F8DC File Offset: 0x0073DADC
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterFollowComponent characterFollowComponent = (CharacterFollowComponent)componentTemplate;
		if (base.CanResetComponentProperty("CreatureDataComponent"))
		{
			if (characterFollowComponent.CreatureDataComponent == null)
			{
				this.CreatureDataComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (characterFollowComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterFollowComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillComp"))
		{
			if (characterFollowComponent.SkillComp == null)
			{
				this.SkillComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseSkillComponent>(this.SkillComp), "SkillComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AttributeSharerIdsInternal"))
		{
			if (characterFollowComponent.AttributeSharerIdsInternal == null)
			{
				this.AttributeSharerIdsInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<int>>(this.AttributeSharerIdsInternal), "AttributeSharerIdsInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AttributeHolderId"))
		{
			this.AttributeHolderId = characterFollowComponent.AttributeHolderId;
		}
		if (base.CanResetComponentProperty("IsVisionSummon"))
		{
			this.IsVisionSummon = characterFollowComponent.IsVisionSummon;
		}
		if (base.CanResetComponentProperty("CurrentConcomitantInherit"))
		{
			if (characterFollowComponent.CurrentConcomitantInherit == null)
			{
				this.CurrentConcomitantInherit = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<IConcomitantInheritContext>(this.CurrentConcomitantInherit), "CurrentConcomitantInherit"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ConcomitantInheritMap"))
		{
			if (characterFollowComponent.ConcomitantInheritMap == null)
			{
				this.ConcomitantInheritMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, IConcomitantInheritContext>>(this.ConcomitantInheritMap), "ConcomitantInheritMap"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400C6E0 RID: 50912
	[Nullable(2)]
	private CreatureDataComponent CreatureDataComponent;

	// Token: 0x0400C6E1 RID: 50913
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400C6E2 RID: 50914
	[Nullable(2)]
	protected CharacterActorComponent ActorComp;

	// Token: 0x0400C6E3 RID: 50915
	[Nullable(2)]
	private BaseSkillComponent SkillComp;

	// Token: 0x0400C6E4 RID: 50916
	private List<int> AttributeSharerIdsInternal = new List<int>();

	// Token: 0x0400C6E5 RID: 50917
	private int AttributeHolderId;

	// Token: 0x0400C6E6 RID: 50918
	private bool IsVisionSummon;

	// Token: 0x0400C6E7 RID: 50919
	[Nullable(2)]
	public IConcomitantInheritContext CurrentConcomitantInherit;

	// Token: 0x0400C6E8 RID: 50920
	public Dictionary<int, IConcomitantInheritContext> ConcomitantInheritMap = new Dictionary<int, IConcomitantInheritContext>();
}
