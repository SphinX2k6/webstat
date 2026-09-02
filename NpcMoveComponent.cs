using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

// Token: 0x020030EB RID: 12523
[NullableContext(1)]
[Nullable(0)]
public class NpcMoveComponent : BaseMoveComponent, IStaticVariableResetter, IComponentDependency
{
	// Token: 0x06019E35 RID: 106037 RVA: 0x00791FD0 File Offset: 0x007901D0
	static NpcMoveComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(NpcMoveComponent.CreateStaticDefaultValue), new Action(NpcMoveComponent.ResetStaticDefaultValue));
	}

	// Token: 0x1700230E RID: 8974
	// (get) Token: 0x06019E36 RID: 106038 RVA: 0x00791FEF File Offset: 0x007901EF
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

	// Token: 0x1700230F RID: 8975
	// (get) Token: 0x06019E37 RID: 106039 RVA: 0x00792004 File Offset: 0x00790204
	// (set) Token: 0x06019E38 RID: 106040 RVA: 0x0079200C File Offset: 0x0079020C
	public bool IsTurning
	{
		get
		{
			return this.IsTurningInternal;
		}
		set
		{
			if (this.IsTurningInternal == value)
			{
				return;
			}
			this.IsTurningInternal = value;
			if (value)
			{
				Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.CharTurnBegin);
				return;
			}
			Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.CharTurnEnd);
		}
	}

	// Token: 0x06019E39 RID: 106041 RVA: 0x0079204C File Offset: 0x0079024C
	public override void SetMaxSpeed(float newSpeed)
	{
		float num = 10000f;
		if (num <= 0f)
		{
			num = 10000f;
		}
		num /= 10000f;
		float num2 = newSpeed * num;
		if (this.CharacterMovement.MovementMode == EMovementMode.MOVE_Flying)
		{
			this.CharacterMovement.MaxFlySpeed = num2;
			return;
		}
		this.CharacterMovement.MaxWalkSpeed = num2;
	}

	// Token: 0x06019E3A RID: 106042 RVA: 0x007920AA File Offset: 0x007902AA
	protected override bool OnClear()
	{
		base.OnClear();
		if (this.JumpDelayTimer != null)
		{
			TimerSystem.Instance.Remove(this.JumpDelayTimer);
		}
		MoveToLocationController moveController = base.MoveController;
		if (moveController != null)
		{
			moveController.Dispose();
		}
		return true;
	}

	// Token: 0x06019E3B RID: 106043 RVA: 0x007920DE File Offset: 0x007902DE
	protected override bool OnInit()
	{
		return base.OnInit();
	}

	// Token: 0x06019E3C RID: 106044 RVA: 0x007920E8 File Offset: 0x007902E8
	protected override bool OnStart()
	{
		this.AccelerationLerpCurve = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/Character/Role/Common/Data/Curves/CT_MoveFAcceleration.CT_MoveFAcceleration");
		if (this.AccelerationLerpCurve == null || !this.AccelerationLerpCurve.IsValid())
		{
			ModelBase<PreloadModelNew>.Instance.CommonAssetElement.PrintDebugInfo();
		}
		this.AccelerationChangeMoveState = new global::ECharMoveState?(global::ECharMoveState.Other);
		CharacterActorComponent component = base.Entity.GetComponent<CharacterActorComponent>();
		if (!component.Valid)
		{
			return false;
		}
		this.IsHidden = false;
		this.ActorComp = component;
		this.CharacterMovement = component.Actor.CharacterMovement;
		this.CharacterMovement.GravityScale = 2f;
		this.CharacterMovement.bRotationFollowBaseMovement = true;
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		this.UnifiedStateComponent = base.Entity.GetComponent<BaseUnifiedStateComponent>();
		this.CapsuleOffset = global::Vector.Create(0.0, 0.0, (double)(this.ActorComp.Radius - this.ActorComp.HalfHeight));
		this.InitCreatureProperty();
		this.MovementData = DataTableUtil.GetDataTableRow<SMovementSetting_State>(this.ActorComp.Actor.DtBaseMovementSetting, Singleton<CharacterNameDefines>.Instance.NORMAL.ToString());
		UCharacterMovementComponent characterMovement = this.CharacterMovement;
		if (characterMovement != null)
		{
			characterMovement.SetWalkableFloorAngle(this.MovementData.WalkableFloorAngle);
		}
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
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnDirectionStateChanged, new Action<ECharDirectionState, ECharDirectionState>(base.OnDirectionStateChange));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.OnPositionStateChanged));
		this.IsStopInternal = false;
		base.InitBaseState();
		base.InitTraceInfo();
		return true;
	}

	// Token: 0x06019E3D RID: 106045 RVA: 0x00792304 File Offset: 0x00790504
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(base.OnMoveStateChange));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnDirectionStateChanged, new Action<ECharDirectionState, ECharDirectionState>(base.OnDirectionStateChange));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.OnPositionStateChanged));
		foreach (ITagTask tagTask in this.CanResponseInputTasks)
		{
			tagTask.EndTask();
		}
		this.CanResponseInputTasks.Clear();
		this.IsHidden = false;
		return true;
	}

	// Token: 0x06019E3E RID: 106046 RVA: 0x007923D0 File Offset: 0x007905D0
	protected void OnPositionStateChanged(global::ECharPositionState oldPositionState, global::ECharPositionState newPositionState)
	{
		if (oldPositionState == global::ECharPositionState.Air)
		{
			this.IsFallingIntoWater = false;
			base.StopAddMove(this.AirInertiaHandler);
			this.AirInertiaHandler = 0;
		}
		switch (newPositionState)
		{
		case global::ECharPositionState.Ground:
		case global::ECharPositionState.Climb:
			break;
		case global::ECharPositionState.Air:
			if (this.HasBaseMovement && !this.ActorComp.Actor.BasedMovement.bRelativeRotation && this.DeltaBaseMovementSpeed != null)
			{
				this.AirInertiaHandler = base.SetAddMoveWorld(this.DeltaBaseMovementSpeed, 1.5f, BaseMoveComponent.BaseMoveInheritCurve, new int?(this.AirInertiaHandler), null, global::EVelocityCurveType.None, 0f, 1f);
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

	// Token: 0x06019E3F RID: 106047 RVA: 0x007924DC File Offset: 0x007906DC
	protected override void OnActivate()
	{
		base.OnMoveStateChange(global::ECharMoveState.Stand, global::ECharMoveState.Run);
		this.OnPositionStateChanged(global::ECharPositionState.Air, global::ECharPositionState.Ground);
		if (this.CharacterMovement.MovementMode != this.CharacterMovement.DefaultLandMovementMode)
		{
			bool flag = ModelBase<WorldModel>.Instance.CurEnvironmentInfo.GlobalCaveMode == EActorCavernMode.ActorCavernMode_Outside;
			if (base.Entity.IsEncloseSpace && flag)
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp != null)
				{
					actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_None,
						Context = "[NpcMoveComponent.OnActivate:人在山洞外,实体在山洞里的情况，将movementMode设成none防止掉落]"
					});
				}
			}
			else
			{
				CharacterActorComponent actorComp2 = this.ActorComp;
				if (actorComp2 != null)
				{
					actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = this.CharacterMovement.DefaultLandMovementMode,
						Context = "[NpcMoveComponent.OnActivate]"
					});
				}
			}
		}
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		bool flag2;
		if (component == null)
		{
			flag2 = (null != null);
		}
		else
		{
			CharacterMoveToPointConfig pbMoveToPointConfig = component.PbMoveToPointConfig;
			flag2 = (((pbMoveToPointConfig != null) ? pbMoveToPointConfig.TargetPos : null) != null);
		}
		if (flag2)
		{
			LevelGeneralNetworks.HandleRecvCharacterMoveToPoint(base.Entity, component.PbMoveToPointConfig);
		}
	}

	// Token: 0x06019E40 RID: 106048 RVA: 0x007925E0 File Offset: 0x007907E0
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		if (this.ActorComp == null)
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
			this.Speed = (float)this.ActorComp.ActorVelocityProxy.Size2D();
		}
		this.IsMoving = (this.Speed > 20f);
		if (this.ActorComp.IsMoveAutonomousProxy)
		{
			this.UpdateMovementInput(this.ActorComp.InputDirect);
			object obj;
			if (base.Entity.GetTickInterval() > 1)
			{
				CharacterAnimationComponent animComp = this.AnimComp;
				if (animComp != null && animComp.Valid)
				{
					obj = this.ActorComp.Owner.WasRecentlyRenderedOnScreen(0.2f);
					goto IL_130;
				}
			}
			obj = 0;
			IL_130:
			FTransformDouble? ftransformDouble = null;
			object obj2 = obj;
			if (obj2 != null)
			{
				ftransformDouble = new FTransformDouble?(this.AnimComp.GetMeshTransform());
			}
			bool flag = false;
			if (base.CanResponseInput())
			{
				base.SetInfoVar();
				float pitch = this.ActorComp.ActorRotationProxy.Pitch;
				this.UpdateFacing();
				flag |= (pitch != this.ActorComp.ActorRotationProxy.Pitch);
				base.CacheVar();
			}
			else
			{
				this.HasMoveInput = false;
			}
			if ((obj2 & flag) != null)
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

	// Token: 0x06019E41 RID: 106049 RVA: 0x00792800 File Offset: 0x00790A00
	protected override void InitCreatureProperty()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		this.CreatureProperty = component.GetEntityPropertyConfig();
		this.CharacterMovement.Mass = (float)this.CreatureProperty.重量;
		this.CharacterMovement.HitPriority = this.CreatureProperty.碰撞优先级;
		this.CharacterMovement.GoThroughPriority = this.CreatureProperty.穿透优先级;
	}

	// Token: 0x06019E42 RID: 106050 RVA: 0x00792868 File Offset: 0x00790A68
	public unsafe override void GetAndConsumeAddMove(float deltaSeconds, global::Vector outVector, global::Rotator outRotator)
	{
		outVector.Reset();
		outRotator.Reset();
		if (this.AddMoveOffset != null)
		{
			global::Vector tmpVector = this.TmpVector;
			FVectorDouble value = this.AddMoveOffset.Value;
			tmpVector.FromUeVector(value);
			outVector.AdditionEqual(this.TmpVector);
			this.AddMoveOffset = null;
		}
		if (!this.AddMoveRotation.IsNearlyZero())
		{
			outRotator.DeepCopy(this.AddMoveRotation);
			this.AddMoveRotation.Reset();
		}
		if (this.VelocityAdditionMap.Count == 0)
		{
			return;
		}
		BaseMoveComponent.VelocityAdditionTotal.Reset();
		foreach (KeyValuePair<int, VelocityAddition> keyValuePair in this.VelocityAdditionMap)
		{
			int key = keyValuePair.Key;
			VelocityAddition value2 = keyValuePair.Value;
			if (value2.Duration >= 0f && value2.ElapsedTime >= value2.Duration)
			{
				this.VelocityAdditionMap.Remove(key);
			}
			else if (value2.MovementMode > 0 && (int)this.CharacterMovement.CustomMovementMode != value2.MovementMode)
			{
				this.VelocityAdditionMap.Remove(key);
			}
			else
			{
				value2.ElapsedTime += this.DeltaTimeSeconds;
				global::Vector velocityVector = this.VelocityVector;
				FVectorDouble value = value2.Velocity.Value;
				velocityVector.FromUeVector(value);
				UCurveFloat curveFloat = value2.CurveFloat;
				if (curveFloat != null && curveFloat.IsValid())
				{
					this.VelocityVector.MultiplyEqual((double)value2.CurveFloat.GetFloatValue((value2.Duration > 0f) ? (value2.ElapsedTime / value2.Duration) : 1f));
				}
				if (value2.Duration > 0f && value2.ElapsedTime > value2.Duration)
				{
					float num = value2.ElapsedTime - value2.Duration;
					float num2 = (this.DeltaTimeSeconds - num) / this.DeltaTimeSeconds;
					this.VelocityVector.MultiplyEqual((double)num2);
				}
				BaseMoveComponent.VelocityAdditionTotal.AdditionEqual(this.VelocityVector);
			}
		}
		BaseMoveComponent.VelocityAdditionTotal.Multiply((double)deltaSeconds, BaseMoveComponent.VelocityAdditionDestination);
		if (BaseMoveComponent.VelocityAdditionDestination.ContainsNaN())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "VelocityAdditionDestination NaN";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("VelocityAdditionDestination", BaseMoveComponent.VelocityAdditionDestination);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VelocityAdditionTotal", BaseMoveComponent.VelocityAdditionTotal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("deltaTimeSeconds", deltaSeconds);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		outVector.AdditionEqual(BaseMoveComponent.VelocityAdditionDestination);
	}

	// Token: 0x06019E43 RID: 106051 RVA: 0x00792B44 File Offset: 0x00790D44
	protected void UpdateMovementInput(FVectorDouble inputDirect)
	{
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		global::ECharPositionState? echarPositionState = (unifiedStateComponent != null) ? new global::ECharPositionState?(unifiedStateComponent.PositionState) : null;
		if (echarPositionState != null)
		{
			global::ECharPositionState valueOrDefault = echarPositionState.GetValueOrDefault();
			if (valueOrDefault == global::ECharPositionState.Ground)
			{
				APawn actor = this.ActorComp.Actor;
				CharacterAnimationComponent animComp = this.AnimComp;
				actor.D_AddMovementInput(inputDirect, (animComp != null && animComp.Valid) ? this.AnimComp.GetWalkRunMix() : 1f, false);
				return;
			}
			if (valueOrDefault != global::ECharPositionState.Air)
			{
				return;
			}
			this.ActorComp.Actor.D_AddMovementInput(inputDirect, 1f, false);
		}
	}

	// Token: 0x06019E44 RID: 106052 RVA: 0x00792BDC File Offset: 0x00790DDC
	protected void UpdateFacing()
	{
		if (!base.CanUpdateMovingRotation())
		{
			return;
		}
		if (this.ActorComp.OverrideTurnSpeed.GetValueOrDefault() != 0f)
		{
			base.SmoothCharacterRotation(this.ActorComp.InputRotatorProxy, this.ActorComp.OverrideTurnSpeed.Value, this.DeltaTimeSeconds, false, "Movement.UpdateFacing", true);
			this.ActorComp.SetOverrideTurnSpeed(null);
			return;
		}
		base.UpdateGroundedRotation();
	}

	// Token: 0x06019E45 RID: 106053 RVA: 0x00792C52 File Offset: 0x00790E52
	public new static void CreateStaticDefaultValue()
	{
		BaseMoveComponent.CreateStaticDefaultValue();
	}

	// Token: 0x06019E46 RID: 106054 RVA: 0x00792C59 File Offset: 0x00790E59
	public new static void ResetStaticDefaultValue()
	{
		BaseMoveComponent.ResetStaticDefaultValue();
		BaseMoveComponent.BaseMoveInheritCurveInternal = null;
	}

	// Token: 0x06019E47 RID: 106055 RVA: 0x00792C68 File Offset: 0x00790E68
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		NpcMoveComponent npcMoveComponent = (NpcMoveComponent)componentTemplate;
		if (base.CanResetComponentProperty("CanResponseInputTasks") && npcMoveComponent.CanResponseInputTasks != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.CanResponseInputTasks), "CanResponseInputTasks"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CachedDeltaYaw"))
		{
			this.CachedDeltaYaw = npcMoveComponent.CachedDeltaYaw;
		}
		if (base.CanResetComponentProperty("IsTurningInternal"))
		{
			this.IsTurningInternal = npcMoveComponent.IsTurningInternal;
		}
		if (base.CanResetComponentProperty("AirInertiaHandler"))
		{
			this.AirInertiaHandler = npcMoveComponent.AirInertiaHandler;
		}
		return true;
	}

	// Token: 0x0400CF8F RID: 53135
	private const int MIN_MOVE_SPEED = 20;

	// Token: 0x0400CF90 RID: 53136
	private const int MAX_IN_WATER_SPEED = 800;

	// Token: 0x0400CF91 RID: 53137
	private const float BASE_MOVE_INHERIT_TIME = 1.5f;

	// Token: 0x0400CF92 RID: 53138
	private const int PER_TEN_THOUSAND = 10000;

	// Token: 0x0400CF93 RID: 53139
	private const string ACC_LERP_CURVE_PATH = "/Game/Aki/Character/Role/Common/Data/Curves/CT_MoveFAcceleration.CT_MoveFAcceleration";

	// Token: 0x0400CF94 RID: 53140
	private const string BASE_MOVE_INHERIT_CURVE_PATH = "/Game/Aki/Character/BaseCharacter/Curves/CURVE_HorizontalVelocity.CURVE_HorizontalVelocity";

	// Token: 0x0400CF95 RID: 53141
	protected readonly List<ITagTask> CanResponseInputTasks = new List<ITagTask>();

	// Token: 0x0400CF96 RID: 53142
	protected float CachedDeltaYaw;

	// Token: 0x0400CF97 RID: 53143
	protected bool IsTurningInternal;

	// Token: 0x0400CF98 RID: 53144
	protected int AirInertiaHandler;
}
