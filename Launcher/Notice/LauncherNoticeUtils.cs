using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.HotPatchKuroSdk;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Platform.PlatformSdk;
using CSharpScript.Launcher.Util;
using UnrealEngine;

namespace CSharpScript.Launcher.Notice
{
	// Token: 0x020045D2 RID: 17874
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LauncherNoticeUtils : Singleton<LauncherNoticeUtils>
	{
		// Token: 0x0602ED46 RID: 191814 RVA: 0x00B16FF8 File Offset: 0x00B151F8
		[NullableContext(2)]
		public void OpenNotice(string logMsg = null)
		{
			if (Singleton<Platform>.Instance.IsCloudGame() && Singleton<CloudGameManagerLauncher>.Instance.IsPreLaunch)
			{
				return;
			}
			if (Singleton<Platform>.Instance.IsXboxPlatform() || Singleton<Platform>.Instance.IsPs5Platform())
			{
				return;
			}
			if (this.HasNoticeAutoOpened)
			{
				return;
			}
			if (logMsg != null)
			{
				Singleton<LauncherLog>.Instance.Info("热更公告日志: " + logMsg, default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.OpenNoticeImp();
			this.HasNoticeAutoOpened = true;
		}

		// Token: 0x0602ED47 RID: 191815 RVA: 0x00B1706E File Offset: 0x00B1526E
		public void CloseNotice(string reason)
		{
			LauncherSdk.Get().CloseWebView(reason);
		}

		// Token: 0x0602ED48 RID: 191816 RVA: 0x00B1707B File Offset: 0x00B1527B
		public void OpenNoticeByUser()
		{
			this.OpenNoticeImp();
		}

		// Token: 0x0602ED49 RID: 191817 RVA: 0x00B17084 File Offset: 0x00B15284
		public bool CheckGrayBoxHit()
		{
			return true;
		}

		// Token: 0x0602ED4A RID: 191818 RVA: 0x00B17094 File Offset: 0x00B15294
		private void OpenNoticeImp()
		{
			if (!this.CheckGrayBoxHit())
			{
				return;
			}
			string noticeUrl = this.GetNoticeUrl();
			if (this.CanUseSdk())
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "热更阶段打开公告 - sdk旧";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Url", noticeUrl);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.SdkOpenNotice(noticeUrl);
				return;
			}
			if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "热更阶段打开公告 - sdk新";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Url", noticeUrl);
				instance2.Info(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().OpenWebView(noticeUrl, null);
				return;
			}
			LauncherLog instance3 = Singleton<LauncherLog>.Instance;
			string message3 = "热更阶段打开公告 - 无sdk";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Url", noticeUrl);
			instance3.Info(message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().OpenExternalUrl(noticeUrl);
		}

		// Token: 0x0602ED4B RID: 191819 RVA: 0x00B17158 File Offset: 0x00B15358
		private void SdkOpenNotice(string url)
		{
			LauncherSdkBase launcherSdkBase = LauncherSdk.Get();
			launcherSdkBase.SetFont();
			launcherSdkBase.OpenUrl("", url, true, true, true, "Default");
		}

		// Token: 0x0602ED4C RID: 191820 RVA: 0x00B17178 File Offset: 0x00B15378
		public string GetNoticeUrl()
		{
			string noticePreUrl = this.GetNoticePreUrl();
			string serverId = this.GetServerId();
			string value = Singleton<LauncherLanguageLib>.Instance.PackageLanguage ?? "";
			string deviceId = this.GetDeviceId();
			string value2 = "1000000000";
			string value3 = this.IsGlobalSdk() ? "global" : "cn";
			string gameId = this.GetGameId();
			string channelId = this.GetChannelId();
			string platformStr = this.GetPlatformStr();
			string value4 = "before_login";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(78, 10);
			defaultInterpolatedStringHandler.AppendFormatted(noticePreUrl);
			defaultInterpolatedStringHandler.AppendLiteral("?server_id=");
			defaultInterpolatedStringHandler.AppendFormatted(serverId);
			defaultInterpolatedStringHandler.AppendLiteral("&role_id=");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			defaultInterpolatedStringHandler.AppendLiteral("&user_id=");
			defaultInterpolatedStringHandler.AppendFormatted(value4);
			defaultInterpolatedStringHandler.AppendLiteral("&game_id=");
			defaultInterpolatedStringHandler.AppendFormatted(gameId);
			defaultInterpolatedStringHandler.AppendLiteral("&svr_area=");
			defaultInterpolatedStringHandler.AppendFormatted(value3);
			defaultInterpolatedStringHandler.AppendLiteral("&did=");
			defaultInterpolatedStringHandler.AppendFormatted(deviceId);
			defaultInterpolatedStringHandler.AppendLiteral("&channel=");
			defaultInterpolatedStringHandler.AppendFormatted(channelId);
			defaultInterpolatedStringHandler.AppendLiteral("&platform=");
			defaultInterpolatedStringHandler.AppendFormatted(platformStr);
			defaultInterpolatedStringHandler.AppendLiteral("&lang=");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602ED4D RID: 191821 RVA: 0x00B172BE File Offset: 0x00B154BE
		private bool CanUseSdk()
		{
			return !Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn && UKuroStaticLibrary.IsModuleLoaded("KuroSDK") && Singleton<BaseConfigController>.Instance.GetPublicValue("UseSDK") == "1";
		}

		// Token: 0x0602ED4E RID: 191822 RVA: 0x00B172F3 File Offset: 0x00B154F3
		private bool IsGlobalSdk()
		{
			return Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") != "CN";
		}

		// Token: 0x0602ED4F RID: 191823 RVA: 0x00B1730E File Offset: 0x00B1550E
		private string GetDefaultServerId()
		{
			if (!this.IsGlobalSdk())
			{
				return "76402e5b20be2c39f095a152090afddc";
			}
			return "86d52186155b148b5c138ceb41be9650";
		}

		// Token: 0x0602ED50 RID: 191824 RVA: 0x00B17324 File Offset: 0x00B15524
		private string GetServerId()
		{
			EntryJson cdnReturnConfigInfo = Singleton<BaseConfigController>.Instance.GetCdnReturnConfigInfo();
			List<ILoginServersData> list = (cdnReturnConfigInfo != null) ? cdnReturnConfigInfo.LoginServers : null;
			if (list == null || list.Count == 0)
			{
				return this.GetDefaultServerId();
			}
			return list[0].id ?? this.GetDefaultServerId();
		}

		// Token: 0x0602ED51 RID: 191825 RVA: 0x00B17370 File Offset: 0x00B15570
		private string GetGameId()
		{
			if (!this.IsGlobalSdk())
			{
				return "G152";
			}
			return "G153";
		}

		// Token: 0x0602ED52 RID: 191826 RVA: 0x00B17385 File Offset: 0x00B15585
		private string GetNoticePreUrl()
		{
			if (!this.IsGlobalSdk())
			{
				return "https://aki-gm-resources.aki-game.com/aki/announcement/index.html";
			}
			return "https://aki-gm-resources-oversea.aki-game.net/aki/announcement/index.html";
		}

		// Token: 0x0602ED53 RID: 191827 RVA: 0x00B1739A File Offset: 0x00B1559A
		private string GetDeviceId()
		{
			if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
			{
				return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetDeviceId();
			}
			if (this.CanUseSdk())
			{
				return UKuroSDKManager.GetBasicInfo().DeviceId ?? "";
			}
			return "";
		}

		// Token: 0x0602ED54 RID: 191828 RVA: 0x00B173D9 File Offset: 0x00B155D9
		private string GetChannelId()
		{
			if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
			{
				return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetChannelId();
			}
			if (this.CanUseSdk())
			{
				return LauncherSdk.Get().GetChannelId();
			}
			return "";
		}

		// Token: 0x0602ED55 RID: 191829 RVA: 0x00B17410 File Offset: 0x00B15610
		private string GetPlatformStr()
		{
			if (Singleton<Platform>.Instance.IsAndroidPlatform())
			{
				return "Android";
			}
			if (Singleton<Platform>.Instance.IsIOSPlatform())
			{
				return "iOS";
			}
			if (Singleton<Platform>.Instance.IsMacPlatform())
			{
				return "Mac";
			}
			if (Singleton<Platform>.Instance.IsPs5Platform())
			{
				return "PS5";
			}
			if (Singleton<Platform>.Instance.IsXSXPlatform())
			{
				return "XSX";
			}
			if (Singleton<Platform>.Instance.IsWinGDKPlatform())
			{
				return "WinGDK";
			}
			if (Singleton<Platform>.Instance.IsOpenHarmonyPlatform())
			{
				return "OpenHarmony";
			}
			return "PC";
		}

		// Token: 0x0401AA3D RID: 109117
		public bool HasNoticeAutoOpened;

		// Token: 0x0401AA3E RID: 109118
		public int NoticeOpenDownloadSizeThreshold = 500;
	}
}
