using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000F10 RID: 3856
[NullableContext(1)]
[Nullable(0)]
public class PlatformSdkOpenHarmony : PlatformSdkBase
{
	// Token: 0x06006002 RID: 24578 RVA: 0x001803CC File Offset: 0x0017E5CC
	protected override void BindSpecialEvent()
	{
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Clear();
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Add(new Action<string>(this.AnnounceRedPointCallBack));
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Clear();
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Add(new Action<string>(this.CustomerServiceResultCallBack));
	}

	// Token: 0x06006003 RID: 24579 RVA: 0x0018042D File Offset: 0x0017E62D
	protected override void OnInit()
	{
		UKuroSDKManager.GetBasicInfo().bIsValid = false;
		TimerSystem.Instance.Delay(delegate(float _)
		{
			this.CurrentDid = UKuroSDKManager.GetBasicInfo().DeviceId;
			FCrashSightProxy.SetCustomData("SdkDeviceId", this.CurrentDid);
			FCrashSightProxy.SetCustomData("SdkOaid", this.GetOaid());
			FCrashSightProxy.SetCustomData("SdkJyId", this.GetJyDid());
			FCrashSightProxy.SetCustomData("SdkChannelId", this.GetChannelId());
		}, 10000f, null, null, true, 1f);
	}

	// Token: 0x06006004 RID: 24580 RVA: 0x00180460 File Offset: 0x0017E660
	public void AnnounceRedPointCallBack(string result)
	{
		AndroidSdkRePointSt androidSdkRePointSt = Json.Parse<AndroidSdkRePointSt>(result, null);
		ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(androidSdkRePointSt.showRed);
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
	}

	// Token: 0x06006005 RID: 24581 RVA: 0x00180498 File Offset: 0x0017E698
	public void CustomerServiceResultCallBack(string result)
	{
		string[] array = result.Split(',', StringSplitOptions.None);
		if (array != null && array.Length > 1)
		{
			this.CurrentCustomerShowState = (int.Parse(array[1]) > 0);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkCustomerRedPointRefresh);
	}

	// Token: 0x06006006 RID: 24582 RVA: 0x001804DC File Offset: 0x0017E6DC
	public override void SdkOpenUrlWnd(string title, string url, bool isLandscape, bool transparent, bool webAccelerated = true)
	{
		if (this.LastOpenTime != 0.0 && Singleton<Time>.Instance.Now - this.LastOpenTime <= 5000.0)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InDisplayCd", Array.Empty<object>());
			return;
		}
		this.LastOpenTime = Singleton<Time>.Instance.Now;
		string data = Json.Stringify<OpenWebViewParamAndroid>(new OpenWebViewParamAndroid
		{
			title = title,
			url = url,
			isLandscape = isLandscape,
			transparent = transparent,
			webAccelerated = webAccelerated,
			identifier = "Default",
			showInDialog = false
		}, null);
		UKuroSDKManager.OpenWebView(title, url, isLandscape, transparent, webAccelerated, "Default", data);
	}

	// Token: 0x06006007 RID: 24583 RVA: 0x00180590 File Offset: 0x0017E790
	public override void OpenFeedback()
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
		this.OpenWebView(feedBackUrl.title, feedBackOpenUrl, true, false, true, "Default");
	}

	// Token: 0x06006008 RID: 24584 RVA: 0x001805DC File Offset: 0x0017E7DC
	public override void OpenWebView(string title, string url, bool isLandscape, bool transparent, bool webAccelerated, string identifier)
	{
		if (this.LastOpenTime != 0.0 && Singleton<Time>.Instance.Now - this.LastOpenTime <= 5000.0)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InDisplayCd", Array.Empty<object>());
			return;
		}
		this.LastOpenTime = Singleton<Time>.Instance.Now;
		string data = Json.Stringify<OpenWebViewParamAndroid>(new OpenWebViewParamAndroid
		{
			title = title,
			url = url,
			isLandscape = isLandscape,
			transparent = transparent,
			webAccelerated = webAccelerated,
			identifier = identifier,
			showInDialog = false
		}, null);
		UKuroSDKManager.OpenWebView(title, url, isLandscape, transparent, webAccelerated, identifier, data);
	}

	// Token: 0x06006009 RID: 24585 RVA: 0x0018068C File Offset: 0x0017E88C
	[NullableContext(2)]
	private OpenHarmonySdkParam GetSdkParamCache()
	{
		if (this.SdkParamCache == null)
		{
			string sdkParams = UKuroSDKManager.GetSdkParams("");
			this.SdkParamCache = Json.Parse<OpenHarmonySdkParam>(sdkParams, null);
			if (this.SdkParamCache == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.KuroSdk;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "GetSdkParamData parse failed";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("data", sdkParams);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		return this.SdkParamCache;
	}

	// Token: 0x0600600A RID: 24586 RVA: 0x001806EE File Offset: 0x0017E8EE
	public override string GetChannelId()
	{
		OpenHarmonySdkParam sdkParamCache = this.GetSdkParamCache();
		return ((sdkParamCache != null) ? sdkParamCache.channelId : null) ?? "";
	}

	// Token: 0x0600600B RID: 24587 RVA: 0x0018070B File Offset: 0x0017E90B
	public override string GetGameId()
	{
		OpenHarmonySdkParam sdkParamCache = this.GetSdkParamCache();
		return ((sdkParamCache != null) ? sdkParamCache.gameId : null) ?? "";
	}

	// Token: 0x0600600C RID: 24588 RVA: 0x00180728 File Offset: 0x0017E928
	public override string GetChannelName()
	{
		OpenHarmonySdkParam sdkParamCache = this.GetSdkParamCache();
		return ((sdkParamCache != null) ? sdkParamCache.channelName : null) ?? "";
	}

	// Token: 0x0600600D RID: 24589 RVA: 0x00180745 File Offset: 0x0017E945
	public override string GetDid()
	{
		OpenHarmonySdkParam sdkParamCache = this.GetSdkParamCache();
		return ((sdkParamCache != null) ? sdkParamCache.did : null) ?? "";
	}

	// Token: 0x0600600E RID: 24590 RVA: 0x00180762 File Offset: 0x0017E962
	public override string GetAppChannelId()
	{
		OpenHarmonySdkParam sdkParamCache = this.GetSdkParamCache();
		return ((sdkParamCache != null) ? sdkParamCache.appChannelId : null) ?? "";
	}

	// Token: 0x0600600F RID: 24591 RVA: 0x0018077F File Offset: 0x0017E97F
	public override string GetOaid()
	{
		OpenHarmonySdkParam sdkParamCache = this.GetSdkParamCache();
		return ((sdkParamCache != null) ? sdkParamCache.oaid : null) ?? "";
	}

	// Token: 0x06006010 RID: 24592 RVA: 0x0018079C File Offset: 0x0017E99C
	public override string GetJyDid()
	{
		OpenHarmonySdkParam sdkParamCache = this.GetSdkParamCache();
		return ((sdkParamCache != null) ? sdkParamCache.jyDid : null) ?? "";
	}

	// Token: 0x06006011 RID: 24593 RVA: 0x001807B9 File Offset: 0x0017E9B9
	public override string GetAccessToken()
	{
		OpenHarmonySdkParam sdkParamCache = this.GetSdkParamCache();
		return ((sdkParamCache != null) ? sdkParamCache.accessToken : null) ?? "";
	}

	// Token: 0x06006012 RID: 24594 RVA: 0x001807D8 File Offset: 0x0017E9D8
	public override void SetFont()
	{
		SetFontParamAndroid setFontParamAndroid = new SetFontParamAndroid();
		setFontParamAndroid.fontType = "1";
		string deviceFontAsset = ModelBase<KuroSdkModel>.Instance.GetDeviceFontAsset();
		setFontParamAndroid.fontPath = deviceFontAsset;
		string text = Json.Stringify<SetFontParamAndroid>(setFontParamAndroid, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "SetFont";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("json", text);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UKuroSDKManager.SetFont(text);
	}

	// Token: 0x06006013 RID: 24595 RVA: 0x0018083C File Offset: 0x0017EA3C
	public override void OpenCustomerService(EKuroSdkOpenCustomerServerType fromType)
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		OpenCustomerServiceParamAndroid openCustomerServiceParamAndroid = new OpenCustomerServiceParamAndroid();
		openCustomerServiceParamAndroid.IsLogin = (instance.IsSdkLoggedIn() ? "1" : "0");
		int num = (int)fromType;
		openCustomerServiceParamAndroid.FromLogin = num.ToString();
		openCustomerServiceParamAndroid.RoleId = this.GetCustomServerRoleId();
		openCustomerServiceParamAndroid.ServerId = (instance.GetServerId() ?? "");
		openCustomerServiceParamAndroid.IsLandscape = "1";
		openCustomerServiceParamAndroid.ExtendsInfo = this.GetCustomServerExtendsInfo();
		UKuroSDKManager.OpenCustomerService(Json.Stringify<OpenCustomerServiceParamAndroid>(openCustomerServiceParamAndroid, null));
	}

	// Token: 0x06006014 RID: 24596 RVA: 0x001808C0 File Offset: 0x0017EAC0
	public override void SdkPay(ISDKPayment paymentInfo)
	{
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			AndroidSdkPayRole sdkPayRoleInfo = this.GetSdkPayRoleInfo();
			string paymentInfo2 = this.GetPaymentInfo(paymentInfo, sdkPayRoleInfo);
			UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroPay;
			UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, paymentInfo2);
		}
	}

	// Token: 0x06006015 RID: 24597 RVA: 0x001808F4 File Offset: 0x0017EAF4
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

	// Token: 0x06006016 RID: 24598 RVA: 0x0018093C File Offset: 0x0017EB3C
	public string GetCreateRoleInfo()
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		RoleInfoSdk roleInfoSdk = new RoleInfoSdk();
		roleInfoSdk.RoleId = this.GetRoleId();
		roleInfoSdk.RoleName = (instance.GetPlayerName() ?? "");
		roleInfoSdk.ServerId = (instance.GetServerId() ?? "");
		roleInfoSdk.ServerName = (instance.GetServerName() ?? "");
		roleInfoSdk.RoleLevel = "1";
		roleInfoSdk.VipLevel = "0";
		roleInfoSdk.PartyName = " ";
		double createPlayerTime = instance.GetCreatePlayerTime();
		roleInfoSdk.RoleCreateTime = ((createPlayerTime != 0.0) ? createPlayerTime.ToString() : "0");
		roleInfoSdk.BalanceLevelOne = "0";
		roleInfoSdk.BalanceLevelTwo = "0";
		roleInfoSdk.SumPay = "0";
		roleInfoSdk.gameName = "AKI";
		roleInfoSdk.gameVersion = "0.0.0";
		roleInfoSdk.RoleAvatar = "";
		SdkLoginConfig sdkLoginConfig = instance.GetSdkLoginConfig();
		roleInfoSdk.ChannelUserId = (((sdkLoginConfig != null) ? sdkLoginConfig.Uid.ToString() : null) ?? "0");
		SdkLoginConfig sdkLoginConfig2 = instance.GetSdkLoginConfig();
		roleInfoSdk.GameUserId = (((sdkLoginConfig2 != null) ? sdkLoginConfig2.UserName.ToString() : null) ?? "0");
		return Json.Stringify<RoleInfoSdk>(roleInfoSdk, null) ?? "";
	}

	// Token: 0x06006017 RID: 24599 RVA: 0x00180A84 File Offset: 0x0017EC84
	private AndroidSdkPayRole GetSdkPayRoleInfo()
	{
		FunctionModel instance = ModelBase<FunctionModel>.Instance;
		LoginModel instance2 = ModelBase<LoginModel>.Instance;
		AndroidSdkPayRole androidSdkPayRole = new AndroidSdkPayRole();
		androidSdkPayRole.roleId = this.GetRoleId();
		androidSdkPayRole.roleName = (instance.GetPlayerName() ?? "");
		int? playerLevel = instance.GetPlayerLevel();
		androidSdkPayRole.roleLevel = ((playerLevel != null && playerLevel.Value != 0) ? playerLevel.Value.ToString() : "1");
		androidSdkPayRole.serverId = (instance2.GetServerId() ?? "");
		androidSdkPayRole.serverName = (instance2.GetServerName() ?? "");
		androidSdkPayRole.vipLevel = "0";
		androidSdkPayRole.partyName = " ";
		androidSdkPayRole.setBalanceLevelOne = "0";
		androidSdkPayRole.setBalanceLevelTwo = "0";
		return androidSdkPayRole;
	}

	// Token: 0x06006018 RID: 24600 RVA: 0x00180B50 File Offset: 0x0017ED50
	private string GetPaymentInfo(ISDKPayment payment, AndroidSdkPayRole roleInfo)
	{
		PayInfoAndroid payInfoAndroid = new PayInfoAndroid();
		payInfoAndroid.cpOrderId = payment.cpOrderId.ToString();
		string callbackUrl = payment.callbackUrl;
		payInfoAndroid.callbackUrl = (((callbackUrl != null) ? callbackUrl.ToString() : null) ?? "");
		payInfoAndroid.product_id = payment.product_id.ToString();
		payInfoAndroid.goodsName = payment.goodsName.ToString();
		payInfoAndroid.goodsDesc = payment.goodsDesc.ToString();
		payInfoAndroid.currency = payment.currency.ToString();
		string extraParams = payment.extraParams;
		payInfoAndroid.extraParams = ((extraParams != null) ? extraParams.ToString() : null);
		string text = Json.Stringify<PayInfoAndroid>(payInfoAndroid, null);
		text = text.Replace("}", ",");
		text += StringUtils.Format("\"price\":{0}", new string[]
		{
			payment.price.ToString()
		});
		text += "}";
		string text2 = Json.Stringify<AndroidSdkPayRole>(roleInfo, null);
		string text3 = StringUtils.Format("{\"RoleInfo\":{0},\"OrderInfo\":{1}}", new string[]
		{
			text2,
			text
		});
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "SdkJson";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sdkJson", text3);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return text3 ?? "";
	}

	// Token: 0x06006019 RID: 24601 RVA: 0x00180C8C File Offset: 0x0017EE8C
	public override void Share(ShareData shareData, string imagePath)
	{
		string sKuroSDKEventParameter = Json.Stringify<ShareData>(shareData, null);
		UKuroSDKStaticLibrary.Share(imagePath, sKuroSDKEventParameter);
	}

	// Token: 0x0600601A RID: 24602 RVA: 0x00180CA8 File Offset: 0x0017EEA8
	public override void ShareTexture(ShareData shareData, string texturePath)
	{
		string sKuroSDKEventParameter = Json.Stringify<ShareData>(shareData, null);
		UKuroSDKStaticLibrary.Share(texturePath, sKuroSDKEventParameter);
	}

	// Token: 0x0600601B RID: 24603 RVA: 0x00180CC4 File Offset: 0x0017EEC4
	protected override void OnPaymentCallBack(FPaymentStruct payment, string strResult, Action<bool, string> paymentFunction)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "OnPaymentCallBack";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("payment", payment);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		paymentFunction(payment.PaymentType == (EPaymentType)0, strResult);
	}

	// Token: 0x0600601C RID: 24604 RVA: 0x00180D08 File Offset: 0x0017EF08
	protected override void OnShareResult(int code, string platform, string msg)
	{
		if (code == 0)
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShareResult, true);
			return;
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShareResult, false);
	}

	// Token: 0x0600601D RID: 24605 RVA: 0x00180D30 File Offset: 0x0017EF30
	protected override string GetCustomServerExtendsInfo()
	{
		return Json.Stringify<List<OpenCustomerServiceExtendsInfoData>>(new List<OpenCustomerServiceExtendsInfoData>
		{
			new OpenCustomerServiceExtendsInfoData
			{
				key = "version",
				label = "version",
				value = Singleton<BaseConfigController>.Instance.GetP4Version()
			}
		}, null) ?? "";
	}

	// Token: 0x04002E1C RID: 11804
	private const int WEBVIEWCD = 5000;

	// Token: 0x04002E1D RID: 11805
	private const int GETINFODELAY = 10000;

	// Token: 0x04002E1E RID: 11806
	[Nullable(2)]
	private OpenHarmonySdkParam SdkParamCache;
}
