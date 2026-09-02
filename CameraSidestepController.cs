using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;

// Token: 0x02000E30 RID: 3632
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(true)]
public class CameraSidestepController : CameraControllerBase<EFightCameraSidestep>, ICanGetConfigMapValue
{
	// Token: 0x06005609 RID: 22025 RVA: 0x000E9B0C File Offset: 0x000E7D0C
	public CameraSidestepController(FightCameraLogicComponent camera) : base(camera)
	{
	}

	// Token: 0x0600560A RID: 22026 RVA: 0x000E9B83 File Offset: 0x000E7D83
	public override string Name()
	{
		return "SidestepController";
	}

	// Token: 0x0600560B RID: 22027 RVA: 0x000E9B8C File Offset: 0x000E7D8C
	protected override void OnInit()
	{
		base.SetConfigMap(EFightCameraSidestep.旋转角速度插值速率, "YawInterpSpeed");
		base.SetConfigMap(EFightCameraSidestep.俯仰角插值速率, "PitchInterpSpeed");
		base.SetConfigMap(EFightCameraSidestep.俯仰角加速度, "PitchAccelerate");
		base.SetConfigMap(EFightCameraSidestep.最大仰角, "MaxPitch");
		base.SetConfigMap(EFightCameraSidestep.最大俯角, "MinPitch");
		base.SetConfigMap(EFightCameraSidestep.相机俯角偏移, "PitchOffset");
		base.SetConfigMap(EFightCameraSidestep.俯仰修正时间阈值, "MoveDurationThreshold");
		base.SetConfigMap(EFightCameraSidestep.自动偏转最大角速度, "MaxYawSpeed");
		base.SetConfigMap(EFightCameraSidestep.移动输入恢复臂长目标值下限, "InputRecoverArmLengthMin");
		base.SetConfigMap(EFightCameraSidestep.移动输入恢复臂长目标值上限, "InputRecoverArmLengthMax");
		base.SetConfigMap(EFightCameraSidestep.移动输入恢复臂长最小速度, "InputRecoverArmLengthSpeedMin");
		base.SetConfigMap(EFightCameraSidestep.移动输入恢复臂长最大速度, "InputRecoverArmLengthSpeedMax");
		base.SetConfigMap(EFightCameraSidestep.移动输入恢复臂长与目标臂长最大差值, "InputRecoverArmLengthLimit");
		base.SetCurveConfigMap(EFightCameraSidestep.移动输入恢复臂长与目标臂长最大差值, "InputRecoverArmLengthCurve");
		base.RegisterPairConfigKey(EFightCameraSidestep.移动输入恢复臂长目标值下限, EFightCameraSidestep.移动输入恢复臂长目标值上限, true);
		base.RegisterPairConfigKey(EFightCameraSidestep.移动输入恢复臂长最小速度, EFightCameraSidestep.移动输入恢复臂长最大速度, true);
	}

	// Token: 0x0600560C RID: 22028 RVA: 0x000E9C60 File Offset: 0x000E7E60
	protected override void UpdateInternal(float deltaTime)
	{
		if (!base.CameraModel.IsEnableSidestepCamera)
		{
			return;
		}
		if (this.Camera.Character == null)
		{
			return;
		}
		this.UpdateCameraInfo((double)deltaTime);
		if (this.MoveDuration <= 0.0)
		{
			return;
		}
		this.UpdateInternalSidestep((double)deltaTime);
		this.UpdateInternalSlope((double)deltaTime);
		this.RecoverArmLength((double)deltaTime);
	}

	// Token: 0x0600560D RID: 22029 RVA: 0x000E9CBC File Offset: 0x000E7EBC
	private void UpdateCameraInfo(double deltaTime)
	{
		this.Camera.GetCameraTargetRotator(this.TempRotator);
		CameraUtility.GetRotatorInGravity(this.TempRotator, this.TempRotator);
		CameraUtility.GetRotatorInGravity(this.Camera.CurrentCamera.ArmRotation, this.TempRotator2);
		Rotator rotator = Rotator.Create(0f, this.TempRotator.Yaw, 0f);
		Rotator rotator2 = Rotator.Create(0f, this.TempRotator2.Yaw, 0f);
		rotator.Vector(this.CharacterFacing);
		rotator2.Vector(this.CameraFacing);
		if (this.Camera.IsModifiedArmRotationPitch || this.Camera.IsModifiedArmRotationYaw || this.Camera.IsModifiedArmLength || !this.IsCharacterMoving())
		{
			this.MoveDuration = 0.0;
			this.YawSpeed = 0.0;
			return;
		}
		this.MoveDuration += deltaTime;
		this.YawSpeed = Singleton<MathUtils>.Instance.InterpTo(this.YawSpeed, this.MaxYawSpeed, deltaTime, this.YawInterpSpeed);
	}

	// Token: 0x0600560E RID: 22030 RVA: 0x000E9DD4 File Offset: 0x000E7FD4
	private void UpdateInternalSidestep(double deltaTime)
	{
		double num = this.CameraFacing.SineAngle2D(this.CharacterFacing, 9.999999747378752E-05) * deltaTime * this.YawSpeed;
		if (this.Camera.IsInNormalGravityMode())
		{
			Rotator armRotation = this.Camera.DesiredCamera.ArmRotation;
			armRotation.Yaw = (float)(((double)armRotation.Yaw + num) % 360.0);
		}
		else
		{
			CameraUtility.AddYawInGravity(this.Camera.DesiredCamera.ArmRotation, num, this.Camera.DesiredCamera.ArmRotation);
		}
		this.Camera.IsModifiedArmRotationYaw = true;
	}

	// Token: 0x0600560F RID: 22031 RVA: 0x000E9E70 File Offset: 0x000E8070
	private void UpdateInternalSlope(double deltaTime)
	{
		if (this.MoveDuration < this.MoveDurationThreshold)
		{
			return;
		}
		EntityHandle characterEntityHandle = this.Camera.CharacterEntityHandle;
		CharacterAnimationComponent characterAnimationComponent;
		if (characterEntityHandle == null)
		{
			characterAnimationComponent = null;
		}
		else
		{
			WorldEntity entity = characterEntityHandle.Entity;
			characterAnimationComponent = ((entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null);
		}
		CharacterAnimationComponent characterAnimationComponent2 = characterAnimationComponent;
		if (characterAnimationComponent2 == null || !characterAnimationComponent2.Valid)
		{
			return;
		}
		EntityHandle characterEntityHandle2 = this.Camera.CharacterEntityHandle;
		CharacterMoveComponent characterMoveComponent;
		if (characterEntityHandle2 == null)
		{
			characterMoveComponent = null;
		}
		else
		{
			WorldEntity entity2 = characterEntityHandle2.Entity;
			characterMoveComponent = ((entity2 != null) ? entity2.GetComponent<CharacterMoveComponent>() : null);
		}
		CharacterMoveComponent characterMoveComponent2 = characterMoveComponent;
		if (characterMoveComponent2 == null || !characterMoveComponent2.Valid)
		{
			return;
		}
		CharacterDriveVehicleComponent characterDriveVehicleComponent = this.Camera.CharacterDriveVehicleComponent;
		if (characterDriveVehicleComponent != null && characterDriveVehicleComponent.IsOnVehicle)
		{
			VehicleAnimationComponent vehicleAnimationComponent = this.Camera.VehicleAnimationComponent;
			if (vehicleAnimationComponent != null && vehicleAnimationComponent.Valid)
			{
				this.GravityUp.FromUeVector(this.Camera.VehicleMoveComponent.GravityUp);
				this.MoveNormal.FromUeVector(this.Camera.VehicleAnimationComponent.MovementNormal);
				goto IL_107;
			}
		}
		this.GravityUp.FromUeVector(characterMoveComponent2.GravityUp);
		this.MoveNormal.FromUeVector(characterAnimationComponent2.MovementTerrainNormal);
		IL_107:
		CameraUtility.GetVectorInGravity(this.GravityUp, this.GravityUp);
		CameraUtility.GetVectorInGravity(this.MoveNormal, this.MoveNormal);
		Vector tempVector = this.TempVector;
		this.GravityUp.CrossProduct(this.CameraFacing, tempVector);
		tempVector.CrossProduct(this.MoveNormal, tempVector);
		float pitch = this.Camera.CameraRotationInGravity.Pitch;
		double num = Singleton<MathUtils>.Instance.Clamp(Math.Atan2(tempVector.Z, tempVector.Size2D() + 9.999999747378752E-05) * 57.295780181884766 - this.PitchOffset, this.MinPitch, this.MaxPitch) - (double)pitch;
		double num2 = Math.Abs(num);
		double to = this.PitchInterpSpeed * num;
		this.PitchSpeed = Singleton<MathUtils>.Instance.InterpConstantTo(this.PitchSpeed, to, deltaTime, this.PitchAccelerate);
		if (this.Camera.IsInNormalGravityMode())
		{
			this.Camera.DesiredCamera.ArmRotation.Pitch = (float)((double)pitch + Singleton<MathUtils>.Instance.Clamp(this.PitchSpeed * deltaTime, -num2, num2));
		}
		else
		{
			CameraUtility.AddPitchInGravity(this.Camera.DesiredCamera.ArmRotation, Singleton<MathUtils>.Instance.Clamp(this.PitchSpeed * deltaTime, -num2, num2), this.Camera.DesiredCamera.ArmRotation);
		}
		this.Camera.IsModifiedArmRotationPitch = true;
	}

	// Token: 0x06005610 RID: 22032 RVA: 0x000EA0E4 File Offset: 0x000E82E4
	protected bool IsCharacterMoving()
	{
		if (this.Camera.Character == null)
		{
			return false;
		}
		if (this.Camera.ContainsTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"], false) || this.Camera.ContainsTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"], false))
		{
			return false;
		}
		CharacterDriveVehicleComponent characterDriveVehicleComponent = this.Camera.CharacterDriveVehicleComponent;
		if (characterDriveVehicleComponent != null && characterDriveVehicleComponent.IsOnVehicle)
		{
			VehicleMoveComponent vehicleMoveComponent = this.Camera.VehicleMoveComponent;
			if (vehicleMoveComponent != null && vehicleMoveComponent.Valid)
			{
				return this.Camera.VehicleMoveComponent.Speed > 70f;
			}
		}
		CharacterMoveComponent component = this.Camera.CharacterEntityHandle.Entity.GetComponent<CharacterMoveComponent>();
		return component != null && component.Valid && component.Speed > 70f;
	}

	// Token: 0x06005611 RID: 22033 RVA: 0x000EA1B8 File Offset: 0x000E83B8
	private unsafe void RecoverArmLength(double deltaTime)
	{
		TsBaseCharacter character = this.Camera.Character;
		CharacterMoveComponent characterMoveComponent = (character != null) ? character.CharacterActorComponent.Entity.GetComponent<CharacterMoveComponent>() : null;
		if (characterMoveComponent == null || !characterMoveComponent.HasMoveInput)
		{
			CharacterDriveVehicleComponent characterDriveVehicleComponent = this.Camera.CharacterDriveVehicleComponent;
			if (characterDriveVehicleComponent != null && characterDriveVehicleComponent.IsOnVehicle)
			{
				VehicleMoveComponent vehicleMoveComponent = this.Camera.VehicleMoveComponent;
				if (vehicleMoveComponent == null || !vehicleMoveComponent.HasMoveInput)
				{
					return;
				}
			}
		}
		float num = 0f;
		float armLengthWithSettingAndZoom = this.Camera.GetArmLengthWithSettingAndZoom(this.Camera.CurrentCamera, true);
		float armLengthWithSetting = this.Camera.GetArmLengthWithSetting(this.Camera.CurrentCamera);
		float num2 = armLengthWithSetting - this.Camera.CurrentCamera.ArmLength;
		double num3 = this.InputRecoverArmLengthMin + (double)num2;
		double num4 = Math.Max((double)armLengthWithSetting, this.InputRecoverArmLengthMax);
		if ((double)armLengthWithSettingAndZoom < num3)
		{
			double num5 = num3 - (double)armLengthWithSettingAndZoom;
			num = (float)Math.Min(Singleton<MathUtils>.Instance.Lerp(this.InputRecoverArmLengthSpeedMin, this.InputRecoverArmLengthSpeedMax, (double)this.InputRecoverArmLengthCurve.GetCurrentValue((float)(num5 / this.InputRecoverArmLengthLimit))) * deltaTime, num5);
		}
		else if ((double)armLengthWithSettingAndZoom > num4)
		{
			double num6 = (double)armLengthWithSettingAndZoom - num4;
			num = (float)(-(float)Math.Min(Singleton<MathUtils>.Instance.Lerp(this.InputRecoverArmLengthSpeedMin, this.InputRecoverArmLengthSpeedMax, (double)this.InputRecoverArmLengthCurve.GetCurrentValue((float)(num6 / this.InputRecoverArmLengthLimit))) * deltaTime, num6));
		}
		float num7 = armLengthWithSettingAndZoom + num;
		float num8 = armLengthWithSettingAndZoom / this.Camera.DesiredCamera.ZoomModifier;
		this.Camera.DesiredCamera.ZoomModifier = num7 / num8;
		if ((double)this.Camera.DesiredCamera.ZoomModifier <= 1E-08 && this.EnableDebugZoomModifier)
		{
			this.EnableDebugZoomModifier = false;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[DebugZoomModifier RecoverArmLength]";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DesiredCamera.ZoomModifier", this.Camera.DesiredCamera.ZoomModifier);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("currentArmLength", armLengthWithSettingAndZoom);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("delta", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("newArmLength", num7);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("armLengthBeforeModify", num8);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("CameraConfigTags", this.Camera.CameraConfigController.GetCameraConfigTagsContent());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
		}
	}

	// Token: 0x06005612 RID: 22034 RVA: 0x000EA460 File Offset: 0x000E8660
	public override string GetConfigMapValue(int key)
	{
		return base.GetConfigMapValue((EFightCameraSidestep)key);
	}

	// Token: 0x06005613 RID: 22035 RVA: 0x000EA46C File Offset: 0x000E866C
	[NullableContext(0)]
	public override bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 8:
			{
				char c = key[2];
				if (c != 'n')
				{
					if (c != 'w')
					{
						if (c == 'x')
						{
							if (key == "MaxPitch")
							{
								value = this.MaxPitch;
								return true;
							}
						}
					}
					else if (key == "YawSpeed")
					{
						value = this.YawSpeed;
						return true;
					}
				}
				else if (key == "MinPitch")
				{
					value = this.MinPitch;
					return true;
				}
				break;
			}
			case 9:
				if (key == "GravityUp")
				{
					value = this.GravityUp;
					return true;
				}
				break;
			case 10:
			{
				char c = key[0];
				if (c != 'M')
				{
					if (c != 'P')
					{
						if (c == 'T')
						{
							if (key == "TempVector")
							{
								value = this.TempVector;
								return true;
							}
						}
					}
					else if (key == "PitchSpeed")
					{
						value = this.PitchSpeed;
						return true;
					}
				}
				else if (key == "MoveNormal")
				{
					value = this.MoveNormal;
					return true;
				}
				break;
			}
			case 11:
			{
				char c = key[0];
				if (c != 'M')
				{
					if (c != 'P')
					{
						if (c == 'T')
						{
							if (key == "TempRotator")
							{
								value = this.TempRotator;
								return true;
							}
						}
					}
					else if (key == "PitchOffset")
					{
						value = this.PitchOffset;
						return true;
					}
				}
				else if (key == "MaxYawSpeed")
				{
					value = this.MaxYawSpeed;
					return true;
				}
				break;
			}
			case 12:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c != 'M')
					{
						if (c == 'T')
						{
							if (key == "TempRotator2")
							{
								value = this.TempRotator2;
								return true;
							}
						}
					}
					else if (key == "MoveDuration")
					{
						value = this.MoveDuration;
						return true;
					}
				}
				else if (key == "CameraFacing")
				{
					value = this.CameraFacing;
					return true;
				}
				break;
			}
			case 14:
				if (key == "YawInterpSpeed")
				{
					value = this.YawInterpSpeed;
					return true;
				}
				break;
			case 15:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'P')
					{
						if (key == "PitchAccelerate")
						{
							value = this.PitchAccelerate;
							return true;
						}
					}
				}
				else if (key == "CharacterFacing")
				{
					value = this.CharacterFacing;
					return true;
				}
				break;
			}
			case 16:
				if (key == "PitchInterpSpeed")
				{
					value = this.PitchInterpSpeed;
					return true;
				}
				break;
			case 21:
				if (key == "MoveDurationThreshold")
				{
					value = this.MoveDurationThreshold;
					return true;
				}
				break;
			case 23:
				if (key == "EnableDebugZoomModifier")
				{
					value = this.EnableDebugZoomModifier;
					return true;
				}
				break;
			case 24:
			{
				char c = key[22];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "InputRecoverArmLengthMin")
						{
							value = this.InputRecoverArmLengthMin;
							return true;
						}
					}
				}
				else if (key == "InputRecoverArmLengthMax")
				{
					value = this.InputRecoverArmLengthMax;
					return true;
				}
				break;
			}
			case 26:
			{
				char c = key[21];
				if (c != 'C')
				{
					if (c == 'L')
					{
						if (key == "InputRecoverArmLengthLimit")
						{
							value = this.InputRecoverArmLengthLimit;
							return true;
						}
					}
				}
				else if (key == "InputRecoverArmLengthCurve")
				{
					value = this.InputRecoverArmLengthCurve;
					return true;
				}
				break;
			}
			case 29:
			{
				char c = key[27];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "InputRecoverArmLengthSpeedMin")
						{
							value = this.InputRecoverArmLengthSpeedMin;
							return true;
						}
					}
				}
				else if (key == "InputRecoverArmLengthSpeedMax")
				{
					value = this.InputRecoverArmLengthSpeedMax;
					return true;
				}
				break;
			}
			}
		}
		return base.TryGetMember(key, out value);
	}

	// Token: 0x06005614 RID: 22036 RVA: 0x000EA95C File Offset: 0x000E8B5C
	[NullableContext(0)]
	public override void SetMember(string key, object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 8:
			{
				char c = key[2];
				if (c != 'n')
				{
					if (c != 'w')
					{
						if (c == 'x')
						{
							if (key == "MaxPitch")
							{
								double num2;
								if (value is double)
								{
									double num = (double)value;
									num2 = num;
								}
								else if (value is float)
								{
									float num3 = (float)value;
									num2 = (double)num3;
								}
								else if (value is int)
								{
									int num4 = (int)value;
									num2 = (double)num4;
								}
								else if (value is long)
								{
									long num5 = (long)value;
									num2 = (double)num5;
								}
								else
								{
									num2 = (double)value;
								}
								this.MaxPitch = num2;
								return;
							}
						}
					}
					else if (key == "YawSpeed")
					{
						double num2;
						if (value is double)
						{
							double num6 = (double)value;
							num2 = num6;
						}
						else if (value is float)
						{
							float num7 = (float)value;
							num2 = (double)num7;
						}
						else if (value is int)
						{
							int num8 = (int)value;
							num2 = (double)num8;
						}
						else if (value is long)
						{
							long num9 = (long)value;
							num2 = (double)num9;
						}
						else
						{
							num2 = (double)value;
						}
						this.YawSpeed = num2;
						return;
					}
				}
				else if (key == "MinPitch")
				{
					double num2;
					if (value is double)
					{
						double num10 = (double)value;
						num2 = num10;
					}
					else if (value is float)
					{
						float num11 = (float)value;
						num2 = (double)num11;
					}
					else if (value is int)
					{
						int num12 = (int)value;
						num2 = (double)num12;
					}
					else if (value is long)
					{
						long num13 = (long)value;
						num2 = (double)num13;
					}
					else
					{
						num2 = (double)value;
					}
					this.MinPitch = num2;
					return;
				}
				break;
			}
			case 10:
				if (key == "PitchSpeed")
				{
					double num2;
					if (value is double)
					{
						double num14 = (double)value;
						num2 = num14;
					}
					else if (value is float)
					{
						float num15 = (float)value;
						num2 = (double)num15;
					}
					else if (value is int)
					{
						int num16 = (int)value;
						num2 = (double)num16;
					}
					else if (value is long)
					{
						long num17 = (long)value;
						num2 = (double)num17;
					}
					else
					{
						num2 = (double)value;
					}
					this.PitchSpeed = num2;
					return;
				}
				break;
			case 11:
			{
				char c = key[0];
				if (c != 'M')
				{
					if (c == 'P')
					{
						if (key == "PitchOffset")
						{
							double num2;
							if (value is double)
							{
								double num18 = (double)value;
								num2 = num18;
							}
							else if (value is float)
							{
								float num19 = (float)value;
								num2 = (double)num19;
							}
							else if (value is int)
							{
								int num20 = (int)value;
								num2 = (double)num20;
							}
							else if (value is long)
							{
								long num21 = (long)value;
								num2 = (double)num21;
							}
							else
							{
								num2 = (double)value;
							}
							this.PitchOffset = num2;
							return;
						}
					}
				}
				else if (key == "MaxYawSpeed")
				{
					double num2;
					if (value is double)
					{
						double num22 = (double)value;
						num2 = num22;
					}
					else if (value is float)
					{
						float num23 = (float)value;
						num2 = (double)num23;
					}
					else if (value is int)
					{
						int num24 = (int)value;
						num2 = (double)num24;
					}
					else if (value is long)
					{
						long num25 = (long)value;
						num2 = (double)num25;
					}
					else
					{
						num2 = (double)value;
					}
					this.MaxYawSpeed = num2;
					return;
				}
				break;
			}
			case 12:
				if (key == "MoveDuration")
				{
					double num2;
					if (value is double)
					{
						double num26 = (double)value;
						num2 = num26;
					}
					else if (value is float)
					{
						float num27 = (float)value;
						num2 = (double)num27;
					}
					else if (value is int)
					{
						int num28 = (int)value;
						num2 = (double)num28;
					}
					else if (value is long)
					{
						long num29 = (long)value;
						num2 = (double)num29;
					}
					else
					{
						num2 = (double)value;
					}
					this.MoveDuration = num2;
					return;
				}
				break;
			case 14:
				if (key == "YawInterpSpeed")
				{
					double num2;
					if (value is double)
					{
						double num30 = (double)value;
						num2 = num30;
					}
					else if (value is float)
					{
						float num31 = (float)value;
						num2 = (double)num31;
					}
					else if (value is int)
					{
						int num32 = (int)value;
						num2 = (double)num32;
					}
					else if (value is long)
					{
						long num33 = (long)value;
						num2 = (double)num33;
					}
					else
					{
						num2 = (double)value;
					}
					this.YawInterpSpeed = num2;
					return;
				}
				break;
			case 15:
				if (key == "PitchAccelerate")
				{
					double num2;
					if (value is double)
					{
						double num34 = (double)value;
						num2 = num34;
					}
					else if (value is float)
					{
						float num35 = (float)value;
						num2 = (double)num35;
					}
					else if (value is int)
					{
						int num36 = (int)value;
						num2 = (double)num36;
					}
					else if (value is long)
					{
						long num37 = (long)value;
						num2 = (double)num37;
					}
					else
					{
						num2 = (double)value;
					}
					this.PitchAccelerate = num2;
					return;
				}
				break;
			case 16:
				if (key == "PitchInterpSpeed")
				{
					double num2;
					if (value is double)
					{
						double num38 = (double)value;
						num2 = num38;
					}
					else if (value is float)
					{
						float num39 = (float)value;
						num2 = (double)num39;
					}
					else if (value is int)
					{
						int num40 = (int)value;
						num2 = (double)num40;
					}
					else if (value is long)
					{
						long num41 = (long)value;
						num2 = (double)num41;
					}
					else
					{
						num2 = (double)value;
					}
					this.PitchInterpSpeed = num2;
					return;
				}
				break;
			case 21:
				if (key == "MoveDurationThreshold")
				{
					double num2;
					if (value is double)
					{
						double num42 = (double)value;
						num2 = num42;
					}
					else if (value is float)
					{
						float num43 = (float)value;
						num2 = (double)num43;
					}
					else if (value is int)
					{
						int num44 = (int)value;
						num2 = (double)num44;
					}
					else if (value is long)
					{
						long num45 = (long)value;
						num2 = (double)num45;
					}
					else
					{
						num2 = (double)value;
					}
					this.MoveDurationThreshold = num2;
					return;
				}
				break;
			case 23:
				if (key == "EnableDebugZoomModifier")
				{
					this.EnableDebugZoomModifier = (bool)value;
					return;
				}
				break;
			case 24:
			{
				char c = key[22];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "InputRecoverArmLengthMin")
						{
							double num2;
							if (value is double)
							{
								double num46 = (double)value;
								num2 = num46;
							}
							else if (value is float)
							{
								float num47 = (float)value;
								num2 = (double)num47;
							}
							else if (value is int)
							{
								int num48 = (int)value;
								num2 = (double)num48;
							}
							else if (value is long)
							{
								long num49 = (long)value;
								num2 = (double)num49;
							}
							else
							{
								num2 = (double)value;
							}
							this.InputRecoverArmLengthMin = num2;
							return;
						}
					}
				}
				else if (key == "InputRecoverArmLengthMax")
				{
					double num2;
					if (value is double)
					{
						double num50 = (double)value;
						num2 = num50;
					}
					else if (value is float)
					{
						float num51 = (float)value;
						num2 = (double)num51;
					}
					else if (value is int)
					{
						int num52 = (int)value;
						num2 = (double)num52;
					}
					else if (value is long)
					{
						long num53 = (long)value;
						num2 = (double)num53;
					}
					else
					{
						num2 = (double)value;
					}
					this.InputRecoverArmLengthMax = num2;
					return;
				}
				break;
			}
			case 26:
			{
				char c = key[21];
				if (c != 'C')
				{
					if (c == 'L')
					{
						if (key == "InputRecoverArmLengthLimit")
						{
							double num2;
							if (value is double)
							{
								double num54 = (double)value;
								num2 = num54;
							}
							else if (value is float)
							{
								float num55 = (float)value;
								num2 = (double)num55;
							}
							else if (value is int)
							{
								int num56 = (int)value;
								num2 = (double)num56;
							}
							else if (value is long)
							{
								long num57 = (long)value;
								num2 = (double)num57;
							}
							else
							{
								num2 = (double)value;
							}
							this.InputRecoverArmLengthLimit = num2;
							return;
						}
					}
				}
				else if (key == "InputRecoverArmLengthCurve")
				{
					this.InputRecoverArmLengthCurve = (CurveBase)value;
					return;
				}
				break;
			}
			case 29:
			{
				char c = key[27];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "InputRecoverArmLengthSpeedMin")
						{
							double num2;
							if (value is double)
							{
								double num58 = (double)value;
								num2 = num58;
							}
							else if (value is float)
							{
								float num59 = (float)value;
								num2 = (double)num59;
							}
							else if (value is int)
							{
								int num60 = (int)value;
								num2 = (double)num60;
							}
							else if (value is long)
							{
								long num61 = (long)value;
								num2 = (double)num61;
							}
							else
							{
								num2 = (double)value;
							}
							this.InputRecoverArmLengthSpeedMin = num2;
							return;
						}
					}
				}
				else if (key == "InputRecoverArmLengthSpeedMax")
				{
					double num2;
					if (value is double)
					{
						double num62 = (double)value;
						num2 = num62;
					}
					else if (value is float)
					{
						float num63 = (float)value;
						num2 = (double)num63;
					}
					else if (value is int)
					{
						int num64 = (int)value;
						num2 = (double)num64;
					}
					else if (value is long)
					{
						long num65 = (long)value;
						num2 = (double)num65;
					}
					else
					{
						num2 = (double)value;
					}
					this.InputRecoverArmLengthSpeedMax = num2;
					return;
				}
				break;
			}
			}
		}
		base.SetMember(key, value);
	}

	// Token: 0x06005615 RID: 22037 RVA: 0x000EB35F File Offset: 0x000E955F
	[NullableContext(0)]
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraSidestepController.<MemberIter>d__37 <MemberIter>d__ = new CameraSidestepController.<MemberIter>d__37(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x04001BBD RID: 7101
	public double YawInterpSpeed;

	// Token: 0x04001BBE RID: 7102
	public double PitchInterpSpeed;

	// Token: 0x04001BBF RID: 7103
	public double PitchAccelerate;

	// Token: 0x04001BC0 RID: 7104
	private double PitchSpeed;

	// Token: 0x04001BC1 RID: 7105
	public double PitchOffset;

	// Token: 0x04001BC2 RID: 7106
	public double MaxYawSpeed;

	// Token: 0x04001BC3 RID: 7107
	public double MaxPitch;

	// Token: 0x04001BC4 RID: 7108
	public double MinPitch;

	// Token: 0x04001BC5 RID: 7109
	public double MoveDurationThreshold = 1.0;

	// Token: 0x04001BC6 RID: 7110
	private double YawSpeed;

	// Token: 0x04001BC7 RID: 7111
	private double MoveDuration;

	// Token: 0x04001BC8 RID: 7112
	public double InputRecoverArmLengthMin;

	// Token: 0x04001BC9 RID: 7113
	public double InputRecoverArmLengthMax;

	// Token: 0x04001BCA RID: 7114
	public double InputRecoverArmLengthSpeedMin;

	// Token: 0x04001BCB RID: 7115
	public double InputRecoverArmLengthSpeedMax;

	// Token: 0x04001BCC RID: 7116
	public double InputRecoverArmLengthLimit;

	// Token: 0x04001BCD RID: 7117
	[Nullable(2)]
	public CurveBase InputRecoverArmLengthCurve;

	// Token: 0x04001BCE RID: 7118
	private readonly Vector CameraFacing = Vector.Create();

	// Token: 0x04001BCF RID: 7119
	private readonly Vector CharacterFacing = Vector.Create();

	// Token: 0x04001BD0 RID: 7120
	private readonly Vector GravityUp = Vector.Create();

	// Token: 0x04001BD1 RID: 7121
	private readonly Vector MoveNormal = Vector.Create();

	// Token: 0x04001BD2 RID: 7122
	private readonly Rotator TempRotator = Rotator.Create();

	// Token: 0x04001BD3 RID: 7123
	private readonly Rotator TempRotator2 = Rotator.Create();

	// Token: 0x04001BD4 RID: 7124
	private readonly Vector TempVector = Vector.Create();

	// Token: 0x04001BD5 RID: 7125
	private bool EnableDebugZoomModifier = true;
}
