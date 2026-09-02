using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Platform.PlatformSdk;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000EA2 RID: 3746
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class KuroSdkController : ControllerBase<KuroSdkController>
{
	// Token: 0x06005CB0 RID: 23728 RVA: 0x00174B24 File Offset: 0x00172D24
	protected override bool OnInit()
	{
		if (this.CanUseSdk())
		{
			this.ReadIfGlobalSdk();
			this.InitPlatformSdkInstance();
			PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
			if (platformSdkBase != null)
			{
				platformSdkBase.Init();
			}
			this.KuroSdkKickBindFunction();
			this.KuroSdkLogoutBindFunction(ControllerBase<LoginController>.Instance.OnLogoutAccount);
			this.KuroSdkLoginBindFunction(delegate(FLoginStruct result)
			{
				this.OnLogin(result);
			});
			Action<string, string> callback;
			if ((callback = KuroSdkController.<>O.<0>__OnThirdPartyJoinSessionEvent) == null)
			{
				callback = (KuroSdkController.<>O.<0>__OnThirdPartyJoinSessionEvent = new Action<string, string>(OnlineController.OnThirdPartyJoinSessionEvent));
			}
			this.JoinSessionBindFunction(callback);
		}
		this.AddEvent();
		this.InitListener();
		this.OnRegisterNetEvent();
		this.InitTick();
		this.BindWebViewCloseDelegate();
		this.AndroidScreenChangeDelegate = global::DelegateUtils.ToManualReleaseDelegate<FAndroidScreenChangeHandler>(new Action(this.AndroidScreenChangeCallBack));
		UKuroStaticAndroidLibrary.AddAndroidScreenChangeDelegate(this.AndroidScreenChangeDelegate);
		this.ShowKeyboardDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUIShowVirtualKeyboard>(new Action<bool>(this.ShowKeyboardCallBack));
		UUITextInputComponent.SetShowKeyboardDelegate(this.ShowKeyboardDelegate);
		this.TryInitPostWebView();
		return true;
	}

	// Token: 0x06005CB1 RID: 23729 RVA: 0x00174C08 File Offset: 0x00172E08
	public void CloseWebView(string identifier = "Default")
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().CloseWebView();
		}
		if (this.CanUseSdk() && this.PlatformSdkBase != null)
		{
			this.PlatformSdkBase.CloseWebView(identifier);
		}
	}

	// Token: 0x06005CB2 RID: 23730 RVA: 0x00174C44 File Offset: 0x00172E44
	private void InitTick()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			this.TickId = TimerSystem.Instance.Forever(new TTimerAction(this.SdkCheckTimer), 1000f, 1f, null, null, true);
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().SetTickInnerState(false);
		}
	}

	// Token: 0x06005CB3 RID: 23731 RVA: 0x00174C96 File Offset: 0x00172E96
	private void SdkCheckTimer(float delta)
	{
		this.OnTimer(delta * (float)Singleton<TimeUtil>.Instance.Millisecond);
	}

	// Token: 0x06005CB4 RID: 23732 RVA: 0x00174CAB File Offset: 0x00172EAB
	private void EndTick()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().SetTickInnerState(true);
		}
		if (this.TickId != null)
		{
			TimerSystem.Instance.Remove(this.TickId);
		}
	}

	// Token: 0x06005CB5 RID: 23733 RVA: 0x00174CE2 File Offset: 0x00172EE2
	private void OnTimer(float delta)
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().Tick((double)delta);
		}
	}

	// Token: 0x06005CB6 RID: 23734 RVA: 0x00174D01 File Offset: 0x00172F01
	private void InitListener()
	{
		if (!this.ListenerState)
		{
			Singleton<Application>.Instance.AddApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.ApplicationHasReactivatedDelegate));
		}
		this.ListenerState = true;
	}

	// Token: 0x06005CB7 RID: 23735 RVA: 0x00174D2C File Offset: 0x00172F2C
	private void ApplicationHasReactivatedDelegate()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "ApplicationHasReactivatedDelegate", default(ReadOnlySpan<ValueTuple<string, object>>));
		ControllerBase<PayItemController>.Instance.RequestSdkCheckout(ECheckoutReason.StopGame);
		PlatformReportTerminateGame eventData = new PlatformReportTerminateGame();
		Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToThirdParty(eventData);
	}

	// Token: 0x06005CB8 RID: 23736 RVA: 0x00174D78 File Offset: 0x00172F78
	protected override bool OnClear()
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase != null)
		{
			platformSdkBase.OnClear();
		}
		this.RemoveEvent();
		this.RemoveListener();
		this.OnUnRegisterNetEvent();
		this.CancelCurrentWaitPayItemTimer(true);
		if (this.AndroidScreenChangeDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.AndroidScreenChangeCallBack));
			this.AndroidScreenChangeDelegate = null;
		}
		if (this.ShowKeyboardDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool>(this.ShowKeyboardCallBack));
			this.ShowKeyboardDelegate = null;
		}
		this.EndTick();
		this.RemoveNoticeCheckTimer();
		UKuroStaticAndroidLibrary.ClearAndroidScreenChangeDelegate();
		return true;
	}

	// Token: 0x06005CB9 RID: 23737 RVA: 0x00174E01 File Offset: 0x00173001
	private void RemoveListener()
	{
		if (this.ListenerState)
		{
			Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.ApplicationHasReactivatedDelegate));
		}
		this.ListenerState = false;
	}

	// Token: 0x06005CBA RID: 23738 RVA: 0x00174E2C File Offset: 0x0017302C
	private unsafe void AndroidScreenChangeCallBack()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "AndroidScreenChangeCallBack", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAndroidConfigurationChange);
		UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
		ULGUICanvas ulguicanvas = (uiRootItem != null) ? uiRootItem.GetRenderCanvas() : null;
		if (ulguicanvas != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "旋转后LguiCanvasViewPort";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("viewPortX", ulguicanvas.GetViewportSize().X);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("viewPortY", ulguicanvas.GetViewportSize().Y);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x06005CBB RID: 23739 RVA: 0x00174EF0 File Offset: 0x001730F0
	private void ShowKeyboardCallBack(bool state)
	{
		if (this.CanUseSdk())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "ShowVirtualKeyboard";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (Singleton<Info>.Instance.IsWinGDKPlatform())
			{
				if (state)
				{
					UKuroStaticXSXLibrary.ShowKeyBoard(state);
					return;
				}
			}
			else
			{
				UKuroSDKStaticLibrary.ShowVirtualKeyboard(state);
			}
		}
	}

	// Token: 0x06005CBC RID: 23740 RVA: 0x00174F50 File Offset: 0x00173150
	private void AddEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnSetLoginServerId, new Action(this.OnSetLoginServerId));
		Singleton<EventSystem>.Instance.Add<string>(EEventName.LoginSuccess, new Action<string>(this.OnLoginSuccess));
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		Singleton<EventSystem>.Instance.Add(EEventName.SdkRefreshNoticeRedDot, new Action(this.OnSdkRefreshNoticeRedDot));
		if (Singleton<Platform>.Instance.IsPs5Platform())
		{
			Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnQuestFinishListNotify, new Action(this.OnQuestFinishListNotify));
		}
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshOnlineTeamList, new Action(this.RefreshMultiPlayerActivity));
		Singleton<EventSystem>.Instance.Add(EEventName.ChangeModeFinish, new Action(this.RefreshMultiPlayerActivity));
	}

	// Token: 0x06005CBD RID: 23741 RVA: 0x0017507C File Offset: 0x0017327C
	private void RemoveEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSetLoginServerId, new Action(this.OnSetLoginServerId));
		Singleton<EventSystem>.Instance.Remove(EEventName.LoginSuccess, new Action<string>(this.OnLoginSuccess));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.SdkRefreshNoticeRedDot, new Action(this.OnSdkRefreshNoticeRedDot));
		if (Singleton<Platform>.Instance.IsPs5Platform())
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestFinishListNotify, new Action(this.OnQuestFinishListNotify));
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshOnlineTeamList, new Action(this.RefreshMultiPlayerActivity));
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangeModeFinish, new Action(this.RefreshMultiPlayerActivity));
	}

	// Token: 0x06005CBE RID: 23742 RVA: 0x001751A7 File Offset: 0x001733A7
	private void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<AppGradeNotify>(ENotifyMessageId.AppGradeNotify, new Action<AppGradeNotify, Net.CallbackStatus>(this.OnAppGradeNotify));
	}

	// Token: 0x06005CBF RID: 23743 RVA: 0x001751C5 File Offset: 0x001733C5
	private void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AppGradeNotify);
	}

	// Token: 0x06005CC0 RID: 23744 RVA: 0x001751D7 File Offset: 0x001733D7
	private void OnQuestFinishListNotify()
	{
		KuroSdkModel instance = ModelBase<KuroSdkModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.UpdateActivityProgress(0);
	}

	// Token: 0x06005CC1 RID: 23745 RVA: 0x001751EC File Offset: 0x001733EC
	public void RefreshMultiPlayerActivity()
	{
		if (!Singleton<Info>.Instance.IsXboxPlatform())
		{
			return;
		}
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		string playerIdByPlayerSessionId = ControllerBase<OnlineController>.Instance.GetPlayerIdByPlayerSessionId(id.ToString());
		EXboxMultiplayerActivityJoinRestriction roomRestriction = ModelBase<KuroSdkModel>.Instance.GetRoomRestriction();
		if (ModelBase<OnlineModel>.Instance.GetIsMyTeam() && ModelBase<GameModeModel>.Instance.IsMulti)
		{
			this.SetMultiPlayerActivity(ModelBase<OnlineModel>.Instance.GetCurrentTeamSize(), ModelBase<OnlineModel>.Instance.TeamMaxSize, playerIdByPlayerSessionId, roomRestriction);
		}
	}

	// Token: 0x06005CC2 RID: 23746 RVA: 0x00175268 File Offset: 0x00173468
	public void RefreshOnlineHallActivity()
	{
		if (!Singleton<Info>.Instance.IsXboxPlatform())
		{
			return;
		}
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		string playerIdByPlayerSessionId = ControllerBase<OnlineController>.Instance.GetPlayerIdByPlayerSessionId(id.ToString());
		EXboxMultiplayerActivityJoinRestriction roomRestriction = ModelBase<KuroSdkModel>.Instance.GetRoomRestriction();
		this.SetMultiPlayerActivity(1, ModelBase<OnlineModel>.Instance.TeamMaxSize, playerIdByPlayerSessionId, roomRestriction);
	}

	// Token: 0x06005CC3 RID: 23747 RVA: 0x001752C3 File Offset: 0x001734C3
	private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason reason)
	{
		if (!Singleton<Platform>.Instance.IsPs5Platform())
		{
			return;
		}
		KuroSdkModel instance = ModelBase<KuroSdkModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.UpdateActivityProgress(questId);
	}

	// Token: 0x06005CC4 RID: 23748 RVA: 0x001752E2 File Offset: 0x001734E2
	private void OnWorldDoneAndCloseLoading()
	{
		this.CheckNoticeRedDot(0f);
	}

	// Token: 0x06005CC5 RID: 23749 RVA: 0x001752EF File Offset: 0x001734EF
	private void OnLoadingNetDataDone()
	{
		this.RequestServerPlayOnlyState();
		this.RequestUpdatePlatformBlockAccount();
		this.RequestWebSign();
		this.RefreshXboxPlayOnlyState();
		this.TryInitIntroductionParam();
	}

	// Token: 0x06005CC6 RID: 23750 RVA: 0x00175310 File Offset: 0x00173510
	private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		if (this.PlatformSdkBase != null)
		{
			this.PlatformSdkBase.SetGamePadMode(Singleton<Info>.Instance.IsInGamepad());
		}
	}

	// Token: 0x06005CC7 RID: 23751 RVA: 0x0017532F File Offset: 0x0017352F
	private void OnSdkRefreshNoticeRedDot()
	{
		this.CheckNoticeRedDot(0f);
	}

	// Token: 0x06005CC8 RID: 23752 RVA: 0x0017533C File Offset: 0x0017353C
	private void OnLoginSuccess(string account)
	{
		IReadOnlyList<Pay> currentRegionPayConfigList = ConfigBase<PayItemConfig>.Instance.GetCurrentRegionPayConfigList();
		List<string> list = new List<string>();
		if (currentRegionPayConfigList != null)
		{
			foreach (Pay pay in currentRegionPayConfigList)
			{
				list.Add(pay.ProductId);
			}
		}
		ControllerBase<PayItemController>.Instance.QueryProductInfoAsync(list);
		this.InitNoticeCheckTimer();
	}

	// Token: 0x06005CC9 RID: 23753 RVA: 0x001753B0 File Offset: 0x001735B0
	private void InitNoticeCheckTimer()
	{
		bool flag = this.IfNeedPostWebViewOnClient();
		if (this.CheckNoticeRedDotTimerId == null && flag)
		{
			this.CheckNoticeRedDotTimerId = TimerSystem.Instance.Forever(new TTimerAction(this.CheckNoticeRedDot), 600000f, 1f, null, null, false);
			this.CheckNoticeRedDot(0f);
		}
	}

	// Token: 0x06005CCA RID: 23754 RVA: 0x00175405 File Offset: 0x00173605
	private void RemoveNoticeCheckTimer()
	{
		if (this.CheckNoticeRedDotTimerId != null)
		{
			TimerSystem.Instance.Remove(this.CheckNoticeRedDotTimerId);
			this.CheckNoticeRedDotTimerId = null;
		}
	}

	// Token: 0x06005CCB RID: 23755 RVA: 0x00175427 File Offset: 0x00173627
	private void OnSetLoginServerId()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn || (this.CanUseSdk() && this.IfGlobalSdk))
		{
			this.PostKuroSdkEvent(EKuroSdkEventKey.KUROINITIALIZEPOSTWEBVIEW);
		}
	}

	// Token: 0x06005CCC RID: 23756 RVA: 0x00175450 File Offset: 0x00173650
	private void InitPlatformSdkInstance()
	{
		if (this.PlatformSdkBase == null)
		{
			if (Singleton<Platform>.Instance.IsAndroidPlatform() && !this.GetIfGlobalSdk())
			{
				this.PlatformSdkBase = new PlatformSdkAndroid();
				return;
			}
			if (Singleton<Platform>.Instance.IsAndroidPlatform() && this.GetIfGlobalSdk())
			{
				this.PlatformSdkBase = new PlatformSdkAndroidGlobal();
				return;
			}
			if (Singleton<Platform>.Instance.IsIOSPlatform() && this.GetIfGlobalSdk())
			{
				this.PlatformSdkBase = new PlatformSdkIosGlobal();
				return;
			}
			if (Singleton<Platform>.Instance.IsIOSPlatform() && !this.GetIfGlobalSdk())
			{
				this.PlatformSdkBase = new PlatformSdkIos();
				return;
			}
			if (Singleton<Platform>.Instance.IsWindowsOnlyPlatform() && !this.GetIfGlobalSdk())
			{
				if (!Singleton<Platform>.Instance.IsCloudGame())
				{
					this.PlatformSdkBase = new PlatformSdkWindows();
					return;
				}
				if (Singleton<CloudGameManager>.Instance.IsWebPlatform)
				{
					Singleton<Log>.Instance.Info(ELogModule.CloudGame, ELogAuthor.BB, "云游戏Web SDK初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.PlatformSdkBase = new PlatformCloudSdkWeb();
					return;
				}
				if (Singleton<Platform>.Instance.CloudGamePlatform == "Android")
				{
					Singleton<Log>.Instance.Info(ELogModule.CloudGame, ELogAuthor.BB, "云游戏Android SDK初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.PlatformSdkBase = new PlatformCloudSdkAndroid();
					return;
				}
				if (Singleton<Platform>.Instance.CloudGamePlatform == "IOS" || Singleton<Platform>.Instance.CloudGamePlatform == "Mac")
				{
					Singleton<Log>.Instance.Info(ELogModule.CloudGame, ELogAuthor.BB, "云游戏Ios SDK初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.PlatformSdkBase = new PlatformCloudSdkIos();
					return;
				}
				this.PlatformSdkBase = new PlatformSdkWindows();
				return;
			}
			else
			{
				if (Singleton<Platform>.Instance.IsWindowsOnlyPlatform() && this.GetIfGlobalSdk())
				{
					this.PlatformSdkBase = new PlatformSdkWindowsGlobal();
					return;
				}
				if (Singleton<Platform>.Instance.IsMacPlatform() && !this.GetIfGlobalSdk())
				{
					this.PlatformSdkBase = new PlatformSdkMac();
					return;
				}
				if (Singleton<Platform>.Instance.IsMacPlatform() && this.GetIfGlobalSdk())
				{
					this.PlatformSdkBase = new PlatformSdkMacGlobal();
					return;
				}
				if ((Singleton<Platform>.Instance.IsXSXPlatform() || Singleton<Platform>.Instance.IsWinGDKPlatform()) && this.GetIfGlobalSdk())
				{
					this.PlatformSdkBase = new PlatformXSXGlobal();
					return;
				}
				if (Singleton<Platform>.Instance.IsOpenHarmonyPlatform())
				{
					this.PlatformSdkBase = new PlatformSdkOpenHarmony();
					return;
				}
				Singleton<Log>.Instance.Error(ELogModule.KuroSdk, ELogAuthor.YZY, "未找到合适的PlatformSdk实例", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}
	}

	// Token: 0x06005CCD RID: 23757 RVA: 0x001756BB File Offset: 0x001738BB
	public bool GetIfGlobalSdk()
	{
		return this.IfGlobalSdk || (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn && Singleton<PlatformSdkConfig>.Instance.IsGlobal);
	}

	// Token: 0x06005CCE RID: 23758 RVA: 0x001756DF File Offset: 0x001738DF
	public string GetChannelId()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetChannelId();
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return ((platformSdkBase != null) ? platformSdkBase.GetChannelId() : null) ?? "";
	}

	// Token: 0x06005CCF RID: 23759 RVA: 0x00175718 File Offset: 0x00173918
	public string GetDeviceDid()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetDeviceId();
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return ((platformSdkBase != null) ? platformSdkBase.GetDeviceDid() : null) ?? "";
	}

	// Token: 0x06005CD0 RID: 23760 RVA: 0x00175751 File Offset: 0x00173951
	[NullableContext(2)]
	public string GetPackageId()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetPackageId();
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return null;
		}
		return platformSdkBase.GetPackageId();
	}

	// Token: 0x06005CD1 RID: 23761 RVA: 0x00175780 File Offset: 0x00173980
	public bool CheckIfSdkLogin()
	{
		return this.CanUseSdk() && this.GetCurrentLoginInfo().Uid != "0";
	}

	// Token: 0x06005CD2 RID: 23762 RVA: 0x001757A1 File Offset: 0x001739A1
	public FLoginStruct GetCurrentLoginInfo()
	{
		return UKuroSDKManager.GetCurrentLoginInfo();
	}

	// Token: 0x06005CD3 RID: 23763 RVA: 0x001757A8 File Offset: 0x001739A8
	private void ReadIfGlobalSdk()
	{
		this.IfGlobalSdk = Singleton<PublicUtil>.Instance.GetIfGlobalSdk();
	}

	// Token: 0x06005CD4 RID: 23764 RVA: 0x001757BA File Offset: 0x001739BA
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public SdkAgreementLinkData[] GetAgreement()
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return null;
		}
		return platformSdkBase.GetAgreement();
	}

	// Token: 0x06005CD5 RID: 23765 RVA: 0x001757CD File Offset: 0x001739CD
	public void TestOpenWnd()
	{
		this.SdkOpenUrlWnd("用户协议", "https://wutheringwaves.kurogame.com/p/agreement_public.html", true, true, true);
	}

	// Token: 0x06005CD6 RID: 23766 RVA: 0x001757E2 File Offset: 0x001739E2
	public bool CanUseSdk()
	{
		return !Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn && UKuroStaticLibrary.IsModuleLoaded("KuroSDK") && Singleton<BaseConfigController>.Instance.GetPublicValue("UseSDK") == "1";
	}

	// Token: 0x06005CD7 RID: 23767 RVA: 0x00175818 File Offset: 0x00173A18
	public void PostKuroSdkEvent(EKuroSdkEventKey eventKey)
	{
		if (this.PlatformSdkBase == null && !Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			if (eventKey == EKuroSdkEventKey.KUROSDKEXIT)
			{
				this.ExitGame();
			}
			return;
		}
		switch (eventKey)
		{
		case EKuroSdkEventKey.KUROSDKLOGIN:
		{
			PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
			if (platformSdkBase == null)
			{
				return;
			}
			platformSdkBase.SdkLogin();
			return;
		}
		case EKuroSdkEventKey.KUROSDKKICK:
		{
			PlatformSdkBase platformSdkBase2 = this.PlatformSdkBase;
			if (platformSdkBase2 == null)
			{
				return;
			}
			platformSdkBase2.SdkKick();
			return;
		}
		case EKuroSdkEventKey.KUROSDKSELECTROLE:
			this.ReportSelectRole();
			return;
		case EKuroSdkEventKey.KUROSDKCREATEROLE:
			this.ReportCreateRole();
			return;
		case EKuroSdkEventKey.KUROSDKLEVEUPROLE:
			this.ReportLevelUpRole();
			return;
		case EKuroSdkEventKey.KUROSDKEXIT:
		{
			PlatformSdkBase platformSdkBase3 = this.PlatformSdkBase;
			if (platformSdkBase3 == null)
			{
				return;
			}
			platformSdkBase3.SdkExit();
			return;
		}
		case EKuroSdkEventKey.KUROSDKLOGOUT:
		{
			PlatformSdkBase platformSdkBase4 = this.PlatformSdkBase;
			if (platformSdkBase4 == null)
			{
				return;
			}
			platformSdkBase4.SdkLogout();
			return;
		}
		case EKuroSdkEventKey.KUROSDKOPENLOGINWND:
			this.SdkOpenLoginWnd();
			return;
		case EKuroSdkEventKey.KUROSDKPAY:
		case EKuroSdkEventKey.KUROSDKOPENSDKWND:
		case EKuroSdkEventKey.KuroDoInit:
			break;
		case EKuroSdkEventKey.KUROINITIALIZEPOSTWEBVIEW:
			this.InitPostWebView();
			return;
		case EKuroSdkEventKey.KUROOPENPOSTWEBVIEW:
			this.OpenPostWebView(EOpenNoticeStage.Normal);
			return;
		case EKuroSdkEventKey.KuroOpenPrivacyClauseWnd:
		{
			PlatformSdkBase platformSdkBase5 = this.PlatformSdkBase;
			if (platformSdkBase5 == null)
			{
				return;
			}
			platformSdkBase5.KuroOpenPrivacyClauseWnd();
			return;
		}
		case EKuroSdkEventKey.KuroOpenUserCenter:
			this.OpenUserCenter();
			return;
		case EKuroSdkEventKey.KuroReadProductInfo:
		{
			PlatformSdkBase platformSdkBase6 = this.PlatformSdkBase;
			if (platformSdkBase6 == null)
			{
				return;
			}
			platformSdkBase6.ReadProductInfo();
			return;
		}
		case EKuroSdkEventKey.KuroShowAgreement:
		{
			PlatformSdkBase platformSdkBase7 = this.PlatformSdkBase;
			if (platformSdkBase7 == null)
			{
				return;
			}
			platformSdkBase7.ShowAgreement();
			break;
		}
		case EKuroSdkEventKey.KuroNotiLanguage:
			this.NotifyLanguage();
			return;
		default:
			return;
		}
	}

	// Token: 0x06005CD8 RID: 23768 RVA: 0x00175944 File Offset: 0x00173B44
	private void NotifyLanguage()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().NotifyCurrentLanguage(packageLanguage);
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.NotifyLanguage();
	}

	// Token: 0x06005CD9 RID: 23769 RVA: 0x00175989 File Offset: 0x00173B89
	private void SdkOpenLoginWnd()
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.SdkOpenLoginWnd();
	}

	// Token: 0x06005CDA RID: 23770 RVA: 0x0017599C File Offset: 0x00173B9C
	public void OpenUserCenter()
	{
		Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "OpenUserCenter", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			SdkLoginConfig sdkLoginConfig = ModelBase<LoginModel>.Instance.GetSdkLoginConfig();
			string text = (sdkLoginConfig != null) ? sdkLoginConfig.Uid : null;
			if (text != null)
			{
				Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().OpenUserCenter(text, delegate
				{
					Singleton<EventSystem>.Instance.Emit(EEventName.SdkRefreshAccessToken);
				});
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "OpenUserCenter";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("userId", text);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().OpenUserCenter("test", delegate
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.SdkRefreshAccessToken);
			});
			return;
		}
		else
		{
			PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
			if (platformSdkBase == null)
			{
				return;
			}
			platformSdkBase.OpenUserCenter();
			return;
		}
	}

	// Token: 0x06005CDB RID: 23771 RVA: 0x00175A89 File Offset: 0x00173C89
	private void ExitGame()
	{
		if (GlobalData.IsPlayInEditor)
		{
			UKismetSystemLibrary.QuitGame(GlobalData.World, null, EQuitPreference.Quit, false);
			return;
		}
		if (!this.CanUseSdk())
		{
			KuroApplication.ExitWithReason(false, "SDK");
		}
	}

	// Token: 0x06005CDC RID: 23772 RVA: 0x00175AB4 File Offset: 0x00173CB4
	public void SdkPay(int payId, string orderId, string name, string desc, string callBackUrl)
	{
		ISDKPayment sdkPayProduct = KuroSdkControllerTool.GetSdkPayProduct(payId, orderId, name, desc, callBackUrl);
		this.SdkPay(sdkPayProduct);
	}

	// Token: 0x06005CDD RID: 23773 RVA: 0x00175AD8 File Offset: 0x00173CD8
	public void SdkPay(ISDKPayment paymentInfo)
	{
		if (this.CanUseSdk())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.KuroSdk;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "SdkPay";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SdkPay", paymentInfo);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			StartSdkPayEvent startSdkPayEvent = new StartSdkPayEvent();
			startSdkPayEvent.s_sdk_pay_order = paymentInfo.cpOrderId;
			startSdkPayEvent.s_sdk_callback_url = (paymentInfo.callbackUrl ?? "");
			ControllerBase<LogReportController>.Instance.LogReport(startSdkPayEvent);
			ModelBase<KuroSdkModel>.Instance.CurrentPayingOrderId = paymentInfo.cpOrderId;
			PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
			if (platformSdkBase != null)
			{
				platformSdkBase.SdkPay(paymentInfo);
			}
			ModelBase<KuroSdkModel>.Instance.CurrentPayItemName = paymentInfo.goodsName;
			this.KuroSdkPaymentBindFunction(new Action<bool, string>(this.OnSdkPayEnd));
		}
	}

	// Token: 0x06005CDE RID: 23774 RVA: 0x00175B8D File Offset: 0x00173D8D
	public void OnSdkPayEnd(bool payResult, string str)
	{
		if (payResult && ModelBase<KuroSdkModel>.Instance.CurrentPayItemName != "")
		{
			this.StartWaitPayItemTimer();
		}
	}

	// Token: 0x06005CDF RID: 23775 RVA: 0x00175BAE File Offset: 0x00173DAE
	public void OpenNotice(EOpenNoticeStage stage = EOpenNoticeStage.Normal)
	{
		this.OpenPostWebView(stage);
	}

	// Token: 0x06005CE0 RID: 23776 RVA: 0x00175BB7 File Offset: 0x00173DB7
	public void OpenFeedback()
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.OpenFeedback();
	}

	// Token: 0x06005CE1 RID: 23777 RVA: 0x00175BC9 File Offset: 0x00173DC9
	public void SdkOpenUrlWnd(string title, string url, bool isLandscape = true, bool transparent = true, bool webAccelerated = true)
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().OpenWebView(url, null);
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.SdkOpenUrlWnd(title, url, isLandscape, transparent, webAccelerated);
	}

	// Token: 0x06005CE2 RID: 23778 RVA: 0x00175C00 File Offset: 0x00173E00
	public void OpenExternalUrl(string url)
	{
		Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().OpenExternalUrl(url);
	}

	// Token: 0x06005CE3 RID: 23779 RVA: 0x00175C14 File Offset: 0x00173E14
	[NullableContext(0)]
	public UniTask<bool> QueryProductByProductId([Nullable(1)] string[] productList)
	{
		KuroSdkController.<QueryProductByProductId>d__67 <QueryProductByProductId>d__;
		<QueryProductByProductId>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<QueryProductByProductId>d__.<>4__this = this;
		<QueryProductByProductId>d__.productList = productList;
		<QueryProductByProductId>d__.<>1__state = -1;
		<QueryProductByProductId>d__.<>t__builder.Start<KuroSdkController.<QueryProductByProductId>d__67>(ref <QueryProductByProductId>d__);
		return <QueryProductByProductId>d__.<>t__builder.Task;
	}

	// Token: 0x06005CE4 RID: 23780 RVA: 0x00175C5F File Offset: 0x00173E5F
	public void ShareByteData(ShareData shareData, TArray<byte> data)
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.ShareByteData(shareData, data);
	}

	// Token: 0x06005CE5 RID: 23781 RVA: 0x00175C73 File Offset: 0x00173E73
	public void Share(ShareData shareData, string imagePath)
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.Share(shareData, imagePath);
	}

	// Token: 0x06005CE6 RID: 23782 RVA: 0x00175C87 File Offset: 0x00173E87
	public void ShareTexture(ShareData shareData, string texturePath)
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.ShareTexture(shareData, texturePath);
	}

	// Token: 0x06005CE7 RID: 23783 RVA: 0x00175C9B File Offset: 0x00173E9B
	private string GetCurrentQueryChannel()
	{
		return "";
	}

	// Token: 0x06005CE8 RID: 23784 RVA: 0x00175CA2 File Offset: 0x00173EA2
	public void OpenWebView(string title, string url, bool isLandscape, bool transparent, bool webAccelerated = true, string identifier = "Default")
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().OpenWebView(url, null);
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.OpenWebView(title, url, isLandscape, transparent, webAccelerated, identifier);
	}

	// Token: 0x06005CE9 RID: 23785 RVA: 0x00175CDB File Offset: 0x00173EDB
	public void KuroSdkLoginBindFunction(Action<FLoginStruct> loginFunction)
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.KuroSdkLoginBindFunction(loginFunction);
	}

	// Token: 0x06005CEA RID: 23786 RVA: 0x00175CEE File Offset: 0x00173EEE
	public void KuroSdkLoginBindFunction(Action<ILoginInfo> loginFunction)
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.KuroSdkLoginBindFunction(loginFunction);
	}

	// Token: 0x06005CEB RID: 23787 RVA: 0x00175D01 File Offset: 0x00173F01
	public void KuroSdkKickBindFunction()
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.KuroSdkKickBindFunction();
	}

	// Token: 0x06005CEC RID: 23788 RVA: 0x00175D13 File Offset: 0x00173F13
	public void KuroSdkLogoutBindFunction(Action callback)
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.KuroSdkLogoutBindFunction(callback);
	}

	// Token: 0x06005CED RID: 23789 RVA: 0x00175D26 File Offset: 0x00173F26
	public void KuroSdkPaymentBindFunction(Action<bool, string> paymentFunction)
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.KuroSdkPaymentBindFunction(paymentFunction);
	}

	// Token: 0x06005CEE RID: 23790 RVA: 0x00175D39 File Offset: 0x00173F39
	public void JoinSessionBindFunction(Action<string, string> callback)
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.JoinSessionBindFunction(callback);
	}

	// Token: 0x06005CEF RID: 23791 RVA: 0x00175D4C File Offset: 0x00173F4C
	public void SetPostWebViewRedPointState(bool state)
	{
		this.CurrentPostViewRedPointState = state;
	}

	// Token: 0x06005CF0 RID: 23792 RVA: 0x00175D55 File Offset: 0x00173F55
	public bool GetPostWebViewRedPointState()
	{
		if (this.IfNeedPostWebViewOnClient())
		{
			return ModelBase<KuroSdkModel>.Instance.NoticeRedDotState;
		}
		return this.CurrentPostViewRedPointState;
	}

	// Token: 0x06005CF1 RID: 23793 RVA: 0x00175D70 File Offset: 0x00173F70
	public bool NeedShowCustomerService()
	{
		return ControllerBase<ChannelController>.Instance.CheckCustomerServiceOpen();
	}

	// Token: 0x06005CF2 RID: 23794 RVA: 0x00175D7C File Offset: 0x00173F7C
	public bool GetCustomerServiceRedPointState()
	{
		return this.PlatformSdkBase != null && this.PlatformSdkBase.GetCustomerServiceShowState();
	}

	// Token: 0x06005CF3 RID: 23795 RVA: 0x00175D93 File Offset: 0x00173F93
	public void OpenCustomerService(EKuroSdkOpenCustomerServerType fromType)
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().OpenCustomerService();
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase != null)
		{
			platformSdkBase.ResetCustomServerRedDot();
		}
		PlatformSdkBase platformSdkBase2 = this.PlatformSdkBase;
		if (platformSdkBase2 == null)
		{
			return;
		}
		platformSdkBase2.OpenCustomerService(fromType);
	}

	// Token: 0x06005CF4 RID: 23796 RVA: 0x00175DD3 File Offset: 0x00173FD3
	public bool GetIfCanQRCodeLogin()
	{
		if (!this.CanUseSdk())
		{
			return false;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return platformSdkBase != null && platformSdkBase.GetIsQRCodeLogin();
	}

	// Token: 0x06005CF5 RID: 23797 RVA: 0x00175DF0 File Offset: 0x00173FF0
	public void DoQRCodeLogin()
	{
		if (!this.CanUseSdk())
		{
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.QRCodeLogin();
	}

	// Token: 0x06005CF6 RID: 23798 RVA: 0x00175E0B File Offset: 0x0017400B
	public bool CheckPhotoPermission()
	{
		if (!this.CanUseSdk() || this.PlatformSdkBase == null)
		{
			return true;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return platformSdkBase == null || platformSdkBase.CheckPhotoPermission();
	}

	// Token: 0x06005CF7 RID: 23799 RVA: 0x00175E30 File Offset: 0x00174030
	public void RequestPhotoPermission(Action<bool> callBack)
	{
		if (!this.CanUseSdk())
		{
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.RequestPhotoPermission(callBack);
	}

	// Token: 0x06005CF8 RID: 23800 RVA: 0x00175E4C File Offset: 0x0017404C
	public void CancelCurrentWaitPayItemTimer(bool clearPayItem = true)
	{
		if (clearPayItem)
		{
			ModelBase<KuroSdkModel>.Instance.CurrentPayItemName = "";
			Singleton<Log>.Instance.Info(ELogModule.KuroSdk, ELogAuthor.YZY, "CancelCurrentWaitPayItemTimer clearPayItem", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (this.WaitPayResponseTimerId != null)
		{
			TimerSystem.Instance.Remove(this.WaitPayResponseTimerId);
			this.WaitPayResponseTimerId = null;
		}
	}

	// Token: 0x06005CF9 RID: 23801 RVA: 0x00175EA7 File Offset: 0x001740A7
	public void CancelQueryProductTimer()
	{
		if (this.CheckQueryProductTimerId != null)
		{
			TimerSystem.Instance.Remove(this.CheckQueryProductTimerId);
			this.CheckQueryProductTimerId = null;
		}
	}

	// Token: 0x06005CFA RID: 23802 RVA: 0x00175EC9 File Offset: 0x001740C9
	private void StartQueryProductTimer()
	{
		this.CancelQueryProductTimer();
		this.CheckQueryProductTimerId = TimerSystem.Instance.Delay(delegate(float _)
		{
			CustomPromise<bool> queryPromise = ModelBase<KuroSdkModel>.Instance.QueryPromise;
			if (queryPromise != null && queryPromise.IsPending)
			{
				ModelBase<KuroSdkModel>.Instance.QueryPromise.SetResult(false);
			}
			this.CheckQueryProductTimerId = null;
		}, 10000f, null, null, true, 1f);
	}

	// Token: 0x06005CFB RID: 23803 RVA: 0x00175EFC File Offset: 0x001740FC
	public void StartWaitPayItemTimer()
	{
		this.CancelCurrentWaitPayItemTimer(false);
		int? waitPaySuccessTime = ConfigBase<PayItemConfig>.Instance.GetWaitPaySuccessTime();
		this.WaitPayResponseTimerId = TimerSystem.Instance.Delay(delegate(float _)
		{
			string currentPayItemName = ModelBase<KuroSdkModel>.Instance.CurrentPayItemName;
			if (StringUtils.IsBlank(currentPayItemName))
			{
				this.WaitPayResponseTimerId = null;
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PayResTimeOut);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				currentPayItemName
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			this.WaitPayResponseTimerId = null;
		}, (float)waitPaySuccessTime.Value, null, null, true, 1f);
	}

	// Token: 0x06005CFC RID: 23804 RVA: 0x00175F48 File Offset: 0x00174148
	public void RequestServerPlayOnlyState()
	{
		PsnSettingRequest message = PsnSettingRequest.Create();
		Singleton<Net>.Instance.Call<PsnSettingResponse>(ERequestMessageId.PsnSettingRequest, message, delegate(PsnSettingResponse response, Net.CallbackStatus _)
		{
			ModelBase<KuroSdkModel>.Instance.SetPlayStationPlayOnlyState(response.MatchPsnUser);
		}, 0);
		XboxSettingRequest message2 = XboxSettingRequest.Create();
		Singleton<Net>.Instance.Call<XboxSettingResponse>(ERequestMessageId.XboxSettingRequest, message2, delegate(XboxSettingResponse response, Net.CallbackStatus _)
		{
			ModelBase<KuroSdkModel>.Instance.SetXboxPlayOnlyState(response.MatchXboxUser);
		}, 0);
	}

	// Token: 0x06005CFD RID: 23805 RVA: 0x00175FC4 File Offset: 0x001741C4
	public void RequestWebSign()
	{
		PlayerGameTokenRequest message = PlayerGameTokenRequest.Create();
		Singleton<Net>.Instance.Call<PlayerGameTokenResponse>(ERequestMessageId.PlayerGameTokenRequest, message, delegate(PlayerGameTokenResponse response, Net.CallbackStatus _)
		{
			ModelBase<KuroSdkModel>.Instance.NoticeSign = (((response != null) ? response.GameToken : null) ?? "");
			this.CheckNoticeRedDot(0f);
		}, 0);
	}

	// Token: 0x06005CFE RID: 23806 RVA: 0x00175FF4 File Offset: 0x001741F4
	public UniTask RequestUpdatePlatformBlockAccount()
	{
		KuroSdkController.<RequestUpdatePlatformBlockAccount>d__94 <RequestUpdatePlatformBlockAccount>d__;
		<RequestUpdatePlatformBlockAccount>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestUpdatePlatformBlockAccount>d__.<>4__this = this;
		<RequestUpdatePlatformBlockAccount>d__.<>1__state = -1;
		<RequestUpdatePlatformBlockAccount>d__.<>t__builder.Start<KuroSdkController.<RequestUpdatePlatformBlockAccount>d__94>(ref <RequestUpdatePlatformBlockAccount>d__);
		return <RequestUpdatePlatformBlockAccount>d__.<>t__builder.Task;
	}

	// Token: 0x06005CFF RID: 23807 RVA: 0x00176038 File Offset: 0x00174238
	public void RequestChangeServerPlayStationPlayOnlyState(bool state)
	{
		PsnSettingUpdateRequest psnSettingUpdateRequest = PsnSettingUpdateRequest.Create();
		psnSettingUpdateRequest.MatchPsnUser = state;
		Singleton<Net>.Instance.Call<PsnSettingUpdateResponse>(ERequestMessageId.PsnSettingUpdateRequest, psnSettingUpdateRequest, delegate(PsnSettingUpdateResponse response, Net.CallbackStatus _)
		{
			if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25432, null, true, true);
				return;
			}
			ModelBase<KuroSdkModel>.Instance.SetPlayStationPlayOnlyState(state);
		}, 0);
	}

	// Token: 0x06005D00 RID: 23808 RVA: 0x00176084 File Offset: 0x00174284
	public void RequestChangeServerXboxPlayOnlyState(bool state)
	{
		XboxSettingUpdateRequest xboxSettingUpdateRequest = XboxSettingUpdateRequest.Create();
		xboxSettingUpdateRequest.MatchXboxUser = state;
		Singleton<Net>.Instance.Call<XboxSettingUpdateResponse>(ERequestMessageId.XboxSettingUpdateRequest, xboxSettingUpdateRequest, delegate(XboxSettingUpdateResponse response, Net.CallbackStatus _)
		{
			if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25432, null, true, true);
			}
			ModelBase<KuroSdkModel>.Instance.SetXboxPlayOnlyState(state);
		}, 0);
	}

	// Token: 0x06005D01 RID: 23809 RVA: 0x001760CD File Offset: 0x001742CD
	private bool CheckIfCanOpenReviewView()
	{
		return ModelBase<KuroSdkModel>.Instance.NeedOpenReviewState;
	}

	// Token: 0x06005D02 RID: 23810 RVA: 0x001760DE File Offset: 0x001742DE
	public void TryOpenReview()
	{
		if (!this.CheckIfCanOpenReviewView())
		{
			return;
		}
		TimerSystem.Instance.Delay(delegate(float _)
		{
			double global = LocalStorage.GetGlobal<double>(ELocalStorageGlobalKey.LastReviewTime, 0.0);
			int valueOrDefault = ConfigBase<CommonConfig>.Instance.GetReviewCd().GetValueOrDefault();
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if (serverTime - global > (double)valueOrDefault)
			{
				LocalStorage.SetGlobal<double>(ELocalStorageGlobalKey.LastReviewTime, serverTime);
				this.OpenReview();
				return;
			}
			ModelBase<KuroSdkModel>.Instance.NeedOpenReviewState = false;
		}, (float)ModelBase<KuroSdkModel>.Instance.ReviewDelay, null, null, true, 1f);
	}

	// Token: 0x06005D03 RID: 23811 RVA: 0x00176114 File Offset: 0x00174314
	private void OpenReview()
	{
		if (ModelBase<KuroSdkModel>.Instance.NeedReviewConfirmBox)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ShowReviewConfirm);
			confirmBoxDataNew.SetCloseFunction(delegate
			{
				if (this.PlatformSdkBase != null)
				{
					this.PlatformSdkBase.OpenReview(ModelBase<KuroSdkModel>.Instance.CurrentReviewId);
					ModelBase<KuroSdkModel>.Instance.NeedOpenReviewState = false;
				}
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
			return;
		}
		if (this.PlatformSdkBase != null)
		{
			this.PlatformSdkBase.OpenReview(ModelBase<KuroSdkModel>.Instance.CurrentReviewId);
			ModelBase<KuroSdkModel>.Instance.NeedOpenReviewState = false;
		}
	}

	// Token: 0x06005D04 RID: 23812 RVA: 0x0017617F File Offset: 0x0017437F
	[NullableContext(2)]
	private void OnAppGradeNotify(AppGradeNotify notify, Net.CallbackStatus status)
	{
		ModelBase<KuroSdkModel>.Instance.NeedOpenReviewState = true;
		ModelBase<KuroSdkModel>.Instance.ReviewDelay = notify.Delay;
		ModelBase<KuroSdkModel>.Instance.CurrentReviewId = notify.Id;
		if (notify.Type != 1)
		{
			this.TryOpenReview();
		}
	}

	// Token: 0x06005D05 RID: 23813 RVA: 0x001761BB File Offset: 0x001743BB
	public void ClientOpenReview()
	{
		ModelBase<KuroSdkModel>.Instance.NeedOpenReviewState = true;
		ModelBase<KuroSdkModel>.Instance.ReviewDelay = 1000;
		this.TryOpenReview();
	}

	// Token: 0x06005D06 RID: 23814 RVA: 0x001761DD File Offset: 0x001743DD
	public void SetCursor(string path)
	{
		if (this.PlatformSdkBase != null)
		{
			this.PlatformSdkBase.SetCursor(path);
		}
	}

	// Token: 0x06005D07 RID: 23815 RVA: 0x001761F3 File Offset: 0x001743F3
	private void ReportSelectRole()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToServer(EReportRoleDataType.Select, this.ConvertRoleInfoData(KuroSdkControllerTool.GetRoleInfoData()));
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.SdkSelectRole();
	}

	// Token: 0x06005D08 RID: 23816 RVA: 0x0017622D File Offset: 0x0017442D
	private void ReportCreateRole()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToServer(EReportRoleDataType.Create, this.ConvertRoleInfoData(KuroSdkControllerTool.GetCreateRoleInfoData()));
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.SdkCreateRole();
	}

	// Token: 0x06005D09 RID: 23817 RVA: 0x00176267 File Offset: 0x00174467
	private void ReportLevelUpRole()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().ReportToServer(EReportRoleDataType.LevelUp, this.ConvertRoleInfoData(KuroSdkControllerTool.GetRoleInfoData()));
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.SdkLevelUpRole();
	}

	// Token: 0x06005D0A RID: 23818 RVA: 0x001762A4 File Offset: 0x001744A4
	private ReportRoleData ConvertRoleInfoData(RoleInfoSdk roleInfoData)
	{
		return new ReportRoleData
		{
			roleId = roleInfoData.RoleId,
			roleLevel = roleInfoData.RoleLevel,
			roleName = roleInfoData.RoleName,
			serverId = roleInfoData.ServerId,
			serverName = roleInfoData.ServerName
		};
	}

	// Token: 0x06005D0B RID: 23819 RVA: 0x001762F4 File Offset: 0x001744F4
	private void BindWebViewCloseDelegate()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().BindOnWebViewCloseCallBack(delegate
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.SdkRefreshNoticeRedDot);
			});
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.BindWebViewCloseDelegate(delegate
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.SdkRefreshNoticeRedDot);
		});
	}

	// Token: 0x06005D0C RID: 23820 RVA: 0x0017636B File Offset: 0x0017456B
	private bool IfNeedPostWebViewOnClient()
	{
		return true;
	}

	// Token: 0x06005D0D RID: 23821 RVA: 0x0017636E File Offset: 0x0017456E
	private void InitPostWebView()
	{
		if (this.IfNeedPostWebViewOnClient())
		{
			this.TryInitPostWebView();
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.InitializePostWebView();
	}

	// Token: 0x06005D0E RID: 23822 RVA: 0x00176390 File Offset: 0x00174590
	private void OpenPostWebView(EOpenNoticeStage stage = EOpenNoticeStage.Normal)
	{
		NoticeClickLogEvent logData = new NoticeClickLogEvent();
		ControllerBase<LogReportController>.Instance.LogReport(logData);
		if (this.IfNeedPostWebViewOnClient())
		{
			this.OpenPostWebViewOnClient(stage);
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.OpenPostWebView();
	}

	// Token: 0x06005D0F RID: 23823 RVA: 0x001763D0 File Offset: 0x001745D0
	private unsafe void OpenPostWebViewOnClient(EOpenNoticeStage stage = EOpenNoticeStage.Normal)
	{
		this.HttpGetNoticeH5Data(delegate(bool state, int urlIndex)
		{
			if (state)
			{
				string noticeUrl = ModelBase<KuroSdkModel>.Instance.GetNoticeUrl(urlIndex, stage);
				this.OpenWebView("", noticeUrl, true, true, true, "Default");
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.KuroSdk;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "OpenPostWebViewOnClient";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("urlIndex", urlIndex);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.KuroSdk;
			ELogAuthor author2 = ELogAuthor.YZY;
			string message2 = "OpenPostWebViewOnClientFail";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("state", state);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("urlIndex", urlIndex);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}, 0);
	}

	// Token: 0x06005D10 RID: 23824 RVA: 0x00176404 File Offset: 0x00174604
	private void HttpGetNoticeH5Data(Action<bool, int> callBack, int currentIndex = 0)
	{
		if (ModelBase<KuroSdkModel>.Instance.GetEntryPointData() == null)
		{
			callBack(false, currentIndex);
			return;
		}
		if (currentIndex >= ModelBase<KuroSdkModel>.Instance.GetEntryPointData().h5AppUrl.Length)
		{
			callBack(false, currentIndex);
			return;
		}
		Http.Get(ModelBase<KuroSdkModel>.Instance.GetNoticeUrl(currentIndex, EOpenNoticeStage.Normal), null, delegate(bool success, int code, string data)
		{
			if (!success || code != 200)
			{
				this.HttpGetNoticeH5Data(callBack, currentIndex + 1);
				return;
			}
			callBack(true, currentIndex);
		}, null);
	}

	// Token: 0x06005D11 RID: 23825 RVA: 0x001764A4 File Offset: 0x001746A4
	private void HttpGetInfo(string url, Action<bool, int, string> callBack, int currentTryCount = 0)
	{
		Http.Get(url, null, delegate(bool success, int code, string data)
		{
			if (success && code == 200)
			{
				callBack(true, code, data);
				return;
			}
			int num = currentTryCount + 1;
			if (num < 3)
			{
				this.HttpGetInfo(url, callBack, num);
				return;
			}
			callBack(false, code, data);
		}, null);
	}

	// Token: 0x06005D12 RID: 23826 RVA: 0x001764F4 File Offset: 0x001746F4
	public unsafe void TryInitIntroductionParam()
	{
		if (this.TryInitIntroductionParamState)
		{
			return;
		}
		string introductionVersionUrl = ModelBase<KuroSdkModel>.Instance.GetIntroductionVersionUrl();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "TryInitIntroductionParam";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("url", introductionVersionUrl);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.HttpGetInfo(introductionVersionUrl, delegate(bool state, int code, string data)
		{
			if (!state)
			{
				string introductionVersionUrl2 = ModelBase<KuroSdkModel>.Instance.GetIntroductionVersionUrl();
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.KuroSdk;
				ELogAuthor author2 = ELogAuthor.YZY;
				string message2 = "TryInitIntroductionParam fail";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("state", state);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("code", code);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("url", introductionVersionUrl2);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			else
			{
				IntroductionData introductionData = Json.Decode<IntroductionData>(data, null);
				ModelBase<KuroSdkModel>.Instance.SetIntroductionData(introductionData);
			}
			this.TryInitIntroductionParamState = false;
		}, 0);
	}

	// Token: 0x06005D13 RID: 23827 RVA: 0x00176550 File Offset: 0x00174750
	private unsafe void TryInitPostWebView()
	{
		if (!this.IfNeedPostWebViewOnClient())
		{
			return;
		}
		string currentLoginServerId = ModelBase<LoginServerModel>.Instance.GetCurrentLoginServerId();
		if (currentLoginServerId == "" || currentLoginServerId == "0")
		{
			return;
		}
		if (this.TryInitPostWebViewState)
		{
			return;
		}
		this.TryInitPostWebViewState = true;
		string entryPointUrl = ModelBase<KuroSdkModel>.Instance.GetEntryPointUrl();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.KuroSdk;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "TryInitPostWebView";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("url", entryPointUrl);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.HttpGetInfo(entryPointUrl, delegate(bool state, int code, string data)
		{
			if (!state)
			{
				string entryPointUrl2 = ModelBase<KuroSdkModel>.Instance.GetEntryPointUrl();
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.KuroSdk;
				ELogAuthor author2 = ELogAuthor.YZY;
				string message2 = "TryInitPostWebView fail";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("state", state);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("code", code);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("url", entryPointUrl2);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			else
			{
				PostWebViewEntryPointData entryPointData = Json.Decode<PostWebViewEntryPointData>(data, null);
				ModelBase<KuroSdkModel>.Instance.SetEntryPointData(entryPointData);
			}
			this.TryInitPostWebViewState = false;
		}, 0);
	}

	// Token: 0x06005D14 RID: 23828 RVA: 0x001765E4 File Offset: 0x001747E4
	private void CheckNoticeRedDot(float delta)
	{
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		if (instance == null || instance.LoadingPhase != ELoadingPhase.Finished || ModelBase<KuroSdkModel>.Instance.NoticeSign == "")
		{
			return;
		}
		this.HttpGetNoticeRedDotState(delegate(bool state, int code, string data)
		{
			if (state)
			{
				NoticeRedDotData noticeRedDotData = Json.Decode<NoticeRedDotData>(data, null);
				ModelBase<KuroSdkModel>.Instance.NoticeRedDotState = noticeRedDotData.data;
				Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
				return;
			}
			ModelBase<KuroSdkModel>.Instance.NoticeRedDotState = false;
			Singleton<EventSystem>.Instance.Emit(EEventName.SdkPostWebViewRedPointRefresh);
		}, 0);
	}

	// Token: 0x06005D15 RID: 23829 RVA: 0x00176648 File Offset: 0x00174848
	private void HttpGetNoticeRedDotState(Action<bool, int, string> callBack, int currentIndex = 0)
	{
		if (ModelBase<KuroSdkModel>.Instance.GetEntryPointData() == null)
		{
			callBack(false, 0, "");
			return;
		}
		if (currentIndex >= ModelBase<KuroSdkModel>.Instance.GetEntryPointData().apiUrls.Length)
		{
			callBack(false, 0, "");
			return;
		}
		Http.Get(ModelBase<KuroSdkModel>.Instance.GetQueryNoticeRedDotStateUrl(currentIndex), null, delegate(bool success, int code, string data)
		{
			if (!success || code != 200)
			{
				this.HttpGetNoticeRedDotState(callBack, currentIndex + 1);
				return;
			}
			callBack(success, code, data);
		}, null);
	}

	// Token: 0x06005D16 RID: 23830 RVA: 0x001766E8 File Offset: 0x001748E8
	private void HttpGetNoticeContentData(Action<bool, int, string> callBack, int currentIndex = 0)
	{
		if (ModelBase<KuroSdkModel>.Instance.GetEntryPointData() == null)
		{
			callBack(false, 0, "");
			return;
		}
		if (currentIndex >= ModelBase<KuroSdkModel>.Instance.GetEntryPointData().contentUrl.Length)
		{
			callBack(false, 0, "");
			return;
		}
		Http.Get(ModelBase<KuroSdkModel>.Instance.GetNoticeContentUrl(currentIndex), null, delegate(bool success, int code, string data)
		{
			if (!success || code != 200)
			{
				this.HttpGetNoticeContentData(callBack, currentIndex + 1);
				return;
			}
			callBack(success, code, data);
		}, null);
	}

	// Token: 0x06005D17 RID: 23831 RVA: 0x00176786 File Offset: 0x00174986
	public void RecoverSdkData()
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.RecoverSdkData();
	}

	// Token: 0x06005D18 RID: 23832 RVA: 0x00176798 File Offset: 0x00174998
	public void ShowExternalLogin()
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.ShowExternalLogin();
	}

	// Token: 0x06005D19 RID: 23833 RVA: 0x001767AA File Offset: 0x001749AA
	public void UnlockSdkTrophy(string id)
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().UnlockSdkTrophy(int.Parse(id));
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.UnlockSdkTrophy(id);
	}

	// Token: 0x06005D1A RID: 23834 RVA: 0x001767E0 File Offset: 0x001749E0
	public bool CheckIfPioneer()
	{
		string packageId = this.GetPackageId();
		return packageId != null && !(packageId == "") && ConfigBase<CommonConfig>.Instance.GetPioneerPkgIdList().Contains(packageId);
	}

	// Token: 0x06005D1B RID: 23835 RVA: 0x00176818 File Offset: 0x00174A18
	[NullableContext(0)]
	public UniTask<ESdkCommunicationRestricted> GetCommunicationRestrictedAsync([Nullable(2)] string accountId)
	{
		KuroSdkController.<GetCommunicationRestrictedAsync>d__124 <GetCommunicationRestrictedAsync>d__;
		<GetCommunicationRestrictedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<ESdkCommunicationRestricted>.Create();
		<GetCommunicationRestrictedAsync>d__.<>4__this = this;
		<GetCommunicationRestrictedAsync>d__.accountId = accountId;
		<GetCommunicationRestrictedAsync>d__.<>1__state = -1;
		<GetCommunicationRestrictedAsync>d__.<>t__builder.Start<KuroSdkController.<GetCommunicationRestrictedAsync>d__124>(ref <GetCommunicationRestrictedAsync>d__);
		return <GetCommunicationRestrictedAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06005D1C RID: 23836 RVA: 0x00176864 File Offset: 0x00174A64
	[NullableContext(0)]
	public UniTask<bool> OpenMessageBox([Nullable(1)] string accountId, ESdkMessageBoxMode dialogMode, ESdkMessageBoxType msgType, ESdkPrivilege sdkPrivilege = ESdkPrivilege.Invalid)
	{
		KuroSdkController.<OpenMessageBox>d__125 <OpenMessageBox>d__;
		<OpenMessageBox>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenMessageBox>d__.<>4__this = this;
		<OpenMessageBox>d__.accountId = accountId;
		<OpenMessageBox>d__.dialogMode = dialogMode;
		<OpenMessageBox>d__.msgType = msgType;
		<OpenMessageBox>d__.sdkPrivilege = sdkPrivilege;
		<OpenMessageBox>d__.<>1__state = -1;
		<OpenMessageBox>d__.<>t__builder.Start<KuroSdkController.<OpenMessageBox>d__125>(ref <OpenMessageBox>d__);
		return <OpenMessageBox>d__.<>t__builder.Task;
	}

	// Token: 0x06005D1D RID: 23837 RVA: 0x001768C8 File Offset: 0x00174AC8
	[return: Nullable(new byte[]
	{
		0,
		0,
		1,
		1,
		1
	})]
	public UniTask<ValueTuple<string, string, string>> GetThirdPartyLoginInfoAsync()
	{
		KuroSdkController.<GetThirdPartyLoginInfoAsync>d__126 <GetThirdPartyLoginInfoAsync>d__;
		<GetThirdPartyLoginInfoAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<ValueTuple<string, string, string>>.Create();
		<GetThirdPartyLoginInfoAsync>d__.<>4__this = this;
		<GetThirdPartyLoginInfoAsync>d__.<>1__state = -1;
		<GetThirdPartyLoginInfoAsync>d__.<>t__builder.Start<KuroSdkController.<GetThirdPartyLoginInfoAsync>d__126>(ref <GetThirdPartyLoginInfoAsync>d__);
		return <GetThirdPartyLoginInfoAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06005D1E RID: 23838 RVA: 0x0017690C File Offset: 0x00174B0C
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public UniTask<Dictionary<string, bool>> GetSdkBlockingUser()
	{
		KuroSdkController.<GetSdkBlockingUser>d__127 <GetSdkBlockingUser>d__;
		<GetSdkBlockingUser>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<string, bool>>.Create();
		<GetSdkBlockingUser>d__.<>4__this = this;
		<GetSdkBlockingUser>d__.<>1__state = -1;
		<GetSdkBlockingUser>d__.<>t__builder.Start<KuroSdkController.<GetSdkBlockingUser>d__127>(ref <GetSdkBlockingUser>d__);
		return <GetSdkBlockingUser>d__.<>t__builder.Task;
	}

	// Token: 0x06005D1F RID: 23839 RVA: 0x0017694F File Offset: 0x00174B4F
	public void SetPlayOnly(bool state)
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().SetPlayOnly(state);
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.SetPlayOnly(state);
	}

	// Token: 0x06005D20 RID: 23840 RVA: 0x0017697F File Offset: 0x00174B7F
	public bool NeedCheckPlayOnly()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().NeedCheckPlayOnly();
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return platformSdkBase != null && platformSdkBase.NeedCheckPlayOnly();
	}

	// Token: 0x06005D21 RID: 23841 RVA: 0x001769AE File Offset: 0x00174BAE
	public bool GetSdkFriendOnlyState()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetSdkFriendOnlyState();
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return platformSdkBase != null && platformSdkBase.GetSdkFriendOnlyState();
	}

	// Token: 0x06005D22 RID: 23842 RVA: 0x001769DD File Offset: 0x00174BDD
	public bool PlayOnly()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().PlayOnly();
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return platformSdkBase != null && platformSdkBase.PlayOnly();
	}

	// Token: 0x06005D23 RID: 23843 RVA: 0x00176A0C File Offset: 0x00174C0C
	public void SaveSdkFriendOnlyState(bool state)
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().SaveSdkFriendOnlyState(state);
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.SaveSdkFriendOnlyState(state);
	}

	// Token: 0x06005D24 RID: 23844 RVA: 0x00176A3C File Offset: 0x00174C3C
	public bool SupportSwitchFriendShowType()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().SupportSwitchFriendShowType();
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return platformSdkBase != null && platformSdkBase.SupportSwitchFriendShowType();
	}

	// Token: 0x06005D25 RID: 23845 RVA: 0x00176A6B File Offset: 0x00174C6B
	public bool NeedShowThirdPartyId()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().NeedShowThirdPartyId();
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return platformSdkBase != null && platformSdkBase.NeedShowThirdPartyId();
	}

	// Token: 0x06005D26 RID: 23846 RVA: 0x00176A9C File Offset: 0x00174C9C
	public string CreatePlayerSession(int? id)
	{
		if (!Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return "-1";
		}
		EPlayStationJoinAble gameJoinTypeToPlayStationJoinType = ModelBase<OnlineModel>.Instance.GetGameJoinTypeToPlayStationJoinType();
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk == null)
		{
			return null;
		}
		return platformSdk.CreatePlayerSession((int)gameJoinTypeToPlayStationJoinType, id.GetValueOrDefault());
	}

	// Token: 0x06005D27 RID: 23847 RVA: 0x00176AE3 File Offset: 0x00174CE3
	public void JoinPlayerSession(string playerSession)
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
			if (platformSdk == null)
			{
				return;
			}
			platformSdk.JoinPlayerSession(playerSession);
		}
	}

	// Token: 0x06005D28 RID: 23848 RVA: 0x00176B06 File Offset: 0x00174D06
	public void SetMultiPlayerActivity(int currentPlayerCount, int maxPlayerCount, string playerSession, EXboxMultiplayerActivityJoinRestriction restriction)
	{
		if (!Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
			if (platformSdkBase == null)
			{
				return;
			}
			platformSdkBase.SetMultiPlayerActivity(currentPlayerCount, maxPlayerCount, playerSession, restriction);
		}
	}

	// Token: 0x06005D29 RID: 23849 RVA: 0x00176B29 File Offset: 0x00174D29
	public void LeavePlayerSession()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
			if (platformSdk == null)
			{
				return;
			}
			platformSdk.LeavePlayerSession();
		}
	}

	// Token: 0x06005D2A RID: 23850 RVA: 0x00176B4B File Offset: 0x00174D4B
	public void LeaveMultiPlayerActivity()
	{
		if (!Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
			if (platformSdkBase == null)
			{
				return;
			}
			platformSdkBase.LeaveMultiPlayerActivity();
		}
	}

	// Token: 0x06005D2B RID: 23851 RVA: 0x00176B6C File Offset: 0x00174D6C
	public void GetCommunicationRestricted([Nullable(2)] string accountId, Action<ESdkCommunicationRestricted> callBack)
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetCommunicationRestricted(accountId, callBack);
			return;
		}
		if (this.PlatformSdkBase == null)
		{
			callBack(ESdkCommunicationRestricted.No);
			return;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		callBack((platformSdkBase == null || platformSdkBase.CheckPrivilege(ESdkPrivilege.Communications)) ? ESdkCommunicationRestricted.No : ESdkCommunicationRestricted.Yes);
	}

	// Token: 0x06005D2C RID: 23852 RVA: 0x00176BC8 File Offset: 0x00174DC8
	public bool CheckPrivilege(ESdkPrivilege privilege)
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return true;
		}
		if (this.PlatformSdkBase == null)
		{
			return true;
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return platformSdkBase == null || platformSdkBase.CheckPrivilege(privilege);
	}

	// Token: 0x06005D2D RID: 23853 RVA: 0x00176BF4 File Offset: 0x00174DF4
	public string GetPlayerIdByPlayerSessionId(string playerSession)
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetPlayerIdByPlayerSessionId(playerSession);
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return ((platformSdkBase != null) ? platformSdkBase.GetSessionId(playerSession) : null) ?? "-1";
	}

	// Token: 0x06005D2E RID: 23854 RVA: 0x00176C2F File Offset: 0x00174E2F
	public void OpenProfileCard(string id)
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.OpenProfileCard(id);
	}

	// Token: 0x06005D2F RID: 23855 RVA: 0x00176C42 File Offset: 0x00174E42
	public bool SupportSwitchFriendSearchByThirdPartyId()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().SupportSwitchFriendSearchByThirdPartyId();
		}
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return platformSdkBase != null && platformSdkBase.SupportSwitchFriendSearchByThirdPartyId();
	}

	// Token: 0x06005D30 RID: 23856 RVA: 0x00176C71 File Offset: 0x00174E71
	public void UpdateRecentPlayer(string[] ids)
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.UpdateRecentPlayer(ids);
	}

	// Token: 0x06005D31 RID: 23857 RVA: 0x00176C84 File Offset: 0x00174E84
	public bool CheckIfSingleServerAfterSelect()
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return platformSdkBase != null && platformSdkBase.CheckIfSingleServerAfterSelect();
	}

	// Token: 0x06005D32 RID: 23858 RVA: 0x00176C98 File Offset: 0x00174E98
	[return: Nullable(0)]
	public UniTask<bool> SaveSingleServerRegion(int loginType, string region, string userId, string userName, string token)
	{
		KuroSdkController.<SaveSingleServerRegion>d__147 <SaveSingleServerRegion>d__;
		<SaveSingleServerRegion>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SaveSingleServerRegion>d__.<>4__this = this;
		<SaveSingleServerRegion>d__.loginType = loginType;
		<SaveSingleServerRegion>d__.region = region;
		<SaveSingleServerRegion>d__.userId = userId;
		<SaveSingleServerRegion>d__.userName = userName;
		<SaveSingleServerRegion>d__.token = token;
		<SaveSingleServerRegion>d__.<>1__state = -1;
		<SaveSingleServerRegion>d__.<>t__builder.Start<KuroSdkController.<SaveSingleServerRegion>d__147>(ref <SaveSingleServerRegion>d__);
		return <SaveSingleServerRegion>d__.<>t__builder.Task;
	}

	// Token: 0x06005D33 RID: 23859 RVA: 0x00176D08 File Offset: 0x00174F08
	private UniTask OnLogin(FLoginStruct result)
	{
		KuroSdkController.<OnLogin>d__148 <OnLogin>d__;
		<OnLogin>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnLogin>d__.<>4__this = this;
		<OnLogin>d__.result = result;
		<OnLogin>d__.<>1__state = -1;
		<OnLogin>d__.<>t__builder.Start<KuroSdkController.<OnLogin>d__148>(ref <OnLogin>d__);
		return <OnLogin>d__.<>t__builder.Task;
	}

	// Token: 0x06005D34 RID: 23860 RVA: 0x00176D54 File Offset: 0x00174F54
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<string> QuerySingleServerRegion(ILoginInfo result)
	{
		KuroSdkController.<QuerySingleServerRegion>d__149 <QuerySingleServerRegion>d__;
		<QuerySingleServerRegion>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
		<QuerySingleServerRegion>d__.<>4__this = this;
		<QuerySingleServerRegion>d__.result = result;
		<QuerySingleServerRegion>d__.<>1__state = -1;
		<QuerySingleServerRegion>d__.<>t__builder.Start<KuroSdkController.<QuerySingleServerRegion>d__149>(ref <QuerySingleServerRegion>d__);
		return <QuerySingleServerRegion>d__.<>t__builder.Task;
	}

	// Token: 0x06005D35 RID: 23861 RVA: 0x00176DA0 File Offset: 0x00174FA0
	[NullableContext(0)]
	public UniTask<ESdkCommunicationRestricted> GetUserGeneratedContentRestricted([Nullable(2)] string accountId)
	{
		KuroSdkController.<GetUserGeneratedContentRestricted>d__150 <GetUserGeneratedContentRestricted>d__;
		<GetUserGeneratedContentRestricted>d__.<>t__builder = AsyncUniTaskMethodBuilder<ESdkCommunicationRestricted>.Create();
		<GetUserGeneratedContentRestricted>d__.<>4__this = this;
		<GetUserGeneratedContentRestricted>d__.accountId = accountId;
		<GetUserGeneratedContentRestricted>d__.<>1__state = -1;
		<GetUserGeneratedContentRestricted>d__.<>t__builder.Start<KuroSdkController.<GetUserGeneratedContentRestricted>d__150>(ref <GetUserGeneratedContentRestricted>d__);
		return <GetUserGeneratedContentRestricted>d__.<>t__builder.Task;
	}

	// Token: 0x06005D36 RID: 23862 RVA: 0x00176DEB File Offset: 0x00174FEB
	public void CheckPermission(string id, ESdkPermission permission, Action<bool> callback)
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		if (platformSdkBase == null)
		{
			return;
		}
		platformSdkBase.CheckPermission(id, permission, callback);
	}

	// Token: 0x06005D37 RID: 23863 RVA: 0x00176E00 File Offset: 0x00175000
	public string GetExternalToken()
	{
		PlatformSdkBase platformSdkBase = this.PlatformSdkBase;
		return ((platformSdkBase != null) ? platformSdkBase.GetExternalToken() : null) ?? "";
	}

	// Token: 0x06005D38 RID: 23864 RVA: 0x00176E20 File Offset: 0x00175020
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<string> GetExternalCollectionId()
	{
		KuroSdkController.<GetExternalCollectionId>d__153 <GetExternalCollectionId>d__;
		<GetExternalCollectionId>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
		<GetExternalCollectionId>d__.<>4__this = this;
		<GetExternalCollectionId>d__.<>1__state = -1;
		<GetExternalCollectionId>d__.<>t__builder.Start<KuroSdkController.<GetExternalCollectionId>d__153>(ref <GetExternalCollectionId>d__);
		return <GetExternalCollectionId>d__.<>t__builder.Task;
	}

	// Token: 0x06005D39 RID: 23865 RVA: 0x00176E64 File Offset: 0x00175064
	private void RefreshXboxPlayOnlyState()
	{
		if (Singleton<Info>.Instance.IsXboxPlatform())
		{
			bool flag = this.CheckPrivilege(ESdkPrivilege.CrossPlay);
			this.RequestChangeServerXboxPlayOnlyState(!flag);
		}
	}

	// Token: 0x04002C37 RID: 11319
	private const int GACHATYPE = 1;

	// Token: 0x04002C38 RID: 11320
	private const int PAYDELAY = 10000;

	// Token: 0x04002C39 RID: 11321
	private const int TIMERDELAY = 1000;

	// Token: 0x04002C3A RID: 11322
	private const int CHECKNOTCEREDDOTGAP = 600000;

	// Token: 0x04002C3B RID: 11323
	[Nullable(2)]
	private PlatformSdkBase PlatformSdkBase;

	// Token: 0x04002C3C RID: 11324
	private bool IfGlobalSdk;

	// Token: 0x04002C3D RID: 11325
	private bool CurrentPostViewRedPointState;

	// Token: 0x04002C3E RID: 11326
	public bool IsKick;

	// Token: 0x04002C3F RID: 11327
	[Nullable(2)]
	private FAndroidScreenChangeHandler AndroidScreenChangeDelegate;

	// Token: 0x04002C40 RID: 11328
	[Nullable(2)]
	private FLGUIShowVirtualKeyboard ShowKeyboardDelegate;

	// Token: 0x04002C41 RID: 11329
	[Nullable(2)]
	private TimerHandle WaitPayResponseTimerId;

	// Token: 0x04002C42 RID: 11330
	[Nullable(2)]
	private TimerHandle CheckQueryProductTimerId;

	// Token: 0x04002C43 RID: 11331
	private bool ListenerState;

	// Token: 0x04002C44 RID: 11332
	[Nullable(2)]
	private TimerHandle TickId;

	// Token: 0x04002C45 RID: 11333
	[Nullable(2)]
	private TimerHandle CheckNoticeRedDotTimerId;

	// Token: 0x04002C46 RID: 11334
	private bool TryInitPostWebViewState;

	// Token: 0x04002C47 RID: 11335
	private bool TryInitIntroductionParamState;

	// Token: 0x020072F0 RID: 29424
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04027E44 RID: 163396
		[Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public static Action<string, string> <0>__OnThirdPartyJoinSessionEvent;
	}
}
