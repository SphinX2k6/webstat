using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Movement;
using UnrealEngine;

// Token: 0x0200303F RID: 12351
[NullableContext(1)]
[Nullable(0)]
public class SoarConfigParams : IStaticVariableResetter
{
	// Token: 0x06019463 RID: 103523 RVA: 0x00741C60 File Offset: 0x0073FE60
	static SoarConfigParams()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SoarConfigParams.CreateStaticDefaultValue), new Action(SoarConfigParams.ResetStaticDefaultValue));
	}

	// Token: 0x17002212 RID: 8722
	// (get) Token: 0x06019464 RID: 103524 RVA: 0x00741C7F File Offset: 0x0073FE7F
	public static SoarConfigParams SoarConfigBase
	{
		get
		{
			if (SoarConfigParams.SoarConfigBaseInternal == null)
			{
				SoarConfigParams.SoarConfigBaseInternal = new SoarConfigParams();
				SoarConfigParams.SoarConfigBaseInternal.Init(Singleton<ResourceSystem>.Instance.GetLoadedAsset<BP_SoarConfig_C>("/Game/Aki/Data/Fight/Movement/DA_SoarConfigBase.DA_SoarConfigBase"));
			}
			return SoarConfigParams.SoarConfigBaseInternal;
		}
	}

	// Token: 0x06019465 RID: 103525 RVA: 0x00741CB0 File Offset: 0x0073FEB0
	public static void ReInitSoarConfigBase()
	{
		if (SoarConfigParams.SoarConfigBaseInternal == null)
		{
			SoarConfigParams.SoarConfigBaseInternal = new SoarConfigParams();
		}
		SoarConfigParams.SoarConfigBaseInternal.Init(Singleton<ResourceSystem>.Instance.GetLoadedAsset<BP_SoarConfig_C>("/Game/Aki/Data/Fight/Movement/DA_SoarConfigBase.DA_SoarConfigBase"));
	}

	// Token: 0x06019466 RID: 103526 RVA: 0x00741CDC File Offset: 0x0073FEDC
	public SoarConfigParams()
	{
		this.SoarBalanceSpeed = (float)this.SoarBalanceVelocity.Size();
		this.SoarSplineInputAngleCos = (float)Math.Cos((double)(this.SoarSplineInputAngle * 0.017453292f));
		this.SoarSplineInputAngleSin = (float)Math.Sin((double)(this.SoarSplineInputAngle * 0.017453292f));
		this.SoarSplineInputDirectMinX = (float)Math.Sin((double)(this.SoarPitchMin * 0.017453292f));
	}

	// Token: 0x06019467 RID: 103527 RVA: 0x00741EF4 File Offset: 0x007400F4
	public void Init(BP_SoarConfig_C ueConfig)
	{
		this.SoarInputNormalAngleMin = ueConfig.阻挡面角度极限最小值;
		this.SoarInputNormalAngleMax = ueConfig.阻挡面角度极限最大值;
		this.SoarAerodynamicsMin = ueConfig.空气阻力面系数最小值;
		this.SoarAerodynamicsMax = ueConfig.空气阻力面系数最大值;
		this.SoarSpeedThresholdMin = ueConfig.阻挡面最小值对应速度值;
		this.SoarSpeedThresholdMax = ueConfig.阻挡面最大值对应速度值;
		this.SoarPitchMin = ueConfig.阻挡面最小角度;
		this.SoarPitchMax = ueConfig.阻挡面最大角度;
		this.SoarNormalSpeedNoInput = ueConfig.无输入时阻挡面转速;
		Vector soarBalanceVelocity = this.SoarBalanceVelocity;
		FVector 满抬升输入时平衡速度向量 = ueConfig.满抬升输入时平衡速度向量;
		FVectorDouble fvectorDouble = 满抬升输入时平衡速度向量;
		soarBalanceVelocity.DeepCopy(fvectorDouble);
		this.SoarBalanceSpeed = (float)this.SoarBalanceVelocity.Size();
		this.SoarBalanceInputThreshold = ueConfig.满抬升输入判定阈值;
		this.SoarBalanceAccelMin = ueConfig.平衡用最小加速度;
		this.SoarBalanceAccelMax = ueConfig.平衡用最大加速度;
		this.SoarBalanceAccelOffset = ueConfig.平衡使用最大值对应速度差;
		this.SoarBalanceSpeedThreshold = ueConfig.满抬升输入平衡开启速度阈值;
		this.SoarBalanceSpeed2 = ueConfig.非满抬升输入平衡速度值;
		this.SoarBalanceSpeedThreshold2 = ueConfig.非满抬升输入平衡开启速度阈值;
		this.SoarNormalSpeed = ueConfig.阻挡面转速第一段线性;
		this.SoarNormalLerp = ueConfig.阻挡面转速第二段比例;
		this.SoarRotateSpeed = ueConfig.面向转速第一段线性;
		this.SoarRotateLerp = ueConfig.面向转速第二段比例;
		this.SoarBoostNormalSpeed = ueConfig.Boost阻挡面转速第一段线性;
		this.SoarBoostNormalLerp = ueConfig.Boost阻挡面转速第二段比例;
		this.SoarBoostAccel = ueConfig.Boost加速度;
		this.SoarSplineMinSpeed = ueConfig.风道最小速度;
		this.SoarSplineAccel = ueConfig.风道最大加速度;
		this.SoarSplineRotateAngleSpeedWithoutInput = ueConfig.风道无输入面向修正速度;
		this.SoarSplineRotateAngleSpeedWithInput = ueConfig.风道有输入面向修正速度;
		this.SoarSplineRotateLerp = ueConfig.风道转向第二段比例;
		this.SoarSplinePushCenterDistMin = ueConfig.风道中线拉回最小速对应距离;
		this.SoarSplinePushCenterDistMax = ueConfig.风道中线拉回最大速对应距离;
		this.SoarSplinePushCenterSpeedMin = ueConfig.风道中线拉回最小速度;
		this.SoarSplinePushCenterSpeedMax = ueConfig.风道中线拉回最大速度;
		this.SoarSplineInputAngle = ueConfig.风道输入对应偏转;
		this.SoarSplineInputAngleCos = (float)Math.Cos((double)(this.SoarSplineInputAngle * 0.017453292f));
		this.SoarSplineInputAngleSin = (float)Math.Sin((double)(this.SoarSplineInputAngle * 0.017453292f));
		this.SoarSplineInputDirectMinX = (float)Math.Sin((double)(this.SoarPitchMin * 0.017453292f));
		this.SoarAirFriction = ueConfig.空气阻力;
		this.SoarGravityValue = ueConfig.重力加速度;
		this.SoarMaxSpeed = ueConfig.最大速度;
		this.SoarHitWallExitTimeLength = ueConfig.撞墙结束时间;
		this.DebugDraw = (GlobalData.IsPlayInEditor && ueConfig.DebugDraw);
	}

	// Token: 0x06019468 RID: 103528 RVA: 0x0074214C File Offset: 0x0074034C
	public static void CreateStaticDefaultValue()
	{
		SoarConfigParams.SoarConfigBaseInternal = null;
	}

	// Token: 0x06019469 RID: 103529 RVA: 0x00742154 File Offset: 0x00740354
	public static void ResetStaticDefaultValue()
	{
		SoarConfigParams.SoarConfigBaseInternal = null;
	}

	// Token: 0x0400C723 RID: 50979
	[Nullable(2)]
	private static SoarConfigParams SoarConfigBaseInternal;

	// Token: 0x0400C724 RID: 50980
	public float SoarInputNormalAngleMin = 12.38f;

	// Token: 0x0400C725 RID: 50981
	public float SoarInputNormalAngleMax = 45f;

	// Token: 0x0400C726 RID: 50982
	public float SoarAerodynamicsMin = 4.9f;

	// Token: 0x0400C727 RID: 50983
	public float SoarAerodynamicsMax = 30f;

	// Token: 0x0400C728 RID: 50984
	public float SoarSpeedThresholdMin = 1700f;

	// Token: 0x0400C729 RID: 50985
	public float SoarSpeedThresholdMax = 2200f;

	// Token: 0x0400C72A RID: 50986
	public float SoarPitchMin = 10f;

	// Token: 0x0400C72B RID: 50987
	public float SoarPitchMax = 140f;

	// Token: 0x0400C72C RID: 50988
	public float SoarNormalSpeedNoInput = 6f;

	// Token: 0x0400C72D RID: 50989
	public Vector SoarBalanceVelocity = Vector.Create(1650.0, 0.0, -385.0);

	// Token: 0x0400C72E RID: 50990
	public float SoarBalanceSpeed;

	// Token: 0x0400C72F RID: 50991
	public float SoarBalanceInputThreshold = -0.8f;

	// Token: 0x0400C730 RID: 50992
	public float SoarBalanceAccelMin = 100f;

	// Token: 0x0400C731 RID: 50993
	public float SoarBalanceAccelMax = 1000f;

	// Token: 0x0400C732 RID: 50994
	public float SoarBalanceAccelOffset = 400f;

	// Token: 0x0400C733 RID: 50995
	public float SoarBalanceSpeedThreshold = 1700f;

	// Token: 0x0400C734 RID: 50996
	public float SoarBalanceSpeed2 = 1500f;

	// Token: 0x0400C735 RID: 50997
	public float SoarBalanceSpeedThreshold2 = 1500f;

	// Token: 0x0400C736 RID: 50998
	public float SoarNormalSpeed = 200f;

	// Token: 0x0400C737 RID: 50999
	public float SoarNormalLerp = 0.95f;

	// Token: 0x0400C738 RID: 51000
	public float SoarRotateSpeed = 65f;

	// Token: 0x0400C739 RID: 51001
	public float SoarRotateLerp = 0.98f;

	// Token: 0x0400C73A RID: 51002
	public float SoarBoostNormalSpeed = 50f;

	// Token: 0x0400C73B RID: 51003
	public float SoarBoostNormalLerp = 0.95f;

	// Token: 0x0400C73C RID: 51004
	public float SoarBoostAccel = 5000f;

	// Token: 0x0400C73D RID: 51005
	public float SoarSplineMinSpeed = 500f;

	// Token: 0x0400C73E RID: 51006
	public float SoarSplineAccel = 500f;

	// Token: 0x0400C73F RID: 51007
	public float SoarSplineRotateAngleSpeedWithoutInput = 360f;

	// Token: 0x0400C740 RID: 51008
	public float SoarSplineRotateAngleSpeedWithInput = 180f;

	// Token: 0x0400C741 RID: 51009
	public float SoarSplineRotateLerp = 0.95f;

	// Token: 0x0400C742 RID: 51010
	public float SoarSplinePushCenterDistMin;

	// Token: 0x0400C743 RID: 51011
	public float SoarSplinePushCenterDistMax = 800f;

	// Token: 0x0400C744 RID: 51012
	public float SoarSplinePushCenterSpeedMin;

	// Token: 0x0400C745 RID: 51013
	public float SoarSplinePushCenterSpeedMax = 300f;

	// Token: 0x0400C746 RID: 51014
	public float SoarSplineInputAngle = 30f;

	// Token: 0x0400C747 RID: 51015
	public float SoarSplineInputAngleCos;

	// Token: 0x0400C748 RID: 51016
	public float SoarSplineInputAngleSin;

	// Token: 0x0400C749 RID: 51017
	public float SoarSplineInputDirectMinX;

	// Token: 0x0400C74A RID: 51018
	public float SoarAirFriction = 0.02f;

	// Token: 0x0400C74B RID: 51019
	public float SoarGravityValue = 1900f;

	// Token: 0x0400C74C RID: 51020
	public float SoarMaxSpeed = 3000f;

	// Token: 0x0400C74D RID: 51021
	public float SoarHitWallExitTimeLength = 1500f;

	// Token: 0x0400C74E RID: 51022
	public bool DebugDraw;
}
