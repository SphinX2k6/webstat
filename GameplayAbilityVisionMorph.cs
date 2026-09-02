using System;
using System.Runtime.CompilerServices;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200315F RID: 12639
[NullableContext(2)]
[Nullable(0)]
public class GameplayAbilityVisionMorph : GameplayAbilityVisionBase
{
	// Token: 0x0601A30A RID: 107274 RVA: 0x007B1385 File Offset: 0x007AF585
	[NullableContext(1)]
	public GameplayAbilityVisionMorph(CharacterVisionComponent visionComponent) : base(visionComponent)
	{
	}

	// Token: 0x0601A30B RID: 107275 RVA: 0x007B138E File Offset: 0x007AF58E
	protected override void OnCreate()
	{
		this.StealthTagTask = base.GameplayTagComponent.ListenForTagAddOrRemove(new int?(GameplayAbilityVisionMisc.stealthTag), delegate(int tagId, bool tagExist)
		{
			if (tagExist)
			{
				BaseTagComponent visionTagComponent = this.VisionTagComponent;
				if (visionTagComponent == null)
				{
					return;
				}
				visionTagComponent.AddTag(new int?(GameplayAbilityVisionMisc.stealthTag));
				return;
			}
			else
			{
				BaseTagComponent visionTagComponent2 = this.VisionTagComponent;
				if (visionTagComponent2 == null)
				{
					return;
				}
				visionTagComponent2.RemoveTag(new int?(GameplayAbilityVisionMisc.stealthTag));
				return;
			}
		}, null);
	}

	// Token: 0x0601A30C RID: 107276 RVA: 0x007B13B8 File Offset: 0x007AF5B8
	protected override void OnDestroy()
	{
		this.EndAllTask();
		VisionSkillComponent visionSkillComponent = this.VisionSkillComponent;
		if (visionSkillComponent != null)
		{
			visionSkillComponent.OnVisionAbilityDestroy();
		}
		ITagTask stealthTagTask = this.StealthTagTask;
		if (stealthTagTask == null)
		{
			return;
		}
		stealthTagTask.EndTask();
	}

	// Token: 0x0601A30D RID: 107277 RVA: 0x007B13E4 File Offset: 0x007AF5E4
	protected unsafe override void OnTick(float delta)
	{
		if (this.Synchronized)
		{
			float num = this.VisionActorComponent.ScaledHalfHeight - base.ActorComponent.ScaledHalfHeight;
			Vector tempVector = GameplayAbilityVisionMisc.tempVector1;
			tempVector.DeepCopy(this.VisionActorComponent.ActorLocationProxy);
			Vector tempVector2 = GameplayAbilityVisionMisc.tempVector2;
			base.MoveComponent.GravityUp.Multiply((double)num, tempVector2);
			tempVector.SubtractionEqual(tempVector2);
			if (this.IsHit(base.ActorComponent.ActorLocationProxy, tempVector))
			{
				Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.HXY, "变身OnTick过程穿墙，需打断幻象变身技能", default(ReadOnlySpan<ValueTuple<string, object>>));
				Singleton<EventSystem>.Instance.Emit(EEventName.VisionMorphInterrupt);
				BaseSkillComponent skillComponent = base.SkillComponent;
				Skill currentSkill = base.SkillComponent.CurrentSkill;
				skillComponent.EndSkill((currentSkill != null) ? currentSkill.SkillId : 0, "GameplayAbilityVisionMorph.IsHit");
				return;
			}
			base.ActorComponent.SetActorLocationAndRotation(tempVector.ToUeVector(false), this.VisionActorComponent.ActorRotation, "GameplayAbilityVisionMorph.OnTick", false, null);
			if (this.PrintLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.HXY;
				string message = "GameplayAbilityVisionMorph.OnTick设置位置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("人的位置", base.ActorComponent.ActorLocationProxy);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("幻象的位置", this.VisionActorComponent.ActorLocationProxy);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.PrintLog = false;
			}
		}
	}

	// Token: 0x0601A30E RID: 107278 RVA: 0x007B155C File Offset: 0x007AF75C
	protected override bool OnActivateAbility()
	{
		if (this.IsActivating || !this.Init())
		{
			return false;
		}
		this.IsActivating = true;
		if (!this.VisionData.空中能否释放)
		{
			base.SkillComponent.PlaySkillMontage(0, "", 0f, null);
		}
		this.SetCollision(false, null);
		base.GameplayTagComponent.AddTag(new int?(GameplayAbilityVisionMisc.invincibleTag));
		base.BuffComponent.RemoveBuff(1101004005L, -1, "幻象变身技能激活时移除角色禁止闪避的Buff", null, null, null);
		base.CueComponent.AddCue(19000000191L, new GameplayCueParam?(new GameplayCueParam
		{
			Sync = new bool?(true),
			Instant = true
		}));
		TimerSystemInstance instance = TimerSystem.Instance;
		TTimerAction action = delegate(float _)
		{
			this.SetCharacterHidden(true);
		};
		float num = 300f;
		CharacterModel instance2 = ModelBase<CharacterModel>.Instance;
		this.CharacterHiddenTimer = instance.Delay(action, num * ((instance2 != null) ? instance2.SelfCenteredTimeDilation : 1f), null, null, true, 1f);
		this.MorphBegin();
		return true;
	}

	// Token: 0x0601A30F RID: 107279 RVA: 0x007B1674 File Offset: 0x007AF874
	protected override bool OnEndAbility()
	{
		if (!this.IsActivating)
		{
			return true;
		}
		this.IsActivating = false;
		this.MorphEnd(false);
		base.GameplayTagComponent.RemoveTag(new int?(GameplayAbilityVisionMisc.invincibleTag));
		base.GameplayTagComponent.RemoveTag(new int?(GameplayAbilityVisionMisc.morphTag));
		return true;
	}

	// Token: 0x0601A310 RID: 107280 RVA: 0x007B16C6 File Offset: 0x007AF8C6
	public override bool HandlePress(EInputAction action, float time)
	{
		return this.VisionSkillComponent != null && this.VisionSkillComponent.HandlePress(action, time);
	}

	// Token: 0x0601A311 RID: 107281 RVA: 0x007B16E0 File Offset: 0x007AF8E0
	private bool Init()
	{
		this.PreInit();
		if (!this.VisionEntity.IsInit)
		{
			return false;
		}
		if (this.NeedNoActive() && this.VisionEntity.Entity.Active)
		{
			return false;
		}
		if (this.NeedNoAi())
		{
			CharacterAiComponent component = this.VisionEntity.Entity.GetComponent<CharacterAiComponent>();
			if (component != null && component.IsEnabled())
			{
				Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Skill, this.VisionEntity.Entity, "变身幻象不能配置AI，请检查一下AI配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
		}
		this.VisionActorComponent = this.VisionEntity.Entity.GetComponent<CharacterActorComponent>();
		this.VisionTagComponent = this.VisionEntity.Entity.GetComponent<BaseTagComponent>();
		this.VisionBuffComponent = this.VisionEntity.Entity.GetComponent<CharacterBuffComponent>();
		this.VisionCueComponent = this.VisionEntity.Entity.GetComponent<CharacterGameplayCueComponent>();
		this.VisionMoveComponent = this.VisionEntity.Entity.GetComponent<CharacterMoveComponent>();
		this.VisionSkillComponent = this.VisionEntity.Entity.GetComponent<VisionSkillComponent>();
		this.VisionSkillComponent.InitVisionSkill(base.EntityHandle, true);
		return true;
	}

	// Token: 0x0601A312 RID: 107282 RVA: 0x007B1804 File Offset: 0x007AFA04
	private void SetCollision(bool enable, EntityHandle visionEntity = null)
	{
		if (visionEntity == null)
		{
			visionEntity = this.VisionEntity;
		}
		CharacterActorComponent characterActorComponent;
		if (visionEntity == null)
		{
			characterActorComponent = null;
		}
		else
		{
			WorldEntity entity = visionEntity.Entity;
			characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
		}
		CharacterActorComponent characterActorComponent2 = characterActorComponent;
		if (characterActorComponent2 == null)
		{
			return;
		}
		Singleton<CollisionUtils>.Instance.SetCollisionResponseToPawn(characterActorComponent2.Actor.CapsuleComponent, EPawnChannel.PawnPlayer, enable ? ECollisionResponse.ECR_Block : ECollisionResponse.ECR_Ignore);
		characterActorComponent2.Actor.CapsuleComponent.IgnoreActorWhenMoving(base.ActorComponent.Actor, !enable);
		base.ActorComponent.Actor.CapsuleComponent.IgnoreActorWhenMoving(characterActorComponent2.Actor, !enable);
	}

	// Token: 0x0601A313 RID: 107283 RVA: 0x007B1894 File Offset: 0x007AFA94
	private unsafe void MorphBegin()
	{
		this.IsMorphing = true;
		this.VisionMoveComponent.SetForceSpeed(Vector.ZeroVectorProxy);
		this.SetVisionEnable(true, null);
		Vector tempVector = GameplayAbilityVisionMisc.tempVector1;
		base.MoveComponent.GravityUp.Multiply((double)(this.VisionActorComponent.ScaledHalfHeight - base.ActorComponent.ScaledHalfHeight), tempVector);
		BaseActorComponent visionActorComponent = this.VisionActorComponent;
		FVectorDouble actorLocation = base.ActorComponent.ActorLocation;
		FVectorDouble fvectorDouble = tempVector.ToUeVector(false);
		visionActorComponent.SetActorLocationAndRotation(actorLocation + fvectorDouble, base.ActorComponent.ActorRotation, "幻象变身出现位置", false, null);
		this.PrintLog = true;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Battle;
		ELogAuthor author = ELogAuthor.HXY;
		string message = "GameplayAbilityVisionMorph.MorphBegin设置位置";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("人的位置", base.ActorComponent.ActorLocationProxy);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("幻象的位置", this.VisionActorComponent.ActorLocationProxy);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.Synchronized = true;
		base.GameplayTagComponent.AddTag(new int?(GameplayAbilityVisionMisc.morphTag));
		if (this.WaitMorphTagRemoveTask == null)
		{
			this.WaitMorphTagRemoveTask = base.GameplayTagComponent.ListenForTagAddOrRemove(new int?(GameplayAbilityVisionMisc.morphTag), delegate(int tagId, bool tagExist)
			{
				if (!tagExist)
				{
					this.MorphEnd(true);
				}
			}, null);
		}
		this.VisionBuffComponent.AddBuff(1900000017L, new AddBuffParam
		{
			InstigatorId = this.VisionBuffComponent.CreatureDataId,
			Reason = "开始幻象变身时幻象自身的材质和粒子"
		});
		int 技能ID = this.VisionData.技能ID;
		if (技能ID > 0)
		{
			BaseSkillComponent visionSkillComponent = this.VisionSkillComponent;
			int skillId = 技能ID;
			SkillParam skillParam = new SkillParam();
			EntityHandle skillTarget = base.SkillComponent.SkillTarget;
			skillParam.Target = ((skillTarget != null) ? skillTarget.Entity : null);
			skillParam.SocketName = base.SkillComponent.SkillTargetSocket;
			skillParam.Reason = "VisionSkill.BeginSkill";
			skillParam.CheckMultiSkill = new bool?(true);
			visionSkillComponent.BeginSkill(skillId, skillParam);
			base.SkillComponent.SkillTarget = this.VisionSkillComponent.SkillTarget;
			base.SkillComponent.SkillTargetSocket = this.VisionSkillComponent.SkillTargetSocket;
		}
		ControllerBase<RoleAudioController>.Instance.PlayRoleAudio(base.Entity, ERoleAudioType.VisionMorph, null);
		Singleton<EventSystem>.Instance.Emit<EntityHandle, EntityHandle>(EEventName.VisionMorphBegin, this.VisionEntity, base.EntityHandle);
		Singleton<EventSystem>.Instance.EmitWithTargets<EntityHandle, EntityHandle>(new object[]
		{
			base.EntityHandle.Entity,
			this.VisionEntity.Entity
		}, EEventName.VisionMorphBegin, this.VisionEntity, base.EntityHandle);
	}

	// Token: 0x0601A314 RID: 107284 RVA: 0x007B1B28 File Offset: 0x007AFD28
	private void MorphEnd(bool playMontage)
	{
		if (!this.IsMorphing)
		{
			return;
		}
		this.IsMorphing = false;
		this.EndAllTask();
		this.PlayEndEffect();
		this.SetCharacterHidden(false);
		base.MoveComponent.SetForceSpeed(Vector.ZeroVectorProxy);
		bool flag = this.FixMovementMode();
		if (playMontage)
		{
			if (flag)
			{
				base.SkillComponent.PlaySkillMontage(1, "", 0f, delegate(bool _)
				{
					this.<MorphEnd>g__endSkill|25_0();
				});
			}
			else
			{
				this.<MorphEnd>g__endSkill|25_0();
			}
		}
		else
		{
			this.<MorphEnd>g__endSkill|25_0();
		}
		this.VisionSkillComponent.OnMorphEnd();
		Singleton<EventSystem>.Instance.Emit<EntityHandle, EntityHandle>(EEventName.VisionMorphEnd, base.EntityHandle, this.VisionEntity);
		Singleton<EventSystem>.Instance.EmitWithTargets<EntityHandle, EntityHandle>(new object[]
		{
			base.EntityHandle.Entity,
			this.VisionEntity.Entity
		}, EEventName.VisionMorphEnd, base.EntityHandle, this.VisionEntity);
	}

	// Token: 0x0601A315 RID: 107285 RVA: 0x007B1C0C File Offset: 0x007AFE0C
	private void SetCharacterHidden(bool hidden)
	{
		if (!hidden)
		{
			base.CueComponent.AddCue(19000000201L, new GameplayCueParam?(new GameplayCueParam
			{
				Sync = new bool?(true),
				Instant = true
			}));
			Singleton<MathUtils>.Instance.LookRotationUpFirst(base.ActorComponent.ActorForwardProxy, base.MoveComponent.GravityUp, GameplayAbilityVisionMisc.tempRotator);
			base.ActorComponent.SetActorRotation(GameplayAbilityVisionMisc.tempRotator.ToUeRotator(), "GameplayAbilityVisionMorph.SetCharacterHidden", false);
		}
		ControllerBase<CreatureController>.Instance.SetActorVisible(base.Entity, !hidden, true, true, "幻象变身技能隐藏角色", true);
	}

	// Token: 0x0601A316 RID: 107286 RVA: 0x007B1CB4 File Offset: 0x007AFEB4
	private void EndAllTask()
	{
		this.Synchronized = false;
		if (this.WaitMorphTagRemoveTask != null)
		{
			this.WaitMorphTagRemoveTask.EndTask();
			this.WaitMorphTagRemoveTask = null;
		}
		if (this.CharacterHiddenTimer != null && TimerSystem.Instance.Has(this.CharacterHiddenTimer))
		{
			TimerSystem.Instance.Remove(this.CharacterHiddenTimer);
			this.CharacterHiddenTimer = null;
		}
	}

	// Token: 0x0601A317 RID: 107287 RVA: 0x007B1D14 File Offset: 0x007AFF14
	private bool FixMovementMode()
	{
		UTraceLineElement staticLineTrace = SkillUtils.GetStaticLineTrace();
		Vector actorLocationProxy = base.ActorComponent.ActorLocationProxy;
		float num = base.ActorComponent.ScaledHalfHeight + 20f;
		Vector tempVector = GameplayAbilityVisionMisc.tempVector1;
		base.MoveComponent.GravityDirect.Multiply((double)num, tempVector);
		tempVector.AdditionEqual(actorLocationProxy);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(staticLineTrace, actorLocationProxy);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(staticLineTrace, tempVector);
		return Singleton<TraceElementCommon>.Instance.LineTrace(staticLineTrace, "GameplayAbilityVisionMorph.FixMovementMode") && staticLineTrace.HitResult.bBlockingHit;
	}

	// Token: 0x0601A318 RID: 107288 RVA: 0x007B1DA0 File Offset: 0x007AFFA0
	private void PlayEndEffect()
	{
		GameplayAbilityVisionMorph.<>c__DisplayClass29_0 CS$<>8__locals1 = new GameplayAbilityVisionMorph.<>c__DisplayClass29_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.capturedVisionEntity = this.VisionEntity;
		CS$<>8__locals1.capturedVisionCueComponent = this.VisionCueComponent;
		CS$<>8__locals1.capturedVisionHiddenTimer = null;
		CharacterGameplayCueComponent capturedVisionCueComponent = CS$<>8__locals1.capturedVisionCueComponent;
		if (capturedVisionCueComponent != null)
		{
			capturedVisionCueComponent.AddCue(19000000182L, new GameplayCueParam?(new GameplayCueParam
			{
				Sync = new bool?(true),
				Instant = true
			}));
		}
		CS$<>8__locals1.cueHandle = 0;
		CS$<>8__locals1.cueHandle = CS$<>8__locals1.capturedVisionCueComponent.AddCue(19000000181L, new GameplayCueParam?(new GameplayCueParam
		{
			EndCallback = delegate()
			{
				if (CS$<>8__locals1.capturedVisionHiddenTimer != null && TimerSystem.Instance.Has(CS$<>8__locals1.capturedVisionHiddenTimer))
				{
					TimerSystem.Instance.Remove(CS$<>8__locals1.capturedVisionHiddenTimer);
					CS$<>8__locals1.capturedVisionHiddenTimer = null;
					CS$<>8__locals1.<>4__this.VisionDisable(CS$<>8__locals1.cueHandle, CS$<>8__locals1.capturedVisionEntity, CS$<>8__locals1.capturedVisionCueComponent);
				}
			},
			Sync = new bool?(true)
		}));
		GameplayAbilityVisionMorph.<>c__DisplayClass29_0 CS$<>8__locals2 = CS$<>8__locals1;
		TimerSystemInstance instance = TimerSystem.Instance;
		TTimerAction action = delegate(float _)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.HXY, "幻象消失材质没有正常结束，被保底", default(ReadOnlySpan<ValueTuple<string, object>>));
			CS$<>8__locals1.capturedVisionHiddenTimer = null;
			CS$<>8__locals1.<>4__this.VisionDisable(CS$<>8__locals1.cueHandle, CS$<>8__locals1.capturedVisionEntity, CS$<>8__locals1.capturedVisionCueComponent);
		};
		float num = 1000f;
		CharacterModel instance2 = ModelBase<CharacterModel>.Instance;
		CS$<>8__locals2.capturedVisionHiddenTimer = instance.Delay(action, num * ((instance2 != null) ? instance2.SelfCenteredTimeDilation : 1f), null, null, true, 1f);
	}

	// Token: 0x0601A319 RID: 107289 RVA: 0x007B1EA8 File Offset: 0x007B00A8
	[NullableContext(1)]
	private bool IsHit(Vector startLocation, Vector endLocation)
	{
		UTraceLineElement staticLineTrace = SkillUtils.GetStaticLineTrace();
		Singleton<TraceElementCommon>.Instance.SetStartLocation(staticLineTrace, startLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(staticLineTrace, endLocation);
		return Singleton<TraceElementCommon>.Instance.LineTrace(staticLineTrace, "GameplayAbilityVisionMorph.FixLocation") && staticLineTrace.HitResult.bBlockingHit;
	}

	// Token: 0x0601A31A RID: 107290 RVA: 0x007B1EF4 File Offset: 0x007B00F4
	private void VisionDisable(int cueHandle, EntityHandle visionEntity, CharacterGameplayCueComponent visionCueComponent)
	{
		if (this.IsActivating)
		{
			base.GameplayTagComponent.RemoveTag(new int?(GameplayAbilityVisionMisc.invincibleTag));
		}
		if (visionEntity != null && visionEntity.Valid)
		{
			ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(visionEntity.Entity, "210000004", null, null, null, EBulletCreateSource.Others);
			if (visionCueComponent != null)
			{
				visionCueComponent.RemoveCueByHandle((long)cueHandle);
			}
			this.SetVisionEnable(false, visionEntity);
			this.SetCollision(true, visionEntity);
		}
	}

	// Token: 0x0601A31B RID: 107291 RVA: 0x007B1F6F File Offset: 0x007B016F
	protected virtual void SetVisionEnable(bool enable, EntityHandle visionEntity = null)
	{
		if (visionEntity == null)
		{
			visionEntity = this.VisionEntity;
		}
		ControllerBase<CreatureController>.Instance.SetEntityEnable(visionEntity.Entity, enable, "GameplayAbilityVisionMorph.SetVisionEnable", true);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPhantomEnableStateChange, enable);
	}

	// Token: 0x0601A31C RID: 107292 RVA: 0x007B1FA4 File Offset: 0x007B01A4
	protected virtual void PreInit()
	{
		this.VisionEntity = PhantomUtil.GetSummonedEntity(this.VisionComponent.Entity, ESummonType.ConcomitantVision, 1);
		this.VisionData = PhantomUtil.GetVisionData(this.VisionComponent.GetVisionId(null));
	}

	// Token: 0x0601A31D RID: 107293 RVA: 0x007B1FE8 File Offset: 0x007B01E8
	protected virtual bool NeedNoAi()
	{
		return true;
	}

	// Token: 0x0601A31E RID: 107294 RVA: 0x007B1FEB File Offset: 0x007B01EB
	protected virtual bool NeedNoActive()
	{
		return true;
	}

	// Token: 0x0601A322 RID: 107298 RVA: 0x007B203E File Offset: 0x007B023E
	[CompilerGenerated]
	private void <MorphEnd>g__endSkill|25_0()
	{
		BaseSkillComponent skillComponent = base.SkillComponent;
		Skill currentSkill = base.SkillComponent.CurrentSkill;
		skillComponent.EndSkill((currentSkill != null) ? currentSkill.SkillId : 0, "GameplayAbilityVisionMorph.MorphEnd");
	}

	// Token: 0x0400D2A2 RID: 53922
	protected EntityHandle VisionEntity;

	// Token: 0x0400D2A3 RID: 53923
	protected SVisionData VisionData;

	// Token: 0x0400D2A4 RID: 53924
	protected CharacterActorComponent VisionActorComponent;

	// Token: 0x0400D2A5 RID: 53925
	private BaseTagComponent VisionTagComponent;

	// Token: 0x0400D2A6 RID: 53926
	protected CharacterBuffComponent VisionBuffComponent;

	// Token: 0x0400D2A7 RID: 53927
	private CharacterGameplayCueComponent VisionCueComponent;

	// Token: 0x0400D2A8 RID: 53928
	private CharacterMoveComponent VisionMoveComponent;

	// Token: 0x0400D2A9 RID: 53929
	protected VisionSkillComponent VisionSkillComponent;

	// Token: 0x0400D2AA RID: 53930
	private ITagTask WaitMorphTagRemoveTask;

	// Token: 0x0400D2AB RID: 53931
	private ITagTask StealthTagTask;

	// Token: 0x0400D2AC RID: 53932
	private TimerHandle CharacterHiddenTimer;

	// Token: 0x0400D2AD RID: 53933
	private bool IsActivating;

	// Token: 0x0400D2AE RID: 53934
	private bool IsMorphing;

	// Token: 0x0400D2AF RID: 53935
	private bool Synchronized;

	// Token: 0x0400D2B0 RID: 53936
	private bool PrintLog;
}
