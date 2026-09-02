using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Util;
using UnrealEngine;

namespace CSharpScript.Launcher.HotPatchPushSdk
{
	// Token: 0x020045F9 RID: 17913
	public class HotPatchPushSdk
	{
		// Token: 0x0602EDE2 RID: 191970 RVA: 0x00B19527 File Offset: 0x00B17727
		public static bool IfCanUsePush()
		{
			return false;
		}

		// Token: 0x0602EDE3 RID: 191971 RVA: 0x00B1952C File Offset: 0x00B1772C
		public static void StartPush()
		{
			if (!HotPatchPushSdk.IfCanUsePush())
			{
				Singleton<LauncherLog>.Instance.Info("不可使用push push 初始化失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			string publicValue = Singleton<BaseConfigController>.Instance.GetPublicValue("PushAppId");
			string publicValue2 = Singleton<BaseConfigController>.Instance.GetPublicValue("PushAppKey");
			string publicValue3 = Singleton<BaseConfigController>.Instance.GetPublicValue("PushAppSecret");
			Singleton<LauncherLog>.Instance.Debug("push appId" + publicValue, default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<LauncherLog>.Instance.Debug("push appKey" + publicValue2, default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<LauncherLog>.Instance.Debug("push appSecret" + publicValue3, default(ReadOnlySpan<ValueTuple<string, object>>));
			if (Singleton<LauncherStorageLib>.Instance.GetGlobal<bool>(ELauncherStorageGlobalKey.NotFirstTimeOpenPush, false))
			{
				Singleton<LauncherStorageLib>.Instance.GetGlobal<bool>(ELauncherStorageGlobalKey.CachePushOpenState, false);
				return;
			}
			Singleton<LauncherStorageLib>.Instance.SetGlobal<bool>(ELauncherStorageGlobalKey.NotFirstTimeOpenPush, true);
		}

		// Token: 0x0602EDE4 RID: 191972 RVA: 0x00B1960C File Offset: 0x00B1780C
		[NullableContext(1)]
		public static void SendLocalPush(string title, string desc, string exData)
		{
			if (!HotPatchPushSdk.IfCanUsePush())
			{
				Singleton<LauncherLog>.Instance.Info("SendLocalPush", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0602EDE5 RID: 191973 RVA: 0x00B19638 File Offset: 0x00B17838
		[Conditional("KURO_PUSH_SDK")]
		public static void TurnOnPush()
		{
			if (!HotPatchPushSdk.IfCanUsePush())
			{
				return;
			}
			UKuroPushSdkStaticLibrary.TurnOnPush();
			Singleton<LauncherStorageLib>.Instance.SetGlobal<bool>(ELauncherStorageGlobalKey.CachePushOpenState, true);
		}

		// Token: 0x0602EDE6 RID: 191974 RVA: 0x00B19654 File Offset: 0x00B17854
		[Conditional("KURO_PUSH_SDK")]
		public static void TurnOffPush()
		{
			if (!HotPatchPushSdk.IfCanUsePush())
			{
				return;
			}
			UKuroPushSdkStaticLibrary.TurnOffPush();
			Singleton<LauncherStorageLib>.Instance.SetGlobal<bool>(ELauncherStorageGlobalKey.CachePushOpenState, false);
		}

		// Token: 0x0602EDE7 RID: 191975 RVA: 0x00B19670 File Offset: 0x00B17870
		public static bool GetPushState()
		{
			HotPatchPushSdk.IfCanUsePush();
			return false;
		}
	}
}
