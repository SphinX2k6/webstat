using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x0200322D RID: 12845
[NullableContext(1)]
[Nullable(0)]
public class UeMovementTickManageComponent : EntityComponent, IUeMovementComp
{
	// Token: 0x1700243F RID: 9279
	// (get) Token: 0x0601AB88 RID: 109448 RVA: 0x007F4B9F File Offset: 0x007F2D9F
	public new static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(CharacterActorComponent)
			};
		}
	}

	// Token: 0x17002440 RID: 9280
	// (get) Token: 0x0601AB89 RID: 109449 RVA: 0x007F4BB4 File Offset: 0x007F2DB4
	// (set) Token: 0x0601AB8A RID: 109450 RVA: 0x007F4BBC File Offset: 0x007F2DBC
	[Nullable(2)]
	public UeSkeletalTickManageComponent SkelTickMgr { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17002441 RID: 9281
	// (get) Token: 0x0601AB8B RID: 109451 RVA: 0x007F4BC5 File Offset: 0x007F2DC5
	// (set) Token: 0x0601AB8C RID: 109452 RVA: 0x007F4BD0 File Offset: 0x007F2DD0
	public EMovementTickMode TickMode
	{
		get
		{
			return this.TickModeInternal;
		}
		protected set
		{
			if (this.TickModeInternal == value)
			{
				return;
			}
			EMovementTickMode tickModeInternal = this.TickModeInternal;
			this.TickModeInternal = value;
			switch (tickModeInternal)
			{
			case EMovementTickMode.TsProxy:
				UeMovementTickController.DeleteManager(this, 0);
				Singleton<TickSystem>.Instance.CleanMovementProxyTickFunction(this.MoveComponent);
				if (value != EMovementTickMode.TsProxyNotParallel)
				{
					this.ProxyTickCount = 0;
					this.ProxyTickDelta = 0f;
				}
				break;
			case EMovementTickMode.UeUpdate:
				this.MoveComponent.SetKuroOnlyTickOutside(true);
				this.MoveComponent.SetComponentTickEnabled(false);
				break;
			case EMovementTickMode.TsProxyNotParallel:
				UeMovementTickController.DeleteManager(this, 0);
				break;
			}
			switch (value)
			{
			case EMovementTickMode.TsProxy:
				UeMovementTickController.AddManager(this, 0);
				Singleton<TickSystem>.Instance.SetMovementProxyTickFunction(ETickingGroup.TG_PrePhysics, this.MoveComponent, 1);
				return;
			case EMovementTickMode.TsTakeOver:
				break;
			case EMovementTickMode.UeUpdate:
				this.MoveComponent.SetKuroOnlyTickOutside(false);
				this.MoveComponent.SetComponentTickEnabled(true);
				return;
			case EMovementTickMode.TsProxyNotParallel:
				UeMovementTickController.AddManager(this, 0);
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x17002442 RID: 9282
	// (get) Token: 0x0601AB8D RID: 109453 RVA: 0x007F4CB2 File Offset: 0x007F2EB2
	// (set) Token: 0x0601AB8E RID: 109454 RVA: 0x007F4CBA File Offset: 0x007F2EBA
	protected bool ForbiddenTickPose
	{
		get
		{
			return this.ForbiddenTickPoseInternal;
		}
		set
		{
			if (this.ForbiddenTickPoseInternal == value)
			{
				return;
			}
			this.ForbiddenTickPoseInternal = value;
			this.MoveComponent.bForbiddenTickPose = value;
		}
	}

	// Token: 0x17002443 RID: 9283
	// (get) Token: 0x0601AB8F RID: 109455 RVA: 0x007F4CD9 File Offset: 0x007F2ED9
	// (set) Token: 0x0601AB90 RID: 109456 RVA: 0x007F4CE1 File Offset: 0x007F2EE1
	public bool TeleportLock
	{
		get
		{
			return this.TeleportLockInternal;
		}
		set
		{
			if (this.TeleportLockInternal == value)
			{
				return;
			}
			this.TeleportLockInternal = value;
			this.ActorComp.SetActorVelocity(Vector.ZeroVectorProxy);
		}
	}

	// Token: 0x0601AB91 RID: 109457 RVA: 0x007F4D04 File Offset: 0x007F2F04
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.CharacterMoveComp = base.Entity.GetComponent<BaseMoveComponent>();
		this.VehiclePerformComp = base.Entity.GetComponent<BaseVehiclePerformComponent>();
		this.MoveComponent = (this.ActorComp.Owner.GetComponentByClass(UCharacterMovementComponent.StaticClass()) as UCharacterMovementComponent);
		if (this.MoveComponent == null)
		{
			return false;
		}
		this.DebugComp = base.Entity.GetComponent<ActorDebugMovementComponent>();
		this.SkelTickMgr = base.Entity.GetComponent<UeSkeletalTickManageComponent>();
		this.MoveComponent.SetKuroOnlyTickOutside(true);
		this.MoveComponent.SetComponentTickEnabled(false);
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		this.ForbiddenTickPose = (base.Entity.GetTickInterval() > 1 || UeSkeletalTickController.EnabledNewSkelTickTiming);
		this.DebugLastTickFrame = (long)Singleton<Time>.Instance.Frame;
		this.TeleportLockInternal = false;
		this.TickMode = (UeMovementTickController.EnabledMovementParallel ? EMovementTickMode.TsProxy : EMovementTickMode.TsTakeOver);
		if (ModelBase<SundryModel>.Instance.RoleFallingDebugLogOn && this.ActorComp.IsRoleAndCtrlByMe)
		{
			this.SetVelocityInfoCacheEnable(true);
		}
		this.UroParams = new FAnimUpdateRateParameters();
		return true;
	}

	// Token: 0x0601AB92 RID: 109458 RVA: 0x007F4E2F File Offset: 0x007F302F
	protected override bool OnEnd()
	{
		this.TickMode = EMovementTickMode.None;
		this.OldMeshTransform = null;
		return true;
	}

	// Token: 0x0601AB93 RID: 109459 RVA: 0x007F4E48 File Offset: 0x007F3048
	protected unsafe override void OnDisable(string reason)
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (((actorComp != null) ? actorComp.Actor : null) != null)
		{
			this.ActorComp.Actor.BasedMovement.MovementBase = null;
		}
		CharacterActorComponent actorComp2 = this.ActorComp;
		if (actorComp2 != null && actorComp2.IsRoleAndCtrlByMe)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "UeMovementTickManageComponent Disable";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Entity", base.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DisableInfo", base.DumpDisableInfo());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x0601AB94 RID: 109460 RVA: 0x007F4EFC File Offset: 0x007F30FC
	protected override void OnEnable()
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.IsRoleAndCtrlByMe)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "UeMovementTickManageComponent Enable";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Entity", base.Entity.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.DebugLastTickFrame = (long)Singleton<Time>.Instance.Frame;
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp == null)
		{
			return;
		}
		animComp.ConsumeRootMotion();
	}

	// Token: 0x0601AB95 RID: 109461 RVA: 0x007F4F74 File Offset: 0x007F3174
	protected override void OnTick(float delta)
	{
		if (this.TickMode != EMovementTickMode.TsTakeOver)
		{
			return;
		}
		this.TickMovement(delta);
		this.ResetCachedTransformAndSetModelBuffer();
		if (UeMovementTickController.EnabledMovementParallel)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			bool flag;
			if (actorComp == null)
			{
				flag = false;
			}
			else
			{
				AActor attachRootParentActor = actorComp.Actor.GetAttachRootParentActor();
				flag = ((attachRootParentActor != null) ? new bool?(attachRootParentActor.IsValid()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				this.TickMode = EMovementTickMode.TsProxyNotParallel;
				return;
			}
			this.TickMode = EMovementTickMode.TsProxy;
		}
	}

	// Token: 0x0601AB96 RID: 109462 RVA: 0x007F4FE8 File Offset: 0x007F31E8
	public bool CanTickDefault()
	{
		return base.Active;
	}

	// Token: 0x0601AB97 RID: 109463 RVA: 0x007F4FF0 File Offset: 0x007F31F0
	public bool CanTickWithDistance()
	{
		if (this.CharacterMoveComp != null)
		{
			return base.Active && this.CharacterMoveComp.CanMoveWithDistance();
		}
		return base.Active;
	}

	// Token: 0x0601AB98 RID: 109464 RVA: 0x007F5018 File Offset: 0x007F3218
	public void PreProxyTick(float delta)
	{
		this.ProxyTickCount++;
		this.ProxyTickDelta += base.Entity.TimeDilation * delta;
		if (this.ProxyTickCount >= base.Entity.GetTickInterval())
		{
			this.TickMovement(this.ProxyTickDelta);
		}
	}

	// Token: 0x0601AB99 RID: 109465 RVA: 0x007F506C File Offset: 0x007F326C
	public void ProxyTick()
	{
		if (this.ProxyTickCount >= base.Entity.GetTickInterval())
		{
			this.ResetCachedTransformAndSetModelBuffer();
			this.ProxyTickCount = 0;
			this.ProxyTickDelta = 0f;
		}
		if (!UeMovementTickController.EnabledMovementParallel)
		{
			this.TickMode = EMovementTickMode.TsTakeOver;
			return;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		bool flag;
		if (actorComp == null)
		{
			flag = false;
		}
		else
		{
			AActor attachRootParentActor = actorComp.Actor.GetAttachRootParentActor();
			flag = ((attachRootParentActor != null) ? new bool?(attachRootParentActor.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			this.TickMode = EMovementTickMode.TsProxyNotParallel;
			return;
		}
		this.TickMode = EMovementTickMode.TsProxy;
	}

	// Token: 0x0601AB9A RID: 109466 RVA: 0x007F50FC File Offset: 0x007F32FC
	protected void TickMovement(float delta)
	{
		this.HasMove = false;
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.LastActorLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		}
		CharacterActorComponent actorComp2 = this.ActorComp;
		if (actorComp2 != null)
		{
			actorComp2.LastActorRotation.DeepCopy(this.ActorComp.ActorRotationProxy);
		}
		this.CheckTickFrame();
		if (this.MoveComponent == null || this.TeleportLock)
		{
			return;
		}
		if (ControllerBase<WorldController>.Instance.GetIsWorldOriginInUiMode() && this.MoveComponent.MovementMode != EMovementMode.MOVE_Falling)
		{
			return;
		}
		CharacterActorComponent actorComp3 = this.ActorComp;
		if (((actorComp3 != null) ? actorComp3.Actor.GetAttachRootParentActor() : null) != null)
		{
			BaseMoveComponent characterMoveComp = this.CharacterMoveComp;
			if (characterMoveComp == null || !characterMoveComp.NeedRootMotionWhenAttached)
			{
				return;
			}
		}
		if (this.DebugComp != null)
		{
			this.DebugComp.MarkDebugRecord("移动组件更新前 ", null, true);
		}
		if (this.VehiclePerformComp != null)
		{
			foreach (VehiclePassengerInfo vehiclePassengerInfo in this.VehiclePerformComp.PassengerInfoMap.Values)
			{
				Entity passengerEntity = vehiclePassengerInfo.PassengerEntity;
				ActorDebugMovementComponent actorDebugMovementComponent = (passengerEntity != null) ? passengerEntity.GetComponent<ActorDebugMovementComponent>() : null;
				if (actorDebugMovementComponent != null)
				{
					actorDebugMovementComponent.MarkDebugRecord("载具移动组件更新前", null, true);
				}
			}
		}
		this.CharacterMoveComp.ConsumeForceFallingSpeed();
		PawnTimeScaleComponent component = base.Entity.GetComponent<PawnTimeScaleComponent>();
		float num = (component != null) ? component.CurrentTimeScale : 1f;
		BaseMoveComponent characterMoveComp2 = this.CharacterMoveComp;
		if (characterMoveComp2 == null || !characterMoveComp2.NeedRootMotionWhenAttached)
		{
			BaseMoveComponent characterMoveComp3 = this.CharacterMoveComp;
			if (characterMoveComp3 != null && characterMoveComp3.IsSpecialMove)
			{
				goto IL_43D;
			}
		}
		if (this.CharacterMoveComp != null)
		{
			this.CharacterMoveComp.GetAndConsumeAddMove(delta * 0.001f * num, UeMovementTickManageComponent.TmpVector, UeMovementTickManageComponent.TmpRotator);
			if (!UeMovementTickManageComponent.TmpVector.IsNearlyZero(9.999999747378752E-05))
			{
				if (this.MoveComponent.MovementMode == EMovementMode.MOVE_Falling)
				{
					this.ActorComp.AddActorWorldOffset(UeMovementTickManageComponent.TmpVector.ToUeVector(false), "AddMove", true);
				}
				else
				{
					this.MoveComponent.SetAddMove(UeMovementTickManageComponent.TmpVector.ToUeVector(false));
				}
			}
			if (!UeMovementTickManageComponent.TmpRotator.IsNearlyZero())
			{
				CharacterActorComponent actorComp4 = this.ActorComp;
				if (actorComp4 != null)
				{
					actorComp4.AddActorLocalRotation(UeMovementTickManageComponent.TmpRotator.ToUeRotator(), "叠加旋转", false);
				}
			}
		}
		bool flag = base.Entity.GetTickInterval() > 1;
		this.ForbiddenTickPose = (flag || this.Frozen || UeSkeletalTickController.EnabledNewSkelTickTiming);
		this.ModelBufferTimeLength = 0f;
		CharacterAnimationComponent animComp = this.AnimComp;
		USkeletalMeshComponent uskeletalMeshComponent;
		if (animComp == null)
		{
			uskeletalMeshComponent = null;
		}
		else
		{
			TsBaseCharacter actor = animComp.Actor;
			uskeletalMeshComponent = ((actor != null) ? actor.Mesh : null);
		}
		USkeletalMeshComponent uskeletalMeshComponent2 = uskeletalMeshComponent;
		if (uskeletalMeshComponent2 != null && uskeletalMeshComponent2.bEnableUpdateRateOptimizations)
		{
			CharacterAnimationComponent animComp2 = this.AnimComp;
			bool flag2;
			if (animComp2 == null)
			{
				flag2 = false;
			}
			else
			{
				UAnimInstance mainAnimInstance = animComp2.MainAnimInstance;
				flag2 = ((mainAnimInstance != null) ? new bool?(mainAnimInstance.HasKuroRootMotionAnim()) : null).GetValueOrDefault();
			}
			if (flag2)
			{
				BaseMoveComponent characterMoveComp4 = this.CharacterMoveComp;
				if (((characterMoveComp4 != null) ? characterMoveComp4.BasePlatform : null) == null)
				{
					uskeletalMeshComponent2.GetAnimUpdateRateParameters(ref this.UroParams);
					if (!this.UroParams.bSkipUpdate && this.UroParams.UpdateRate > base.Entity.GetTickInterval())
					{
						this.ModelBufferTimeLength = (float)this.UroParams.UpdateRate * delta * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation / (float)Math.Max(1, base.Entity.GetTickInterval());
					}
				}
			}
		}
		if (flag)
		{
			CharacterAnimationComponent animComp3 = this.AnimComp;
			if (animComp3 != null && animComp3.Valid && this.ActorComp.Owner.WasRecentlyRenderedOnScreen(0.2f))
			{
				this.ModelBufferTimeLength = Math.Max(delta * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation, this.ModelBufferTimeLength);
			}
		}
		if (this.ModelBufferTimeLength <= 10f || this.AnimComp == null)
		{
			this.MoveComponent.KuroTickComponentOutside(delta * 0.001f * num);
		}
		else
		{
			this.OldMeshTransform = new FTransformDouble?(this.AnimComp.GetMeshTransform());
			this.OldActorLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			this.OldActorRotator.DeepCopy(this.ActorComp.ActorRotationProxy);
			this.MoveComponent.KuroTickComponentOutside(delta * 0.001f * num);
			this.ActorComp.ResetAllCachedTime();
		}
		IL_43D:
		this.HasMove = true;
	}

	// Token: 0x0601AB9B RID: 109467 RVA: 0x007F5560 File Offset: 0x007F3760
	protected void ResetCachedTransformAndSetModelBuffer()
	{
		this.CacheVelocityInfo("AfterTickMovement");
		this.UpdateVelocityCache();
		if (!this.HasMove)
		{
			return;
		}
		BaseMoveComponent characterMoveComp = this.CharacterMoveComp;
		if (characterMoveComp == null || !characterMoveComp.IsSpecialMove)
		{
			this.ActorComp.ResetAllCachedTime();
		}
		if (this.OldMeshTransform != null && this.ModelBufferTimeLength >= 10f && (!this.OldActorLocation.Equals(this.ActorComp.ActorLocationProxy, 9.999999747378752E-05) || !this.OldActorRotator.Equals(this.ActorComp.ActorRotationProxy, 0.0001f)))
		{
			this.AnimComp.SetModelBuffer(this.OldMeshTransform.Value, this.ModelBufferTimeLength);
			this.OldMeshTransform = null;
		}
		this.CharacterMoveComp.ApplyForceSpeedAndRecordSpeed();
		if (this.DebugComp != null)
		{
			this.DebugComp.MarkDebugRecord("移动组件更新后", null, true);
		}
		if (this.VehiclePerformComp != null)
		{
			foreach (VehiclePassengerInfo vehiclePassengerInfo in this.VehiclePerformComp.PassengerInfoMap.Values)
			{
				Entity passengerEntity = vehiclePassengerInfo.PassengerEntity;
				ActorDebugMovementComponent actorDebugMovementComponent = (passengerEntity != null) ? passengerEntity.GetComponent<ActorDebugMovementComponent>() : null;
				Entity passengerEntity2 = vehiclePassengerInfo.PassengerEntity;
				BaseActorComponent baseActorComponent = (passengerEntity2 != null) ? passengerEntity2.GetComponent<BaseActorComponent>() : null;
				if (baseActorComponent != null)
				{
					baseActorComponent.ResetAllCachedTime();
				}
				if (actorDebugMovementComponent != null)
				{
					actorDebugMovementComponent.MarkDebugRecord("载具移动组件更新后", null, true);
				}
			}
		}
		if (this.FixFacingForVelocity)
		{
			this.FixFacingForVelocity = false;
			Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(this.ActorComp.ActorVelocityProxy);
			if (Singleton<MathUtils>.Instance.CommonTempVector.Normalize(9.99999993922529E-09))
			{
				this.ActorComp.SetInputFacing(Singleton<MathUtils>.Instance.CommonTempVector, true);
				this.ActorComp.SetOverrideTurnSpeed(new float?(this.FixFacingTurnSpeed));
			}
		}
	}

	// Token: 0x0601AB9C RID: 109468 RVA: 0x007F5764 File Offset: 0x007F3964
	private unsafe void CheckTickFrame()
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.IsRoleAndCtrlByMe && (long)Singleton<Time>.Instance.Frame - this.DebugLastTickFrame > 1L)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "[b1057126] 角色更新异常";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DebugLastTickFrame", this.DebugLastTickFrame);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Current", Singleton<Time>.Instance.Frame);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.DebugLastTickFrame = (long)Singleton<Time>.Instance.Frame;
	}

	// Token: 0x0601AB9D RID: 109469 RVA: 0x007F5819 File Offset: 0x007F3A19
	public override void OnEntityBudgetTickEnableChange(bool isEnable)
	{
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null && animComp.Valid && isEnable)
		{
			this.AnimComp.ConsumeRootMotion();
		}
	}

	// Token: 0x0601AB9E RID: 109470 RVA: 0x007F583C File Offset: 0x007F3A3C
	public void EnableFixFacingForVelocityOneFrame(bool enable, float? turnSpeed)
	{
		if (this.FixFacingForVelocity == enable)
		{
			return;
		}
		this.FixFacingForVelocity = enable;
		float? num = turnSpeed;
		float valueOrDefault;
		if (num == null)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			valueOrDefault = ((actorComp != null) ? actorComp.OverrideTurnSpeed : null).GetValueOrDefault(180f);
		}
		else
		{
			valueOrDefault = num.GetValueOrDefault();
		}
		this.FixFacingTurnSpeed = valueOrDefault;
	}

	// Token: 0x0601AB9F RID: 109471 RVA: 0x007F589C File Offset: 0x007F3A9C
	public void SetVelocityInfoCacheEnable(bool enable)
	{
		if (this.EnableVelocityInfoCache == enable)
		{
			return;
		}
		this.ActorComp.Actor.CharacterMovement.bKuroVelocityDebug = enable;
		this.ActorComp.Actor.Mesh.bRootMotionDebug = enable;
		this.EnableVelocityInfoCache = enable;
		this.VelocityInfoCacheArray.Clear();
		this.FrameCounter = 0;
	}

	// Token: 0x0601ABA0 RID: 109472 RVA: 0x007F58F8 File Offset: 0x007F3AF8
	public void UpdateVelocityCache()
	{
		if (!this.EnableVelocityInfoCache)
		{
			return;
		}
		while (this.FrameCounter > this.VelocityInfoFrameSize)
		{
			long? num = null;
			if (this.VelocityInfoCacheArray.Count > 0)
			{
				VelocityCacheInfo velocityCacheInfo = this.VelocityInfoCacheArray[0];
				num = ((velocityCacheInfo != null) ? new long?(velocityCacheInfo.Frame) : null);
				this.VelocityInfoCacheArray.RemoveAt(0);
			}
			while (this.VelocityInfoCacheArray.Count != 0)
			{
				long? num2 = num;
				long num3 = this.LastFrame;
				if (num2.GetValueOrDefault() == num3 & num2 != null)
				{
					break;
				}
				num2 = num;
				num3 = this.VelocityInfoCacheArray[0].Frame;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					break;
				}
				this.VelocityInfoCacheArray.RemoveAt(0);
			}
			this.FrameCounter--;
		}
	}

	// Token: 0x0601ABA1 RID: 109473 RVA: 0x007F59D8 File Offset: 0x007F3BD8
	public void CacheVelocityInfo(string context)
	{
		if (!this.EnableVelocityInfoCache)
		{
			return;
		}
		VelocityCacheInfo velocityCacheInfo = new VelocityCacheInfo();
		velocityCacheInfo.Frame = UKismetSystemLibrary.GetFrameCount();
		velocityCacheInfo.SpeedZ = new float?((float)Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.ActorVelocityProxy));
		velocityCacheInfo.MoveMode = new EMovementMode?(this.ActorComp.Actor.CharacterMovement.MovementMode);
		Vector tmpVectorField = this.TmpVectorField;
		FVector fvector = this.ActorComp.Actor.CharacterMovement.Velocity;
		tmpVectorField.FromUeVector(fvector);
		velocityCacheInfo.VelocityZ = new float?((float)Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TmpVectorField));
		Vector tmpVectorField2 = this.TmpVectorField;
		fvector = this.ActorComp.Actor.CharacterMovement.GetLastUpdateVelocity();
		tmpVectorField2.FromUeVector(fvector);
		velocityCacheInfo.LastZ = new float?((float)Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TmpVectorField));
		velocityCacheInfo.Context = context;
		long frameCount = UKismetSystemLibrary.GetFrameCount();
		this.VelocityInfoCacheArray.Add(velocityCacheInfo);
		this.FrameCounter += ((this.LastFrame != frameCount) ? 1 : 0);
		this.LastFrame = frameCount;
	}

	// Token: 0x0601ABA2 RID: 109474 RVA: 0x007F5B10 File Offset: 0x007F3D10
	public unsafe void DumpVelocityCacheInfo(string reason = "", bool onlyLast = false)
	{
		if (!this.EnableVelocityInfoCache)
		{
			return;
		}
		if (this.VelocityInfoCacheArray.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[b1123700] Cannot dump velocity infos for empty cache";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "PbDataId";
			CharacterActorComponent actorComp = this.ActorComp;
			ptr = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Frame", UKismetSystemLibrary.GetFrameCount());
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item2 = "Name";
			CharacterActorComponent actorComp2 = this.ActorComp;
			object item3;
			if (actorComp2 == null)
			{
				item3 = null;
			}
			else
			{
				TsBaseCharacter actor = actorComp2.Actor;
				item3 = ((actor != null) ? actor.GetName() : null);
			}
			ptr2 = new ValueTuple<string, object>(item2, item3);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Test;
		ELogAuthor author2 = ELogAuthor.YJX;
		string message2 = "[b1123700] Dump cached velocity infos";
		<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray6<ValueTuple<string, object>>);
		ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
		string item4 = "PbDataId";
		CharacterActorComponent actorComp3 = this.ActorComp;
		ptr3 = new ValueTuple<string, object>(item4, (actorComp3 != null) ? new int?(actorComp3.CreatureData.GetPbDataId()) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Frame", UKismetSystemLibrary.GetFrameCount());
		ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2);
		string item5 = "Name";
		CharacterActorComponent actorComp4 = this.ActorComp;
		ptr4 = new ValueTuple<string, object>(item5, (actorComp4 != null) ? actorComp4.Actor : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("Size", this.VelocityInfoCacheArray.Count);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("OnlyLast", onlyLast);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 5) = new ValueTuple<string, object>("Reason", reason);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 6));
		string text = "";
		if (onlyLast)
		{
			int count = this.VelocityInfoCacheArray.Count;
			text += this.VelocityInfoCacheArray[count - 1].Dump();
		}
		else
		{
			foreach (VelocityCacheInfo velocityCacheInfo in this.VelocityInfoCacheArray)
			{
				text += velocityCacheInfo.Dump();
			}
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.Test;
		ELogAuthor author3 = ELogAuthor.YJX;
		string message3 = "[b1123700] DumpInfos";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Info", text);
		instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601ABA3 RID: 109475 RVA: 0x007F5DBC File Offset: 0x007F3FBC
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		UeMovementTickManageComponent ueMovementTickManageComponent = (UeMovementTickManageComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (ueMovementTickManageComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComponent"))
		{
			if (ueMovementTickManageComponent.MoveComponent == null)
			{
				this.MoveComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UCharacterMovementComponent>(this.MoveComponent), "MoveComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (ueMovementTickManageComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("VehiclePerformComp"))
		{
			if (ueMovementTickManageComponent.VehiclePerformComp == null)
			{
				this.VehiclePerformComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseVehiclePerformComponent>(this.VehiclePerformComp), "VehiclePerformComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CharacterMoveComp"))
		{
			if (ueMovementTickManageComponent.CharacterMoveComp == null)
			{
				this.CharacterMoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseMoveComponent>(this.CharacterMoveComp), "CharacterMoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DebugComp"))
		{
			if (ueMovementTickManageComponent.DebugComp == null)
			{
				this.DebugComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ActorDebugMovementComponent>(this.DebugComp), "DebugComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("<SkelTickMgr>k__BackingField"))
		{
			if (ueMovementTickManageComponent.SkelTickMgr == null)
			{
				this.SkelTickMgr = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UeSkeletalTickManageComponent>(this.SkelTickMgr), "<SkelTickMgr>k__BackingField"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FixFacingForVelocity"))
		{
			this.FixFacingForVelocity = ueMovementTickManageComponent.FixFacingForVelocity;
		}
		if (base.CanResetComponentProperty("FixFacingTurnSpeed"))
		{
			this.FixFacingTurnSpeed = ueMovementTickManageComponent.FixFacingTurnSpeed;
		}
		if (base.CanResetComponentProperty("ProxyTickCount"))
		{
			this.ProxyTickCount = ueMovementTickManageComponent.ProxyTickCount;
		}
		if (base.CanResetComponentProperty("ProxyTickDelta"))
		{
			this.ProxyTickDelta = ueMovementTickManageComponent.ProxyTickDelta;
		}
		if (base.CanResetComponentProperty("TickModeInternal"))
		{
			this.TickModeInternal = ueMovementTickManageComponent.TickModeInternal;
		}
		if (base.CanResetComponentProperty("HasMove"))
		{
			this.HasMove = ueMovementTickManageComponent.HasMove;
		}
		if (base.CanResetComponentProperty("ModelBufferTimeLength"))
		{
			this.ModelBufferTimeLength = ueMovementTickManageComponent.ModelBufferTimeLength;
		}
		if (base.CanResetComponentProperty("OldMeshTransform"))
		{
			this.OldMeshTransform = ueMovementTickManageComponent.OldMeshTransform;
		}
		if (base.CanResetComponentProperty("OldActorLocation") && ueMovementTickManageComponent.OldActorLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.OldActorLocation), "OldActorLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("OldActorRotator") && ueMovementTickManageComponent.OldActorRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.OldActorRotator), "OldActorRotator"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ForbiddenTickPoseInternal"))
		{
			this.ForbiddenTickPoseInternal = ueMovementTickManageComponent.ForbiddenTickPoseInternal;
		}
		if (base.CanResetComponentProperty("UroParams"))
		{
			if (ueMovementTickManageComponent.UroParams == null)
			{
				this.UroParams = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FAnimUpdateRateParameters>(this.UroParams), "UroParams"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TeleportLockInternal"))
		{
			this.TeleportLockInternal = ueMovementTickManageComponent.TeleportLockInternal;
		}
		if (base.CanResetComponentProperty("Frozen"))
		{
			this.Frozen = ueMovementTickManageComponent.Frozen;
		}
		if (base.CanResetComponentProperty("DebugLastTickFrame"))
		{
			this.DebugLastTickFrame = ueMovementTickManageComponent.DebugLastTickFrame;
		}
		if (base.CanResetComponentProperty("EnableVelocityInfoCache"))
		{
			this.EnableVelocityInfoCache = ueMovementTickManageComponent.EnableVelocityInfoCache;
		}
		if (base.CanResetComponentProperty("VelocityInfoCacheArray"))
		{
			if (ueMovementTickManageComponent.VelocityInfoCacheArray == null)
			{
				this.VelocityInfoCacheArray = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<VelocityCacheInfo>>(this.VelocityInfoCacheArray), "VelocityInfoCacheArray"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("VelocityInfoFrameSize"))
		{
			this.VelocityInfoFrameSize = ueMovementTickManageComponent.VelocityInfoFrameSize;
		}
		if (base.CanResetComponentProperty("FrameCounter"))
		{
			this.FrameCounter = ueMovementTickManageComponent.FrameCounter;
		}
		if (base.CanResetComponentProperty("LastFrame"))
		{
			this.LastFrame = ueMovementTickManageComponent.LastFrame;
		}
		if (base.CanResetComponentProperty("TmpVectorField"))
		{
			if (ueMovementTickManageComponent.TmpVectorField == null)
			{
				this.TmpVectorField = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVectorField), "TmpVectorField"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D89D RID: 55453
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400D89E RID: 55454
	[Nullable(2)]
	private UCharacterMovementComponent MoveComponent;

	// Token: 0x0400D89F RID: 55455
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400D8A0 RID: 55456
	[Nullable(2)]
	private BaseVehiclePerformComponent VehiclePerformComp;

	// Token: 0x0400D8A1 RID: 55457
	[Nullable(2)]
	private BaseMoveComponent CharacterMoveComp;

	// Token: 0x0400D8A2 RID: 55458
	[Nullable(2)]
	private ActorDebugMovementComponent DebugComp;

	// Token: 0x0400D8A4 RID: 55460
	private bool FixFacingForVelocity;

	// Token: 0x0400D8A5 RID: 55461
	private float FixFacingTurnSpeed;

	// Token: 0x0400D8A6 RID: 55462
	private int ProxyTickCount;

	// Token: 0x0400D8A7 RID: 55463
	private float ProxyTickDelta;

	// Token: 0x0400D8A8 RID: 55464
	private EMovementTickMode TickModeInternal;

	// Token: 0x0400D8A9 RID: 55465
	private bool HasMove;

	// Token: 0x0400D8AA RID: 55466
	private float ModelBufferTimeLength;

	// Token: 0x0400D8AB RID: 55467
	private FTransformDouble? OldMeshTransform;

	// Token: 0x0400D8AC RID: 55468
	private readonly Vector OldActorLocation = Vector.Create();

	// Token: 0x0400D8AD RID: 55469
	private readonly Rotator OldActorRotator = Rotator.Create();

	// Token: 0x0400D8AE RID: 55470
	private bool ForbiddenTickPoseInternal;

	// Token: 0x0400D8AF RID: 55471
	[Nullable(2)]
	private FAnimUpdateRateParameters UroParams;

	// Token: 0x0400D8B0 RID: 55472
	private bool TeleportLockInternal;

	// Token: 0x0400D8B1 RID: 55473
	public bool Frozen;

	// Token: 0x0400D8B2 RID: 55474
	private long DebugLastTickFrame;

	// Token: 0x0400D8B3 RID: 55475
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector = Vector.Create();

	// Token: 0x0400D8B4 RID: 55476
	[StaticVariableRuleIgnore]
	private static readonly Rotator TmpRotator = Rotator.Create();

	// Token: 0x0400D8B5 RID: 55477
	public bool EnableVelocityInfoCache;

	// Token: 0x0400D8B6 RID: 55478
	public List<VelocityCacheInfo> VelocityInfoCacheArray = new List<VelocityCacheInfo>();

	// Token: 0x0400D8B7 RID: 55479
	public int VelocityInfoFrameSize = 5;

	// Token: 0x0400D8B8 RID: 55480
	public int FrameCounter;

	// Token: 0x0400D8B9 RID: 55481
	public long LastFrame;

	// Token: 0x0400D8BA RID: 55482
	public Vector TmpVectorField = Vector.Create();
}
