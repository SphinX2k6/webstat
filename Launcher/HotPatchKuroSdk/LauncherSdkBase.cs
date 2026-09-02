using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Platform.PlatformSdk;
using CSharpScript.Launcher.Util;
using CSharpScript.Typing;
using UnrealEngine;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004605 RID: 17925
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherSdkBase
	{
		// Token: 0x0602EE28 RID: 192040 RVA: 0x00B1A93C File Offset: 0x00B18B3C
		public void Init()
		{
			Singleton<LauncherLog>.Instance.Info("LauncherSdkBase Init", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (LauncherSdk.canUseSdk())
			{
				this.BindSdkLoginCallback();
				this.BindSdkFocusCallback();
				this.BindSdkExitCallback();
				this.BindSdkLogoutCallback();
				this.BindSdkKickCallback();
			}
			this.ifGlobalSdk = LauncherSdk.IsGlobalSdk();
		}

		// Token: 0x0602EE29 RID: 192041 RVA: 0x00B1A994 File Offset: 0x00B18B94
		private void RefreshCursor()
		{
			string str = "Aki/Cursor";
			string cursor = UBlueprintPathsLibrary.ProjectContentDir() + "/" + str + "/CursorNor.png";
			this.SetCursor(cursor);
		}

		// Token: 0x0602EE2A RID: 192042 RVA: 0x00B1A9C4 File Offset: 0x00B18BC4
		public bool GetSdkFocusState()
		{
			return this.SdkFocusState;
		}

		// Token: 0x0602EE2B RID: 192043 RVA: 0x00B1A9CC File Offset: 0x00B18BCC
		private void BindSdkFocusCallback()
		{
			UKuroSDKManager.Get().GameStateChangeCallBack.Clear();
			UKuroSDKManager.Get().GameStateChangeCallBack.Add(delegate(string result)
			{
				string a = this.ParseGameWindowStateStatus(result);
				bool flag = false;
				if (a == "0")
				{
					flag = true;
				}
				this.SdkFocusState = flag;
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "LauncherSdkBase BindSdkFocusCallback";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sdkGetFocus", flag);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			});
		}

		// Token: 0x0602EE2C RID: 192044 RVA: 0x00B1A9F8 File Offset: 0x00B18BF8
		[return: Nullable(2)]
		private string ParseGameWindowStateStatus(string result)
		{
			if (string.IsNullOrEmpty(result))
			{
				return null;
			}
			if (result.StartsWith('{') || result.StartsWith('['))
			{
				try
				{
					GameWindowStateData gameWindowStateData = JsonSerializer.Deserialize<GameWindowStateData>(result, null);
					return (gameWindowStateData != null) ? gameWindowStateData.status : null;
				}
				catch
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "GameWindowState JSON解析失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", result);
					instance.Warn(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return null;
				}
			}
			string[] array = result.Split(',', StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split('=', StringSplitOptions.None);
				if (array2.Length == 2 && array2[0] == "status")
				{
					return array2[1];
				}
			}
			return null;
		}

		// Token: 0x0602EE2D RID: 192045 RVA: 0x00B1AAB8 File Offset: 0x00B18CB8
		private void BindSdkExitCallback()
		{
			UKuroSDKManager.Get().ExitDelegate.Clear();
			UKuroSDKManager.Get().ExitDelegate.Add(delegate()
			{
				Singleton<LauncherLog>.Instance.Info("LauncherSdkBase BindSdkExitCallback", default(ReadOnlySpan<ValueTuple<string, object>>));
				KuroApplication.ExitWithReason(false, "SDK");
			});
		}

		// Token: 0x0602EE2E RID: 192046 RVA: 0x00B1AAF7 File Offset: 0x00B18CF7
		private void BindSdkKickCallback()
		{
			UKuroSDKManager.Get().KickDelegate.Clear();
			UKuroSDKManager.Get().KickDelegate.Add(delegate()
			{
				Singleton<LauncherLog>.Instance.Info("LauncherSdkBase BindSdkKickCallback", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ClearCacheLoginData();
			});
		}

		// Token: 0x0602EE2F RID: 192047 RVA: 0x00B1AB23 File Offset: 0x00B18D23
		private void BindSdkLogoutCallback()
		{
			UKuroSDKManager.Get().LogoutDelegate.Clear();
			UKuroSDKManager.Get().LogoutDelegate.Add(delegate()
			{
				Singleton<LauncherLog>.Instance.Info("LauncherSdkBase BindSdkLogoutCallback", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ClearCacheLoginData();
			});
		}

		// Token: 0x0602EE30 RID: 192048 RVA: 0x00B1AB4F File Offset: 0x00B18D4F
		private unsafe void BindSdkLoginCallback()
		{
			UKuroSDKManager.Get().LoginDelegate.Clear();
			UKuroSDKManager.Get().LoginDelegate.Add(delegate(FLoginStruct loginInfo)
			{
				if (loginInfo != null)
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "收到登录回调";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("state", loginInfo.LoginCode);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("name", loginInfo.UserName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("uid", loginInfo.Uid);
					instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					this.CacheLoginData = loginInfo;
					Action<FLoginStruct> loginCallback = this.LoginCallback;
					if (loginCallback == null)
					{
						return;
					}
					loginCallback(loginInfo);
				}
			});
		}

		// Token: 0x0602EE31 RID: 192049 RVA: 0x00B1AB7C File Offset: 0x00B18D7C
		public void Login(Action<FLoginStruct> callback)
		{
			this.RefreshCursor();
			this.LauncherTraceId = UKismetGuidLibrary.NewGuid().ToString();
			this.LoginCallback = callback;
			if (LauncherSdk.canUseSdk())
			{
				this.SetFont();
				UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKLogin;
				UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
			}
		}

		// Token: 0x0602EE32 RID: 192050 RVA: 0x00B1ABCA File Offset: 0x00B18DCA
		public void SetCursor(string path)
		{
			UKuroSDKManager.SetCursor(path);
		}

		// Token: 0x0602EE33 RID: 192051 RVA: 0x00B1ABD4 File Offset: 0x00B18DD4
		public void Logout()
		{
			if (LauncherSdk.canUseSdk())
			{
				Singleton<LauncherLog>.Instance.Info("HotFixView SDKLogOut", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ClearCacheLoginData();
				UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKLogout;
				UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
			}
		}

		// Token: 0x0602EE34 RID: 192052 RVA: 0x00B1AC14 File Offset: 0x00B18E14
		public void ClearCacheLoginData()
		{
			Singleton<LauncherLog>.Instance.Info("LauncherSdkBase ClearCacheLoginData", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CacheLoginData = null;
		}

		// Token: 0x0602EE35 RID: 192053 RVA: 0x00B1AC40 File Offset: 0x00B18E40
		public virtual string GetChannelId()
		{
			return "";
		}

		// Token: 0x0602EE36 RID: 192054 RVA: 0x00B1AC48 File Offset: 0x00B18E48
		public virtual void OpenUrl(string title, string url, bool isLandscape, bool transparent, bool webAccelerated, string identifier = "Default")
		{
			if (LauncherSdk.canUseSdk())
			{
				string sdkOpenUrlWndInfo = this.GetSdkOpenUrlWndInfo(title, url);
				UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroOpenSdkUrlWnd;
				UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, sdkOpenUrlWndInfo ?? "");
			}
		}

		// Token: 0x0602EE37 RID: 192055 RVA: 0x00B1AC79 File Offset: 0x00B18E79
		protected virtual string GetPlatformFontStr()
		{
			return "";
		}

		// Token: 0x0602EE38 RID: 192056 RVA: 0x00B1AC80 File Offset: 0x00B18E80
		public void SetFont()
		{
			if (!LauncherSdk.canUseSdk())
			{
				return;
			}
			string platformFontStr = this.GetPlatformFontStr();
			if (platformFontStr != "")
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "LauncherSdkBase SetFont";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("fontStr", platformFontStr);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				UKuroSDKManager.SetFont(platformFontStr);
			}
		}

		// Token: 0x0602EE39 RID: 192057 RVA: 0x00B1ACD4 File Offset: 0x00B18ED4
		private string GetFontAsset()
		{
			string text = Singleton<LauncherLanguageLib>.Instance.GetPackageLanguage() ?? "";
			if (text != null)
			{
				int length = text.Length;
				if (length == 2)
				{
					switch (text[1])
					{
					case 'a':
						if (text == "ja")
						{
							return "MotoyaAporoStdW5.otf";
						}
						break;
					case 'd':
						if (text == "id")
						{
							return "LaguSansBold.otf";
						}
						break;
					case 'e':
						if (text == "de")
						{
							return "LaguSansBold.otf";
						}
						break;
					case 'h':
						if (text == "th")
						{
							return "Kanit-Medium.ttf";
						}
						break;
					case 'i':
						if (text == "vi")
						{
							return "LaguSansBold.otf";
						}
						break;
					case 'n':
						if (text == "en")
						{
							return "LaguSansBold.otf";
						}
						break;
					case 'o':
						if (text == "ko")
						{
							return "SUITE-Bold.otf";
						}
						break;
					case 'r':
						if (text == "fr")
						{
							return "LaguSansBold.otf";
						}
						break;
					case 's':
						if (text == "es")
						{
							return "LaguSansBold.otf";
						}
						break;
					case 't':
						if (text == "pt")
						{
							return "LaguSansBold.otf";
						}
						break;
					case 'u':
						if (text == "ru")
						{
							return "LaguSansBold.otf";
						}
						break;
					}
				}
			}
			return "H7GBKHeavy.TTF";
		}

		// Token: 0x0602EE3A RID: 192058 RVA: 0x00B1AE80 File Offset: 0x00B19080
		public string GetCurrentFontName()
		{
			string fontAsset = this.GetFontAsset();
			if (fontAsset == "LaguSansBold.otf")
			{
				return "Lagu Sans";
			}
			if (fontAsset == "H7GBKHeavy.TTF")
			{
				return "文鼎方新书H7GBK_H";
			}
			if (fontAsset == "MotoyaAporoStdW5.otf")
			{
				return "Motoya Aporo Std W5";
			}
			if (fontAsset == "SUITE-Bold.otf")
			{
				return "SUITE";
			}
			if (!(fontAsset == "Kanit-Medium.ttf"))
			{
				return "文鼎方新书H7GBK_H";
			}
			return "Kanit Medium";
		}

		// Token: 0x0602EE3B RID: 192059 RVA: 0x00B1AEFC File Offset: 0x00B190FC
		public string GetDeviceFontAsset()
		{
			string fontAsset = this.GetFontAsset();
			return this.GetFontPlatformName(fontAsset);
		}

		// Token: 0x0602EE3C RID: 192060 RVA: 0x00B1AF18 File Offset: 0x00B19118
		private string GetFontPlatformName(string source)
		{
			if (!Singleton<Platform>.Instance.IsIOSPlatform() && !Singleton<Platform>.Instance.IsMacPlatform())
			{
				return source;
			}
			if (source == "LaguSansBold.otf")
			{
				return "LaguSans-Bold.otf";
			}
			if (source == "H7GBKHeavy.TTF")
			{
				return "ARFangXinShuH7GBK-Heavy.TTF";
			}
			if (source == "MotoyaAporoStdW5.otf")
			{
				return "MotoyaAporoStd-W5.otf";
			}
			if (source == "SUITE-Bold.otf")
			{
				return "SUITE-Bold.otf";
			}
			if (source == "Kanit-Medium.ttf")
			{
				return "Kanit-Medium.ttf";
			}
			return source;
		}

		// Token: 0x0602EE3D RID: 192061 RVA: 0x00B1AFA0 File Offset: 0x00B191A0
		public void CloseWebView(string reason)
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "LauncherSdkBase CloseWebView";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
			{
				Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().CloseWebView();
				return;
			}
			if (LauncherSdk.canUseSdk())
			{
				UKuroSDKManager.CloseWebView("Default");
			}
		}

		// Token: 0x0602EE3E RID: 192062 RVA: 0x00B1AFFD File Offset: 0x00B191FD
		[return: Nullable(2)]
		protected string GetSdkOpenUrlWndInfo(string title, string url)
		{
			return JsonSerializer.Serialize<Dictionary<string, string>>(new Dictionary<string, string>
			{
				{
					"title",
					title
				},
				{
					"url",
					url
				}
			}, null);
		}

		// Token: 0x0602EE3F RID: 192063 RVA: 0x00B1B024 File Offset: 0x00B19224
		protected bool IsValidJsonStr(string jsonStr)
		{
			bool result;
			try
			{
				JsonDocument.Parse(jsonStr, default(JsonDocumentOptions));
				result = true;
			}
			catch
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "待解析的字符串不合法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("", jsonStr);
				instance.Warn(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				result = false;
			}
			return result;
		}

		// Token: 0x0602EE40 RID: 192064 RVA: 0x00B1B080 File Offset: 0x00B19280
		public void ReportChannelEvent(HotPatchLog eventData)
		{
			if (LauncherSdk.canUseSdk())
			{
				UKuroSDKManager.UpdateChannelEvent(JsonSerializer.Serialize<HotPatchLog>(eventData, null));
			}
		}

		// Token: 0x0602EE41 RID: 192065 RVA: 0x00B1B095 File Offset: 0x00B19295
		public void ReportMarketingEvent(SdkReportData eventData)
		{
			if (LauncherSdk.canUseSdk())
			{
				UKuroSDKManager.LogMarketingEvent(eventData.GetReportString());
			}
		}

		// Token: 0x0602EE42 RID: 192066 RVA: 0x00B1B0A9 File Offset: 0x00B192A9
		public void AdditionReportForSdk(HotPatchLog hotPatchLog, SdkReportData sdkReportData)
		{
			if (Singleton<Platform>.Instance.IsMacPlatform())
			{
				return;
			}
			this.ReportChannelEvent(hotPatchLog);
			if (this.ifGlobalSdk)
			{
				this.ReportMarketingEvent(sdkReportData);
			}
		}

		// Token: 0x0401AAD1 RID: 109265
		private bool SdkFocusState;

		// Token: 0x0401AAD2 RID: 109266
		[Nullable(2)]
		public FLoginStruct CacheLoginData;

		// Token: 0x0401AAD3 RID: 109267
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<FLoginStruct> LoginCallback;

		// Token: 0x0401AAD4 RID: 109268
		public string LauncherTraceId = "";

		// Token: 0x0401AAD5 RID: 109269
		private bool ifGlobalSdk;

		// Token: 0x0401AAD6 RID: 109270
		private const string LAGUSANSBOLD = "LaguSansBold.otf";

		// Token: 0x0401AAD7 RID: 109271
		private const string MOTOYTA = "MotoyaAporoStdW5.otf";

		// Token: 0x0401AAD8 RID: 109272
		private const string SUITEBOLD = "SUITE-Bold.otf";

		// Token: 0x0401AAD9 RID: 109273
		private const string H7GBKHEAVY = "H7GBKHeavy.TTF";

		// Token: 0x0401AADA RID: 109274
		private const string KANIT = "Kanit-Medium.ttf";
	}
}
