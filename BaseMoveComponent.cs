using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02003018 RID: 12312
[NullableContext(1)]
[Nullable(0)]
public class BaseMoveComponent : EntityComponent, IStaticVariableResetter
{
	// Token: 0x0601916E RID: 102766 RVA: 0x00721C41 File Offset: 0x0071FE41
	static BaseMoveComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BaseMoveComponent.CreateStaticDefaultValue), new Action(BaseMoveComponent.ResetStaticDefaultValue));
	}

	// Token: 0x170021CC RID: 8652
	// (get) Token: 0x0601916F RID: 102767 RVA: 0x00721C60 File Offset: 0x0071FE60
	[Nullable(2)]
	protected static UCurveFloat BaseMoveInheritCurve
	{
		[NullableContext(2)]
		get
		{
			if (BaseMoveComponent.BaseMoveInheritCurveInternal == null)
			{
				BaseMoveComponent.BaseMoveInheritCurveInternal = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UCurveFloat>("/Game/Aki/Character/BaseCharacter/Curves/CURVE_HorizontalVelocity.CURVE_HorizontalVelocity");
			}
			return BaseMoveComponent.BaseMoveInheritCurveInternal;
		}
	}

	// Token: 0x06019170 RID: 102768 RVA: 0x00721C84 File Offset: 0x0071FE84
	public global::Vector ClampOffsetByChain(global::Vector offset)
	{
		if (this.ConfigChainLengthSquared < 0.0)
		{
			return offset;
		}
		double num = Math.Sqrt(this.ConfigChainLengthSquared);
		global::Vector chainTempPredicted = this.ChainTempPredicted;
		this.ActorComp.ActorLocationProxy.Addition(offset, chainTempPredicted);
		global::Vector chainTempToCenter = this.ChainTempToCenter;
		this.ChainCenter.Subtraction(chainTempPredicted, chainTempToCenter);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, chainTempToCenter);
		double num2 = chainTempToCenter.SizeSquared();
		if (num2 > this.ConfigChainLengthSquared)
		{
			double num3 = Math.Sqrt(num2);
			double num4 = num3 - num;
			chainTempToCenter.MultiplyEqual(num4 / num3);
			offset.AdditionEqual(chainTempToCenter);
		}
		return offset;
	}

	// Token: 0x06019171 RID: 102769 RVA: 0x00721D24 File Offset: 0x0071FF24
	public void SetForceSpeed(IVector speed)
	{
		if (speed.ContainsNaN())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "SetForceSpeed Contains NaN";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("speed", speed);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.ForceSpeed.DeepCopy(speed);
		if (this.ActorComp != null)
		{
			this.ActorComp.SetActorVelocity(this.ForceSpeed);
			this.ActorComp.ResetCachedVelocityTime();
		}
	}

	// Token: 0x170021CD RID: 8653
	// (get) Token: 0x06019172 RID: 102770 RVA: 0x00721D8F File Offset: 0x0071FF8F
	public bool IsJump
	{
		get
		{
			return this.JumpFrameCount > 0;
		}
	}

	// Token: 0x170021CE RID: 8654
	// (get) Token: 0x06019173 RID: 102771 RVA: 0x00721D9A File Offset: 0x0071FF9A
	// (set) Token: 0x06019174 RID: 102772 RVA: 0x00721DA4 File Offset: 0x0071FFA4
	[Nullable(2)]
	public SMovementSetting CurrentMovementSettings
	{
		[NullableContext(2)]
		get
		{
			return this.CurrentMovementSettingsInternal;
		}
		[NullableContext(2)]
		protected set
		{
			this.CurrentMovementSettingsInternal = value;
			this.CurrentMovementRotationSetting.UpdateSettings(value.ControllerRotationSpeedSetting);
			if (this.CharacterMovement != null && value != null)
			{
				UCharacterMovementComponent characterMovement = this.CharacterMovement;
				FKuroMovementSetting fkuroMovementSetting = new FKuroMovementSetting(value.Acceleration, value.ControllerRotationSpeed, new FKuroMovementRotationSetting(value.ControllerRotationSpeedSetting.最大旋转速度, value.ControllerRotationSpeedSetting.最大角度差, value.ControllerRotationSpeedSetting.最小旋转速度, value.ControllerRotationSpeedSetting.最小角度差, (int)value.ControllerRotationSpeedSetting.渐变曲线.CurveType, value.ControllerRotationSpeedSetting.渐变曲线.N), value.FastSwimSpeed, value.GroundFriction, value.MovementCurve, value.NormalSwimSpeed, value.RotationRateCurve, value.RunSpeed, value.SprintSpeed, value.SwingAcceleration, value.SwingSpeed, value.WalkSpeed);
				characterMovement.SetKuroMovementSettings(fkuroMovementSetting);
			}
		}
	}

	// Token: 0x06019175 RID: 102773 RVA: 0x00721E91 File Offset: 0x00720091
	public void SetGravityDirectWithoutRotate(IVector v)
	{
		this.SetGravityDirectWithoutRotateByNumber(v.X, v.Y, v.Z);
	}

	// Token: 0x06019176 RID: 102774 RVA: 0x00721EAC File Offset: 0x007200AC
	public void SetGravityDirectWithoutRotateByNumber(double x, double y, double z)
	{
		this.TmpVector.X = x;
		this.TmpVector.Y = y;
		this.TmpVector.Z = z;
		if (!this.TmpVector.Normalize(9.99999993922529E-09))
		{
			return;
		}
		if (this.GravityDirectInternal.Equals(this.TmpVector, 9.999999747378752E-05))
		{
			return;
		}
		this.IsStandardGravityInternal = Singleton<MathUtils>.Instance.IsNearlyEqual(this.TmpVector.Z, -1.0, null);
		if (this.IsStandardGravityInternal)
		{
			this.GravityDirectInternal.Set(0.0, 0.0, -1.0);
		}
		else
		{
			this.GravityDirectInternal.DeepCopy(this.TmpVector);
		}
		this.GravityDirectInternal.UnaryNegation(this.GravityUpInternal);
		if (this.CharacterMovement != null)
		{
			this.CharacterMovement.Kuro_SetGravityDirect(this.GravityDirectInternal.ToUeVectorOld());
		}
		this.ActorComp.ResetGravityRelatedCachedTime();
		Singleton<EventSystem>.Instance.EmitWithTarget<global::Vector, bool>(base.Entity, EEventName.CharGravityDirectChanged, this.GravityDirect, this.IsStandardGravity);
		Singleton<EventSystem>.Instance.Emit<Entity, global::Vector, bool>(EEventName.AnyCharGravityDirectChanged, base.Entity, this.GravityDirect, this.IsStandardGravity);
	}

	// Token: 0x06019177 RID: 102775 RVA: 0x00722000 File Offset: 0x00720200
	public void SetGravityDirectByNumber(double x, double y, double z, bool clearGround = true, float overrideSmoothTime = -1f)
	{
		this.TmpVector.X = x;
		this.TmpVector.Y = y;
		this.TmpVector.Z = z;
		if (!this.TmpVector.Normalize(9.99999993922529E-09))
		{
			return;
		}
		if (this.GravityDirectInternal.Equals(this.TmpVector, 9.999999747378752E-05))
		{
			return;
		}
		float timeLength = (float)((overrideSmoothTime > 0f) ? ((double)overrideSmoothTime) : (Math.Acos(global::Vector.DotProduct(this.GravityDirectInternal, this.TmpVector)) / 3.141592653589793 * 500.0));
		Quat.FindBetween(this.GravityDirectInternal, this.TmpVector, this.TmpQuat);
		this.IsStandardGravityInternal = Singleton<MathUtils>.Instance.IsNearlyEqual(this.TmpVector.Z, -1.0, null);
		if (this.IsStandardGravityInternal)
		{
			this.GravityDirectInternal.Set(0.0, 0.0, -1.0);
		}
		else
		{
			this.GravityDirectInternal.DeepCopy(this.TmpVector);
		}
		this.GravityDirectInternal.UnaryNegation(this.GravityUpInternal);
		if (this.CharacterMovement != null)
		{
			this.CharacterMovement.Kuro_SetGravityDirect(this.GravityDirectInternal.ToUeVectorOld());
			if (clearGround)
			{
				BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
				if (unifiedStateComponent != null && unifiedStateComponent.PositionState == global::ECharPositionState.Ground)
				{
					CharacterActorComponent actorComp = this.ActorComp;
					if (actorComp != null)
					{
						actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
						{
							Mode = EMovementMode.MOVE_Falling,
							Context = "[BaseMoveComponent.SetGravityDirectByNumber]"
						});
					}
				}
			}
		}
		if (this.ActorComp.ActorUpProxy.DotProduct(this.TmpVector) > -0.9999)
		{
			this.TmpQuat.RotateVector(global::Vector.UpVectorProxy, this.TmpVector);
			this.TmpQuat.Multiply(this.ActorComp.ActorQuatProxy, this.TmpQuat2);
			this.TmpQuat2.Rotator(this.TmpRotator);
			if (this.AnimComp != null)
			{
				this.AnimComp.SetLocationAndRotatorWithModelBuffer(this.ActorComp.ActorLocationProxy.ToUeVector(false), this.TmpRotator.ToUeRotator(), timeLength, "SetGravity", ESetRotationPriority.Anim, true);
			}
			else
			{
				this.ActorComp.SetActorRotation(this.TmpRotator.ToUeRotator(), "SetGravity", false);
			}
			CharacterActorComponent actorComp2 = this.ActorComp;
			if (actorComp2 != null && actorComp2.IsRoleAndCtrlByMe)
			{
				CharacterInputComponent component = base.Entity.GetComponent<CharacterInputComponent>();
				if (component == null || !component.IsLocalInput)
				{
					this.TmpQuat.RotateVector(this.ActorComp.InputDirectProxy, this.TmpVector);
					this.ActorComp.SetInputDirect(this.TmpVector, true);
					this.TmpQuat.RotateVector(this.ActorComp.InputFacingProxy, this.TmpVector);
					this.ActorComp.SetInputFacing(this.TmpVector, true);
					goto IL_303;
				}
			}
			this.ActorComp.ClearInput(false, true);
		}
		else
		{
			this.ActorComp.ClearInput(false, true);
		}
		IL_303:
		this.ActorComp.ResetGravityRelatedCachedTime();
		Singleton<EventSystem>.Instance.EmitWithTarget<global::Vector, bool>(base.Entity, EEventName.CharGravityDirectChanged, this.GravityDirect, this.IsStandardGravity);
		Singleton<EventSystem>.Instance.Emit<Entity, global::Vector, bool>(EEventName.AnyCharGravityDirectChanged, base.Entity, this.GravityDirect, this.IsStandardGravity);
	}

	// Token: 0x06019178 RID: 102776 RVA: 0x0072235F File Offset: 0x0072055F
	public void SetGravityDirect(IVector v)
	{
		this.SetGravityDirectByNumber(v.X, v.Y, v.Z, true, -1f);
	}

	// Token: 0x06019179 RID: 102777 RVA: 0x0072237F File Offset: 0x0072057F
	public void SetGravityDirect(Aki.Protocol.Vector v)
	{
		this.SetGravityDirectByNumber((double)v.X, (double)v.Y, (double)v.Z, true, -1f);
	}

	// Token: 0x170021CF RID: 8655
	// (get) Token: 0x0601917A RID: 102778 RVA: 0x007223A2 File Offset: 0x007205A2
	public global::Vector GravityDirect
	{
		get
		{
			return this.GravityDirectInternal;
		}
	}

	// Token: 0x170021D0 RID: 8656
	// (get) Token: 0x0601917B RID: 102779 RVA: 0x007223AC File Offset: 0x007205AC
	public global::Vector GravityUp
	{
		get
		{
			if (this.GravityUpInternal.Equals(global::Vector.ZeroVectorProxy, 9.999999747378752E-05))
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.YZ, "GravityUp is zero", default(ReadOnlySpan<ValueTuple<string, object>>));
				return global::Vector.UpVectorProxy;
			}
			return this.GravityUpInternal;
		}
	}

	// Token: 0x170021D1 RID: 8657
	// (get) Token: 0x0601917C RID: 102780 RVA: 0x007223FB File Offset: 0x007205FB
	public bool IsStandardGravity
	{
		get
		{
			return this.IsStandardGravityInternal;
		}
	}

	// Token: 0x170021D2 RID: 8658
	// (get) Token: 0x0601917E RID: 102782 RVA: 0x00722413 File Offset: 0x00720613
	// (set) Token: 0x0601917D RID: 102781 RVA: 0x00722403 File Offset: 0x00720603
	public float AccelerationLerpTime
	{
		get
		{
			return this.DesireMaxAccelerationLerpTime;
		}
		set
		{
			this.DesireMaxAccelerationLerpTime = value;
			this.MaxAccelerationLerpTime = value;
		}
	}

	// Token: 0x0601917F RID: 102783 RVA: 0x0072241B File Offset: 0x0072061B
	public void SetFallingHorizontalMaxSpeed(float v)
	{
		this.FallingHorizontalMaxSpeed = v;
	}

	// Token: 0x06019180 RID: 102784 RVA: 0x00722424 File Offset: 0x00720624
	public void ClearFallingHorizontalMaxSpeed()
	{
		this.FallingHorizontalMaxSpeed = 700f;
	}

	// Token: 0x06019181 RID: 102785 RVA: 0x00722434 File Offset: 0x00720634
	protected override bool OnInit()
	{
		this.IsStandardGravityInternal = true;
		this.GravityDirectInternal.Set(0.0, 0.0, -1.0);
		this.GravityUpInternal.Set(0.0, 0.0, 1.0);
		return true;
	}

	// Token: 0x06019182 RID: 102786 RVA: 0x00722495 File Offset: 0x00720695
	protected override bool OnStart()
	{
		this.TimeScaleComp = base.Entity.GetComponent<PawnTimeScaleComponent>();
		return true;
	}

	// Token: 0x06019183 RID: 102787 RVA: 0x007224A9 File Offset: 0x007206A9
	public void SetUseDebugMovementSetting(bool newSelect)
	{
		this.UseDebugMovementSetting = newSelect;
	}

	// Token: 0x06019184 RID: 102788 RVA: 0x007224B2 File Offset: 0x007206B2
	public void SetDebugMovementSetting(SMovementSetting newSetting)
	{
		this.DebugMovementSetting = newSetting;
	}

	// Token: 0x06019185 RID: 102789 RVA: 0x007224BB File Offset: 0x007206BB
	public void ApplyDebugMovementSetting()
	{
		this.CurrentMovementSettings = this.DebugMovementSetting;
	}

	// Token: 0x06019186 RID: 102790 RVA: 0x007224CC File Offset: 0x007206CC
	protected void ResetMovementSettingByDirectionState(ECharDirectionState? newDirectionState)
	{
		if (newDirectionState != null)
		{
			switch (newDirectionState.GetValueOrDefault())
			{
			case ECharDirectionState.LockDirection:
				this.CurrentMovementSettings = this.MovementData.LockDirection.Standing;
				return;
			case ECharDirectionState.AimDirection:
				this.CurrentMovementSettings = this.MovementData.AimDirection.Standing;
				break;
			case ECharDirectionState.FaceDirection:
				this.CurrentMovementSettings = this.MovementData.FaceDirection.Standing;
				return;
			default:
				return;
			}
		}
	}

	// Token: 0x06019187 RID: 102791 RVA: 0x00722544 File Offset: 0x00720744
	protected void ResetMovementSetting(ECharDirectionState? newDirectionState)
	{
		if (this.MovementData == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "以下BP_{Character}没有在蓝图中配置Dt_BaseMovementSetting找对应的蓝图负责人处理";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Character", this.ActorComp.Actor.GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (this.UseDebugMovementSetting)
		{
			this.ApplyDebugMovementSetting();
			return;
		}
		this.ResetMovementSettingByDirectionState(newDirectionState);
	}

	// Token: 0x06019188 RID: 102792 RVA: 0x007225AC File Offset: 0x007207AC
	public void ResetMaxSpeed(global::ECharMoveState? newMoveState)
	{
		if (this.SpeedLockFrame > 0)
		{
			return;
		}
		float maxFixSpeed = this.ActorComp.Actor.TsCharacterDebugComponent.MaxFixSpeed;
		if (newMoveState != null)
		{
			global::ECharMoveState valueOrDefault = newMoveState.GetValueOrDefault();
			switch (valueOrDefault)
			{
			case global::ECharMoveState.Walk:
			{
				float num = maxFixSpeed;
				SMovementSetting currentMovementSettings = this.CurrentMovementSettings;
				this.SetMaxSpeed(num + ((currentMovementSettings != null) ? currentMovementSettings.WalkSpeed : 0f));
				return;
			}
			case global::ECharMoveState.WalkStop:
			case global::ECharMoveState.RunStop:
				break;
			case global::ECharMoveState.Run:
			{
				float num2 = maxFixSpeed;
				SMovementSetting currentMovementSettings2 = this.CurrentMovementSettings;
				this.SetMaxSpeed(num2 + ((currentMovementSettings2 != null) ? currentMovementSettings2.RunSpeed : 0f));
				return;
			}
			case global::ECharMoveState.Sprint:
			{
				float num3 = maxFixSpeed;
				SMovementSetting currentMovementSettings3 = this.CurrentMovementSettings;
				this.SetMaxSpeed(num3 + ((currentMovementSettings3 != null) ? currentMovementSettings3.SprintSpeed : 0f));
				return;
			}
			default:
				if (valueOrDefault == global::ECharMoveState.Swing)
				{
					float num4 = maxFixSpeed;
					SMovementSetting currentMovementSettings4 = this.CurrentMovementSettings;
					this.SetMaxSpeed(num4 + ((currentMovementSettings4 != null) ? currentMovementSettings4.SwingSpeed : 0f));
					return;
				}
				break;
			}
		}
		float num5 = maxFixSpeed;
		SMovementSetting currentMovementSettings5 = this.CurrentMovementSettings;
		this.SetMaxSpeed(num5 + ((currentMovementSettings5 != null) ? currentMovementSettings5.RunSpeed : 0f));
	}

	// Token: 0x06019189 RID: 102793 RVA: 0x007226AC File Offset: 0x007208AC
	public virtual void SetMaxSpeed(float newSpeed)
	{
		float num = 10000f;
		num /= 10000f;
		float num2 = newSpeed * num;
		if (this.CharacterMovement.MovementMode == EMovementMode.MOVE_Flying)
		{
			this.CharacterMovement.MaxFlySpeed = num2;
			return;
		}
		this.CharacterMovement.MaxWalkSpeed = num2;
	}

	// Token: 0x0601918A RID: 102794 RVA: 0x007226FC File Offset: 0x007208FC
	public void ResetCharacterMovementInfo(global::ECharMoveState? newMoveState)
	{
		this.CharacterMovement.MaxWalkSpeedCrouched = this.CharacterMovement.MaxWalkSpeed;
		if (newMoveState.GetValueOrDefault() == global::ECharMoveState.Swing)
		{
			UCharacterMovementComponent characterMovement = this.CharacterMovement;
			SMovementSetting currentMovementSettings = this.CurrentMovementSettings;
			characterMovement.MaxAcceleration = ((currentMovementSettings != null) ? currentMovementSettings.SwingAcceleration : 0f);
		}
		else
		{
			UCharacterMovementComponent characterMovement2 = this.CharacterMovement;
			SMovementSetting currentMovementSettings2 = this.CurrentMovementSettings;
			characterMovement2.MaxAcceleration = ((currentMovementSettings2 != null) ? currentMovementSettings2.Acceleration : 0f);
		}
		UCharacterMovementComponent characterMovement3 = this.CharacterMovement;
		SMovementSetting currentMovementSettings3 = this.CurrentMovementSettings;
		characterMovement3.GroundFriction = ((currentMovementSettings3 != null) ? currentMovementSettings3.GroundFriction : 0f);
	}

	// Token: 0x0601918B RID: 102795 RVA: 0x00722790 File Offset: 0x00720990
	protected void OnDirectionStateChange(ECharDirectionState oldDirectionState, ECharDirectionState newDirectionState)
	{
		this.ResetMovementSetting(new ECharDirectionState?(newDirectionState));
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		global::ECharMoveState? newMoveState = (unifiedStateComponent != null) ? new global::ECharMoveState?(unifiedStateComponent.MoveState) : null;
		this.ResetMaxSpeed(newMoveState);
		this.ResetCharacterMovementInfo(newMoveState);
	}

	// Token: 0x0601918C RID: 102796 RVA: 0x007227D8 File Offset: 0x007209D8
	protected void OnMoveStateChange(global::ECharMoveState oldMoveState, global::ECharMoveState newMoveState)
	{
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		ECharDirectionState? newDirectionState = (unifiedStateComponent != null) ? new ECharDirectionState?(unifiedStateComponent.DirectionState) : null;
		this.ResetMovementSetting(newDirectionState);
		this.ResetMaxSpeed(new global::ECharMoveState?(newMoveState));
		this.ResetCharacterMovementInfo(new global::ECharMoveState?(newMoveState));
	}

	// Token: 0x0601918D RID: 102797 RVA: 0x00722824 File Offset: 0x00720A24
	protected void OnPositionStateChange(global::ECharPositionState oldPositionState, global::ECharPositionState newPositionState)
	{
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		ECharDirectionState? newDirectionState = (unifiedStateComponent != null) ? new ECharDirectionState?(unifiedStateComponent.DirectionState) : null;
		this.ResetMovementSetting(newDirectionState);
		BaseUnifiedStateComponent unifiedStateComponent2 = this.UnifiedStateComponent;
		global::ECharMoveState? newMoveState = (unifiedStateComponent2 != null) ? new global::ECharMoveState?(unifiedStateComponent2.MoveState) : null;
		this.ResetMaxSpeed(newMoveState);
		this.ResetCharacterMovementInfo(newMoveState);
	}

	// Token: 0x0601918E RID: 102798 RVA: 0x00722888 File Offset: 0x00720A88
	public unsafe void SetAddMoveOffset(FVectorDouble? offset)
	{
		if (offset != null && !Singleton<MathUtils>.Instance.IsValidVector(offset, 100000000))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "AddMove NaN";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this.ActorComp.Actor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Offset", offset);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.AddMoveOffset = offset;
		if (this.ActorComp.IsRoleAndCtrlByMe && offset != null && offset.Value.SizeSquared() > 1000000.0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Movement;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "AddMove超过了10米";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Actor", this.ActorComp.Actor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Offset", offset);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		}
	}

	// Token: 0x0601918F RID: 102799 RVA: 0x007229BE File Offset: 0x00720BBE
	public void SetAddMoveRotation(FRotator rotation)
	{
		this.AddMoveRotation.DeepCopy(rotation);
	}

	// Token: 0x06019190 RID: 102800 RVA: 0x007229CD File Offset: 0x00720BCD
	[NullableContext(2)]
	public void StopMove(bool isStop, string context = null)
	{
		if (isStop)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.SetActorVelocity(global::Vector.ZeroVectorProxy);
			}
			MoveToLocationController moveController = this.MoveController;
			if (moveController != null)
			{
				moveController.StopMove(context);
			}
		}
		this.IsStopInternal = isStop;
	}

	// Token: 0x06019191 RID: 102801 RVA: 0x00722A01 File Offset: 0x00720C01
	[NullableContext(2)]
	public void StopMoveNew(string context = null)
	{
		this.Speed = 0f;
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.SetActorVelocity(global::Vector.ZeroVectorProxy);
		}
		MoveToLocationController moveController = this.MoveController;
		if (moveController == null)
		{
			return;
		}
		moveController.StopMove(context);
	}

	// Token: 0x06019192 RID: 102802 RVA: 0x00722A35 File Offset: 0x00720C35
	[NullableContext(2)]
	public void StopMoveByHandleId(int handleId, string context = null)
	{
		this.Speed = 0f;
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.SetActorVelocity(global::Vector.ZeroVectorProxy);
		}
		MoveToLocationController moveController = this.MoveController;
		if (moveController == null)
		{
			return;
		}
		moveController.StopMoveByHandleId(handleId, context);
	}

	// Token: 0x06019193 RID: 102803 RVA: 0x00722A6C File Offset: 0x00720C6C
	public void SetHiddenMovementMode(bool isHidden)
	{
		if (isHidden == this.IsHidden)
		{
			return;
		}
		if (isHidden)
		{
			UCharacterMovementComponent characterMovement = this.CharacterMovement;
			TEnumAsByte<EMovementMode>? tenumAsByte = (characterMovement != null) ? new TEnumAsByte<EMovementMode>?(characterMovement.MovementMode) : null;
			this.OldMovementMode = ((tenumAsByte != null) ? new EMovementMode?(tenumAsByte.GetValueOrDefault()) : null);
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_None,
					Context = "[BaseMoveComponent.SetHiddenMovementMode] if true"
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
					Mode = this.OldMovementMode.Value,
					Context = "[BaseMoveComponent.SetHiddenMovementMode]"
				});
			}
		}
		this.IsHidden = isHidden;
	}

	// Token: 0x06019194 RID: 102804 RVA: 0x00722B40 File Offset: 0x00720D40
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		this.CurrentGravityScale = new GravityScale(0f, 0f, 0f, 0f, 0f, 0f, false, false);
		this.ForceSpeed.Set(-100000000.0, -100000000.0, -100000000.0);
		return true;
	}

	// Token: 0x06019195 RID: 102805 RVA: 0x00722BA0 File Offset: 0x00720DA0
	protected void InitTraceInfo()
	{
		this.SphereTrace = new UTraceSphereElement();
		this.SphereTrace.WorldContextObject = this.ActorComp.Owner;
		this.SphereTrace.bIsSingle = true;
		this.SphereTrace.bIgnoreSelf = true;
		this.SphereTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Visible);
		this.WaterSphereTrace = new UTraceSphereElement();
		this.WaterSphereTrace.WorldContextObject = this.ActorComp.Owner;
		this.WaterSphereTrace.bIsSingle = true;
		this.WaterSphereTrace.bIgnoreSelf = true;
		this.WaterSphereTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Water);
	}

	// Token: 0x06019196 RID: 102806 RVA: 0x00722C40 File Offset: 0x00720E40
	protected void InitBaseState()
	{
		EEntityType entityType = this.ActorComp.CreatureData.GetEntityType();
		switch (entityType)
		{
		case EEntityType.Player:
			this.CharacterMovement.bKuroAutoActiveNav = false;
			this.CharacterMovement.bKuroStillBlockInNav = true;
			this.CharacterMovement.bProjectNavMeshWalking = false;
			this.IsInputDrivenCharacter = true;
			goto IL_E1;
		case EEntityType.Npc:
			this.CharacterMovement.bKuroAutoActiveNav = false;
			this.CharacterMovement.bKuroStillBlockInNav = false;
			this.CharacterMovement.bProjectNavMeshWalking = false;
			this.IsInputDrivenCharacter = true;
			goto IL_E1;
		case EEntityType.Monster:
			break;
		default:
			if (entityType != EEntityType.Vision)
			{
				this.CharacterMovement.bKuroAutoActiveNav = false;
				this.CharacterMovement.bKuroStillBlockInNav = false;
				this.CharacterMovement.bProjectNavMeshWalking = true;
				this.IsInputDrivenCharacter = true;
				goto IL_E1;
			}
			break;
		}
		this.CharacterMovement.bKuroAutoActiveNav = false;
		this.CharacterMovement.bKuroStillBlockInNav = true;
		this.CharacterMovement.bProjectNavMeshWalking = false;
		this.IsInputDrivenCharacter = false;
		IL_E1:
		this.CharacterMovement.bImpartBaseVelocityZ = false;
		this.CharacterMovement.bImpartBaseVelocityX = false;
		this.CharacterMovement.bImpartBaseVelocityY = false;
	}

	// Token: 0x06019197 RID: 102807 RVA: 0x00722D54 File Offset: 0x00720F54
	protected override void OnActivate()
	{
		this.OnMoveStateChange(global::ECharMoveState.Stand, global::ECharMoveState.Run);
		if (this.CharacterMovement.MovementMode == EMovementMode.MOVE_NavWalking)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp == null)
			{
				return;
			}
			actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Walking,
				Context = "[BaseMoveComponent.OnActivate]"
			});
		}
	}

	// Token: 0x06019198 RID: 102808 RVA: 0x00722DB0 File Offset: 0x00720FB0
	protected void PrintAnimInstanceMovementInfo()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Test;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "TickInfo:";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("HasMoveInput", this.HasMoveInput);
		instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06019199 RID: 102809 RVA: 0x00722DF0 File Offset: 0x00720FF0
	protected virtual void InitCreatureProperty()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return;
		}
		this.CreatureProperty = component.GetEntityPropertyConfig();
		this.CharacterMovement.Mass = (float)this.CreatureProperty.重量;
		this.CharacterMovement.HitPriority = this.CreatureProperty.碰撞优先级;
		this.CharacterMovement.GoThroughPriority = this.CreatureProperty.穿透优先级;
	}

	// Token: 0x0601919A RID: 102810 RVA: 0x00722E5C File Offset: 0x0072105C
	public void ResetHitPriorityAndGoThrough()
	{
		if (this.CreatureProperty == null)
		{
			return;
		}
		this.CharacterMovement.HitPriority = this.CreatureProperty.碰撞优先级;
		this.CharacterMovement.GoThroughPriority = this.CreatureProperty.穿透优先级;
	}

	// Token: 0x0601919B RID: 102811 RVA: 0x00722E99 File Offset: 0x00721099
	public void ResetMass()
	{
		if (this.CreatureProperty == null)
		{
			return;
		}
		this.CharacterMovement.Mass = (float)this.CreatureProperty.重量;
	}

	// Token: 0x0601919C RID: 102812 RVA: 0x00722EC1 File Offset: 0x007210C1
	public bool CanResponseInput()
	{
		return this.CannotResponseInputCount == 0;
	}

	// Token: 0x0601919D RID: 102813 RVA: 0x00722ECC File Offset: 0x007210CC
	protected void SetInfoVar()
	{
		if ((double)this.DeltaTimeSeconds > 1E-08)
		{
			this.Acceleration.DeepCopy(this.ActorComp.ActorVelocityProxy);
			this.Acceleration.SubtractionEqual(this.PreviousVelocity);
			this.Acceleration.DivisionEqual((double)this.DeltaTimeSeconds);
			this.AimYawRate = Math.Abs(this.ActorComp.ActorRotationProxy.Yaw - this.PreviousAimYaw) / this.DeltaTimeSeconds;
		}
		bool hasMoveInput = this.HasMoveInput;
		this.HasMoveInput = (this.ActorComp.InputDirectProxy.SizeSquared() > 1E-08 && (double)this.CharacterMovement.MaxAcceleration > 1E-08);
		if (hasMoveInput != this.HasMoveInput)
		{
			Singleton<EventSystem>.Instance.EmitWithTarget<bool, bool>(base.Entity, EEventName.OnInputMoveChanged, hasMoveInput, this.HasMoveInput);
		}
	}

	// Token: 0x0601919E RID: 102814 RVA: 0x00722FB7 File Offset: 0x007211B7
	protected void CacheVar()
	{
		this.PreviousVelocity.DeepCopy(this.ActorComp.ActorVelocityProxy);
		this.PreviousAimYaw = this.ActorComp.ActorRotation.Yaw;
	}

	// Token: 0x0601919F RID: 102815 RVA: 0x00722FE8 File Offset: 0x007211E8
	public bool CanUpdateMovingRotation()
	{
		if (this.UnifiedStateComponent.DirectionState != ECharDirectionState.AimDirection)
		{
			CharacterAnimationComponent animComp = this.AnimComp;
			if (animComp != null && animComp.Valid && this.AnimComp.HasKuroRootMotion)
			{
				return this.AnimComp.ShellAnimInstance.GetMainAnimsCurveValueWithDelta(Singleton<CharacterNameDefines>.Instance.ROOT_ROTATABLE, 0f, false, false) >= 0.5f;
			}
		}
		return true;
	}

	// Token: 0x060191A0 RID: 102816 RVA: 0x00723054 File Offset: 0x00721254
	public void SetLockedRotation(bool @lock)
	{
		this.IsLockedRotation = @lock;
	}

	// Token: 0x170021D3 RID: 8659
	// (get) Token: 0x060191A1 RID: 102817 RVA: 0x0072305D File Offset: 0x0072125D
	public bool LockedRotation
	{
		get
		{
			return this.IsLockedRotation;
		}
	}

	// Token: 0x060191A2 RID: 102818 RVA: 0x00723068 File Offset: 0x00721268
	public void SmoothCharacterRotation(IRotator target, float speed, float deltaTimeSeconds, bool clearMeshRotationBuffer = false, string context = "Movement.SmoothCharacterRotation", bool influenceByTimeDilation = true)
	{
		if (this.IsLockedRotation)
		{
			return;
		}
		global::Rotator actorRotationProxy = this.ActorComp.ActorRotationProxy;
		if (actorRotationProxy.Equals2(target, 0.0001f))
		{
			return;
		}
		if (this.IsStandardGravity)
		{
			this.TmpRotator.DeepCopy(target);
			Singleton<MathUtils>.Instance.RotatorInterpConstantTo(actorRotationProxy, this.TmpRotator, deltaTimeSeconds, (influenceByTimeDilation ? this.SpeedScaled(speed) : speed) * this.TurnRate, this.TmpRotator);
		}
		else
		{
			this.TmpRotator.DeepCopy(target);
			Singleton<GravityUtils>.Instance.RotatorInterpConstantToForActor(this.ActorComp, actorRotationProxy, this.TmpRotator, deltaTimeSeconds, (influenceByTimeDilation ? this.SpeedScaled(speed) : speed) * this.TurnRate, this.TmpRotator);
		}
		if (base.Entity.GetTickInterval() > 1)
		{
			CharacterAnimationComponent animComp = this.AnimComp;
			if (animComp != null && animComp.Valid && this.ActorComp.Owner.WasRecentlyRenderedOnScreen(0.2f))
			{
				FTransformDouble meshTransform = this.AnimComp.GetMeshTransform();
				this.ActorComp.SetActorRotationWithPriority(this.TmpRotator.ToUeRotator(), context, ESetRotationPriority.Movement, clearMeshRotationBuffer, false);
				this.AnimComp.SetModelBuffer(meshTransform, deltaTimeSeconds * 1000f * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
				return;
			}
		}
		this.ActorComp.SetActorRotationWithPriority(this.TmpRotator.ToUeRotator(), context, ESetRotationPriority.Movement, clearMeshRotationBuffer, false);
	}

	// Token: 0x060191A3 RID: 102819 RVA: 0x007231BC File Offset: 0x007213BC
	public void ApplyForceSpeedAndRecordSpeed()
	{
		if (this.ForceSpeed.X != -100000000.0)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.SetActorVelocity(this.ForceSpeed);
			}
			this.ForceSpeed.X = -100000000.0;
		}
	}

	// Token: 0x060191A4 RID: 102820 RVA: 0x0072320A File Offset: 0x0072140A
	public virtual bool ConsumeForceFallingSpeed()
	{
		return true;
	}

	// Token: 0x060191A5 RID: 102821 RVA: 0x00723210 File Offset: 0x00721410
	[NullableContext(2)]
	public void SetAddMoveWorldSpeedWithMesh(UMeshComponent mesh, FVectorDouble speed)
	{
		if (mesh == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.WCL, "[CharacterMoveComponent.SetAddMoveWorldSpeedWithMesh] 叠加位移失败，mesh为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int value;
		this.VelocityAdditionMapByMesh.TryGetValue(mesh, out value);
		value = this.SetAddMoveWorld(new FVectorDouble?(speed), -1f, null, new int?(value), null, global::EVelocityCurveType.None, 0f, 1f);
		this.VelocityAdditionMapByMesh[mesh] = value;
	}

	// Token: 0x060191A6 RID: 102822 RVA: 0x00723288 File Offset: 0x00721488
	public virtual void SetAddMoveWithMesh(UMeshComponent mesh, FVectorDouble speed, float timeLength, [Nullable(2)] UCurveFloat curve = null)
	{
		if (mesh == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.WCL, "[CharacterMoveComponent.SetAddMoveWithMesh] 叠加位移失败，mesh为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int value;
		this.VelocityAdditionMapByMesh.TryGetValue(mesh, out value);
		FRotator actorRotation = this.ActorComp.ActorRotation;
		FVector fvector = speed;
		FVector fvector2 = actorRotation.RotateVector(fvector);
		FVectorDouble value2 = fvector2;
		value = this.SetAddMoveWorld(new FVectorDouble?(value2), timeLength, curve, new int?(value), null, global::EVelocityCurveType.None, 0f, 1f);
		this.VelocityAdditionMapByMesh[mesh] = value;
	}

	// Token: 0x060191A7 RID: 102823 RVA: 0x00723324 File Offset: 0x00721524
	[NullableContext(2)]
	public unsafe int SetAddMoveWorld(FVectorDouble? speed, float timeLength, UCurveFloat curve, int? handler, int? movementMode, global::EVelocityCurveType velocityCurveType = global::EVelocityCurveType.None, float velocityCurveMin = 0f, float velocityCurveMax = 1f)
	{
		if (speed == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.WCL, "[CharacterMoveComponent.SetAddMoveWorldNew] 叠加位移失败，速度为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0;
		}
		if (GlobalData.IsPlayInEditor && (velocityCurveMin >= velocityCurveMax || Singleton<MathUtils>.Instance.Clamp(velocityCurveMin, 0f, 1f) != velocityCurveMin || Singleton<MathUtils>.Instance.Clamp(velocityCurveMax, 0f, 1f) != velocityCurveMax))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Game;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "速度曲线配置错误";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Min", velocityCurveMin);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Max", velocityCurveMax);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return 0;
		}
		VelocityAddition velocityAddition = null;
		if (handler != null)
		{
			this.VelocityAdditionMap.TryGetValue(handler.Value, out velocityAddition);
			if (velocityAddition != null)
			{
				if (speed.ContainsNaN())
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Movement;
					ELogAuthor author2 = ELogAuthor.LCZ;
					string message2 = "SetAddMoveWorld Contains NaN";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("speed", speed);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				velocityAddition.ElapsedTime = 0f;
				velocityAddition.Velocity = speed;
				velocityAddition.Duration = timeLength;
				velocityAddition.CurveFloat = curve;
				velocityAddition.MovementMode = movementMode.GetValueOrDefault();
				return handler.Value;
			}
		}
		velocityAddition = new VelocityAddition(timeLength, speed.Value, curve, movementMode.GetValueOrDefault(), velocityCurveType, velocityCurveMin, velocityCurveMax);
		int num = this.VelocityAdditionIncId + 1;
		this.VelocityAdditionIncId = num;
		int num2 = num;
		this.VelocityAdditionMap[num2] = velocityAddition;
		return num2;
	}

	// Token: 0x060191A8 RID: 102824 RVA: 0x007234D0 File Offset: 0x007216D0
	public void SetAddMoveWorldWithMesh(UMeshComponent mesh, FVectorDouble speed, float timeLength, [Nullable(2)] UCurveFloat curve)
	{
		if (mesh == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.WCL, "[CharacterMoveComponent.SetAddMoveWorldWithMesh] 叠加位移失败，mesh为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int value;
		this.VelocityAdditionMapByMesh.TryGetValue(mesh, out value);
		value = this.SetAddMoveWorld(new FVectorDouble?(speed), timeLength, curve, new int?(value), null, global::EVelocityCurveType.None, 0f, 1f);
		this.VelocityAdditionMapByMesh[mesh] = value;
	}

	// Token: 0x060191A9 RID: 102825 RVA: 0x00723543 File Offset: 0x00721743
	public bool StopAddMove(int handler)
	{
		return this.VelocityAdditionMap.Remove(handler);
	}

	// Token: 0x060191AA RID: 102826 RVA: 0x00723554 File Offset: 0x00721754
	public bool StopAddMoveWithMesh(UMeshComponent mesh)
	{
		int key;
		this.VelocityAdditionMapByMesh.TryGetValue(mesh, out key);
		return this.VelocityAdditionMap.Remove(key);
	}

	// Token: 0x060191AB RID: 102827 RVA: 0x0072357C File Offset: 0x0072177C
	public void StopAllAddMove()
	{
		this.VelocityAdditionMap.Clear();
	}

	// Token: 0x060191AC RID: 102828 RVA: 0x0072358C File Offset: 0x0072178C
	protected override void OnTick(float delta)
	{
		this.CharHeightAboveGround = -1f;
		this.CharHeightAboveGroundDetectHeight = -1f;
		this.CharHeightAboveWater = -1f;
		this.CharHeightAboveWaterDetectHeight = -1f;
		this.CanMoveWithDistanceInternal = (base.Entity.DistanceWithCamera <= 7000f);
		if (this.IsNeedDelayCheckWalkOffLedge && this.WalkOffLedgeCheckFrame + 1 <= Singleton<Time>.Instance.Frame)
		{
			this.WalkOffLedgeCheckFrame = Singleton<Time>.Instance.Frame;
			this.SetWalkOffLedge(this.WalkOffCount <= 0);
			this.IsNeedDelayCheckWalkOffLedge = false;
		}
	}

	// Token: 0x060191AD RID: 102829 RVA: 0x00723628 File Offset: 0x00721828
	protected void OnTickGravityScale()
	{
		if (!this.CurrentGravityScale.Enable)
		{
			return;
		}
		if (this.CurrentGravityScale.ElapsedTime < this.CurrentGravityScale.Duration)
		{
			BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
			if (unifiedStateComponent != null && unifiedStateComponent.PositionState == global::ECharPositionState.Air)
			{
				this.CurrentGravityScale.ElapsedTime += this.DeltaTimeSeconds;
				if (this.CurrentGravityScale.VelocityTop < Math.Abs(this.CharacterMovement.Velocity.Z))
				{
					this.CharacterMovement.GravityScale = 2f * ((this.CharacterMovement.Velocity.Z > 0f) ? this.CurrentGravityScale.ScaleUp : this.CurrentGravityScale.ScaleDown);
					return;
				}
				this.CharacterMovement.GravityScale = 2f * this.CurrentGravityScale.ScaleTop;
				if (this.CurrentGravityScale.ForceVelocityZero)
				{
					this.CharacterMovement.Velocity = FVector.ZeroVector;
				}
				return;
			}
		}
		this.CharacterMovement.GravityScale = 2f;
		this.CurrentGravityScale.Enable = false;
	}

	// Token: 0x060191AE RID: 102830 RVA: 0x00723748 File Offset: 0x00721948
	public unsafe virtual void GetAndConsumeAddMove(float deltaSeconds, global::Vector outVector, global::Rotator outRotator)
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
			int num;
			VelocityAddition velocityAddition;
			keyValuePair.Deconstruct(out num, out velocityAddition);
			int num2 = num;
			VelocityAddition velocityAddition2 = velocityAddition;
			if (velocityAddition2.Duration >= 0f && velocityAddition2.ElapsedTime >= velocityAddition2.Duration)
			{
				this.VelocityAdditionMap.Remove(num2);
			}
			else if (velocityAddition2.MovementMode > 0 && (int)this.CharacterMovement.CustomMovementMode != velocityAddition2.MovementMode)
			{
				this.VelocityAdditionMap.Remove(num2);
			}
			else
			{
				velocityAddition2.ElapsedTime += deltaSeconds;
				if (this.PauseLocks.Count <= 0)
				{
					global::Vector velocityVector = this.VelocityVector;
					FVectorDouble value = velocityAddition2.Velocity.Value;
					velocityVector.FromUeVector(value);
					if (velocityAddition2.VelocityCurveType != global::EVelocityCurveType.None)
					{
						float num3 = velocityAddition2.VelocityCurveFunc((velocityAddition2.Duration > 0f) ? (velocityAddition2.ElapsedTime / velocityAddition2.Duration) : 1f);
						global::Vector velocityVector2 = this.VelocityVector;
						value = velocityAddition2.Velocity.Value;
						velocityVector2.FromUeVector(value);
						this.VelocityVector.MultiplyEqual((double)num3);
					}
					else
					{
						UCurveFloat curveFloat = velocityAddition2.CurveFloat;
						if (curveFloat != null && curveFloat.IsValid())
						{
							this.VelocityVector.MultiplyEqual((double)velocityAddition2.CurveFloat.GetFloatValue((velocityAddition2.Duration > 0f) ? (velocityAddition2.ElapsedTime / velocityAddition2.Duration) : 1f));
						}
					}
					if (velocityAddition2.Duration > 0f && velocityAddition2.ElapsedTime > velocityAddition2.Duration)
					{
						float num4 = velocityAddition2.ElapsedTime - velocityAddition2.Duration;
						float num5 = (deltaSeconds - num4) / deltaSeconds;
						this.VelocityVector.MultiplyEqual((double)num5);
					}
					BaseMoveComponent.VelocityAdditionTotal.AdditionEqual(this.VelocityVector);
					if (this.VelocityVector.ContainsNaN())
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Movement;
						ELogAuthor author = ELogAuthor.LCZ;
						string message = "VelocityVector NaN";
						<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", num2);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VelocityVector", this.VelocityVector);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("velocityAddition.Velocity", velocityAddition2.Velocity);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("deltaTimeSeconds", deltaSeconds);
						instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
						this.VelocityAdditionMap.Remove(num2);
						return;
					}
				}
			}
		}
		BaseMoveComponent.VelocityAdditionTotal.Multiply((double)deltaSeconds, BaseMoveComponent.VelocityAdditionDestination);
		if (BaseMoveComponent.VelocityAdditionDestination.ContainsNaN())
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Movement;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "VelocityAdditionDestination NaN";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("VelocityAdditionDestination", BaseMoveComponent.VelocityAdditionDestination);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("VelocityAdditionTotal", BaseMoveComponent.VelocityAdditionTotal);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("deltaTimeSeconds", deltaSeconds);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return;
		}
		outVector.AdditionEqual(BaseMoveComponent.VelocityAdditionDestination);
	}

	// Token: 0x060191AF RID: 102831 RVA: 0x00723B4C File Offset: 0x00721D4C
	public float GetHeightAboveGround(float heightDetect = 500f)
	{
		if (this.CharHeightAboveGroundDetectHeight >= heightDetect)
		{
			return Math.Min(this.CharHeightAboveGround, heightDetect);
		}
		this.CharHeightAboveGroundDetectHeight = heightDetect;
		this.TmpVector.DeepCopy(this.ActorComp.FloorLocation);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, (double)this.ActorComp.ScaledRadius);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.SphereTrace, this.TmpVector);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, (double)(-(double)heightDetect));
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.SphereTrace, this.TmpVector);
		this.SphereTrace.Radius = this.ActorComp.ScaledRadius;
		bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(this.SphereTrace, "CharacterMoveComponent_GetHeightAboveGround");
		UKuroHitResult hitResult = this.SphereTrace.HitResult;
		if (flag && hitResult.bBlockingHit)
		{
			this.CharHeightAboveGround = hitResult.TimeArray.Get(0) * heightDetect;
		}
		else
		{
			this.CharHeightAboveGround = heightDetect;
		}
		return this.CharHeightAboveGround;
	}

	// Token: 0x060191B0 RID: 102832 RVA: 0x00723C58 File Offset: 0x00721E58
	public float GetHeightAboveWater(float heightDetect = 500f)
	{
		if (this.CharHeightAboveWaterDetectHeight >= heightDetect)
		{
			return Math.Min(this.CharHeightAboveWater, heightDetect);
		}
		this.CharHeightAboveWaterDetectHeight = heightDetect;
		this.TmpVector.DeepCopy(this.ActorComp.FloorLocation);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, (double)this.ActorComp.ScaledRadius);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.WaterSphereTrace, this.TmpVector);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TmpVector, (double)(-(double)heightDetect));
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.WaterSphereTrace, this.TmpVector);
		this.WaterSphereTrace.Radius = this.ActorComp.ScaledRadius;
		bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(this.WaterSphereTrace, "CharacterMoveComponent_GetHeightAboveGround");
		UKuroHitResult hitResult = this.WaterSphereTrace.HitResult;
		if (flag && hitResult.bBlockingHit)
		{
			this.CharHeightAboveWater = hitResult.TimeArray.Get(0) * heightDetect;
		}
		else
		{
			this.CharHeightAboveWater = heightDetect;
		}
		return this.CharHeightAboveWater;
	}

	// Token: 0x060191B1 RID: 102833 RVA: 0x00723D63 File Offset: 0x00721F63
	public bool IsInAir()
	{
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		return unifiedStateComponent != null && unifiedStateComponent.PositionState == global::ECharPositionState.Air;
	}

	// Token: 0x060191B2 RID: 102834 RVA: 0x00723D7C File Offset: 0x00721F7C
	public bool IsInRoll()
	{
		UCharacterMovementComponent characterMovement = this.CharacterMovement;
		if (((characterMovement != null) ? new TEnumAsByte<EMovementMode>?(characterMovement.MovementMode) : null) == EMovementMode.MOVE_Custom)
		{
			UCharacterMovementComponent characterMovement2 = this.CharacterMovement;
			byte? b = (characterMovement2 != null) ? new byte?(characterMovement2.CustomMovementMode) : null;
			return ((b != null) ? new int?((int)b.GetValueOrDefault()) : null).GetValueOrDefault() == 9;
		}
		return false;
	}

	// Token: 0x060191B3 RID: 102835 RVA: 0x00723E1C File Offset: 0x0072201C
	public void SetSpeedLock()
	{
		this.SpeedLockFrame = 5;
	}

	// Token: 0x170021D4 RID: 8660
	// (get) Token: 0x060191B4 RID: 102836 RVA: 0x00723E25 File Offset: 0x00722025
	// (set) Token: 0x060191B5 RID: 102837 RVA: 0x00723E2D File Offset: 0x0072202D
	public bool FallingIntoWater
	{
		get
		{
			return this.IsFallingIntoWater;
		}
		set
		{
			this.IsFallingIntoWater = value;
		}
	}

	// Token: 0x060191B6 RID: 102838 RVA: 0x00723E38 File Offset: 0x00722038
	public void MoveCharacter(global::Vector offset, float deltaTime, string reason = "")
	{
		UCharacterMovementComponent characterMovement = this.CharacterMovement;
		bool flag;
		if (!(((characterMovement != null) ? new TEnumAsByte<EMovementMode>?(characterMovement.MovementMode) : null) == EMovementMode.MOVE_Walking))
		{
			UCharacterMovementComponent characterMovement2 = this.CharacterMovement;
			flag = (((characterMovement2 != null) ? new TEnumAsByte<EMovementMode>?(characterMovement2.MovementMode) : null) == EMovementMode.MOVE_NavWalking);
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			offset.DivisionEqual((double)deltaTime);
			this.ActorComp.KuroMoveAlongFloor(offset.ToUeVectorOld(), deltaTime, (reason != "") ? reason : "MoveCharacter");
		}
		else
		{
			this.ActorComp.AddActorWorldOffset(offset.ToUeVector(false), (reason != "") ? reason : "MoveCharacter", true);
		}
		this.ActorComp.ResetAllCachedTime();
	}

	// Token: 0x060191B7 RID: 102839 RVA: 0x00723F34 File Offset: 0x00722134
	public void SetWalkOffLedgeRecord(bool walkOff)
	{
		if (walkOff)
		{
			int num = this.WalkOffCount - 1;
			this.WalkOffCount = num;
			if (num == 0)
			{
				this.IsNeedDelayCheckWalkOffLedge = true;
				this.WalkOffLedgeCheckFrame = Singleton<Time>.Instance.Frame;
				return;
			}
		}
		else
		{
			int num = this.WalkOffCount + 1;
			this.WalkOffCount = num;
			if (num == 1)
			{
				this.IsNeedDelayCheckWalkOffLedge = false;
				this.SetWalkOffLedge(false);
			}
		}
	}

	// Token: 0x060191B8 RID: 102840 RVA: 0x00723F94 File Offset: 0x00722194
	protected void SetWalkOffLedge(bool walkOff)
	{
		if (walkOff)
		{
			this.CharacterMovement.bCanWalkOffLedges = true;
			this.CharacterMovement.PerchRadiusThreshold = 0f;
			this.CharacterMovement.PerchAdditionalHeight = 40f;
			return;
		}
		this.CharacterMovement.bCanWalkOffLedges = false;
		this.CharacterMovement.PerchRadiusThreshold = this.ActorComp.ScaledRadius;
		this.CharacterMovement.PerchAdditionalHeight = this.ActorComp.ScaledRadius * 2f;
	}

	// Token: 0x060191B9 RID: 102841 RVA: 0x00724010 File Offset: 0x00722210
	protected void LerpMaxAcceleration()
	{
		if (this.DesireMaxAccelerationLerpTime <= 0f)
		{
			return;
		}
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		global::ECharMoveState? echarMoveState = (unifiedStateComponent != null) ? new global::ECharMoveState?(unifiedStateComponent.MoveState) : null;
		global::ECharMoveState? accelerationChangeMoveState = this.AccelerationChangeMoveState;
		if (!(echarMoveState.GetValueOrDefault() == accelerationChangeMoveState.GetValueOrDefault() & echarMoveState != null == (accelerationChangeMoveState != null)))
		{
			this.DesireMaxAccelerationLerpTime = 0f;
			return;
		}
		SMovementSetting currentMovementSettings = this.CurrentMovementSettings;
		float num = (currentMovementSettings != null) ? currentMovementSettings.Acceleration : 0f;
		this.DesireMaxAccelerationLerpTime -= this.DeltaTimeSeconds;
		float inTime = (this.MaxAccelerationLerpTime - this.DesireMaxAccelerationLerpTime) / this.MaxAccelerationLerpTime;
		float floatValue = this.AccelerationLerpCurve.GetFloatValue(inTime);
		this.CharacterMovement.MaxAcceleration = floatValue * num;
		float num2 = (Singleton<MathUtils>.Instance.Clamp(floatValue, 1f, 2f) - 1f) * 0.8f + 1f;
		this.SetMaxSpeed(this.CurrentMovementSettings.SprintSpeed * num2);
	}

	// Token: 0x060191BA RID: 102842 RVA: 0x0072411C File Offset: 0x0072231C
	protected void UpdateGroundedRotation()
	{
		float angleOffsetFromCurrentToInputAbs = Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInputAbs(this.ActorComp);
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		if (unifiedStateComponent == null || unifiedStateComponent.MoveState != global::ECharMoveState.Stand || this.HasInputPrevFrame)
		{
			this.SmoothCharacterRotation(this.ActorComp.InputRotatorProxy, this.CurrentMovementRotationSetting.GetSpeed(angleOffsetFromCurrentToInputAbs), this.DeltaTimeSeconds, false, "Movement.UpdateGroundedRotation.ROTATION_MEDIUM", true);
		}
		this.HasInputPrevFrame = (angleOffsetFromCurrentToInputAbs > 1f);
	}

	// Token: 0x060191BB RID: 102843 RVA: 0x00724194 File Offset: 0x00722394
	protected void UpdateInAirRotation()
	{
		if (this.UnifiedStateComponent == null)
		{
			return;
		}
		if (this.UnifiedStateComponent.MoveState == global::ECharMoveState.Glide || this.UnifiedStateComponent.MoveState == global::ECharMoveState.Slide)
		{
			this.SmoothCharacterRotation(this.ActorComp.InputRotatorProxy, 60f, this.DeltaTimeSeconds, false, "Movement.UpdateInAirRotation", true);
		}
	}

	// Token: 0x060191BC RID: 102844 RVA: 0x007241EB File Offset: 0x007223EB
	protected void UpdateUsingControllerRotation()
	{
		this.SmoothCharacterRotation(this.ActorComp.InputRotatorProxy, 1500f, this.DeltaTimeSeconds, false, "Movement.UpdateGroundedRotation.ROTATION_AIM", true);
	}

	// Token: 0x060191BD RID: 102845 RVA: 0x00724210 File Offset: 0x00722410
	protected unsafe void UpdateBaseMovement()
	{
		FBasedMovementInfo basedMovement = this.ActorComp.Actor.BasedMovement;
		AActor aactor;
		if (basedMovement == null)
		{
			aactor = null;
		}
		else
		{
			UPrimitiveComponent movementBase = basedMovement.MovementBase;
			aactor = ((movementBase != null) ? movementBase.GetOwner() : null);
		}
		AActor aactor2 = aactor;
		if (this.BasedMovementActor != aactor2)
		{
			this.BasedMovementActor = aactor2;
			if (aactor2 != null && !(aactor2 is TsBaseCharacter))
			{
				TEnumAsByte<EComponentMobility>? tenumAsByte;
				if (basedMovement == null)
				{
					tenumAsByte = null;
				}
				else
				{
					UPrimitiveComponent movementBase2 = basedMovement.MovementBase;
					tenumAsByte = ((movementBase2 != null) ? new TEnumAsByte<EComponentMobility>?(movementBase2.Mobility) : null);
				}
				if (tenumAsByte == EComponentMobility.Movable)
				{
					Singleton<TickSystem>.Instance.AddTickPrerequisiteActor(ETickingGroup.TG_PrePhysics, aactor2, 2);
				}
			}
		}
		bool flag = false;
		BasePlatform basePlatformByBasedMovementInfo = BasePlatformController.GetBasePlatformByBasedMovementInfo(basedMovement);
		if (this.HasBaseMovement != basedMovement.bRelativeRotation || this.BasePlatform != basePlatformByBasedMovementInfo)
		{
			this.HasBaseMovement = basedMovement.bRelativeRotation;
			this.BasePlatform = basePlatformByBasedMovementInfo;
			flag = true;
		}
		if (this.HasBaseMovement)
		{
			TEnumAsByte<EComponentMobility>? tenumAsByte2;
			if (basedMovement == null)
			{
				tenumAsByte2 = null;
			}
			else
			{
				UPrimitiveComponent movementBase3 = basedMovement.MovementBase;
				tenumAsByte2 = ((movementBase3 != null) ? new TEnumAsByte<EComponentMobility>?(movementBase3.Mobility) : null);
			}
			if (tenumAsByte2 == EComponentMobility.Movable)
			{
				FQuat baseDeltaQuat = this.CharacterMovement.BaseDeltaQuat;
				this.DeltaBaseMovementQuat.FromUeQuat(baseDeltaQuat);
				FVector baseDeltaPosition = this.CharacterMovement.BaseDeltaPosition;
				this.DeltaBaseMovementOffset = new FVectorDouble?(new FVectorDouble(ref baseDeltaPosition));
				FVectorDouble fvectorDouble;
				if (Singleton<MathUtils>.Instance.IsNearlyZero((double)this.DeltaTimeSeconds, null))
				{
					fvectorDouble = new FVectorDouble(0.0, 0.0, 0.0);
				}
				else
				{
					FVectorDouble value = this.DeltaBaseMovementOffset.Value;
					fvectorDouble = value / (double)(this.DeltaTimeSeconds * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
				}
				if (basePlatformByBasedMovementInfo != null && !basePlatformByBasedMovementInfo.IsDeltaBaseSpeedNeedZ)
				{
					fvectorDouble.Z = 0.0;
				}
				if (this.DeltaBaseMovementSpeed != null)
				{
					FVectorDouble value2 = this.DeltaBaseMovementSpeed.Value;
					Singleton<MathUtils>.Instance.LerpVector(this.DeltaBaseMovementSpeed.Value, fvectorDouble, 0.2f, ref value2);
					this.DeltaBaseMovementSpeed = new FVectorDouble?(value2);
				}
				else
				{
					this.DeltaBaseMovementSpeed = new FVectorDouble?(fvectorDouble);
				}
				if (Math.Abs(this.DeltaBaseMovementSpeed.Value.X) > 3000.0 || Math.Abs(this.DeltaBaseMovementSpeed.Value.Y) > 3000.0 || Math.Abs(this.DeltaBaseMovementSpeed.Value.Z) > 3000.0)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Movement;
					ELogAuthor author = ELogAuthor.LCZ;
					string message = "异常惯性速度";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Speed", this.DeltaBaseMovementSpeed);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
					string item = "BasedMovement";
					AActor owner = basedMovement.MovementBase.GetOwner();
					ptr = new ValueTuple<string, object>(item, (owner != null) ? owner.GetName() : null);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				this.HasDeltaBaseMovementData = true;
				goto IL_349;
			}
		}
		this.DeltaBaseMovementQuat.Reset();
		this.DeltaBaseMovementSpeed = null;
		this.HasDeltaBaseMovementData = false;
		IL_349:
		if (flag)
		{
			Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.CharBasePlatformChanged);
		}
	}

	// Token: 0x060191BE RID: 102846 RVA: 0x0072457F File Offset: 0x0072277F
	protected virtual float SpeedScaled(float speed)
	{
		return speed;
	}

	// Token: 0x170021D5 RID: 8661
	// (get) Token: 0x060191BF RID: 102847 RVA: 0x00724582 File Offset: 0x00722782
	// (set) Token: 0x060191C0 RID: 102848 RVA: 0x0072458A File Offset: 0x0072278A
	public bool CanMoveFromInput
	{
		get
		{
			return this.CanMoveFromInputInternal;
		}
		set
		{
			this.CanMoveFromInputInternal = value;
		}
	}

	// Token: 0x060191C1 RID: 102849 RVA: 0x00724593 File Offset: 0x00722793
	public virtual bool CanMove()
	{
		return this.CanMoveFromInputInternal && (this.CanMoveWithDistanceInternal || this.UnifiedStateComponent.IsInFighting);
	}

	// Token: 0x060191C2 RID: 102850 RVA: 0x007245B4 File Offset: 0x007227B4
	public virtual bool CanMoveWithDistance()
	{
		return this.CanMoveWithDistanceInternal;
	}

	// Token: 0x060191C3 RID: 102851 RVA: 0x007245BC File Offset: 0x007227BC
	public virtual bool CanJumpPress()
	{
		return false;
	}

	// Token: 0x060191C4 RID: 102852 RVA: 0x007245BF File Offset: 0x007227BF
	public virtual bool CanWalkPress()
	{
		return false;
	}

	// Token: 0x060191C5 RID: 102853 RVA: 0x007245C2 File Offset: 0x007227C2
	public bool IsMovingToLocation()
	{
		return this.MoveController.IsMoving();
	}

	// Token: 0x060191C6 RID: 102854 RVA: 0x007245CF File Offset: 0x007227CF
	[NullableContext(2)]
	public void StopMoveWithCallback(ELevelEventState result, string context = null)
	{
		this.MoveController.StopMoveWithCallback(result, context);
	}

	// Token: 0x060191C7 RID: 102855 RVA: 0x007245DE File Offset: 0x007227DE
	[NullableContext(2)]
	public void StopMoveToLocation(string context = null)
	{
		this.MoveController.StopMoveToLocation(context);
	}

	// Token: 0x060191C8 RID: 102856 RVA: 0x007245EC File Offset: 0x007227EC
	public int MoveAlongPath(MoveCharacterConfig config, [Nullable(2)] string context = null)
	{
		this.IsStopInternal = false;
		return this.MoveController.MoveAlongPath(config, context);
	}

	// Token: 0x170021D6 RID: 8662
	// (get) Token: 0x060191C9 RID: 102857 RVA: 0x00724602 File Offset: 0x00722802
	public MoveToLocationController MoveController
	{
		get
		{
			if (this.MoveControllerInternal == null)
			{
				this.MoveControllerInternal = new MoveToLocationController(base.Entity);
			}
			return this.MoveControllerInternal;
		}
	}

	// Token: 0x060191CA RID: 102858 RVA: 0x00724623 File Offset: 0x00722823
	public void SetTurnRate(float v)
	{
		this.TurnRate = v;
	}

	// Token: 0x060191CB RID: 102859 RVA: 0x0072462C File Offset: 0x0072282C
	public void ResetTurnRate()
	{
		this.TurnRate = 1f;
	}

	// Token: 0x060191CC RID: 102860 RVA: 0x00724639 File Offset: 0x00722839
	public void SetAirControl(float v)
	{
		this.CharacterMovement.AirControl = v;
	}

	// Token: 0x060191CD RID: 102861 RVA: 0x00724647 File Offset: 0x00722847
	public void ResetAirControl()
	{
		this.CharacterMovement.AirControl = 0.05f;
	}

	// Token: 0x060191CE RID: 102862 RVA: 0x00724659 File Offset: 0x00722859
	public void ResetCharTraceHeight()
	{
		this.CharHeightAboveGround = -1f;
		this.CharHeightAboveGroundDetectHeight = -1f;
		this.CharHeightAboveWater = -1f;
		this.CharHeightAboveWaterDetectHeight = -1f;
	}

	// Token: 0x060191CF RID: 102863 RVA: 0x00724687 File Offset: 0x00722887
	protected override bool OnClear()
	{
		base.OnClear();
		this.IsNeedDelayCheckWalkOffLedge = false;
		this.WalkOffLedgeCheckFrame = 0;
		return true;
	}

	// Token: 0x060191D0 RID: 102864 RVA: 0x0072469F File Offset: 0x0072289F
	public void AddPauseLock(string key)
	{
		this.PauseLocks[key] = true;
	}

	// Token: 0x060191D1 RID: 102865 RVA: 0x007246B0 File Offset: 0x007228B0
	public void RemovePauseLock(string key)
	{
		bool flag;
		this.PauseLocks.TryGetValue(key, out flag);
		if (flag)
		{
			this.PauseLocks.Remove(key);
		}
	}

	// Token: 0x060191D2 RID: 102866 RVA: 0x007246DC File Offset: 0x007228DC
	public void SetInputMaxDegree(float degree)
	{
		this.MaxMoveDegree = degree;
	}

	// Token: 0x060191D3 RID: 102867 RVA: 0x007246E5 File Offset: 0x007228E5
	public void SetInputScale(float scale)
	{
		this.InputScale = scale;
	}

	// Token: 0x060191D4 RID: 102868 RVA: 0x007246EE File Offset: 0x007228EE
	public bool HasInputMoveLimit()
	{
		return this.MaxMoveDegree > 0f;
	}

	// Token: 0x060191D5 RID: 102869 RVA: 0x00724700 File Offset: 0x00722900
	public void GetFixInputMoveDirection([Nullable(new byte[]
	{
		0,
		1
	})] OneOf<global::Vector, FVector, FVectorDouble> direction, global::Vector @out)
	{
		if (this.ActorComp == null)
		{
			return;
		}
		FVectorDouble asT;
		if (direction.IsT1)
		{
			asT = new FVectorDouble(direction.AsT1.X, direction.AsT1.Y, direction.AsT1.Z);
		}
		else if (direction.IsT2)
		{
			asT = new FVectorDouble((double)direction.AsT2.X, (double)direction.AsT2.Y, (double)direction.AsT2.Z);
		}
		else
		{
			asT = direction.AsT3;
		}
		this.TmpVector.DeepCopy(asT);
		if (Singleton<MathUtils>.Instance.GetAngleByVectorDot(this.ActorComp.ActorForwardProxy, global::Vector.Create(asT)) <= (double)this.MaxMoveDegree || this.TmpVector.IsNearlyZero(9.999999747378752E-05))
		{
			return;
		}
		this.ActorComp.ActorForwardProxy.CrossProduct(this.TmpVector, this.TmpVector2);
		bool flag = Singleton<MathUtils>.Instance.DotProduct(this.TmpVector2, this.ActorComp.ActorUpProxy) > 0.0;
		this.TmpVector2.DeepCopy(this.ActorComp.ActorForwardProxy);
		this.TmpVector2.RotateAngleAxis((double)(flag ? this.MaxMoveDegree : (-1f * this.MaxMoveDegree)), this.ActorComp.ActorUpProxy, @out);
		if (this.InputScale != 1f)
		{
			@out.MultiplyEqual((double)this.InputScale);
		}
	}

	// Token: 0x060191D6 RID: 102870 RVA: 0x0072487D File Offset: 0x00722A7D
	public static void CreateStaticDefaultValue()
	{
		BaseMoveComponent.VelocityAdditionTotal = global::Vector.Create();
		BaseMoveComponent.VelocityAdditionDestination = global::Vector.Create();
	}

	// Token: 0x060191D7 RID: 102871 RVA: 0x00724893 File Offset: 0x00722A93
	public static void ResetStaticDefaultValue()
	{
		BaseMoveComponent.BaseMoveInheritCurveInternal = null;
		BaseMoveComponent.VelocityAdditionTotal = null;
		BaseMoveComponent.VelocityAdditionDestination = null;
	}

	// Token: 0x060191D8 RID: 102872 RVA: 0x007248A8 File Offset: 0x00722AA8
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseMoveComponent baseMoveComponent = (BaseMoveComponent)componentTemplate;
		if (base.CanResetComponentProperty("IsInputDrivenCharacter"))
		{
			this.IsInputDrivenCharacter = baseMoveComponent.IsInputDrivenCharacter;
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (baseMoveComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CharacterMovement"))
		{
			if (baseMoveComponent.CharacterMovement == null)
			{
				this.CharacterMovement = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UCharacterMovementComponent>(this.CharacterMovement), "CharacterMovement"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (baseMoveComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TimeScaleComp"))
		{
			if (baseMoveComponent.TimeScaleComp == null)
			{
				this.TimeScaleComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnTimeScaleComponent>(this.TimeScaleComp), "TimeScaleComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveControllerInternal"))
		{
			if (baseMoveComponent.MoveControllerInternal == null)
			{
				this.MoveControllerInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MoveToLocationController>(this.MoveControllerInternal), "MoveControllerInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HasMoveInput"))
		{
			this.HasMoveInput = baseMoveComponent.HasMoveInput;
		}
		if (base.CanResetComponentProperty("ForceExitStateStop"))
		{
			this.ForceExitStateStop = baseMoveComponent.ForceExitStateStop;
		}
		if (base.CanResetComponentProperty("IsMoving"))
		{
			this.IsMoving = baseMoveComponent.IsMoving;
		}
		if (base.CanResetComponentProperty("Speed"))
		{
			this.Speed = baseMoveComponent.Speed;
		}
		if (base.CanResetComponentProperty("IsSpecialMove"))
		{
			this.IsSpecialMove = baseMoveComponent.IsSpecialMove;
		}
		if (base.CanResetComponentProperty("NeedRootMotionWhenAttached"))
		{
			this.NeedRootMotionWhenAttached = baseMoveComponent.NeedRootMotionWhenAttached;
		}
		if (base.CanResetComponentProperty("CanMoveWithDistanceInternal"))
		{
			this.CanMoveWithDistanceInternal = baseMoveComponent.CanMoveWithDistanceInternal;
		}
		if (base.CanResetComponentProperty("CanMoveFromInputInternal"))
		{
			this.CanMoveFromInputInternal = baseMoveComponent.CanMoveFromInputInternal;
		}
		if (base.CanResetComponentProperty("DeltaTimeSeconds"))
		{
			this.DeltaTimeSeconds = baseMoveComponent.DeltaTimeSeconds;
		}
		if (base.CanResetComponentProperty("JumpUpRate"))
		{
			this.JumpUpRate = baseMoveComponent.JumpUpRate;
		}
		if (base.CanResetComponentProperty("ConfigChainLengthSquared"))
		{
			this.ConfigChainLengthSquared = baseMoveComponent.ConfigChainLengthSquared;
		}
		if (base.CanResetComponentProperty("CurrentChainLengthSquared"))
		{
			this.CurrentChainLengthSquared = baseMoveComponent.CurrentChainLengthSquared;
		}
		if (base.CanResetComponentProperty("ChainCenter") && baseMoveComponent.ChainCenter != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.ChainCenter), "ChainCenter"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ChainTempPredicted") && baseMoveComponent.ChainTempPredicted != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.ChainTempPredicted), "ChainTempPredicted"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ChainTempToCenter") && baseMoveComponent.ChainTempToCenter != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.ChainTempToCenter), "ChainTempToCenter"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ForceSpeed") && baseMoveComponent.ForceSpeed != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.ForceSpeed), "ForceSpeed"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("Acceleration"))
		{
			if (baseMoveComponent.Acceleration == null)
			{
				this.Acceleration = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.Acceleration), "Acceleration"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PreviousVelocity") && baseMoveComponent.PreviousVelocity != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.PreviousVelocity), "PreviousVelocity"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpVector") && baseMoveComponent.TmpVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector), "TmpVector"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpVector2") && baseMoveComponent.TmpVector2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TmpVector2), "TmpVector2"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpQuat") && baseMoveComponent.TmpQuat != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TmpQuat), "TmpQuat"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpQuat2") && baseMoveComponent.TmpQuat2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TmpQuat2), "TmpQuat2"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpRotator") && baseMoveComponent.TmpRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.TmpRotator), "TmpRotator"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("PreviousAimYaw"))
		{
			this.PreviousAimYaw = baseMoveComponent.PreviousAimYaw;
		}
		if (base.CanResetComponentProperty("AimYawRate"))
		{
			this.AimYawRate = baseMoveComponent.AimYawRate;
		}
		if (base.CanResetComponentProperty("IsFallingIntoWater"))
		{
			this.IsFallingIntoWater = baseMoveComponent.IsFallingIntoWater;
		}
		if (base.CanResetComponentProperty("JumpFrameCount"))
		{
			this.JumpFrameCount = baseMoveComponent.JumpFrameCount;
		}
		if (base.CanResetComponentProperty("CharHeightAboveGround"))
		{
			this.CharHeightAboveGround = baseMoveComponent.CharHeightAboveGround;
		}
		if (base.CanResetComponentProperty("CharHeightAboveGroundDetectHeight"))
		{
			this.CharHeightAboveGroundDetectHeight = baseMoveComponent.CharHeightAboveGroundDetectHeight;
		}
		if (base.CanResetComponentProperty("CharHeightAboveWater"))
		{
			this.CharHeightAboveWater = baseMoveComponent.CharHeightAboveWater;
		}
		if (base.CanResetComponentProperty("CharHeightAboveWaterDetectHeight"))
		{
			this.CharHeightAboveWaterDetectHeight = baseMoveComponent.CharHeightAboveWaterDetectHeight;
		}
		if (base.CanResetComponentProperty("CreatureProperty"))
		{
			if (baseMoveComponent.CreatureProperty == null)
			{
				this.CreatureProperty = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SEntityProperty>(this.CreatureProperty), "CreatureProperty"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DefaultMovementData"))
		{
			if (baseMoveComponent.DefaultMovementData == null)
			{
				this.DefaultMovementData = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SMovementSetting_State>(this.DefaultMovementData), "DefaultMovementData"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MovementDataMap"))
		{
			if (baseMoveComponent.MovementDataMap == null)
			{
				this.MovementDataMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, SMovementSetting_State>>(this.MovementDataMap), "MovementDataMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MovementData"))
		{
			if (baseMoveComponent.MovementData == null)
			{
				this.MovementData = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SMovementSetting_State>(this.MovementData), "MovementData"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurrentMovementSettingsInternal"))
		{
			if (baseMoveComponent.CurrentMovementSettingsInternal == null)
			{
				this.CurrentMovementSettingsInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SMovementSetting>(this.CurrentMovementSettingsInternal), "CurrentMovementSettingsInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurrentMovementRotationSetting") && baseMoveComponent.CurrentMovementRotationSetting != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<RotationSetting>(this.CurrentMovementRotationSetting), "CurrentMovementRotationSetting"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("UnifiedStateComponent"))
		{
			if (baseMoveComponent.UnifiedStateComponent == null)
			{
				this.UnifiedStateComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseUnifiedStateComponent>(this.UnifiedStateComponent), "UnifiedStateComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HasBaseMovement"))
		{
			this.HasBaseMovement = baseMoveComponent.HasBaseMovement;
		}
		if (base.CanResetComponentProperty("OldMovementMode"))
		{
			this.OldMovementMode = baseMoveComponent.OldMovementMode;
		}
		if (base.CanResetComponentProperty("IsHidden"))
		{
			this.IsHidden = baseMoveComponent.IsHidden;
		}
		if (base.CanResetComponentProperty("HasDeltaBaseMovementData"))
		{
			this.HasDeltaBaseMovementData = baseMoveComponent.HasDeltaBaseMovementData;
		}
		if (base.CanResetComponentProperty("DeltaBaseMovementOffset"))
		{
			this.DeltaBaseMovementOffset = baseMoveComponent.DeltaBaseMovementOffset;
		}
		if (base.CanResetComponentProperty("DeltaBaseMovementSpeed"))
		{
			this.DeltaBaseMovementSpeed = baseMoveComponent.DeltaBaseMovementSpeed;
		}
		if (base.CanResetComponentProperty("DeltaConveyBeltSpeed"))
		{
			this.DeltaConveyBeltSpeed = baseMoveComponent.DeltaConveyBeltSpeed;
		}
		if (base.CanResetComponentProperty("DeltaBaseMovementQuat"))
		{
			if (baseMoveComponent.DeltaBaseMovementQuat == null)
			{
				this.DeltaBaseMovementQuat = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.DeltaBaseMovementQuat), "DeltaBaseMovementQuat"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BasedMovementActor"))
		{
			if (baseMoveComponent.BasedMovementActor == null)
			{
				this.BasedMovementActor = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.BasedMovementActor), "BasedMovementActor"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BasePlatform"))
		{
			if (baseMoveComponent.BasePlatform == null)
			{
				this.BasePlatform = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BasePlatform>(this.BasePlatform), "BasePlatform"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsLockedRotation"))
		{
			this.IsLockedRotation = baseMoveComponent.IsLockedRotation;
		}
		if (base.CanResetComponentProperty("SpeedLockFrame"))
		{
			this.SpeedLockFrame = baseMoveComponent.SpeedLockFrame;
		}
		if (base.CanResetComponentProperty("VelocityVector") && baseMoveComponent.VelocityVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.VelocityVector), "VelocityVector"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("IsStopInternal"))
		{
			this.IsStopInternal = baseMoveComponent.IsStopInternal;
		}
		if (base.CanResetComponentProperty("DebugMovementSetting"))
		{
			if (baseMoveComponent.DebugMovementSetting == null)
			{
				this.DebugMovementSetting = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SMovementSetting>(this.DebugMovementSetting), "DebugMovementSetting"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UseDebugMovementSetting"))
		{
			this.UseDebugMovementSetting = baseMoveComponent.UseDebugMovementSetting;
		}
		if (base.CanResetComponentProperty("WalkOffCount"))
		{
			this.WalkOffCount = baseMoveComponent.WalkOffCount;
		}
		if (base.CanResetComponentProperty("CannotResponseInputCount"))
		{
			this.CannotResponseInputCount = baseMoveComponent.CannotResponseInputCount;
		}
		if (base.CanResetComponentProperty("CapsuleOffset"))
		{
			if (baseMoveComponent.CapsuleOffset == null)
			{
				this.CapsuleOffset = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CapsuleOffset), "CapsuleOffset"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SphereTrace"))
		{
			if (baseMoveComponent.SphereTrace == null)
			{
				this.SphereTrace = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.SphereTrace), "SphereTrace"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("WaterSphereTrace"))
		{
			if (baseMoveComponent.WaterSphereTrace == null)
			{
				this.WaterSphereTrace = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.WaterSphereTrace), "WaterSphereTrace"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AccelerationChangeMoveState"))
		{
			this.AccelerationChangeMoveState = baseMoveComponent.AccelerationChangeMoveState;
		}
		if (base.CanResetComponentProperty("AccelerationLerpCurve"))
		{
			if (baseMoveComponent.AccelerationLerpCurve == null)
			{
				this.AccelerationLerpCurve = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UCurveFloat>(this.AccelerationLerpCurve), "AccelerationLerpCurve"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FallingHorizontalMaxSpeed"))
		{
			this.FallingHorizontalMaxSpeed = baseMoveComponent.FallingHorizontalMaxSpeed;
		}
		if (base.CanResetComponentProperty("DesireMaxAccelerationLerpTime"))
		{
			this.DesireMaxAccelerationLerpTime = baseMoveComponent.DesireMaxAccelerationLerpTime;
		}
		if (base.CanResetComponentProperty("MaxAccelerationLerpTime"))
		{
			this.MaxAccelerationLerpTime = baseMoveComponent.MaxAccelerationLerpTime;
		}
		if (base.CanResetComponentProperty("IsNeedDelayCheckWalkOffLedge"))
		{
			this.IsNeedDelayCheckWalkOffLedge = baseMoveComponent.IsNeedDelayCheckWalkOffLedge;
		}
		if (base.CanResetComponentProperty("WalkOffLedgeCheckFrame"))
		{
			this.WalkOffLedgeCheckFrame = baseMoveComponent.WalkOffLedgeCheckFrame;
		}
		if (base.CanResetComponentProperty("TurnRate"))
		{
			this.TurnRate = baseMoveComponent.TurnRate;
		}
		if (base.CanResetComponentProperty("IsRegionMoveMode"))
		{
			this.IsRegionMoveMode = baseMoveComponent.IsRegionMoveMode;
		}
		if (base.CanResetComponentProperty("GravityDirectInternal") && baseMoveComponent.GravityDirectInternal != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.GravityDirectInternal), "GravityDirectInternal"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("GravityUpInternal") && baseMoveComponent.GravityUpInternal != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.GravityUpInternal), "GravityUpInternal"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("IsStandardGravityInternal"))
		{
			this.IsStandardGravityInternal = baseMoveComponent.IsStandardGravityInternal;
		}
		if (base.CanResetComponentProperty("JumpDelayTimer"))
		{
			if (baseMoveComponent.JumpDelayTimer == null)
			{
				this.JumpDelayTimer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.JumpDelayTimer), "JumpDelayTimer"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("GroundedTimeUe"))
		{
			this.GroundedTimeUe = baseMoveComponent.GroundedTimeUe;
		}
		if (base.CanResetComponentProperty("VelocityAdditionIncId"))
		{
			this.VelocityAdditionIncId = baseMoveComponent.VelocityAdditionIncId;
		}
		if (base.CanResetComponentProperty("VelocityAdditionMap") && baseMoveComponent.VelocityAdditionMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, VelocityAddition>>(this.VelocityAdditionMap), "VelocityAdditionMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("VelocityAdditionMapByMesh") && baseMoveComponent.VelocityAdditionMapByMesh != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<UMeshComponent, int>>(this.VelocityAdditionMapByMesh), "VelocityAdditionMapByMesh"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("AddMoveOffset"))
		{
			this.AddMoveOffset = baseMoveComponent.AddMoveOffset;
		}
		if (base.CanResetComponentProperty("AddMoveRotation"))
		{
			if (baseMoveComponent.AddMoveRotation == null)
			{
				this.AddMoveRotation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.AddMoveRotation), "AddMoveRotation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurrentGravityScale"))
		{
			if (baseMoveComponent.CurrentGravityScale == null)
			{
				this.CurrentGravityScale = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<GravityScale>(this.CurrentGravityScale), "CurrentGravityScale"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HasInputPrevFrame"))
		{
			this.HasInputPrevFrame = baseMoveComponent.HasInputPrevFrame;
		}
		if (base.CanResetComponentProperty("PauseLocks"))
		{
			if (baseMoveComponent.PauseLocks == null)
			{
				this.PauseLocks = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, bool>>(this.PauseLocks), "PauseLocks"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MaxMoveDegree"))
		{
			this.MaxMoveDegree = baseMoveComponent.MaxMoveDegree;
		}
		if (base.CanResetComponentProperty("InputScale"))
		{
			this.InputScale = baseMoveComponent.InputScale;
		}
		return true;
	}

	// Token: 0x0400C4B2 RID: 50354
	[Nullable(2)]
	protected static UCurveFloat BaseMoveInheritCurveInternal;

	// Token: 0x0400C4B3 RID: 50355
	public const string PROFILE_KEY = "CharacterMoveComponent_GetHeightAboveGround";

	// Token: 0x0400C4B4 RID: 50356
	public const float ROTATION_AIM = 1500f;

	// Token: 0x0400C4B5 RID: 50357
	public const float HEIGHT_DETECT = 500f;

	// Token: 0x0400C4B6 RID: 50358
	public const float ROTATABLE_THREADHOLD = 0.5f;

	// Token: 0x0400C4B7 RID: 50359
	public const float BASE_MOVEMENT_VELOCITY_RATE = 0.2f;

	// Token: 0x0400C4B8 RID: 50360
	public const int SPEED_LOCK_FRAME = 5;

	// Token: 0x0400C4B9 RID: 50361
	public const float INVALID_FORCE_SPEED = -100000000f;

	// Token: 0x0400C4BA RID: 50362
	public const bool OPEN_DEBUG = false;

	// Token: 0x0400C4BB RID: 50363
	public const float DEFAULT_MAX_FALLING_VELOCITY_2D = 700f;

	// Token: 0x0400C4BC RID: 50364
	public const float DEFAULT_AIR_CONTROL = 0.05f;

	// Token: 0x0400C4BD RID: 50365
	public const int WALK_OFF_LEDGE_DELAY_FRAME = 1;

	// Token: 0x0400C4BE RID: 50366
	protected bool IsInputDrivenCharacter;

	// Token: 0x0400C4BF RID: 50367
	[Nullable(2)]
	public CharacterActorComponent ActorComp;

	// Token: 0x0400C4C0 RID: 50368
	[Nullable(2)]
	public UCharacterMovementComponent CharacterMovement;

	// Token: 0x0400C4C1 RID: 50369
	[Nullable(2)]
	protected CharacterAnimationComponent AnimComp;

	// Token: 0x0400C4C2 RID: 50370
	[Nullable(2)]
	protected PawnTimeScaleComponent TimeScaleComp;

	// Token: 0x0400C4C3 RID: 50371
	[Nullable(2)]
	protected MoveToLocationController MoveControllerInternal;

	// Token: 0x0400C4C4 RID: 50372
	public bool HasMoveInput;

	// Token: 0x0400C4C5 RID: 50373
	public bool ForceExitStateStop;

	// Token: 0x0400C4C6 RID: 50374
	public bool IsMoving;

	// Token: 0x0400C4C7 RID: 50375
	public float Speed;

	// Token: 0x0400C4C8 RID: 50376
	public bool IsSpecialMove;

	// Token: 0x0400C4C9 RID: 50377
	public bool NeedRootMotionWhenAttached;

	// Token: 0x0400C4CA RID: 50378
	protected bool CanMoveWithDistanceInternal = true;

	// Token: 0x0400C4CB RID: 50379
	protected bool CanMoveFromInputInternal = true;

	// Token: 0x0400C4CC RID: 50380
	protected float DeltaTimeSeconds;

	// Token: 0x0400C4CD RID: 50381
	public float JumpUpRate = 1f;

	// Token: 0x0400C4CE RID: 50382
	protected double ConfigChainLengthSquared = -1.0;

	// Token: 0x0400C4CF RID: 50383
	protected double CurrentChainLengthSquared;

	// Token: 0x0400C4D0 RID: 50384
	protected readonly global::Vector ChainCenter = global::Vector.Create();

	// Token: 0x0400C4D1 RID: 50385
	private readonly global::Vector ChainTempPredicted = global::Vector.Create();

	// Token: 0x0400C4D2 RID: 50386
	private readonly global::Vector ChainTempToCenter = global::Vector.Create();

	// Token: 0x0400C4D3 RID: 50387
	protected readonly global::Vector ForceSpeed = global::Vector.Create(-100000000.0, -100000000.0, -100000000.0);

	// Token: 0x0400C4D4 RID: 50388
	public global::Vector Acceleration = global::Vector.Create();

	// Token: 0x0400C4D5 RID: 50389
	protected readonly global::Vector PreviousVelocity = global::Vector.Create();

	// Token: 0x0400C4D6 RID: 50390
	protected readonly global::Vector TmpVector = global::Vector.Create();

	// Token: 0x0400C4D7 RID: 50391
	protected readonly global::Vector TmpVector2 = global::Vector.Create();

	// Token: 0x0400C4D8 RID: 50392
	protected readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400C4D9 RID: 50393
	protected readonly Quat TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400C4DA RID: 50394
	protected readonly global::Rotator TmpRotator = global::Rotator.Create();

	// Token: 0x0400C4DB RID: 50395
	protected float PreviousAimYaw;

	// Token: 0x0400C4DC RID: 50396
	public float AimYawRate;

	// Token: 0x0400C4DD RID: 50397
	public bool IsFallingIntoWater;

	// Token: 0x0400C4DE RID: 50398
	protected int JumpFrameCount;

	// Token: 0x0400C4DF RID: 50399
	protected float CharHeightAboveGround = -1f;

	// Token: 0x0400C4E0 RID: 50400
	protected float CharHeightAboveGroundDetectHeight = -1f;

	// Token: 0x0400C4E1 RID: 50401
	protected float CharHeightAboveWater = -1f;

	// Token: 0x0400C4E2 RID: 50402
	protected float CharHeightAboveWaterDetectHeight = -1f;

	// Token: 0x0400C4E3 RID: 50403
	[Nullable(2)]
	protected SEntityProperty CreatureProperty;

	// Token: 0x0400C4E4 RID: 50404
	[Nullable(2)]
	protected SMovementSetting_State DefaultMovementData;

	// Token: 0x0400C4E5 RID: 50405
	protected Dictionary<int, SMovementSetting_State> MovementDataMap = new Dictionary<int, SMovementSetting_State>();

	// Token: 0x0400C4E6 RID: 50406
	[Nullable(2)]
	public SMovementSetting_State MovementData;

	// Token: 0x0400C4E7 RID: 50407
	[Nullable(2)]
	private SMovementSetting CurrentMovementSettingsInternal;

	// Token: 0x0400C4E8 RID: 50408
	public readonly RotationSetting CurrentMovementRotationSetting = new RotationSetting();

	// Token: 0x0400C4E9 RID: 50409
	[Nullable(2)]
	protected BaseUnifiedStateComponent UnifiedStateComponent;

	// Token: 0x0400C4EA RID: 50410
	public bool HasBaseMovement;

	// Token: 0x0400C4EB RID: 50411
	protected EMovementMode? OldMovementMode;

	// Token: 0x0400C4EC RID: 50412
	protected bool IsHidden;

	// Token: 0x0400C4ED RID: 50413
	public bool HasDeltaBaseMovementData;

	// Token: 0x0400C4EE RID: 50414
	public FVectorDouble? DeltaBaseMovementOffset;

	// Token: 0x0400C4EF RID: 50415
	public FVectorDouble? DeltaBaseMovementSpeed;

	// Token: 0x0400C4F0 RID: 50416
	public FVectorDouble? DeltaConveyBeltSpeed;

	// Token: 0x0400C4F1 RID: 50417
	public Quat DeltaBaseMovementQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400C4F2 RID: 50418
	[Nullable(2)]
	private AActor BasedMovementActor;

	// Token: 0x0400C4F3 RID: 50419
	[Nullable(2)]
	public BasePlatform BasePlatform;

	// Token: 0x0400C4F4 RID: 50420
	protected bool IsLockedRotation;

	// Token: 0x0400C4F5 RID: 50421
	protected int SpeedLockFrame;

	// Token: 0x0400C4F6 RID: 50422
	protected readonly global::Vector VelocityVector = global::Vector.Create();

	// Token: 0x0400C4F7 RID: 50423
	protected bool IsStopInternal;

	// Token: 0x0400C4F8 RID: 50424
	[Nullable(2)]
	protected SMovementSetting DebugMovementSetting;

	// Token: 0x0400C4F9 RID: 50425
	protected bool UseDebugMovementSetting;

	// Token: 0x0400C4FA RID: 50426
	protected int WalkOffCount;

	// Token: 0x0400C4FB RID: 50427
	protected int CannotResponseInputCount;

	// Token: 0x0400C4FC RID: 50428
	[Nullable(2)]
	protected global::Vector CapsuleOffset;

	// Token: 0x0400C4FD RID: 50429
	[Nullable(2)]
	protected UTraceSphereElement SphereTrace;

	// Token: 0x0400C4FE RID: 50430
	[Nullable(2)]
	protected UTraceSphereElement WaterSphereTrace;

	// Token: 0x0400C4FF RID: 50431
	public global::ECharMoveState? AccelerationChangeMoveState;

	// Token: 0x0400C500 RID: 50432
	[Nullable(2)]
	protected UCurveFloat AccelerationLerpCurve;

	// Token: 0x0400C501 RID: 50433
	protected float FallingHorizontalMaxSpeed = 700f;

	// Token: 0x0400C502 RID: 50434
	protected float DesireMaxAccelerationLerpTime;

	// Token: 0x0400C503 RID: 50435
	protected float MaxAccelerationLerpTime;

	// Token: 0x0400C504 RID: 50436
	private bool IsNeedDelayCheckWalkOffLedge;

	// Token: 0x0400C505 RID: 50437
	private int WalkOffLedgeCheckFrame;

	// Token: 0x0400C506 RID: 50438
	protected float TurnRate = 1f;

	// Token: 0x0400C507 RID: 50439
	public bool IsRegionMoveMode;

	// Token: 0x0400C508 RID: 50440
	protected readonly global::Vector GravityDirectInternal = global::Vector.Create(0.0, 0.0, -1.0);

	// Token: 0x0400C509 RID: 50441
	protected readonly global::Vector GravityUpInternal = global::Vector.Create(0.0, 0.0, 1.0);

	// Token: 0x0400C50A RID: 50442
	protected bool IsStandardGravityInternal = true;

	// Token: 0x0400C50B RID: 50443
	[Nullable(2)]
	protected TimerHandle JumpDelayTimer;

	// Token: 0x0400C50C RID: 50444
	public float GroundedTimeUe;

	// Token: 0x0400C50D RID: 50445
	protected int VelocityAdditionIncId = 1;

	// Token: 0x0400C50E RID: 50446
	protected static global::Vector VelocityAdditionTotal;

	// Token: 0x0400C50F RID: 50447
	protected static global::Vector VelocityAdditionDestination;

	// Token: 0x0400C510 RID: 50448
	protected readonly Dictionary<int, VelocityAddition> VelocityAdditionMap = new Dictionary<int, VelocityAddition>();

	// Token: 0x0400C511 RID: 50449
	protected readonly Dictionary<UMeshComponent, int> VelocityAdditionMapByMesh = new Dictionary<UMeshComponent, int>();

	// Token: 0x0400C512 RID: 50450
	protected FVectorDouble? AddMoveOffset;

	// Token: 0x0400C513 RID: 50451
	protected global::Rotator AddMoveRotation = global::Rotator.Create();

	// Token: 0x0400C514 RID: 50452
	[Nullable(2)]
	public GravityScale CurrentGravityScale;

	// Token: 0x0400C515 RID: 50453
	private bool HasInputPrevFrame;

	// Token: 0x0400C516 RID: 50454
	protected Dictionary<string, bool> PauseLocks = new Dictionary<string, bool>();

	// Token: 0x0400C517 RID: 50455
	protected float MaxMoveDegree;

	// Token: 0x0400C518 RID: 50456
	protected float InputScale = 1f;
}
