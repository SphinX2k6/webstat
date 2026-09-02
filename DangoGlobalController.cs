using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.NPC.Tuanzi.CommonConfig;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x02001B18 RID: 6936
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class DangoGlobalController : ControllerBase<DangoGlobalController>
{
	// Token: 0x0600C7DB RID: 51163 RVA: 0x0034E328 File Offset: 0x0034C528
	public void InitGlobalConfig(string configPath, [Nullable(2)] Action<bool> callback = null)
	{
		Singleton<ResourceSystem>.Instance.LoadAsync<BP_DangoGlobalConfig_C>(configPath, delegate([Nullable(2)] BP_DangoGlobalConfig_C result, string _)
		{
			if (result == null || !result.IsValid())
			{
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
				return;
			}
			else
			{
				DangoGlobalConfig config = DangoGlobalConfig.Create(result);
				ModelBase<DangoGlobalModel>.Instance.Config = config;
				Action<bool> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(true);
				return;
			}
		}, ResourceSystem.EResourceLoadPriority.Default, "Ui.DangoUi");
	}

	// Token: 0x0600C7DC RID: 51164 RVA: 0x0034E364 File Offset: 0x0034C564
	public void ApplyDangoMoveCamera(Vector lookAtPosition)
	{
		DangoGlobalConfig config = ModelBase<DangoGlobalModel>.Instance.Config;
		ECustomCameraMode? cameraMode = ModelBase<CameraModel>.Instance.MainModel.CameraMode;
		ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Free;
		if ((cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null) && config != null)
		{
			ControllerBase<CameraController>.Instance.MainModel.FreeCamera.LogicComponent.ApplyCameraBlend(lookAtPosition, null, (float)config.MovingCameraArmLength, config.MovingCameraBlendTime, config.MovingCameraCurve, config.MovingCameraFov, null);
		}
	}

	// Token: 0x0600C7DD RID: 51165 RVA: 0x0034E3DC File Offset: 0x0034C5DC
	public void ApplyDangoBeforeMoveCamera(Vector lookAtPosition, [Nullable(2)] Action callback = null)
	{
		DangoGlobalConfig config = ModelBase<DangoGlobalModel>.Instance.Config;
		ECustomCameraMode? cameraMode = ModelBase<CameraModel>.Instance.MainModel.CameraMode;
		ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Free;
		bool flag = cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null;
		ACameraActor cameraActor = ControllerBase<CameraController>.Instance.MainModel.FreeCamera.DisplayComponent.CameraActor;
		if (config == null || !flag || cameraActor == null || !cameraActor.IsValid())
		{
			if (callback != null)
			{
				callback();
			}
			return;
		}
		int beforeMoveCameraArmLength = config.BeforeMoveCameraArmLength;
		Quat quat = Quat.Create(0f, 0f, 0f, 1f);
		Vector vector = Vector.Create();
		Vector vector2 = Vector.Create();
		quat.FromUeQuat(cameraActor.K2_GetActorQuaternion());
		quat.RotateVector(Vector.ForwardVectorProxy, vector2);
		vector2.MultiplyEqual((double)(-(double)beforeMoveCameraArmLength));
		vector2.AdditionEqual(lookAtPosition);
		Vector vector3 = vector;
		FVectorDouble fvectorDouble = cameraActor.D_K2_GetActorLocation();
		vector3.FromUeVector(fvectorDouble);
		double num = Vector.Dist(vector2, vector);
		if (num < (double)config.BeforeMoveCameraTriggerDistance)
		{
			if (callback != null)
			{
				callback();
			}
			return;
		}
		float blendTime;
		if (num > (double)config.BeforeMoveCameraFarDistance)
		{
			blendTime = config.BeforeMoveCameraBlendTimeFar;
		}
		else
		{
			blendTime = (float)Singleton<MathUtils>.Instance.RangeClamp(num, (double)config.BeforeMoveCameraCloseDistanceEdgeMin, (double)config.BeforeMoveCameraCloseDistanceEdgeMax, (double)config.BeforeMoveCameraBlendTimeCloseMin, (double)config.BeforeMoveCameraBlendTimeCloseMax);
		}
		ControllerBase<CameraController>.Instance.MainModel.FreeCamera.LogicComponent.ApplyCameraBlend(lookAtPosition, null, (float)beforeMoveCameraArmLength, blendTime, config.BeforeMoveCameraCurve, config.BeforeMoveCameraFov, callback);
	}
}
