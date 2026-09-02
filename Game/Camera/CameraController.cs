using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Data.Camera;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Gamepad;
using CSharpScript.Game.Module.SeamlessTravel;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x02007085 RID: 28805
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class CameraController : ControllerBase<CameraController>
	{
		// Token: 0x1700A59C RID: 42396
		// (get) Token: 0x06045CEC RID: 285932 RVA: 0x012461CC File Offset: 0x012443CC
		public CameraModelInstance MainModel
		{
			get
			{
				return ModelBase<CameraModel>.Instance.MainModel;
			}
		}

		// Token: 0x06045CED RID: 285933 RVA: 0x012461D8 File Offset: 0x012443D8
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Add(EEventName.BeforeLoadMap, new Action(this.BeforeLoadMap));
			Singleton<EventSystem>.Instance.Add(EEventName.AfterLoadMap, new Action(this.AfterLoadMap));
			return base.OnInit();
		}

		// Token: 0x06045CEE RID: 285934 RVA: 0x01246240 File Offset: 0x01244440
		public void OnPossess([Nullable(2)] APawn pawn, string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			FightCamera fightCamera = separateCameraModel.FightCamera;
			if (fightCamera != null)
			{
				fightCamera.LogicComponent.SetPawn(pawn);
			}
			SequenceCamera sequenceCamera = separateCameraModel.SequenceCamera;
			if (sequenceCamera == null)
			{
				return;
			}
			sequenceCamera.PlayerComponent.SetPawn(pawn);
		}

		// Token: 0x06045CEF RID: 285935 RVA: 0x0124628A File Offset: 0x0124448A
		[return: Nullable(2)]
		public CameraModelInstance GetSeparateCameraModel(string cameraName)
		{
			return ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
		}

		// Token: 0x06045CF0 RID: 285936 RVA: 0x01246298 File Offset: 0x01244498
		public CameraModelInstance InitSeparateCamera(string cameraName, [Nullable(2)] Vector2D initLocation = null, [Nullable(2)] Vector2D initSize = null, bool enableScissorOffset = false, bool enableLog = false)
		{
			if (enableLog)
			{
				Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[分屏相机]初始化分屏", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			CameraModelInstance cameraModelInstance = ModelBase<CameraModel>.Instance.CreateSeparateCameraModel(cameraName);
			if (cameraName != "MainCamera")
			{
				this.CacheAndDisableFrameGenCvars();
			}
			Vector2D viewLocation = initLocation ?? Vector2D.Create();
			Vector2D viewSize = initSize ?? Vector2D.Create();
			cameraModelInstance.SetViewInfo(viewLocation, viewSize, enableScissorOffset);
			return cameraModelInstance;
		}

		// Token: 0x06045CF1 RID: 285937 RVA: 0x01246304 File Offset: 0x01244504
		private void CacheAndDisableFrameGenCvars()
		{
			if (this.CachedFrameGenCvarValues.Count > 0)
			{
				return;
			}
			foreach (string text in CameraController.SeparateCameraDisabledCvars)
			{
				int consoleVariableIntValue = UKismetSystemLibrary.GetConsoleVariableIntValue(text);
				this.CachedFrameGenCvarValues[text] = consoleVariableIntValue;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[分屏相机]缓存帧生成CVar";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(text, consoleVariableIntValue);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, text + " 0", null);
			}
			Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableDLSSG("Separate_Camera");
		}

		// Token: 0x06045CF2 RID: 285938 RVA: 0x0124639C File Offset: 0x0124459C
		private void RestoreFrameGenCvars()
		{
			if (this.CachedFrameGenCvarValues.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<string, int> keyValuePair in this.CachedFrameGenCvarValues)
			{
				UObject world = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted(keyValuePair.Key);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(keyValuePair.Value);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			}
			this.CachedFrameGenCvarValues.Clear();
			Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableDLSSG("Separate_Camera");
			Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[分屏相机]还原帧生成CVar", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06045CF3 RID: 285939 RVA: 0x01246470 File Offset: 0x01244670
		[NullableContext(2)]
		public void FadeSeparateCamera([Nullable(1)] string cameraName, float fadeTime, Vector2D targetViewLocation = null, Vector2D targetViewSize = null, bool enableScissorOffset = false, UCurveFloat curveFloat = null, Action callback = null, bool enableLog = false)
		{
			CameraModelInstance cameraModelInstance = ModelBase<CameraModel>.Instance.CreateSeparateCameraModel(cameraName);
			Vector2D targetViewLocation2 = targetViewLocation ?? Vector2D.Create();
			Vector2D targetViewSize2 = targetViewSize ?? Vector2D.Create();
			if (enableLog)
			{
				Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[分屏相机]开始调整分屏", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			cameraModelInstance.SetTargetViewInfo(fadeTime, targetViewLocation2, targetViewSize2, enableScissorOffset, curveFloat, delegate
			{
				if (enableLog)
				{
					Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[分屏相机]副屏调整结束", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			});
		}

		// Token: 0x06045CF4 RID: 285940 RVA: 0x012464F4 File Offset: 0x012446F4
		[NullableContext(2)]
		public void DestroySeparateCameraModel([Nullable(1)] string cameraName, float fadeTime, Vector2D targetViewLocation = null, Vector2D targetViewSize = null, bool enableScissorOffset = false, UCurveFloat curveFloat = null, Action callback = null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[分屏相机]开始离开分屏";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cameraName", cameraName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.FadeSeparateCamera(cameraName, fadeTime, targetViewLocation, targetViewSize, enableScissorOffset, curveFloat, delegate
			{
				ModelBase<CameraModel>.Instance.DestroySeparateCameraModel(cameraName);
				if (!ModelBase<CameraModel>.Instance.HasSeparateCamera())
				{
					this.RestoreFrameGenCvars();
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Camera;
				ELogAuthor author2 = ELogAuthor.LJM;
				string message2 = "[分屏相机]结束离开分屏";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("cameraName", cameraName);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			}, false);
		}

		// Token: 0x06045CF5 RID: 285941 RVA: 0x0124656C File Offset: 0x0124476C
		[NullableContext(2)]
		public unsafe void SetViewTarget(AActor newViewTarget, [Nullable(1)] string reason, float blendTime = 0f, EViewTargetBlendFunction blendFunction = EViewTargetBlendFunction.VTBlend_Linear, float blendExp = 0f, bool? bLockOutgoing = null, bool? bKuroEnableBlend = null, [Nullable(1)] string cameraName = "MainCamera", Action callback = null, UCurveFloat blendCurve = null)
		{
			if (newViewTarget == null || !newViewTarget.IsValid())
			{
				Singleton<Log>.Instance.Warn(ELogModule.Camera, ELogAuthor.LCZ, "Camera not valid", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			APlayerController playerController = this.GetPlayerController();
			if (playerController == null)
			{
				return;
			}
			playerController.bShouldPerformFullTickWhenPaused = true;
			APlayerCameraManager playerCameraManager = this.GetPlayerCameraManager(cameraName);
			if (playerCameraManager == null || !playerCameraManager.IsValid())
			{
				return;
			}
			CameraModelInstance model = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (model == null)
			{
				return;
			}
			model.CurrentCameraActor = newViewTarget;
			model.CurrentCameraComponent = (newViewTarget.GetComponentByClass(UCameraComponent.StaticClass()) as UCameraComponent);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "绑定相机 SetViewTarget";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", newViewTarget);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("blendTime", blendTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			CameraController.ViewTargetTransitionParams.BlendTime = (CameraUtility.CharacterMovementBaseIsMoving() ? 0f : blendTime);
			CameraController.ViewTargetTransitionParams.BlendFunction = blendFunction;
			CameraController.ViewTargetTransitionParams.BlendExp = blendExp;
			CameraController.ViewTargetTransitionParams.bLockOutgoing = bLockOutgoing.GetValueOrDefault();
			CameraController.ViewTargetTransitionParams.bKuroEnableBlend = bKuroEnableBlend.GetValueOrDefault();
			CameraController.ViewTargetTransitionParams.BlendCurve = blendCurve;
			playerCameraManager.ResetViewTarget(newViewTarget, CameraController.ViewTargetTransitionParams);
			model.CurrentCameraComponent.bEnableScissorOffCenter = model.IsEnableScissorOffsetCenter();
			Singleton<EventSystem>.Instance.Emit<float, string>(EEventName.CameraViewTargetChanged, CameraUtility.CharacterMovementBaseIsMoving() ? 0f : blendTime, cameraName);
			if (blendTime > 0f)
			{
				model.IsInCameraModeBlending = true;
				TimerSystem.Instance.Delay(delegate(float _)
				{
					model.IsInCameraModeBlending = false;
					Action callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3();
				}, blendTime * 1000f, null, null, true, 1f);
				return;
			}
			model.IsInCameraModeBlending = false;
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		}

		// Token: 0x06045CF6 RID: 285942 RVA: 0x0124679C File Offset: 0x0124499C
		public void ResetViewTarget(float blendTime = 0f, EViewTargetBlendFunction blendFunction = EViewTargetBlendFunction.VTBlend_Linear, float blendExp = 0f, string cameraName = "MainCamera", [Nullable(2)] UCurveFloat blendCurve = null)
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			CameraController.ViewTargetTransitionParams.BlendTime = blendTime;
			CameraController.ViewTargetTransitionParams.BlendFunction = blendFunction;
			CameraController.ViewTargetTransitionParams.BlendExp = blendExp;
			CameraController.ViewTargetTransitionParams.bLockOutgoing = true;
			CameraController.ViewTargetTransitionParams.bKuroEnableBlend = true;
			CameraController.ViewTargetTransitionParams.BlendCurve = blendCurve;
			separateCameraModel.PlayerCameraManager.ResetViewTarget(separateCameraModel.CurrentCameraActor, CameraController.ViewTargetTransitionParams);
			separateCameraModel.CurrentCameraComponent.bEnableScissorOffCenter = separateCameraModel.IsEnableScissorOffsetCenter();
		}

		// Token: 0x06045CF7 RID: 285943 RVA: 0x01246829 File Offset: 0x01244A29
		protected override void OnTick(float delta)
		{
			this.UpdateCameraLayout(delta);
			this.UpdateCameraTransform();
			this.UpdateCameraDitherRadius();
		}

		// Token: 0x06045CF8 RID: 285944 RVA: 0x01246840 File Offset: 0x01244A40
		[NullableContext(2)]
		public unsafe bool EnterCameraMode(ECustomCameraMode mode, float blendTime = 0f, EViewTargetBlendFunction blendFunction = EViewTargetBlendFunction.VTBlend_Linear, float blendExp = 0f, Action callback = null, bool bMustCallback = false, [Nullable(1)] string cameraName = "MainCamera", UCurveFloat blendCurve = null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraMode]EnterCameraMode";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("mode", mode);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("blendTime", blendTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("blendFunction", blendFunction);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("blendExp", blendExp);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("bMustCallback", bMustCallback);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("cameraName", cameraName);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			if (this.CameraModeMutex)
			{
				return this.PushPendingCameraModeRequest(true, mode, blendTime, blendFunction, blendExp, callback, bMustCallback, cameraName, blendCurve);
			}
			this.CameraModeMutex = true;
			bool result;
			try
			{
				result = this.EnterCameraModeInternal(mode, blendTime, blendFunction, blendExp, callback, bMustCallback, cameraName, blendCurve);
			}
			finally
			{
				this.CameraModeMutex = false;
			}
			this.DrainPendingCameraModeRequests();
			return result;
		}

		// Token: 0x06045CF9 RID: 285945 RVA: 0x01246978 File Offset: 0x01244B78
		[NullableContext(2)]
		private unsafe bool EnterCameraModeInternal(ECustomCameraMode mode, float blendTime, EViewTargetBlendFunction blendFunction, float blendExp, Action callback, bool bMustCallback, [Nullable(1)] string cameraName, UCurveFloat blendCurve)
		{
			if (mode == ECustomCameraMode.LockOn)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[CameraMode]战斗镜头不应主动切换，应由其他镜头退出时被动切换";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cameraName", cameraName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return false;
			}
			separateCameraModel.EnableMode(mode);
			if (separateCameraModel.IsInHigherMode(mode))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Camera;
				ELogAuthor author2 = ELogAuthor.LJM;
				string message2 = "[CameraMode]意图进入较低优先级的镜头";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CurrentMode", separateCameraModel.CameraMode);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("NewMode", mode);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Index", cameraName);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				if (bMustCallback && callback != null)
				{
					callback();
				}
				return false;
			}
			return this.SwitchCameraMode(mode, blendTime, blendFunction, blendExp, callback, cameraName, blendCurve);
		}

		// Token: 0x06045CFA RID: 285946 RVA: 0x01246A74 File Offset: 0x01244C74
		[NullableContext(2)]
		public unsafe bool ExitCameraMode(ECustomCameraMode mode, float blendTime = 0f, EViewTargetBlendFunction blendFunction = EViewTargetBlendFunction.VTBlend_Linear, float blendExp = 0f, Action callback = null, [Nullable(1)] string cameraName = "MainCamera", UCurveFloat blendCurve = null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraMode]ExitCameraMode";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("mode", mode);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("blendTime", blendTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("blendFunction", blendFunction);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("blendExp", blendExp);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("cameraName", cameraName);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			if (this.CameraModeMutex)
			{
				return this.PushPendingCameraModeRequest(false, mode, blendTime, blendFunction, blendExp, callback, true, cameraName, blendCurve);
			}
			this.CameraModeMutex = true;
			bool result;
			try
			{
				result = this.ExitCameraModeInternal(mode, blendTime, blendFunction, blendExp, callback, cameraName, blendCurve);
			}
			finally
			{
				this.CameraModeMutex = false;
			}
			this.DrainPendingCameraModeRequests();
			return result;
		}

		// Token: 0x06045CFB RID: 285947 RVA: 0x01246B88 File Offset: 0x01244D88
		[NullableContext(2)]
		private bool ExitCameraModeInternal(ECustomCameraMode mode, float blendTime, EViewTargetBlendFunction blendFunction, float blendExp, Action callback, [Nullable(1)] string cameraName, UCurveFloat blendCurve)
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return false;
			}
			if (mode == ECustomCameraMode.LockOn)
			{
				Singleton<Log>.Instance.Error(ELogModule.Camera, ELogAuthor.WCL, "战斗镜头不应主动切换，应由其他镜头退出时被动切换", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			separateCameraModel.DisableMode(mode);
			return this.SwitchCameraMode(separateCameraModel.GetNextMode(), blendTime, blendFunction, blendExp, callback, cameraName, blendCurve);
		}

		// Token: 0x06045CFC RID: 285948 RVA: 0x01246BE8 File Offset: 0x01244DE8
		[NullableContext(2)]
		private unsafe bool PushPendingCameraModeRequest(bool isEnter, ECustomCameraMode mode, float blendTime, EViewTargetBlendFunction blendFunction, float blendExp, Action callback, bool bMustCallback, [Nullable(1)] string cameraName, UCurveFloat blendCurve)
		{
			if (this.PendingCameraModeRequests.Count >= 5)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[CameraMode]镜头模式切换嵌套请求过多，疑似循环调用，丢弃本次请求";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsEnter", isEnter);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Mode", mode);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CameraName", cameraName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return false;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Camera;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "[CameraMode]PushPendingCameraModeRequest 镜头模式切换产生嵌套，加入队列待当前切换完成后执行";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("IsEnter", isEnter);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("mode", mode);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("blendTime", blendTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("blendFunction", blendFunction);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("blendExp", blendExp);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 5) = new ValueTuple<string, object>("bMustCallback", bMustCallback);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 6) = new ValueTuple<string, object>("cameraName", cameraName);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 7));
			this.PendingCameraModeRequests.Add(new CameraController.PendingCameraModeRequest
			{
				IsEnter = isEnter,
				Mode = mode,
				BlendTime = blendTime,
				BlendFunction = blendFunction,
				BlendExp = blendExp,
				Callback = callback,
				BMustCallback = bMustCallback,
				CameraName = cameraName,
				BlendCurve = blendCurve
			});
			return true;
		}

		// Token: 0x06045CFD RID: 285949 RVA: 0x01246DC0 File Offset: 0x01244FC0
		private unsafe void DrainPendingCameraModeRequests()
		{
			if (this.IsDrainingCameraModeRequests)
			{
				return;
			}
			this.IsDrainingCameraModeRequests = true;
			try
			{
				Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraMode]PushPendingCameraModeRequest 开始处理等待", default(ReadOnlySpan<ValueTuple<string, object>>));
				int num = 0;
				while (this.PendingCameraModeRequests.Count > 0)
				{
					if (++num > 5)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Camera;
						ELogAuthor author = ELogAuthor.LJM;
						string message = "[CameraMode]DrainPendingCameraModeRequests 镜头模式切换产生循环调用，丢弃剩余请求";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Remaining", this.PendingCameraModeRequests.Count);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						this.PendingCameraModeRequests.Clear();
						break;
					}
					CameraController.PendingCameraModeRequest pendingCameraModeRequest = this.PendingCameraModeRequests[0];
					this.PendingCameraModeRequests.RemoveAt(0);
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Camera;
					ELogAuthor author2 = ELogAuthor.LJM;
					string message2 = "[CameraMode]PushPendingCameraModeRequest 处理";
					<>y__InlineArray9<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray9<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("index", num - 1);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isEnter", pendingCameraModeRequest.IsEnter);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Mode", pendingCameraModeRequest.Mode);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("isEnter", pendingCameraModeRequest.IsEnter);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("BlendTime", pendingCameraModeRequest.BlendTime);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("BlendFunction", pendingCameraModeRequest.BlendFunction);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("BlendExp", pendingCameraModeRequest.BlendExp);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("MustCallback", pendingCameraModeRequest.BMustCallback);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 8) = new ValueTuple<string, object>("CameraName", pendingCameraModeRequest.CameraName);
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray9<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 9));
					if (pendingCameraModeRequest.IsEnter)
					{
						this.EnterCameraMode(pendingCameraModeRequest.Mode, pendingCameraModeRequest.BlendTime, pendingCameraModeRequest.BlendFunction, pendingCameraModeRequest.BlendExp, pendingCameraModeRequest.Callback, pendingCameraModeRequest.BMustCallback, pendingCameraModeRequest.CameraName, pendingCameraModeRequest.BlendCurve);
					}
					else
					{
						this.ExitCameraMode(pendingCameraModeRequest.Mode, pendingCameraModeRequest.BlendTime, pendingCameraModeRequest.BlendFunction, pendingCameraModeRequest.BlendExp, pendingCameraModeRequest.Callback, pendingCameraModeRequest.CameraName, pendingCameraModeRequest.BlendCurve);
					}
				}
			}
			finally
			{
				Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraMode]PushPendingCameraModeRequest 结束处理等待", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.IsDrainingCameraModeRequests = false;
			}
		}

		// Token: 0x06045CFE RID: 285950 RVA: 0x01247094 File Offset: 0x01245294
		public Rotator GetCameraRotation(Rotator outRotator, string cameraName = "MainCamera")
		{
			outRotator.Reset();
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return outRotator;
			}
			FightCamera fightCamera = separateCameraModel.FightCamera;
			FightCameraLogicComponent fightCameraLogicComponent = (fightCamera != null) ? fightCamera.LogicComponent : null;
			ECustomCameraMode? cameraMode = separateCameraModel.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.LockOn;
			if ((cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null) && !separateCameraModel.IsInCameraModeBlending && fightCameraLogicComponent != null)
			{
				outRotator.FromUeRotator(fightCameraLogicComponent.CameraRotation);
			}
			else
			{
				FRotator cameraRotation = separateCameraModel.PlayerCameraManager.GetCameraRotation();
				outRotator.FromUeRotator(cameraRotation);
			}
			return outRotator;
		}

		// Token: 0x06045CFF RID: 285951 RVA: 0x01247118 File Offset: 0x01245318
		[NullableContext(2)]
		private bool SwitchCameraMode(ECustomCameraMode mode, float blendTime = 0f, EViewTargetBlendFunction blendFunction = EViewTargetBlendFunction.VTBlend_Linear, float blendExp = 0f, Action callback = null, [Nullable(1)] string cameraName = "MainCamera", UCurveFloat blendCurve = null)
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return false;
			}
			ECustomCameraMode? cameraMode = separateCameraModel.CameraMode;
			if (cameraMode.GetValueOrDefault() == mode & cameraMode != null)
			{
				return false;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraMode]CameraManager.SwitchCameraMode:切换镜头模式";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mode", mode);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			separateCameraModel.SetCameraMode(mode);
			if (mode == ECustomCameraMode.Sequence || mode == ECustomCameraMode.Scene)
			{
				Global.CharacterCameraManager.StopAllCameraShakes(true);
			}
			ACameraActor newViewTarget;
			switch (mode)
			{
			case ECustomCameraMode.LockOn:
				newViewTarget = separateCameraModel.FightCamera.DisplayComponent.CameraActor;
				break;
			case ECustomCameraMode.Sequence:
				newViewTarget = separateCameraModel.SequenceCamera.DisplayComponent.CineCamera;
				break;
			case ECustomCameraMode.Widget:
				newViewTarget = separateCameraModel.WidgetCamera.DisplayComponent.CineCamera;
				break;
			case ECustomCameraMode.Scene:
				newViewTarget = separateCameraModel.SceneCamera.DisplayComponent.CineCamera;
				break;
			case ECustomCameraMode.Orbital:
				newViewTarget = separateCameraModel.OrbitalCamera.DisplayComponent.CineCamera;
				break;
			case ECustomCameraMode.Free:
				newViewTarget = separateCameraModel.FreeCamera.DisplayComponent.CameraActor;
				break;
			default:
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Camera;
				ELogAuthor author2 = ELogAuthor.LJM;
				string message2 = "CameraManager.SwitchCameraMode: 错误的镜头模式 ";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("mode", mode);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			}
			float blendTime2 = blendTime * ModelBase<CharacterModel>.Instance.SelfCenteredTimeDilation;
			this.SetViewTarget(newViewTarget, "SwitchMode", blendTime2, blendFunction, blendExp, new bool?(true), new bool?(true), cameraName, callback, blendCurve);
			return true;
		}

		// Token: 0x06045D00 RID: 285952 RVA: 0x01247294 File Offset: 0x01245494
		public void RefreshSequenceCamera(string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			ECustomCameraMode? cameraMode = separateCameraModel.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Sequence;
			if (!(cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null))
			{
				return;
			}
			this.SetViewTarget(separateCameraModel.SequenceCamera.DisplayComponent.CineCamera, "RefreshMode", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, new bool?(false), new bool?(false), cameraName, null, null);
		}

		// Token: 0x06045D01 RID: 285953 RVA: 0x01247304 File Offset: 0x01245504
		public void EnterDialogueMode([Nullable(2)] Vector interactPoint, bool delayBlendInDialogueCamera = false, float? specificOffsetRate = null, float? specificHeightOffset = null, string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			separateCameraModel.FightCamera.LogicComponent.EnterSequenceDialogue(interactPoint, delayBlendInDialogueCamera, specificOffsetRate, specificHeightOffset);
		}

		// Token: 0x06045D02 RID: 285954 RVA: 0x01247338 File Offset: 0x01245538
		public void ExitDialogMode(string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			separateCameraModel.FightCamera.LogicComponent.ExitSequenceDialogue();
		}

		// Token: 0x06045D03 RID: 285955 RVA: 0x01247368 File Offset: 0x01245568
		public void EnterCameraExplore(int id, FVectorDouble? lookAt1, FVectorDouble? lookAt2, float prepTime, float fadeDistance, float armLengthMin, float armLengthMax, string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			separateCameraModel.FightCamera.LogicComponent.EnterCameraExplore(id, lookAt1, lookAt2, prepTime, fadeDistance, armLengthMin, armLengthMax);
		}

		// Token: 0x06045D04 RID: 285956 RVA: 0x012473A4 File Offset: 0x012455A4
		public void ExitCameraExplore(int id, string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			separateCameraModel.FightCamera.LogicComponent.ExitCameraExplore(id);
		}

		// Token: 0x06045D05 RID: 285957 RVA: 0x012473D2 File Offset: 0x012455D2
		public ACameraActor SpawnCameraActor()
		{
			ACameraActor acameraActor = this.SpawnActor<ACameraActor>(ACameraActor.StaticClass());
			acameraActor.CameraComponent.bConstrainAspectRatio = false;
			return acameraActor;
		}

		// Token: 0x06045D06 RID: 285958 RVA: 0x012473EC File Offset: 0x012455EC
		public void SetInputEnable(object handler, bool bVisible, string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			separateCameraModel.FightCamera.LogicComponent.CameraInputController.SetInputEnable(handler, bVisible);
		}

		// Token: 0x06045D07 RID: 285959 RVA: 0x01247420 File Offset: 0x01245620
		public BP_CineCamera_C SpawnCineCamera()
		{
			return this.SpawnActor<BP_CineCamera_C>(BP_CineCamera_C.StaticClass());
		}

		// Token: 0x06045D08 RID: 285960 RVA: 0x0124742D File Offset: 0x0124562D
		public T SpawnActor<[Nullable(0)] T>(UClassStackOnlyPtr type) where T : AActor
		{
			return (T)((object)Singleton<ActorSystem>.Instance.Get(type, Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true));
		}

		// Token: 0x06045D09 RID: 285961 RVA: 0x0124744B File Offset: 0x0124564B
		[NullableContext(2)]
		public ACharacter GetCharacter()
		{
			return Global.BaseCharacter;
		}

		// Token: 0x06045D0A RID: 285962 RVA: 0x01247452 File Offset: 0x01245652
		[NullableContext(2)]
		public APlayerController GetPlayerController()
		{
			return Global.PlayerController;
		}

		// Token: 0x06045D0B RID: 285963 RVA: 0x0124745C File Offset: 0x0124565C
		public TArray<SCamera_Setting> GetCameraConfigs([Nullable(2)] UDataTable dataTable = null)
		{
			TArray<SCamera_Setting> result = new TArray<SCamera_Setting>();
			BPL_CameraUtility_C.DtGetCameraConfigs(ref result, dataTable, GlobalData.World);
			return result;
		}

		// Token: 0x06045D0C RID: 285964 RVA: 0x01247480 File Offset: 0x01245680
		public TArray<SCameraConfig> GetCameraConfigList([Nullable(2)] UDataTable dataTable = null)
		{
			TArray<SCameraConfig> result = new TArray<SCameraConfig>();
			BPL_CameraUtility_C.DtGetCameraConfigList(ref result, dataTable, GlobalData.World);
			return result;
		}

		// Token: 0x06045D0D RID: 285965 RVA: 0x012474A1 File Offset: 0x012456A1
		public APlayerCameraManager GetMainPlayerCameraManager()
		{
			return Global.CharacterCameraManager;
		}

		// Token: 0x06045D0E RID: 285966 RVA: 0x012474A8 File Offset: 0x012456A8
		[return: Nullable(2)]
		public APlayerCameraManager GetPlayerCameraManager(string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return null;
			}
			return separateCameraModel.PlayerCameraManager;
		}

		// Token: 0x06045D0F RID: 285967 RVA: 0x012474C0 File Offset: 0x012456C0
		public void SetTimeDilation(float timeDilation, string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			separateCameraModel.FightCamera.SetTimeDilation(timeDilation);
			separateCameraModel.SequenceCamera.SetTimeDilation(timeDilation);
			separateCameraModel.WidgetCamera.SetTimeDilation(timeDilation);
			separateCameraModel.OrbitalCamera.SetTimeDilation(timeDilation);
			FreeCamera freeCamera = separateCameraModel.FreeCamera;
			if (freeCamera != null)
			{
				freeCamera.SetTimeDilation(timeDilation);
			}
			Global.CharacterCameraManager.CameraModifyCustomTimeDilation = timeDilation;
		}

		// Token: 0x06045D10 RID: 285968 RVA: 0x0124752C File Offset: 0x0124572C
		public void PlayWorldCameraShake([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase> shakeClass, FVectorDouble? location, float innerRadius, float outerRadius, float falloff, bool shakeTowardsEpicenter, string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			if (this.IsSettlementCamera(cameraName) || this.IsSequenceCameraInCinematic(cameraName))
			{
				return;
			}
			if (separateCameraModel.ShakeModify > 0f)
			{
				UGameplayStatics.D_PlayWorldCameraShakeWithModifier(GlobalData.World, shakeClass, location.GetValueOrDefault(), innerRadius, outerRadius, falloff, shakeTowardsEpicenter, separateCameraModel.ShakeModify, ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
			}
			this.PlayForceFeedbackFromCameraShake(new TSubclassOf<UCameraShakeBase>?(shakeClass), cameraName);
		}

		// Token: 0x06045D11 RID: 285969 RVA: 0x012475A4 File Offset: 0x012457A4
		public int PlayCameraShake([Nullable(2)] UClass shakeClass, float? scale = null, ECameraShakePlaySpace? playSpace = null, FRotator? userPlaySpaceRot = null, bool playForceFeedback = false, bool stopManually = false, string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return -1;
			}
			if (!Global.CharacterCameraManager.IsValid())
			{
				return -1;
			}
			if (this.IsSettlementCamera(cameraName) || this.IsSequenceCameraInCinematic(cameraName))
			{
				return -1;
			}
			UCameraShakeBase ucameraShakeBase = Global.CharacterCameraManager.StartCameraShake(shakeClass, scale.GetValueOrDefault(1f), playSpace.GetValueOrDefault(), userPlaySpaceRot.GetValueOrDefault(), ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
			if (playForceFeedback)
			{
				this.PlayForceFeedbackFromCameraShake(new TSubclassOf<UCameraShakeBase>?(shakeClass), cameraName);
			}
			if (stopManually && ucameraShakeBase != null)
			{
				Dictionary<int, UCameraShakeBase> cameraShakeMap = separateCameraModel.CameraShakeMap;
				CameraModelInstance cameraModelInstance = separateCameraModel;
				int num = cameraModelInstance.CameraShakeInstanceId + 1;
				cameraModelInstance.CameraShakeInstanceId = num;
				cameraShakeMap.Add(num, ucameraShakeBase);
			}
			return separateCameraModel.CameraShakeInstanceId;
		}

		// Token: 0x06045D12 RID: 285970 RVA: 0x01247660 File Offset: 0x01245860
		public void StopCameraShake(int cameraShakeInstanceId, bool playForceFeedback = false, string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			if (!Global.CharacterCameraManager.IsValid())
			{
				return;
			}
			if (!separateCameraModel.CameraShakeMap.ContainsKey(cameraShakeInstanceId))
			{
				return;
			}
			UCameraShakeBase ucameraShakeBase;
			if (separateCameraModel.CameraShakeMap.Remove(cameraShakeInstanceId, out ucameraShakeBase))
			{
				if (!ucameraShakeBase.IsValid())
				{
					return;
				}
				Global.CharacterCameraManager.StopCameraShake(ucameraShakeBase, true);
				if (playForceFeedback)
				{
					this.StopForceFeedbackFromCameraShake(new TSubclassOf<UCameraShakeBase>?(ucameraShakeBase.GetClass()), cameraName);
				}
			}
		}

		// Token: 0x06045D13 RID: 285971 RVA: 0x012476D8 File Offset: 0x012458D8
		public void PlayForceFeedbackFromCameraShake([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase>? shakeClass = null, string cameraName = "MainCamera")
		{
			if (Singleton<Info>.Instance.IsInGamepad() && (shakeClass != null && shakeClass.GetValueOrDefault().IsChildOf(BP_CameraShakeAndForceFeedback_C.StaticClass())))
			{
				UKuroForceFeedbackEffect forceFeedbackEffect = (UKuroStaticLibrary.GetDefaultObject(shakeClass.Value) as BP_CameraShakeAndForceFeedback_C).ForceFeedbackEffect;
				if (forceFeedbackEffect != null)
				{
					ControllerBase<GamepadController>.Instance.PlayKuroForceFeedback(forceFeedbackEffect, null, false, false, false, "CameraController");
				}
			}
		}

		// Token: 0x06045D14 RID: 285972 RVA: 0x01247750 File Offset: 0x01245950
		public void StopForceFeedbackFromCameraShake([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase>? shakeClass = null, string cameraName = "MainCamera")
		{
			if (Singleton<Info>.Instance.IsInGamepad() && (shakeClass != null && shakeClass.GetValueOrDefault().IsChildOf(BP_CameraShakeAndForceFeedback_C.StaticClass())))
			{
				UKuroForceFeedbackEffect forceFeedbackEffect = (UKuroStaticLibrary.GetDefaultObject(shakeClass.Value) as BP_CameraShakeAndForceFeedback_C).ForceFeedbackEffect;
				if (forceFeedbackEffect != null)
				{
					GamepadController.StopKuroForceFeedback(forceFeedbackEffect, FNameUtil.NONE);
				}
			}
		}

		// Token: 0x06045D15 RID: 285973 RVA: 0x012477B8 File Offset: 0x012459B8
		[NullableContext(2)]
		public void LoadCharacterCameraConfig(UDataTable dataTable)
		{
			ModelBase<CameraModel>.Instance.ModelIterator(delegate(CameraModelInstance cameraModelInstance)
			{
				cameraModelInstance.FightCamera.LogicComponent.CameraConfigController.LoadCharacterConfig(dataTable);
			});
		}

		// Token: 0x06045D16 RID: 285974 RVA: 0x012477E8 File Offset: 0x012459E8
		public void UnloadCharacterCameraConfig([Nullable(2)] UDataTable dataTable, string cameraName = "MainCamera")
		{
			ModelBase<CameraModel>.Instance.ModelIterator(delegate(CameraModelInstance cameraModelInstance)
			{
				cameraModelInstance.FightCamera.LogicComponent.CameraConfigController.UnloadCharacterConfig(dataTable);
			});
		}

		// Token: 0x06045D17 RID: 285975 RVA: 0x01247818 File Offset: 0x01245A18
		public unsafe bool ReturnLockOnCameraMode(float blendTime = 0f, EViewTargetBlendFunction blendFunction = EViewTargetBlendFunction.VTBlend_Linear, float blendExp = 0f, [Nullable(2)] Action callback = null, string cameraName = "MainCamera")
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraMode]ReturnLockOnCameraMode";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("blendTime", blendTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("blendFunction", blendFunction);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("blendExp", blendExp);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("cameraName", cameraName);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			if (this.CameraModeMutex)
			{
				return this.PushPendingCameraModeRequest(true, ECustomCameraMode.LockOn, blendTime, blendFunction, blendExp, callback, true, cameraName, null);
			}
			this.CameraModeMutex = true;
			bool result;
			try
			{
				result = this.ReturnLockOnCameraModeInternal(blendTime, blendFunction, blendExp, callback, cameraName);
			}
			finally
			{
				this.CameraModeMutex = false;
			}
			this.DrainPendingCameraModeRequests();
			return result;
		}

		// Token: 0x06045D18 RID: 285976 RVA: 0x01247908 File Offset: 0x01245B08
		public bool ReturnLockOnCameraModeInternal(float blendTime = 0f, EViewTargetBlendFunction blendFunction = EViewTargetBlendFunction.VTBlend_Linear, float blendExp = 0f, [Nullable(2)] Action callback = null, string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return false;
			}
			ECustomCameraMode? ecustomCameraMode = separateCameraModel.CameraMode;
			ECustomCameraMode ecustomCameraMode2 = ECustomCameraMode.LockOn;
			if (ecustomCameraMode.GetValueOrDefault() == ecustomCameraMode2 & ecustomCameraMode != null)
			{
				return false;
			}
			ECustomCameraMode? cameraMode = separateCameraModel.CameraMode;
			for (;;)
			{
				ecustomCameraMode = cameraMode;
				ecustomCameraMode2 = ECustomCameraMode.LockOn;
				if (ecustomCameraMode.GetValueOrDefault() == ecustomCameraMode2 & ecustomCameraMode != null)
				{
					break;
				}
				if (cameraMode != null)
				{
					separateCameraModel.DisableMode(cameraMode.Value);
				}
				cameraMode = new ECustomCameraMode?(separateCameraModel.GetNextMode());
			}
			return this.SwitchCameraMode(cameraMode.Value, blendTime, blendFunction, blendExp, callback, cameraName, null);
		}

		// Token: 0x06045D19 RID: 285977 RVA: 0x012479A0 File Offset: 0x01245BA0
		public bool IsSequenceCameraInCinematic(string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			SequenceCameraPlayerComponent sequenceCameraPlayerComponent;
			if (separateCameraModel == null)
			{
				sequenceCameraPlayerComponent = null;
			}
			else
			{
				SequenceCamera sequenceCamera = separateCameraModel.SequenceCamera;
				sequenceCameraPlayerComponent = ((sequenceCamera != null) ? sequenceCamera.GetComponent<SequenceCameraPlayerComponent>() : null);
			}
			SequenceCameraPlayerComponent sequenceCameraPlayerComponent2 = sequenceCameraPlayerComponent;
			return sequenceCameraPlayerComponent2 != null && sequenceCameraPlayerComponent2.Valid && sequenceCameraPlayerComponent2.GetIsInCinematic();
		}

		// Token: 0x06045D1A RID: 285978 RVA: 0x012479EC File Offset: 0x01245BEC
		private void UpdateCameraLayout(float deltaTime)
		{
			if (!ModelBase<CameraModel>.Instance.HasSeparateCamera())
			{
				return;
			}
			ModelBase<CameraModel>.Instance.ModelIterator(delegate(CameraModelInstance cameraModelInstance)
			{
				cameraModelInstance.UpdateCameraLayout(deltaTime);
			});
		}

		// Token: 0x06045D1B RID: 285979 RVA: 0x01247A29 File Offset: 0x01245C29
		private void UpdateCameraTransform()
		{
			ModelBase<CameraModel>.Instance.ModelIterator(delegate(CameraModelInstance cameraModelInstance)
			{
				AActor currentCameraActor = cameraModelInstance.CurrentCameraActor;
				if (currentCameraActor == null || !currentCameraActor.IsValid())
				{
					return;
				}
				Vector cameraLocation = cameraModelInstance.CameraLocation;
				FVectorDouble fvectorDouble = cameraModelInstance.CurrentCameraActor.D_K2_GetActorLocation();
				cameraLocation.FromUeVector(fvectorDouble);
				Rotator cameraRotator = cameraModelInstance.CameraRotator;
				FRotator frotator = cameraModelInstance.CurrentCameraActor.K2_GetActorRotation();
				cameraRotator.DeepCopy(frotator);
				cameraModelInstance.CameraTransform = new FTransformDouble?(cameraModelInstance.CurrentCameraActor.D_GetTransform());
			});
		}

		// Token: 0x06045D1C RID: 285980 RVA: 0x01247A54 File Offset: 0x01245C54
		public void UpdateCameraDitherRadius()
		{
			ModelBase<CameraModel>.Instance.ModelIterator(delegate(CameraModelInstance cameraModelInstance)
			{
				cameraModelInstance.UpdateCameraDitherRadius();
			});
		}

		// Token: 0x06045D1D RID: 285981 RVA: 0x01247A80 File Offset: 0x01245C80
		public bool IsSettlementCamera(string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			bool flag;
			if (separateCameraModel == null)
			{
				flag = (null != null);
			}
			else
			{
				FightCamera fightCamera = separateCameraModel.FightCamera;
				if (fightCamera == null)
				{
					flag = (null != null);
				}
				else
				{
					FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
					flag = (((logicComponent != null) ? logicComponent.SettlementCamera : null) != null);
				}
			}
			return flag && separateCameraModel.FightCamera.LogicComponent.SettlementCamera.IsPlayingSettlementCamera();
		}

		// Token: 0x06045D1E RID: 285982 RVA: 0x01247AD6 File Offset: 0x01245CD6
		public void StopAllCameraShakes()
		{
			Global.CharacterCameraManager.StopAllCameraShakes(true);
		}

		// Token: 0x06045D1F RID: 285983 RVA: 0x01247AE4 File Offset: 0x01245CE4
		public void SetHideHeadEnable(bool enable, EHideHeadEnum firstPersonType, string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			separateCameraModel.SetHideHeadEnabled(enable, firstPersonType);
		}

		// Token: 0x06045D20 RID: 285984 RVA: 0x01247B0C File Offset: 0x01245D0C
		private void ConstrainAspectRatio(bool bConstrainAspectRatio, string cameraName = "MainCamera")
		{
			CameraModelInstance separateCameraModel = ModelBase<CameraModel>.Instance.GetSeparateCameraModel(cameraName);
			if (separateCameraModel == null)
			{
				return;
			}
			FightCamera fightCamera = separateCameraModel.FightCamera;
			ACameraActor acameraActor;
			if (fightCamera == null)
			{
				acameraActor = null;
			}
			else
			{
				FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
				acameraActor = ((logicComponent != null) ? logicComponent.CameraActor : null);
			}
			ACameraActor acameraActor2 = acameraActor;
			if (acameraActor2 == null || !acameraActor2.IsValid() || Global.CharacterController == null)
			{
				return;
			}
			if (acameraActor2.CameraComponent.bConstrainAspectRatio == bConstrainAspectRatio)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			Global.CharacterController.GetViewportSize(ref num, ref num2);
			double num3 = (double)((float)num);
			float num4 = (float)num2;
			if (num3 / (double)num4 >= 1.76)
			{
				return;
			}
			acameraActor2.CameraComponent.bConstrainAspectRatio = bConstrainAspectRatio;
		}

		// Token: 0x06045D21 RID: 285985 RVA: 0x01247BA4 File Offset: 0x01245DA4
		public FViewTargetTransitionParams GetDefaultViewTargetTransitionParams()
		{
			CameraController.ViewTargetTransitionParams.BlendTime = 0f;
			CameraController.ViewTargetTransitionParams.BlendFunction = EViewTargetBlendFunction.VTBlend_Linear;
			CameraController.ViewTargetTransitionParams.BlendExp = 0f;
			CameraController.ViewTargetTransitionParams.bLockOutgoing = false;
			CameraController.ViewTargetTransitionParams.bKuroEnableBlend = false;
			CameraController.ViewTargetTransitionParams.BlendCurve = null;
			return CameraController.ViewTargetTransitionParams;
		}

		// Token: 0x06045D22 RID: 285986 RVA: 0x01247C08 File Offset: 0x01245E08
		public void RestoreSeparateCamera(string reason)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[分屏相机]RestoreSeparateCamera";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.InitSeparateCamera("MainCamera", Vector2D.Create(0.0, 0.0), Vector2D.Create(1.0, 1.0), false, true);
			ModelBase<CameraModel>.Instance.ModelIterator(delegate(CameraModelInstance cameraModelInstance)
			{
				ModelBase<CameraModel>.Instance.DestroySeparateCameraModel(cameraModelInstance.CameraName);
			});
			this.RestoreFrameGenCvars();
		}

		// Token: 0x06045D23 RID: 285987 RVA: 0x01247CA8 File Offset: 0x01245EA8
		private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
		{
			if (oldEntity != null && oldEntity.Valid)
			{
				BaseTagComponent component = oldEntity.Entity.GetComponent<BaseTagComponent>();
				if (component != null && component.Valid)
				{
					component.RemoveTagAddOrRemoveListener(CameraController.ConstrainAspectRatioGameplayTag, new BaseTagComponent.TTagSwitchedCallback(this.OnConstrainAspectRatioGameplayTagChanged));
				}
			}
			if (newEntity.Valid)
			{
				BaseTagComponent component2 = newEntity.Entity.GetComponent<BaseTagComponent>();
				if (component2 != null && component2.Valid)
				{
					component2.AddTagAddOrRemoveListener(CameraController.ConstrainAspectRatioGameplayTag, new BaseTagComponent.TTagSwitchedCallback(this.OnConstrainAspectRatioGameplayTagChanged), null);
					this.ConstrainAspectRatio(component2.HasTag(CameraController.ConstrainAspectRatioGameplayTag), "MainCamera");
				}
			}
		}

		// Token: 0x06045D24 RID: 285988 RVA: 0x01247D3B File Offset: 0x01245F3B
		private void OnConstrainAspectRatioGameplayTagChanged(int gameplayTagId, bool tagExist)
		{
			this.ConstrainAspectRatio(tagExist, "MainCamera");
		}

		// Token: 0x06045D25 RID: 285989 RVA: 0x01247D4C File Offset: 0x01245F4C
		private void BeforeLoadMap()
		{
			APlayerCameraManager playerCameraManager = this.GetPlayerCameraManager("MainCamera");
			ACameraActor acameraActor = (playerCameraManager != null) ? playerCameraManager.AnimCameraActor : null;
			if (acameraActor != null && acameraActor.IsValid())
			{
				ModelBase<SeamlessTravelModel>.Instance.AddSeamlessTravelActor(acameraActor);
			}
			this.RestoreSeparateCamera("BeforeLoadMap");
		}

		// Token: 0x06045D26 RID: 285990 RVA: 0x01247D94 File Offset: 0x01245F94
		private void AfterLoadMap()
		{
			APlayerCameraManager playerCameraManager = this.GetPlayerCameraManager("MainCamera");
			ACameraActor acameraActor = (playerCameraManager != null) ? playerCameraManager.AnimCameraActor : null;
			if (acameraActor != null && acameraActor.IsValid())
			{
				ModelBase<SeamlessTravelModel>.Instance.RemoveSeamlessTravelActor(acameraActor);
			}
			this.RestoreSeparateCamera("AfterLoadMap");
		}

		// Token: 0x06045D27 RID: 285991 RVA: 0x01247DDB File Offset: 0x01245FDB
		protected override bool OnLeaveLevel()
		{
			this.RestoreSeparateCamera("OnLeaveLevel");
			return true;
		}

		// Token: 0x06045D28 RID: 285992 RVA: 0x01247DE9 File Offset: 0x01245FE9
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BeforeLoadMap, new Action(this.BeforeLoadMap));
			Singleton<EventSystem>.Instance.Remove(EEventName.AfterLoadMap, new Action(this.AfterLoadMap));
			return base.OnClear();
		}

		// Token: 0x0402713D RID: 160061
		private const int SECOND_TO_MILLISECOND = 1000;

		// Token: 0x0402713E RID: 160062
		private const double CONSTRAIN_ASPECT_RATIO = 1.76;

		// Token: 0x0402713F RID: 160063
		private static readonly int ConstrainAspectRatioGameplayTag = GameplayTagDefine.EGameplayTagId["关卡.副本.跑酷副本.调节长宽比专用"];

		// Token: 0x04027140 RID: 160064
		[StaticVariableRuleIgnore]
		private static readonly string[] SeparateCameraDisabledCvars = new string[]
		{
			"r.NGX.DLSS.Enable",
			"r.Streamline.DLSSG.Enable",
			"r.FidelityFX.FSR3.Enabled",
			"r.FidelityFX.FI.Enabled",
			"r.Xess.Enabled",
			"r.XeFG.Enabled",
			"r.VolumetricCloud.MinMaxDepth"
		};

		// Token: 0x04027141 RID: 160065
		[StaticVariableRuleIgnore]
		public static readonly FViewTargetTransitionParams ViewTargetTransitionParams = new FViewTargetTransitionParams();

		// Token: 0x04027142 RID: 160066
		private const bool CameraModeDebug = true;

		// Token: 0x04027143 RID: 160067
		[StaticVariableRuleIgnore]
		private static readonly Vector2D TmpVector2D1 = Vector2D.Create();

		// Token: 0x04027144 RID: 160068
		[StaticVariableRuleIgnore]
		private static readonly Vector2D TmpVector2D2 = Vector2D.Create();

		// Token: 0x04027145 RID: 160069
		[StaticVariableRuleIgnore]
		private static readonly Vector2D TmpVector2D3 = Vector2D.Create();

		// Token: 0x04027146 RID: 160070
		[StaticVariableRuleIgnore]
		private static readonly Vector2D TmpVector2D4 = Vector2D.Create();

		// Token: 0x04027147 RID: 160071
		private readonly Dictionary<string, int> CachedFrameGenCvarValues = new Dictionary<string, int>();

		// Token: 0x04027148 RID: 160072
		private bool CameraModeMutex;

		// Token: 0x04027149 RID: 160073
		private List<CameraController.PendingCameraModeRequest> PendingCameraModeRequests = new List<CameraController.PendingCameraModeRequest>();

		// Token: 0x0402714A RID: 160074
		private const int CAMERA_MODE_MAX_PENDING_COUNT = 5;

		// Token: 0x0402714B RID: 160075
		private bool IsDrainingCameraModeRequests;

		// Token: 0x0200CCAE RID: 52398
		[NullableContext(2)]
		[Nullable(0)]
		private class PendingCameraModeRequest
		{
			// Token: 0x0403EC85 RID: 257157
			public bool IsEnter;

			// Token: 0x0403EC86 RID: 257158
			public ECustomCameraMode Mode;

			// Token: 0x0403EC87 RID: 257159
			public float BlendTime;

			// Token: 0x0403EC88 RID: 257160
			public EViewTargetBlendFunction BlendFunction;

			// Token: 0x0403EC89 RID: 257161
			public float BlendExp;

			// Token: 0x0403EC8A RID: 257162
			public Action Callback;

			// Token: 0x0403EC8B RID: 257163
			public bool BMustCallback;

			// Token: 0x0403EC8C RID: 257164
			[Nullable(1)]
			public string CameraName = "MainCamera";

			// Token: 0x0403EC8D RID: 257165
			public UCurveFloat BlendCurve;
		}
	}
}
