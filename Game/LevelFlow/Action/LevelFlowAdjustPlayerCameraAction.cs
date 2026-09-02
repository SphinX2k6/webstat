using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Render;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F88 RID: 28552
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowAdjustPlayerCameraAction : LevelFlowActionBase
	{
		// Token: 0x06045177 RID: 282999 RVA: 0x012044EF File Offset: 0x012026EF
		public LevelFlowAdjustPlayerCameraAction Init(AdjustPlayerCamera param)
		{
			this.Param = param;
			return this;
		}

		// Token: 0x06045178 RID: 283000 RVA: 0x012044FC File Offset: 0x012026FC
		protected override void OnExecute()
		{
			if (this.Param == null)
			{
				base.FinishExecute(false);
				return;
			}
			AdjustPlayerCamera params_ = this.Param;
			if (!this.UpdateCameraHookConfig(params_))
			{
				base.FinishExecute(false);
				return;
			}
			bool flag = false;
			switch (params_.Option.Type)
			{
			case EAdjustPlayerCamera.Basic:
			{
				IAdjustBasicCamera adjustBasicCamera = params_.Option as IAdjustBasicCamera;
				if (adjustBasicCamera != null && adjustBasicCamera.IsSynchronous.GetValueOrDefault())
				{
					flag = true;
					Singleton<EventSystem>.Instance.Add(EEventName.AdjustCameraSync, new Action<string>(this.CameraMoveFinished));
				}
				this.EnableHookConfig(params_, null);
				if (!string.IsNullOrEmpty((adjustBasicCamera != null) ? adjustBasicCamera.SightUi : null))
				{
					Singleton<EventSystem>.Instance.Emit<bool, ECameraAimVisibleReason, string, string>(EEventName.SetCameraAimVisible, true, ECameraAimVisibleReason.Default, adjustBasicCamera.SightUi, null);
				}
				break;
			}
			case EAdjustPlayerCamera.Horizontal:
			{
				this.EnableHookConfig(params_, new int?(LevelFlowAdjustPlayerCameraAction.noAimGameplayTag));
				IAdjustHorizontalCamera adjustHorizontalCamera = params_.Option as IAdjustHorizontalCamera;
				ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ApplyCameraSpline((adjustHorizontalCamera != null) ? adjustHorizontalCamera.SplineEntityId : 0, (adjustHorizontalCamera != null) ? adjustHorizontalCamera.YawAngle : 0f, (adjustHorizontalCamera != null) ? adjustHorizontalCamera.PitchAngle : 0f, params_.Option.FadeInTime, new bool?(false), new float?(0f));
				if (((adjustHorizontalCamera != null) ? adjustHorizontalCamera.DepthOfField : null) != null)
				{
					ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ApplyDepthOfField(adjustHorizontalCamera.DepthOfField.Fstop, adjustHorizontalCamera.DepthOfField.Distance, adjustHorizontalCamera.DepthOfField.BlurAmount, adjustHorizontalCamera.DepthOfField.BlurRadius);
				}
				else
				{
					ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ExitDepthOfField();
				}
				ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.PlayerComponent.SetPlayCameraSequenceEnabled(false);
				RenderUtil.CloseVelocityScreenSizeCull();
				break;
			}
			case EAdjustPlayerCamera.Dialog:
			{
				this.EnableHookConfig(params_, new int?(LevelFlowAdjustPlayerCameraAction.noAimGameplayTag));
				IAdjustDialogCamera adjustDialogCamera = params_.Option as IAdjustDialogCamera;
				float? num = (adjustDialogCamera != null) ? new float?(adjustDialogCamera.PitchAngle) : null;
				if (num != null)
				{
					num = -num;
				}
				float? num2 = (adjustDialogCamera != null) ? new float?(adjustDialogCamera.YawAngle) : null;
				if (num2 != null)
				{
					num2 += (float)180;
				}
				float value = this.HookConfig.DefaultConfig[EFightCameraDefault.基础臂长];
				ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.AdjustDialogueCamera((adjustDialogCamera != null) ? adjustDialogCamera.CenterPos : null, num.GetValueOrDefault(), num2.GetValueOrDefault(), new float?(value));
				break;
			}
			case EAdjustPlayerCamera.Fixed:
			{
				this.EnableHookConfig(params_, new int?(LevelFlowAdjustPlayerCameraAction.noAimGameplayTag));
				IAdjustFixedCamera adjustFixedCamera = params_.Option as IAdjustFixedCamera;
				Vector vector = Vector.Create();
				Rotator rotator = Rotator.Create();
				vector.Set((double)((adjustFixedCamera != null) ? adjustFixedCamera.CenterPos.X : null).GetValueOrDefault(), (double)((adjustFixedCamera != null) ? adjustFixedCamera.CenterPos.Y : null).GetValueOrDefault(), (double)((adjustFixedCamera != null) ? adjustFixedCamera.CenterPos.Z : null).GetValueOrDefault());
				rotator.Set(((adjustFixedCamera != null) ? adjustFixedCamera.CenterRot.Y : null).GetValueOrDefault(), ((adjustFixedCamera != null) ? adjustFixedCamera.CenterRot.Z : null).GetValueOrDefault(), ((adjustFixedCamera != null) ? adjustFixedCamera.CenterRot.X : null).GetValueOrDefault());
				SceneCameraPlayerComponent playerComponent = ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent;
				Vector vectorLoc = vector;
				Rotator vectorRot = rotator;
				float fov = params_.Option.Fov;
				float fadeInTime = params_.Option.FadeInTime;
				float fadeOutTime2 = params_.Option.FadeOutTime;
				ESceneSubCameraType type = ESceneSubCameraType.Fix;
				Action callback = null;
				Aki.TDConfigMgr.Action.EViewTargetBlendFunction? eviewTargetBlendFunction;
				if (adjustFixedCamera == null)
				{
					eviewTargetBlendFunction = null;
				}
				else
				{
					IBlendFunction blendIn = adjustFixedCamera.BlendIn;
					eviewTargetBlendFunction = ((blendIn != null) ? new Aki.TDConfigMgr.Action.EViewTargetBlendFunction?(blendIn.Type) : null);
				}
				Aki.TDConfigMgr.Action.EViewTargetBlendFunction? eviewTargetBlendFunction2 = eviewTargetBlendFunction;
				UnrealEngine.EViewTargetBlendFunction? blendInFunc = new UnrealEngine.EViewTargetBlendFunction?((UnrealEngine.EViewTargetBlendFunction)eviewTargetBlendFunction2.Value);
				IBlendFunction blendIn2 = adjustFixedCamera.BlendIn;
				float? blendInExp = new float?(((blendIn2 != null) ? new float?(blendIn2.BlendExp) : null).GetValueOrDefault());
				IBlendFunction blendOut = adjustFixedCamera.BlendOut;
				UnrealEngine.EViewTargetBlendFunction? blendOutFunc = new UnrealEngine.EViewTargetBlendFunction?((UnrealEngine.EViewTargetBlendFunction)((blendOut != null) ? new Aki.TDConfigMgr.Action.EViewTargetBlendFunction?(blendOut.Type) : null).Value);
				IBlendFunction blendOut2 = adjustFixedCamera.BlendOut;
				playerComponent.EnterFixSceneSubCamera(vectorLoc, vectorRot, fov, fadeInTime, fadeOutTime2, type, callback, blendInFunc, blendInExp, blendOutFunc, new float?(((blendOut2 != null) ? new float?(blendOut2.BlendExp) : null).GetValueOrDefault()), new bool?(false), null, new bool?(false), null, "", null, null, null, false, false);
				if (adjustFixedCamera != null && adjustFixedCamera.HidePlayer.GetValueOrDefault())
				{
					ControllerBase<CameraController>.Instance.MainModel.SetHidePlayer(true, true);
				}
				break;
			}
			case EAdjustPlayerCamera.AxisLock:
			{
				IAdjustAxisLockCamera adjustAxisLockCamera = params_.Option as IAdjustAxisLockCamera;
				float valueOrDefault = ((adjustAxisLockCamera != null) ? adjustAxisLockCamera.AxisRotate.Y : null).GetValueOrDefault();
				float valueOrDefault2 = ((adjustAxisLockCamera != null) ? adjustAxisLockCamera.AxisRotate.Z : null).GetValueOrDefault();
				this.HookConfig.DefaultConfig[EFightCameraDefault.Pitch限制Min] = valueOrDefault;
				this.HookConfig.DefaultConfig[EFightCameraDefault.Pitch限制Max] = valueOrDefault;
				this.HookConfig.DefaultConfig[EFightCameraDefault.WorldYaw限制Min] = valueOrDefault2;
				this.HookConfig.DefaultConfig[EFightCameraDefault.WorldYaw限制Max] = valueOrDefault2;
				if (((adjustAxisLockCamera != null) ? adjustAxisLockCamera.ScreenConfig : null) == null)
				{
					this.EnableHookConfig(params_, new int?(LevelFlowAdjustPlayerCameraAction.noAimGameplayTag));
					if (adjustAxisLockCamera != null && adjustAxisLockCamera.HidePlayer.GetValueOrDefault())
					{
						ControllerBase<CameraController>.Instance.MainModel.SetHidePlayer(true, true);
					}
				}
				else if (Math.Abs(ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Pitch - valueOrDefault) <= adjustAxisLockCamera.ScreenConfig.TriggerAngle && Math.Abs(ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Yaw - valueOrDefault2) <= adjustAxisLockCamera.ScreenConfig.TriggerAngle)
				{
					this.EnableHookConfig(params_, new int?(LevelFlowAdjustPlayerCameraAction.noAimGameplayTag));
					if (adjustAxisLockCamera != null && adjustAxisLockCamera.HidePlayer.GetValueOrDefault())
					{
						ControllerBase<CameraController>.Instance.MainModel.SetHidePlayer(true, true);
					}
				}
				else
				{
					float fadeInTime2 = adjustAxisLockCamera.ScreenConfig.FadeInTime;
					float fadeOutTime = adjustAxisLockCamera.ScreenConfig.FadeOutTime;
					bool hidePlayer = adjustAxisLockCamera.HidePlayer.GetValueOrDefault();
					ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.Common, ELoadingPerform.CameraFade, "LevelFlowAdjustPlayerCameraAction_AxisLock", delegate
					{
						this.HookConfig.FadeInTime = 0.1f;
						this.EnableHookConfig(params_, new int?(LevelFlowAdjustPlayerCameraAction.noAimGameplayTag));
						if (hidePlayer)
						{
							ControllerBase<CameraController>.Instance.MainModel.SetHidePlayer(true, true);
						}
						ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Common, "LevelFlowAdjustPlayerCameraAction_AxisLock", null, new float?(fadeOutTime));
					}, new object[]
					{
						fadeInTime2
					});
				}
				break;
			}
			case EAdjustPlayerCamera.FirstPerson:
			{
				IAdjustFirstPersonCamera adjustFirstPersonCamera = params_.Option as IAdjustFirstPersonCamera;
				this.EnableHookConfig(params_, new int?(LevelFlowAdjustPlayerCameraAction.noAimGameplayTag));
				ControllerBase<CameraController>.Instance.SetHideHeadEnable(true, EHideHeadEnum.LevelEvent, "MainCamera");
				if (adjustFirstPersonCamera != null && adjustFirstPersonCamera.HidePlayer.GetValueOrDefault())
				{
					ControllerBase<CameraController>.Instance.MainModel.SetHidePlayer(true, false);
				}
				break;
			}
			}
			if (!flag)
			{
				this.CameraMoveFinished("MainCamera");
			}
		}

		// Token: 0x06045179 RID: 283001 RVA: 0x01204D50 File Offset: 0x01202F50
		private bool UpdateCameraHookConfig(AdjustPlayerCamera @params)
		{
			CameraConfigController cameraConfigController = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraConfigController;
			if (cameraConfigController == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.ZWY, "CameraConfigController不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			EAdjustPlayerCamera type = @params.Option.Type;
			CameraConfig cameraConfigByTag = cameraConfigController.GetCameraConfigByTag(GameplayTagUtils.GetTagIdByName(type.ToEnumString()));
			if (cameraConfigByTag == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.ZWY;
				string message = "没有找到对应Tag的镜头配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tag", type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.HookConfig = cameraConfigByTag;
			cameraConfigByTag.Priority = @params.Option.Priority;
			cameraConfigByTag.FadeInTime = @params.Option.FadeInTime;
			cameraConfigByTag.FadeOutTime = @params.Option.FadeOutTime;
			if (@params.Option.FadeInCurve != null)
			{
				cameraConfigByTag.FadeInCurve = ConfigCurveUtils.CreateCurveByBaseCurve(@params.Option.FadeInCurve, null);
			}
			else
			{
				cameraConfigByTag.FadeInCurve = CurveUtils.CreateCurve(ECurveType.Linear, Array.Empty<float>());
			}
			if (@params.Option.FadeOutCurve != null)
			{
				cameraConfigByTag.FadeOutCurve = ConfigCurveUtils.CreateCurveByBaseCurve(@params.Option.FadeOutCurve, null);
			}
			else
			{
				cameraConfigByTag.FadeOutCurve = CurveUtils.CreateCurve(ECurveType.Linear, Array.Empty<float>());
			}
			IAdjustPlayerCameraType option = @params.Option;
			bool flag;
			if (option == null)
			{
				flag = false;
			}
			else
			{
				float armLength = option.ArmLength;
				flag = true;
			}
			if (flag && @params.Option.ArmLength != 0f)
			{
				cameraConfigByTag.DefaultConfig[EFightCameraDefault.基础臂长] = @params.Option.ArmLength;
			}
			else
			{
				cameraConfigByTag.DefaultConfig.Remove(EFightCameraDefault.基础臂长);
			}
			IAdjustPlayerCameraType option2 = @params.Option;
			bool flag2;
			if (option2 == null)
			{
				flag2 = false;
			}
			else
			{
				float minumArmLength = option2.MinumArmLength;
				flag2 = true;
			}
			if (flag2 && @params.Option.MinumArmLength != 0f)
			{
				cameraConfigByTag.DefaultConfig[EFightCameraDefault.最小臂长] = @params.Option.MinumArmLength;
			}
			else
			{
				cameraConfigByTag.DefaultConfig.Remove(EFightCameraDefault.最小臂长);
			}
			IAdjustPlayerCameraType option3 = @params.Option;
			bool flag3;
			if (option3 == null)
			{
				flag3 = false;
			}
			else
			{
				float maxiumArmLength = option3.MaxiumArmLength;
				flag3 = true;
			}
			if (flag3 && @params.Option.MaxiumArmLength != 0f)
			{
				cameraConfigByTag.DefaultConfig[EFightCameraDefault.最大臂长] = @params.Option.MaxiumArmLength;
			}
			else
			{
				cameraConfigByTag.DefaultConfig.Remove(EFightCameraDefault.最大臂长);
			}
			IAdjustPlayerCameraType option4 = @params.Option;
			if (option4 != null && option4.Offset.X != null)
			{
				float? num = @params.Option.Offset.X;
				float num2 = 0f;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					cameraConfigByTag.DefaultConfig[EFightCameraDefault.相机臂偏移X] = @params.Option.Offset.X.Value;
					goto IL_2A1;
				}
			}
			cameraConfigByTag.DefaultConfig.Remove(EFightCameraDefault.相机臂偏移X);
			IL_2A1:
			IAdjustPlayerCameraType option5 = @params.Option;
			if (option5 != null && option5.Offset.Y != null)
			{
				float? num = @params.Option.Offset.Y;
				float num2 = 0f;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					cameraConfigByTag.DefaultConfig[EFightCameraDefault.相机臂偏移Y] = @params.Option.Offset.Y.Value;
					goto IL_325;
				}
			}
			cameraConfigByTag.DefaultConfig.Remove(EFightCameraDefault.相机臂偏移Y);
			IL_325:
			IAdjustPlayerCameraType option6 = @params.Option;
			if (option6 != null && option6.Offset.Z != null)
			{
				float? num = @params.Option.Offset.Z;
				float num2 = 0f;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					cameraConfigByTag.DefaultConfig[EFightCameraDefault.相机臂偏移Z] = @params.Option.Offset.Z.Value;
					goto IL_3A9;
				}
			}
			cameraConfigByTag.DefaultConfig.Remove(EFightCameraDefault.相机臂偏移Z);
			IL_3A9:
			IAdjustPlayerCameraType option7 = @params.Option;
			bool flag4;
			if (option7 == null)
			{
				flag4 = false;
			}
			else
			{
				float fov = option7.Fov;
				flag4 = true;
			}
			if (flag4 && @params.Option.Fov != 0f)
			{
				cameraConfigByTag.DefaultConfig[EFightCameraDefault.Fov] = @params.Option.Fov;
			}
			else
			{
				cameraConfigByTag.DefaultConfig.Remove(EFightCameraDefault.Fov);
			}
			IAdjustPlayerCameraType option8 = @params.Option;
			if (option8 == null || option8.IsDisableResetFocus == null)
			{
				cameraConfigByTag.DefaultConfig.Remove(EFightCameraDefault.禁用重置视角);
			}
			else
			{
				cameraConfigByTag.DefaultConfig[EFightCameraDefault.禁用重置视角] = (@params.Option.IsDisableResetFocus.Value > false);
			}
			IAdjustPlayerCameraType option9 = @params.Option;
			if (option9 == null || option9.Type != EAdjustPlayerCamera.Basic)
			{
				IAdjustPlayerCameraType option10 = @params.Option;
				if (option10 == null || option10.Type != EAdjustPlayerCamera.FirstPerson)
				{
					return true;
				}
			}
			if (@params.Option.YawLimitMax != null)
			{
				cameraConfigByTag.DefaultConfig[EFightCameraDefault.Yaw限制Max] = @params.Option.YawLimitMax.Value;
			}
			else
			{
				cameraConfigByTag.DefaultConfig.Remove(EFightCameraDefault.Yaw限制Max);
			}
			if (@params.Option.YawLimitMin != null)
			{
				cameraConfigByTag.DefaultConfig[EFightCameraDefault.Yaw限制Min] = @params.Option.YawLimitMin.Value;
			}
			else
			{
				cameraConfigByTag.DefaultConfig.Remove(EFightCameraDefault.Yaw限制Min);
			}
			if (@params.Option.PitchLimitMax != null)
			{
				cameraConfigByTag.DefaultConfig[EFightCameraDefault.Pitch限制Max] = @params.Option.PitchLimitMax.Value;
			}
			else
			{
				cameraConfigByTag.DefaultConfig.Remove(EFightCameraDefault.Pitch限制Max);
			}
			if (@params.Option.PitchLimitMin != null)
			{
				cameraConfigByTag.DefaultConfig[EFightCameraDefault.Pitch限制Min] = @params.Option.PitchLimitMin.Value;
			}
			else
			{
				cameraConfigByTag.DefaultConfig.Remove(EFightCameraDefault.Pitch限制Min);
			}
			return true;
		}

		// Token: 0x0604517A RID: 283002 RVA: 0x012052F8 File Offset: 0x012034F8
		private void EnableHookConfig(AdjustPlayerCamera @params, int? extraTagId = null)
		{
			FightCameraLogicComponent logicComponent = ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent;
			if (logicComponent != null)
			{
				logicComponent.CameraConfigController.EnableHookConfig(@params.Option.Type, extraTagId);
			}
			if (Global.BaseCharacter != null)
			{
				EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(Global.BaseCharacter.EntityId);
				if (entityById == null)
				{
					return;
				}
				WorldEntity entity = entityById.Entity;
				if (entity == null)
				{
					return;
				}
				CharacterInputComponent component = entity.GetComponent<CharacterInputComponent>();
				if (component == null)
				{
					return;
				}
				component.InterruptAutoMoving("进入相机调整AdjustPlayerCamera", true);
			}
		}

		// Token: 0x0604517B RID: 283003 RVA: 0x01205378 File Offset: 0x01203578
		private void CameraMoveFinished(string cameraName)
		{
			if (cameraName != "MainCamera")
			{
				return;
			}
			base.FinishExecute(true);
			if (Singleton<EventSystem>.Instance.Has(EEventName.AdjustCameraSync, new Action<string>(this.CameraMoveFinished)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.AdjustCameraSync, new Action<string>(this.CameraMoveFinished));
			}
		}

		// Token: 0x040268DA RID: 157914
		[Nullable(2)]
		private CameraConfig HookConfig;

		// Token: 0x040268DB RID: 157915
		[Nullable(2)]
		private AdjustPlayerCamera Param;

		// Token: 0x040268DC RID: 157916
		private const float IMMEDIATELY_FADE_CAMERA_TIME = 0.1f;

		// Token: 0x040268DD RID: 157917
		private static readonly int noAimGameplayTag = GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.禁止瞄准模式"];
	}
}
