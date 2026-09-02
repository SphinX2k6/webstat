using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000F0E RID: 3854
[NullableContext(1)]
[Nullable(0)]
public class PlatformSdkMacGlobal : PlatformSdkBase
{
	// Token: 0x06005FF2 RID: 24562 RVA: 0x0017FDB4 File Offset: 0x0017DFB4
	protected override void OnInit()
	{
		this.CurrentDid = UKuroSDKManager.GetBasicInfo().DeviceId;
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk() && UKuroLauncherLibrary.IsFirstIntoLauncher())
		{
			UKuroSDKManager.PostSplashScreenEndSuccess();
		}
		FCrashSightProxy.SetCustomData("SdkDeviceId", this.CurrentDid);
		FCrashSightProxy.SetCustomData("SdkChannelId", this.GetChannelId());
	}

	// Token: 0x06005FF3 RID: 24563 RVA: 0x0017FE09 File Offset: 0x0017E009
	protected override void BindSpecialEvent()
	{
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Clear();
		UKuroSDKManager.Get().CustomerServiceResultDelegate.Add(new Action<string>(this.CustomerServiceResultCallBack));
	}

	// Token: 0x06005FF4 RID: 24564 RVA: 0x0017FE38 File Offset: 0x0017E038
	public void CustomerServiceResultCallBack(string result)
	{
		PlatformSdkMacGlobal.ISdkCustomerService sdkCustomerService = Json.Parse<PlatformSdkMacGlobal.ISdkCustomerService>(result, null);
		if (sdkCustomerService != null)
		{
			this.CurrentCustomerShowState = (sdkCustomerService.isredot > 0);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkCustomerRedPointRefresh);
	}

	// Token: 0x06005FF5 RID: 24565 RVA: 0x0017FE70 File Offset: 0x0017E070
	public override void OpenCustomerService(EKuroSdkOpenCustomerServerType fromType)
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		PlayerInfoModel instance2 = ModelBase<PlayerInfoModel>.Instance;
		OpenCustomerServiceParamMac openCustomerServiceParamMac = new OpenCustomerServiceParamMac();
		openCustomerServiceParamMac.islogin = ((instance.IsSdkLoggedIn() > false) ? 1 : 0);
		openCustomerServiceParamMac.from = fromType;
		openCustomerServiceParamMac.RoleId = this.GetCustomServerRoleId();
		openCustomerServiceParamMac.RoleName = instance2.GetAccountName(true);
		openCustomerServiceParamMac.ServerId = (instance.GetServerId() ?? "");
		openCustomerServiceParamMac.ServerName = (instance.GetServerName() ?? "");
		int? playerLevel = instance2.GetPlayerLevel();
		openCustomerServiceParamMac.RoleLevel = ((playerLevel != null && playerLevel.Value != 0) ? playerLevel.Value.ToString() : "");
		openCustomerServiceParamMac.ExtendsInfo = this.GetCustomServerExtendsInfo();
		UKuroSDKManager.OpenCustomerService(Json.Stringify<OpenCustomerServiceParamMac>(openCustomerServiceParamMac, null));
	}

	// Token: 0x06005FF6 RID: 24566 RVA: 0x0017FF34 File Offset: 0x0017E134
	public override string GetChannelId()
	{
		PlatformSdkMacGlobal.IUserInfo cacheUserInfo = this.GetCacheUserInfo();
		if (cacheUserInfo != null && cacheUserInfo.channelId != null)
		{
			return cacheUserInfo.channelId;
		}
		return "";
	}

	// Token: 0x06005FF7 RID: 24567 RVA: 0x0017FF60 File Offset: 0x0017E160
	private PlatformSdkMacGlobal.IUserInfo GetCacheUserInfo()
	{
		if (this.CacheUserInfo == null)
		{
			string sdkParams = UKuroSDKManager.GetSdkParams("");
			this.CacheUserInfo = Json.Parse<PlatformSdkMacGlobal.UserInfo>(sdkParams, null);
		}
		return this.CacheUserInfo;
	}

	// Token: 0x06005FF8 RID: 24568 RVA: 0x0017FF94 File Offset: 0x0017E194
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

	// Token: 0x06005FF9 RID: 24569 RVA: 0x0017FFDC File Offset: 0x0017E1DC
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

	// Token: 0x06005FFA RID: 24570 RVA: 0x00180024 File Offset: 0x0017E224
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
			PlatformSdkMacGlobal.IQueryProduct queryProduct = Json.Parse<PlatformSdkMacGlobal.IQueryProduct>(array[1], null);
			if (((queryProduct != null) ? queryProduct.products : null) != null)
			{
				foreach (PlatformSdkMacGlobal.QueryProductContent queryProductContent in queryProduct.products)
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

	// Token: 0x06005FFB RID: 24571 RVA: 0x001800E8 File Offset: 0x0017E2E8
	public override void SdkPay(ISDKPayment paymentInfo)
	{
		ISDKPayRole sdkPayRoleInfo = this.GetSdkPayRoleInfo();
		string paymentInfo2 = this.GetPaymentInfo(paymentInfo, sdkPayRoleInfo);
		UKuroSDKEventType ukuroSDKEventType = UKuroSDKEventType.KuroPay;
		UKuroSDKManager.KuroSDKEvent(ukuroSDKEventType, paymentInfo2);
	}

	// Token: 0x06005FFC RID: 24572 RVA: 0x00180110 File Offset: 0x0017E310
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

	// Token: 0x06005FFD RID: 24573 RVA: 0x001801D4 File Offset: 0x0017E3D4
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

	// Token: 0x06005FFE RID: 24574 RVA: 0x001802BC File Offset: 0x0017E4BC
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

	// Token: 0x06005FFF RID: 24575 RVA: 0x00180339 File Offset: 0x0017E539
	public override void SdkExit()
	{
		UKuroSDKManager.ShowExitGameDialog();
	}

	// Token: 0x04002E10 RID: 11792
	private const int WEBVIEWCD = 5000;

	// Token: 0x04002E11 RID: 11793
	[Nullable(2)]
	private PlatformSdkMacGlobal.IUserInfo CacheUserInfo;

	// Token: 0x0200732F RID: 29487
	private interface IUserInfo
	{
		// Token: 0x1700A7D5 RID: 42965
		// (get) Token: 0x06046B9A RID: 289690
		// (set) Token: 0x06046B9B RID: 289691
		string token { get; set; }

		// Token: 0x1700A7D6 RID: 42966
		// (get) Token: 0x06046B9C RID: 289692
		// (set) Token: 0x06046B9D RID: 289693
		string userId { get; set; }

		// Token: 0x1700A7D7 RID: 42967
		// (get) Token: 0x06046B9E RID: 289694
		// (set) Token: 0x06046B9F RID: 289695
		string userName { get; set; }

		// Token: 0x1700A7D8 RID: 42968
		// (get) Token: 0x06046BA0 RID: 289696
		// (set) Token: 0x06046BA1 RID: 289697
		string extendParams { get; set; }

		// Token: 0x1700A7D9 RID: 42969
		// (get) Token: 0x06046BA2 RID: 289698
		// (set) Token: 0x06046BA3 RID: 289699
		string channelId { get; set; }
	}

	// Token: 0x02007330 RID: 29488
	[Nullable(0)]
	private class UserInfo : PlatformSdkMacGlobal.IUserInfo
	{
		// Token: 0x1700A7DA RID: 42970
		// (get) Token: 0x06046BA4 RID: 289700 RVA: 0x012C1A09 File Offset: 0x012BFC09
		// (set) Token: 0x06046BA5 RID: 289701 RVA: 0x012C1A11 File Offset: 0x012BFC11
		public string token { get; set; } = "";

		// Token: 0x1700A7DB RID: 42971
		// (get) Token: 0x06046BA6 RID: 289702 RVA: 0x012C1A1A File Offset: 0x012BFC1A
		// (set) Token: 0x06046BA7 RID: 289703 RVA: 0x012C1A22 File Offset: 0x012BFC22
		public string userId { get; set; } = "";

		// Token: 0x1700A7DC RID: 42972
		// (get) Token: 0x06046BA8 RID: 289704 RVA: 0x012C1A2B File Offset: 0x012BFC2B
		// (set) Token: 0x06046BA9 RID: 289705 RVA: 0x012C1A33 File Offset: 0x012BFC33
		public string userName { get; set; } = "";

		// Token: 0x1700A7DD RID: 42973
		// (get) Token: 0x06046BAA RID: 289706 RVA: 0x012C1A3C File Offset: 0x012BFC3C
		// (set) Token: 0x06046BAB RID: 289707 RVA: 0x012C1A44 File Offset: 0x012BFC44
		public string extendParams { get; set; } = "";

		// Token: 0x1700A7DE RID: 42974
		// (get) Token: 0x06046BAC RID: 289708 RVA: 0x012C1A4D File Offset: 0x012BFC4D
		// (set) Token: 0x06046BAD RID: 289709 RVA: 0x012C1A55 File Offset: 0x012BFC55
		public string channelId { get; set; } = "";
	}

	// Token: 0x02007331 RID: 29489
	[NullableContext(0)]
	private class IQueryProduct
	{
		// Token: 0x04027EF9 RID: 163577
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public PlatformSdkMacGlobal.QueryProductContent[] products;

		// Token: 0x04027EFA RID: 163578
		public int code;

		// Token: 0x04027EFB RID: 163579
		[Nullable(1)]
		public string msg = "";
	}

	// Token: 0x02007332 RID: 29490
	private interface IQueryProductContent
	{
		// Token: 0x1700A7DF RID: 42975
		// (get) Token: 0x06046BB0 RID: 289712
		// (set) Token: 0x06046BB1 RID: 289713
		string goodsId { get; set; }

		// Token: 0x1700A7E0 RID: 42976
		// (get) Token: 0x06046BB2 RID: 289714
		// (set) Token: 0x06046BB3 RID: 289715
		string name { get; set; }

		// Token: 0x1700A7E1 RID: 42977
		// (get) Token: 0x06046BB4 RID: 289716
		// (set) Token: 0x06046BB5 RID: 289717
		string desc { get; set; }

		// Token: 0x1700A7E2 RID: 42978
		// (get) Token: 0x06046BB6 RID: 289718
		// (set) Token: 0x06046BB7 RID: 289719
		string currency { get; set; }

		// Token: 0x1700A7E3 RID: 42979
		// (get) Token: 0x06046BB8 RID: 289720
		// (set) Token: 0x06046BB9 RID: 289721
		float price { get; set; }
	}

	// Token: 0x02007333 RID: 29491
	[Nullable(0)]
	private class QueryProductContent : PlatformSdkMacGlobal.IQueryProductContent
	{
		// Token: 0x1700A7E4 RID: 42980
		// (get) Token: 0x06046BBA RID: 289722 RVA: 0x012C1AB0 File Offset: 0x012BFCB0
		// (set) Token: 0x06046BBB RID: 289723 RVA: 0x012C1AB8 File Offset: 0x012BFCB8
		public string goodsId { get; set; } = "";

		// Token: 0x1700A7E5 RID: 42981
		// (get) Token: 0x06046BBC RID: 289724 RVA: 0x012C1AC1 File Offset: 0x012BFCC1
		// (set) Token: 0x06046BBD RID: 289725 RVA: 0x012C1AC9 File Offset: 0x012BFCC9
		public string name { get; set; } = "";

		// Token: 0x1700A7E6 RID: 42982
		// (get) Token: 0x06046BBE RID: 289726 RVA: 0x012C1AD2 File Offset: 0x012BFCD2
		// (set) Token: 0x06046BBF RID: 289727 RVA: 0x012C1ADA File Offset: 0x012BFCDA
		public string desc { get; set; } = "";

		// Token: 0x1700A7E7 RID: 42983
		// (get) Token: 0x06046BC0 RID: 289728 RVA: 0x012C1AE3 File Offset: 0x012BFCE3
		// (set) Token: 0x06046BC1 RID: 289729 RVA: 0x012C1AEB File Offset: 0x012BFCEB
		public string currency { get; set; } = "";

		// Token: 0x1700A7E8 RID: 42984
		// (get) Token: 0x06046BC2 RID: 289730 RVA: 0x012C1AF4 File Offset: 0x012BFCF4
		// (set) Token: 0x06046BC3 RID: 289731 RVA: 0x012C1AFC File Offset: 0x012BFCFC
		public float price { get; set; }
	}

	// Token: 0x02007334 RID: 29492
	[NullableContext(0)]
	private class ISdkCustomerService
	{
		// Token: 0x04027F01 RID: 163585
		[Nullable(1)]
		public string cuid = "";

		// Token: 0x04027F02 RID: 163586
		public int isredot;
	}
}
