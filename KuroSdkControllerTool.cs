using System;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using CSharpScript.Core.Common;

// Token: 0x02000ECB RID: 3787
[NullableContext(1)]
[Nullable(0)]
public class KuroSdkControllerTool
{
	// Token: 0x06005D8B RID: 23947 RVA: 0x00177A9C File Offset: 0x00175C9C
	public static string GetCreateRoleInfo()
	{
		RoleInfoSdk createRoleInfoData = KuroSdkControllerTool.GetCreateRoleInfoData();
		JsonSerializerOptions options = new JsonSerializerOptions
		{
			IncludeFields = true,
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
		};
		return JsonSerializer.Serialize<RoleInfoSdk>(createRoleInfoData, options);
	}

	// Token: 0x06005D8C RID: 23948 RVA: 0x00177ACC File Offset: 0x00175CCC
	public static RoleInfoSdk GetCreateRoleInfoData()
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		RoleInfoSdk roleInfoSdk = new RoleInfoSdk();
		roleInfoSdk.RoleId = KuroSdkControllerTool.GetRoleId();
		roleInfoSdk.RoleName = (instance.GetPlayerName() ?? "");
		roleInfoSdk.ServerId = (instance.GetServerId() ?? "");
		roleInfoSdk.ServerName = (instance.GetServerName() ?? "");
		roleInfoSdk.RoleLevel = "1";
		roleInfoSdk.VipLevel = "0";
		roleInfoSdk.PartyName = " ";
		roleInfoSdk.RoleCreateTime = ((instance.GetCreatePlayerTime() != 0.0) ? instance.GetCreatePlayerTime() : "");
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
		return roleInfoSdk;
	}

	// Token: 0x06005D8D RID: 23949 RVA: 0x00177C1C File Offset: 0x00175E1C
	private static string GetRoleId()
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
		ModelBase<LoginModel>.Instance.GetCreatePlayerId();
		return ModelBase<LoginModel>.Instance.GetCreatePlayerId().ToString();
	}

	// Token: 0x06005D8E RID: 23950 RVA: 0x00177C94 File Offset: 0x00175E94
	public static RoleInfoSdk GetRoleInfoData()
	{
		FunctionModel instance = ModelBase<FunctionModel>.Instance;
		LoginModel instance2 = ModelBase<LoginModel>.Instance;
		RoleInfoSdk roleInfoSdk = new RoleInfoSdk();
		roleInfoSdk.RoleId = KuroSdkControllerTool.GetRoleId();
		roleInfoSdk.RoleName = (instance.GetPlayerName() ?? "");
		roleInfoSdk.ServerId = (instance2.GetServerId() ?? "");
		roleInfoSdk.ServerName = (instance2.GetServerName() ?? "");
		int? playerLevel = instance.GetPlayerLevel();
		roleInfoSdk.RoleLevel = ((playerLevel != null && playerLevel.Value != 0) ? playerLevel.Value.ToString() : "1");
		roleInfoSdk.VipLevel = "0";
		roleInfoSdk.PartyName = " ";
		roleInfoSdk.RoleCreateTime = "";
		roleInfoSdk.BalanceLevelOne = instance.GetPlayerCashCoin();
		roleInfoSdk.BalanceLevelTwo = "0";
		roleInfoSdk.SumPay = "0";
		roleInfoSdk.gameName = "AKI";
		roleInfoSdk.gameVersion = "0.0.0";
		roleInfoSdk.RoleAvatar = "";
		SdkLoginConfig sdkLoginConfig = instance2.GetSdkLoginConfig();
		roleInfoSdk.ChannelUserId = ((((sdkLoginConfig != null) ? sdkLoginConfig.Uid : null) != null) ? instance2.GetSdkLoginConfig().Uid.ToString() : "0");
		SdkLoginConfig sdkLoginConfig2 = instance2.GetSdkLoginConfig();
		roleInfoSdk.GameUserId = ((((sdkLoginConfig2 != null) ? sdkLoginConfig2.UserName : null) != null) ? instance2.GetSdkLoginConfig().UserName.ToString() : "0");
		return roleInfoSdk;
	}

	// Token: 0x06005D8F RID: 23951 RVA: 0x00177DF8 File Offset: 0x00175FF8
	public static string GetRoleInfo()
	{
		RoleInfoSdk roleInfoData = KuroSdkControllerTool.GetRoleInfoData();
		JsonSerializerOptions options = new JsonSerializerOptions
		{
			IncludeFields = true,
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
		};
		return JsonSerializer.Serialize<RoleInfoSdk>(roleInfoData, options);
	}

	// Token: 0x06005D90 RID: 23952 RVA: 0x00177E28 File Offset: 0x00176028
	public static string GetPaymentInfo(ISDKPayment payment, ISDKPayRole roleInfo)
	{
		if (Singleton<Info>.Instance.PlatformType != ESourcePlatformType.Mac && Singleton<Info>.Instance.PlatformType != ESourcePlatformType.IOS && !Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			string text = Json.Stringify<SdkPayObject>(new SdkPayObject
			{
				RoleInfo = roleInfo,
				OrderInfo = payment
			}, null);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "SdkJson";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sdkJson", text);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return text ?? "";
		}
		PayInfoMacIos payInfoMacIos = new PayInfoMacIos();
		payInfoMacIos.RoleId = roleInfo.roleId.ToString();
		payInfoMacIos.RoleName = roleInfo.roleName.ToString();
		payInfoMacIos.ServerId = roleInfo.serverId.ToString();
		payInfoMacIos.ServerName = roleInfo.serverName.ToString();
		payInfoMacIos.CpOrder = payment.cpOrderId.ToString();
		payInfoMacIos.CallbackUrl = payment.callbackUrl.ToString();
		payInfoMacIos.GamePropID = payment.product_id.ToString();
		payInfoMacIos.GoodsName = payment.goodsName.ToString();
		payInfoMacIos.GoodsDesc = payment.goodsDesc.ToString();
		payInfoMacIos.Price = payment.price.ToString();
		payInfoMacIos.GoodsCurrency = "";
		if (Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				IncludeFields = true,
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
			};
			return JsonSerializer.Serialize<PayInfoMacIos>(payInfoMacIos, options) ?? "";
		}
		return Json.Stringify<PayInfoMacIos>(payInfoMacIos, null) ?? "";
	}

	// Token: 0x06005D91 RID: 23953 RVA: 0x00177FAC File Offset: 0x001761AC
	public static ISDKPayment GetSdkPayProduct(int payId, string orderId, string name, string desc, string callBackUrl)
	{
		int? num;
		string extraParams = (ModelBase<PlayerInfoModel>.Instance.GetId() != null) ? num.GetValueOrDefault().ToString() : null;
		string payIdAmount = ModelBase<RechargeModel>.Instance.GetPayIdAmount(payId);
		string payIdProductId = ModelBase<RechargeModel>.Instance.GetPayIdProductId(payId);
		return new SDKPayment
		{
			product_id = payIdProductId,
			cpOrderId = orderId,
			price = payIdAmount,
			goodsName = name,
			goodsDesc = desc,
			extraParams = extraParams,
			callbackUrl = callBackUrl,
			currency = ""
		};
	}

	// Token: 0x06005D92 RID: 23954 RVA: 0x00178040 File Offset: 0x00176240
	public static ISDKPayRole GetSdkPayRoleInfo()
	{
		FunctionModel instance = ModelBase<FunctionModel>.Instance;
		LoginModel instance2 = ModelBase<LoginModel>.Instance;
		int? playerLevel = instance.GetPlayerLevel();
		return new SDKPayRole
		{
			roleId = KuroSdkControllerTool.GetRoleId(),
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

	// Token: 0x06005D93 RID: 23955 RVA: 0x00178104 File Offset: 0x00176304
	[return: Nullable(2)]
	public static string GetSdkOpenUrlWndInfo(string title, string url)
	{
		string text = Json.Stringify<OpenSdkUrlWndParam>(new OpenSdkUrlWndParam
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
}
