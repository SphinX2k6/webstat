using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Platform.PlatformSdk;
using UnrealEngine;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004604 RID: 17924
	public class LauncherSdk : IStaticVariableResetter
	{
		// Token: 0x0602EE20 RID: 192032 RVA: 0x00B1A748 File Offset: 0x00B18948
		static LauncherSdk()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LauncherSdk.CreateStaticDefaultValue), new Action(LauncherSdk.ResetStaticDefaultValue));
		}

		// Token: 0x0602EE21 RID: 192033 RVA: 0x00B1A767 File Offset: 0x00B18967
		public static bool canUseSdk()
		{
			return !Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn && UKuroStaticLibrary.IsModuleLoaded("KuroSDK") && Singleton<BaseConfigController>.Instance.GetPublicValue("UseSDK") == "1";
		}

		// Token: 0x0602EE22 RID: 192034 RVA: 0x00B1A79C File Offset: 0x00B1899C
		[NullableContext(1)]
		public static LauncherSdkBase Get()
		{
			Platform instance = Singleton<Platform>.Instance;
			if (LauncherSdk.LauncherSdkInstance != null)
			{
				return LauncherSdk.LauncherSdkInstance;
			}
			if (!LauncherSdk.canUseSdk())
			{
				LauncherSdk.LauncherSdkInstance = new LauncherSdkBase();
			}
			else if (instance.IsAndroidPlatform())
			{
				LauncherSdk.LauncherSdkInstance = new LauncherSdkAndroid();
			}
			else if (instance.IsIOSPlatform())
			{
				LauncherSdk.LauncherSdkInstance = new LauncherSdkIosGlobal();
			}
			else if (instance.IsOpenHarmonyPlatform())
			{
				LauncherSdk.LauncherSdkInstance = new LauncherSdkOpenHarmony();
			}
			else if (instance.IsWindowsOnlyPlatform())
			{
				if (instance.CloudGamePlatform == ECloudGamePlatform.Android.ToEnumString() || instance.CloudGamePlatform == ECloudGamePlatform.IOS.ToEnumString() || instance.CloudGamePlatform == ECloudGamePlatform.Mac.ToEnumString() || instance.CloudGamePlatform == ECloudGamePlatform.Windows.ToEnumString())
				{
					LauncherSdk.LauncherSdkInstance = new LauncherSdkCloud();
				}
				else
				{
					LauncherSdk.LauncherSdkInstance = (LauncherSdk.IsGlobalSdk() ? new LauncherSdkWindowsGlobal() : new LauncherSdkWindows());
				}
			}
			else if (instance.IsMacPlatform())
			{
				LauncherSdk.LauncherSdkInstance = new LauncherSdkMacGlobal();
			}
			else if (instance.IsXboxPlatform())
			{
				LauncherSdk.LauncherSdkInstance = new LauncherSdkXboxGlobal();
			}
			if (LauncherSdk.LauncherSdkInstance == null)
			{
				Singleton<LauncherLog>.Instance.Error("LauncherSdkInstance is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				LauncherSdk.LauncherSdkInstance = new LauncherSdkBase();
			}
			return LauncherSdk.LauncherSdkInstance;
		}

		// Token: 0x0602EE23 RID: 192035 RVA: 0x00B1A8E5 File Offset: 0x00B18AE5
		public static void Init()
		{
			LauncherSdk.Get().Init();
		}

		// Token: 0x0602EE24 RID: 192036 RVA: 0x00B1A8F1 File Offset: 0x00B18AF1
		public static bool IsGlobalSdk()
		{
			return Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") != "CN" || (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn && Singleton<PlatformSdkConfig>.Instance.IsGlobal);
		}

		// Token: 0x0602EE25 RID: 192037 RVA: 0x00B1A928 File Offset: 0x00B18B28
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0602EE26 RID: 192038 RVA: 0x00B1A92A File Offset: 0x00B18B2A
		public static void ResetStaticDefaultValue()
		{
			LauncherSdk.LauncherSdkInstance = null;
		}

		// Token: 0x0401AAD0 RID: 109264
		[Nullable(2)]
		private static LauncherSdkBase LauncherSdkInstance;
	}
}
