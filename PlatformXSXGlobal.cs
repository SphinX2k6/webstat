using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Launcher.Util;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000F26 RID: 3878
[NullableContext(1)]
[Nullable(0)]
public class PlatformXSXGlobal : PlatformSdkBase
{
	// Token: 0x0600606A RID: 24682 RVA: 0x00182540 File Offset: 0x00180740
	protected override void OnInit()
	{
		this.CurrentDid = UKuroSDKManager.GetBasicInfo().DeviceId;
		FCrashSightProxy.SetCustomData("SdkDeviceId", this.CurrentDid);
		FCrashSightProxy.SetCustomData("SdkChannelId", this.GetChannelId());
	}

	// Token: 0x0600606B RID: 24683 RVA: 0x00182574 File Offset: 0x00180774
	protected override void BindSpecialEvent()
	{
		UKuroSDKManager.Get().AnnounceInitDelegate.Clear();
		UKuroSDKManager.Get().AnnounceInitDelegate.Add(this.OnAnnounceInitCallBack);
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Clear();
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Add(new Action<string>(this.AnnounceRedPointCallBack));
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Clear();
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Add(new Action<string>(this.CustomerServiceResultCallBack));
		UKuroSDKManager.Get().OnLoginDelegate.Clear();
		UKuroSDKManager.Get().OnLoginDelegate.Add(new Action<string>(this.OnLoginCallBack));
		this.XboxGameInviteDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnXboxInviteReceivedDynamic>(new Action<FXboxInviteInfo>(this.OnXboxGameInvite));
		bool flag = UKuroStaticXSXLibrary.RegisterForXboxGameInviteEventWithCallback(this.XboxGameInviteDelegate);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "RegisterForXboxGameInviteEventWithCallback";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", flag);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.QueryExternalAchievementDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnXboxAchievementsReceived>(new <>A{00000018}<bool, TArray<FXboxAchievementInfo>>(this.OnQueryExternalAchievement));
		UKuroStaticXSXLibrary.RegisterXboxAchievementsCallback(this.QueryExternalAchievementDelegate);
		this.CheckPermissionDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnXboxPermissionCheckResult>(new Action<FXboxPermissionCheckResult>(this.OnCheckPermission));
		this.InitXboxToken();
		this.QueryExternalAchievement();
		this.CacheBlockList();
	}

	// Token: 0x0600606C RID: 24684 RVA: 0x001826C0 File Offset: 0x001808C0
	public void AnnounceRedPointCallBack(string result)
	{
		XSXSdkRedPointContentSt xsxsdkRedPointContentSt = Json.Parse<XSXSdkRedPointContentSt>(Json.Parse<XSXSdkRedPointSt>(result, null).data, null);
		ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(xsxsdkRedPointContentSt.showRed);
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
	}

	// Token: 0x0600606D RID: 24685 RVA: 0x00182700 File Offset: 0x00180900
	public void OnLoginCallBack(string result)
	{
		this.QueryExternalAchievement();
	}

	// Token: 0x0600606E RID: 24686 RVA: 0x00182708 File Offset: 0x00180908
	public void CustomerServiceResultCallBack(string result)
	{
		XSXSdkCustomerServiceSt xsxsdkCustomerServiceSt = Json.Parse<XSXSdkCustomerServiceSt>(result, null);
		XSXSdkCustomerServiceContentSt xsxsdkCustomerServiceContentSt = Json.Parse<XSXSdkCustomerServiceContentSt>(xsxsdkCustomerServiceSt.data, null);
		if (xsxsdkCustomerServiceSt != null)
		{
			this.CurrentCustomerShowState = (xsxsdkCustomerServiceContentSt.isreddot > 0);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkCustomerRedPointRefresh);
	}

	// Token: 0x0600606F RID: 24687 RVA: 0x0018274C File Offset: 0x0018094C
	public override void OpenWebView(string title, string url, bool isLandscape, bool transparent, bool webAccelerated, string identifier)
	{
		bool titlebar = false;
		if (transparent)
		{
			titlebar = true;
		}
		string text = Json.Stringify<OpenWebViewParamWindows>(new OpenWebViewParamWindows
		{
			title = title,
			url = url,
			transparent = transparent,
			titlebar = titlebar,
			innerbrowser = true,
			webAccelerated = webAccelerated,
			identifier = identifier
		}, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "OpenWebView";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sdkJson", text ?? "");
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UKuroSDKManager.OpenWebView(title, url, isLandscape, transparent, webAccelerated, identifier, text);
	}

	// Token: 0x06006070 RID: 24688 RVA: 0x001827E0 File Offset: 0x001809E0
	[return: Nullable(2)]
	public override string GetSdkOpenUrlWndInfo(string title, string url)
	{
		string text = Json.Stringify<OpenSdkUrlWndParamWindows>(new OpenSdkUrlWndParamWindows
		{
			title = title,
			url = url
		}, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "SdkJson";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sdkJson", text ?? "");
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return text;
	}

	// Token: 0x06006071 RID: 24689 RVA: 0x00182838 File Offset: 0x00180A38
	public override void SdkExit()
	{
		KuroApplication.ExitWithReason(false, "SdkExit");
	}

	// Token: 0x06006072 RID: 24690 RVA: 0x00182848 File Offset: 0x00180A48
	public override void InitializePostWebView()
	{
		string currentSelectServerId = this.GetCurrentSelectServerId();
		string text = Json.Stringify<InitializePostWebViewParam>(new InitializePostWebViewParam
		{
			language = Singleton<LanguageSystem>.Instance.PackageLanguage,
			cdn = new string[]
			{
				Singleton<PublicUtil>.Instance.GetNoticeBaseUrl() + "/gamenotice/" + Singleton<PublicUtil>.Instance.GetGameId() + "/"
			},
			serverId = currentSelectServerId
		}, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "初始化公告";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("json", text);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroInitializePostWebView;
		UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, text);
	}

	// Token: 0x06006073 RID: 24691 RVA: 0x001828E8 File Offset: 0x00180AE8
	public override void SdkPay(ISDKPayment paymentInfo)
	{
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			ISDKPayRole sdkPayRoleInfo = KuroSdkControllerTool.GetSdkPayRoleInfo();
			string paymentInfo2 = this.GetPaymentInfo(paymentInfo, sdkPayRoleInfo);
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroPay;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, paymentInfo2);
		}
	}

	// Token: 0x06006074 RID: 24692 RVA: 0x0018291A File Offset: 0x00180B1A
	private string GetPaymentInfo(ISDKPayment payment, ISDKPayRole roleInfo)
	{
		return Json.Stringify<PayInfoXSXGlobal>(new PayInfoXSXGlobal
		{
			goodsId = payment.product_id.ToString()
		}, null);
	}

	// Token: 0x06006075 RID: 24693 RVA: 0x00182938 File Offset: 0x00180B38
	public override void OpenCustomerService(EKuroSdkOpenCustomerServerType fromType)
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		UKuroSDKManager.OpenCustomerService(Json.Stringify<OpenCustomerServiceParamWindows>(new OpenCustomerServiceParamWindows
		{
			islogin = instance.IsSdkLoggedIn(),
			from = fromType,
			roleId = this.GetCustomServerRoleId(),
			extendsInfo = this.GetCustomServerExtendsInfo()
		}, null));
	}

	// Token: 0x06006076 RID: 24694 RVA: 0x00182988 File Offset: 0x00180B88
	public override void SdkCreateRole()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "上报创建新角色", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			string createRoleInfo = this.GetCreateRoleInfo();
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKCreateRole;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, createRoleInfo);
		}
	}

	// Token: 0x06006077 RID: 24695 RVA: 0x001829D0 File Offset: 0x00180BD0
	public override void SdkSelectRole()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "上报选择角色", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			string roleInfo = this.GetRoleInfo();
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKSelectedRole;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, roleInfo);
		}
	}

	// Token: 0x06006078 RID: 24696 RVA: 0x00182A18 File Offset: 0x00180C18
	public override void SdkLevelUpRole()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "上报角色升级", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			string roleInfo = this.GetRoleInfo();
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroSDKUpgradeRole;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, roleInfo);
		}
	}

	// Token: 0x06006079 RID: 24697 RVA: 0x00182A60 File Offset: 0x00180C60
	private string GetCreateRoleInfo()
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		RoleInfoWindows roleInfoWindows = new RoleInfoWindows();
		roleInfoWindows.roleId = this.GetRoleId();
		roleInfoWindows.roleName = (instance.GetPlayerName() ?? "");
		roleInfoWindows.serverId = (instance.GetServerId() ?? "");
		roleInfoWindows.serverName = (instance.GetServerName() ?? "");
		roleInfoWindows.roleLevel = "1";
		roleInfoWindows.vipLevel = "0";
		roleInfoWindows.partyName = " ";
		roleInfoWindows.roleCreateTime = ((instance.GetCreatePlayerTime() != 0.0) ? instance.GetCreatePlayerTime().ToString() : "");
		roleInfoWindows.setBalanceLevelOne = "0";
		roleInfoWindows.setBalanceLevelTwo = "0";
		roleInfoWindows.setSumPay = "0";
		JsonSerializerOptions options = new JsonSerializerOptions
		{
			IncludeFields = true,
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
		};
		return JsonSerializer.Serialize<RoleInfoWindows>(roleInfoWindows, options);
	}

	// Token: 0x0600607A RID: 24698 RVA: 0x00182B50 File Offset: 0x00180D50
	private string GetRoleInfo()
	{
		FunctionModel instance = ModelBase<FunctionModel>.Instance;
		LoginModel instance2 = ModelBase<LoginModel>.Instance;
		RoleInfoWindows roleInfoWindows = new RoleInfoWindows();
		roleInfoWindows.roleId = this.GetRoleId();
		roleInfoWindows.roleName = (instance.GetPlayerName() ?? "");
		roleInfoWindows.serverId = (instance2.GetServerId() ?? "");
		roleInfoWindows.serverName = (instance2.GetServerName() ?? "");
		int? playerLevel = instance.GetPlayerLevel();
		roleInfoWindows.roleLevel = ((playerLevel != null && playerLevel.Value != 0) ? playerLevel.Value.ToString() : "1");
		roleInfoWindows.vipLevel = "0";
		roleInfoWindows.partyName = " ";
		roleInfoWindows.roleCreateTime = "";
		roleInfoWindows.setBalanceLevelOne = instance.GetPlayerCashCoin();
		roleInfoWindows.setBalanceLevelTwo = "0";
		roleInfoWindows.setSumPay = "0";
		JsonSerializerOptions options = new JsonSerializerOptions
		{
			IncludeFields = true,
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
		};
		return JsonSerializer.Serialize<RoleInfoWindows>(roleInfoWindows, options);
	}

	// Token: 0x0600607B RID: 24699 RVA: 0x00182C50 File Offset: 0x00180E50
	public override void OpenUserCenter()
	{
		UKuroSDKManager.BindAccount();
	}

	// Token: 0x0600607C RID: 24700 RVA: 0x00182C58 File Offset: 0x00180E58
	public override void QueryProduct(string[] productList, string channelId)
	{
		string text = "";
		int num = productList.Length;
		for (int i = 0; i < num; i++)
		{
			text += productList[i];
			if (i != num - 1)
			{
				text += ",";
			}
		}
		UKuroSDKManager.QueryProductInfo(Json.Stringify<QueryProductInfoParamWindows>(new QueryProductInfoParamWindows
		{
			goodsIds = text,
			payChannel = channelId
		}, null) ?? "");
	}

	// Token: 0x0600607D RID: 24701 RVA: 0x00182CC0 File Offset: 0x00180EC0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	protected override QueryProductSt[] OnQueryProduct(string str)
	{
		XSXSdkQueryProductSt xsxsdkQueryProductSt = Json.Parse<XSXSdkQueryProductSt>(str, null);
		List<QueryProductSt> list = new List<QueryProductSt>();
		if (((xsxsdkQueryProductSt != null) ? xsxsdkQueryProductSt.data : null) != null)
		{
			foreach (XSXSdkProductContentSt xsxsdkProductContentSt in xsxsdkQueryProductSt.data)
			{
				list.Add(new QueryProductSt
				{
					ChannelGoodId = xsxsdkProductContentSt.channelGoodsId,
					Currency = xsxsdkProductContentSt.currency,
					CurrencyCode = xsxsdkProductContentSt.currencyCode,
					GoodId = xsxsdkProductContentSt.goodsId,
					Name = xsxsdkProductContentSt.name,
					Price = new float?(xsxsdkProductContentSt.price)
				});
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600607E RID: 24702 RVA: 0x00182D74 File Offset: 0x00180F74
	public override void SetFont()
	{
		SetFontParamWindows setFontParamWindows = new SetFontParamWindows();
		string currentFontName = ModelBase<KuroSdkModel>.Instance.GetCurrentFontName();
		setFontParamWindows.name = currentFontName;
		string deviceFontAsset = ModelBase<KuroSdkModel>.Instance.GetDeviceFontAsset();
		setFontParamWindows.path = UBlueprintPathsLibrary.RootDir() + "Client/Binaries/Win64/ThirdParty/KrPcSdk_Global/" + deviceFontAsset;
		JsonSerializerOptions options = new JsonSerializerOptions
		{
			IncludeFields = true,
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
		};
		string text = JsonSerializer.Serialize<SetFontParamWindows>(setFontParamWindows, options);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "SetFont";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("data", text);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UKuroSDKManager.SetFont(text);
	}

	// Token: 0x0600607F RID: 24703 RVA: 0x00182E05 File Offset: 0x00181005
	public override string GetChannelId()
	{
		return UKuroSDKManager.GetSdkParams("channel_id");
	}

	// Token: 0x06006080 RID: 24704 RVA: 0x00182E11 File Offset: 0x00181011
	public override string GetChannelName()
	{
		return UKuroSDKManager.GetSdkParams("channel_name");
	}

	// Token: 0x06006081 RID: 24705 RVA: 0x00182E1D File Offset: 0x0018101D
	public override string GetGameId()
	{
		return UKuroSDKManager.GetSdkParams("project_id");
	}

	// Token: 0x06006082 RID: 24706 RVA: 0x00182E29 File Offset: 0x00181029
	public override string GetDid()
	{
		return UKuroSDKManager.GetSdkParams("did");
	}

	// Token: 0x06006083 RID: 24707 RVA: 0x00182E35 File Offset: 0x00181035
	public override string GetAccessToken()
	{
		return UKuroSDKManager.GetSdkParams("token");
	}

	// Token: 0x06006084 RID: 24708 RVA: 0x00182E44 File Offset: 0x00181044
	public override void SdkOpenUrlWnd(string title, string url, bool isLandscape, bool transparent, bool webAccelerated = true)
	{
		if (this.LastOpenTime != 0.0 && Singleton<Time>.Instance.Now - this.LastOpenTime <= 5000.0)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InDisplayCd", Array.Empty<object>());
			return;
		}
		this.LastOpenTime = Singleton<Time>.Instance.Now;
		this.OpenWebView(title, url, isLandscape, transparent, webAccelerated, "");
	}

	// Token: 0x06006085 RID: 24709 RVA: 0x00182EB5 File Offset: 0x001810B5
	public override bool GetProtocolState()
	{
		return true;
	}

	// Token: 0x06006086 RID: 24710 RVA: 0x00182EB8 File Offset: 0x001810B8
	protected override void OnPaymentCallBack(FPaymentStruct payment, string strResult, Action<bool, string> paymentFunction)
	{
		XSXPaymentSt xsxpaymentSt = Json.Parse<XSXPaymentSt>(strResult, null);
		bool arg = false;
		if (xsxpaymentSt != null && xsxpaymentSt.error == 0)
		{
			arg = true;
			Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "OnPaymentCallBack Windows Success", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		paymentFunction(arg, strResult);
	}

	// Token: 0x06006087 RID: 24711 RVA: 0x00182F08 File Offset: 0x00181108
	private long GetCurrentUserHandle()
	{
		if (this.CurrentUserHandle != 0L)
		{
			return this.CurrentUserHandle;
		}
		long num = 0L;
		UKuroStaticXSXLibrary.GetXboxDefaultUserHandle(ref num);
		this.CurrentUserHandle = num;
		return num;
	}

	// Token: 0x06006088 RID: 24712 RVA: 0x00182F38 File Offset: 0x00181138
	public override string GetThirdUserId()
	{
		return UKuroStaticXSXLibrary.GetXboxUserId(this.GetCurrentUserHandle()).UserId.ToString();
	}

	// Token: 0x06006089 RID: 24713 RVA: 0x00182F5D File Offset: 0x0018115D
	public override string GetOnlineId()
	{
		return UKuroStaticXSXLibrary.GetXboxGamertagForDisplay(this.GetCurrentUserHandle(), EXboxGamertagComponent.Classic).Gamertag;
	}

	// Token: 0x0600608A RID: 24714 RVA: 0x00182F70 File Offset: 0x00181170
	public override void OpenProfileCard(string xuid)
	{
		UKuroStaticXSXLibrary.ShowXboxPlayerProfileCard(this.GetCurrentUserHandle(), long.Parse(xuid));
	}

	// Token: 0x0600608B RID: 24715 RVA: 0x00182F84 File Offset: 0x00181184
	private void CacheBlockList()
	{
		Action<FXboxAvoidListResult> callback = null;
		callback = delegate(FXboxAvoidListResult result)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "CacheBlockList";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("result", result);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			global::DelegateUtils.ReleaseManualReleaseDelegate(callback);
			int num = result.Xuids.Num();
			for (int i = 0; i < num; i++)
			{
				long num2 = result.Xuids.Get(i);
				this.BlockMap.TryAdd(num2.ToString(), true);
			}
		};
		FOnXboxAvoidListResult callback2 = global::DelegateUtils.ToManualReleaseDelegate<FOnXboxAvoidListResult>(callback);
		UKuroStaticXSXLibrary.GetXboxAvoidListAsync(this.GetCurrentUserHandle(), callback2);
	}

	// Token: 0x0600608C RID: 24716 RVA: 0x00182FCD File Offset: 0x001811CD
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public override UniTask<Dictionary<string, bool>> GetSdkBlockingUser()
	{
		return UniTask.FromResult<Dictionary<string, bool>>(this.BlockMap);
	}

	// Token: 0x0600608D RID: 24717 RVA: 0x00182FDA File Offset: 0x001811DA
	public override bool NeedCheckPlayOnly()
	{
		return true;
	}

	// Token: 0x0600608E RID: 24718 RVA: 0x00182FDD File Offset: 0x001811DD
	public override bool GetSdkFriendOnlyState()
	{
		return Singleton<LauncherStorageLib>.Instance.GetGlobal<bool>(ELauncherStorageGlobalKey.PlayStationFriendOnly, false);
	}

	// Token: 0x0600608F RID: 24719 RVA: 0x00182FEB File Offset: 0x001811EB
	public override void SaveSdkFriendOnlyState(bool state)
	{
		Singleton<LauncherStorageLib>.Instance.SetGlobal<bool>(ELauncherStorageGlobalKey.PlayStationFriendOnly, state);
	}

	// Token: 0x06006090 RID: 24720 RVA: 0x00182FFA File Offset: 0x001811FA
	public override bool SupportSwitchFriendShowType()
	{
		return true;
	}

	// Token: 0x06006091 RID: 24721 RVA: 0x00182FFD File Offset: 0x001811FD
	public override bool NeedShowThirdPartyId()
	{
		return true;
	}

	// Token: 0x06006092 RID: 24722 RVA: 0x00183000 File Offset: 0x00181200
	public override string CreatePlayerSession(string id)
	{
		return id;
	}

	// Token: 0x06006093 RID: 24723 RVA: 0x00183003 File Offset: 0x00181203
	public override string GetSessionId(string playerSession)
	{
		return playerSession;
	}

	// Token: 0x06006094 RID: 24724 RVA: 0x00183008 File Offset: 0x00181208
	public unsafe override void SetMultiPlayerActivity(int currentPlayerCount, int maxPlayerCount, string playerSession, EXboxMultiplayerActivityJoinRestriction restriction)
	{
		string connectionString = "";
		string groupId = "";
		if (restriction != EXboxMultiplayerActivityJoinRestriction.Activity_InviteOnly)
		{
			connectionString = playerSession;
			groupId = "WutheringWaves" + playerSession;
		}
		string thirdUserId = this.GetThirdUserId();
		Action<bool> setMpCb = null;
		setMpCb = delegate(bool bSuccess)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.KuroSdk;
			ELogAuthor author2 = ELogAuthor.YZY;
			string message2 = "CreateXboxMultiplayerActivityAsync";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bSuccess", bSuccess);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			global::DelegateUtils.ReleaseManualReleaseDelegate(setMpCb);
		};
		FOnXboxCallResult callback = global::DelegateUtils.ToManualReleaseDelegate<FOnXboxCallResult>(setMpCb);
		UKuroStaticXSXLibrary.SetXboxMultiplayerActivityAsync(this.GetCurrentUserHandle(), long.Parse(thirdUserId), connectionString, maxPlayerCount, currentPlayerCount, groupId, restriction, true, callback);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "SetMultiPlayerActivity";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("currentPlayerCount", currentPlayerCount);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("maxPlayerCount", maxPlayerCount);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("playerSession", playerSession);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("restriction", restriction);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
	}

	// Token: 0x06006095 RID: 24725 RVA: 0x00183110 File Offset: 0x00181310
	public void GetMultiPlayerActivityInfo()
	{
		long currentUserHandle = this.GetCurrentUserHandle();
		string thirdUserId = this.GetThirdUserId();
		string text = "";
		int num = 0;
		int num2 = 0;
		string text2 = "";
		bool xboxMultiplayerActivity = UKuroStaticXSXLibrary.GetXboxMultiplayerActivity(currentUserHandle, long.Parse(thirdUserId), ref text, ref num, ref num2, ref text2);
		string item = text;
		int num3 = num;
		int num4 = num2;
		string item2 = text2;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "GetXboxMultiplayerActivityInfo";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("connectionString", item);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.KuroSdk;
		ELogAuthor author2 = ELogAuthor.YZY;
		string message2 = "GetXboxMultiplayerActivityInfo";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("maxPlayers", num3);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.KuroSdk;
		ELogAuthor author3 = ELogAuthor.YZY;
		string message3 = "GetXboxMultiplayerActivityInfo";
		ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("currentPlayers", num4);
		instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
		Log instance4 = Singleton<Log>.Instance;
		ELogModule module4 = ELogModule.KuroSdk;
		ELogAuthor author4 = ELogAuthor.YZY;
		string message4 = "GetXboxMultiplayerActivityInfo";
		ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("groupId", item2);
		instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
		Log instance5 = Singleton<Log>.Instance;
		ELogModule module5 = ELogModule.KuroSdk;
		ELogAuthor author5 = ELogAuthor.YZY;
		string message5 = "GetXboxMultiplayerActivityInfo";
		ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("result", xboxMultiplayerActivity);
		instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
	}

	// Token: 0x06006096 RID: 24726 RVA: 0x00183234 File Offset: 0x00181434
	public override void LeaveMultiPlayerActivity()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "LeaveMultiPlayerActivity", default(ReadOnlySpan<ValueTuple<string, object>>));
		Action<bool> deleteMpCb = null;
		deleteMpCb = delegate(bool bSuccess)
		{
			this.OnDeleteMultiPlayerActivityAsyncComplete(bSuccess);
			global::DelegateUtils.ReleaseManualReleaseDelegate(deleteMpCb);
		};
		FOnXboxCallResult callback = global::DelegateUtils.ToManualReleaseDelegate<FOnXboxCallResult>(deleteMpCb);
		UKuroStaticXSXLibrary.DeleteXboxMultiplayerActivityAsync(this.GetCurrentUserHandle(), callback);
	}

	// Token: 0x06006097 RID: 24727 RVA: 0x0018329C File Offset: 0x0018149C
	private void OnDeleteMultiPlayerActivityAsyncComplete(bool bSuccess)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "LeaveMultiPlayerActivity";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bSuccess", bSuccess);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06006098 RID: 24728 RVA: 0x001832D8 File Offset: 0x001814D8
	public override bool CheckPrivilege(ESdkPrivilege privilege)
	{
		bool flag;
		if (this.PrivilegeCacheMap.TryGetValue((int)privilege, out flag) && flag)
		{
			return true;
		}
		bool flag2 = false;
		EXboxUserPrivilege privilege2 = EXboxUserPrivilege.Multiplayer;
		if (privilege == ESdkPrivilege.Multiplayer)
		{
			flag2 = true;
			privilege2 = EXboxUserPrivilege.Multiplayer;
		}
		else if (privilege == ESdkPrivilege.Communications)
		{
			flag2 = true;
			privilege2 = EXboxUserPrivilege.Communications;
		}
		else if (privilege == ESdkPrivilege.UserGeneratedContent)
		{
			flag2 = true;
			privilege2 = EXboxUserPrivilege.UserGeneratedContent;
		}
		else if (privilege == ESdkPrivilege.CrossPlay)
		{
			flag2 = true;
			privilege2 = EXboxUserPrivilege.CrossPlay;
		}
		if (flag2)
		{
			bool bHasPrivilege = UKuroStaticXSXLibrary.CheckXboxPrivilege(this.GetCurrentUserHandle(), privilege2, EXboxUserPrivilegeOptions.None).bHasPrivilege;
			this.PrivilegeCacheMap[(int)privilege] = bHasPrivilege;
			return bHasPrivilege;
		}
		return true;
	}

	// Token: 0x06006099 RID: 24729 RVA: 0x00183350 File Offset: 0x00181550
	public override bool ResolvePrivilege(ESdkPrivilege privilege)
	{
		if (privilege == ESdkPrivilege.Invalid)
		{
			return true;
		}
		bool flag;
		if (this.PrivilegeCacheMap.TryGetValue((int)privilege, out flag) && flag)
		{
			return true;
		}
		EXboxUserPrivilege privilege2 = EXboxUserPrivilege.Multiplayer;
		if (privilege == ESdkPrivilege.Multiplayer)
		{
			privilege2 = EXboxUserPrivilege.Multiplayer;
		}
		else if (privilege == ESdkPrivilege.Communications)
		{
			privilege2 = EXboxUserPrivilege.Communications;
		}
		else if (privilege == ESdkPrivilege.UserGeneratedContent)
		{
			privilege2 = EXboxUserPrivilege.UserGeneratedContent;
		}
		else if (privilege == ESdkPrivilege.CrossPlay)
		{
			privilege2 = EXboxUserPrivilege.CrossPlay;
		}
		bool flag2 = UKuroStaticXSXLibrary.ResolveXboxPrivilegeWithUi(this.GetCurrentUserHandle(), privilege2, EXboxUserPrivilegeOptions.None);
		if (flag2)
		{
			this.PrivilegeCacheMap[(int)privilege] = true;
		}
		return flag2;
	}

	// Token: 0x0600609A RID: 24730 RVA: 0x001833B8 File Offset: 0x001815B8
	public override void JoinSessionBindFunction(Action<string, string> callback)
	{
		this.JoinSessionCallback = callback;
		if (this.PendingJoinSessionInfo != null)
		{
			string userId = this.PendingJoinSessionInfo.userId;
			string playerSession = this.PendingJoinSessionInfo.playerSession;
			this.PendingJoinSessionInfo = null;
			this.JoinSessionCallback(userId, playerSession);
		}
	}

	// Token: 0x0600609B RID: 24731 RVA: 0x00183400 File Offset: 0x00181600
	public override bool SupportSwitchFriendSearchByThirdPartyId()
	{
		return true;
	}

	// Token: 0x0600609C RID: 24732 RVA: 0x00183404 File Offset: 0x00181604
	public override void OnClear()
	{
		if (this.XboxGameInviteDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FXboxInviteInfo>(this.OnXboxGameInvite));
			this.XboxGameInviteDelegate = null;
		}
		UKuroStaticXSXLibrary.UnregisterFromXboxGameInviteEvent();
		if (this.QueryExternalAchievementDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new <>A{00000018}<bool, TArray<FXboxAchievementInfo>>(this.OnQueryExternalAchievement));
			this.QueryExternalAchievementDelegate = null;
		}
		UKuroStaticXSXLibrary.UnregisterXboxAchievementsCallback();
		if (this.CheckPermissionDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FXboxPermissionCheckResult>(this.OnCheckPermission));
			this.CheckPermissionDelegate = null;
		}
	}

	// Token: 0x0600609D RID: 24733 RVA: 0x0018347C File Offset: 0x0018167C
	private void OnXboxGameInvite(FXboxInviteInfo info)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "XboxGameInviteCallback";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("inviteInfo", info);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (info.bHasInvite)
		{
			string text = info.InvitedXuid.ToString();
			string connectionString = info.ConnectionString;
			if (this.JoinSessionCallback != null)
			{
				this.JoinSessionCallback(text, connectionString);
				return;
			}
			this.PendingJoinSessionInfo = new XboxPendingJoinSessionInfo();
			this.PendingJoinSessionInfo.userId = text;
			this.PendingJoinSessionInfo.playerSession = connectionString;
		}
	}

	// Token: 0x0600609E RID: 24734 RVA: 0x00183508 File Offset: 0x00181708
	public new void QueryExternalAchievement()
	{
		long currentUserHandle = this.GetCurrentUserHandle();
		string thirdUserId = this.GetThirdUserId();
		UKuroStaticXSXLibrary.GetXboxAchievementsAsync(currentUserHandle, long.Parse(thirdUserId), EXboxAchievementType.All, false, EXboxAchievementOrderBy.DefaultOrder, 0, 0);
	}

	// Token: 0x0600609F RID: 24735 RVA: 0x00183534 File Offset: 0x00181734
	private void OnQueryExternalAchievement(bool bSuccess, [Nullable(new byte[]
	{
		2,
		1
	})] in TArray<FXboxAchievementInfo> Achievements)
	{
		if (bSuccess && Achievements != null)
		{
			int num = Achievements.Num();
			for (int i = 0; i < num; i++)
			{
				FXboxAchievementInfo fxboxAchievementInfo = Achievements.Get(i);
				SdkAchievementContentData sdkAchievementContentData = new SdkAchievementContentData();
				sdkAchievementContentData.AchievementId = fxboxAchievementInfo.Id;
				sdkAchievementContentData.Progress = ((fxboxAchievementInfo.ProgressState == 1) ? 100 : 0);
				this.AchievementMap[fxboxAchievementInfo.Id] = sdkAchievementContentData;
			}
		}
	}

	// Token: 0x060060A0 RID: 24736 RVA: 0x001835A0 File Offset: 0x001817A0
	public override void UnlockSdkTrophy(string id)
	{
		if (!this.AchievementMap.ContainsKey(id))
		{
			return;
		}
		if (this.AchievementMap[id].Progress == 100)
		{
			return;
		}
		long currentUserHandle = this.GetCurrentUserHandle();
		string thirdUserId = this.GetThirdUserId();
		UKuroStaticXSXLibrary.UpdateXboxAchievementAsync(currentUserHandle, long.Parse(thirdUserId), id, 100);
	}

	// Token: 0x060060A1 RID: 24737 RVA: 0x001835F0 File Offset: 0x001817F0
	public override void UpdateRecentPlayer(string[] ids)
	{
		long userHandle = this.GetCurrentUserHandle();
		string thirdUserId = this.GetThirdUserId();
		TArray<FXboxRecentPlayerUpdate> tarray = new TArray<FXboxRecentPlayerUpdate>();
		foreach (string text in ids)
		{
			if (!(text == thirdUserId))
			{
				FXboxRecentPlayerUpdate fxboxRecentPlayerUpdate = new FXboxRecentPlayerUpdate();
				fxboxRecentPlayerUpdate.Xuid = long.Parse(text);
				tarray.Add(fxboxRecentPlayerUpdate);
			}
		}
		if (tarray.Num() == 0)
		{
			return;
		}
		Action<bool> recentCb = null;
		recentCb = delegate(bool bSuccess)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "UpdateXboxMultiplayerActivityRecentPlayersAsync";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bSuccess", bSuccess);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			global::DelegateUtils.ReleaseManualReleaseDelegate(recentCb);
			UKuroStaticXSXLibrary.FlushXboxMultiplayerActivityRecentPlayersAsync(userHandle);
		};
		FOnXboxCallResult callback = global::DelegateUtils.ToManualReleaseDelegate<FOnXboxCallResult>(recentCb);
		UKuroStaticXSXLibrary.UpdateXboxMultiplayerActivityRecentPlayersAsync(userHandle, tarray, callback);
	}

	// Token: 0x060060A2 RID: 24738 RVA: 0x0018369C File Offset: 0x0018189C
	public override bool CheckIfSingleServerAfterSelect()
	{
		return Singleton<Info>.Instance.IsBuildShipping;
	}

	// Token: 0x060060A3 RID: 24739 RVA: 0x001836B0 File Offset: 0x001818B0
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public override UniTask<string> GetOnlyRegionInfo(ILoginInfo result)
	{
		PlatformXSXGlobal.<GetOnlyRegionInfo>d__70 <GetOnlyRegionInfo>d__;
		<GetOnlyRegionInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
		<GetOnlyRegionInfo>d__.result = result;
		<GetOnlyRegionInfo>d__.<>1__state = -1;
		<GetOnlyRegionInfo>d__.<>t__builder.Start<PlatformXSXGlobal.<GetOnlyRegionInfo>d__70>(ref <GetOnlyRegionInfo>d__);
		return <GetOnlyRegionInfo>d__.<>t__builder.Task;
	}

	// Token: 0x060060A4 RID: 24740 RVA: 0x001836F4 File Offset: 0x001818F4
	[return: Nullable(0)]
	public override UniTask<bool> SaveSingleServerRegion(int loginType, string region, string userId, string userName, string token)
	{
		PlatformXSXGlobal.<SaveSingleServerRegion>d__71 <SaveSingleServerRegion>d__;
		<SaveSingleServerRegion>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SaveSingleServerRegion>d__.loginType = loginType;
		<SaveSingleServerRegion>d__.region = region;
		<SaveSingleServerRegion>d__.userId = userId;
		<SaveSingleServerRegion>d__.userName = userName;
		<SaveSingleServerRegion>d__.token = token;
		<SaveSingleServerRegion>d__.<>1__state = -1;
		<SaveSingleServerRegion>d__.<>t__builder.Start<PlatformXSXGlobal.<SaveSingleServerRegion>d__71>(ref <SaveSingleServerRegion>d__);
		return <SaveSingleServerRegion>d__.<>t__builder.Task;
	}

	// Token: 0x060060A5 RID: 24741 RVA: 0x0018375C File Offset: 0x0018195C
	private void OnCheckPermission(FXboxPermissionCheckResult result)
	{
		ESdkPermission esdkPermission = this.ConvertPermissionToESdkPermission(result.Permission);
		string key = result.TargetXuid.ToString() + esdkPermission.ToString();
		Action<bool> action;
		if (this.PermissionCallBackMap.TryGetValue(key, out action))
		{
			action(result.bIsAllowed);
			this.PermissionCallBackMap.Remove(key);
		}
		List<XboxPermissionCheckResultSt> list;
		if (this.UserPermissionMap.TryGetValue(result.TargetXuid.ToString(), out list))
		{
			foreach (XboxPermissionCheckResultSt xboxPermissionCheckResultSt in list)
			{
				if (xboxPermissionCheckResultSt.Permission == esdkPermission)
				{
					xboxPermissionCheckResultSt.Result = result.bIsAllowed;
					break;
				}
			}
		}
	}

	// Token: 0x060060A6 RID: 24742 RVA: 0x00183834 File Offset: 0x00181A34
	public override void CheckPermission(string xuid, ESdkPermission permission, Action<bool> callback)
	{
		if (xuid == "")
		{
			callback(true);
			return;
		}
		List<XboxPermissionCheckResultSt> list;
		if (this.UserPermissionMap.TryGetValue(xuid, out list))
		{
			using (List<XboxPermissionCheckResultSt>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					XboxPermissionCheckResultSt xboxPermissionCheckResultSt = enumerator.Current;
					if (xboxPermissionCheckResultSt.Permission == permission)
					{
						callback(xboxPermissionCheckResultSt.Result);
						return;
					}
				}
				goto IL_7F;
			}
		}
		list = new List<XboxPermissionCheckResultSt>();
		this.UserPermissionMap[xuid] = list;
		IL_7F:
		XboxPermissionCheckResultSt xboxPermissionCheckResultSt2 = new XboxPermissionCheckResultSt();
		xboxPermissionCheckResultSt2.Permission = permission;
		xboxPermissionCheckResultSt2.Result = false;
		list.Add(xboxPermissionCheckResultSt2);
		this.PermissionCallBackMap[xuid + permission.ToString()] = callback;
		EXboxPermission permission2 = this.ConvertPermission(permission);
		UKuroStaticXSXLibrary.CheckXboxPermissionAsync(this.GetCurrentUserHandle(), long.Parse(xuid), permission2, this.CheckPermissionDelegate);
	}

	// Token: 0x060060A7 RID: 24743 RVA: 0x0018392C File Offset: 0x00181B2C
	private EXboxPermission ConvertPermission(ESdkPermission permission)
	{
		if (permission == ESdkPermission.CommunicateUsingText)
		{
			return EXboxPermission.CommunicateUsingText;
		}
		if (permission == ESdkPermission.CommunicateUsingVoice)
		{
			return EXboxPermission.CommunicateUsingVoice;
		}
		if (permission == ESdkPermission.ViewTargetProfile)
		{
			return EXboxPermission.ViewTargetProfile;
		}
		return EXboxPermission.CommunicateUsingText;
	}

	// Token: 0x060060A8 RID: 24744 RVA: 0x00183940 File Offset: 0x00181B40
	private ESdkPermission ConvertPermissionToESdkPermission(EXboxPermission permission)
	{
		if (permission == EXboxPermission.CommunicateUsingText)
		{
			return ESdkPermission.CommunicateUsingText;
		}
		if (permission == EXboxPermission.CommunicateUsingVoice)
		{
			return ESdkPermission.CommunicateUsingVoice;
		}
		if (permission == EXboxPermission.ViewTargetProfile)
		{
			return ESdkPermission.ViewTargetProfile;
		}
		return ESdkPermission.CommunicateUsingText;
	}

	// Token: 0x060060A9 RID: 24745 RVA: 0x00183954 File Offset: 0x00181B54
	private void InitXboxToken()
	{
		this.QueryXboxToken(delegate(string token)
		{
			this.XboxToken = token;
		});
	}

	// Token: 0x060060AA RID: 24746 RVA: 0x00183968 File Offset: 0x00181B68
	private void QueryXboxToken(Action<string> finishTokenCallBack)
	{
		long currentUserHandle = this.GetCurrentUserHandle();
		string url = "https://sdk-prod-cdn-aws.kurogame-service.com";
		Action<FXboxTokenAndSignatureResult> tokenCb = null;
		tokenCb = delegate(FXboxTokenAndSignatureResult result)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(tokenCb);
			if (result.bSuccess)
			{
				finishTokenCallBack(result.Token);
				return;
			}
			this.QueryXboxToken(finishTokenCallBack);
		};
		FOnXboxTokenAndSignatureResult callback = global::DelegateUtils.ToManualReleaseDelegate<FOnXboxTokenAndSignatureResult>(tokenCb);
		UKuroStaticXSXLibrary.GetXboxTokenAndSignatureAsync(currentUserHandle, url, callback);
	}

	// Token: 0x060060AB RID: 24747 RVA: 0x001839C1 File Offset: 0x00181BC1
	public override string GetExternalToken()
	{
		return this.XboxToken;
	}

	// Token: 0x060060AC RID: 24748 RVA: 0x001839CC File Offset: 0x00181BCC
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public override UniTask<string> GetExternalCollectionId()
	{
		PlatformXSXGlobal.<GetExternalCollectionId>d__79 <GetExternalCollectionId>d__;
		<GetExternalCollectionId>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
		<GetExternalCollectionId>d__.<>1__state = -1;
		<GetExternalCollectionId>d__.<>t__builder.Start<PlatformXSXGlobal.<GetExternalCollectionId>d__79>(ref <GetExternalCollectionId>d__);
		return <GetExternalCollectionId>d__.<>t__builder.Task;
	}

	// Token: 0x04002E5A RID: 11866
	private const int WEBVIEWCD = 5000;

	// Token: 0x04002E5B RID: 11867
	private long CurrentUserHandle;

	// Token: 0x04002E5C RID: 11868
	[Nullable(2)]
	private FOnXboxAchievementsReceived QueryExternalAchievementDelegate;

	// Token: 0x04002E5D RID: 11869
	[Nullable(2)]
	private FOnXboxInviteReceivedDynamic XboxGameInviteDelegate;

	// Token: 0x04002E5E RID: 11870
	[Nullable(2)]
	private FOnXboxPermissionCheckResult CheckPermissionDelegate;

	// Token: 0x04002E5F RID: 11871
	private readonly Dictionary<int, bool> PrivilegeCacheMap = new Dictionary<int, bool>();

	// Token: 0x04002E60 RID: 11872
	private readonly Dictionary<string, bool> BlockMap = new Dictionary<string, bool>();

	// Token: 0x04002E61 RID: 11873
	private string XboxToken = "";

	// Token: 0x04002E62 RID: 11874
	private readonly Dictionary<string, List<XboxPermissionCheckResultSt>> UserPermissionMap = new Dictionary<string, List<XboxPermissionCheckResultSt>>();

	// Token: 0x04002E63 RID: 11875
	private readonly Dictionary<string, Action<bool>> PermissionCallBackMap = new Dictionary<string, Action<bool>>();

	// Token: 0x04002E64 RID: 11876
	public readonly Action<string> OnAnnounceInitCallBack = delegate(string result)
	{
	};

	// Token: 0x04002E65 RID: 11877
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<string, string> JoinSessionCallback;

	// Token: 0x04002E66 RID: 11878
	[Nullable(2)]
	private XboxPendingJoinSessionInfo PendingJoinSessionInfo;
}
