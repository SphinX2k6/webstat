using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Module.Plot;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070B5 RID: 28853
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneCameraPlayerComponent : EntityComponent
	{
		// Token: 0x06045F24 RID: 286500 RVA: 0x01254880 File Offset: 0x01252A80
		protected override bool OnCreate(IEntityArgs args = null)
		{
			this.CameraModelInstanceInternal = ((args != null) ? args.GetP1<CameraModelInstance>() : null);
			return base.OnCreate(args);
		}

		// Token: 0x06045F25 RID: 286501 RVA: 0x0125489B File Offset: 0x01252A9B
		protected override bool OnStart()
		{
			this.DisplayComponent = base.Entity.GetComponent<SceneCameraDisplayComponent>();
			this.SceneCameraInputComponent = base.Entity.GetComponent<SceneCameraInputComponent>();
			this.FixSceneSubCameraList = new List<SceneSubCamera>();
			return this.DisplayComponent.Valid;
		}

		// Token: 0x06045F26 RID: 286502 RVA: 0x012548D5 File Offset: 0x01252AD5
		protected override bool OnEnd()
		{
			this.DisplayComponent = null;
			this.SceneCameraInputComponent = null;
			this.FixSceneSubCameraList = null;
			return true;
		}

		// Token: 0x06045F27 RID: 286503 RVA: 0x012548F0 File Offset: 0x01252AF0
		public void ExitCameraMode(Action callback = null, SceneSubCamera camera = null, ELevelSequenceTransition? transitionType = null)
		{
			if (!ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Scene, (transitionType == ELevelSequenceTransition.Mask) ? 0f : ((camera != null) ? camera.FadeOut : 1f), UnrealEngine.EViewTargetBlendFunction.VTBlend_Linear, 0f, callback, this.CameraModelInstanceInternal.CameraName, null) && callback != null)
			{
				callback();
			}
		}

		// Token: 0x06045F28 RID: 286504 RVA: 0x01254950 File Offset: 0x01252B50
		public void ExitSceneSubCamera(SceneSubCamera camera, Action callback = null, ELevelSequenceTransition? transitionType = null)
		{
			this.DisplayComponent.RemoveBoundSceneCamera(camera);
			if ((camera == null || !camera.EnableInPlotMode) && ModelBase<PlotModel>.Instance.IsInHighLevelPlot())
			{
				this.ExitCameraMode(callback, camera, transitionType);
				return;
			}
			if (!this.DisplayComponent.IsIdle())
			{
				this.DisplayComponent.UpdateViewTarget(null, null);
				if (callback != null)
				{
					callback();
				}
				return;
			}
			if (this.CameraModelInstanceInternal.IsInHigherMode(ECustomCameraMode.Scene))
			{
				this.ExitCameraMode(callback, camera, transitionType);
				return;
			}
			this.DisplayComponent.UpdateViewTarget(new float?(0f), null);
			this.CameraModelInstanceInternal.FightCamera.LogicComponent.SetRotation(new FRotator(this.CameraModelInstanceInternal.FightCamera.LogicComponent.CameraRotation.Pitch, this.DisplayComponent.CineCamera.K2_GetActorRotation().Yaw, this.CameraModelInstanceInternal.FightCamera.LogicComponent.CameraRotation.Roll));
			this.ExitCameraMode(callback, camera, transitionType);
		}

		// Token: 0x06045F29 RID: 286505 RVA: 0x01254A5C File Offset: 0x01252C5C
		[NullableContext(1)]
		public void EnterSceneSubCamera(SceneSubCamera camera, [Nullable(2)] Action callback = null)
		{
			if (camera != this.DisplayComponent.CurSceneSubCamera)
			{
				return;
			}
			this.DisplayComponent.UpdateViewTarget(null, callback);
		}

		// Token: 0x06045F2A RID: 286506 RVA: 0x01254A90 File Offset: 0x01252C90
		public void EnterFixSceneSubCamera([Nullable(1)] Vector vectorLoc, [Nullable(1)] Rotator vectorRot, float fov, float fadeInTime, float fadeOutTime, ESceneSubCameraType type, Action callback = null, UnrealEngine.EViewTargetBlendFunction? blendInFunc = 0, float? blendInExp = 0f, UnrealEngine.EViewTargetBlendFunction? blendOutFunc = 0, float? blendOutExp = 0f, bool? isCameraAberrationEnable = false, CameraAberrationView cameraAberrationView = null, bool? canAcceptInput = false, SceneFixInputData fixInputData = null, [Nullable(1)] string reason = "", SceneCameraFollowConfig followConfig = null, UCurveFloat blendInCurve = null, UCurveFloat blendOutCurve = null, bool enableInPlotMode = false, bool mustCallback = false)
		{
			UnrealEngine.EViewTargetBlendFunction value = blendInFunc.GetValueOrDefault();
			if (blendInFunc == null)
			{
				value = UnrealEngine.EViewTargetBlendFunction.VTBlend_Linear;
				blendInFunc = new UnrealEngine.EViewTargetBlendFunction?(value);
			}
			float value2 = blendInExp.GetValueOrDefault();
			if (blendInExp == null)
			{
				value2 = 0f;
				blendInExp = new float?(value2);
			}
			value = blendOutFunc.GetValueOrDefault();
			if (blendOutFunc == null)
			{
				value = UnrealEngine.EViewTargetBlendFunction.VTBlend_Linear;
				blendOutFunc = new UnrealEngine.EViewTargetBlendFunction?(value);
			}
			value2 = blendOutExp.GetValueOrDefault();
			if (blendOutExp == null)
			{
				value2 = 0f;
				blendOutExp = new float?(value2);
			}
			bool value3 = isCameraAberrationEnable.GetValueOrDefault();
			if (isCameraAberrationEnable == null)
			{
				value3 = false;
				isCameraAberrationEnable = new bool?(value3);
			}
			value3 = canAcceptInput.GetValueOrDefault();
			if (canAcceptInput == null)
			{
				value3 = false;
				canAcceptInput = new bool?(value3);
			}
			if (!enableInPlotMode && ModelBase<PlotModel>.Instance.IsInHighLevelPlot())
			{
				return;
			}
			this.CameraModelInstanceInternal.FightCamera.LogicComponent.SetIsDitherEffectEnable(false);
			SceneSubCamera unBoundSceneCamera = this.DisplayComponent.GetUnBoundSceneCamera(type);
			unBoundSceneCamera.FadeIn = fadeInTime;
			unBoundSceneCamera.FadeInFunc = blendInFunc.Value;
			unBoundSceneCamera.FadeInExp = blendInExp.Value;
			unBoundSceneCamera.FadeOut = fadeOutTime;
			unBoundSceneCamera.FadeOutFunc = blendOutFunc.Value;
			unBoundSceneCamera.FadeOutExp = blendOutExp.Value;
			unBoundSceneCamera.Camera.GetCineCameraComponent().SetFieldOfView(fov);
			unBoundSceneCamera.Camera.CameraComponent.bConstrainAspectRatio = false;
			unBoundSceneCamera.IsCameraAberrationEnable = isCameraAberrationEnable.Value;
			unBoundSceneCamera.CameraAberrationView = cameraAberrationView;
			unBoundSceneCamera.FadeInCurve = blendInCurve;
			unBoundSceneCamera.FadeOutCurve = blendOutCurve;
			unBoundSceneCamera.StartRotation = vectorRot;
			unBoundSceneCamera.CanAcceptInput = canAcceptInput.Value;
			unBoundSceneCamera.EnableInPlotMode = enableInPlotMode;
			unBoundSceneCamera.FixInputData = fixInputData;
			unBoundSceneCamera.FollowConfig = followConfig;
			AActor camera = unBoundSceneCamera.Camera;
			FRotator frotator = vectorRot.ToUeRotator();
			FVectorDouble fvectorDouble = vectorLoc.ToUeVector(false);
			FVectorDouble fvectorDouble2 = new FVectorDouble(1.0, 1.0, 1.0);
			FVector fvector = fvectorDouble2;
			FTransformDouble ftransformDouble = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
			camera.D_K2_SetActorTransform(ftransformDouble, false, ref WorldGlobal.SweepHitResult, true);
			if (type == ESceneSubCameraType.Gameplay && reason != "")
			{
				if (this.GameplaySceneSubCameraList.ContainsKey(reason))
				{
					this.GameplaySceneSubCameraList[reason].Add(unBoundSceneCamera);
				}
				else
				{
					this.GameplaySceneSubCameraList[reason] = new List<SceneSubCamera>
					{
						unBoundSceneCamera
					};
				}
			}
			else
			{
				this.FixSceneSubCameraList.Add(unBoundSceneCamera);
			}
			ECustomCameraMode? cameraMode = this.CameraModelInstanceInternal.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Scene;
			if (cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null)
			{
				this.EnterSceneSubCamera(unBoundSceneCamera, callback);
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.EnableCSMStable 0", null);
			ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Scene, fadeInTime, blendInFunc.Value, blendInExp.Value, callback, mustCallback, this.CameraModelInstanceInternal.CameraName, blendInCurve);
			SceneCameraDisplayComponent displayComponent = this.DisplayComponent;
			if (displayComponent == null)
			{
				return;
			}
			displayComponent.EnableExtraCameraAction();
		}

		// Token: 0x06045F2B RID: 286507 RVA: 0x01254D6B File Offset: 0x01252F6B
		public void ExitFixSceneSubCamera(Action exitFixCameraCallback = null, bool needYaw = true)
		{
			if (this.FixSceneSubCameraList.Count == 0)
			{
				return;
			}
			this.ExitSceneSubCameraByType(ESceneSubCameraType.Fix, exitFixCameraCallback, needYaw, "");
		}

		// Token: 0x06045F2C RID: 286508 RVA: 0x01254D89 File Offset: 0x01252F89
		[NullableContext(1)]
		public void ExitGameplaySubCamera(string reason, [Nullable(2)] Action exitFixCameraCallback = null, bool needYaw = true)
		{
			if (!this.GameplaySceneSubCameraList.ContainsKey(reason))
			{
				return;
			}
			this.ExitSceneSubCameraByType(ESceneSubCameraType.Gameplay, exitFixCameraCallback, needYaw, reason);
		}

		// Token: 0x06045F2D RID: 286509 RVA: 0x01254DA4 File Offset: 0x01252FA4
		[NullableContext(1)]
		private void ExitSceneSubCameraByType(ESceneSubCameraType type, [Nullable(2)] Action exitFixCameraCallback = null, bool needYaw = true, string reason = "")
		{
			Action callback = delegate()
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.EnableCSMStable 1", null);
				Action exitFixCameraCallback2 = exitFixCameraCallback;
				if (exitFixCameraCallback2 == null)
				{
					return;
				}
				exitFixCameraCallback2();
			};
			this.CameraModelInstanceInternal.FightCamera.LogicComponent.SetIsDitherEffectEnable(true);
			SceneSubCamera sceneSubCamera = null;
			if (this.DisplayComponent.CurSceneSubCamera.Type == type && this.DisplayComponent.DefaultSceneSubCamera != this.DisplayComponent.CurSceneSubCamera)
			{
				sceneSubCamera = this.DisplayComponent.CurSceneSubCamera;
			}
			if (type != ESceneSubCameraType.Fix)
			{
				if (type == ESceneSubCameraType.Gameplay)
				{
					foreach (SceneSubCamera camera in this.GameplaySceneSubCameraList[reason])
					{
						this.DisplayComponent.RemoveBoundSceneCamera(camera);
					}
					this.GameplaySceneSubCameraList.Remove(reason);
					if (this.GameplaySceneSubCameraList.Count > 0)
					{
						return;
					}
				}
			}
			else
			{
				while (this.FixSceneSubCameraList.Count > 0)
				{
					SceneSubCamera camera2 = this.FixSceneSubCameraList[this.FixSceneSubCameraList.Count - 1];
					this.FixSceneSubCameraList.RemoveAt(this.FixSceneSubCameraList.Count - 1);
					this.DisplayComponent.RemoveBoundSceneCamera(camera2);
				}
			}
			if (!this.DisplayComponent.IsIdle())
			{
				this.DisplayComponent.UpdateViewTarget(null, null);
				return;
			}
			if (this.CameraModelInstanceInternal.IsInHigherMode(ECustomCameraMode.Scene))
			{
				this.ExitCameraMode(callback, null, null);
				return;
			}
			if (sceneSubCamera != null)
			{
				this.DisplayComponent.DefaultSceneSubCamera.CopyData(sceneSubCamera);
				this.DisplayComponent.UpdateViewTarget(new float?(0f), null);
			}
			if (needYaw)
			{
				this.CameraModelInstanceInternal.FightCamera.LogicComponent.SetRotation(new FRotator(this.CameraModelInstanceInternal.FightCamera.LogicComponent.CameraRotation.Pitch, this.DisplayComponent.CineCamera.K2_GetActorRotation().Yaw, this.CameraModelInstanceInternal.FightCamera.LogicComponent.CameraRotation.Roll));
			}
			ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Scene, this.DisplayComponent.DefaultSceneSubCamera.FadeOut, this.DisplayComponent.DefaultSceneSubCamera.FadeOutFunc, this.DisplayComponent.DefaultSceneSubCamera.FadeOutExp, callback, this.CameraModelInstanceInternal.CameraName, this.DisplayComponent.DefaultSceneSubCamera.FadeOutCurve);
		}

		// Token: 0x06045F2E RID: 286510 RVA: 0x01255014 File Offset: 0x01253214
		public bool IsCameraAberrationEnable()
		{
			return this.DisplayComponent.CurSceneSubCamera.IsCameraAberrationEnable;
		}

		// Token: 0x06045F2F RID: 286511 RVA: 0x01255026 File Offset: 0x01253226
		public void EnableOrthographicToPerspectiveView(Action callback = null)
		{
			this.DisplayComponent.EnableOrthographicToPerspectiveView(callback);
		}

		// Token: 0x06045F30 RID: 286512 RVA: 0x01255034 File Offset: 0x01253234
		public bool IsDefaultSubCameraValid()
		{
			SceneCameraDisplayComponent displayComponent = this.DisplayComponent;
			if (displayComponent == null)
			{
				return false;
			}
			SceneSubCamera defaultSceneSubCamera = displayComponent.DefaultSceneSubCamera;
			bool? flag;
			if (defaultSceneSubCamera == null)
			{
				flag = null;
			}
			else
			{
				BP_CineCamera_C camera = defaultSceneSubCamera.Camera;
				flag = ((camera != null) ? new bool?(camera.IsValid()) : null);
			}
			bool? flag2 = flag;
			return flag2.GetValueOrDefault();
		}

		// Token: 0x06045F31 RID: 286513 RVA: 0x01255088 File Offset: 0x01253288
		public void SetCameraFov(float fov, float minFov, float maxFov)
		{
			if (this.DisplayComponent.CurSceneSubCamera != null)
			{
				float fieldOfView = Math.Max(minFov, Math.Min(maxFov, fov));
				this.DisplayComponent.CurSceneSubCamera.Camera.GetCineCameraComponent().SetFieldOfView(fieldOfView);
			}
		}

		// Token: 0x06045F32 RID: 286514 RVA: 0x012550CB File Offset: 0x012532CB
		[NullableContext(1)]
		public void SetCameraLookAtPosition(Vector targetPosition, float duration = 1f)
		{
			this.SceneCameraInputComponent.SetLookAtTarget(targetPosition, duration * 1000f);
		}

		// Token: 0x06045F33 RID: 286515 RVA: 0x012550E0 File Offset: 0x012532E0
		protected override bool OnClear()
		{
			this.CameraModelInstanceInternal = null;
			return true;
		}

		// Token: 0x06045F34 RID: 286516 RVA: 0x012550EC File Offset: 0x012532EC
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneCameraPlayerComponent sceneCameraPlayerComponent = (SceneCameraPlayerComponent)componentTemplate;
			if (base.CanResetComponentProperty("CameraModelInstanceInternal"))
			{
				if (sceneCameraPlayerComponent.CameraModelInstanceInternal == null)
				{
					this.CameraModelInstanceInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CameraModelInstance>(this.CameraModelInstanceInternal), "CameraModelInstanceInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DisplayComponent"))
			{
				if (sceneCameraPlayerComponent.DisplayComponent == null)
				{
					this.DisplayComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneCameraDisplayComponent>(this.DisplayComponent), "DisplayComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SceneCameraInputComponent"))
			{
				if (sceneCameraPlayerComponent.SceneCameraInputComponent == null)
				{
					this.SceneCameraInputComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneCameraInputComponent>(this.SceneCameraInputComponent), "SceneCameraInputComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FixSceneSubCameraList"))
			{
				if (sceneCameraPlayerComponent.FixSceneSubCameraList == null)
				{
					this.FixSceneSubCameraList = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<SceneSubCamera>>(this.FixSceneSubCameraList), "FixSceneSubCameraList"))
				{
					return false;
				}
			}
			return !base.CanResetComponentProperty("GameplaySceneSubCameraList") || sceneCameraPlayerComponent.GameplaySceneSubCameraList == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, List<SceneSubCamera>>>(this.GameplaySceneSubCameraList), "GameplaySceneSubCameraList");
		}

		// Token: 0x040272F8 RID: 160504
		private CameraModelInstance CameraModelInstanceInternal;

		// Token: 0x040272F9 RID: 160505
		private SceneCameraDisplayComponent DisplayComponent;

		// Token: 0x040272FA RID: 160506
		private SceneCameraInputComponent SceneCameraInputComponent;

		// Token: 0x040272FB RID: 160507
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<SceneSubCamera> FixSceneSubCameraList;

		// Token: 0x040272FC RID: 160508
		[Nullable(1)]
		private readonly Dictionary<string, List<SceneSubCamera>> GameplaySceneSubCameraList = new Dictionary<string, List<SceneSubCamera>>();
	}
}
