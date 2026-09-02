using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform;
using CSharpScript.Typing;
using UnrealEngine;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044BB RID: 17595
	[NullableContext(1)]
	[Nullable(0)]
	public class AppUtil
	{
		// Token: 0x0602E702 RID: 190210 RVA: 0x00AFE093 File Offset: 0x00AFC293
		public static void SetWorldContext(UObject worldContext)
		{
		}

		// Token: 0x0602E703 RID: 190211 RVA: 0x00AFE098 File Offset: 0x00AFC298
		public static void QuitGame(string reason = "")
		{
			if (Singleton<Platform>.Instance.IsPs5Platform())
			{
				Singleton<LauncherLog>.Instance.Error("Ps平台不允许主动退出", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (Singleton<Platform>.Instance.IsCloudGameRunningHotPatch())
			{
				KuroApplication.ExitWithCode(false, reason, 1);
				return;
			}
			KuroApplication.ExitWithReason(false, reason);
		}

		// Token: 0x0602E704 RID: 190212 RVA: 0x00AFE0E8 File Offset: 0x00AFC2E8
		public unsafe static void QuitGameOnPatchSuccess(string reason = "", bool hasUpdate = true)
		{
			if (!Singleton<Platform>.Instance.IsCloudGameRunningHotPatch())
			{
				return;
			}
			int num = hasUpdate ? 0 : 2;
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[ExitCode] QuitGameOnPatchSuccess";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("hasUpdate", hasUpdate);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("exitCode", num);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			KuroApplication.ExitWithCode(false, reason, num);
		}

		// Token: 0x0602E705 RID: 190213 RVA: 0x00AFE184 File Offset: 0x00AFC384
		public unsafe static ENetworkType GetNetworkConnectionType()
		{
			string text = KuroApplication.IniPlatformName();
			if (text != "Android" && text != "IOS" && text != "OpenHarmony")
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "当前非安卓、鸿蒙、ios平台, 网络类型无法判断, 默认Ethernet";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("platform", text);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("networkType", ENetworkType.Ethernet);
				instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return ENetworkType.Ethernet;
			}
			return (ENetworkType)UKuroLauncherLibrary.GetNetworkConnectionType();
		}

		// Token: 0x0602E706 RID: 190214 RVA: 0x00AFE219 File Offset: 0x00AFC419
		public static bool IsPioneerApp()
		{
			return Singleton<BaseConfigController>.Instance.GetPublicValue("AppTag") == "Pioneer";
		}

		// Token: 0x0602E707 RID: 190215 RVA: 0x00AFE234 File Offset: 0x00AFC434
		public static string GetAppVersion()
		{
			return UKuroLauncherLibrary.GetAppVersion();
		}

		// Token: 0x0401A5F6 RID: 108022
		private const string PIONEER_APP_TAG = "Pioneer";
	}
}
