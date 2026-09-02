using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x0200102C RID: 4140
[NullableContext(2)]
[Nullable(0)]
public class FurnitureCameraComponent
{
	// Token: 0x06006BA9 RID: 27561 RVA: 0x001C3724 File Offset: 0x001C1924
	public void EnterAreaCamera(int areaCameraId, IFurnitureCameraFadeInContext fadeInContext = null)
	{
		this.CameraMode = EFurnitureCameraMode.AreaCamera;
		FurnitureAreaCameraContext areaCameraContext = new FurnitureAreaCameraContext
		{
			AreaCameraId = areaCameraId
		};
		this.AreaCameraContext = areaCameraContext;
		SpringFestivalAreaCamera? areaCameraConfig = ConfigBase<FurnitureConfig>.Instance.GetAreaCameraConfig(areaCameraId);
		global::Vector vector = global::Vector.Create();
		vector.FromConfigVector(areaCameraConfig.Value.CameraLocation.Value);
		Aki.Config.Vector value = areaCameraConfig.Value.CameraRotator.Value;
		Rotator rot = Rotator.Create(value.Y, value.Z, value.X);
		FurnitureCameraContext cameraContext = new FurnitureCameraContext
		{
			Pos = vector,
			Rot = rot,
			Fov = (float)areaCameraConfig.Value.CameraFov
		};
		IFurnitureCameraFadeInContext furnitureCameraFadeInContext = fadeInContext;
		if (fadeInContext == null)
		{
			FurnitureCameraFadeInContext furnitureCameraFadeInContext2 = new FurnitureCameraFadeInContext();
			furnitureCameraFadeInContext2.FadeInTime = 0f;
			furnitureCameraFadeInContext = furnitureCameraFadeInContext2;
			furnitureCameraFadeInContext2.FadeInExp = 1f;
		}
		IFurnitureCameraFadeInContext fadeInContext2 = furnitureCameraFadeInContext;
		this.EnterCameraInternal(cameraContext, fadeInContext2);
	}

	// Token: 0x06006BAA RID: 27562 RVA: 0x001C380C File Offset: 0x001C1A0C
	[NullableContext(1)]
	public void EnterSlotCamera(IFurnitureSlotContext slotContext, [Nullable(2)] IFurnitureCameraFadeInContext fadeInContext = null)
	{
		this.CameraMode = EFurnitureCameraMode.SlotCamera;
		this.SlotContext = slotContext;
		int mapId = ModelBase<FurnitureModel>.Instance.MapId;
		int slotEntityId = slotContext.SlotEntityId;
		FurnitureSlotComponent sceneSlotEntitySlotComponentData = ModelBase<FurnitureModel>.Instance.GetSceneSlotEntitySlotComponentData(mapId, slotEntityId);
		if (sceneSlotEntitySlotComponentData == null)
		{
			return;
		}
		int subSlotIndex = slotContext.SubSlotIndex;
		bool flag = subSlotIndex == -1;
		IFurnitureCamera furnitureCamera = sceneSlotEntitySlotComponentData.FurnitureCamera;
		if (furnitureCamera == null)
		{
			return;
		}
		if (!flag)
		{
			IFurnitureSlot furnitureSlot = sceneSlotEntitySlotComponentData.Slots[subSlotIndex];
			IFurnitureCamera furnitureCamera2 = (furnitureSlot != null) ? furnitureSlot.SlotCamera : null;
			if (furnitureCamera2 != null)
			{
				furnitureCamera = furnitureCamera2;
			}
		}
		global::Vector vector = global::Vector.Create();
		vector.FromConfigVector(furnitureCamera.Pos);
		Rotator rot = Rotator.Create(furnitureCamera.Rot.Y.GetValueOrDefault(), furnitureCamera.Rot.Z.GetValueOrDefault(), furnitureCamera.Rot.X.GetValueOrDefault());
		int valueOrDefault = furnitureCamera.Fov.GetValueOrDefault(75);
		FurnitureCameraContext cameraContext = new FurnitureCameraContext
		{
			Pos = vector,
			Rot = rot,
			Fov = (float)valueOrDefault
		};
		IFurnitureCameraFadeInContext furnitureCameraFadeInContext = fadeInContext;
		if (furnitureCameraFadeInContext == null)
		{
			float? fadeInTime = furnitureCamera.FadeInTime;
			IBlendFunction fadeInCurve = furnitureCamera.FadeInCurve;
			float? num = (fadeInCurve != null) ? new float?(fadeInCurve.BlendExp) : null;
			bool flag2 = fadeInTime != null;
			bool flag3 = num != null;
			float? num2 = flag2 ? fadeInTime : new float?(0.5f);
			float? num3 = flag3 ? num : new float?(16f);
			furnitureCameraFadeInContext = new FurnitureCameraFadeInContext
			{
				FadeInTime = num2.Value,
				FadeInExp = num3.Value
			};
		}
		this.EnterCameraInternal(cameraContext, furnitureCameraFadeInContext);
	}

	// Token: 0x06006BAB RID: 27563 RVA: 0x001C39B0 File Offset: 0x001C1BB0
	[NullableContext(1)]
	private void EnterCameraInternal(IFurnitureCameraContext cameraContext, IFurnitureCameraFadeInContext fadeInContext)
	{
		this.CameraContext = cameraContext;
		SceneCameraPlayerComponent playerComponent = ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent;
		if (playerComponent == null)
		{
			return;
		}
		playerComponent.EnterFixSceneSubCamera(cameraContext.Pos, cameraContext.Rot, cameraContext.Fov, fadeInContext.FadeInTime, 0f, ESceneSubCameraType.Fix, null, new UnrealEngine.EViewTargetBlendFunction?(UnrealEngine.EViewTargetBlendFunction.VTBlend_EaseOut), new float?(fadeInContext.FadeInExp), new UnrealEngine.EViewTargetBlendFunction?(UnrealEngine.EViewTargetBlendFunction.VTBlend_Linear), new float?(0f), new bool?(false), null, new bool?(false), null, "", null, null, null, false, false);
	}

	// Token: 0x06006BAC RID: 27564 RVA: 0x001C3A3B File Offset: 0x001C1C3B
	public void ExitFurnitureCamera()
	{
		ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent.ExitFixSceneSubCamera(null, true);
	}

	// Token: 0x06006BAD RID: 27565 RVA: 0x001C3A58 File Offset: 0x001C1C58
	public EFurnitureCameraMode GetCameraMode()
	{
		return this.CameraMode;
	}

	// Token: 0x06006BAE RID: 27566 RVA: 0x001C3A60 File Offset: 0x001C1C60
	public IFurnitureCameraContext GetCameraContext()
	{
		return this.CameraContext;
	}

	// Token: 0x06006BAF RID: 27567 RVA: 0x001C3A68 File Offset: 0x001C1C68
	public IFurnitureSlotContext GetSlotContext()
	{
		return this.SlotContext;
	}

	// Token: 0x06006BB0 RID: 27568 RVA: 0x001C3A70 File Offset: 0x001C1C70
	public IFurnitureAreaCameraContext GetAreaCameraContext()
	{
		return this.AreaCameraContext;
	}

	// Token: 0x0400333C RID: 13116
	private EFurnitureCameraMode CameraMode;

	// Token: 0x0400333D RID: 13117
	private IFurnitureCameraContext CameraContext;

	// Token: 0x0400333E RID: 13118
	private IFurnitureSlotContext SlotContext;

	// Token: 0x0400333F RID: 13119
	private IFurnitureAreaCameraContext AreaCameraContext;
}
