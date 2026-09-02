using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.NPC.Tuanzi.CommonConfig;
using UnrealEngine;

// Token: 0x02001B17 RID: 6935
[NullableContext(2)]
[Nullable(0)]
public class DangoGlobalConfig
{
	// Token: 0x0600C7D8 RID: 51160 RVA: 0x0034DFAC File Offset: 0x0034C1AC
	[NullableContext(1)]
	public static DangoGlobalConfig Create(BP_DangoGlobalConfig_C configAsset)
	{
		DangoGlobalConfig dangoGlobalConfig = new DangoGlobalConfig();
		dangoGlobalConfig.ConfigAsset = configAsset;
		dangoGlobalConfig.AttachSocketName = new FName?(configAsset.堆叠绑定骨骼名称);
		dangoGlobalConfig.StackInterval = configAsset.堆叠间隔;
		dangoGlobalConfig.MoveStartingTime = configAsset.跳跃前摇时间;
		dangoGlobalConfig.MoveTime = configAsset.跳跃移动时间;
		dangoGlobalConfig.MoveTotalTime = configAsset.跳跃前摇时间 + configAsset.跳跃移动时间 + configAsset.跳跃后摇时间;
		dangoGlobalConfig.MoveRotateSpeed = configAsset.跳跃旋转速度;
		dangoGlobalConfig.MoveBaseHeightOffset = configAsset.跳跃高度偏移基准;
		dangoGlobalConfig.MaxRiseHeightEdge = Math.Abs(configAsset.跳跃上升偏移曲线高度范围);
		dangoGlobalConfig.MaxFallHeightEdge = Math.Abs(configAsset.跳跃下降偏移曲线高度范围);
		dangoGlobalConfig.MoveRiseCurve = configAsset.跳跃上升偏移曲线;
		dangoGlobalConfig.MoveFallCurve = configAsset.跳跃下降偏移曲线;
		dangoGlobalConfig.BlankHoleFallCurve = configAsset.黑洞下降偏移曲线;
		dangoGlobalConfig.BeforeMoveCameraTriggerDistance = configAsset.跳跃前镜头死区距离基准;
		dangoGlobalConfig.BeforeMoveCameraArmLength = configAsset.跳跃前镜头臂长;
		FInt32Range 跳跃前镜头近距离追踪时间范围 = configAsset.跳跃前镜头近距离追踪时间范围;
		dangoGlobalConfig.BeforeMoveCameraBlendTimeCloseMin = (float)跳跃前镜头近距离追踪时间范围.LowerBound.Value * 0.001f;
		dangoGlobalConfig.BeforeMoveCameraBlendTimeCloseMax = (float)跳跃前镜头近距离追踪时间范围.UpperBound.Value * 0.001f;
		FInt32Range 跳跃前镜头近距离基准范围 = configAsset.跳跃前镜头近距离基准范围;
		dangoGlobalConfig.BeforeMoveCameraCloseDistanceEdgeMin = 跳跃前镜头近距离基准范围.LowerBound.Value;
		dangoGlobalConfig.BeforeMoveCameraCloseDistanceEdgeMax = 跳跃前镜头近距离基准范围.UpperBound.Value;
		dangoGlobalConfig.BeforeMoveCameraBlendTimeFar = (float)configAsset.跳跃前镜头远距离追踪时间 * 0.001f;
		dangoGlobalConfig.BeforeMoveCameraFarDistance = configAsset.跳跃前镜头远距离基准;
		dangoGlobalConfig.BeforeMoveCameraFov = configAsset.跳跃前镜头FOV;
		dangoGlobalConfig.BeforeMoveCameraCurve = CurveUtils.CreateCurveByStruct(configAsset.跳跃前镜头曲线);
		dangoGlobalConfig.MovingCameraArmLength = configAsset.跳跃中镜头臂长;
		dangoGlobalConfig.MovingCameraBlendTime = (float)configAsset.跳跃中镜头追踪时间 * 0.001f;
		dangoGlobalConfig.MovingCameraFov = configAsset.跳跃中镜头FOV;
		dangoGlobalConfig.MovingCameraCurve = CurveUtils.CreateCurveByStruct(configAsset.跳跃中镜头曲线);
		foreach (KeyValuePair<TEnumAsByte<EDangoPerformType>, SDangoPerformData> keyValuePair in configAsset.动作表现)
		{
			TEnumAsByte<EDangoPerformType> tenumAsByte;
			SDangoPerformData sdangoPerformData;
			keyValuePair.Deconstruct(out tenumAsByte, out sdangoPerformData);
			TEnumAsByte<EDangoPerformType> value = tenumAsByte;
			SDangoPerformData sdangoPerformData2 = sdangoPerformData;
			if (!(sdangoPerformData2 == null))
			{
				DangoPerformConfig dangoPerformConfig = new DangoPerformConfig();
				dangoPerformConfig.ActionType = sdangoPerformData2.动画类型;
				dangoPerformConfig.ActionTargetType = sdangoPerformData2.动画目标类型;
				dangoPerformConfig.RecursionActionType = sdangoPerformData2.堆叠上方团子动画类型;
				dangoPerformConfig.Duration = sdangoPerformData2.持续时间;
				foreach (SDangoPerformEffectData sdangoPerformEffectData in sdangoPerformData2.特效列表)
				{
					DangoPerformEffectConfig dangoPerformEffectConfig = new DangoPerformEffectConfig();
					dangoPerformEffectConfig.EffectPath = sdangoPerformEffectData.特效路径.ToAssetPathName();
					dangoPerformEffectConfig.PerformLocationType = sdangoPerformEffectData.特效位置类型;
					Vector locationOffset = dangoPerformEffectConfig.LocationOffset;
					FVector 位置偏移 = sdangoPerformEffectData.位置偏移;
					locationOffset.FromUeVector(位置偏移);
					dangoPerformEffectConfig.DelayTime = sdangoPerformEffectData.释放延迟时间;
					if (!FNameUtil.IsNothing(sdangoPerformEffectData.骨骼名称))
					{
						dangoPerformEffectConfig.AttachSocket = new FName?(sdangoPerformEffectData.骨骼名称);
					}
					dangoPerformConfig.EffectConfigList.Add(dangoPerformEffectConfig);
				}
				dangoGlobalConfig.PerformConfigMap.Add(value, dangoPerformConfig);
			}
		}
		return dangoGlobalConfig;
	}

	// Token: 0x0600C7D9 RID: 51161 RVA: 0x0034E304 File Offset: 0x0034C504
	public DangoPerformConfig GetPerformConfig(EDangoPerformType type)
	{
		return this.PerformConfigMap.GetValueOrDefault(type);
	}

	// Token: 0x04005FB0 RID: 24496
	public BP_DangoGlobalConfig_C ConfigAsset;

	// Token: 0x04005FB1 RID: 24497
	public FName? AttachSocketName;

	// Token: 0x04005FB2 RID: 24498
	public int StackInterval;

	// Token: 0x04005FB3 RID: 24499
	public int MoveStartingTime;

	// Token: 0x04005FB4 RID: 24500
	public int MoveTime;

	// Token: 0x04005FB5 RID: 24501
	public int MoveTotalTime;

	// Token: 0x04005FB6 RID: 24502
	public int MoveRotateSpeed;

	// Token: 0x04005FB7 RID: 24503
	public int MoveBaseHeightOffset;

	// Token: 0x04005FB8 RID: 24504
	public int MaxRiseHeightEdge;

	// Token: 0x04005FB9 RID: 24505
	public int MaxFallHeightEdge;

	// Token: 0x04005FBA RID: 24506
	public UCurveFloat MoveRiseCurve;

	// Token: 0x04005FBB RID: 24507
	public UCurveFloat MoveFallCurve;

	// Token: 0x04005FBC RID: 24508
	public UCurveFloat BlankHoleFallCurve;

	// Token: 0x04005FBD RID: 24509
	public int BeforeMoveCameraTriggerDistance;

	// Token: 0x04005FBE RID: 24510
	public int BeforeMoveCameraArmLength;

	// Token: 0x04005FBF RID: 24511
	public float BeforeMoveCameraBlendTimeCloseMin;

	// Token: 0x04005FC0 RID: 24512
	public float BeforeMoveCameraBlendTimeCloseMax;

	// Token: 0x04005FC1 RID: 24513
	public int BeforeMoveCameraCloseDistanceEdgeMin;

	// Token: 0x04005FC2 RID: 24514
	public int BeforeMoveCameraCloseDistanceEdgeMax;

	// Token: 0x04005FC3 RID: 24515
	public int BeforeMoveCameraFarDistance;

	// Token: 0x04005FC4 RID: 24516
	public float BeforeMoveCameraBlendTimeFar;

	// Token: 0x04005FC5 RID: 24517
	public float BeforeMoveCameraFov;

	// Token: 0x04005FC6 RID: 24518
	public CurveBase BeforeMoveCameraCurve;

	// Token: 0x04005FC7 RID: 24519
	public int MovingCameraArmLength;

	// Token: 0x04005FC8 RID: 24520
	public float MovingCameraBlendTime;

	// Token: 0x04005FC9 RID: 24521
	public float MovingCameraFov;

	// Token: 0x04005FCA RID: 24522
	public CurveBase MovingCameraCurve;

	// Token: 0x04005FCB RID: 24523
	[Nullable(1)]
	private readonly Dictionary<EDangoPerformType, DangoPerformConfig> PerformConfigMap = new Dictionary<EDangoPerformType, DangoPerformConfig>();
}
