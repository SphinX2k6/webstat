using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.Vehicle;
using UnrealEngine;

// Token: 0x0200328B RID: 12939
[NullableContext(1)]
[Nullable(0)]
public class GongduolaConfig : VehicleConfig
{
	// Token: 0x0601B157 RID: 110935 RVA: 0x0081DA00 File Offset: 0x0081BC00
	public GongduolaConfig(Entity entity, [Nullable(2)] BP_GongduolaConfig_C asset) : base(entity, asset)
	{
		if (asset == null || !asset.IsValid())
		{
			return;
		}
		this.RotaryIntertia = asset.转动惯量;
		this.SpeedImpactFactor = asset.速度冲击力系数;
		this.RotationImpactFactor = asset.旋转冲击力系数;
		this.TurnForwardInputMinX = asset.前向转弯最小X输入;
		this.TurnBackwardInputMaxX = asset.后向转向最大X输入;
		this.MaxFloatingSpeed = asset.最大上浮速度;
		this.FloatingFrictionFactor = asset.漂浮阻力系数;
		this.BuoyancyBalanceRatio = asset.浮力平衡位置;
		this.StrandedWaterDepthThreshold = asset.搁浅位置;
		this.BaseMaxSpeed = asset.前进最大移动速度;
		this.BaseMaxAcceleration = asset.常态前进加速度;
		this.BaseMinAcceleration = asset.常态最小加速度;
		this.BaseMaxRotYawAcc = asset.常态最大转向加速度;
		this.BaseMinRotYawAcc = asset.常态最小转向加速度;
		this.BaseMaxBackwardSpeed = asset.常态后退最大移动速度;
		this.BaseBackwardAcceleration = asset.常态后退加速度;
		this.BaseBrakeAcceleration = asset.常态刹车加速度;
		this.BaseTurningForceForwardFactor = asset.常态转向强制前向输入系数;
		this.BaseMaxForwardThreshold = asset.常态最大前后输入阈值;
		this.BaseMaxRightThreshold = asset.常态最大左右输入阈值;
		this.BaseRotAngleCoef = asset.常态转向公式角度修正系数;
		this.BaseRotSpeedCoef = asset.常态转向公式速度修正系数;
		this.BaseRotConstCoef = asset.常态转向公式最终修正系数;
		this.BaseMinFriction = asset.常态径向运动摩擦力;
		this.BaseMaxFriction = asset.常态横向运动摩擦力;
		this.BaseMaxRotationSpeed = asset.常态最大转向速度;
		this.BaseRotFrictionFactor = asset.常态转向摩擦力系数;
		this.BaseStaticRotFriction = asset.常态转向静止摩擦力;
		this.SprintExceedLimitSpeed = asset.冲刺超限移动速度;
		this.SprintExceedLimitDuration = asset.冲刺超限持续时间;
		this.SprintMaxSpeed = asset.冲刺最大移动速度;
		this.SprintMaxAcceleration = asset.冲刺前进加速度;
		this.SprintMinAcceleration = asset.冲刺最小加速度;
		this.SprintMaxRotYawAcc = asset.冲刺最大转向加速度;
		this.SprintMinRotYawAcc = asset.冲刺最小转向加速度;
		this.SprintMaxBackwardSpeed = asset.冲刺后退最大移动速度;
		this.SprintBackwardAcceleration = asset.冲刺后退加速度;
		this.SprintBrakeAcceleration = asset.冲刺刹车加速度;
		this.SprintDuration = asset.冲刺持续时间;
		this.SprintExtraFriction = asset.超出最大速度时的额外摩擦力;
		this.SprintTurningForceForwardFactor = asset.冲刺转向强制前向输入系数;
		this.SprintMaxForwardThreshold = asset.冲刺最大前后输入阈值;
		this.SprintMaxRightThreshold = asset.冲刺最大左右输入阈值;
		this.SprintStopSpeed = asset.冲刺停止速度;
		this.SprintCoolDown = asset.冲刺冷却时间;
		this.SprintMaxUsableCount = asset.冲刺最大使用次数;
		this.SprintRotAngleCoef = asset.冲刺转向公式角度修正系数;
		this.SprintRotSpeedCoef = asset.冲刺转向公式速度修正系数;
		this.SprintRotConstCoef = asset.冲刺转向公式最终修正系数;
		this.SprintMinFriction = asset.冲刺径向运动摩擦力;
		this.SprintMaxFriction = asset.冲刺横向运动摩擦力;
		this.SprintMaxRotationSpeed = asset.冲刺最大转向速度;
		this.SprintRotFrictionFactor = asset.冲刺转向摩擦力系数;
		this.SprintStaticRotFriction = asset.冲刺转向静止摩擦力;
		this.SprintForceInputDuration = asset.冲刺固定前向输入时间;
	}

	// Token: 0x0601B158 RID: 110936 RVA: 0x0081DCBC File Offset: 0x0081BEBC
	public override VehicleConfig DeepCopy()
	{
		GongduolaConfig gongduolaConfig = new GongduolaConfig(this.VehicleEntity, null);
		this.DeepCopyInternal(gongduolaConfig);
		return gongduolaConfig;
	}

	// Token: 0x0601B159 RID: 110937 RVA: 0x0081DCE0 File Offset: 0x0081BEE0
	public override bool Init()
	{
		if (!base.Init())
		{
			return false;
		}
		Entity vehicleEntity = this.VehicleEntity;
		VehicleActorComponent vehicleActorComponent = (vehicleEntity != null) ? vehicleEntity.GetComponent<VehicleActorComponent>() : null;
		if (vehicleActorComponent == null)
		{
			return false;
		}
		this.InitGongduolaMovement(vehicleActorComponent.Actor.VehicleMovementComponent);
		this.InitGongduolaBaseInfo();
		return true;
	}

	// Token: 0x0601B15A RID: 110938 RVA: 0x0081DD28 File Offset: 0x0081BF28
	protected void InitGongduolaBaseInfo()
	{
		Entity vehicleEntity = this.VehicleEntity;
		GongduolaPerformComponent gongduolaPerformComponent = (vehicleEntity != null) ? vehicleEntity.GetComponent<GongduolaPerformComponent>() : null;
		if (gongduolaPerformComponent == null)
		{
			return;
		}
		gongduolaPerformComponent.SprintStopSpeedSquared = this.SprintStopSpeed * this.SprintStopSpeed;
		gongduolaPerformComponent.SprintCd = this.SprintCoolDown;
		gongduolaPerformComponent.SprintUsableCount = this.SprintMaxUsableCount;
	}

	// Token: 0x0601B15B RID: 110939 RVA: 0x0081DD78 File Offset: 0x0081BF78
	protected void InitGongduolaMovement(UKuroVehicleMovementComponent movement)
	{
		movement.RotaryInertia = this.RotaryIntertia;
		movement.SpeedImpactFactor = this.SpeedImpactFactor;
		movement.RotationImpactFactor = this.RotationImpactFactor;
		movement.ExtraFrictionWhenExceedMaxSpeed = this.SprintExtraFriction;
		this.SetBaseStateMoveConfig(movement);
		this.SetBuoyancyRelatedConfig(movement);
		Entity vehicleEntity = this.VehicleEntity;
		GongduolaInputComponent gongduolaInputComponent = (vehicleEntity != null) ? vehicleEntity.GetComponent<GongduolaInputComponent>() : null;
		if (gongduolaInputComponent != null)
		{
			gongduolaInputComponent.TurnForwardInputMinX = this.TurnForwardInputMinX;
			gongduolaInputComponent.TurnBackwardInputMaxX = this.TurnBackwardInputMaxX;
		}
	}

	// Token: 0x0601B15C RID: 110940 RVA: 0x0081DDF4 File Offset: 0x0081BFF4
	public virtual void SetBaseStateMoveConfig(UKuroVehicleMovementComponent movement)
	{
		Entity vehicleEntity = this.VehicleEntity;
		GongduolaInputComponent gongduolaInputComponent = (vehicleEntity != null) ? vehicleEntity.GetComponent<GongduolaInputComponent>() : null;
		if (gongduolaInputComponent != null)
		{
			gongduolaInputComponent.TurningForceInputFactor = this.BaseTurningForceForwardFactor;
			gongduolaInputComponent.MaxForwardThreshold = this.BaseMaxForwardThreshold;
			gongduolaInputComponent.MaxRightThreshold = this.BaseMaxRightThreshold;
		}
		movement.MaxSpeed = this.BaseMaxSpeed;
		movement.MaxAcceleration = this.BaseMaxAcceleration;
		movement.MinAcceleration = this.BaseMinAcceleration;
		movement.MaxBackwardSpeed = this.BaseMaxBackwardSpeed;
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

	// Token: 0x0601B15D RID: 110941 RVA: 0x0081DEFC File Offset: 0x0081C0FC
	public void SetSprintStateMoveConfig(UKuroVehicleMovementComponent movement)
	{
		Entity vehicleEntity = this.VehicleEntity;
		GongduolaInputComponent gongduolaInputComponent = (vehicleEntity != null) ? vehicleEntity.GetComponent<GongduolaInputComponent>() : null;
		if (gongduolaInputComponent != null)
		{
			gongduolaInputComponent.TurningForceInputFactor = this.SprintTurningForceForwardFactor;
			gongduolaInputComponent.MaxForwardThreshold = this.SprintMaxForwardThreshold;
			gongduolaInputComponent.MaxRightThreshold = this.SprintMaxRightThreshold;
		}
		movement.MaxSpeed = this.SprintMaxSpeed;
		movement.MaxAcceleration = this.SprintMaxAcceleration;
		movement.MinAcceleration = this.SprintMinAcceleration;
		movement.MaxBackwardSpeed = this.SprintMaxBackwardSpeed;
		movement.MaxBackwardAcceleration = this.SprintBackwardAcceleration;
		movement.MaxBrakeAcceleration = this.SprintBrakeAcceleration;
		movement.MaxRotationYawAcceleration = this.SprintMaxRotYawAcc;
		movement.MinRotationYawAcceleration = this.SprintMinRotYawAcc;
		movement.RotAngleCoef = this.SprintRotAngleCoef;
		movement.RotSpeedCoef = this.SprintRotSpeedCoef;
		movement.RotConstCoef = this.SprintRotConstCoef;
		movement.MinFriction = this.SprintMinFriction;
		movement.MaxFriction = this.SprintMaxFriction;
		movement.MaxRotationSpeed = this.SprintMaxRotationSpeed;
		movement.RotFrictionFactor = this.SprintRotFrictionFactor;
		movement.StaticRotFriction = this.SprintStaticRotFriction;
	}

	// Token: 0x0601B15E RID: 110942 RVA: 0x0081E003 File Offset: 0x0081C203
	public void SetBuoyancyRelatedConfig(UKuroVehicleMovementComponent movement)
	{
		movement.MaxFloatingSpeed = this.MaxFloatingSpeed;
		movement.FloatingFrictionFactor = this.FloatingFrictionFactor;
		movement.BuoyancyBalanceRatio = this.BuoyancyBalanceRatio;
		movement.StrandedWaterDepthThreshold = this.StrandedWaterDepthThreshold;
	}

	// Token: 0x0601B15F RID: 110943 RVA: 0x0081E038 File Offset: 0x0081C238
	protected override void DeepCopyInternal(VehicleConfig inOut)
	{
		base.DeepCopyInternal(inOut);
		GongduolaConfig gongduolaConfig = (GongduolaConfig)inOut;
		gongduolaConfig.RotaryIntertia = this.RotaryIntertia;
		gongduolaConfig.SpeedImpactFactor = this.SpeedImpactFactor;
		gongduolaConfig.RotationImpactFactor = this.RotationImpactFactor;
		gongduolaConfig.TurnForwardInputMinX = this.TurnForwardInputMinX;
		gongduolaConfig.TurnBackwardInputMaxX = this.TurnBackwardInputMaxX;
		gongduolaConfig.MaxFloatingSpeed = this.MaxFloatingSpeed;
		gongduolaConfig.FloatingFrictionFactor = this.FloatingFrictionFactor;
		gongduolaConfig.BuoyancyBalanceRatio = this.BuoyancyBalanceRatio;
		gongduolaConfig.StrandedWaterDepthThreshold = this.StrandedWaterDepthThreshold;
		gongduolaConfig.BaseMaxSpeed = this.BaseMaxSpeed;
		gongduolaConfig.BaseMaxAcceleration = this.BaseMaxAcceleration;
		gongduolaConfig.BaseMinAcceleration = this.BaseMinAcceleration;
		gongduolaConfig.BaseMaxRotYawAcc = this.BaseMaxRotYawAcc;
		gongduolaConfig.BaseMinRotYawAcc = this.BaseMinRotYawAcc;
		gongduolaConfig.BaseMaxBackwardSpeed = this.BaseMaxBackwardSpeed;
		gongduolaConfig.BaseBackwardAcceleration = this.BaseBackwardAcceleration;
		gongduolaConfig.BaseBrakeAcceleration = this.BaseBrakeAcceleration;
		gongduolaConfig.BaseTurningForceForwardFactor = this.BaseTurningForceForwardFactor;
		gongduolaConfig.BaseMaxForwardThreshold = this.BaseMaxForwardThreshold;
		gongduolaConfig.BaseMaxRightThreshold = this.BaseMaxRightThreshold;
		gongduolaConfig.BaseRotAngleCoef = this.BaseRotAngleCoef;
		gongduolaConfig.BaseRotSpeedCoef = this.BaseRotSpeedCoef;
		gongduolaConfig.BaseRotConstCoef = this.BaseRotConstCoef;
		gongduolaConfig.BaseMinFriction = this.BaseMinFriction;
		gongduolaConfig.BaseMaxFriction = this.BaseMaxFriction;
		gongduolaConfig.BaseMaxRotationSpeed = this.BaseMaxRotationSpeed;
		gongduolaConfig.BaseRotFrictionFactor = this.BaseRotFrictionFactor;
		gongduolaConfig.BaseStaticRotFriction = this.BaseStaticRotFriction;
		gongduolaConfig.SprintExceedLimitSpeed = this.SprintExceedLimitSpeed;
		gongduolaConfig.SprintMaxSpeed = this.SprintMaxSpeed;
		gongduolaConfig.SprintMaxAcceleration = this.SprintMaxAcceleration;
		gongduolaConfig.SprintMinAcceleration = this.SprintMinAcceleration;
		gongduolaConfig.SprintMaxRotYawAcc = this.SprintMaxRotYawAcc;
		gongduolaConfig.SprintMinRotYawAcc = this.SprintMinRotYawAcc;
		gongduolaConfig.SprintMaxBackwardSpeed = this.SprintMaxBackwardSpeed;
		gongduolaConfig.SprintBackwardAcceleration = this.SprintBackwardAcceleration;
		gongduolaConfig.SprintBrakeAcceleration = this.SprintBrakeAcceleration;
		gongduolaConfig.SprintDuration = this.SprintDuration;
		gongduolaConfig.SprintExtraFriction = this.SprintExtraFriction;
		gongduolaConfig.SprintTurningForceForwardFactor = this.SprintTurningForceForwardFactor;
		gongduolaConfig.SprintMaxForwardThreshold = this.SprintMaxForwardThreshold;
		gongduolaConfig.SprintMaxRightThreshold = this.SprintMaxRightThreshold;
		gongduolaConfig.SprintStopSpeed = this.SprintStopSpeed;
		gongduolaConfig.SprintCoolDown = this.SprintCoolDown;
		gongduolaConfig.SprintMaxUsableCount = this.SprintMaxUsableCount;
		gongduolaConfig.SprintRotAngleCoef = this.SprintRotAngleCoef;
		gongduolaConfig.SprintRotSpeedCoef = this.SprintRotSpeedCoef;
		gongduolaConfig.SprintRotConstCoef = this.SprintRotConstCoef;
		gongduolaConfig.SprintMinFriction = this.SprintMinFriction;
		gongduolaConfig.SprintMaxFriction = this.SprintMaxFriction;
		gongduolaConfig.SprintMaxRotationSpeed = this.SprintMaxRotationSpeed;
		gongduolaConfig.SprintRotFrictionFactor = this.SprintRotFrictionFactor;
		gongduolaConfig.SprintStaticRotFriction = this.SprintStaticRotFriction;
		gongduolaConfig.SprintForceInputDuration = this.SprintForceInputDuration;
	}

	// Token: 0x0400DC30 RID: 56368
	public float RotaryIntertia;

	// Token: 0x0400DC31 RID: 56369
	public float SpeedImpactFactor;

	// Token: 0x0400DC32 RID: 56370
	public float RotationImpactFactor;

	// Token: 0x0400DC33 RID: 56371
	public float TurnForwardInputMinX;

	// Token: 0x0400DC34 RID: 56372
	public float TurnBackwardInputMaxX;

	// Token: 0x0400DC35 RID: 56373
	public float MaxFloatingSpeed;

	// Token: 0x0400DC36 RID: 56374
	public float FloatingFrictionFactor;

	// Token: 0x0400DC37 RID: 56375
	public float BuoyancyBalanceRatio;

	// Token: 0x0400DC38 RID: 56376
	public float StrandedWaterDepthThreshold;

	// Token: 0x0400DC39 RID: 56377
	public float BaseMaxSpeed;

	// Token: 0x0400DC3A RID: 56378
	public float BaseMaxAcceleration;

	// Token: 0x0400DC3B RID: 56379
	public float BaseMinAcceleration;

	// Token: 0x0400DC3C RID: 56380
	public float BaseBrakeAcceleration;

	// Token: 0x0400DC3D RID: 56381
	public float BaseMaxBackwardSpeed;

	// Token: 0x0400DC3E RID: 56382
	public float BaseBackwardAcceleration;

	// Token: 0x0400DC3F RID: 56383
	public float BaseMaxRotYawAcc;

	// Token: 0x0400DC40 RID: 56384
	public float BaseMinRotYawAcc;

	// Token: 0x0400DC41 RID: 56385
	public float BaseRotAngleCoef;

	// Token: 0x0400DC42 RID: 56386
	public float BaseRotSpeedCoef;

	// Token: 0x0400DC43 RID: 56387
	public float BaseRotConstCoef;

	// Token: 0x0400DC44 RID: 56388
	public float BaseMinFriction;

	// Token: 0x0400DC45 RID: 56389
	public float BaseMaxFriction;

	// Token: 0x0400DC46 RID: 56390
	public float BaseMaxRotationSpeed;

	// Token: 0x0400DC47 RID: 56391
	public float BaseRotFrictionFactor;

	// Token: 0x0400DC48 RID: 56392
	public float BaseStaticRotFriction;

	// Token: 0x0400DC49 RID: 56393
	public float BaseTurningForceForwardFactor;

	// Token: 0x0400DC4A RID: 56394
	public float BaseMaxForwardThreshold;

	// Token: 0x0400DC4B RID: 56395
	public float BaseMaxRightThreshold;

	// Token: 0x0400DC4C RID: 56396
	public float SprintExceedLimitSpeed;

	// Token: 0x0400DC4D RID: 56397
	public float SprintExceedLimitDuration;

	// Token: 0x0400DC4E RID: 56398
	public float SprintMaxSpeed;

	// Token: 0x0400DC4F RID: 56399
	public float SprintMaxAcceleration;

	// Token: 0x0400DC50 RID: 56400
	public float SprintMinAcceleration;

	// Token: 0x0400DC51 RID: 56401
	public float SprintBrakeAcceleration;

	// Token: 0x0400DC52 RID: 56402
	public float SprintMaxBackwardSpeed;

	// Token: 0x0400DC53 RID: 56403
	public float SprintBackwardAcceleration;

	// Token: 0x0400DC54 RID: 56404
	public float SprintMaxRotYawAcc;

	// Token: 0x0400DC55 RID: 56405
	public float SprintMinRotYawAcc;

	// Token: 0x0400DC56 RID: 56406
	public float SprintDuration;

	// Token: 0x0400DC57 RID: 56407
	public float SprintStopSpeed;

	// Token: 0x0400DC58 RID: 56408
	public float SprintExtraFriction;

	// Token: 0x0400DC59 RID: 56409
	public float SprintRotAngleCoef;

	// Token: 0x0400DC5A RID: 56410
	public float SprintRotSpeedCoef;

	// Token: 0x0400DC5B RID: 56411
	public float SprintRotConstCoef;

	// Token: 0x0400DC5C RID: 56412
	public float SprintMinFriction;

	// Token: 0x0400DC5D RID: 56413
	public float SprintMaxFriction;

	// Token: 0x0400DC5E RID: 56414
	public float SprintMaxRotationSpeed;

	// Token: 0x0400DC5F RID: 56415
	public float SprintRotFrictionFactor;

	// Token: 0x0400DC60 RID: 56416
	public float SprintStaticRotFriction;

	// Token: 0x0400DC61 RID: 56417
	public float SprintForceInputDuration;

	// Token: 0x0400DC62 RID: 56418
	public float SprintTurningForceForwardFactor;

	// Token: 0x0400DC63 RID: 56419
	public float SprintMaxForwardThreshold;

	// Token: 0x0400DC64 RID: 56420
	public float SprintMaxRightThreshold;

	// Token: 0x0400DC65 RID: 56421
	public float SprintCoolDown;

	// Token: 0x0400DC66 RID: 56422
	public int SprintMaxUsableCount;
}
