using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000F19 RID: 3865
[NullableContext(1)]
[Nullable(0)]
public class PlatformSdkWindowsGlobal : PlatformSdkBase
{
	// Token: 0x06006042 RID: 24642 RVA: 0x001819F9 File Offset: 0x0017FBF9
	protected override void OnInit()
	{
		this.CurrentDid = UKuroSDKManager.GetBasicInfo().DeviceId;
		FCrashSightProxy.SetCustomData("SdkDeviceId", this.CurrentDid);
		FCrashSightProxy.SetCustomData("SdkChannelId", this.GetChannelId());
	}

	// Token: 0x06006043 RID: 24643 RVA: 0x00181A2C File Offset: 0x0017FC2C
	protected override void BindSpecialEvent()
	{
		UKuroSDKManager.Get().AnnounceInitDelegate.Clear();
		UKuroSDKManager.Get().AnnounceInitDelegate.Add(this.OnAnnounceInitCallBack);
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Clear();
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Add(this.AnnounceRedPointCallBack);
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Clear();
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Add(new Action<string>(this.CustomerServiceResultCallBack));
		UKuroSDKManager.Get().OnLoginDelegate.Clear();
		UKuroSDKManager.Get().OnLoginDelegate.Add(this.OnLoginCallBack);
	}

	// Token: 0x06006044 RID: 24644 RVA: 0x00181AD0 File Offset: 0x0017FCD0
	public void CustomerServiceResultCallBack(string result)
	{
		WindowsSdkCustomerServiceSt windowsSdkCustomerServiceSt = Json.Parse<WindowsSdkCustomerServiceSt>(result, null);
		WindowsSdkCustomerServiceContentSt windowsSdkCustomerServiceContentSt = Json.Parse<WindowsSdkCustomerServiceContentSt>(windowsSdkCustomerServiceSt.data, null);
		if (windowsSdkCustomerServiceSt != null)
		{
			this.CurrentCustomerShowState = (windowsSdkCustomerServiceContentSt.isreddot > 0);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkCustomerRedPointRefresh);
	}

	// Token: 0x06006045 RID: 24645 RVA: 0x00181B14 File Offset: 0x0017FD14
	public override void OpenWebView(string title, string url, bool isLandscape, bool transparent, bool webAccelerated, string identifier)
	{
		string text = Json.Stringify<OpenWebViewParamWindows>(new OpenWebViewParamWindows
		{
			title = title,
			url = url,
			transparent = transparent,
			titlebar = transparent,
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
		UKuroSDKManager.OpenWebView(title, url, isLandscape, transparent, webAccelerated, identifier, text ?? "");
	}

	// Token: 0x06006046 RID: 24646 RVA: 0x00181BAC File Offset: 0x0017FDAC
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

	// Token: 0x06006047 RID: 24647 RVA: 0x00181C04 File Offset: 0x0017FE04
	public override void SdkExit()
	{
		KuroApplication.ExitWithReason(false, "SdkExit");
	}

	// Token: 0x06006048 RID: 24648 RVA: 0x00181C14 File Offset: 0x0017FE14
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

	// Token: 0x06006049 RID: 24649 RVA: 0x00181CB4 File Offset: 0x0017FEB4
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

	// Token: 0x0600604A RID: 24650 RVA: 0x00181CE8 File Offset: 0x0017FEE8
	private string GetPaymentInfo(ISDKPayment payment, ISDKPayRole roleInfo)
	{
		return Json.Stringify<PayInfoWindowsGlobal>(new PayInfoWindowsGlobal
		{
			roleId = roleInfo.roleId.ToString(),
			roleName = roleInfo.roleName.ToString(),
			serverId = roleInfo.serverId.ToString(),
			serverName = roleInfo.serverName.ToString(),
			cpOrder = payment.cpOrderId.ToString(),
			callbackUrl = payment.callbackUrl.ToString(),
			goodsId = payment.product_id.ToString(),
			productName = payment.goodsName.ToString(),
			goodsDesc = payment.goodsDesc.ToString(),
			currencyType = "USD",
			customMsg = roleInfo.roleId.ToString(),
			price = payment.price.ToString()
		}, null);
	}

	// Token: 0x0600604B RID: 24651 RVA: 0x00181DC8 File Offset: 0x0017FFC8
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

	// Token: 0x0600604C RID: 24652 RVA: 0x00181E18 File Offset: 0x00180018
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

	// Token: 0x0600604D RID: 24653 RVA: 0x00181E60 File Offset: 0x00180060
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

	// Token: 0x0600604E RID: 24654 RVA: 0x00181EA8 File Offset: 0x001800A8
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

	// Token: 0x0600604F RID: 24655 RVA: 0x00181EF0 File Offset: 0x001800F0
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

	// Token: 0x06006050 RID: 24656 RVA: 0x00181FE0 File Offset: 0x001801E0
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

	// Token: 0x06006051 RID: 24657 RVA: 0x001820E0 File Offset: 0x001802E0
	public override void OpenUserCenter()
	{
		UKuroSDKManager.BindAccount();
	}

	// Token: 0x06006052 RID: 24658 RVA: 0x001820E8 File Offset: 0x001802E8
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

	// Token: 0x06006053 RID: 24659 RVA: 0x00182150 File Offset: 0x00180350
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	protected override QueryProductSt[] OnQueryProduct(string str)
	{
		WindowsSdkQueryProductSt windowsSdkQueryProductSt = Json.Parse<WindowsSdkQueryProductSt>(str, null);
		List<QueryProductSt> list = new List<QueryProductSt>();
		if (((windowsSdkQueryProductSt != null) ? windowsSdkQueryProductSt.data : null) != null)
		{
			foreach (WindowsSdkProductContentSt windowsSdkProductContentSt in windowsSdkQueryProductSt.data)
			{
				list.Add(new QueryProductSt
				{
					ChannelGoodId = windowsSdkProductContentSt.channelGoodsId,
					Currency = windowsSdkProductContentSt.currency,
					CurrencyCode = windowsSdkProductContentSt.currencyCode,
					GoodId = windowsSdkProductContentSt.goodsId,
					Name = windowsSdkProductContentSt.name,
					Price = new float?(windowsSdkProductContentSt.price)
				});
			}
		}
		return list.ToArray();
	}

	// Token: 0x06006054 RID: 24660 RVA: 0x00182204 File Offset: 0x00180404
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

	// Token: 0x06006055 RID: 24661 RVA: 0x00182295 File Offset: 0x00180495
	public override string GetChannelId()
	{
		return UKuroSDKManager.GetSdkParams("channel_id");
	}

	// Token: 0x06006056 RID: 24662 RVA: 0x001822A1 File Offset: 0x001804A1
	public override string GetChannelName()
	{
		return UKuroSDKManager.GetSdkParams("channel_name");
	}

	// Token: 0x06006057 RID: 24663 RVA: 0x001822AD File Offset: 0x001804AD
	public override string GetGameId()
	{
		return UKuroSDKManager.GetSdkParams("project_id");
	}

	// Token: 0x06006058 RID: 24664 RVA: 0x001822B9 File Offset: 0x001804B9
	public override string GetDid()
	{
		return UKuroSDKManager.GetSdkParams("did");
	}

	// Token: 0x06006059 RID: 24665 RVA: 0x001822C5 File Offset: 0x001804C5
	public override string GetAccessToken()
	{
		return UKuroSDKManager.GetSdkParams("token");
	}

	// Token: 0x0600605A RID: 24666 RVA: 0x001822D4 File Offset: 0x001804D4
	public override void SdkOpenUrlWnd(string title, string url, bool isLandscape, bool transparent, bool webAccelerated = true)
	{
		if (this.LastOpenTime != 0.0 && Singleton<Time>.Instance.Now - this.LastOpenTime <= 5000.0)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InDisplayCd", Array.Empty<object>());
			return;
		}
		this.LastOpenTime = Singleton<Time>.Instance.Now;
		this.OpenWebView(title, url, isLandscape, transparent, webAccelerated, string.Empty);
	}

	// Token: 0x0600605B RID: 24667 RVA: 0x00182345 File Offset: 0x00180545
	public override bool GetProtocolState()
	{
		return true;
	}

	// Token: 0x0600605C RID: 24668 RVA: 0x00182348 File Offset: 0x00180548
	protected override void OnPaymentCallBack(FPaymentStruct payment, string strResult, Action<bool, string> paymentFunction)
	{
		WindowsPaymentSt windowsPaymentSt = Json.Parse<WindowsPaymentSt>(strResult, null);
		bool arg = false;
		if (windowsPaymentSt != null && windowsPaymentSt.error == 0)
		{
			arg = true;
			Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "OnPaymentCallBack Windows Success", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		paymentFunction(arg, strResult);
	}

	// Token: 0x04002E37 RID: 11831
	private const int WEBVIEWCD = 5000;

	// Token: 0x04002E38 RID: 11832
	public readonly Action<string> OnAnnounceInitCallBack = delegate(string result)
	{
	};

	// Token: 0x04002E39 RID: 11833
	public readonly Action<string> AnnounceRedPointCallBack = delegate(string result)
	{
		WindowsSdkRedPointContentSt windowsSdkRedPointContentSt = Json.Parse<WindowsSdkRedPointContentSt>(Json.Parse<WindowsSdkRedPointSt>(result, null).data, null);
		ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(windowsSdkRedPointContentSt.showRed);
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
	};

	// Token: 0x04002E3A RID: 11834
	public readonly Action<string> OnLoginCallBack = delegate(string result)
	{
	};
}
