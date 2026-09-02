using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.Camera.SceneCameraRotator
{
	// Token: 0x020070C0 RID: 28864
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneCameraInputRotator : SceneCameraRotatorBase
	{
		// Token: 0x06045FBE RID: 286654 RVA: 0x0125B420 File Offset: 0x01259620
		public SceneCameraInputRotator(SceneFixInputData fixInputData)
		{
			this.CapturedFixInputData.DeepCopy(fixInputData);
			CameraModel instance = ModelBase<CameraModel>.Instance;
			this.MobileDensityYawScale = instance.MobileDensityYawScale;
			this.MobileDensityPitchScale = instance.MobileDensityPitchScale;
		}

		// Token: 0x06045FBF RID: 286655 RVA: 0x0125B468 File Offset: 0x01259668
		public override bool IsValid()
		{
			return true;
		}

		// Token: 0x06045FC0 RID: 286656 RVA: 0x0125B46C File Offset: 0x0125966C
		public override void ComputeExpectRotation()
		{
			this.ComputeCameraInput(this.FightCameraLogicComp);
			SceneSubCamera subCamera = this.SubCamera;
			BP_CineCamera_C bp_CineCamera_C = (subCamera != null) ? subCamera.Camera : null;
			if (bp_CineCamera_C == null || !bp_CineCamera_C.IsValid())
			{
				return;
			}
			Rotator workingRotator = this.WorkingRotator;
			FRotator frotator = bp_CineCamera_C.K2_GetActorRotation();
			workingRotator.DeepCopy(frotator);
			if (this.IsNormalGravity)
			{
				if (this.CurrentFrameHasCameraRotationInput)
				{
					this.WorkingRotator.Pitch = Singleton<MathUtils>.Instance.WrapAngle(this.WorkingRotator.Pitch + this.PitchRotateSpeed);
					this.WorkingRotator.Yaw = Singleton<MathUtils>.Instance.WrapAngle(this.WorkingRotator.Yaw + this.YawRotateSpeed);
				}
				return;
			}
			this.WorkingRotator.Quaternion(this.WorkingQuat);
			if (!this.CurrentFrameHasCameraRotationInput)
			{
				return;
			}
			Quat.ConstructorByAxisAngle(this.GravityUp, this.YawRotateSpeed * 0.017453292f, this.ScratchQuat1);
			this.ScratchQuat1.Multiply(this.WorkingQuat, this.ScratchQuat2);
			this.WorkingQuat.DeepCopy(this.ScratchQuat2);
			this.ScratchRotator.Set(this.PitchRotateSpeed, 0f, 0f);
			this.ScratchRotator.Quaternion(this.ScratchQuat1);
			this.WorkingQuat.Multiply(this.ScratchQuat1, this.ScratchQuat2);
			this.WorkingQuat.DeepCopy(this.ScratchQuat2);
		}

		// Token: 0x06045FC1 RID: 286657 RVA: 0x0125B5CC File Offset: 0x012597CC
		public override void ApplyRotationLimit()
		{
			if (!this.IsNormalGravity)
			{
				if (this.CurrentFrameHasCameraRotationInput)
				{
					base.FixCameraPitchInSpecialGravity(this.CapturedFixInputData.PitchLimitMin, this.CapturedFixInputData.PitchLimitMax);
					base.FixCameraYawInSpecialGravity(this.CapturedFixInputData.YawLimitMin, this.CapturedFixInputData.YawLimitMax);
				}
				return;
			}
			if (!this.CurrentFrameHasCameraRotationInput)
			{
				return;
			}
			base.ApplyRotatorInputLimits(this.CapturedFixInputData, this.StartRotator);
		}

		// Token: 0x06045FC2 RID: 286658 RVA: 0x0125B63D File Offset: 0x0125983D
		public override void ApplyRotationToCameraActor()
		{
			if (!this.IsNormalGravity)
			{
				base.ClearCameraGravityRoll();
				this.WorkingQuat.Rotator(this.WorkingRotator);
				base.WriteCameraRotation();
				return;
			}
			if (!this.CurrentFrameHasCameraRotationInput)
			{
				return;
			}
			base.WriteCameraRotation();
		}

		// Token: 0x06045FC3 RID: 286659 RVA: 0x0125B678 File Offset: 0x01259878
		[NullableContext(2)]
		private void ComputeCameraInput(FightCameraLogicComponent fightCameraLogicComp)
		{
			this.PitchRotateSpeed = 0f;
			this.YawRotateSpeed = 0f;
			this.CurrentFrameHasCameraRotationInput = false;
			if (fightCameraLogicComp == null)
			{
				return;
			}
			EntityHandle characterEntityHandle = fightCameraLogicComp.CharacterEntityHandle;
			if (characterEntityHandle == null || !characterEntityHandle.IsInit)
			{
				return;
			}
			WorldEntity entity = characterEntityHandle.Entity;
			CharacterInputComponent characterInputComponent = (entity != null) ? entity.GetComponent<CharacterInputComponent>() : null;
			if (characterInputComponent == null)
			{
				return;
			}
			ValueTuple<float, float> cameraInput = characterInputComponent.GetCameraInput();
			float num = cameraInput.Item1;
			float num2 = cameraInput.Item2;
			bool flag = (double)Math.Abs(num) >= 0.0001;
			bool flag2 = (double)Math.Abs(num2) >= 0.0001;
			this.CurrentFrameHasCameraRotationInput = (flag || flag2);
			if (SceneCameraInputRotator.IsInGamepad())
			{
				num *= 1f;
				num2 *= 1f;
			}
			else if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				num *= ModelBase<CharacterModel>.Instance.SelfCenteredTimeDilation;
				num2 *= ModelBase<CharacterModel>.Instance.SelfCenteredTimeDilation;
				num /= 60f;
				num2 /= 60f;
			}
			else if (SceneCameraInputRotator.IsInTouch())
			{
				num *= 180f * this.MobileDensityYawScale;
				num2 *= 180f * this.MobileDensityPitchScale;
				num /= 3f;
				num2 /= 3f;
			}
			this.YawRotateSpeed = num * this.CapturedFixInputData.YawInputSpeed;
			this.PitchRotateSpeed = -num2 * this.CapturedFixInputData.PitchInputSpeed;
		}

		// Token: 0x06045FC4 RID: 286660 RVA: 0x0125B7C9 File Offset: 0x012599C9
		private static bool IsInTouch()
		{
			return Singleton<Info>.Instance.IsInTouch() || (Singleton<Info>.Instance.IsInGamepad() && ModelBase<ControlScreenModel>.Instance.IsTouching);
		}

		// Token: 0x06045FC5 RID: 286661 RVA: 0x0125B7F1 File Offset: 0x012599F1
		private static bool IsInGamepad()
		{
			return Singleton<Info>.Instance.IsInGamepad() && !ModelBase<ControlScreenModel>.Instance.IsTouching;
		}

		// Token: 0x0402739A RID: 160666
		private const float DEFAULT_FPS = 60f;

		// Token: 0x0402739B RID: 160667
		private const float TOUCH_DEFAULT_PARAM = 3f;

		// Token: 0x0402739C RID: 160668
		private const float DEFAULT_DPI = 180f;

		// Token: 0x0402739D RID: 160669
		private const float DEFAULT_GAMEPAD_INPUT_RATE = 1f;

		// Token: 0x0402739E RID: 160670
		private readonly SceneFixInputData CapturedFixInputData = new SceneFixInputData();

		// Token: 0x0402739F RID: 160671
		private readonly float MobileDensityYawScale;

		// Token: 0x040273A0 RID: 160672
		private readonly float MobileDensityPitchScale;

		// Token: 0x040273A1 RID: 160673
		private float PitchRotateSpeed;

		// Token: 0x040273A2 RID: 160674
		private float YawRotateSpeed;

		// Token: 0x040273A3 RID: 160675
		private bool CurrentFrameHasCameraRotationInput;
	}
}
