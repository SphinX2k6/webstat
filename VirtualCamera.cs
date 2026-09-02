using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

// Token: 0x02000E37 RID: 3639
[GeneratePropertyAccessMethod(true)]
public class VirtualCamera : IClear
{
	// Token: 0x06005645 RID: 22085 RVA: 0x000ECF4B File Offset: 0x000EB14B
	public bool ClearObject()
	{
		return true;
	}

	// Token: 0x06005646 RID: 22086 RVA: 0x000ECF50 File Offset: 0x000EB150
	public virtual bool TryGetMember(string key, out object value)
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
			case 8:
				if (key == "CharAddZ")
				{
					value = this.CharAddZ;
					return true;
				}
				break;
			case 9:
			{
				char c = key[3];
				if (c != 'L')
				{
					if (c == 'O')
					{
						if (key == "ArmOffset")
						{
							value = this.ArmOffset;
							return true;
						}
					}
				}
				else if (key == "ArmLength")
				{
					value = this.ArmLength;
					return true;
				}
				break;
			}
			case 10:
				if (key == "DynamicFov")
				{
					value = this.DynamicFov;
					return true;
				}
				break;
			case 11:
			{
				char c = key[5];
				if (c <= 'c')
				{
					if (c != 'Y')
					{
						if (c == 'c')
						{
							if (key == "ArmLocation")
							{
								value = this.ArmLocation;
								return true;
							}
						}
					}
					else
					{
						if (key == "WorldYawMin")
						{
							value = this.WorldYawMin;
							return true;
						}
						if (key == "WorldYawMax")
						{
							value = this.WorldYawMax;
							return true;
						}
					}
				}
				else if (c != 'm')
				{
					if (c == 't')
					{
						if (key == "ArmRotation")
						{
							value = this.ArmRotation;
							return true;
						}
					}
				}
				else
				{
					if (key == "YawLimitMin")
					{
						value = this.YawLimitMin;
						return true;
					}
					if (key == "YawLimitMax")
					{
						value = this.YawLimitMax;
						return true;
					}
				}
				break;
			}
			case 12:
			{
				char c = key[2];
				switch (c)
				{
				case 'm':
					if (key == "CameraOffset")
					{
						value = this.CameraOffset;
						return true;
					}
					break;
				case 'n':
					if (key == "MinArmLength")
					{
						value = this.MinArmLength;
						return true;
					}
					break;
				case 'o':
					if (key == "ZoomModifier")
					{
						value = this.ZoomModifier;
						return true;
					}
					break;
				case 'p':
				case 'q':
					break;
				case 'r':
					if (key == "WorldRollMin")
					{
						value = this.WorldRollMin;
						return true;
					}
					if (key == "WorldRollMax")
					{
						value = this.WorldRollMax;
						return true;
					}
					break;
				default:
					if (c == 'x')
					{
						if (key == "MaxArmLength")
						{
							value = this.MaxArmLength;
							return true;
						}
					}
					break;
				}
				break;
			}
			case 13:
			{
				char c = key[0];
				if (c != 'D')
				{
					if (c != 'L')
					{
						if (c == 'P')
						{
							if (key == "PitchLimitMin")
							{
								value = this.PitchLimitMin;
								return true;
							}
							if (key == "PitchLimitMax")
							{
								value = this.PitchLimitMax;
								return true;
							}
						}
					}
					else if (key == "LookUpOffsetZ")
					{
						value = this.LookUpOffsetZ;
						return true;
					}
				}
				else
				{
					if (key == "DynamicFovMin")
					{
						value = this.DynamicFovMin;
						return true;
					}
					if (key == "DynamicFovMax")
					{
						value = this.DynamicFovMax;
						return true;
					}
				}
				break;
			}
			case 15:
				if (key == "LookDownOffsetZ")
				{
					value = this.LookDownOffsetZ;
					return true;
				}
				break;
			case 16:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'E')
					{
						if (key == "EnableDynamicFov")
						{
							value = this.EnableDynamicFov;
							return true;
						}
					}
				}
				else if (key == "CharAddArmLength")
				{
					value = this.CharAddArmLength;
					return true;
				}
				break;
			}
			case 18:
			{
				char c = key[16];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "DynamicFovParamMin")
						{
							value = this.DynamicFovParamMin;
							return true;
						}
					}
				}
				else if (key == "DynamicFovParamMax")
				{
					value = this.DynamicFovParamMax;
					return true;
				}
				break;
			}
			case 19:
				if (key == "DynamicFovLerpSpeed")
				{
					value = this.DynamicFovLerpSpeed;
					return true;
				}
				break;
			case 22:
			{
				char c = key[20];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "CameraOffsetFloatUpMin")
						{
							value = this.CameraOffsetFloatUpMin;
							return true;
						}
					}
				}
				else if (key == "CameraOffsetFloatUpMax")
				{
					value = this.CameraOffsetFloatUpMax;
					return true;
				}
				break;
			}
			}
		}
		value = null;
		return false;
	}

	// Token: 0x06005647 RID: 22087 RVA: 0x000ED4E0 File Offset: 0x000EB6E0
	public virtual void SetMember(string key, object value)
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
			case 8:
				if (key == "CharAddZ")
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
					this.CharAddZ = num2;
					return;
				}
				break;
			case 9:
			{
				char c = key[3];
				if (c != 'L')
				{
					if (c == 'O')
					{
						if (key == "ArmOffset")
						{
							this.ArmOffset = (Vector)value;
							return;
						}
					}
				}
				else if (key == "ArmLength")
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
					this.ArmLength = num2;
					return;
				}
				break;
			}
			case 10:
				if (key == "DynamicFov")
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
					this.DynamicFov = num2;
					return;
				}
				break;
			case 11:
			{
				char c = key[5];
				if (c <= 'c')
				{
					if (c != 'Y')
					{
						if (c == 'c')
						{
							if (key == "ArmLocation")
							{
								this.ArmLocation = (Vector)value;
								return;
							}
						}
					}
					else
					{
						if (key == "WorldYawMin")
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
							this.WorldYawMin = num2;
							return;
						}
						if (key == "WorldYawMax")
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
							this.WorldYawMax = num2;
							return;
						}
					}
				}
				else if (c != 'm')
				{
					if (c == 't')
					{
						if (key == "ArmRotation")
						{
							this.ArmRotation = (Rotator)value;
							return;
						}
					}
				}
				else
				{
					if (key == "YawLimitMin")
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
						this.YawLimitMin = num2;
						return;
					}
					if (key == "YawLimitMax")
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
						this.YawLimitMax = num2;
						return;
					}
				}
				break;
			}
			case 12:
			{
				char c = key[2];
				switch (c)
				{
				case 'm':
					if (key == "CameraOffset")
					{
						this.CameraOffset = (Vector)value;
						return;
					}
					break;
				case 'n':
					if (key == "MinArmLength")
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
						this.MinArmLength = num2;
						return;
					}
					break;
				case 'o':
					if (key == "ZoomModifier")
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
						this.ZoomModifier = num2;
						return;
					}
					break;
				case 'p':
				case 'q':
					break;
				case 'r':
					if (key == "WorldRollMin")
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
						this.WorldRollMin = num2;
						return;
					}
					if (key == "WorldRollMax")
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
						this.WorldRollMax = num2;
						return;
					}
					break;
				default:
					if (c == 'x')
					{
						if (key == "MaxArmLength")
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
							this.MaxArmLength = num2;
							return;
						}
					}
					break;
				}
				break;
			}
			case 13:
			{
				char c = key[0];
				if (c != 'D')
				{
					if (c != 'L')
					{
						if (c == 'P')
						{
							if (key == "PitchLimitMin")
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
								this.PitchLimitMin = num2;
								return;
							}
							if (key == "PitchLimitMax")
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
								this.PitchLimitMax = num2;
								return;
							}
						}
					}
					else if (key == "LookUpOffsetZ")
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
						this.LookUpOffsetZ = num2;
						return;
					}
				}
				else
				{
					if (key == "DynamicFovMin")
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
						this.DynamicFovMin = num2;
						return;
					}
					if (key == "DynamicFovMax")
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
						this.DynamicFovMax = num2;
						return;
					}
				}
				break;
			}
			case 15:
				if (key == "LookDownOffsetZ")
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
					this.LookDownOffsetZ = num2;
					return;
				}
				break;
			case 16:
			{
				char c = key[0];
				if (c != 'C')
				{
					if (c == 'E')
					{
						if (key == "EnableDynamicFov")
						{
							this.EnableDynamicFov = (bool)value;
							return;
						}
					}
				}
				else if (key == "CharAddArmLength")
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
					this.CharAddArmLength = num2;
					return;
				}
				break;
			}
			case 18:
			{
				char c = key[16];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "DynamicFovParamMin")
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
							this.DynamicFovParamMin = num2;
							return;
						}
					}
				}
				else if (key == "DynamicFovParamMax")
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
					this.DynamicFovParamMax = num2;
					return;
				}
				break;
			}
			case 19:
				if (key == "DynamicFovLerpSpeed")
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
					this.DynamicFovLerpSpeed = num2;
					return;
				}
				break;
			case 22:
			{
				char c = key[20];
				if (c != 'a')
				{
					if (c == 'i')
					{
						if (key == "CameraOffsetFloatUpMin")
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
							this.CameraOffsetFloatUpMin = num2;
							return;
						}
					}
				}
				else if (key == "CameraOffsetFloatUpMax")
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
					this.CameraOffsetFloatUpMax = num2;
					return;
				}
				break;
			}
			}
		}
		throw new KeyNotFoundException("设置VirtualCamera成员属性失败" + key + ")");
	}

	// Token: 0x06005648 RID: 22088 RVA: 0x000EE47B File Offset: 0x000EC67B
	public virtual IEnumerable<ValueTuple<string, object>> MemberIter()
	{
		VirtualCamera.<MemberIter>d__33 <MemberIter>d__ = new VirtualCamera.<MemberIter>d__33(-2);
		<MemberIter>d__.<>4__this = this;
		return <MemberIter>d__;
	}

	// Token: 0x04001C13 RID: 7187
	[Nullable(1)]
	public Vector ArmOffset = Vector.Create();

	// Token: 0x04001C14 RID: 7188
	public float ArmLength;

	// Token: 0x04001C15 RID: 7189
	public float MinArmLength;

	// Token: 0x04001C16 RID: 7190
	public float MaxArmLength;

	// Token: 0x04001C17 RID: 7191
	public float YawLimitMin;

	// Token: 0x04001C18 RID: 7192
	public float YawLimitMax;

	// Token: 0x04001C19 RID: 7193
	public float PitchLimitMin;

	// Token: 0x04001C1A RID: 7194
	public float PitchLimitMax;

	// Token: 0x04001C1B RID: 7195
	public float LookDownOffsetZ;

	// Token: 0x04001C1C RID: 7196
	public float LookUpOffsetZ;

	// Token: 0x04001C1D RID: 7197
	[Nullable(1)]
	public Vector CameraOffset = Vector.Create();

	// Token: 0x04001C1E RID: 7198
	public float Fov;

	// Token: 0x04001C1F RID: 7199
	public bool EnableDynamicFov;

	// Token: 0x04001C20 RID: 7200
	public float DynamicFov;

	// Token: 0x04001C21 RID: 7201
	public float DynamicFovMin;

	// Token: 0x04001C22 RID: 7202
	public float DynamicFovMax;

	// Token: 0x04001C23 RID: 7203
	public float DynamicFovParamMin;

	// Token: 0x04001C24 RID: 7204
	public float DynamicFovParamMax;

	// Token: 0x04001C25 RID: 7205
	public float DynamicFovLerpSpeed;

	// Token: 0x04001C26 RID: 7206
	[Nullable(1)]
	public Vector ArmLocation = Vector.Create();

	// Token: 0x04001C27 RID: 7207
	[Nullable(1)]
	public Rotator ArmRotation = Rotator.Create();

	// Token: 0x04001C28 RID: 7208
	public float ZoomModifier = 1f;

	// Token: 0x04001C29 RID: 7209
	public float WorldYawMin;

	// Token: 0x04001C2A RID: 7210
	public float WorldYawMax;

	// Token: 0x04001C2B RID: 7211
	public float WorldRollMin;

	// Token: 0x04001C2C RID: 7212
	public float WorldRollMax;

	// Token: 0x04001C2D RID: 7213
	public float CameraOffsetFloatUpMin;

	// Token: 0x04001C2E RID: 7214
	public float CameraOffsetFloatUpMax;

	// Token: 0x04001C2F RID: 7215
	public float CharAddArmLength;

	// Token: 0x04001C30 RID: 7216
	public float CharAddZ;
}
