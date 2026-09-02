using System;
using System.Runtime.CompilerServices;

// Token: 0x02003290 RID: 12944
[NullableContext(1)]
[Nullable(0)]
public class GongduolaSplineMoveComponent : VehicleSplineMoveComponent
{
	// Token: 0x0601B1BD RID: 111037 RVA: 0x00821414 File Offset: 0x0081F614
	protected override void InputAdjustSlideTrack(Vector inputDirect)
	{
		this.SplineQuat.Inverse(this.TmpQuat);
		this.ActorComp.ActorLocationProxy.Subtraction(this.SplineLocation, this.TmpVector1);
		this.TmpQuat.RotateVector(this.TmpVector1, this.TmpVector);
		this.TmpQuat.Multiply(this.ActorComp.ActorQuatProxy, this.TmpQuat1);
		this.TmpQuat1.Rotator(this.TmpRotator);
		SplineMoveParams currentSplineMoveParamsInternal = this.CurrentSplineMoveParamsInternal;
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
		this.TmpVector1.DeepCopy(inputDirect);
		this.ConvertToTriangleInput(this.TmpVector1);
		this.TmpVector1.X = 1.0;
		this.AdjustInputForValid(this.TmpVector1, (float)this.TmpVector.Y, this.TmpRotator.Yaw, num, num2);
		this.ConvertToCircleInput(this.TmpVector1);
		VehicleActorComponent vehicleActorComp = this.VehicleActorComp;
		if (vehicleActorComp == null)
		{
			return;
		}
		vehicleActorComp.SetInputDirect(this.TmpVector1, false);
	}

	// Token: 0x0601B1BE RID: 111038 RVA: 0x00821570 File Offset: 0x0081F770
	protected void ConvertToTriangleInput(Vector inOutInput)
	{
		double absMax = inOutInput.GetAbsMax();
		if (inOutInput.Size() < 1.0)
		{
			return;
		}
		if (absMax < 0.0001)
		{
			return;
		}
		inOutInput.MultiplyEqual(1.0 / absMax);
	}

	// Token: 0x0601B1BF RID: 111039 RVA: 0x008215B5 File Offset: 0x0081F7B5
	protected void ConvertToCircleInput(Vector inOutInput)
	{
		if (inOutInput.Size() < 1.0)
		{
			return;
		}
		inOutInput.Normalize(9.99999993922529E-09);
	}

	// Token: 0x0601B1C0 RID: 111040 RVA: 0x008215DC File Offset: 0x0081F7DC
	protected void AdjustInputForValid(Vector inOutInput, float curDist, float curYaw, float minYaw, float maxYaw)
	{
		SplineMoveParams currentSplineMoveParams = base.CurrentSplineMoveParams;
		if (currentSplineMoveParams == null || !currentSplineMoveParams.OnlyForward)
		{
			return;
		}
		float num = Math.Min(maxYaw - curYaw, curYaw - minYaw);
		if (this.TmpVector1.Y * this.LastLockedInput.Y <= 0.0 || num > 10f)
		{
			this.LastLockedInput.Reset();
		}
		SplineMoveParams currentSplineMoveParams2 = base.CurrentSplineMoveParams;
		bool flag = currentSplineMoveParams2.CurrentMaxOffset <= currentSplineMoveParams2.MaxOffsetDist;
		bool flag2 = Singleton<MathUtils>.Instance.InRangeArray((double)curYaw, new double[]
		{
			(double)minYaw,
			(double)maxYaw
		});
		if (!flag)
		{
			if (Math.Abs(curYaw) >= 90f)
			{
				inOutInput.Y = (double)(-(double)Math.Sign(curDist));
				return;
			}
			int num2 = (curDist > 0f) ? 1 : -1;
			int num3 = (curYaw > 0f) ? 1 : -1;
			if (num2 * num3 > 0)
			{
				inOutInput.Y = (double)(-(double)Math.Sign(curYaw));
				return;
			}
			float num4 = Math.Abs(curYaw);
			int num5 = (num4 < 45f) ? 1 : ((num4 > 60f) ? -1 : 0);
			inOutInput.Y = (double)(num5 * Math.Sign(curYaw));
			return;
		}
		else
		{
			if (!flag2)
			{
				this.LastLockedInput.DeepCopy(inOutInput);
				inOutInput.Y = (double)(-(double)Math.Sign(curYaw));
				return;
			}
			if (this.LastLockedInput.Y * inOutInput.Y > 0.0)
			{
				inOutInput.Y = 0.0;
			}
			return;
		}
	}

	// Token: 0x0601B1C1 RID: 111041 RVA: 0x00821748 File Offset: 0x0081F948
	protected override void ApplySplineMoveDaConfig()
	{
		if (this.ExtraMoveParams == null)
		{
			return;
		}
		GongduolaPerformComponent component = base.Entity.GetComponent<GongduolaPerformComponent>();
		if (!(((component != null) ? component.Config : null) is GongduolaConfig))
		{
			return;
		}
		((GongduolaConfig)component.Config).BaseMaxSpeed = this.ExtraMoveParams.ForwardSpeed;
		((GongduolaConfig)component.Config).BaseMaxAcceleration = this.ExtraMoveParams.ForwardAcceleration;
		component.RefreshMoveConfigFromVehicleConfig();
		component.SetEnableInputSprint(!this.ExtraMoveParams.DisableSprint.GetValueOrDefault());
	}

	// Token: 0x0601B1C2 RID: 111042 RVA: 0x008217D6 File Offset: 0x0081F9D6
	protected override void ResetSplineMoveDaConfig()
	{
		GongduolaPerformComponent component = base.Entity.GetComponent<GongduolaPerformComponent>();
		if (component != null)
		{
			component.ResetVehicleConfig(true);
		}
		if (component == null)
		{
			return;
		}
		component.SetEnableInputSprint(true);
	}

	// Token: 0x0601B1C3 RID: 111043 RVA: 0x008217FC File Offset: 0x0081F9FC
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		GongduolaSplineMoveComponent gongduolaSplineMoveComponent = (GongduolaSplineMoveComponent)componentTemplate;
		if (base.CanResetComponentProperty("LastLockedInput"))
		{
			if (gongduolaSplineMoveComponent.LastLockedInput == null)
			{
				this.LastLockedInput = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.LastLockedInput), "LastLockedInput"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400DC9C RID: 56476
	private const float UNLOCK_TURN_INPUT_MIN_ANGLE = 10f;

	// Token: 0x0400DC9D RID: 56477
	private const float INPUT_ADJUST_FORWARD_MIN_YAW = 45f;

	// Token: 0x0400DC9E RID: 56478
	private const float INPUT_ADJUST_FORWARD_MAX_YAW = 60f;

	// Token: 0x0400DC9F RID: 56479
	protected Vector LastLockedInput = Vector.Create();
}
