using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.Role.Common;
using AkiClient.Game.Aki.Data.Fight.AssestStruct;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using UnrealEngine;

// Token: 0x0200306C RID: 12396
[NullableContext(1)]
[Nullable(0)]
public class CharacterSplineMoveComponent : BaseSplineMoveComponent, IStaticVariableResetter
{
	// Token: 0x06019796 RID: 104342 RVA: 0x0075DAB8 File Offset: 0x0075BCB8
	static CharacterSplineMoveComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterSplineMoveComponent.CreateStaticDefaultValue), new Action(CharacterSplineMoveComponent.ResetStaticDefaultValue));
	}

	// Token: 0x17002259 RID: 8793
	// (get) Token: 0x06019797 RID: 104343 RVA: 0x0075DAE7 File Offset: 0x0075BCE7
	public static BP_SplineMoveConfig_C SplineMoveConfig
	{
		get
		{
			if (CharacterSplineMoveComponent.SplineMoveConfigInternal == null)
			{
				CharacterSplineMoveComponent.SplineMoveConfigInternal = Singleton<ResourceSystem>.Instance.GetLoadedAsset<BP_SplineMoveConfig_C>(CharacterSplineMoveComponent.DaPath);
			}
			return CharacterSplineMoveComponent.SplineMoveConfigInternal;
		}
	}

	// Token: 0x06019798 RID: 104344 RVA: 0x0075DB0C File Offset: 0x0075BD0C
	protected override bool OnStart()
	{
		base.OnStart();
		CharacterActorComponent characterActorComponent = this.ActorComp as CharacterActorComponent;
		if (characterActorComponent != null)
		{
			this.CharActorComp = characterActorComponent;
		}
		this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		this.UnifiedComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.AttributeComp = base.Entity.GetComponent<BaseAttributeComponent>();
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		return true;
	}

	// Token: 0x06019799 RID: 104345 RVA: 0x0075DB9D File Offset: 0x0075BD9D
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		return base.OnEnd();
	}

	// Token: 0x0601979A RID: 104346 RVA: 0x0075DBC8 File Offset: 0x0075BDC8
	protected override void PositionAdjust(float timeKey, float deltaSeconds)
	{
		switch (base.CurrentSplineMoveType)
		{
		case ESplineMovePattern.PathLine:
		case ESplineMovePattern.SlideTrack:
			this.PositionAdjustCommon(timeKey, deltaSeconds);
			return;
		case ESplineMovePattern.RacingTrack:
			this.PositionAdjustRacingTrack(timeKey, deltaSeconds);
			return;
		case ESplineMovePattern.AirPassage:
			this.PositionAdjustAirPassage(timeKey, deltaSeconds);
			return;
		default:
			return;
		}
	}

	// Token: 0x0601979B RID: 104347 RVA: 0x0075DC10 File Offset: 0x0075BE10
	private void PositionAdjustRacingTrack(float timeKey, float deltaSeconds)
	{
		this.TargetLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		this.RacingLeftRight(deltaSeconds);
		if (!base.CheckAndLimitOnlyForwardMove() && this.LastSplineDirection.Normalize(9.99999993922529E-09))
		{
			this.CommonVelocityAdjusted();
			this.AdjustTargetLocationRacingTrack();
		}
		base.LimitMaxMove();
		this.MoveToTargetLocation(deltaSeconds);
	}

	// Token: 0x0601979C RID: 104348 RVA: 0x0075DC74 File Offset: 0x0075BE74
	protected void PositionAdjustAirPassage(float timeKey, float deltaSeconds)
	{
		if (!this.CurrentSplineMoveParamsInternal.NeedLimitSoarTransform)
		{
			return;
		}
		CharacterUnifiedStateComponent unifiedComp = this.UnifiedComp;
		if (unifiedComp == null || unifiedComp.MoveState != global::ECharMoveState.Soar)
		{
			return;
		}
		if (this.SplineDirection.Equals(global::Vector.ZeroVectorProxy, 9.999999747378752E-05))
		{
			return;
		}
		this.TargetLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		base.CheckAndLimitOnlyForwardMove();
		this.TargetLocation.Subtraction(this.SplineLocation, this.OffsetVector);
		this.UpdateCrossSectionParamsAirPassage();
		this.RotationAndVelocityAdjustAirPassage();
		this.LimitCircleAxisMove();
		this.MoveToTargetLocation(deltaSeconds);
	}

	// Token: 0x0601979D RID: 104349 RVA: 0x0075DD18 File Offset: 0x0075BF18
	protected void RotationAndVelocityAdjustAirPassage()
	{
		SplineMoveParams currentSplineMoveParamsInternal = this.CurrentSplineMoveParamsInternal;
		CurveBase edgeLimitCurve = this.CurrentSplineMoveParamsInternal.EdgeLimitCurve;
		float num = (this.CurMaxWidth != 0f) ? edgeLimitCurve.GetCurrentValue((float)Math.Abs(this.LocalOffset.Y) / this.CurMaxWidth) : 1f;
		float num2 = (this.CurMaxHeight != 0f) ? edgeLimitCurve.GetCurrentValue((float)Math.Abs(this.LocalOffset.Z) / this.CurMaxHeight) : 1f;
		float num3 = -currentSplineMoveParamsInternal.InputLimitAngle;
		float num4 = currentSplineMoveParamsInternal.InputLimitAngle;
		float num5 = -currentSplineMoveParamsInternal.InputLimitAngle;
		float num6 = currentSplineMoveParamsInternal.InputLimitAngle;
		if (this.LocalOffset.Y < 0.0)
		{
			num3 *= 1f - num;
		}
		else
		{
			num4 *= 1f - num;
		}
		this.TmpVector1.DeepCopy(this.ActorComp.ActorForwardProxy);
		Singleton<GravityUtils>.Instance.GetBaseQuatInGravityForActor(this.ActorComp, this.TmpQuat);
		this.TmpQuat.Inverse(this.TmpQuat1);
		this.TmpQuat1.RotateVector(this.ActorComp.ActorForwardProxy, this.TmpVector1);
		double num7 = this.TmpVector1.HeadingAngle() * 57.295780181884766;
		this.TmpQuat1.RotateVector(this.SplineDirection, this.TmpVector1);
		double num8 = this.TmpVector1.HeadingAngle() * 57.295780181884766;
		double minAngle = num8 + (double)num3;
		double maxAngle = num8 + (double)num4;
		if (!this.InAngleRange(num7, minAngle, maxAngle))
		{
			double angleB = this.ClampAngle(num7, minAngle, maxAngle);
			double num9 = this.LerpAngle(num7, angleB, (double)num);
			double num10 = Singleton<MathUtils>.Instance.WrapAngle(num9 - num7);
			this.TmpRotator.Set(0f, (float)num10, 0f);
			BaseActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.AddActorLocalRotation(this.TmpRotator.ToUeRotator(), "轨道模式修正", true);
			}
			this.TmpQuat1.RotateVector(this.CharActorComp.ActorVelocityProxy, this.TmpVector1);
			this.TmpRotator.Quaternion(this.TmpQuat1);
			this.TmpQuat1.RotateVector(this.TmpVector1, this.TmpVector);
			this.TmpQuat.RotateVector(this.TmpVector, this.TmpVector1);
			CharacterMoveComponent moveComp = this.MoveComp;
			if (moveComp != null)
			{
				moveComp.SetForceSpeed(this.TmpVector1);
			}
			if (this.DebugMode)
			{
				this.TmpQuat1.RotateVector(this.ActorComp.ActorForwardProxy, this.TmpVector1);
				this.TmpVector1.HeadingAngle();
			}
		}
		if (this.LocalOffset.Z < 0.0)
		{
			num5 *= 1f - num2;
		}
		else
		{
			num6 *= 1f - num2;
		}
		this.CharActorComp.ActorVelocityProxy.GetSafeNormal(this.TmpVector1, 9.99999993922529E-09);
		double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.TmpVector1);
		float num11 = (float)(Math.Asin(Singleton<MathUtils>.Instance.Clamp(znInGravityForActor, -1.0, 1.0)) * 57.295780181884766);
		double znInGravityForActor2 = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.SplineDirection);
		float num12 = (float)(Math.Asin(Singleton<MathUtils>.Instance.Clamp(znInGravityForActor2, -1.0, 1.0)) * 57.295780181884766);
		float num13 = num12 + num5;
		float num14 = num12 + num6;
		if (!this.InAngleRange((double)num11, (double)num13, (double)num14))
		{
			double angleB2 = this.ClampAngle((double)num11, (double)num13, (double)num14);
			double num15 = this.LerpAngle((double)num11, angleB2, (double)num2);
			Singleton<MathUtils>.Instance.WrapAngle(num15 - (double)num11);
			double inB = this.CharActorComp.ActorVelocityProxy.Size();
			this.TmpRotator.Set((float)num15, 0f, 0f);
			this.TmpRotator.Quaternion(this.TmpQuat);
			this.ActorComp.ActorQuatProxy.Multiply(this.TmpQuat, this.TmpQuat1);
			this.TmpQuat1.GetForwardVector(this.TmpVector1);
			this.TmpVector1.MultiplyEqual(inB);
			this.MoveComp.SetForceSpeed(this.TmpVector1);
			if (this.DebugMode)
			{
				this.TmpQuat1.Rotator(this.TmpRotator);
			}
		}
	}

	// Token: 0x0601979E RID: 104350 RVA: 0x0075E180 File Offset: 0x0075C380
	protected void UpdateCrossSectionParamsAirPassage()
	{
		Singleton<MathUtils>.Instance.LookRotationUpFirst(this.SplineDirection, this.MoveComp.GravityUp, this.LocalQuat);
		this.LocalQuat.GetForwardVector(this.TmpVector);
		this.TmpVector.Multiply(this.OffsetVector.DotProduct(this.TmpVector), this.TmpVector1);
		this.OffsetVector.SubtractionEqual(this.TmpVector1);
		this.LocalQuat.Inverse(this.TmpQuat1);
		this.TmpQuat1.RotateVector(this.OffsetVector, this.LocalOffset);
		SplineMoveParams currentSplineMoveParamsInternal = this.CurrentSplineMoveParamsInternal;
		double znInGravityForActor = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.SplineDirection);
		if (Math.Abs(znInGravityForActor) > 0.7070000171661377)
		{
			this.CurShortLen = 0f;
			this.CurLongLen = 0f;
			this.CurMaxWidth = 0f;
			this.CurMaxHeight = 0f;
			return;
		}
		this.CurShortLen = currentSplineMoveParamsInternal.MaxOffsetDist;
		this.CurLongLen = this.CurShortLen / (float)Math.Sqrt(1.0 - znInGravityForActor * znInGravityForActor);
		double y = this.LocalOffset.Y;
		double z = this.LocalOffset.Z;
		float curShortLen = this.CurShortLen;
		float curLongLen = this.CurLongLen;
		double num = (double)(curShortLen * curShortLen) - (double)(curShortLen * curShortLen) * z * z / (double)(curLongLen * curLongLen);
		double num2 = (double)(curLongLen * curLongLen) - (double)(curLongLen * curLongLen) * y * y / (double)(curShortLen * curShortLen);
		this.CurMaxWidth = ((num <= 0.0) ? 0f : ((float)Math.Sqrt(num)));
		this.CurMaxHeight = ((num2 <= 0.0) ? 0f : ((float)Math.Sqrt(num2)));
		if (this.DebugMode)
		{
			this.DrawDebugInfo();
		}
	}

	// Token: 0x0601979F RID: 104351 RVA: 0x0075E354 File Offset: 0x0075C554
	protected void LimitCircleAxisMove()
	{
		if (this.IsInEllipseRange(this.LocalOffset.Y, this.LocalOffset.Z, (double)this.CurShortLen, (double)this.CurLongLen))
		{
			return;
		}
		if (Math.Abs(this.LocalOffset.Y) < 1.0)
		{
			float val = (float)Math.Abs(this.LocalOffset.Z);
			float num = (float)Math.Sign(this.LocalOffset.Z) * Math.Max(this.CurLongLen, val);
			double addZ = (double)num - this.LocalOffset.Z;
			Singleton<GravityUtils>.Instance.SetZnInGravityForActor(this.ActorComp, this.OffsetVector, (double)num);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, this.TargetLocation, addZ);
			return;
		}
		double num2 = this.LocalOffset.Z / this.LocalOffset.Y;
		float curShortLen = this.CurShortLen;
		float curLongLen = this.CurLongLen;
		double d = 1.0 / ((double)(1f / (curShortLen * curShortLen)) + num2 * num2 / (double)(curLongLen * curLongLen));
		float num3 = (float)Math.Sign(this.LocalOffset.Y) * (float)Math.Sqrt(d);
		this.LocalOffset.Set(0.0, (double)num3, num2 * (double)num3);
		this.LocalQuat.RotateVector(this.LocalOffset, this.TmpVector);
		this.TmpVector.Subtraction(this.OffsetVector, this.TmpVector1);
		this.OffsetVector.DeepCopy(this.TmpVector);
		this.TargetLocation.AdditionEqual(this.TmpVector1);
	}

	// Token: 0x060197A0 RID: 104352 RVA: 0x0075E4F0 File Offset: 0x0075C6F0
	protected void DrawDebugInfo()
	{
		BaseActorComponent actorComp = this.ActorComp;
		UKismetSystemLibrary.DrawDebugArrow((actorComp != null) ? actorComp.Owner : null, this.SplineLocation.ToUeVectorOld(), this.TargetLocation.ToUeVectorOld(), 10f, new FLinearColor(0f, 0f, 1f, 1f), 1f, 5f);
		this.LocalQuat.GetRightVector(this.TmpVector);
		this.TmpVector.MultiplyEqual((double)this.CurShortLen);
		this.TmpVector.AdditionEqual(this.SplineLocation);
		BaseActorComponent actorComp2 = this.ActorComp;
		UKismetSystemLibrary.DrawDebugArrow((actorComp2 != null) ? actorComp2.Owner : null, this.SplineLocation.ToUeVectorOld(), this.TmpVector.ToUeVectorOld(), 10f, new FLinearColor(1f, 0f, 0f, 1f), 1f, 5f);
		this.LocalQuat.GetUpVector(this.TmpVector);
		this.TmpVector.MultiplyEqual((double)this.CurLongLen);
		this.TmpVector.AdditionEqual(this.SplineLocation);
		BaseActorComponent actorComp3 = this.ActorComp;
		UKismetSystemLibrary.DrawDebugArrow((actorComp3 != null) ? actorComp3.Owner : null, this.SplineLocation.ToUeVectorOld(), this.TmpVector.ToUeVectorOld(), 10f, new FLinearColor(0f, 1f, 0f, 1f), 1f, 5f);
	}

	// Token: 0x060197A1 RID: 104353 RVA: 0x0075E66C File Offset: 0x0075C86C
	protected bool IsInEllipseRange(double x, double y, double a, double b)
	{
		return !Singleton<MathUtils>.Instance.IsNearlyZero(a, null) && !Singleton<MathUtils>.Instance.IsNearlyZero(b, null) && x * x / (a * a) + y * y / (b * b) <= 1.0;
	}

	// Token: 0x060197A2 RID: 104354 RVA: 0x0075E6C8 File Offset: 0x0075C8C8
	protected override void PositionAdjustCommon(float timeKey, float deltaSeconds)
	{
		this.TargetLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		if (!base.CheckAndLimitOnlyForwardMove() && this.LastSplineDirection.Normalize(9.99999993922529E-09))
		{
			this.CommonVelocityAdjusted();
		}
		base.LimitMaxMove();
		this.MoveToTargetLocation(deltaSeconds);
	}

	// Token: 0x060197A3 RID: 104355 RVA: 0x0075E71C File Offset: 0x0075C91C
	protected override void MoveToTargetLocation(float deltaSeconds)
	{
		if (global::Vector.DistSquared(this.ActorComp.ActorLocationProxy, this.TargetLocation) <= 1E-08)
		{
			return;
		}
		if (this.MoveComp == null)
		{
			this.ActorComp.SetActorLocation(this.TargetLocation.ToUeVector(false), "样条移动", false);
			return;
		}
		this.TargetLocation.Subtraction(this.ActorComp.ActorLocationProxy, this.OffsetVector);
		this.MoveComp.MoveCharacter(this.OffsetVector, deltaSeconds, "");
	}

	// Token: 0x060197A4 RID: 104356 RVA: 0x0075E7A8 File Offset: 0x0075C9A8
	private void CommonVelocityAdjusted()
	{
		if (this.CharActorComp == null)
		{
			return;
		}
		this.TmpVector.DeepCopy(this.CharActorComp.ActorVelocityProxy);
		Quat.FindBetween(this.LastSplineDirection, this.SplineDirection, this.TmpQuat);
		this.TmpQuat.RotateVector(this.TmpVector, this.TmpVector);
		this.CharActorComp.SetActorVelocity(this.TmpVector);
	}

	// Token: 0x060197A5 RID: 104357 RVA: 0x0075E814 File Offset: 0x0075CA14
	private void AdjustTargetLocationRacingTrack()
	{
		if (this.CurrentSplineMoveParamsInternal.Type != ESplineMovePattern.RacingTrack)
		{
			return;
		}
		if (!this.LastSplineDirection.Normalize(9.99999993922529E-09))
		{
			return;
		}
		this.TargetLocation.Subtraction(this.LastSplineLocation, this.OffsetVector);
		this.OffsetVector.Z = 0.0;
		this.LastSplineDirection.Multiply(this.OffsetVector.DotProduct(this.LastSplineDirection), this.TmpVector);
		this.OffsetVector.SubtractionEqual(this.TmpVector);
		this.TmpQuat.RotateVector(this.OffsetVector, this.TmpVector);
		double z = this.TargetLocation.Z;
		this.SplineLocation.Addition(this.TmpVector, this.TargetLocation);
		this.TargetLocation.Z = z;
	}

	// Token: 0x060197A6 RID: 104358 RVA: 0x0075E8F0 File Offset: 0x0075CAF0
	private void RacingLeftRight(float deltaSeconds)
	{
		if (this.CharActorComp == null || this.CurrentSplineMoveParamsInternal.Type != ESplineMovePattern.RacingTrack)
		{
			return;
		}
		global::Vector inputDirectProxy = this.CharActorComp.InputDirectProxy;
		this.TmpVector.X = -this.SplineDirection.Y;
		this.TmpVector.Y = this.SplineDirection.X;
		this.TmpVector.Z = 0.0;
		double num = this.TmpVector.DotProduct(inputDirectProxy);
		if (num < (double)(-(double)this.CurrentSplineMoveParamsInternal.InputLimitSin))
		{
			num = (double)(-(double)this.CurrentSplineMoveParamsInternal.InputLimitSin);
		}
		else if (num > (double)this.CurrentSplineMoveParamsInternal.InputLimitSin)
		{
			num = (double)this.CurrentSplineMoveParamsInternal.InputLimitSin;
		}
		double num2 = (double)this.MoveComp.CharacterMovement.MaxWalkSpeed * num;
		float maxAcceleration = this.MoveComp.CharacterMovement.MaxAcceleration;
		double num3 = num2 - (double)this.LastRightSpeed;
		float num4 = maxAcceleration * deltaSeconds;
		float num5;
		if (Math.Abs(num3) > (double)num4)
		{
			if (num3 * (double)this.LastRightSpeed < 0.0)
			{
				num5 = this.LastRightSpeed * (float)Math.Pow(0.9599999785423279, (double)(deltaSeconds * 60f));
			}
			else
			{
				num5 = this.LastRightSpeed;
			}
			num5 += (float)Math.Sign(num3) * num4;
		}
		else
		{
			num5 = (float)num2;
		}
		this.TmpVector.MultiplyEqual((double)((this.LastRightSpeed + num5) / 2f * deltaSeconds));
		this.TargetLocation.AdditionEqual(this.TmpVector);
		this.LastRightSpeed = num5;
	}

	// Token: 0x060197A7 RID: 104359 RVA: 0x0075EA78 File Offset: 0x0075CC78
	protected override void InputAdjust()
	{
		if (this.CharActorComp == null)
		{
			return;
		}
		if (base.CurrentSplineMoveType == ESplineMovePattern.AirPassage)
		{
			return;
		}
		CharacterUnifiedStateComponent unifiedComp = this.UnifiedComp;
		if (unifiedComp != null && unifiedComp.PositionState == global::ECharPositionState.Climb)
		{
			this.InputAdjustClimbState();
			return;
		}
		this.InputAdjustWithSplineType(this.CharActorComp.InputDirectProxy);
	}

	// Token: 0x060197A8 RID: 104360 RVA: 0x0075EAC8 File Offset: 0x0075CCC8
	private void InputAdjustClimbState()
	{
		global::Vector inputDirectProxy = this.CharActorComp.InputDirectProxy;
		SplineMoveParams currentSplineMoveParams = base.CurrentSplineMoveParams;
		if (currentSplineMoveParams == null || !currentSplineMoveParams.IsAdaptiveClimbInput)
		{
			ModelBase<CameraModel>.Instance.MainModel.CameraRotator.Quaternion(this.TmpQuat);
			this.TmpQuat.RotateVector(inputDirectProxy, this.TmpVector);
			this.CharActorComp.SetInputDirect(this.TmpVector, false);
			this.InputAdjustWithSplineType(inputDirectProxy);
			this.ActorComp.ActorQuatProxy.Inverse(this.TmpQuat);
			this.TmpQuat.RotateVector(inputDirectProxy, this.TmpVector);
			this.TmpVector.Z = 0.0;
			this.CharActorComp.SetInputDirect(this.TmpVector, false);
			return;
		}
		this.TmpVector.Z = inputDirectProxy.X;
		this.TmpVector.Y = inputDirectProxy.Y;
		this.TmpVector.X = 0.0;
		ModelBase<CameraModel>.Instance.MainModel.CameraRotator.Quaternion(this.TmpQuat);
		this.TmpQuat.RotateVector(this.TmpVector, this.TmpVector);
		this.ActorComp.ActorQuatProxy.UnRotateVector(this.TmpVector, this.TmpVector);
		if (Singleton<MathUtils>.Instance.IsNearlyZero(this.TmpVector.Y, null) && Singleton<MathUtils>.Instance.IsNearlyZero(this.TmpVector.Z, null))
		{
			this.CharActorComp.SetInputDirect(this.TmpVector, false);
			return;
		}
		double num = Math.Atan2(this.TmpVector.X, this.TmpVector.Z) * 57.295780181884766;
		if (num > -30.0 && num < 150.0)
		{
			this.CharActorComp.SetInputDirect(global::Vector.ForwardVectorProxy, false);
			return;
		}
		this.CharActorComp.SetInputDirect(global::Vector.BackwardVectorProxy, false);
	}

	// Token: 0x060197A9 RID: 104361 RVA: 0x0075ECE0 File Offset: 0x0075CEE0
	private void InputAdjustWithSplineType(global::Vector inputDirect)
	{
		switch (this.CurrentSplineMoveParamsInternal.Type)
		{
		case ESplineMovePattern.PathLine:
			this.InputAdjustPathLine(inputDirect);
			return;
		case ESplineMovePattern.RacingTrack:
			this.InputAdjustRacingTrack(inputDirect);
			return;
		case ESplineMovePattern.SlideTrack:
			this.InputAdjustSlideTrack(inputDirect);
			return;
		default:
			return;
		}
	}

	// Token: 0x060197AA RID: 104362 RVA: 0x0075ED24 File Offset: 0x0075CF24
	private void InputAdjustSlideTrack(global::Vector inputDirect)
	{
		SplineMoveParams currentSplineMoveParamsInternal = this.CurrentSplineMoveParamsInternal;
		this.SplineQuat.Inverse(this.TmpQuat);
		this.ActorComp.ActorLocationProxy.Subtraction(this.SplineLocation, this.TmpVector);
		this.TmpQuat.RotateVector(this.TmpVector, this.TmpVector);
		float currentValue = currentSplineMoveParamsInternal.EdgeLimitCurve.GetCurrentValue((float)Math.Abs(this.TmpVector.Y) / currentSplineMoveParamsInternal.MaxOffsetDist);
		float num = -currentSplineMoveParamsInternal.InputLimitAngle;
		float num2 = currentSplineMoveParamsInternal.InputLimitAngle;
		if (this.TmpVector.Y < 0.0)
		{
			num *= 1f - currentValue;
		}
		else
		{
			num2 *= 1f - currentValue;
		}
		this.MinTurnAngle = num;
		this.MaxTurnAngle = num2;
		if (inputDirect.IsNearlyZero(9.999999747378752E-05))
		{
			this.SplineQuat.RotateVector(global::Vector.ForwardVectorProxy, this.TmpVector);
			this.CharActorComp.SetInputDirect(this.TmpVector, false);
			this.CharActorComp.SetInputFacing(this.TmpVector, true);
			return;
		}
		ModelBase<CameraModel>.Instance.MainModel.CameraRotator.Quaternion(this.TmpQuat);
		this.TmpQuat.RotateVector(global::Vector.ForwardVectorProxy, this.TmpVector);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.TmpVector);
		if (this.TmpVector.IsNearlyZero(9.999999747378752E-05))
		{
			this.TmpQuat.RotateVector(global::Vector.UpVectorProxy, this.TmpVector);
		}
		this.ActorComp.ActorGravityDirectProxy.UnaryNegation(this.TmpVector1);
		Singleton<MathUtils>.Instance.LookRotationUpFirst(this.TmpVector, this.TmpVector1, this.TmpQuat);
		this.TmpQuat.Inverse(this.TmpQuat);
		this.TmpQuat.RotateVector(inputDirect, this.TmpVector);
		double currentValue2 = this.TmpVector.HeadingAngle() * 57.295780181884766;
		float num3 = (float)(Singleton<MathUtils>.Instance.Clamp(currentValue2, (double)num, (double)num2) * 0.01745329238474369);
		this.TmpVector.Set((double)((float)Math.Cos((double)num3)), (double)((float)Math.Sin((double)num3)), 0.0);
		this.SplineQuat.RotateVector(this.TmpVector, this.TmpVector);
		this.CharActorComp.SetInputDirect(this.TmpVector, false);
		this.CharActorComp.SetInputFacing(this.TmpVector, true);
	}

	// Token: 0x060197AB RID: 104363 RVA: 0x0075EFAC File Offset: 0x0075D1AC
	private void InputAdjustPathLine(global::Vector inputDirect)
	{
		SplineMoveParams currentSplineMoveParamsInternal = this.CurrentSplineMoveParamsInternal;
		if (inputDirect.IsNearlyZero(9.999999747378752E-05))
		{
			this.InputAdjustPathLineFacing(currentSplineMoveParamsInternal);
			return;
		}
		double value = inputDirect.DotProduct(this.SplineDirection);
		float num;
		if (currentSplineMoveParamsInternal.OnlyForward)
		{
			if (inputDirect.DotProduct(this.SplineDirection) < 0.7070000171661377)
			{
				this.CharActorComp.ClearInput(true, true);
				this.InputAdjustPathLineFacing(currentSplineMoveParamsInternal);
				return;
			}
			num = 1f;
		}
		else
		{
			if (Math.Abs(value) < 0.7070000171661377)
			{
				this.CharActorComp.ClearInput(true, true);
				this.InputAdjustPathLineFacing(currentSplineMoveParamsInternal);
				return;
			}
			num = (float)Math.Sign(value);
		}
		this.SplineDirection.Multiply((double)(num * 500f), this.TmpVector);
		this.TmpVector.AdditionEqual(this.SplineLocation);
		this.TmpVector.SubtractionEqual(this.TargetLocation);
		this.TmpVector.Z = 0.0;
		this.TmpVector.Normalize(9.99999993922529E-09);
		this.CharActorComp.SetInputDirect(this.TmpVector, false);
		this.CharActorComp.SetInputFacing(this.TmpVector, true);
		this.InputAdjustPathLineFacing(currentSplineMoveParamsInternal);
	}

	// Token: 0x060197AC RID: 104364 RVA: 0x0075F0EC File Offset: 0x0075D2EC
	private void InputAdjustPathLineFacing(SplineMoveParams @params)
	{
		EPathLineFacingType? adjustFacingType = @params.AdjustFacingType;
		if (adjustFacingType != null)
		{
			EPathLineFacingType valueOrDefault = adjustFacingType.GetValueOrDefault();
			if (valueOrDefault != EPathLineFacingType.Current)
			{
				if (valueOrDefault != EPathLineFacingType.Custom)
				{
					return;
				}
				this.TmpVector.Set((double)((float)Math.Cos((double)(0.017453292f * @params.AdjustFacingLimit))), (double)((float)Math.Sin((double)(0.017453292f * @params.AdjustFacingLimit))), 0.0);
				this.CharActorComp.SetInputFacing(this.TmpVector, true);
			}
			else if (Math.Abs(this.SplineDirection.DotProduct(this.MoveComp.GravityUp)) < 0.9999)
			{
				Singleton<MathUtils>.Instance.LookRotationUpFirst(this.SplineDirection, this.MoveComp.GravityUp, this.TmpQuat);
				this.TmpVector1.Set((double)((float)Math.Cos((double)(0.017453292f * @params.AdjustFacingLimit))), (double)((float)Math.Sin((double)(0.017453292f * @params.AdjustFacingLimit))), 0.0);
				this.TmpQuat.RotateVector(this.TmpVector1, this.TmpVector);
				this.CharActorComp.SetInputFacing(this.TmpVector, true);
				return;
			}
		}
	}

	// Token: 0x060197AD RID: 104365 RVA: 0x0075F228 File Offset: 0x0075D428
	private void InputAdjustRacingTrack(global::Vector inputDirect)
	{
		SplineMoveParams currentSplineMoveParamsInternal = this.CurrentSplineMoveParamsInternal;
		this.CharActorComp.SetInputFacing(this.SplineDirection, true);
		if (inputDirect.IsNearlyZero(9.999999747378752E-05))
		{
			this.LastForward = true;
			this.CharActorComp.SetInputDirect(this.SplineDirection, false);
			return;
		}
		double num = this.SplineDirection.DotProduct(inputDirect);
		if (currentSplineMoveParamsInternal.OnlyForward || num > (double)(this.LastForward ? -0.5f : 0.5f))
		{
			this.LastForward = true;
			this.CharActorComp.SetInputDirect(this.SplineDirection, false);
			return;
		}
		this.LastForward = false;
		this.SplineDirection.UnaryNegation(this.TmpVector);
		this.CharActorComp.SetInputDirect(this.TmpVector, false);
	}

	// Token: 0x060197AE RID: 104366 RVA: 0x0075F300 File Offset: 0x0075D500
	protected double NormalizeAngle(double angle)
	{
		double num = angle % 360.0;
		if (num < 0.0)
		{
			num += 360.0;
		}
		return num;
	}

	// Token: 0x060197AF RID: 104367 RVA: 0x0075F334 File Offset: 0x0075D534
	protected bool InAngleRange(double angle, double minAngle, double maxAngle)
	{
		double num = this.NormalizeAngle(maxAngle - minAngle);
		return this.NormalizeAngle(angle - minAngle) < num;
	}

	// Token: 0x060197B0 RID: 104368 RVA: 0x0075F358 File Offset: 0x0075D558
	protected double ClampAngle(double angle, double minAngle, double maxAngle)
	{
		if (this.InAngleRange(angle, minAngle, maxAngle))
		{
			return Singleton<MathUtils>.Instance.WrapAngle(angle);
		}
		float num = (float)Math.Abs(Singleton<MathUtils>.Instance.WrapAngle(angle - minAngle));
		float num2 = (float)Math.Abs(Singleton<MathUtils>.Instance.WrapAngle(angle - maxAngle));
		if (num >= num2)
		{
			return Singleton<MathUtils>.Instance.WrapAngle(maxAngle);
		}
		return Singleton<MathUtils>.Instance.WrapAngle(minAngle);
	}

	// Token: 0x060197B1 RID: 104369 RVA: 0x0075F3BD File Offset: 0x0075D5BD
	protected double LerpAngle(double angleA, double angleB, double alpha)
	{
		return Singleton<MathUtils>.Instance.WrapAngle(angleA + Singleton<MathUtils>.Instance.WrapAngle(angleB - angleA) * alpha);
	}

	// Token: 0x060197B2 RID: 104370 RVA: 0x0075F3DC File Offset: 0x0075D5DC
	public unsafe override void StartSplineMoveInternal(SplineMoveParams config)
	{
		int id = config.Id;
		if (this.DisableKey != null)
		{
			base.Enable(new int?(this.DisableKey.Value), "SplineMoveComponent.StartSplineMoveInternal");
			this.DisableKey = null;
			this.OnSplineMoveEnable(id, config);
		}
		base.AddSplineMoveParams(id, config);
		base.SelectNextSplineMove();
		this.LastRightSpeed = 0f;
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Movement;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "StartSplineMove";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Spline Id", id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.ActorComp.Owner);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StackCount", this.SplineStack.Count);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x060197B3 RID: 104371 RVA: 0x0075F4CF File Offset: 0x0075D6CF
	public override bool IsPlannerMove()
	{
		return base.CurrentSplineMoveType != ESplineMovePattern.AirPassage;
	}

	// Token: 0x060197B4 RID: 104372 RVA: 0x0075F4DD File Offset: 0x0075D6DD
	protected void ApplySplineMoveDaConfig(SplineMoveParams config)
	{
		if (config.Type != ESplineMovePattern.PathLine)
		{
			return;
		}
		this.ApplySplineMoveDaConfigInternal(true, config);
	}

	// Token: 0x060197B5 RID: 104373 RVA: 0x0075F4F0 File Offset: 0x0075D6F0
	protected void ResetSplineMoveDaConfig()
	{
		this.ApplySplineMoveDaConfigInternal(false, null);
	}

	// Token: 0x060197B6 RID: 104374 RVA: 0x0075F4FC File Offset: 0x0075D6FC
	[NullableContext(2)]
	private void ApplySplineMoveDaConfigInternal(bool apply, SplineMoveParams config = null)
	{
		if (apply)
		{
			BP_SplineMoveConfig_C bp_SplineMoveConfig_C = null;
			if (!string.IsNullOrEmpty((config != null) ? config.ConfigDaPath : null))
			{
				bp_SplineMoveConfig_C = Singleton<ResourceSystem>.Instance.Load<BP_SplineMoveConfig_C>(config.ConfigDaPath, "js_undefined");
			}
			if (bp_SplineMoveConfig_C == null)
			{
				bp_SplineMoveConfig_C = CharacterSplineMoveComponent.SplineMoveConfig;
			}
			CharacterMoveComponent moveComp = this.MoveComp;
			if (moveComp != null)
			{
				moveComp.SetTurnRate(bp_SplineMoveConfig_C.TurnRate);
			}
			CharacterMoveComponent moveComp2 = this.MoveComp;
			if (moveComp2 != null)
			{
				moveComp2.SetAirControl(bp_SplineMoveConfig_C.AirControl);
			}
			CharacterMoveComponent moveComp3 = this.MoveComp;
			if (moveComp3 != null)
			{
				moveComp3.SetOverrideMaxFallingSpeed(bp_SplineMoveConfig_C.MaxFlySpeed);
			}
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null)
			{
				tagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.超级跳跃"]));
			}
			BaseAttributeComponent attributeComp = this.AttributeComp;
			if (attributeComp != null)
			{
				attributeComp.SetBaseValue(EAttributeType.Jump, 10000f * bp_SplineMoveConfig_C.JumpHeightRate);
			}
			CharacterAnimationComponent animComp = this.AnimComp;
			UAnimInstance uanimInstance = (animComp != null) ? animComp.MainAnimInstance : null;
			if (UKuroStaticLibrary.IsObjectClassByName(uanimInstance, Singleton<CharacterNameDefines>.Instance.ABP_BASEROLE))
			{
				ABP_BaseRole_C abp_BaseRole_C = uanimInstance as ABP_BaseRole_C;
				if (abp_BaseRole_C == null)
				{
					return;
				}
				abp_BaseRole_C.设置跳跃速率(bp_SplineMoveConfig_C.JumpTimeScale);
				return;
			}
		}
		else
		{
			CharacterMoveComponent moveComp4 = this.MoveComp;
			if (moveComp4 != null)
			{
				moveComp4.ResetTurnRate();
			}
			CharacterMoveComponent moveComp5 = this.MoveComp;
			if (moveComp5 != null)
			{
				moveComp5.ResetAirControl();
			}
			CharacterMoveComponent moveComp6 = this.MoveComp;
			if (moveComp6 != null)
			{
				moveComp6.ResetOverrideMaxFallingSpeed();
			}
			BaseTagComponent tagComp2 = this.TagComp;
			if (tagComp2 != null)
			{
				tagComp2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.超级跳跃"]));
			}
			BaseAttributeComponent attributeComp2 = this.AttributeComp;
			if (attributeComp2 != null)
			{
				attributeComp2.SetBaseValue(EAttributeType.Jump, 10000f);
			}
			CharacterAnimationComponent animComp2 = this.AnimComp;
			UAnimInstance uanimInstance2 = (animComp2 != null) ? animComp2.MainAnimInstance : null;
			if (UKuroStaticLibrary.IsObjectClassByName(uanimInstance2, Singleton<CharacterNameDefines>.Instance.ABP_BASEROLE))
			{
				ABP_BaseRole_C abp_BaseRole_C2 = uanimInstance2 as ABP_BaseRole_C;
				if (abp_BaseRole_C2 == null)
				{
					return;
				}
				abp_BaseRole_C2.设置跳跃速率(1f);
			}
		}
	}

	// Token: 0x060197B7 RID: 104375 RVA: 0x0075F6BC File Offset: 0x0075D8BC
	protected override void OnSplineMoveEnable(int id, SplineMoveParams config)
	{
		base.OnSplineMoveEnable(id, config);
		this.ApplySplineMoveDaConfig(config);
	}

	// Token: 0x060197B8 RID: 104376 RVA: 0x0075F6CD File Offset: 0x0075D8CD
	protected override void OnSplineMoveDisable()
	{
		base.OnSplineMoveDisable();
		this.ResetSplineMoveDaConfig();
	}

	// Token: 0x060197B9 RID: 104377 RVA: 0x0075F6DC File Offset: 0x0075D8DC
	protected override void OnSelectNextSplineMoveEnd()
	{
		if (!this.InheritThisFrame)
		{
			CharacterActorComponent charActorComp = this.CharActorComp;
			if (charActorComp != null)
			{
				charActorComp.ClearInput(false, true);
			}
			this.RefreshTurnAngleLimit();
		}
		RoleGaitComponent component = base.Entity.GetComponent<RoleGaitComponent>();
		if (component != null)
		{
			SplineMoveParams currentSplineMoveParams = base.CurrentSplineMoveParams;
			component.SetDisableStopAnim(currentSplineMoveParams != null && currentSplineMoveParams.IsDisableStopAnim);
		}
		CharacterClimbComponent component2 = base.Entity.GetComponent<CharacterClimbComponent>();
		if (component2 != null)
		{
			SplineMoveParams currentSplineMoveParams2 = base.CurrentSplineMoveParams;
			component2.SetIsAllowEarlyExitClimb(currentSplineMoveParams2 != null && currentSplineMoveParams2.IsAllowEarlyExitClimb);
		}
		base.OnSelectNextSplineMoveEnd();
	}

	// Token: 0x060197BA RID: 104378 RVA: 0x0075F760 File Offset: 0x0075D960
	private void RefreshTurnAngleLimit()
	{
		if (this.CurrentSplineMoveParamsInternal == null)
		{
			return;
		}
		this.MinTurnAngle = -this.CurrentSplineMoveParamsInternal.InputLimitAngle;
		this.MaxTurnAngle = this.CurrentSplineMoveParamsInternal.InputLimitAngle;
	}

	// Token: 0x060197BB RID: 104379 RVA: 0x0075F790 File Offset: 0x0075D990
	private unsafe void OnStateInherit(Entity oldEntity, bool notInheritMoveAndAnim)
	{
		CharacterSplineMoveComponent component = oldEntity.GetComponent<CharacterSplineMoveComponent>();
		if (component == null || !component.Active)
		{
			return;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Movement;
		ELogAuthor author = ELogAuthor.YJX;
		string message = "[CharacterSplineMoveComp] 轨道模式继承";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LastEntity", oldEntity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurEntity", base.Entity.Id);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.InheritThisFrame = true;
		foreach (int key in component.SplineStack)
		{
			SplineMoveParams splineMoveParams = component.SplineMoveParamsMap[key];
			if (splineMoveParams.AllowInherit)
			{
				base.InheritStartSplineMove(splineMoveParams);
			}
		}
		this.LastTimeKey = component.LastTimeKey;
		this.LastSplineLocation.DeepCopy(component.LastSplineLocation);
		this.LastSplineDirection.DeepCopy(component.LastSplineDirection);
		this.LastLocation.DeepCopy(component.LastLocation);
		this.LastRightSpeed = component.LastRightSpeed;
		this.LastForward = component.LastForward;
		foreach (int num in component.SplineStack)
		{
			if (component.SplineMoveParamsMap[num].AllowInherit)
			{
				component.EndSplineMove(num);
			}
		}
		this.InheritThisFrame = false;
	}

	// Token: 0x060197BC RID: 104380 RVA: 0x0075F940 File Offset: 0x0075DB40
	public static void CreateStaticDefaultValue()
	{
		CharacterSplineMoveComponent.SplineMoveConfigInternal = null;
	}

	// Token: 0x060197BD RID: 104381 RVA: 0x0075F948 File Offset: 0x0075DB48
	public static void ResetStaticDefaultValue()
	{
		CharacterSplineMoveComponent.SplineMoveConfigInternal = null;
	}

	// Token: 0x060197BE RID: 104382 RVA: 0x0075F950 File Offset: 0x0075DB50
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterSplineMoveComponent characterSplineMoveComponent = (CharacterSplineMoveComponent)componentTemplate;
		if (base.CanResetComponentProperty("CharActorComp"))
		{
			if (characterSplineMoveComponent.CharActorComp == null)
			{
				this.CharActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.CharActorComp), "CharActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedComp"))
		{
			if (characterSplineMoveComponent.UnifiedComp == null)
			{
				this.UnifiedComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedComp), "UnifiedComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (characterSplineMoveComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (characterSplineMoveComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AttributeComp"))
		{
			if (characterSplineMoveComponent.AttributeComp == null)
			{
				this.AttributeComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseAttributeComponent>(this.AttributeComp), "AttributeComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LastRightSpeed"))
		{
			this.LastRightSpeed = characterSplineMoveComponent.LastRightSpeed;
		}
		if (base.CanResetComponentProperty("LastForward"))
		{
			this.LastForward = characterSplineMoveComponent.LastForward;
		}
		if (base.CanResetComponentProperty("MinTurnAngle"))
		{
			this.MinTurnAngle = characterSplineMoveComponent.MinTurnAngle;
		}
		if (base.CanResetComponentProperty("MaxTurnAngle"))
		{
			this.MaxTurnAngle = characterSplineMoveComponent.MaxTurnAngle;
		}
		if (base.CanResetComponentProperty("CurMaxWidth"))
		{
			this.CurMaxWidth = characterSplineMoveComponent.CurMaxWidth;
		}
		if (base.CanResetComponentProperty("CurMaxHeight"))
		{
			this.CurMaxHeight = characterSplineMoveComponent.CurMaxHeight;
		}
		if (base.CanResetComponentProperty("CurLongLen"))
		{
			this.CurLongLen = characterSplineMoveComponent.CurLongLen;
		}
		if (base.CanResetComponentProperty("CurShortLen"))
		{
			this.CurShortLen = characterSplineMoveComponent.CurShortLen;
		}
		if (base.CanResetComponentProperty("LocalOffset"))
		{
			if (characterSplineMoveComponent.LocalOffset == null)
			{
				this.LocalOffset = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.LocalOffset), "LocalOffset"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LocalQuat"))
		{
			if (characterSplineMoveComponent.LocalQuat == null)
			{
				this.LocalQuat = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.LocalQuat), "LocalQuat"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DebugMode"))
		{
			this.DebugMode = characterSplineMoveComponent.DebugMode;
		}
		return true;
	}

	// Token: 0x0400C9E8 RID: 51688
	private const float COSINE_45 = 0.707f;

	// Token: 0x0400C9E9 RID: 51689
	private const float MAX_INPUT_COS = 0.707f;

	// Token: 0x0400C9EA RID: 51690
	private const float FORWARD_BACKWARD_THRESHOLD = 0.5f;

	// Token: 0x0400C9EB RID: 51691
	private const float FORECAST_DIST = 500f;

	// Token: 0x0400C9EC RID: 51692
	private const float DAMPING = 0.96f;

	// Token: 0x0400C9ED RID: 51693
	private const float STANDARD_FPS = 60f;

	// Token: 0x0400C9EE RID: 51694
	[StaticVariableRuleIgnore]
	public static readonly string DaPath = "/Game/Aki/Data/Fight/DA_SplineMoveConfig.DA_SplineMoveConfig";

	// Token: 0x0400C9EF RID: 51695
	[Nullable(2)]
	private static BP_SplineMoveConfig_C SplineMoveConfigInternal = null;

	// Token: 0x0400C9F0 RID: 51696
	[Nullable(2)]
	private CharacterActorComponent CharActorComp;

	// Token: 0x0400C9F1 RID: 51697
	[Nullable(2)]
	private CharacterUnifiedStateComponent UnifiedComp;

	// Token: 0x0400C9F2 RID: 51698
	[Nullable(2)]
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400C9F3 RID: 51699
	[Nullable(2)]
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400C9F4 RID: 51700
	[Nullable(2)]
	private BaseAttributeComponent AttributeComp;

	// Token: 0x0400C9F5 RID: 51701
	public float LastRightSpeed;

	// Token: 0x0400C9F6 RID: 51702
	protected bool LastForward = true;

	// Token: 0x0400C9F7 RID: 51703
	public float MinTurnAngle;

	// Token: 0x0400C9F8 RID: 51704
	public float MaxTurnAngle;

	// Token: 0x0400C9F9 RID: 51705
	public float CurMaxWidth;

	// Token: 0x0400C9FA RID: 51706
	public float CurMaxHeight;

	// Token: 0x0400C9FB RID: 51707
	public float CurLongLen;

	// Token: 0x0400C9FC RID: 51708
	public float CurShortLen;

	// Token: 0x0400C9FD RID: 51709
	public global::Vector LocalOffset = global::Vector.Create();

	// Token: 0x0400C9FE RID: 51710
	public Quat LocalQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400C9FF RID: 51711
	public bool DebugMode;
}
