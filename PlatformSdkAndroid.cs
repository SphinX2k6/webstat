using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000F06 RID: 3846
[NullableContext(1)]
[Nullable(0)]
public class PlatformSdkAndroid : PlatformSdkBase
{
	// Token: 0x06005EF9 RID: 24313 RVA: 0x0017BD58 File Offset: 0x00179F58
	protected override void BindSpecialEvent()
	{
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Clear();
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Add(new Action<string>(this.AnnounceRedPointCallBack));
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Clear();
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Add(new Action<string>(this.CustomerServiceResultCallBack));
	}

	// Token: 0x06005EFA RID: 24314 RVA: 0x0017BDB9 File Offset: 0x00179FB9
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

	// Token: 0x06005EFB RID: 24315 RVA: 0x0017BDEC File Offset: 0x00179FEC
	public void AnnounceRedPointCallBack(string result)
	{
		AndroidSdkRePointSt androidSdkRePointSt = Json.Parse<AndroidSdkRePointSt>(result, null);
		ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(androidSdkRePointSt.showRed);
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
	}

	// Token: 0x06005EFC RID: 24316 RVA: 0x0017BE24 File Offset: 0x0017A024
	public void CustomerServiceResultCallBack(string result)
	{
		string[] array = result.Split(',', StringSplitOptions.None);
		if (array != null && array.Length > 1)
		{
			this.CurrentCustomerShowState = (int.Parse(array[1]) > 0);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkCustomerRedPointRefresh);
	}

	// Token: 0x06005EFD RID: 24317 RVA: 0x0017BE68 File Offset: 0x0017A068
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
		}, null) ?? "";
		UKuroSDKManager.OpenWebView(title, url, isLandscape, transparent, webAccelerated, "Default", data);
	}

	// Token: 0x06005EFE RID: 24318 RVA: 0x0017BF28 File Offset: 0x0017A128
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

	// Token: 0x06005EFF RID: 24319 RVA: 0x0017BF74 File Offset: 0x0017A174
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
		}, null) ?? "";
		UKuroSDKManager.OpenWebView(title, url, isLandscape, transparent, webAccelerated, identifier, data);
	}

	// Token: 0x06005F00 RID: 24320 RVA: 0x0017C02C File Offset: 0x0017A22C
	private string GetSdkParamData(string needParam)
	{
		if (this.SdkParamCacheMap.Count == 0)
		{
			string[] array = UKuroSDKManager.GetSdkParams("").Split(',', StringSplitOptions.None);
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				string[] array2 = array[i].Split('=', StringSplitOptions.None);
				if (array2.Length == 2)
				{
					this.SdkParamCacheMap[array2[0]] = array2[1];
				}
			}
		}
		string text;
		if (this.SdkParamCacheMap.TryGetValue(needParam, out text) && text != null && !StringUtils.IsEmpty(text))
		{
			return text;
		}
		return "";
	}

	// Token: 0x06005F01 RID: 24321 RVA: 0x0017C0B2 File Offset: 0x0017A2B2
	public override string GetChannelId()
	{
		return this.GetSdkParamData("channelId");
	}

	// Token: 0x06005F02 RID: 24322 RVA: 0x0017C0BF File Offset: 0x0017A2BF
	public override string GetGameId()
	{
		return this.GetSdkParamData("gameId");
	}

	// Token: 0x06005F03 RID: 24323 RVA: 0x0017C0CC File Offset: 0x0017A2CC
	public override string GetChannelName()
	{
		return this.GetSdkParamData("channelName");
	}

	// Token: 0x06005F04 RID: 24324 RVA: 0x0017C0D9 File Offset: 0x0017A2D9
	public override string GetDid()
	{
		return this.GetSdkParamData("did");
	}

	// Token: 0x06005F05 RID: 24325 RVA: 0x0017C0E6 File Offset: 0x0017A2E6
	public override string GetAppChannelId()
	{
		return this.GetSdkParamData("appChannelId");
	}

	// Token: 0x06005F06 RID: 24326 RVA: 0x0017C0F3 File Offset: 0x0017A2F3
	public override string GetOaid()
	{
		return this.GetSdkParamData("oaid");
	}

	// Token: 0x06005F07 RID: 24327 RVA: 0x0017C100 File Offset: 0x0017A300
	public override string GetJyDid()
	{
		return this.GetSdkParamData("jyDid");
	}

	// Token: 0x06005F08 RID: 24328 RVA: 0x0017C10D File Offset: 0x0017A30D
	public override string GetAccessToken()
	{
		return this.GetSdkParamData("accessToken");
	}

	// Token: 0x06005F09 RID: 24329 RVA: 0x0017C11C File Offset: 0x0017A31C
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

	// Token: 0x06005F0A RID: 24330 RVA: 0x0017C180 File Offset: 0x0017A380
	public override void OpenCustomerService(EKuroSdkOpenCustomerServerType fromType)
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		OpenCustomerServiceParamAndroid openCustomerServiceParamAndroid = new OpenCustomerServiceParamAndroid();
		openCustomerServiceParamAndroid.IsLogin = (instance.IsSdkLoggedIn() ? "1" : "0");
		int num = (int)fromType;
		openCustomerServiceParamAndroid.FromLogin = num.ToString();
		openCustomerServiceParamAndroid.RoleId = this.GetCustomServerRoleId();
		openCustomerServiceParamAndroid.ServerId = (instance.GetServerId() ?? "");
		openCustomerServiceParamAndroid.IsLandscape = "0";
		openCustomerServiceParamAndroid.ExtendsInfo = this.GetCustomServerExtendsInfo();
		UKuroSDKManager.OpenCustomerService(Json.Stringify<OpenCustomerServiceParamAndroid>(openCustomerServiceParamAndroid, null));
	}

	// Token: 0x06005F0B RID: 24331 RVA: 0x0017C204 File Offset: 0x0017A404
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

	// Token: 0x06005F0C RID: 24332 RVA: 0x0017C238 File Offset: 0x0017A438
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

	// Token: 0x06005F0D RID: 24333 RVA: 0x0017C280 File Offset: 0x0017A480
	public string GetCreateRoleInfo()
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		RoleInfoSdk roleInfoSdk = new RoleInfoSdk();
		roleInfoSdk.RoleId = this.GetRoleId();
		roleInfoSdk.RoleName = ((instance.GetPlayerName() != null) ? instance.GetPlayerName() : "");
		roleInfoSdk.ServerId = ((instance.GetServerId() != null) ? instance.GetServerId() : "");
		roleInfoSdk.ServerName = ((instance.GetServerName() != null) ? instance.GetServerName() : "");
		roleInfoSdk.RoleLevel = "1";
		roleInfoSdk.VipLevel = "0";
		roleInfoSdk.PartyName = " ";
		roleInfoSdk.RoleCreateTime = instance.GetCreatePlayerTime().ToString();
		roleInfoSdk.BalanceLevelOne = "0";
		roleInfoSdk.BalanceLevelTwo = "0";
		roleInfoSdk.SumPay = "0";
		roleInfoSdk.gameName = "AKI";
		roleInfoSdk.gameVersion = "0.0.0";
		roleInfoSdk.RoleAvatar = "";
		SdkLoginConfig sdkLoginConfig = instance.GetSdkLoginConfig();
		roleInfoSdk.ChannelUserId = ((((sdkLoginConfig != null) ? sdkLoginConfig.Uid : null) != null) ? instance.GetSdkLoginConfig().Uid.ToString() : "0");
		SdkLoginConfig sdkLoginConfig2 = instance.GetSdkLoginConfig();
		roleInfoSdk.GameUserId = ((((sdkLoginConfig2 != null) ? sdkLoginConfig2.UserName : null) != null) ? instance.GetSdkLoginConfig().UserName.ToString() : "0");
		return Json.Stringify<RoleInfoSdk>(roleInfoSdk, null) ?? "";
	}

	// Token: 0x06005F0E RID: 24334 RVA: 0x0017C3E0 File Offset: 0x0017A5E0
	private AndroidSdkPayRole GetSdkPayRoleInfo()
	{
		FunctionModel instance = ModelBase<FunctionModel>.Instance;
		LoginModel instance2 = ModelBase<LoginModel>.Instance;
		AndroidSdkPayRole androidSdkPayRole = new AndroidSdkPayRole();
		androidSdkPayRole.roleId = this.GetRoleId();
		androidSdkPayRole.roleName = ((instance.GetPlayerName() != null) ? instance.GetPlayerName() : "");
		int? playerLevel = instance.GetPlayerLevel();
		androidSdkPayRole.roleLevel = ((playerLevel != null && playerLevel.Value != 0) ? playerLevel.Value.ToString() : "1");
		androidSdkPayRole.serverId = ((instance2.GetServerId() != null) ? instance2.GetServerId() : "");
		androidSdkPayRole.serverName = ((instance2.GetServerName() != null) ? instance2.GetServerName() : "");
		androidSdkPayRole.vipLevel = "0";
		androidSdkPayRole.partyName = " ";
		androidSdkPayRole.setBalanceLevelOne = "0";
		androidSdkPayRole.setBalanceLevelTwo = "0";
		return androidSdkPayRole;
	}

	// Token: 0x06005F0F RID: 24335 RVA: 0x0017C4BC File Offset: 0x0017A6BC
	private string GetPaymentInfo(ISDKPayment payment, AndroidSdkPayRole roleInfo)
	{
		PayInfoAndroid payInfoAndroid = new PayInfoAndroid();
		payInfoAndroid.cpOrderId = payment.cpOrderId.ToString();
		payInfoAndroid.callbackUrl = payment.callbackUrl.ToString();
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

	// Token: 0x06005F10 RID: 24336 RVA: 0x0017C5E8 File Offset: 0x0017A7E8
	public override void Share(ShareData shareData, string imagePath)
	{
		string sKuroSDKEventParameter = Json.Stringify<ShareData>(shareData, null);
		UKuroSDKStaticLibrary.Share(imagePath, sKuroSDKEventParameter);
	}

	// Token: 0x06005F11 RID: 24337 RVA: 0x0017C604 File Offset: 0x0017A804
	public override void ShareTexture(ShareData shareData, string texturePath)
	{
		string sKuroSDKEventParameter = Json.Stringify<ShareData>(shareData, null);
		UKuroSDKStaticLibrary.Share(texturePath, sKuroSDKEventParameter);
	}

	// Token: 0x06005F12 RID: 24338 RVA: 0x0017C620 File Offset: 0x0017A820
	protected override void OnShareResult(int code, string platform, string msg)
	{
		if (code == 0)
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShareResult, true);
			return;
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShareResult, false);
	}

	// Token: 0x04002DE8 RID: 11752
	private const int WEBVIEWCD = 5000;

	// Token: 0x04002DE9 RID: 11753
	private const int GETINFODELAY = 10000;

	// Token: 0x04002DEA RID: 11754
	private readonly Dictionary<string, string> SdkParamCacheMap = new Dictionary<string, string>();
}
