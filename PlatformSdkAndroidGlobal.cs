using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000F07 RID: 3847
[NullableContext(1)]
[Nullable(0)]
public class PlatformSdkAndroidGlobal : PlatformSdkBase
{
	// Token: 0x06005F15 RID: 24341 RVA: 0x0017C6BC File Offset: 0x0017A8BC
	protected override void BindSpecialEvent()
	{
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Clear();
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Add(new Action<string>(this.AnnounceRedPointCallBack));
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Clear();
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Add(new Action<string>(this.CustomerServiceResultCallBack));
	}

	// Token: 0x06005F16 RID: 24342 RVA: 0x0017C71D File Offset: 0x0017A91D
	protected override void OnInit()
	{
		UKuroSDKManager.GetBasicInfo().bIsValid = false;
		TimerSystem.Instance.Delay(delegate(float _)
		{
			this.CurrentDid = UKuroSDKManager.GetBasicInfo().DeviceId;
			FCrashSightProxy.SetCustomData("SdkDeviceId", this.CurrentDid);
			FCrashSightProxy.SetCustomData("SdkJyId", this.GetJyDid());
			FCrashSightProxy.SetCustomData("SdkChannelId", this.GetChannelId());
		}, 10000f, null, null, true, 1f);
	}

	// Token: 0x06005F17 RID: 24343 RVA: 0x0017C750 File Offset: 0x0017A950
	public void AnnounceRedPointCallBack(string result)
	{
		PlatformSdkAndroidGlobal.AndroidSdkRePointSt androidSdkRePointSt = Json.Parse<PlatformSdkAndroidGlobal.AndroidSdkRePointSt>(result, null);
		ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(androidSdkRePointSt.showRed);
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
	}

	// Token: 0x06005F18 RID: 24344 RVA: 0x0017C788 File Offset: 0x0017A988
	public void CustomerServiceResultCallBack(string result)
	{
		string[] array = result.Split(',', StringSplitOptions.None);
		if (array != null && array.Length > 1)
		{
			this.CurrentCustomerShowState = (int.Parse(array[1]) > 0);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkCustomerRedPointRefresh);
	}

	// Token: 0x06005F19 RID: 24345 RVA: 0x0017C7CC File Offset: 0x0017A9CC
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

	// Token: 0x06005F1A RID: 24346 RVA: 0x0017C88C File Offset: 0x0017AA8C
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

	// Token: 0x06005F1B RID: 24347 RVA: 0x0017C8D8 File Offset: 0x0017AAD8
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

	// Token: 0x06005F1C RID: 24348 RVA: 0x0017C990 File Offset: 0x0017AB90
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	protected override QueryProductSt[] OnQueryProduct(string str)
	{
		string[] array = str.Split('|', StringSplitOptions.None);
		List<QueryProductSt> list = new List<QueryProductSt>();
		if (array != null && array.Length > 1 && array[0] == "success")
		{
			PlatformSdkAndroidGlobal.IQueryProduct[] array2 = Json.Parse<PlatformSdkAndroidGlobal.IQueryProduct[]>(array[1], null);
			if (array2 != null)
			{
				foreach (PlatformSdkAndroidGlobal.IQueryProduct queryProduct in array2)
				{
					list.Add(new QueryProductSt
					{
						Currency = queryProduct.currency,
						GoodId = queryProduct.goodsId,
						Name = queryProduct.name,
						Desc = queryProduct.desc,
						Price = new float?(queryProduct.price)
					});
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06005F1D RID: 24349 RVA: 0x0017CA58 File Offset: 0x0017AC58
	protected override void OnGetSharePlatform(string str)
	{
		PlatformSdkAndroidGlobal.SharePlatform[] array = Json.Parse<PlatformSdkAndroidGlobal.SharePlatform[]>(Json.Parse<PlatformSdkAndroidGlobal.ISharePlatformSt>(str, null).data, null);
		List<SharePlatformSt> shareResult = new List<SharePlatformSt>();
		if (array != null)
		{
			foreach (PlatformSdkAndroidGlobal.SharePlatform sharePlatform in array)
			{
				SharePlatformSt sharePlatformSt = new SharePlatformSt();
				sharePlatformSt.IconUrl = sharePlatform.iconUrl;
				sharePlatformSt.PlatformId = sharePlatform.platform.ToString();
				shareResult.Add(sharePlatformSt);
			}
		}
		this.GetSharePlatformCallBackList.ForEach(delegate(Action<SharePlatformSt[]> value)
		{
			value(shareResult.ToArray());
		});
		this.GetSharePlatformCallBackList.Clear();
		base.OnGetSharePlatform(str);
	}

	// Token: 0x06005F1E RID: 24350 RVA: 0x0017CB04 File Offset: 0x0017AD04
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

	// Token: 0x06005F1F RID: 24351 RVA: 0x0017CB8A File Offset: 0x0017AD8A
	public override string GetChannelId()
	{
		return this.GetSdkParamData("channelId");
	}

	// Token: 0x06005F20 RID: 24352 RVA: 0x0017CB97 File Offset: 0x0017AD97
	public override string GetChannelName()
	{
		return this.GetSdkParamData("channelName");
	}

	// Token: 0x06005F21 RID: 24353 RVA: 0x0017CBA4 File Offset: 0x0017ADA4
	public override string GetDid()
	{
		return this.GetSdkParamData("did");
	}

	// Token: 0x06005F22 RID: 24354 RVA: 0x0017CBB1 File Offset: 0x0017ADB1
	public override string GetJyDid()
	{
		return this.GetSdkParamData("jyDid");
	}

	// Token: 0x06005F23 RID: 24355 RVA: 0x0017CBBE File Offset: 0x0017ADBE
	public override string GetAccessToken()
	{
		return this.GetSdkParamData("accessToken");
	}

	// Token: 0x06005F24 RID: 24356 RVA: 0x0017CBCC File Offset: 0x0017ADCC
	public override void SetFont()
	{
		SetFontParamAndroid setFontParamAndroid = new SetFontParamAndroid();
		setFontParamAndroid.fontType = "1";
		string deviceFontAsset = ModelBase<KuroSdkModel>.Instance.GetDeviceFontAsset();
		setFontParamAndroid.fontPath = deviceFontAsset;
		UKuroSDKManager.SetFont(Json.Stringify<SetFontParamAndroid>(setFontParamAndroid, null));
	}

	// Token: 0x06005F25 RID: 24357 RVA: 0x0017CC08 File Offset: 0x0017AE08
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

	// Token: 0x06005F26 RID: 24358 RVA: 0x0017CC8C File Offset: 0x0017AE8C
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
		UKuroSDKManager.QueryProductInfo(Json.Stringify<QueryProductInfoParamAndroid>(new QueryProductInfoParamAndroid
		{
			GoodIdList = text,
			ChannelId = channelId
		}, null));
	}

	// Token: 0x06005F27 RID: 24359 RVA: 0x0017CCEC File Offset: 0x0017AEEC
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

	// Token: 0x06005F28 RID: 24360 RVA: 0x0017CD20 File Offset: 0x0017AF20
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

	// Token: 0x06005F29 RID: 24361 RVA: 0x0017CD68 File Offset: 0x0017AF68
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

	// Token: 0x06005F2A RID: 24362 RVA: 0x0017CEB4 File Offset: 0x0017B0B4
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

	// Token: 0x06005F2B RID: 24363 RVA: 0x0017CF90 File Offset: 0x0017B190
	private string GetPaymentInfo(ISDKPayment payment, AndroidSdkPayRole roleInfo)
	{
		string text = Json.Stringify<PayInfoAndroid>(new PayInfoAndroid
		{
			cpOrderId = payment.cpOrderId.ToString(),
			callbackUrl = payment.callbackUrl.ToString(),
			product_id = payment.product_id.ToString(),
			goodsName = payment.goodsName.ToString(),
			goodsDesc = payment.goodsDesc.ToString(),
			currency = "USD",
			extraParams = roleInfo.roleId.ToString()
		}, null);
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

	// Token: 0x06005F2C RID: 24364 RVA: 0x0017D0B0 File Offset: 0x0017B2B0
	public override void Share(ShareData shareData, string imagePath)
	{
		string sKuroSDKEventParameter = Json.Stringify<ShareData>(shareData, null);
		UKuroSDKStaticLibrary.Share(imagePath, sKuroSDKEventParameter);
	}

	// Token: 0x06005F2D RID: 24365 RVA: 0x0017D0CC File Offset: 0x0017B2CC
	public override void ShareTexture(ShareData shareData, string texturePath)
	{
		string sKuroSDKEventParameter = Json.Stringify<ShareData>(shareData, null);
		UKuroSDKStaticLibrary.Share(texturePath, sKuroSDKEventParameter);
	}

	// Token: 0x06005F2E RID: 24366 RVA: 0x0017D0E8 File Offset: 0x0017B2E8
	protected override void OnShareResult(int code, string platform, string msg)
	{
		if (code == 0)
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShareResult, true);
			return;
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShareResult, false);
	}

	// Token: 0x06005F2F RID: 24367 RVA: 0x0017D110 File Offset: 0x0017B310
	protected override int CurrentPlatformYearReviewTime()
	{
		return 1;
	}

	// Token: 0x04002DEB RID: 11755
	private const int WEBVIEWCD = 5000;

	// Token: 0x04002DEC RID: 11756
	private const int GETINFODELAY = 10000;

	// Token: 0x04002DED RID: 11757
	private const int MAXREVIEWTIME = 1;

	// Token: 0x04002DEE RID: 11758
	private readonly Dictionary<string, string> SdkParamCacheMap = new Dictionary<string, string>();

	// Token: 0x02007308 RID: 29448
	[NullableContext(0)]
	private class AndroidSdkRePointSt
	{
		// Token: 0x04027EA8 RID: 163496
		public bool showRed;
	}

	// Token: 0x02007309 RID: 29449
	[Nullable(0)]
	private class IQueryProduct
	{
		// Token: 0x1700A79E RID: 42910
		// (get) Token: 0x06046AFA RID: 289530 RVA: 0x012C1007 File Offset: 0x012BF207
		// (set) Token: 0x06046AFB RID: 289531 RVA: 0x012C100F File Offset: 0x012BF20F
		public string goodsId { get; set; }

		// Token: 0x1700A79F RID: 42911
		// (get) Token: 0x06046AFC RID: 289532 RVA: 0x012C1018 File Offset: 0x012BF218
		// (set) Token: 0x06046AFD RID: 289533 RVA: 0x012C1020 File Offset: 0x012BF220
		public string name { get; set; }

		// Token: 0x1700A7A0 RID: 42912
		// (get) Token: 0x06046AFE RID: 289534 RVA: 0x012C1029 File Offset: 0x012BF229
		// (set) Token: 0x06046AFF RID: 289535 RVA: 0x012C1031 File Offset: 0x012BF231
		public string desc { get; set; }

		// Token: 0x1700A7A1 RID: 42913
		// (get) Token: 0x06046B00 RID: 289536 RVA: 0x012C103A File Offset: 0x012BF23A
		// (set) Token: 0x06046B01 RID: 289537 RVA: 0x012C1042 File Offset: 0x012BF242
		public string currency { get; set; }

		// Token: 0x1700A7A2 RID: 42914
		// (get) Token: 0x06046B02 RID: 289538 RVA: 0x012C104B File Offset: 0x012BF24B
		// (set) Token: 0x06046B03 RID: 289539 RVA: 0x012C1053 File Offset: 0x012BF253
		public float price { get; set; }
	}

	// Token: 0x0200730A RID: 29450
	[NullableContext(0)]
	private class ISharePlatformSt
	{
		// Token: 0x04027EAE RID: 163502
		[Nullable(1)]
		public string data = "";
	}

	// Token: 0x0200730B RID: 29451
	private interface ISharePlatform
	{
		// Token: 0x1700A7A3 RID: 42915
		// (get) Token: 0x06046B06 RID: 289542
		// (set) Token: 0x06046B07 RID: 289543
		int platform { get; set; }

		// Token: 0x1700A7A4 RID: 42916
		// (get) Token: 0x06046B08 RID: 289544
		// (set) Token: 0x06046B09 RID: 289545
		string iconUrl { get; set; }
	}

	// Token: 0x0200730C RID: 29452
	[Nullable(0)]
	private class SharePlatform : PlatformSdkAndroidGlobal.ISharePlatform
	{
		// Token: 0x1700A7A5 RID: 42917
		// (get) Token: 0x06046B0A RID: 289546 RVA: 0x012C1077 File Offset: 0x012BF277
		// (set) Token: 0x06046B0B RID: 289547 RVA: 0x012C107F File Offset: 0x012BF27F
		public int platform { get; set; }

		// Token: 0x1700A7A6 RID: 42918
		// (get) Token: 0x06046B0C RID: 289548 RVA: 0x012C1088 File Offset: 0x012BF288
		// (set) Token: 0x06046B0D RID: 289549 RVA: 0x012C1090 File Offset: 0x012BF290
		public string iconUrl { get; set; }
	}
}
