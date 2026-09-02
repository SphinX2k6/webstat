using System;

namespace CSharpScript.Game.LevelGamePlay.Guarantee
{
	// Token: 0x02006E6D RID: 28269
	public static class EGuaranteeActionExtensions
	{
		// Token: 0x06044975 RID: 280949 RVA: 0x011D4CD4 File Offset: 0x011D2ED4
		public static string ToEnumString(this EGuaranteeAction value)
		{
			string result;
			switch (value)
			{
			case EGuaranteeAction.EnablePlayerMoveControl:
				result = "EnablePlayerMoveControl";
				break;
			case EGuaranteeAction.ExitOrbitalCamera:
				result = "ExitOrbitalCamera";
				break;
			case EGuaranteeAction.RestorePlayerCameraAdjustment:
				result = "RestorePlayerCameraAdjustment";
				break;
			case EGuaranteeAction.UnLimitPlayerOperation:
				result = "UnLimitPlayerOperation";
				break;
			case EGuaranteeAction.ActionBlackScreenFadeOut:
				result = "ActionBlackScreenFadeOut";
				break;
			case EGuaranteeAction.DisableSplineMoveModel:
				result = "DisableSplineMoveModel";
				break;
			case EGuaranteeAction.StopEffect:
				result = "StopEffect";
				break;
			case EGuaranteeAction.Preload:
				result = "Preload";
				break;
			case EGuaranteeAction.DisableKey4Func:
				result = "DisableKey4Func";
				break;
			case EGuaranteeAction.ActionExitMovieMode:
				result = "ActionExitMovieMode";
				break;
			case EGuaranteeAction.StopGamepadShake:
				result = "StopGamepadShake";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06044976 RID: 280950 RVA: 0x011D4D7C File Offset: 0x011D2F7C
		public static EGuaranteeAction FromString(string name)
		{
			EGuaranteeAction result;
			if (!EGuaranteeActionExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EGuaranteeAction 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06044977 RID: 280951 RVA: 0x011D4DA8 File Offset: 0x011D2FA8
		public static bool TryFromString(string name, out EGuaranteeAction value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EGuaranteeAction.EnablePlayerMoveControl;
				return false;
			}
			if (name != null)
			{
				int length = name.Length;
				if (length != 7)
				{
					switch (length)
					{
					case 10:
						if (name == "StopEffect")
						{
							value = EGuaranteeAction.StopEffect;
							return true;
						}
						break;
					case 11:
					case 12:
					case 13:
					case 14:
					case 18:
					case 20:
					case 21:
						break;
					case 15:
						if (name == "DisableKey4Func")
						{
							value = EGuaranteeAction.DisableKey4Func;
							return true;
						}
						break;
					case 16:
						if (name == "StopGamepadShake")
						{
							value = EGuaranteeAction.StopGamepadShake;
							return true;
						}
						break;
					case 17:
						if (name == "ExitOrbitalCamera")
						{
							value = EGuaranteeAction.ExitOrbitalCamera;
							return true;
						}
						break;
					case 19:
						if (name == "ActionExitMovieMode")
						{
							value = EGuaranteeAction.ActionExitMovieMode;
							return true;
						}
						break;
					case 22:
					{
						char c = name[0];
						if (c != 'D')
						{
							if (c == 'U')
							{
								if (name == "UnLimitPlayerOperation")
								{
									value = EGuaranteeAction.UnLimitPlayerOperation;
									return true;
								}
							}
						}
						else if (name == "DisableSplineMoveModel")
						{
							value = EGuaranteeAction.DisableSplineMoveModel;
							return true;
						}
						break;
					}
					case 23:
						if (name == "EnablePlayerMoveControl")
						{
							value = EGuaranteeAction.EnablePlayerMoveControl;
							return true;
						}
						break;
					case 24:
						if (name == "ActionBlackScreenFadeOut")
						{
							value = EGuaranteeAction.ActionBlackScreenFadeOut;
							return true;
						}
						break;
					default:
						if (length == 29)
						{
							if (name == "RestorePlayerCameraAdjustment")
							{
								value = EGuaranteeAction.RestorePlayerCameraAdjustment;
								return true;
							}
						}
						break;
					}
				}
				else if (name == "Preload")
				{
					value = EGuaranteeAction.Preload;
					return true;
				}
			}
			value = EGuaranteeAction.EnablePlayerMoveControl;
			return false;
		}

		// Token: 0x06044978 RID: 280952 RVA: 0x011D4F3C File Offset: 0x011D313C
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"EnablePlayerMoveControl",
				"ExitOrbitalCamera",
				"RestorePlayerCameraAdjustment",
				"UnLimitPlayerOperation",
				"ActionBlackScreenFadeOut",
				"DisableSplineMoveModel",
				"StopEffect",
				"Preload",
				"DisableKey4Func",
				"ActionExitMovieMode",
				"StopGamepadShake"
			};
		}

		// Token: 0x06044979 RID: 280953 RVA: 0x011D4FAA File Offset: 0x011D31AA
		public static EGuaranteeAction[] GetValues()
		{
			return new EGuaranteeAction[]
			{
				EGuaranteeAction.EnablePlayerMoveControl,
				EGuaranteeAction.ExitOrbitalCamera,
				EGuaranteeAction.RestorePlayerCameraAdjustment,
				EGuaranteeAction.UnLimitPlayerOperation,
				EGuaranteeAction.ActionBlackScreenFadeOut,
				EGuaranteeAction.DisableSplineMoveModel,
				EGuaranteeAction.StopEffect,
				EGuaranteeAction.Preload,
				EGuaranteeAction.DisableKey4Func,
				EGuaranteeAction.ActionExitMovieMode,
				EGuaranteeAction.StopGamepadShake
			};
		}

		// Token: 0x0604497A RID: 280954 RVA: 0x011D4FC0 File Offset: 0x011D31C0
		public static string[] GetNames()
		{
			return new string[]
			{
				"EnablePlayerMoveControl",
				"ExitOrbitalCamera",
				"RestorePlayerCameraAdjustment",
				"UnLimitPlayerOperation",
				"ActionBlackScreenFadeOut",
				"DisableSplineMoveModel",
				"StopEffect",
				"Preload",
				"DisableKey4Func",
				"ActionExitMovieMode",
				"StopGamepadShake"
			};
		}
	}
}
