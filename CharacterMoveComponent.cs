using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02003059 RID: 12377
[NullableContext(1)]
[Nullable(0)]
public class CharacterMoveComponent : BaseMoveComponent, IComponentDependency, IStaticVariableResetter
{
	// Token: 0x06019679 RID: 104057 RVA: 0x00754804 File Offset: 0x00752A04
	static CharacterMoveComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterMoveComponent.CreateStaticDefaultValue), new Action(CharacterMoveComponent.ResetStaticDefaultValue));
	}

	// Token: 0x1700223F RID: 8767
	// (get) Token: 0x0601967A RID: 104058 RVA: 0x0075488B File Offset: 0x00752A8B
	// (set) Token: 0x0601967B RID: 104059 RVA: 0x00754892 File Offset: 0x00752A92
	[StaticVariableRuleIgnore]
	public static bool EnableKuroAsyncRootMotion
	{
		get
		{
			return CharacterMoveComponent.EnableKuroAsyncRootMotionInternal;
		}
		set
		{
			CharacterMoveComponent.EnableKuroAsyncRootMotionInternal = value;
		}
	}

	// Token: 0x17002240 RID: 8768
	// (get) Token: 0x0601967C RID: 104060 RVA: 0x0075489A File Offset: 0x00752A9A
	public static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(CharacterActorComponent)
			};
		}
	}

	// Token: 0x0601967D RID: 104061 RVA: 0x007548B0 File Offset: 0x00752AB0
	public void SetForceFallingSpeed(FVector speed, int tagId)
	{
		this.ForceFallingSpeedCache.ForceFallingSpeed.FromUeVector(speed);
		double addZ = Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.ForceFallingSpeedCache.ForceFallingSpeed);
		this.TmpVector.Reset();
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, addZ);
		base.SetForceSpeed(this.TmpVector);
		this.ForceFallingSpeedCache.Tag = tagId;
		this.ForceFallingSpeedCache.HasForceFallingSpeed = true;
	}

	// Token: 0x0601967E RID: 104062 RVA: 0x00754934 File Offset: 0x00752B34
	public override bool ConsumeForceFallingSpeed()
	{
		if (!this.ForceFallingSpeedCache.HasForceFallingSpeed)
		{
			return false;
		}
		if (!this.TagComponent.HasTag(this.ForceFallingSpeedCache.Tag))
		{
			this.ForceFallingSpeedCache.HasForceFallingSpeed = false;
			return false;
		}
		if (!this.AnimComp.HasKuroRootMotion && this.CharacterMovement.MovementMode == EMovementMode.MOVE_Falling)
		{
			double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.ActorVelocityProxy);
			Singleton<GravityUtils>.Instance.SetZnInGravityForActor(this.ActorComp, this.ForceFallingSpeedCache.ForceFallingSpeed, (double)((float)znInGravityForActor));
			base.SetForceSpeed(this.ForceFallingSpeedCache.ForceFallingSpeed);
			this.ForceFallingSpeedCache.HasForceFallingSpeed = false;
			return true;
		}
		return false;
	}

	// Token: 0x17002241 RID: 8769
	// (get) Token: 0x0601967F RID: 104063 RVA: 0x007549F5 File Offset: 0x00752BF5
	public float WalkSpeed
	{
		get
		{
			return base.CurrentMovementSettings.WalkSpeed;
		}
	}

	// Token: 0x17002242 RID: 8770
	// (get) Token: 0x06019680 RID: 104064 RVA: 0x00754A02 File Offset: 0x00752C02
	public float RunSpeed
	{
		get
		{
			return base.CurrentMovementSettings.RunSpeed;
		}
	}

	// Token: 0x17002243 RID: 8771
	// (get) Token: 0x06019681 RID: 104065 RVA: 0x00754A0F File Offset: 0x00752C0F
	public float SprintSpeed
	{
		get
		{
			return base.CurrentMovementSettings.SprintSpeed;
		}
	}

	// Token: 0x17002244 RID: 8772
	// (get) Token: 0x06019682 RID: 104066 RVA: 0x00754A1C File Offset: 0x00752C1C
	public float SwimSpeed
	{
		get
		{
			return base.CurrentMovementSettings.NormalSwimSpeed;
		}
	}

	// Token: 0x17002245 RID: 8773
	// (get) Token: 0x06019683 RID: 104067 RVA: 0x00754A29 File Offset: 0x00752C29
	public float FastSwimSpeed
	{
		get
		{
			return base.CurrentMovementSettings.FastSwimSpeed;
		}
	}

	// Token: 0x17002246 RID: 8774
	// (get) Token: 0x06019684 RID: 104068 RVA: 0x00754A36 File Offset: 0x00752C36
	public bool IsKuroPlanarPhysWalkingEnable
	{
		get
		{
			return this.IsKuroPlanarPhysWalkingEnableInternal;
		}
	}

	// Token: 0x06019685 RID: 104069 RVA: 0x00754A3E File Offset: 0x00752C3E
	public void SetOverrideMaxFallingSpeed(float v)
	{
		this.OverrideMaxFallingSpeed = v;
	}

	// Token: 0x06019686 RID: 104070 RVA: 0x00754A47 File Offset: 0x00752C47
	public void ResetOverrideMaxFallingSpeed()
	{
		this.OverrideMaxFallingSpeed = 0f;
	}

	// Token: 0x06019687 RID: 104071 RVA: 0x00754A54 File Offset: 0x00752C54
	public override void SetMaxSpeed(float newSpeed)
	{
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		float? num = (attributeComponent != null) ? new float?(attributeComponent.GetCurrentValue(EAttributeType.SpeedRatio)) : null;
		if (num == null || num.Value <= 0f)
		{
			num = new float?((float)10000);
		}
		num = new float?(num.Value / 10000f);
		EMovementMode emovementMode = this.CharacterMovement.MovementMode;
		if (emovementMode == EMovementMode.MOVE_Flying)
		{
			this.CharacterMovement.MaxFlySpeed = newSpeed * num.Value;
		}
		else if (emovementMode == EMovementMode.MOVE_Falling)
		{
			this.CharacterMovement.MaxWalkSpeed = ((this.OverrideMaxFallingSpeed > 0f) ? this.OverrideMaxFallingSpeed : newSpeed) * num.Value;
		}
		else
		{
			this.CharacterMovement.MaxWalkSpeed = newSpeed * num.Value;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			bool isRoleAndCtrlByMe = actorComp.IsRoleAndCtrlByMe;
		}
	}

	// Token: 0x06019688 RID: 104072 RVA: 0x00754B40 File Offset: 0x00752D40
	protected void OnLand()
	{
		this.GroundedTimeUe = UGameplayStatics.GetGamePlayTimeSeconds(this.ActorComp.Actor);
		this.GroundedFrame = Singleton<Time>.Instance.Frame;
		if (AActor.GetKuroNetMode() == EKuroNetMode.KNM_Net && this.ActorComp.IsAutonomousProxy)
		{
			Singleton<EventSystem>.Instance.Emit<Entity>(EEventName.EntityOnLandedPush, base.Entity);
		}
	}

	// Token: 0x06019689 RID: 104073 RVA: 0x00754BA8 File Offset: 0x00752DA8
	protected void OnPositionStateChanged(global::ECharPositionState oldPositionState, global::ECharPositionState newPositionState)
	{
		if (oldPositionState == global::ECharPositionState.Air)
		{
			this.IsFallingIntoWater = false;
			base.StopAddMove(this.AirInertiaHandler);
			this.AirInertiaHandler = 0;
			if (this.ActorComp.IsRoleAndCtrlByMe && newPositionState == global::ECharPositionState.Ground)
			{
				this.PlayerMotionRequest(MotionType.BeLand);
			}
		}
		switch (newPositionState)
		{
		case global::ECharPositionState.Ground:
			if (base.Entity.Active && this.ActorComp.IsAutonomousProxy)
			{
				CharacterDamageComponent component = base.Entity.GetComponent<CharacterDamageComponent>();
				if (component == null)
				{
					return;
				}
				component.FallInjure();
				return;
			}
			break;
		case global::ECharPositionState.Climb:
			break;
		case global::ECharPositionState.Air:
			if (this.HasBaseMovement && !this.ActorComp.Actor.BasedMovement.bRelativeRotation && this.DeltaBaseMovementSpeed != null)
			{
				this.AirInertiaHandler = base.SetAddMoveWorld(this.DeltaBaseMovementSpeed, 1.5f, BaseMoveComponent.BaseMoveInheritCurve, new int?(this.AirInertiaHandler), null, global::EVelocityCurveType.None, 0f, 1f);
			}
			if (this.DeltaConveyBeltSpeed != null)
			{
				this.AirInertiaHandler = base.SetAddMoveWorld(this.DeltaConveyBeltSpeed, 1.5f, BaseMoveComponent.BaseMoveInheritCurve, new int?(this.AirInertiaHandler), null, global::EVelocityCurveType.None, 0f, 1f);
			}
			break;
		case global::ECharPositionState.Water:
		{
			this.VelocityVector.FromUeVector(this.ActorComp.ActorVelocityProxy);
			double num = this.VelocityVector.Size();
			if (num > 800.0)
			{
				this.VelocityVector.MultiplyEqual(800.0 / num);
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp == null)
				{
					return;
				}
				actorComp.SetActorVelocity(this.VelocityVector);
				return;
			}
			break;
		}
		default:
			return;
		}
	}

	// Token: 0x0601968A RID: 104074 RVA: 0x00754D48 File Offset: 0x00752F48
	[NullableContext(2)]
	protected void OnStateInherit(Entity other, bool notInheritMoveAndAnim)
	{
		if (other == null || !other.Valid)
		{
			return;
		}
		CharacterMoveComponent component = other.GetComponent<CharacterMoveComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		CharacterInputComponent component2 = other.GetComponent<CharacterInputComponent>();
		CharacterInputComponent component3 = base.Entity.GetComponent<CharacterInputComponent>();
		if (component2 != null && component3 != null)
		{
			InputContinuously autoMovingConfig = component2.GetAutoMovingConfig();
			if (autoMovingConfig.GetAutoMovingState())
			{
				component3.SetAutoMovingConfig(autoMovingConfig);
				autoMovingConfig.ResetAutoMovingState("切人");
			}
			component3.IsLocalInput = component2.IsLocalInput;
		}
		BaseGravityComponent component4 = base.Entity.GetComponent<BaseGravityComponent>();
		if (component4 != null)
		{
			component4.SetGravityByPriority(0, component.GravityDirect, true, -1f, true);
		}
		this.CharacterMovement.ConsumeInputVector();
		this.CharacterMovement.AddInputVector(component.CharacterMovement.GetLastInputVector(), true);
		this.ActorComp.SetInputDirect(component.ActorComp.InputDirectProxy, false);
		this.ActorComp.SetInputFacing(component.ActorComp.InputFacingProxy, false);
		this.ActorComp.SetOverrideTurnSpeed(component.ActorComp.OverrideTurnSpeed);
		this.HasMoveInput = component.HasMoveInput;
		this.CharacterMovement.LastUpdateVelocity = component.GetLastUpdateVelocity();
		this.ActorComp.ResetCachedVelocityTime();
		CharacterActorComponent actorComp = component.ActorComp;
		if (actorComp != null)
		{
			actorComp.ClearInput(false, false);
		}
		if (component2 != null)
		{
			component2.ResetMoveVectorCache();
		}
		if (notInheritMoveAndAnim)
		{
			return;
		}
		this.MoveInherit(component);
		this.TagInherit(other, component);
	}

	// Token: 0x0601968B RID: 104075 RVA: 0x00754EB4 File Offset: 0x007530B4
	protected unsafe void OnTeleportStart(bool b)
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.CreatureData.IsRole())
		{
			return;
		}
		if (base.IsMovingToLocation())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "因传送打断当前移动,设置移动结果失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "PbDataId";
			CharacterActorComponent actorComp2 = this.ActorComp;
			ptr = new ValueTuple<string, object>(item, (actorComp2 != null) ? new int?(actorComp2.CreatureData.GetPbDataId()) : null);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			base.StopMoveWithCallback(ELevelEventState.Failure, "CharacterMoveComponent.OnTeleportStart");
		}
	}

	// Token: 0x0601968C RID: 104076 RVA: 0x00754F80 File Offset: 0x00753180
	private void MoveInherit(CharacterMoveComponent otherMoveComp)
	{
		this.IsMoving = otherMoveComp.IsMoving;
		this.LastJumpTime = otherMoveComp.LastJumpTime;
		CharacterMoveComponent.TempVelocity.DeepCopy(otherMoveComp.ActorComp.ActorVelocityProxy);
		double num = CharacterMoveComponent.TempVelocity.SizeSquared();
		if (num > 1000000.0)
		{
			CharacterMoveComponent.TempVelocity.MultiplyEqual((double)((float)Math.Sqrt(1000000.0 / num)));
		}
		BaseTagComponent component = base.Entity.GetComponent<BaseTagComponent>();
		if (component == null || !component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.切人不继承速度"]))
		{
			this.ForceSpeed.DeepCopy(CharacterMoveComponent.TempVelocity);
			this.Speed = (float)Math.Sqrt(Singleton<GravityUtils>.Instance.GetPlanarSizeSquared2dForActor(this.ActorComp, this.ForceSpeed));
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.SetActorVelocity(this.ForceSpeed);
			}
			this.CharacterMovement.LastUpdateVelocity = otherMoveComp.CharacterMovement.LastUpdateVelocity;
		}
		UeMovementTickManageComponent component2 = otherMoveComp.Entity.GetComponent<UeMovementTickManageComponent>();
		if (component2 != null)
		{
			component2.DumpVelocityCacheInfo("战斗换人", false);
		}
		if (otherMoveComp.ActorComp.Actor.BasedMovement.MovementBase == null)
		{
			this.ActorComp.Actor.BasedMovement.MovementBase = null;
		}
		FFindFloorResult currentFloor = this.ActorComp.Actor.CharacterMovement.CurrentFloor;
		FFindFloorResult currentFloor2 = otherMoveComp.ActorComp.Actor.CharacterMovement.CurrentFloor;
		currentFloor.bBlockingHit = currentFloor2.bBlockingHit;
		currentFloor.bLineTrace = currentFloor2.bLineTrace;
		currentFloor.bWalkableFloor = currentFloor2.bWalkableFloor;
		currentFloor.FloorDist = currentFloor2.FloorDist;
		currentFloor.HitResult = currentFloor2.HitResult;
		currentFloor.LineDist = currentFloor2.LineDist;
		UKuroStaticLibrary.SetBaseAndSaveBaseLocation(this.CharacterMovement, otherMoveComp.CharacterMovement.GetMovementBase());
	}

	// Token: 0x0601968D RID: 104077 RVA: 0x0075514C File Offset: 0x0075334C
	private void TagInherit(Entity other, CharacterMoveComponent otherMoveComp)
	{
		BaseTagComponent component = other.GetComponent<BaseTagComponent>();
		CharacterUnifiedStateComponent component2 = other.GetComponent<CharacterUnifiedStateComponent>();
		if (otherMoveComp.CharacterMovement.MovementMode == EMovementMode.MOVE_None || (component != null && component.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.幻象变身中"])))
		{
			this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Walking,
				CustomMode = 0,
				Context = "[CharacterMoveComponent.OnStateInherit] MOVE_None"
			});
			return;
		}
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent == null || !tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.不继承移动模式"]))
		{
			if (otherMoveComp.CharacterMovement.MovementMode != EMovementMode.MOVE_Flying)
			{
				BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
				if ((unifiedStateComponent == null || unifiedStateComponent.MoveState != global::ECharMoveState.Roll) && (component2 == null || component2.PositionState != global::ECharPositionState.Floating) && (component2 == null || component2.PositionState != global::ECharPositionState.Ride))
				{
					CharacterWalkOnWaterComponent walkOnWaterComp = this.WalkOnWaterComp;
					if (walkOnWaterComp == null || !walkOnWaterComp.BlockMoveModeInherit(otherMoveComp.CharacterMovement))
					{
						this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
						{
							Mode = otherMoveComp.CharacterMovement.MovementMode,
							CustomMode = otherMoveComp.CharacterMovement.CustomMovementMode,
							Context = "[CharacterMoveComponent.OnStateInherit]"
						});
					}
				}
			}
			return;
		}
		if (otherMoveComp.CharacterMovement.MovementMode == EMovementMode.MOVE_Walking)
		{
			this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = otherMoveComp.CharacterMovement.MovementMode,
				CustomMode = otherMoveComp.CharacterMovement.CustomMovementMode,
				Context = "[CharacterMoveComponent.OnStateInherit.]"
			});
			return;
		}
		this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = EMovementMode.MOVE_Falling,
			CustomMode = 0,
			Context = "[CharacterMoveComponent.OnStateInherit]"
		});
	}

	// Token: 0x0601968E RID: 104078 RVA: 0x00755344 File Offset: 0x00753544
	protected void OnSprintTag(int tagId, bool tagExist)
	{
		if (tagExist)
		{
			if (tagId == GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避.前闪"])
			{
				this.PlayerMotionRequest(MotionType.Spurt);
				return;
			}
			if (tagId == GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避.后闪"])
			{
				this.PlayerMotionRequest(MotionType.Pullback);
				return;
			}
			if (tagId == GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避.空中前闪"])
			{
				this.PlayerMotionRequest(MotionType.AirSprint);
				return;
			}
			if (tagId == GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避.空中后闪"])
			{
				this.PlayerMotionRequest(MotionType.BackFlip);
			}
		}
	}

	// Token: 0x0601968F RID: 104079 RVA: 0x007553BB File Offset: 0x007535BB
	protected void OnEnableWalkOnAirTag(int tagId, bool tagExist)
	{
		this.CharacterMovement.bKuroWalkOnAir = tagExist;
	}

	// Token: 0x06019690 RID: 104080 RVA: 0x007553CC File Offset: 0x007535CC
	[NullableContext(2)]
	protected void OnVisionMorphBegin(EntityHandle visionEntity, EntityHandle roleEntity)
	{
		if ((roleEntity == null || !roleEntity.Valid || roleEntity.Id != base.Entity.Id) && (visionEntity == null || !visionEntity.Valid || visionEntity.Id != base.Entity.Id))
		{
			return;
		}
		this.ResetPlanarPhysWalking();
	}

	// Token: 0x06019691 RID: 104081 RVA: 0x00755428 File Offset: 0x00753628
	[NullableContext(2)]
	protected void OnVisionMorphEnd(EntityHandle roleEntity, EntityHandle visionEntity)
	{
		if ((roleEntity == null || !roleEntity.Valid || roleEntity.Id != base.Entity.Id) && (visionEntity == null || !visionEntity.Valid || visionEntity.Id != base.Entity.Id))
		{
			return;
		}
		this.ResetPlanarPhysWalking();
	}

	// Token: 0x06019692 RID: 104082 RVA: 0x00755484 File Offset: 0x00753684
	[NullableContext(2)]
	protected void OnTeleportComplete(TeleportContext teleportContext)
	{
		this.ResetPlanarPhysWalking();
	}

	// Token: 0x06019693 RID: 104083 RVA: 0x0075548C File Offset: 0x0075368C
	protected void OnWorldDone()
	{
		this.ResetPlanarPhysWalking();
	}

	// Token: 0x06019694 RID: 104084 RVA: 0x00755494 File Offset: 0x00753694
	protected void OnRoleGoUp()
	{
		this.ResetPlanarPhysWalking();
	}

	// Token: 0x06019695 RID: 104085 RVA: 0x0075549C File Offset: 0x0075369C
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		base.OnInitData(args);
		this.ForceFallingSpeedCache = new ForceFallingSpeedCache();
		return true;
	}

	// Token: 0x06019696 RID: 104086 RVA: 0x007554B4 File Offset: 0x007536B4
	protected override bool OnClear()
	{
		base.OnClear();
		if (this.JumpDelayTimer != null)
		{
			TimerSystem.Instance.Remove(this.JumpDelayTimer);
		}
		CharacterMoveComponent.TempVelocity.Reset();
		MoveToLocationController moveController = base.MoveController;
		if (moveController != null)
		{
			moveController.Dispose();
		}
		this.UnInitMovementData();
		return true;
	}

	// Token: 0x06019697 RID: 104087 RVA: 0x00755504 File Offset: 0x00753704
	protected override bool OnStart()
	{
		this.AccelerationLerpCurve = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/Character/Role/Common/Data/Curves/CT_MoveFAcceleration.CT_MoveFAcceleration");
		UCurveFloat accelerationLerpCurve = this.AccelerationLerpCurve;
		if (accelerationLerpCurve == null || !accelerationLerpCurve.IsValid())
		{
			ModelBase<PreloadModelNew>.Instance.CommonAssetElement.PrintDebugInfo();
		}
		base.AccelerationLerpTime = 0f;
		this.AccelerationChangeMoveState = new global::ECharMoveState?(global::ECharMoveState.Other);
		CharacterActorComponent component = base.Entity.GetComponent<CharacterActorComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		this.IsHidden = false;
		this.ActorComp = component;
		this.CharacterMovement = component.Actor.CharacterMovement;
		global::Vector gravityDirectInternal = this.GravityDirectInternal;
		FVector fvector = this.CharacterMovement.Kuro_GetGravityDirect();
		gravityDirectInternal.FromUeVector(fvector);
		this.IsStandardGravityInternal = (Math.Abs(this.GravityDirectInternal.Z + 1.0) < 1E-08);
		if (this.IsStandardGravityInternal)
		{
			this.GravityDirectInternal.Set(0.0, 0.0, -1.0);
		}
		this.GravityDirectInternal.UnaryNegation(this.GravityUpInternal);
		this.CharacterMovement.GravityScale = 2f;
		this.CharacterMovement.bRotationFollowBaseMovement = true;
		this.CharacterMovement.SetWalkableFloorAngle(55f);
		this.CharacterMovement.bEnablePhysicsInteraction = false;
		this.SetKuroPlanarPhysWalking(this.IsEnablePlanarPhysWalking());
		this.SetKuroAsyncRootMotion(this.IsEnableAsyncRootMotion());
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		this.GlideComp = base.Entity.GetComponent<CharacterGlideComponent>();
		this.SwimComp = base.Entity.GetComponent<CharacterSwimComponent>();
		this.WalkOnWaterComp = base.Entity.GetComponent<CharacterWalkOnWaterComponent>();
		this.FloatingComp = base.Entity.GetComponent<CharacterFloatingComponent>();
		this.AttributeComponent = base.Entity.GetComponent<BaseAttributeComponent>();
		this.TagComponent = base.Entity.GetComponent<BaseTagComponent>();
		this.DeathComponent = base.Entity.GetComponent<BaseDeathComponent>();
		this.UnifiedStateComponent = base.Entity.GetComponent<BaseUnifiedStateComponent>();
		this.SkillComp = base.Entity.GetComponent<CharacterSkillComponent>();
		this.CapsuleOffset = global::Vector.Create(0.0, 0.0, (double)(this.ActorComp.Radius - this.ActorComp.HalfHeight));
		this.InitCreatureProperty();
		this.InitStepUpParams();
		this.InitMovementData();
		if (this.ActorComp.Actor.DtBaseMovementSetting == null || this.MovementData == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "以下BP_{Character}没有在蓝图中配置Dt_BaseMovementSetting找对应的蓝图负责人处理";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Character", this.ActorComp.Actor.GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(base.OnMoveStateChange));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(base.OnPositionStateChange));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnDirectionStateChanged, new Action<ECharDirectionState, ECharDirectionState>(base.OnDirectionStateChange));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnLand, new Action(this.OnLand));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.OnPositionStateChanged));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
		if (this.IsKuroPlanarPhysWalkingEnableInternal)
		{
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.VisionMorphBegin, new Action<EntityHandle, EntityHandle>(this.OnVisionMorphBegin));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.VisionMorphEnd, new Action<EntityHandle, EntityHandle>(this.OnVisionMorphEnd));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnRoleGoUp, new Action(this.OnRoleGoUp));
			Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		}
		this.IsStopInternal = false;
		base.InitBaseState();
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		if (attributeComponent != null)
		{
			attributeComponent.AddListener(EAttributeType.SpeedRatio, new Action<EAttributeType, float, float>(this.OnSpeedRatioAttributeChanged), null);
		}
		this.CannotResponseInputCount = 0;
		for (int i = 0; i < CharacterMoveComponent.cannotResponseInputTag.Length; i++)
		{
			int num = CharacterMoveComponent.cannotResponseInputTag[i];
			if (this.TagComponent != null)
			{
				if (this.TagComponent.HasTag(num))
				{
					this.CannotResponseInputCount++;
				}
				this.CanResponseInputTasks.Add(this.TagComponent.ListenForTagAddOrRemove(new int?(num), new BaseTagComponent.TTagSwitchedCallback(this.OnResponseInputTagsChanged), null));
			}
		}
		base.InitTraceInfo();
		this.TagComponent.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避.前闪"], new BaseTagComponent.TTagSwitchedCallback(this.OnSprintTag), null);
		this.TagComponent.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避.后闪"], new BaseTagComponent.TTagSwitchedCallback(this.OnSprintTag), null);
		this.TagComponent.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避.空中前闪"], new BaseTagComponent.TTagSwitchedCallback(this.OnSprintTag), null);
		this.TagComponent.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避.空中后闪"], new BaseTagComponent.TTagSwitchedCallback(this.OnSprintTag), null);
		this.TagComponent.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["功能.功能制作.开启空中步行状态"], new BaseTagComponent.TTagSwitchedCallback(this.OnEnableWalkOnAirTag), null);
		this.InitInputMoveLimit();
		return base.OnStart();
	}

	// Token: 0x06019698 RID: 104088 RVA: 0x00755AC0 File Offset: 0x00753CC0
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(base.OnMoveStateChange));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(base.OnPositionStateChange));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnDirectionStateChanged, new Action<ECharDirectionState, ECharDirectionState>(base.OnDirectionStateChange));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnLand, new Action(this.OnLand));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.OnPositionStateChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		if (this.IsKuroPlanarPhysWalkingEnableInternal)
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.VisionMorphBegin, new Action<EntityHandle, EntityHandle>(this.OnVisionMorphBegin));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.VisionMorphEnd, new Action<EntityHandle, EntityHandle>(this.OnVisionMorphEnd));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnRoleGoUp, new Action(this.OnRoleGoUp));
			Singleton<EventSystem>.Instance.Remove(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
		if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDoneAndCloseLoading, new Action(this.InitHandlePbMoveToPoint)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.InitHandlePbMoveToPoint));
		}
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		if (attributeComponent != null)
		{
			attributeComponent.RemoveListener(EAttributeType.SpeedRatio, new Action<EAttributeType, float, float>(this.OnSpeedRatioAttributeChanged));
		}
		for (int i = 0; i < this.CanResponseInputTasks.Count; i++)
		{
			this.CanResponseInputTasks[i].EndTask();
		}
		this.CanResponseInputTasks.Clear();
		this.IsHidden = false;
		this.TagComponent.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避.前闪"], new BaseTagComponent.TTagSwitchedCallback(this.OnSprintTag));
		this.TagComponent.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避.后闪"], new BaseTagComponent.TTagSwitchedCallback(this.OnSprintTag));
		this.TagComponent.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避.空中前闪"], new BaseTagComponent.TTagSwitchedCallback(this.OnSprintTag));
		this.TagComponent.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.闪避.空中后闪"], new BaseTagComponent.TTagSwitchedCallback(this.OnSprintTag));
		this.IsKuroPlanarPhysWalkingEnableInternal = false;
		return true;
	}

	// Token: 0x06019699 RID: 104089 RVA: 0x00755D90 File Offset: 0x00753F90
	protected override void OnActivate()
	{
		base.OnMoveStateChange(global::ECharMoveState.Stand, global::ECharMoveState.Run);
		if (this.CharacterMovement.MovementMode == EMovementMode.MOVE_NavWalking)
		{
			this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Walking,
				Context = "[CharacterMoveComponent.OnActivate]"
			});
		}
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		bool flag;
		if (component == null)
		{
			flag = (null != null);
		}
		else
		{
			CharacterMoveToPointConfig pbMoveToPointConfig = component.PbMoveToPointConfig;
			flag = (((pbMoveToPointConfig != null) ? pbMoveToPointConfig.TargetPos : null) != null);
		}
		if (flag)
		{
			if (ModelBase<GameModeModel>.Instance.WorldDoneAndLoadingClosed)
			{
				this.InitHandlePbMoveToPoint();
				return;
			}
			if (!Singleton<EventSystem>.Instance.Has(EEventName.WorldDoneAndCloseLoading, new Action(this.InitHandlePbMoveToPoint)))
			{
				Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.InitHandlePbMoveToPoint));
			}
		}
	}

	// Token: 0x0601969A RID: 104090 RVA: 0x00755E58 File Offset: 0x00754058
	private void InitHandlePbMoveToPoint()
	{
		if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDoneAndCloseLoading, new Action(this.InitHandlePbMoveToPoint)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.InitHandlePbMoveToPoint));
		}
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		bool flag;
		if (component == null)
		{
			flag = (null != null);
		}
		else
		{
			CharacterMoveToPointConfig pbMoveToPointConfig = component.PbMoveToPointConfig;
			flag = (((pbMoveToPointConfig != null) ? pbMoveToPointConfig.TargetPos : null) != null);
		}
		if (flag)
		{
			LevelGeneralNetworks.HandleRecvCharacterMoveToPoint(base.Entity, component.PbMoveToPointConfig);
		}
	}

	// Token: 0x0601969B RID: 104091 RVA: 0x00755ED5 File Offset: 0x007540D5
	protected override void OnDisable(string reason)
	{
		this.DeltaTimeSeconds = 0f;
		if (this.GetWhirlpoolEnable())
		{
			this.EndWhirlpool("实体Disable");
		}
	}

	// Token: 0x0601969C RID: 104092 RVA: 0x00755EF8 File Offset: 0x007540F8
	protected unsafe override void OnTick(float delta)
	{
		if ((double)delta < 1E-08)
		{
			return;
		}
		base.OnTick(delta);
		if (this.ActorComp == null || this.DeathComponent == null || (!this.WhirlpoolPoint.GetEnable() && this.DeathComponent.IsDead()))
		{
			return;
		}
		this.DeltaTimeSeconds = delta * 0.001f;
		MoveToLocationController moveController = base.MoveController;
		if (moveController != null)
		{
			moveController.UpdateMove(this.DeltaTimeSeconds);
		}
		if (this.SpeedLockFrame > 0)
		{
			this.SpeedLockFrame--;
		}
		if (base.IsJump)
		{
			this.LastJumpTime = Singleton<Time>.Instance.PlayerWorldTime;
			this.JumpFrameCount--;
		}
		base.LerpMaxAcceleration();
		base.UpdateBaseMovement();
		if (this.IsSpecialMove)
		{
			return;
		}
		if (this.IsStopInternal)
		{
			this.Speed = 0f;
		}
		else
		{
			this.Speed = (float)Math.Sqrt(Singleton<GravityUtils>.Instance.GetPlanarSizeSquared2dForActor(this.ActorComp, this.ActorComp.ActorVelocityProxy));
		}
		this.IsMoving = (this.Speed > 20f);
		if (this.ActorComp.IsMoveAutonomousProxy)
		{
			this.UpdateInputOrder();
			BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
			if (unifiedStateComponent != null && unifiedStateComponent.Valid && this.UnifiedStateComponent.PositionState == global::ECharPositionState.Air && this.UnifiedStateComponent.MoveState == global::ECharMoveState.Other && !this.AnimComp.HasKuroRootMotion)
			{
				float num = Math.Max(this.FallingHorizontalMaxSpeed, this.OverrideMaxFallingSpeed);
				if (this.Speed > num * 1.01f)
				{
					CharacterMoveComponent.TempVelocity.DeepCopy(this.ActorComp.ActorVelocityProxy);
					double addZ = Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, CharacterMoveComponent.TempVelocity);
					CharacterMoveComponent.TempVelocity.MultiplyEqual((double)(num / this.Speed));
					if (CharacterMoveComponent.TempVelocity.ContainsNaN())
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Movement;
						ELogAuthor author = ELogAuthor.LCZ;
						string message = "Air Speed Limit has NaN";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("velocity", CharacterMoveComponent.TempVelocity);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("speed", this.Speed);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("max", num);
						instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					}
					Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, CharacterMoveComponent.TempVelocity, addZ);
					this.ActorComp.SetActorVelocity(CharacterMoveComponent.TempVelocity);
					this.Speed = this.FallingHorizontalMaxSpeed;
				}
			}
			bool? flag = null;
			if (base.Entity.GetTickInterval() > 1)
			{
				CharacterAnimationComponent animComp = this.AnimComp;
				if (animComp != null && animComp.Valid && this.ActorComp.Owner.WasRecentlyRenderedOnScreen(0.2f))
				{
					flag = new bool?(true);
				}
			}
			FTransformDouble? ftransformDouble = null;
			if (flag.GetValueOrDefault())
			{
				ftransformDouble = new FTransformDouble?(this.AnimComp.GetMeshTransform());
			}
			bool flag2 = false;
			if (base.CanResponseInput())
			{
				base.SetInfoVar();
				float pitch = this.ActorComp.ActorRotationProxy.Pitch;
				this.UpdateFacing();
				flag2 = (flag2 || pitch != this.ActorComp.ActorRotationProxy.Pitch);
				base.CacheVar();
			}
			else
			{
				this.HasMoveInput = false;
			}
			if (this.WhirlpoolPoint.GetEnable())
			{
				flag2 = this.UpdateInAreaWhirlpool();
				WhirlpoolPoint whirlpoolPoint = this.WhirlpoolPoint;
				float deltaTimeSeconds = this.DeltaTimeSeconds;
				PawnTimeScaleComponent timeScaleComp = this.TimeScaleComp;
				if (!whirlpoolPoint.OnTick(deltaTimeSeconds * ((timeScaleComp != null) ? timeScaleComp.CurrentTimeScale : 1f)))
				{
					this.EndWhirlpool("时间到了");
				}
			}
			if (flag.GetValueOrDefault() && flag2)
			{
				this.AnimComp.SetModelBuffer(ftransformDouble.Value, delta * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
			}
			base.OnTickGravityScale();
			if (this.HasBaseMovement)
			{
				this.DeltaBaseMovementQuat.RotateVector(this.ActorComp.InputFacingProxy, this.TmpVector);
				this.ActorComp.SetInputFacing(this.TmpVector, true);
			}
			if (ModelBase<SundryModel>.Instance.SceneCheckOn)
			{
				base.PrintAnimInstanceMovementInfo();
			}
			this.UpdateMoveChain();
			if (this.TryGlideTime != 0.0)
			{
				if (this.TrySetGlide())
				{
					this.TryGlideTime = 0.0;
				}
				this.TryGlideTime = (double)((int)Math.Max(this.TryGlideTime - (double)delta, 0.0));
			}
			return;
		}
		if (base.CanResponseInput())
		{
			base.SetInfoVar();
			this.UpdateFacing();
			base.CacheVar();
			return;
		}
		this.HasMoveInput = false;
	}

	// Token: 0x0601969D RID: 104093 RVA: 0x0075637F File Offset: 0x0075457F
	protected bool ContainsTag(int tag)
	{
		BaseTagComponent tagComponent = this.TagComponent;
		return tagComponent != null && tagComponent.HasTag(tag);
	}

	// Token: 0x0601969E RID: 104094 RVA: 0x00756394 File Offset: 0x00754594
	public void JumpRelease()
	{
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		if (unifiedStateComponent == null || unifiedStateComponent.PositionState != global::ECharPositionState.Floating)
		{
			this.ActorComp.Actor.StopJumping();
			return;
		}
		Entity entity = base.Entity;
		if (entity == null)
		{
			return;
		}
		CharacterFloatingComponent component = entity.GetComponent<CharacterFloatingComponent>();
		if (component == null)
		{
			return;
		}
		component.JumpRelease();
	}

	// Token: 0x0601969F RID: 104095 RVA: 0x007563E4 File Offset: 0x007545E4
	protected bool JumpCheck()
	{
		if (!base.CanResponseInput() || this.ContainsTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止跳跃"]))
		{
			return false;
		}
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		if (unifiedStateComponent == null || unifiedStateComponent.PositionState != global::ECharPositionState.Ground)
		{
			BaseUnifiedStateComponent unifiedStateComponent2 = this.UnifiedStateComponent;
			return unifiedStateComponent2 != null && unifiedStateComponent2.PositionState == global::ECharPositionState.Ski;
		}
		return true;
	}

	// Token: 0x060196A0 RID: 104096 RVA: 0x00756440 File Offset: 0x00754640
	public override bool CanJumpPress()
	{
		if (this.GroundedFrame > Singleton<Time>.Instance.Frame - 2)
		{
			return false;
		}
		CharacterSkillComponent component = base.Entity.GetComponent<CharacterSkillComponent>();
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		global::ECharPositionState? echarPositionState = (unifiedStateComponent != null) ? new global::ECharPositionState?(unifiedStateComponent.PositionState) : null;
		BaseUnifiedStateComponent unifiedStateComponent2 = this.UnifiedStateComponent;
		global::ECharMoveState? echarMoveState = (unifiedStateComponent2 != null) ? new global::ECharMoveState?(unifiedStateComponent2.MoveState) : null;
		if (echarPositionState != null)
		{
			switch (echarPositionState.GetValueOrDefault())
			{
			case global::ECharPositionState.Ground:
			case global::ECharPositionState.Climb:
			case global::ECharPositionState.Ski:
				return (component == null || !component.Valid || component.CheckJumpCanInterrupt()) && this.JumpCheck();
			case global::ECharPositionState.Air:
				if (echarMoveState.GetValueOrDefault() == global::ECharMoveState.Glide)
				{
					return Singleton<Time>.Instance.WorldTime - this.LastGlidingControlTime > 0.30000001192092896;
				}
				echarMoveState.GetValueOrDefault();
				return true;
			case global::ECharPositionState.RailSlide:
			case global::ECharPositionState.Floating:
				return true;
			}
		}
		return false;
	}

	// Token: 0x060196A1 RID: 104097 RVA: 0x00756545 File Offset: 0x00754745
	public override bool CanWalkPress()
	{
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		return unifiedStateComponent != null && unifiedStateComponent.PositionState == global::ECharPositionState.Ground;
	}

	// Token: 0x060196A2 RID: 104098 RVA: 0x0075655C File Offset: 0x0075475C
	protected void LimitMaxSpeed()
	{
		this.VelocityVector.FromUeVector(this.ActorComp.ActorVelocityProxy);
		double num = this.VelocityVector.Size();
		SMovementSetting currentMovementSettings = base.CurrentMovementSettings;
		float? num2 = (currentMovementSettings != null) ? new float?(currentMovementSettings.SprintSpeed) : null;
		double num3 = num;
		float? num4 = num2;
		double? num5 = (num4 != null) ? new double?((double)num4.GetValueOrDefault()) : null;
		if (num3 > num5.GetValueOrDefault() & num5 != null)
		{
			this.VelocityVector.MultiplyEqual((double)num2.Value / num);
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp == null)
			{
				return;
			}
			actorComp.SetActorVelocity(this.VelocityVector);
		}
	}

	// Token: 0x060196A3 RID: 104099 RVA: 0x00756610 File Offset: 0x00754810
	protected void OnJump()
	{
		CharacterAnimationComponent component = base.Entity.GetComponent<CharacterAnimationComponent>();
		if (component != null && component.Valid && component.MainAnimInstance != null)
		{
			component.MainAnimInstance.Montage_Stop(0f, null);
		}
		this.JumpFrameCount = 3;
		this.AnimComp.OnJump();
	}

	// Token: 0x060196A4 RID: 104100 RVA: 0x00756660 File Offset: 0x00754860
	public void OnDropPress()
	{
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		if (unifiedStateComponent != null && unifiedStateComponent.PositionState == global::ECharPositionState.Floating)
		{
			CharacterFloatingComponent component = base.Entity.GetComponent<CharacterFloatingComponent>();
			if (component == null)
			{
				return;
			}
			component.CtrlPress();
		}
	}

	// Token: 0x060196A5 RID: 104101 RVA: 0x0075668E File Offset: 0x0075488E
	public void OnDropRelease()
	{
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		if (unifiedStateComponent != null && unifiedStateComponent.PositionState == global::ECharPositionState.Floating)
		{
			CharacterFloatingComponent component = base.Entity.GetComponent<CharacterFloatingComponent>();
			if (component == null)
			{
				return;
			}
			component.CtrlRelease();
		}
	}

	// Token: 0x060196A6 RID: 104102 RVA: 0x007566BC File Offset: 0x007548BC
	public void JumpPress()
	{
		if (this.CheckInHit())
		{
			return;
		}
		if (!this.CanJumpPress())
		{
			return;
		}
		CharacterFloatingComponent floatingComp = this.FloatingComp;
		if (floatingComp != null && floatingComp.IsFloating)
		{
			CharacterFloatingComponent component = base.Entity.GetComponent<CharacterFloatingComponent>();
			if (component != null)
			{
				component.JumpPressInAir();
			}
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null)
			{
				tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]));
			}
			CharacterSkillComponent component2 = base.Entity.GetComponent<CharacterSkillComponent>();
			if (component2 != null && component2.Valid && component2.CurrentSkill != null)
			{
				component2.StopGroup1Skill("悬浮跳跃打断技能");
			}
			this.OnJump();
			this.PlayerMotionRequest(MotionType.MotionJump);
			return;
		}
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		global::ECharPositionState? echarPositionState = (unifiedStateComponent != null) ? new global::ECharPositionState?(unifiedStateComponent.PositionState) : null;
		global::ECharPositionState? echarPositionState2 = echarPositionState;
		global::ECharPositionState echarPositionState3 = global::ECharPositionState.Ground;
		bool flag = echarPositionState2.GetValueOrDefault() == echarPositionState3 & echarPositionState2 != null;
		bool flag2 = echarPositionState.GetValueOrDefault() == global::ECharPositionState.Climb;
		if (flag || flag2)
		{
			BaseTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 != null)
			{
				tagComponent2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]));
			}
			CharacterSkillComponent component3 = base.Entity.GetComponent<CharacterSkillComponent>();
			if (component3 != null && component3.Valid && component3.CurrentSkill != null)
			{
				component3.StopGroup1Skill("跳跃打断技能");
				this.LimitMaxSpeed();
			}
			this.OnJump();
			if (flag)
			{
				this.PlayerMotionRequest(MotionType.MotionJump);
			}
			return;
		}
		if (echarPositionState.GetValueOrDefault() == global::ECharPositionState.Air)
		{
			if (this.JumpPressInAir())
			{
				return;
			}
		}
		else if (echarPositionState.GetValueOrDefault() == global::ECharPositionState.Ski)
		{
			if (this.JumpPressInSki())
			{
				return;
			}
		}
		else if (echarPositionState.GetValueOrDefault() == global::ECharPositionState.RailSlide && this.JumpPressInRailSlide())
		{
			return;
		}
		if (this.TrySetGlide())
		{
			return;
		}
		this.TryGlideTime = 500.0;
	}

	// Token: 0x060196A7 RID: 104103 RVA: 0x0075686C File Offset: 0x00754A6C
	protected bool CheckInHit()
	{
		return this.TagComponent != null && (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击"]) || this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.被击硬直时间"]));
	}

	// Token: 0x060196A8 RID: 104104 RVA: 0x007568BC File Offset: 0x00754ABC
	protected bool JumpPressInAir()
	{
		if (this.CheckInHit())
		{
			return false;
		}
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		global::ECharMoveState? echarMoveState = (unifiedStateComponent != null) ? new global::ECharMoveState?(unifiedStateComponent.MoveState) : null;
		if (echarMoveState.GetValueOrDefault() == global::ECharMoveState.Glide)
		{
			CharacterGlideComponent glideComp = this.GlideComp;
			if (glideComp != null && glideComp.Valid)
			{
				this.GlideComp.ExitGlideState("MoveComp");
				this.LastGlidingControlTime = Singleton<Time>.Instance.WorldTime;
			}
			return true;
		}
		if (echarMoveState.GetValueOrDefault() == global::ECharMoveState.Slide)
		{
			global::Vector tempVelocity = CharacterMoveComponent.TempVelocity;
			FVector fvector = this.CharacterMovement.Kuro_GetBlockDirectWhenMove();
			tempVelocity.FromUeVector(fvector);
			CharacterAnimationComponent animComp = this.AnimComp;
			if (animComp != null && animComp.Valid)
			{
				if (this.SlideTrans == null)
				{
					this.SlideTrans = global::Transform.Create();
				}
				Singleton<MathUtils>.Instance.LookRotationUpFirst(CharacterMoveComponent.TempVelocity, base.GravityUp, this.TmpQuat);
				this.SlideTrans.Set(this.ActorComp.ActorLocationProxy, this.TmpQuat, this.ActorComp.ActorScaleProxy);
				this.AnimComp.SetTransformWithModelBuffer(this.SlideTrans.ToUeTransform(), 100f, null, true);
			}
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, CharacterMoveComponent.TempVelocity);
			if (!CharacterMoveComponent.TempVelocity.Normalize(9.99999993922529E-09))
			{
				CharacterMoveComponent.TempVelocity.DeepCopy(this.ActorComp.ActorForwardProxy);
			}
			CharacterMoveComponent.TempVelocity.MultiplyEqual(900.0 / CharacterMoveComponent.TempVelocity.Size());
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.SetActorVelocity(CharacterMoveComponent.TempVelocity);
			}
			this.OnJump();
			CharacterActorComponent actorComp2 = this.ActorComp;
			if (actorComp2 != null)
			{
				actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Falling,
					Context = "[CharacterMoveComponent.JumpPressInAir]"
				});
			}
			this.PlayerMotionRequest(MotionType.MotionJump);
			return true;
		}
		return false;
	}

	// Token: 0x060196A9 RID: 104105 RVA: 0x00756A9C File Offset: 0x00754C9C
	protected bool JumpPressInSki()
	{
		if (this.CheckInHit())
		{
			return false;
		}
		CharacterSlideComponent component = base.Entity.GetComponent<CharacterSlideComponent>();
		if (!component)
		{
			return false;
		}
		UCharacterMovementComponent characterMovement = this.CharacterMovement;
		if (!(((characterMovement != null) ? new TEnumAsByte<EMovementMode>?(characterMovement.MovementMode) : null) != EMovementMode.MOVE_Custom))
		{
			UCharacterMovementComponent characterMovement2 = this.CharacterMovement;
			byte? b = (characterMovement2 != null) ? new byte?(characterMovement2.CustomMovementMode) : null;
			if (((b != null) ? new int?((int)b.GetValueOrDefault()) : null).GetValueOrDefault() == 8)
			{
				CharacterMoveComponent.TempVelocity.FromUeVector(this.ActorComp.ActorForwardProxy);
				CharacterAnimationComponent animComp = this.AnimComp;
				if (animComp != null && animComp.Valid)
				{
					if (this.SlideTrans == null)
					{
						this.SlideTrans = global::Transform.Create();
					}
					Singleton<MathUtils>.Instance.LookRotationUpFirst(CharacterMoveComponent.TempVelocity, component.SlideForward, this.TmpQuat);
					this.SlideTrans.Set(this.ActorComp.ActorLocationProxy, this.TmpQuat, this.ActorComp.ActorScaleProxy);
					this.AnimComp.SetTransformWithModelBuffer(this.SlideTrans.ToUeTransform(), 100f, null, true);
				}
				Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, CharacterMoveComponent.TempVelocity);
				if (!CharacterMoveComponent.TempVelocity.Normalize(9.99999993922529E-09))
				{
					CharacterMoveComponent.TempVelocity.DeepCopy(this.ActorComp.ActorForwardProxy);
				}
				CharacterMoveComponent.TempVelocity.MultiplyEqual((double)((float)Math.Sqrt(Singleton<GravityUtils>.Instance.GetPlanarSizeSquared2dForActor(this.ActorComp, this.ActorComp.ActorVelocityProxy))));
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp != null)
				{
					actorComp.SetActorVelocity(CharacterMoveComponent.TempVelocity);
				}
				this.OnJump();
				component.OnJump();
				this.PlayerMotionRequest(MotionType.MotionJump);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060196AA RID: 104106 RVA: 0x00756C98 File Offset: 0x00754E98
	protected bool JumpPressInRailSlide()
	{
		if (this.CheckInHit())
		{
			return false;
		}
		CharacterRailSlideComponent component = base.Entity.GetComponent<CharacterRailSlideComponent>();
		if (!component)
		{
			return false;
		}
		UCharacterMovementComponent characterMovement = this.CharacterMovement;
		if (!(((characterMovement != null) ? new TEnumAsByte<EMovementMode>?(characterMovement.MovementMode) : null) != EMovementMode.MOVE_Custom))
		{
			UCharacterMovementComponent characterMovement2 = this.CharacterMovement;
			byte? b = (characterMovement2 != null) ? new byte?(characterMovement2.CustomMovementMode) : null;
			if (((b != null) ? new int?((int)b.GetValueOrDefault()) : null).GetValueOrDefault() == 12)
			{
				component.OnJump();
				return true;
			}
		}
		return false;
	}

	// Token: 0x060196AB RID: 104107 RVA: 0x00756D60 File Offset: 0x00754F60
	public bool TrySetGlide()
	{
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		if (unifiedStateComponent == null || unifiedStateComponent.PositionState != global::ECharPositionState.Air)
		{
			return false;
		}
		global::ECharMoveState moveState = this.UnifiedStateComponent.MoveState;
		if (moveState == global::ECharMoveState.Glide || moveState == global::ECharMoveState.Slide)
		{
			return false;
		}
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.滑翔禁止"]))
		{
			return false;
		}
		if (Singleton<Time>.Instance.WorldTime - this.LastGlidingControlTime > 0.30000001192092896)
		{
			if (base.GetHeightAboveGround(500f) <= 250f)
			{
				BaseTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 == null || !tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为改变.跳跃进滑翔"]))
				{
					return false;
				}
			}
			if (ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.Strength) > 10f)
			{
				CharacterSkillComponent component = base.Entity.GetComponent<CharacterSkillComponent>();
				if (component != null && component.Valid && component.CurrentSkill != null)
				{
					if (!component.CheckGlideCanInterrupt())
					{
						return false;
					}
					component.StopGroup1Skill("滑翔打断技能");
					this.LimitMaxSpeed();
				}
				CharacterGlideComponent glideComp = this.GlideComp;
				if (glideComp != null && glideComp.Valid)
				{
					this.GlideComp.EnterGlideState("MoveComp");
					base.StopAddMove(this.AirInertiaHandler);
					this.AirInertiaHandler = 0;
					this.LastGlidingControlTime = Singleton<Time>.Instance.WorldTime;
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060196AC RID: 104108 RVA: 0x00756EB8 File Offset: 0x007550B8
	protected void PlayerMovementInput(FVectorDouble inputDirect)
	{
		CharacterActionComponent component = base.Entity.GetComponent<CharacterActionComponent>();
		if (component != null && component.GetSitDownState())
		{
			return;
		}
		CharacterSkillComponent skillComp = this.SkillComp;
		if (skillComp != null && skillComp.Valid && this.ContainsTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中.全身动作"]) && !this.ContainsTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.摇荡"]))
		{
			if (!base.CanResponseInput() || !skillComp.IsMainSkillReadyEnd || inputDirect.SizeSquared() < 1E-08 || this.ContainsTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.禁止移动打断技能"]))
			{
				return;
			}
			skillComp.StopGroup1Skill("移动打断技能");
		}
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		global::ECharPositionState? echarPositionState = (unifiedStateComponent != null) ? new global::ECharPositionState?(unifiedStateComponent.PositionState) : null;
		if (echarPositionState != null)
		{
			switch (echarPositionState.GetValueOrDefault())
			{
			case global::ECharPositionState.Ground:
			{
				APawn actor = this.ActorComp.Actor;
				FVectorDouble worldDirection = inputDirect;
				CharacterAnimationComponent animComp = this.AnimComp;
				actor.D_AddMovementInput(worldDirection, (animComp != null && animComp.Valid) ? this.AnimComp.GetWalkRunMix() : 1f, false);
				return;
			}
			case global::ECharPositionState.Climb:
				break;
			case global::ECharPositionState.Air:
				this.ActorComp.Actor.D_AddMovementInput(inputDirect, 1f, false);
				return;
			case global::ECharPositionState.Water:
				this.ActorComp.Actor.D_AddMovementInput(inputDirect, 1f, false);
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x060196AD RID: 104109 RVA: 0x00757017 File Offset: 0x00755217
	protected void UpdateInputOrder()
	{
		if (!base.CanResponseInput())
		{
			return;
		}
		this.PlayerMovementInput(this.ActorComp.InputDirect);
	}

	// Token: 0x060196AE RID: 104110 RVA: 0x00757034 File Offset: 0x00755234
	public void SmoothCharacterRotationByValue(float pitch, float yaw, float roll, float speed, float deltaTimeSeconds, string context = "Movement.SmoothCharacterRotationByValue")
	{
		if (base.LockedRotation)
		{
			return;
		}
		this.TmpRotator.Pitch = pitch;
		this.TmpRotator.Yaw = yaw;
		this.TmpRotator.Roll = roll;
		global::Rotator actorRotationProxy = this.ActorComp.ActorRotationProxy;
		if (this.TmpRotator.Equals(actorRotationProxy, 0.0001f))
		{
			return;
		}
		if (base.IsStandardGravity)
		{
			Singleton<MathUtils>.Instance.RotatorInterpConstantTo(actorRotationProxy, this.TmpRotator, deltaTimeSeconds, speed, this.TmpRotator);
		}
		else
		{
			Singleton<GravityUtils>.Instance.RotatorInterpConstantToForActor(this.ActorComp, actorRotationProxy, this.TmpRotator, deltaTimeSeconds, speed, this.TmpRotator);
		}
		this.ActorComp.SetActorRotationWithPriority(this.TmpRotator.ToUeRotator(), context, ESetRotationPriority.Movement, false, false);
	}

	// Token: 0x060196AF RID: 104111 RVA: 0x007570F0 File Offset: 0x007552F0
	public int SetAddMoveSpeed(FVectorDouble speed, int? handler = null)
	{
		FRotator actorRotation = this.ActorComp.ActorRotation;
		FVector fvector = speed;
		FVector fvector2 = actorRotation.RotateVector(fvector);
		FVectorDouble value = fvector2;
		return base.SetAddMoveWorld(new FVectorDouble?(value), -1f, null, handler, null, global::EVelocityCurveType.None, 0f, 1f);
	}

	// Token: 0x060196B0 RID: 104112 RVA: 0x0075714C File Offset: 0x0075534C
	public void SetAddMoveSpeedWithMesh(USkeletalMeshComponent mesh, FVectorDouble speed)
	{
		if (mesh == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.WCL, "[CharacterMoveComponent.SetAddMoveSpeedWithMesh] 叠加位移失败，mesh为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int? handler = new int?(this.VelocityAdditionMapByMesh.ContainsKey(mesh) ? this.VelocityAdditionMapByMesh[mesh] : 0);
		FRotator actorRotation = this.ActorComp.ActorRotation;
		FVector fvector = speed;
		FVector fvector2 = actorRotation.RotateVector(fvector);
		FVectorDouble value = fvector2;
		handler = new int?(base.SetAddMoveWorld(new FVectorDouble?(value), -1f, null, handler, null, global::EVelocityCurveType.None, 0f, 1f));
		if (handler != null)
		{
			this.VelocityAdditionMapByMesh[mesh] = handler.Value;
		}
	}

	// Token: 0x060196B1 RID: 104113 RVA: 0x00757210 File Offset: 0x00755410
	[NullableContext(2)]
	public int SetAddMove(FVectorDouble speed, float timeLength, UCurveFloat curve = null, int? handler = null, global::EVelocityCurveType? velocityCurveType = null, float? velocityCurveMin = null, float? velocityCurveMax = null)
	{
		FRotator actorRotation = this.ActorComp.ActorRotation;
		FVector fvector = speed;
		FVector fvector2 = actorRotation.RotateVector(fvector);
		FVectorDouble value = fvector2;
		return base.SetAddMoveWorld(new FVectorDouble?(value), timeLength, curve, handler, null, velocityCurveType.GetValueOrDefault(), velocityCurveMin.GetValueOrDefault(), velocityCurveMax.GetValueOrDefault(1f));
	}

	// Token: 0x060196B2 RID: 104114 RVA: 0x00757278 File Offset: 0x00755478
	public override void SetAddMoveWithMesh(UMeshComponent mesh, FVectorDouble speed, float timeLength, [Nullable(2)] UCurveFloat curve = null)
	{
		if (mesh == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.WCL, "[CharacterMoveComponent.SetAddMoveWithMesh] 叠加位移失败，mesh为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int? handler = new int?(this.VelocityAdditionMapByMesh.ContainsKey(mesh) ? this.VelocityAdditionMapByMesh[mesh] : 0);
		FRotator actorRotation = this.ActorComp.ActorRotation;
		FVector fvector = speed;
		FVector fvector2 = actorRotation.RotateVector(fvector);
		FVectorDouble value = fvector2;
		handler = new int?(base.SetAddMoveWorld(new FVectorDouble?(value), timeLength, curve, handler, null, global::EVelocityCurveType.None, 0f, 1f));
		if (handler != null)
		{
			this.VelocityAdditionMapByMesh[mesh] = handler.Value;
		}
	}

	// Token: 0x060196B3 RID: 104115 RVA: 0x0075733C File Offset: 0x0075553C
	public void SetGravityScale(float scaleUp, float scaleDown, float scaleTop, float velocityTop, float duration, bool forceVelocityZero, Entity attacker)
	{
		if (Math.Abs(scaleUp - 1f) < 0.0001f && Math.Abs(scaleDown - 1f) < 0.0001f && Math.Abs(scaleTop - 1f) < 0.0001f)
		{
			return;
		}
		if (duration <= 0f)
		{
			return;
		}
		this.CurrentGravityScale.ScaleUp = scaleUp;
		this.CurrentGravityScale.ScaleDown = scaleDown;
		this.CurrentGravityScale.ScaleTop = scaleTop;
		this.CurrentGravityScale.VelocityTop = velocityTop;
		this.CurrentGravityScale.Duration = duration;
		this.CurrentGravityScale.ElapsedTime = 0f;
		this.CurrentGravityScale.ForceVelocityZero = forceVelocityZero;
		this.CurrentGravityScale.Enable = true;
	}

	// Token: 0x060196B4 RID: 104116 RVA: 0x007573F4 File Offset: 0x007555F4
	public FVector GetLastUpdateVelocity()
	{
		return this.CharacterMovement.GetLastUpdateVelocity();
	}

	// Token: 0x17002247 RID: 8775
	// (get) Token: 0x060196B5 RID: 104117 RVA: 0x00757401 File Offset: 0x00755601
	public float CharacterWeight
	{
		get
		{
			return (float)((this.CreatureProperty != null) ? this.CreatureProperty.重量 : 0);
		}
	}

	// Token: 0x17002248 RID: 8776
	// (get) Token: 0x060196B6 RID: 104118 RVA: 0x00757420 File Offset: 0x00755620
	public bool HasSwimmingBlock
	{
		get
		{
			return this.CharacterMovement.CustomMovementMode == 1 && this.CharacterMovement.Kuro_GetBlockDirectWhenMove().SizeSquared() > 0f;
		}
	}

	// Token: 0x060196B7 RID: 104119 RVA: 0x00757457 File Offset: 0x00755657
	protected bool UpdateSkillRotation()
	{
		return !(!this.SkillComp) && (this.SkillComp.Active && this.SkillComp.UpdateAllSkillRotator(this.DeltaTimeSeconds));
	}

	// Token: 0x060196B8 RID: 104120 RVA: 0x0075748C File Offset: 0x0075568C
	protected void UpdateFacing()
	{
		if (!base.CanUpdateMovingRotation())
		{
			this.UpdateSkillRotation();
			return;
		}
		CharacterActionComponent component = base.Entity.GetComponent<CharacterActionComponent>();
		if (component != null && component.GetSitDownState())
		{
			return;
		}
		if (this.ActorComp.OverrideTurnSpeed.GetValueOrDefault() != 0f)
		{
			base.SmoothCharacterRotation(this.ActorComp.InputRotatorProxy, this.ActorComp.OverrideTurnSpeed.Value, this.DeltaTimeSeconds, false, "Movement.UpdateFacing", true);
			this.ActorComp.SetOverrideTurnSpeed(null);
			return;
		}
		if (this.UpdateSkillRotation())
		{
			return;
		}
		if (!this.IsInputDrivenCharacter)
		{
			return;
		}
		if (this.AnimComp.BattleIdleEndTime > 0)
		{
			return;
		}
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		if (unifiedStateComponent != null && unifiedStateComponent.Valid)
		{
			global::ECharPositionState positionState = unifiedStateComponent.PositionState;
			if (!this.ContainsTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中.全身动作"]))
			{
				if (this.ActorComp.UseControllerRotation)
				{
					base.UpdateUsingControllerRotation();
					return;
				}
				if (positionState == global::ECharPositionState.Ground)
				{
					base.UpdateGroundedRotation();
					return;
				}
				if (positionState != global::ECharPositionState.Air)
				{
					if (positionState != global::ECharPositionState.Floating)
					{
						return;
					}
					base.UpdateGroundedRotation();
					return;
				}
				else
				{
					if (unifiedStateComponent.MoveState == global::ECharMoveState.WalkOnAir)
					{
						base.UpdateGroundedRotation();
						return;
					}
					base.UpdateInAirRotation();
					return;
				}
			}
		}
		else
		{
			base.UpdateGroundedRotation();
		}
	}

	// Token: 0x060196B9 RID: 104121 RVA: 0x007575BA File Offset: 0x007557BA
	protected override float SpeedScaled(float speed)
	{
		if (this.TimeScaleComp == null)
		{
			return speed;
		}
		return speed * this.TimeScaleComp.CurrentTimeScale * this.ActorComp.TimeDilation;
	}

	// Token: 0x060196BA RID: 104122 RVA: 0x007575DF File Offset: 0x007557DF
	public override bool CanMove()
	{
		return base.CanMove() && !this.ContainsTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.被击硬直时间"]);
	}

	// Token: 0x060196BB RID: 104123 RVA: 0x00757604 File Offset: 0x00755804
	protected void OnSpeedRatioAttributeChanged(EAttributeType attribute, float newValue, float oldValue)
	{
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		global::ECharMoveState? newMoveState = (unifiedStateComponent != null) ? new global::ECharMoveState?(unifiedStateComponent.MoveState) : null;
		CharacterMoveComponent component = base.Entity.GetComponent<CharacterMoveComponent>();
		if (component != null && component.Valid)
		{
			component.ResetMaxSpeed(newMoveState);
		}
	}

	// Token: 0x060196BC RID: 104124 RVA: 0x00757650 File Offset: 0x00755850
	protected void OnResponseInputTagsChanged(int tagId, bool tagExists)
	{
		if (tagExists)
		{
			if (this.CannotResponseInputCount == 0)
			{
				this.HasMoveInput = false;
				CharacterFloatingComponent floatingComp = this.FloatingComp;
				if (floatingComp != null && floatingComp.Valid)
				{
					this.FloatingComp.HasFloatingMoveInput = false;
				}
			}
			this.CannotResponseInputCount++;
			return;
		}
		this.CannotResponseInputCount--;
	}

	// Token: 0x060196BD RID: 104125 RVA: 0x007576AC File Offset: 0x007558AC
	[NullableContext(2)]
	public void SetChain(float length, global::Vector centerLocation = null)
	{
		if (length < 0f)
		{
			this.ConfigChainLengthSquared = -1.0;
		}
		else
		{
			this.ConfigChainLengthSquared = (double)(length * length);
		}
		if (centerLocation != null)
		{
			this.ChainCenter.FromUeVector(centerLocation);
			return;
		}
		this.ChainCenter.FromUeVector(this.ActorComp.GetInitLocation());
	}

	// Token: 0x060196BE RID: 104126 RVA: 0x00757704 File Offset: 0x00755904
	public void UpdateMoveChain()
	{
		if (this.ConfigChainLengthSquared < 0.0)
		{
			return;
		}
		this.CurrentChainLengthSquared = Math.Max(this.CurrentChainLengthSquared, this.ConfigChainLengthSquared);
		this.ChainCenter.Subtraction(this.ActorComp.ActorLocationProxy, CharacterMoveComponent.TempVelocity);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, CharacterMoveComponent.TempVelocity);
		double num = CharacterMoveComponent.TempVelocity.SizeSquared();
		if (num > this.CurrentChainLengthSquared)
		{
			CharacterMoveComponent.TempVelocity.MultiplyEqual((double)(((float)Math.Sqrt(num) - (float)Math.Sqrt(this.CurrentChainLengthSquared)) / (float)Math.Sqrt(num)));
			base.MoveCharacter(CharacterMoveComponent.TempVelocity, this.DeltaTimeSeconds, "");
			return;
		}
		if (num > this.ConfigChainLengthSquared)
		{
			this.CurrentChainLengthSquared = num;
		}
	}

	// Token: 0x060196BF RID: 104127 RVA: 0x007577D0 File Offset: 0x007559D0
	public void PlayerMotionRequest(MotionType type)
	{
		PlayerMotionRequest playerMotionRequest = Aki.Protocol.PlayerMotionRequest.Create();
		playerMotionRequest.Motion = type;
		Singleton<Net>.Instance.Call<PlayerMotionResponse>(ERequestMessageId.PlayerMotionRequest, playerMotionRequest, null, 0);
	}

	// Token: 0x060196C0 RID: 104128 RVA: 0x007577FC File Offset: 0x007559FC
	private bool UpdateInAreaWhirlpool()
	{
		int needTagId = this.WhirlpoolPoint.GetNeedTagId();
		if (needTagId != 0)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null || !tagComponent.HasTag(needTagId))
			{
				return false;
			}
		}
		float num = Singleton<MathUtils>.Instance.Clamp(this.WhirlpoolPoint.GetAlpha(), 0f, 1f);
		global::Vector velocityAdditionDestination = BaseMoveComponent.VelocityAdditionDestination;
		global::Vector.Lerp(this.WhirlpoolPoint.BeginLocation, this.WhirlpoolPoint.ToLocation, (double)num, velocityAdditionDestination);
		this.ActorComp.SetActorLocation(velocityAdditionDestination.ToUeVector(false), "移动.被吸引", true);
		return true;
	}

	// Token: 0x060196C1 RID: 104129 RVA: 0x00757890 File Offset: 0x00755A90
	public void BeginWhirlpool(int id, float moveTime, global::Vector location, global::Vector beginLocation, float duration = -1f, global::EVelocityCurveType curveType = global::EVelocityCurveType.None, bool cancelByHit = true, int needTagId = 0)
	{
		if (needTagId != 0)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null || !tagComponent.HasTag(needTagId))
			{
				return;
			}
		}
		this.CharacterMovement.GravityScale = 0f;
		base.Entity.GetComponent<CharacterUnifiedStateComponent>().SetMoveState(global::ECharMoveState.KnockUp);
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Falling,
				Context = "[CharacterMoveComponent.BeginWhirlpool]"
			});
		}
		CharacterActorComponent actorComp2 = this.ActorComp;
		bool flag;
		if (actorComp2 == null)
		{
			flag = false;
		}
		else
		{
			UCapsuleComponent capsuleComponent = actorComp2.Actor.CapsuleComponent;
			flag = ((capsuleComponent != null) ? new bool?(capsuleComponent.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			Singleton<CollisionUtils>.Instance.SetCollisionResponseToPawn(this.ActorComp.Actor.CapsuleComponent, EPawnChannel.All, ECollisionResponse.ECR_Ignore);
		}
		this.SetForceFallingSpeed(global::Vector.ZeroVector, GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.击飞"]);
		this.WhirlpoolPoint.Begin(id, moveTime, location, beginLocation, duration, curveType, cancelByHit, needTagId);
		base.Entity.GetComponent<CharacterHitComponent>().ActiveStiff(-1f);
	}

	// Token: 0x060196C2 RID: 104130 RVA: 0x007579A4 File Offset: 0x00755BA4
	public void EndWhirlpool(string reason)
	{
		this.CharacterMovement.GravityScale = 2f;
		this.WhirlpoolPoint.OnEnd();
		CharacterActorComponent actorComp = this.ActorComp;
		bool flag;
		if (actorComp == null)
		{
			flag = false;
		}
		else
		{
			UCapsuleComponent capsuleComponent = actorComp.Actor.CapsuleComponent;
			flag = ((capsuleComponent != null) ? new bool?(capsuleComponent.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			Singleton<CollisionUtils>.Instance.SetCollisionResponseToPawn(this.ActorComp.Actor.CapsuleComponent, EPawnChannel.All, ECollisionResponse.ECR_Block);
		}
		if (this.UnifiedStateComponent != null && this.UnifiedStateComponent.PositionState != global::ECharPositionState.Air)
		{
			base.Entity.GetComponent<CharacterHitComponent>().DeActiveStiff("EndWhirlpool");
		}
	}

	// Token: 0x060196C3 RID: 104131 RVA: 0x00757A4D File Offset: 0x00755C4D
	public bool GetWhirlpoolEnable()
	{
		return this.WhirlpoolPoint.GetEnable();
	}

	// Token: 0x060196C4 RID: 104132 RVA: 0x00757A5A File Offset: 0x00755C5A
	public bool GetWhirlpoolCancelByHit()
	{
		return this.WhirlpoolPoint.GetCancelByHit();
	}

	// Token: 0x060196C5 RID: 104133 RVA: 0x00757A67 File Offset: 0x00755C67
	public int GetWhirlpoolId()
	{
		return this.WhirlpoolPoint.GetId();
	}

	// Token: 0x060196C6 RID: 104134 RVA: 0x00757A74 File Offset: 0x00755C74
	public bool CompareWhirlpoolPriority(float moveTime)
	{
		return moveTime < this.WhirlpoolPoint.GetMoveTime();
	}

	// Token: 0x060196C7 RID: 104135 RVA: 0x00757A84 File Offset: 0x00755C84
	public void UpdateWhirlpoolLocation(global::Vector location)
	{
		this.WhirlpoolPoint.UpdateLocation(location);
	}

	// Token: 0x060196C8 RID: 104136 RVA: 0x00757A92 File Offset: 0x00755C92
	protected void InitStepUpParams()
	{
		if (this.CharacterMovement == null)
		{
			return;
		}
		this.InitMaxStepHeight = this.CharacterMovement.MaxStepHeight;
		this.InitStepUpPercent = this.CharacterMovement.StepUpDeltaPrecent;
		this.InitStepUpStandardSpeed = this.CharacterMovement.StepUpStandardSpeed;
	}

	// Token: 0x060196C9 RID: 104137 RVA: 0x00757AD0 File Offset: 0x00755CD0
	public void SetStepUpParamsRecord(bool reset)
	{
		if (reset)
		{
			this.StepUpOffCount--;
			if (this.StepUpOffCount == 0)
			{
				this.ResetStepUpParams();
				return;
			}
		}
		else
		{
			this.StepUpOffCount++;
			if (this.StepUpOffCount == 1)
			{
				this.SetStepUpParams();
			}
		}
	}

	// Token: 0x060196CA RID: 104138 RVA: 0x00757B0F File Offset: 0x00755D0F
	protected void SetStepUpParams()
	{
		if (this.CharacterMovement == null)
		{
			return;
		}
		this.CharacterMovement.StepUpDeltaPrecent = 1f;
		this.CharacterMovement.StepUpStandardSpeed = 1f;
	}

	// Token: 0x060196CB RID: 104139 RVA: 0x00757B3A File Offset: 0x00755D3A
	protected void ResetStepUpParams()
	{
		if (this.CharacterMovement == null)
		{
			return;
		}
		this.CharacterMovement.StepUpDeltaPrecent = this.InitStepUpPercent;
		this.CharacterMovement.StepUpStandardSpeed = this.InitStepUpStandardSpeed;
	}

	// Token: 0x060196CC RID: 104140 RVA: 0x00757B67 File Offset: 0x00755D67
	public void SetStepHeight(float value)
	{
		if (this.CharacterMovement == null)
		{
			return;
		}
		this.CharacterMovement.MaxStepHeight = value;
	}

	// Token: 0x060196CD RID: 104141 RVA: 0x00757B7E File Offset: 0x00755D7E
	public void ResetStepHeight()
	{
		if (this.CharacterMovement == null)
		{
			return;
		}
		this.CharacterMovement.MaxStepHeight = this.InitMaxStepHeight;
	}

	// Token: 0x060196CE RID: 104142 RVA: 0x00757B9A File Offset: 0x00755D9A
	public void SetWalkableFloorAngle(float value)
	{
		if (this.CharacterMovement == null)
		{
			return;
		}
		this.CharacterMovement.SetWalkableFloorAngle(value);
	}

	// Token: 0x060196CF RID: 104143 RVA: 0x00757BB1 File Offset: 0x00755DB1
	public void ResetWalkableFloorAngle()
	{
		if (this.CharacterMovement == null)
		{
			return;
		}
		this.CharacterMovement.SetWalkableFloorAngle(this.MovementData.WalkableFloorAngle);
	}

	// Token: 0x060196D0 RID: 104144 RVA: 0x00757BD2 File Offset: 0x00755DD2
	public void SetKuroPlanarPhysWalking(bool enable)
	{
		this.IsKuroPlanarPhysWalkingEnableInternal = enable;
		this.CharacterMovement.SetKuroPlanarPhysWalking(enable);
	}

	// Token: 0x060196D1 RID: 104145 RVA: 0x00757BE7 File Offset: 0x00755DE7
	public void ResetPlanarPhysWalking()
	{
		this.CharacterMovement.bKuroPlanarNeedFindFloor = true;
	}

	// Token: 0x060196D2 RID: 104146 RVA: 0x00757BF8 File Offset: 0x00755DF8
	public void TryJumpInFreeRunning()
	{
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		if (unifiedStateComponent != null && unifiedStateComponent.PositionState == global::ECharPositionState.Ground)
		{
			this.OnJump();
			this.PlayerMotionRequest(MotionType.MotionJump);
			return;
		}
		BaseUnifiedStateComponent unifiedStateComponent2 = this.UnifiedStateComponent;
		if (unifiedStateComponent2 != null && unifiedStateComponent2.PositionState == global::ECharPositionState.Ski)
		{
			this.JumpPressInSki();
		}
	}

	// Token: 0x060196D3 RID: 104147 RVA: 0x00757C48 File Offset: 0x00755E48
	public bool IsOnGroundOrOnWater()
	{
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		return (unifiedStateComponent != null && unifiedStateComponent.PositionState == global::ECharPositionState.Ground) || (this.CharacterMovement.MovementMode == EMovementMode.MOVE_Custom && this.CharacterMovement.CustomMovementMode == 5);
	}

	// Token: 0x060196D4 RID: 104148 RVA: 0x00757C98 File Offset: 0x00755E98
	[Conditional("DEBUG")]
	private void UpdateKuroAsyncRootMotion()
	{
		bool flag = this.IsEnableAsyncRootMotion();
		if (this.IsKuroAsyncRootMotionEnable != flag)
		{
			this.SetKuroAsyncRootMotion(flag);
		}
	}

	// Token: 0x060196D5 RID: 104149 RVA: 0x00757CBC File Offset: 0x00755EBC
	public void SetKuroAsyncRootMotion(bool enable)
	{
		this.IsKuroAsyncRootMotionEnable = enable;
		this.CharacterMovement.SetKuroAsyncRootMotion(enable);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Movement;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "设置Kuro异步RootMotion";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("enable", enable);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060196D6 RID: 104150 RVA: 0x00757D08 File Offset: 0x00755F08
	private bool CheckPerformanceOptimizationCondition()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		if (instanceId != this.PerfConditionCachedInstanceId)
		{
			this.PerfConditionCachedInstanceId = instanceId;
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			int? num = (config != null) ? new int?(config.GetValueOrDefault().InstSubType) : null;
			this.PerfConditionCachedSubType = ((num != null) ? new EDungeonSubType?((EDungeonSubType)num.GetValueOrDefault()) : null);
		}
		return (this.PerfConditionCachedSubType.GetValueOrDefault() == EDungeonSubType.DangoAbyss && ModelBase<DangoAbyssModel>.Instance.IsPlanarDungeon()) || this.PerfConditionCachedSubType.GetValueOrDefault() == EDungeonSubType.PhantomArena;
	}

	// Token: 0x060196D7 RID: 104151 RVA: 0x00757DBC File Offset: 0x00755FBC
	private bool IsEnablePlanarPhysWalking()
	{
		return this.CheckPerformanceOptimizationCondition();
	}

	// Token: 0x060196D8 RID: 104152 RVA: 0x00757DC9 File Offset: 0x00755FC9
	private bool IsEnableAsyncRootMotion()
	{
		return CharacterMoveComponent.EnableKuroAsyncRootMotion && this.CheckPerformanceOptimizationCondition();
	}

	// Token: 0x060196D9 RID: 104153 RVA: 0x00757DDF File Offset: 0x00755FDF
	public void SetMovementData(SMovementSetting_State movementData, bool refresh = false)
	{
		this.MovementData = movementData;
		UCharacterMovementComponent characterMovement = this.CharacterMovement;
		if (characterMovement != null)
		{
			characterMovement.SetWalkableFloorAngle(this.MovementData.WalkableFloorAngle);
		}
		if (refresh)
		{
			base.OnPositionStateChange(global::ECharPositionState.Ground, global::ECharPositionState.Ground);
		}
	}

	// Token: 0x060196DA RID: 104154 RVA: 0x00757E10 File Offset: 0x00756010
	private void InitInputMoveLimit()
	{
		CharacterAnimationComponent animComp = this.AnimComp;
		if (UKuroStaticLibrary.IsObjectClassByName((animComp != null) ? animComp.MainAnimInstance : null, Singleton<CharacterNameDefines>.Instance.ABP_BASERUNANIMAL))
		{
			this.MaxMoveDegree = this.MovementData.CustomSetting00.Standing.ControllerRotationSpeedSetting.最大角度差;
		}
	}

	// Token: 0x060196DB RID: 104155 RVA: 0x00757E60 File Offset: 0x00756060
	private void InitMovementData()
	{
		this.DefaultMovementData = DataTableUtil.GetDataTableRow<SMovementSetting_State>(this.ActorComp.Actor.DtBaseMovementSetting, Singleton<CharacterNameDefines>.Instance.NORMAL.ToString());
		this.MovementData = this.DefaultMovementData;
		List<SMovementSetting_State> dataTableAllRowFromTable = DataTableUtil.GetDataTableAllRowFromTable<SMovementSetting_State>(this.ActorComp.Actor.DtBaseMovementSetting);
		for (int i = 0; i < dataTableAllRowFromTable.Count; i++)
		{
			SMovementSetting_State smovementSetting_State = dataTableAllRowFromTable[i];
			if (!(smovementSetting_State.EnableTag.TagName == FName.NAME_None))
			{
				this.MovementDataMap[smovementSetting_State.EnableTag.TagId()] = smovementSetting_State;
				BaseTagComponent tagComponent = this.TagComponent;
				if (tagComponent != null && tagComponent.HasTag(smovementSetting_State.EnableTag.TagId()))
				{
					this.MovementData = smovementSetting_State;
				}
				BaseTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 != null)
				{
					tagComponent2.AddTagAddOrRemoveListener(smovementSetting_State.EnableTag.TagId(), new BaseTagComponent.TTagSwitchedCallback(this.OnMovementDataTagChanged), null);
				}
			}
		}
		UCharacterMovementComponent characterMovement = this.CharacterMovement;
		if (characterMovement == null)
		{
			return;
		}
		characterMovement.SetWalkableFloorAngle(this.MovementData.WalkableFloorAngle);
	}

	// Token: 0x060196DC RID: 104156 RVA: 0x00757F78 File Offset: 0x00756178
	private void UnInitMovementData()
	{
		foreach (KeyValuePair<int, SMovementSetting_State> keyValuePair in this.MovementDataMap)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null)
			{
				tagComponent.RemoveTagAddOrRemoveListener(keyValuePair.Key, new BaseTagComponent.TTagSwitchedCallback(this.OnMovementDataTagChanged));
			}
		}
		this.MovementDataMap.Clear();
	}

	// Token: 0x060196DD RID: 104157 RVA: 0x00757FF4 File Offset: 0x007561F4
	private void OnMovementDataTagChanged(int tagId, bool tagExist)
	{
		if (tagExist)
		{
			this.MovementData = (this.MovementDataMap.ContainsKey(tagId) ? this.MovementDataMap[tagId] : null);
		}
		else if (this.MovementData == (this.MovementDataMap.ContainsKey(tagId) ? this.MovementDataMap[tagId] : null))
		{
			this.MovementData = this.DefaultMovementData;
		}
		UCharacterMovementComponent characterMovement = this.CharacterMovement;
		if (characterMovement != null)
		{
			characterMovement.SetWalkableFloorAngle(this.MovementData.WalkableFloorAngle);
		}
		base.OnPositionStateChange(global::ECharPositionState.Ground, global::ECharPositionState.Ground);
	}

	// Token: 0x060196DE RID: 104158 RVA: 0x00758083 File Offset: 0x00756283
	public new static void CreateStaticDefaultValue()
	{
		BaseMoveComponent.CreateStaticDefaultValue();
		CharacterMoveComponent.EnableKuroAsyncRootMotionInternal = true;
	}

	// Token: 0x060196DF RID: 104159 RVA: 0x00758090 File Offset: 0x00756290
	public new static void ResetStaticDefaultValue()
	{
		BaseMoveComponent.ResetStaticDefaultValue();
		CharacterMoveComponent.EnableKuroAsyncRootMotionInternal = false;
		BaseMoveComponent.BaseMoveInheritCurveInternal = null;
	}

	// Token: 0x060196E0 RID: 104160 RVA: 0x007580A4 File Offset: 0x007562A4
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterMoveComponent characterMoveComponent = (CharacterMoveComponent)componentTemplate;
		if (base.CanResetComponentProperty("GlideComp"))
		{
			if (characterMoveComponent.GlideComp == null)
			{
				this.GlideComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterGlideComponent>(this.GlideComp), "GlideComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SwimComp"))
		{
			if (characterMoveComponent.SwimComp == null)
			{
				this.SwimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterSwimComponent>(this.SwimComp), "SwimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("WalkOnWaterComp"))
		{
			if (characterMoveComponent.WalkOnWaterComp == null)
			{
				this.WalkOnWaterComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterWalkOnWaterComponent>(this.WalkOnWaterComp), "WalkOnWaterComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FloatingComp"))
		{
			if (characterMoveComponent.FloatingComp == null)
			{
				this.FloatingComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterFloatingComponent>(this.FloatingComp), "FloatingComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ForceFallingSpeedCache"))
		{
			if (characterMoveComponent.ForceFallingSpeedCache == null)
			{
				this.ForceFallingSpeedCache = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ForceFallingSpeedCache>(this.ForceFallingSpeedCache), "ForceFallingSpeedCache"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillComp"))
		{
			if (characterMoveComponent.SkillComp == null)
			{
				this.SkillComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterSkillComponent>(this.SkillComp), "SkillComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LastGlidingControlTime"))
		{
			this.LastGlidingControlTime = characterMoveComponent.LastGlidingControlTime;
		}
		if (base.CanResetComponentProperty("AttributeComponent"))
		{
			if (characterMoveComponent.AttributeComponent == null)
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
			if (characterMoveComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DeathComponent"))
		{
			if (characterMoveComponent.DeathComponent == null)
			{
				this.DeathComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseDeathComponent>(this.DeathComponent), "DeathComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AirInertiaHandler"))
		{
			this.AirInertiaHandler = characterMoveComponent.AirInertiaHandler;
		}
		if (base.CanResetComponentProperty("CanResponseInputTasks") && characterMoveComponent.CanResponseInputTasks != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.CanResponseInputTasks), "CanResponseInputTasks"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("LastJumpTime"))
		{
			this.LastJumpTime = characterMoveComponent.LastJumpTime;
		}
		if (base.CanResetComponentProperty("TryGlideTime"))
		{
			this.TryGlideTime = characterMoveComponent.TryGlideTime;
		}
		if (base.CanResetComponentProperty("WhirlpoolPoint") && characterMoveComponent.WhirlpoolPoint != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<WhirlpoolPoint>(this.WhirlpoolPoint), "WhirlpoolPoint"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("IsKuroPlanarPhysWalkingEnableInternal"))
		{
			this.IsKuroPlanarPhysWalkingEnableInternal = characterMoveComponent.IsKuroPlanarPhysWalkingEnableInternal;
		}
		if (base.CanResetComponentProperty("IsKuroAsyncRootMotionEnable"))
		{
			this.IsKuroAsyncRootMotionEnable = characterMoveComponent.IsKuroAsyncRootMotionEnable;
		}
		if (base.CanResetComponentProperty("OverrideMaxFallingSpeed"))
		{
			this.OverrideMaxFallingSpeed = characterMoveComponent.OverrideMaxFallingSpeed;
		}
		if (base.CanResetComponentProperty("GroundedFrame"))
		{
			this.GroundedFrame = characterMoveComponent.GroundedFrame;
		}
		if (base.CanResetComponentProperty("SlideTrans"))
		{
			if (characterMoveComponent.SlideTrans == null)
			{
				this.SlideTrans = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Transform>(this.SlideTrans), "SlideTrans"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StepUpOffCount"))
		{
			this.StepUpOffCount = characterMoveComponent.StepUpOffCount;
		}
		if (base.CanResetComponentProperty("InitMaxStepHeight"))
		{
			this.InitMaxStepHeight = characterMoveComponent.InitMaxStepHeight;
		}
		if (base.CanResetComponentProperty("InitStepUpPercent"))
		{
			this.InitStepUpPercent = characterMoveComponent.InitStepUpPercent;
		}
		if (base.CanResetComponentProperty("InitStepUpStandardSpeed"))
		{
			this.InitStepUpStandardSpeed = characterMoveComponent.InitStepUpStandardSpeed;
		}
		if (base.CanResetComponentProperty("PerfConditionCachedInstanceId"))
		{
			this.PerfConditionCachedInstanceId = characterMoveComponent.PerfConditionCachedInstanceId;
		}
		if (base.CanResetComponentProperty("PerfConditionCachedSubType"))
		{
			this.PerfConditionCachedSubType = characterMoveComponent.PerfConditionCachedSubType;
		}
		return true;
	}

	// Token: 0x0400C919 RID: 51481
	private const int MIN_MOVE_SPEED = 20;

	// Token: 0x0400C91A RID: 51482
	private const float GLIDING_CONTROL_OFFSET = 0.3f;

	// Token: 0x0400C91B RID: 51483
	public const int GLIDING_HEIGHT_THREDHOLD = 250;

	// Token: 0x0400C91C RID: 51484
	private const int MAX_IN_WATER_SPEED = 800;

	// Token: 0x0400C91D RID: 51485
	public const int GLIDE_STRENGTH_THREADHOLD = 10;

	// Token: 0x0400C91E RID: 51486
	private const int SQUARE_MAX_INHERIT_SPEED = 1000000;

	// Token: 0x0400C91F RID: 51487
	[StaticVariableRuleIgnore]
	private static readonly int[] cannotResponseInputTag = new int[]
	{
		GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.被抓取"],
		GameplayTagDefine.EGameplayTagId["功能.功能制作.被击硬直时间"],
		GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"],
		GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.溺水"]
	};

	// Token: 0x0400C920 RID: 51488
	private const int JUMP_FRAME_COUNT = 3;

	// Token: 0x0400C921 RID: 51489
	private const int SLIDE_JUMP_LERP_TIME = 100;

	// Token: 0x0400C922 RID: 51490
	private const int SLIDE_JUMP_SPEED = 900;

	// Token: 0x0400C923 RID: 51491
	private const float OVER_VELOCITY_PERCENT = 1.01f;

	// Token: 0x0400C924 RID: 51492
	private const float BASE_MOVE_INHERIT_TIME = 1.5f;

	// Token: 0x0400C925 RID: 51493
	private const int TRY_GLIDE_TIME = 500;

	// Token: 0x0400C926 RID: 51494
	private const int MAX_WALK_FLOOR_ANGLE = 55;

	// Token: 0x0400C927 RID: 51495
	private const int DEFAULT_MAX_STEP_HEIGHT = 45;

	// Token: 0x0400C928 RID: 51496
	private const float DEFAULT_STEP_UP_PERCENT = 0.08f;

	// Token: 0x0400C929 RID: 51497
	private const int DEFAULT_STEP_UP_STANDARD_SPEED = 400;

	// Token: 0x0400C92A RID: 51498
	private static bool EnableKuroAsyncRootMotionInternal;

	// Token: 0x0400C92B RID: 51499
	[Nullable(2)]
	protected CharacterGlideComponent GlideComp;

	// Token: 0x0400C92C RID: 51500
	[Nullable(2)]
	protected CharacterSwimComponent SwimComp;

	// Token: 0x0400C92D RID: 51501
	[Nullable(2)]
	protected CharacterWalkOnWaterComponent WalkOnWaterComp;

	// Token: 0x0400C92E RID: 51502
	[Nullable(2)]
	protected CharacterFloatingComponent FloatingComp;

	// Token: 0x0400C92F RID: 51503
	[Nullable(2)]
	public ForceFallingSpeedCache ForceFallingSpeedCache;

	// Token: 0x0400C930 RID: 51504
	[Nullable(2)]
	protected CharacterSkillComponent SkillComp;

	// Token: 0x0400C931 RID: 51505
	protected double LastGlidingControlTime;

	// Token: 0x0400C932 RID: 51506
	[Nullable(2)]
	protected BaseAttributeComponent AttributeComponent;

	// Token: 0x0400C933 RID: 51507
	[Nullable(2)]
	protected BaseTagComponent TagComponent;

	// Token: 0x0400C934 RID: 51508
	[Nullable(2)]
	protected BaseDeathComponent DeathComponent;

	// Token: 0x0400C935 RID: 51509
	protected int AirInertiaHandler;

	// Token: 0x0400C936 RID: 51510
	protected readonly List<ITagTask> CanResponseInputTasks = new List<ITagTask>();

	// Token: 0x0400C937 RID: 51511
	public double LastJumpTime;

	// Token: 0x0400C938 RID: 51512
	protected double TryGlideTime;

	// Token: 0x0400C939 RID: 51513
	private readonly WhirlpoolPoint WhirlpoolPoint = new WhirlpoolPoint();

	// Token: 0x0400C93A RID: 51514
	private bool IsKuroPlanarPhysWalkingEnableInternal;

	// Token: 0x0400C93B RID: 51515
	private bool IsKuroAsyncRootMotionEnable;

	// Token: 0x0400C93C RID: 51516
	private float OverrideMaxFallingSpeed;

	// Token: 0x0400C93D RID: 51517
	protected int GroundedFrame;

	// Token: 0x0400C93E RID: 51518
	[StaticVariableRuleIgnore]
	protected static readonly global::Vector TempVelocity = global::Vector.Create();

	// Token: 0x0400C93F RID: 51519
	[Nullable(2)]
	protected global::Transform SlideTrans;

	// Token: 0x0400C940 RID: 51520
	private int StepUpOffCount;

	// Token: 0x0400C941 RID: 51521
	protected float InitMaxStepHeight = 45f;

	// Token: 0x0400C942 RID: 51522
	protected float InitStepUpPercent = 0.08f;

	// Token: 0x0400C943 RID: 51523
	protected float InitStepUpStandardSpeed = 400f;

	// Token: 0x0400C944 RID: 51524
	private int PerfConditionCachedInstanceId = int.MinValue;

	// Token: 0x0400C945 RID: 51525
	private EDungeonSubType? PerfConditionCachedSubType;
}
