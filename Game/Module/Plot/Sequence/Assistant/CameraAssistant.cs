using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.GamePlay.StreamingSource;
using AkiClient.Game.Aki.Sequence.Seq_BP.SeqStreamingSource;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.MovieMode;
using CSharpScript.Game.Module.Plot.Flow;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence.Assistant
{
	// Token: 0x020053A1 RID: 21409
	[NullableContext(2)]
	[Nullable(0)]
	public class CameraAssistant : SeqBaseAssistant
	{
		// Token: 0x06036985 RID: 223621 RVA: 0x00DCFFB8 File Offset: 0x00DCE1B8
		public override void PreAllPlay(Action<bool> callback = null)
		{
			bool? isViewTargetControl = this.Model.IsViewTargetControl;
			bool flag = false;
			if (isViewTargetControl.GetValueOrDefault() == flag & isViewTargetControl != null)
			{
				return;
			}
			float 相机过渡时间 = this.Model.SequenceData.相机过渡时间;
			BP_CineCamera_C cineCamera = ModelBase<CameraModel>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera;
			UCineCameraComponent cineCameraComponent = cineCamera.GetCineCameraComponent();
			if (相机过渡时间 > 0f)
			{
				if (this.Model.SequenceData.约束宽高比)
				{
					if (!cineCameraComponent.bConstrainAspectRatio)
					{
						int num = 0;
						int num2 = 0;
						Global.CharacterController.GetViewportSize(ref num, ref num2);
						float num3 = (float)num / (float)num2;
						cineCameraComponent.bConstrainAspectRatio = true;
						cineCameraComponent.Filmback.SensorWidth = cineCameraComponent.Filmback.SensorHeight * num3;
					}
				}
				else if (cineCameraComponent.bConstrainAspectRatio)
				{
					ControllerBase<PlotController>.Instance.ManualAdaptAspectRatio((float)((int)(相机过渡时间 * 1000f)));
				}
			}
			float cameraBlendInTime = this.Model.SequenceData.CameraBlendInTime;
			SequenceCameraPlayerComponent component = ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.GetComponent<SequenceCameraPlayerComponent>();
			if (component != null && component.GetIsInCinematic() && component != null && component.GetIfNeedWaitInPlot())
			{
				component.StopSequence();
			}
			bool flag2 = true;
			int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.FlowAdaptation, true, true);
			int num4 = 0;
			bool flag3 = currentValue.GetValueOrDefault() > num4 & currentValue != null;
			if (flag2 && cameraBlendInTime > 0f && flag3)
			{
				this.Model.EnablingUiBlend = true;
				cineCameraComponent.bConstrainAspectRatio = false;
				EnterMovieModeParams param = new EnterMovieModeParams
				{
					BlendTime = cameraBlendInTime
				};
				ControllerBase<MovieModeController>.Instance.EnterMovieMode(param, delegate(bool success)
				{
					if (!success)
					{
						Singleton<Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.HYF, "进入UI黑边失败", default(ReadOnlySpan<ValueTuple<string, object>>));
						this.Model.EnablingUiBlend = false;
					}
				});
			}
			ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Sequence, cameraBlendInTime, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, false, "MainCamera", null);
			this.ControllingView = true;
			if (this.Model.SequenceData.IsEnableDynamicStreamingSource)
			{
				this.DynamicStreamingSourceProxy = Singleton<ActorSystem>.Instance.Spawn<BP_KuroStreamingSourceProxy_Seq_C>(BP_KuroStreamingSourceProxy_Seq_C.StaticClass(), new FTransformDouble(), null);
				ControllerBase<GameModeController>.Instance.SwitchStreamingSource(this.DynamicStreamingSourceProxy, false, false, new EMovementLockMode?(EMovementLockMode.StreamingSource)).Forget();
			}
			if (!ModelBase<PlotModel>.Instance.PlotConfig.IsPreStreaming)
			{
				return;
			}
			if (this.PreLoadActor == null)
			{
				this.PreLoadActor = Singleton<ActorSystem>.Instance.Spawn<BP_StreamingSourceActor_C>(BP_StreamingSourceActor_C.StaticClass(), new FTransformDouble(), null);
			}
			if (this.CameraLoadActor == null)
			{
				this.CameraLoadActor = Singleton<ActorSystem>.Instance.Spawn<BP_StreamingSourceActor_C>(BP_StreamingSourceActor_C.StaticClass(), new FTransformDouble(), null);
				cineCamera = ModelBase<CameraModel>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera;
				this.CameraLoadActor.K2_AttachToActor(cineCamera, null, EAttachmentRule.SnapToTarget, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false, true);
			}
		}

		// Token: 0x06036986 RID: 223622 RVA: 0x00DD0250 File Offset: 0x00DCE450
		public override void PreEachPlay()
		{
			bool? isViewTargetControl = this.Model.IsViewTargetControl;
			bool flag = false;
			if (isViewTargetControl.GetValueOrDefault() == flag & isViewTargetControl != null)
			{
				return;
			}
			TArray<AActor> tarray = new TArray<AActor>();
			BP_CineCamera_C cineCamera = ModelBase<CameraModel>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera;
			if (this.Model.SequenceData.相机过渡时间 <= 0f || this.Model.SubSeqIndex != 0)
			{
				cineCamera.ResetSeqCineCamSetting();
			}
			tarray.Add(cineCamera);
			this.Model.CurLevelSeqActor.SetBindingByTag(SequenceDefine.CAMERA_TAG, tarray, false, true);
			FTransformDouble ftransformDouble = ModelBase<CameraModel>.Instance.MainModel.CameraTransform.Value;
			if (this.Model.SequenceData.混入到相机首帧 && this.Model.SubSeqIndex == 0)
			{
				Transform transform = Transform.Create();
				FTransform ftransform = transform.ToUeTransformOld();
				ULevelSequence sequence = this.Model.CurLevelSeqActor.GetSequence();
				if (!UKuroSequenceRuntimeFunctionLibrary.GetFrameTransformByTag(sequence, SequenceDefine.CAMERA_TAG, UKuroSequenceRuntimeFunctionLibrary.GetPlaybackStart(sequence), ref ftransform))
				{
					Singleton<Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.HYF, "未能获取到Sequence起始帧的相机Transform，无法启用起始帧过渡", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				else
				{
					transform.FromUeTransform(ftransform);
					ftransformDouble = transform.ToUeTransform();
					if (this.Model.RelativeTransform != null)
					{
						Transform transform2 = Transform.Create();
						transform.ComposeTransforms(this.Model.RelativeTransform, transform2);
						ftransformDouble = transform2.ToUeTransform();
					}
				}
			}
			ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera.D_K2_SetActorTransform(ftransformDouble, false, null, true);
			BP_KuroStreamingSourceProxy_Seq_C dynamicStreamingSourceProxy = this.DynamicStreamingSourceProxy;
			if (dynamicStreamingSourceProxy == null || !dynamicStreamingSourceProxy.IsValid())
			{
				return;
			}
			TArray<AActor> tarray2 = new TArray<AActor>();
			tarray2.Add(this.DynamicStreamingSourceProxy);
			this.Model.CurLevelSeqActor.SetBindingByTag(SequenceDefine.SeqStreamingSourceProxy_TAG, tarray2, false, true);
		}

		// Token: 0x06036987 RID: 223623 RVA: 0x00DD0427 File Offset: 0x00DCE627
		public override void EachStop()
		{
		}

		// Token: 0x06036988 RID: 223624 RVA: 0x00DD042C File Offset: 0x00DCE62C
		public override void AllStop(Action<bool> callback = null)
		{
			bool? isViewTargetControl = this.Model.IsViewTargetControl;
			bool flag = false;
			if (isViewTargetControl.GetValueOrDefault() == flag & isViewTargetControl != null)
			{
				return;
			}
			if (this.Model.IsSeamless && ControllerBase<FlowController>.Instance.CollectSeamlessFinalize(ESeamlessFinalizeFlag.ExitMovieMode))
			{
				return;
			}
			if (this.Model.Config.KeepCamera.GetValueOrDefault())
			{
				this.ControllingView = false;
				if (this.Model.EnablingUiBlend)
				{
					ExitMovieModeParams param = new ExitMovieModeParams
					{
						BlendTime = 0f
					};
					ControllerBase<MovieModeController>.Instance.ExitMovieMode(param, null);
					this.Model.EnablingUiBlend = false;
				}
				CameraModelInstance mainModel = ModelBase<CameraModel>.Instance.MainModel;
				mainModel.SaveSeqCamera();
				SeqCameraThings savedSeqCameraThings = mainModel.GetSavedSeqCameraThings();
				if (savedSeqCameraThings == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.BB, "读取Sequence相机信息时，信息不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				UiCamera uiCamera = UiCameraManager.Get();
				uiCamera.SetWorldLocation(savedSeqCameraThings.CameraLocation);
				uiCamera.SetWorldRotation(savedSeqCameraThings.CameraRotation);
				UiCameraPostEffectComponent uiCameraComponent = uiCamera.GetUiCameraComponent<UiCameraPostEffectComponent>();
				uiCameraComponent.SetCameraAperture(savedSeqCameraThings.CurrentAperture);
				uiCameraComponent.SetCameraFocalDistance(savedSeqCameraThings.FocusSettings.ManualFocusDistance);
				uiCameraComponent.SetCameraFieldOfView(savedSeqCameraThings.FieldOfView);
				ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Sequence, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
				uiCamera.Enter(0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null);
				return;
			}
			ModelBase<CameraModel>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera.LookatTrackingSettings.bEnableLookAtTracking = false;
			if (this.Model.Config.ResetCamera.GetValueOrDefault())
			{
				CameraBlueprintFunctionLibrary.ResetFightCameraPitchAndArmLength();
			}
			else
			{
				FRotator rotation = ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera.K2_GetActorRotation();
				rotation.Roll = 0f;
				ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.SetRotation(rotation);
			}
			float cameraBlendOutTime = this.Model.SequenceData.CameraBlendOutTime;
			this.ControllingView = false;
			if (cameraBlendOutTime == 0f)
			{
				ControllerBase<SequenceController>.Instance.DisableMotionBlurAwhile();
			}
			if (this.Model.EnablingUiBlend)
			{
				ExitMovieModeParams param2 = new ExitMovieModeParams
				{
					BlendTime = cameraBlendOutTime
				};
				ControllerBase<MovieModeController>.Instance.ExitMovieMode(param2, null);
				this.Model.EnablingUiBlend = false;
			}
			ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Sequence, cameraBlendOutTime, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
		}

		// Token: 0x06036989 RID: 223625 RVA: 0x00DD068C File Offset: 0x00DCE88C
		[NullableContext(0)]
		public override UniTask<bool> AllStopPromise()
		{
			CameraAssistant.<AllStopPromise>d__9 <AllStopPromise>d__;
			<AllStopPromise>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<AllStopPromise>d__.<>4__this = this;
			<AllStopPromise>d__.<>1__state = -1;
			<AllStopPromise>d__.<>t__builder.Start<CameraAssistant.<AllStopPromise>d__9>(ref <AllStopPromise>d__);
			return <AllStopPromise>d__.<>t__builder.Task;
		}

		// Token: 0x0603698A RID: 223626 RVA: 0x00DD06D0 File Offset: 0x00DCE8D0
		public override void End()
		{
			bool? isViewTargetControl = this.Model.IsViewTargetControl;
			bool flag = false;
			if (isViewTargetControl.GetValueOrDefault() == flag & isViewTargetControl != null)
			{
				return;
			}
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ExitCameraGuideAtOnce();
			if (this.PreLoadActor != null)
			{
				UWorldPartitionStreamingSourceComponent worldPartitionStreamingSource = this.PreLoadActor.WorldPartitionStreamingSource;
				if (worldPartitionStreamingSource != null)
				{
					worldPartitionStreamingSource.DisableStreamingSource();
				}
			}
			if (this.CameraLoadActor != null)
			{
				UWorldPartitionStreamingSourceComponent worldPartitionStreamingSource2 = this.CameraLoadActor.WorldPartitionStreamingSource;
				if (worldPartitionStreamingSource2 != null)
				{
					worldPartitionStreamingSource2.DisableStreamingSource();
				}
			}
			if (this.DynamicStreamingSourceProxy != null)
			{
				GameModeModel instance = ModelBase<GameModeModel>.Instance;
				if (instance != null)
				{
					instance.DetachStreamingSourceFromActor();
				}
				Singleton<ActorSystem>.Instance.Put("CameraAssistant.DestroySeqDynamicStreamingSourceProxy", this.DynamicStreamingSourceProxy, null);
				ModelBase<GameModeModel>.Instance.AttachStreamingSourcesToActor(ControllerBase<RoleTriggerController>.Instance.GetMyRoleTriggerOrUndefined());
				ControllerBase<MovementLockController>.Instance.Unlock();
			}
			ModelBase<CameraModel>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera.LookatTrackingSettings.bEnableLookAtTracking = false;
			foreach (KeyValuePair<string, UMatineeCameraShake> keyValuePair in this.CameraShake)
			{
				string key = keyValuePair.Key;
				UMatineeCameraShake value = keyValuePair.Value;
				Global.CharacterCameraManager.StopCameraShake(value, true);
			}
			this.CameraShake.Clear();
			if (this.ControllingView && !ControllerBase<FlowController>.Instance.CollectSeamlessFinalize(ESeamlessFinalizeFlag.ExitSequenceCamera))
			{
				ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Sequence, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
			}
			if (this.Model.EnablingUiBlend && !ControllerBase<FlowController>.Instance.CollectSeamlessFinalize(ESeamlessFinalizeFlag.ExitMovieMode))
			{
				ExitMovieModeParams param = new ExitMovieModeParams
				{
					BlendTime = 0f
				};
				ControllerBase<MovieModeController>.Instance.ExitMovieMode(param, null);
				this.Model.EnablingUiBlend = false;
			}
		}

		// Token: 0x0603698B RID: 223627 RVA: 0x00DD08A8 File Offset: 0x00DCEAA8
		public void CalcPreloadLocation()
		{
		}

		// Token: 0x0603698C RID: 223628 RVA: 0x00DD08AC File Offset: 0x00DCEAAC
		[NullableContext(1)]
		public void StartCameraShake(TSoftClassPtr<UMatineeCameraShake> cameraShakePtr)
		{
			TSoftClassPtr<UObject> tsoftClassPtr = cameraShakePtr.As<UObject>();
			if (!UKismetSystemLibrary.IsValidSoftClassReference(tsoftClassPtr))
			{
				return;
			}
			string path = cameraShakePtr.ToAssetPathName();
			if (this.CameraShake.ContainsKey(path))
			{
				return;
			}
			Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(path, delegate([Nullable(2)] UClass shakeClass, string _)
			{
				SequenceModel model = this.Model;
				if (model != null && model.IsPlaying && shakeClass != null)
				{
					UMatineeCameraShake umatineeCameraShake = Global.CharacterCameraManager.StartMatineeCameraShake(shakeClass, 1f, ECameraShakePlaySpace.CameraLocal, default(FRotator), 1f);
					if (umatineeCameraShake != null)
					{
						this.CameraShake[path] = umatineeCameraShake;
					}
				}
			}, 100, "js_undefined");
		}

		// Token: 0x0603698D RID: 223629 RVA: 0x00DD091C File Offset: 0x00DCEB1C
		[NullableContext(1)]
		public void StopCameraShake(TSoftClassPtr<UMatineeCameraShake> cameraShakePtr)
		{
			TSoftClassPtr<UObject> tsoftClassPtr = cameraShakePtr.As<UObject>();
			if (!UKismetSystemLibrary.IsValidSoftClassReference(tsoftClassPtr))
			{
				foreach (KeyValuePair<string, UMatineeCameraShake> keyValuePair in this.CameraShake)
				{
					UMatineeCameraShake value = keyValuePair.Value;
					Global.CharacterCameraManager.StopCameraShake(value, true);
				}
				this.CameraShake.Clear();
				return;
			}
			string key = cameraShakePtr.ToAssetPathName();
			UMatineeCameraShake shakeInstance;
			if (!this.CameraShake.TryGetValue(key, out shakeInstance))
			{
				return;
			}
			Global.CharacterCameraManager.StopCameraShake(shakeInstance, true);
			this.CameraShake.Remove(key);
		}

		// Token: 0x0401F72E RID: 128814
		private bool ControllingView;

		// Token: 0x0401F72F RID: 128815
		private BP_StreamingSourceActor_C PreLoadActor;

		// Token: 0x0401F730 RID: 128816
		private BP_StreamingSourceActor_C CameraLoadActor;

		// Token: 0x0401F731 RID: 128817
		[Nullable(1)]
		private readonly Dictionary<string, UMatineeCameraShake> CameraShake = new Dictionary<string, UMatineeCameraShake>();

		// Token: 0x0401F732 RID: 128818
		private BP_KuroStreamingSourceProxy_Seq_C DynamicStreamingSourceProxy;
	}
}
