using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000F0C RID: 3852
[NullableContext(1)]
[Nullable(0)]
public class PlatformSdkIosGlobal : PlatformSdkBase
{
	// Token: 0x06005FCE RID: 24526 RVA: 0x0017F218 File Offset: 0x0017D418
	protected override void OnInit()
	{
		this.CurrentDid = UKuroSDKManager.GetBasicInfo().DeviceId;
		FCrashSightProxy.SetCustomData("SdkDeviceId", this.CurrentDid);
		FCrashSightProxy.SetCustomData("Sdkidfv", this.Getidfv());
		FCrashSightProxy.SetCustomData("SdkJyId", this.GetJyDid());
		FCrashSightProxy.SetCustomData("SdkChannelId", this.GetChannelId());
	}

	// Token: 0x06005FCF RID: 24527 RVA: 0x0017F278 File Offset: 0x0017D478
	protected override void BindSpecialEvent()
	{
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Clear();
		UKuroSDKManager.Get().AnnounceRedPointDelegate.Add(this.AnnounceRedPointCallBack);
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Clear();
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Add(new Action<string>(this.CustomerServiceResultCallBack));
	}

	// Token: 0x06005FD0 RID: 24528 RVA: 0x0017F2D4 File Offset: 0x0017D4D4
	public void CustomerServiceResultCallBack(string result)
	{
		PlatformSdkIosGlobal.ISdkCustomerService sdkCustomerService = Json.Parse<PlatformSdkIosGlobal.ISdkCustomerService>(result, null);
		if (sdkCustomerService != null)
		{
			this.CurrentCustomerShowState = (sdkCustomerService.isredot > 0);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkCustomerRedPointRefresh);
	}

	// Token: 0x06005FD1 RID: 24529 RVA: 0x0017F30C File Offset: 0x0017D50C
	public override void OpenCustomerService(EKuroSdkOpenCustomerServerType fromType)
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		PlayerInfoModel instance2 = ModelBase<PlayerInfoModel>.Instance;
		UKuroSDKManager.OpenCustomerService(Json.Stringify<OpenCustomerServiceParamIos>(new OpenCustomerServiceParamIos
		{
			islogin = ((instance.IsSdkLoggedIn() > false) ? 1 : 0),
			from = fromType,
			RoleId = this.GetCustomServerRoleId(),
			RoleName = instance2.GetAccountName(true),
			ServerId = instance.GetServerId(),
			ServerName = instance.GetServerName(),
			RoleLevel = instance2.GetPlayerLevel().GetValueOrDefault(),
			ExtendsInfo = this.GetCustomServerExtendsInfo()
		}, null));
	}

	// Token: 0x06005FD2 RID: 24530 RVA: 0x0017F39C File Offset: 0x0017D59C
	public override string GetChannelId()
	{
		PlatformSdkIosGlobal.IUserInfo cacheUserInfo = this.GetCacheUserInfo();
		if (cacheUserInfo == null || cacheUserInfo.channelId == null)
		{
			return "";
		}
		if (cacheUserInfo == null)
		{
			return null;
		}
		return cacheUserInfo.channelId;
	}

	// Token: 0x06005FD3 RID: 24531 RVA: 0x0017F3CC File Offset: 0x0017D5CC
	private string Getidfv()
	{
		PlatformSdkIosGlobal.IUserInfo cacheUserInfo = this.GetCacheUserInfo();
		if (cacheUserInfo == null || cacheUserInfo.idfv == null)
		{
			return "";
		}
		if (cacheUserInfo == null)
		{
			return null;
		}
		return cacheUserInfo.idfv;
	}

	// Token: 0x06005FD4 RID: 24532 RVA: 0x0017F3FC File Offset: 0x0017D5FC
	public override string GetJyDid()
	{
		PlatformSdkIosGlobal.IUserInfo cacheUserInfo = this.GetCacheUserInfo();
		if (cacheUserInfo == null || cacheUserInfo.jyDeviceId == null)
		{
			return "";
		}
		if (cacheUserInfo == null)
		{
			return null;
		}
		return cacheUserInfo.jyDeviceId;
	}

	// Token: 0x06005FD5 RID: 24533 RVA: 0x0017F42C File Offset: 0x0017D62C
	private PlatformSdkIosGlobal.IUserInfo GetCacheUserInfo()
	{
		if (this.CacheUserInfo == null)
		{
			string sdkParams = UKuroSDKManager.GetSdkParams("");
			this.CacheUserInfo = Json.Parse<PlatformSdkIosGlobal.UserInfo>(sdkParams, null);
		}
		return this.CacheUserInfo;
	}

	// Token: 0x06005FD6 RID: 24534 RVA: 0x0017F460 File Offset: 0x0017D660
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
		UKuroSDKManager.QueryProductInfo(text);
	}

	// Token: 0x06005FD7 RID: 24535 RVA: 0x0017F4A8 File Offset: 0x0017D6A8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	protected override QueryProductSt[] OnQueryProduct(string str)
	{
		string[] array = str.Split('|', StringSplitOptions.None);
		List<QueryProductSt> list = new List<QueryProductSt>();
		if (array != null && array.Length != 0)
		{
			PlatformSdkIosGlobal.IQueryProduct queryProduct = Json.Parse<PlatformSdkIosGlobal.IQueryProduct>(array[1], null);
			PlatformSdkIosGlobal.QueryProductContent[] array2 = (queryProduct != null) ? queryProduct.products : null;
			if (array2 != null)
			{
				foreach (PlatformSdkIosGlobal.QueryProductContent queryProductContent in array2)
				{
					list.Add(new QueryProductSt
					{
						Currency = queryProductContent.currency,
						GoodId = queryProductContent.goodsId,
						Name = queryProductContent.name,
						Desc = queryProductContent.desc,
						Price = new float?(queryProductContent.price)
					});
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06005FD8 RID: 24536 RVA: 0x0017F568 File Offset: 0x0017D768
	protected override void OnGetSharePlatform(string str)
	{
		PlatformSdkIosGlobal.SharePlatform sharePlatform = Json.Parse<PlatformSdkIosGlobal.SharePlatform>(str, null);
		if (sharePlatform.KROVERSEA_SDK_KEY_RESULT == 0)
		{
			PlatformSdkIosGlobal.SharePlatformContent[] array = Json.Parse<PlatformSdkIosGlobal.SharePlatformContent[]>(sharePlatform.KROVERSEA_SDK_KEY_DATA, null);
			List<SharePlatformSt> shareResult = new List<SharePlatformSt>();
			if (array != null)
			{
				foreach (PlatformSdkIosGlobal.SharePlatformContent sharePlatformContent in array)
				{
					SharePlatformSt sharePlatformSt = new SharePlatformSt();
					sharePlatformSt.IconUrl = sharePlatformContent.iconUrl;
					sharePlatformSt.PlatformId = sharePlatformContent.platform.ToString();
					shareResult.Add(sharePlatformSt);
				}
			}
			this.GetSharePlatformCallBackList.ForEach(delegate(Action<SharePlatformSt[]> value)
			{
				value(shareResult.ToArray());
			});
			this.GetSharePlatformCallBackList = new List<Action<SharePlatformSt[]>>();
		}
		base.OnGetSharePlatform(str);
	}

	// Token: 0x06005FD9 RID: 24537 RVA: 0x0017F624 File Offset: 0x0017D824
	public override void SdkPay(ISDKPayment paymentInfo)
	{
		ISDKPayRole sdkPayRoleInfo = this.GetSdkPayRoleInfo();
		string paymentInfo2 = this.GetPaymentInfo(paymentInfo, sdkPayRoleInfo);
		UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroPay;
		UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, paymentInfo2);
	}

	// Token: 0x06005FDA RID: 24538 RVA: 0x0017F64C File Offset: 0x0017D84C
	private ISDKPayRole GetSdkPayRoleInfo()
	{
		FunctionModel instance = ModelBase<FunctionModel>.Instance;
		LoginModel instance2 = ModelBase<LoginModel>.Instance;
		int? playerLevel = instance.GetPlayerLevel();
		return new SDKPayRole
		{
			roleId = this.GetRoleId(),
			roleName = (instance.GetPlayerName() ?? ""),
			roleLevel = ((playerLevel != null && playerLevel.Value != 0) ? playerLevel.Value.ToString() : "1"),
			serverId = (instance2.GetServerId() ?? ""),
			serverName = (instance2.GetServerName() ?? ""),
			vipLevel = "0",
			partyName = " ",
			setBalanceLevelOne = 0,
			setBalanceLevelTwo = 0
		};
	}

	// Token: 0x06005FDB RID: 24539 RVA: 0x0017F710 File Offset: 0x0017D910
	private string GetPaymentInfo(ISDKPayment payment, ISDKPayRole roleInfo)
	{
		return Json.Stringify<PayInfoMacIosGlobal>(new PayInfoMacIosGlobal
		{
			RoleId = roleInfo.roleId.ToString(),
			RoleName = roleInfo.roleName.ToString(),
			ServerId = roleInfo.serverId.ToString(),
			ServerName = roleInfo.serverName.ToString(),
			CpOrder = payment.cpOrderId.ToString(),
			CallbackUrl = payment.callbackUrl.ToString(),
			GamePropID = payment.product_id.ToString(),
			GoodsName = payment.goodsName.ToString(),
			GoodsDesc = payment.goodsDesc.ToString(),
			Price = payment.price.ToString(),
			GoodsCurrency = "USD",
			ExtraParams = roleInfo.roleId.ToString()
		}, null) ?? "";
	}

	// Token: 0x06005FDC RID: 24540 RVA: 0x0017F7F8 File Offset: 0x0017D9F8
	public override void Share(ShareData shareData, string imagePath)
	{
		string sKuroSDKEventParameter = Json.Stringify<ShareData>(shareData, null);
		UKuroSDKStaticLibrary.Share(imagePath, sKuroSDKEventParameter);
	}

	// Token: 0x06005FDD RID: 24541 RVA: 0x0017F814 File Offset: 0x0017DA14
	public override void ShareTexture(ShareData shareData, string texturePath)
	{
		string sKuroSDKEventParameter = Json.Stringify<ShareData>(shareData, null);
		UKuroSDKStaticLibrary.Share(texturePath, sKuroSDKEventParameter);
	}

	// Token: 0x06005FDE RID: 24542 RVA: 0x0017F830 File Offset: 0x0017DA30
	public override void SetFont()
	{
		string deviceFontAsset = ModelBase<KuroSdkModel>.Instance.GetDeviceFontAsset();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "SetFont";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("fontPath", deviceFontAsset);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UKuroSDKManager.SetFont(deviceFontAsset);
	}

	// Token: 0x06005FDF RID: 24543 RVA: 0x0017F878 File Offset: 0x0017DA78
	protected unsafe override void OnShareResult(int code, string platform, string msg)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "OnShareResult";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("code", code);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("platform", platform);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("msg", msg);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		if (code == 1)
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShareResult, true);
			return;
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShareResult, false);
	}

	// Token: 0x06005FE0 RID: 24544 RVA: 0x0017F91C File Offset: 0x0017DB1C
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

	// Token: 0x06005FE1 RID: 24545 RVA: 0x0017F999 File Offset: 0x0017DB99
	public override void OpenExternalUrl(string url)
	{
		UKuroSDKManager.OpenDefaultWebView(url);
	}

	// Token: 0x06005FE2 RID: 24546 RVA: 0x0017F9A1 File Offset: 0x0017DBA1
	protected override int CurrentPlatformYearReviewTime()
	{
		return 3;
	}

	// Token: 0x06005FE3 RID: 24547 RVA: 0x0017F9A4 File Offset: 0x0017DBA4
	protected unsafe void KuroBindExternalLoginResult()
	{
		UKuroSDKManager.Get().ExternalLoginCallBack.Clear();
		UKuroSDKManager.Get().ExternalLoginCallBack.Add(delegate(bool result, string msg)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "ShowExternalLoginUI";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("result", result);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("msg", msg);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (result)
			{
				this.ExternalLoginState = true;
				base.QueryExternalAchievement();
			}
			this.ExternalLoginState = result;
		});
	}

	// Token: 0x06005FE4 RID: 24548 RVA: 0x0017F9D0 File Offset: 0x0017DBD0
	protected override void BindExternalEvent()
	{
		this.KuroBindExternalLoginResult();
		base.KuroBindExternalAchievementWriteResult();
		base.KuroBindExternalAchievementQueryResult();
	}

	// Token: 0x06005FE5 RID: 24549 RVA: 0x0017F9E4 File Offset: 0x0017DBE4
	public override void UnlockSdkTrophy(string id)
	{
		this.UpdateExternalAchievementProgress(id, 100);
	}

	// Token: 0x06005FE6 RID: 24550 RVA: 0x0017F9F0 File Offset: 0x0017DBF0
	public void UpdateExternalAchievementProgress(string achievementName, int progress)
	{
		if (!this.ExternalLoginState)
		{
			return;
		}
		if ((this.AchievementMap.ContainsKey(achievementName) ? this.AchievementMap[achievementName].Progress : 0) >= 100)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "UpdateExternalAchievementProgress";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("achievementName", achievementName);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		SdkAchievementContentData sdkAchievementContentData = new SdkAchievementContentData();
		sdkAchievementContentData.AchievementId = achievementName;
		sdkAchievementContentData.Progress = progress;
		UKuroSDKManager.WriteExternalAchievements(Json.Stringify<SdkAchievementData>(new SdkAchievementData
		{
			Achievements = new SdkAchievementContentData[]
			{
				sdkAchievementContentData
			}
		}, null) ?? "");
	}

	// Token: 0x04002E0B RID: 11787
	private const int WEBVIEWCD = 5000;

	// Token: 0x04002E0C RID: 11788
	private const int MAXREVIEWTIME = 3;

	// Token: 0x04002E0D RID: 11789
	[Nullable(2)]
	private PlatformSdkIosGlobal.IUserInfo CacheUserInfo;

	// Token: 0x04002E0E RID: 11790
	public readonly Action<string> AnnounceRedPointCallBack = delegate(string result)
	{
		if (result.Contains("showRed") && (result.Contains("1") || result.Contains("YES")))
		{
			ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(true);
			Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
			return;
		}
		ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(false);
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
	};

	// Token: 0x02007322 RID: 29474
	private interface ISharePlatformContent
	{
		// Token: 0x1700A7B3 RID: 42931
		// (get) Token: 0x06046B4A RID: 289610
		// (set) Token: 0x06046B4B RID: 289611
		string iconUrl { get; set; }

		// Token: 0x1700A7B4 RID: 42932
		// (get) Token: 0x06046B4C RID: 289612
		// (set) Token: 0x06046B4D RID: 289613
		string platform { get; set; }
	}

	// Token: 0x02007323 RID: 29475
	[Nullable(0)]
	private class SharePlatformContent : PlatformSdkIosGlobal.ISharePlatformContent
	{
		// Token: 0x1700A7B5 RID: 42933
		// (get) Token: 0x06046B4E RID: 289614 RVA: 0x012C180A File Offset: 0x012BFA0A
		// (set) Token: 0x06046B4F RID: 289615 RVA: 0x012C1812 File Offset: 0x012BFA12
		public string iconUrl { get; set; }

		// Token: 0x1700A7B6 RID: 42934
		// (get) Token: 0x06046B50 RID: 289616 RVA: 0x012C181B File Offset: 0x012BFA1B
		// (set) Token: 0x06046B51 RID: 289617 RVA: 0x012C1823 File Offset: 0x012BFA23
		public string platform { get; set; }
	}

	// Token: 0x02007324 RID: 29476
	private interface ISharePlatform
	{
		// Token: 0x1700A7B7 RID: 42935
		// (get) Token: 0x06046B53 RID: 289619
		// (set) Token: 0x06046B54 RID: 289620
		string KROVERSEA_SDK_KEY_DATA { get; set; }

		// Token: 0x1700A7B8 RID: 42936
		// (get) Token: 0x06046B55 RID: 289621
		// (set) Token: 0x06046B56 RID: 289622
		string KROVERSEA_SDK_KEY_REASON { get; set; }

		// Token: 0x1700A7B9 RID: 42937
		// (get) Token: 0x06046B57 RID: 289623
		// (set) Token: 0x06046B58 RID: 289624
		int KROVERSEA_SDK_KEY_RESULT { get; set; }
	}

	// Token: 0x02007325 RID: 29477
	[Nullable(0)]
	private class SharePlatform : PlatformSdkIosGlobal.ISharePlatform
	{
		// Token: 0x1700A7BA RID: 42938
		// (get) Token: 0x06046B59 RID: 289625 RVA: 0x012C1834 File Offset: 0x012BFA34
		// (set) Token: 0x06046B5A RID: 289626 RVA: 0x012C183C File Offset: 0x012BFA3C
		public string KROVERSEA_SDK_KEY_DATA { get; set; }

		// Token: 0x1700A7BB RID: 42939
		// (get) Token: 0x06046B5B RID: 289627 RVA: 0x012C1845 File Offset: 0x012BFA45
		// (set) Token: 0x06046B5C RID: 289628 RVA: 0x012C184D File Offset: 0x012BFA4D
		public string KROVERSEA_SDK_KEY_REASON { get; set; }

		// Token: 0x1700A7BC RID: 42940
		// (get) Token: 0x06046B5D RID: 289629 RVA: 0x012C1856 File Offset: 0x012BFA56
		// (set) Token: 0x06046B5E RID: 289630 RVA: 0x012C185E File Offset: 0x012BFA5E
		public int KROVERSEA_SDK_KEY_RESULT { get; set; }
	}

	// Token: 0x02007326 RID: 29478
	[NullableContext(0)]
	private class IQueryProduct
	{
		// Token: 0x04027EDE RID: 163550
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public PlatformSdkIosGlobal.QueryProductContent[] products;

		// Token: 0x04027EDF RID: 163551
		public int code;

		// Token: 0x04027EE0 RID: 163552
		[Nullable(1)]
		public string msg;
	}

	// Token: 0x02007327 RID: 29479
	private interface IQueryProductContent
	{
		// Token: 0x1700A7BD RID: 42941
		// (get) Token: 0x06046B61 RID: 289633
		// (set) Token: 0x06046B62 RID: 289634
		string goodsId { get; set; }

		// Token: 0x1700A7BE RID: 42942
		// (get) Token: 0x06046B63 RID: 289635
		// (set) Token: 0x06046B64 RID: 289636
		string name { get; set; }

		// Token: 0x1700A7BF RID: 42943
		// (get) Token: 0x06046B65 RID: 289637
		// (set) Token: 0x06046B66 RID: 289638
		string desc { get; set; }

		// Token: 0x1700A7C0 RID: 42944
		// (get) Token: 0x06046B67 RID: 289639
		// (set) Token: 0x06046B68 RID: 289640
		string currency { get; set; }

		// Token: 0x1700A7C1 RID: 42945
		// (get) Token: 0x06046B69 RID: 289641
		// (set) Token: 0x06046B6A RID: 289642
		float price { get; set; }
	}

	// Token: 0x02007328 RID: 29480
	[Nullable(0)]
	private class QueryProductContent : PlatformSdkIosGlobal.IQueryProductContent
	{
		// Token: 0x1700A7C2 RID: 42946
		// (get) Token: 0x06046B6B RID: 289643 RVA: 0x012C1877 File Offset: 0x012BFA77
		// (set) Token: 0x06046B6C RID: 289644 RVA: 0x012C187F File Offset: 0x012BFA7F
		public string goodsId { get; set; }

		// Token: 0x1700A7C3 RID: 42947
		// (get) Token: 0x06046B6D RID: 289645 RVA: 0x012C1888 File Offset: 0x012BFA88
		// (set) Token: 0x06046B6E RID: 289646 RVA: 0x012C1890 File Offset: 0x012BFA90
		public string name { get; set; }

		// Token: 0x1700A7C4 RID: 42948
		// (get) Token: 0x06046B6F RID: 289647 RVA: 0x012C1899 File Offset: 0x012BFA99
		// (set) Token: 0x06046B70 RID: 289648 RVA: 0x012C18A1 File Offset: 0x012BFAA1
		public string desc { get; set; }

		// Token: 0x1700A7C5 RID: 42949
		// (get) Token: 0x06046B71 RID: 289649 RVA: 0x012C18AA File Offset: 0x012BFAAA
		// (set) Token: 0x06046B72 RID: 289650 RVA: 0x012C18B2 File Offset: 0x012BFAB2
		public string currency { get; set; }

		// Token: 0x1700A7C6 RID: 42950
		// (get) Token: 0x06046B73 RID: 289651 RVA: 0x012C18BB File Offset: 0x012BFABB
		// (set) Token: 0x06046B74 RID: 289652 RVA: 0x012C18C3 File Offset: 0x012BFAC3
		public float price { get; set; }
	}

	// Token: 0x02007329 RID: 29481
	private interface IUserInfo
	{
		// Token: 0x1700A7C7 RID: 42951
		// (get) Token: 0x06046B76 RID: 289654
		// (set) Token: 0x06046B77 RID: 289655
		string token { get; set; }

		// Token: 0x1700A7C8 RID: 42952
		// (get) Token: 0x06046B78 RID: 289656
		// (set) Token: 0x06046B79 RID: 289657
		string userId { get; set; }

		// Token: 0x1700A7C9 RID: 42953
		// (get) Token: 0x06046B7A RID: 289658
		// (set) Token: 0x06046B7B RID: 289659
		string userName { get; set; }

		// Token: 0x1700A7CA RID: 42954
		// (get) Token: 0x06046B7C RID: 289660
		// (set) Token: 0x06046B7D RID: 289661
		string extendParams { get; set; }

		// Token: 0x1700A7CB RID: 42955
		// (get) Token: 0x06046B7E RID: 289662
		// (set) Token: 0x06046B7F RID: 289663
		string channelId { get; set; }

		// Token: 0x1700A7CC RID: 42956
		// (get) Token: 0x06046B80 RID: 289664
		// (set) Token: 0x06046B81 RID: 289665
		string idfv { get; set; }

		// Token: 0x1700A7CD RID: 42957
		// (get) Token: 0x06046B82 RID: 289666
		// (set) Token: 0x06046B83 RID: 289667
		string jyDeviceId { get; set; }
	}

	// Token: 0x0200732A RID: 29482
	[Nullable(0)]
	private class UserInfo : PlatformSdkIosGlobal.IUserInfo
	{
		// Token: 0x1700A7CE RID: 42958
		// (get) Token: 0x06046B84 RID: 289668 RVA: 0x012C18D4 File Offset: 0x012BFAD4
		// (set) Token: 0x06046B85 RID: 289669 RVA: 0x012C18DC File Offset: 0x012BFADC
		public string token { get; set; }

		// Token: 0x1700A7CF RID: 42959
		// (get) Token: 0x06046B86 RID: 289670 RVA: 0x012C18E5 File Offset: 0x012BFAE5
		// (set) Token: 0x06046B87 RID: 289671 RVA: 0x012C18ED File Offset: 0x012BFAED
		public string userId { get; set; }

		// Token: 0x1700A7D0 RID: 42960
		// (get) Token: 0x06046B88 RID: 289672 RVA: 0x012C18F6 File Offset: 0x012BFAF6
		// (set) Token: 0x06046B89 RID: 289673 RVA: 0x012C18FE File Offset: 0x012BFAFE
		public string userName { get; set; }

		// Token: 0x1700A7D1 RID: 42961
		// (get) Token: 0x06046B8A RID: 289674 RVA: 0x012C1907 File Offset: 0x012BFB07
		// (set) Token: 0x06046B8B RID: 289675 RVA: 0x012C190F File Offset: 0x012BFB0F
		public string extendParams { get; set; }

		// Token: 0x1700A7D2 RID: 42962
		// (get) Token: 0x06046B8C RID: 289676 RVA: 0x012C1918 File Offset: 0x012BFB18
		// (set) Token: 0x06046B8D RID: 289677 RVA: 0x012C1920 File Offset: 0x012BFB20
		public string channelId { get; set; }

		// Token: 0x1700A7D3 RID: 42963
		// (get) Token: 0x06046B8E RID: 289678 RVA: 0x012C1929 File Offset: 0x012BFB29
		// (set) Token: 0x06046B8F RID: 289679 RVA: 0x012C1931 File Offset: 0x012BFB31
		public string idfv { get; set; }

		// Token: 0x1700A7D4 RID: 42964
		// (get) Token: 0x06046B90 RID: 289680 RVA: 0x012C193A File Offset: 0x012BFB3A
		// (set) Token: 0x06046B91 RID: 289681 RVA: 0x012C1942 File Offset: 0x012BFB42
		public string jyDeviceId { get; set; }
	}

	// Token: 0x0200732B RID: 29483
	[NullableContext(0)]
	private class ISdkCustomerService
	{
		// Token: 0x04027EED RID: 163565
		[Nullable(1)]
		public string cuid;

		// Token: 0x04027EEE RID: 163566
		public int isredot;
	}
}
