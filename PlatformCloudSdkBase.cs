using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Launcher.Platform;

// Token: 0x02000EFE RID: 3838
[NullableContext(1)]
[Nullable(0)]
public class PlatformCloudSdkBase : PlatformSdkWindows
{
	// Token: 0x06005EC5 RID: 24261 RVA: 0x0017B220 File Offset: 0x00179420
	public override void BindProtocolListener()
	{
	}

	// Token: 0x06005EC6 RID: 24262 RVA: 0x0017B222 File Offset: 0x00179422
	public override void BindShareResultListener()
	{
		Singleton<CloudGameManager>.Instance.BindFunction(ECloudGameReceiveDataKey.OnShareResult, new TCloudGameOnReceiveDataFunction(this.OnCloudShareResult));
		Singleton<CloudGameManager>.Instance.BindFunction(ECloudGameReceiveDataKey.OnSDKPayResult, new TCloudGameOnReceiveDataFunction(this.OnSdkPayResult));
	}

	// Token: 0x06005EC7 RID: 24263 RVA: 0x0017B252 File Offset: 0x00179452
	public override void KuroSdkBindRedPointFunction(Action<int> callBack)
	{
	}

	// Token: 0x06005EC8 RID: 24264 RVA: 0x0017B254 File Offset: 0x00179454
	public override void KuroSdkExitBindFunction()
	{
	}

	// Token: 0x06005EC9 RID: 24265 RVA: 0x0017B256 File Offset: 0x00179456
	public override void KuroSdkQueryProductBindFunction()
	{
	}

	// Token: 0x06005ECA RID: 24266 RVA: 0x0017B258 File Offset: 0x00179458
	public override void KuroDeepLinkBindFunction()
	{
	}

	// Token: 0x06005ECB RID: 24267 RVA: 0x0017B25A File Offset: 0x0017945A
	public override void KuroGameWinStateBindFunction()
	{
		Singleton<CloudGameManager>.Instance.BindFunction(ECloudGameReceiveDataKey.OnGameWindowStatusChanged, new TCloudGameOnReceiveDataFunction(this.OnGameWindowStatusChanged));
	}

	// Token: 0x06005ECC RID: 24268 RVA: 0x0017B273 File Offset: 0x00179473
	public override void SdkLogout()
	{
	}

	// Token: 0x06005ECD RID: 24269 RVA: 0x0017B278 File Offset: 0x00179478
	public override void SdkLogin()
	{
		if (Singleton<CloudGameManagerLauncher>.Instance.IsPreLaunch)
		{
			Singleton<Log>.Instance.Info(ELogModule.CloudGame, ELogAuthor.TL, "请求下发缓存的SDK登录信息 预启动跳过重复流程", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<CloudGameManager>.Instance.SendData(ECloudGameSendData.RequestLogin);
		Singleton<Log>.Instance.Info(ELogModule.CloudGame, ELogAuthor.BB, "请求下发缓存的SDK登录信息", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06005ECE RID: 24270 RVA: 0x0017B2DC File Offset: 0x001794DC
	public override void SdkCreateRole()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.TL, "云游戏上报创建新角色", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			string createRoleInfo = KuroSdkControllerTool.GetCreateRoleInfo();
			Singleton<CloudGameManager>.Instance.SendDataByKey(ECloudGameSendData.SDKCreateRole, createRoleInfo);
		}
	}

	// Token: 0x06005ECF RID: 24271 RVA: 0x0017B324 File Offset: 0x00179524
	public override void SdkSelectRole()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.TL, "云游戏上报选择新角色", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			string roleInfo = KuroSdkControllerTool.GetRoleInfo();
			Singleton<CloudGameManager>.Instance.SendDataByKey(ECloudGameSendData.SDKSelectRole, roleInfo);
		}
	}

	// Token: 0x06005ED0 RID: 24272 RVA: 0x0017B36C File Offset: 0x0017956C
	public override void SdkLevelUpRole()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.TL, "云游戏上报角色升级", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			string roleInfo = KuroSdkControllerTool.GetRoleInfo();
			Singleton<CloudGameManager>.Instance.SendDataByKey(ECloudGameSendData.SDKLevelUpRole, roleInfo);
		}
	}

	// Token: 0x06005ED1 RID: 24273 RVA: 0x0017B3B4 File Offset: 0x001795B4
	public override void SdkOpenLoginWnd()
	{
		Singleton<CloudGameManager>.Instance.SendData(ECloudGameSendData.RequestLogin);
		Singleton<Log>.Instance.Info(ELogModule.CloudGame, ELogAuthor.BB, "请求重新下发缓存的SDK登录信息", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06005ED2 RID: 24274 RVA: 0x0017B3EB File Offset: 0x001795EB
	public override void OpenUserCenter()
	{
		Singleton<CloudGameManager>.Instance.SendData(ECloudGameSendData.OpenUserCenter);
	}

	// Token: 0x06005ED3 RID: 24275 RVA: 0x0017B3F8 File Offset: 0x001795F8
	public override void ShowAgreement()
	{
		Singleton<CloudGameManager>.Instance.SendData(ECloudGameSendData.OpenAgreement);
	}

	// Token: 0x06005ED4 RID: 24276 RVA: 0x0017B405 File Offset: 0x00179605
	public override void KuroOpenPrivacyClauseWnd()
	{
		Singleton<CloudGameManager>.Instance.SendData(ECloudGameSendData.OpenPrivacyClause);
	}

	// Token: 0x06005ED5 RID: 24277 RVA: 0x0017B414 File Offset: 0x00179614
	public override void OpenPostWebView()
	{
		if (this.LastOpenPostViewTime != 0.0 && Singleton<Time>.Instance.Now - this.LastOpenPostViewTime <= 5000.0)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InDisplayCd", Array.Empty<object>());
			return;
		}
		this.LastOpenPostViewTime = Singleton<Time>.Instance.Now;
		Singleton<Log>.Instance.Info(ELogModule.CloudGame, ELogAuthor.BB, "打开公告", default(ReadOnlySpan<ValueTuple<string, object>>));
		FunctionModel instance = ModelBase<FunctionModel>.Instance;
		PlayerInfoModel instance2 = ModelBase<PlayerInfoModel>.Instance;
		string type = ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk() ? "global" : "cn";
		OpenPostWebViewParam openPostWebViewParam = new OpenPostWebViewParam();
		openPostWebViewParam.playerId = ((instance2.GetId() == null) ? "0" : instance2.GetId().ToString());
		int? playerLevel = instance.GetPlayerLevel();
		openPostWebViewParam.playerLevel = ((playerLevel != null && playerLevel.Value != 0) ? playerLevel.Value.ToString() : "1");
		openPostWebViewParam.language = Singleton<LanguageSystem>.Instance.PackageLanguage;
		openPostWebViewParam.extend = "extend";
		openPostWebViewParam.gameOrientation = "2";
		openPostWebViewParam.type = type;
		string text = Json.Stringify<OpenPostWebViewParam>(openPostWebViewParam, null);
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.BB;
		string message = "云游戏OpenPostWebView";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("data", text);
		instance3.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<CloudGameManager>.Instance.SendDataByKey(ECloudGameSendData.OpenPostWebView, text);
	}

	// Token: 0x06005ED6 RID: 24278 RVA: 0x0017B594 File Offset: 0x00179794
	public override void CustomerServiceResultCallBack(string result)
	{
		PlatformSdkIos.ISdkCustomerService sdkCustomerService = Json.Parse<PlatformSdkIos.ISdkCustomerService>(result, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.BB;
		string message = "当前客服红点数量";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("num", result);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (sdkCustomerService != null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.CloudGame;
			ELogAuthor author2 = ELogAuthor.BB;
			string message2 = "当前客服红点数量";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("num", sdkCustomerService.isredot);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.CurrentCustomerShowState = (sdkCustomerService.isredot > 0);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.SdkCustomerRedPointRefresh);
	}

	// Token: 0x06005ED7 RID: 24279 RVA: 0x0017B62C File Offset: 0x0017982C
	public override void OpenWebView(string title, string url, bool isLandscape, bool transparent, bool webAccelerated, string identifier)
	{
		if (this.LastOpenTime != 0.0 && Singleton<Time>.Instance.Now - this.LastOpenTime <= 5000.0)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InDisplayCd", Array.Empty<object>());
			return;
		}
		this.LastOpenTime = Singleton<Time>.Instance.Now;
		string text = Json.Stringify<OpenWebViewParamCloudGame>(new OpenWebViewParamCloudGame
		{
			title = title,
			url = url,
			transparent = transparent,
			webAccelerated = webAccelerated,
			isLandscape = isLandscape,
			identifier = identifier
		}, null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CloudGame;
		ELogAuthor author = ELogAuthor.BB;
		string message = "OpenWebView";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sdkJson", text ?? "");
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<CloudGameManager>.Instance.SendDataByKey(ECloudGameSendData.OpenWebView, text);
	}

	// Token: 0x06005ED8 RID: 24280 RVA: 0x0017B703 File Offset: 0x00179903
	public override void SdkOpenUrlWnd(string title, string url, bool isLandscape, bool transparent, bool webAccelerated = true)
	{
		this.OpenWebView(title, url, isLandscape, transparent, webAccelerated, string.Empty);
	}

	// Token: 0x06005ED9 RID: 24281 RVA: 0x0017B717 File Offset: 0x00179917
	private void OnCloudShareResult(string resultJson)
	{
		if (Json.Decode<ShareResult>(resultJson, null).ErrorCode == 0)
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShareResult, true);
			return;
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShareResult, false);
	}

	// Token: 0x06005EDA RID: 24282 RVA: 0x0017B74C File Offset: 0x0017994C
	private void OnSdkPayResult(string resultJson)
	{
		CloudSDKPayResult cloudSDKPayResult = Json.Decode<CloudSDKPayResult>(resultJson, null);
		ControllerBase<KuroSdkController>.Instance.OnSdkPayEnd(cloudSDKPayResult.paymentType == 1, "");
		if (cloudSDKPayResult.paymentType == 1)
		{
			SuccessSdkPayEvent successSdkPayEvent = new SuccessSdkPayEvent();
			successSdkPayEvent.s_sdk_pay_order = ModelBase<KuroSdkModel>.Instance.CurrentPayingOrderId;
			ControllerBase<LogReportController>.Instance.LogReport(successSdkPayEvent);
		}
		else
		{
			FailSdkPayEvent failSdkPayEvent = new FailSdkPayEvent();
			failSdkPayEvent.s_sdk_pay_order = ModelBase<KuroSdkModel>.Instance.CurrentPayingOrderId;
			failSdkPayEvent.s_reason = ((cloudSDKPayResult.paymentType == 3) ? "cancel" : "fail");
			ControllerBase<LogReportController>.Instance.LogReport(failSdkPayEvent);
		}
		Singleton<KuroSdkReport>.Instance.OnSdkPay();
	}

	// Token: 0x06005EDB RID: 24283 RVA: 0x0017B7EC File Offset: 0x001799EC
	private void OnGameWindowStatusChanged(string resultJson)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "Cloud KuroGameWinStateBindFunction";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("data", resultJson);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		GameWindowStateData gameWindowStateData = Json.Parse<GameWindowStateData>(resultJson, null);
		bool sdkGetFocusState = false;
		if (gameWindowStateData != null && gameWindowStateData.status == "0")
		{
			sdkGetFocusState = true;
		}
		ModelBase<KuroSdkModel>.Instance.OnSdkFocusChange(sdkGetFocusState);
	}

	// Token: 0x06005EDC RID: 24284 RVA: 0x0017B84C File Offset: 0x00179A4C
	public override void RecoverSdkData()
	{
		Singleton<Log>.Instance.Info(ELogModule.CloudGame, ELogAuthor.BB, "PlatformCloudSdkBase.RecoverSdkData", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<CloudGameManager>.Instance.TryRequestGamePadDevice();
	}

	// Token: 0x04002DE3 RID: 11747
	private const int WEBVIEWCD = 5000;
}
