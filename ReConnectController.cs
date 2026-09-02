using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.UI.Module.Loading.View;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher;
using CSharpScript.Launcher.Update;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02002754 RID: 10068
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ReConnectController : UiControllerBase<ReConnectController>
{
	// Token: 0x06013DEE RID: 81390 RVA: 0x00589924 File Offset: 0x00587B24
	protected override bool OnInit()
	{
		Singleton<Heartbeat>.Instance.SetMaxTimeOutHandler(new Action(this.OnHeartbeatTimeout));
		Singleton<Net>.Instance.SetAddRequestMaskHandle(new Action<int>(this.OnRequestMaskAdd));
		Singleton<Net>.Instance.SetRemoveRequestMaskHandle(new Action<int>(this.OnRequestMaskRemove));
		Singleton<Net>.Instance.SetNetworkErrorHandle(new Net.TNetworkErrorHandle(this.OnNetWorkError));
		if (Singleton<Info>.Instance.IsMobilePlatform())
		{
			Singleton<Application>.Instance.AddApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.ApplicationHasReactivated));
		}
		return true;
	}

	// Token: 0x06013DEF RID: 81391 RVA: 0x005899AD File Offset: 0x00587BAD
	protected override bool OnClear()
	{
		if (Singleton<Info>.Instance.IsMobilePlatform())
		{
			Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.ApplicationHasReactivated));
		}
		return true;
	}

	// Token: 0x06013DF0 RID: 81392 RVA: 0x005899D3 File Offset: 0x00587BD3
	private void OnRequestMaskAdd(int rpcId)
	{
		ModelBase<ReConnectModel>.Instance.AddRpc(rpcId);
		this.OpenNetworkMaskView();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.NetWorkMaskRpcAdd, rpcId);
	}

	// Token: 0x06013DF1 RID: 81393 RVA: 0x005899F7 File Offset: 0x00587BF7
	private void OnRequestMaskRemove(int rpcId)
	{
		ModelBase<ReConnectModel>.Instance.DelRpc(rpcId);
		if (ModelBase<ReConnectModel>.Instance.IsRpcEmpty())
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.NetWorkMaskView, null);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.NetWorkMaskRpcRemove, rpcId);
	}

	// Token: 0x06013DF2 RID: 81394 RVA: 0x00589A31 File Offset: 0x00587C31
	protected override void OnAddEvents()
	{
		ReConnectModel instance = ModelBase<ReConnectModel>.Instance;
		instance.LastNetworkType = AppUtil.GetNetworkConnectionType();
		instance.NetworkListener.NetworkChangeDelegate.Add(new Action<byte>(this.OnNetworkTypeChange));
	}

	// Token: 0x06013DF3 RID: 81395 RVA: 0x00589A5E File Offset: 0x00587C5E
	protected override void OnRemoveEvents()
	{
		ModelBase<ReConnectModel>.Instance.NetworkListener.NetworkChangeDelegate.Remove(new Action<byte>(this.OnNetworkTypeChange));
	}

	// Token: 0x06013DF4 RID: 81396 RVA: 0x00589A80 File Offset: 0x00587C80
	public unsafe void Logout(ELogoutReason reason)
	{
		bool flag = ModelBase<ReConnectModel>.Instance.GetReConnectStatus() > EReConnectStatus.NoReConnect;
		if (flag)
		{
			ReconnectProcessReporter.ReportReconnectProcess(EReconnectProcessStep.ReconvCancel, Aki.Protocol.ErrorCode.Success);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Reconnect;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "调用登出";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("原因", reason.ToString());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("是否正在重连", flag);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ModelBase<ReConnectModel>.Instance.AddReConnectIncId();
		this.BackLoginView(EBackLoginViewReason.Logout, false);
	}

	// Token: 0x06013DF5 RID: 81397 RVA: 0x00589B1A File Offset: 0x00587D1A
	public void GmBackToLoginView(EBackLoginViewReason reason, bool reconnectFail)
	{
		this.BackLoginView(reason, reconnectFail);
	}

	// Token: 0x06013DF6 RID: 81398 RVA: 0x00589B24 File Offset: 0x00587D24
	private void OnHeartbeatTimeout()
	{
		if (Singleton<Net>.Instance.IsServerConnected())
		{
			this.TryReConnect(false, "Heartbeat max time out");
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.Reconnect, ELogAuthor.MZJ, "未完成连接，但是触发心跳超时最大次数", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06013DF7 RID: 81399 RVA: 0x00589B68 File Offset: 0x00587D68
	public unsafe void TryReConnect(bool isSilent, string reason)
	{
		if (!this.CanReconnect(reason))
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Reconnect;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "尝试重连";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("调用函数", reason);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("是否静默重连", isSilent);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ReConnectModel instance2 = ModelBase<ReConnectModel>.Instance;
		instance2.SetReconnectDoing();
		Singleton<Heartbeat>.Instance.StopHeartBeat(HeartbeatDefine.EStopHeartbeat.ReconnectStart);
		if (isSilent)
		{
			instance2.StartShowMaskTimer(new Action(this.OpenNetworkMaskView));
		}
		else
		{
			this.OpenNetworkMaskView();
		}
		Singleton<Net>.Instance.Disconnect(Net.EDisconnectReason.Reconnect);
		instance2.ReconvTraceId = UKismetGuidLibrary.NewGuid().ToString();
		this.ReConnectServer(0).ContinueWith(new Action<ReconnectResult>(this.OnReconnectResult)).Forget(new Action<Exception>(this.OnReconnectReject), true);
	}

	// Token: 0x06013DF8 RID: 81400 RVA: 0x00589C58 File Offset: 0x00587E58
	private void OnNetWorkError(int errorCode)
	{
		this.TryReConnect(false, "Net.OnNetworkError");
	}

	// Token: 0x06013DF9 RID: 81401 RVA: 0x00589C68 File Offset: 0x00587E68
	private void OnNetworkTypeChange(byte newType)
	{
		ReConnectModel instance = ModelBase<ReConnectModel>.Instance;
		if ((ENetworkType)newType != instance.LastNetworkType)
		{
			instance.LastNetworkType = (ENetworkType)newType;
			if (newType == 4 || newType == 3)
			{
				this.TryReConnect(true, "OnNetworkTypeChange");
			}
		}
	}

	// Token: 0x06013DFA RID: 81402 RVA: 0x00589CA4 File Offset: 0x00587EA4
	private unsafe void ApplicationHasReactivated()
	{
		long num = DateTimeOffset.Now.ToUnixTimeMilliseconds();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Reconnect;
		ELogAuthor author = ELogAuthor.MZJ;
		string message = "Application Reactivated";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("nowMs", num);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("lastMs", Singleton<Net>.Instance.LastReceiveTimeMs);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if ((float)num - Singleton<Net>.Instance.LastReceiveTimeMs > (float)ModelBase<ReConnectModel>.Instance.ServerChannelCloseTimeMs)
		{
			this.TryReConnect(true, "Application Reactivated and channel closed");
			return;
		}
		Singleton<Heartbeat>.Instance.SendHeartbeatImmediately();
	}

	// Token: 0x06013DFB RID: 81403 RVA: 0x00589D58 File Offset: 0x00587F58
	private bool CanReconnect(string reason)
	{
		if (ModelBase<ReConnectModel>.Instance.GetReConnectStatus() != EReConnectStatus.NoReConnect)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Reconnect;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "正在尝试重连中, 请勿重复!";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("调用函数", reason);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (!Singleton<Net>.Instance.IsServerConnected())
		{
			return false;
		}
		if (!ModelBase<LoginModel>.Instance.HasReconnectInfo())
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Reconnect;
			ELogAuthor author2 = ELogAuthor.ZJC;
			string message2 = "没有重连信息！";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("调用函数", reason);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		if (!ControllerBase<LoginController>.Instance.CheckCanReConnect())
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Reconnect;
			ELogAuthor author3 = ELogAuthor.MZJ;
			string message3 = "当前还在登录界面, 不触发重连";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("调用函数", reason);
			instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return false;
		}
		return true;
	}

	// Token: 0x06013DFC RID: 81404 RVA: 0x00589E14 File Offset: 0x00588014
	private unsafe void BackLoginView(EBackLoginViewReason reason, bool reconnectFail = false)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Reconnect;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "返回登录界面";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("原因", reason);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("是否重连失败触发", reconnectFail);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ModelBase<ReConnectModel>.Instance.CancelShowMaskTimer();
		Singleton<EventSystem>.Instance.Emit(EEventName.BackLoginView);
		Singleton<Net>.Instance.Disconnect(Net.EDisconnectReason.Logout);
		Singleton<Heartbeat>.Instance.StopHeartBeat(HeartbeatDefine.EStopHeartbeat.BackLoginView);
		Action<bool> action = reconnectFail ? new Action<bool>(this.PromptBackToLoginView) : delegate(bool b)
		{
			this.BackToLoginScene();
		};
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.NetWorkMaskView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.NetWorkMaskView, action);
			return;
		}
		action(true);
	}

	// Token: 0x06013DFD RID: 81405 RVA: 0x00589EF4 File Offset: 0x005880F4
	private UniTask BackToLoginScene()
	{
		ReConnectController.<BackToLoginScene>d__18 <BackToLoginScene>d__;
		<BackToLoginScene>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<BackToLoginScene>d__.<>1__state = -1;
		<BackToLoginScene>d__.<>t__builder.Start<ReConnectController.<BackToLoginScene>d__18>(ref <BackToLoginScene>d__);
		return <BackToLoginScene>d__.<>t__builder.Task;
	}

	// Token: 0x06013DFE RID: 81406 RVA: 0x00589F30 File Offset: 0x00588130
	[NullableContext(2)]
	public unsafe BackToGameData CreateBackToGameData(EBackToGameType backToGameType)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Reconnect;
		ELogAuthor author = ELogAuthor.LFJW;
		string message = "[BackToGame] 创建BackToGameData数据(开始)";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EBackToGameType", backToGameType);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (ModelBase<LoginModel>.Instance.GetBackToGameData() != null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Reconnect;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "[BackToGame] 重复创建BackToGameData";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("BackToGameType", backToGameType);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		BackToGameData backToGameData = new BackToGameData();
		backToGameData.BackToGameType = backToGameType;
		backToGameData.LoadingTexturePath = ModelBase<LoadingModel>.Instance.GetLoadingTexturePath();
		backToGameData.Progress = 0.01f;
		backToGameData.LoadingTitle = ConfigMultiTextLang.GetLocalTextNew(ModelBase<LoadingModel>.Instance.GetLoadingTitle(), null);
		backToGameData.LoadingTips = ConfigMultiTextLang.GetLocalTextNew(ModelBase<LoadingModel>.Instance.GetLoadingTips(), null);
		BackToGameLoginData backToGameLoginData = new BackToGameLoginData();
		backToGameLoginData.Uid = ModelBase<LoginModel>.Instance.GetLoginUid();
		backToGameLoginData.UserName = ModelBase<LoginModel>.Instance.GetLoginUserName();
		backToGameLoginData.Token = ModelBase<LoginModel>.Instance.GetLoginToken();
		backToGameLoginData.SelectServerId = ModelBase<LoginServerModel>.Instance.GetCurrentLoginServerId();
		backToGameLoginData.SelectServerIp = ModelBase<LoginServerModel>.Instance.GetCurrentSelectServerIp();
		backToGameData.BackToGameLoginData = backToGameLoginData;
		if (!ModelBase<LoginModel>.Instance.SaveBackToGameData(backToGameData, false))
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Reconnect;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "[BackToGame] 保存BackToGameData到C++失败";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Reason", "CreateBackToGameData");
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return null;
		}
		Log instance4 = Singleton<Log>.Instance;
		ELogModule module4 = ELogModule.Reconnect;
		ELogAuthor author4 = ELogAuthor.LFJW;
		string message4 = "[BackToGame] 创建BackToGameData数据(结束)";
		<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Uid", backToGameLoginData.Uid);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("UserName", backToGameLoginData.UserName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SelectServerId", backToGameLoginData.Token);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("SelectServerId", backToGameLoginData.SelectServerId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("SelectServerIp", backToGameLoginData.SelectServerIp);
		instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
		return backToGameData;
	}

	// Token: 0x06013DFF RID: 81407 RVA: 0x0058A140 File Offset: 0x00588340
	public bool TryBackToGame()
	{
		BackToGameData backToGameData = ModelBase<LoginModel>.Instance.GetBackToGameData();
		if (backToGameData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Reconnect, ELogAuthor.ZJC, "[BackToGame] backToGameData无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Reconnect;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "[BackToGame] 返回登录界面并重新进游戏";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BackToGameType", backToGameData.BackToGameType);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (!GlobalData.GameInstance.IsValid() || !GlobalData.GameInstance.GetWorld().IsValid())
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Reconnect;
			ELogAuthor author2 = ELogAuthor.ZJC;
			string message2 = "[BackToGame] 返回登录界面并重新进游戏失败，因为world无效";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("BackToGameType", backToGameData.BackToGameType);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			ModelBase<LoginModel>.Instance.RemoveBackToGameData();
			return false;
		}
		WBP_UILoading_C wbp_UILoading_C = UUMGManager.CreateWidget(GlobalData.GameInstance.GetWorld(), WBP_UILoading_C.StaticClass()) as WBP_UILoading_C;
		if (wbp_UILoading_C == null || !wbp_UILoading_C.IsValid())
		{
			Singleton<Log>.Instance.Error(ELogModule.Reconnect, ELogAuthor.LFJW, "[BackToGame] 创建WBP_UILoading失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		wbp_UILoading_C.AddToViewport(0);
		if (!wbp_UILoading_C.IsInViewport())
		{
			Singleton<Log>.Instance.Error(ELogModule.Reconnect, ELogAuthor.LFJW, "[BackToGame] WBP_UILoading的IsInViewport为false", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		backToGameData.LoadingWidget = wbp_UILoading_C;
		FSlateFontInfo font = wbp_UILoading_C.Title.Font;
		FName? dynamicFName = FNameUtil.GetDynamicFName(Singleton<LanguageSystem>.Instance.GetLanguageDefineByCode(Singleton<LanguageSystem>.Instance.PackageLanguage).LanguageCode);
		font.TypefaceFontName = dynamicFName.Value;
		wbp_UILoading_C.Tips.Font.TypefaceFontName = dynamicFName.Value;
		wbp_UILoading_C.ProgressText.Font.TypefaceFontName = dynamicFName.Value;
		wbp_UILoading_C.Title.SetText(new FText(backToGameData.LoadingTitle));
		wbp_UILoading_C.Tips.SetText(new FText(backToGameData.LoadingTips));
		wbp_UILoading_C.SetProgress(backToGameData.Progress, wbp_UILoading_C.FirstProgressRatio, true);
		UTexture2D texture = Singleton<ResourceSystem>.Instance.Load<UTexture2D>(backToGameData.LoadingTexturePath, "js_undefined");
		UImage image_Background = wbp_UILoading_C.Image_Background;
		if (image_Background != null)
		{
			image_Background.SetBrushFromTexture(texture, false);
		}
		UKuroStaticLibrary.SynchronizeProperties(wbp_UILoading_C.Title);
		UKuroStaticLibrary.SynchronizeProperties(wbp_UILoading_C.Tips);
		UKuroStaticLibrary.SynchronizeProperties(wbp_UILoading_C.ProgressText);
		if (!ModelBase<LoginModel>.Instance.SaveBackToGameData(backToGameData, true))
		{
			UKuroStaticLibrary.DestroyObject(wbp_UILoading_C);
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Reconnect;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "[BackToGame] 保存BackToGameData到C++失败";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Reason", "TryBackToGame");
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return false;
		}
		Singleton<AudioSystem>.Instance.SetState("reconnect_auto_login", "in_auto_login", true);
		ModelBase<ReConnectModel>.Instance.CancelShowMaskTimer();
		Singleton<EventSystem>.Instance.Emit(EEventName.BackLoginView);
		Singleton<Net>.Instance.Disconnect(Net.EDisconnectReason.Logout);
		Singleton<Heartbeat>.Instance.StopHeartBeat(HeartbeatDefine.EStopHeartbeat.BackLoginAndEnterGame);
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.NetWorkMaskView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.NetWorkMaskView, new Action<bool>(this.<TryBackToGame>g__CallFunction|20_0));
		}
		else
		{
			this.<TryBackToGame>g__CallFunction|20_0(true);
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.FEstimation.Enable 0", null);
		return true;
	}

	// Token: 0x06013E00 RID: 81408 RVA: 0x0058A432 File Offset: 0x00588632
	private void PromptBackToLoginView(bool isOpenSuccess)
	{
		if (Singleton<UiManager>.Instance.IsInited)
		{
			this.ShowBackLoginConfirmBox();
			return;
		}
		ModelBase<ReConnectModel>.Instance.DisconnectedFunction = new Action(this.ShowBackLoginConfirmBox);
	}

	// Token: 0x06013E01 RID: 81409 RVA: 0x0058A460 File Offset: 0x00588660
	private void ShowBackLoginConfirmBox()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(ModelBase<LoginModel>.Instance.HasBackToGameData() ? EConfirmBoxConfigId.BackToLoginAndEnterGame : EConfirmBoxConfigId.BackLoginView);
		confirmBoxDataNew.SetCloseFunction(delegate
		{
			if (ModelBase<LoginModel>.Instance.HasBackToGameData())
			{
				this.TryBackToGame();
				return;
			}
			this.BackToLoginScene();
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
	}

	// Token: 0x06013E02 RID: 81410 RVA: 0x0058A4A6 File Offset: 0x005886A6
	private void OpenNetworkMaskView()
	{
		if (Singleton<UiManager>.Instance.IsInited && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.NetWorkMaskView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.NetWorkMaskView, null, null);
		}
	}

	// Token: 0x06013E03 RID: 81411 RVA: 0x0058A4D8 File Offset: 0x005886D8
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<ReconnectResult> ReConnectServer(int lastReconnectIntervalMs)
	{
		ReConnectController.<ReConnectServer>d__24 <ReConnectServer>d__;
		<ReConnectServer>d__.<>t__builder = AsyncUniTaskMethodBuilder<ReconnectResult>.Create();
		<ReConnectServer>d__.<>4__this = this;
		<ReConnectServer>d__.<>1__state = -1;
		<ReConnectServer>d__.<>t__builder.Start<ReConnectController.<ReConnectServer>d__24>(ref <ReConnectServer>d__);
		return <ReConnectServer>d__.<>t__builder.Task;
	}

	// Token: 0x06013E04 RID: 81412 RVA: 0x0058A51C File Offset: 0x0058871C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<ReconnectResult> ConnectGateway()
	{
		ReConnectController.<ConnectGateway>d__25 <ConnectGateway>d__;
		<ConnectGateway>d__.<>t__builder = AsyncUniTaskMethodBuilder<ReconnectResult>.Create();
		<ConnectGateway>d__.<>1__state = -1;
		<ConnectGateway>d__.<>t__builder.Start<ReConnectController.<ConnectGateway>d__25>(ref <ConnectGateway>d__);
		return <ConnectGateway>d__.<>t__builder.Task;
	}

	// Token: 0x06013E05 RID: 81413 RVA: 0x0058A558 File Offset: 0x00588758
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<ReconnectResult> AskProtoKey()
	{
		ReConnectController.<AskProtoKey>d__26 <AskProtoKey>d__;
		<AskProtoKey>d__.<>t__builder = AsyncUniTaskMethodBuilder<ReconnectResult>.Create();
		<AskProtoKey>d__.<>1__state = -1;
		<AskProtoKey>d__.<>t__builder.Start<ReConnectController.<AskProtoKey>d__26>(ref <AskProtoKey>d__);
		return <AskProtoKey>d__.<>t__builder.Task;
	}

	// Token: 0x06013E06 RID: 81414 RVA: 0x0058A594 File Offset: 0x00588794
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<ReconnectResult> ReconnectRequest()
	{
		ReConnectController.<ReconnectRequest>d__27 <ReconnectRequest>d__;
		<ReconnectRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<ReconnectResult>.Create();
		<ReconnectRequest>d__.<>1__state = -1;
		<ReconnectRequest>d__.<>t__builder.Start<ReConnectController.<ReconnectRequest>d__27>(ref <ReconnectRequest>d__);
		return <ReconnectRequest>d__.<>t__builder.Task;
	}

	// Token: 0x06013E07 RID: 81415 RVA: 0x0058A5D0 File Offset: 0x005887D0
	private void OnReconnectReject(Exception error)
	{
		if (ModelBase<ReConnectModel>.Instance != null)
		{
			ModelBase<ReConnectModel>.Instance.ClearReconnectData();
		}
		Singleton<Log>.Instance.Info(ELogModule.Reconnect, ELogAuthor.ZJC, "由于其他原因, 重连流程中断", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.TryReConnect(false, "ReconnectController.ForceBreakReconnectHandle");
	}

	// Token: 0x06013E08 RID: 81416 RVA: 0x0058A618 File Offset: 0x00588818
	private void OnReconnectResult(ReconnectResult result)
	{
		switch (result.Result)
		{
		case EReconnectResult.Success:
			this.ReconnectSuccess();
			return;
		case EReconnectResult.Fail:
			this.ReconnectFail(result.Step, result.ErrorCode, result.IsPermittedSilentLogin);
			return;
		case EReconnectResult.Cancel:
			Singleton<Log>.Instance.Info(ELogModule.Reconnect, ELogAuthor.ZJC, "由于用户登出, 重连流程不再执行", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		default:
			return;
		}
	}

	// Token: 0x06013E09 RID: 81417 RVA: 0x0058A67C File Offset: 0x0058887C
	private unsafe void ReconnectSuccess()
	{
		ModelBase<ReConnectModel>.Instance.CancelShowMaskTimer();
		if (ModelBase<ReConnectModel>.Instance.IsRpcEmpty() && Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.NetWorkMaskView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.NetWorkMaskView, null);
		}
		ReconnectProcessReporter.ReportReconnectProcess(EReconnectProcessStep.ReconvSuccess, Aki.Protocol.ErrorCode.Success);
		string reconnectToken = ModelBase<LoginModel>.Instance.GetReconnectToken();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Reconnect;
		ELogAuthor author = ELogAuthor.ZJC;
		string message = "重连流程, 重登成功!";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("重连后下行包:", Singleton<Net>.Instance.GetDownStreamSeqNo());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("重连后token", reconnectToken);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ModelBase<ReConnectModel>.Instance.ClearReconnectData();
		Singleton<ThirdPartySdkManager>.Instance.Logout();
		int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
		Singleton<ThirdPartySdkManager>.Instance.SetUserInfoForTpSafe(value.ToString(), value);
		Singleton<EventSystem>.Instance.Emit(EEventName.ReConnectSuccess);
		Singleton<Heartbeat>.Instance.BeginHeartBeat(HeartbeatDefine.EBeginHeartbeat.ReConnectSuccess);
	}

	// Token: 0x06013E0A RID: 81418 RVA: 0x0058A788 File Offset: 0x00588988
	private void ReconnectFail(EReconnectProcessStep step, int? errorCode = null, bool isPermittedSilentLogin = false)
	{
		Singleton<Net>.Instance.Disconnect(Net.EDisconnectReason.Reconnect);
		ModelBase<ReConnectModel>.Instance.ResetReconnectStatus();
		if (step == EReconnectProcessStep.ReconvRet && errorCode != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Reconnect;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "重连流程, 服务器拒绝，尝试重新进游戏";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ErrorCode", errorCode);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ReconnectProcessReporter.ReportReconnectProcess(EReconnectProcessStep.ReconvFail, Aki.Protocol.ErrorCode.Success);
			if (isPermittedSilentLogin)
			{
				this.CreateBackToGameData(EBackToGameType.Normal);
			}
			this.BackLoginView(EBackLoginViewReason.ReconnectError, true);
			return;
		}
		if (!ModelBase<ReConnectModel>.Instance.IsReConnectMaxCount())
		{
			int num = ModelBase<ReConnectModel>.Instance.AddReConnectCount();
			double delayTimeMs = Math.Pow(2.0, (double)num) * 1000.0 + (new Random().NextDouble() * 2000.0 - 1000.0);
			TimerSystem.Instance.Delay(delegate(float _)
			{
				if (!ModelBase<ReConnectModel>.Instance.IsReConnectIdSame())
				{
					return;
				}
				this.ReConnectServer((int)delayTimeMs).ContinueWith(new Action<ReconnectResult>(this.OnReconnectResult)).Forget(new Action<Exception>(this.OnReconnectReject), true);
			}, (float)((int)delayTimeMs), null, null, true, 1f);
			Singleton<Net>.Instance.StartReconnecting();
			return;
		}
		ModelBase<ReConnectModel>.Instance.AddTryCount();
		ModelBase<ReConnectModel>.Instance.ReSetReConnectCount();
		if (ModelBase<ReConnectModel>.Instance.IsTryMaxCount())
		{
			Singleton<Log>.Instance.Info(ELogModule.Reconnect, ELogAuthor.ZJC, "已达最大重连流程次数,不再尝试重连!", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.BackLoginView(EBackLoginViewReason.ReconnectMax, true);
			ReconnectProcessReporter.ReportReconnectProcess(EReconnectProcessStep.ReconvFail, Aki.Protocol.ErrorCode.Success);
			return;
		}
		this.ReConnectServer(0).ContinueWith(new Action<ReconnectResult>(this.OnReconnectResult)).Forget(new Action<Exception>(this.OnReconnectReject), true);
		Singleton<EventSystem>.Instance.Emit(EEventName.ReConnectFail);
	}

	// Token: 0x06013E0D RID: 81421 RVA: 0x0058A928 File Offset: 0x00588B28
	[CompilerGenerated]
	internal static UniTask <BackToLoginScene>g__Callback|18_0()
	{
		ReConnectController.<<BackToLoginScene>g__Callback|18_0>d <<BackToLoginScene>g__Callback|18_0>d;
		<<BackToLoginScene>g__Callback|18_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<<BackToLoginScene>g__Callback|18_0>d.<>1__state = -1;
		<<BackToLoginScene>g__Callback|18_0>d.<>t__builder.Start<ReConnectController.<<BackToLoginScene>g__Callback|18_0>d>(ref <<BackToLoginScene>g__Callback|18_0>d);
		return <<BackToLoginScene>g__Callback|18_0>d.<>t__builder.Task;
	}

	// Token: 0x06013E0E RID: 81422 RVA: 0x0058A963 File Offset: 0x00588B63
	[CompilerGenerated]
	private void <TryBackToGame>g__CallFunction|20_0(bool b)
	{
		this.BackToLoginScene();
	}

	// Token: 0x04009A8B RID: 39563
	private const int ONE_THOUSAND = 1000;

	// Token: 0x04009A8C RID: 39564
	private const int TWO_THOUSAND = 2000;

	// Token: 0x04009A8D RID: 39565
	private const int RECONNECT_TIME_OUT = 20000;
}
