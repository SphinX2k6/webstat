using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.UI.Manager;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x02000E1D RID: 3613
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(true)]
public class CameraGuideController : CameraControllerBase<EFightCameraGuide>, ICanGetConfigMapValue
{
	// Token: 0x0600554B RID: 21835 RVA: 0x000D90FC File Offset: 0x000D72FC
	public CameraGuideController(FightCameraLogicComponent camera) : base(camera)
	{
	}

	// Token: 0x170005B6 RID: 1462
	// (get) Token: 0x0600554C RID: 21836 RVA: 0x000D9176 File Offset: 0x000D7376
	public bool IsBlending
	{
		get
		{
			return this.BlendState > CameraGuideController.EBlendState.Default;
		}
	}

	// Token: 0x170005B7 RID: 1463
	// (get) Token: 0x0600554D RID: 21837 RVA: 0x000D9181 File Offset: 0x000D7381
	// (set) Token: 0x0600554E RID: 21838 RVA: 0x000D9189 File Offset: 0x000D7389
	public bool ForceUsingCameraGuideParameters { get; private set; }

	// Token: 0x0600554F RID: 21839 RVA: 0x000D9192 File Offset: 0x000D7392
	public override string Name()
	{
		return "GuideController";
	}

	// Token: 0x06005550 RID: 21840 RVA: 0x000D919C File Offset: 0x000D739C
	protected override void OnInit()
	{
		base.SetConfigMap(EFightCameraGuide.修正角度Min, "CheckAdjustYawAngleMin");
		base.SetConfigMap(EFightCameraGuide.修正角度Max, "CheckAdjustYawAngleMax");
		base.SetConfigMap(EFightCameraGuide.额外臂长系数_目标水平距离_, "CameraArmLengthRateHorizontal");
		base.SetConfigMap(EFightCameraGuide.额外臂长系数_目标高度差_, "CameraArmLengthRateVertical");
		base.SetConfigMap(EFightCameraGuide.额外臂长限制, "CameraArmLengthAdditionMax");
		base.SetConfigMap(EFightCameraGuide.额外臂水平偏移系数_目标水平距离_, "CameraArmOffsetHorizontalLengthRate");
		base.SetConfigMap(EFightCameraGuide.额外臂水平偏移上限, "CameraArmOffsetHorizontalLengthMax");
		base.SetConfigMap(EFightCameraGuide.额外臂垂直偏移系数_目标高度差_, "CameraArmOffsetVerticalLengthRate");
		base.SetConfigMap(EFightCameraGuide.额外臂垂直偏移上限, "CameraArmOffsetVerticalLengthMax");
		base.SetConfigMap(EFightCameraGuide.InRangeMin, "DefaultPitchInRangeMin");
		base.SetConfigMap(EFightCameraGuide.InRangeMax, "DefaultPitchInRangeMax");
		base.SetConfigMap(EFightCameraGuide.OutRangeMin, "DefaultPitchOutRangeMin");
		base.SetConfigMap(EFightCameraGuide.OutRangeMax, "DefaultPitchOutRangeMax");
		base.SetConfigMap(EFightCameraGuide.NearerRange, "NearerRange");
		base.SetConfigMap(EFightCameraGuide.CameraPitchMin, "CameraPitchMin");
		base.SetConfigMap(EFightCameraGuide.CameraPitchMax, "CameraPitchMax");
		base.SetConfigMap(EFightCameraGuide.CameraPitchOffset, "CameraPitchOffset");
		base.RegisterPairConfigKey(EFightCameraGuide.修正角度Min, EFightCameraGuide.修正角度Max, true);
		base.RegisterPairConfigKey(EFightCameraGuide.InRangeMin, EFightCameraGuide.InRangeMax, true);
		base.RegisterPairConfigKey(EFightCameraGuide.OutRangeMin, EFightCameraGuide.OutRangeMax, true);
		base.RegisterPairConfigKey(EFightCameraGuide.CameraPitchMin, EFightCameraGuide.CameraPitchMax, true);
	}

	// Token: 0x06005551 RID: 21841 RVA: 0x000D92A8 File Offset: 0x000D74A8
	public void ExitCameraGuide()
	{
		if (this.EnableDebugLog)
		{
			Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraLookAt] OnExitGuide ExitCameraGuide", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.OnExitGuide();
	}

	// Token: 0x06005552 RID: 21842 RVA: 0x000D92E0 File Offset: 0x000D74E0
	public void ExitCameraGuideAtOnce()
	{
		if (this.EnableDebugLog)
		{
			Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.JYS, "[CameraLookAt] OnExitGuide ExitCameraGuideAtOnce", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.OnExitGuideAtOnce();
	}

	// Token: 0x06005553 RID: 21843 RVA: 0x000D9317 File Offset: 0x000D7517
	public override void SetConfigs(Dictionary<EFightCameraGuide, float> config, Dictionary<EFightCameraGuide, CurveBase> curveConfig)
	{
		base.SetConfigs(config, curveConfig);
		this.Initialized = true;
	}

	// Token: 0x06005554 RID: 21844 RVA: 0x000D9328 File Offset: 0x000D7528
	[NullableContext(2)]
	public unsafe void ApplyCameraGuide([Nullable(1)] Vector lookAt, float fadeInTime, float stayTime, float fadeOutTime, bool lockCameraInput, Vector endPosition, float? fov, bool ignoreAdjustYaw = false, bool staticCamera = false, float specificArmLength = 0f, bool disableArmOffset = false, Action callback = null, bool forceUsingCameraGuideParameters = false)
	{
		if (this.EnableDebugLog)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraLookAt] ApplyCameraGuide";
			<>y__InlineArray11<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray11<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("lookAt", lookAt);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("fadeInTime", fadeInTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("stayTime", stayTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("fadeOutTime", fadeOutTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("lockCameraInput", lockCameraInput);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("endPosition", endPosition);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("fov", fov);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("ignoreAdjustYaw", ignoreAdjustYaw);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 8) = new ValueTuple<string, object>("staticCamera", staticCamera);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 9) = new ValueTuple<string, object>("disableArmOffset", disableArmOffset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 10) = new ValueTuple<string, object>("forceUsingCameraGuideParameters", forceUsingCameraGuideParameters);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 11));
		}
		if (!this.IsActivate || !this.Initialized)
		{
			if (this.EnableDebugLog)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Camera;
				ELogAuthor author2 = ELogAuthor.LJM;
				string message2 = "[CameraLookAt] ApplyCameraGuide Fail";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("this.IsActivate", this.IsActivate);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("this.Initialized", this.Initialized);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				base.ShowBlockSetInfo("CameraLookAt");
			}
			return;
		}
		this.LookAtLocation.FromUeVector(lookAt);
		CameraUtility.GetVectorInGravity(lookAt, this.LookAtLocationInGravity);
		this.FadeInTime = fadeInTime;
		this.StayTime = stayTime;
		this.FadeOutTime = fadeOutTime;
		this.LockCameraInputTime = lockCameraInput;
		this.StaticCamera = staticCamera;
		this.ForceUsingCameraGuideParameters = forceUsingCameraGuideParameters;
		this.OnEnterGuide(specificArmLength);
		Vector playerLocation = this.Camera.PlayerLocation;
		Rotator armRotation = this.Camera.CurrentCamera.ArmRotation;
		Vector vector = Vector.Create();
		armRotation.Vector(vector);
		Vector vector2 = Vector.Create();
		vector2.DeepCopy(this.LookAtLocation);
		vector2.SubtractionEqual(endPosition ?? playerLocation);
		CameraUtility.GetVectorInGravity(vector2, vector2);
		CameraUtility.GetVectorInGravity(vector, vector);
		Rotator rotator = Rotator.Create();
		vector2.Rotation(rotator);
		this.AdjustDesiredRotatorYaw = rotator.Yaw;
		this.AdjustBeginRotatorYaw = this.Camera.CameraRotationInGravity.Yaw;
		if (!this.StaticCamera && !ignoreAdjustYaw)
		{
			double num = vector2.CosineAngle2D(vector, 9.999999747378752E-05);
			if (vector2.SineAngle2D(vector, 9.999999747378752E-05) < 0.0)
			{
				if (num > Math.Cos((double)(this.CheckAdjustYawAngleMin * 0.017453292f)))
				{
					this.AdjustDesiredRotatorYaw += this.CheckAdjustYawAngleMin;
				}
				else if (num < Math.Cos((double)(this.CheckAdjustYawAngleMax * 0.017453292f)))
				{
					this.AdjustDesiredRotatorYaw += this.CheckAdjustYawAngleMax;
				}
				else
				{
					this.AdjustDesiredRotatorYaw = this.AdjustBeginRotatorYaw;
				}
			}
			else if (num > Math.Cos((double)(this.CheckAdjustYawAngleMin * 0.017453292f)))
			{
				this.AdjustDesiredRotatorYaw -= this.CheckAdjustYawAngleMin;
			}
			else if (num < Math.Cos((double)(this.CheckAdjustYawAngleMax * 0.017453292f)))
			{
				this.AdjustDesiredRotatorYaw -= this.CheckAdjustYawAngleMax;
			}
			else
			{
				this.AdjustDesiredRotatorYaw = this.AdjustBeginRotatorYaw;
			}
		}
		if (this.AdjustBeginRotatorYaw - this.AdjustDesiredRotatorYaw > 180f)
		{
			this.AdjustDesiredRotatorYaw += 360f;
		}
		else if (this.AdjustDesiredRotatorYaw - this.AdjustBeginRotatorYaw > 180f)
		{
			this.AdjustDesiredRotatorYaw -= 360f;
		}
		if (!this.StaticCamera)
		{
			Rotator rotator2 = Rotator.Create();
			vector2.Rotation(rotator2);
			this.AdjustBeginRotatorPitch = this.Camera.CameraRotationInGravity.Pitch;
			if (vector2.Size() > (double)this.NearerRange)
			{
				float currentValue = rotator2.Pitch + this.CameraPitchOffset;
				this.AdjustDesiredRotatorPitch = Singleton<MathUtils>.Instance.Clamp(currentValue, this.CameraPitchMin, this.CameraPitchMax);
			}
			else
			{
				this.AdjustDesiredRotatorPitch = (float)Singleton<MathUtils>.Instance.RangeClamp(vector2.Z, (double)this.DefaultPitchInRangeMin, (double)this.DefaultPitchInRangeMax, (double)this.DefaultPitchOutRangeMin, (double)this.DefaultPitchOutRangeMax);
			}
		}
		else
		{
			this.AdjustBeginRotatorPitch = this.Camera.CameraRotationInGravity.Pitch;
			this.AdjustDesiredRotatorPitch = rotator.Pitch;
		}
		double num2 = vector2.Size2D();
		if (specificArmLength > 0f)
		{
			this.DesiredCameraArmLengthAddition = 0f;
			this.DesiredCameraSpecificArmLength = specificArmLength;
			this.IsCameraSpecificArmLengthEnabled = true;
		}
		else
		{
			this.DesiredCameraArmLengthAddition = (float)(num2 * (double)this.CameraArmLengthRateHorizontal + Math.Abs(vector2.Z) * (double)this.CameraArmLengthRateVertical);
			this.DesiredCameraArmLengthAddition = Singleton<MathUtils>.Instance.Clamp(this.DesiredCameraArmLengthAddition, 0f, this.CameraArmLengthAdditionMax);
			this.DesiredCameraSpecificArmLength = 0f;
			this.IsCameraSpecificArmLengthEnabled = false;
		}
		this.StartPlayerLocation.DeepCopy(playerLocation);
		this.DisableArmOffset = disableArmOffset;
		if (!this.DisableArmOffset)
		{
			if (endPosition == null)
			{
				Vector vector3 = Vector.Create();
				vector3.DeepCopy(this.LookAtLocation);
				vector3.SubtractionEqual(playerLocation);
				CameraUtility.SetZnInGravity(vector3, 0.0, vector3);
				if (num2 * (double)this.CameraArmOffsetHorizontalLengthRate > (double)this.CameraArmOffsetHorizontalLengthMax)
				{
					vector3.Normalize(9.999999747378752E-05);
					this.DesiredCameraArmOffset.DeepCopy(vector3);
					this.DesiredCameraArmOffset.MultiplyEqual((double)this.CameraArmOffsetHorizontalLengthMax);
				}
				else
				{
					this.DesiredCameraArmOffset.DeepCopy(vector3);
					this.DesiredCameraArmOffset.MultiplyEqual((double)this.CameraArmOffsetHorizontalLengthRate);
				}
				double num3 = (this.LookAtLocationInGravity.Z - this.Camera.PlayerLocationInGravity.Z) * (double)this.CameraArmOffsetVerticalLengthRate;
				num3 = Singleton<MathUtils>.Instance.Clamp(num3, (double)(-(double)this.CameraArmOffsetVerticalLengthMax), (double)this.CameraArmOffsetVerticalLengthMax);
				CameraUtility.SetZnInGravity(this.DesiredCameraArmOffset, num3, this.DesiredCameraArmOffset);
			}
			else
			{
				this.DesiredCameraArmOffset.DeepCopy(endPosition);
				this.DesiredCameraArmOffset.SubtractionEqual(playerLocation);
			}
		}
		else
		{
			this.DesiredCameraArmOffset.Reset();
		}
		this.Camera.AddPlayerTag(CameraGuideController.CameraGuideTag);
		this.CurrentFov = this.Camera.CurrentCamera.Fov;
		float fov3;
		if (fov != null && fov.GetValueOrDefault() > 0f)
		{
			float? num4 = fov;
			float fov2 = this.Fov;
			if (!(num4.GetValueOrDefault() == fov2 & num4 != null))
			{
				fov3 = fov.Value;
				goto IL_719;
			}
		}
		fov3 = -1f;
		IL_719:
		this.Fov = fov3;
		if (callback != null)
		{
			Action cameraLookAtCallback = this.CameraLookAtCallback;
			if (cameraLookAtCallback != null)
			{
				cameraLookAtCallback();
			}
			this.CameraLookAtCallback = callback;
			this.CanExit = false;
		}
		else
		{
			this.CanExit = true;
		}
		BP_EventManager_C bpEventManager = GlobalData.BpEventManager;
		if (bpEventManager.IsValid())
		{
			BP_EventManager_C bp_EventManager_C = bpEventManager;
			if (bp_EventManager_C == null)
			{
				return;
			}
			bp_EventManager_C.当触发相机注视时.Broadcast();
		}
	}

	// Token: 0x06005555 RID: 21845 RVA: 0x000D9AA4 File Offset: 0x000D7CA4
	private void UpdateRotation(float alpha)
	{
		double num = Singleton<MathUtils>.Instance.LerpSin((double)this.AdjustBeginRotatorYaw, (double)this.AdjustDesiredRotatorYaw, (double)alpha);
		double num2 = Singleton<MathUtils>.Instance.LerpSin((double)this.AdjustBeginRotatorPitch, (double)this.AdjustDesiredRotatorPitch, (double)alpha);
		CameraUtility.SetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, Rotator.Create((float)num2, (float)num, 0f));
		this.Camera.IsModifiedArmRotationPitch = true;
		this.Camera.IsModifiedArmRotationYaw = true;
		if (-1f != this.Fov)
		{
			double num3 = Singleton<MathUtils>.Instance.LerpSin((double)this.CurrentFov, (double)this.Fov, (double)alpha);
			this.Camera.DesiredCamera.Fov = (float)num3;
		}
	}

	// Token: 0x06005556 RID: 21846 RVA: 0x000D9B60 File Offset: 0x000D7D60
	private void UpdateArmLengthAndOffset(float alpha)
	{
		if (this.IsCameraSpecificArmLengthEnabled)
		{
			this.CurrentCameraSpecificArmLength = (float)Singleton<MathUtils>.Instance.LerpSin((double)this.StartCameraSpecificArmLength, (double)this.DesiredCameraSpecificArmLength, (double)alpha);
		}
		else
		{
			this.CurrentCameraArmLengthAddition = (float)Singleton<MathUtils>.Instance.LerpSin((double)this.StartCameraArmLengthAddition, (double)this.DesiredCameraArmLengthAddition, (double)alpha);
		}
		Vector.LerpSin(this.StartCameraArmOffset, this.DesiredCameraArmOffset, alpha, this.CurrentCameraArmOffset);
		if (this.StaticCamera && !this.DisableArmOffset)
		{
			this.TmpVector.DeepCopy(this.Camera.PlayerLocation);
			this.TmpVector.SubtractionEqual(this.StartPlayerLocation);
			this.CurrentCameraArmOffset.SubtractionEqual(this.TmpVector);
		}
		if (this.IsDebug)
		{
			Vector inB = Vector.Create(this.Camera.PlayerLocation);
			Vector vector = Vector.Create();
			vector.AdditionEqual(inB).AdditionEqual(this.CurrentCameraArmOffset);
			Vector vector2 = Vector.Create();
			vector2.AdditionEqual(inB).AdditionEqual(this.DesiredCameraArmOffset);
			UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, this.Camera.PlayerLocation.ToUeVector(false), vector.ToUeVector(false), new FLinearColor(0f, 1f, 0f, 1f), 0f, 5f);
			UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, vector.ToUeVector(false), vector2.ToUeVector(false), new FLinearColor(1f, 1f, 0f, 1f), 0f, 5f);
			if (this.BlendState != CameraGuideController.EBlendState.Default)
			{
				UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, this.LookAtLocation.ToUeVector(false), vector2.ToUeVector(false), new FLinearColor(1f, 0f, 0f, 1f), 0f, 5f);
			}
		}
	}

	// Token: 0x06005557 RID: 21847 RVA: 0x000D9D34 File Offset: 0x000D7F34
	private void UpdateFadeOut(float alpha)
	{
		if (alpha >= 1f)
		{
			this.CurrentCameraArmLengthAddition = this.StartCameraArmLengthAddition;
			this.CurrentCameraSpecificArmLength = this.StartCameraSpecificArmLength;
			this.StartCameraArmOffset.DeepCopy(this.CurrentCameraArmOffset);
		}
		if (this.IsCameraSpecificArmLengthEnabled)
		{
			this.CurrentCameraSpecificArmLength = (float)Singleton<MathUtils>.Instance.LerpSin((double)this.StartCameraSpecificArmLength, (double)this.Camera.GetRawArmLength(), (double)alpha);
		}
		else
		{
			this.CurrentCameraArmLengthAddition = (float)Singleton<MathUtils>.Instance.LerpSin((double)this.StartCameraArmLengthAddition, 0.0, (double)alpha);
		}
		this.TmpVector.DeepCopy(this.StartCameraArmOffset);
		if (this.StaticCamera && !this.DisableArmOffset)
		{
			this.TmpVector.AdditionEqual(this.StartPlayerLocation);
			this.TmpVector.SubtractionEqual(this.Camera.PlayerLocation);
		}
		Vector.LerpSin(this.TmpVector, Vector.ZeroVectorProxy, alpha, this.CurrentCameraArmOffset);
		if (-1f != this.Fov)
		{
			double num = Singleton<MathUtils>.Instance.LerpSin((double)this.CurrentFov, (double)this.Camera.Fov, (double)alpha);
			this.Camera.DesiredCamera.Fov = (float)num;
		}
	}

	// Token: 0x06005558 RID: 21848 RVA: 0x000D9E68 File Offset: 0x000D8068
	protected override void UpdateInternal(float deltaTime)
	{
		this.ElapsedTime += deltaTime;
		if (!this.LockCameraInputTime && this.HasCameraInput())
		{
			this.OnExitGuide();
		}
		switch (this.BlendState)
		{
		case CameraGuideController.EBlendState.BlendIn:
		{
			float num = (this.FadeInTime > 0f) ? (this.ElapsedTime / this.FadeInTime) : 1f;
			num = Singleton<MathUtils>.Instance.Clamp(num, 0f, 1f);
			this.UpdateRotation(num);
			this.UpdateArmLengthAndOffset(num);
			if (this.ElapsedTime > this.FadeInTime)
			{
				this.OnEnterStaying();
				return;
			}
			break;
		}
		case CameraGuideController.EBlendState.Staying:
			if (this.StaticCamera && !this.DisableArmOffset)
			{
				this.TmpVector.DeepCopy(this.Camera.PlayerLocation);
				this.TmpVector.SubtractionEqual(this.StartPlayerLocation);
				this.CurrentCameraArmOffset.DeepCopy(this.DesiredCameraArmOffset);
				this.CurrentCameraArmOffset.SubtractionEqual(this.TmpVector);
			}
			if (this.StayTime >= 0f && this.ElapsedTime > this.FadeInTime + this.StayTime)
			{
				if (this.CameraLookAtCallback != null)
				{
					Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.JYS, "[CameraLookAt] EBlendState.Staying结束时先执行Callback", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.CameraLookAtCallback();
					this.CameraLookAtCallback = null;
				}
				if (this.CanExit)
				{
					if (this.EnableDebugLog)
					{
						Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraLookAt] OnExitGuide EBlendState.Staying", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					this.OnExitGuide();
					return;
				}
			}
			break;
		case CameraGuideController.EBlendState.BlendOut:
		{
			this.FadeOutElapsedTime += deltaTime;
			float num2 = (this.FadeOutTime > 0f) ? (this.FadeOutElapsedTime / this.FadeOutTime) : 1f;
			num2 = Singleton<MathUtils>.Instance.Clamp(num2, 0f, 1f);
			this.UpdateFadeOut(num2);
			if (this.FadeOutElapsedTime > this.FadeOutTime)
			{
				this.BlendState = CameraGuideController.EBlendState.Default;
				this.IsCameraSpecificArmLengthEnabled = false;
				this.Camera.RemovePlayerTag(CameraGuideController.CameraGuideTag);
			}
			break;
		}
		default:
			return;
		}
	}

	// Token: 0x06005559 RID: 21849 RVA: 0x000DA07C File Offset: 0x000D827C
	protected override void OnDisable()
	{
		if (this.EnableDebugLog)
		{
			Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LJM, "[CameraLookAt] OnExitGuide OnDisable", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.OnExitGuide();
	}

	// Token: 0x0600555A RID: 21850 RVA: 0x000DA0B4 File Offset: 0x000D82B4
	protected override void UpdateDeactivateInternal(float deltaTime)
	{
		if (this.BlendState == CameraGuideController.EBlendState.BlendOut)
		{
			this.FadeOutElapsedTime += deltaTime;
			float num = (this.FadeOutTime > 0f) ? (this.FadeOutElapsedTime / this.FadeOutTime) : 1f;
			num = Singleton<MathUtils>.Instance.Clamp(num, 0f, 1f);
			this.UpdateFadeOut(num);
			if (this.FadeOutElapsedTime > this.FadeOutTime)
			{
				this.BlendState = CameraGuideController.EBlendState.Default;
				this.IsCameraSpecificArmLengthEnabled = false;
				this.Camera.RemovePlayerTag(CameraGuideController.CameraGuideTag);
			}
		}
	}

	// Token: 0x0600555B RID: 21851 RVA: 0x000DA144 File Offset: 0x000D8344
	private unsafe void OnEnterGuide(float specificArmLength)
	{
		if (this.EnableDebugLog)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[CameraLookAt] ApplyCameraGuide OnEnterGuide";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("this.StartCameraArmLengthAddition", this.CurrentCameraArmLengthAddition);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("this.StartCameraArmOffset", this.CurrentCameraArmOffset);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.BlendState = CameraGuideController.EBlendState.BlendIn;
		this.ElapsedTime = 0f;
		this.FadeOutElapsedTime = 0f;
		if (specificArmLength > 0f)
		{
			this.StartCameraSpecificArmLength = this.Camera.GetRawArmLength();
			this.StartCameraArmLengthAddition = 0f;
			this.CurrentCameraArmLengthAddition = 0f;
		}
		else
		{
			this.StartCameraArmLengthAddition = this.CurrentCameraArmLengthAddition;
			this.StartCameraSpecificArmLength = 0f;
		}
		this.StartCameraArmOffset.Set(this.CurrentCameraArmOffset.X, this.CurrentCameraArmOffset.Y, this.CurrentCameraArmOffset.Z);
		if (this.LockCameraInputTime)
		{
			this.Camera.CameraInputController.Lock(this);
		}
		this.Camera.CameraRotationZone.Lock(this);
	}

	// Token: 0x0600555C RID: 21852 RVA: 0x000DA276 File Offset: 0x000D8476
	private void OnEnterStaying()
	{
		this.BlendState = CameraGuideController.EBlendState.Staying;
	}

	// Token: 0x0600555D RID: 21853 RVA: 0x000DA280 File Offset: 0x000D8480
	private unsafe void OnExitGuide()
	{
		CameraGuideController.EBlendState blendState = this.BlendState;
		bool flag = blendState - CameraGuideController.EBlendState.BlendIn <= 1;
		if (flag)
		{
			if (this.EnableDebugLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[CameraLookAt] ApplyCameraGuide OnExitGuide";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("this.FadeInTime", this.FadeInTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("this.ElapsedTime", this.ElapsedTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("this.FadeOutElapsedTime", this.FadeOutElapsedTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("this.BlendState", this.BlendState);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			this.BlendState = CameraGuideController.EBlendState.BlendOut;
			this.FadeOutElapsedTime = 0f;
			this.StartCameraArmLengthAddition = this.CurrentCameraArmLengthAddition;
			this.StartCameraSpecificArmLength = this.CurrentCameraSpecificArmLength;
			this.StartCameraArmOffset.DeepCopy(this.CurrentCameraArmOffset);
			this.StartPlayerLocation.DeepCopy(this.Camera.PlayerLocation);
			this.Camera.CameraInputController.Unlock(this);
			if (-1f != this.Fov)
			{
				this.CurrentFov = this.Camera.CurrentCamera.Fov;
			}
		}
		this.Camera.CameraRotationZone.Unlock(this);
		this.CanExit = true;
		this.ForceUsingCameraGuideParameters = false;
		this.CameraLookAtCallback = null;
		this.Camera.RemovePlayerTag(CameraGuideController.CameraGuideTag);
	}

	// Token: 0x0600555E RID: 21854 RVA: 0x000DA418 File Offset: 0x000D8618
	private unsafe void OnExitGuideAtOnce()
	{
		CameraGuideController.EBlendState blendState = this.BlendState;
		bool flag = blendState - CameraGuideController.EBlendState.BlendIn <= 1;
		if (flag)
		{
			if (this.EnableDebugLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.JYS;
				string message = "[CameraLookAt] 立马退出Guide";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("this.FadeInTime", this.FadeInTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("this.ElapsedTime", this.ElapsedTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("this.FadeOutElapsedTime", this.FadeOutElapsedTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("this.BlendState", this.BlendState);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			this.FadeOutElapsedTime = 0f;
			this.StartCameraArmLengthAddition = this.CurrentCameraArmLengthAddition;
			this.StartCameraSpecificArmLength = this.CurrentCameraSpecificArmLength;
			this.StartCameraArmOffset.DeepCopy(this.CurrentCameraArmOffset);
			this.StartPlayerLocation.DeepCopy(this.Camera.PlayerLocation);
			this.Camera.CameraInputController.Unlock(this);
			if (-1f != this.Fov)
			{
				this.CurrentFov = this.Camera.CurrentCamera.Fov;
			}
		}
		this.Camera.CameraRotationZone.Unlock(this);
		this.UpdateFadeOut(1f);
		this.BlendState = CameraGuideController.EBlendState.Default;
		this.IsCameraSpecificArmLengthEnabled = false;
		this.ForceUsingCameraGuideParameters = false;
		this.CanExit = true;
		this.CameraLookAtCallback = null;
		this.Camera.RemovePlayerTag(CameraGuideController.CameraGuideTag);
	}

	// Token: 0x0600555F RID: 21855 RVA: 0x000DA5C1 File Offset: 0x000D87C1
	public bool IsLockCameraInput()
	{
		return this.LockCameraInputTime;
	}

	// Token: 0x06005560 RID: 21856 RVA: 0x000DA5CC File Offset: 0x000D87CC
	private bool HasCameraInput()
	{
		EntityHandle characterEntityHandle = this.Camera.CharacterEntityHandle;
		if (characterEntityHandle == null || !characterEntityHandle.Valid)
		{
			return false;
		}
		CharacterInputComponent component = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterInputComponent>();
		return component != null && component.Valid && component.HasCameraInput(0.0001f);
	}

	// Token: 0x06005561 RID: 21857 RVA: 0x000DA62B File Offset: 0x000D882B
	public override string GetConfigMapValue(int key)
	{
		return base.GetConfigMapValue((EFightCameraGuide)key);
	}

	// Token: 0x06005562 RID: 21858 RVA: 0x000DA635 File Offset: 0x000D8835
	public void CameraGuideFinishStaying()
	{
		this.CanExit = true;
	}

	// Token: 0x06005563 RID: 21859 RVA: 0x000DA63E File Offset: 0x000D883E
	public bool IsCameraGuideAvailable()
	{
		return this.IsActivate && this.Initialized;
	}

	// Token: 0x06005564 RID: 21860 RVA: 0x000DA650 File Offset: 0x000D8850
	[NullableContext(0)]
	public override bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 3:
				if (key == "Fov")
				{
					value = this.Fov;
					return true;
				}
				break;
			case 7:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'I')
					{
						if (key == "IsDebug")
						{
							value = this.IsDebug;
							return true;
						}
					}
				}
				else if (key == "CanExit")
				{
					value = this.CanExit;
					return true;
				}
				break;
			}
			case 8:
				if (key == "StayTime")
				{
					value = this.StayTime;
					return true;
				}
				break;
			case 9:
				if (key == "TmpVector")
				{
					value = this.TmpVector;
					return true;
				}
				break;
			case 10:
			{
				char c = key[0];
				switch (c)
				{
				case 'B':
					if (key == "BlendState")
					{
						value = this.BlendState;
						return true;
					}
					break;
				case 'C':
					if (key == "CurrentFov")
					{
						value = this.CurrentFov;
						return true;
					}
					break;
				case 'D':
				case 'E':
					break;
				case 'F':
					if (key == "FadeInTime")
					{
						value = this.FadeInTime;
						return true;
					}
					break;
				default:
					if (c == 'I')
					{
						if (key == "IsBlending")
						{
							value = this.IsBlending;
							return true;
						}
					}
					break;
				}
				break;
			}
			case 11:
			{
				char c = key[0];
				switch (c)
				{
				case 'E':
					if (key == "ElapsedTime")
					{
						value = this.ElapsedTime;
						return true;
					}
					break;
				case 'F':
					if (key == "FadeOutTime")
					{
						value = this.FadeOutTime;
						return true;
					}
					break;
				case 'G':
				case 'H':
					break;
				case 'I':
					if (key == "Initialized")
					{
						value = this.Initialized;
						return true;
					}
					break;
				default:
					if (c == 'N')
					{
						if (key == "NearerRange")
						{
							value = this.NearerRange;
							return true;
						}
					}
					break;
				}
				break;
			}
			case 12:
				if (key == "StaticCamera")
				{
					value = this.StaticCamera;
					return true;
				}
				break;
			case 14:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c != 'E')
					{
						if (c == 'L')
						{
							if (key == "LookAtLocation")
							{
								value = this.LookAtLocation;
								return true;
							}
						}
					}
					else if (key == "EnableDebugLog")
					{
						value = this.EnableDebugLog;
						return true;
					}
				}
				else
				{
					if (key == "CameraPitchMin")
					{
						value = this.CameraPitchMin;
						return true;
					}
					if (key == "CameraPitchMax")
					{
						value = this.CameraPitchMax;
						return true;
					}
				}
				break;
			}
			case 16:
				if (key == "DisableArmOffset")
				{
					value = this.DisableArmOffset;
					return true;
				}
				break;
			case 17:
				if (key == "CameraPitchOffset")
				{
					value = this.CameraPitchOffset;
					return true;
				}
				break;
			case 18:
				if (key == "FadeOutElapsedTime")
				{
					value = this.FadeOutElapsedTime;
					return true;
				}
				break;
			case 19:
			{
				char c = key[0];
				if (c != 'L')
				{
					if (c == 'S')
					{
						if (key == "StartPlayerLocation")
						{
							value = this.StartPlayerLocation;
							return true;
						}
					}
				}
				else if (key == "LockCameraInputTime")
				{
					value = this.LockCameraInputTime;
					return true;
				}
				break;
			}
			case 20:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'S')
					{
						if (key == "StartCameraArmOffset")
						{
							value = this.StartCameraArmOffset;
							return true;
						}
					}
				}
				else if (key == "CameraLookAtCallback")
				{
					value = this.CameraLookAtCallback;
					return true;
				}
				break;
			}
			case 21:
				if (key == "AdjustBeginRotatorYaw")
				{
					value = this.AdjustBeginRotatorYaw;
					return true;
				}
				break;
			case 22:
			{
				char c = key[2];
				if (c <= 'f')
				{
					if (c != 'e')
					{
						if (c == 'f')
						{
							if (key == "DefaultPitchInRangeMin")
							{
								value = this.DefaultPitchInRangeMin;
								return true;
							}
							if (key == "DefaultPitchInRangeMax")
							{
								value = this.DefaultPitchInRangeMax;
								return true;
							}
						}
					}
					else
					{
						if (key == "CheckAdjustYawAngleMin")
						{
							value = this.CheckAdjustYawAngleMin;
							return true;
						}
						if (key == "CheckAdjustYawAngleMax")
						{
							value = this.CheckAdjustYawAngleMax;
							return true;
						}
					}
				}
				else if (c != 'r')
				{
					if (c == 's')
					{
						if (key == "DesiredCameraArmOffset")
						{
							value = this.DesiredCameraArmOffset;
							return true;
						}
					}
				}
				else if (key == "CurrentCameraArmOffset")
				{
					value = this.CurrentCameraArmOffset;
					return true;
				}
				break;
			}
			case 23:
			{
				char c = key[22];
				if (c != 'h')
				{
					if (c != 'n')
					{
						switch (c)
						{
						case 'w':
							if (key == "AdjustDesiredRotatorYaw")
							{
								value = this.AdjustDesiredRotatorYaw;
								return true;
							}
							break;
						case 'x':
							if (key == "DefaultPitchOutRangeMax")
							{
								value = this.DefaultPitchOutRangeMax;
								return true;
							}
							break;
						case 'y':
							if (key == "LookAtLocationInGravity")
							{
								value = this.LookAtLocationInGravity;
								return true;
							}
							break;
						}
					}
					else if (key == "DefaultPitchOutRangeMin")
					{
						value = this.DefaultPitchOutRangeMin;
						return true;
					}
				}
				else if (key == "AdjustBeginRotatorPitch")
				{
					value = this.AdjustBeginRotatorPitch;
					return true;
				}
				break;
			}
			case 25:
				if (key == "AdjustDesiredRotatorPitch")
				{
					value = this.AdjustDesiredRotatorPitch;
					return true;
				}
				break;
			case 26:
				if (key == "CameraArmLengthAdditionMax")
				{
					value = this.CameraArmLengthAdditionMax;
					return true;
				}
				break;
			case 27:
				if (key == "CameraArmLengthRateVertical")
				{
					value = this.CameraArmLengthRateVertical;
					return true;
				}
				break;
			case 28:
			{
				char c = key[11];
				if (c != 'A')
				{
					if (c == 'S')
					{
						if (key == "StartCameraSpecificArmLength")
						{
							value = this.StartCameraSpecificArmLength;
							return true;
						}
					}
				}
				else if (key == "StartCameraArmLengthAddition")
				{
					value = this.StartCameraArmLengthAddition;
					return true;
				}
				break;
			}
			case 29:
				if (key == "CameraArmLengthRateHorizontal")
				{
					value = this.CameraArmLengthRateHorizontal;
					return true;
				}
				break;
			case 30:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'D')
					{
						if (key == "DesiredCameraArmLengthAddition")
						{
							value = this.DesiredCameraArmLengthAddition;
							return true;
						}
						if (key == "DesiredCameraSpecificArmLength")
						{
							value = this.DesiredCameraSpecificArmLength;
							return true;
						}
					}
				}
				else
				{
					if (key == "CurrentCameraArmLengthAddition")
					{
						value = this.CurrentCameraArmLengthAddition;
						return true;
					}
					if (key == "CurrentCameraSpecificArmLength")
					{
						value = this.CurrentCameraSpecificArmLength;
						return true;
					}
				}
				break;
			}
			case 31:
				if (key == "ForceUsingCameraGuideParameters")
				{
					value = this.ForceUsingCameraGuideParameters;
					return true;
				}
				break;
			case 32:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'I')
					{
						if (key == "IsCameraSpecificArmLengthEnabled")
						{
							value = this.IsCameraSpecificArmLengthEnabled;
							return true;
						}
					}
				}
				else if (key == "CameraArmOffsetVerticalLengthMax")
				{
					value = this.CameraArmOffsetVerticalLengthMax;
					return true;
				}
				break;
			}
			case 33:
				if (key == "CameraArmOffsetVerticalLengthRate")
				{
					value = this.CameraArmOffsetVerticalLengthRate;
					return true;
				}
				break;
			case 34:
				if (key == "CameraArmOffsetHorizontalLengthMax")
				{
					value = this.CameraArmOffsetHorizontalLengthMax;
					return true;
				}
				break;
			case 35:
				if (key == "CameraArmOffsetHorizontalLengthRate")
				{
					value = this.CameraArmOffsetHorizontalLengthRate;
					return true;
				}
				break;
			}
		}
		return base.TryGetMember(key, out value);
	}

	// Token: 0x06005565 RID: 21861 RVA: 0x000DAFD8 File Offset: 0x000D91D8
	[NullableContext(0)]
	public override void SetMember(string key, object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 3:
				if (key == "Fov")
				{
					float num2;
					if (value is double)
					{
						double num = (double)value;
						num2 = (float)num;
					}
					else if (value is float)
					{
						float num3 = (float)value;
						num2 = num3;
					}
					else if (value is int)
					{
						int num4 = (int)value;
						num2 = (float)num4;
					}
					else if (value is long)
					{
						long num5 = (long)value;
						num2 = (float)num5;
					}
					else
					{
						num2 = (float)value;
					}
					this.Fov = num2;
					return;
				}
				break;
			case 7:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'I')
					{
						if (key == "IsDebug")
						{
							this.IsDebug = (bool)value;
							return;
						}
					}
				}
				else if (key == "CanExit")
				{
					this.CanExit = (bool)value;
					return;
				}
				break;
			}
			case 8:
				if (key == "StayTime")
				{
					float num2;
					if (value is double)
					{
						double num6 = (double)value;
						num2 = (float)num6;
					}
					else if (value is float)
					{
						float num7 = (float)value;
						num2 = num7;
					}
					else if (value is int)
					{
						int num8 = (int)value;
						num2 = (float)num8;
					}
					else if (value is long)
					{
						long num9 = (long)value;
						num2 = (float)num9;
					}
					else
					{
						num2 = (float)value;
					}
					this.StayTime = num2;
					return;
				}
				break;
			case 10:
				switch (key[0])
				{
				case 'B':
					if (key == "BlendState")
					{
						this.BlendState = (CameraGuideController.EBlendState)value;
						return;
					}
					break;
				case 'C':
					if (key == "CurrentFov")
					{
						float num2;
						if (value is double)
						{
							double num10 = (double)value;
							num2 = (float)num10;
						}
						else if (value is float)
						{
							float num11 = (float)value;
							num2 = num11;
						}
						else if (value is int)
						{
							int num12 = (int)value;
							num2 = (float)num12;
						}
						else if (value is long)
						{
							long num13 = (long)value;
							num2 = (float)num13;
						}
						else
						{
							num2 = (float)value;
						}
						this.CurrentFov = num2;
						return;
					}
					break;
				case 'F':
					if (key == "FadeInTime")
					{
						float num2;
						if (value is double)
						{
							double num14 = (double)value;
							num2 = (float)num14;
						}
						else if (value is float)
						{
							float num15 = (float)value;
							num2 = num15;
						}
						else if (value is int)
						{
							int num16 = (int)value;
							num2 = (float)num16;
						}
						else if (value is long)
						{
							long num17 = (long)value;
							num2 = (float)num17;
						}
						else
						{
							num2 = (float)value;
						}
						this.FadeInTime = num2;
						return;
					}
					break;
				}
				break;
			case 11:
			{
				char c = key[0];
				switch (c)
				{
				case 'E':
					if (key == "ElapsedTime")
					{
						float num2;
						if (value is double)
						{
							double num18 = (double)value;
							num2 = (float)num18;
						}
						else if (value is float)
						{
							float num19 = (float)value;
							num2 = num19;
						}
						else if (value is int)
						{
							int num20 = (int)value;
							num2 = (float)num20;
						}
						else if (value is long)
						{
							long num21 = (long)value;
							num2 = (float)num21;
						}
						else
						{
							num2 = (float)value;
						}
						this.ElapsedTime = num2;
						return;
					}
					break;
				case 'F':
					if (key == "FadeOutTime")
					{
						float num2;
						if (value is double)
						{
							double num22 = (double)value;
							num2 = (float)num22;
						}
						else if (value is float)
						{
							float num23 = (float)value;
							num2 = num23;
						}
						else if (value is int)
						{
							int num24 = (int)value;
							num2 = (float)num24;
						}
						else if (value is long)
						{
							long num25 = (long)value;
							num2 = (float)num25;
						}
						else
						{
							num2 = (float)value;
						}
						this.FadeOutTime = num2;
						return;
					}
					break;
				case 'G':
				case 'H':
					break;
				case 'I':
					if (key == "Initialized")
					{
						this.Initialized = (bool)value;
						return;
					}
					break;
				default:
					if (c == 'N')
					{
						if (key == "NearerRange")
						{
							float num2;
							if (value is double)
							{
								double num26 = (double)value;
								num2 = (float)num26;
							}
							else if (value is float)
							{
								float num27 = (float)value;
								num2 = num27;
							}
							else if (value is int)
							{
								int num28 = (int)value;
								num2 = (float)num28;
							}
							else if (value is long)
							{
								long num29 = (long)value;
								num2 = (float)num29;
							}
							else
							{
								num2 = (float)value;
							}
							this.NearerRange = num2;
							return;
						}
					}
					break;
				}
				break;
			}
			case 12:
				if (key == "StaticCamera")
				{
					this.StaticCamera = (bool)value;
					return;
				}
				break;
			case 14:
			{
				char c = key[12];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "CameraPitchMin")
						{
							float num2;
							if (value is double)
							{
								double num30 = (double)value;
								num2 = (float)num30;
							}
							else if (value is float)
							{
								float num31 = (float)value;
								num2 = num31;
							}
							else if (value is int)
							{
								int num32 = (int)value;
								num2 = (float)num32;
							}
							else if (value is long)
							{
								long num33 = (long)value;
								num2 = (float)num33;
							}
							else
							{
								num2 = (float)value;
							}
							this.CameraPitchMin = num2;
							return;
						}
					}
				}
				else if (key == "CameraPitchMax")
				{
					float num2;
					if (value is double)
					{
						double num34 = (double)value;
						num2 = (float)num34;
					}
					else if (value is float)
					{
						float num35 = (float)value;
						num2 = num35;
					}
					else if (value is int)
					{
						int num36 = (int)value;
						num2 = (float)num36;
					}
					else if (value is long)
					{
						long num37 = (long)value;
						num2 = (float)num37;
					}
					else
					{
						num2 = (float)value;
					}
					this.CameraPitchMax = num2;
					return;
				}
				break;
			}
			case 16:
				if (key == "DisableArmOffset")
				{
					this.DisableArmOffset = (bool)value;
					return;
				}
				break;
			case 17:
				if (key == "CameraPitchOffset")
				{
					float num2;
					if (value is double)
					{
						double num38 = (double)value;
						num2 = (float)num38;
					}
					else if (value is float)
					{
						float num39 = (float)value;
						num2 = num39;
					}
					else if (value is int)
					{
						int num40 = (int)value;
						num2 = (float)num40;
					}
					else if (value is long)
					{
						long num41 = (long)value;
						num2 = (float)num41;
					}
					else
					{
						num2 = (float)value;
					}
					this.CameraPitchOffset = num2;
					return;
				}
				break;
			case 18:
				if (key == "FadeOutElapsedTime")
				{
					float num2;
					if (value is double)
					{
						double num42 = (double)value;
						num2 = (float)num42;
					}
					else if (value is float)
					{
						float num43 = (float)value;
						num2 = num43;
					}
					else if (value is int)
					{
						int num44 = (int)value;
						num2 = (float)num44;
					}
					else if (value is long)
					{
						long num45 = (long)value;
						num2 = (float)num45;
					}
					else
					{
						num2 = (float)value;
					}
					this.FadeOutElapsedTime = num2;
					return;
				}
				break;
			case 19:
				if (key == "LockCameraInputTime")
				{
					this.LockCameraInputTime = (bool)value;
					return;
				}
				break;
			case 20:
				if (key == "CameraLookAtCallback")
				{
					this.CameraLookAtCallback = (Action)value;
					return;
				}
				break;
			case 21:
				if (key == "AdjustBeginRotatorYaw")
				{
					float num2;
					if (value is double)
					{
						double num46 = (double)value;
						num2 = (float)num46;
					}
					else if (value is float)
					{
						float num47 = (float)value;
						num2 = num47;
					}
					else if (value is int)
					{
						int num48 = (int)value;
						num2 = (float)num48;
					}
					else if (value is long)
					{
						long num49 = (long)value;
						num2 = (float)num49;
					}
					else
					{
						num2 = (float)value;
					}
					this.AdjustBeginRotatorYaw = num2;
					return;
				}
				break;
			case 22:
			{
				char c = key[1];
				if (c != 'e')
				{
					if (c != 'h')
					{
						if (c == 'u')
						{
							if (key == "CurrentCameraArmOffset")
							{
								this.CurrentCameraArmOffset = (Vector)value;
								return;
							}
						}
					}
					else
					{
						if (key == "CheckAdjustYawAngleMin")
						{
							float num2;
							if (value is double)
							{
								double num50 = (double)value;
								num2 = (float)num50;
							}
							else if (value is float)
							{
								float num51 = (float)value;
								num2 = num51;
							}
							else if (value is int)
							{
								int num52 = (int)value;
								num2 = (float)num52;
							}
							else if (value is long)
							{
								long num53 = (long)value;
								num2 = (float)num53;
							}
							else
							{
								num2 = (float)value;
							}
							this.CheckAdjustYawAngleMin = num2;
							return;
						}
						if (key == "CheckAdjustYawAngleMax")
						{
							float num2;
							if (value is double)
							{
								double num54 = (double)value;
								num2 = (float)num54;
							}
							else if (value is float)
							{
								float num55 = (float)value;
								num2 = num55;
							}
							else if (value is int)
							{
								int num56 = (int)value;
								num2 = (float)num56;
							}
							else if (value is long)
							{
								long num57 = (long)value;
								num2 = (float)num57;
							}
							else
							{
								num2 = (float)value;
							}
							this.CheckAdjustYawAngleMax = num2;
							return;
						}
					}
				}
				else
				{
					if (key == "DefaultPitchInRangeMin")
					{
						float num2;
						if (value is double)
						{
							double num58 = (double)value;
							num2 = (float)num58;
						}
						else if (value is float)
						{
							float num59 = (float)value;
							num2 = num59;
						}
						else if (value is int)
						{
							int num60 = (int)value;
							num2 = (float)num60;
						}
						else if (value is long)
						{
							long num61 = (long)value;
							num2 = (float)num61;
						}
						else
						{
							num2 = (float)value;
						}
						this.DefaultPitchInRangeMin = num2;
						return;
					}
					if (key == "DefaultPitchInRangeMax")
					{
						float num2;
						if (value is double)
						{
							double num62 = (double)value;
							num2 = (float)num62;
						}
						else if (value is float)
						{
							float num63 = (float)value;
							num2 = num63;
						}
						else if (value is int)
						{
							int num64 = (int)value;
							num2 = (float)num64;
						}
						else if (value is long)
						{
							long num65 = (long)value;
							num2 = (float)num65;
						}
						else
						{
							num2 = (float)value;
						}
						this.DefaultPitchInRangeMax = num2;
						return;
					}
				}
				break;
			}
			case 23:
			{
				char c = key[22];
				if (c <= 'n')
				{
					if (c != 'h')
					{
						if (c == 'n')
						{
							if (key == "DefaultPitchOutRangeMin")
							{
								float num2;
								if (value is double)
								{
									double num66 = (double)value;
									num2 = (float)num66;
								}
								else if (value is float)
								{
									float num67 = (float)value;
									num2 = num67;
								}
								else if (value is int)
								{
									int num68 = (int)value;
									num2 = (float)num68;
								}
								else if (value is long)
								{
									long num69 = (long)value;
									num2 = (float)num69;
								}
								else
								{
									num2 = (float)value;
								}
								this.DefaultPitchOutRangeMin = num2;
								return;
							}
						}
					}
					else if (key == "AdjustBeginRotatorPitch")
					{
						float num2;
						if (value is double)
						{
							double num70 = (double)value;
							num2 = (float)num70;
						}
						else if (value is float)
						{
							float num71 = (float)value;
							num2 = num71;
						}
						else if (value is int)
						{
							int num72 = (int)value;
							num2 = (float)num72;
						}
						else if (value is long)
						{
							long num73 = (long)value;
							num2 = (float)num73;
						}
						else
						{
							num2 = (float)value;
						}
						this.AdjustBeginRotatorPitch = num2;
						return;
					}
				}
				else if (c != 'w')
				{
					if (c == 'x')
					{
						if (key == "DefaultPitchOutRangeMax")
						{
							float num2;
							if (value is double)
							{
								double num74 = (double)value;
								num2 = (float)num74;
							}
							else if (value is float)
							{
								float num75 = (float)value;
								num2 = num75;
							}
							else if (value is int)
							{
								int num76 = (int)value;
								num2 = (float)num76;
							}
							else if (value is long)
							{
								long num77 = (long)value;
								num2 = (float)num77;
							}
							else
							{
								num2 = (float)value;
							}
							this.DefaultPitchOutRangeMax = num2;
							return;
						}
					}
				}
				else if (key == "AdjustDesiredRotatorYaw")
				{
					float num2;
					if (value is double)
					{
						double num78 = (double)value;
						num2 = (float)num78;
					}
					else if (value is float)
					{
						float num79 = (float)value;
						num2 = num79;
					}
					else if (value is int)
					{
						int num80 = (int)value;
						num2 = (float)num80;
					}
					else if (value is long)
					{
						long num81 = (long)value;
						num2 = (float)num81;
					}
					else
					{
						num2 = (float)value;
					}
					this.AdjustDesiredRotatorYaw = num2;
					return;
				}
				break;
			}
			case 25:
				if (key == "AdjustDesiredRotatorPitch")
				{
					float num2;
					if (value is double)
					{
						double num82 = (double)value;
						num2 = (float)num82;
					}
					else if (value is float)
					{
						float num83 = (float)value;
						num2 = num83;
					}
					else if (value is int)
					{
						int num84 = (int)value;
						num2 = (float)num84;
					}
					else if (value is long)
					{
						long num85 = (long)value;
						num2 = (float)num85;
					}
					else
					{
						num2 = (float)value;
					}
					this.AdjustDesiredRotatorPitch = num2;
					return;
				}
				break;
			case 26:
				if (key == "CameraArmLengthAdditionMax")
				{
					float num2;
					if (value is double)
					{
						double num86 = (double)value;
						num2 = (float)num86;
					}
					else if (value is float)
					{
						float num87 = (float)value;
						num2 = num87;
					}
					else if (value is int)
					{
						int num88 = (int)value;
						num2 = (float)num88;
					}
					else if (value is long)
					{
						long num89 = (long)value;
						num2 = (float)num89;
					}
					else
					{
						num2 = (float)value;
					}
					this.CameraArmLengthAdditionMax = num2;
					return;
				}
				break;
			case 27:
				if (key == "CameraArmLengthRateVertical")
				{
					float num2;
					if (value is double)
					{
						double num90 = (double)value;
						num2 = (float)num90;
					}
					else if (value is float)
					{
						float num91 = (float)value;
						num2 = num91;
					}
					else if (value is int)
					{
						int num92 = (int)value;
						num2 = (float)num92;
					}
					else if (value is long)
					{
						long num93 = (long)value;
						num2 = (float)num93;
					}
					else
					{
						num2 = (float)value;
					}
					this.CameraArmLengthRateVertical = num2;
					return;
				}
				break;
			case 28:
			{
				char c = key[11];
				if (c != 'A')
				{
					if (c == 'S')
					{
						if (key == "StartCameraSpecificArmLength")
						{
							float num2;
							if (value is double)
							{
								double num94 = (double)value;
								num2 = (float)num94;
							}
							else if (value is float)
							{
								float num95 = (float)value;
								num2 = num95;
							}
							else if (value is int)
							{
								int num96 = (int)value;
								num2 = (float)num96;
							}
							else if (value is long)
							{
								long num97 = (long)value;
								num2 = (float)num97;
							}
							else
							{
								num2 = (float)value;
							}
							this.StartCameraSpecificArmLength = num2;
							return;
						}
					}
				}
				else if (key == "StartCameraArmLengthAddition")
				{
					float num2;
					if (value is double)
					{
						double num98 = (double)value;
						num2 = (float)num98;
					}
					else if (value is float)
					{
						float num99 = (float)value;
						num2 = num99;
					}
					else if (value is int)
					{
						int num100 = (int)value;
						num2 = (float)num100;
					}
					else if (value is long)
					{
						long num101 = (long)value;
						num2 = (float)num101;
					}
					else
					{
						num2 = (float)value;
					}
					this.StartCameraArmLengthAddition = num2;
					return;
				}
				break;
			}
			case 29:
				if (key == "CameraArmLengthRateHorizontal")
				{
					float num2;
					if (value is double)
					{
						double num102 = (double)value;
						num2 = (float)num102;
					}
					else if (value is float)
					{
						float num103 = (float)value;
						num2 = num103;
					}
					else if (value is int)
					{
						int num104 = (int)value;
						num2 = (float)num104;
					}
					else if (value is long)
					{
						long num105 = (long)value;
						num2 = (float)num105;
					}
					else
					{
						num2 = (float)value;
					}
					this.CameraArmLengthRateHorizontal = num2;
					return;
				}
				break;
			case 30:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'D')
					{
						if (key == "DesiredCameraArmLengthAddition")
						{
							float num2;
							if (value is double)
							{
								double num106 = (double)value;
								num2 = (float)num106;
							}
							else if (value is float)
							{
								float num107 = (float)value;
								num2 = num107;
							}
							else if (value is int)
							{
								int num108 = (int)value;
								num2 = (float)num108;
							}
							else if (value is long)
							{
								long num109 = (long)value;
								num2 = (float)num109;
							}
							else
							{
								num2 = (float)value;
							}
							this.DesiredCameraArmLengthAddition = num2;
							return;
						}
						if (key == "DesiredCameraSpecificArmLength")
						{
							float num2;
							if (value is double)
							{
								double num110 = (double)value;
								num2 = (float)num110;
							}
							else if (value is float)
							{
								float num111 = (float)value;
								num2 = num111;
							}
							else if (value is int)
							{
								int num112 = (int)value;
								num2 = (float)num112;
							}
							else if (value is long)
							{
								long num113 = (long)value;
								num2 = (float)num113;
							}
							else
							{
								num2 = (float)value;
							}
							this.DesiredCameraSpecificArmLength = num2;
							return;
						}
					}
				}
				else
				{
					if (key == "CurrentCameraArmLengthAddition")
					{
						float num2;
						if (value is double)
						{
							double num114 = (double)value;
							num2 = (float)num114;
						}
						else if (value is float)
						{
							float num115 = (float)value;
							num2 = num115;
						}
						else if (value is int)
						{
							int num116 = (int)value;
							num2 = (float)num116;
						}
						else if (value is long)
						{
							long num117 = (long)value;
							num2 = (float)num117;
						}
						else
						{
							num2 = (float)value;
						}
						this.CurrentCameraArmLengthAddition = num2;
						return;
					}
					if (key == "CurrentCameraSpecificArmLength")
					{
						float num2;
						if (value is double)
						{
							double num118 = (double)value;
							num2 = (float)num118;
						}
						else if (value is float)
						{
							float num119 = (float)value;
							num2 = num119;
						}
						else if (value is int)
						{
							int num120 = (int)value;
							num2 = (float)num120;
						}
						else if (value is long)
						{
							long num121 = (long)value;
							num2 = (float)num121;
						}
						else
						{
							num2 = (float)value;
						}
						this.CurrentCameraSpecificArmLength = num2;
						return;
					}
				}
				break;
			}
			case 31:
				if (key == "ForceUsingCameraGuideParameters")
				{
					this.ForceUsingCameraGuideParameters = (bool)value;
					return;
				}
				break;
			case 32:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'I')
					{
						if (key == "IsCameraSpecificArmLengthEnabled")
						{
							this.IsCameraSpecificArmLengthEnabled = (bool)value;
							return;
						}
					}
				}
				else if (key == "CameraArmOffsetVerticalLengthMax")
				{
					float num2;
					if (value is double)
					{
						double num122 = (double)value;
						num2 = (float)num122;
					}
					else if (value is float)
					{
						float num123 = (float)value;
						num2 = num123;
					}
					else if (value is int)
					{
						int num124 = (int)value;
						num2 = (float)num124;
					}
					else if (value is long)
					{
						long num125 = (long)value;
						num2 = (float)num125;
					}
					else
					{
						num2 = (float)value;
					}
					this.CameraArmOffsetVerticalLengthMax = num2;
					return;
				}
				break;
			}
			case 33:
				if (key == "CameraArmOffsetVerticalLengthRate")
				{
					float num2;
					if (value is double)
					{
						double num126 = (double)value;
						num2 = (float)num126;
					}
					else if (value is float)
					{
						float num127 = (float)value;
						num2 = num127;
					}
					else if (value is int)
					{
						int num128 = (int)value;
						num2 = (float)num128;
					}
					else if (value is long)
					{
						long num129 = (long)value;
						num2 = (float)num129;
					}
					else
					{
						num2 = (float)value;
					}
					this.CameraArmOffsetVerticalLengthRate = num2;
					return;
				}
				break;
			case 34:
				if (key == "CameraArmOffsetHorizontalLengthMax")
				{
					float num2;
					if (value is double)
					{
						double num130 = (double)value;
						num2 = (float)num130;
					}
					else if (value is float)
					{
						float num131 = (float)value;
						num2 = num131;
					}
					else if (value is int)
					{
						int num132 = (int)value;
						num2 = (float)num132;
					}
					else if (value is long)
					{
						long num133 = (long)value;
						num2 = (float)num133;
					}
					else
					{
						num2 = (float)value;
					}
					this.CameraArmOffsetHorizontalLengthMax = num2;
					return;
				}
				break;
			case 35:
				if (key == "CameraArmOffsetHorizontalLengthRate")
				{
					float num2;
					if (value is double)
					{
						double num134 = (double)value;
						num2 = (float)num134;
					}
					else if (value is float)
					{
						float num135 = (float)value;
						num2 = num135;
					}
					else if (value is int)
					{
						int num136 = (int)value;
						num2 = (float)num136;
					}
					else if (value is long)
					{
						long num137 = (long)value;
						num2 = (float)num137;
					}
					else
					{
						num2 = (float)value;
					}
					this.CameraArmOffsetHorizontalLengthRate = num2;
					return;
				}
				break;
			}
		}
		base.SetMember(key, value);
	}

	// Token: 0x06005566 RID: 21862 RVA: 0x000DC589 File Offset: 0x000DA789
	[NullableContext(0)]
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraGuideController.<MemberIter>d__84 <MemberIter>d__ = new CameraGuideController.<MemberIter>d__84(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x04001A51 RID: 6737
	[StaticVariableRuleIgnore]
	private static readonly int CameraGuideTag = GameplayTagDefine.EGameplayTagId["关卡.Common.镜头.注视镜头"];

	// Token: 0x04001A52 RID: 6738
	internal const int DefaultValue = -1;

	// Token: 0x04001A53 RID: 6739
	public float CheckAdjustYawAngleMin;

	// Token: 0x04001A54 RID: 6740
	public float CheckAdjustYawAngleMax;

	// Token: 0x04001A55 RID: 6741
	public float CameraArmLengthRateHorizontal;

	// Token: 0x04001A56 RID: 6742
	public float CameraArmLengthRateVertical;

	// Token: 0x04001A57 RID: 6743
	public float CameraArmLengthAdditionMax;

	// Token: 0x04001A58 RID: 6744
	public float CameraArmOffsetHorizontalLengthRate;

	// Token: 0x04001A59 RID: 6745
	public float CameraArmOffsetHorizontalLengthMax;

	// Token: 0x04001A5A RID: 6746
	public float CameraArmOffsetVerticalLengthRate;

	// Token: 0x04001A5B RID: 6747
	public float CameraArmOffsetVerticalLengthMax;

	// Token: 0x04001A5C RID: 6748
	public float DefaultPitchInRangeMin;

	// Token: 0x04001A5D RID: 6749
	public float DefaultPitchInRangeMax;

	// Token: 0x04001A5E RID: 6750
	public float DefaultPitchOutRangeMin;

	// Token: 0x04001A5F RID: 6751
	public float DefaultPitchOutRangeMax;

	// Token: 0x04001A60 RID: 6752
	public float CameraPitchMin;

	// Token: 0x04001A61 RID: 6753
	public float CameraPitchMax;

	// Token: 0x04001A62 RID: 6754
	public float CameraPitchOffset;

	// Token: 0x04001A63 RID: 6755
	public float NearerRange;

	// Token: 0x04001A64 RID: 6756
	private float FadeInTime;

	// Token: 0x04001A65 RID: 6757
	private float StayTime;

	// Token: 0x04001A66 RID: 6758
	private float FadeOutTime;

	// Token: 0x04001A67 RID: 6759
	private bool LockCameraInputTime;

	// Token: 0x04001A68 RID: 6760
	public float CurrentCameraArmLengthAddition;

	// Token: 0x04001A69 RID: 6761
	private float StartCameraArmLengthAddition;

	// Token: 0x04001A6A RID: 6762
	private float DesiredCameraArmLengthAddition;

	// Token: 0x04001A6B RID: 6763
	public float CurrentCameraSpecificArmLength;

	// Token: 0x04001A6C RID: 6764
	public bool IsCameraSpecificArmLengthEnabled;

	// Token: 0x04001A6D RID: 6765
	public float StartCameraSpecificArmLength;

	// Token: 0x04001A6E RID: 6766
	public float DesiredCameraSpecificArmLength;

	// Token: 0x04001A6F RID: 6767
	public Vector CurrentCameraArmOffset = Vector.Create();

	// Token: 0x04001A70 RID: 6768
	private readonly Vector StartCameraArmOffset = Vector.Create();

	// Token: 0x04001A71 RID: 6769
	private readonly Vector DesiredCameraArmOffset = Vector.Create();

	// Token: 0x04001A72 RID: 6770
	private readonly Vector StartPlayerLocation = Vector.Create();

	// Token: 0x04001A73 RID: 6771
	private CameraGuideController.EBlendState BlendState;

	// Token: 0x04001A74 RID: 6772
	private float AdjustBeginRotatorPitch;

	// Token: 0x04001A75 RID: 6773
	private float AdjustDesiredRotatorPitch;

	// Token: 0x04001A76 RID: 6774
	private float AdjustBeginRotatorYaw;

	// Token: 0x04001A77 RID: 6775
	private float AdjustDesiredRotatorYaw;

	// Token: 0x04001A78 RID: 6776
	private float ElapsedTime;

	// Token: 0x04001A79 RID: 6777
	private float FadeOutElapsedTime;

	// Token: 0x04001A7A RID: 6778
	private bool StaticCamera;

	// Token: 0x04001A7B RID: 6779
	private bool DisableArmOffset;

	// Token: 0x04001A7C RID: 6780
	private readonly Vector LookAtLocation = Vector.Create();

	// Token: 0x04001A7D RID: 6781
	private readonly Vector LookAtLocationInGravity = Vector.Create();

	// Token: 0x04001A7E RID: 6782
	private float Fov = -1f;

	// Token: 0x04001A7F RID: 6783
	private float CurrentFov;

	// Token: 0x04001A80 RID: 6784
	private bool Initialized;

	// Token: 0x04001A81 RID: 6785
	private readonly Vector TmpVector = Vector.Create();

	// Token: 0x04001A82 RID: 6786
	private readonly bool EnableDebugLog = true;

	// Token: 0x04001A83 RID: 6787
	[Nullable(2)]
	private Action CameraLookAtCallback;

	// Token: 0x04001A84 RID: 6788
	private bool CanExit = true;

	// Token: 0x04001A86 RID: 6790
	private bool IsDebug;

	// Token: 0x02007282 RID: 29314
	[NullableContext(0)]
	internal enum EBlendState
	{
		// Token: 0x04027B9C RID: 162716
		Default,
		// Token: 0x04027B9D RID: 162717
		BlendIn,
		// Token: 0x04027B9E RID: 162718
		Staying,
		// Token: 0x04027B9F RID: 162719
		BlendOut
	}
}
