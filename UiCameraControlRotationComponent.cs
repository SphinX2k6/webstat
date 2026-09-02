using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.UiComponent;
using UnrealEngine;

// Token: 0x02002C45 RID: 11333
[NullableContext(1)]
[Nullable(0)]
public class UiCameraControlRotationComponent : UiCameraComponent
{
	// Token: 0x06016B3D RID: 92989 RVA: 0x0064D7D2 File Offset: 0x0064B9D2
	protected override void OnActivate()
	{
		base.EnableTick();
	}

	// Token: 0x06016B3E RID: 92990 RVA: 0x0064D7DA File Offset: 0x0064B9DA
	protected override void OnDeactivate()
	{
		base.RemoveTick();
	}

	// Token: 0x06016B3F RID: 92991 RVA: 0x0064D7E4 File Offset: 0x0064B9E4
	public void InitDataByConfig(SUiRoleCameraSetting config)
	{
		this.InitData(config.倍化手柄输入倍率, config.移动端旋转输入倍率, config.移动端缩放输入倍率, config.镜头Yaw灵敏度系数, config.镜头Pitch灵敏度系数, config.镜头缩放灵敏度系数, config.最小臂长, config.最大臂长, config.Pitch限制Min, config.Pitch限制Max, config.Yaw限制Min, config.Yaw限制Max, config.相机相对角色的最低高度, config.最大臂长时的光圈, config.最小臂长时的光圈);
	}

	// Token: 0x06016B40 RID: 92992 RVA: 0x0064D854 File Offset: 0x0064BA54
	public void InitData(float gamepadInputRate, float mobileRotateInputRate, float mobileZoomInputRate, float sensitivityYaw, float sensitivityPitch, float sensitivityZoom, float minArmLength, float maxArmLength, float pitchLimitMin, float pitchLimitMax, float yawLimitMin, float yawLimitMax, float cameraRelativeHeightLimitMin, float cameraMaxAperture, float cameraMinAperture)
	{
		this.GamepadInputRate = gamepadInputRate;
		this.MobileRotateInputRate = mobileRotateInputRate;
		this.MobileZoomInputRate = mobileZoomInputRate;
		this.SensitivityYaw = sensitivityYaw;
		this.SensitivityPitch = sensitivityPitch;
		this.SensitivityZoom = sensitivityZoom;
		this.CameraRelativeHeightLimitMin = cameraRelativeHeightLimitMin;
		UiCameraControlRotationComponent.VirtualCamera desiredCamera = this.DesiredCamera;
		desiredCamera.MinArmLength = minArmLength;
		desiredCamera.MaxArmLength = maxArmLength;
		desiredCamera.PitchLimitMin = pitchLimitMin;
		desiredCamera.PitchLimitMax = pitchLimitMax;
		desiredCamera.YawLimitMin = yawLimitMin;
		desiredCamera.YawLimitMax = yawLimitMax;
		this.CameraMaxAperture = cameraMaxAperture;
		this.CameraMinAperture = cameraMinAperture;
	}

	// Token: 0x06016B41 RID: 92993 RVA: 0x0064D8DC File Offset: 0x0064BADC
	public void UpdateData(FVectorDouble sourceLocation, float cameraFloatMaxOffset, float cameraFloatMinOffset, float cameraFloatMaxArmLength, float cameraFloatMinArmLength)
	{
		UiCameraStructure cameraStructure = base.GetCameraStructure();
		if (cameraStructure == null)
		{
			return;
		}
		FVectorDouble actorLocation = cameraStructure.GetActorLocation();
		FRotator springRelativeRotation = cameraStructure.GetSpringRelativeRotation();
		this.DesiredCamera.ArmRotation.DeepCopy(springRelativeRotation);
		this.DesiredCamera.DefaultLookCenterLocation.DeepCopy(actorLocation);
		this.TempSourceLocation.DeepCopy(sourceLocation);
		this.TempCameraLocation.DeepCopy(actorLocation);
		double num = Vector.Dist2D(this.TempSourceLocation, this.TempCameraLocation);
		float num2 = MathCommon.DegreeToRadian(MathCommon.WrapAngle(springRelativeRotation.Pitch));
		double z = num * Math.Tan((double)num2) + this.TempCameraLocation.Z;
		this.TempLookCenterLocation.X = this.TempSourceLocation.X;
		this.TempLookCenterLocation.Y = this.TempSourceLocation.Y;
		this.TempLookCenterLocation.Z = z;
		this.DesiredCamera.LookCenterLocation.DeepCopy(this.TempLookCenterLocation);
		this.DesiredCamera.ArmLength = cameraStructure.GetSpringArmLength();
		this.DefaultCameraArmLength = cameraStructure.GetSpringArmLength();
		this.DesiredCamera.ArmHeight = (float)(this.TempLookCenterLocation.Z - this.TempSourceLocation.Z - (double)this.CameraRelativeHeightLimitMin);
		this.CameraFloatMaxOffset = cameraFloatMaxOffset;
		this.CameraFloatMinOffset = cameraFloatMinOffset;
		this.CameraFloatMaxArmLength = cameraFloatMaxArmLength;
		this.CameraFloatMinArmLength = cameraFloatMinArmLength;
		this.DesiredCamera.HeightOffset = 0f;
		this.DefaultCamera.DeepCopy(this.DesiredCamera);
		this.CurrentCamera.DeepCopy(this.DesiredCamera);
	}

	// Token: 0x06016B42 RID: 92994 RVA: 0x0064DA5F File Offset: 0x0064BC5F
	protected override void OnTick(float delta)
	{
		if (!this.IsFading)
		{
			this.UpdateInput(delta);
		}
		this.UpdateYaw();
		this.UpdatePitch();
		this.UpdateArmLength();
		this.UpdateFading(delta);
		this.UpdateCameraTransform();
		this.UpdateFloorReflectionSetting();
	}

	// Token: 0x06016B43 RID: 92995 RVA: 0x0064DA95 File Offset: 0x0064BC95
	private void ResetInput()
	{
		this.YawInput = 0f;
		this.PitchInput = 0f;
		this.ZoomInput = 0f;
	}

	// Token: 0x06016B44 RID: 92996 RVA: 0x0064DAB8 File Offset: 0x0064BCB8
	private void UpdateInput(float deltaTime)
	{
		float num = this.YawInput;
		float num2 = this.PitchInput;
		float num3 = this.ZoomInput;
		this.ResetInput();
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			num *= this.GamepadInputRate;
			num2 *= this.GamepadInputRate;
		}
		else if (Singleton<Info>.Instance.IsInTouch())
		{
			num *= this.MobileRotateInputRate;
			num2 *= this.MobileRotateInputRate;
			num3 *= this.MobileZoomInputRate;
		}
		num = num * this.SensitivityYaw * deltaTime;
		num2 = num2 * this.SensitivityPitch * deltaTime;
		num3 = num3 * this.SensitivityZoom * deltaTime;
		if (!Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null))
		{
			this.DesiredCamera.ArmRotation.Yaw += num;
		}
		if (!Singleton<MathUtils>.Instance.IsNearlyZero((double)num2, null))
		{
			this.DesiredCamera.ArmRotation.Pitch += num2;
		}
		if (!Singleton<MathUtils>.Instance.IsNearlyZero((double)num3, null))
		{
			this.DesiredCamera.ArmLength += num3;
		}
	}

	// Token: 0x06016B45 RID: 92997 RVA: 0x0064DBD0 File Offset: 0x0064BDD0
	private void UpdateYaw()
	{
		float num = this.DesiredCamera.ArmRotation.Yaw;
		num %= 360f;
		num = ((num > 180f) ? (num - 360f) : num);
		if (Math.Abs(this.DesiredCamera.YawLimitMin) + Math.Abs(this.DesiredCamera.YawLimitMax) < 360f)
		{
			num = Singleton<MathUtils>.Instance.Clamp(num, this.DesiredCamera.YawLimitMin, this.DesiredCamera.YawLimitMax);
		}
		this.DesiredCamera.ArmRotation.Yaw = num;
	}

	// Token: 0x06016B46 RID: 92998 RVA: 0x0064DC64 File Offset: 0x0064BE64
	private void UpdatePitch()
	{
		float num = this.DesiredCamera.ArmRotation.Pitch;
		num %= 360f;
		num = ((num > 180f) ? (num - 360f) : num);
		num = Singleton<MathUtils>.Instance.Clamp(num, this.DesiredCamera.PitchLimitMin, this.DesiredCamera.PitchLimitMax);
		this.DesiredCamera.ArmRotation.Pitch = num;
	}

	// Token: 0x06016B47 RID: 92999 RVA: 0x0064DCD0 File Offset: 0x0064BED0
	private void UpdateArmLength()
	{
		this.DesiredCamera.ArmLength = Singleton<MathUtils>.Instance.Clamp(this.DesiredCamera.ArmLength, this.DesiredCamera.MinArmLength, this.DesiredCamera.MaxArmLength);
	}

	// Token: 0x06016B48 RID: 93000 RVA: 0x0064DD08 File Offset: 0x0064BF08
	public void StartFade(float duration, UCurveFloat fadeCurve, bool fadeArmLength, bool fadeArmRotationPitch, bool fadeArmRotationYaw, bool fadeArmRotationRoll)
	{
		this.LastCamera.DeepCopy(this.CurrentCamera);
		this.FadeArmLength = fadeArmLength;
		this.FadeArmRotationPitch = fadeArmRotationPitch;
		this.FadeArmRotationYaw = fadeArmRotationYaw;
		this.FadeArmRotationRoll = fadeArmRotationRoll;
		this.IsFading = true;
		this.FadeDuration = duration;
		this.FadeElapse = 0f;
		this.FadeCurve = fadeCurve;
	}

	// Token: 0x06016B49 RID: 93001 RVA: 0x0064DD68 File Offset: 0x0064BF68
	private void UpdateFading(float deltaTime)
	{
		if (!this.IsFading || this.FadeCurve == null)
		{
			this.CurrentCamera.DeepCopy(this.DesiredCamera);
			return;
		}
		this.FadeElapse += deltaTime;
		if (this.FadeElapse >= this.FadeDuration)
		{
			this.IsFading = false;
			this.FadeCurve = null;
			this.CurrentCamera.DeepCopy(this.DesiredCamera);
			return;
		}
		float floatValue = this.FadeCurve.GetFloatValue(this.FadeElapse / this.FadeDuration);
		if (this.FadeArmLength)
		{
			this.CurrentCamera.ArmLength = Singleton<MathUtils>.Instance.Lerp(this.LastCamera.ArmLength, this.DesiredCamera.ArmLength, floatValue);
		}
		if (this.FadeArmRotationPitch)
		{
			this.CurrentCamera.ArmRotation.Pitch = Singleton<MathUtils>.Instance.Lerp(this.LastCamera.ArmRotation.Pitch, this.DesiredCamera.ArmRotation.Pitch, floatValue);
		}
		if (this.FadeArmRotationYaw)
		{
			this.CurrentCamera.ArmRotation.Yaw = Singleton<MathUtils>.Instance.Lerp(this.LastCamera.ArmRotation.Yaw, this.DesiredCamera.ArmRotation.Yaw, floatValue);
		}
		if (this.FadeArmRotationRoll)
		{
			this.CurrentCamera.ArmRotation.Roll = Singleton<MathUtils>.Instance.Lerp(this.LastCamera.ArmRotation.Roll, this.DesiredCamera.ArmRotation.Roll, floatValue);
		}
	}

	// Token: 0x06016B4A RID: 93002 RVA: 0x0064DEEC File Offset: 0x0064C0EC
	private void UpdateCameraTransform()
	{
		Rotator armRotation = this.CurrentCamera.ArmRotation;
		this.TempLookCenterLocation.DeepCopy(this.CurrentCamera.LookCenterLocation);
		Vector tempLookCenterLocation = this.TempLookCenterLocation;
		float num = this.CurrentCamera.ArmLength;
		float pitch = this.CurrentCamera.ArmRotation.Pitch;
		if (pitch > 0f && !Singleton<MathUtils>.Instance.IsNearlyZero((double)pitch, null))
		{
			float num2 = MathCommon.DegreeToRadian(MathCommon.WrapAngle(pitch));
			float num3 = (float)Math.Abs((double)this.CurrentCamera.ArmHeight / Math.Sin((double)num2));
			num3 = Singleton<MathUtils>.Instance.Clamp(num3, this.CurrentCamera.MinArmLength, this.CurrentCamera.MaxArmLength);
			num = Singleton<MathUtils>.Instance.Clamp(num, this.CurrentCamera.MinArmLength, num3);
		}
		armRotation.Quaternion(null).RotateVector(Vector.ForwardVectorProxy, this.TempCameraForward);
		this.TempCameraForward.Multiply((double)(-(double)num), this.TempCameraVector);
		tempLookCenterLocation.Addition(this.TempCameraVector, this.TempCameraLocation);
		this.UpdateHeightOffset(num);
		this.UpdateAperture(num);
		Vector defaultLookCenterLocation = this.CurrentCamera.DefaultLookCenterLocation;
		this.TempCameraLocation.Z = defaultLookCenterLocation.Z + (double)this.CurrentCamera.HeightOffset;
		double num4 = tempLookCenterLocation.Z - (double)this.CurrentCamera.ArmHeight;
		if (this.TempCameraLocation.Z < num4)
		{
			this.TempCameraLocation.Z = num4;
		}
		this.TempCameraLocation.X = defaultLookCenterLocation.X;
		this.TempCameraLocation.Y = defaultLookCenterLocation.Y;
		UiCameraStructure cameraStructure = base.GetCameraStructure();
		if (cameraStructure == null)
		{
			return;
		}
		cameraStructure.SetSprintArmRelativeRotation(armRotation.ToUeRotator());
		cameraStructure.SetSpringArmLength(num);
		cameraStructure.SetActorLocation(this.TempCameraLocation.ToUeVector(false));
	}

	// Token: 0x06016B4B RID: 93003 RVA: 0x0064E0C4 File Offset: 0x0064C2C4
	public void UpdateHeightOffset(float armLength)
	{
		if (armLength < this.DefaultCameraArmLength)
		{
			this.CurrentCamera.HeightOffset = Singleton<MathUtils>.Instance.RangeClamp(armLength, this.CameraFloatMinArmLength, this.DefaultCameraArmLength, this.CameraFloatMinOffset, 0f);
			return;
		}
		this.CurrentCamera.HeightOffset = Singleton<MathUtils>.Instance.RangeClamp(armLength, this.DefaultCameraArmLength, this.CameraFloatMaxArmLength, 0f, this.CameraFloatMaxOffset);
	}

	// Token: 0x06016B4C RID: 93004 RVA: 0x0064E138 File Offset: 0x0064C338
	public void UpdateAperture(float armLength)
	{
		this.CurrentCamera.Aperture = Singleton<MathUtils>.Instance.RangeClamp(armLength, this.CameraFloatMinArmLength, this.CameraFloatMaxArmLength, this.CameraMinAperture, this.CameraMaxAperture);
		UiCameraPostEffectComponent uiCameraComponent = this.OwnerUiCamera.GetUiCameraComponent<UiCameraPostEffectComponent>();
		if (uiCameraComponent == null)
		{
			return;
		}
		uiCameraComponent.SetCameraAperture(this.CurrentCamera.Aperture);
	}

	// Token: 0x06016B4D RID: 93005 RVA: 0x0064E194 File Offset: 0x0064C394
	public void UpdateFloorReflectionSetting()
	{
		if (!this.NeedCheckReflection)
		{
			return;
		}
		this.TempSourceLocation.Addition(this.SourceLocationOffset, this.ScreenReflectionPosition);
		FVectorDouble worldLocation = this.ScreenReflectionPosition.ToUeVector(false);
		bool flag = HudUnitUtils.PositionUtil.ProjectWorldToScreen(worldLocation, this.SourceScreenPos);
		if (flag)
		{
			Vector2D viewportSizeByPool = WorldMapUtil.GetViewportSizeByPool();
			flag = (Math.Abs(this.SourceScreenPos.X) <= viewportSizeByPool.X / 2.0 && Math.Abs(this.SourceScreenPos.Y) <= viewportSizeByPool.Y / 2.0);
		}
		UiSceneUtils.SetSceneFloorReflection(flag, false);
	}

	// Token: 0x06016B4E RID: 93006 RVA: 0x0064E23C File Offset: 0x0064C43C
	public void SetNeedFloorReflection(bool state)
	{
		this.NeedCheckReflection = state;
	}

	// Token: 0x06016B4F RID: 93007 RVA: 0x0064E245 File Offset: 0x0064C445
	public void AddZoomInput(float zoomInput)
	{
		this.ZoomInput = zoomInput;
	}

	// Token: 0x06016B50 RID: 93008 RVA: 0x0064E24E File Offset: 0x0064C44E
	public void AddYawInput(float yawInput)
	{
		this.YawInput = yawInput;
	}

	// Token: 0x06016B51 RID: 93009 RVA: 0x0064E257 File Offset: 0x0064C457
	public void AddPitchInput(float pitchInput)
	{
		this.PitchInput = pitchInput;
	}

	// Token: 0x06016B52 RID: 93010 RVA: 0x0064E260 File Offset: 0x0064C460
	public void DoMoveForward(float moveDistance, float duration, UCurveFloat curve)
	{
		this.DesiredCamera.ArmLength = this.DesiredCamera.ArmLength - moveDistance;
		this.StartFade(duration, curve, true, false, false, false);
	}

	// Token: 0x06016B53 RID: 93011 RVA: 0x0064E286 File Offset: 0x0064C486
	public void SetArmLength(float armLength)
	{
		this.DesiredCamera.ArmLength = armLength;
	}

	// Token: 0x06016B54 RID: 93012 RVA: 0x0064E294 File Offset: 0x0064C494
	public void SetArmRotation(float pitch, float yaw, float roll)
	{
		this.DesiredCamera.ArmRotation.Pitch = pitch;
		this.DesiredCamera.ArmRotation.Yaw = yaw;
		this.DesiredCamera.ArmRotation.Roll = roll;
	}

	// Token: 0x06016B55 RID: 93013 RVA: 0x0064E2CC File Offset: 0x0064C4CC
	public void SetArmRotationByDefaultCamera()
	{
		Rotator armRotation = this.DefaultCamera.ArmRotation;
		this.SetArmRotation(armRotation.Pitch, armRotation.Yaw, armRotation.Roll);
	}

	// Token: 0x0400AF03 RID: 44803
	public readonly UiCameraControlRotationComponent.VirtualCamera DefaultCamera = new UiCameraControlRotationComponent.VirtualCamera();

	// Token: 0x0400AF04 RID: 44804
	public readonly UiCameraControlRotationComponent.VirtualCamera LastCamera = new UiCameraControlRotationComponent.VirtualCamera();

	// Token: 0x0400AF05 RID: 44805
	public readonly UiCameraControlRotationComponent.VirtualCamera CurrentCamera = new UiCameraControlRotationComponent.VirtualCamera();

	// Token: 0x0400AF06 RID: 44806
	public readonly UiCameraControlRotationComponent.VirtualCamera DesiredCamera = new UiCameraControlRotationComponent.VirtualCamera();

	// Token: 0x0400AF07 RID: 44807
	public readonly Vector TempLookCenterLocation = Vector.Create();

	// Token: 0x0400AF08 RID: 44808
	public readonly Vector TempCameraForward = Vector.Create();

	// Token: 0x0400AF09 RID: 44809
	public readonly Vector TempCameraVector = Vector.Create();

	// Token: 0x0400AF0A RID: 44810
	public readonly Vector TempCameraLocation = Vector.Create();

	// Token: 0x0400AF0B RID: 44811
	public Vector TempSourceLocation = Vector.Create();

	// Token: 0x0400AF0C RID: 44812
	private readonly Vector2D SourceScreenPos = new Vector2D();

	// Token: 0x0400AF0D RID: 44813
	private readonly Vector SourceLocationOffset = new Vector(0.0, 0.0, 30.0);

	// Token: 0x0400AF0E RID: 44814
	private readonly Vector ScreenReflectionPosition = Vector.Create();

	// Token: 0x0400AF0F RID: 44815
	private bool NeedCheckReflection;

	// Token: 0x0400AF10 RID: 44816
	private float GamepadInputRate;

	// Token: 0x0400AF11 RID: 44817
	private float MobileRotateInputRate;

	// Token: 0x0400AF12 RID: 44818
	private float MobileZoomInputRate;

	// Token: 0x0400AF13 RID: 44819
	private float SensitivityYaw;

	// Token: 0x0400AF14 RID: 44820
	private float SensitivityPitch;

	// Token: 0x0400AF15 RID: 44821
	private float SensitivityZoom;

	// Token: 0x0400AF16 RID: 44822
	private float CameraRelativeHeightLimitMin;

	// Token: 0x0400AF17 RID: 44823
	private float CameraFloatMaxOffset;

	// Token: 0x0400AF18 RID: 44824
	private float CameraFloatMinOffset;

	// Token: 0x0400AF19 RID: 44825
	private float CameraFloatMinArmLength;

	// Token: 0x0400AF1A RID: 44826
	private float CameraFloatMaxArmLength;

	// Token: 0x0400AF1B RID: 44827
	private float CameraMaxAperture;

	// Token: 0x0400AF1C RID: 44828
	private float CameraMinAperture;

	// Token: 0x0400AF1D RID: 44829
	private float YawInput;

	// Token: 0x0400AF1E RID: 44830
	private float PitchInput;

	// Token: 0x0400AF1F RID: 44831
	private float ZoomInput;

	// Token: 0x0400AF20 RID: 44832
	private float DefaultCameraArmLength;

	// Token: 0x0400AF21 RID: 44833
	private bool IsFading;

	// Token: 0x0400AF22 RID: 44834
	private float FadeDuration;

	// Token: 0x0400AF23 RID: 44835
	private float FadeElapse;

	// Token: 0x0400AF24 RID: 44836
	private UCurveFloat FadeCurve;

	// Token: 0x0400AF25 RID: 44837
	private bool FadeArmLength;

	// Token: 0x0400AF26 RID: 44838
	private bool FadeArmRotationPitch;

	// Token: 0x0400AF27 RID: 44839
	private bool FadeArmRotationYaw;

	// Token: 0x0400AF28 RID: 44840
	private bool FadeArmRotationRoll;

	// Token: 0x02008F66 RID: 36710
	[Nullable(0)]
	public class VirtualCamera
	{
		// Token: 0x06049D26 RID: 302374 RVA: 0x01400B98 File Offset: 0x013FED98
		public void DeepCopy(UiCameraControlRotationComponent.VirtualCamera camera)
		{
			this.ArmLength = camera.ArmLength;
			this.MinArmLength = camera.MinArmLength;
			this.MaxArmLength = camera.MaxArmLength;
			this.YawLimitMin = camera.YawLimitMin;
			this.YawLimitMax = camera.YawLimitMax;
			this.PitchLimitMin = camera.PitchLimitMin;
			this.PitchLimitMax = camera.PitchLimitMax;
			this.HeightOffset = camera.HeightOffset;
			this.ArmHeight = camera.ArmHeight;
			this.Aperture = camera.Aperture;
			this.LookCenterLocation.DeepCopy(camera.LookCenterLocation);
			this.DefaultLookCenterLocation.DeepCopy(camera.DefaultLookCenterLocation);
			this.ArmRotation.DeepCopy(camera.ArmRotation);
		}

		// Token: 0x04030268 RID: 197224
		public float ArmLength;

		// Token: 0x04030269 RID: 197225
		public float MinArmLength;

		// Token: 0x0403026A RID: 197226
		public float MaxArmLength;

		// Token: 0x0403026B RID: 197227
		public float YawLimitMin;

		// Token: 0x0403026C RID: 197228
		public float YawLimitMax;

		// Token: 0x0403026D RID: 197229
		public float PitchLimitMin;

		// Token: 0x0403026E RID: 197230
		public float PitchLimitMax;

		// Token: 0x0403026F RID: 197231
		public float HeightOffset;

		// Token: 0x04030270 RID: 197232
		public float ArmHeight;

		// Token: 0x04030271 RID: 197233
		public float Aperture;

		// Token: 0x04030272 RID: 197234
		public Vector LookCenterLocation = Vector.Create();

		// Token: 0x04030273 RID: 197235
		public Vector DefaultLookCenterLocation = Vector.Create();

		// Token: 0x04030274 RID: 197236
		public Rotator ArmRotation = Rotator.Create();
	}
}
