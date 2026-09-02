using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Core.Common;

// Token: 0x02000E00 RID: 3584
[GeneratePropertyAccessMethod(true)]
public class CameraAdjustController : CameraControllerBase<EFightCameraAdjust>, ICanGetConfigMapValue
{
	// Token: 0x06005421 RID: 21537 RVA: 0x000C651B File Offset: 0x000C471B
	[NullableContext(1)]
	public CameraAdjustController(FightCameraLogicComponent camera) : base(camera)
	{
	}

	// Token: 0x06005422 RID: 21538 RVA: 0x000C652F File Offset: 0x000C472F
	[NullableContext(1)]
	public override string Name()
	{
		return "AdjustController";
	}

	// Token: 0x06005423 RID: 21539 RVA: 0x000C6538 File Offset: 0x000C4738
	protected override void OnInit()
	{
		base.SetConfigMap(EFightCameraAdjust.摄像机最小Pitch_目标比角色矮_, "CheckLowAdjustPitchMin");
		base.SetConfigMap(EFightCameraAdjust.摄像机最大Pitch_目标比角色矮_, "CheckLowAdjustPitchMax");
		base.SetConfigMap(EFightCameraAdjust.摄像机最小Pitch_目标比角色高_, "CheckTallAdjustPitchMin");
		base.SetConfigMap(EFightCameraAdjust.摄像机最大Pitch_目标比角色高_, "CheckTallAdjustPitchMax");
		base.SetConfigMap(EFightCameraAdjust.近距离范围, "CheckAdjustNearerRange");
		base.SetConfigMap(EFightCameraAdjust.近距离修正最小角度, "CheckAdjustNearerYawAngleMin");
		base.SetConfigMap(EFightCameraAdjust.近距离修正最大角度, "CheckAdjustNearerYawAngleMax");
		base.SetConfigMap(EFightCameraAdjust.远距离修正最小角度, "CheckAdjustFartherYawAngleMin");
		base.SetConfigMap(EFightCameraAdjust.远距离修正最大角度, "CheckAdjustFartherYawAngleMax");
		base.SetConfigMap(EFightCameraAdjust.检测屏幕内MinX, "CheckInScreenMinX");
		base.SetConfigMap(EFightCameraAdjust.检测屏幕内MaxX, "CheckInScreenMaxX");
		base.SetConfigMap(EFightCameraAdjust.检测屏幕内MinY, "CheckInScreenMinY");
		base.SetConfigMap(EFightCameraAdjust.检测屏幕内MaxY, "CheckInScreenMaxY");
		base.SetConfigMap(EFightCameraAdjust.技能修正过渡时间, "DefaultAdjustFadeTime");
		base.SetCurveConfigMap(EFightCameraAdjust.技能修正过渡时间, "DefaultAdjustFadeCurve");
		base.RegisterPairConfigKey(EFightCameraAdjust.摄像机最小Pitch_目标比角色矮_, EFightCameraAdjust.摄像机最大Pitch_目标比角色矮_, true);
		base.RegisterPairConfigKey(EFightCameraAdjust.摄像机最小Pitch_目标比角色高_, EFightCameraAdjust.摄像机最大Pitch_目标比角色高_, true);
		base.RegisterPairConfigKey(EFightCameraAdjust.近距离修正最小角度, EFightCameraAdjust.近距离修正最大角度, true);
		base.RegisterPairConfigKey(EFightCameraAdjust.远距离修正最小角度, EFightCameraAdjust.远距离修正最大角度, true);
		base.RegisterPairConfigKey(EFightCameraAdjust.检测屏幕内MinX, EFightCameraAdjust.检测屏幕内MaxX, true);
		base.RegisterPairConfigKey(EFightCameraAdjust.检测屏幕内MinY, EFightCameraAdjust.检测屏幕内MaxY, true);
	}

	// Token: 0x06005424 RID: 21540 RVA: 0x000C663B File Offset: 0x000C483B
	protected override void OnDisable()
	{
		if (this.IsAdjusting)
		{
			this.EndAdjust();
		}
	}

	// Token: 0x06005425 RID: 21541 RVA: 0x000C664C File Offset: 0x000C484C
	public void ApplyCameraAdjust()
	{
		if (!this.IsActivate)
		{
			return;
		}
		if (this.Camera.TargetEntity == null || !this.Camera.IsTargetLocationValid)
		{
			return;
		}
		Vector playerLocation = this.Camera.PlayerLocation;
		Vector targetLocation = this.Camera.TargetLocation;
		Rotator armRotation = this.Camera.CurrentCamera.ArmRotation;
		Vector vector = Vector.Create();
		armRotation.Vector(vector);
		targetLocation.Subtraction(playerLocation, this.TmpTargetOffset);
		bool flag = !this.TmpTargetOffset.IsNearlyZero(9.999999747378752E-05) && !vector.IsNearlyZero(9.999999747378752E-05);
		double num = this.TmpTargetOffset.CosineAngle2D(vector, 9.999999747378752E-05);
		double num2 = this.TmpTargetOffset.Size();
		double num3 = (double)((this.TmpTargetOffset.Z < 0.0) ? this.CheckLowAdjustPitchMin : this.CheckTallAdjustPitchMin);
		double num4 = (double)((this.TmpTargetOffset.Z < 0.0) ? this.CheckLowAdjustPitchMax : this.CheckTallAdjustPitchMax);
		float num5 = (num2 < (double)this.CheckAdjustNearerRange) ? this.CheckAdjustNearerYawAngleMin : this.CheckAdjustFartherYawAngleMin;
		float num6 = (num2 < (double)this.CheckAdjustNearerRange) ? this.CheckAdjustNearerYawAngleMax : this.CheckAdjustFartherYawAngleMax;
		this.IsAdjustedPitch = ((double)armRotation.Pitch < num3 || (double)armRotation.Pitch > num4);
		this.IsAdjustedYaw = (!flag || num > Math.Cos((double)(num5 * 0.017453292f)) || num < Math.Cos((double)(num6 * 0.017453292f)));
		bool flag2 = this.Camera.CheckPositionInScreen(targetLocation, this.CheckInScreenMinX, this.CheckInScreenMaxX, this.CheckInScreenMinY, this.CheckInScreenMaxY);
		if (flag2 && !this.IsAdjustedPitch && !this.IsAdjustedYaw)
		{
			return;
		}
		this.Camera.CameraAutoController.EnableForce(this);
		this.IsAdjustedYaw = true;
		this.IsAdjusting = true;
		this.AdjustElapsedTime = 0f;
		if (this.IsAdjustedYaw)
		{
			double num7 = this.TmpTargetOffset.SineAngle2D(vector, 9.999999747378752E-05);
			this.AdjustBeginRotatorYaw = this.Camera.CurrentCamera.ArmRotation.Yaw;
			Rotator rotator = Rotator.Create();
			this.TmpTargetOffset.Rotation(rotator);
			this.AdjustDesiredRotatorYaw = rotator.Yaw;
			if (num7 > 0.0)
			{
				if (!flag2 || num > Math.Cos((double)(num5 * 0.017453292f)))
				{
					this.AdjustDesiredRotatorYaw += num5;
				}
				else if (num < Math.Cos((double)(num6 * 0.017453292f)))
				{
					this.AdjustDesiredRotatorYaw += num6;
				}
				else
				{
					this.AdjustDesiredRotatorYaw = this.AdjustBeginRotatorYaw;
				}
			}
			else if (!flag2 || num > Math.Cos((double)(num5 * 0.017453292f)))
			{
				this.AdjustDesiredRotatorYaw -= num5;
			}
			else if (num < Math.Cos((double)(num6 * 0.017453292f)))
			{
				this.AdjustDesiredRotatorYaw -= num6;
			}
			else
			{
				this.AdjustDesiredRotatorYaw = this.AdjustBeginRotatorYaw;
			}
			if (this.AdjustBeginRotatorYaw - this.AdjustDesiredRotatorYaw > 180f)
			{
				this.AdjustDesiredRotatorYaw += 360f;
			}
			else if (this.AdjustDesiredRotatorYaw - this.AdjustBeginRotatorYaw > 180f)
			{
				this.AdjustDesiredRotatorYaw -= 360f;
			}
		}
		if (this.IsAdjustedPitch)
		{
			this.AdjustBeginRotatorPitch = (float)Singleton<MathUtils>.Instance.StandardizingPitch((double)this.Camera.CurrentCamera.ArmRotation.Pitch);
			this.AdjustDesiredRotatorPitch = (float)Singleton<MathUtils>.Instance.StandardizingPitch((double)this.Camera.AdjustPitch(this.TmpTargetOffset));
		}
	}

	// Token: 0x06005426 RID: 21542 RVA: 0x000C6A00 File Offset: 0x000C4C00
	protected override void UpdateInternal(float deltaTime)
	{
	}

	// Token: 0x06005427 RID: 21543 RVA: 0x000C6A0D File Offset: 0x000C4C0D
	private void EndAdjust()
	{
		this.Camera.CameraAutoController.DisableForce(this);
		this.IsAdjusting = false;
		this.IsAdjustedPitch = false;
		this.IsAdjustedYaw = false;
	}

	// Token: 0x06005428 RID: 21544 RVA: 0x000C6A35 File Offset: 0x000C4C35
	[NullableContext(1)]
	public override string GetConfigMapValue(int key)
	{
		return base.GetConfigMapValue((EFightCameraAdjust)key);
	}

	// Token: 0x06005429 RID: 21545 RVA: 0x000C6A40 File Offset: 0x000C4C40
	public override bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 11:
				if (key == "IsAdjusting")
				{
					value = this.IsAdjusting;
					return true;
				}
				break;
			case 13:
				if (key == "IsAdjustedYaw")
				{
					value = this.IsAdjustedYaw;
					return true;
				}
				break;
			case 15:
			{
				char c = key[0];
				if (c != 'I')
				{
					if (c == 'T')
					{
						if (key == "TmpTargetOffset")
						{
							value = this.TmpTargetOffset;
							return true;
						}
					}
				}
				else if (key == "IsAdjustedPitch")
				{
					value = this.IsAdjustedPitch;
					return true;
				}
				break;
			}
			case 17:
			{
				char c = key[15];
				if (c != 'm')
				{
					if (c != 'n')
					{
						if (c == 'x')
						{
							if (key == "CheckInScreenMaxX")
							{
								value = this.CheckInScreenMaxX;
								return true;
							}
							if (key == "CheckInScreenMaxY")
							{
								value = this.CheckInScreenMaxY;
								return true;
							}
						}
					}
					else
					{
						if (key == "CheckInScreenMinX")
						{
							value = this.CheckInScreenMinX;
							return true;
						}
						if (key == "CheckInScreenMinY")
						{
							value = this.CheckInScreenMinY;
							return true;
						}
					}
				}
				else if (key == "AdjustElapsedTime")
				{
					value = this.AdjustElapsedTime;
					return true;
				}
				break;
			}
			case 21:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c == 'D')
					{
						if (key == "DefaultAdjustFadeTime")
						{
							value = this.DefaultAdjustFadeTime;
							return true;
						}
					}
				}
				else if (key == "AdjustBeginRotatorYaw")
				{
					value = this.AdjustBeginRotatorYaw;
					return true;
				}
				break;
			}
			case 22:
			{
				char c = key[20];
				if (c <= 'g')
				{
					if (c != 'a')
					{
						if (c == 'g')
						{
							if (key == "CheckAdjustNearerRange")
							{
								value = this.CheckAdjustNearerRange;
								return true;
							}
						}
					}
					else if (key == "CheckLowAdjustPitchMax")
					{
						value = this.CheckLowAdjustPitchMax;
						return true;
					}
				}
				else if (c != 'i')
				{
					if (c == 'v')
					{
						if (key == "DefaultAdjustFadeCurve")
						{
							value = this.DefaultAdjustFadeCurve;
							return true;
						}
					}
				}
				else if (key == "CheckLowAdjustPitchMin")
				{
					value = this.CheckLowAdjustPitchMin;
					return true;
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
							if (key == "CheckTallAdjustPitchMin")
							{
								value = this.CheckTallAdjustPitchMin;
								return true;
							}
						}
					}
					else if (key == "AdjustBeginRotatorPitch")
					{
						value = this.AdjustBeginRotatorPitch;
						return true;
					}
				}
				else if (c != 'w')
				{
					if (c == 'x')
					{
						if (key == "CheckTallAdjustPitchMax")
						{
							value = this.CheckTallAdjustPitchMax;
							return true;
						}
					}
				}
				else if (key == "AdjustDesiredRotatorYaw")
				{
					value = this.AdjustDesiredRotatorYaw;
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
			case 28:
			{
				char c = key[26];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "CheckAdjustNearerYawAngleMin")
						{
							value = this.CheckAdjustNearerYawAngleMin;
							return true;
						}
					}
				}
				else if (key == "CheckAdjustNearerYawAngleMax")
				{
					value = this.CheckAdjustNearerYawAngleMax;
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
						if (key == "CheckAdjustFartherYawAngleMin")
						{
							value = this.CheckAdjustFartherYawAngleMin;
							return true;
						}
					}
				}
				else if (key == "CheckAdjustFartherYawAngleMax")
				{
					value = this.CheckAdjustFartherYawAngleMax;
					return true;
				}
				break;
			}
			}
		}
		return base.TryGetMember(key, out value);
	}

	// Token: 0x0600542A RID: 21546 RVA: 0x000C6F14 File Offset: 0x000C5114
	public override void SetMember(string key, object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 11:
				if (key == "IsAdjusting")
				{
					this.IsAdjusting = (bool)value;
					return;
				}
				break;
			case 13:
				if (key == "IsAdjustedYaw")
				{
					this.IsAdjustedYaw = (bool)value;
					return;
				}
				break;
			case 15:
				if (key == "IsAdjustedPitch")
				{
					this.IsAdjustedPitch = (bool)value;
					return;
				}
				break;
			case 17:
			{
				char c = key[15];
				if (c != 'm')
				{
					if (c != 'n')
					{
						if (c == 'x')
						{
							if (key == "CheckInScreenMaxX")
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
								this.CheckInScreenMaxX = num2;
								return;
							}
							if (key == "CheckInScreenMaxY")
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
								this.CheckInScreenMaxY = num2;
								return;
							}
						}
					}
					else
					{
						if (key == "CheckInScreenMinX")
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
							this.CheckInScreenMinX = num2;
							return;
						}
						if (key == "CheckInScreenMinY")
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
							this.CheckInScreenMinY = num2;
							return;
						}
					}
				}
				else if (key == "AdjustElapsedTime")
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
					this.AdjustElapsedTime = num2;
					return;
				}
				break;
			}
			case 21:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c == 'D')
					{
						if (key == "DefaultAdjustFadeTime")
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
							this.DefaultAdjustFadeTime = num2;
							return;
						}
					}
				}
				else if (key == "AdjustBeginRotatorYaw")
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
					this.AdjustBeginRotatorYaw = num2;
					return;
				}
				break;
			}
			case 22:
			{
				char c = key[20];
				if (c <= 'g')
				{
					if (c != 'a')
					{
						if (c == 'g')
						{
							if (key == "CheckAdjustNearerRange")
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
								this.CheckAdjustNearerRange = num2;
								return;
							}
						}
					}
					else if (key == "CheckLowAdjustPitchMax")
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
						this.CheckLowAdjustPitchMax = num2;
						return;
					}
				}
				else if (c != 'i')
				{
					if (c == 'v')
					{
						if (key == "DefaultAdjustFadeCurve")
						{
							this.DefaultAdjustFadeCurve = (CurveBase)value;
							return;
						}
					}
				}
				else if (key == "CheckLowAdjustPitchMin")
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
					this.CheckLowAdjustPitchMin = num2;
					return;
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
							if (key == "CheckTallAdjustPitchMin")
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
								this.CheckTallAdjustPitchMin = num2;
								return;
							}
						}
					}
					else if (key == "AdjustBeginRotatorPitch")
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
						this.AdjustBeginRotatorPitch = num2;
						return;
					}
				}
				else if (c != 'w')
				{
					if (c == 'x')
					{
						if (key == "CheckTallAdjustPitchMax")
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
							this.CheckTallAdjustPitchMax = num2;
							return;
						}
					}
				}
				else if (key == "AdjustDesiredRotatorYaw")
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
					this.AdjustDesiredRotatorPitch = num2;
					return;
				}
				break;
			case 28:
			{
				char c = key[26];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "CheckAdjustNearerYawAngleMin")
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
							this.CheckAdjustNearerYawAngleMin = num2;
							return;
						}
					}
				}
				else if (key == "CheckAdjustNearerYawAngleMax")
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
					this.CheckAdjustNearerYawAngleMax = num2;
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
						if (key == "CheckAdjustFartherYawAngleMin")
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
							this.CheckAdjustFartherYawAngleMin = num2;
							return;
						}
					}
				}
				else if (key == "CheckAdjustFartherYawAngleMax")
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
					this.CheckAdjustFartherYawAngleMax = num2;
					return;
				}
				break;
			}
			}
		}
		base.SetMember(key, value);
	}

	// Token: 0x0600542B RID: 21547 RVA: 0x000C7B37 File Offset: 0x000C5D37
	public override IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		CameraAdjustController.<MemberIter>d__34 <MemberIter>d__ = new CameraAdjustController.<MemberIter>d__34(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x040018CF RID: 6351
	public float CheckLowAdjustPitchMin;

	// Token: 0x040018D0 RID: 6352
	public float CheckLowAdjustPitchMax;

	// Token: 0x040018D1 RID: 6353
	public float CheckTallAdjustPitchMin;

	// Token: 0x040018D2 RID: 6354
	public float CheckTallAdjustPitchMax;

	// Token: 0x040018D3 RID: 6355
	public float CheckAdjustNearerRange;

	// Token: 0x040018D4 RID: 6356
	public float CheckAdjustNearerYawAngleMin;

	// Token: 0x040018D5 RID: 6357
	public float CheckAdjustNearerYawAngleMax;

	// Token: 0x040018D6 RID: 6358
	public float CheckAdjustFartherYawAngleMin;

	// Token: 0x040018D7 RID: 6359
	public float CheckAdjustFartherYawAngleMax;

	// Token: 0x040018D8 RID: 6360
	public float CheckInScreenMinX;

	// Token: 0x040018D9 RID: 6361
	public float CheckInScreenMaxX;

	// Token: 0x040018DA RID: 6362
	public float CheckInScreenMinY;

	// Token: 0x040018DB RID: 6363
	public float CheckInScreenMaxY;

	// Token: 0x040018DC RID: 6364
	public float DefaultAdjustFadeTime;

	// Token: 0x040018DD RID: 6365
	[Nullable(2)]
	public CurveBase DefaultAdjustFadeCurve;

	// Token: 0x040018DE RID: 6366
	private bool IsAdjusting;

	// Token: 0x040018DF RID: 6367
	private bool IsAdjustedPitch;

	// Token: 0x040018E0 RID: 6368
	private float AdjustBeginRotatorPitch;

	// Token: 0x040018E1 RID: 6369
	private float AdjustDesiredRotatorPitch;

	// Token: 0x040018E2 RID: 6370
	private bool IsAdjustedYaw;

	// Token: 0x040018E3 RID: 6371
	private float AdjustBeginRotatorYaw;

	// Token: 0x040018E4 RID: 6372
	private float AdjustDesiredRotatorYaw;

	// Token: 0x040018E5 RID: 6373
	private float AdjustElapsedTime;

	// Token: 0x040018E6 RID: 6374
	[Nullable(1)]
	private readonly Vector TmpTargetOffset = Vector.Create();
}
