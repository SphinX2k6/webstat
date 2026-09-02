using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020020CF RID: 8399
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class LoadingController : UiControllerBase<LoadingController>
{
	// Token: 0x060100C7 RID: 65735 RVA: 0x00468537 File Offset: 0x00466737
	protected override bool OnInit()
	{
		ModelBase<LoadingModel>.Instance.Speed = 25;
		return true;
	}

	// Token: 0x060100C8 RID: 65736 RVA: 0x00468546 File Offset: 0x00466746
	protected override bool OnClear()
	{
		UNavigationSystemV1.SetGameLoadingFlag(GlobalData.GameInstance, false);
		return true;
	}

	// Token: 0x060100C9 RID: 65737 RVA: 0x00468554 File Offset: 0x00466754
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<PushDataCompleteNotify>(ENotifyMessageId.PushDataCompleteNotify, new Action<PushDataCompleteNotify, Net.CallbackStatus>(this.OnPushDataCompleteNotify));
	}

	// Token: 0x060100CA RID: 65738 RVA: 0x0046856F File Offset: 0x0046676F
	private void OnPushDataCompleteNotify(PushDataCompleteNotify notify, Net.CallbackStatus status)
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnLoadingNetDataDone);
	}

	// Token: 0x060100CB RID: 65739 RVA: 0x00468581 File Offset: 0x00466781
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PushDataCompleteNotify);
	}

	// Token: 0x060100CC RID: 65740 RVA: 0x00468590 File Offset: 0x00466790
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
		Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnInstanceChange, new Action<int, int>(this.OnInstanceChange));
	}

	// Token: 0x060100CD RID: 65741 RVA: 0x00468664 File Offset: 0x00466864
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		Singleton<EventSystem>.Instance.Remove(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnInstanceChange, new Action<int, int>(this.OnInstanceChange));
	}

	// Token: 0x060100CE RID: 65742 RVA: 0x00468735 File Offset: 0x00466935
	private void OnWorldDone()
	{
		this.UpdateUidViewShow();
	}

	// Token: 0x060100CF RID: 65743 RVA: 0x0046873D File Offset: 0x0046693D
	private void OnWorldDoneAndCloseLoading()
	{
		this.OnLoadingEnd();
	}

	// Token: 0x060100D0 RID: 65744 RVA: 0x00468745 File Offset: 0x00466945
	private void OnBeforeLoadMap()
	{
		this.OnLoadingStart();
	}

	// Token: 0x060100D1 RID: 65745 RVA: 0x0046874D File Offset: 0x0046694D
	private void OnTeleportStart(bool b)
	{
		this.OnLoadingStart();
	}

	// Token: 0x060100D2 RID: 65746 RVA: 0x00468755 File Offset: 0x00466955
	private void OnTeleportComplete(TeleportContext teleportContext)
	{
		this.OnLoadingEnd();
	}

	// Token: 0x060100D3 RID: 65747 RVA: 0x0046875D File Offset: 0x0046695D
	private void OnInstanceChange(int lastInsId, int newInsId)
	{
		ModelBase<LoadingModel>.Instance.LastInstanceId = lastInsId;
	}

	// Token: 0x060100D4 RID: 65748 RVA: 0x0046876A File Offset: 0x0046696A
	private void OnLoadingStart()
	{
		UNavigationSystemV1.SetGameLoadingFlag(GlobalData.GameInstance, true);
	}

	// Token: 0x060100D5 RID: 65749 RVA: 0x00468777 File Offset: 0x00466977
	private void OnLoadingEnd()
	{
		UNavigationSystemV1.SetGameLoadingFlag(GlobalData.GameInstance, false);
		ModelBase<LoadingModel>.Instance.LastInstanceId = 0;
	}

	// Token: 0x060100D6 RID: 65750 RVA: 0x00468790 File Offset: 0x00466990
	public void UpdateUidViewShow()
	{
		bool isShowUidView = ModelBase<LoadingModel>.Instance.IsShowUidView;
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.UidView) != isShowUidView)
		{
			if (isShowUidView)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.UidView, null, null);
			}
			else
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.UidView, null);
			}
		}
		if ((KuroApplication.IsBuildShipping() && KuroApplication.GetAppReleaseType() == "Product") || UKuroLauncherLibrary.GetAppInternalUseType() == "Marketing")
		{
			return;
		}
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MView, null, null);
		}
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BcView) && Singleton<BaseConfigController>.Instance.GetRptIsOpen())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BcView, null, null);
		}
	}

	// Token: 0x060100D7 RID: 65751 RVA: 0x0046885A File Offset: 0x00466A5A
	private void OnChangeTeam()
	{
		if (!ModelBase<LoadingModel>.Instance.IsLoadingView)
		{
			return;
		}
		this.HandleRoleBuffChangeInLoading();
	}

	// Token: 0x060100D8 RID: 65752 RVA: 0x00468870 File Offset: 0x00466A70
	private UniTask HandleRoleBuffChangeInLoading()
	{
		LoadingController.<HandleRoleBuffChangeInLoading>d__17 <HandleRoleBuffChangeInLoading>d__;
		<HandleRoleBuffChangeInLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HandleRoleBuffChangeInLoading>d__.<>1__state = -1;
		<HandleRoleBuffChangeInLoading>d__.<>t__builder.Start<LoadingController.<HandleRoleBuffChangeInLoading>d__17>(ref <HandleRoleBuffChangeInLoading>d__);
		return <HandleRoleBuffChangeInLoading>d__.<>t__builder.Task;
	}

	// Token: 0x060100D9 RID: 65753 RVA: 0x004688AC File Offset: 0x00466AAC
	public UniTask GameModeOpenLoading(Action<bool> openCallback = null)
	{
		LoadingController.<GameModeOpenLoading>d__18 <GameModeOpenLoading>d__;
		<GameModeOpenLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<GameModeOpenLoading>d__.<>4__this = this;
		<GameModeOpenLoading>d__.openCallback = openCallback;
		<GameModeOpenLoading>d__.<>1__state = -1;
		<GameModeOpenLoading>d__.<>t__builder.Start<LoadingController.<GameModeOpenLoading>d__18>(ref <GameModeOpenLoading>d__);
		return <GameModeOpenLoading>d__.<>t__builder.Task;
	}

	// Token: 0x060100DA RID: 65754 RVA: 0x004688F8 File Offset: 0x00466AF8
	public UniTask GameModeCloseLoading()
	{
		LoadingController.<GameModeCloseLoading>d__19 <GameModeCloseLoading>d__;
		<GameModeCloseLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<GameModeCloseLoading>d__.<>4__this = this;
		<GameModeCloseLoading>d__.<>1__state = -1;
		<GameModeCloseLoading>d__.<>t__builder.Start<LoadingController.<GameModeCloseLoading>d__19>(ref <GameModeCloseLoading>d__);
		return <GameModeCloseLoading>d__.<>t__builder.Task;
	}

	// Token: 0x060100DB RID: 65755 RVA: 0x0046893C File Offset: 0x00466B3C
	public void OpenLoadingView(Action<bool> loadCallback = null, Action<bool> finishCallback = null)
	{
		NormalLoadingViewGlobalData.CreateFirstProgressPromise();
		NormalLoadingViewGlobalData.CreateFinishPromisePromise();
		this.SetProgress(10, null, 1, true, false);
		ModelBase<LoadingModel>.Instance.SetIsLoading(true);
		EUiViewName openLoadingViewName = ModelBase<LoadingModel>.Instance.GetOpenLoadingViewName();
		Action <>9__1;
		Singleton<UiManager>.Instance.OpenView(openLoadingViewName, null, delegate(bool result, int _)
		{
			Action<bool> loadCallback2 = loadCallback;
			if (loadCallback2 != null)
			{
				loadCallback2(result);
			}
			LoadingController <>4__this = this;
			int progress = 10;
			Action reachHandle;
			if ((reachHandle = <>9__1) == null)
			{
				reachHandle = (<>9__1 = delegate()
				{
					NormalLoadingViewGlobalData.FinishFirstProgressPromise();
					Action<bool> finishCallback2 = finishCallback;
					if (finishCallback2 == null)
					{
						return;
					}
					finishCallback2(true);
				});
			}
			<>4__this.SetProgress(progress, reachHandle, 1, false, false);
		});
	}

	// Token: 0x060100DC RID: 65756 RVA: 0x004689A8 File Offset: 0x00466BA8
	public UniTask CloseLoadingView()
	{
		LoadingController.<CloseLoadingView>d__21 <CloseLoadingView>d__;
		<CloseLoadingView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CloseLoadingView>d__.<>4__this = this;
		<CloseLoadingView>d__.<>1__state = -1;
		<CloseLoadingView>d__.<>t__builder.Start<LoadingController.<CloseLoadingView>d__21>(ref <CloseLoadingView>d__);
		return <CloseLoadingView>d__.<>t__builder.Task;
	}

	// Token: 0x060100DD RID: 65757 RVA: 0x004689EB File Offset: 0x00466BEB
	public void OpenFadeLoadingView(TOpenViewCallBack finishCallback = null)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FadeLoadingView, null, finishCallback);
	}

	// Token: 0x060100DE RID: 65758 RVA: 0x004689FE File Offset: 0x00466BFE
	public void CloseFadeLoadingView(Action<bool> finishCallback = null)
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.FadeLoadingView, finishCallback);
	}

	// Token: 0x060100DF RID: 65759 RVA: 0x00468A10 File Offset: 0x00466C10
	public void OpenVideoCenterView(TOpenViewCallBack finishCallback = null, string textKey = null)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PlotTransitionView, textKey, finishCallback);
	}

	// Token: 0x060100E0 RID: 65760 RVA: 0x00468A23 File Offset: 0x00466C23
	public void CloseVideoCenterView(Action<bool> finishCallback = null)
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.PlotTransitionView, finishCallback);
	}

	// Token: 0x060100E1 RID: 65761 RVA: 0x00468A35 File Offset: 0x00466C35
	[NullableContext(1)]
	public void OpenSpecialTransitionView(ISpecialTransitionViewParams @params, [Nullable(2)] TOpenViewCallBack finishCallback)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SpecialTransitionView, @params, finishCallback);
	}

	// Token: 0x060100E2 RID: 65762 RVA: 0x00468A48 File Offset: 0x00466C48
	public void CloseSpecialTransitionView(Action<bool> finishCallback)
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.SpecialTransitionView, finishCallback);
	}

	// Token: 0x060100E3 RID: 65763 RVA: 0x00468A5C File Offset: 0x00466C5C
	public void SetProgress(int progress, Action reachHandle = null, int speedRate = 1, bool reset = false, bool smooth = true)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Loading;
		ELogAuthor author = ELogAuthor.TL;
		string message = "SetProgress";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("progress", progress);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		LoadingModel instance2 = ModelBase<LoadingModel>.Instance;
		if (reachHandle != null)
		{
			instance2.ReachHandleQueue.Push(new ValueTuple<int, Action>(progress, reachHandle));
		}
		if (reset)
		{
			instance2.CurrentProgress = 0f;
			instance2.ReachHandleQueue.Clear();
		}
		instance2.SpeedRate = speedRate;
		instance2.NextProgress = progress;
		instance2.NextProgress = Math.Min(instance2.NextProgress, 100);
		if (!smooth)
		{
			instance2.CurrentProgress = (float)progress;
		}
	}

	// Token: 0x060100E4 RID: 65764 RVA: 0x00468AF8 File Offset: 0x00466CF8
	public unsafe void AddProgress(float progress, int maxProgress)
	{
		LoadingModel instance = ModelBase<LoadingModel>.Instance;
		instance.NextProgress = (int)Math.Min((float)instance.NextProgress + progress, (float)maxProgress);
		instance.NextProgress = Math.Min(instance.NextProgress, 100);
		while (instance.ReachHandleQueue.Size > 0)
		{
			ValueTuple<int, Action> front = instance.ReachHandleQueue.Front;
			if ((float)front.Item1 > instance.CurrentProgress)
			{
				break;
			}
			instance.ReachHandleQueue.Pop();
			front.Item2();
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Loading;
			ELogAuthor author = ELogAuthor.TL;
			string message = "AddProgress";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("progress", progress);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("maxProgress", maxProgress);
			instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x060100E5 RID: 65765 RVA: 0x00468BE0 File Offset: 0x00466DE0
	[NullableContext(0)]
	public UniTask<bool> RequestLoadingConfigAsync()
	{
		LoadingController.<RequestLoadingConfigAsync>d__30 <RequestLoadingConfigAsync>d__;
		<RequestLoadingConfigAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestLoadingConfigAsync>d__.<>1__state = -1;
		<RequestLoadingConfigAsync>d__.<>t__builder.Start<LoadingController.<RequestLoadingConfigAsync>d__30>(ref <RequestLoadingConfigAsync>d__);
		return <RequestLoadingConfigAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0200844D RID: 33869
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402CD50 RID: 183632
		[Nullable(0)]
		public static Action <0>__FinishEndPromise;
	}
}
