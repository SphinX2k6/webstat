using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;

// Token: 0x02000F04 RID: 3844
[NullableContext(1)]
[Nullable(0)]
public class PlatformCloudSdkWeb : PlatformCloudSdkBase
{
	// Token: 0x06005EF2 RID: 24306 RVA: 0x0017BB0D File Offset: 0x00179D0D
	protected override void BindSpecialEvent()
	{
		Singleton<CloudGameManager>.Instance.BindFunction(ECloudGameReceiveDataKey.OnPostRedDotRefresh, new TCloudGameOnReceiveDataFunction(this.AnnounceRedPointCallBack));
		Singleton<CloudGameManager>.Instance.BindFunction(ECloudGameReceiveDataKey.OnCustomerRedDotRefresh, new TCloudGameOnReceiveDataFunction(this.CustomerServiceResultCallBack));
	}

	// Token: 0x06005EF3 RID: 24307 RVA: 0x0017BB40 File Offset: 0x00179D40
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

	// Token: 0x06005EF4 RID: 24308 RVA: 0x0017BBAC File Offset: 0x00179DAC
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

	// Token: 0x06005EF5 RID: 24309 RVA: 0x0017BC50 File Offset: 0x00179E50
	public override void SdkPay(ISDKPayment paymentInfo)
	{
		ISDKPayRole sdkPayRoleInfo = KuroSdkControllerTool.GetSdkPayRoleInfo();
		string paymentInfo2 = KuroSdkControllerTool.GetPaymentInfo(paymentInfo, sdkPayRoleInfo);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.BB;
		string message = "WebPayment";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("json", paymentInfo2);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<CloudGameManager>.Instance.SendDataByKey(ECloudGameSendData.SDKPay, paymentInfo2);
	}

	// Token: 0x06005EF6 RID: 24310 RVA: 0x0017BCA4 File Offset: 0x00179EA4
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
