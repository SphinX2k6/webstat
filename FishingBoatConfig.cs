using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Level.Vehicle;
using UnrealEngine;

// Token: 0x02003286 RID: 12934
[NullableContext(1)]
[Nullable(0)]
public class FishingBoatConfig : GongduolaConfig
{
	// Token: 0x0601B132 RID: 110898 RVA: 0x0081CEF1 File Offset: 0x0081B0F1
	public FishingBoatConfig(Entity entity, [Nullable(2)] BP_GongduolaConfig_C asset) : base(entity, asset)
	{
	}

	// Token: 0x0601B133 RID: 110899 RVA: 0x0081CEFC File Offset: 0x0081B0FC
	public override VehicleConfig DeepCopy()
	{
		FishingBoatConfig fishingBoatConfig = new FishingBoatConfig(this.VehicleEntity, null);
		this.DeepCopyInternal(fishingBoatConfig);
		return fishingBoatConfig;
	}

	// Token: 0x0601B134 RID: 110900 RVA: 0x0081CF20 File Offset: 0x0081B120
	public override void SetBaseStateMoveConfig(UKuroVehicleMovementComponent movement)
	{
		Entity vehicleEntity = this.VehicleEntity;
		GongduolaInputComponent gongduolaInputComponent = (vehicleEntity != null) ? vehicleEntity.GetComponent<GongduolaInputComponent>() : null;
		if (gongduolaInputComponent != null)
		{
			gongduolaInputComponent.TurningForceInputFactor = this.BaseTurningForceForwardFactor;
			gongduolaInputComponent.MaxForwardThreshold = this.BaseMaxForwardThreshold;
			gongduolaInputComponent.MaxRightThreshold = this.BaseMaxRightThreshold;
		}
		float num = 1f;
		Entity vehicleEntity2 = this.VehicleEntity;
		BaseAttributeComponent baseAttributeComponent = (vehicleEntity2 != null) ? vehicleEntity2.GetComponent<BaseAttributeComponent>() : null;
		if (baseAttributeComponent != null)
		{
			num = baseAttributeComponent.GetCurrentValue(EAttributeType.SpeedRatio);
			num /= 10000f;
		}
		this.RealMaxSpeed = this.BaseMaxSpeed * num;
		movement.MaxSpeed = this.RealMaxSpeed;
		movement.MaxAcceleration = this.BaseMaxAcceleration;
		movement.MinAcceleration = this.BaseMinAcceleration;
		movement.MaxBackwardSpeed = this.BaseMaxBackwardSpeed * num;
		movement.MaxBackwardAcceleration = this.BaseBackwardAcceleration;
		movement.MaxBrakeAcceleration = this.BaseBrakeAcceleration;
		movement.MaxRotationYawAcceleration = this.BaseMaxRotYawAcc;
		movement.MinRotationYawAcceleration = this.BaseMinRotYawAcc;
		movement.RotAngleCoef = this.BaseRotAngleCoef;
		movement.RotSpeedCoef = this.BaseRotSpeedCoef;
		movement.RotConstCoef = this.BaseRotConstCoef;
		movement.MinFriction = this.BaseMinFriction;
		movement.MaxFriction = this.BaseMaxFriction;
		movement.MaxRotationSpeed = this.BaseMaxRotationSpeed;
		movement.RotFrictionFactor = this.BaseRotFrictionFactor;
		movement.StaticRotFriction = this.BaseStaticRotFriction;
	}

	// Token: 0x0601B135 RID: 110901 RVA: 0x0081D064 File Offset: 0x0081B264
	public void RefreshSprintConfig(float sprintMaxSpeedRatio, float sprintExceedLimitDuration, float sprintDuration)
	{
		float num = this.RealMaxSpeed * sprintMaxSpeedRatio;
		this.SprintMaxSpeed = ((num <= this.SprintExceedLimitSpeed) ? num : this.SprintExceedLimitSpeed);
		this.SprintExceedLimitDuration = ((sprintExceedLimitDuration <= sprintDuration) ? sprintExceedLimitDuration : sprintDuration);
		this.SprintDuration = sprintDuration;
		this.SprintBrakeAcceleration = 3000f;
	}

	// Token: 0x0601B136 RID: 110902 RVA: 0x0081D0B2 File Offset: 0x0081B2B2
	protected override void DeepCopyInternal(VehicleConfig inOut)
	{
		base.DeepCopyInternal(inOut);
		((FishingBoatConfig)inOut).RealMaxSpeed = this.RealMaxSpeed;
	}

	// Token: 0x0400DC22 RID: 56354
	private float RealMaxSpeed;
}
