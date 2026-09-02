using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FF5 RID: 4085
[NullableContext(2)]
[Nullable(0)]
public class ActivityGamePlayPlotView : UiTickViewBase, ISimulatePlot
{
	// Token: 0x060069A6 RID: 27046 RVA: 0x001B83C4 File Offset: 0x001B65C4
	[NullableContext(1)]
	public ActivityGamePlayPlotView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x1700082F RID: 2095
	// (get) Token: 0x060069A7 RID: 27047 RVA: 0x001B8432 File Offset: 0x001B6632
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public PlotOptionItem[] Options
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			PlotTextCommonLogic commonLogic = this.CommonLogic;
			if (commonLogic == null)
			{
				return null;
			}
			return commonLogic.Options;
		}
	}

	// Token: 0x17000830 RID: 2096
	// (get) Token: 0x060069A8 RID: 27048 RVA: 0x001B8445 File Offset: 0x001B6645
	public ITalkItem CurrentSubtitle
	{
		get
		{
			return this.CommonLogic.CurrentContent;
		}
	}

	// Token: 0x17000831 RID: 2097
	// (get) Token: 0x060069A9 RID: 27049 RVA: 0x001B8452 File Offset: 0x001B6652
	public bool HasOptions
	{
		get
		{
			return this.CurrentSubtitle != null && this.CurrentSubtitle.Options != null && this.CurrentSubtitle.Options.Count != 0;
		}
	}

	// Token: 0x060069AA RID: 27050 RVA: 0x001B8480 File Offset: 0x001B6680
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUISprite)),
			new ValueTuple<int, Type>(16, typeof(UUITexture)),
			new ValueTuple<int, Type>(17, typeof(UUITexture)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUITexture)),
			new ValueTuple<int, Type>(20, typeof(UUISprite)),
			new ValueTuple<int, Type>(21, typeof(UUIScrollViewComponent)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(28, typeof(UUIItem))
		};
	}

	// Token: 0x060069AB RID: 27051 RVA: 0x001B872C File Offset: 0x001B692C
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(28));
		UUIButtonComponent closeBtn = this.CaptionItem.GetCloseBtn();
		PlotConfig plotConfig = ModelBase<PlotModel>.Instance.PlotConfig;
		if (plotConfig.ActivityGamePlayPlotConfig != null)
		{
			ActivityGamePlayPlot? config = ConfigActivityGamePlayPlotById.GetConfig(plotConfig.ActivityGamePlayPlotConfig.Value, true);
			if (config != null && config.Value.NeedClose)
			{
				this.SkipComp = new PlotSkipComponent(closeBtn, this.OnSkip, this.OnSkipPop, null, this.OnSkipCancel, null, null);
			}
		}
		UUIScrollViewComponent scrollView = base.GetScrollView(21);
		if (scrollView != null)
		{
			scrollView.SetCanScroll(false);
		}
		if (scrollView != null)
		{
			scrollView.SetRayCastTargetForScrollView(false);
		}
		this.CommonLogic = new PlotTextCommonLogic(base.GetItem(1), base.GetText(2), base.GetText(12), base.GetText(3), base.GetItem(9), scrollView, this, base.GetLayoutBase(5), base.GetItem(4), base.GetSlider(27), this.UiViewSequence, base.GetItem(26), base.GetItem(22), null, null, null, null, null, null, null);
		this.CommonLogic.SetPlotContentAnimFinishCallback(new Action(this.HandleSubtitleAnimFinished));
		this.SkipSubtitleTipItem = base.GetItem(13);
		this.SkipSubtitleTipItemActive(false);
		this.ShowWaitingPoint(false);
		this.UpdateByPlotConfig();
		this.AddScreenEffectPlotRoot();
		this.FadeTimePhoto = 0;
		this.FadeTimeBlackScreen = 0;
		this.BgWidget = base.GetTexture(16);
		if (this.BgWidget != null)
		{
			this.BgWidget.SetAlpha(0f);
		}
		this.BgWidgetFront = base.GetTexture(17);
		if (this.BgWidgetFront != null)
		{
			this.BgWidgetFront.SetAlpha(0f);
		}
		this.WidgetMiddle = base.GetTexture(19);
		if (this.WidgetMiddle != null)
		{
			this.WidgetMiddle.SetAlpha(0f);
		}
		this.BgWidgetMiddle = base.GetSprite(20);
		if (this.BgWidgetMiddle != null)
		{
			this.BgWidgetMiddle.SetUIActive(false);
		}
		this.BlackBgWidget = base.GetSprite(15);
		if (this.BlackBgWidget != null)
		{
			this.BlackBgWidget.SetAlpha(0f);
		}
		this.IsVisible = true;
	}

	// Token: 0x060069AC RID: 27052 RVA: 0x001B8961 File Offset: 0x001B6B61
	private void ShowBlackBg(bool isShow)
	{
		if (isShow == this.IsShowBlackBg)
		{
			return;
		}
		this.IsShowBlackBg = isShow;
		base.PlaySequence(isShow ? "PlotStart" : "PlotClose", null, false);
	}

	// Token: 0x060069AD RID: 27053 RVA: 0x001B898C File Offset: 0x001B6B8C
	protected override UniTask OnPlayingStartSequenceAsync()
	{
		ActivityGamePlayPlotView.<OnPlayingStartSequenceAsync>d__50 <OnPlayingStartSequenceAsync>d__;
		<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingStartSequenceAsync>d__.<>4__this = this;
		<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
		<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<ActivityGamePlayPlotView.<OnPlayingStartSequenceAsync>d__50>(ref <OnPlayingStartSequenceAsync>d__);
		return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060069AE RID: 27054 RVA: 0x001B89D0 File Offset: 0x001B6BD0
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		ActivityGamePlayPlotView.<OnPlayingCloseSequenceAsync>d__51 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<ActivityGamePlayPlotView.<OnPlayingCloseSequenceAsync>d__51>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060069AF RID: 27055 RVA: 0x001B8A13 File Offset: 0x001B6C13
	protected override void OnAfterShow()
	{
		Singleton<EventSystem>.Instance.Emit<EUiViewName, bool>(EEventName.PlotViewChange, this.ViewInfo.Name, true);
	}

	// Token: 0x060069B0 RID: 27056 RVA: 0x001B8A34 File Offset: 0x001B6C34
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Emit<EUiViewName, bool>(EEventName.PlotViewChange, this.ViewInfo.Name, false);
		ModelBase<PlotModel>.Instance.OptionEnable = true;
		base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI", this.BgWidget, null, null);
		base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI", this.BgWidgetFront, null, null);
		base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI", this.WidgetMiddle, null, null);
		this.IsAlreadyHavePhoto = false;
		this.FadeTimePhoto = 0;
		this.FadeTimeBlackScreen = 0;
		this.RemoveTickPhoto();
		this.RemoveTickBlackScreen();
		this.CommonLogic.OnBeforeHide();
		this.ClearPlotView();
		TimerHandle startDelayTimer = this.StartDelayTimer;
		if (startDelayTimer != null)
		{
			startDelayTimer.Remove();
		}
		this.StartDelayTimer = null;
		base.GetItem(26).SetUIActive(false);
		this.CloseChildView().Forget();
	}

	// Token: 0x060069B1 RID: 27057 RVA: 0x001B8B27 File Offset: 0x001B6D27
	protected override void OnBeforeDestroy()
	{
		this.CommonLogic.Clear();
		this.RemoveScreenEffectPlotRoot();
		this.InteractController = null;
		this.PlotFadeShowPromise = null;
		this.PlotFadeHidePromise = null;
		PlotSkipComponent skipComp = this.SkipComp;
		if (skipComp != null)
		{
			skipComp.OnClear();
		}
		this.SkipComp = null;
	}

	// Token: 0x060069B2 RID: 27058 RVA: 0x001B8B68 File Offset: 0x001B6D68
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PlotConfigChanged, new Action(this.UpdateByPlotConfig));
		Singleton<EventSystem>.Instance.Add<ITalkItem>(EEventName.UpdatePlotSubtitle, new Action<ITalkItem>(this.UpdateSeqSubtitle));
		Singleton<EventSystem>.Instance.Add(EEventName.ShowPlotSubtitleOptions, new Action(this.ShowOptions));
		Singleton<EventSystem>.Instance.Add<SetHeadIconVisible, Action>(EEventName.UpdatePortraitVisible, new Action<SetHeadIconVisible, Action>(this.HandlePortraitVisible));
		Singleton<EventSystem>.Instance.Add(EEventName.ClearPlotSubtitle, new Action(this.ClearPlotSubtitle));
		Singleton<EventSystem>.Instance.Add<PawnInteractController>(EEventName.TriggerPlotInteraction, new Action<PawnInteractController>(this.TriggerPlotInteraction));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.HidePlotUi, new Action<bool>(this.HideAll));
		Singleton<EventSystem>.Instance.Add<bool, FKey>(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
		Singleton<EventSystem>.Instance.Add<bool, bool, string, Action>(EEventName.PlotViewBgFadePhoto, new Action<bool, bool, string, Action>(this.OnPlotViewBgFadePhoto));
		Singleton<EventSystem>.Instance.Add<bool, Action>(EEventName.PlotViewBgFadeBlackScreen, new Action<bool, Action>(this.OnPlotViewBgFadeBlackScreen));
		Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerPlotForward, new Action<float>(this.OnNavigationTriggerPlotForward));
		Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerPlotRight, new Action<float>(this.OnNavigationTriggerPlotRight));
		Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerPlotZoom, new Action<float>(this.OnNavigationTriggerPlotZoom));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		PlotSkipComponent skipComp = this.SkipComp;
		if (skipComp != null)
		{
			skipComp.AddEventListener();
		}
		ControllerBase<InputDistributeController>.Instance.BindTouch(0, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouchPlotVisible));
		UUIDraggableComponent uuidraggableComponent = base.GetButton(0).RootUIComp.Get().GetOwner().GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent;
		if (uuidraggableComponent != null)
		{
			uuidraggableComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDragCallBack));
			uuidraggableComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallBack));
			uuidraggableComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndDragCallBack));
			uuidraggableComponent.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnBtnSubtitleSkipClick));
			uuidraggableComponent.OnPointerScrollCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerScrollCallBack));
		}
		UUIItem item = base.GetItem(1);
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlink(base.GetText(3), ETermExplanationViewType.Center, ETermExplanationReportType.Plot, ETermExplanationViewAttachDirection.Up, item, null, null, ETermExplanationGroup.Default, 0, ETermExplanationViewStyle.Default);
	}

	// Token: 0x060069B3 RID: 27059 RVA: 0x001B8E0C File Offset: 0x001B700C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotConfigChanged, new Action(this.UpdateByPlotConfig));
		Singleton<EventSystem>.Instance.Remove<ITalkItem>(EEventName.UpdatePlotSubtitle, new Action<ITalkItem>(this.UpdateSeqSubtitle));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShowPlotSubtitleOptions, new Action(this.ShowOptions));
		Singleton<EventSystem>.Instance.Remove<SetHeadIconVisible, Action>(EEventName.UpdatePortraitVisible, new Action<SetHeadIconVisible, Action>(this.HandlePortraitVisible));
		Singleton<EventSystem>.Instance.Remove(EEventName.ClearPlotSubtitle, new Action(this.ClearPlotSubtitle));
		Singleton<EventSystem>.Instance.Remove<PawnInteractController>(EEventName.TriggerPlotInteraction, new Action<PawnInteractController>(this.TriggerPlotInteraction));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.HidePlotUi, new Action<bool>(this.HideAll));
		Singleton<EventSystem>.Instance.Remove<bool, FKey>(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
		Singleton<EventSystem>.Instance.Remove<bool, bool, string, Action>(EEventName.PlotViewBgFadePhoto, new Action<bool, bool, string, Action>(this.OnPlotViewBgFadePhoto));
		Singleton<EventSystem>.Instance.Remove<bool, Action>(EEventName.PlotViewBgFadeBlackScreen, new Action<bool, Action>(this.OnPlotViewBgFadeBlackScreen));
		Singleton<EventSystem>.Instance.Remove<float>(EEventName.NavigationTriggerPlotForward, new Action<float>(this.OnNavigationTriggerPlotForward));
		Singleton<EventSystem>.Instance.Remove<float>(EEventName.NavigationTriggerPlotRight, new Action<float>(this.OnNavigationTriggerPlotRight));
		Singleton<EventSystem>.Instance.Remove<float>(EEventName.NavigationTriggerPlotZoom, new Action<float>(this.OnNavigationTriggerPlotZoom));
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		PlotSkipComponent skipComp = this.SkipComp;
		if (skipComp != null)
		{
			skipComp.RemoveEventListener();
		}
		ControllerBase<InputDistributeController>.Instance.UnBindTouch(0, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouchPlotVisible));
		UUIDraggableComponent uuidraggableComponent = base.GetButton(0).RootUIComp.Get().GetOwner().GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent;
		if (uuidraggableComponent != null)
		{
			uuidraggableComponent.OnPointerBeginDragCallBack.Unbind();
			uuidraggableComponent.OnPointerDragCallBack.Unbind();
			uuidraggableComponent.OnPointerEndDragCallBack.Unbind();
			uuidraggableComponent.OnPointerUpCallBack.Unbind();
			uuidraggableComponent.OnPointerScrollCallBack.Unbind();
		}
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(3));
	}

	// Token: 0x060069B4 RID: 27060 RVA: 0x001B9057 File Offset: 0x001B7257
	private void OnNavigationTriggerPlotForward(float value)
	{
		ControllerBase<InputController>.Instance.InputAxis(EInputAxis.LookUp, value, true);
	}

	// Token: 0x060069B5 RID: 27061 RVA: 0x001B906A File Offset: 0x001B726A
	private void OnNavigationTriggerPlotRight(float value)
	{
		ControllerBase<InputController>.Instance.InputAxis(EInputAxis.Turn, value, true);
	}

	// Token: 0x060069B6 RID: 27062 RVA: 0x001B9080 File Offset: 0x001B7280
	private void OnNavigationTriggerPlotZoom(float value)
	{
		if (Singleton<MathUtils>.Instance.IsNearlyZero((double)value, null))
		{
			return;
		}
		float num = value * 1.2f;
		ControllerBase<InputController>.Instance.InputAxis(EInputAxis.Zoom, -num, true);
	}

	// Token: 0x060069B7 RID: 27063 RVA: 0x001B90BF File Offset: 0x001B72BF
	private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!ModelBase<PlotModel>.Instance.CanControlView)
		{
			return;
		}
		this.CurrentDragPosition = new FVector?(eventData.GetLocalPointInPlane());
	}

	// Token: 0x060069B8 RID: 27064 RVA: 0x001B90E0 File Offset: 0x001B72E0
	private void OnPointerScrollCallBack(ULGUIPointerEventData eventData)
	{
		if (!ModelBase<PlotModel>.Instance.CanControlView)
		{
			return;
		}
		if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
		{
			this.CurrentDragPosition = null;
			return;
		}
		float value = eventData.scrollAxisValue * 1.2f;
		ControllerBase<InputController>.Instance.InputAxis(EInputAxis.Zoom, value, true);
	}

	// Token: 0x060069B9 RID: 27065 RVA: 0x001B9134 File Offset: 0x001B7334
	private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!ModelBase<PlotModel>.Instance.CanControlView)
		{
			return;
		}
		if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
		{
			this.CurrentDragPosition = null;
			return;
		}
		FVector? currentDragPosition = this.CurrentDragPosition;
		this.CurrentDragPosition = new FVector?(eventData.GetLocalPointInPlane());
		if (currentDragPosition == null)
		{
			return;
		}
		float num = (this.CurrentDragPosition.Value.Y - currentDragPosition.Value.Y) * 0.03f;
		float value = (this.CurrentDragPosition.Value.X - currentDragPosition.Value.X) * 0.06f;
		ControllerBase<InputController>.Instance.InputAxis(EInputAxis.Turn, value, true);
		ControllerBase<InputController>.Instance.InputAxis(EInputAxis.LookUp, -num, true);
	}

	// Token: 0x060069BA RID: 27066 RVA: 0x001B91F5 File Offset: 0x001B73F5
	private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!ModelBase<PlotModel>.Instance.CanControlView)
		{
			return;
		}
		this.CurrentDragPosition = null;
	}

	// Token: 0x060069BB RID: 27067 RVA: 0x001B9210 File Offset: 0x001B7410
	protected override void OnTick(float delta)
	{
		if (this.TickPhotoFade)
		{
			this.OnFadeTickPhoto(delta);
		}
		if (this.TickBlackScreenFade)
		{
			this.OnFadeTickBlackScreen(delta);
		}
		this.CommonLogic.OnTick(delta);
	}

	// Token: 0x060069BC RID: 27068 RVA: 0x001B923C File Offset: 0x001B743C
	public void SimulateClickSubtitle()
	{
		if (Singleton<Info>.Instance.IsBuildShipping)
		{
			return;
		}
		this.OnBtnSubtitleSkipClick(null);
	}

	// Token: 0x060069BD RID: 27069 RVA: 0x001B9254 File Offset: 0x001B7454
	public void SimulateClickOption()
	{
		if (Singleton<Info>.Instance.IsBuildShipping)
		{
			return;
		}
		if (this.Options == null)
		{
			return;
		}
		for (int i = this.Options.Length - 1; i >= 0; i--)
		{
			PlotOptionItem plotOptionItem = this.Options[i];
			if (!plotOptionItem.CheckToggleGray())
			{
				plotOptionItem.OptionClick(new bool?(true));
			}
		}
	}

	// Token: 0x060069BE RID: 27070 RVA: 0x001B92AC File Offset: 0x001B74AC
	private void UpdateCaptionData()
	{
		PlotConfig plotConfig = ModelBase<PlotModel>.Instance.PlotConfig;
		if (plotConfig.ActivityGamePlayPlotConfig == null)
		{
			return;
		}
		ActivityGamePlayPlot? config = ConfigActivityGamePlayPlotById.GetConfig(plotConfig.ActivityGamePlayPlotConfig.Value, true);
		if (config == null)
		{
			return;
		}
		this.CaptionItem.SetTitleByTextIdAndArgNew(config.Value.Name, Array.Empty<object>());
		this.CaptionItem.SetTitleIcon(config.Value.Icon);
		this.CaptionItem.SetHelpBtnActive(config.Value.HelpId != 0);
		if (config.Value.HelpId != 0)
		{
			this.CaptionItem.SetHelpCallBack(delegate
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(config.Value.HelpId);
			});
		}
		this.CaptionItem.SetCloseBtnActive(config.Value.NeedClose);
	}

	// Token: 0x060069BF RID: 27071 RVA: 0x001B93AC File Offset: 0x001B75AC
	private void UpdateByPlotConfig()
	{
		this.ClearOptions();
		this.UpdateCaptionData();
		base.GetButton(0).RootUIComp.Get().SetUIActive(true);
		this.IsShowBlackBg = true;
		base.GetSprite(7).SetUIActive(this.IsShowBlackBg);
	}

	// Token: 0x060069C0 RID: 27072 RVA: 0x001B93F8 File Offset: 0x001B75F8
	[NullableContext(1)]
	private void UpdateSeqSubtitle(ITalkItem inPlotSubtitleInfo)
	{
		this.RemoveDelayTimer();
		this.CanJumpToNextTalk = false;
		TimerHandle startDelayTimer = this.StartDelayTimer;
		if (startDelayTimer != null)
		{
			startDelayTimer.Remove();
		}
		this.StartDelayTimer = null;
		ICaptionParam captionParams = inPlotSubtitleInfo.CaptionParams;
		float num = ((captionParams != null) ? captionParams.StartTime : null).GetValueOrDefault() * 1000f;
		bool flag = false;
		if (inPlotSubtitleInfo.Type.GetValueOrDefault() == ETalkItemType.SystemOption)
		{
			ITalkItemSystemOption talkItemSystemOption = inPlotSubtitleInfo as ITalkItemSystemOption;
			flag = (talkItemSystemOption != null && talkItemSystemOption.OptionConfig.KeepPreTalkItem.GetValueOrDefault());
		}
		if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC && num > 20f)
		{
			if (!flag)
			{
				this.ShowBlackBg(false);
			}
			this.ClearOptions();
			this.StartDelayTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.StartDelayTimer = null;
				this.CommonLogic.UpdatePlotSubtitle(inPlotSubtitleInfo);
				if (inPlotSubtitleInfo.Type.GetValueOrDefault() == ETalkItemType.Option || inPlotSubtitleInfo.Type.GetValueOrDefault() == ETalkItemType.SystemOption)
				{
					this.HandleSubtitleActions();
					return;
				}
				this.PlaySubtitle(inPlotSubtitleInfo);
			}, num, null, null, true, 1f);
			return;
		}
		this.CommonLogic.UpdatePlotSubtitle(inPlotSubtitleInfo);
		if (inPlotSubtitleInfo.Type.GetValueOrDefault() == ETalkItemType.Option || inPlotSubtitleInfo.Type.GetValueOrDefault() == ETalkItemType.SystemOption)
		{
			if (!flag)
			{
				this.ShowBlackBg(false);
			}
			this.ClearOptions();
			this.HandleSubtitleActions();
			return;
		}
		this.PlaySubtitle(inPlotSubtitleInfo);
	}

	// Token: 0x060069C1 RID: 27073 RVA: 0x001B9567 File Offset: 0x001B7767
	private void ShowOptions()
	{
		this.CommonLogic.ShowOptions();
	}

	// Token: 0x060069C2 RID: 27074 RVA: 0x001B9574 File Offset: 0x001B7774
	private void ClearOptions()
	{
		this.CommonLogic.ClearOptions();
	}

	// Token: 0x060069C3 RID: 27075 RVA: 0x001B9581 File Offset: 0x001B7781
	private void ShowUiExceptPhoto()
	{
		UUIItem item = base.GetItem(23);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(24);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(true);
	}

	// Token: 0x060069C4 RID: 27076 RVA: 0x001B95AA File Offset: 0x001B77AA
	[NullableContext(1)]
	private void HandlePortraitVisible(SetHeadIconVisible headIconInfo, Action callback)
	{
		this.CommonLogic.HandlePortraitVisible(this.RootItem, headIconInfo, callback);
	}

	// Token: 0x060069C5 RID: 27077 RVA: 0x001B95C0 File Offset: 0x001B77C0
	[NullableContext(1)]
	private void TriggerPlotInteraction(PawnInteractController interactController)
	{
		this.CommonLogic.IsInteraction = true;
		this.InteractController = interactController;
		this.PreTalkItems = ControllerBase<PlotController>.Instance.GetTalkItemsOfFlow(this.InteractController.PreTalkConfigs);
		this.PreTalkIndex = -1;
		if (this.PreTalkItems != null)
		{
			ModelBase<PlotModel>.Instance.FlowListName = this.InteractController.PreTalkConfigs.FlowListName;
			this.PlayNextPreTalk();
			return;
		}
		this.InitInteractOptions();
	}

	// Token: 0x060069C6 RID: 27078 RVA: 0x001B9634 File Offset: 0x001B7834
	[NullableContext(1)]
	private void PlaySubtitle(ITalkItem currentContent)
	{
		this.ClearOptions();
		this.ShowBlackBg(true);
		if (this.CommonLogic.IsInteraction || !ModelBase<PlotModel>.Instance.PlotConfig.CanInteractive)
		{
			this.SkipSubtitleTipItemActive(true);
			this.ShowWaitingPoint(false);
			this.CanJumpToNextTalk = true;
			return;
		}
		float? waitTime = currentContent.WaitTime;
		if (waitTime == null)
		{
			waitTime = new float?(ModelBase<PlotModel>.Instance.PlotGlobalConfig.JumpWaitTime);
			currentContent.WaitTime = waitTime;
		}
		if ((double)waitTime.Value < ModelBase<PlotModel>.Instance.PlotTemplate.MinWaitingTime)
		{
			waitTime = new float?((float)ModelBase<PlotModel>.Instance.PlotTemplate.MinWaitingTime);
			currentContent.WaitTime = waitTime;
		}
		double num = Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)waitTime.Value);
		if (num < 20.0)
		{
			this.SkipSubtitleTipItemActive(true);
			this.ShowWaitingPoint(false);
			this.CanJumpToNextTalk = true;
			return;
		}
		this.SkipSubtitleTipItemActive(false);
		this.ShowWaitingPoint(true);
		this.WaitingSkipTimerId = TimerSystem.Instance.Delay(delegate(float timeId)
		{
			this.ShowWaitingPoint(false);
			this.WaitingSkipTimerId = null;
			this.CanJumpToNextTalk = true;
			if (!this.CommonLogic.IsTextAnimPlaying)
			{
				if (this.HasOptions)
				{
					this.HandleSubtitleActions();
					return;
				}
				if (ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState != EAutoPlayState.Manual)
				{
					this.DelayHandleSubtitleActions();
				}
			}
			this.SkipSubtitleTipItemActive(true);
		}, (float)num, null, null, true, 1f);
	}

	// Token: 0x060069C7 RID: 27079 RVA: 0x001B9750 File Offset: 0x001B7950
	private void HandleSubtitleAnimFinished()
	{
		if (this.CommonLogic.IsInteraction)
		{
			this.DelayHandleSubtitleActions();
			return;
		}
		if (!this.CanJumpToNextTalk)
		{
			return;
		}
		if (this.HasOptions)
		{
			this.SkipSubtitleTipItemActive(false);
			this.HandleSubtitleActions();
			return;
		}
		if (ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState != EAutoPlayState.Manual)
		{
			this.DelayHandleSubtitleActions();
		}
	}

	// Token: 0x060069C8 RID: 27080 RVA: 0x001B97A8 File Offset: 0x001B79A8
	private void DelayHandleSubtitleActions()
	{
		this.RemoveDelayTimer();
		float num = 1f;
		if (this.CommonLogic.IsInteraction)
		{
			num = ModelBase<PlotModel>.Instance.PlotGlobalConfig.EndWaitTimeInteraction;
		}
		else if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC)
		{
			num = ModelBase<PlotModel>.Instance.PlotGlobalConfig.EndWaitTimeLevelC;
		}
		if ((double)num < ModelBase<PlotModel>.Instance.PlotTemplate.MinWaitingTime)
		{
			num = (float)ModelBase<PlotModel>.Instance.PlotTemplate.MinWaitingTime;
		}
		float num2 = num * 1000f;
		TimerSystemInstance instance = TimerSystem.Instance;
		TTimerAction action = delegate(float _)
		{
			this.SkipSubtitleTipItemActive(false);
			this.HandleSubtitleActions();
		};
		float? playDelayTime = this.CommonLogic.PlayDelayTime;
		float num3 = num2;
		this.DelayId = instance.Delay(action, (playDelayTime.GetValueOrDefault() <= num3 & playDelayTime != null) ? num2 : this.CommonLogic.PlayDelayTime.Value, null, null, true, 1f);
	}

	// Token: 0x060069C9 RID: 27081 RVA: 0x001B988F File Offset: 0x001B7A8F
	private void HandleSubtitleActions()
	{
		this.CanJumpToNextTalk = false;
		this.RemoveDelayTimer();
		if (this.CommonLogic.IsInteraction)
		{
			this.PlayNextPreTalk();
			return;
		}
		ControllerBase<FlowController>.Instance.FlowShowTalk.SubmitSubtitle(this.CommonLogic.CurrentContent);
	}

	// Token: 0x060069CA RID: 27082 RVA: 0x001B98CC File Offset: 0x001B7ACC
	private void InitInteractOptions()
	{
		this.CommonLogic.InitInteractOptions();
	}

	// Token: 0x060069CB RID: 27083 RVA: 0x001B98DC File Offset: 0x001B7ADC
	private void PlayNextPreTalk()
	{
		this.PreTalkIndex++;
		if (this.PreTalkItems != null && this.PreTalkIndex < this.PreTalkItems.Count)
		{
			this.CommonLogic.ClearPlotContent(false);
			ITalkItem talkItem = this.PreTalkItems[this.PreTalkIndex];
			this.CommonLogic.PlaySubtitle(talkItem);
			this.PlaySubtitle(talkItem);
			return;
		}
		if (this.PreTalkItems != null && this.PreTalkIndex == this.PreTalkItems.Count)
		{
			this.InitInteractOptions();
		}
	}

	// Token: 0x060069CC RID: 27084 RVA: 0x001B9968 File Offset: 0x001B7B68
	protected unsafe void OnBtnSubtitleSkipClick(ULGUIPointerEventData eventData)
	{
		if (((eventData != null) ? eventData.dragComponent : null) != null && ModelBase<PlotModel>.Instance.CanControlView)
		{
			return;
		}
		if (this.CommonLogic.IsInteraction)
		{
			if (this.PreTalkItems == null || this.PreTalkIndex >= this.PreTalkItems.Count)
			{
				return;
			}
		}
		else if (!ControllerBase<FlowController>.Instance.IsInShowTalk())
		{
			return;
		}
		if (!this.CanJumpToNextTalk)
		{
			if (this.WaitingSkipTimerId != null && this.CommonLogic.SubtitleAnimationTimer == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "当前字幕已显示完全，但等待时间未结束，无法点到下一句";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TalkId", this.CommonLogic.CurrentContent.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("WaitTime", this.CommonLogic.CurrentContent.WaitTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("AnimationTime", this.CommonLogic.GetPlotContentAnimDuration());
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			return;
		}
		if (this.CommonLogic.SubtitleAnimationTimer != null)
		{
			this.CommonLogic.ForceSkipPlotContentAnim();
			return;
		}
		this.SkipSubtitleTipItemActive(false);
		this.HandleSubtitleActions();
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_ia_spl_plot_next");
	}

	// Token: 0x060069CD RID: 27085 RVA: 0x001B9AC5 File Offset: 0x001B7CC5
	private void OnOpenView(EUiViewName viewName, int _)
	{
		if (viewName == EUiViewName.PlotReviewView)
		{
			Singleton<AudioSystem>.Instance.PostEvent("plot_review_enter");
		}
	}

	// Token: 0x060069CE RID: 27086 RVA: 0x001B9AE4 File Offset: 0x001B7CE4
	private void OnCloseView(EUiViewName viewName, int _)
	{
		if (viewName == EUiViewName.PlotReviewView)
		{
			Singleton<AudioSystem>.Instance.PostEvent("plot_review_exit");
			this.IsVisible = true;
			this.ShowUiExceptPhoto();
		}
	}

	// Token: 0x060069CF RID: 27087 RVA: 0x001B9B10 File Offset: 0x001B7D10
	private void SkipSubtitleTipItemActive(bool value)
	{
		ModelBase<PlotModel>.Instance.CanClick = value;
		UUIItem skipSubtitleTipItem = this.SkipSubtitleTipItem;
		if (skipSubtitleTipItem != null)
		{
			skipSubtitleTipItem.SetUIActive(value);
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.NavigationRefreshPlotNextPage, value);
	}

	// Token: 0x060069D0 RID: 27088 RVA: 0x001B9B40 File Offset: 0x001B7D40
	private void ShowWaitingPoint(bool enable)
	{
		base.GetItem(14).SetUIActive(enable);
	}

	// Token: 0x060069D1 RID: 27089 RVA: 0x001B9B50 File Offset: 0x001B7D50
	private void RemoveDelayTimer()
	{
		if (TimerSystem.Instance.Has(this.DelayId))
		{
			TimerSystem.Instance.Remove(this.DelayId);
		}
		this.DelayId = null;
	}

	// Token: 0x060069D2 RID: 27090 RVA: 0x001B9B7C File Offset: 0x001B7D7C
	public void RemoveWaitSkipTimer()
	{
		if (TimerSystem.Instance.Has(this.WaitingSkipTimerId))
		{
			TimerSystem.Instance.Remove(this.WaitingSkipTimerId);
		}
		this.WaitingSkipTimerId = null;
	}

	// Token: 0x060069D3 RID: 27091 RVA: 0x001B9BA8 File Offset: 0x001B7DA8
	private void HideAll(bool isHidden)
	{
		this.RootItem.SetUIActive(!isHidden);
	}

	// Token: 0x060069D4 RID: 27092 RVA: 0x001B9BB9 File Offset: 0x001B7DB9
	[NullableContext(1)]
	private void OnInputAnyKey(bool bPress, FKey _)
	{
		if (!bPress)
		{
			return;
		}
		if (this.IsVisible)
		{
			return;
		}
		this.IsVisible = true;
		this.ShowUiExceptPhoto();
	}

	// Token: 0x060069D5 RID: 27093 RVA: 0x001B9BD5 File Offset: 0x001B7DD5
	[NullableContext(1)]
	private void OnTouchPlotVisible(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification _)
	{
		if (touchData.TouchType != InputDistributeDefine.ETouchType.TouchBegin)
		{
			return;
		}
		if (this.IsVisible)
		{
			return;
		}
		this.IsVisible = true;
		this.ShowUiExceptPhoto();
	}

	// Token: 0x060069D6 RID: 27094 RVA: 0x001B9BF8 File Offset: 0x001B7DF8
	private Number GetCurrentPercentPhoto()
	{
		float rangePct = Singleton<MathUtils>.Instance.GetRangePct(0f, 1000f, this.FadeTimePhoto);
		if (this.IsAlreadyHavePhoto && this.IsFadeInPhoto)
		{
			this.BgWidgetFront.SetAlpha(rangePct);
		}
		else
		{
			if (!this.IsFadeInPhoto && this.BgWidget.GetAlpha() <= 0f)
			{
				return 0;
			}
			this.BgWidget.SetAlpha(rangePct);
		}
		return rangePct;
	}

	// Token: 0x060069D7 RID: 27095 RVA: 0x001B9C78 File Offset: 0x001B7E78
	private Number GetCurrentPercentPhotoMiddle()
	{
		float rangePct = Singleton<MathUtils>.Instance.GetRangePct(0f, 1000f, this.FadeTimePhoto);
		if (!this.IsFadeInPhoto && this.WidgetMiddle.GetAlpha() <= 0f)
		{
			return 0;
		}
		this.WidgetMiddle.SetAlpha(rangePct);
		return rangePct;
	}

	// Token: 0x060069D8 RID: 27096 RVA: 0x001B9CD8 File Offset: 0x001B7ED8
	private void OnFadeTickPhoto(float deltaTime)
	{
		if (this.FadeTimePhoto < 0)
		{
			this.FadeTimePhoto = 0;
		}
		if (this.FadeTimePhoto > 1000)
		{
			this.FadeTimePhoto = 1000;
		}
		if (this.IsFadeInPhoto)
		{
			this.FadeTimePhoto += deltaTime;
			if (this.IsFullPhoto.GetValueOrDefault())
			{
				if (this.GetCurrentPercentPhoto() > 1)
				{
					this.RemoveTickPhoto();
					this.OnCloseEventPhoto();
					return;
				}
			}
			else if (this.GetCurrentPercentPhotoMiddle() > 1)
			{
				this.RemoveTickPhoto();
				this.OnCloseEventPhoto();
				return;
			}
		}
		else
		{
			this.FadeTimePhoto -= deltaTime;
			if (this.IsFullPhoto.GetValueOrDefault())
			{
				if (this.GetCurrentPercentPhoto() <= 0)
				{
					this.RemoveTickPhoto();
					this.OnCloseEventPhoto();
					return;
				}
			}
			else if (this.GetCurrentPercentPhotoMiddle() <= 0)
			{
				this.RemoveTickPhoto();
				this.OnCloseEventPhoto();
			}
		}
	}

	// Token: 0x060069D9 RID: 27097 RVA: 0x001B9E00 File Offset: 0x001B8000
	private void OnCloseEventPhoto()
	{
		if (this.IsFullPhoto.GetValueOrDefault())
		{
			if (this.IsFadeInPhoto && this.PlotFadeHidePromise != null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "Plot图片FadeIn结束", default(ReadOnlySpan<ValueTuple<string, object>>));
				if (this.IsAlreadyHavePhoto)
				{
					this.BgWidget.SetTexture(this.BgWidgetFront.GetTexture());
					this.BgWidgetFront.SetAlpha(0f);
					this.PlotFadeHidePromise.SetResult(true);
					this.PlotFadeHidePromise = null;
				}
				else
				{
					this.PlotFadeHidePromise.SetResult(true);
					this.PlotFadeHidePromise = null;
				}
				this.IsAlreadyHavePhoto = true;
			}
			else if (!this.IsFadeInPhoto && this.PlotFadeShowPromise != null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "Plot图片FadeOut结束", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.PlotFadeShowPromise.SetResult(true);
				this.PlotFadeShowPromise = null;
				base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI", this.BgWidget, null, null);
				this.IsAlreadyHavePhoto = false;
				ControllerBase<PlotController>.Instance.ResetViewControl();
			}
		}
		else if (this.IsFadeInPhoto && this.PlotFadeHidePromise != null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "Plot Middle图片FadeIn结束", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.PlotFadeHidePromise.SetResult(true);
			this.PlotFadeHidePromise = null;
			this.IsAlreadyHavePhoto = true;
		}
		else if (!this.IsFadeInPhoto && this.PlotFadeShowPromise != null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "Plot Middle图片FadeOut结束", default(ReadOnlySpan<ValueTuple<string, object>>));
			UUISprite bgWidgetMiddle = this.BgWidgetMiddle;
			if (bgWidgetMiddle != null)
			{
				bgWidgetMiddle.SetUIActive(false);
			}
			this.PlotFadeShowPromise.SetResult(true);
			this.PlotFadeShowPromise = null;
			base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI", this.WidgetMiddle, null, null);
			this.IsAlreadyHavePhoto = false;
			ControllerBase<PlotController>.Instance.ResetViewControl();
		}
		Action<ITalkItem> plotViewPhotoCallback = this.PlotViewPhotoCallback;
		if (plotViewPhotoCallback == null)
		{
			return;
		}
		plotViewPhotoCallback(this.CurrentSubtitle);
	}

	// Token: 0x060069DA RID: 27098 RVA: 0x001BA014 File Offset: 0x001B8214
	public UniTask FadeInBgPhoto(string path = null, Action<ITalkItem> callback = null)
	{
		ActivityGamePlayPlotView.<FadeInBgPhoto>d__98 <FadeInBgPhoto>d__;
		<FadeInBgPhoto>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FadeInBgPhoto>d__.<>4__this = this;
		<FadeInBgPhoto>d__.path = path;
		<FadeInBgPhoto>d__.callback = callback;
		<FadeInBgPhoto>d__.<>1__state = -1;
		<FadeInBgPhoto>d__.<>t__builder.Start<ActivityGamePlayPlotView.<FadeInBgPhoto>d__98>(ref <FadeInBgPhoto>d__);
		return <FadeInBgPhoto>d__.<>t__builder.Task;
	}

	// Token: 0x060069DB RID: 27099 RVA: 0x001BA068 File Offset: 0x001B8268
	public UniTask FadeOutBgPhoto(Action<ITalkItem> callback = null)
	{
		ActivityGamePlayPlotView.<FadeOutBgPhoto>d__99 <FadeOutBgPhoto>d__;
		<FadeOutBgPhoto>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FadeOutBgPhoto>d__.<>4__this = this;
		<FadeOutBgPhoto>d__.callback = callback;
		<FadeOutBgPhoto>d__.<>1__state = -1;
		<FadeOutBgPhoto>d__.<>t__builder.Start<ActivityGamePlayPlotView.<FadeOutBgPhoto>d__99>(ref <FadeOutBgPhoto>d__);
		return <FadeOutBgPhoto>d__.<>t__builder.Task;
	}

	// Token: 0x060069DC RID: 27100 RVA: 0x001BA0B4 File Offset: 0x001B82B4
	public UniTask FadeInBgPhotoMiddle(string path = null, Action<ITalkItem> callback = null)
	{
		ActivityGamePlayPlotView.<FadeInBgPhotoMiddle>d__100 <FadeInBgPhotoMiddle>d__;
		<FadeInBgPhotoMiddle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FadeInBgPhotoMiddle>d__.<>4__this = this;
		<FadeInBgPhotoMiddle>d__.path = path;
		<FadeInBgPhotoMiddle>d__.callback = callback;
		<FadeInBgPhotoMiddle>d__.<>1__state = -1;
		<FadeInBgPhotoMiddle>d__.<>t__builder.Start<ActivityGamePlayPlotView.<FadeInBgPhotoMiddle>d__100>(ref <FadeInBgPhotoMiddle>d__);
		return <FadeInBgPhotoMiddle>d__.<>t__builder.Task;
	}

	// Token: 0x060069DD RID: 27101 RVA: 0x001BA108 File Offset: 0x001B8308
	public UniTask FadeOutBgPhotoMiddle(Action<ITalkItem> callback = null)
	{
		ActivityGamePlayPlotView.<FadeOutBgPhotoMiddle>d__101 <FadeOutBgPhotoMiddle>d__;
		<FadeOutBgPhotoMiddle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FadeOutBgPhotoMiddle>d__.<>4__this = this;
		<FadeOutBgPhotoMiddle>d__.callback = callback;
		<FadeOutBgPhotoMiddle>d__.<>1__state = -1;
		<FadeOutBgPhotoMiddle>d__.<>t__builder.Start<ActivityGamePlayPlotView.<FadeOutBgPhotoMiddle>d__101>(ref <FadeOutBgPhotoMiddle>d__);
		return <FadeOutBgPhotoMiddle>d__.<>t__builder.Task;
	}

	// Token: 0x060069DE RID: 27102 RVA: 0x001BA153 File Offset: 0x001B8353
	private void AddTickPhoto()
	{
		this.TickPhotoFade = true;
	}

	// Token: 0x060069DF RID: 27103 RVA: 0x001BA15C File Offset: 0x001B835C
	private void RemoveTickPhoto()
	{
		this.TickPhotoFade = false;
	}

	// Token: 0x060069E0 RID: 27104 RVA: 0x001BA165 File Offset: 0x001B8365
	private void AddTickBlackScreen()
	{
		this.TickBlackScreenFade = true;
	}

	// Token: 0x060069E1 RID: 27105 RVA: 0x001BA16E File Offset: 0x001B836E
	private void RemoveTickBlackScreen()
	{
		this.TickBlackScreenFade = false;
	}

	// Token: 0x060069E2 RID: 27106 RVA: 0x001BA178 File Offset: 0x001B8378
	private Number GetCurrentPercentBlackScreen()
	{
		float rangePct = Singleton<MathUtils>.Instance.GetRangePct(0f, 1000f, this.FadeTimeBlackScreen);
		this.BlackBgWidget.SetAlpha(rangePct);
		return rangePct;
	}

	// Token: 0x060069E3 RID: 27107 RVA: 0x001BA1B8 File Offset: 0x001B83B8
	private void OnFadeTickBlackScreen(float deltaTime)
	{
		if (this.FadeTimeBlackScreen < 0)
		{
			this.FadeTimeBlackScreen = 0;
		}
		if (this.FadeTimeBlackScreen > 1000)
		{
			this.FadeTimeBlackScreen = 1000;
		}
		if (this.IsFadeInBlackScreen)
		{
			this.FadeTimeBlackScreen += deltaTime;
			if (this.GetCurrentPercentBlackScreen() > 1)
			{
				this.RemoveTickBlackScreen();
				this.OnCloseEventBlackScreen();
				return;
			}
		}
		else
		{
			this.FadeTimeBlackScreen -= deltaTime;
			if (this.GetCurrentPercentBlackScreen() < 0)
			{
				this.RemoveTickBlackScreen();
				this.OnCloseEventBlackScreen();
			}
		}
	}

	// Token: 0x060069E4 RID: 27108 RVA: 0x001BA280 File Offset: 0x001B8480
	private void OnCloseEventBlackScreen()
	{
		if (this.IsFadeInBlackScreen && this.PlotFadeHidePromise != null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "Plot黑幕FadeIn结束", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.PlotFadeHidePromise.SetResult(true);
			this.PlotFadeHidePromise = null;
		}
		else if (!this.IsFadeInBlackScreen && this.PlotFadeShowPromise != null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "Plot黑幕FadeOut结束", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.PlotFadeShowPromise.SetResult(true);
			this.PlotFadeShowPromise = null;
		}
		Action<ITalkItem> plotViewBlackScreenCallback = this.PlotViewBlackScreenCallback;
		if (plotViewBlackScreenCallback == null)
		{
			return;
		}
		plotViewBlackScreenCallback(this.CurrentSubtitle);
	}

	// Token: 0x060069E5 RID: 27109 RVA: 0x001BA32C File Offset: 0x001B852C
	public UniTask FadeInBgBlackScreen(Action<ITalkItem> callback = null)
	{
		ActivityGamePlayPlotView.<FadeInBgBlackScreen>d__109 <FadeInBgBlackScreen>d__;
		<FadeInBgBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FadeInBgBlackScreen>d__.<>4__this = this;
		<FadeInBgBlackScreen>d__.callback = callback;
		<FadeInBgBlackScreen>d__.<>1__state = -1;
		<FadeInBgBlackScreen>d__.<>t__builder.Start<ActivityGamePlayPlotView.<FadeInBgBlackScreen>d__109>(ref <FadeInBgBlackScreen>d__);
		return <FadeInBgBlackScreen>d__.<>t__builder.Task;
	}

	// Token: 0x060069E6 RID: 27110 RVA: 0x001BA378 File Offset: 0x001B8578
	public UniTask FadeOutBgBlackScreen(Action<ITalkItem> callback = null)
	{
		ActivityGamePlayPlotView.<FadeOutBgBlackScreen>d__110 <FadeOutBgBlackScreen>d__;
		<FadeOutBgBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FadeOutBgBlackScreen>d__.<>4__this = this;
		<FadeOutBgBlackScreen>d__.callback = callback;
		<FadeOutBgBlackScreen>d__.<>1__state = -1;
		<FadeOutBgBlackScreen>d__.<>t__builder.Start<ActivityGamePlayPlotView.<FadeOutBgBlackScreen>d__110>(ref <FadeOutBgBlackScreen>d__);
		return <FadeOutBgBlackScreen>d__.<>t__builder.Task;
	}

	// Token: 0x060069E7 RID: 27111 RVA: 0x001BA3C4 File Offset: 0x001B85C4
	public UniTask OpenChildView(int id, bool isLoop)
	{
		ActivityGamePlayPlotView.<OpenChildView>d__113 <OpenChildView>d__;
		<OpenChildView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenChildView>d__.<>4__this = this;
		<OpenChildView>d__.id = id;
		<OpenChildView>d__.isLoop = isLoop;
		<OpenChildView>d__.<>1__state = -1;
		<OpenChildView>d__.<>t__builder.Start<ActivityGamePlayPlotView.<OpenChildView>d__113>(ref <OpenChildView>d__);
		return <OpenChildView>d__.<>t__builder.Task;
	}

	// Token: 0x060069E8 RID: 27112 RVA: 0x001BA418 File Offset: 0x001B8618
	public UniTask CloseChildView()
	{
		ActivityGamePlayPlotView.<CloseChildView>d__114 <CloseChildView>d__;
		<CloseChildView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CloseChildView>d__.<>4__this = this;
		<CloseChildView>d__.<>1__state = -1;
		<CloseChildView>d__.<>t__builder.Start<ActivityGamePlayPlotView.<CloseChildView>d__114>(ref <CloseChildView>d__);
		return <CloseChildView>d__.<>t__builder.Task;
	}

	// Token: 0x060069E9 RID: 27113 RVA: 0x001BA45C File Offset: 0x001B865C
	public void AddScreenEffectPlotRoot()
	{
		BP_ScreenEffectSystem_C instance = ScreenEffectSystem.GetInstance();
		UUIItem item = base.GetItem(11);
		if (instance == null || !instance.IsValid() || item == null)
		{
			return;
		}
		AUIContainerActor screenEffectPlotRoot = null;
		instance.GetScreenEffectPlotRoot(ref screenEffectPlotRoot);
		this.ScreenEffectPlotRoot = screenEffectPlotRoot;
		if (this.ScreenEffectPlotRoot != null && this.ScreenEffectPlotRoot.IsValid())
		{
			this.ScreenEffectPlotRoot.K2_AttachRootComponentTo(item, default(FName), EAttachLocation.KeepRelativeOffset, true);
		}
	}

	// Token: 0x060069EA RID: 27114 RVA: 0x001BA4C4 File Offset: 0x001B86C4
	public void RemoveScreenEffectPlotRoot()
	{
		if (this.ScreenEffectPlotRoot != null && this.ScreenEffectPlotRoot.IsValid())
		{
			this.ScreenEffectPlotRoot.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
		}
		this.ScreenEffectPlotRoot = null;
	}

	// Token: 0x060069EB RID: 27115 RVA: 0x001BA4F0 File Offset: 0x001B86F0
	private void OnPlotViewBgFadePhoto(bool isFadeIn, bool isFull, string path, Action callback)
	{
		this.DoOnPlotViewBgFadePhoto(isFadeIn, isFull, path, delegate(ITalkItem _)
		{
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		});
	}

	// Token: 0x060069EC RID: 27116 RVA: 0x001BA524 File Offset: 0x001B8724
	private UniTask DoOnPlotViewBgFadePhoto(bool isFadeIn, bool isFull, string path, Action<ITalkItem> callback)
	{
		ActivityGamePlayPlotView.<DoOnPlotViewBgFadePhoto>d__118 <DoOnPlotViewBgFadePhoto>d__;
		<DoOnPlotViewBgFadePhoto>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<DoOnPlotViewBgFadePhoto>d__.<>4__this = this;
		<DoOnPlotViewBgFadePhoto>d__.isFadeIn = isFadeIn;
		<DoOnPlotViewBgFadePhoto>d__.isFull = isFull;
		<DoOnPlotViewBgFadePhoto>d__.path = path;
		<DoOnPlotViewBgFadePhoto>d__.callback = callback;
		<DoOnPlotViewBgFadePhoto>d__.<>1__state = -1;
		<DoOnPlotViewBgFadePhoto>d__.<>t__builder.Start<ActivityGamePlayPlotView.<DoOnPlotViewBgFadePhoto>d__118>(ref <DoOnPlotViewBgFadePhoto>d__);
		return <DoOnPlotViewBgFadePhoto>d__.<>t__builder.Task;
	}

	// Token: 0x060069ED RID: 27117 RVA: 0x001BA588 File Offset: 0x001B8788
	private void OnPlotViewBgFadeBlackScreen(bool isFadeIn, Action callback)
	{
		this.DoOnPlotViewBgFadeBlackScreen(isFadeIn, delegate(ITalkItem _)
		{
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		}).Forget();
	}

	// Token: 0x060069EE RID: 27118 RVA: 0x001BA5BC File Offset: 0x001B87BC
	private UniTask DoOnPlotViewBgFadeBlackScreen(bool isFadeIn, Action<ITalkItem> callback)
	{
		ActivityGamePlayPlotView.<DoOnPlotViewBgFadeBlackScreen>d__120 <DoOnPlotViewBgFadeBlackScreen>d__;
		<DoOnPlotViewBgFadeBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<DoOnPlotViewBgFadeBlackScreen>d__.<>4__this = this;
		<DoOnPlotViewBgFadeBlackScreen>d__.isFadeIn = isFadeIn;
		<DoOnPlotViewBgFadeBlackScreen>d__.callback = callback;
		<DoOnPlotViewBgFadeBlackScreen>d__.<>1__state = -1;
		<DoOnPlotViewBgFadeBlackScreen>d__.<>t__builder.Start<ActivityGamePlayPlotView.<DoOnPlotViewBgFadeBlackScreen>d__120>(ref <DoOnPlotViewBgFadeBlackScreen>d__);
		return <DoOnPlotViewBgFadeBlackScreen>d__.<>t__builder.Task;
	}

	// Token: 0x060069EF RID: 27119 RVA: 0x001BA60F File Offset: 0x001B880F
	private void ClearPlotSubtitle()
	{
		this.ClearPlotView();
		this.CommonLogic.ClearPlotContent(false);
	}

	// Token: 0x060069F0 RID: 27120 RVA: 0x001BA624 File Offset: 0x001B8824
	private void ClearPlotView()
	{
		this.RemoveWaitSkipTimer();
		this.RemoveDelayTimer();
		this.ClearOptions();
		base.GetItem(1).SetUIActive(false);
		base.GetText(2).SetUIActive(false);
		base.GetText(12).SetUIActive(false);
		base.GetItem(9).SetUIActive(false);
	}

	// Token: 0x0400322E RID: 12846
	private const int FADE_TIME = 1000;

	// Token: 0x0400322F RID: 12847
	private const float ROTATE_RATE_X = 0.06f;

	// Token: 0x04003230 RID: 12848
	private const float ROTATE_RATE_Y = 0.03f;

	// Token: 0x04003231 RID: 12849
	private const float ZOOM_RATE = 1.2f;

	// Token: 0x04003232 RID: 12850
	[Nullable(1)]
	private const string DEFAULT_PATH = "/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI";

	// Token: 0x04003233 RID: 12851
	[Nullable(1)]
	private const string CLICK_AUDIO_EVENT = "play_ui_ia_spl_plot_next";

	// Token: 0x04003234 RID: 12852
	[Nullable(1)]
	protected PopupCaptionItem CaptionItem;

	// Token: 0x04003235 RID: 12853
	[Nullable(1)]
	public List<PlotOption> CurOption = new List<PlotOption>();

	// Token: 0x04003236 RID: 12854
	private PlotSkipComponent SkipComp;

	// Token: 0x04003237 RID: 12855
	private TimerHandle DelayId;

	// Token: 0x04003238 RID: 12856
	private TimerHandle WaitingSkipTimerId;

	// Token: 0x04003239 RID: 12857
	public PawnInteractController InteractController;

	// Token: 0x0400323A RID: 12858
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ITalkItem> PreTalkItems;

	// Token: 0x0400323B RID: 12859
	private int PreTalkIndex;

	// Token: 0x0400323C RID: 12860
	private bool CanJumpToNextTalk;

	// Token: 0x0400323D RID: 12861
	private UUIItem SkipSubtitleTipItem;

	// Token: 0x0400323E RID: 12862
	private AUIContainerActor ScreenEffectPlotRoot;

	// Token: 0x0400323F RID: 12863
	private PlotTextCommonLogic CommonLogic;

	// Token: 0x04003240 RID: 12864
	private bool TickBlackScreenFade;

	// Token: 0x04003241 RID: 12865
	private bool TickPhotoFade;

	// Token: 0x04003242 RID: 12866
	private UUITexture BgWidget;

	// Token: 0x04003243 RID: 12867
	private UUITexture BgWidgetFront;

	// Token: 0x04003244 RID: 12868
	private UUITexture WidgetMiddle;

	// Token: 0x04003245 RID: 12869
	private UUISprite BgWidgetMiddle;

	// Token: 0x04003246 RID: 12870
	private UUISprite BlackBgWidget;

	// Token: 0x04003247 RID: 12871
	private CustomPromise<bool> PlotFadeShowPromise;

	// Token: 0x04003248 RID: 12872
	private CustomPromise<bool> PlotFadeHidePromise;

	// Token: 0x04003249 RID: 12873
	private Action<ITalkItem> PlotViewPhotoCallback;

	// Token: 0x0400324A RID: 12874
	private Action<ITalkItem> PlotViewBlackScreenCallback;

	// Token: 0x0400324B RID: 12875
	private Number FadeTimePhoto = 0;

	// Token: 0x0400324C RID: 12876
	private Number FadeTimeBlackScreen = 0;

	// Token: 0x0400324D RID: 12877
	private bool IsFadeInPhoto;

	// Token: 0x0400324E RID: 12878
	private bool IsFadeInBlackScreen;

	// Token: 0x0400324F RID: 12879
	private bool IsVisible = true;

	// Token: 0x04003250 RID: 12880
	private bool IsAlreadyHavePhoto;

	// Token: 0x04003251 RID: 12881
	private bool? IsFullPhoto;

	// Token: 0x04003252 RID: 12882
	private bool IsShowBlackBg;

	// Token: 0x04003253 RID: 12883
	private FVector? CurrentDragPosition;

	// Token: 0x04003254 RID: 12884
	private TimerHandle StartDelayTimer;

	// Token: 0x04003255 RID: 12885
	[Nullable(1)]
	private readonly Action OnSkip = delegate()
	{
		ControllerBase<FlowController>.Instance.BackgroundFlow("UI点击跳过(PlotView)", true, false, false);
	};

	// Token: 0x04003256 RID: 12886
	private readonly Action OnSkipPop;

	// Token: 0x04003257 RID: 12887
	private readonly Action OnSkipCancel;

	// Token: 0x04003258 RID: 12888
	private PlotChildView ChildView;

	// Token: 0x04003259 RID: 12889
	[Nullable(1)]
	private string ChildViewName = "";

	// Token: 0x020073D6 RID: 29654
	[NullableContext(0)]
	private class EPlotChildCom
	{
		// Token: 0x04028139 RID: 164153
		public const int BtnNextPage = 0;

		// Token: 0x0402813A RID: 164154
		public const int PlotText = 1;

		// Token: 0x0402813B RID: 164155
		public const int NPCName = 2;

		// Token: 0x0402813C RID: 164156
		public const int TxtList = 3;

		// Token: 0x0402813D RID: 164157
		public const int OptionItem = 4;

		// Token: 0x0402813E RID: 164158
		public const int OptionLayout = 5;

		// Token: 0x0402813F RID: 164159
		public const int TextList = 6;

		// Token: 0x04028140 RID: 164160
		public const int PlotBg = 7;

		// Token: 0x04028141 RID: 164161
		public const int PlotTextUHD = 8;

		// Token: 0x04028142 RID: 164162
		public const int PanelLine = 9;

		// Token: 0x04028143 RID: 164163
		public const int TxtFloat = 10;

		// Token: 0x04028144 RID: 164164
		public const int ScreenEffect = 11;

		// Token: 0x04028145 RID: 164165
		public const int NPCTitle = 12;

		// Token: 0x04028146 RID: 164166
		public const int NextIcon = 13;

		// Token: 0x04028147 RID: 164167
		public const int WaitingPoint = 14;

		// Token: 0x04028148 RID: 164168
		public const int BlackScreenBg = 15;

		// Token: 0x04028149 RID: 164169
		public const int PhotoScreenBg = 16;

		// Token: 0x0402814A RID: 164170
		public const int PhotoScreenBgFront = 17;

		// Token: 0x0402814B RID: 164171
		public const int DoingText = 18;

		// Token: 0x0402814C RID: 164172
		public const int PhotoScreenMiddle = 19;

		// Token: 0x0402814D RID: 164173
		public const int PhotoScreenBgMiddle = 20;

		// Token: 0x0402814E RID: 164174
		public const int TextScrollView = 21;

		// Token: 0x0402814F RID: 164175
		public const int OptionAdjustItem = 22;

		// Token: 0x04028150 RID: 164176
		public const int PnlBg = 23;

		// Token: 0x04028151 RID: 164177
		public const int PnlInfo = 24;

		// Token: 0x04028152 RID: 164178
		public const int SonUi = 25;

		// Token: 0x04028153 RID: 164179
		public const int BlockOption = 26;

		// Token: 0x04028154 RID: 164180
		public const int OptionLimitBar = 27;

		// Token: 0x04028155 RID: 164181
		public const int Caption = 28;
	}
}
