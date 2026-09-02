using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;

namespace CSharpScript.Game.Camera.SceneCameraRotator
{
	// Token: 0x020070BE RID: 28862
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneCameraBlendToTargetRotator : SceneCameraRotatorBase
	{
		// Token: 0x06045FB1 RID: 286641 RVA: 0x0125AE1C File Offset: 0x0125901C
		public override bool IsValid()
		{
			return !this.Finished;
		}

		// Token: 0x06045FB2 RID: 286642 RVA: 0x0125AE27 File Offset: 0x01259027
		public override void OnActivate()
		{
			this.BlendElapsed = 0f;
			this.Finished = false;
		}

		// Token: 0x06045FB3 RID: 286643 RVA: 0x0125AE3C File Offset: 0x0125903C
		public override void ComputeExpectRotation()
		{
			SceneSubCamera subCamera = this.SubCamera;
			BP_CineCamera_C bp_CineCamera_C = (subCamera != null) ? subCamera.Camera : null;
			if (bp_CineCamera_C == null || !bp_CineCamera_C.IsValid())
			{
				this.Finished = true;
				return;
			}
			if (this.BlendDuration <= 0f)
			{
				this.WorkingQuat.DeepCopy(this.BlendTargetQuat);
				this.Finished = true;
				return;
			}
			this.BlendElapsed += this.DeltaTime;
			float num = Singleton<MathUtils>.Instance.Clamp(this.BlendElapsed / this.BlendDuration, 0f, 1f);
			Quat.Slerp(this.BlendStartQuat, this.BlendTargetQuat, num, this.WorkingQuat);
			if (num >= 1f)
			{
				this.Finished = true;
			}
		}

		// Token: 0x06045FB4 RID: 286644 RVA: 0x0125AEF4 File Offset: 0x012590F4
		public override void ApplyRotationLimit()
		{
			if (!this.IsNormalGravity || this.CapturedFixInputData == null)
			{
				return;
			}
			this.WorkingQuat.Rotator(this.WorkingRotator);
			base.ApplyRotatorInputLimits(this.CapturedFixInputData, this.StartRotator);
			this.WorkingRotator.Quaternion(this.WorkingQuat);
		}

		// Token: 0x06045FB5 RID: 286645 RVA: 0x0125AF48 File Offset: 0x01259148
		public override void ApplyRotationToCameraActor()
		{
			SceneSubCamera subCamera = this.SubCamera;
			BP_CineCamera_C bp_CineCamera_C = (subCamera != null) ? subCamera.Camera : null;
			if (bp_CineCamera_C == null || !bp_CineCamera_C.IsValid())
			{
				this.Finished = true;
				return;
			}
			if (!this.IsNormalGravity)
			{
				base.ClearCameraGravityRoll();
			}
			this.WorkingQuat.Rotator(this.WorkingRotator);
			base.WriteCameraRotation();
		}

		// Token: 0x06045FB6 RID: 286646 RVA: 0x0125AFA4 File Offset: 0x012591A4
		public unsafe bool InitFromLookAtTarget(SceneSubCamera subCamera, FightCameraLogicComponent fightCameraLogicComp, Vector targetPosition, float blendDurationMs)
		{
			BP_CineCamera_C camera = subCamera.Camera;
			if (camera == null || !camera.IsValid())
			{
				return false;
			}
			this.PrepareFrame(subCamera, fightCameraLogicComp, 0f);
			this.ScratchVector1.DeepCopy(targetPosition);
			Vector scratchVector = this.ScratchVector2;
			FVectorDouble fvectorDouble = camera.D_K2_GetActorLocation();
			scratchVector.DeepCopy(fvectorDouble);
			this.ScratchVector1.SubtractionEqual(this.ScratchVector2);
			if (Singleton<MathUtils>.Instance.IsNearlyZero(this.ScratchVector1.SizeSquared(), null))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Camera;
				ELogAuthor author = ELogAuthor.ZJL;
				string message = "尝试让相机看向一个与相机位置重合的点，危险操作已被阻止";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("targetPosition", targetPosition);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("cameraLocation", this.ScratchVector2);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.ScratchVector1, this.GravityUp, this.WorkingQuat);
			if (!this.IsNormalGravity)
			{
				float pitchMin = -90f;
				float pitchMax = 90f;
				float yawMin = -180f;
				float yawMax = 180f;
				if (subCamera.CanAcceptInput && subCamera.FixInputData != null)
				{
					pitchMin = subCamera.FixInputData.PitchLimitMin;
					pitchMax = subCamera.FixInputData.PitchLimitMax;
					yawMin = subCamera.FixInputData.YawLimitMin;
					yawMax = subCamera.FixInputData.YawLimitMax;
				}
				base.FixCameraPitchInSpecialGravity(pitchMin, pitchMax);
				base.FixCameraYawInSpecialGravity(yawMin, yawMax);
				base.ClearCameraGravityRoll();
			}
			this.BlendTargetQuat.DeepCopy(this.WorkingQuat);
			Rotator scratchRotator = this.ScratchRotator;
			FRotator frotator = camera.K2_GetActorRotation();
			scratchRotator.DeepCopy(frotator);
			this.ScratchRotator.Quaternion(this.BlendStartQuat);
			if (this.IsNormalGravity && subCamera.CanAcceptInput && subCamera.FixInputData != null)
			{
				this.WorkingQuat.DeepCopy(this.BlendTargetQuat);
				this.WorkingQuat.Rotator(this.WorkingRotator);
				base.ApplyRotatorInputLimits(subCamera.FixInputData, this.StartRotator);
				this.WorkingRotator.Quaternion(this.BlendTargetQuat);
				this.CapturedFixInputData = new SceneFixInputData();
				this.CapturedFixInputData.DeepCopy(subCamera.FixInputData);
			}
			else
			{
				this.CapturedFixInputData = null;
			}
			this.BlendDuration = blendDurationMs;
			this.BlendElapsed = 0f;
			this.Finished = false;
			return true;
		}

		// Token: 0x04027392 RID: 160658
		[Nullable(2)]
		private SceneFixInputData CapturedFixInputData;

		// Token: 0x04027393 RID: 160659
		private readonly Quat BlendStartQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x04027394 RID: 160660
		private readonly Quat BlendTargetQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x04027395 RID: 160661
		private float BlendDuration;

		// Token: 0x04027396 RID: 160662
		private float BlendElapsed;

		// Token: 0x04027397 RID: 160663
		private bool Finished;
	}
}
