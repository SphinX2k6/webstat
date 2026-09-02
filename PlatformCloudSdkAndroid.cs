using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;

// Token: 0x02000EFD RID: 3837
[NullableContext(1)]
[Nullable(0)]
public class PlatformCloudSdkAndroid : PlatformCloudSdkBase
{
	// Token: 0x06005EBD RID: 24253 RVA: 0x0017ADAC File Offset: 0x00178FAC
	protected override void BindSpecialEvent()
	{
		Singleton<CloudGameManager>.Instance.BindFunction(ECloudGameReceiveDataKey.OnPostRedDotRefresh, new TCloudGameOnReceiveDataFunction(this.AnnounceRedPointCallBack));
		Singleton<CloudGameManager>.Instance.BindFunction(ECloudGameReceiveDataKey.OnCustomerRedDotRefresh, new TCloudGameOnReceiveDataFunction(this.CustomerServiceResultCallBack));
	}

	// Token: 0x06005EBE RID: 24254 RVA: 0x0017ADE0 File Offset: 0x00178FE0
	public override void AnnounceRedPointCallBack(string result)
	{
		AndroidSdkRePointSt androidSdkRePointSt = Json.Parse<AndroidSdkRePointSt>(result, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.BB;
		string message = "公告红点";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("data", androidSdkRePointSt);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(androidSdkRePointSt.showRed);
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
	}

	// Token: 0x06005EBF RID: 24255 RVA: 0x0017AE40 File Offset: 0x00179040
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
		string text = Json.Stringify<OpenCustomerServiceParamAndroid>(openCustomerServiceParamAndroid, null);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.BB;
		string message = "AndroidCustomerService";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("json", text);
		instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<CloudGameManager>.Instance.SendDataByKey(ECloudGameSendData.OpenCustomerService, text ?? "");
	}

	// Token: 0x06005EC0 RID: 24256 RVA: 0x0017AF00 File Offset: 0x00179100
	public unsafe override void SdkPay(ISDKPayment paymentInfo)
	{
		AndroidSdkPayRole sdkPayRoleInfo = this.GetSdkPayRoleInfo();
		string androidPaymentInfo = this.GetAndroidPaymentInfo(paymentInfo, sdkPayRoleInfo);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.BB;
		string message = "AndroidPayment";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("json", androidPaymentInfo);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("paymentInfo", paymentInfo);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		Singleton<CloudGameManager>.Instance.SendDataByKey(ECloudGameSendData.SDKPay, androidPaymentInfo);
	}

	// Token: 0x06005EC1 RID: 24257 RVA: 0x0017AF80 File Offset: 0x00179180
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

	// Token: 0x06005EC2 RID: 24258 RVA: 0x0017B04C File Offset: 0x0017924C
	private string GetAndroidPaymentInfo(ISDKPayment payment, AndroidSdkPayRole roleInfo)
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
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.BB;
		string message = "SdkJson";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sdkJson", text3);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return text3 ?? "";
	}

	// Token: 0x06005EC3 RID: 24259 RVA: 0x0017B17C File Offset: 0x0017937C
	public override void InitializePostWebView()
	{
		string currentSelectServerId = this.GetCurrentSelectServerId();
		string text = Json.Stringify<InitializePostWebViewParam>(new InitializePostWebViewParam
		{
			language = Singleton<LanguageSystem>.Instance.PackageLanguage,
			serverId = currentSelectServerId,
			cdn = new string[]
			{
				Singleton<PublicUtil>.Instance.GetNoticeBaseUrl() + "/gamenotice/" + Singleton<PublicUtil>.Instance.GetGameId()
			}
		}, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.BB;
		string message = "初始化公告";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("json", text);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<CloudGameManager>.Instance.SendDataByKey(ECloudGameSendData.InitPostWebView, text);
	}
}
