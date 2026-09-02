using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x0200709E RID: 28830
	[NullableContext(2)]
	[Nullable(0)]
	public class CameraRotationZone
	{
		// Token: 0x06045DDB RID: 286171 RVA: 0x0124BD5C File Offset: 0x01249F5C
		[NullableContext(1)]
		public void Init(FightCameraLogicComponent camera)
		{
			this.Camera = camera;
			this.MotorStandByLargePitchAngle = ConfigCommonParamById.GetFloatConfig("MotorJumpPitchThreshold").GetValueOrDefault(100f);
			this.MotorStandByLargePitchTime = ConfigCommonParamById.GetFloatConfig("MotorJumpPitchTime").GetValueOrDefault(0.5f);
		}

		// Token: 0x06045DDC RID: 286172 RVA: 0x0124BDAC File Offset: 0x01249FAC
		public void SetCharacter(EntityHandle characterEntityHandle)
		{
			this.CharacterEntityHandle = characterEntityHandle;
			EntityHandle characterEntityHandle2 = this.CharacterEntityHandle;
			if (characterEntityHandle2 == null || !characterEntityHandle2.Valid)
			{
				return;
			}
			this.CharacterInputComponent = this.CharacterEntityHandle.Entity.GetComponent<CharacterInputComponent>();
			this.CharacterActorComponent = this.CharacterEntityHandle.Entity.GetComponent<CharacterActorComponent>();
			this.CharacterGlideComponent = this.CharacterEntityHandle.Entity.GetComponent<CharacterGlideComponent>();
			this.CharacterAnimationComponent = this.CharacterEntityHandle.Entity.GetComponent<CharacterAnimationComponent>();
		}

		// Token: 0x06045DDD RID: 286173 RVA: 0x0124BE30 File Offset: 0x0124A030
		public void SetVehicle(EntityHandle vehicleEntityHandle)
		{
			this.VehicleEntityHandle = vehicleEntityHandle;
			EntityHandle vehicleEntityHandle2 = this.VehicleEntityHandle;
			if (vehicleEntityHandle2 == null || !vehicleEntityHandle2.Valid)
			{
				this.VehicleActorComponent = null;
				this.VehicleTagComponent = null;
				return;
			}
			this.VehicleActorComponent = this.VehicleEntityHandle.Entity.GetComponent<VehicleActorComponent>();
			this.VehicleTagComponent = this.VehicleEntityHandle.Entity.GetComponent<VehicleTagComponent>();
		}

		// Token: 0x06045DDE RID: 286174 RVA: 0x0124BE98 File Offset: 0x0124A098
		public void UpdateInputState(float deltaTime)
		{
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.None)
			{
				return;
			}
			if (this.BlockSet.Count > 0)
			{
				return;
			}
			this.Camera.GetCameraTargetInput(this.InputVector);
			if (this.IsHasPitchMovement())
			{
				this.PitchInputTime += deltaTime;
			}
			else
			{
				this.PitchInputTime = 0f;
			}
			ValueTuple<float, float> cameraInput = this.CharacterInputComponent.GetCameraInput();
			double num = (double)cameraInput.Item1;
			double num2 = (double)cameraInput.Item2;
			double value = num;
			double value2 = num2;
			if (!Singleton<MathUtils>.Instance.IsNearlyZero(value2, new double?(0.0001)))
			{
				this.PitchRollbackTime = 0f;
			}
			else
			{
				this.PitchRollbackTime += deltaTime;
			}
			if (!Singleton<MathUtils>.Instance.IsNearlyZero(this.InputVector.Y, new double?(0.0001)))
			{
				this.YawInputTime += deltaTime;
			}
			else
			{
				this.YawInputTime = 0f;
			}
			if (!Singleton<MathUtils>.Instance.IsNearlyZero(value, new double?(0.0001)))
			{
				this.YawRollbackTime = 0f;
			}
			else
			{
				this.YawRollbackTime += deltaTime;
			}
			if (this.Camera.PlayerRotatorInGravity.Pitch > this.GetLargePitchStandByAngle())
			{
				this.StandByLargePitchAngle = 0f;
				return;
			}
			this.StandByLargePitchAngle += deltaTime;
		}

		// Token: 0x06045DDF RID: 286175 RVA: 0x0124BFF4 File Offset: 0x0124A1F4
		public void UpdatePitchZone(float deltaTime)
		{
			if (!this.CheckValid())
			{
				return;
			}
			if (!this.IsPitchZoneEnable())
			{
				return;
			}
			this.UpdatePitchZoneLimit();
			float num = this.Camera.PlayerRotatorInGravity.Pitch;
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar)
			{
				global::Vector actorVelocityProxy = this.CharacterActorComponent.ActorVelocityProxy;
				if (this.Camera.IsInNormalGravityMode())
				{
					Singleton<MathUtils>.Instance.LookRotationForwardFirst(actorVelocityProxy, global::Vector.UpVectorProxy, this.TmpQuat);
					this.TmpQuat.Rotator(this.TmpRotator);
				}
				else
				{
					actorVelocityProxy.Rotation(this.TmpRotator);
					CameraUtility.GetRotatorInGravity(this.TmpRotator, this.TmpRotator);
				}
				num = this.TmpRotator.Pitch;
			}
			num += this.Camera.PitchBasis;
			float pitchInGravity = CameraUtility.GetPitchInGravity(this.Camera.DesiredCamera.ArmRotation);
			float deltaPitch = Singleton<MathUtils>.Instance.WrapAngle(num - pitchInGravity);
			this.UpdateZonePitchState(deltaPitch, pitchInGravity);
			float targetPitch = this.GetTargetPitch(num, pitchInGravity, deltaPitch, deltaTime);
			CameraUtility.SetPitchInGravity(this.Camera.DesiredCamera.ArmRotation, (double)targetPitch, this.Camera.DesiredCamera.ArmRotation);
		}

		// Token: 0x06045DE0 RID: 286176 RVA: 0x0124C118 File Offset: 0x0124A318
		private void UpdatePitchZoneLimit()
		{
			this.PitchSoftZoneMin = this.Camera.PitchSoftZoneMin;
			this.PitchSoftZoneMax = this.Camera.PitchSoftZoneMax;
			this.PitchDeadZoneMin = this.Camera.PitchDeadZoneMin;
			this.PitchDeadZoneMax = this.Camera.PitchDeadZoneMax;
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor)
			{
				this.PitchSoftZoneMin += Math.Max(0f, this.Camera.PlayerRotatorInGravity.Pitch);
			}
		}

		// Token: 0x06045DE1 RID: 286177 RVA: 0x0124C1A0 File Offset: 0x0124A3A0
		private void UpdateZonePitchState(float deltaPitch, float cameraPitch)
		{
			if (deltaPitch >= this.PitchSoftZoneMin && deltaPitch <= this.PitchSoftZoneMax)
			{
				this.CameraPitchZoneState = CameraRotationZone.ECameraZoneState.InSoftZone;
			}
			if (this.IsStandbyPitchEnable())
			{
				this.CameraPitchZoneState = CameraRotationZone.ECameraZoneState.Standby;
			}
			else if (this.CharacterInputComponent.HasCameraInput(0.0001f) || this.BlockSet.Count > 0)
			{
				this.CameraPitchZoneState = CameraRotationZone.ECameraZoneState.InDeadZone;
			}
			else if (this.IsSoftPitchEnable())
			{
				if (this.CameraPitchZoneState != CameraRotationZone.ECameraZoneState.InSoftZone && this.IsDeadZoneTransitionToSoftZoneEnable())
				{
					this.CameraPitchZoneState = CameraRotationZone.ECameraZoneState.DeadZoneTransitionToSoftZone;
				}
			}
			else if (this.IsPitchTransitionToForwardEnable())
			{
				this.CameraPitchZoneState = CameraRotationZone.ECameraZoneState.TransitionToForward;
			}
			bool enableDebug = this.EnableDebug;
		}

		// Token: 0x06045DE2 RID: 286178 RVA: 0x0124C238 File Offset: 0x0124A438
		private float GetTargetPitch(float actorPitch, float cameraPitch, float deltaPitch, float deltaTime)
		{
			if (this.CameraPitchZoneState == CameraRotationZone.ECameraZoneState.Standby && this.IsStandByPitchFreeLook())
			{
				return cameraPitch;
			}
			float num = Singleton<MathUtils>.Instance.Lerp(this.Camera.PitchZoneSpeedMin, this.Camera.PitchZoneSpeedMax, Singleton<MathUtils>.Instance.Clamp(Math.Abs(deltaPitch) / this.PitchSoftZoneMax, 0f, 1f));
			float targetDeltaPitch = deltaTime * num;
			float num2 = cameraPitch;
			if (this.CameraPitchZoneState != CameraRotationZone.ECameraZoneState.Standby && this.CameraPitchZoneState != CameraRotationZone.ECameraZoneState.InDeadZone)
			{
				num2 = this.GetTargetPitchTransitionToForward(cameraPitch, actorPitch, targetDeltaPitch, deltaPitch);
				float num3 = Singleton<MathUtils>.Instance.WrapAngle(actorPitch - num2);
				if (num3 >= this.PitchSoftZoneMin && num3 <= this.PitchSoftZoneMax)
				{
					this.CameraPitchZoneState = CameraRotationZone.ECameraZoneState.InSoftZone;
				}
			}
			bool enableDebug = this.EnableDebug;
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar || this.Camera.CameraZoneMode == EFightCameraZoneMode.Vehicle)
			{
				num2 = this.ClampAxisAngle(this.CameraPitchZoneState == CameraRotationZone.ECameraZoneState.InSoftZone, actorPitch, num2, this.PitchSoftZoneMin, this.PitchSoftZoneMax, this.PitchDeadZoneMin, this.PitchDeadZoneMax);
			}
			else
			{
				num2 = this.ClampRelativePitchAngle(this.CameraPitchZoneState == CameraRotationZone.ECameraZoneState.InSoftZone, num2, this.PitchSoftZoneMin, this.PitchSoftZoneMax, this.PitchDeadZoneMin, this.PitchDeadZoneMax);
			}
			return num2;
		}

		// Token: 0x06045DE3 RID: 286179 RVA: 0x0124C35C File Offset: 0x0124A55C
		public void UpdateYawZone(float deltaTime)
		{
			if (!this.CheckValid())
			{
				return;
			}
			if (!this.IsYawZoneEnable())
			{
				return;
			}
			this.UpdateYawZoneLimit();
			this.UpdateZoneYawState();
			float targetYaw = this.GetTargetYaw(deltaTime);
			CameraUtility.SetYawInGravity(this.Camera.DesiredCamera.ArmRotation, (double)targetYaw, this.Camera.DesiredCamera.ArmRotation);
		}

		// Token: 0x06045DE4 RID: 286180 RVA: 0x0124C3B8 File Offset: 0x0124A5B8
		private void UpdateYawZoneLimit()
		{
			this.YawSoftZoneMin = this.Camera.YawSoftZoneMin;
			this.YawSoftZoneMax = this.Camera.YawSoftZoneMax;
			this.YawDeadZoneMin = this.Camera.YawDeadZoneMin;
			this.YawDeadZoneMax = this.Camera.YawDeadZoneMax;
		}

		// Token: 0x06045DE5 RID: 286181 RVA: 0x0124C40C File Offset: 0x0124A60C
		private void UpdateZoneYawState()
		{
			float yaw = this.Camera.PlayerRotatorInGravity.Yaw;
			float yawInGravity = CameraUtility.GetYawInGravity(this.Camera.DesiredCamera.ArmRotation);
			float num = Singleton<MathUtils>.Instance.WrapAngle(yaw - yawInGravity);
			if (num >= this.YawSoftZoneMin && num <= this.YawSoftZoneMax)
			{
				this.CameraYawZoneState = CameraRotationZone.ECameraZoneState.InSoftZone;
			}
			if (this.IsStandbyYawEnable())
			{
				this.CameraYawZoneState = CameraRotationZone.ECameraZoneState.Standby;
			}
			else if ((this.IsDeadYawEnable() && this.CharacterInputComponent.HasCameraInput(0.0001f)) || this.BlockSet.Count > 0)
			{
				this.CameraYawZoneState = CameraRotationZone.ECameraZoneState.InDeadZone;
			}
			else if (this.IsSoftYawEnable())
			{
				if (this.CameraYawZoneState != CameraRotationZone.ECameraZoneState.InSoftZone && this.IsDeadZoneTransitionToSoftZoneEnable())
				{
					this.CameraYawZoneState = CameraRotationZone.ECameraZoneState.DeadZoneTransitionToSoftZone;
				}
			}
			else if (this.IsYawTransitionToForwardEnable())
			{
				if (this.CameraYawZoneState == CameraRotationZone.ECameraZoneState.InSoftZone)
				{
					this.CameraYawZoneState = CameraRotationZone.ECameraZoneState.TransitionToForwardWithSoftZone;
				}
				else if (this.CameraYawZoneState != CameraRotationZone.ECameraZoneState.TransitionToForwardWithSoftZone)
				{
					this.CameraYawZoneState = CameraRotationZone.ECameraZoneState.TransitionToForward;
				}
			}
			bool enableDebug = this.EnableDebug;
		}

		// Token: 0x06045DE6 RID: 286182 RVA: 0x0124C4FC File Offset: 0x0124A6FC
		private float GetTargetYaw(float deltaTime)
		{
			if (this.CameraYawZoneState == CameraRotationZone.ECameraZoneState.Standby && this.IsStandByYawFreeLook())
			{
				return CameraUtility.GetYawInGravity(this.Camera.DesiredCamera.ArmRotation);
			}
			float yaw = this.Camera.PlayerRotatorInGravity.Yaw;
			float yawInGravity = CameraUtility.GetYawInGravity(this.Camera.DesiredCamera.ArmRotation);
			float num = Singleton<MathUtils>.Instance.WrapAngle(yaw - yawInGravity);
			float targetDeltaYaw = deltaTime * this.GetYawSpeed();
			float num2 = yawInGravity;
			if (this.CameraYawZoneState == CameraRotationZone.ECameraZoneState.InSoftZone)
			{
				num2 = this.GetTargetYawInSoftZone(yawInGravity, targetDeltaYaw);
			}
			else if (this.CameraYawZoneState == CameraRotationZone.ECameraZoneState.DeadZoneTransitionToSoftZone)
			{
				num2 = this.GetTargetYawDeadZoneTransitionToSoftZone(yawInGravity, targetDeltaYaw, num, num2);
				float num3 = this.IsSoftYawAddAngle() ? this.YawSoftZoneMin : this.YawSoftZoneMax;
				float num4 = Singleton<MathUtils>.Instance.WrapAngle(yaw - num2);
				if ((num < 0f && num4 > num3) || (num > 0f && num4 < num3))
				{
					this.CameraYawZoneState = CameraRotationZone.ECameraZoneState.InSoftZone;
				}
			}
			else if (this.CameraYawZoneState == CameraRotationZone.ECameraZoneState.TransitionToForward || this.CameraYawZoneState == CameraRotationZone.ECameraZoneState.TransitionToForwardWithSoftZone)
			{
				num2 = this.GetTargetYawTransitionToForward(yawInGravity, yaw, targetDeltaYaw, num);
				float num5 = Singleton<MathUtils>.Instance.WrapAngle(yaw - num2);
				if (num5 >= this.YawSoftZoneMin && num5 <= this.YawSoftZoneMax)
				{
					this.CameraYawZoneState = CameraRotationZone.ECameraZoneState.InSoftZone;
				}
			}
			bool enableDebug = this.EnableDebug;
			num2 = this.ClampAxisAngle(this.CameraYawZoneState == CameraRotationZone.ECameraZoneState.InSoftZone || this.CameraYawZoneState == CameraRotationZone.ECameraZoneState.TransitionToForwardWithSoftZone, yaw, num2, this.YawSoftZoneMin, this.YawSoftZoneMax, this.YawDeadZoneMin, this.YawDeadZoneMax);
			bool enableDebug2 = this.EnableDebug;
			return num2;
		}

		// Token: 0x06045DE7 RID: 286183 RVA: 0x0124C67C File Offset: 0x0124A87C
		private float GetTargetYawInSoftZone(float cameraYaw, float targetDeltaYaw)
		{
			if (this.Camera.CameraZoneMode != EFightCameraZoneMode.Motor || !this.IsEnableSoftYawAddAngle() || Singleton<MathUtils>.Instance.IsNearlyZero(this.InputVector.Y, new double?(0.0001)))
			{
				return Singleton<MathUtils>.Instance.WrapAngle(cameraYaw + (this.IsEnableSoftYawAddAngle() ? (this.IsSoftYawAddAngle() ? targetDeltaYaw : (-targetDeltaYaw)) : 0f));
			}
			if (this.IsSoftYawAddAngle())
			{
				return Singleton<MathUtils>.Instance.WrapAngle(cameraYaw + targetDeltaYaw * this.Camera.YawSoftZoneSpeedRatio);
			}
			return Singleton<MathUtils>.Instance.WrapAngle(cameraYaw - targetDeltaYaw * this.Camera.YawSoftZoneSpeedRatio);
		}

		// Token: 0x06045DE8 RID: 286184 RVA: 0x0124C728 File Offset: 0x0124A928
		private float GetTargetYawDeadZoneTransitionToSoftZone(float cameraYaw, float targetDeltaYaw, float deltaYaw, float targetYaw)
		{
			if (this.IsDeadYawTransitionToSoftYawAddAngle(deltaYaw))
			{
				return Singleton<MathUtils>.Instance.WrapAngle(cameraYaw + targetDeltaYaw * this.Camera.YawDeadZoneTransToSoftZoneSpeedRatio);
			}
			if (this.IsDeadYawTransitionToSoftYawMinusAngle(deltaYaw))
			{
				return Singleton<MathUtils>.Instance.WrapAngle(cameraYaw - targetDeltaYaw * this.Camera.YawDeadZoneTransToSoftZoneSpeedRatio);
			}
			return targetYaw;
		}

		// Token: 0x06045DE9 RID: 286185 RVA: 0x0124C780 File Offset: 0x0124A980
		private float GetTargetYawTransitionToForward(float cameraYaw, float actorYaw, float targetDeltaYaw, float deltaYaw)
		{
			if (deltaYaw < 0f)
			{
				float num = Singleton<MathUtils>.Instance.WrapAngle(cameraYaw - targetDeltaYaw * this.Camera.YawTransToForwardSpeedRatio);
				if (Singleton<MathUtils>.Instance.WrapAngle(actorYaw - num) <= 0f)
				{
					return num;
				}
				return actorYaw;
			}
			else
			{
				float num2 = Singleton<MathUtils>.Instance.WrapAngle(cameraYaw + targetDeltaYaw * this.Camera.YawTransToForwardSpeedRatio);
				if (Singleton<MathUtils>.Instance.WrapAngle(actorYaw - num2) >= 0f)
				{
					return num2;
				}
				return actorYaw;
			}
		}

		// Token: 0x06045DEA RID: 286186 RVA: 0x0124C7FC File Offset: 0x0124A9FC
		private float GetTargetPitchTransitionToForward(float cameraPitch, float actorPitch, float targetDeltaPitch, float deltaPitch)
		{
			if (deltaPitch < 0f)
			{
				float num = Singleton<MathUtils>.Instance.WrapAngle(cameraPitch - targetDeltaPitch);
				if (Singleton<MathUtils>.Instance.WrapAngle(actorPitch - num) <= 0f)
				{
					return num;
				}
				return actorPitch;
			}
			else
			{
				float num2 = Singleton<MathUtils>.Instance.WrapAngle(cameraPitch + targetDeltaPitch);
				if (Singleton<MathUtils>.Instance.WrapAngle(actorPitch - num2) >= 0f)
				{
					return num2;
				}
				return actorPitch;
			}
		}

		// Token: 0x06045DEB RID: 286187 RVA: 0x0124C860 File Offset: 0x0124AA60
		private float ClampAxisAngle(bool isInSoftZone, float actorAngle, float targetAngle, float softZoneMinAngle, float softZoneMaxAngle, float deadZoneMinAngle, float deadZoneMaxAngle)
		{
			float num = Singleton<MathUtils>.Instance.WrapAngle(actorAngle - targetAngle);
			float num2 = isInSoftZone ? softZoneMinAngle : deadZoneMinAngle;
			float num3 = isInSoftZone ? softZoneMaxAngle : deadZoneMaxAngle;
			if (num < num2)
			{
				return Singleton<MathUtils>.Instance.WrapAngle(actorAngle - num2);
			}
			if (num > num3)
			{
				return Singleton<MathUtils>.Instance.WrapAngle(actorAngle - num3);
			}
			return targetAngle;
		}

		// Token: 0x06045DEC RID: 286188 RVA: 0x0124C8B4 File Offset: 0x0124AAB4
		private float ClampRelativePitchAngle(bool isInSoftZone, float targetPitch, float softZoneMinAngle, float softZoneMaxAngle, float deadZoneMinAngle, float deadZoneMaxAngle)
		{
			Rotator tmpRotator = this.TmpRotator;
			global::Vector tmpVector = this.TmpVector;
			CameraUtility.GetRotatorInGravity(this.Camera.DesiredCamera.ArmRotation, this.TmpRotator);
			tmpRotator.Pitch = targetPitch;
			tmpRotator.Vector(tmpVector);
			Rotator tmpRotator2 = this.TmpRotator1;
			tmpRotator2.DeepCopy(this.Camera.PlayerRotatorInGravity);
			tmpRotator2.Roll = 0f;
			tmpRotator2.Quaternion(this.TmpQuat);
			this.TmpQuat.UnRotateVector(tmpVector, tmpVector);
			tmpVector.Rotation(tmpRotator);
			tmpRotator.Pitch = this.ClampRelativeAxisAngle(isInSoftZone, tmpRotator.Pitch, softZoneMinAngle, softZoneMaxAngle, deadZoneMinAngle, deadZoneMaxAngle);
			tmpRotator.Vector(tmpVector);
			this.TmpQuat.RotateVector(tmpVector, tmpVector);
			tmpVector.Rotation(tmpRotator);
			return tmpRotator.Pitch;
		}

		// Token: 0x06045DED RID: 286189 RVA: 0x0124C978 File Offset: 0x0124AB78
		private float ClampRelativeAxisAngle(bool isInSoftZone, float targetAngle, float softZoneMinAngle, float softZoneMaxAngle, float deadZoneMinAngle, float deadZoneMaxAngle)
		{
			float num = isInSoftZone ? softZoneMinAngle : deadZoneMinAngle;
			float num2 = isInSoftZone ? softZoneMaxAngle : deadZoneMaxAngle;
			if (targetAngle < -num2)
			{
				return -num2;
			}
			if (targetAngle > -num)
			{
				return -num;
			}
			return targetAngle;
		}

		// Token: 0x06045DEE RID: 286190 RVA: 0x0124C9A9 File Offset: 0x0124ABA9
		private bool IsPitchZoneEnable()
		{
			return this.Camera.CameraZoneMode != EFightCameraZoneMode.None && this.Camera.CameraZoneMode != EFightCameraZoneMode.Horizontal;
		}

		// Token: 0x06045DEF RID: 286191 RVA: 0x0124C9CB File Offset: 0x0124ABCB
		private bool IsYawZoneEnable()
		{
			return this.Camera.CameraZoneMode != EFightCameraZoneMode.None && this.Camera.CameraZoneMode != EFightCameraZoneMode.Horizontal;
		}

		// Token: 0x06045DF0 RID: 286192 RVA: 0x0124C9F0 File Offset: 0x0124ABF0
		private bool IsStandbyYawEnable()
		{
			if (this.BlockSet.Count > 0)
			{
				return false;
			}
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar)
			{
				return this.Camera.CharacterMoveEnterState == ECharMoveState.Soar || this.CharacterAnimationComponent.HasKuroRootMotion || this.CharacterInputComponent.IsInCameraDrivenAutoFlightMode() || (this.YawInputTime > 0f && this.YawRollbackTime > 0f && !this.IsYawRollback());
			}
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Vehicle)
			{
				return this.YawInputTime > 0f && this.YawRollbackTime > 0f && !this.IsYawRollback();
			}
			return this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor && (!this.IsStandByLargePitchAngle() || this.VehicleTagComponent.HasAnyTag(this.VehicleStandbyZone) || this.VehicleActorComponent.ActorVelocityProxy.Size() <= 5.0 || (this.YawInputTime > 0f && this.YawRollbackTime > 0f && !this.IsYawRollback()));
		}

		// Token: 0x06045DF1 RID: 286193 RVA: 0x0124CB10 File Offset: 0x0124AD10
		private bool IsStandbyPitchEnable()
		{
			if (this.BlockSet.Count > 0)
			{
				return false;
			}
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar)
			{
				return this.Camera.CharacterMoveEnterState == ECharMoveState.Soar || this.CharacterAnimationComponent.HasKuroRootMotion || this.CharacterInputComponent.IsInCameraDrivenAutoFlightMode() || (this.PitchRollbackTime > 0f && !this.IsPitchRollback());
			}
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Vehicle)
			{
				return this.PitchRollbackTime > 0f && !this.IsPitchRollback();
			}
			return this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor && (!this.IsStandByLargePitchAngle() || this.VehicleTagComponent.HasAnyTag(this.VehicleStandbyZone) || this.VehicleActorComponent.ActorVelocityProxy.Size() <= 5.0 || (this.PitchRollbackTime > 0f && !this.IsPitchRollback()));
		}

		// Token: 0x06045DF2 RID: 286194 RVA: 0x0124CC06 File Offset: 0x0124AE06
		private bool IsDeadYawEnable()
		{
			return this.Camera.CameraZoneMode != EFightCameraZoneMode.Soar || !this.CharacterInputComponent.IsInCameraDrivenAutoFlightMode();
		}

		// Token: 0x06045DF3 RID: 286195 RVA: 0x0124CC26 File Offset: 0x0124AE26
		private bool IsSoftYawEnable()
		{
			return (this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar || this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor) && this.IsYawInputEnable() && this.IsYawRollback();
		}

		// Token: 0x06045DF4 RID: 286196 RVA: 0x0124CC58 File Offset: 0x0124AE58
		private bool IsSoftPitchEnable()
		{
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar)
			{
				return !this.CharacterAnimationComponent.HasKuroRootMotion && this.IsPitchInputEnable() && this.IsPitchRollback();
			}
			return this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor && this.IsPitchInputEnable() && this.IsPitchRollback();
		}

		// Token: 0x06045DF5 RID: 286197 RVA: 0x0124CCB1 File Offset: 0x0124AEB1
		private bool IsEnableSoftYawAddAngle()
		{
			return this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar || this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor;
		}

		// Token: 0x06045DF6 RID: 286198 RVA: 0x0124CCD4 File Offset: 0x0124AED4
		private bool IsSoftYawAddAngle()
		{
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar)
			{
				return this.InputVector.Y < 0.0;
			}
			return this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor && this.InputVector.Y > 0.0;
		}

		// Token: 0x06045DF7 RID: 286199 RVA: 0x0124CD2C File Offset: 0x0124AF2C
		private bool IsDeadZoneTransitionToSoftZoneEnable()
		{
			return this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar || this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor;
		}

		// Token: 0x06045DF8 RID: 286200 RVA: 0x0124CD4D File Offset: 0x0124AF4D
		private bool IsDeadYawTransitionToSoftYawAddAngle(float deltaYaw)
		{
			return (this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar || this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor) && this.InputVector.Y > 0.0 && deltaYaw > 0f;
		}

		// Token: 0x06045DF9 RID: 286201 RVA: 0x0124CD8D File Offset: 0x0124AF8D
		private bool IsDeadYawTransitionToSoftYawMinusAngle(float deltaYaw)
		{
			return (this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar || this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor) && this.InputVector.Y < 0.0 && deltaYaw < 0f;
		}

		// Token: 0x06045DFA RID: 286202 RVA: 0x0124CDD0 File Offset: 0x0124AFD0
		private bool IsYawTransitionToForwardEnable()
		{
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar || this.Camera.CameraZoneMode == EFightCameraZoneMode.Vehicle)
			{
				return this.IsYawRollback();
			}
			return this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor && (this.IsYawRollback() || (this.CameraYawZoneState == CameraRotationZone.ECameraZoneState.InSoftZone && !Singleton<MathUtils>.Instance.IsNearlyZero(this.InputVector.Y, new double?(0.0001))));
		}

		// Token: 0x06045DFB RID: 286203 RVA: 0x0124CE4C File Offset: 0x0124B04C
		private bool IsPitchTransitionToForwardEnable()
		{
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar)
			{
				return this.CharacterAnimationComponent.HasKuroRootMotion || this.IsPitchRollback();
			}
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Vehicle)
			{
				return this.IsPitchRollback();
			}
			return this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor && (this.IsPitchRollback() || (this.CameraYawZoneState == CameraRotationZone.ECameraZoneState.InSoftZone && !Singleton<MathUtils>.Instance.IsNearlyZero(this.InputVector.X, new double?(0.0001))));
		}

		// Token: 0x06045DFC RID: 286204 RVA: 0x0124CEE0 File Offset: 0x0124B0E0
		private float GetYawSpeed()
		{
			float yaw = this.Camera.PlayerRotatorInGravity.Yaw;
			float yawInGravity = CameraUtility.GetYawInGravity(this.Camera.DesiredCamera.ArmRotation);
			float value = Singleton<MathUtils>.Instance.WrapAngle(yaw - yawInGravity);
			return Singleton<MathUtils>.Instance.Lerp(this.Camera.YawZoneSpeedMin, this.Camera.YawZoneSpeedMax, Singleton<MathUtils>.Instance.Clamp(Math.Abs(value) / this.YawDeadZoneMax, 0f, 1f));
		}

		// Token: 0x06045DFD RID: 286205 RVA: 0x0124CF63 File Offset: 0x0124B163
		private bool IsStandByPitchFreeLook()
		{
			return this.Camera.CameraZoneMode != EFightCameraZoneMode.Motor;
		}

		// Token: 0x06045DFE RID: 286206 RVA: 0x0124CF76 File Offset: 0x0124B176
		private bool IsStandByYawFreeLook()
		{
			return this.Camera.CameraZoneMode != EFightCameraZoneMode.Motor;
		}

		// Token: 0x06045DFF RID: 286207 RVA: 0x0124CF8C File Offset: 0x0124B18C
		private bool CheckValid()
		{
			EntityHandle characterEntityHandle = this.CharacterEntityHandle;
			if (characterEntityHandle == null || !characterEntityHandle.Valid)
			{
				return false;
			}
			CharacterInputComponent characterInputComponent = this.CharacterInputComponent;
			if (characterInputComponent == null || !characterInputComponent.Valid)
			{
				return false;
			}
			CharacterActorComponent characterActorComponent = this.CharacterActorComponent;
			if (characterActorComponent == null || !characterActorComponent.Valid)
			{
				return false;
			}
			CharacterGlideComponent characterGlideComponent = this.CharacterGlideComponent;
			if (characterGlideComponent == null || !characterGlideComponent.Valid)
			{
				return false;
			}
			CharacterAnimationComponent characterAnimationComponent = this.CharacterAnimationComponent;
			return characterAnimationComponent != null && characterAnimationComponent.Valid && (this.Camera.CameraZoneMode != EFightCameraZoneMode.Motor || this.IsVehicleValid());
		}

		// Token: 0x06045E00 RID: 286208 RVA: 0x0124D02F File Offset: 0x0124B22F
		private float GetLargePitchStandByAngle()
		{
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor)
			{
				return this.MotorStandByLargePitchAngle;
			}
			return 100f;
		}

		// Token: 0x06045E01 RID: 286209 RVA: 0x0124D04B File Offset: 0x0124B24B
		public float GetLargePitchStandByTime()
		{
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor)
			{
				return this.MotorStandByLargePitchTime;
			}
			return 0.5f;
		}

		// Token: 0x06045E02 RID: 286210 RVA: 0x0124D067 File Offset: 0x0124B267
		public bool IsPitchRollback()
		{
			return this.PitchRollbackTime >= this.Camera.PitchRollbackEnableTime;
		}

		// Token: 0x06045E03 RID: 286211 RVA: 0x0124D07F File Offset: 0x0124B27F
		private bool IsPitchInputEnable()
		{
			return this.PitchInputTime >= this.Camera.PitchInputEnableTime;
		}

		// Token: 0x06045E04 RID: 286212 RVA: 0x0124D097 File Offset: 0x0124B297
		private bool IsYawRollback()
		{
			return this.YawRollbackTime >= this.Camera.YawRollbackEnableTime;
		}

		// Token: 0x06045E05 RID: 286213 RVA: 0x0124D0AF File Offset: 0x0124B2AF
		public bool IsYawInputEnable()
		{
			return this.YawInputTime >= this.Camera.YawInputEnableTime;
		}

		// Token: 0x06045E06 RID: 286214 RVA: 0x0124D0C7 File Offset: 0x0124B2C7
		private bool IsStandByLargePitchAngle()
		{
			return this.StandByLargePitchAngle >= this.GetLargePitchStandByTime();
		}

		// Token: 0x06045E07 RID: 286215 RVA: 0x0124D0DC File Offset: 0x0124B2DC
		private bool IsHasPitchMovement()
		{
			CharacterGlideComponent characterGlideComponent = this.CharacterGlideComponent;
			if (characterGlideComponent != null && characterGlideComponent.Valid)
			{
				CharacterActorComponent characterActorComponent = this.CharacterActorComponent;
				if (characterActorComponent != null && characterActorComponent.Valid)
				{
					return this.CharacterGlideComponent.SoarBoostOn || !this.InputVector.IsNearlyZero(9.999999747378752E-05);
				}
			}
			return false;
		}

		// Token: 0x06045E08 RID: 286216 RVA: 0x0124D13F File Offset: 0x0124B33F
		public bool IsHasPitchUpMovement()
		{
			CharacterGlideComponent characterGlideComponent = this.CharacterGlideComponent;
			return characterGlideComponent != null && characterGlideComponent.Valid && this.InputVector.X < 0.0;
		}

		// Token: 0x06045E09 RID: 286217 RVA: 0x0124D170 File Offset: 0x0124B370
		public bool IsHasPitchHorizontalMovement()
		{
			CharacterGlideComponent characterGlideComponent = this.CharacterGlideComponent;
			if (characterGlideComponent != null && characterGlideComponent.Valid)
			{
				CharacterActorComponent characterActorComponent = this.CharacterActorComponent;
				if (characterActorComponent != null && characterActorComponent.Valid)
				{
					return this.CharacterGlideComponent.SoarBalanceOn;
				}
			}
			return false;
		}

		// Token: 0x06045E0A RID: 286218 RVA: 0x0124D1B0 File Offset: 0x0124B3B0
		public bool IsHasYawHorizontalMovement()
		{
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Motor && this.IsVehicleValid())
			{
				return !Singleton<MathUtils>.Instance.IsNearlyZero(this.VehicleActorComponent.ActorVelocityProxy.Size(), new double?((double)5)) && !Singleton<MathUtils>.Instance.IsNearlyZero(this.InputVector.Y, new double?(0.0001));
			}
			return !Singleton<MathUtils>.Instance.IsNearlyZero(this.InputVector.Y, new double?(0.0001));
		}

		// Token: 0x06045E0B RID: 286219 RVA: 0x0124D245 File Offset: 0x0124B445
		[NullableContext(1)]
		public void Lock(object control)
		{
			this.BlockSet.Add(control);
		}

		// Token: 0x06045E0C RID: 286220 RVA: 0x0124D254 File Offset: 0x0124B454
		[NullableContext(1)]
		public void Unlock(object control)
		{
			this.BlockSet.Remove(control);
		}

		// Token: 0x06045E0D RID: 286221 RVA: 0x0124D263 File Offset: 0x0124B463
		private bool IsVehicleValid()
		{
			EntityHandle vehicleEntityHandle = this.VehicleEntityHandle;
			return vehicleEntityHandle != null && vehicleEntityHandle.Valid;
		}

		// Token: 0x06045E0E RID: 286222 RVA: 0x0124D278 File Offset: 0x0124B478
		[Conditional("DEBUG")]
		public void DebugDrawZone()
		{
			float yaw = this.Camera.PlayerRotatorInGravity.Yaw;
			float pitch = this.Camera.PlayerRotatorInGravity.Pitch;
			if (this.Camera.CameraZoneMode == EFightCameraZoneMode.Soar)
			{
				global::Vector actorVelocityProxy = this.CharacterActorComponent.ActorVelocityProxy;
				Singleton<MathUtils>.Instance.LookRotationForwardFirst(actorVelocityProxy, global::Vector.UpVectorProxy, this.TmpQuat);
				this.TmpQuat.Rotator(this.TmpRotator);
				float pitch2 = this.TmpRotator.Pitch;
			}
		}

		// Token: 0x06045E0F RID: 286223 RVA: 0x0124D2F8 File Offset: 0x0124B4F8
		[Conditional("DEBUG")]
		private void DebugDrawYawSoftZone(float leftAngle, float rightAngle, float playerPitch, float playerYaw, FLinearColor color)
		{
			global::Vector vector = global::Vector.Create();
			float num = rightAngle - leftAngle;
			if (num < 0f)
			{
				num += 360f;
			}
			new Rotator(playerPitch, num / 2f + leftAngle + playerYaw, 0f).Vector(vector);
			UKismetSystemLibrary.D_DrawDebugCone(GlobalData.World, this.Camera.PlayerLocation.ToUeVector(false), vector.ToUeVector(false), 300f, MathCommon.UnwindDegrees(rightAngle - leftAngle) * 0.017453292f / 2f, 0f, 100, color, 0f, 1f);
		}

		// Token: 0x06045E10 RID: 286224 RVA: 0x0124D38C File Offset: 0x0124B58C
		[Conditional("DEBUG")]
		private void DrawCamera()
		{
			global::Vector vector = global::Vector.Create(this.Camera.PlayerLocation);
			global::Vector vector2 = global::Vector.Create();
			this.Camera.DesiredCamera.ArmRotation.Vector(vector2);
			vector2.Normalize(9.99999993922529E-09);
			vector2.MultiplyEqual(500.0);
			vector.AdditionEqual(vector2);
			UKismetSystemLibrary.D_DrawDebugArrow(this.Camera.Character.CharacterActorComponent.Actor, this.Camera.PlayerLocation.ToUeVector(false), vector.ToUeVector(false), 2000f, (this.CameraYawZoneState == CameraRotationZone.ECameraZoneState.InSoftZone || this.CameraYawZoneState == CameraRotationZone.ECameraZoneState.TransitionToForwardWithSoftZone) ? ColorUtils.LinearGreen : ColorUtils.LinearRed, 0f, 10f);
		}

		// Token: 0x06045E11 RID: 286225 RVA: 0x0124D450 File Offset: 0x0124B650
		public void Clear()
		{
			this.Camera = null;
			this.CharacterEntityHandle = null;
			this.CharacterInputComponent = null;
			this.CharacterActorComponent = null;
			this.CharacterGlideComponent = null;
			this.CharacterAnimationComponent = null;
			this.VehicleEntityHandle = null;
			this.VehicleActorComponent = null;
			this.VehicleTagComponent = null;
		}

		// Token: 0x0402720F RID: 160271
		private const int CAMERA_DIRECTION_LENGTH = 500;

		// Token: 0x04027210 RID: 160272
		private const int CAMERA_DIRECTION_ARROW_SIZE = 2000;

		// Token: 0x04027211 RID: 160273
		private const int INVALID_PITCH_THRESHOLD = 100;

		// Token: 0x04027212 RID: 160274
		private const float INVALID_PITCH_TIME = 0.5f;

		// Token: 0x04027213 RID: 160275
		[Nullable(1)]
		private readonly int[] VehicleStandbyZone = new int[]
		{
			GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.镜头保持"]
		};

		// Token: 0x04027214 RID: 160276
		private float MotorStandByLargePitchAngle = 85f;

		// Token: 0x04027215 RID: 160277
		private float MotorStandByLargePitchTime = 2f;

		// Token: 0x04027216 RID: 160278
		private FightCameraLogicComponent Camera;

		// Token: 0x04027217 RID: 160279
		private EntityHandle CharacterEntityHandle;

		// Token: 0x04027218 RID: 160280
		private CharacterInputComponent CharacterInputComponent;

		// Token: 0x04027219 RID: 160281
		private CharacterActorComponent CharacterActorComponent;

		// Token: 0x0402721A RID: 160282
		private CharacterGlideComponent CharacterGlideComponent;

		// Token: 0x0402721B RID: 160283
		private CharacterAnimationComponent CharacterAnimationComponent;

		// Token: 0x0402721C RID: 160284
		private EntityHandle VehicleEntityHandle;

		// Token: 0x0402721D RID: 160285
		private VehicleActorComponent VehicleActorComponent;

		// Token: 0x0402721E RID: 160286
		private VehicleTagComponent VehicleTagComponent;

		// Token: 0x0402721F RID: 160287
		private CameraRotationZone.ECameraZoneState CameraPitchZoneState;

		// Token: 0x04027220 RID: 160288
		private CameraRotationZone.ECameraZoneState CameraYawZoneState;

		// Token: 0x04027221 RID: 160289
		private float StandByLargePitchAngle;

		// Token: 0x04027222 RID: 160290
		private float YawInputTime;

		// Token: 0x04027223 RID: 160291
		private float YawRollbackTime;

		// Token: 0x04027224 RID: 160292
		private float YawSoftZoneMin;

		// Token: 0x04027225 RID: 160293
		private float YawSoftZoneMax;

		// Token: 0x04027226 RID: 160294
		private float YawDeadZoneMin;

		// Token: 0x04027227 RID: 160295
		private float YawDeadZoneMax;

		// Token: 0x04027228 RID: 160296
		private float PitchInputTime;

		// Token: 0x04027229 RID: 160297
		private float PitchRollbackTime;

		// Token: 0x0402722A RID: 160298
		private float PitchSoftZoneMin;

		// Token: 0x0402722B RID: 160299
		private float PitchSoftZoneMax;

		// Token: 0x0402722C RID: 160300
		private float PitchDeadZoneMin;

		// Token: 0x0402722D RID: 160301
		private float PitchDeadZoneMax;

		// Token: 0x0402722E RID: 160302
		[Nullable(1)]
		private readonly global::Vector InputVector = global::Vector.Create();

		// Token: 0x0402722F RID: 160303
		[Nullable(1)]
		private readonly global::Vector TmpVector = global::Vector.Create();

		// Token: 0x04027230 RID: 160304
		[Nullable(1)]
		private readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x04027231 RID: 160305
		[Nullable(1)]
		private readonly Rotator TmpRotator = Rotator.Create();

		// Token: 0x04027232 RID: 160306
		[Nullable(1)]
		private readonly Rotator TmpRotator1 = Rotator.Create();

		// Token: 0x04027233 RID: 160307
		[Nullable(1)]
		private readonly HashSet<object> BlockSet = new HashSet<object>();

		// Token: 0x04027234 RID: 160308
		private readonly bool EnableDebug;

		// Token: 0x0200CCB9 RID: 52409
		[NullableContext(0)]
		private enum ECameraZoneState
		{
			// Token: 0x0403ECA4 RID: 257188
			Standby,
			// Token: 0x0403ECA5 RID: 257189
			InDeadZone,
			// Token: 0x0403ECA6 RID: 257190
			InSoftZone,
			// Token: 0x0403ECA7 RID: 257191
			DeadZoneTransitionToSoftZone,
			// Token: 0x0403ECA8 RID: 257192
			TransitionToForward,
			// Token: 0x0403ECA9 RID: 257193
			TransitionToForwardWithSoftZone
		}
	}
}
