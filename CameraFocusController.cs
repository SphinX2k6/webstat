using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;

// Token: 0x02000E0F RID: 3599
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(true)]
public class CameraFocusController : CameraControllerBase<EFightCameraFocus>, ICanGetConfigMapValue
{
	// Token: 0x060054DE RID: 21726 RVA: 0x000D38BA File Offset: 0x000D1ABA
	public CameraFocusController(FightCameraLogicComponent camera) : base(camera)
	{
	}

	// Token: 0x060054DF RID: 21727 RVA: 0x000D38F6 File Offset: 0x000D1AF6
	public override string Name()
	{
		return "FocusController";
	}

	// Token: 0x060054E0 RID: 21728 RVA: 0x000D3900 File Offset: 0x000D1B00
	protected override void OnInit()
	{
		base.SetConfigMap(EFightCameraFocus.臂旋转Yaw过渡最小速度, "RelativeRotationLagYawSpeedMin");
		base.SetConfigMap(EFightCameraFocus.臂旋转Yaw过渡最大速度, "RelativeRotationLagYawSpeedMax");
		base.SetConfigMap(EFightCameraFocus.臂旋转Yaw过渡与目标Yaw角度最大差值, "RelativeRotationLagYawAngleRange");
		base.SetCurveConfigMap(EFightCameraFocus.臂旋转Yaw过渡与目标Yaw角度最大差值, "RelativeRotationLagYawCurve");
		base.SetConfigMap(EFightCameraFocus.臂旋转Pitch过渡最小速度, "RelativeRotationLagPitchSpeedMin");
		base.SetConfigMap(EFightCameraFocus.臂旋转Pitch过渡最大速度, "RelativeRotationLagPitchSpeedMax");
		base.SetConfigMap(EFightCameraFocus.臂旋转Pitch过渡与目标Pitch角度最大差值, "RelativeRotationLagPitchAngleRange");
		base.SetCurveConfigMap(EFightCameraFocus.臂旋转Pitch过渡与目标Pitch角度最大差值, "RelativeRotationLagPitchCurve");
		base.SetConfigMap(EFightCameraFocus.臂旋转过渡速度最小系数_目标距离_, "RelativeRotationLagRatioMin");
		base.SetConfigMap(EFightCameraFocus.臂旋转过渡速度最大系数_目标距离_, "RelativeRotationLagRatioMax");
		base.SetConfigMap(EFightCameraFocus.臂旋转过渡速度最小距离_目标距离_, "RelativeRotationLagDistanceRangeMin");
		base.SetConfigMap(EFightCameraFocus.臂旋转过渡速度最大距离_目标距离_, "RelativeRotationLagDistanceRangeMax");
		base.SetCurveConfigMap(EFightCameraFocus.臂旋转过渡速度最大距离_目标距离_, "RelativeRotationLagRatioCurve");
		base.SetConfigMap(EFightCameraFocus.强锁定_启动左右对峙, "YawSignAdaptionOn");
		base.SetConfigMap(EFightCameraFocus.强锁定_左右对峙_交换角度, "YawSignAdaptionThreshold");
		base.SetConfigMap(EFightCameraFocus.强锁定_左右对峙_交换冷却, "YawSignAdaptionCooldown");
		base.SetConfigMap(EFightCameraFocus.强锁定_左右对峙_启动距离阈值, "YawSignAdaptionDistanceThreshold");
		base.SetConfigMap(EFightCameraFocus.强锁定_左右对峙_锁定方向, "YawSignAdaptionLockDirection");
		base.SetConfigMap(EFightCameraFocus.软锁定_镜头偏角最小值, "RelativeYawSoftMin");
		base.SetConfigMap(EFightCameraFocus.软锁定_镜头偏角最大值, "RelativeYawSoftMax");
		base.SetConfigMap(EFightCameraFocus.软锁定_镜头输入缓冲时间, "SoftUnlockInputTime");
		base.SetConfigMap(EFightCameraFocus.软锁定_镜头Yaw输入启动速度, "SoftUnlockInputYawMinSpeed");
		base.SetConfigMap(EFightCameraFocus.软锁定_镜头Pitch输入启动速度, "SoftUnlockInputPitchMinSpeed");
		base.SetConfigMap(EFightCameraFocus.软锁定_锁定时相机臂偏移Y, "CameraOffsetSoft");
		base.SetConfigMap(EFightCameraFocus.强锁定_锁定时相机臂偏移Y, "CameraOffset");
		base.SetConfigMap(EFightCameraFocus.强锁定_输入灵敏度Yaw, "HardLockInputYawSensitivity");
		base.SetConfigMap(EFightCameraFocus.强锁定_输入灵敏度Pitch, "HardLockInputPitchSensitivity");
		base.SetConfigMap(EFightCameraFocus.强锁定_输入灵敏度Yaw_手柄, "HardLockInputYawSensitivityGamepad");
		base.SetConfigMap(EFightCameraFocus.强锁定_输入灵敏度Pitch_手柄, "HardLockInputPitchSensitivityGamepad");
		base.SetConfigMap(EFightCameraFocus.软锁定_输入灵敏度Yaw, "SoftLockInputYawSensitivity");
		base.SetConfigMap(EFightCameraFocus.软锁定_输入灵敏度Pitch, "SoftLockInputPitchSensitivity");
		base.SetConfigMap(EFightCameraFocus.软锁定_输入灵敏度Yaw_手柄, "SoftLockInputYawSensitivityGamepad");
		base.SetConfigMap(EFightCameraFocus.软锁定_输入灵敏度Pitch_手柄, "SoftLockInputPitchSensitivityGamepad");
		base.SetConfigMap(EFightCameraFocus.强锁定_切换目标_输入衰减律, "ChangeShowTargetDamping");
		base.SetConfigMap(EFightCameraFocus.强锁定_切换目标_角度系数, "ChangeShowTargetAngleCoefficient");
		base.SetConfigMap(EFightCameraFocus.强锁定_切换目标_距离系数, "ChangeShowTargetDistCoefficient");
		base.SetConfigMap(EFightCameraFocus.强锁定_镜头偏角最小值, "RelativeYawHardMin");
		base.SetConfigMap(EFightCameraFocus.强锁定_镜头偏角最大值, "RelativeYawHardMax");
		base.SetConfigMap(EFightCameraFocus.强锁定_镜头俯仰角最小值, "RelativePitchHardMin");
		base.SetConfigMap(EFightCameraFocus.强锁定_镜头俯仰角最大值, "RelativePitchHardMax");
		base.SetConfigMap(EFightCameraFocus.软锁定_镜头Yaw输入解锁速度, "SoftUnlockYawSpeed");
		base.SetConfigMap(EFightCameraFocus.软锁定_镜头Pitch输入解锁速度, "SoftUnlockPitchSpeed");
		base.SetConfigMap(EFightCameraFocus.强锁定_切换目标_启动速度, "ChangeShowTargetSensitivity");
		base.SetConfigMap(EFightCameraFocus.强锁定_切换目标_启动速度_手柄, "ChangeShowTargetSensitivityGamepad");
		base.RegisterPairConfigKey(EFightCameraFocus.臂旋转Yaw过渡最小速度, EFightCameraFocus.臂旋转Yaw过渡最大速度, true);
		base.RegisterPairConfigKey(EFightCameraFocus.臂旋转Pitch过渡最小速度, EFightCameraFocus.臂旋转Pitch过渡最大速度, true);
		base.RegisterPairConfigKey(EFightCameraFocus.软锁定_镜头偏角最小值, EFightCameraFocus.软锁定_镜头偏角最大值, true);
		base.RegisterPairConfigKey(EFightCameraFocus.强锁定_镜头偏角最小值, EFightCameraFocus.强锁定_镜头偏角最大值, true);
		base.RegisterPairConfigKey(EFightCameraFocus.强锁定_镜头俯仰角最小值, EFightCameraFocus.强锁定_镜头俯仰角最大值, true);
		base.RegisterPairConfigKey(EFightCameraFocus.臂旋转过渡速度最小距离_目标距离_, EFightCameraFocus.臂旋转过渡速度最大距离_目标距离_, true);
		base.RegisterPairConfigKey(EFightCameraFocus.臂旋转过渡速度最小系数_目标距离_, EFightCameraFocus.臂旋转过渡速度最大系数_目标距离_, true);
	}

	// Token: 0x060054E1 RID: 21729 RVA: 0x000D3B8C File Offset: 0x000D1D8C
	protected override void OnEnable()
	{
		this.Camera.CameraAutoController.EnableForce(this);
		this.Camera.CameraSidestepController.Lock(this);
		this.AddCameraOffsetY = new float?(0f);
		Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
	}

	// Token: 0x060054E2 RID: 21730 RVA: 0x000D3BE4 File Offset: 0x000D1DE4
	protected override void OnDisable()
	{
		Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
		this.Camera.CameraAutoController.DisableForce(this);
		this.Camera.CameraSidestepController.Unlock(this);
		this.ExpectedYawSign = 0f;
		this.PrevChangeYawSignTime = 0f;
		this.SumYawPitchInput.Reset();
	}

	// Token: 0x060054E3 RID: 21731 RVA: 0x000D3C4D File Offset: 0x000D1E4D
	protected override bool UpdateCustomEnableCondition()
	{
		return this.HasTarget() && this.Camera.CharacterEntityHandle.IsInit;
	}

	// Token: 0x060054E4 RID: 21732 RVA: 0x000D3C6C File Offset: 0x000D1E6C
	private bool HasTarget()
	{
		if (this.Camera.TargetEntity == null)
		{
			FightCameraLogicComponent camera = this.Camera;
			return camera != null && camera.IsSpecificLockTarget && camera.SpecificLockTargetType == ECameraSpecificLockType.Location;
		}
		return true;
	}

	// Token: 0x060054E5 RID: 21733 RVA: 0x000D3CA5 File Offset: 0x000D1EA5
	protected override void UpdateInternal(float deltaSeconds)
	{
		this.UpdateSoftUnlockState((double)deltaSeconds);
		this.UpdateArmRotation(deltaSeconds);
		this.UpdateShowTarget((double)deltaSeconds);
	}

	// Token: 0x060054E6 RID: 21734 RVA: 0x000D3CC0 File Offset: 0x000D1EC0
	private void UpdateSoftUnlockState(double deltaSeconds)
	{
		if (!this.HasTarget() || !this.Camera.IsTargetLocationValid)
		{
			return;
		}
		ValueTuple<float, float> cameraInput = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterInputComponent>().GetCameraInput();
		float num = cameraInput.Item1;
		float num2 = cameraInput.Item2;
		num *= (Singleton<Info>.Instance.IsInGamepad() ? this.SoftLockInputYawSensitivityGamepad : this.SoftLockInputYawSensitivity);
		num2 *= (Singleton<Info>.Instance.IsInGamepad() ? this.SoftLockInputPitchSensitivityGamepad : this.SoftLockInputPitchSensitivity);
		if (Math.Abs(num) > this.SoftUnlockInputYawMinSpeed || Math.Abs(num2) > this.SoftUnlockInputPitchMinSpeed)
		{
			this.SoftUnlockInputRemainTime = (double)this.SoftUnlockInputTime;
		}
		if (this.SoftUnlockInputRemainTime <= 0.0)
		{
			return;
		}
		this.SoftUnlockInputRemainTime -= deltaSeconds;
	}

	// Token: 0x060054E7 RID: 21735 RVA: 0x000D3D90 File Offset: 0x000D1F90
	private unsafe void UpdateArmRotation(float deltaSeconds)
	{
		if (!this.HasTarget() || !this.Camera.IsTargetLocationValid)
		{
			return;
		}
		if (this.Camera.IsModifiedArmRotationPitch && this.Camera.IsModifiedArmRotationYaw)
		{
			return;
		}
		ValueTuple<float, float> cameraInput = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterInputComponent>().GetCameraInput();
		float item = cameraInput.Item1;
		float item2 = cameraInput.Item2;
		FightCameraLogicComponent camera = this.Camera;
		int num = 2;
		List<int> list = new List<int>(num);
		CollectionsMarshal.SetCount<int>(list, num);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int num2 = 0;
		*span[num2] = GameplayTagDefine.EGameplayTagId["行为状态.方向状态.注视方向"];
		num2++;
		*span[num2] = GameplayTagDefine.EGameplayTagId["行为状态.方向状态.看向方向"];
		bool flag = camera.ContainsAnyTag(list, false);
		bool isSoftLockEnable = !flag && base.CameraModel.IsSoftLockEnable() && !this.ShouldSoftUnlock() && !this.CanMoveCameraInSoftLock();
		Vector playerLocation = this.Camera.PlayerLocation;
		this.Camera.TargetLocation.Subtraction(playerLocation, this.TargetOffset);
		this.UpdateTargetYaw(deltaSeconds, flag || this.Camera.IsSpecificLockTarget, isSoftLockEnable, item);
		this.UpdateTargetPitch(deltaSeconds, flag || this.Camera.IsSpecificLockTarget, isSoftLockEnable, item2);
	}

	// Token: 0x060054E8 RID: 21736 RVA: 0x000D3ED8 File Offset: 0x000D20D8
	private void UpdateTargetYaw(float deltaSeconds, bool isLockSight, bool isSoftLockEnable, float inputYaw)
	{
		if (this.Camera.IsModifiedArmRotationYaw)
		{
			return;
		}
		this.Camera.IsModifiedArmRotationYaw = true;
		float value = this.AddCameraOffsetY.GetValueOrDefault();
		if (this.AddCameraOffsetY == null)
		{
			value = 0f;
			this.AddCameraOffsetY = new float?(value);
		}
		float num = 0f;
		bool flag = false;
		float min = 0f;
		float max = 0f;
		this.TargetRotator.Yaw = (float)(Math.Atan2(this.TargetOffset.Y, this.TargetOffset.X) * 57.295780181884766);
		float num2 = Singleton<MathUtils>.Instance.WrapAngle(this.Camera.CameraRotation.Yaw - this.TargetRotator.Yaw);
		float num3 = (float)((num2 >= 0f) ? 1 : -1);
		this.TargetOffset.Rotation(this.TmpRotator);
		float yaw = Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.TmpRotator, this.Camera.GravityInverseQuat, this.TmpRotator).Yaw;
		float yaw2 = Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.CameraRotation, this.Camera.GravityInverseQuat, this.TmpRotator).Yaw;
		float yaw3 = Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.CurrentCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator).Yaw;
		if (!this.Camera.IsInNormalGravityMode())
		{
			this.TargetRotator.Yaw = yaw;
			num2 = Singleton<MathUtils>.Instance.WrapAngle(yaw2 - yaw);
			num3 = (float)((num2 >= 0f) ? 1 : -1);
		}
		if (isLockSight)
		{
			if (this.YawSignAdaptionOn != 0f)
			{
				float num4 = 0f;
				float num5 = inputYaw * (Singleton<Info>.Instance.IsInGamepad() ? this.HardLockInputYawSensitivityGamepad : this.HardLockInputYawSensitivity);
				float num6 = (float)((num5 >= 0f) ? 1 : -1);
				if (this.ExpectedYawSign == 0f)
				{
					this.ExpectedYawSign = num3;
					this.PrevChangeYawSignTime = (float)Singleton<Time>.Instance.Now;
				}
				if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.YawSignAdaptionLockDirection, -1.0, null))
				{
					this.ExpectedYawSign = -1f;
				}
				else if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.YawSignAdaptionLockDirection, 1.0, null))
				{
					this.ExpectedYawSign = 1f;
				}
				else if (Singleton<Time>.Instance.Now > (double)(this.PrevChangeYawSignTime + this.YawSignAdaptionCooldown) && this.ExpectedYawSign != num3)
				{
					this.ExpectedYawSign = num3;
					this.PrevChangeYawSignTime = (float)Singleton<Time>.Instance.Now;
				}
				float num7 = 0f;
				float num8 = 180f;
				if (Singleton<MathUtils>.Instance.Square((double)this.YawSignAdaptionDistanceThreshold) < this.TargetOffset.SizeSquared())
				{
					num7 = this.RelativeYawHardMin;
					num8 = this.RelativeYawHardMax;
				}
				if (Math.Abs(num2) < num7)
				{
					num4 += this.ExpectedYawSign * num7;
					if (num6 == num3)
					{
						num4 += num5;
					}
				}
				else if (Math.Abs(num2) > num8)
				{
					num4 += this.ExpectedYawSign * num8;
					if (num6 != num3)
					{
						num4 += num5;
					}
				}
				else
				{
					float num9 = num2 + num5;
					if (num3 * num9 < 0f)
					{
						if (num3 == num6 && num8 != 180f)
						{
							float val = Singleton<MathUtils>.Instance.WrapAngle(this.TargetRotator.Yaw + this.ExpectedYawSign * num8);
							float val2 = Singleton<MathUtils>.Instance.WrapAngle(this.TargetRotator.Yaw + this.ExpectedYawSign * num7);
							max = Math.Max(val2, val);
							min = Math.Min(val2, val);
							flag = true;
						}
						if (num3 != num6 && num7 != 0f)
						{
							double val3 = (double)Singleton<MathUtils>.Instance.WrapAngle(this.TargetRotator.Yaw + this.ExpectedYawSign * num8);
							double val4 = (double)Singleton<MathUtils>.Instance.WrapAngle(this.TargetRotator.Yaw + this.ExpectedYawSign * num7);
							max = (float)Math.Max(val4, val3);
							min = (float)Math.Min(val4, val3);
							flag = true;
						}
					}
					num4 += num9;
				}
				num4 = Singleton<MathUtils>.Instance.Clamp(num4, num2 - 179f, num2 + 179f);
				this.TargetRotator.Yaw = Singleton<MathUtils>.Instance.WrapAngle(this.TargetRotator.Yaw + num4);
				num = num3 * this.CameraOffset;
			}
		}
		else
		{
			if (isSoftLockEnable)
			{
				CharacterLockOnComponent component = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterLockOnComponent>();
				if (component != null && component != null)
				{
					EntityHandle showTarget = component.ShowTarget;
					if (((showTarget != null) ? new bool?(showTarget.Valid) : null).GetValueOrDefault())
					{
						if (Math.Abs(num2) < this.RelativeYawSoftMin)
						{
							this.TargetRotator.Yaw += num3 * this.RelativeYawSoftMin;
						}
						else if (Math.Abs(num2) > this.RelativeYawSoftMax)
						{
							this.TargetRotator.Yaw += num3 * this.RelativeYawSoftMax;
						}
						else
						{
							this.TargetRotator.Yaw = yaw2;
						}
					}
				}
			}
			else
			{
				this.TargetRotator.Yaw = yaw3;
			}
			num = num3 * this.CameraOffsetSoft;
		}
		float num10 = Math.Abs(num - this.AddCameraOffsetY.Value);
		if (num10 > 100f * deltaSeconds)
		{
			this.AddCameraOffsetY = new float?(Singleton<MathUtils>.Instance.Lerp(this.AddCameraOffsetY.Value, num, 100f * deltaSeconds / num10));
		}
		else
		{
			this.AddCameraOffsetY = new float?(num);
		}
		float num11 = Singleton<MathUtils>.Instance.Lerp(this.RelativeRotationLagRatioMin, this.RelativeRotationLagRatioMax, this.RelativeRotationLagRatioCurve.GetCurrentValue((float)((this.TargetOffset.Size2D() - (double)this.RelativeRotationLagDistanceRangeMin) / (double)(this.RelativeRotationLagDistanceRangeMax - this.RelativeRotationLagDistanceRangeMin))));
		float num12 = Singleton<MathUtils>.Instance.Lerp(this.RelativeRotationLagYawSpeedMin, this.RelativeRotationLagYawSpeedMax, this.RelativeRotationLagYawCurve.GetCurrentValue(Math.Abs(num2) / this.RelativeRotationLagYawAngleRange));
		if (this.Camera.IsInNormalGravityMode())
		{
			this.Camera.DesiredCamera.ArmRotation.Yaw = Singleton<MathUtils>.Instance.RotatorAxisInterpTo(this.Camera.CurrentCamera.ArmRotation.Yaw, this.TargetRotator.Yaw, deltaSeconds, num11 * num12);
		}
		else
		{
			CameraUtility.SetYawInGravity(this.Camera.DesiredCamera.ArmRotation, (double)Singleton<MathUtils>.Instance.RotatorAxisInterpTo(yaw3, this.TargetRotator.Yaw, deltaSeconds, num11 * num12), this.Camera.DesiredCamera.ArmRotation);
		}
		if (flag)
		{
			this.Camera.DesiredCamera.ArmRotation.Yaw = Singleton<MathUtils>.Instance.Clamp(this.Camera.DesiredCamera.ArmRotation.Yaw, min, max);
		}
	}

	// Token: 0x060054E9 RID: 21737 RVA: 0x000D45D8 File Offset: 0x000D27D8
	private void UpdateTargetPitch(float deltaSeconds, bool isLockSight, bool isSoftLockEnable, float inputPitch)
	{
		if (this.Camera.IsModifiedArmRotationPitch)
		{
			return;
		}
		this.Camera.IsModifiedArmRotationPitch = true;
		this.TargetRotator.Pitch = this.Camera.AdjustPitch(this.TargetOffset);
		float num = Singleton<MathUtils>.Instance.WrapAngle(this.Camera.CameraRotation.Pitch - this.TargetRotator.Pitch);
		float num2 = (float)((num >= 0f) ? 1 : -1);
		float pitch = Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.CameraRotation, this.Camera.GravityInverseQuat, this.TmpRotator).Pitch;
		float pitch2 = Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.Camera.CurrentCamera.ArmRotation, this.Camera.GravityInverseQuat, this.TmpRotator).Pitch;
		if (!this.Camera.IsInNormalGravityMode())
		{
			num = Singleton<MathUtils>.Instance.WrapAngle(pitch - this.TargetRotator.Pitch);
			num2 = (float)((num >= 0f) ? 1 : -1);
		}
		if (isLockSight)
		{
			if (this.YawSignAdaptionOn != 0f)
			{
				double num3 = 0.0;
				double num4 = (double)inputPitch;
				num4 *= (double)(Singleton<Info>.Instance.IsInGamepad() ? this.HardLockInputPitchSensitivityGamepad : this.HardLockInputPitchSensitivity);
				num4 = -num4;
				double num5 = (double)((num4 >= 0.0) ? 1 : -1);
				if (Math.Abs(num) < this.RelativePitchHardMin)
				{
					num3 += (double)(num2 * this.RelativePitchHardMin);
					if (num5 == (double)num2)
					{
						num3 += num4;
					}
				}
				else if (Math.Abs(num) > this.RelativePitchHardMax)
				{
					num3 += (double)(num2 * this.RelativePitchHardMax);
					if (num5 != (double)num2)
					{
						num3 += num4;
					}
				}
				else
				{
					double num6 = (double)num + num4;
					num3 += num6;
				}
				num3 = Singleton<MathUtils>.Instance.Clamp(num3, (double)(num - 179f), (double)(num + 179f));
				this.TargetRotator.Pitch = (float)Singleton<MathUtils>.Instance.WrapAngle((double)this.TargetRotator.Pitch + num3);
			}
		}
		else if (!isSoftLockEnable)
		{
			if (this.Camera.IsInNormalGravityMode())
			{
				this.TargetRotator.Pitch = this.Camera.CurrentCamera.ArmRotation.Pitch;
			}
			else
			{
				this.TargetRotator.Pitch = pitch2;
			}
		}
		float interpSpeed = Singleton<MathUtils>.Instance.Lerp(this.RelativeRotationLagPitchSpeedMin, this.RelativeRotationLagPitchSpeedMax, this.RelativeRotationLagPitchCurve.GetCurrentValue(Math.Abs(num) / this.RelativeRotationLagPitchAngleRange));
		if (this.Camera.IsInNormalGravityMode())
		{
			this.Camera.DesiredCamera.ArmRotation.Pitch = Singleton<MathUtils>.Instance.RotatorAxisInterpTo(this.Camera.CurrentCamera.ArmRotation.Pitch, this.TargetRotator.Pitch, deltaSeconds, interpSpeed);
			return;
		}
		CameraUtility.SetPitchInGravity(this.Camera.DesiredCamera.ArmRotation, (double)Singleton<MathUtils>.Instance.RotatorAxisInterpTo(pitch2, this.TargetRotator.Pitch, deltaSeconds, interpSpeed), this.Camera.DesiredCamera.ArmRotation);
	}

	// Token: 0x060054EA RID: 21738 RVA: 0x000D48E8 File Offset: 0x000D2AE8
	private void UpdateShowTarget(double deltaSeconds)
	{
		if (!this.Camera.ContainsTag(GameplayTagDefine.EGameplayTagId["行为状态.方向状态.注视方向"], false))
		{
			this.SumYawPitchInput.Reset();
			this.FirstInput = true;
			return;
		}
		ValueTuple<float, float> cameraInput = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterInputComponent>().GetCameraInput();
		float item = cameraInput.Item1;
		float item2 = cameraInput.Item2;
		if (item == 0f && item2 == 0f)
		{
			this.SumYawPitchInput.Reset();
			this.FirstInput = true;
			return;
		}
		double num = (double)(-(double)item2);
		double num2 = (double)(Singleton<Info>.Instance.IsInGamepad() ? this.ChangeShowTargetSensitivityGamepad : this.ChangeShowTargetSensitivity) * deltaSeconds;
		if ((double)item * this.SumYawPitchInput.X + num * this.SumYawPitchInput.Y <= 0.0)
		{
			this.FirstInput = true;
			this.SumYawPitchInput.Set((double)item * num2, num * num2);
		}
		else
		{
			this.SumYawPitchInput.X += (double)item * num2;
			this.SumYawPitchInput.Y += num * num2;
		}
		double num3 = this.SumYawPitchInput.SizeSquared();
		if (num3 > (this.FirstInput ? 0.25 : 1.0))
		{
			double num4 = Math.Sqrt(num3);
			this.SumYawPitchInput.DivisionEqual((double)((float)num4));
			this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterLockOnComponent>().ChangeShowTarget(this.SumYawPitchInput, this.ChangeShowTargetAngleCoefficient, this.ChangeShowTargetDistCoefficient);
			this.SumYawPitchInput.MultiplyEqual((double)((float)(num4 - (double)(this.FirstInput ? 0.5f : 1f))));
			this.FirstInput = false;
		}
		this.SumYawPitchInput.MultiplyEqual((double)((float)Math.Pow((double)(1f - this.ChangeShowTargetDamping), deltaSeconds * 60.0)));
	}

	// Token: 0x060054EB RID: 21739 RVA: 0x000D4ACC File Offset: 0x000D2CCC
	protected override void UpdateDeactivateInternal(float deltaSeconds)
	{
		this.ClearUnlockInputRemainTime();
		if (this.AddCameraOffsetY == null)
		{
			return;
		}
		int num = 0;
		float num2 = Math.Abs((float)num - this.AddCameraOffsetY.Value);
		if (num2 > 100f * deltaSeconds)
		{
			this.AddCameraOffsetY = new float?(Singleton<MathUtils>.Instance.Lerp(this.AddCameraOffsetY.Value, (float)num, 100f * deltaSeconds / num2));
			return;
		}
		this.AddCameraOffsetY = null;
	}

	// Token: 0x060054EC RID: 21740 RVA: 0x000D4B48 File Offset: 0x000D2D48
	private void OnCharUseSkill(int charId, int skillId, bool isAutonomousProxy)
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		Entity entity = (baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null;
		int? num = (entity != null) ? new int?(entity.Id) : null;
		if (!(charId == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
		if (component != null && component.Valid)
		{
			Skill currentSkill = component.CurrentSkill;
			if (currentSkill != null && currentSkill.SkillInfo.IsLockOn)
			{
				this.ClearUnlockInputRemainTime();
				return;
			}
		}
	}

	// Token: 0x060054ED RID: 21741 RVA: 0x000D4BD4 File Offset: 0x000D2DD4
	public bool ShouldSoftUnlock()
	{
		ValueTuple<float, float> cameraInput = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterInputComponent>().GetCameraInput();
		float num = cameraInput.Item1;
		float num2 = cameraInput.Item2;
		num *= (Singleton<Info>.Instance.IsInGamepad() ? this.SoftLockInputYawSensitivityGamepad : this.SoftLockInputYawSensitivity);
		num2 *= (Singleton<Info>.Instance.IsInGamepad() ? this.SoftLockInputPitchSensitivityGamepad : this.SoftLockInputPitchSensitivity);
		return Math.Abs(num) > this.SoftUnlockYawSpeed || Math.Abs(num2) > this.SoftUnlockPitchSpeed;
	}

	// Token: 0x060054EE RID: 21742 RVA: 0x000D4C60 File Offset: 0x000D2E60
	public bool CanMoveCameraInSoftLock()
	{
		return this.SoftUnlockInputRemainTime > 0.0;
	}

	// Token: 0x060054EF RID: 21743 RVA: 0x000D4C73 File Offset: 0x000D2E73
	private void ClearUnlockInputRemainTime()
	{
		this.SoftUnlockInputRemainTime = 0.0;
	}

	// Token: 0x060054F0 RID: 21744 RVA: 0x000D4C84 File Offset: 0x000D2E84
	public override string GetConfigMapValue(int key)
	{
		return base.GetConfigMapValue((EFightCameraFocus)key);
	}

	// Token: 0x060054F1 RID: 21745 RVA: 0x000D4C90 File Offset: 0x000D2E90
	public override void PostProcessConfig(Dictionary<EFightCameraFocus, float> config, Dictionary<EFightCameraFocus, CurveBase> curveConfig)
	{
		base.PostProcessConfig(config, curveConfig);
		if (this.RelativeYawHardMin < 0f || this.RelativeYawHardMin > 180f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Controller;
			ELogAuthor author = ELogAuthor.LJM;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(44, 2);
			defaultInterpolatedStringHandler.AppendLiteral("锁定镜头配置错误，强锁定-镜头偏角最小值");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.RelativeYawHardMin);
			defaultInterpolatedStringHandler.AppendLiteral("不在0-180之间或者大于强锁定-镜头偏角最大值");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.RelativeYawHardMax);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (this.RelativeYawHardMax < 0f || this.RelativeYawHardMax > 180f)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Controller;
			ELogAuthor author2 = ELogAuthor.LJM;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(44, 2);
			defaultInterpolatedStringHandler.AppendLiteral("锁定镜头配置错误，强锁定-镜头偏角最大值");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.RelativeYawHardMax);
			defaultInterpolatedStringHandler.AppendLiteral("不在0-180之间或者小于强锁定-镜头偏角最小值");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.RelativeYawHardMin);
			instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (this.RelativePitchHardMin < 0f || this.RelativePitchHardMin > 180f)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Controller;
			ELogAuthor author3 = ELogAuthor.LJM;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 2);
			defaultInterpolatedStringHandler.AppendLiteral("锁定镜头配置错误，强锁定-镜头俯仰角最小值");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.RelativePitchHardMin);
			defaultInterpolatedStringHandler.AppendLiteral("不在0-180之间或者大于强锁定-镜头俯仰角最大值");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.RelativePitchHardMax);
			instance3.Error(module3, author3, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (this.RelativePitchHardMax < 0f || this.RelativePitchHardMax > 180f)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Controller;
			ELogAuthor author4 = ELogAuthor.LJM;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 2);
			defaultInterpolatedStringHandler.AppendLiteral("锁定镜头配置错误，强锁定-镜头俯仰角最大值");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.RelativePitchHardMax);
			defaultInterpolatedStringHandler.AppendLiteral("不在0-180之间或者小于强锁定-镜头俯仰角最小值");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.RelativePitchHardMin);
			instance4.Error(module4, author4, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x060054F2 RID: 21746 RVA: 0x000D4E84 File Offset: 0x000D3084
	[NullableContext(0)]
	public override bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 10:
			{
				char c = key[0];
				if (c != 'F')
				{
					if (c == 'T')
					{
						if (key == "TmpRotator")
						{
							value = this.TmpRotator;
							return true;
						}
					}
				}
				else if (key == "FirstInput")
				{
					value = this.FirstInput;
					return true;
				}
				break;
			}
			case 12:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'T')
					{
						if (key == "TargetOffset")
						{
							value = this.TargetOffset;
							return true;
						}
					}
				}
				else if (key == "CameraOffset")
				{
					value = this.CameraOffset;
					return true;
				}
				break;
			}
			case 13:
				if (key == "TargetRotator")
				{
					value = this.TargetRotator;
					return true;
				}
				break;
			case 15:
				if (key == "ExpectedYawSign")
				{
					value = this.ExpectedYawSign;
					return true;
				}
				break;
			case 16:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c != 'C')
					{
						if (c == 'S')
						{
							if (key == "SumYawPitchInput")
							{
								value = this.SumYawPitchInput;
								return true;
							}
						}
					}
					else if (key == "CameraOffsetSoft")
					{
						value = this.CameraOffsetSoft;
						return true;
					}
				}
				else if (key == "AddCameraOffsetY")
				{
					value = this.AddCameraOffsetY;
					return true;
				}
				break;
			}
			case 17:
				if (key == "YawSignAdaptionOn")
				{
					value = this.YawSignAdaptionOn;
					return true;
				}
				break;
			case 18:
			{
				char c = key[11];
				if (c != 'H')
				{
					if (c != 'S')
					{
						if (c == 'a')
						{
							if (key == "SoftUnlockYawSpeed")
							{
								value = this.SoftUnlockYawSpeed;
								return true;
							}
						}
					}
					else
					{
						if (key == "RelativeYawSoftMin")
						{
							value = this.RelativeYawSoftMin;
							return true;
						}
						if (key == "RelativeYawSoftMax")
						{
							value = this.RelativeYawSoftMax;
							return true;
						}
					}
				}
				else
				{
					if (key == "RelativeYawHardMax")
					{
						value = this.RelativeYawHardMax;
						return true;
					}
					if (key == "RelativeYawHardMin")
					{
						value = this.RelativeYawHardMin;
						return true;
					}
				}
				break;
			}
			case 19:
				if (key == "SoftUnlockInputTime")
				{
					value = this.SoftUnlockInputTime;
					return true;
				}
				break;
			case 20:
			{
				char c = key[18];
				if (c != 'a')
				{
					if (c != 'e')
					{
						if (c == 'i')
						{
							if (key == "RelativePitchHardMin")
							{
								value = this.RelativePitchHardMin;
								return true;
							}
						}
					}
					else if (key == "SoftUnlockPitchSpeed")
					{
						value = this.SoftUnlockPitchSpeed;
						return true;
					}
				}
				else if (key == "RelativePitchHardMax")
				{
					value = this.RelativePitchHardMax;
					return true;
				}
				break;
			}
			case 21:
				if (key == "PrevChangeYawSignTime")
				{
					value = this.PrevChangeYawSignTime;
					return true;
				}
				break;
			case 23:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'Y')
					{
						if (key == "YawSignAdaptionCooldown")
						{
							value = this.YawSignAdaptionCooldown;
							return true;
						}
					}
				}
				else if (key == "ChangeShowTargetDamping")
				{
					value = this.ChangeShowTargetDamping;
					return true;
				}
				break;
			}
			case 24:
				if (key == "YawSignAdaptionThreshold")
				{
					value = this.YawSignAdaptionThreshold;
					return true;
				}
				break;
			case 25:
				if (key == "SoftUnlockInputRemainTime")
				{
					value = this.SoftUnlockInputRemainTime;
					return true;
				}
				break;
			case 26:
				if (key == "SoftUnlockInputYawMinSpeed")
				{
					value = this.SoftUnlockInputYawMinSpeed;
					return true;
				}
				break;
			case 27:
			{
				char c = key[0];
				if (c <= 'H')
				{
					if (c != 'C')
					{
						if (c == 'H')
						{
							if (key == "HardLockInputYawSensitivity")
							{
								value = this.HardLockInputYawSensitivity;
								return true;
							}
						}
					}
					else if (key == "ChangeShowTargetSensitivity")
					{
						value = this.ChangeShowTargetSensitivity;
						return true;
					}
				}
				else if (c != 'R')
				{
					if (c == 'S')
					{
						if (key == "SoftLockInputYawSensitivity")
						{
							value = this.SoftLockInputYawSensitivity;
							return true;
						}
					}
				}
				else
				{
					if (key == "RelativeRotationLagYawCurve")
					{
						value = this.RelativeRotationLagYawCurve;
						return true;
					}
					if (key == "RelativeRotationLagRatioMin")
					{
						value = this.RelativeRotationLagRatioMin;
						return true;
					}
					if (key == "RelativeRotationLagRatioMax")
					{
						value = this.RelativeRotationLagRatioMax;
						return true;
					}
				}
				break;
			}
			case 28:
			{
				char c = key[0];
				if (c != 'S')
				{
					if (c == 'Y')
					{
						if (key == "YawSignAdaptionLockDirection")
						{
							value = this.YawSignAdaptionLockDirection;
							return true;
						}
					}
				}
				else if (key == "SoftUnlockInputPitchMinSpeed")
				{
					value = this.SoftUnlockInputPitchMinSpeed;
					return true;
				}
				break;
			}
			case 29:
			{
				char c = key[0];
				if (c != 'H')
				{
					if (c != 'R')
					{
						if (c == 'S')
						{
							if (key == "SoftLockInputPitchSensitivity")
							{
								value = this.SoftLockInputPitchSensitivity;
								return true;
							}
						}
					}
					else
					{
						if (key == "RelativeRotationLagPitchCurve")
						{
							value = this.RelativeRotationLagPitchCurve;
							return true;
						}
						if (key == "RelativeRotationLagRatioCurve")
						{
							value = this.RelativeRotationLagRatioCurve;
							return true;
						}
					}
				}
				else if (key == "HardLockInputPitchSensitivity")
				{
					value = this.HardLockInputPitchSensitivity;
					return true;
				}
				break;
			}
			case 30:
			{
				char c = key[28];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "RelativeRotationLagYawSpeedMin")
						{
							value = this.RelativeRotationLagYawSpeedMin;
							return true;
						}
					}
				}
				else if (key == "RelativeRotationLagYawSpeedMax")
				{
					value = this.RelativeRotationLagYawSpeedMax;
					return true;
				}
				break;
			}
			case 31:
				if (key == "ChangeShowTargetDistCoefficient")
				{
					value = this.ChangeShowTargetDistCoefficient;
					return true;
				}
				break;
			case 32:
			{
				char c = key[30];
				if (c <= 'g')
				{
					if (c != 'a')
					{
						if (c == 'g')
						{
							if (key == "RelativeRotationLagYawAngleRange")
							{
								value = this.RelativeRotationLagYawAngleRange;
								return true;
							}
						}
					}
					else if (key == "RelativeRotationLagPitchSpeedMax")
					{
						value = this.RelativeRotationLagPitchSpeedMax;
						return true;
					}
				}
				else if (c != 'i')
				{
					if (c != 'l')
					{
						if (c == 'n')
						{
							if (key == "ChangeShowTargetAngleCoefficient")
							{
								value = this.ChangeShowTargetAngleCoefficient;
								return true;
							}
						}
					}
					else if (key == "YawSignAdaptionDistanceThreshold")
					{
						value = this.YawSignAdaptionDistanceThreshold;
						return true;
					}
				}
				else if (key == "RelativeRotationLagPitchSpeedMin")
				{
					value = this.RelativeRotationLagPitchSpeedMin;
					return true;
				}
				break;
			}
			case 34:
			{
				char c = key[0];
				if (c <= 'H')
				{
					if (c != 'C')
					{
						if (c == 'H')
						{
							if (key == "HardLockInputYawSensitivityGamepad")
							{
								value = this.HardLockInputYawSensitivityGamepad;
								return true;
							}
						}
					}
					else if (key == "ChangeShowTargetSensitivityGamepad")
					{
						value = this.ChangeShowTargetSensitivityGamepad;
						return true;
					}
				}
				else if (c != 'R')
				{
					if (c == 'S')
					{
						if (key == "SoftLockInputYawSensitivityGamepad")
						{
							value = this.SoftLockInputYawSensitivityGamepad;
							return true;
						}
					}
				}
				else if (key == "RelativeRotationLagPitchAngleRange")
				{
					value = this.RelativeRotationLagPitchAngleRange;
					return true;
				}
				break;
			}
			case 35:
			{
				char c = key[33];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "RelativeRotationLagDistanceRangeMin")
						{
							value = this.RelativeRotationLagDistanceRangeMin;
							return true;
						}
					}
				}
				else if (key == "RelativeRotationLagDistanceRangeMax")
				{
					value = this.RelativeRotationLagDistanceRangeMax;
					return true;
				}
				break;
			}
			case 36:
			{
				char c = key[0];
				if (c != 'H')
				{
					if (c == 'S')
					{
						if (key == "SoftLockInputPitchSensitivityGamepad")
						{
							value = this.SoftLockInputPitchSensitivityGamepad;
							return true;
						}
					}
				}
				else if (key == "HardLockInputPitchSensitivityGamepad")
				{
					value = this.HardLockInputPitchSensitivityGamepad;
					return true;
				}
				break;
			}
			}
		}
		return base.TryGetMember(key, out value);
	}

	// Token: 0x060054F3 RID: 21747 RVA: 0x000D586C File Offset: 0x000D3A6C
	[NullableContext(0)]
	public override void SetMember(string key, object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 10:
				if (key == "FirstInput")
				{
					this.FirstInput = (bool)value;
					return;
				}
				break;
			case 12:
				if (key == "CameraOffset")
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
					this.CameraOffset = num2;
					return;
				}
				break;
			case 15:
				if (key == "ExpectedYawSign")
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
					this.ExpectedYawSign = num2;
					return;
				}
				break;
			case 16:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c == 'C')
					{
						if (key == "CameraOffsetSoft")
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
							this.CameraOffsetSoft = num2;
							return;
						}
					}
				}
				else if (key == "AddCameraOffsetY")
				{
					this.AddCameraOffsetY = (float?)value;
					return;
				}
				break;
			}
			case 17:
				if (key == "YawSignAdaptionOn")
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
					this.YawSignAdaptionOn = num2;
					return;
				}
				break;
			case 18:
			{
				char c = key[11];
				if (c != 'H')
				{
					if (c != 'S')
					{
						if (c == 'a')
						{
							if (key == "SoftUnlockYawSpeed")
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
								this.SoftUnlockYawSpeed = num2;
								return;
							}
						}
					}
					else
					{
						if (key == "RelativeYawSoftMin")
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
							this.RelativeYawSoftMin = num2;
							return;
						}
						if (key == "RelativeYawSoftMax")
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
							this.RelativeYawSoftMax = num2;
							return;
						}
					}
				}
				else
				{
					if (key == "RelativeYawHardMax")
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
						this.RelativeYawHardMax = num2;
						return;
					}
					if (key == "RelativeYawHardMin")
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
						this.RelativeYawHardMin = num2;
						return;
					}
				}
				break;
			}
			case 19:
				if (key == "SoftUnlockInputTime")
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
					this.SoftUnlockInputTime = num2;
					return;
				}
				break;
			case 20:
			{
				char c = key[18];
				if (c != 'a')
				{
					if (c != 'e')
					{
						if (c == 'i')
						{
							if (key == "RelativePitchHardMin")
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
								this.RelativePitchHardMin = num2;
								return;
							}
						}
					}
					else if (key == "SoftUnlockPitchSpeed")
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
						this.SoftUnlockPitchSpeed = num2;
						return;
					}
				}
				else if (key == "RelativePitchHardMax")
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
					this.RelativePitchHardMax = num2;
					return;
				}
				break;
			}
			case 21:
				if (key == "PrevChangeYawSignTime")
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
					this.PrevChangeYawSignTime = num2;
					return;
				}
				break;
			case 23:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'Y')
					{
						if (key == "YawSignAdaptionCooldown")
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
							this.YawSignAdaptionCooldown = num2;
							return;
						}
					}
				}
				else if (key == "ChangeShowTargetDamping")
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
					this.ChangeShowTargetDamping = num2;
					return;
				}
				break;
			}
			case 24:
				if (key == "YawSignAdaptionThreshold")
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
					this.YawSignAdaptionThreshold = num2;
					return;
				}
				break;
			case 25:
				if (key == "SoftUnlockInputRemainTime")
				{
					double softUnlockInputRemainTime;
					if (value is double)
					{
						double num70 = (double)value;
						softUnlockInputRemainTime = num70;
					}
					else if (value is float)
					{
						float num71 = (float)value;
						softUnlockInputRemainTime = (double)num71;
					}
					else if (value is int)
					{
						int num72 = (int)value;
						softUnlockInputRemainTime = (double)num72;
					}
					else if (value is long)
					{
						long num73 = (long)value;
						softUnlockInputRemainTime = (double)num73;
					}
					else
					{
						softUnlockInputRemainTime = (double)value;
					}
					this.SoftUnlockInputRemainTime = softUnlockInputRemainTime;
					return;
				}
				break;
			case 26:
				if (key == "SoftUnlockInputYawMinSpeed")
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
					this.SoftUnlockInputYawMinSpeed = num2;
					return;
				}
				break;
			case 27:
			{
				char c = key[0];
				if (c <= 'H')
				{
					if (c != 'C')
					{
						if (c == 'H')
						{
							if (key == "HardLockInputYawSensitivity")
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
								this.HardLockInputYawSensitivity = num2;
								return;
							}
						}
					}
					else if (key == "ChangeShowTargetSensitivity")
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
						this.ChangeShowTargetSensitivity = num2;
						return;
					}
				}
				else if (c != 'R')
				{
					if (c == 'S')
					{
						if (key == "SoftLockInputYawSensitivity")
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
							this.SoftLockInputYawSensitivity = num2;
							return;
						}
					}
				}
				else
				{
					if (key == "RelativeRotationLagYawCurve")
					{
						this.RelativeRotationLagYawCurve = (CurveBase)value;
						return;
					}
					if (key == "RelativeRotationLagRatioMin")
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
						this.RelativeRotationLagRatioMin = num2;
						return;
					}
					if (key == "RelativeRotationLagRatioMax")
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
						this.RelativeRotationLagRatioMax = num2;
						return;
					}
				}
				break;
			}
			case 28:
			{
				char c = key[0];
				if (c != 'S')
				{
					if (c == 'Y')
					{
						if (key == "YawSignAdaptionLockDirection")
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
							this.YawSignAdaptionLockDirection = num2;
							return;
						}
					}
				}
				else if (key == "SoftUnlockInputPitchMinSpeed")
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
					this.SoftUnlockInputPitchMinSpeed = num2;
					return;
				}
				break;
			}
			case 29:
			{
				char c = key[0];
				if (c != 'H')
				{
					if (c != 'R')
					{
						if (c == 'S')
						{
							if (key == "SoftLockInputPitchSensitivity")
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
								this.SoftLockInputPitchSensitivity = num2;
								return;
							}
						}
					}
					else
					{
						if (key == "RelativeRotationLagPitchCurve")
						{
							this.RelativeRotationLagPitchCurve = (CurveBase)value;
							return;
						}
						if (key == "RelativeRotationLagRatioCurve")
						{
							this.RelativeRotationLagRatioCurve = (CurveBase)value;
							return;
						}
					}
				}
				else if (key == "HardLockInputPitchSensitivity")
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
					this.HardLockInputPitchSensitivity = num2;
					return;
				}
				break;
			}
			case 30:
			{
				char c = key[28];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "RelativeRotationLagYawSpeedMin")
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
							this.RelativeRotationLagYawSpeedMin = num2;
							return;
						}
					}
				}
				else if (key == "RelativeRotationLagYawSpeedMax")
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
					this.RelativeRotationLagYawSpeedMax = num2;
					return;
				}
				break;
			}
			case 31:
				if (key == "ChangeShowTargetDistCoefficient")
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
					this.ChangeShowTargetDistCoefficient = num2;
					return;
				}
				break;
			case 32:
			{
				char c = key[30];
				if (c <= 'g')
				{
					if (c != 'a')
					{
						if (c == 'g')
						{
							if (key == "RelativeRotationLagYawAngleRange")
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
								this.RelativeRotationLagYawAngleRange = num2;
								return;
							}
						}
					}
					else if (key == "RelativeRotationLagPitchSpeedMax")
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
						this.RelativeRotationLagPitchSpeedMax = num2;
						return;
					}
				}
				else if (c != 'i')
				{
					if (c != 'l')
					{
						if (c == 'n')
						{
							if (key == "ChangeShowTargetAngleCoefficient")
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
								this.ChangeShowTargetAngleCoefficient = num2;
								return;
							}
						}
					}
					else if (key == "YawSignAdaptionDistanceThreshold")
					{
						float num2;
						if (value is double)
						{
							double num138 = (double)value;
							num2 = (float)num138;
						}
						else if (value is float)
						{
							float num139 = (float)value;
							num2 = num139;
						}
						else if (value is int)
						{
							int num140 = (int)value;
							num2 = (float)num140;
						}
						else if (value is long)
						{
							long num141 = (long)value;
							num2 = (float)num141;
						}
						else
						{
							num2 = (float)value;
						}
						this.YawSignAdaptionDistanceThreshold = num2;
						return;
					}
				}
				else if (key == "RelativeRotationLagPitchSpeedMin")
				{
					float num2;
					if (value is double)
					{
						double num142 = (double)value;
						num2 = (float)num142;
					}
					else if (value is float)
					{
						float num143 = (float)value;
						num2 = num143;
					}
					else if (value is int)
					{
						int num144 = (int)value;
						num2 = (float)num144;
					}
					else if (value is long)
					{
						long num145 = (long)value;
						num2 = (float)num145;
					}
					else
					{
						num2 = (float)value;
					}
					this.RelativeRotationLagPitchSpeedMin = num2;
					return;
				}
				break;
			}
			case 34:
			{
				char c = key[0];
				if (c <= 'H')
				{
					if (c != 'C')
					{
						if (c == 'H')
						{
							if (key == "HardLockInputYawSensitivityGamepad")
							{
								float num2;
								if (value is double)
								{
									double num146 = (double)value;
									num2 = (float)num146;
								}
								else if (value is float)
								{
									float num147 = (float)value;
									num2 = num147;
								}
								else if (value is int)
								{
									int num148 = (int)value;
									num2 = (float)num148;
								}
								else if (value is long)
								{
									long num149 = (long)value;
									num2 = (float)num149;
								}
								else
								{
									num2 = (float)value;
								}
								this.HardLockInputYawSensitivityGamepad = num2;
								return;
							}
						}
					}
					else if (key == "ChangeShowTargetSensitivityGamepad")
					{
						float num2;
						if (value is double)
						{
							double num150 = (double)value;
							num2 = (float)num150;
						}
						else if (value is float)
						{
							float num151 = (float)value;
							num2 = num151;
						}
						else if (value is int)
						{
							int num152 = (int)value;
							num2 = (float)num152;
						}
						else if (value is long)
						{
							long num153 = (long)value;
							num2 = (float)num153;
						}
						else
						{
							num2 = (float)value;
						}
						this.ChangeShowTargetSensitivityGamepad = num2;
						return;
					}
				}
				else if (c != 'R')
				{
					if (c == 'S')
					{
						if (key == "SoftLockInputYawSensitivityGamepad")
						{
							float num2;
							if (value is double)
							{
								double num154 = (double)value;
								num2 = (float)num154;
							}
							else if (value is float)
							{
								float num155 = (float)value;
								num2 = num155;
							}
							else if (value is int)
							{
								int num156 = (int)value;
								num2 = (float)num156;
							}
							else if (value is long)
							{
								long num157 = (long)value;
								num2 = (float)num157;
							}
							else
							{
								num2 = (float)value;
							}
							this.SoftLockInputYawSensitivityGamepad = num2;
							return;
						}
					}
				}
				else if (key == "RelativeRotationLagPitchAngleRange")
				{
					float num2;
					if (value is double)
					{
						double num158 = (double)value;
						num2 = (float)num158;
					}
					else if (value is float)
					{
						float num159 = (float)value;
						num2 = num159;
					}
					else if (value is int)
					{
						int num160 = (int)value;
						num2 = (float)num160;
					}
					else if (value is long)
					{
						long num161 = (long)value;
						num2 = (float)num161;
					}
					else
					{
						num2 = (float)value;
					}
					this.RelativeRotationLagPitchAngleRange = num2;
					return;
				}
				break;
			}
			case 35:
			{
				char c = key[33];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "RelativeRotationLagDistanceRangeMin")
						{
							float num2;
							if (value is double)
							{
								double num162 = (double)value;
								num2 = (float)num162;
							}
							else if (value is float)
							{
								float num163 = (float)value;
								num2 = num163;
							}
							else if (value is int)
							{
								int num164 = (int)value;
								num2 = (float)num164;
							}
							else if (value is long)
							{
								long num165 = (long)value;
								num2 = (float)num165;
							}
							else
							{
								num2 = (float)value;
							}
							this.RelativeRotationLagDistanceRangeMin = num2;
							return;
						}
					}
				}
				else if (key == "RelativeRotationLagDistanceRangeMax")
				{
					float num2;
					if (value is double)
					{
						double num166 = (double)value;
						num2 = (float)num166;
					}
					else if (value is float)
					{
						float num167 = (float)value;
						num2 = num167;
					}
					else if (value is int)
					{
						int num168 = (int)value;
						num2 = (float)num168;
					}
					else if (value is long)
					{
						long num169 = (long)value;
						num2 = (float)num169;
					}
					else
					{
						num2 = (float)value;
					}
					this.RelativeRotationLagDistanceRangeMax = num2;
					return;
				}
				break;
			}
			case 36:
			{
				char c = key[0];
				if (c != 'H')
				{
					if (c == 'S')
					{
						if (key == "SoftLockInputPitchSensitivityGamepad")
						{
							float num2;
							if (value is double)
							{
								double num170 = (double)value;
								num2 = (float)num170;
							}
							else if (value is float)
							{
								float num171 = (float)value;
								num2 = num171;
							}
							else if (value is int)
							{
								int num172 = (int)value;
								num2 = (float)num172;
							}
							else if (value is long)
							{
								long num173 = (long)value;
								num2 = (float)num173;
							}
							else
							{
								num2 = (float)value;
							}
							this.SoftLockInputPitchSensitivityGamepad = num2;
							return;
						}
					}
				}
				else if (key == "HardLockInputPitchSensitivityGamepad")
				{
					float num2;
					if (value is double)
					{
						double num174 = (double)value;
						num2 = (float)num174;
					}
					else if (value is float)
					{
						float num175 = (float)value;
						num2 = num175;
					}
					else if (value is int)
					{
						int num176 = (int)value;
						num2 = (float)num176;
					}
					else if (value is long)
					{
						long num177 = (long)value;
						num2 = (float)num177;
					}
					else
					{
						num2 = (float)value;
					}
					this.HardLockInputPitchSensitivityGamepad = num2;
					return;
				}
				break;
			}
			}
		}
		base.SetMember(key, value);
	}

	// Token: 0x060054F4 RID: 21748 RVA: 0x000D731C File Offset: 0x000D551C
	[NullableContext(0)]
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraFocusController.<MemberIter>d__81 <MemberIter>d__ = new CameraFocusController.<MemberIter>d__81(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x040019D5 RID: 6613
	internal const int ArmOffsetYSpeed = 100;

	// Token: 0x040019D6 RID: 6614
	internal const int DefaultFps = 60;

	// Token: 0x040019D7 RID: 6615
	internal const float FirstThreshold = 0.5f;

	// Token: 0x040019D8 RID: 6616
	internal const double FirstThresholdSquared = 0.25;

	// Token: 0x040019D9 RID: 6617
	internal const float LockDirectionLeft = -1f;

	// Token: 0x040019DA RID: 6618
	internal const float LockDirectionRight = 1f;

	// Token: 0x040019DB RID: 6619
	public float RelativeRotationLagYawSpeedMin;

	// Token: 0x040019DC RID: 6620
	public float RelativeRotationLagYawSpeedMax;

	// Token: 0x040019DD RID: 6621
	public float RelativeRotationLagYawAngleRange;

	// Token: 0x040019DE RID: 6622
	[Nullable(2)]
	public CurveBase RelativeRotationLagYawCurve;

	// Token: 0x040019DF RID: 6623
	public float RelativeRotationLagPitchSpeedMin;

	// Token: 0x040019E0 RID: 6624
	public float RelativeRotationLagPitchSpeedMax;

	// Token: 0x040019E1 RID: 6625
	public float RelativeRotationLagPitchAngleRange;

	// Token: 0x040019E2 RID: 6626
	[Nullable(2)]
	public CurveBase RelativeRotationLagPitchCurve;

	// Token: 0x040019E3 RID: 6627
	public float RelativeRotationLagRatioMin;

	// Token: 0x040019E4 RID: 6628
	public float RelativeRotationLagRatioMax;

	// Token: 0x040019E5 RID: 6629
	public float RelativeRotationLagDistanceRangeMin;

	// Token: 0x040019E6 RID: 6630
	public float RelativeRotationLagDistanceRangeMax;

	// Token: 0x040019E7 RID: 6631
	[Nullable(2)]
	public CurveBase RelativeRotationLagRatioCurve;

	// Token: 0x040019E8 RID: 6632
	public float YawSignAdaptionOn;

	// Token: 0x040019E9 RID: 6633
	public float YawSignAdaptionThreshold;

	// Token: 0x040019EA RID: 6634
	public float YawSignAdaptionCooldown;

	// Token: 0x040019EB RID: 6635
	public float YawSignAdaptionDistanceThreshold;

	// Token: 0x040019EC RID: 6636
	public float YawSignAdaptionLockDirection;

	// Token: 0x040019ED RID: 6637
	public float RelativeYawSoftMin;

	// Token: 0x040019EE RID: 6638
	public float RelativeYawSoftMax;

	// Token: 0x040019EF RID: 6639
	public float CameraOffsetSoft;

	// Token: 0x040019F0 RID: 6640
	public float CameraOffset;

	// Token: 0x040019F1 RID: 6641
	public float HardLockInputYawSensitivity;

	// Token: 0x040019F2 RID: 6642
	public float HardLockInputPitchSensitivity;

	// Token: 0x040019F3 RID: 6643
	public float HardLockInputYawSensitivityGamepad;

	// Token: 0x040019F4 RID: 6644
	public float HardLockInputPitchSensitivityGamepad;

	// Token: 0x040019F5 RID: 6645
	public float SoftLockInputYawSensitivity;

	// Token: 0x040019F6 RID: 6646
	public float SoftLockInputPitchSensitivity;

	// Token: 0x040019F7 RID: 6647
	public float SoftLockInputYawSensitivityGamepad;

	// Token: 0x040019F8 RID: 6648
	public float SoftLockInputPitchSensitivityGamepad;

	// Token: 0x040019F9 RID: 6649
	public float ChangeShowTargetDamping;

	// Token: 0x040019FA RID: 6650
	public float ChangeShowTargetAngleCoefficient;

	// Token: 0x040019FB RID: 6651
	public float ChangeShowTargetDistCoefficient;

	// Token: 0x040019FC RID: 6652
	public float ChangeShowTargetSensitivity;

	// Token: 0x040019FD RID: 6653
	public float ChangeShowTargetSensitivityGamepad;

	// Token: 0x040019FE RID: 6654
	public float RelativeYawHardMax;

	// Token: 0x040019FF RID: 6655
	public float RelativeYawHardMin;

	// Token: 0x04001A00 RID: 6656
	public float RelativePitchHardMax;

	// Token: 0x04001A01 RID: 6657
	public float RelativePitchHardMin;

	// Token: 0x04001A02 RID: 6658
	public float SoftUnlockYawSpeed;

	// Token: 0x04001A03 RID: 6659
	public float SoftUnlockPitchSpeed;

	// Token: 0x04001A04 RID: 6660
	public float SoftUnlockInputTime;

	// Token: 0x04001A05 RID: 6661
	public float SoftUnlockInputYawMinSpeed;

	// Token: 0x04001A06 RID: 6662
	public float SoftUnlockInputPitchMinSpeed;

	// Token: 0x04001A07 RID: 6663
	private double SoftUnlockInputRemainTime;

	// Token: 0x04001A08 RID: 6664
	private readonly Rotator TmpRotator = Rotator.Create();

	// Token: 0x04001A09 RID: 6665
	private readonly Vector TargetOffset = Vector.Create();

	// Token: 0x04001A0A RID: 6666
	private readonly Rotator TargetRotator = Rotator.Create();

	// Token: 0x04001A0B RID: 6667
	private float ExpectedYawSign;

	// Token: 0x04001A0C RID: 6668
	public float? AddCameraOffsetY;

	// Token: 0x04001A0D RID: 6669
	private readonly Vector2D SumYawPitchInput = Vector2D.Create();

	// Token: 0x04001A0E RID: 6670
	private bool FirstInput = true;

	// Token: 0x04001A0F RID: 6671
	private float PrevChangeYawSignTime;
}
