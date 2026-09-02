using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FEE RID: 28654
	[NullableContext(1)]
	[Nullable(0)]
	public class InputKeyUtils
	{
		// Token: 0x0604556C RID: 284012 RVA: 0x0121D164 File Offset: 0x0121B364
		public static string GetGamepadKeyIconPath(string keyName)
		{
			GamepadKey? gamepadKeyConfig = ConfigBase<InputSettingsConfig>.Instance.GetGamepadKeyConfig(keyName);
			if (gamepadKeyConfig == null)
			{
				return "";
			}
			GamepadKey valueOrDefault = gamepadKeyConfig.GetValueOrDefault();
			if (Singleton<Info>.Instance.IsPsGamepad())
			{
				return valueOrDefault.PsKeyIconPath;
			}
			if (Singleton<Info>.Instance.IsBackBoneGamepad())
			{
				return valueOrDefault.BackBoneKeyIconPath;
			}
			if (Singleton<Info>.Instance.IsNsProGamepad())
			{
				return valueOrDefault.NsKeyIconPath;
			}
			return valueOrDefault.KeyIconPath;
		}

		// Token: 0x0604556D RID: 284013 RVA: 0x0121D1DC File Offset: 0x0121B3DC
		public static string GetGamepadKeyIconPathByType(string keyName, EInputControllerType type)
		{
			GamepadKey? gamepadKeyConfig = ConfigBase<InputSettingsConfig>.Instance.GetGamepadKeyConfig(keyName);
			if (gamepadKeyConfig == null)
			{
				return "";
			}
			GamepadKey valueOrDefault = gamepadKeyConfig.GetValueOrDefault();
			if (type == EInputControllerType.PS4 || type == EInputControllerType.PS5)
			{
				return valueOrDefault.PsKeyIconPath;
			}
			if (type == EInputControllerType.BackBone)
			{
				return valueOrDefault.BackBoneKeyIconPath;
			}
			if (type == EInputControllerType.NsPro)
			{
				return valueOrDefault.NsKeyIconPath;
			}
			if (type == EInputControllerType.XboxOne)
			{
				return valueOrDefault.KeyIconPath;
			}
			return "";
		}

		// Token: 0x0604556E RID: 284014 RVA: 0x0121D248 File Offset: 0x0121B448
		[return: Nullable(2)]
		public static string GetPcKeyIconPathByCurrentPlatform(string keyName)
		{
			PcKey? pcKeyConfig = ConfigBase<InputSettingsConfig>.Instance.GetPcKeyConfig(keyName);
			if (pcKeyConfig == null)
			{
				return null;
			}
			PcKey valueOrDefault = pcKeyConfig.GetValueOrDefault();
			if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Mac)
			{
				return valueOrDefault.MacKeyIconPath;
			}
			if (Singleton<InputSettingsManager>.Instance.CheckUseFrenchKeyboard && !StringUtils.IsBlank(valueOrDefault.FrenchKeyIconPath))
			{
				return valueOrDefault.FrenchKeyIconPath;
			}
			return LanguageKeyTransUtils.GetKeyTrans(Singleton<InputSettingsManager>.Instance.CurrentDeviceLang).GetPcKeyIconPath(valueOrDefault);
		}

		// Token: 0x0604556F RID: 284015 RVA: 0x0121D2C2 File Offset: 0x0121B4C2
		public static EInputControllerType GetLastGamepadEnum()
		{
			if (Singleton<Info>.Instance.IsPs5Platform())
			{
				return EInputControllerType.PS5;
			}
			return LocalStorage.GetGlobal<EInputControllerType>(ELocalStorageGlobalKey.LastGamepadEnum, EInputControllerType.XboxOne);
		}

		// Token: 0x06045570 RID: 284016 RVA: 0x0121D2E0 File Offset: 0x0121B4E0
		public static string ConvertKeyToActionOrAxis(string keyName, bool isActionOrAxis)
		{
			if (isActionOrAxis && keyName == EKey.Gamepad_LeftTriggerAxis)
			{
				return EKey.Gamepad_LeftTrigger;
			}
			if (isActionOrAxis && keyName == EKey.Gamepad_RightTriggerAxis)
			{
				return EKey.Gamepad_RightTrigger;
			}
			if (!isActionOrAxis && keyName == EKey.Gamepad_LeftTrigger)
			{
				return EKey.Gamepad_LeftTriggerAxis;
			}
			if (!isActionOrAxis && keyName == EKey.Gamepad_RightTrigger)
			{
				return EKey.Gamepad_RightTriggerAxis;
			}
			return keyName;
		}
	}
}
