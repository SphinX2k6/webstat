using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200329E RID: 12958
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleSplineMoveComponent : VehicleSplineMoveComponent
{
	// Token: 0x170024F3 RID: 9459
	// (get) Token: 0x0601B28A RID: 111242 RVA: 0x00828911 File Offset: 0x00826B11
	// (set) Token: 0x0601B28B RID: 111243 RVA: 0x0082891C File Offset: 0x00826B1C
	protected bool AutopilotBraking
	{
		get
		{
			return this.AutopilotBrakingInternal;
		}
		set
		{
			if (this.AutopilotBrakingInternal == value)
			{
				return;
			}
			this.AutopilotBrakingInternal = value;
			MotorcycleMoveComponent component = base.Entity.GetComponent<MotorcycleMoveComponent>();
			if (component != null)
			{
				component.BackBraking = value;
			}
		}
	}

	// Token: 0x170024F4 RID: 9460
	// (get) Token: 0x0601B28C RID: 111244 RVA: 0x00828950 File Offset: 0x00826B50
	// (set) Token: 0x0601B28D RID: 111245 RVA: 0x00828958 File Offset: 0x00826B58
	protected bool AutopilotSprint
	{
		get
		{
			return this.AutopilotSprintInternal;
		}
		set
		{
			if (this.AutopilotSprintInternal == value)
			{
				return;
			}
			this.AutopilotSprintInternal = value;
			if (value)
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp == null)
				{
					return;
				}
				tagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冲刺.路网自动"]));
				return;
			}
			else
			{
				BaseTagComponent tagComp2 = this.TagComp;
				if (tagComp2 == null)
				{
					return;
				}
				tagComp2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冲刺.路网自动"]));
				return;
			}
		}
	}

	// Token: 0x0601B28E RID: 111246 RVA: 0x008289C3 File Offset: 0x00826BC3
	protected override bool OnInit()
	{
		this.DetectedRecordList = new DoublyLinkedList<MotorcycleSplineMoveComponent.RoadBlockDetectRecord>(null);
		return base.OnInit();
	}

	// Token: 0x0601B28F RID: 111247 RVA: 0x008289D7 File Offset: 0x00826BD7
	protected override void PositionAdjust(float timeKey, float deltaSeconds)
	{
		this.CalAdjustRotation(timeKey, deltaSeconds);
		this.PositionAdjustCommon(timeKey, deltaSeconds);
	}

	// Token: 0x0601B290 RID: 111248 RVA: 0x008289EC File Offset: 0x00826BEC
	protected unsafe override void MoveToTargetLocation(float deltaSeconds)
	{
		if (this.IsDebug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "SplineMove MoveToTargetLocation";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TimeKey", this.SplineTimeKey);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Current", this.VehicleActorComp.ActorLocationProxy);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Target", this.TargetLocation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("QuatDelta", this.QuatDelta);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		if (this.TargetLocation.Equals(this.VehicleActorComp.ActorLocationProxy, 9.999999747378752E-05) && this.QuatDelta.Equals(Quat.IdentityProxy, 0.0001f))
		{
			return;
		}
		VehicleActorComponent vehicleActorComp = this.VehicleActorComp;
		UKuroVehicleMovementComponent ukuroVehicleMovementComponent;
		if (vehicleActorComp == null)
		{
			ukuroVehicleMovementComponent = null;
		}
		else
		{
			TsBaseVehicle vehicleOwner = vehicleActorComp.VehicleOwner;
			ukuroVehicleMovementComponent = ((vehicleOwner != null) ? vehicleOwner.VehicleMovementComponent : null);
		}
		UKuroVehicleMovementComponent ukuroVehicleMovementComponent2 = ukuroVehicleMovementComponent;
		if (ukuroVehicleMovementComponent2 == null)
		{
			base.MoveToTargetLocation(deltaSeconds);
			this.ActorComp.AddActorWorldRotation(this.QuatDelta.Rotator(null).ToUeRotator(), "MotorSplineMove", false);
			this.ActorComp.ResetRotationCachedTime();
			return;
		}
		this.TargetLocation.Subtraction(this.ActorComp.ActorLocationProxy, this.TmpVector);
		Vector tmpVector = this.TmpVector1;
		FVector motorNormal = ukuroVehicleMovementComponent2.GetMotorNormal();
		tmpVector.FromUeVector(motorNormal);
		double num = this.TmpVector.DotProduct(this.TmpVector1);
		if (num < 0.0)
		{
			this.MoveDelta.DeepCopy(this.TmpVector);
		}
		else
		{
			Vector.VectorPlaneProject(this.TmpVector, this.TmpVector1, this.MoveDelta);
		}
		if (this.IsDebug)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Test;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "SplineMove MoveToTargetLocation2";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("dot", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Offset", this.TmpVector);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Normal", this.TmpVector1);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("MoveDelta", this.MoveDelta);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
		}
		ukuroVehicleMovementComponent2.MoveMotorcycle(this.MoveDelta.ToUeVectorOld(), this.QuatDelta.ToUeQuat(), true);
		BaseActorComponent actorComp = this.ActorComp;
		if (((actorComp != null) ? actorComp.DebugMovementComp : null) != null)
		{
			this.ActorComp.DebugMovementComp.MarkDebugRecord("SplineMove.SetActorLocation", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		this.ActorComp.ResetLocationCachedTime();
		this.ActorComp.ResetRotationCachedTime();
	}

	// Token: 0x0601B291 RID: 111249 RVA: 0x00828CB4 File Offset: 0x00826EB4
	protected unsafe void CalAdjustRotation(float timeKey, float deltaSeconds)
	{
		Vector actorForwardProxy = this.ActorComp.ActorForwardProxy;
		float num = base.CurrentSplineMoveParams.PredictDist;
		if (!base.IsPositiveMoving)
		{
			num *= -1f;
		}
		USplineComponent spline = base.CurrentSplineMoveParams.Spline;
		float distanceAlongSplineAtSplineInputKey = spline.GetDistanceAlongSplineAtSplineInputKey(this.SplineTimeKey);
		Vector tmpVector = this.TmpVector;
		FVectorDouble fvectorDouble = spline.D_GetLocationAtDistanceAlongSpline(distanceAlongSplineAtSplineInputKey + num, ESplineCoordinateSpace.World);
		tmpVector.FromUeVector(fvectorDouble);
		this.TmpVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		this.SplineQuat.UnRotateVector(actorForwardProxy, this.TmpVector);
		bool flag = false;
		if (Math.Abs(this.TmpVector.Z) > (double)base.CurrentSplineMoveParams.AdjustFacingLimitPitchSin)
		{
			this.TmpVector.Z = (double)((float)Math.Sign(this.TmpVector.Z) * base.CurrentSplineMoveParams.AdjustFacingLimitPitchSin);
			flag = true;
		}
		double num2 = Math.Sqrt(1.0 - this.TmpVector.Z * this.TmpVector.Z);
		if (Singleton<MathUtils>.Instance.IsNearlyZero(this.TmpVector.X, null) && Singleton<MathUtils>.Instance.IsNearlyZero(this.TmpVector.Y, null))
		{
			this.TmpVector.X = num2;
			this.TmpVector.Y = 0.0;
		}
		else
		{
			float num3 = base.CurrentSplineMoveParams.AdjustFacingLimit * 0.017453292f;
			SplineMoveParams currentSplineMoveParams = base.CurrentSplineMoveParams;
			if (((currentSplineMoveParams != null) ? currentSplineMoveParams.AdjustFacingLimitCurve : null) != null)
			{
				this.ActorComp.ActorLocationProxy.Subtraction(this.SplineLocation, this.TmpVector1);
				this.SplineQuat.UnRotateVector(this.TmpVector1, this.TmpVector1);
				double value = this.TmpVector1.Y / (double)base.CurrentSplineMoveParams.MaxOffsetDist;
				num3 *= base.CurrentSplineMoveParams.AdjustFacingLimitCurve.GetFloatValue((float)Math.Abs(value));
			}
			double num4 = Math.Atan2(this.TmpVector.Y, this.TmpVector.X);
			if (num4 > (double)num3)
			{
				this.TmpVector.X = Math.Cos((double)num3);
				this.TmpVector.Y = Math.Sin((double)num3);
				flag = true;
			}
			else if (num4 < (double)(-(double)num3))
			{
				this.TmpVector.X = Math.Cos((double)(-(double)num3));
				this.TmpVector.Y = Math.Sin((double)(-(double)num3));
				flag = true;
			}
			else
			{
				this.TmpVector.X = Math.Cos(num4);
				this.TmpVector.Y = Math.Sin(num4);
			}
			this.TmpVector.X *= num2;
			this.TmpVector.Y *= num2;
		}
		if (flag)
		{
			if (this.IsDebug)
			{
				this.SplineQuat.UnRotateVector(this.ActorComp.ActorForwardProxy, this.TmpVector1);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "Motor SplineMove CalAdjustRotation";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TimeKey", this.SplineTimeKey);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("OnlyForward", base.CurrentSplineMoveParams.OnlyForward);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Local", this.TmpVector1);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("NewLocal", this.TmpVector);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Limit", base.CurrentSplineMoveParams.AdjustFacingLimit);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("PitchCos", base.CurrentSplineMoveParams.AdjustFacingLimitPitchSin);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			}
			this.SplineQuat.RotateVector(this.TmpVector, this.TmpVector1);
			Quat.FindBetween(actorForwardProxy, this.TmpVector1, this.QuatDelta);
			return;
		}
		this.QuatDelta.Reset();
	}

	// Token: 0x0601B292 RID: 111250 RVA: 0x008290DC File Offset: 0x008272DC
	protected override void InputAdjust()
	{
		if (base.CurrentSplineMoveParams == null)
		{
			return;
		}
		if (base.CurrentSplineMoveParams.AutopilotRoute != null)
		{
			if (this.DetectRoadBlock(4000f))
			{
				this.InputAdjustInternal(0f, 0f, true, -500f, 1000f);
				return;
			}
			this.InputAdjustInternal(0f, 0f, true, 0f, 0f);
			return;
		}
		else
		{
			if (base.CurrentSplineMoveParams.AutoDriveStandbyTime >= 0f && base.Entity.GetComponent<MotorcycleInputComponent>().LastInputSeconds + (double)base.CurrentSplineMoveParams.AutoDriveStandbyTime <= Singleton<Time>.Instance.NowSeconds)
			{
				this.InputAdjustInternal(0f, 0f, false, 0f, 0f);
				return;
			}
			UCurveFloat inputCorrectionCurve = base.CurrentSplineMoveParams.InputCorrectionCurve;
			if (inputCorrectionCurve == null)
			{
				this.InputAdjustInternal(-1f, 1f, false, 0f, 0f);
				return;
			}
			this.TmpVector.DeepCopy(this.SplineDirection);
			if (!base.IsPositiveMoving)
			{
				this.TmpVector.MultiplyEqual(-1.0);
			}
			this.ActorComp.ActorLocationProxy.Subtraction(this.SplineLocation, this.TmpVector1);
			this.SplineQuat.UnRotateVector(this.TmpVector1, this.TmpVector1);
			this.TmpVector1.X = 0.0;
			double num = (this.Using3d ? this.TmpVector1.Size() : this.TmpVector1.Y) / (double)base.CurrentSplineMoveParams.MaxOffsetDist;
			float floatValue = inputCorrectionCurve.GetFloatValue((float)num);
			float left = -inputCorrectionCurve.GetFloatValue((float)(-(float)num));
			this.InputAdjustInternal(left, floatValue, false, 0f, 0f);
			return;
		}
	}

	// Token: 0x0601B293 RID: 111251 RVA: 0x00829291 File Offset: 0x00827491
	private void InputAdjustInternal(float left, float right, bool canAutoBrakeAndSprint = false, float predictRightOffset = 0f, float newPredictLength = 0f)
	{
		if (this.Using3d)
		{
			this.InputAdjust3dInternal(left, right, newPredictLength);
			return;
		}
		this.InputAdjust2dInternal(left, right, canAutoBrakeAndSprint, predictRightOffset, newPredictLength);
	}

	// Token: 0x0601B294 RID: 111252 RVA: 0x008292B4 File Offset: 0x008274B4
	private unsafe void InputAdjust2dInternal(float left, float right, bool canAutoBrakeAndSprint = false, float predictRightOffset = 0f, float newPredictLength = 0f)
	{
		float num = (newPredictLength > 0f) ? newPredictLength : base.CurrentSplineMoveParams.PredictDist;
		if (!base.IsPositiveMoving)
		{
			num *= -1f;
		}
		USplineComponent spline = base.CurrentSplineMoveParams.Spline;
		float distanceAlongSplineAtSplineInputKey = spline.GetDistanceAlongSplineAtSplineInputKey(this.SplineTimeKey);
		Vector tmpVector = this.TmpVector;
		FVectorDouble fvectorDouble = spline.D_GetLocationAtDistanceAlongSpline(distanceAlongSplineAtSplineInputKey + num, ESplineCoordinateSpace.World);
		tmpVector.FromUeVector(fvectorDouble);
		if (predictRightOffset != 0f)
		{
			this.SplineQuat.GetRightVector(this.TmpVector1);
			this.TmpVector1.MultiplyEqual((double)(base.IsPositiveMoving ? predictRightOffset : (-(double)predictRightOffset)));
			this.TmpVector.AdditionEqual(this.TmpVector1);
		}
		if (this.IsDebug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Motor auto pilot";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TimeKey", this.SplineTimeKey);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("location", this.SplineLocation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("dist", distanceAlongSplineAtSplineInputKey);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("WithOffset", this.TmpVector);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			UKismetSystemLibrary.D_DrawDebugArrow(this.ActorComp.Owner, this.ActorComp.ActorLocation, this.TmpVector.ToUeVector(false), 5f, MotorcycleSplineMoveComponent.greenColor, 0f, 10f);
		}
		this.TmpVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		this.TmpVector.Normalize(9.99999993922529E-09);
		float angleOffsetInGravityForActor = Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityForActor(this.ActorComp, this.ActorComp.ActorForwardProxy, this.TmpVector);
		float num2 = angleOffsetInGravityForActor / base.CurrentSplineMoveParams.InputCorrectionBaseAngle;
		if ((double)(num2 + right) < this.VehicleActorComp.InputDirectProxy.Y)
		{
			num2 += right;
		}
		else if ((double)(num2 + left) > this.VehicleActorComp.InputDirectProxy.Y)
		{
			num2 += left;
		}
		else
		{
			num2 = (float)this.VehicleActorComp.InputDirectProxy.Y;
		}
		VehicleActorComponent vehicleActorComp = this.VehicleActorComp;
		SplineMoveParams currentSplineMoveParams = base.CurrentSplineMoveParams;
		vehicleActorComp.SetInputDirectByNumber((currentSplineMoveParams != null && currentSplineMoveParams.DisableAutoForward) ? ((float)this.VehicleActorComp.InputDirectProxy.X) : 1f, Singleton<MathUtils>.Instance.Clamp(num2, -1f, 1f), 0f);
		if (canAutoBrakeAndSprint)
		{
			if (Math.Abs(angleOffsetInGravityForActor) > (this.AutopilotBraking ? 30f : 90f))
			{
				this.AutopilotBraking = true;
			}
			else
			{
				this.AutopilotBraking = false;
			}
			this.AutopilotSprint = (!this.AutopilotBraking && base.CurrentSplineMoveParams.AutoSprint && Singleton<MathUtils>.Instance.IsNearlyZero((double)predictRightOffset, null) && this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.无限氮气.路网"]));
			return;
		}
		this.AutopilotBraking = false;
		this.AutopilotSprint = false;
	}

	// Token: 0x0601B295 RID: 111253 RVA: 0x008295D8 File Offset: 0x008277D8
	private unsafe void InputAdjust3dInternal(float left, float right, float newPredictLength = 0f)
	{
		this.ActorComp.ActorLocationProxy.Subtraction(this.SplineLocation, this.TmpVector1);
		this.SplineQuat.UnRotateVector(this.TmpVector1, this.TmpVector1);
		if (this.TmpVector1.Normalize(9.99999993922529E-09))
		{
			this.TmpVector1.MultiplyEqual((double)(-(double)(left + right) / 2f));
		}
		else
		{
			this.TmpVector1.Reset();
		}
		float num = (right - left) / 2f;
		float num2 = (newPredictLength > 0f) ? newPredictLength : base.CurrentSplineMoveParams.PredictDist;
		if (!base.IsPositiveMoving)
		{
			num2 *= -1f;
		}
		USplineComponent spline = base.CurrentSplineMoveParams.Spline;
		float distanceAlongSplineAtSplineInputKey = spline.GetDistanceAlongSplineAtSplineInputKey(this.SplineTimeKey);
		Vector tmpVector = this.TmpVector;
		FVectorDouble fvectorDouble = spline.D_GetLocationAtDistanceAlongSpline(distanceAlongSplineAtSplineInputKey + num2, ESplineCoordinateSpace.World);
		tmpVector.FromUeVector(fvectorDouble);
		if (this.IsDebug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Motor auto pilot";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TimeKey", this.SplineTimeKey);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("location", this.SplineLocation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("dist", distanceAlongSplineAtSplineInputKey);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("WithOffset", this.TmpVector);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			UKismetSystemLibrary.D_DrawDebugArrow(this.ActorComp.Owner, this.ActorComp.ActorLocation, this.TmpVector.ToUeVector(false), 5f, MotorcycleSplineMoveComponent.greenColor, 0f, 10f);
			this.SplineDirection.Multiply((double)(base.IsPositiveMoving ? 500 : -500), this.TmpVector);
			this.TmpVector.AdditionEqual(this.SplineLocation);
			UKismetSystemLibrary.D_DrawDebugArrow(this.ActorComp.Owner, this.SplineLocation.ToUeVector(false), this.TmpVector.ToUeVector(false), 5f, MotorcycleSplineMoveComponent.blueColor, 0f, 10f);
		}
		this.TmpVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		this.TmpVector.Normalize(9.99999993922529E-09);
		this.SplineQuat.UnRotateVector(this.TmpVector, this.TmpVector);
		double num3 = (90.0 - Math.Acos(this.TmpVector.Z) * 57.295780181884766) / (double)base.CurrentSplineMoveParams.InputCorrectionBaseAngle;
		double num4 = (!Singleton<MathUtils>.Instance.IsNearlyZero(this.TmpVector.X, null) || !Singleton<MathUtils>.Instance.IsNearlyZero(this.TmpVector.Y, null)) ? (Math.Atan2(this.TmpVector.Y, this.TmpVector.X) * 57.295780181884766 / (double)base.CurrentSplineMoveParams.InputCorrectionBaseAngle) : 0.0;
		bool isDebug = this.IsDebug;
		num3 += this.TmpVector1.Z;
		double num5 = num4 + this.TmpVector1.Y;
		this.SplineQuat.UnRotateVector(this.ActorComp.ActorForwardProxy, this.TmpVector);
		double num6 = (90.0 - Math.Acos(this.TmpVector.Z) * 57.295780181884766) / (double)base.CurrentSplineMoveParams.InputCorrectionBaseAngle;
		double num7 = (!Singleton<MathUtils>.Instance.IsNearlyZero(this.TmpVector.X, null) || !Singleton<MathUtils>.Instance.IsNearlyZero(this.TmpVector.Y, null)) ? (Math.Atan2(this.TmpVector.Y, this.TmpVector.X) * 57.295780181884766 / (double)base.CurrentSplineMoveParams.InputCorrectionBaseAngle) : 0.0;
		MotorcycleActorComponent motorcycleActorComponent = this.ActorComp as MotorcycleActorComponent;
		double num8 = num6 + motorcycleActorComponent.AirRotateInputProxy.X;
		double num9 = num7 + motorcycleActorComponent.AirRotateInputProxy.Y;
		bool isDebug2 = this.IsDebug;
		double num10 = num3 - num8;
		double num11 = num5 - num9;
		double num12 = Math.Sqrt(num10 * num10 + num11 * num11);
		if (num12 < (double)num)
		{
			return;
		}
		double num13 = (num12 - (double)num) / num12;
		num10 *= num13;
		num11 *= num13;
		this.TmpVector.Set(num10 + motorcycleActorComponent.AirRotateInputProxy.X, num11 + motorcycleActorComponent.AirRotateInputProxy.Y, 0.0);
		bool isDebug3 = this.IsDebug;
		if (false)
		{
			double num14 = this.TmpVector.SizeSquared();
			if (num14 > 1.0)
			{
				this.TmpVector.DivisionEqual(Math.Sqrt(num14));
			}
		}
		else
		{
			this.TmpVector.X = Singleton<MathUtils>.Instance.Clamp(this.TmpVector.X, -1.0, 1.0);
			this.TmpVector.Y = Singleton<MathUtils>.Instance.Clamp(this.TmpVector.Y, -1.0, 1.0);
		}
		motorcycleActorComponent.SetAirRotateInput(this.TmpVector);
	}

	// Token: 0x0601B296 RID: 111254 RVA: 0x00829B4C File Offset: 0x00827D4C
	protected unsafe override void UpdateSplineLocationAndDirection()
	{
		this.Using3d = (this.ActorComp.VehicleMoveComp.GetMotorSubState() == EMotorSubState.Soaring);
		USplineComponent spline = base.CurrentSplineMoveParams.Spline;
		float maxOffsetDist = base.CurrentSplineMoveParams.MaxOffsetDist;
		float searchRadius = Singleton<MathUtils>.Instance.Clamp(maxOffsetDist * 2f, 200f, 50000f);
		int num = spline.GetNumberOfSplinePoints() - 1;
		bool flag = base.CurrentSplineMoveParams.AutopilotRoute != null && this.LastTimeKey != -1f && num >= 5;
		float num2 = flag ? this.FindInputKeyInCurrentRouteRange(spline, num) : this.FindInputKeyByPartition(spline, searchRadius);
		if (num2 < 0f)
		{
			num2 = this.FindInputKeyByPartition(spline, 50000f);
		}
		if (this.IsDebug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "MotorSplineMove Update (Partition)";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("timeKey", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("UseRangeSearch", flag);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.SplineTimeKey = num2;
		Vector splineLocation = this.SplineLocation;
		FVectorDouble fvectorDouble = spline.D_GetLocationAtSplineInputKey(num2, ESplineCoordinateSpace.World);
		splineLocation.FromUeVector(fvectorDouble);
		Vector splineDirection = this.SplineDirection;
		FVector directionAtSplineInputKey = spline.GetDirectionAtSplineInputKey(num2, ESplineCoordinateSpace.World);
		fvectorDouble = directionAtSplineInputKey;
		splineDirection.DeepCopy(fvectorDouble);
		if (base.CurrentSplineMoveParams.OnlyForward || base.CurrentSplineMoveParams.OnlyPositiveMove)
		{
			base.IsPositiveMoving = true;
		}
		else
		{
			Vector actorForwardProxy = this.ActorComp.ActorForwardProxy;
			double num3 = this.SplineDirection.DotProduct(actorForwardProxy);
			base.IsPositiveMoving = (num3 >= 0.0);
		}
		if (this.IsPlannerMove())
		{
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.SplineDirection);
		}
		this.SplineDirection.Normalize(9.99999993922529E-09);
		this.ActorComp.ActorGravityDirectProxy.UnaryNegation(this.TmpVector);
		if (base.IsPositiveMoving)
		{
			this.TmpVector1.DeepCopy(this.SplineDirection);
		}
		else
		{
			this.SplineDirection.UnaryNegation(this.TmpVector1);
		}
		if (this.Using3d)
		{
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TmpVector1, this.TmpVector, this.SplineQuat);
		}
		else
		{
			Singleton<MathUtils>.Instance.LookRotationUpFirst(this.TmpVector1, this.TmpVector, this.SplineQuat);
		}
		base.CurrentSplineMoveParams.UpdateParamsByTimeKey(this.SplineTimeKey);
	}

	// Token: 0x0601B297 RID: 111255 RVA: 0x00829DCC File Offset: 0x00827FCC
	private float FindInputKeyInCurrentRouteRange(USplineComponent splineComp, int maxTimeKey)
	{
		float num = this.LastTimeKey;
		float num2 = this.LastTimeKey;
		if (base.IsPositiveMoving)
		{
			num = this.LastTimeKey - 1f;
			num2 = this.LastTimeKey + 3f;
		}
		else
		{
			num = this.LastTimeKey - 3f;
			num2 = this.LastTimeKey + 1f;
		}
		float result;
		if (!splineComp.IsClosedLoop())
		{
			FVectorDouble fvectorDouble = this.ActorComp.ActorLocation;
			result = splineComp.D_FindInputKeyClosestToWorldLocationInRange(fvectorDouble, (int)num, (int)num2);
		}
		else if (num < 0f)
		{
			FVectorDouble fvectorDouble = this.ActorComp.ActorLocation;
			float num3 = splineComp.D_FindInputKeyClosestToWorldLocationInRange(fvectorDouble, (int)(num + (float)maxTimeKey), maxTimeKey);
			fvectorDouble = this.ActorComp.ActorLocation;
			float num4 = splineComp.D_FindInputKeyClosestToWorldLocationInRange(fvectorDouble, 0, (int)num2);
			Vector tmpVector = this.TmpVector;
			fvectorDouble = splineComp.D_GetLocationAtSplineInputKey(num3, ESplineCoordinateSpace.World);
			tmpVector.FromUeVector(fvectorDouble);
			Vector tmpVector2 = this.TmpVector1;
			fvectorDouble = splineComp.D_GetLocationAtSplineInputKey(num4, ESplineCoordinateSpace.World);
			tmpVector2.FromUeVector(fvectorDouble);
			if (Vector.DistSquared(this.ActorComp.ActorLocationProxy, this.TmpVector) < Vector.DistSquared(this.ActorComp.ActorLocationProxy, this.TmpVector1))
			{
				result = num3;
			}
			else
			{
				result = num4;
			}
		}
		else if (num2 > (float)maxTimeKey)
		{
			FVectorDouble fvectorDouble = this.ActorComp.ActorLocation;
			float num5 = splineComp.D_FindInputKeyClosestToWorldLocationInRange(fvectorDouble, 0, (int)(num2 - (float)maxTimeKey));
			fvectorDouble = this.ActorComp.ActorLocation;
			float num6 = splineComp.D_FindInputKeyClosestToWorldLocationInRange(fvectorDouble, (int)num, maxTimeKey);
			Vector tmpVector3 = this.TmpVector;
			fvectorDouble = splineComp.D_GetLocationAtSplineInputKey(num5, ESplineCoordinateSpace.World);
			tmpVector3.FromUeVector(fvectorDouble);
			Vector tmpVector4 = this.TmpVector1;
			fvectorDouble = splineComp.D_GetLocationAtSplineInputKey(num6, ESplineCoordinateSpace.World);
			tmpVector4.FromUeVector(fvectorDouble);
			if (Vector.DistSquared(this.ActorComp.ActorLocationProxy, this.TmpVector) < Vector.DistSquared(this.ActorComp.ActorLocationProxy, this.TmpVector1))
			{
				result = num5;
			}
			else
			{
				result = num6;
			}
		}
		else
		{
			FVectorDouble fvectorDouble = this.ActorComp.ActorLocation;
			result = splineComp.D_FindInputKeyClosestToWorldLocationInRange(fvectorDouble, (int)num, (int)num2);
		}
		return result;
	}

	// Token: 0x0601B298 RID: 111256 RVA: 0x00829FBC File Offset: 0x008281BC
	private float FindInputKeyByPartition(USplineComponent splineComp, float searchRadius)
	{
		FVectorDouble fvectorDouble;
		if (base.CurrentSplineMoveParams.UseSplineGravity || this.Using3d)
		{
			fvectorDouble = this.ActorComp.ActorLocationProxy.ToUeVector(false);
			return splineComp.D_FindInputKeyClosestToWorldLocationByPartition(fvectorDouble, searchRadius);
		}
		fvectorDouble = this.ActorComp.ActorLocationProxy.ToUeVector(false);
		return splineComp.D_FindInputKeyClosestToWorldLocationByPartitionInGravity(fvectorDouble, this.ActorComp.ActorGravityDirectProxy.ToUeVectorOld(), searchRadius, base.CurrentSplineMoveParams.LayerVerticalLimit);
	}

	// Token: 0x0601B299 RID: 111257 RVA: 0x0082A030 File Offset: 0x00828230
	private bool DetectRoadBlock(float detectDistance = 4000f)
	{
		float num = detectDistance;
		if (!base.IsPositiveMoving)
		{
			num *= -1f;
		}
		float distanceAlongSplineAtSplineInputKey = base.CurrentSplineMoveParams.Spline.GetDistanceAlongSplineAtSplineInputKey(this.SplineTimeKey);
		float num2 = distanceAlongSplineAtSplineInputKey + num;
		DoublyLinkedNode<MotorcycleSplineMoveComponent.RoadBlockDetectRecord> doublyLinkedNode = this.DetectedRecordList.GetHeadNode().Next;
		while (((doublyLinkedNode != null) ? doublyLinkedNode.Element : null) != null && doublyLinkedNode != this.DetectedRecordList.GetHeadNode())
		{
			DoublyLinkedNode<MotorcycleSplineMoveComponent.RoadBlockDetectRecord> next = doublyLinkedNode.Next;
			if (doublyLinkedNode.Element.DetectFrame < Singleton<Time>.Instance.Frame - 15)
			{
				this.DetectedRecordList.RemoveThis(doublyLinkedNode);
			}
			doublyLinkedNode = next;
		}
		this.TryRoadBlockDetect(distanceAlongSplineAtSplineInputKey, num2);
		if (this.IsDebug)
		{
			this.DrawBlockDetectRecord();
		}
		doublyLinkedNode = this.DetectedRecordList.GetHeadNode().Next;
		while (((doublyLinkedNode != null) ? doublyLinkedNode.Element : null) != null && doublyLinkedNode != this.DetectedRecordList.GetHeadNode())
		{
			MotorcycleSplineMoveComponent.RoadBlockDetectRecord element = doublyLinkedNode.Element;
			if (element.BlockDist >= 0f && element.StartDist < num2 && element.EndDist > distanceAlongSplineAtSplineInputKey)
			{
				return true;
			}
			doublyLinkedNode = doublyLinkedNode.Next;
		}
		return false;
	}

	// Token: 0x0601B29A RID: 111258 RVA: 0x0082A140 File Offset: 0x00828340
	private void TryRoadBlockDetect(float startDist, float endDist)
	{
		for (int i = 0; i < 1; i++)
		{
			float num = base.IsPositiveMoving ? startDist : (-startDist);
			float num2 = base.IsPositiveMoving ? (endDist + 100f) : (-endDist - 100f);
			DoublyLinkedNode<MotorcycleSplineMoveComponent.RoadBlockDetectRecord> next = this.DetectedRecordList.GetHeadNode().Next;
			while (((next != null) ? next.Element : null) != null && next != this.DetectedRecordList.GetHeadNode())
			{
				MotorcycleSplineMoveComponent.RoadBlockDetectRecord element = next.Element;
				if (element.StartDist >= num2)
				{
					break;
				}
				if (element.StartDist > num)
				{
					num2 = element.StartDist;
					break;
				}
				if (element.EndDist >= num2)
				{
					num = 0f;
					num2 = 0f;
					break;
				}
				num = element.EndDist;
				next = next.Next;
			}
			if (num >= num2 || num >= endDist)
			{
				break;
			}
			this.TryRoadBlockDetectOnePiece(num, num2, (next != null) ? next.Pre : null);
		}
	}

	// Token: 0x0601B29B RID: 111259 RVA: 0x0082A220 File Offset: 0x00828420
	private bool TryRoadBlockDetectOnePiece(float inStartDist, float inEndDist, [Nullable(new byte[]
	{
		2,
		1
	})] DoublyLinkedNode<MotorcycleSplineMoveComponent.RoadBlockDetectRecord> currentNode)
	{
		float num = Math.Abs(inStartDist);
		float num2 = Math.Abs(inEndDist);
		USplineComponent spline = base.CurrentSplineMoveParams.Spline;
		Vector tmpVector = this.TmpVector;
		FVectorDouble fvectorDouble = spline.D_GetLocationAtDistanceAlongSpline(num, ESplineCoordinateSpace.World);
		tmpVector.FromUeVector(fvectorDouble);
		Vector tmpVector2 = this.TmpVector2;
		FVector directionAtDistanceAlongSpline = spline.GetDirectionAtDistanceAlongSpline(num, ESplineCoordinateSpace.World);
		tmpVector2.FromUeVector(directionAtDistanceAlongSpline);
		float num3 = num2;
		while (Math.Abs(num3 - num) > MotorcycleSplineMoveComponent.MIN_DETECT_DIST * 2f)
		{
			Vector tmpVector3 = this.TmpVector1;
			fvectorDouble = spline.D_GetLocationAtDistanceAlongSpline(num3, ESplineCoordinateSpace.World);
			tmpVector3.FromUeVector(fvectorDouble);
			this.TmpVector1.SubtractionEqual(this.TmpVector);
			if (!this.TmpVector1.Normalize(9.99999993922529E-09) || Vector.DotProduct(this.TmpVector1, this.TmpVector2) > MotorcycleSplineMoveComponent.ROAD_BLOCK_DETECT_MAX_ANGLE_COS)
			{
				break;
			}
			num3 = (num3 + num) * 0.5f;
		}
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = this.ActorComp.Owner;
		actorTrace.Radius = 15f;
		actorTrace.ActorsToIgnore.Empty(true);
		VehiclePerformComponent performComp = this.PerformComp;
		AActor aactor;
		if (performComp == null)
		{
			aactor = null;
		}
		else
		{
			Entity driver = performComp.Driver;
			if (driver == null)
			{
				aactor = null;
			}
			else
			{
				BaseActorComponent component = driver.GetComponent<BaseActorComponent>();
				aactor = ((component != null) ? component.Owner : null);
			}
		}
		AActor aactor2 = aactor;
		if (aactor2 != null)
		{
			actorTrace.ActorsToIgnore.Add(aactor2);
		}
		BaseActorComponent actorComp = this.ActorComp;
		Vector vector;
		if (actorComp == null)
		{
			vector = null;
		}
		else
		{
			BaseMoveComponent moveComp = actorComp.MoveComp;
			vector = ((moveComp != null) ? moveComp.GravityDirect : null);
		}
		Vector gravityDirect = vector ?? Vector.DownVectorProxy;
		Singleton<GravityUtils>.Instance.AddZnInGravity(gravityDirect, this.TmpVector, 100.0);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, this.TmpVector);
		Vector tmpVector4 = this.TmpVector1;
		fvectorDouble = spline.D_GetLocationAtDistanceAlongSpline(num3, ESplineCoordinateSpace.World);
		tmpVector4.FromUeVector(fvectorDouble);
		Singleton<GravityUtils>.Instance.AddZnInGravity(gravityDirect, this.TmpVector1, 100.0);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, this.TmpVector1);
		UCapsuleComponent capsuleComponent = this.VehicleActorComp.VehicleOwner.CapsuleComponent;
		bool flag = Singleton<TraceElementCommon>.Instance.ShapeTrace(capsuleComponent, actorTrace, "Motor SplineMove RoadBlock", "Motor SplineMove RoadBlock");
		MotorcycleSplineMoveComponent.RoadBlockDetectRecord roadBlockDetectRecord = new MotorcycleSplineMoveComponent.RoadBlockDetectRecord();
		roadBlockDetectRecord.StartDist = inStartDist;
		roadBlockDetectRecord.EndDist = (float)Math.Sign(num2) * num3;
		roadBlockDetectRecord.DetectFrame = Singleton<Time>.Instance.Frame;
		if (flag)
		{
			roadBlockDetectRecord.BlockDist = actorTrace.HitResult.TimeArray.Get(0) * (roadBlockDetectRecord.EndDist - roadBlockDetectRecord.StartDist);
		}
		else
		{
			roadBlockDetectRecord.BlockDist = -1f;
		}
		if (currentNode != null)
		{
			this.DetectedRecordList.Insert(roadBlockDetectRecord, currentNode);
			return flag;
		}
		this.DetectedRecordList.AddTail(roadBlockDetectRecord);
		return flag;
	}

	// Token: 0x0601B29C RID: 111260 RVA: 0x0082A4B8 File Offset: 0x008286B8
	private void DrawBlockDetectRecord()
	{
		USplineComponent spline = base.CurrentSplineMoveParams.Spline;
		DoublyLinkedNode<MotorcycleSplineMoveComponent.RoadBlockDetectRecord> next = this.DetectedRecordList.GetHeadNode().Next;
		BaseActorComponent actorComp = this.ActorComp;
		Vector vector;
		if (actorComp == null)
		{
			vector = null;
		}
		else
		{
			BaseMoveComponent moveComp = actorComp.MoveComp;
			vector = ((moveComp != null) ? moveComp.GravityDirect : null);
		}
		Vector gravityDirect = vector ?? Vector.DownVectorProxy;
		while (((next != null) ? next.Element : null) != null && next != this.DetectedRecordList.GetHeadNode())
		{
			MotorcycleSplineMoveComponent.RoadBlockDetectRecord element = next.Element;
			float num = element.StartDist;
			FVectorDouble fvectorDouble;
			if (element.BlockDist >= 0f)
			{
				num += element.BlockDist;
				Vector tmpVector = this.TmpVector;
				fvectorDouble = spline.D_GetLocationAtDistanceAlongSpline(Math.Abs(element.StartDist), ESplineCoordinateSpace.World);
				tmpVector.FromUeVector(fvectorDouble);
				Singleton<GravityUtils>.Instance.AddZnInGravity(gravityDirect, this.TmpVector, 100.0);
				Vector tmpVector2 = this.TmpVector1;
				fvectorDouble = spline.D_GetLocationAtDistanceAlongSpline(Math.Abs(num), ESplineCoordinateSpace.World);
				tmpVector2.FromUeVector(fvectorDouble);
				Singleton<GravityUtils>.Instance.AddZnInGravity(gravityDirect, this.TmpVector1, 100.0);
				UKismetSystemLibrary.D_DrawDebugLine(this.ActorComp.Owner, this.TmpVector.ToUeVector(false), this.TmpVector1.ToUeVector(false), MotorcycleSplineMoveComponent.redColor, 0.05f, 25f);
			}
			Vector tmpVector3 = this.TmpVector;
			fvectorDouble = spline.D_GetLocationAtDistanceAlongSpline(Math.Abs(num), ESplineCoordinateSpace.World);
			tmpVector3.FromUeVector(fvectorDouble);
			Singleton<GravityUtils>.Instance.AddZnInGravity(gravityDirect, this.TmpVector, 100.0);
			Vector tmpVector4 = this.TmpVector1;
			fvectorDouble = spline.D_GetLocationAtDistanceAlongSpline(Math.Abs(element.EndDist), ESplineCoordinateSpace.World);
			tmpVector4.FromUeVector(fvectorDouble);
			Singleton<GravityUtils>.Instance.AddZnInGravity(gravityDirect, this.TmpVector1, 100.0);
			UKismetSystemLibrary.D_DrawDebugLine(this.ActorComp.Owner, this.TmpVector.ToUeVector(false), this.TmpVector1.ToUeVector(false), MotorcycleSplineMoveComponent.greenColor, 0.05f, 25f);
			next = next.Next;
		}
	}

	// Token: 0x0601B29D RID: 111261 RVA: 0x0082A6B5 File Offset: 0x008288B5
	protected override void OnSelectNextSplineMoveBegin()
	{
		this.AutopilotBraking = false;
		this.AutopilotSprint = false;
		base.OnSelectNextSplineMoveBegin();
	}

	// Token: 0x0601B29E RID: 111262 RVA: 0x0082A6CB File Offset: 0x008288CB
	protected override void OnSelectNextSplineMoveEnd()
	{
		base.OnSelectNextSplineMoveEnd();
		MotorcycleInputComponent component = base.Entity.GetComponent<MotorcycleInputComponent>();
		if (component != null)
		{
			component.ForceRefreshBraking();
		}
		this.DetectedRecordList.RemoveAllNodeWithoutHead();
	}

	// Token: 0x0601B29F RID: 111263 RVA: 0x0082A6F4 File Offset: 0x008288F4
	public void ForceClearUpdate()
	{
		this.LastTimeKey = -1f;
	}

	// Token: 0x0601B2A0 RID: 111264 RVA: 0x0082A704 File Offset: 0x00828904
	protected override void UpdateSplineGravity(ESplineGravityUpdateType type)
	{
		base.UpdateSplineGravity(type);
		if (this.IsDebug)
		{
			SplineMoveParams currentSplineMoveParams = base.CurrentSplineMoveParams;
			if (currentSplineMoveParams != null && currentSplineMoveParams.UseSplineGravity)
			{
				this.TmpVector.DeepCopy(this.VehicleActorComp.VehicleMoveComp.GravityUp);
				this.TmpVector.MultiplyEqual(300.0);
				this.TmpVector.AdditionEqual(this.ActorComp.ActorLocationProxy);
				UKismetSystemLibrary.D_DrawDebugArrow(this.ActorComp.Owner, this.ActorComp.ActorLocation, this.TmpVector.ToUeVector(false), 5f, MotorcycleSplineMoveComponent.yellowColor, 0f, 10f);
				Vector tmpVector = this.TmpVector;
				FVector motorNormal = this.ActorComp.VehicleMoveComp.VehicleMovement.GetMotorNormal();
				tmpVector.FromUeVector(motorNormal);
				this.TmpVector.MultiplyEqual(300.0);
				this.TmpVector.AdditionEqual(this.ActorComp.ActorLocationProxy);
				UKismetSystemLibrary.D_DrawDebugArrow(this.ActorComp.Owner, this.ActorComp.ActorLocation, this.TmpVector.ToUeVector(false), 5f, MotorcycleSplineMoveComponent.blueColor, 0f, 10f);
			}
		}
	}

	// Token: 0x0601B2A1 RID: 111265 RVA: 0x0082A846 File Offset: 0x00828A46
	protected override void OnPositiveMovingChanged()
	{
		this.DetectedRecordList.RemoveAllNodeWithoutHead();
	}

	// Token: 0x0601B2A2 RID: 111266 RVA: 0x0082A854 File Offset: 0x00828A54
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		MotorcycleSplineMoveComponent motorcycleSplineMoveComponent = (MotorcycleSplineMoveComponent)componentTemplate;
		if (base.CanResetComponentProperty("OnTick1") && motorcycleSplineMoveComponent.OnTick1 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.OnTick1), "OnTick1"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("QuatDelta"))
		{
			if (motorcycleSplineMoveComponent.QuatDelta == null)
			{
				this.QuatDelta = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.QuatDelta), "QuatDelta"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveDelta"))
		{
			if (motorcycleSplineMoveComponent.MoveDelta == null)
			{
				this.MoveDelta = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.MoveDelta), "MoveDelta"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AutopilotBrakingInternal"))
		{
			this.AutopilotBrakingInternal = motorcycleSplineMoveComponent.AutopilotBrakingInternal;
		}
		if (base.CanResetComponentProperty("AutopilotSprintInternal"))
		{
			this.AutopilotSprintInternal = motorcycleSplineMoveComponent.AutopilotSprintInternal;
		}
		if (base.CanResetComponentProperty("DetectedRecordList"))
		{
			if (motorcycleSplineMoveComponent.DetectedRecordList == null)
			{
				this.DetectedRecordList = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<DoublyLinkedList<MotorcycleSplineMoveComponent.RoadBlockDetectRecord>>(this.DetectedRecordList), "DetectedRecordList"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsDebug"))
		{
			this.IsDebug = motorcycleSplineMoveComponent.IsDebug;
		}
		return true;
	}

	// Token: 0x0400DD2F RID: 56623
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor redColor = new FLinearColor(1f, 0f, 0f, 1f);

	// Token: 0x0400DD30 RID: 56624
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor greenColor = new FLinearColor(0f, 1f, 0f, 1f);

	// Token: 0x0400DD31 RID: 56625
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor yellowColor = new FLinearColor(1f, 1f, 0f, 1f);

	// Token: 0x0400DD32 RID: 56626
	[StaticVariableRuleIgnore]
	private static readonly FLinearColor blueColor = new FLinearColor(0f, 0f, 1f, 1f);

	// Token: 0x0400DD33 RID: 56627
	private const float AUTOPILOT_BRAKING_THRESHOLD_MIN = 30f;

	// Token: 0x0400DD34 RID: 56628
	private const float AUTOPILOT_BRAKING_THRESHOLD_MAX = 90f;

	// Token: 0x0400DD35 RID: 56629
	private const float ROAD_BLOCK_DETECT_RADIUS = 15f;

	// Token: 0x0400DD36 RID: 56630
	private const float ROAD_BLOCK_DETECT_DIS = 4000f;

	// Token: 0x0400DD37 RID: 56631
	private const float ROAD_BLOCK_DETECT_MAX_ANGLE = 10f;

	// Token: 0x0400DD38 RID: 56632
	[StaticVariableRuleIgnore]
	private static readonly double ROAD_BLOCK_DETECT_MAX_ANGLE_COS = Math.Cos(0.1745329201221466);

	// Token: 0x0400DD39 RID: 56633
	private const float ROAD_BLOCK_DETECT_HEIGHT = 100f;

	// Token: 0x0400DD3A RID: 56634
	private const float ROAD_BLOCK_RIGHT_OFFSET = -500f;

	// Token: 0x0400DD3B RID: 56635
	private const float ROAD_BLOCK_NEW_PREDICT_DIST = 1000f;

	// Token: 0x0400DD3C RID: 56636
	private const float ROAD_BLOCK_DETECT_ADD_DIST_AT_END = 100f;

	// Token: 0x0400DD3D RID: 56637
	private const int MAX_DETECT_TIMES_ONE_FRAME = 1;

	// Token: 0x0400DD3E RID: 56638
	private const int PARTITION_SEARCH_RADIUS_MIN = 200;

	// Token: 0x0400DD3F RID: 56639
	private const int PARTITION_SEARCH_RADIUS_MAX = 50000;

	// Token: 0x0400DD40 RID: 56640
	private const int ROAD_BLOCK_DETECTE_MAX_CACHE_FRAME = 15;

	// Token: 0x0400DD41 RID: 56641
	[StaticVariableRuleIgnore]
	private static readonly float MIN_DETECT_DIST = 266.66666f;

	// Token: 0x0400DD42 RID: 56642
	private const string PROFILE_KEY = "Motor SplineMove RoadBlock";

	// Token: 0x0400DD43 RID: 56643
	private readonly Stat OnTick1 = Stat.Create("MotorcycleSplineMoveComponent Tick", "", "");

	// Token: 0x0400DD44 RID: 56644
	protected Quat QuatDelta = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400DD45 RID: 56645
	protected Vector MoveDelta = Vector.Create();

	// Token: 0x0400DD46 RID: 56646
	protected bool AutopilotBrakingInternal;

	// Token: 0x0400DD47 RID: 56647
	protected bool AutopilotSprintInternal;

	// Token: 0x0400DD48 RID: 56648
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private DoublyLinkedList<MotorcycleSplineMoveComponent.RoadBlockDetectRecord> DetectedRecordList;

	// Token: 0x0400DD49 RID: 56649
	public bool IsDebug;

	// Token: 0x02009468 RID: 37992
	[NullableContext(0)]
	public class RoadBlockDetectRecord
	{
		// Token: 0x040313E8 RID: 201704
		public float StartDist;

		// Token: 0x040313E9 RID: 201705
		public float EndDist;

		// Token: 0x040313EA RID: 201706
		public int DetectFrame = -1;

		// Token: 0x040313EB RID: 201707
		public float BlockDist = -1f;
	}
}
