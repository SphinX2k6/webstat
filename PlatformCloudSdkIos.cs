using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;

// Token: 0x02000F03 RID: 3843
[NullableContext(1)]
[Nullable(0)]
public class PlatformCloudSdkIos : PlatformCloudSdkBase
{
	// Token: 0x06005EEC RID: 24300 RVA: 0x0017B8CD File Offset: 0x00179ACD
	protected override void BindSpecialEvent()
	{
		Singleton<CloudGameManager>.Instance.BindFunction(ECloudGameReceiveDataKey.OnPostRedDotRefresh, new TCloudGameOnReceiveDataFunction(this.AnnounceRedPointCallBack));
		Singleton<CloudGameManager>.Instance.BindFunction(ECloudGameReceiveDataKey.OnCustomerRedDotRefresh, new TCloudGameOnReceiveDataFunction(this.CustomerServiceResultCallBack));
	}

	// Token: 0x06005EED RID: 24301 RVA: 0x0017B900 File Offset: 0x00179B00
	public override void AnnounceRedPointCallBack(string result)
	{
		if (result.Contains("showRed") && (result.Contains("1") || result.Contains("YES")))
		{
			ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(true);
			Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
			return;
		}
		ControllerBase<KuroSdkController>.Instance.SetPostWebViewRedPointState(false);
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
	}

	// Token: 0x06005EEE RID: 24302 RVA: 0x0017B96C File Offset: 0x00179B6C
	public override void OpenCustomerService(EKuroSdkOpenCustomerServerType fromType)
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		PlayerInfoModel instance2 = ModelBase<PlayerInfoModel>.Instance;
		string text = Json.Stringify<OpenCustomerServiceParamIos>(new OpenCustomerServiceParamIos
		{
			islogin = ((instance.IsSdkLoggedIn() > false) ? 1 : 0),
			from = fromType,
			RoleId = this.GetCustomServerRoleId(),
			RoleName = instance2.GetAccountName(true),
			ServerId = instance.GetServerId(),
			ServerName = instance.GetServerName(),
			RoleLevel = instance2.GetPlayerLevel().GetValueOrDefault(),
			ExtendsInfo = this.GetCustomServerExtendsInfo()
		}, null);
		Singleton<CloudGameManager>.Instance.SendDataByKey(ECloudGameSendData.OpenCustomerService, text ?? "");
	}

	// Token: 0x06005EEF RID: 24303 RVA: 0x0017BA10 File Offset: 0x00179C10
	public override void SdkPay(ISDKPayment paymentInfo)
	{
		ISDKPayRole sdkPayRoleInfo = KuroSdkControllerTool.GetSdkPayRoleInfo();
		string paymentInfo2 = KuroSdkControllerTool.GetPaymentInfo(paymentInfo, sdkPayRoleInfo);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.BB;
		string message = "IOSPayment";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("json", paymentInfo2);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<CloudGameManager>.Instance.SendDataByKey(ECloudGameSendData.SDKPay, paymentInfo2);
	}

	// Token: 0x06005EF0 RID: 24304 RVA: 0x0017BA64 File Offset: 0x00179C64
	public override void InitializePostWebView()
	{
		string currentSelectServerId = this.GetCurrentSelectServerId();
		string text = Json.Stringify<InitializePostWebViewParam>(new InitializePostWebViewParam
		{
			language = Singleton<LanguageSystem>.Instance.PackageLanguage,
			serverId = currentSelectServerId,
			cdn = new string[]
			{
				Singleton<PublicUtil>.Instance.GetNoticeBaseUrl() + "/gamenotice/" + Singleton<PublicUtil>.Instance.GetGameId() + "/"
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
