using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000F11 RID: 3857
[NullableContext(1)]
[Nullable(0)]
public class PlatformSdkWindows : PlatformSdkBase
{
	// Token: 0x06006020 RID: 24608 RVA: 0x00180DE9 File Offset: 0x0017EFE9
	protected override void OnInit()
	{
		this.CurrentDid = UKuroSDKManager.GetBasicInfo().DeviceId;
		FCrashSightProxy.SetCustomData("SdkDeviceId", this.CurrentDid);
		FCrashSightProxy.SetCustomData("SdkChannelId", this.GetChannelId());
	}

	// Token: 0x06006021 RID: 24609 RVA: 0x00180E1C File Offset: 0x0017F01C
	protected override void BindSpecialEvent()
	{
		UKuroSDKManager.Get().AnnounceInitDelegate.Clear();
		UKuroSDKManager.Get().AnnounceInitDelegate.Add(this.OnAnnounceInitCallBack);
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Clear();
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Add(new Action<string>(this.AnnounceRedPointCallBack));
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Clear();
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Add(new Action<string>(this.CustomerServiceResultCallBack));
		UKuroSDKManager.Get().OnLoginDelegate.Clear();
		UKuroSDKManager.Get().OnLoginDelegate.Add(this.OnLoginCallBack);
	}

	// Token: 0x06006022 RID: 24610 RVA: 0x00180EC8 File Offset: 0x0017F0C8
	public override void OpenWebView(string title, string url, bool isLandscape, bool transparent, bool webAccelerated, string identifier)
	{
		string text = Json.Stringify<OpenWebViewParamWindows>(new OpenWebViewParamWindows
		{
			title = title,
			url = url,
			transparent = transparent,
			webAccelerated = webAccelerated,
			innerbrowser = true,
			identifier = identifier
		}, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "OpenWebView";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sdkJson", text ?? "");
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UKuroSDKManager.OpenWebView(title, url, isLandscape, transparent, webAccelerated, identifier, text ?? "");
	}

	// Token: 0x06006023 RID: 24611 RVA: 0x00180F58 File Offset: 0x0017F158
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

	// Token: 0x06006024 RID: 24612 RVA: 0x00180FB0 File Offset: 0x0017F1B0
	public virtual void AnnounceRedPointCallBack(string result)
	{
		PlatformSdkWindows.WindowsSdkRedPointContentSt windowsSdkRedPointContentSt = Json.Parse<PlatformSdkWindows.WindowsSdkRedPointContentSt>(Json.Parse<PlatformSdkWindows.WindowsSdkRedPointSt>(result, null).data, null);
		ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(windowsSdkRedPointContentSt.showRed);
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
	}

	// Token: 0x06006025 RID: 24613 RVA: 0x00180FF0 File Offset: 0x0017F1F0
	public virtual void CustomerServiceResultCallBack(string result)
	{
		PlatformSdkWindows.WindowsSdkCustomerServiceSt windowsSdkCustomerServiceSt = Json.Parse<PlatformSdkWindows.WindowsSdkCustomerServiceSt>(result, null);
		PlatformSdkWindows.WindowsSdkCustomerServiceContentSt windowsSdkCustomerServiceContentSt = Json.Parse<PlatformSdkWindows.WindowsSdkCustomerServiceContentSt>(windowsSdkCustomerServiceSt.data, null);
		if (windowsSdkCustomerServiceSt != null)
		{
			this.CurrentCustomerShowState = (windowsSdkCustomerServiceContentSt.isreddot > 0);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkCustomerRedPointRefresh);
	}

	// Token: 0x06006026 RID: 24614 RVA: 0x00181034 File Offset: 0x0017F234
	public override void SdkOpenUrlWnd(string title, string url, bool isLandscape, bool transparent, bool webAccelerated = true)
	{
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			if (this.LastOpenTime != 0.0 && Singleton<Time>.Instance.Now - this.LastOpenTime <= 5000.0)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InDisplayCd", Array.Empty<object>());
				return;
			}
			this.LastOpenTime = Singleton<Time>.Instance.Now;
			this.OpenWebView(title, url, isLandscape, transparent, webAccelerated, string.Empty);
		}
	}

	// Token: 0x06006027 RID: 24615 RVA: 0x001810B4 File Offset: 0x0017F2B4
	public override void OpenFeedback()
	{
		IFeedBackData feedBackUrl = Singleton<BaseConfigController>.Instance.GetFeedBackUrl();
		if (feedBackUrl == null)
		{
			return;
		}
		string url = feedBackUrl.url;
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
		string url2 = StringUtils.Format(this.FeedBackSt, new string[]
		{
			url,
			text2,
			instance.GetServerId().ToString(),
			text4,
			text6,
			instance2.GetPlayerName().ToString(),
			ModelBase<FunctionModel>.Instance.PlayerId.ToString(),
			Singleton<LanguageSystem>.Instance.PackageLanguage
		});
		if (!ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			UKismetSystemLibrary.LaunchURL(url2);
			return;
		}
		ControllerBase<KuroSdkController>.Instance.OpenWebView(feedBackUrl.title, url2, true, true, true, "Default");
	}

	// Token: 0x06006028 RID: 24616 RVA: 0x0018120E File Offset: 0x0017F40E
	public override void SdkExit()
	{
		UKuroSDKManager.ShowExitGameDialog();
	}

	// Token: 0x06006029 RID: 24617 RVA: 0x00181218 File Offset: 0x0017F418
	public override void InitializePostWebView()
	{
		List<ILoginServersData> loginServersByClientRegion = ModelBase<LoginServerModel>.Instance.GetLoginServersByClientRegion();
		if (loginServersByClientRegion == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "没有登录服务器信息", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "serverId", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, loginServersByClientRegion[0].id, default(ReadOnlySpan<ValueTuple<string, object>>));
		string text = Json.Stringify<InitializePostWebViewParam>(new InitializePostWebViewParam
		{
			language = Singleton<LanguageSystem>.Instance.PackageLanguage,
			cdn = new string[]
			{
				Singleton<PublicUtil>.Instance.GetNoticeBaseUrl() + "/gamenotice/" + Singleton<PublicUtil>.Instance.GetGameId() + "/"
			},
			serverId = ((loginServersByClientRegion[0].id == null) ? "1013" : loginServersByClientRegion[0].id)
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

	// Token: 0x0600602A RID: 24618 RVA: 0x0018133C File Offset: 0x0017F53C
	public override string GetChannelId()
	{
		return UKuroSDKManager.GetSdkParams("channel_id");
	}

	// Token: 0x0600602B RID: 24619 RVA: 0x00181348 File Offset: 0x0017F548
	public override string GetChannelName()
	{
		return UKuroSDKManager.GetSdkParams("channel_name");
	}

	// Token: 0x0600602C RID: 24620 RVA: 0x00181354 File Offset: 0x0017F554
	public override string GetGameId()
	{
		return UKuroSDKManager.GetSdkParams("project_id");
	}

	// Token: 0x0600602D RID: 24621 RVA: 0x00181360 File Offset: 0x0017F560
	public override string GetDid()
	{
		return UKuroSDKManager.GetSdkParams("did");
	}

	// Token: 0x0600602E RID: 24622 RVA: 0x0018136C File Offset: 0x0017F56C
	public override string GetAccessToken()
	{
		return UKuroSDKManager.GetSdkParams("token");
	}

	// Token: 0x0600602F RID: 24623 RVA: 0x00181378 File Offset: 0x0017F578
	public override SdkAgreementLinkData[] GetAgreement()
	{
		SdkAgreementLinkData[] result = new SdkAgreementLinkData[0];
		string sdkParams = UKuroSDKManager.GetSdkParams("game_init_agreement");
		if (!ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
		{
			result = Json.Parse<SdkAgreementLinkData[]>(sdkParams, null);
		}
		return result;
	}

	// Token: 0x06006030 RID: 24624 RVA: 0x001813AC File Offset: 0x0017F5AC
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

	// Token: 0x06006031 RID: 24625 RVA: 0x001813E0 File Offset: 0x0017F5E0
	private string GetPaymentInfo(ISDKPayment payment, ISDKPayRole roleInfo)
	{
		return Json.Stringify<PayInfoWindows>(new PayInfoWindows
		{
			roleId = roleInfo.roleId.ToString(),
			roleName = roleInfo.roleName.ToString(),
			serverId = roleInfo.serverId.ToString(),
			serverName = roleInfo.serverName.ToString(),
			cpOrderId = payment.cpOrderId.ToString(),
			callbackUrl = payment.callbackUrl.ToString(),
			product_id = payment.product_id.ToString(),
			goodsName = payment.goodsName.ToString(),
			goodsDesc = payment.goodsDesc.ToString(),
			currency = "",
			extraParams = ""
		}, null).Replace("}", ",") + StringUtils.Format("\"price\":{0}", new string[]
		{
			payment.price.ToString()
		}) + "}";
	}

	// Token: 0x06006032 RID: 24626 RVA: 0x001814E4 File Offset: 0x0017F6E4
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

	// Token: 0x06006033 RID: 24627 RVA: 0x00181534 File Offset: 0x0017F734
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

	// Token: 0x06006034 RID: 24628 RVA: 0x0018157C File Offset: 0x0017F77C
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

	// Token: 0x06006035 RID: 24629 RVA: 0x001815C4 File Offset: 0x0017F7C4
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

	// Token: 0x06006036 RID: 24630 RVA: 0x0018160C File Offset: 0x0017F80C
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

	// Token: 0x06006037 RID: 24631 RVA: 0x001816FC File Offset: 0x0017F8FC
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

	// Token: 0x06006038 RID: 24632 RVA: 0x001817FC File Offset: 0x0017F9FC
	public override void SetFont()
	{
		SetFontParamWindows setFontParamWindows = new SetFontParamWindows();
		string currentFontName = ModelBase<KuroSdkModel>.Instance.GetCurrentFontName();
		setFontParamWindows.name = currentFontName;
		string deviceFontAsset = ModelBase<KuroSdkModel>.Instance.GetDeviceFontAsset();
		setFontParamWindows.path = UBlueprintPathsLibrary.RootDir() + "Client/Binaries/Win64/ThirdParty/KrPcSdk_Mainland/" + deviceFontAsset;
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

	// Token: 0x06006039 RID: 24633 RVA: 0x00181890 File Offset: 0x0017FA90
	protected override void OnPaymentCallBack(FPaymentStruct payment, string strResult, Action<bool, string> paymentFunction)
	{
		PlatformSdkWindows.WindowsPaymentSt windowsPaymentSt = Json.Parse<PlatformSdkWindows.WindowsPaymentSt>(strResult, null);
		bool arg = false;
		if (windowsPaymentSt != null && windowsPaymentSt.error == 0)
		{
			arg = true;
			Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "OnPaymentCallBack Windows Success", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		paymentFunction(arg, strResult);
	}

	// Token: 0x04002E1F RID: 11807
	private const int WEBVIEWCD = 5000;

	// Token: 0x04002E20 RID: 11808
	public readonly Action<string> OnAnnounceInitCallBack = delegate(string result)
	{
	};

	// Token: 0x04002E21 RID: 11809
	public readonly Action<string> OnLoginCallBack = delegate(string result)
	{
	};

	// Token: 0x02007335 RID: 29493
	[Nullable(0)]
	private class WindowsSdkRedPointSt
	{
		// Token: 0x04027F03 RID: 163587
		public string data;

		// Token: 0x04027F04 RID: 163588
		public int error;

		// Token: 0x04027F05 RID: 163589
		public string type;
	}

	// Token: 0x02007336 RID: 29494
	[NullableContext(0)]
	private class WindowsSdkRedPointContentSt
	{
		// Token: 0x04027F06 RID: 163590
		public bool showRed;
	}

	// Token: 0x02007337 RID: 29495
	[Nullable(0)]
	private class WindowsSdkCustomerServiceSt
	{
		// Token: 0x04027F07 RID: 163591
		public string data;

		// Token: 0x04027F08 RID: 163592
		public int error;

		// Token: 0x04027F09 RID: 163593
		public string type;
	}

	// Token: 0x02007338 RID: 29496
	[NullableContext(0)]
	private class WindowsSdkCustomerServiceContentSt
	{
		// Token: 0x04027F0A RID: 163594
		public int cuid;

		// Token: 0x04027F0B RID: 163595
		public int isreddot;
	}

	// Token: 0x02007339 RID: 29497
	[Nullable(0)]
	private class WindowsPaymentSt
	{
		// Token: 0x04027F0C RID: 163596
		public string data;

		// Token: 0x04027F0D RID: 163597
		public int error;

		// Token: 0x04027F0E RID: 163598
		public string type;
	}
}
