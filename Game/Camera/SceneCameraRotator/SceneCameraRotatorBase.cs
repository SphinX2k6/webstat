using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;

namespace CSharpScript.Game.Camera.SceneCameraRotator
{
	// Token: 0x020070C1 RID: 28865
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class SceneCameraRotatorBase
	{
		// Token: 0x06045FC6 RID: 286662
		public abstract bool IsValid();

		// Token: 0x06045FC7 RID: 286663
		public abstract void ComputeExpectRotation();

		// Token: 0x06045FC8 RID: 286664
		public abstract void ApplyRotationLimit();

		// Token: 0x06045FC9 RID: 286665
		public abstract void ApplyRotationToCameraActor();

		// Token: 0x06045FCA RID: 286666 RVA: 0x0125B80E File Offset: 0x01259A0E
		public virtual void OnActivate()
		{
		}

		// Token: 0x06045FCB RID: 286667 RVA: 0x0125B810 File Offset: 0x01259A10
		public virtual void OnDeactivate()
		{
		}

		// Token: 0x06045FCC RID: 286668 RVA: 0x0125B812 File Offset: 0x01259A12
		[NullableContext(2)]
		public virtual void OnTick(SceneSubCamera subCamera, FightCameraLogicComponent fightCameraLogicComp, float deltaTime)
		{
			this.PrepareFrame(subCamera, fightCameraLogicComp, deltaTime);
			this.ComputeExpectRotation();
			this.ApplyRotationLimit();
			this.ApplyRotationToCameraActor();
		}

		// Token: 0x06045FCD RID: 286669 RVA: 0x0125B830 File Offset: 0x01259A30
		[NullableContext(2)]
		public virtual void PrepareFrame(SceneSubCamera subCamera, FightCameraLogicComponent fightCameraLogicComp, float deltaTime)
		{
			this.SubCamera = subCamera;
			this.FightCameraLogicComp = fightCameraLogicComp;
			this.DeltaTime = deltaTime;
			if (subCamera == null || fightCameraLogicComp == null)
			{
				return;
			}
			this.IsNormalGravity = fightCameraLogicComp.IsInNormalGravityMode();
			this.StartRotator.DeepCopy(subCamera.StartRotation);
			this.StartRotator.Quaternion(this.StartQuat);
			this.GravityUp.DeepCopy(this.IsNormalGravity ? Vector.UpVectorProxy : fightCameraLogicComp.GravityUp);
		}

		// Token: 0x06045FCE RID: 286670 RVA: 0x0125B8A8 File Offset: 0x01259AA8
		protected void ClearCameraGravityRoll()
		{
			this.WorkingQuat.RotateVector(Vector.ForwardVectorProxy, this.ScratchVector1);
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.ScratchVector1, this.GravityUp, this.WorkingQuat);
		}

		// Token: 0x06045FCF RID: 286671 RVA: 0x0125B8DC File Offset: 0x01259ADC
		protected float ClampAngleByStartRotator(float angle, float startAngle, float minLimit, float maxLimit)
		{
			float currentValue = Singleton<MathUtils>.Instance.WrapAngle(angle - startAngle);
			float num = Singleton<MathUtils>.Instance.Clamp(currentValue, minLimit, maxLimit);
			return Singleton<MathUtils>.Instance.WrapAngle(num + startAngle);
		}

		// Token: 0x06045FD0 RID: 286672 RVA: 0x0125B914 File Offset: 0x01259B14
		protected void ApplyRotatorInputLimits(SceneFixInputData fixInput, Rotator startRot)
		{
			this.WorkingRotator.Pitch = this.ClampAngleByStartRotator(this.WorkingRotator.Pitch, startRot.Pitch, fixInput.PitchLimitMin, fixInput.PitchLimitMax);
			this.WorkingRotator.Yaw = this.ClampAngleByStartRotator(this.WorkingRotator.Yaw, startRot.Yaw, fixInput.YawLimitMin, fixInput.YawLimitMax);
		}

		// Token: 0x06045FD1 RID: 286673 RVA: 0x0125B980 File Offset: 0x01259B80
		protected void FixCameraPitchInSpecialGravity(float pitchMin, float pitchMax)
		{
			this.StartQuat.RotateVector(Vector.ForwardVectorProxy, this.ScratchVector1);
			float num = (float)Math.Asin((double)Singleton<MathUtils>.Instance.Clamp((float)this.ScratchVector1.DotProduct(this.GravityUp), -1f, 1f)) * 57.29578f;
			this.WorkingQuat.RotateVector(Vector.ForwardVectorProxy, this.ScratchVector2);
			float num2 = (float)Math.Asin((double)Singleton<MathUtils>.Instance.Clamp((float)this.ScratchVector2.DotProduct(this.GravityUp), -1f, 1f)) * 57.29578f;
			float num3 = Singleton<MathUtils>.Instance.WrapAngle(num2 - num);
			float num4 = Singleton<MathUtils>.Instance.Clamp(num3, pitchMin, pitchMax);
			if ((double)Math.Abs(num4 - num3) > 0.0001)
			{
				float inPitch = num4 - num3;
				this.ScratchRotator.Set(inPitch, 0f, 0f);
				this.ScratchRotator.Quaternion(this.ScratchQuat1);
				this.WorkingQuat.Multiply(this.ScratchQuat1, this.ScratchQuat2);
				this.WorkingQuat.DeepCopy(this.ScratchQuat2);
			}
		}

		// Token: 0x06045FD2 RID: 286674 RVA: 0x0125BAA8 File Offset: 0x01259CA8
		protected void FixCameraYawInSpecialGravity(float yawMin, float yawMax)
		{
			this.StartQuat.RotateVector(Vector.ForwardVectorProxy, this.ScratchVector1);
			float num = (float)this.ScratchVector1.DotProduct(this.GravityUp);
			this.GravityUp.Multiply((double)num, this.ScratchVector3);
			this.ScratchVector1.SubtractionEqual(this.ScratchVector3);
			this.ScratchVector1.Normalize(9.99999993922529E-09);
			this.WorkingQuat.RotateVector(Vector.ForwardVectorProxy, this.ScratchVector2);
			float num2 = (float)this.ScratchVector2.DotProduct(this.GravityUp);
			this.GravityUp.Multiply((double)num2, this.ScratchVector3);
			this.ScratchVector2.SubtractionEqual(this.ScratchVector3);
			this.ScratchVector2.Normalize(9.99999993922529E-09);
			float num3 = (float)Singleton<MathUtils>.Instance.GetAngleByVectorDot(this.ScratchVector1, this.ScratchVector2);
			this.ScratchVector1.CrossProduct(this.ScratchVector2, this.ScratchVector3);
			float num4 = (this.ScratchVector3.DotProduct(this.GravityUp) >= 0.0) ? 1f : -1f;
			float num5 = num3 * num4;
			float num6 = Singleton<MathUtils>.Instance.Clamp(num5, yawMin, yawMax);
			if ((double)Math.Abs(num6 - num5) > 0.0001)
			{
				float num7 = num6 - num5;
				Quat.ConstructorByAxisAngle(this.GravityUp, num7 * 0.017453292f, this.ScratchQuat1);
				this.ScratchQuat1.Multiply(this.WorkingQuat, this.ScratchQuat2);
				this.WorkingQuat.DeepCopy(this.ScratchQuat2);
			}
		}

		// Token: 0x06045FD3 RID: 286675 RVA: 0x0125BC44 File Offset: 0x01259E44
		protected void WriteCameraRotation()
		{
			SceneSubCamera subCamera = this.SubCamera;
			BP_CineCamera_C bp_CineCamera_C = (subCamera != null) ? subCamera.Camera : null;
			if (bp_CineCamera_C == null || !bp_CineCamera_C.IsValid())
			{
				return;
			}
			bp_CineCamera_C.K2_SetActorRotation(this.WorkingRotator.ToUeRotator(), false);
		}

		// Token: 0x040273A4 RID: 160676
		[Nullable(2)]
		protected SceneSubCamera SubCamera;

		// Token: 0x040273A5 RID: 160677
		[Nullable(2)]
		protected FightCameraLogicComponent FightCameraLogicComp;

		// Token: 0x040273A6 RID: 160678
		protected float DeltaTime;

		// Token: 0x040273A7 RID: 160679
		protected bool IsNormalGravity = true;

		// Token: 0x040273A8 RID: 160680
		protected readonly Vector GravityUp = Vector.Create(0.0, 0.0, 1.0);

		// Token: 0x040273A9 RID: 160681
		protected readonly Rotator StartRotator = Rotator.Create();

		// Token: 0x040273AA RID: 160682
		protected readonly Quat StartQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x040273AB RID: 160683
		protected readonly Rotator WorkingRotator = Rotator.Create();

		// Token: 0x040273AC RID: 160684
		protected readonly Quat WorkingQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x040273AD RID: 160685
		protected readonly Rotator ScratchRotator = Rotator.Create();

		// Token: 0x040273AE RID: 160686
		protected readonly Quat ScratchQuat1 = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x040273AF RID: 160687
		protected readonly Quat ScratchQuat2 = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x040273B0 RID: 160688
		protected readonly Vector ScratchVector1 = Vector.Create();

		// Token: 0x040273B1 RID: 160689
		protected readonly Vector ScratchVector2 = Vector.Create();

		// Token: 0x040273B2 RID: 160690
		protected readonly Vector ScratchVector3 = Vector.Create();
	}
}
