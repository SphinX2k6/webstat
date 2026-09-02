using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;

// Token: 0x02000E05 RID: 3589
[NullableContext(1)]
[Nullable(0)]
public class CameraConfig
{
	// Token: 0x06005451 RID: 21585 RVA: 0x000CB900 File Offset: 0x000C9B00
	public CameraConfig(SCameraConfig config)
	{
		this.Type = config.Type;
		this.Tag = ((config.Tag.TagName == FName.NAME_None) ? null : new FGameplayTag?(config.Tag));
		this.PcValid = config.PC生效;
		this.MobileValid = config.手机生效;
		this.Priority = config.优先级;
		this.EnableModifyCamera = config.启用Modify镜头;
		this.EnableAdjustCamera = config.启用技能修正镜头;
		this.EnableAutoCamera = config.启用自动镜头;
		this.EnableFocusCamera = config.启用锁定镜头;
		this.EnableSidestepCamera = config.启用移动自动镜头;
		this.EnableClimbCamera = config.启用攀爬镜头;
		this.FadeInTime = config.淡入时间;
		this.FadeInCurve = CurveUtils.CreateCurveByStruct(config.淡入曲线);
		this.FadeOutTime = config.淡出时间;
		this.FadeOutCurve = CurveUtils.CreateCurveByStruct(config.淡出曲线);
		this.LockOnParts = FightCameraLogicComponent.TArrayToArray<string>(config.锁定点名称);
		this.DefaultConfig = FightCameraLogicComponent.TMapToMap<EFightCameraDefault>(config.基础);
		this.DefaultCurveConfig = FightCameraLogicComponent.TMapToCurveMap<EFightCameraDefault>(config.基础曲线配置);
		this.AdjustConfig = FightCameraLogicComponent.TMapToMap<EFightCameraAdjust>(config.技能修正);
		this.CurveAdjustConfig = FightCameraLogicComponent.TMapToCurveMap<EFightCameraAdjust>(config.技能修正曲线配置);
		this.AutoConfig = FightCameraLogicComponent.TMapToMap<EFightCameraAuto>(config.自动镜头);
		this.CurveAutoConfig = FightCameraLogicComponent.TMapToCurveMap<EFightCameraAuto>(config.自动镜头曲线配置);
		this.FocusConfig = FightCameraLogicComponent.TMapToMap<EFightCameraFocus>(config.锁定镜头);
		this.CurveFocusConfig = FightCameraLogicComponent.TMapToCurveMap<EFightCameraFocus>(config.锁定镜头曲线配置);
		this.InputConfig = FightCameraLogicComponent.TMapToMap<EFightCameraInput>(config.镜头输入);
		this.CurveInputConfig = FightCameraLogicComponent.TMapToCurveMap<EFightCameraInput>(config.镜头输入曲线配置);
		this.ModifyConfig = FightCameraLogicComponent.TMapToMap<EFightCameraModify>(config.Modify镜头);
		this.CurveModifyConfig = FightCameraLogicComponent.TMapToCurveMap<EFightCameraModify>(config.Modify镜头曲线配置);
		this.GuideConfig = FightCameraLogicComponent.TMapToMap<EFightCameraGuide>(config.引导镜头);
		this.CurveGuideConfig = FightCameraLogicComponent.TMapToCurveMap<EFightCameraGuide>(config.引导镜头曲线配置);
		this.ExploreConfig = FightCameraLogicComponent.TMapToMap<EFightCameraExplore>(config.跑图镜头);
		this.CurveExploreConfig = FightCameraLogicComponent.TMapToCurveMap<EFightCameraExplore>(config.跑图镜头曲线配置);
		this.DialogueConfig = FightCameraLogicComponent.TMapToMap<EFightCameraDialogue>(config.对话镜头);
		this.CurveDialogueConfig = FightCameraLogicComponent.TMapToCurveMap<EFightCameraDialogue>(config.对话镜头曲线配置);
		this.ClimbConfig = FightCameraLogicComponent.TMapToMap<EFightCameraClimb>(config.攀爬镜头);
		this.CurveClimbConfig = FightCameraLogicComponent.TMapToCurveMap<EFightCameraClimb>(config.攀爬镜头曲线配置);
		this.SidestepConfig = FightCameraLogicComponent.TMapToMap<EFightCameraSidestep>(config.移动自动镜头);
		this.CurveSidestepConfig = FightCameraLogicComponent.TMapToCurveMap<EFightCameraSidestep>(config.移动自动镜头曲线配置);
		this.VehicleConfig = FightCameraLogicComponent.TMapToMap<EFightCameraVehicle>(config.载具镜头);
		this.VehicleCurveConfig = FightCameraLogicComponent.TMapToCurveMap<EFightCameraVehicle>(config.载具镜头曲线配置);
		this.GravityConfig = FightCameraLogicComponent.TMapToMap<EFightCameraGravity>(config.镜头重力);
		this.IsOpenMainLoop = config.是否开启主镜头缓入缓出;
		this.IsResetDefaultConfig = config.是否重置默认配置;
		this.IsResetCameraLock = config.是否重置镜头锁定;
		this.IsUniqueFade = config.是否独立过渡时间;
		this.CameraArmLocationSocketName = config.主控角色骨骼;
		this.CameraArmLocationSocketOverrideType = config.主控角色骨骼覆盖方式;
	}

	// Token: 0x0400192E RID: 6446
	public EFightCameraType Type;

	// Token: 0x0400192F RID: 6447
	public FGameplayTag? Tag;

	// Token: 0x04001930 RID: 6448
	public bool PcValid;

	// Token: 0x04001931 RID: 6449
	public bool MobileValid;

	// Token: 0x04001932 RID: 6450
	public int Priority;

	// Token: 0x04001933 RID: 6451
	public bool EnableModifyCamera;

	// Token: 0x04001934 RID: 6452
	public bool EnableAdjustCamera;

	// Token: 0x04001935 RID: 6453
	public bool EnableAutoCamera;

	// Token: 0x04001936 RID: 6454
	public bool EnableFocusCamera;

	// Token: 0x04001937 RID: 6455
	public bool EnableSidestepCamera;

	// Token: 0x04001938 RID: 6456
	public bool EnableClimbCamera;

	// Token: 0x04001939 RID: 6457
	public float FadeInTime;

	// Token: 0x0400193A RID: 6458
	public CurveBase FadeInCurve;

	// Token: 0x0400193B RID: 6459
	public float FadeOutTime;

	// Token: 0x0400193C RID: 6460
	public CurveBase FadeOutCurve;

	// Token: 0x0400193D RID: 6461
	public bool IsOpenMainLoop;

	// Token: 0x0400193E RID: 6462
	public string[] LockOnParts;

	// Token: 0x0400193F RID: 6463
	public Dictionary<EFightCameraDefault, float> DefaultConfig;

	// Token: 0x04001940 RID: 6464
	public Dictionary<EFightCameraDefault, CurveBase> DefaultCurveConfig;

	// Token: 0x04001941 RID: 6465
	public Dictionary<EFightCameraAdjust, float> AdjustConfig;

	// Token: 0x04001942 RID: 6466
	public Dictionary<EFightCameraAdjust, CurveBase> CurveAdjustConfig;

	// Token: 0x04001943 RID: 6467
	public Dictionary<EFightCameraAuto, float> AutoConfig;

	// Token: 0x04001944 RID: 6468
	public Dictionary<EFightCameraAuto, CurveBase> CurveAutoConfig;

	// Token: 0x04001945 RID: 6469
	public Dictionary<EFightCameraFocus, float> FocusConfig;

	// Token: 0x04001946 RID: 6470
	public Dictionary<EFightCameraFocus, CurveBase> CurveFocusConfig;

	// Token: 0x04001947 RID: 6471
	public Dictionary<EFightCameraInput, float> InputConfig;

	// Token: 0x04001948 RID: 6472
	public Dictionary<EFightCameraInput, CurveBase> CurveInputConfig;

	// Token: 0x04001949 RID: 6473
	public Dictionary<EFightCameraModify, float> ModifyConfig;

	// Token: 0x0400194A RID: 6474
	public Dictionary<EFightCameraModify, CurveBase> CurveModifyConfig;

	// Token: 0x0400194B RID: 6475
	public Dictionary<EFightCameraGuide, float> GuideConfig;

	// Token: 0x0400194C RID: 6476
	public Dictionary<EFightCameraGuide, CurveBase> CurveGuideConfig;

	// Token: 0x0400194D RID: 6477
	public Dictionary<EFightCameraExplore, float> ExploreConfig;

	// Token: 0x0400194E RID: 6478
	public Dictionary<EFightCameraExplore, CurveBase> CurveExploreConfig;

	// Token: 0x0400194F RID: 6479
	public Dictionary<EFightCameraDialogue, float> DialogueConfig;

	// Token: 0x04001950 RID: 6480
	public Dictionary<EFightCameraDialogue, CurveBase> CurveDialogueConfig;

	// Token: 0x04001951 RID: 6481
	public Dictionary<EFightCameraClimb, float> ClimbConfig;

	// Token: 0x04001952 RID: 6482
	public Dictionary<EFightCameraClimb, CurveBase> CurveClimbConfig;

	// Token: 0x04001953 RID: 6483
	public Dictionary<EFightCameraSidestep, float> SidestepConfig;

	// Token: 0x04001954 RID: 6484
	public Dictionary<EFightCameraSidestep, CurveBase> CurveSidestepConfig;

	// Token: 0x04001955 RID: 6485
	public Dictionary<EFightCameraVehicle, float> VehicleConfig;

	// Token: 0x04001956 RID: 6486
	public Dictionary<EFightCameraVehicle, CurveBase> VehicleCurveConfig;

	// Token: 0x04001957 RID: 6487
	public Dictionary<EFightCameraGravity, float> GravityConfig;

	// Token: 0x04001958 RID: 6488
	public Dictionary<EFightCameraGravity, CurveBase> GravityCurveConfig = new Dictionary<EFightCameraGravity, CurveBase>();

	// Token: 0x04001959 RID: 6489
	public bool IsResetDefaultConfig;

	// Token: 0x0400195A RID: 6490
	public bool IsResetCameraLock;

	// Token: 0x0400195B RID: 6491
	public bool IsUniqueFade;

	// Token: 0x0400195C RID: 6492
	public FName CameraArmLocationSocketName = FNameUtil.EMPTY;

	// Token: 0x0400195D RID: 6493
	public EFightCameraSocketOverrideType CameraArmLocationSocketOverrideType;
}
