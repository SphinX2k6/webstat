using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.Swing;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using UnrealEngine;

// Token: 0x02002FEE RID: 12270
[NullableContext(1)]
[Nullable(0)]
public class CharacterSwingComponent : EntityComponent
{
	// Token: 0x06019011 RID: 102417 RVA: 0x00718040 File Offset: 0x00716240
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.MoveComp = base.Entity.GetComponent<BaseMoveComponent>();
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		return true;
	}

	// Token: 0x06019012 RID: 102418 RVA: 0x00718094 File Offset: 0x00716294
	protected override void OnTick(float delta)
	{
		if (this.IsStartSwing)
		{
			PawnChairController chairController = this.ChairController;
			bool flag;
			if (chairController == null)
			{
				flag = false;
			}
			else
			{
				Entity entity = chairController.Entity;
				bool? flag2;
				if (entity == null)
				{
					flag2 = null;
				}
				else
				{
					SceneItemActorComponent component = entity.GetComponent<SceneItemActorComponent>();
					flag2 = ((component != null) ? new bool?(component.GetIsSceneInteractionLoadCompleted()) : null);
				}
				bool? flag3 = flag2;
				flag = flag3.GetValueOrDefault();
			}
			bool flag4 = flag;
			if (this.SwingMontage != null && flag4)
			{
				SwingConfig swingConfig = this.SwingConfig;
				if (swingConfig != null && swingConfig.IsRole)
				{
					this.OnStartRoleSwing();
				}
				else
				{
					this.OnStartSwing();
				}
				this.IsStartSwing = false;
			}
		}
		if (this.SwingState == ESwingStateType.EnterSwing || this.SwingState == ESwingStateType.LoopSwing)
		{
			BaseMoveComponent moveComp = this.MoveComp;
			if (moveComp != null && moveComp.HasMoveInput)
			{
				this.ExitLoopSwing();
			}
		}
	}

	// Token: 0x06019013 RID: 102419 RVA: 0x00718154 File Offset: 0x00716354
	public unsafe void StartSwing(string daPath, int chairPbDataId, bool? immediately = false)
	{
		bool value = immediately.GetValueOrDefault();
		if (immediately == null)
		{
			value = false;
			immediately = new bool?(value);
		}
		if (this.IsSwinging || this.IsStartSwing)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[CharacterSwing] 正在荡秋千";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "PbDataId";
			CharacterActorComponent actorComp = this.ActorComp;
			ptr = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Chair", chairPbDataId);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (!this.GetChairController(chairPbDataId))
		{
			return;
		}
		this.Immediately = immediately.Value;
		this.InitConfig(daPath, delegate([Nullable(2)] UAnimMontage result, string _)
		{
			if (result == null || !result.IsValid())
			{
				return;
			}
			this.SwingMontage = result;
			this.IsStartSwing = true;
		});
	}

	// Token: 0x06019014 RID: 102420 RVA: 0x0071823C File Offset: 0x0071643C
	public unsafe void StartRoleSwing(string daPath, int chairPbDataId, bool immediately = false)
	{
		if (Singleton<Time>.Instance.Now - this.LastEndSwingTime < 1000.0)
		{
			return;
		}
		if (this.ActorComp == null)
		{
			return;
		}
		if (this.IsSwinging || this.IsStartSwing)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[CharacterSwing] 正在荡秋千";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "PbDataId";
			CharacterActorComponent actorComp = this.ActorComp;
			ptr = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Chair", chairPbDataId);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (!this.GetChairController(chairPbDataId))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Character;
			ELogAuthor author2 = ELogAuthor.CWZ;
			string message2 = "[CharacterSwing] 椅子Entity或ChairController无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
			string item2 = "PbDataId";
			CharacterActorComponent actorComp2 = this.ActorComp;
			ptr2 = new ValueTuple<string, object>(item2, (actorComp2 != null) ? new int?(actorComp2.CreatureData.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Chair", chairPbDataId);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		this.Immediately = immediately;
		int pbDataId = this.ActorComp.CreatureData.GetPbDataId();
		int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(pbDataId);
		this.InitRoleConfig(baseRoleId, daPath, delegate([Nullable(2)] UAnimMontage result, string _)
		{
			if (result == null || !result.IsValid())
			{
				return;
			}
			this.SwingMontage = result;
			this.IsStartSwing = true;
		});
	}

	// Token: 0x06019015 RID: 102421 RVA: 0x007183CA File Offset: 0x007165CA
	public void LeftStartSwing()
	{
		if (this.SwingState != ESwingStateType.EnterSwing)
		{
			return;
		}
		this.ChangeSwingState(ESwingStateType.LoopSwing);
	}

	// Token: 0x06019016 RID: 102422 RVA: 0x007183E0 File Offset: 0x007165E0
	public void ExitLoopSwing()
	{
		if (!this.IsSwinging)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[CharacterSwing] 重复退出荡秋千";
			string item = "PbDataId";
			CharacterActorComponent actorComp = this.ActorComp;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (this.SwingState != ESwingStateType.EnterSwing && this.SwingState != ESwingStateType.LoopSwing)
		{
			return;
		}
		SwingConfig swingConfig = this.SwingConfig;
		if (swingConfig != null && swingConfig.ExitImmediately)
		{
			this.ExitSwingImmediately();
			return;
		}
		this.ChangeSwingState(ESwingStateType.LeftLoopSwing);
	}

	// Token: 0x06019017 RID: 102423 RVA: 0x0071847C File Offset: 0x0071667C
	public void LeftLoopSwing()
	{
		if (this.SwingState != ESwingStateType.LeftLoopSwing)
		{
			return;
		}
		this.ChangeSwingState(ESwingStateType.ExitSwing);
		this.StandUp();
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null)
		{
			return;
		}
		actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = EMovementMode.MOVE_Falling,
			Context = "[CharacterSwingComponent.LeftLoopSwing]"
		});
	}

	// Token: 0x06019018 RID: 102424 RVA: 0x007184CC File Offset: 0x007166CC
	public void LeftEndSwing()
	{
		if (this.SwingState == ESwingStateType.None)
		{
			return;
		}
		if (this.SwingState == ESwingStateType.EnterSwing || this.SwingState == ESwingStateType.LoopSwing)
		{
			this.ChangeSwingState(ESwingStateType.LeftLoopSwing);
		}
		if (this.SwingState == ESwingStateType.LeftLoopSwing)
		{
			this.LeftLoopSwing();
		}
		if (this.SwingState != ESwingStateType.ExitSwing)
		{
			return;
		}
		this.FinishSwing();
	}

	// Token: 0x06019019 RID: 102425 RVA: 0x0071851C File Offset: 0x0071671C
	private void OnStartSwing()
	{
		CharacterAnimationComponent animComp = this.AnimComp;
		this.AnimInstance = (((animComp != null) ? animComp.MainAnimInstance : null) as UKuroAnimInstanceChar);
		UKuroAnimInstanceChar animInstance = this.AnimInstance;
		if (((animInstance != null) ? animInstance.LogicParams : null) == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.CWZ, "[CharacterSwing] 开始荡秋千失败，AnimInstance异常", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Custom,
				CustomMode = 14,
				Context = "[CharacterSwingComponent.StartSwing]"
			});
		}
		if (this.SitOnChair())
		{
			this.ChangeSwingState(ESwingStateType.EnterSwing);
			if (this.Immediately)
			{
				this.ChangeSwingState(ESwingStateType.LoopSwing);
			}
			return;
		}
		CharacterActorComponent actorComp2 = this.ActorComp;
		if (actorComp2 == null)
		{
			return;
		}
		actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = EMovementMode.MOVE_Falling,
			Context = "[CharacterSwingComponent.StartSwing.Rollback]"
		});
	}

	// Token: 0x0601901A RID: 102426 RVA: 0x007185F8 File Offset: 0x007167F8
	private void OnStartRoleSwing()
	{
		CharacterAnimationComponent animComp = this.AnimComp;
		this.AnimInstance = (((animComp != null) ? animComp.MainAnimInstance : null) as UKuroAnimInstanceChar);
		UKuroAnimInstanceChar animInstance = this.AnimInstance;
		if (((animInstance != null) ? animInstance.LogicParams : null) == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.CWZ, "[CharacterSwing] 开始荡秋千失败，AnimInstance异常", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Custom,
				CustomMode = 14,
				Context = "[CharacterSwingComponent.StartSwing]"
			});
		}
		if (this.SitOnChair())
		{
			this.ChangeSwingState(ESwingStateType.EnterSwing);
			if (this.Immediately)
			{
				this.ChangeSwingState(ESwingStateType.LoopSwing);
			}
			return;
		}
		CharacterActorComponent actorComp2 = this.ActorComp;
		if (actorComp2 == null)
		{
			return;
		}
		actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = EMovementMode.MOVE_Falling,
			Context = "[CharacterSwingComponent.StartSwing.Rollback]"
		});
	}

	// Token: 0x0601901B RID: 102427 RVA: 0x007186D4 File Offset: 0x007168D4
	private bool SitOnChair()
	{
		PawnChairController chairController = this.ChairController;
		SceneItemActorComponent sceneItemActorComponent;
		if (chairController == null)
		{
			sceneItemActorComponent = null;
		}
		else
		{
			Entity entity = chairController.Entity;
			sceneItemActorComponent = ((entity != null) ? entity.GetComponent<SceneItemActorComponent>() : null);
		}
		SceneItemActorComponent sceneItemActorComponent2 = sceneItemActorComponent;
		if (this.ChairController == null || sceneItemActorComponent2 == null)
		{
			return false;
		}
		this.ChairController.Possess(base.Entity, false);
		this.ChairController.IgnoreCollision();
		this.IgnoreCollision(this.ChairController.Entity);
		Vector sitLocation = this.ChairController.GetSitLocation();
		Vector forwardDirection = this.ChairController.GetForwardDirection();
		forwardDirection.Multiply((double)this.SwingConfig.StandUpMoveAwayDist, this.ChairPosition);
		this.ChairPosition.AdditionEqual(sitLocation);
		forwardDirection.Rotation(this.TempRotator);
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.SetActorLocationAndRotation(this.ChairPosition.ToUeVector(false), this.TempRotator.ToUeRotator(), "[CharacterSwingComponent] SitOnChair", false, null);
		}
		CharacterActorComponent actorComp2 = this.ActorComp;
		if (actorComp2 != null)
		{
			actorComp2.ClearInput(false, true);
		}
		CharacterAnimationComponent component = base.Entity.GetComponent<CharacterAnimationComponent>();
		FTransformDouble? ftransformDouble = (component != null) ? new FTransformDouble?(component.GetMeshTransform()) : null;
		if (!this.AttachToSocket(sceneItemActorComponent2))
		{
			return false;
		}
		if (ftransformDouble != null && this.SwingConfig.SitOnModelBufferTime > 10)
		{
			CharacterAnimationComponent component2 = base.Entity.GetComponent<CharacterAnimationComponent>();
			if (component2 != null)
			{
				component2.SetModelBuffer(ftransformDouble.Value, (float)this.SwingConfig.SitOnModelBufferTime);
			}
		}
		this.ChangeSitDownTag(true);
		return true;
	}

	// Token: 0x0601901C RID: 102428 RVA: 0x0071884C File Offset: 0x00716A4C
	private void StandUp()
	{
		PawnChairController chairController = this.ChairController;
		if (chairController != null)
		{
			chairController.ResetCollision();
		}
		PawnChairController chairController2 = this.ChairController;
		if (chairController2 != null)
		{
			chairController2.UnPossess(base.Entity);
		}
		PawnChairController chairController3 = this.ChairController;
		if (((chairController3 != null) ? chairController3.Entity : null) != null)
		{
			this.ResetCollision(this.ChairController.Entity);
		}
		this.ResetAttach();
		TimerSystem.Instance.Delay(delegate(float _)
		{
			this.ChangeSitDownTag(false);
		}, 1000f, null, null, true, 1f);
		SwingConfig swingConfig = this.SwingConfig;
		if (swingConfig != null && swingConfig.ExitImmediately)
		{
			this.ResetActor();
			return;
		}
		CharacterAnimationComponent component = base.Entity.GetComponent<CharacterAnimationComponent>();
		FTransformDouble? ftransformDouble = (component != null) ? new FTransformDouble?(component.GetMeshTransform()) : null;
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.SetActorLocation(this.ChairPosition.ToUeVector(false), "[CharacterSwingComponent] SitOnChair", false);
		}
		if (ftransformDouble != null && this.SwingConfig.StandUpModelBufferTime > 10)
		{
			CharacterAnimationComponent component2 = base.Entity.GetComponent<CharacterAnimationComponent>();
			if (component2 != null)
			{
				component2.SetModelBuffer(ftransformDouble.Value, (float)this.SwingConfig.StandUpModelBufferTime);
			}
		}
		this.ResetActor();
	}

	// Token: 0x0601901D RID: 102429 RVA: 0x0071897C File Offset: 0x00716B7C
	private void ResetActor()
	{
		if (this.ChairController != null)
		{
			this.TempVector.DeepCopy(this.ChairController.GetForwardDirection());
		}
		else
		{
			this.TempVector.DeepCopy(this.ActorComp.ActorForwardProxy);
		}
		Vector.VectorPlaneProject(this.TempVector, this.ActorComp.ActorGravityDirectProxy, this.TempVector2);
		if (!this.TempVector2.IsNearlyZero(9.999999747378752E-05))
		{
			this.TempVector2.Normalize(9.99999993922529E-09);
			this.ActorComp.ActorGravityDirectProxy.Multiply(-1.0, this.TempVector);
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TempVector2, this.TempVector, this.TempRotator);
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.SetActorRotation(this.TempRotator.ToUeRotator(), "[CharacterSwingComponent] ResetActor", false);
			}
		}
		CharacterActorComponent actorComp2 = this.ActorComp;
		if (actorComp2 != null)
		{
			actorComp2.SetInputDirect(this.ActorComp.ActorForwardProxy, false);
		}
		CharacterActorComponent actorComp3 = this.ActorComp;
		if (actorComp3 != null)
		{
			actorComp3.SetInputFacing(this.ActorComp.ActorForwardProxy, false);
		}
		CharacterActorComponent actorComp4 = this.ActorComp;
		if (actorComp4 == null)
		{
			return;
		}
		actorComp4.ClearInput(false, true);
	}

	// Token: 0x0601901E RID: 102430 RVA: 0x00718ABC File Offset: 0x00716CBC
	private void ChangeSitDownTag(bool value)
	{
		if (value)
		{
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp == null || !tagComp.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止坐下"]))
			{
				BaseTagComponent tagComp2 = this.TagComp;
				if (tagComp2 != null)
				{
					tagComp2.AddTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止坐下"]));
				}
			}
		}
		if (!value)
		{
			BaseTagComponent tagComp3 = this.TagComp;
			if (tagComp3 != null && tagComp3.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止坐下"]))
			{
				BaseTagComponent tagComp4 = this.TagComp;
				if (tagComp4 == null)
				{
					return;
				}
				tagComp4.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止坐下"]));
			}
		}
	}

	// Token: 0x0601901F RID: 102431 RVA: 0x00718B64 File Offset: 0x00716D64
	private unsafe bool AttachToSocket(SceneItemActorComponent chair)
	{
		SceneInteractionActor sceneInteractionActor = chair.GetInteractionMainActor() as SceneInteractionActor;
		ASkeletalMeshActor askeletalMeshActor = ((sceneInteractionActor != null) ? sceneInteractionActor.GetActorByKey(this.SwingConfig.ReferenceActor) : null) as ASkeletalMeshActor;
		if (((askeletalMeshActor != null) ? askeletalMeshActor.SkeletalMeshComponent : null) == null)
		{
			this.StandUp();
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.CWZ, "[CharacterSwing] 椅子ReferenceActor无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		this.SwingAnimInstance = askeletalMeshActor.SkeletalMeshComponent.GetAnimInstance();
		FName fname = FNameUtil.GetDynamicFName(this.SwingConfig.AttachSocket) ?? FName.NAME_None;
		FTransformDouble ftransformDouble = askeletalMeshActor.SkeletalMeshComponent.D_GetSocketTransform(fname, ERelativeTransformSpace.RTS_World);
		FTransformDouble relativeTransform = chair.ActorTransform.GetRelativeTransform(ftransformDouble);
		this.TempTransform.FromUeTransform(relativeTransform);
		Vector tempVector = this.TempVector;
		FVectorDouble location = ftransformDouble.GetLocation();
		tempVector.FromUeVector(location);
		if (this.TempVector.Equals(Vector.ZeroVectorProxy, 9.999999747378752E-05))
		{
			this.TempVector.DeepCopy(chair.ActorLocationProxy);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[CharacterSwing] 找不到Socket";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", (chair != null) ? new int?(chair.CreatureData.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SocketName", fname);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.ActorComp.Actor.K2_AttachToComponent(askeletalMeshActor.SkeletalMeshComponent, fname, EAttachmentRule.KeepRelative, EAttachmentRule.SnapToTarget, EAttachmentRule.KeepWorld, false, true);
		this.ActorComp.SetForbidSettingLocAndRot(false, EForbidSettingLocAndRotReason.Swing);
		this.ActorComp.Actor.D_K2_SetActorRelativeLocation(this.SwingConfig.AttachLocation.ToUeVector(false), false, ref WorldGlobal.SweepHitResult, false);
		this.ActorComp.Actor.K2_SetActorRelativeRotation(this.SwingConfig.AttachRotator.ToUeRotator(), false, ref WorldGlobal.SweepHitResult, false);
		this.ActorComp.ResetAllCachedTime();
		this.ActorComp.SetForbidSettingLocAndRot(true, EForbidSettingLocAndRotReason.Swing);
		return true;
	}

	// Token: 0x06019020 RID: 102432 RVA: 0x00718D85 File Offset: 0x00716F85
	private void ResetAttach()
	{
		this.ActorComp.Actor.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
		this.ActorComp.SetForbidSettingLocAndRot(false, EForbidSettingLocAndRotReason.Swing);
	}

	// Token: 0x06019021 RID: 102433 RVA: 0x00718DA8 File Offset: 0x00716FA8
	private void IgnoreCollision(Entity chair)
	{
		SceneItemActorComponent component = chair.GetComponent<SceneItemActorComponent>();
		if (component != null && component.Entity != null)
		{
			this.IgnoreActorsCollision(component, true);
		}
		this.ActorComp.Actor.CapsuleComponent.SetCollisionResponseToChannel(ECollisionChannel.ECC_Pawn, ECollisionResponse.ECR_Ignore);
	}

	// Token: 0x06019022 RID: 102434 RVA: 0x00718DE8 File Offset: 0x00716FE8
	[NullableContext(2)]
	private void ResetCollision(Entity chair)
	{
		this.ActorComp.Actor.CapsuleComponent.SetCollisionResponseToChannel(ECollisionChannel.ECC_Pawn, ECollisionResponse.ECR_Block);
		if (chair == null)
		{
			return;
		}
		SceneItemActorComponent component = chair.GetComponent<SceneItemActorComponent>();
		if (component != null && component.Entity != null)
		{
			this.IgnoreActorsCollision(component, false);
		}
	}

	// Token: 0x06019023 RID: 102435 RVA: 0x00718E2C File Offset: 0x0071702C
	private void IgnoreActorsCollision(SceneItemActorComponent actorComp, bool bCollision)
	{
		CreatureDataComponent component = actorComp.Entity.GetComponent<CreatureDataComponent>();
		int pbDataId = (component != null) ? component.GetPbDataId() : 0;
		int? ownerEntity = ModelBase<CreatureModel>.Instance.GetOwnerEntity(pbDataId);
		SceneItemActorComponent sceneItemActorComponent;
		if (ownerEntity != null)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(ownerEntity.Value);
			if (entityByPbDataId != null && entityByPbDataId.Valid)
			{
				sceneItemActorComponent = entityByPbDataId.Entity.GetComponent<SceneItemActorComponent>();
			}
			else
			{
				sceneItemActorComponent = actorComp;
			}
		}
		else
		{
			sceneItemActorComponent = actorComp;
		}
		TArray<AActor> tarray = new TArray<AActor>();
		sceneItemActorComponent.Owner.GetAttachedActors(ref tarray, true);
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			AActor aactor = tarray.Get(i);
			TArray<AActor> tarray2 = new TArray<AActor>();
			aactor.GetAttachedActors(ref tarray2, true);
			int num2 = tarray2.Num();
			for (int j = 0; j < num2; j++)
			{
				this.ActorComp.Actor.CapsuleComponent.IgnoreActorWhenMoving(tarray2.Get(j), bCollision);
			}
		}
	}

	// Token: 0x06019024 RID: 102436 RVA: 0x00718F1A File Offset: 0x0071711A
	private void FinishSwing()
	{
		this.LastEndSwingTime = Singleton<Time>.Instance.Now;
		this.ChangeSwingState(ESwingStateType.None);
		this.SwingMontage = null;
		this.SwingAnimInstance = null;
		this.SwingConfig = null;
	}

	// Token: 0x06019025 RID: 102437 RVA: 0x00718F48 File Offset: 0x00717148
	private void ExitSwingImmediately()
	{
		this.ChangeSwingState(ESwingStateType.LeftLoopSwing);
		this.StandUp();
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Falling,
				Context = "[CharacterSwingComponent.ExitSwingImmediately]"
			});
		}
		this.FinishSwing();
	}

	// Token: 0x06019026 RID: 102438 RVA: 0x00718F98 File Offset: 0x00717198
	private void InitConfig(string daPath, [Nullable(new byte[]
	{
		1,
		2,
		1
	})] Action<UAnimMontage, string> callback)
	{
		Action<BP_CharacterSwingConfig_C, string> <>9__1;
		Singleton<ResourceSystem>.Instance.LoadTypeAsync("BP_CharacterSwingConfig_C", delegate
		{
			ResourceSystem instance = Singleton<ResourceSystem>.Instance;
			string daPath2 = daPath;
			Action<BP_CharacterSwingConfig_C, string> callback2;
			if ((callback2 = <>9__1) == null)
			{
				callback2 = (<>9__1 = delegate([Nullable(2)] BP_CharacterSwingConfig_C result, string _)
				{
					if (result == null || !result.IsValid())
					{
						return;
					}
					SwingConfig swingConfig = new SwingConfig();
					if (!swingConfig.Init(result))
					{
						return;
					}
					this.SwingConfig = swingConfig;
					Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(this.SwingConfig.AnimMontagePath, callback, 100, "js_undefined");
				});
			}
			instance.LoadAsync<BP_CharacterSwingConfig_C>(daPath2, callback2, 100, "js_undefined");
		}, "js_undefined");
	}

	// Token: 0x06019027 RID: 102439 RVA: 0x00718FE0 File Offset: 0x007171E0
	private void InitRoleConfig(int roleId, string daPath, [Nullable(new byte[]
	{
		1,
		2,
		1
	})] Action<UAnimMontage, string> callback)
	{
		Action<BP_RoleSwingConfig_C, string> <>9__1;
		Singleton<ResourceSystem>.Instance.LoadTypeAsync("BP_RoleSwingConfig_C", delegate
		{
			ResourceSystem instance = Singleton<ResourceSystem>.Instance;
			string daPath2 = daPath;
			Action<BP_RoleSwingConfig_C, string> callback2;
			if ((callback2 = <>9__1) == null)
			{
				callback2 = (<>9__1 = delegate([Nullable(2)] BP_RoleSwingConfig_C result, string _)
				{
					if (result == null || !result.IsValid())
					{
						return;
					}
					SwingConfig swingConfig = new SwingConfig();
					if (!swingConfig.InitRole(roleId, result))
					{
						return;
					}
					this.SwingConfig = swingConfig;
					Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(this.SwingConfig.AnimMontagePath, callback, 100, "js_undefined");
				});
			}
			instance.LoadAsync<BP_RoleSwingConfig_C>(daPath2, callback2, 100, "js_undefined");
		}, "js_undefined");
	}

	// Token: 0x06019028 RID: 102440 RVA: 0x00719030 File Offset: 0x00717230
	private unsafe void ChangeSwingState(ESwingStateType type)
	{
		UKuroAnimInstanceChar animInstance = this.AnimInstance;
		if (((animInstance != null) ? animInstance.LogicParams : null) == null || this.SwingAnimInstance == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.CWZ, "[CharacterSwing] 秋千状态切换失败，AnimInstance异常", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (type == this.SwingState && type != ESwingStateType.None)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[CharacterSwing] 重复设置荡秋千状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "PbDataId";
			CharacterActorComponent actorComp = this.ActorComp;
			ptr = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("type", CharacterSwingComponent.GetSwingStateName(type));
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.SwingState = type;
		this.IsSwinging = (type > ESwingStateType.None);
		this.AnimInstance.LogicParams.bSwingState = this.IsSwinging;
		this.AnimInstance.LogicParams.SwingStateType = type;
		switch (type)
		{
		case ESwingStateType.None:
			this.SwingAnimInstance.Montage_Stop(1f, null);
			return;
		case ESwingStateType.EnterSwing:
			this.SwingAnimInstance.Montage_Play(this.SwingMontage, 1f, EMontagePlayReturnType.MontageLength, 0f, true);
			return;
		case ESwingStateType.LoopSwing:
		case ESwingStateType.LeftLoopSwing:
			break;
		case ESwingStateType.ExitSwing:
			this.SwingAnimInstance.Montage_JumpToSection(Singleton<CharacterNameDefines>.Instance.END_SECTION, this.SwingMontage);
			break;
		default:
			return;
		}
	}

	// Token: 0x06019029 RID: 102441 RVA: 0x007191A8 File Offset: 0x007173A8
	private bool GetChairController(int chairPbDataId)
	{
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(chairPbDataId);
		WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
		PawnInteractNewComponent pawnInteractNewComponent = (worldEntity != null) ? worldEntity.GetComponent<PawnInteractNewComponent>() : null;
		SceneItemActorComponent sceneItemActorComponent = (worldEntity != null) ? worldEntity.GetComponent<SceneItemActorComponent>() : null;
		this.ChairController = (((pawnInteractNewComponent != null) ? pawnInteractNewComponent.GetSubEntityInteractLogicController() : null) as PawnChairController);
		return worldEntity != null && pawnInteractNewComponent != null && sceneItemActorComponent != null && this.ChairController != null;
	}

	// Token: 0x0601902A RID: 102442 RVA: 0x00719214 File Offset: 0x00717414
	private static string GetSwingStateName(ESwingStateType type)
	{
		switch (type)
		{
		case ESwingStateType.None:
			return "None";
		case ESwingStateType.EnterSwing:
			return "进入荡秋千";
		case ESwingStateType.LoopSwing:
			return "荡秋千中";
		case ESwingStateType.LeftLoopSwing:
			return "预备离开秋千";
		case ESwingStateType.ExitSwing:
			return "退出荡秋千";
		default:
			return "";
		}
	}

	// Token: 0x0601902B RID: 102443 RVA: 0x00719260 File Offset: 0x00717460
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterSwingComponent characterSwingComponent = (CharacterSwingComponent)componentTemplate;
		if (base.CanResetComponentProperty("ChairPosition") && characterSwingComponent.ChairPosition != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.ChairPosition), "ChairPosition"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempVector") && characterSwingComponent.TempVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector), "TempVector"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempVector2") && characterSwingComponent.TempVector2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector2), "TempVector2"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempRotator") && characterSwingComponent.TempRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TempRotator), "TempRotator"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempTransform") && characterSwingComponent.TempTransform != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Transform>(this.TempTransform), "TempTransform"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ChairController"))
		{
			if (characterSwingComponent.ChairController == null)
			{
				this.ChairController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnChairController>(this.ChairController), "ChairController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterSwingComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (characterSwingComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (characterSwingComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterSwingComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SwingConfig"))
		{
			if (characterSwingComponent.SwingConfig == null)
			{
				this.SwingConfig = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SwingConfig>(this.SwingConfig), "SwingConfig"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimInstance"))
		{
			if (characterSwingComponent.AnimInstance == null)
			{
				this.AnimInstance = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroAnimInstanceChar>(this.AnimInstance), "AnimInstance"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SwingMontage"))
		{
			if (characterSwingComponent.SwingMontage == null)
			{
				this.SwingMontage = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UAnimMontage>(this.SwingMontage), "SwingMontage"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SwingAnimInstance"))
		{
			if (characterSwingComponent.SwingAnimInstance == null)
			{
				this.SwingAnimInstance = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UAnimInstance>(this.SwingAnimInstance), "SwingAnimInstance"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsSwinging"))
		{
			this.IsSwinging = characterSwingComponent.IsSwinging;
		}
		if (base.CanResetComponentProperty("IsStartSwing"))
		{
			this.IsStartSwing = characterSwingComponent.IsStartSwing;
		}
		if (base.CanResetComponentProperty("SwingState"))
		{
			this.SwingState = characterSwingComponent.SwingState;
		}
		if (base.CanResetComponentProperty("Immediately"))
		{
			this.Immediately = characterSwingComponent.Immediately;
		}
		if (base.CanResetComponentProperty("LastEndSwingTime"))
		{
			this.LastEndSwingTime = characterSwingComponent.LastEndSwingTime;
		}
		return true;
	}

	// Token: 0x0400C39D RID: 50077
	private const long SWING_INTERVAL_TIME = 1000L;

	// Token: 0x0400C39E RID: 50078
	private readonly Vector ChairPosition = Vector.Create();

	// Token: 0x0400C39F RID: 50079
	private readonly Vector TempVector = Vector.Create();

	// Token: 0x0400C3A0 RID: 50080
	private readonly Vector TempVector2 = Vector.Create();

	// Token: 0x0400C3A1 RID: 50081
	private readonly Rotator TempRotator = Rotator.Create();

	// Token: 0x0400C3A2 RID: 50082
	private readonly Transform TempTransform = Transform.Create();

	// Token: 0x0400C3A3 RID: 50083
	[Nullable(2)]
	private PawnChairController ChairController;

	// Token: 0x0400C3A4 RID: 50084
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400C3A5 RID: 50085
	[Nullable(2)]
	private BaseMoveComponent MoveComp;

	// Token: 0x0400C3A6 RID: 50086
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400C3A7 RID: 50087
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400C3A8 RID: 50088
	[Nullable(2)]
	private SwingConfig SwingConfig;

	// Token: 0x0400C3A9 RID: 50089
	[Nullable(2)]
	private UKuroAnimInstanceChar AnimInstance;

	// Token: 0x0400C3AA RID: 50090
	[Nullable(2)]
	private UAnimMontage SwingMontage;

	// Token: 0x0400C3AB RID: 50091
	[Nullable(2)]
	private UAnimInstance SwingAnimInstance;

	// Token: 0x0400C3AC RID: 50092
	public bool IsSwinging;

	// Token: 0x0400C3AD RID: 50093
	public bool IsStartSwing;

	// Token: 0x0400C3AE RID: 50094
	public ESwingStateType SwingState;

	// Token: 0x0400C3AF RID: 50095
	private bool Immediately;

	// Token: 0x0400C3B0 RID: 50096
	public double LastEndSwingTime;
}
