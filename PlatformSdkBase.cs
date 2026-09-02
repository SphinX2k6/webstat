using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.HotPatchKuroSdk;
using CSharpScript.Launcher.Platform;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000F0A RID: 3850
[NullableContext(1)]
[Nullable(0)]
public class PlatformSdkBase
{
	// Token: 0x06005F34 RID: 24372 RVA: 0x0017D188 File Offset: 0x0017B388
	public virtual void Init()
	{
		this.KuroOnLogBindFunction();
		this.BindProtocolListener();
		this.BindShareResultListener();
		this.KuroSdkExitBindFunction();
		this.KuroSdkBindRedPointFunction(new Action<int>(this.RedPointCallBack));
		this.KuroSdkQueryProductBindFunction();
		this.KuroDeepLinkBindFunction();
		this.KuroGameWinStateBindFunction();
		this.BindSpecialEvent();
		this.BindExternalEvent();
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			this.StartInitProgress();
		}
		this.SetGamePadMode(Singleton<Info>.Instance.IsInGamepad());
		this.CurrentDid = UKuroSDKManager.GetBasicInfo().DeviceId;
	}

	// Token: 0x06005F35 RID: 24373 RVA: 0x0017D210 File Offset: 0x0017B410
	private void StartInitProgress()
	{
		if (!UKuroLauncherLibrary.IsFirstIntoLauncher())
		{
			UKuroSDKManager.Get().LogoutDelegate.Clear();
			if (LauncherSdk.Get().CacheLoginData == null && !ModelBase<LoginModel>.Instance.HasBackToGameData())
			{
				this.SdkLogout();
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.SdkInitDone);
			return;
		}
		UKuroSDKManager.SetIfGlobalSdk(ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk());
		this.SetFont();
		this.CheckIfHasInitTimer = TimerSystem.Instance.Forever(delegate(float _)
		{
			this.CheckIfInitSuccess();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x06005F36 RID: 24374 RVA: 0x0017D2A3 File Offset: 0x0017B4A3
	public virtual void OpenWebView(string title, string url, bool isLandscape, bool transparent, bool webAccelerated)
	{
	}

	// Token: 0x06005F37 RID: 24375 RVA: 0x0017D2A8 File Offset: 0x0017B4A8
	private void CheckIfInitSuccess()
	{
		if (UKuroSDKManager.GetSdkInitState())
		{
			UKuroSDKManager.SetWindowsMode(false);
			this.SdkSplashScreenEndSuccess();
			ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KuroNotiLanguage);
			ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KUROINITIALIZEPOSTWEBVIEW);
			if (Singleton<Platform>.Instance.IsWindowsOnlyPlatform() && ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
			{
				this.CheckPostWebViewInitTimer = TimerSystem.Instance.Forever(delegate(float _)
				{
					this.CheckIfInitPostWebView();
				}, 1000f, 1f, null, null, true);
			}
			if (this.CheckIfHasInitTimer != null)
			{
				TimerSystem.Instance.Remove(this.CheckIfHasInitTimer);
				this.CheckIfHasInitTimer = null;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.SdkInitDone);
		}
	}

	// Token: 0x06005F38 RID: 24376 RVA: 0x0017D351 File Offset: 0x0017B551
	protected virtual void OnInit()
	{
	}

	// Token: 0x06005F39 RID: 24377 RVA: 0x0017D354 File Offset: 0x0017B554
	public virtual void ShowExternalLogin()
	{
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk() && Singleton<Platform>.Instance.IsIOSPlatform())
		{
			Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "ShowExternalLoginUI", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKuroSDKManager.ShowExternalLogin();
		}
	}

	// Token: 0x06005F3A RID: 24378 RVA: 0x0017D39A File Offset: 0x0017B59A
	private void SdkSplashScreenEndSuccess()
	{
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			UKuroSDKManager.PostSplashScreenEndSuccess();
		}
	}

	// Token: 0x06005F3B RID: 24379 RVA: 0x0017D3B0 File Offset: 0x0017B5B0
	protected void SdkDoInit()
	{
		UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroDoInit;
		UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
	}

	// Token: 0x06005F3C RID: 24380 RVA: 0x0017D3CC File Offset: 0x0017B5CC
	private void CheckIfInitPostWebView()
	{
		if (UKuroSDKManager.GetPostWebViewInitState())
		{
			if (this.CheckPostWebViewInitTimer != null)
			{
				TimerSystem.Instance.Remove(this.CheckPostWebViewInitTimer);
				this.CheckPostWebViewInitTimer = null;
				return;
			}
		}
		else
		{
			ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KUROINITIALIZEPOSTWEBVIEW);
		}
	}

	// Token: 0x06005F3D RID: 24381 RVA: 0x0017D404 File Offset: 0x0017B604
	public virtual void SdkLogout()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "游戏注销", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKLogout;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
		}
	}

	// Token: 0x06005F3E RID: 24382 RVA: 0x0017D448 File Offset: 0x0017B648
	private void RedPointCallBack(int result)
	{
		bool postWebViewRedPointState = result == 1;
		ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(postWebViewRedPointState);
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
	}

	// Token: 0x06005F3F RID: 24383 RVA: 0x0017D478 File Offset: 0x0017B678
	public virtual void SdkLogin()
	{
		if (!this.GetProtocolState())
		{
			return;
		}
		if (!UKuroSDKManager.GetSdkInitState())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "开始进行Sdk登录!!!", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			if (Singleton<Platform>.Instance.IsWindowsOnlyPlatform())
			{
				UKuroSDKEventType ukuroSDKEventType;
				if (UKuroLauncherLibrary.IsFirstIntoLauncher())
				{
					ukuroSDKEventType = UKuroSDKEventType.KuroSDKLogin;
					UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
					return;
				}
				ukuroSDKEventType = UKuroSDKEventType.KuroSDKOpenLoginWnd;
				UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
				return;
			}
			else
			{
				UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKLogin;
				UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
			}
		}
	}

	// Token: 0x06005F40 RID: 24384 RVA: 0x0017D500 File Offset: 0x0017B700
	public virtual void SdkKick()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "响应Sdk踢人完成!!!，返回sdk", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKKick;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
			ControllerBase<KuroSdkController>.Instance.IsKick = true;
			Singleton<EventSystem>.Instance.Emit(EEventName.SdkKick);
		}
	}

	// Token: 0x06005F41 RID: 24385 RVA: 0x0017D560 File Offset: 0x0017B760
	public virtual void SdkSelectRole()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "上报选择角色", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			string roleInfo = KuroSdkControllerTool.GetRoleInfo();
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKSelectedRole;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, roleInfo);
		}
	}

	// Token: 0x06005F42 RID: 24386 RVA: 0x0017D5A8 File Offset: 0x0017B7A8
	public virtual void SdkCreateRole()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "上报创建新角色", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			string createRoleInfo = KuroSdkControllerTool.GetCreateRoleInfo();
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKCreateRole;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, createRoleInfo);
		}
	}

	// Token: 0x06005F43 RID: 24387 RVA: 0x0017D5F0 File Offset: 0x0017B7F0
	public virtual void SdkLevelUpRole()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "上报角色升级", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			string roleInfo = KuroSdkControllerTool.GetRoleInfo();
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKUpgradeRole;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, roleInfo);
		}
	}

	// Token: 0x06005F44 RID: 24388 RVA: 0x0017D638 File Offset: 0x0017B838
	public virtual void SdkExit()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "游戏退出", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (GlobalData.IsPlayInEditor)
		{
			UKismetSystemLibrary.QuitGame(GlobalData.World, null, EQuitPreference.Quit, false);
			return;
		}
		if (!ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			KuroApplication.ExitWithReason(false, "SDK");
			return;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.ExitGamePush);
		if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			KuroApplication.ExitWithReason(false, "SDK");
			return;
		}
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS || (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android && ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk()))
		{
			Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "直接退出", default(ReadOnlySpan<ValueTuple<string, object>>));
			KuroApplication.ExitWithReason(false, "SDK");
			return;
		}
		UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKExit;
		UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
	}

	// Token: 0x06005F45 RID: 24389 RVA: 0x0017D714 File Offset: 0x0017B914
	public virtual void SdkOpenLoginWnd()
	{
		if (!this.GetProtocolState())
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "主动打开sdk登录界面", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			UKuroSDKEventType ukuroSDKEventType;
			if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS && ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
			{
				ukuroSDKEventType = UKuroSDKEventType.KuroSDKLogin;
				UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
				return;
			}
			ukuroSDKEventType = UKuroSDKEventType.KuroSDKOpenLoginWnd;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
		}
	}

	// Token: 0x06005F46 RID: 24390 RVA: 0x0017D788 File Offset: 0x0017B988
	public virtual SdkAgreementLinkData[] GetAgreement()
	{
		List<SdkAgreementLinkData> list = new List<SdkAgreementLinkData>();
		string agreementUrl = UKuroSDKManager.GetAgreementUrl();
		if (!ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
		{
			if (Singleton<Platform>.Instance.IsAndroidPlatform())
			{
				AndroidSdkAgreementData androidSdkAgreementData = Json.Decode<AndroidSdkAgreementData>(agreementUrl, null);
				if (((androidSdkAgreementData != null) ? androidSdkAgreementData.gameInit : null) != null)
				{
					foreach (SdkAgreementLinkData item in androidSdkAgreementData.gameInit)
					{
						list.Add(item);
					}
				}
			}
			else if (Singleton<Platform>.Instance.IsWindowsOnlyPlatform())
			{
				SdkAgreementLinkData[] array = Json.Decode<SdkAgreementLinkData[]>(agreementUrl, null);
				if (array != null)
				{
					list.AddRange(array);
				}
			}
			else if (Singleton<Platform>.Instance.IsIOSPlatform() || Singleton<Platform>.Instance.IsMacPlatform())
			{
				string[] array2 = agreementUrl.Split(',', StringSplitOptions.None);
				for (int i = 0; i < array2.Length; i++)
				{
					string[] array3 = array2[i].Replace("{", "").Replace("}", "").Split(';', StringSplitOptions.None);
					if (array3.Length >= 2)
					{
						string[] array4 = array3[0].Split('=', StringSplitOptions.None);
						SdkAgreementLinkData sdkAgreementLinkData = new SdkAgreementLinkData();
						sdkAgreementLinkData.link = array4[1];
						sdkAgreementLinkData.link = sdkAgreementLinkData.link.Trim();
						sdkAgreementLinkData.link = sdkAgreementLinkData.link.Replace("\"", "");
						string[] array5 = array3[1].Split('=', StringSplitOptions.None);
						sdkAgreementLinkData.title = array5[1];
						sdkAgreementLinkData.title = sdkAgreementLinkData.title.Trim();
						sdkAgreementLinkData.title = sdkAgreementLinkData.title.Replace("\"", "");
						sdkAgreementLinkData.title = sdkAgreementLinkData.title.ToLower();
						sdkAgreementLinkData.title = Uri.UnescapeDataString(sdkAgreementLinkData.title);
						list.Add(sdkAgreementLinkData);
					}
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06005F47 RID: 24391 RVA: 0x0017D96D File Offset: 0x0017BB6D
	public virtual void QueryProduct(string[] productList, string channelId)
	{
		CustomPromise<bool> queryPromise = ModelBase<KuroSdkModel>.Instance.QueryPromise;
		if (queryPromise == null)
		{
			return;
		}
		queryPromise.SetResult(true);
	}

	// Token: 0x06005F48 RID: 24392 RVA: 0x0017D984 File Offset: 0x0017BB84
	public virtual void ShareByteData(ShareData shareData, TArray<byte> data)
	{
		string sKuroSDKEventParameter = JsonSerializer.Serialize<ShareData>(shareData, null);
		UKuroSDKManager.Share(data, sKuroSDKEventParameter);
	}

	// Token: 0x06005F49 RID: 24393 RVA: 0x0017D9A1 File Offset: 0x0017BBA1
	public virtual void Share(ShareData shareData, string imagePath)
	{
	}

	// Token: 0x06005F4A RID: 24394 RVA: 0x0017D9A3 File Offset: 0x0017BBA3
	public virtual void ShareTexture(ShareData shareData, string texturePath)
	{
	}

	// Token: 0x06005F4B RID: 24395 RVA: 0x0017D9A8 File Offset: 0x0017BBA8
	public virtual void SdkPay(ISDKPayment paymentInfo)
	{
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			ISDKPayRole sdkPayRoleInfo = KuroSdkControllerTool.GetSdkPayRoleInfo();
			string paymentInfo2 = KuroSdkControllerTool.GetPaymentInfo(paymentInfo, sdkPayRoleInfo);
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroPay;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, paymentInfo2);
		}
	}

	// Token: 0x06005F4C RID: 24396 RVA: 0x0017D9DC File Offset: 0x0017BBDC
	public virtual string GetCurrentSelectServerId()
	{
		if (ModelBase<LoginServerModel>.Instance.GetLoginServersByClientRegion() == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "没有登录服务器信息", default(ReadOnlySpan<ValueTuple<string, object>>));
			return "0";
		}
		string currentLoginServerId = ModelBase<LoginServerModel>.Instance.GetCurrentLoginServerId();
		if (currentLoginServerId == "0")
		{
			Singleton<Log>.Instance.Warn(ELogModule.KuroSdk, ELogAuthor.YZY, "海外选服没有服务器", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "当前服务器Id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("serverId", currentLoginServerId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return currentLoginServerId;
	}

	// Token: 0x06005F4D RID: 24397 RVA: 0x0017DA74 File Offset: 0x0017BC74
	public virtual void InitializePostWebView()
	{
		string currentSelectServerId = this.GetCurrentSelectServerId();
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "serverId", default(ReadOnlySpan<ValueTuple<string, object>>));
		InitializePostWebViewParam initializePostWebViewParam = new InitializePostWebViewParam();
		initializePostWebViewParam.language = Singleton<LanguageSystem>.Instance.PackageLanguage;
		initializePostWebViewParam.serverId = currentSelectServerId;
		if (Singleton<Platform>.Instance.IsWindowsOnlyPlatform() || Singleton<Platform>.Instance.IsAndroidPlatform())
		{
			initializePostWebViewParam.cdn = new string[]
			{
				Singleton<PublicUtil>.Instance.GetNoticeBaseUrl() + "/gamenotice/" + Singleton<PublicUtil>.Instance.GetGameId()
			};
		}
		else
		{
			initializePostWebViewParam.cdn = new string[]
			{
				Singleton<PublicUtil>.Instance.GetNoticeBaseUrl() + "/gamenotice/" + Singleton<PublicUtil>.Instance.GetGameId() + "/"
			};
		}
		string text = JsonSerializer.Serialize<InitializePostWebViewParam>(initializePostWebViewParam, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "初始化公告";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("json", text);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroInitializePostWebView;
		UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, text);
	}

	// Token: 0x06005F4E RID: 24398 RVA: 0x0017DB78 File Offset: 0x0017BD78
	[return: Nullable(2)]
	public virtual string GetSdkOpenUrlWndInfo(string title, string url)
	{
		string text = JsonSerializer.Serialize<OpenSdkUrlWndParam>(new OpenSdkUrlWndParam
		{
			title = title,
			wndUrl = url
		}, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "SdkJson";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sdkJson", text ?? "");
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return text;
	}

	// Token: 0x06005F4F RID: 24399 RVA: 0x0017DBD0 File Offset: 0x0017BDD0
	public virtual void OpenUserCenter()
	{
		UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroOpenUserCenter;
		UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
	}

	// Token: 0x06005F50 RID: 24400 RVA: 0x0017DBEC File Offset: 0x0017BDEC
	public virtual void ShowAgreement()
	{
		UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroShowAgreement;
		UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
		Singleton<KuroSdkReport>.Instance.Report(new SdkReportOpenPrivacy(null));
	}

	// Token: 0x06005F51 RID: 24401 RVA: 0x0017DC18 File Offset: 0x0017BE18
	public virtual void KuroOpenPrivacyClauseWnd()
	{
		UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroOpenPrivacyClauseWnd;
		UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
		Singleton<KuroSdkReport>.Instance.Report(new SdkReportOpenPrivacy(null));
	}

	// Token: 0x06005F52 RID: 24402 RVA: 0x0017DC44 File Offset: 0x0017BE44
	public virtual void ReadProductInfo()
	{
		UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroReadProductInfo;
		UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, "");
	}

	// Token: 0x06005F53 RID: 24403 RVA: 0x0017DC60 File Offset: 0x0017BE60
	public virtual void NotifyLanguage()
	{
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroNotiLanguage;
		UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, packageLanguage);
		this.SetFont();
	}

	// Token: 0x06005F54 RID: 24404 RVA: 0x0017DC8C File Offset: 0x0017BE8C
	public virtual void OpenPostWebView()
	{
		if (this.LastOpenPostViewTime != 0.0 && Singleton<Time>.Instance.Now - this.LastOpenPostViewTime <= 5000.0)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InDisplayCd", Array.Empty<object>());
			return;
		}
		this.LastOpenPostViewTime = Singleton<Time>.Instance.Now;
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "打开公告", default(ReadOnlySpan<ValueTuple<string, object>>));
		FunctionModel instance = ModelBase<FunctionModel>.Instance;
		PlayerInfoModel instance2 = ModelBase<PlayerInfoModel>.Instance;
		string type = ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk() ? "global" : "cn";
		OpenPostWebViewParam openPostWebViewParam = new OpenPostWebViewParam();
		openPostWebViewParam.playerId = ((instance2.GetId() == null) ? "0" : instance2.GetId().ToString());
		int? playerLevel = instance.GetPlayerLevel();
		openPostWebViewParam.playerLevel = ((playerLevel != null && playerLevel.Value != 0) ? playerLevel.Value.ToString() : "1");
		openPostWebViewParam.language = Singleton<LanguageSystem>.Instance.PackageLanguage;
		openPostWebViewParam.extend = "extend";
		openPostWebViewParam.gameOrientation = "2";
		openPostWebViewParam.type = type;
		string sKuroSDKEventParameter = JsonSerializer.Serialize<OpenPostWebViewParam>(openPostWebViewParam, null);
		UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroOpenPostWebView;
		UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, sKuroSDKEventParameter);
	}

	// Token: 0x06005F55 RID: 24405 RVA: 0x0017DDDD File Offset: 0x0017BFDD
	public virtual string GetChannelId()
	{
		return "";
	}

	// Token: 0x06005F56 RID: 24406 RVA: 0x0017DDE4 File Offset: 0x0017BFE4
	public virtual string GetGameId()
	{
		return "";
	}

	// Token: 0x06005F57 RID: 24407 RVA: 0x0017DDEB File Offset: 0x0017BFEB
	public virtual string GetChannelName()
	{
		return "";
	}

	// Token: 0x06005F58 RID: 24408 RVA: 0x0017DDF2 File Offset: 0x0017BFF2
	public virtual string GetAppChannelId()
	{
		return "";
	}

	// Token: 0x06005F59 RID: 24409 RVA: 0x0017DDF9 File Offset: 0x0017BFF9
	public virtual string GetDid()
	{
		return "";
	}

	// Token: 0x06005F5A RID: 24410 RVA: 0x0017DE00 File Offset: 0x0017C000
	public virtual string GetOaid()
	{
		return "";
	}

	// Token: 0x06005F5B RID: 24411 RVA: 0x0017DE07 File Offset: 0x0017C007
	public virtual string GetJyDid()
	{
		return "";
	}

	// Token: 0x06005F5C RID: 24412 RVA: 0x0017DE0E File Offset: 0x0017C00E
	public virtual string GetAccessToken()
	{
		return "";
	}

	// Token: 0x06005F5D RID: 24413 RVA: 0x0017DE15 File Offset: 0x0017C015
	public virtual string GetPackageId()
	{
		return UKuroSDKManager.GetPackageId();
	}

	// Token: 0x06005F5E RID: 24414 RVA: 0x0017DE1C File Offset: 0x0017C01C
	public virtual bool GetIsQRCodeLogin()
	{
		return UKuroSDKManager.GetSdkIsQRScan();
	}

	// Token: 0x06005F5F RID: 24415 RVA: 0x0017DE23 File Offset: 0x0017C023
	public virtual void QRCodeLogin()
	{
		UKuroSDKManager.OpenSdkQRScan();
	}

	// Token: 0x06005F60 RID: 24416 RVA: 0x0017DE2A File Offset: 0x0017C02A
	public virtual bool GetIsUserCenterEnable()
	{
		return true;
	}

	// Token: 0x06005F61 RID: 24417 RVA: 0x0017DE2D File Offset: 0x0017C02D
	public virtual void SetFont()
	{
	}

	// Token: 0x06005F62 RID: 24418 RVA: 0x0017DE2F File Offset: 0x0017C02F
	public virtual bool IsCustomerServiceEnable()
	{
		return true;
	}

	// Token: 0x06005F63 RID: 24419 RVA: 0x0017DE32 File Offset: 0x0017C032
	public virtual void OpenCustomerService(EKuroSdkOpenCustomerServerType fromType)
	{
	}

	// Token: 0x06005F64 RID: 24420 RVA: 0x0017DE34 File Offset: 0x0017C034
	public virtual void OpenFeedback()
	{
		IFeedBackData feedBackUrl = Singleton<BaseConfigController>.Instance.GetFeedBackUrl();
		if (feedBackUrl == null)
		{
			return;
		}
		string feedBackOpenUrl = this.GetFeedBackOpenUrl();
		if (!ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			UKismetSystemLibrary.LaunchURL(feedBackOpenUrl);
			return;
		}
		ControllerBase<KuroSdkController>.Instance.SdkOpenUrlWnd(feedBackUrl.title, feedBackOpenUrl, true, true, true);
	}

	// Token: 0x06005F65 RID: 24421 RVA: 0x0017DE80 File Offset: 0x0017C080
	protected virtual string GetFeedBackOpenUrl()
	{
		string url = Singleton<BaseConfigController>.Instance.GetFeedBackUrl().url;
		LoginModel instance = ModelBase<LoginModel>.Instance;
		FunctionModel instance2 = ModelBase<FunctionModel>.Instance;
		string text;
		if (!ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			text = "0";
		}
		else
		{
			SdkLoginConfig sdkLoginConfig = instance.GetSdkLoginConfig();
			text = (((sdkLoginConfig != null) ? sdkLoginConfig.Token : null) ?? "0");
		}
		string text2 = text;
		string text3;
		if (!ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			text3 = "0";
		}
		else
		{
			SdkLoginConfig sdkLoginConfig2 = instance.GetSdkLoginConfig();
			text3 = (((sdkLoginConfig2 != null) ? sdkLoginConfig2.Uid : null) ?? "0");
		}
		string text4 = text3;
		SdkLoginConfig sdkLoginConfig3 = instance.GetSdkLoginConfig();
		string text5;
		if (((sdkLoginConfig3 != null) ? sdkLoginConfig3.UserName : null) == null)
		{
			text5 = "";
		}
		else
		{
			SdkLoginConfig sdkLoginConfig4 = instance.GetSdkLoginConfig();
			text5 = (((sdkLoginConfig4 != null) ? sdkLoginConfig4.UserName : null) ?? "");
		}
		string text6 = text5;
		string feedBackSt = this.FeedBackSt;
		string[] array = new string[8];
		array[0] = url;
		array[1] = text2;
		int num = 2;
		string serverId = instance.GetServerId();
		array[num] = (((serverId != null) ? serverId.ToString() : null) ?? "");
		array[3] = text4;
		array[4] = text6;
		int num2 = 5;
		string playerName = instance2.GetPlayerName();
		array[num2] = (((playerName != null) ? playerName.ToString() : null) ?? "");
		array[6] = ModelBase<FunctionModel>.Instance.PlayerId.ToString();
		array[7] = Singleton<LanguageSystem>.Instance.PackageAudio;
		return StringUtils.Format(feedBackSt, array);
	}

	// Token: 0x06005F66 RID: 24422 RVA: 0x0017DFC4 File Offset: 0x0017C1C4
	public virtual void SdkOpenUrlWnd(string title, string url, bool isLandscape, bool transparent, bool webAccelerated = true)
	{
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			if (this.LastOpenTime != 0.0 && Singleton<Time>.Instance.Now - this.LastOpenTime <= 5000.0)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InDisplayCd", Array.Empty<object>());
				return;
			}
			this.LastOpenTime = Singleton<Time>.Instance.Now;
			string sdkOpenUrlWndInfo = this.GetSdkOpenUrlWndInfo(title, url);
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroOpenSdkUrlWnd;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, sdkOpenUrlWndInfo ?? "");
		}
	}

	// Token: 0x06005F67 RID: 24423 RVA: 0x0017E04C File Offset: 0x0017C24C
	public virtual void OpenWebView(string title, string url, bool isLandscape, bool transparent, bool webAccelerated, string identifier)
	{
		UKuroSDKManager.OpenWebView(title, url, isLandscape, transparent, webAccelerated, identifier, "");
	}

	// Token: 0x06005F68 RID: 24424 RVA: 0x0017E064 File Offset: 0x0017C264
	public void KuroSdkLoginBindFunction(Action<FLoginStruct> loginFunction)
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "绑定登录回调", default(ReadOnlySpan<ValueTuple<string, object>>));
		UKuroSDKManager.Get().LoginDelegate.Clear();
		UKuroSDKManager.Get().LoginDelegate.Add(delegate(FLoginStruct loginInfo)
		{
			Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "登录成功", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (loginInfo != null)
			{
				loginFunction(loginInfo);
			}
		});
	}

	// Token: 0x06005F69 RID: 24425 RVA: 0x0017E0C4 File Offset: 0x0017C2C4
	public void KuroSdkLoginBindFunction(Action<ILoginInfo> loginFunction)
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "绑定登录回调", default(ReadOnlySpan<ValueTuple<string, object>>));
		UKuroSDKManager ukuroSDKManager = UKuroSDKManager.Get();
		if (ukuroSDKManager != null)
		{
			ukuroSDKManager.LoginDelegate.Clear();
		}
		UKuroSDKManager ukuroSDKManager2 = UKuroSDKManager.Get();
		if (ukuroSDKManager2 == null)
		{
			return;
		}
		ukuroSDKManager2.LoginDelegate.Add(delegate(FLoginStruct loginInfo)
		{
			Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "登录成功", default(ReadOnlySpan<ValueTuple<string, object>>));
			loginFunction(new LoginInfo
			{
				LoginCode = (int)loginInfo.LoginCode,
				Uid = loginInfo.Uid,
				UserName = loginInfo.UserName,
				Token = loginInfo.Token
			});
		});
	}

	// Token: 0x06005F6A RID: 24426 RVA: 0x0017E12F File Offset: 0x0017C32F
	public virtual void KuroSdkKickBindFunction()
	{
		UKuroSDKManager.Get().KickDelegate.Clear();
		UKuroSDKManager.Get().KickDelegate.Add(delegate()
		{
			this.SdkLogout();
			LauncherSdk.Get().ClearCacheLoginData();
		});
	}

	// Token: 0x06005F6B RID: 24427 RVA: 0x0017E15C File Offset: 0x0017C35C
	public virtual void KuroSdkLogoutBindFunction(Action callback)
	{
		UKuroSDKManager.Get().LogoutDelegate.Clear();
		UKuroSDKManager.Get().LogoutDelegate.Add(delegate()
		{
			callback();
			LauncherSdk.Get().ClearCacheLoginData();
		});
	}

	// Token: 0x06005F6C RID: 24428 RVA: 0x0017E1A0 File Offset: 0x0017C3A0
	protected virtual void BindSpecialEvent()
	{
	}

	// Token: 0x06005F6D RID: 24429 RVA: 0x0017E1A2 File Offset: 0x0017C3A2
	protected virtual void BindExternalEvent()
	{
	}

	// Token: 0x06005F6E RID: 24430 RVA: 0x0017E1A4 File Offset: 0x0017C3A4
	protected void KuroBindExternalAchievementQueryResult()
	{
		UKuroSDKManager.Get().ExternalQueryAchievementsDelegate.Clear();
		UKuroSDKManager.Get().ExternalQueryAchievementsDelegate.Add(delegate(bool success, TArray<FAchievementStruct> achievementList)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "CacheExternalAchievement";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", success);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.AchievementMap.Clear();
			if (success && achievementList != null)
			{
				foreach (FAchievementStruct fachievementStruct in achievementList)
				{
					SdkAchievementContentData sdkAchievementContentData = new SdkAchievementContentData();
					sdkAchievementContentData.AchievementId = fachievementStruct.AchievementId;
					sdkAchievementContentData.Progress = (int)fachievementStruct.Progress;
					if (!string.IsNullOrEmpty(sdkAchievementContentData.AchievementId))
					{
						this.AchievementMap[sdkAchievementContentData.AchievementId] = sdkAchievementContentData;
					}
				}
			}
		});
	}

	// Token: 0x06005F6F RID: 24431 RVA: 0x0017E1D0 File Offset: 0x0017C3D0
	public void KuroBindExternalAchievementWriteResult()
	{
		UKuroSDKManager.Get().ExternalWriteAchievementsDelegate.Clear();
		UKuroSDKManager.Get().ExternalWriteAchievementsDelegate.Add(delegate(bool success, TArray<string> resultList)
		{
			if (resultList == null)
			{
				return;
			}
			foreach (string text in resultList)
			{
			}
		});
	}

	// Token: 0x06005F70 RID: 24432 RVA: 0x0017E20F File Offset: 0x0017C40F
	public void QueryExternalAchievement()
	{
		UKuroSDKManager.QueryExternalAchievements();
	}

	// Token: 0x06005F71 RID: 24433 RVA: 0x0017E216 File Offset: 0x0017C416
	public virtual void UnlockSdkTrophy(string id)
	{
	}

	// Token: 0x06005F72 RID: 24434 RVA: 0x0017E218 File Offset: 0x0017C418
	public virtual void KuroDeepLinkBindFunction()
	{
		UKuroSDKManager.Get().DeepLinkDelegate.Clear();
		UKuroSDKManager.Get().DeepLinkDelegate.Add(delegate(string result)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = " KuroSDKManager.Get()!.DeepLinkDelegate";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("deepLink", result);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		});
	}

	// Token: 0x06005F73 RID: 24435 RVA: 0x0017E257 File Offset: 0x0017C457
	public virtual void KuroGameWinStateBindFunction()
	{
		UKuroSDKManager.Get().GameStateChangeCallBack.Clear();
		UKuroSDKManager.Get().GameStateChangeCallBack.Add(delegate(string result)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = " KuroGameWinStateBindFunction";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("data", result);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			string a = this.ParseGameWindowStateStatus(result);
			bool sdkGetFocusState = false;
			if (a == "0")
			{
				sdkGetFocusState = true;
			}
			ModelBase<KuroSdkModel>.Instance.OnSdkFocusChange(sdkGetFocusState);
		});
	}

	// Token: 0x06005F74 RID: 24436 RVA: 0x0017E284 File Offset: 0x0017C484
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
				global::GameWindowStateData gameWindowStateData = Json.Decode<global::GameWindowStateData>(result, null);
				return (gameWindowStateData != null) ? gameWindowStateData.status : null;
			}
			catch
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.KuroSdk;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "GameWindowState JSON解析失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", result);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
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

	// Token: 0x06005F75 RID: 24437 RVA: 0x0017E348 File Offset: 0x0017C548
	private void KuroOnLogBindFunction()
	{
		UKuroSDKManager.Get().LogDelegate.Clear();
		UKuroSDKManager.Get().LogDelegate.Add(delegate(string logResult)
		{
			string[] array = logResult.Split(',', StringSplitOptions.None);
			int num = array.Length;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					string[] array2 = array[i].Split('=', StringSplitOptions.None);
					if (array2.Length == 2 && array2[0] == "level")
					{
						int num2 = int.Parse(array2[1]);
						if (num2 != 0)
						{
							if (num2 == 1)
							{
								Log instance = Singleton<Log>.Instance;
								ELogModule module = ELogModule.KuroSdk;
								ELogAuthor author = ELogAuthor.YZY;
								string message = "sdklog";
								ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Info", logResult);
								instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
							}
							else if (num2 == 2)
							{
								Log instance2 = Singleton<Log>.Instance;
								ELogModule module2 = ELogModule.KuroSdk;
								ELogAuthor author2 = ELogAuthor.YZY;
								string message2 = "sdklog";
								ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Warn", logResult);
								instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
							}
							else
							{
								Log instance3 = Singleton<Log>.Instance;
								ELogModule module3 = ELogModule.KuroSdk;
								ELogAuthor author3 = ELogAuthor.YZY;
								string message3 = "sdklog";
								ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Error", logResult);
								instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
							}
						}
					}
				}
			}
		});
	}

	// Token: 0x06005F76 RID: 24438 RVA: 0x0017E387 File Offset: 0x0017C587
	public virtual void KuroSdkExitBindFunction()
	{
		UKuroSDKManager.Get().ExitDelegate.Clear();
		UKuroSDKManager.Get().ExitDelegate.Add(delegate()
		{
			if (GlobalData.World != null)
			{
				KuroApplication.ExitWithReason(false, "KuroSdkExitBindFunction");
			}
		});
	}

	// Token: 0x06005F77 RID: 24439 RVA: 0x0017E3C6 File Offset: 0x0017C5C6
	public virtual void BindProtocolListener()
	{
		UKuroSDKManager.Get().ProtocolCallBack.Clear();
		UKuroSDKManager.Get().ProtocolCallBack.Add(delegate(bool _)
		{
			this.CurrentProtocolState = true;
		});
	}

	// Token: 0x06005F78 RID: 24440 RVA: 0x0017E3F2 File Offset: 0x0017C5F2
	public virtual void BindShareResultListener()
	{
		UKuroSDKManager.Get().ShareResultDelegate.Clear();
		UKuroSDKManager.Get().ShareResultDelegate.Add(delegate(int code, string platform, string msg)
		{
			this.OnShareResult(code, platform, msg);
		});
	}

	// Token: 0x06005F79 RID: 24441 RVA: 0x0017E41E File Offset: 0x0017C61E
	protected virtual void OnShareResult(int code, string platform, string msg)
	{
	}

	// Token: 0x06005F7A RID: 24442 RVA: 0x0017E420 File Offset: 0x0017C620
	public virtual void KuroSdkQueryProductBindFunction()
	{
		UKuroSDKManager.Get().PostProductDelegate.Clear();
		UKuroSDKManager.Get().PostProductDelegate.Add(delegate(string result)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "sdk:查询商品 queryProduct";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", result);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			QueryProductSt[] data = this.OnQueryProduct(result);
			ModelBase<KuroSdkModel>.Instance.OnQueryProductInfo(data);
		});
	}

	// Token: 0x06005F7B RID: 24443 RVA: 0x0017E44C File Offset: 0x0017C64C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	protected virtual QueryProductSt[] OnQueryProduct(string str)
	{
		return null;
	}

	// Token: 0x06005F7C RID: 24444 RVA: 0x0017E44F File Offset: 0x0017C64F
	public virtual void GetSharePlatform(Action<SharePlatformSt[]> callback)
	{
		this.GetSharePlatformCallBackList.Add(callback);
		if (!this.GetSharePlatformState)
		{
			this.GetSharePlatformState = true;
			UKuroSDKManager.GetSharePlatform();
		}
	}

	// Token: 0x06005F7D RID: 24445 RVA: 0x0017E471 File Offset: 0x0017C671
	protected virtual void OnGetSharePlatform(string str)
	{
		this.GetSharePlatformState = false;
	}

	// Token: 0x06005F7E RID: 24446 RVA: 0x0017E47C File Offset: 0x0017C67C
	public virtual void KuroSdkPaymentBindFunction(Action<bool, string> paymentFunction)
	{
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			UKuroSDKManager.Get().PaymentDelegate.Clear();
			UKuroSDKManager.Get().PaymentDelegate.Add(delegate(FPaymentStruct payment, string str)
			{
				this.OnPaymentCallBack(payment, str, paymentFunction);
				if (payment.PaymentType == EPaymentType.Success)
				{
					SuccessSdkPayEvent successSdkPayEvent = new SuccessSdkPayEvent();
					successSdkPayEvent.s_sdk_pay_order = ModelBase<KuroSdkModel>.Instance.CurrentPayingOrderId;
					ControllerBase<LogReportController>.Instance.LogReport(successSdkPayEvent);
				}
				else
				{
					FailSdkPayEvent failSdkPayEvent = new FailSdkPayEvent();
					failSdkPayEvent.s_sdk_pay_order = ModelBase<KuroSdkModel>.Instance.CurrentPayingOrderId;
					failSdkPayEvent.s_reason = ((payment.PaymentType == EPaymentType.Cancel) ? "cancel" : "fail");
					ControllerBase<LogReportController>.Instance.LogReport(failSdkPayEvent);
				}
				Singleton<KuroSdkReport>.Instance.OnSdkPay();
			});
		}
	}

	// Token: 0x06005F7F RID: 24447 RVA: 0x0017E4D3 File Offset: 0x0017C6D3
	protected virtual void OnPaymentCallBack(FPaymentStruct payment, string strResult, Action<bool, string> paymentFunction)
	{
		paymentFunction(payment.PaymentType == EPaymentType.Success, strResult);
	}

	// Token: 0x06005F80 RID: 24448 RVA: 0x0017E4E8 File Offset: 0x0017C6E8
	public virtual void KuroSdkBindRedPointFunction(Action<int> callBack)
	{
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			UKuroSDKManager.Get().PostRedPointDelegate.Clear();
			UKuroSDKManager.Get().PostRedPointDelegate.Add(delegate(byte result)
			{
				callBack((int)result);
			});
		}
	}

	// Token: 0x06005F81 RID: 24449 RVA: 0x0017E538 File Offset: 0x0017C738
	public virtual string GetDeviceDid()
	{
		return this.CurrentDid;
	}

	// Token: 0x06005F82 RID: 24450 RVA: 0x0017E540 File Offset: 0x0017C740
	public virtual void ResetCustomServerRedDot()
	{
		this.CurrentCustomerShowState = false;
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkCustomerRedPointRefresh);
	}

	// Token: 0x06005F83 RID: 24451 RVA: 0x0017E559 File Offset: 0x0017C759
	public virtual bool GetProtocolState()
	{
		return this.CurrentProtocolState || UKuroSDKManager.GetIsAgreeProtocol();
	}

	// Token: 0x06005F84 RID: 24452 RVA: 0x0017E56F File Offset: 0x0017C76F
	public virtual bool GetCustomerServiceShowState()
	{
		return this.CurrentCustomerShowState;
	}

	// Token: 0x06005F85 RID: 24453 RVA: 0x0017E577 File Offset: 0x0017C777
	public virtual bool CheckPhotoPermission()
	{
		return UKuroSDKManager.CheckPhotoPermission();
	}

	// Token: 0x06005F86 RID: 24454 RVA: 0x0017E57E File Offset: 0x0017C77E
	public virtual void RequestPhotoPermission(Action<bool> callBack)
	{
		UKuroSDKManager.Get().RequestPhotoPermissionDelegate.Clear();
		UKuroSDKManager.Get().RequestPhotoPermissionDelegate.Add(callBack);
		UKuroSDKManager.RequestPhotoPermission();
	}

	// Token: 0x06005F87 RID: 24455 RVA: 0x0017E5A4 File Offset: 0x0017C7A4
	public unsafe virtual void OpenReview(int reviewId)
	{
		bool flag = this.CheckIfCanReview();
		if (flag)
		{
			UKuroSDKManager.RequestReviewApp("");
			this.ReportReview(reviewId);
			this.SaveCurrentReviewTime();
			return;
		}
		double[] item = LocalStorage.GetGlobal<double[]>(ELocalStorageGlobalKey.OpenReviewTimeList, null) ?? Array.Empty<double>();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "OpenReview Fail";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("state", flag);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reviewTimeList", item);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06005F88 RID: 24456 RVA: 0x0017E640 File Offset: 0x0017C840
	protected virtual void ReportReview(int id)
	{
		if (Singleton<Info>.Instance.IsMobilePlatform())
		{
			if ((Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android && !ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk()) || Singleton<Info>.Instance.PlatformType == ESourcePlatformType.OpenHarmony)
			{
				return;
			}
			SdkStartReview sdkStartReview = new SdkStartReview();
			sdkStartReview.s_channel = ((Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS) ? "iOS" : "GP");
			sdkStartReview.i_id = id;
			ControllerBase<LogReportController>.Instance.LogReport(sdkStartReview);
		}
	}

	// Token: 0x06005F89 RID: 24457 RVA: 0x0017E6B8 File Offset: 0x0017C8B8
	protected virtual int CurrentPlatformYearReviewTime()
	{
		return 0;
	}

	// Token: 0x06005F8A RID: 24458 RVA: 0x0017E6BC File Offset: 0x0017C8BC
	protected virtual void SaveCurrentReviewTime()
	{
		IEnumerable<double> collection = LocalStorage.GetGlobal<double[]>(ELocalStorageGlobalKey.OpenReviewTimeList, null) ?? Array.Empty<double>();
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		int num = this.CurrentPlatformYearReviewTime();
		List<double> list = new List<double>(collection);
		if (list.Count < num)
		{
			list.Add(serverTime);
		}
		else
		{
			list.RemoveAt(0);
			list.Add(serverTime);
		}
		LocalStorage.SetGlobal<double[]>(ELocalStorageGlobalKey.OpenReviewTimeList, list.ToArray());
	}

	// Token: 0x06005F8B RID: 24459 RVA: 0x0017E720 File Offset: 0x0017C920
	protected virtual bool CheckIfCanReview()
	{
		double[] array = LocalStorage.GetGlobal<double[]>(ELocalStorageGlobalKey.OpenReviewTimeList, null) ?? Array.Empty<double>();
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		int num = this.CurrentPlatformYearReviewTime();
		bool result = false;
		if (array.Length < num)
		{
			result = true;
		}
		else
		{
			double num2 = array[0];
			if (serverTime - num2 >= 31536000.0)
			{
				result = true;
			}
		}
		return result;
	}

	// Token: 0x06005F8C RID: 24460 RVA: 0x0017E774 File Offset: 0x0017C974
	public virtual void SetCursor(string path)
	{
		UKuroSDKManager.SetCursor(path);
	}

	// Token: 0x06005F8D RID: 24461 RVA: 0x0017E77C File Offset: 0x0017C97C
	public virtual void SetGamePadMode(bool ifGamePad)
	{
		UKuroSDKManager.SetGamePadMode(ifGamePad);
	}

	// Token: 0x06005F8E RID: 24462 RVA: 0x0017E784 File Offset: 0x0017C984
	public virtual void BindWebViewCloseDelegate(Action callBack)
	{
		UKuroSDKManager ukuroSDKManager = UKuroSDKManager.Get();
		if (ukuroSDKManager != null)
		{
			ukuroSDKManager.WebViewCloseDelegate.Clear();
		}
		UKuroSDKManager ukuroSDKManager2 = UKuroSDKManager.Get();
		if (ukuroSDKManager2 == null)
		{
			return;
		}
		ukuroSDKManager2.WebViewCloseDelegate.Add(callBack);
	}

	// Token: 0x06005F8F RID: 24463 RVA: 0x0017E7B0 File Offset: 0x0017C9B0
	protected virtual string GetRoleId()
	{
		if (ModelBase<PlayerInfoModel>.Instance.GetId() != null)
		{
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int num = 0;
			if (!(id.GetValueOrDefault() == num & id != null))
			{
				return ModelBase<PlayerInfoModel>.Instance.GetId().ToString();
			}
		}
		if (ModelBase<LoginModel>.Instance.GetCreatePlayerId() != 0)
		{
			return ModelBase<LoginModel>.Instance.GetCreatePlayerId().ToString();
		}
		return "";
	}

	// Token: 0x06005F90 RID: 24464 RVA: 0x0017E82F File Offset: 0x0017CA2F
	protected virtual string GetCustomServerRoleId()
	{
		return StringUtils.Format("{0}", new string[]
		{
			this.GetRoleId()
		});
	}

	// Token: 0x06005F91 RID: 24465 RVA: 0x0017E84C File Offset: 0x0017CA4C
	protected virtual string GetCustomServerExtendsInfo()
	{
		return Json.Stringify<OpenCustomerServiceExtendsInfo>(new OpenCustomerServiceExtendsInfo
		{
			data = new OpenCustomerServiceExtendsInfoData[]
			{
				new OpenCustomerServiceExtendsInfoData
				{
					key = "version",
					label = "version",
					value = Singleton<BaseConfigController>.Instance.GetP4Version()
				}
			}
		}, null) ?? "";
	}

	// Token: 0x06005F92 RID: 24466 RVA: 0x0017E8AB File Offset: 0x0017CAAB
	public virtual void OpenExternalUrl(string url)
	{
		UKismetSystemLibrary.LaunchURL(url);
	}

	// Token: 0x06005F93 RID: 24467 RVA: 0x0017E8B3 File Offset: 0x0017CAB3
	public void CloseWebView(string identifier)
	{
		UKuroSDKManager.CloseWebView(identifier);
	}

	// Token: 0x06005F94 RID: 24468 RVA: 0x0017E8BB File Offset: 0x0017CABB
	public virtual string GetThirdUserId()
	{
		return "";
	}

	// Token: 0x06005F95 RID: 24469 RVA: 0x0017E8C2 File Offset: 0x0017CAC2
	public virtual string GetOnlineId()
	{
		return "";
	}

	// Token: 0x06005F96 RID: 24470 RVA: 0x0017E8C9 File Offset: 0x0017CAC9
	public virtual void OpenProfileCard(string uid)
	{
	}

	// Token: 0x06005F97 RID: 24471 RVA: 0x0017E8CC File Offset: 0x0017CACC
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public virtual UniTask<Dictionary<string, bool>> GetSdkBlockingUser()
	{
		PlatformSdkBase.<GetSdkBlockingUser>d__115 <GetSdkBlockingUser>d__;
		<GetSdkBlockingUser>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<string, bool>>.Create();
		<GetSdkBlockingUser>d__.<>1__state = -1;
		<GetSdkBlockingUser>d__.<>t__builder.Start<PlatformSdkBase.<GetSdkBlockingUser>d__115>(ref <GetSdkBlockingUser>d__);
		return <GetSdkBlockingUser>d__.<>t__builder.Task;
	}

	// Token: 0x06005F98 RID: 24472 RVA: 0x0017E907 File Offset: 0x0017CB07
	public virtual void SetPlayOnly(bool state)
	{
		this.PlayOnlyState = state;
	}

	// Token: 0x06005F99 RID: 24473 RVA: 0x0017E910 File Offset: 0x0017CB10
	public virtual bool NeedCheckPlayOnly()
	{
		return false;
	}

	// Token: 0x06005F9A RID: 24474 RVA: 0x0017E913 File Offset: 0x0017CB13
	public virtual bool PlayOnly()
	{
		return this.NeedCheckPlayOnly() && this.PlayOnlyState;
	}

	// Token: 0x06005F9B RID: 24475 RVA: 0x0017E925 File Offset: 0x0017CB25
	public virtual bool GetSdkFriendOnlyState()
	{
		return false;
	}

	// Token: 0x06005F9C RID: 24476 RVA: 0x0017E928 File Offset: 0x0017CB28
	public virtual void SaveSdkFriendOnlyState(bool state)
	{
	}

	// Token: 0x06005F9D RID: 24477 RVA: 0x0017E92A File Offset: 0x0017CB2A
	public virtual bool SupportSwitchFriendShowType()
	{
		return false;
	}

	// Token: 0x06005F9E RID: 24478 RVA: 0x0017E92D File Offset: 0x0017CB2D
	public virtual bool NeedShowThirdPartyId()
	{
		return false;
	}

	// Token: 0x06005F9F RID: 24479 RVA: 0x0017E930 File Offset: 0x0017CB30
	public virtual string CreatePlayerSession(string id)
	{
		return "-1";
	}

	// Token: 0x06005FA0 RID: 24480 RVA: 0x0017E937 File Offset: 0x0017CB37
	public virtual void SetMultiPlayerActivity(int currentPlayerCount, int maxPlayerCount, string playerSession, EXboxMultiplayerActivityJoinRestriction restriction)
	{
	}

	// Token: 0x06005FA1 RID: 24481 RVA: 0x0017E939 File Offset: 0x0017CB39
	public virtual bool CheckPrivilege(ESdkPrivilege privilege)
	{
		return true;
	}

	// Token: 0x06005FA2 RID: 24482 RVA: 0x0017E93C File Offset: 0x0017CB3C
	public virtual bool ResolvePrivilege(ESdkPrivilege privilege)
	{
		return true;
	}

	// Token: 0x06005FA3 RID: 24483 RVA: 0x0017E93F File Offset: 0x0017CB3F
	public virtual string GetSessionId(string playerSession)
	{
		return "-1";
	}

	// Token: 0x06005FA4 RID: 24484 RVA: 0x0017E946 File Offset: 0x0017CB46
	public virtual bool SupportSwitchFriendSearchByThirdPartyId()
	{
		return false;
	}

	// Token: 0x06005FA5 RID: 24485 RVA: 0x0017E949 File Offset: 0x0017CB49
	public virtual void LeaveMultiPlayerActivity()
	{
	}

	// Token: 0x06005FA6 RID: 24486 RVA: 0x0017E94B File Offset: 0x0017CB4B
	public virtual void JoinSessionBindFunction(Action<string, string> callback)
	{
	}

	// Token: 0x06005FA7 RID: 24487 RVA: 0x0017E94D File Offset: 0x0017CB4D
	public virtual void UpdateRecentPlayer(string[] ids)
	{
	}

	// Token: 0x06005FA8 RID: 24488 RVA: 0x0017E94F File Offset: 0x0017CB4F
	public virtual bool CheckIfSingleServerAfterSelect()
	{
		return false;
	}

	// Token: 0x06005FA9 RID: 24489 RVA: 0x0017E954 File Offset: 0x0017CB54
	[return: Nullable(0)]
	public virtual UniTask<bool> SaveSingleServerRegion(int loginType, string region, string userId, string userName, string token)
	{
		PlatformSdkBase.<SaveSingleServerRegion>d__134 <SaveSingleServerRegion>d__;
		<SaveSingleServerRegion>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SaveSingleServerRegion>d__.<>1__state = -1;
		<SaveSingleServerRegion>d__.<>t__builder.Start<PlatformSdkBase.<SaveSingleServerRegion>d__134>(ref <SaveSingleServerRegion>d__);
		return <SaveSingleServerRegion>d__.<>t__builder.Task;
	}

	// Token: 0x06005FAA RID: 24490 RVA: 0x0017E990 File Offset: 0x0017CB90
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public virtual UniTask<string> GetOnlyRegionInfo(ILoginInfo result)
	{
		PlatformSdkBase.<GetOnlyRegionInfo>d__135 <GetOnlyRegionInfo>d__;
		<GetOnlyRegionInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
		<GetOnlyRegionInfo>d__.<>1__state = -1;
		<GetOnlyRegionInfo>d__.<>t__builder.Start<PlatformSdkBase.<GetOnlyRegionInfo>d__135>(ref <GetOnlyRegionInfo>d__);
		return <GetOnlyRegionInfo>d__.<>t__builder.Task;
	}

	// Token: 0x06005FAB RID: 24491 RVA: 0x0017E9CB File Offset: 0x0017CBCB
	public virtual void CheckPermission(string id, ESdkPermission permission, Action<bool> callback)
	{
		callback(true);
	}

	// Token: 0x06005FAC RID: 24492 RVA: 0x0017E9D4 File Offset: 0x0017CBD4
	public virtual string GetExternalToken()
	{
		return "";
	}

	// Token: 0x06005FAD RID: 24493 RVA: 0x0017E9DC File Offset: 0x0017CBDC
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public virtual UniTask<string> GetExternalCollectionId()
	{
		PlatformSdkBase.<GetExternalCollectionId>d__138 <GetExternalCollectionId>d__;
		<GetExternalCollectionId>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
		<GetExternalCollectionId>d__.<>1__state = -1;
		<GetExternalCollectionId>d__.<>t__builder.Start<PlatformSdkBase.<GetExternalCollectionId>d__138>(ref <GetExternalCollectionId>d__);
		return <GetExternalCollectionId>d__.<>t__builder.Task;
	}

	// Token: 0x06005FAE RID: 24494 RVA: 0x0017EA17 File Offset: 0x0017CC17
	public virtual void OnClear()
	{
	}

	// Token: 0x06005FAF RID: 24495 RVA: 0x0017EA19 File Offset: 0x0017CC19
	public virtual void RecoverSdkData()
	{
	}

	// Token: 0x04002DF8 RID: 11768
	private const int TIMEGAP = 1000;

	// Token: 0x04002DF9 RID: 11769
	private const int WEBVIEWCD = 5000;

	// Token: 0x04002DFA RID: 11770
	private const int ONEYEARTIME = 31536000;

	// Token: 0x04002DFB RID: 11771
	[Nullable(2)]
	private TimerHandle CheckPostWebViewInitTimer;

	// Token: 0x04002DFC RID: 11772
	[Nullable(2)]
	private TimerHandle CheckIfHasInitTimer;

	// Token: 0x04002DFD RID: 11773
	protected double LastOpenTime;

	// Token: 0x04002DFE RID: 11774
	protected double LastOpenPostViewTime;

	// Token: 0x04002DFF RID: 11775
	protected readonly string FeedBackSt = "{0}?token={1}&svr_id={2}&uid={3}&user_name={4}&role_name={5}&role_id={6}&lang={7}";

	// Token: 0x04002E00 RID: 11776
	protected string CurrentDid = "";

	// Token: 0x04002E01 RID: 11777
	protected List<Action<SharePlatformSt[]>> GetSharePlatformCallBackList = new List<Action<SharePlatformSt[]>>();

	// Token: 0x04002E02 RID: 11778
	private bool GetSharePlatformState;

	// Token: 0x04002E03 RID: 11779
	private bool CurrentProtocolState;

	// Token: 0x04002E04 RID: 11780
	protected bool CurrentCustomerShowState;

	// Token: 0x04002E05 RID: 11781
	protected bool ExternalLoginState;

	// Token: 0x04002E06 RID: 11782
	protected Dictionary<string, SdkAchievementContentData> AchievementMap = new Dictionary<string, SdkAchievementContentData>();

	// Token: 0x04002E07 RID: 11783
	private bool PlayOnlyState;

	// Token: 0x0200730E RID: 29454
	[NullableContext(0)]
	private enum ESdkLogLevel
	{
		// Token: 0x04027EB3 RID: 163507
		Debug,
		// Token: 0x04027EB4 RID: 163508
		Info,
		// Token: 0x04027EB5 RID: 163509
		Warn,
		// Token: 0x04027EB6 RID: 163510
		Error
	}
}
