using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Data.Sequence.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect;
using AkiClient.Game.Aki.Sequence.Manager;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Module.Plot.PlotView.PlotComponent;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.Module.Plot.Sequence.Assistant;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002980 RID: 10624
[NullableContext(2)]
[Nullable(0)]
public class PlotSubtitleView : UiTickViewBase, ISimulatePlot
{
	// Token: 0x06015218 RID: 86552 RVA: 0x005D7C2C File Offset: 0x005D5E2C
	[NullableContext(1)]
	public PlotSubtitleView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015219 RID: 86553 RVA: 0x005D7CD4 File Offset: 0x005D5ED4
	private void ShowBlackBg(bool isShow, bool useAnim = true)
	{
		if (isShow == this.IsBlackBgShow)
		{
			return;
		}
		this.IsBlackBgShow = isShow;
		if (isShow)
		{
			base.GetSprite(9).SetUIActive(true);
			if (useAnim)
			{
				this.UiViewSequence.StopSequenceByKey("PlotClose", false, false);
				base.PlaySequence("PlotStart", null, false);
				return;
			}
		}
		else
		{
			if (useAnim)
			{
				this.UiViewSequence.StopSequenceByKey("PlotStart", false, false);
				base.PlaySequence("PlotClose", null, false);
				return;
			}
			base.GetSprite(9).SetUIActive(false);
		}
	}

	// Token: 0x17001BC7 RID: 7111
	// (get) Token: 0x0601521A RID: 86554 RVA: 0x005D7D57 File Offset: 0x005D5F57
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
			GenericLayout<PlotOptionItem, object> optionLayout = this.OptionLayout;
			List<PlotOptionItem> list = (optionLayout != null) ? optionLayout.GetLayoutItemList() : null;
			if (list == null)
			{
				return null;
			}
			return list.ToArray();
		}
	}

	// Token: 0x17001BC8 RID: 7112
	// (get) Token: 0x0601521B RID: 86555 RVA: 0x005D7D76 File Offset: 0x005D5F76
	public ITalkItem CurrentSubtitle
	{
		get
		{
			SubtitleInfo subtitleInfo = this.SubtitleInfo;
			if (subtitleInfo == null)
			{
				return null;
			}
			return subtitleInfo.CurrentConfig;
		}
	}

	// Token: 0x0601521C RID: 86556 RVA: 0x005D7D8C File Offset: 0x005D5F8C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 53;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(34, typeof(UUISliderComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(37, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(38, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(39, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(40, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(41, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(42, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(43, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(44, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(45, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(46, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(47, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(48, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(49, typeof(UUISliderComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(50, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(51, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(52, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnSubtitleSkipClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnAutoClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(18, new Action(this.OnBtnHideClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(33, new Action(this.OnBtnReviewClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601521D RID: 86557 RVA: 0x005D8560 File Offset: 0x005D6760
	protected override void OnStart()
	{
		base.GetButton(2).RootUIComp.Get().SetUIActive(false);
		this.SkipComp = new PlotSkipComponent(base.GetButton(2), new Action(this.OnSkip), new Action(this.OnSkipPop), null, new Action(this.OnSkipCancel), null, null);
		this.SkipComp.EnableSkipButton(false);
		UUIText text = base.GetText(42);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		base.GetButton(33).RootUIComp.Get().SetUIActive(false);
		this.ReviewComp = new PlotReviewComponent(base.GetButton(33), new Action(this.OnBtnReviewClick));
		this.ReviewComp.EnableReviewButton(false);
		base.GetSprite(21).SetAlpha(0f);
		this.SubtitleInfo = new SubtitleInfo();
		this.OptionLayout = new GenericLayout<PlotOptionItem, object>(base.GetLayoutBase(7), new Func<PlotOptionItem>(this.InitOptionItem), base.GetItem(6).GetOwner() as AUIBaseActor, false, true);
		this.OptionLayout.SetActive(false);
		UUIItem item = base.GetItem(45);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.IsOptionShow = false;
		this.SubtitleAnimation = (base.GetItem(8).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
		this.SubtitleAnimDataComp = (base.GetItem(8).GetOwner().GetComponentByClass(UUIEffectTextAnimation.StaticClass()) as UUIEffectTextAnimation);
		base.GetItem(6).SetUIActive(false);
		base.GetItem(24).SetUIActive(false);
		this.OptionLimitBar = base.GetSlider(34);
		this.AutoSelectTimeBar = base.GetSlider(49);
		this.AutoSelectTimeBar.GetRootComponent().SetUIActive(false);
		this.AutoSelectOptionComponent.Init(new PlotAutoSelectOptionComponentContext
		{
			OptionLimitBar = this.OptionLimitBar,
			AutoSelectTimeBar = this.AutoSelectTimeBar,
			ImportantList = base.GetItem(44),
			ImportantOptionTipsIcon = base.GetTexture(47),
			ImportantOptionTipsText = base.GetText(48),
			GetCurrentContentDelegate = (() => this.CurrentSubtitle),
			GetSelectedOptionDelegate = (() => this.SelectedPlotOptionItem),
			GetOptionItemsDelegate = (() => this.Options),
			GetAudioRemainingTimeDelegate = new Func<float>(this.GetCurrentAudioRemainingTime),
			SelectOptionByIndexDelegate = new Action<int>(this.SelectOptionByIndex),
			SetTextureByPathDelegate = delegate(string path, UUITexture texture)
			{
				base.SetTextureByPath(path, texture, null, null);
			},
			RefreshAutoPlayButtonDelegate = delegate
			{
				this.UpdateAutoPlayButton();
			}
		});
		this.IsBlackBgShow = false;
		base.GetSprite(9).SetUIActive(false);
		this.SkipSubtitleTipItem = base.GetItem(19);
		(base.GetButton(1).RootUIComp.Get().GetOwner().GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent).SetActive(false, false);
		this.SkipSubtitleTipItemActive(false);
		this.ShowWaitingPoint(false);
		this.UpdateByPlotConfig();
		this.IsCurSubtitlePaused = false;
		this.AddScreenEffectPlotRoot();
		this.IsVisible = true;
		this.AudioDelegate.Init(new Action<float>(this.CallBackDuration));
		this.UiViewSequence.AddSequenceFinishEvent("ChoiceClose", new Action<string>(this.OptionsLayoutHide), false);
		UUIScrollViewComponent scrollView = base.GetScrollView(27);
		if (scrollView != null)
		{
			scrollView.SetCanScroll(false);
		}
		if (scrollView != null)
		{
			scrollView.SetRayCastTargetForScrollView(false);
		}
		float? num;
		if (scrollView == null)
		{
			num = null;
		}
		else
		{
			UUIItem uuiitem = scrollView.RootUIComp.Get();
			num = ((uuiitem != null) ? new float?(uuiitem.GetHeight()) : null);
		}
		float? num2 = num;
		this.TextScrollViewPrefabHeight = num2.GetValueOrDefault(174f);
		this.FadeTimePhoto = 0f;
		this.BgWidget = base.GetTexture(22);
		if (this.BgWidget != null)
		{
			this.BgWidget.SetAlpha(0f);
		}
		this.BgWidgetFront = base.GetTexture(23);
		if (this.BgWidgetFront != null)
		{
			this.BgWidgetFront.SetAlpha(0f);
		}
		this.WidgetMiddle = base.GetTexture(25);
		if (this.WidgetMiddle != null)
		{
			this.WidgetMiddle.SetAlpha(0f);
		}
		this.BgWidgetMiddle = base.GetSprite(26);
		if (this.BgWidgetMiddle != null)
		{
			this.BgWidgetMiddle.SetUIActive(false);
		}
		this.SonUi = base.GetItem(31);
		this.FullscreenAdaptAnchor = base.GetItem(43);
		base.GetItem(32).SetUIActive(false);
		this.InitTweenAnim(36);
		this.InitTweenAnim(37);
		this.InitTweenAnim(38);
		this.InitTweenAnim(39);
		this.InitTweenAnim(40);
		this.InitTweenAnim(41);
		this.InitTweenAnim(51);
		this.InitTweenAnim(52);
		UiParam uiParam = this.OpenParam as UiParam;
		if (uiParam != null && uiParam.HideAllUi.GetValueOrDefault())
		{
			this.OnBtnHideClick();
		}
		Queue<PlotChildView> sonUiQueue = this.SonUiQueue;
		if (sonUiQueue != null)
		{
			sonUiQueue.Clear();
		}
		this.SonUiQueue = new Queue<PlotChildView>(4);
		Queue<SpineQueueInfo> spineQueue = this.SpineQueue;
		if (spineQueue != null)
		{
			spineQueue.Clear();
		}
		this.SpineQueue = new Queue<SpineQueueInfo>(4);
	}

	// Token: 0x0601521E RID: 86558 RVA: 0x005D8A8C File Offset: 0x005D6C8C
	[NullableContext(1)]
	private void OptionsLayoutHide(string _)
	{
		if (this.IsOptionShow)
		{
			return;
		}
		this.OptionLayout.SetActive(false);
		UUIItem item = base.GetItem(45);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.OptionLimitBar.GetRootComponent().SetUIActive(false);
		this.AutoSelectTimeBar.GetRootComponent().SetUIActive(false);
	}

	// Token: 0x0601521F RID: 86559 RVA: 0x005D8AE4 File Offset: 0x005D6CE4
	protected void ResetSubtitle()
	{
		UUIScrollViewComponent scrollView = base.GetScrollView(27);
		if (scrollView != null)
		{
			scrollView.SetScrollProgress(0f);
		}
		TimerHandle scrollStartTimer = this.ScrollStartTimer;
		if (scrollStartTimer != null)
		{
			scrollStartTimer.Remove();
		}
		this.ScrollStartTimer = null;
		this.RemoveTextAnimTimer();
		base.GetText(4).SetText("", true);
		base.GetText(4).SetUIActive(false);
		base.GetText(17).SetText("", true);
		base.GetText(17).SetUIActive(false);
		base.GetItem(11).SetUIActive(false);
		base.GetText(5).SetText("", true);
		base.GetText(12).SetText("", true);
		base.GetText(5).SetUIActive(false);
		base.GetText(12).SetUIActive(false);
	}

	// Token: 0x06015220 RID: 86560 RVA: 0x005D8BB6 File Offset: 0x005D6DB6
	protected override void OnAfterShow()
	{
		Singleton<EventSystem>.Instance.Emit<EUiViewName, bool>(EEventName.PlotViewChange, this.ViewInfo.Name, true);
		PlotSkipComponent skipComp = this.SkipComp;
		if (skipComp == null)
		{
			return;
		}
		skipComp.EnableSkipButton(ControllerBase<FlowController>.Instance.IsSkipEnabled());
	}

	// Token: 0x06015221 RID: 86561 RVA: 0x005D8BF0 File Offset: 0x005D6DF0
	protected override UniTask OnPlayingStartSequenceAsync()
	{
		PlotSubtitleView.<OnPlayingStartSequenceAsync>d__82 <OnPlayingStartSequenceAsync>d__;
		<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingStartSequenceAsync>d__.<>4__this = this;
		<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
		<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<PlotSubtitleView.<OnPlayingStartSequenceAsync>d__82>(ref <OnPlayingStartSequenceAsync>d__);
		return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015222 RID: 86562 RVA: 0x005D8C34 File Offset: 0x005D6E34
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Emit<EUiViewName, bool>(EEventName.PlotViewChange, this.ViewInfo.Name, false);
		TimerHandle blockOptionTimer = this.BlockOptionTimer;
		if (blockOptionTimer != null)
		{
			blockOptionTimer.Remove();
		}
		this.BlockOptionTimer = null;
		base.GetItem(32).SetUIActive(false);
		this.AutoSelectOptionComponent.Clear();
		this.ClearPendingImmersiveSleep();
	}

	// Token: 0x06015223 RID: 86563 RVA: 0x005D8C98 File Offset: 0x005D6E98
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		PlotSubtitleView.<OnPlayingCloseSequenceAsync>d__84 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<PlotSubtitleView.<OnPlayingCloseSequenceAsync>d__84>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015224 RID: 86564 RVA: 0x005D8CDC File Offset: 0x005D6EDC
	protected override void OnBeforeDestroy()
	{
		ModelBase<PlotModel>.Instance.OptionEnable = true;
		this.ClearPendingImmersiveSleep();
		this.ClearSizeChangedTimer();
		this.AudioDelegate.Clear();
		PlotSkipComponent skipComp = this.SkipComp;
		if (skipComp != null)
		{
			skipComp.OnClear();
		}
		this.SkipComp = null;
		PlotReviewComponent reviewComp = this.ReviewComp;
		if (reviewComp != null)
		{
			reviewComp.OnClear();
		}
		this.ReviewComp = null;
		this.PlotFadeShowPromise = null;
		this.PlotFadeHidePromise = null;
		base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI", this.BgWidget, null, null);
		base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI", this.BgWidgetFront, null, null);
		base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI", this.WidgetMiddle, null, null);
		this.IsAlreadyHavePhoto = false;
		this.FadeTimePhoto = 0f;
		this.RemoveTickPhoto();
		this.RemoveScreenEffectPlotRoot();
		TimerHandle scrollStartTimer = this.ScrollStartTimer;
		if (scrollStartTimer != null)
		{
			scrollStartTimer.Remove();
		}
		this.ScrollStartTimer = null;
		this.RemoveTextAnimTimer();
		this.AutoSelectOptionComponent.Clear();
		this.CloseTransitionView();
		this.HandleAkEvent(false);
		this.StopCurSubtitleAudio();
		this.RemoveAutoPlayDelay();
		this.StopIndependentAudio();
		this.StopWaitingSkipTimer();
		Dictionary<string, PlotChildView> sonUiIncludeMap = this.SonUiIncludeMap;
		if (sonUiIncludeMap != null)
		{
			sonUiIncludeMap.Clear();
		}
		this.SonUiIncludeMap = null;
		this.SonUiInclude = null;
		Queue<SpineQueueInfo> spineQueue = this.SpineQueue;
		if (spineQueue != null)
		{
			spineQueue.Clear();
		}
		this.SpineQueue = null;
		Queue<PlotChildView> sonUiQueue = this.SonUiQueue;
		if (sonUiQueue != null)
		{
			sonUiQueue.Clear();
		}
		this.SonUiQueue = null;
		this.SonUi = null;
	}

	// Token: 0x06015225 RID: 86565 RVA: 0x005D8E5D File Offset: 0x005D705D
	[NullableContext(1)]
	private PlotOptionItem InitOptionItem()
	{
		PlotOptionItem plotOptionItem = new PlotOptionItem(this);
		plotOptionItem.BindOnHover(new Action<PlotOptionItem>(this.OnPlotOptionItemHover));
		return plotOptionItem;
	}

	// Token: 0x06015226 RID: 86566 RVA: 0x005D8E77 File Offset: 0x005D7077
	[NullableContext(1)]
	private void OnPlotOptionItemHover(PlotOptionItem plotOptionItem)
	{
		PlotOptionItem selectedPlotOptionItem = this.SelectedPlotOptionItem;
		if (selectedPlotOptionItem != null)
		{
			selectedPlotOptionItem.SetSelectedDisplay(false);
		}
		this.SelectedPlotOptionItem = plotOptionItem;
		plotOptionItem.SetSelectedDisplay(true);
		this.AutoSelectOptionComponent.OnSelectedOptionChanged();
	}

	// Token: 0x06015227 RID: 86567 RVA: 0x005D8EA4 File Offset: 0x005D70A4
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

	// Token: 0x06015228 RID: 86568 RVA: 0x005D8ED4 File Offset: 0x005D70D4
	private void ShowWaitingPoint(bool enable)
	{
		base.GetItem(20).SetUIActive(enable);
		if (this.SubtitleLevel.GetValueOrDefault() == EPlotLevel.LevelB)
		{
			ControllerBase<TermExplanationController>.Instance.SetEnableHyperLink(base.GetText(5), !enable);
		}
	}

	// Token: 0x06015229 RID: 86569 RVA: 0x005D8F08 File Offset: 0x005D7108
	private void UpdateByPlotConfig()
	{
		PlotConfig plotConfig = ModelBase<PlotModel>.Instance.PlotConfig;
		bool canPause = plotConfig.CanPause;
		this.CanShowAutoButtonByPlotConfig = canPause;
		this.CanShowHideButtonByPlotConfig = canPause;
		this.CanShowReviewButtonByPlotConfig = canPause;
		this.SubtitleLevel = plotConfig.SubtitleLevel;
		this.Level = plotConfig.PlotLevel;
		base.GetButton(0).RootUIComp.Get().SetUIActive(this.CanShowAutoButtonByPlotConfig);
		base.GetButton(18).RootUIComp.Get().SetUIActive(this.CanShowHideButtonByPlotConfig);
		this.ReviewComp.EnableReviewButton(this.CanShowReviewButtonByPlotConfig);
		base.GetButton(1).RootUIComp.Get().SetUIActive(this.SubtitleLevel.GetValueOrDefault() == EPlotLevel.LevelB);
		this.ClearOptions();
		this.UpdateAutoPlayButton();
		this.ResetSubtitle();
		this.DisableInteractSources.Clear();
		PlotSkipComponent skipComp = this.SkipComp;
		if (skipComp != null)
		{
			skipComp.ClearSkipLock();
		}
		this.RestorePlotButtonsVisibility();
	}

	// Token: 0x0601522A RID: 86570 RVA: 0x005D9000 File Offset: 0x005D7200
	private void UpdateAutoPlayButton()
	{
		PlotConfig plotConfig = ModelBase<PlotModel>.Instance.PlotConfig;
		UUIItem item = base.GetItem(14);
		if (item != null)
		{
			item.SetUIActive(plotConfig.AutoPlayState == EAutoPlayState.Manual);
		}
		UUIItem item2 = base.GetItem(15);
		if (item2 != null)
		{
			item2.SetUIActive(plotConfig.AutoPlayState == EAutoPlayState.SemiAuto);
		}
		UUIItem item3 = base.GetItem(16);
		if (item3 != null)
		{
			item3.SetUIActive(plotConfig.AutoPlayState == EAutoPlayState.Auto);
		}
		this.UpdateAutoSelectText();
	}

	// Token: 0x0601522B RID: 86571 RVA: 0x005D9074 File Offset: 0x005D7274
	private void UpdateAutoSelectText()
	{
		UUIText text = base.GetText(50);
		if (text == null)
		{
			return;
		}
		PlotConfig plotConfig = ModelBase<PlotModel>.Instance.PlotConfig;
		bool flag = Singleton<Info>.Instance.IsInGamepad() && plotConfig.CanPause;
		text.SetUIActive(flag);
		if (!flag)
		{
			return;
		}
		string autoSelectTextKey = this.GetAutoSelectTextKey(plotConfig.AutoPlayState);
		text.SetText(ConfigMultiTextLang.GetLocalTextNew(autoSelectTextKey, null) ?? autoSelectTextKey, true);
	}

	// Token: 0x0601522C RID: 86572 RVA: 0x005D90DA File Offset: 0x005D72DA
	[NullableContext(1)]
	private string GetAutoSelectTextKey(EAutoPlayState autoPlayState)
	{
		switch (autoPlayState)
		{
		case EAutoPlayState.Manual:
			return "HotKeyText_HalfAutoPlot_Name";
		case EAutoPlayState.SemiAuto:
			return "HotKeyText_AutoPlot_Name";
		case EAutoPlayState.Auto:
			return "HotKeyText_CancelAutoPlot_Name";
		default:
			return "HotKeyText_HalfAutoPlot_Name";
		}
	}

	// Token: 0x0601522D RID: 86573 RVA: 0x005D9108 File Offset: 0x005D7308
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PlotConfigChanged, new Action(this.OnPlotConfigChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.ClearPlotSubtitle, new Action(this.ClearPlotSubtitle));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.HidePlotUi, new Action<bool>(this.HideAll));
		Singleton<EventSystem>.Instance.Add<bool, FKey>(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.PlotDoingTextShow, new Action<bool>(this.ShowDoingText));
		Singleton<EventSystem>.Instance.Add<ShowTalk>(EEventName.PlotStartShowTalk, new Action<ShowTalk>(this.OnShowTalkStart));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Add<ETermExplanationViewType>(EEventName.OnTermExplanationViewOpening, new Action<ETermExplanationViewType>(this.OnTermExplanationViewOpen));
		Singleton<EventSystem>.Instance.Add(EEventName.OnTermExplanationViewClosed, new Action(this.OnTermExplanationViewClose));
		Singleton<EventSystem>.Instance.Add<float>(EEventName.PlotSequencePlay, new Action<float>(this.OnSequenceStart));
		Singleton<EventSystem>.Instance.Add<bool, bool?, string, string>(EEventName.EnableInteractPlot, new Action<bool, bool?, string, string>(this.OnEnableInteractPlot));
		Singleton<EventSystem>.Instance.Add<EInputControllerMainType, bool>(EEventName.OnImmersiveInputStateChange, new Action<EInputControllerMainType, bool>(this.OnImmersiveInputStateChange));
		Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		Singleton<EventSystem>.Instance.Add(EEventName.UIViewPortSizeChanged, new Action(this.OnSizeChanged));
		ControllerBase<SequenceController>.Instance.Event.Add(ESequenceEventName.UpdateSeqSubtitle, new Action<PlotSubtitleConfig>(this.UpdateSeqSubtitle));
		ControllerBase<SequenceController>.Instance.Event.Add(ESequenceEventName.HandlePlotOptionSelected, new Action<int>(this.HandleSelectedPlotOption));
		ControllerBase<SequenceController>.Instance.Event.Add(ESequenceEventName.HandleSeqSubtitleEnd, new Action<int, bool>(this.HandleSeqSubtitleEnd));
		ControllerBase<SequenceController>.Instance.Event.Add(ESequenceEventName.HandleSubSequenceStop, new Action(this.HandleSubSequenceStop));
		ControllerBase<SequenceController>.Instance.Event.Add(ESequenceEventName.HandleIndependentSeqAudio, new Action<bool, string, float>(this.HandleIndependentSeqAudio));
		this.SkipComp.AddEventListener();
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.EnableSkipPlot, new Action<bool>(this.OnEnableSkipPlotRestoreTween));
		ControllerBase<InputDistributeController>.Instance.BindTouch(0, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouchPlotVisible));
		UUIItem item = base.GetItem(3);
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlink(base.GetText(5), ETermExplanationViewType.Center, ETermExplanationReportType.Plot, ETermExplanationViewAttachDirection.Up, item, delegate
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TermClickTip", Array.Empty<object>());
		}, null, ETermExplanationGroup.Default, 0, ETermExplanationViewStyle.Default);
	}

	// Token: 0x0601522E RID: 86574 RVA: 0x005D93C8 File Offset: 0x005D75C8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotConfigChanged, new Action(this.OnPlotConfigChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.ClearPlotSubtitle, new Action(this.ClearPlotSubtitle));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.HidePlotUi, new Action<bool>(this.HideAll));
		Singleton<EventSystem>.Instance.Remove<bool, FKey>(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.PlotDoingTextShow, new Action<bool>(this.ShowDoingText));
		Singleton<EventSystem>.Instance.Remove<ShowTalk>(EEventName.PlotStartShowTalk, new Action<ShowTalk>(this.OnShowTalkStart));
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Remove<ETermExplanationViewType>(EEventName.OnTermExplanationViewOpening, new Action<ETermExplanationViewType>(this.OnTermExplanationViewOpen));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTermExplanationViewClosed, new Action(this.OnTermExplanationViewClose));
		Singleton<EventSystem>.Instance.Remove<float>(EEventName.PlotSequencePlay, new Action<float>(this.OnSequenceStart));
		Singleton<EventSystem>.Instance.Remove<bool, bool?, string, string>(EEventName.EnableInteractPlot, new Action<bool, bool?, string, string>(this.OnEnableInteractPlot));
		Singleton<EventSystem>.Instance.Remove<EInputControllerMainType, bool>(EEventName.OnImmersiveInputStateChange, new Action<EInputControllerMainType, bool>(this.OnImmersiveInputStateChange));
		Singleton<EventSystem>.Instance.Remove<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.UIViewPortSizeChanged, new Action(this.OnSizeChanged));
		this.ClearSizeChangedTimer();
		ControllerBase<SequenceController>.Instance.Event.Remove(ESequenceEventName.UpdateSeqSubtitle, new Action<PlotSubtitleConfig>(this.UpdateSeqSubtitle));
		ControllerBase<SequenceController>.Instance.Event.Remove(ESequenceEventName.HandlePlotOptionSelected, new Action<int>(this.HandleSelectedPlotOption));
		ControllerBase<SequenceController>.Instance.Event.Remove(ESequenceEventName.HandleSeqSubtitleEnd, new Action<int, bool>(this.HandleSeqSubtitleEnd));
		ControllerBase<SequenceController>.Instance.Event.Remove(ESequenceEventName.HandleSubSequenceStop, new Action(this.HandleSubSequenceStop));
		ControllerBase<SequenceController>.Instance.Event.Remove(ESequenceEventName.HandleIndependentSeqAudio, new Action<bool, string, float>(this.HandleIndependentSeqAudio));
		this.SkipComp.RemoveEventListener();
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.EnableSkipPlot, new Action<bool>(this.OnEnableSkipPlotRestoreTween));
		ControllerBase<InputDistributeController>.Instance.UnBindTouch(0, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouchPlotVisible));
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(5));
	}

	// Token: 0x0601522F RID: 86575 RVA: 0x005D9658 File Offset: 0x005D7858
	private void OnSizeChanged()
	{
		if (base.IsDestroyOrDestroying)
		{
			return;
		}
		UUIItem rootItem = this.RootItem;
		ULGUICanvas ulguicanvas = (rootItem != null && rootItem.IsValid()) ? rootItem.GetRenderCanvas() : null;
		if (ulguicanvas == null)
		{
			return;
		}
		this.ClearSizeChangedTimer();
		ulguicanvas.bPostTickUpdate = true;
		this.SizeChangedTimerId = TimerSystem.Instance.Next(delegate(float _)
		{
			this.SizeChangedTimerId = null;
			if (base.IsDestroyOrDestroying)
			{
				return;
			}
			UUIItem rootItem2 = this.RootItem;
			ULGUICanvas ulguicanvas2 = (rootItem2 != null && rootItem2.IsValid()) ? rootItem2.GetRenderCanvas() : null;
			if (ulguicanvas2 != null)
			{
				ulguicanvas2.bPostTickUpdate = false;
			}
		}, null, null);
	}

	// Token: 0x06015230 RID: 86576 RVA: 0x005D96BC File Offset: 0x005D78BC
	private void ClearSizeChangedTimer()
	{
		TimerHandle sizeChangedTimerId = this.SizeChangedTimerId;
		if (sizeChangedTimerId != null)
		{
			sizeChangedTimerId.Remove();
		}
		this.SizeChangedTimerId = null;
		UUIItem rootItem = this.RootItem;
		ULGUICanvas ulguicanvas = (rootItem != null && rootItem.IsValid()) ? rootItem.GetRenderCanvas() : null;
		if (ulguicanvas != null)
		{
			ulguicanvas.bPostTickUpdate = false;
		}
	}

	// Token: 0x06015231 RID: 86577 RVA: 0x005D9708 File Offset: 0x005D7908
	private void OnEnableInteractPlot(bool enable, bool? includeSubtitleButton, string reason, string skipLock)
	{
		if (!string.IsNullOrEmpty(skipLock))
		{
			if (enable)
			{
				PlotSkipComponent skipComp = this.SkipComp;
				if (skipComp != null)
				{
					skipComp.UnlockSkipButton(skipLock);
				}
			}
			else
			{
				PlotSkipComponent skipComp2 = this.SkipComp;
				if (skipComp2 != null)
				{
					skipComp2.LockSkipButton(skipLock);
				}
			}
		}
		bool valueOrDefault = includeSubtitleButton.GetValueOrDefault(true);
		string key = string.IsNullOrEmpty(reason) ? "Default" : reason;
		if (enable)
		{
			this.DisableInteractSources.Remove(key);
		}
		else
		{
			this.DisableInteractSources[key] = valueOrDefault;
		}
		this.ApplyInteractPlotState();
	}

	// Token: 0x06015232 RID: 86578 RVA: 0x005D9788 File Offset: 0x005D7988
	private void ApplyInteractPlotState()
	{
		bool flag = this.DisableInteractSources.Count > 0;
		bool flag2 = false;
		foreach (KeyValuePair<string, bool> keyValuePair in this.DisableInteractSources)
		{
			if (keyValuePair.Value)
			{
				flag2 = true;
				break;
			}
		}
		bool flag3 = !flag;
		this.MuteAutoPlay(!flag3);
		base.GetButton(0).RootUIComp.Get().SetUIActive(flag3 && this.CanShowAutoButtonByPlotConfig);
		base.GetButton(18).RootUIComp.Get().SetUIActive(flag3 && this.CanShowHideButtonByPlotConfig);
		this.ReviewComp.EnableReviewButton(flag3 && this.CanShowReviewButtonByPlotConfig);
		this.SkipComp.EnableSkipButton(flag3);
		base.GetButton(1).RootUIComp.Get().SetUIActive(!flag2);
		this.RestorePlotButtonsVisibility();
	}

	// Token: 0x06015233 RID: 86579 RVA: 0x005D9898 File Offset: 0x005D7A98
	private void OnSequenceStart(float viewBlendDuration)
	{
		float num = viewBlendDuration * 1000f;
		if (num > 20f && num < 180000f)
		{
			base.GetButton(0).RootUIComp.Get().SetUIActive(false);
			base.GetButton(18).RootUIComp.Get().SetUIActive(false);
			this.ReviewComp.EnableReviewButton(false);
			base.GetButton(1).RootUIComp.Get().SetUIActive(false);
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.UpdateByPlotConfig();
			}, num, null, null, true, 1f);
		}
	}

	// Token: 0x06015234 RID: 86580 RVA: 0x005D993C File Offset: 0x005D7B3C
	private void OnTermExplanationViewOpen(ETermExplanationViewType _)
	{
		this.MuteAutoPlay(true);
	}

	// Token: 0x06015235 RID: 86581 RVA: 0x005D9945 File Offset: 0x005D7B45
	private void OnTermExplanationViewClose()
	{
		this.MuteAutoPlay(false);
	}

	// Token: 0x06015236 RID: 86582 RVA: 0x005D9950 File Offset: 0x005D7B50
	private void OnImmersiveInputStateChange(EInputControllerMainType inputMainType, bool isWake)
	{
		if (!Singleton<InputManager>.Instance.IsImmersiveMouseModeEnabled())
		{
			return;
		}
		if (isWake)
		{
			this.ClearPendingImmersiveSleep();
		}
		else if (!this.IsVisible)
		{
			this.PendingImmersiveSleep = true;
			return;
		}
		if (!isWake && ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState == EAutoPlayState.Manual)
		{
			return;
		}
		if (this.ImmersiveInputWakeState == isWake)
		{
			return;
		}
		this.ApplyImmersiveInputWakeState(isWake);
	}

	// Token: 0x06015237 RID: 86583 RVA: 0x005D99AC File Offset: 0x005D7BAC
	private void ApplyImmersiveInputWakeState(bool isWake)
	{
		this.ImmersiveInputWakeState = isWake;
		if (this.SkipComp != null)
		{
			this.SkipComp.UpdateImmersiveInputWakeState(this.ImmersiveInputWakeState);
		}
		if (this.ReviewComp != null)
		{
			this.ReviewComp.UpdateImmersiveInputWakeState(this.ImmersiveInputWakeState);
		}
		this.UpdatePlotButtonsVisibility(this.ImmersiveInputWakeState);
		this.AutoSelectOptionComponent.OnImmersiveInputStateChange();
	}

	// Token: 0x06015238 RID: 86584 RVA: 0x005D9A0C File Offset: 0x005D7C0C
	private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
	{
		this.UpdateAutoSelectText();
		if (this.SubtitleLevel.GetValueOrDefault() != EPlotLevel.LevelB || !ModelBase<PlotModel>.Instance.IsUseNewLevelBStyle())
		{
			return;
		}
		UUIItem item = base.GetItem(45);
		if (item != null)
		{
			item.SetAnchorOffsetY(PlotSubtitleView.GetPnlLayout02OffsetY(now));
		}
	}

	// Token: 0x06015239 RID: 86585 RVA: 0x005D9A52 File Offset: 0x005D7C52
	private static float GetPnlLayout02OffsetY(EInputControllerMainType type)
	{
		if (type == EInputControllerMainType.Gamepad)
		{
			return -60f;
		}
		if (type == EInputControllerMainType.Touch)
		{
			return 0f;
		}
		return -80f;
	}

	// Token: 0x0601523A RID: 86586 RVA: 0x005D9A6D File Offset: 0x005D7C6D
	private void OnEnableSkipPlotRestoreTween(bool _)
	{
		this.RestorePlotButtonsVisibility();
	}

	// Token: 0x0601523B RID: 86587 RVA: 0x005D9A75 File Offset: 0x005D7C75
	private void ClearPendingImmersiveSleep()
	{
		this.PendingImmersiveSleep = false;
		if (this.PendingImmersiveSleepTimerId != null && TimerSystem.Instance.Has(this.PendingImmersiveSleepTimerId))
		{
			TimerSystem.Instance.Remove(this.PendingImmersiveSleepTimerId);
		}
		this.PendingImmersiveSleepTimerId = null;
	}

	// Token: 0x0601523C RID: 86588 RVA: 0x005D9AB0 File Offset: 0x005D7CB0
	private void TrySchedulePendingImmersiveSleep()
	{
		if (!this.PendingImmersiveSleep)
		{
			return;
		}
		this.PendingImmersiveSleep = false;
		if (ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState == EAutoPlayState.Manual)
		{
			return;
		}
		if (this.PendingImmersiveSleepTimerId != null && TimerSystem.Instance.Has(this.PendingImmersiveSleepTimerId))
		{
			TimerSystem.Instance.Remove(this.PendingImmersiveSleepTimerId);
		}
		this.PendingImmersiveSleepTimerId = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.PendingImmersiveSleepTimerId = null;
			this.ApplyImmersiveInputWakeState(false);
		}, 3000f, null, null, true, 1f);
	}

	// Token: 0x0601523D RID: 86589 RVA: 0x005D9B34 File Offset: 0x005D7D34
	private void InitTweenAnim(int componentType)
	{
		List<ULGUIPlayTweenComponent> list = new List<ULGUIPlayTweenComponent>();
		TArray<UActorComponent> tarray = base.GetItem(componentType).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			list.Add(tarray.Get(i) as ULGUIPlayTweenComponent);
		}
		if (this.TweenAnimMap == null)
		{
			this.TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();
		}
		this.TweenAnimMap[componentType] = list;
	}

	// Token: 0x0601523E RID: 86590 RVA: 0x005D9BA8 File Offset: 0x005D7DA8
	private void PlayTweenAnim(int componentType)
	{
		List<ULGUIPlayTweenComponent> list;
		if (this.TweenAnimMap.TryGetValue(componentType, out list))
		{
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
			{
				ulguiplayTweenComponent.Play();
			}
		}
	}

	// Token: 0x0601523F RID: 86591 RVA: 0x005D9C04 File Offset: 0x005D7E04
	public void StopTweenAnim(int componentType)
	{
		List<ULGUIPlayTweenComponent> list;
		if (this.TweenAnimMap.TryGetValue(componentType, out list))
		{
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
			{
				ulguiplayTweenComponent.Stop();
			}
		}
	}

	// Token: 0x06015240 RID: 86592 RVA: 0x005D9C60 File Offset: 0x005D7E60
	private void UpdatePlotButtonsVisibility(bool visible)
	{
		bool canPause = ModelBase<PlotModel>.Instance.PlotConfig.CanPause;
		if (visible && canPause)
		{
			this.MainButtonsTweenShown = new bool?(true);
			this.StopTweenAnim(41);
			this.StopTweenAnim(52);
			this.PlayTweenAnim(40);
			this.PlayTweenAnim(51);
		}
		else
		{
			this.MainButtonsTweenShown = new bool?(false);
			this.StopTweenAnim(40);
			this.StopTweenAnim(51);
			this.PlayTweenAnim(41);
			this.PlayTweenAnim(52);
		}
		if (this.SkipComp != null)
		{
			bool flag = this.SkipComp.IsSkipButtonEnabled();
			if (visible && flag)
			{
				this.SkipTweenShown = new bool?(true);
				this.StopTweenAnim(37);
				this.PlayTweenAnim(36);
			}
			else
			{
				this.SkipTweenShown = new bool?(false);
				this.StopTweenAnim(36);
				this.PlayTweenAnim(37);
			}
		}
		if (this.ReviewComp != null)
		{
			bool flag2 = this.ReviewComp.IsReviewButtonEnabled();
			if (visible && flag2)
			{
				this.ReviewTweenShown = new bool?(true);
				this.StopTweenAnim(39);
				this.PlayTweenAnim(38);
				return;
			}
			this.ReviewTweenShown = new bool?(false);
			this.StopTweenAnim(38);
			this.PlayTweenAnim(39);
		}
	}

	// Token: 0x06015241 RID: 86593 RVA: 0x005D9D84 File Offset: 0x005D7F84
	private void RestorePlotButtonsVisibility()
	{
		if (!this.ImmersiveInputWakeState)
		{
			return;
		}
		if (ModelBase<PlotModel>.Instance.PlotConfig.CanPause)
		{
			bool? flag = this.MainButtonsTweenShown;
			bool flag2 = false;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				this.MainButtonsTweenShown = new bool?(true);
				this.StopTweenAnim(41);
				this.StopTweenAnim(52);
				this.PlayTweenAnim(40);
				this.PlayTweenAnim(51);
			}
		}
		PlotSkipComponent skipComp = this.SkipComp;
		if (skipComp != null && skipComp.IsSkipButtonEnabled())
		{
			bool? flag = this.SkipTweenShown;
			bool flag2 = false;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				this.SkipTweenShown = new bool?(true);
				this.StopTweenAnim(37);
				this.PlayTweenAnim(36);
			}
		}
		PlotReviewComponent reviewComp = this.ReviewComp;
		if (reviewComp != null && reviewComp.IsReviewButtonEnabled())
		{
			bool? flag = this.ReviewTweenShown;
			bool flag2 = false;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				this.ReviewTweenShown = new bool?(true);
				this.StopTweenAnim(39);
				this.PlayTweenAnim(38);
			}
		}
	}

	// Token: 0x06015242 RID: 86594 RVA: 0x005D9E90 File Offset: 0x005D8090
	private void MuteAutoPlay(bool isMute)
	{
		if (isMute)
		{
			this.MuteTimeLimitedOption = true;
			ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState = EAutoPlayState.Manual;
			this.UpdateAutoPlayButton();
			this.AutoSelectOptionComponent.OnAutoPlayStateChanged();
			return;
		}
		this.MuteTimeLimitedOption = false;
		PlotConfig plotConfig = ModelBase<PlotModel>.Instance.PlotConfig;
		plotConfig.AutoPlayState = plotConfig.AutoPlayStateCache;
		this.UpdateAutoPlayButton();
		this.AutoSelectOptionComponent.OnAutoPlayStateChanged();
		if (plotConfig.AutoPlayState != EAutoPlayState.Manual && ModelBase<SequenceModel>.Instance.IsPlaying && ModelBase<SequenceModel>.Instance.IsPaused.GetValueOrDefault() && (!this.SubtitleInfo.HasSubtitle() || !this.SubtitleInfo.HasOption))
		{
			this.ResumeSequence("Subtitle");
		}
	}

	// Token: 0x06015243 RID: 86595 RVA: 0x005D9F40 File Offset: 0x005D8140
	[NullableContext(1)]
	private void OnShowTalkStart(ShowTalk inShowTalk)
	{
		this.ShowBlackBg(false, false);
		PlotSkipComponent skipComp = this.SkipComp;
		if (skipComp == null)
		{
			return;
		}
		skipComp.AddSummary(inShowTalk.TalkOutline);
	}

	// Token: 0x06015244 RID: 86596 RVA: 0x005D9F60 File Offset: 0x005D8160
	private void OnPlotConfigChanged()
	{
		this.UpdateByPlotConfig();
	}

	// Token: 0x06015245 RID: 86597 RVA: 0x005D9F68 File Offset: 0x005D8168
	private void OnSkip()
	{
		this.MuteAutoPlay(false);
		this.ShowUiExceptPhoto();
		ControllerBase<FlowController>.Instance.BackgroundFlow("UI点击跳过(PlotSubtitleView)", true, false, true);
	}

	// Token: 0x06015246 RID: 86598 RVA: 0x005D9F89 File Offset: 0x005D8189
	private void ShowDoingText(bool bShow)
	{
		base.GetItem(24).SetUIActive(bShow);
	}

	// Token: 0x06015247 RID: 86599 RVA: 0x005D9F9C File Offset: 0x005D819C
	protected void OnBtnSubtitleSkipClick()
	{
		if (this.SubtitleLevel.GetValueOrDefault() != EPlotLevel.LevelB)
		{
			return;
		}
		if (!this.SubtitleInfo.HasSubtitle())
		{
			return;
		}
		ITalkItem currentSubtitle = this.CurrentSubtitle;
		if (currentSubtitle != null && currentSubtitle.Type.GetValueOrDefault() == ETalkItemType.CenterText)
		{
			return;
		}
		if (this.SubtitleInfo.ShowOption)
		{
			return;
		}
		if (this.SubtitleInfo.Skip)
		{
			return;
		}
		if (this.IsCurSubtitlePaused)
		{
			this.ResumeSequence("Subtitle");
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_ia_spl_plot_next");
			return;
		}
		if (this.SubtitleInfo.EnableSkipTime > Singleton<TimeUtil>.Instance.GetServerTimeStamp())
		{
			return;
		}
		if (!this.SubtitleInfo.ShowAllText && this.SubtitleAnimDataComp.GetSelectorOffset() != 0f)
		{
			this.TryShowAllText();
			return;
		}
		this.TryJumpToNextSubtitleOrPlot();
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_ia_spl_plot_next");
	}

	// Token: 0x06015248 RID: 86600 RVA: 0x005DA07C File Offset: 0x005D827C
	private void TryShowAllText()
	{
		TimerHandle scrollStartTimer = this.ScrollStartTimer;
		if (scrollStartTimer != null)
		{
			scrollStartTimer.Remove();
		}
		this.ScrollStartTimer = null;
		this.RemoveTextAnimTimer();
		UUIScrollViewComponent scrollView = base.GetScrollView(27);
		if (scrollView != null)
		{
			scrollView.SetScrollProgress(1f);
		}
		this.SubtitleAnimation.Stop();
		this.SubtitleAnimDataComp.SetSelectorOffset(0f);
		this.SubtitleInfo.EnableSkipTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + 100.0;
		this.SubtitleInfo.ShowAllText = true;
		if (this.SubtitleInfo.HasOption)
		{
			this.ShowOption();
		}
	}

	// Token: 0x06015249 RID: 86601 RVA: 0x005DA119 File Offset: 0x005D8319
	private void TryJumpToNextSubtitleOrPlot()
	{
		if (this.SubtitleInfo.HasOption)
		{
			if (!this.SubtitleInfo.ShowOption)
			{
				this.ShowOption();
			}
			return;
		}
		ControllerBase<SequenceController>.Instance.FinishSubtitle(this.CurrentSubtitle.Id);
	}

	// Token: 0x0601524A RID: 86602 RVA: 0x005DA154 File Offset: 0x005D8354
	protected void OnBtnAutoClick()
	{
		bool flag = false;
		EAutoPlayState eautoPlayState = EAutoPlayState.Manual;
		switch (ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState)
		{
		case EAutoPlayState.Manual:
			eautoPlayState = EAutoPlayState.SemiAuto;
			break;
		case EAutoPlayState.SemiAuto:
			eautoPlayState = EAutoPlayState.Auto;
			break;
		case EAutoPlayState.Auto:
			eautoPlayState = EAutoPlayState.Manual;
			break;
		}
		ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState = eautoPlayState;
		ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayStateCache = eautoPlayState;
		bool flag2 = eautoPlayState > EAutoPlayState.Manual;
		this.UpdateAutoPlayButton();
		this.AutoSelectOptionComponent.OnAutoPlayStateChanged();
		if (flag2)
		{
			flag = true;
		}
		if (flag && ModelBase<SequenceModel>.Instance.IsPlaying && ModelBase<SequenceModel>.Instance.IsPaused.GetValueOrDefault() && (!this.SubtitleInfo.HasSubtitle() || !this.SubtitleInfo.HasOption))
		{
			this.ResumeSequence("Subtitle");
		}
	}

	// Token: 0x0601524B RID: 86603 RVA: 0x005DA211 File Offset: 0x005D8411
	private void OnSkipPop()
	{
		this.MuteAutoPlay(true);
		this.HideUiExceptPhoto();
	}

	// Token: 0x0601524C RID: 86604 RVA: 0x005DA220 File Offset: 0x005D8420
	private void OnSkipCancel()
	{
		this.MuteAutoPlay(false);
		this.ShowUiExceptPhoto();
	}

	// Token: 0x0601524D RID: 86605 RVA: 0x005DA22F File Offset: 0x005D842F
	private void OnBtnHideClick()
	{
		this.HideUiExceptPhoto();
		this.IsVisible = false;
		this.MuteAutoPlay(true);
	}

	// Token: 0x0601524E RID: 86606 RVA: 0x005DA245 File Offset: 0x005D8445
	private void OnBtnReviewClick()
	{
		if (ControllerBase<FlowController>.Instance.OpenPlotReviewView())
		{
			this.HideUiExceptPhoto();
			this.MuteAutoPlay(true);
		}
	}

	// Token: 0x0601524F RID: 86607 RVA: 0x005DA260 File Offset: 0x005D8460
	private void OnOpenView(EUiViewName viewName, int _)
	{
		if (viewName == EUiViewName.PlotReviewView)
		{
			Singleton<AudioSystem>.Instance.PostEvent("plot_review_enter");
		}
	}

	// Token: 0x06015250 RID: 86608 RVA: 0x005DA27F File Offset: 0x005D847F
	private void OnCloseView(EUiViewName viewName, int _)
	{
		if (viewName == EUiViewName.PlotReviewView)
		{
			Singleton<AudioSystem>.Instance.PostEvent("plot_review_exit");
			this.IsVisible = true;
			this.MuteAutoPlay(false);
			this.ShowUiExceptPhoto();
			this.RestorePlotButtonsVisibility();
		}
	}

	// Token: 0x06015251 RID: 86609 RVA: 0x005DA2B8 File Offset: 0x005D84B8
	private void HideUiExceptPhoto()
	{
		UUIItem item = base.GetItem(29);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(30);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x06015252 RID: 86610 RVA: 0x005DA2E1 File Offset: 0x005D84E1
	private void ShowUiExceptPhoto()
	{
		UUIItem item = base.GetItem(29);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(30);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(true);
	}

	// Token: 0x06015253 RID: 86611 RVA: 0x005DA30C File Offset: 0x005D850C
	private void PlaySubtitle()
	{
		SubtitleInfo subtitleInfo = this.SubtitleInfo;
		ETalkItemType? etalkItemType;
		if (subtitleInfo == null)
		{
			etalkItemType = null;
		}
		else
		{
			ITalkItem currentConfig = subtitleInfo.CurrentConfig;
			etalkItemType = ((currentConfig != null) ? currentConfig.Type : null);
		}
		ETalkItemType? etalkItemType2 = etalkItemType;
		if (etalkItemType2 != null)
		{
			switch (etalkItemType2.GetValueOrDefault())
			{
			case ETalkItemType.Option:
			case ETalkItemType.SystemOption:
				this.ResetSubtitle();
				this.SkipSubtitleTipItemActive(false);
				this.ShowWaitingPoint(false);
				this.SubtitleInfo.ShowAllText = true;
				return;
			case ETalkItemType.CenterText:
				this.ShowTransitionView();
				return;
			}
		}
		this.HandleNormalSubtitle();
		this.HandleSubtitleAudio(this.AudioKey, this.SubtitleInfo.CurrentDelayTime, this.SubtitleInfo.CurrentAudioTransitionDuration);
		this.HandleSkipWaiting();
	}

	// Token: 0x06015254 RID: 86612 RVA: 0x005DA3C5 File Offset: 0x005D85C5
	private void HideSubtitle()
	{
		this.ResetSubtitle();
		this.StopCurSubtitleAudio();
		this.SkipSubtitleTipItemActive(false);
		this.ShowWaitingPoint(false);
		this.StopWaitingSkipTimer();
		this.SubtitleInfo.Clear();
	}

	// Token: 0x06015255 RID: 86613 RVA: 0x005DA3F4 File Offset: 0x005D85F4
	private void ShowOption()
	{
		SubtitleInfo subtitleInfo = this.SubtitleInfo;
		if (subtitleInfo == null || !subtitleInfo.HasOption)
		{
			return;
		}
		UUIItem item = base.GetItem(45);
		if (this.SubtitleLevel.GetValueOrDefault() == EPlotLevel.LevelB && ModelBase<PlotModel>.Instance.IsUseNewLevelBStyle())
		{
			if (item != null)
			{
				item.SetAnchorOffsetY(PlotSubtitleView.GetPnlLayout02OffsetY(Singleton<Info>.Instance.InputControllerMainType));
			}
		}
		else if (item != null)
		{
			item.SetAnchorOffsetY(0f);
		}
		if (this.CurrentSubtitle.Type.GetValueOrDefault() == ETalkItemType.SystemOption)
		{
			ControllerBase<PlotController>.Instance.ShowSystemOption(this.CurrentSubtitle, delegate(int index, List<ActionInfo> _)
			{
				ControllerBase<SequenceController>.Instance.SelectOption(index, this.CurrentSubtitle.Id);
			});
			this.SubtitleInfo.ShowOption = true;
			this.HandleSkipWaiting();
			return;
		}
		ModelBase<PlotModel>.Instance.OptionEnable = true;
		this.SubtitleInfo.ShowOption = true;
		this.SetOptionsShow(true);
		this.CurOption = this.FilterOption(this.CurrentSubtitle.Options);
		this.OptionLayout.RefreshByData(this.CurOption.Cast<object>().ToList<object>(), delegate
		{
			this.HandleOptionState();
			this.AutoSelectOptionComponent.OnOptionsShow();
		}, false);
		this.HandleSkipWaiting();
	}

	// Token: 0x06015256 RID: 86614 RVA: 0x005DA50C File Offset: 0x005D870C
	[NullableContext(1)]
	private List<PlotOption> FilterOption(List<ITalkOption> options)
	{
		List<PlotOption> list = new List<PlotOption>();
		for (int i = 0; i < options.Count; i++)
		{
			ITalkOption talkOption = options[i];
			bool flag = ModelBase<PlotModel>.Instance.CheckOptionCondition(talkOption, i, this.CurrentSubtitle);
			if (flag || talkOption.OptionLockTip != null)
			{
				PlotOption item = new PlotOption
				{
					Config = talkOption,
					ConditionCheck = flag,
					OnClick = new Action(this.OnOptionSelected)
				};
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06015257 RID: 86615 RVA: 0x005DA586 File Offset: 0x005D8786
	private void OnOptionSelected()
	{
		this.AutoSelectOptionComponent.OnOptionSelected();
	}

	// Token: 0x06015258 RID: 86616 RVA: 0x005DA593 File Offset: 0x005D8793
	private void SelectOptionByIndex(int optionIndex)
	{
		ControllerBase<SequenceController>.Instance.SelectOption(optionIndex, this.CurrentSubtitle.Id);
	}

	// Token: 0x06015259 RID: 86617 RVA: 0x005DA5AB File Offset: 0x005D87AB
	private void HideOption()
	{
		this.ClearOptions();
	}

	// Token: 0x0601525A RID: 86618 RVA: 0x005DA5B4 File Offset: 0x005D87B4
	private void HandleOptionState()
	{
		PlotOptionItem selectedPlotOptionItem = this.SelectedPlotOptionItem;
		if (selectedPlotOptionItem != null)
		{
			selectedPlotOptionItem.SetSelectedDisplay(false);
		}
		this.SelectedPlotOptionItem = PlotAutoSelectOptionComponent.GetDefaultSelectedOptionItem(this.GetDisplayOptionItems(), this.CurrentSubtitle);
		if (this.SelectedPlotOptionItem != null)
		{
			this.SelectedPlotOptionItem.SetSelectedDisplay(true);
			this.AutoSelectOptionComponent.OnSelectedOptionChanged();
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.SelectedPlotOptionItem.GetToggleItem().GetRootComponent(), true, false, false);
		}
	}

	// Token: 0x0601525B RID: 86619 RVA: 0x005DA628 File Offset: 0x005D8828
	[NullableContext(1)]
	private PlotOptionItem[] GetDisplayOptionItems()
	{
		List<PlotOptionItem> list = new List<PlotOptionItem>();
		int displayGridEndIndex = this.OptionLayout.GetDisplayGridEndIndex();
		for (int i = 0; i <= displayGridEndIndex; i++)
		{
			PlotOptionItem layoutItemByIndex = this.OptionLayout.GetLayoutItemByIndex(i);
			if (layoutItemByIndex != null)
			{
				list.Add(layoutItemByIndex);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0601525C RID: 86620 RVA: 0x005DA670 File Offset: 0x005D8870
	private void HideAll(bool isHidden)
	{
		this.RootItem.SetUIActive(!isHidden);
	}

	// Token: 0x0601525D RID: 86621 RVA: 0x005DA684 File Offset: 0x005D8884
	private void ClearPlotSubtitle()
	{
		this.CheckAndCloseTransitionView();
		SubtitleInfo subtitleInfo = this.SubtitleInfo;
		if (subtitleInfo != null && subtitleInfo.HasSubtitle())
		{
			this.HideSeqSubtitleInternal();
		}
		else
		{
			this.ResetSubtitle();
			this.HideOption();
			this.SkipSubtitleTipItemActive(false);
			this.ShowWaitingPoint(false);
			this.StopWaitingSkipTimer();
		}
		this.StopCurSubtitleAudio();
		this.StopIndependentAudio();
		this.RemoveAutoPlayDelay();
	}

	// Token: 0x0601525E RID: 86622 RVA: 0x005DA6E8 File Offset: 0x005D88E8
	private void HandleSubtitleAudio(string audioId, float audioDelay, float audioTransitionDuration)
	{
		if (StringUtils.IsEmpty(audioId))
		{
			return;
		}
		PlotAudio? audioConfig = StringUtils.IsEmpty(audioId) ? null : ConfigPlotAudioById.GetConfig(audioId, true);
		if (audioConfig == null)
		{
			return;
		}
		this.AudioConfig = audioConfig;
		this.AudioStartTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + (double)audioDelay;
		this.CheckAndPlayAudio();
	}

	// Token: 0x0601525F RID: 86623 RVA: 0x005DA744 File Offset: 0x005D8944
	private void HandleSkipWaiting()
	{
		this.StopWaitingSkipTimer();
		if (this.SubtitleLevel.GetValueOrDefault() != EPlotLevel.LevelB || !this.SubtitleInfo.HasSubtitle())
		{
			this.SkipSubtitleTipItemActive(false);
			this.ShowWaitingPoint(false);
			return;
		}
		if (this.SubtitleInfo.ShowOption)
		{
			this.SkipSubtitleTipItemActive(false);
			this.ShowWaitingPoint(false);
			return;
		}
		double num = this.SubtitleInfo.EnableSkipTime - Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if (num < 20.0)
		{
			this.SkipSubtitleTipItemActive(true);
			this.ShowWaitingPoint(false);
			return;
		}
		this.SkipSubtitleTipItemActive(false);
		this.ShowWaitingPoint(true);
		this.WaitingSkipTimerId = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.SkipSubtitleTipItemActive(true);
			this.ShowWaitingPoint(false);
			this.WaitingSkipTimerId = null;
		}, (float)num, null, null, true, 1f);
	}

	// Token: 0x06015260 RID: 86624 RVA: 0x005DA803 File Offset: 0x005D8A03
	private void StopWaitingSkipTimer()
	{
		if (this.WaitingSkipTimerId != null)
		{
			if (TimerSystem.Instance.Has(this.WaitingSkipTimerId))
			{
				TimerSystem.Instance.Remove(this.WaitingSkipTimerId);
			}
			this.WaitingSkipTimerId = null;
		}
	}

	// Token: 0x06015261 RID: 86625 RVA: 0x005DA838 File Offset: 0x005D8A38
	private void CheckAndPlayAudio()
	{
		if (this.AudioConfig == null)
		{
			return;
		}
		double num = this.AudioStartTime - Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if (num < 20.0)
		{
			this.PlayAudioNow();
			return;
		}
		this.AudioDelayTimerId = TimerSystem.Instance.Delay(delegate(float _)
		{
			if (this.AudioConfig == null)
			{
				return;
			}
			this.PlayAudioNow();
		}, (float)num, null, null, true, 1f);
	}

	// Token: 0x06015262 RID: 86626 RVA: 0x005DA8A0 File Offset: 0x005D8AA0
	private void PlayAudioNow()
	{
		ExternalSourceSetting? config = ConfigExternalSourceSettingById.GetConfig(this.AudioConfig.Value.ExternalSourceSetting, true);
		string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(this.AudioConfig.Value);
		this.AudioDelegate.Enable();
		this.Duration = ((this.AudioConfig.Value.TailTime < 0) ? ModelBase<PlotModel>.Instance.PlotGlobalConfig.AudioEndDelay : ((float)this.AudioConfig.Value.TailTime));
		Singleton<AudioController>.Instance.PostEventByExternalSourcesByUi(config.Value.SubtitleEvent, externalSourcesMediaName, config.Value.SubtitleSrc, this.NormalPlayEventResult, null, new int?(8), this.AudioDelegate.AudioDelegate);
	}

	// Token: 0x06015263 RID: 86627 RVA: 0x005DA96A File Offset: 0x005D8B6A
	private void CallBackDuration(float duration)
	{
		this.Duration += duration;
		this.AudioPlayTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.OnAudioEnd();
		}, this.Duration, null, null, true, 1f);
	}

	// Token: 0x06015264 RID: 86628 RVA: 0x005DA9A4 File Offset: 0x005D8BA4
	private void OnAudioEnd()
	{
		this.AudioPlayTimer = null;
		SubtitleInfo subtitleInfo = this.SubtitleInfo;
		if (subtitleInfo == null || !subtitleInfo.HasSubtitle())
		{
			return;
		}
		if (!this.SubtitleInfo.ShowOption && this.SubtitleInfo.NeedDelay && this.SubtitleInfo.StartFinish)
		{
			this.SubtitleInfo.NeedDelay = false;
			this.DelayAutoPlayTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.OnAutoPlayDelayEnd();
			}, this.SubtitleInfo.CurrentAutoPlayDelayTime, null, null, true, 1f);
			return;
		}
		if (this.IsCurSubtitlePaused && !this.SubtitleInfo.ShowOption && this.IsCurSubtitleAutoPlay())
		{
			this.ResumeSequence("Subtitle");
		}
	}

	// Token: 0x06015265 RID: 86629 RVA: 0x005DAA5B File Offset: 0x005D8C5B
	private void OnAutoPlayDelayEnd()
	{
		this.DelayAutoPlayTimer = null;
		if (this.IsCurSubtitlePaused)
		{
			this.ResumeSequence("Subtitle");
		}
	}

	// Token: 0x06015266 RID: 86630 RVA: 0x005DAA78 File Offset: 0x005D8C78
	private void StopCurSubtitleAudio()
	{
		if (this.AudioConfig == null)
		{
			return;
		}
		ControllerBase<SequenceController>.Instance.StopMouthAnim();
		TimerHandle audioPlayTimer = this.AudioPlayTimer;
		if (audioPlayTimer != null)
		{
			audioPlayTimer.Remove();
		}
		this.AudioPlayTimer = null;
		this.AudioStartTime = 0.0;
		this.Duration = 0f;
		this.AudioDelegate.Disable();
		Singleton<AudioController>.Instance.StopEvent(this.NormalPlayEventResult, true, new int?(500));
		this.RemoveAudioDelayTimer();
		this.AudioConfig = null;
		this.RemoveAutoPlayDelay();
	}

	// Token: 0x06015267 RID: 86631 RVA: 0x005DAB10 File Offset: 0x005D8D10
	private float GetCurrentAudioRemainingTime()
	{
		if (this.AudioConfig == null)
		{
			return 0f;
		}
		if (this.AudioPlayTimer != null && TimerSystem.Instance.Has(this.AudioPlayTimer))
		{
			float nextRemainTime = TimerSystem.Instance.GetNextRemainTime(this.AudioPlayTimer);
			if (nextRemainTime >= 0f)
			{
				return nextRemainTime;
			}
		}
		if (this.AudioDelayTimerId != null && TimerSystem.Instance.Has(this.AudioDelayTimerId))
		{
			float nextRemainTime2 = TimerSystem.Instance.GetNextRemainTime(this.AudioDelayTimerId);
			if (nextRemainTime2 >= 0f)
			{
				return nextRemainTime2;
			}
		}
		if (this.AudioStartTime > 0.0 && this.Duration > 0f)
		{
			return Math.Max(0f, (float)(this.AudioStartTime + (double)this.Duration - Singleton<TimeUtil>.Instance.GetServerTimeStamp()));
		}
		return 0f;
	}

	// Token: 0x06015268 RID: 86632 RVA: 0x005DABE2 File Offset: 0x005D8DE2
	private void RemoveAudioDelayTimer()
	{
		if (this.AudioDelayTimerId != null)
		{
			if (TimerSystem.Instance.Has(this.AudioDelayTimerId))
			{
				TimerSystem.Instance.Remove(this.AudioDelayTimerId);
			}
			this.AudioDelayTimerId = null;
		}
	}

	// Token: 0x06015269 RID: 86633 RVA: 0x005DAC16 File Offset: 0x005D8E16
	private void RemoveAutoPlayDelay()
	{
		if (this.DelayAutoPlayTimer != null)
		{
			if (TimerSystem.Instance.Has(this.DelayAutoPlayTimer))
			{
				TimerSystem.Instance.Remove(this.DelayAutoPlayTimer);
			}
			this.DelayAutoPlayTimer = null;
		}
	}

	// Token: 0x0601526A RID: 86634 RVA: 0x005DAC4C File Offset: 0x005D8E4C
	private void HandleNormalSubtitle()
	{
		ITalkItem currentConfig = this.SubtitleInfo.CurrentConfig;
		EPlotLevel? subtitleLevel = this.SubtitleLevel;
		EPlotLevel eplotLevel = EPlotLevel.LevelA;
		if (subtitleLevel.GetValueOrDefault() == eplotLevel & subtitleLevel != null)
		{
			string text = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(this.SubtitleKey);
			if (StringUtils.IsEmpty(text))
			{
				FlowController instance = ControllerBase<FlowController>.Instance;
				string text2 = "字幕为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", this.SubtitleKey);
				instance.LogError(text2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				text = this.SubtitleKey;
			}
			text = this.ParseSubtitle(text);
			base.GetText(12).SetGameRichText(true);
			base.GetText(12).SetText(text, true);
			base.GetText(12).SetUIActive(true);
			base.GetItem(3).SetAlpha(1f);
			return;
		}
		UUIText text3 = base.GetText(4);
		UUIText text4 = base.GetText(17);
		UUIItem item = base.GetItem(11);
		UUIItem item2 = base.GetItem(45);
		UUIScrollViewComponent scrollView = base.GetScrollView(27);
		object obj;
		if (scrollView == null)
		{
			obj = null;
		}
		else
		{
			UUIItem rootComponent = scrollView.GetRootComponent();
			if (rootComponent == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = rootComponent.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(UUISizeControlByOther.StaticClass()) : null);
			}
		}
		UUISizeControlByOther uuisizeControlByOther = obj as UUISizeControlByOther;
		if (this.SubtitleLevel.GetValueOrDefault() == EPlotLevel.LevelB && ModelBase<PlotModel>.Instance.IsUseNewLevelBStyle())
		{
			this.ShowBlackBg(false, false);
			base.GetItem(3).SetAlpha(1f);
			text3.SetUIActive(false);
			text4.SetUIActive(false);
			item.SetUIActive(false);
			if (uuisizeControlByOther != null)
			{
				uuisizeControlByOther.MinHeight = 60;
			}
			if (item2 != null)
			{
				item2.SetAnchorOffsetY(PlotSubtitleView.GetPnlLayout02OffsetY(Singleton<Info>.Instance.InputControllerMainType));
			}
		}
		else
		{
			this.ShowBlackBg(true, true);
			if (uuisizeControlByOther != null)
			{
				uuisizeControlByOther.MinHeight = 174;
			}
			if (item2 != null)
			{
				item2.SetAnchorOffsetY(0f);
			}
			ITalkItemDialog talkItemDialog = currentConfig as ITalkItemDialog;
			bool flag;
			if (talkItemDialog == null)
			{
				flag = false;
			}
			else
			{
				ITalkItemStyle style = talkItemDialog.Style;
				ETalkItemStyle? etalkItemStyle = (style != null) ? new ETalkItemStyle?(style.Type) : null;
				ETalkItemStyle etalkItemStyle2 = ETalkItemStyle.InnerVoice;
				flag = (etalkItemStyle.GetValueOrDefault() == etalkItemStyle2 & etalkItemStyle != null);
			}
			if (flag)
			{
				text3.SetUIActive(false);
				text4.SetUIActive(false);
				item.SetUIActive(false);
			}
			else
			{
				Speaker? config = ConfigSpeakerById.GetConfig(currentConfig.WhoId.Value, true);
				string text5 = (config != null) ? Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerName, new int?(config.Value.Id)) : null;
				string text6 = (config != null) ? Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerTitle, new int?(config.Value.Id)) : null;
				item.SetUIActive(true);
				if (!StringUtils.IsEmpty(text5))
				{
					text3.SetUIActive(true);
					text3.SetText(text5, true);
				}
				else
				{
					text3.SetUIActive(false);
				}
				if (!StringUtils.IsEmpty(text6))
				{
					text4.SetUIActive(true);
					text4.SetText(text6, true);
				}
				else
				{
					text4.SetUIActive(false);
				}
			}
		}
		string text7 = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(this.SubtitleKey);
		text7 = this.ParseSubtitle(text7);
		base.GetText(5).SetGameRichText(true);
		base.GetText(5).SetText(text7, true);
		base.GetText(5).SetUIActive(true);
		int displayCharLength = base.GetText(5).GetDisplayCharLength();
		if (this.SubtitleAnimation != null)
		{
			float duration = (float)displayCharLength / ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedSeq;
			this.SubtitleAnimDataComp.SetSelectorOffset(1f);
			this.SubtitleAnimation.GetPlayTween().duration = duration;
			this.SubtitleAnimation.Play();
		}
		TimerHandle scrollStartTimer = this.ScrollStartTimer;
		if (scrollStartTimer != null)
		{
			scrollStartTimer.Remove();
		}
		this.ScrollStartTimer = null;
		this.ScrollStartTimer = TimerSystem.GameplayTimeInstance.Next(delegate(float _)
		{
			this.ScrollStartTimer = TimerSystem.GameplayTimeInstance.Next(delegate(float _)
			{
				this.HandlePlotContentScroll();
			}, null, null);
		}, null, null);
	}

	// Token: 0x0601526B RID: 86635 RVA: 0x005DB01C File Offset: 0x005D921C
	private void HandlePlotContentScroll()
	{
		this.ScrollStartTimer = null;
		this.RemoveTextAnimTimer();
		UUIScrollViewComponent scrollView = base.GetScrollView(27);
		UUIItem item = base.GetItem(28);
		if (scrollView == null)
		{
			return;
		}
		UUIText text = base.GetText(5);
		float y = text.GetTextRenderSize().Y;
		UUIItem uuiitem = scrollView.RootUIComp.Get();
		float num = (uuiitem != null) ? uuiitem.GetHeight() : this.TextScrollViewPrefabHeight;
		if (item != null)
		{
			item.SetHeight(num + 265f);
		}
		if (y <= num)
		{
			return;
		}
		float textAnimSpeed = this.GetTextAnimSpeed();
		int num2 = ConfigCommonParamById.GetIntConfig("PlotAutoScrollDelayCharNum").GetValueOrDefault(25);
		int displayCharLength = text.GetDisplayCharLength();
		if (displayCharLength <= num2)
		{
			num2 = text.GetRenderLineCharNum(0);
		}
		num2 = Math.Min(num2, Math.Max(displayCharLength - 1, 1));
		float num3 = (float)num2 / textAnimSpeed * 1000f;
		int num4 = Math.Max(displayCharLength - num2, 1);
		this.ScrollTotalTime = (float)num4 / textAnimSpeed * 1000f;
		this.DelayTextScrollAnimTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.StartAutoScrollAnim();
		}, num3, null, null, true, 1f);
	}

	// Token: 0x0601526C RID: 86636 RVA: 0x005DB131 File Offset: 0x005D9331
	private float GetTextAnimSpeed()
	{
		if (this.Level.GetValueOrDefault() == EPlotLevel.LevelC)
		{
			return ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedLevelC;
		}
		return ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedLevelD;
	}

	// Token: 0x0601526D RID: 86637 RVA: 0x005DB160 File Offset: 0x005D9360
	private void StartAutoScrollAnim()
	{
		this.CurrentAnimTime = 0f;
		int intervalTime = 100;
		this.TextScrollAnimTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			float num = this.CurrentAnimTime / this.ScrollTotalTime;
			UUIScrollViewComponent scrollView = this.GetScrollView(27);
			if (scrollView != null)
			{
				scrollView.SetScrollProgress(num);
			}
			if (num >= 1f && TimerSystem.GameplayTimeInstance.Has(this.TextScrollAnimTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TextScrollAnimTimer);
			}
			this.CurrentAnimTime += (float)intervalTime;
		}, (float)intervalTime, 1f, null, null, true);
	}

	// Token: 0x0601526E RID: 86638 RVA: 0x005DB1B8 File Offset: 0x005D93B8
	private void RemoveTextAnimTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.TextScrollAnimTimer))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TextScrollAnimTimer);
		}
		if (TimerSystem.GameplayTimeInstance.Has(this.DelayTextScrollAnimTimer))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.DelayTextScrollAnimTimer);
		}
		this.TextScrollAnimTimer = null;
		this.DelayTextScrollAnimTimer = null;
	}

	// Token: 0x0601526F RID: 86639 RVA: 0x005DB21C File Offset: 0x005D941C
	[NullableContext(1)]
	private unsafe void UpdateSeqSubtitle(PlotSubtitleConfig inPlotSubtitleInfo)
	{
		if (this.SubtitleInfo.HasSubtitle())
		{
			FlowController instance = ControllerBase<FlowController>.Instance;
			string text = "剧情Seq字幕重复触发";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("curId", this.SubtitleInfo.CurrentConfig.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("newId", inPlotSubtitleInfo.Subtitles.Id);
			instance.LogError(text, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.CheckAndCloseTransitionView();
		this.SubtitleInfo.Clear();
		this.SubtitleInfo.SetCurrentSubtitle(inPlotSubtitleInfo);
		ITalkBackground backgroundConfig;
		if (inPlotSubtitleInfo == null)
		{
			backgroundConfig = null;
		}
		else
		{
			ITalkItem subtitles = inPlotSubtitleInfo.Subtitles;
			backgroundConfig = ((subtitles != null) ? subtitles.BackgroundConfig : null);
		}
		this.SetBackgroundImage(backgroundConfig, new Action(this.ShowSeqSubtitleInternal)).Forget();
	}

	// Token: 0x06015270 RID: 86640 RVA: 0x005DB2F6 File Offset: 0x005D94F6
	private void ShowSeqSubtitleInternal()
	{
		this.SetSubtitleKey();
		this.SetOptions();
		this.SetAudioKeys();
		this.HandleAkEvent(true);
		this.PlaySubtitle();
	}

	// Token: 0x06015271 RID: 86641 RVA: 0x005DB318 File Offset: 0x005D9518
	private void HandleAkEvent(bool isStart)
	{
		if (isStart)
		{
			this.PlayAkEvent(this.SubtitleInfo.CurrentConfig.TalkAkEvent);
			this.LastEndEvent = this.SubtitleInfo.CurrentConfig.TalkEndAkEvent;
			return;
		}
		this.PlayAkEvent(this.LastEndEvent);
		this.LastEndEvent = null;
	}

	// Token: 0x06015272 RID: 86642 RVA: 0x005DB368 File Offset: 0x005D9568
	private void HideSeqSubtitleInternal()
	{
		if (this.SubtitleLevel.GetValueOrDefault() == EPlotLevel.LevelB && this.NeedSwitchTalker())
		{
			this.ShowBlackBg(false, true);
		}
		this.HandleAkEvent(false);
		this.HideSubtitle();
		this.HideOption();
	}

	// Token: 0x06015273 RID: 86643 RVA: 0x005DB39C File Offset: 0x005D959C
	private bool NeedSwitchTalker()
	{
		ITalkItem nextTalkItem = ControllerBase<FlowController>.Instance.FlowSequence.GetNextTalkItem();
		if (nextTalkItem == null || (nextTalkItem != null && nextTalkItem.Type.GetValueOrDefault() == ETalkItemType.Option))
		{
			return true;
		}
		ITalkItem currentSubtitle = this.CurrentSubtitle;
		int? num = (currentSubtitle != null) ? currentSubtitle.WhoId : null;
		int? num2 = (nextTalkItem != null) ? nextTalkItem.WhoId : null;
		return !(num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null));
	}

	// Token: 0x06015274 RID: 86644 RVA: 0x005DB428 File Offset: 0x005D9628
	private void ShowTransitionView()
	{
		string text = null;
		string subtitleKey = this.SubtitleKey;
		if (subtitleKey != "")
		{
			text = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(subtitleKey);
			text = this.ParseSubtitle(text);
		}
		else
		{
			FlowController instance = ControllerBase<FlowController>.Instance;
			string text2 = "该字幕没配置对白";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", this.SubtitleInfo.CurrentConfig.Id);
			instance.LogError(text2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		PlotCenterText centerText = ModelBase<PlotModel>.Instance.CenterText;
		centerText.Text = text;
		centerText.AutoClose = false;
		SubtitleInfo subtitleInfo = this.SubtitleInfo;
		IPostAkEventType talkAkEvent;
		if (subtitleInfo == null)
		{
			talkAkEvent = null;
		}
		else
		{
			ITalkItem currentConfig = subtitleInfo.CurrentConfig;
			talkAkEvent = ((currentConfig != null) ? currentConfig.TalkAkEvent : null);
		}
		centerText.TalkAkEvent = talkAkEvent;
		SubtitleInfo subtitleInfo2 = this.SubtitleInfo;
		IUniversalTone universalTone;
		if (subtitleInfo2 == null)
		{
			universalTone = null;
		}
		else
		{
			ITalkItem currentConfig2 = subtitleInfo2.CurrentConfig;
			universalTone = ((currentConfig2 != null) ? currentConfig2.UniversalTone : null);
		}
		centerText.UniversalTone = universalTone;
		ControllerBase<PlotController>.Instance.HandleShowCenterText(true);
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Plot;
		ELogAuthor author = ELogAuthor.ZFJ;
		string message = "Sequence黑幕监听日志-打开黑幕";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("subtitleKey", this.SubtitleKey);
		instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
	}

	// Token: 0x06015275 RID: 86645 RVA: 0x005DB530 File Offset: 0x005D9730
	private bool CheckAndCloseTransitionView()
	{
		if (this.SubtitleInfo.HasSubtitle() && this.SubtitleInfo.CurrentConfig.Type.GetValueOrDefault() == ETalkItemType.CenterText)
		{
			this.CloseTransitionView();
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.ZFJ, "Sequence黑幕监听日志-关闭黑幕", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}
		return false;
	}

	// Token: 0x06015276 RID: 86646 RVA: 0x005DB58A File Offset: 0x005D978A
	private void CloseTransitionView()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PlotTransitionViewPop))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.PlotTransitionViewPop, null);
		}
	}

	// Token: 0x06015277 RID: 86647 RVA: 0x005DB5AD File Offset: 0x005D97AD
	private void HandleSelectedPlotOption(int inOptionIndex)
	{
		bool skip = this.SubtitleInfo.Skip;
		this.HideOption();
		this.HideSeqSubtitleInternal();
		if (skip)
		{
			this.JumpSequence();
			return;
		}
		if (this.IsCurSubtitlePaused)
		{
			this.ResumeSequence("Subtitle");
		}
	}

	// Token: 0x06015278 RID: 86648 RVA: 0x005DB5E4 File Offset: 0x005D97E4
	[NullableContext(1)]
	private void OnInputAnyKey(bool bPress, FKey key)
	{
		UiParam uiParam = this.OpenParam as UiParam;
		if (uiParam != null && uiParam.HideAllUi.GetValueOrDefault())
		{
			return;
		}
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
		this.MuteAutoPlay(false);
	}

	// Token: 0x06015279 RID: 86649 RVA: 0x005DB634 File Offset: 0x005D9834
	[NullableContext(1)]
	private void OnTouchPlotVisible(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification _)
	{
		UiParam uiParam = this.OpenParam as UiParam;
		if (uiParam != null && uiParam.HideAllUi.GetValueOrDefault())
		{
			return;
		}
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

	// Token: 0x0601527A RID: 86650 RVA: 0x005DB684 File Offset: 0x005D9884
	private void HandleSeqSubtitleEnd(int id, bool isSkip)
	{
		this.SubtitleInfo.StartFinish = true;
		if (!this.SubtitleInfo.HasSubtitle() || this.CurrentSubtitle.Id != id)
		{
			return;
		}
		if (isSkip)
		{
			if (this.SubtitleInfo.HasOption)
			{
				this.SubtitleInfo.Skip = true;
				return;
			}
			this.HideSeqSubtitleInternal();
			this.JumpSequence();
			return;
		}
		else
		{
			if (this.SubtitleInfo.ShowOption)
			{
				this.PauseSequence("Subtitle");
				return;
			}
			if (this.SubtitleInfo.HasOption)
			{
				this.ShowOption();
				this.PauseSequence("Subtitle");
				return;
			}
			if (this.Level.GetValueOrDefault() == EPlotLevel.LevelB && this.SubtitleInfo.NeedDelay && this.SubtitleInfo.CurrentConfig.Type.GetValueOrDefault() != ETalkItemType.CenterText)
			{
				this.PauseSequence("Subtitle");
				this.RemoveAutoPlayDelay();
				this.DelayAutoPlayTimer = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.OnAutoPlayDelayEnd();
				}, this.SubtitleInfo.CurrentAutoPlayDelayTime, null, null, true, 1f);
				return;
			}
			double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			if (this.Level.GetValueOrDefault() == EPlotLevel.LevelB && (!this.IsCurSubtitleAutoPlay() || this.AudioPlayTimer != null) && this.SubtitleInfo.EnableSkipTime <= serverTimeStamp)
			{
				this.PauseSequence("Subtitle");
				return;
			}
			this.CheckAndCloseTransitionView();
			this.HideSeqSubtitleInternal();
			return;
		}
	}

	// Token: 0x0601527B RID: 86651 RVA: 0x005DB7E2 File Offset: 0x005D99E2
	private void HandleSubSequenceStop()
	{
		if (this.SubtitleInfo.HasSubtitle())
		{
			this.CheckAndCloseTransitionView();
			this.HideSeqSubtitleInternal();
			this.StopCurSubtitleAudio();
			this.StopIndependentAudio();
		}
	}

	// Token: 0x0601527C RID: 86652 RVA: 0x005DB80C File Offset: 0x005D9A0C
	[NullableContext(1)]
	private void HandleIndependentSeqAudio(bool isShow, string audioKey, float audioTransitionDuration)
	{
		if (!isShow)
		{
			this.StopIndependentAudio();
			return;
		}
		PlotAudio? config = ConfigPlotAudioById.GetConfig(audioKey, true);
		if (config == null)
		{
			FlowController instance = ControllerBase<FlowController>.Instance;
			string text = "读取语音配置为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("audioKey", audioKey);
			instance.LogError(text, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		ExternalSourceSetting? config2 = ConfigExternalSourceSettingById.GetConfig(config.Value.ExternalSourceSetting, true);
		string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(config.Value);
		Singleton<AudioController>.Instance.PostEventByExternalSourcesByUi(config2.Value.SubtitleEvent, externalSourcesMediaName, config2.Value.SubtitleSrc, this.IndependentPlayEventResult, null, new int?(0), null);
	}

	// Token: 0x0601527D RID: 86653 RVA: 0x005DB8C0 File Offset: 0x005D9AC0
	private void StopIndependentAudio()
	{
		Singleton<AudioController>.Instance.StopEvent(this.IndependentPlayEventResult, true, null);
	}

	// Token: 0x0601527E RID: 86654 RVA: 0x005DB8E7 File Offset: 0x005D9AE7
	private void JumpSequence()
	{
		this.SubtitleInfo.Skip = true;
		ControllerBase<SequenceController>.Instance.JumpToNextSubtitleOrChildSeq();
	}

	// Token: 0x0601527F RID: 86655 RVA: 0x005DB8FF File Offset: 0x005D9AFF
	[NullableContext(1)]
	private void PauseSequence(string reason = "Subtitle")
	{
		this.IsCurSubtitlePaused = true;
		ControllerBase<SequenceController>.Instance.PauseSequence(reason);
	}

	// Token: 0x06015280 RID: 86656 RVA: 0x005DB914 File Offset: 0x005D9B14
	[NullableContext(1)]
	private void ResumeSequence(string reason = "Subtitle")
	{
		ControllerBase<SequenceController>.Instance.ResumeSequence(reason, null);
		this.IsCurSubtitlePaused = false;
		this.HideSeqSubtitleInternal();
	}

	// Token: 0x06015281 RID: 86657 RVA: 0x005DB944 File Offset: 0x005D9B44
	private void PlayAkEvent(IPostAkEventType config)
	{
		if (config == null)
		{
			return;
		}
		string text = "";
		switch (config.Type)
		{
		case EPostAkEvent.Global:
			text = ((IPostAkEventGlobal)config).AkEvent;
			break;
		case EPostAkEvent.Target:
			text = ((IPostAkEventTargeted)config).AkEvent;
			break;
		case EPostAkEvent.Map:
			text = ((IPostAkEventMap)config).AkEvent;
			break;
		case EPostAkEvent.MusicSubtitle:
			text = ((IPostAkEventMusicSubtitle)config).AkEvent;
			break;
		}
		text = Singleton<AudioSystem>.Instance.parseAudioEventPath(text);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		if (config.Type == EPostAkEvent.Global)
		{
			Singleton<AudioSystem>.Instance.PostEvent(text);
			return;
		}
		if (config.Type == EPostAkEvent.Target)
		{
			int entityId = ((IPostAkEventTargeted)config).EntityId;
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(entityId);
			if (entityByPbDataId == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "实体不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			BaseActorComponent component = entityByPbDataId.Entity.GetComponent<BaseActorComponent>();
			AActor aactor = (component != null) ? component.Owner : null;
			if (aactor == null || !aactor.IsValid())
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Event;
				ELogAuthor author2 = ELogAuthor.FZX;
				string message2 = "未能获取到该实体对应的有效Actor";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", entityId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			Singleton<AudioSystem>.Instance.PostEvent(text, aactor, null);
		}
	}

	// Token: 0x06015282 RID: 86658 RVA: 0x005DBAA0 File Offset: 0x005D9CA0
	private void SetSubtitleKey()
	{
		this.SubtitleKey = this.SubtitleInfo.CurrentConfig.TidTalk;
	}

	// Token: 0x06015283 RID: 86659 RVA: 0x005DBAB8 File Offset: 0x005D9CB8
	private void SetOptions()
	{
		this.OptionKeys.Clear();
		this.OsList.Clear();
		if (this.SubtitleInfo.CurrentConfig.Options != null)
		{
			foreach (ITalkOption talkOption in this.SubtitleInfo.CurrentConfig.Options)
			{
				this.OptionKeys.Add((talkOption.TidTalkOption != null) ? talkOption.TidTalkOption : "");
				this.OsList.Add((talkOption.Icon != null) ? talkOption.Icon.Value : 0);
			}
		}
	}

	// Token: 0x06015284 RID: 86660 RVA: 0x005DBB88 File Offset: 0x005D9D88
	private void SetAudioKeys()
	{
		ITalkItem currentConfig = this.SubtitleInfo.CurrentConfig;
		this.AudioKey = ((currentConfig != null && currentConfig.PlayVoice.GetValueOrDefault()) ? this.SubtitleInfo.CurrentConfig.TidTalk : null);
	}

	// Token: 0x06015285 RID: 86661 RVA: 0x005DBBD0 File Offset: 0x005D9DD0
	private void ClearOptions()
	{
		this.CurOption.Clear();
		this.SetOptionsShow(false);
		PlotOptionItem selectedPlotOptionItem = this.SelectedPlotOptionItem;
		if (selectedPlotOptionItem != null)
		{
			selectedPlotOptionItem.SetSelectedDisplay(false);
		}
		this.SelectedPlotOptionItem = null;
		if (this.SubtitleInfo != null)
		{
			this.SubtitleInfo.ShowOption = false;
		}
		this.AutoSelectOptionComponent.Clear();
	}

	// Token: 0x06015286 RID: 86662 RVA: 0x005DBC28 File Offset: 0x005D9E28
	public void SetOptionsShow(bool value)
	{
		if (value == this.IsOptionShow)
		{
			return;
		}
		this.IsOptionShow = value;
		if (value)
		{
			this.OptionLayout.SetActive(true);
			UUIItem item = base.GetItem(45);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			this.UiViewSequence.PlaySequence("ChoiceStart", false, null);
			base.GetItem(32).SetUIActive(true);
			this.BlockOptionTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				base.GetItem(32).SetUIActive(false);
				this.BlockOptionTimer = null;
			}, ModelBase<PlotModel>.Instance.PlotGlobalConfig.ProtectOptionTime, null, null, true, 1f);
			return;
		}
		this.UiViewSequence.PlaySequence("ChoiceClose", false, null);
		base.GetItem(32).SetUIActive(false);
		TimerHandle blockOptionTimer = this.BlockOptionTimer;
		if (blockOptionTimer != null)
		{
			blockOptionTimer.Remove();
		}
		this.BlockOptionTimer = null;
	}

	// Token: 0x06015287 RID: 86663 RVA: 0x005DBD06 File Offset: 0x005D9F06
	public string ParseSubtitle(string inText)
	{
		if (string.IsNullOrEmpty(inText))
		{
			return "";
		}
		return ModelBase<PlotModel>.Instance.PlotTextReplacer.Replace(inText, false);
	}

	// Token: 0x06015288 RID: 86664 RVA: 0x005DBD28 File Offset: 0x005D9F28
	private bool IsCurSubtitleAutoPlay()
	{
		if (this.SubtitleInfo.HasSubtitle() && this.SubtitleInfo.CurrentConfig.Type.GetValueOrDefault() == ETalkItemType.CenterText)
		{
			return true;
		}
		EPlotLevel? subtitleLevel = this.SubtitleLevel;
		EPlotLevel eplotLevel = EPlotLevel.LevelA;
		return (subtitleLevel.GetValueOrDefault() == eplotLevel & subtitleLevel != null) || ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState > EAutoPlayState.Manual;
	}

	// Token: 0x06015289 RID: 86665 RVA: 0x005DBD90 File Offset: 0x005D9F90
	public void AddScreenEffectPlotRoot()
	{
		BP_ScreenEffectSystem_C instance = ScreenEffectSystem.GetInstance();
		if (instance == null || !instance.IsValid())
		{
			return;
		}
		AUIContainerActor screenEffectPlotRoot = null;
		instance.GetScreenEffectPlotRoot(ref screenEffectPlotRoot);
		this.ScreenEffectPlotRoot = screenEffectPlotRoot;
		UUIItem item = base.GetItem(13);
		AUIContainerActor screenEffectPlotRoot2 = this.ScreenEffectPlotRoot;
		if (screenEffectPlotRoot2 != null && screenEffectPlotRoot2.IsValid())
		{
			this.ScreenEffectPlotRoot.K2_AttachRootComponentTo(item, default(FName), EAttachLocation.KeepRelativeOffset, true);
		}
	}

	// Token: 0x0601528A RID: 86666 RVA: 0x005DBDF4 File Offset: 0x005D9FF4
	public void RemoveScreenEffectPlotRoot()
	{
		AUIContainerActor screenEffectPlotRoot = this.ScreenEffectPlotRoot;
		if (screenEffectPlotRoot != null && screenEffectPlotRoot.IsValid())
		{
			this.ScreenEffectPlotRoot.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
		}
		this.ScreenEffectPlotRoot = null;
	}

	// Token: 0x0601528B RID: 86667 RVA: 0x005DBE1F File Offset: 0x005DA01F
	[NullableContext(1)]
	public PlotOptionItem[] GetOptionList()
	{
		return this.OptionLayout.GetLayoutItemList().ToArray();
	}

	// Token: 0x0601528C RID: 86668 RVA: 0x005DBE34 File Offset: 0x005DA034
	protected override void OnTick(float delta)
	{
		if (this.TickPhotoFade)
		{
			this.OnFadeTickPhoto(delta);
		}
		if (this.TickIconAlpha)
		{
			this.WidgetMiddle.SetAlpha(this.EventObject.Icon透明度);
			this.BgWidgetMiddle.SetAlpha(this.EventObject.Icon遮罩透明度);
		}
		this.AutoSelectOptionComponent.OnTick(delta, this.MuteTimeLimitedOption);
		if (!Singleton<Info>.Instance.IsBuildShipping)
		{
			this.TickDebugInfo();
		}
	}

	// Token: 0x0601528D RID: 86669 RVA: 0x005DBEA8 File Offset: 0x005DA0A8
	public void SimulateClickSubtitle()
	{
		if (Singleton<Info>.Instance.IsBuildShipping)
		{
			return;
		}
		this.OnBtnSubtitleSkipClick();
	}

	// Token: 0x0601528E RID: 86670 RVA: 0x005DBEC0 File Offset: 0x005DA0C0
	public void SimulateClickOption()
	{
		if (Singleton<Info>.Instance.IsBuildShipping)
		{
			return;
		}
		if (!this.SubtitleInfo.ShowOption)
		{
			return;
		}
		int recommendedOption = ControllerBase<FlowController>.Instance.GetRecommendedOption(null);
		PlotOptionItem[] optionList = this.GetOptionList();
		if (recommendedOption < optionList.Length)
		{
			PlotOptionItem plotOptionItem = optionList[recommendedOption];
			if (plotOptionItem != null)
			{
				plotOptionItem.OptionClick(new bool?(true));
			}
		}
	}

	// Token: 0x0601528F RID: 86671 RVA: 0x005DBF14 File Offset: 0x005DA114
	private UniTask SetBackgroundImage(ITalkBackground backgroundConfig, Action callback = null)
	{
		PlotSubtitleView.<SetBackgroundImage>d__197 <SetBackgroundImage>d__;
		<SetBackgroundImage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetBackgroundImage>d__.<>4__this = this;
		<SetBackgroundImage>d__.backgroundConfig = backgroundConfig;
		<SetBackgroundImage>d__.callback = callback;
		<SetBackgroundImage>d__.<>1__state = -1;
		<SetBackgroundImage>d__.<>t__builder.Start<PlotSubtitleView.<SetBackgroundImage>d__197>(ref <SetBackgroundImage>d__);
		return <SetBackgroundImage>d__.<>t__builder.Task;
	}

	// Token: 0x06015290 RID: 86672 RVA: 0x005DBF68 File Offset: 0x005DA168
	private UniTask OnPlotViewBgFadePhoto(bool isFadeIn, bool isFull, string path = null, Action callback = null)
	{
		PlotSubtitleView.<OnPlotViewBgFadePhoto>d__198 <OnPlotViewBgFadePhoto>d__;
		<OnPlotViewBgFadePhoto>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlotViewBgFadePhoto>d__.<>4__this = this;
		<OnPlotViewBgFadePhoto>d__.isFadeIn = isFadeIn;
		<OnPlotViewBgFadePhoto>d__.isFull = isFull;
		<OnPlotViewBgFadePhoto>d__.path = path;
		<OnPlotViewBgFadePhoto>d__.callback = callback;
		<OnPlotViewBgFadePhoto>d__.<>1__state = -1;
		<OnPlotViewBgFadePhoto>d__.<>t__builder.Start<PlotSubtitleView.<OnPlotViewBgFadePhoto>d__198>(ref <OnPlotViewBgFadePhoto>d__);
		return <OnPlotViewBgFadePhoto>d__.<>t__builder.Task;
	}

	// Token: 0x06015291 RID: 86673 RVA: 0x005DBFCC File Offset: 0x005DA1CC
	private void AddTickPhoto()
	{
		this.TickPhotoFade = true;
	}

	// Token: 0x06015292 RID: 86674 RVA: 0x005DBFD5 File Offset: 0x005DA1D5
	private void RemoveTickPhoto()
	{
		this.TickPhotoFade = false;
	}

	// Token: 0x06015293 RID: 86675 RVA: 0x005DBFE0 File Offset: 0x005DA1E0
	private float GetCurrentPercentPhoto()
	{
		float rangePct = Singleton<MathUtils>.Instance.GetRangePct(0f, 200f, this.FadeTimePhoto);
		if (this.IsAlreadyHavePhoto && this.IsFadeInPhoto)
		{
			this.BgWidgetFront.SetAlpha(rangePct);
		}
		else
		{
			if (!this.IsFadeInPhoto && this.BgWidget.GetAlpha() <= 0f)
			{
				return 0f;
			}
			this.BgWidget.SetAlpha(rangePct);
		}
		return rangePct;
	}

	// Token: 0x06015294 RID: 86676 RVA: 0x005DC054 File Offset: 0x005DA254
	private float GetCurrentPercentPhotoMiddle()
	{
		float rangePct = Singleton<MathUtils>.Instance.GetRangePct(0f, 200f, this.FadeTimePhoto);
		if (!this.IsFadeInPhoto && this.WidgetMiddle.GetAlpha() <= 0f)
		{
			return 0f;
		}
		this.WidgetMiddle.SetAlpha(rangePct);
		return rangePct;
	}

	// Token: 0x06015295 RID: 86677 RVA: 0x005DC0AC File Offset: 0x005DA2AC
	private void OnFadeTickPhoto(float deltaTime)
	{
		if (this.FadeTimePhoto < 0f)
		{
			this.FadeTimePhoto = 0f;
		}
		if (this.FadeTimePhoto > 200f)
		{
			this.FadeTimePhoto = 200f;
		}
		if (this.IsFadeInPhoto)
		{
			this.FadeTimePhoto += deltaTime;
			if (this.IsFullPhoto.GetValueOrDefault())
			{
				if (this.GetCurrentPercentPhoto() > 1f)
				{
					this.RemoveTickPhoto();
					this.OnCloseEventPhoto();
					return;
				}
			}
			else if (this.GetCurrentPercentPhotoMiddle() > 1f)
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
				if (this.GetCurrentPercentPhoto() <= 0f)
				{
					this.RemoveTickPhoto();
					this.OnCloseEventPhoto();
					return;
				}
			}
			else if (this.GetCurrentPercentPhotoMiddle() <= 0f)
			{
				this.RemoveTickPhoto();
				this.OnCloseEventPhoto();
			}
		}
	}

	// Token: 0x06015296 RID: 86678 RVA: 0x005DC190 File Offset: 0x005DA390
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
					CustomPromise<bool> plotFadeHidePromise = this.PlotFadeHidePromise;
					this.PlotFadeHidePromise = null;
					plotFadeHidePromise.SetResult(true);
				}
				else
				{
					CustomPromise<bool> plotFadeHidePromise2 = this.PlotFadeHidePromise;
					this.PlotFadeHidePromise = null;
					plotFadeHidePromise2.SetResult(true);
				}
				this.IsAlreadyHavePhoto = true;
			}
			else if (!this.IsFadeInPhoto && this.PlotFadeShowPromise != null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "Plot图片FadeOut结束", default(ReadOnlySpan<ValueTuple<string, object>>));
				CustomPromise<bool> plotFadeShowPromise = this.PlotFadeShowPromise;
				this.PlotFadeShowPromise = null;
				plotFadeShowPromise.SetResult(true);
				base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI", this.BgWidget, null, null);
				this.IsAlreadyHavePhoto = false;
			}
		}
		else if (this.IsFadeInPhoto && this.PlotFadeHidePromise != null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "Plot Middle图片FadeIn结束", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (this.IsAlreadyHavePhoto)
			{
				CustomPromise<bool> plotFadeHidePromise3 = this.PlotFadeHidePromise;
				this.PlotFadeHidePromise = null;
				plotFadeHidePromise3.SetResult(true);
			}
			else
			{
				CustomPromise<bool> plotFadeHidePromise4 = this.PlotFadeHidePromise;
				this.PlotFadeHidePromise = null;
				plotFadeHidePromise4.SetResult(true);
			}
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
			CustomPromise<bool> plotFadeShowPromise2 = this.PlotFadeShowPromise;
			this.PlotFadeShowPromise = null;
			plotFadeShowPromise2.SetResult(true);
			base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI", this.WidgetMiddle, null, null);
			this.IsAlreadyHavePhoto = false;
		}
		Action<ITalkItem> plotViewPhotoCallback = this.PlotViewPhotoCallback;
		if (plotViewPhotoCallback == null)
		{
			return;
		}
		plotViewPhotoCallback(null);
	}

	// Token: 0x06015297 RID: 86679 RVA: 0x005DC3A4 File Offset: 0x005DA5A4
	public UniTask FadeInBgPhoto(string path = null, Action callback = null)
	{
		PlotSubtitleView.<FadeInBgPhoto>d__205 <FadeInBgPhoto>d__;
		<FadeInBgPhoto>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FadeInBgPhoto>d__.<>4__this = this;
		<FadeInBgPhoto>d__.path = path;
		<FadeInBgPhoto>d__.callback = callback;
		<FadeInBgPhoto>d__.<>1__state = -1;
		<FadeInBgPhoto>d__.<>t__builder.Start<PlotSubtitleView.<FadeInBgPhoto>d__205>(ref <FadeInBgPhoto>d__);
		return <FadeInBgPhoto>d__.<>t__builder.Task;
	}

	// Token: 0x06015298 RID: 86680 RVA: 0x005DC3F8 File Offset: 0x005DA5F8
	public UniTask FadeOutBgPhoto(Action callback = null)
	{
		PlotSubtitleView.<FadeOutBgPhoto>d__206 <FadeOutBgPhoto>d__;
		<FadeOutBgPhoto>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FadeOutBgPhoto>d__.<>4__this = this;
		<FadeOutBgPhoto>d__.callback = callback;
		<FadeOutBgPhoto>d__.<>1__state = -1;
		<FadeOutBgPhoto>d__.<>t__builder.Start<PlotSubtitleView.<FadeOutBgPhoto>d__206>(ref <FadeOutBgPhoto>d__);
		return <FadeOutBgPhoto>d__.<>t__builder.Task;
	}

	// Token: 0x06015299 RID: 86681 RVA: 0x005DC444 File Offset: 0x005DA644
	public UniTask FadeInBgPhotoMiddle(string path = null, Action callback = null)
	{
		PlotSubtitleView.<FadeInBgPhotoMiddle>d__207 <FadeInBgPhotoMiddle>d__;
		<FadeInBgPhotoMiddle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FadeInBgPhotoMiddle>d__.<>4__this = this;
		<FadeInBgPhotoMiddle>d__.path = path;
		<FadeInBgPhotoMiddle>d__.callback = callback;
		<FadeInBgPhotoMiddle>d__.<>1__state = -1;
		<FadeInBgPhotoMiddle>d__.<>t__builder.Start<PlotSubtitleView.<FadeInBgPhotoMiddle>d__207>(ref <FadeInBgPhotoMiddle>d__);
		return <FadeInBgPhotoMiddle>d__.<>t__builder.Task;
	}

	// Token: 0x0601529A RID: 86682 RVA: 0x005DC498 File Offset: 0x005DA698
	public UniTask FadeOutBgPhotoMiddle(Action callback = null)
	{
		PlotSubtitleView.<FadeOutBgPhotoMiddle>d__208 <FadeOutBgPhotoMiddle>d__;
		<FadeOutBgPhotoMiddle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FadeOutBgPhotoMiddle>d__.<>4__this = this;
		<FadeOutBgPhotoMiddle>d__.callback = callback;
		<FadeOutBgPhotoMiddle>d__.<>1__state = -1;
		<FadeOutBgPhotoMiddle>d__.<>t__builder.Start<PlotSubtitleView.<FadeOutBgPhotoMiddle>d__208>(ref <FadeOutBgPhotoMiddle>d__);
		return <FadeOutBgPhotoMiddle>d__.<>t__builder.Task;
	}

	// Token: 0x0601529B RID: 86683 RVA: 0x005DC4E4 File Offset: 0x005DA6E4
	public UniTask RemovePhotoAtOnce()
	{
		PlotSubtitleView.<RemovePhotoAtOnce>d__209 <RemovePhotoAtOnce>d__;
		<RemovePhotoAtOnce>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RemovePhotoAtOnce>d__.<>4__this = this;
		<RemovePhotoAtOnce>d__.<>1__state = -1;
		<RemovePhotoAtOnce>d__.<>t__builder.Start<PlotSubtitleView.<RemovePhotoAtOnce>d__209>(ref <RemovePhotoAtOnce>d__);
		return <RemovePhotoAtOnce>d__.<>t__builder.Task;
	}

	// Token: 0x0601529C RID: 86684 RVA: 0x005DC527 File Offset: 0x005DA727
	[NullableContext(1)]
	private UUIItem GetSonUiParentForBackgroundUi(bool useFullscreenAdaptAnchor = false)
	{
		if (!useFullscreenAdaptAnchor)
		{
			return this.SonUi;
		}
		return this.FullscreenAdaptAnchor;
	}

	// Token: 0x0601529D RID: 86685 RVA: 0x005DC53C File Offset: 0x005DA73C
	[NullableContext(1)]
	public UniTask PreloadOpenBackgroundUi(TArray<string> uiNameArray, bool useFullscreenAdaptAnchor = false)
	{
		PlotSubtitleView.<PreloadOpenBackgroundUi>d__211 <PreloadOpenBackgroundUi>d__;
		<PreloadOpenBackgroundUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadOpenBackgroundUi>d__.<>4__this = this;
		<PreloadOpenBackgroundUi>d__.uiNameArray = uiNameArray;
		<PreloadOpenBackgroundUi>d__.useFullscreenAdaptAnchor = useFullscreenAdaptAnchor;
		<PreloadOpenBackgroundUi>d__.<>1__state = -1;
		<PreloadOpenBackgroundUi>d__.<>t__builder.Start<PlotSubtitleView.<PreloadOpenBackgroundUi>d__211>(ref <PreloadOpenBackgroundUi>d__);
		return <PreloadOpenBackgroundUi>d__.<>t__builder.Task;
	}

	// Token: 0x0601529E RID: 86686 RVA: 0x005DC590 File Offset: 0x005DA790
	[NullableContext(1)]
	public UniTask PrePreloadOpenBackgroundUi(List<string> uiNameArray, bool useFullscreenAdaptAnchor = false)
	{
		PlotSubtitleView.<PrePreloadOpenBackgroundUi>d__212 <PrePreloadOpenBackgroundUi>d__;
		<PrePreloadOpenBackgroundUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PrePreloadOpenBackgroundUi>d__.<>4__this = this;
		<PrePreloadOpenBackgroundUi>d__.uiNameArray = uiNameArray;
		<PrePreloadOpenBackgroundUi>d__.useFullscreenAdaptAnchor = useFullscreenAdaptAnchor;
		<PrePreloadOpenBackgroundUi>d__.<>1__state = -1;
		<PrePreloadOpenBackgroundUi>d__.<>t__builder.Start<PlotSubtitleView.<PrePreloadOpenBackgroundUi>d__212>(ref <PrePreloadOpenBackgroundUi>d__);
		return <PrePreloadOpenBackgroundUi>d__.<>t__builder.Task;
	}

	// Token: 0x0601529F RID: 86687 RVA: 0x005DC5E4 File Offset: 0x005DA7E4
	[NullableContext(1)]
	public UniTask OpenBackgroundUi(string uiName, string spineName, bool needLoop = true, bool useFullscreenAdaptAnchor = false)
	{
		PlotSubtitleView.<OpenBackgroundUi>d__213 <OpenBackgroundUi>d__;
		<OpenBackgroundUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenBackgroundUi>d__.<>4__this = this;
		<OpenBackgroundUi>d__.uiName = uiName;
		<OpenBackgroundUi>d__.spineName = spineName;
		<OpenBackgroundUi>d__.needLoop = needLoop;
		<OpenBackgroundUi>d__.useFullscreenAdaptAnchor = useFullscreenAdaptAnchor;
		<OpenBackgroundUi>d__.<>1__state = -1;
		<OpenBackgroundUi>d__.<>t__builder.Start<PlotSubtitleView.<OpenBackgroundUi>d__213>(ref <OpenBackgroundUi>d__);
		return <OpenBackgroundUi>d__.<>t__builder.Task;
	}

	// Token: 0x060152A0 RID: 86688 RVA: 0x005DC648 File Offset: 0x005DA848
	[NullableContext(1)]
	public UniTask OpenBackgroundUiForSeekSpine(string uiName, TArray<SpineThingsInfo> spineArray, bool useFullscreenAdaptAnchor = false)
	{
		PlotSubtitleView.<OpenBackgroundUiForSeekSpine>d__214 <OpenBackgroundUiForSeekSpine>d__;
		<OpenBackgroundUiForSeekSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenBackgroundUiForSeekSpine>d__.<>4__this = this;
		<OpenBackgroundUiForSeekSpine>d__.uiName = uiName;
		<OpenBackgroundUiForSeekSpine>d__.spineArray = spineArray;
		<OpenBackgroundUiForSeekSpine>d__.useFullscreenAdaptAnchor = useFullscreenAdaptAnchor;
		<OpenBackgroundUiForSeekSpine>d__.<>1__state = -1;
		<OpenBackgroundUiForSeekSpine>d__.<>t__builder.Start<PlotSubtitleView.<OpenBackgroundUiForSeekSpine>d__214>(ref <OpenBackgroundUiForSeekSpine>d__);
		return <OpenBackgroundUiForSeekSpine>d__.<>t__builder.Task;
	}

	// Token: 0x060152A1 RID: 86689 RVA: 0x005DC6A4 File Offset: 0x005DA8A4
	[NullableContext(1)]
	public UniTask PlayUiLevelSeq(string seqName)
	{
		PlotSubtitleView.<PlayUiLevelSeq>d__215 <PlayUiLevelSeq>d__;
		<PlayUiLevelSeq>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayUiLevelSeq>d__.<>4__this = this;
		<PlayUiLevelSeq>d__.seqName = seqName;
		<PlayUiLevelSeq>d__.<>1__state = -1;
		<PlayUiLevelSeq>d__.<>t__builder.Start<PlotSubtitleView.<PlayUiLevelSeq>d__215>(ref <PlayUiLevelSeq>d__);
		return <PlayUiLevelSeq>d__.<>t__builder.Task;
	}

	// Token: 0x060152A2 RID: 86690 RVA: 0x005DC6F0 File Offset: 0x005DA8F0
	public UniTask CloseBackgroundUiThis()
	{
		PlotSubtitleView.<CloseBackgroundUiThis>d__216 <CloseBackgroundUiThis>d__;
		<CloseBackgroundUiThis>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CloseBackgroundUiThis>d__.<>4__this = this;
		<CloseBackgroundUiThis>d__.<>1__state = -1;
		<CloseBackgroundUiThis>d__.<>t__builder.Start<PlotSubtitleView.<CloseBackgroundUiThis>d__216>(ref <CloseBackgroundUiThis>d__);
		return <CloseBackgroundUiThis>d__.<>t__builder.Task;
	}

	// Token: 0x060152A3 RID: 86691 RVA: 0x005DC734 File Offset: 0x005DA934
	[NullableContext(1)]
	public UniTask CloseWhichBackgroundUi(PlotChildView sonUi)
	{
		PlotSubtitleView.<CloseWhichBackgroundUi>d__217 <CloseWhichBackgroundUi>d__;
		<CloseWhichBackgroundUi>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CloseWhichBackgroundUi>d__.<>4__this = this;
		<CloseWhichBackgroundUi>d__.sonUi = sonUi;
		<CloseWhichBackgroundUi>d__.<>1__state = -1;
		<CloseWhichBackgroundUi>d__.<>t__builder.Start<PlotSubtitleView.<CloseWhichBackgroundUi>d__217>(ref <CloseWhichBackgroundUi>d__);
		return <CloseWhichBackgroundUi>d__.<>t__builder.Task;
	}

	// Token: 0x060152A4 RID: 86692 RVA: 0x005DC780 File Offset: 0x005DA980
	public void CloseSpineAnimation(string str, float blendOutTime = 0f)
	{
		if (string.IsNullOrEmpty(str))
		{
			return;
		}
		if (this.SonUiInclude == null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.JYS, "Ui预览图:不存在的PlotView子界面，关闭失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.SonUiInclude.CloseSpineAnimation(str, blendOutTime);
	}

	// Token: 0x060152A5 RID: 86693 RVA: 0x005DC7C8 File Offset: 0x005DA9C8
	public void PlaySonUiSpine(string spineName, bool needLoop = true, bool freeze = false, float duration = 0f)
	{
		if (string.IsNullOrEmpty(spineName))
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.JYS, "Ui预览图:SpineName为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.SonUiInclude != null)
		{
			this.SonUiInclude.PlaySpineAnimation(spineName, needLoop, freeze, duration);
			return;
		}
		Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.JYS, "Ui预览图:不存在的PlotView子界面,已加入队列", default(ReadOnlySpan<ValueTuple<string, object>>));
		SpineQueueInfo spineQueueInfo = new SpineQueueInfo();
		spineQueueInfo.Name = spineName;
		spineQueueInfo.NeedLoop = new bool?(needLoop);
		spineQueueInfo.Freeze = freeze;
		spineQueueInfo.MixDuration = 0f;
		Queue<SpineQueueInfo> spineQueue = this.SpineQueue;
		if (spineQueue == null)
		{
			return;
		}
		spineQueue.Push(spineQueueInfo);
	}

	// Token: 0x060152A6 RID: 86694 RVA: 0x005DC86C File Offset: 0x005DAA6C
	[NullableContext(1)]
	public void PlaySonUiSpineInArray(TArray<SpineThingsInfo> spineArray)
	{
		if (spineArray.Num() <= 0)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.JYS, "Ui预览图:spineArray为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.SonUiInclude == null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.JYS, "Ui预览图:不存在的PlotView子界面,已加入队列", default(ReadOnlySpan<ValueTuple<string, object>>));
			for (int i = 0; i < spineArray.Num(); i++)
			{
				SpineThingsInfo spineThingsInfo = spineArray.Get(i);
				SpineQueueInfo spineQueueInfo = new SpineQueueInfo();
				spineQueueInfo.Name = spineThingsInfo.Name;
				spineQueueInfo.NeedLoop = new bool?(spineThingsInfo.NeedLoop);
				Queue<SpineQueueInfo> spineQueue = this.SpineQueue;
				if (spineQueue != null)
				{
					spineQueue.Push(spineQueueInfo);
				}
			}
			return;
		}
		for (int j = 0; j < spineArray.Num(); j++)
		{
			this.SonUiInclude.PlaySpineAnimation(spineArray.Get(j).Name, spineArray.Get(j).NeedLoop, false, 0f);
		}
	}

	// Token: 0x060152A7 RID: 86695 RVA: 0x005DC954 File Offset: 0x005DAB54
	public void UpdateSpineForQte(float percentage)
	{
		if (this.SonUiInclude == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Plot, ELogAuthor.JYS, "Ui预览图:不存在的PlotView子界面,已加入队列", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		PlotChildView sonUiInclude = this.SonUiInclude;
		if (sonUiInclude == null)
		{
			return;
		}
		sonUiInclude.UpdateFrozenSpine(percentage);
	}

	// Token: 0x060152A8 RID: 86696 RVA: 0x005DC998 File Offset: 0x005DAB98
	[NullableContext(1)]
	public void UpdateSpineForQteByName(string spineName, float percentage)
	{
		if (this.SonUiInclude == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Plot, ELogAuthor.JYS, "Ui预览图:不存在的PlotView子界面,已加入队列", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		PlotChildView sonUiInclude = this.SonUiInclude;
		if (sonUiInclude == null)
		{
			return;
		}
		sonUiInclude.UpdateFrozenSpineByName(spineName, percentage);
	}

	// Token: 0x060152A9 RID: 86697 RVA: 0x005DC9DC File Offset: 0x005DABDC
	public void ManualUpdateNiagara([Nullable(new byte[]
	{
		2,
		1
	})] List<string> niagaraParamNames, float value)
	{
		if (niagaraParamNames == null || niagaraParamNames.Count == 0)
		{
			return;
		}
		if (this.SonUiInclude == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Plot, ELogAuthor.JYS, "Ui预览图:不存在的PlotView子界面,已加入队列", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		PlotChildView sonUiInclude = this.SonUiInclude;
		if (sonUiInclude == null)
		{
			return;
		}
		sonUiInclude.ManualUpdateNiagara(niagaraParamNames, value);
	}

	// Token: 0x060152AA RID: 86698 RVA: 0x005DCA2C File Offset: 0x005DAC2C
	[NullableContext(1)]
	public void RestoreFreezeSpine(string spineName, bool isLoop = false)
	{
		if (this.SonUiInclude == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Plot, ELogAuthor.JYS, "Ui预览图:不存在的PlotView子界面,已加入队列", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		PlotChildView sonUiInclude = this.SonUiInclude;
		if (sonUiInclude == null)
		{
			return;
		}
		sonUiInclude.RestoreFreezeSpine(spineName, isLoop);
	}

	// Token: 0x060152AB RID: 86699 RVA: 0x005DCA70 File Offset: 0x005DAC70
	public void RegisterCallback([Nullable(new byte[]
	{
		2,
		1
	})] Action<string> callback)
	{
		if (this.SonUiInclude == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Plot, ELogAuthor.JYS, "Ui预览图:不存在的PlotView子界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.SonUiInclude.FiniteSpineEndCallback = callback;
	}

	// Token: 0x060152AC RID: 86700 RVA: 0x005DCAB0 File Offset: 0x005DACB0
	private void DoSpineQueue()
	{
		if (this.SpineQueue == null || this.SonUiInclude == null)
		{
			return;
		}
		while (this.SpineQueue.Size > 0)
		{
			SpineQueueInfo spineQueueInfo = this.SpineQueue.First<SpineQueueInfo>();
			if (spineQueueInfo == null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.JYS, "Ui预览图:Queue播放但Spine队列异常", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.JYS;
			string message = "Ui预览图:Queue播放";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", spineQueueInfo);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.SonUiInclude.PlaySpineAnimation(spineQueueInfo.Name, spineQueueInfo.NeedLoop.Value, spineQueueInfo.Freeze, spineQueueInfo.MixDuration);
			this.SpineQueue.Pop();
		}
	}

	// Token: 0x060152AD RID: 86701 RVA: 0x005DCB6C File Offset: 0x005DAD6C
	[NullableContext(1)]
	[return: Nullable(2)]
	private unsafe PlotChildView FindSonViewInMap(string str)
	{
		if (this.SonUiIncludeMap == null)
		{
			return null;
		}
		PlotChildView plotChildView;
		if (this.SonUiIncludeMap.TryGetValue(str, out plotChildView))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.JYS;
			string message = "Ui预览图:FindSonViewInMap 找到对应的预制体";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", str);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("son", plotChildView);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return plotChildView;
		}
		return null;
	}

	// Token: 0x060152AE RID: 86702 RVA: 0x005DCBEC File Offset: 0x005DADEC
	[NullableContext(1)]
	private unsafe void DeleteSonViewInMap(PlotChildView childView)
	{
		if (this.SonUiIncludeMap == null)
		{
			return;
		}
		string text = null;
		foreach (KeyValuePair<string, PlotChildView> keyValuePair in this.SonUiIncludeMap)
		{
			if (childView == keyValuePair.Value)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.JYS;
				string message = "Ui预览图:DeleteSonViewInMap 找到对应的预制体";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", keyValuePair.Key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("son", keyValuePair.Value);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				text = keyValuePair.Key;
				break;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			this.SonUiIncludeMap.Remove(text);
		}
	}

	// Token: 0x060152AF RID: 86703 RVA: 0x005DCCD0 File Offset: 0x005DAED0
	[NullableContext(1)]
	public void SetIconBySequence(bool bShow, UTexture2D texture, BP_KuroMasterSeqEvent_C obj)
	{
		if (bShow)
		{
			this.TickIconAlpha = true;
			this.EventObject = obj;
			UUITexture widgetMiddle = this.WidgetMiddle;
			if (widgetMiddle != null)
			{
				widgetMiddle.SetTexture(texture);
			}
			UUITexture widgetMiddle2 = this.WidgetMiddle;
			if (widgetMiddle2 != null)
			{
				widgetMiddle2.SetUIActive(true);
			}
			UUISprite bgWidgetMiddle = this.BgWidgetMiddle;
			if (bgWidgetMiddle == null)
			{
				return;
			}
			bgWidgetMiddle.SetUIActive(true);
			return;
		}
		else
		{
			this.TickIconAlpha = false;
			this.EventObject = null;
			base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI", this.WidgetMiddle, null, null);
			UUITexture widgetMiddle3 = this.WidgetMiddle;
			if (widgetMiddle3 != null)
			{
				widgetMiddle3.SetUIActive(false);
			}
			UUISprite bgWidgetMiddle2 = this.BgWidgetMiddle;
			if (bgWidgetMiddle2 == null)
			{
				return;
			}
			bgWidgetMiddle2.SetUIActive(false);
			return;
		}
	}

	// Token: 0x060152B0 RID: 86704 RVA: 0x005DCD70 File Offset: 0x005DAF70
	private void TickDebugInfo()
	{
		bool shouldShowDebugInfoOnView = ModelBase<PlotModel>.Instance.ShouldShowDebugInfoOnView;
		UUIText text = base.GetText(42);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(shouldShowDebugInfoOnView);
		if (!shouldShowDebugInfoOnView)
		{
			return;
		}
		string currentSequenceDebugInfo = ControllerBase<SequenceController>.Instance.GetCurrentSequenceDebugInfo();
		text.SetText(currentSequenceDebugInfo, true);
	}

	// Token: 0x0400A29D RID: 41629
	private string SubtitleKey = "";

	// Token: 0x0400A29E RID: 41630
	[Nullable(1)]
	public readonly List<string> OptionKeys = new List<string>();

	// Token: 0x0400A29F RID: 41631
	[Nullable(1)]
	public readonly List<int> OsList = new List<int>();

	// Token: 0x0400A2A0 RID: 41632
	private string AudioKey = "";

	// Token: 0x0400A2A1 RID: 41633
	private SubtitleInfo SubtitleInfo;

	// Token: 0x0400A2A2 RID: 41634
	private ULGUIPlayTweenComponent SubtitleAnimation;

	// Token: 0x0400A2A3 RID: 41635
	private UUIEffectTextAnimation SubtitleAnimDataComp;

	// Token: 0x0400A2A4 RID: 41636
	private bool IsCurSubtitlePaused;

	// Token: 0x0400A2A5 RID: 41637
	[Nullable(1)]
	private readonly PlayResult NormalPlayEventResult = new PlayResult();

	// Token: 0x0400A2A6 RID: 41638
	[Nullable(1)]
	private readonly PlayResult IndependentPlayEventResult = new PlayResult();

	// Token: 0x0400A2A7 RID: 41639
	private double AudioStartTime;

	// Token: 0x0400A2A8 RID: 41640
	private float Duration;

	// Token: 0x0400A2A9 RID: 41641
	private TimerHandle AudioDelayTimerId;

	// Token: 0x0400A2AA RID: 41642
	private PlotAudio? AudioConfig;

	// Token: 0x0400A2AB RID: 41643
	private UUIItem SkipSubtitleTipItem;

	// Token: 0x0400A2AC RID: 41644
	private TimerHandle WaitingSkipTimerId;

	// Token: 0x0400A2AD RID: 41645
	public int HoverIndex;

	// Token: 0x0400A2AE RID: 41646
	private AUIContainerActor ScreenEffectPlotRoot;

	// Token: 0x0400A2AF RID: 41647
	[Nullable(new byte[]
	{
		2,
		1,
		2
	})]
	private GenericLayout<PlotOptionItem, object> OptionLayout;

	// Token: 0x0400A2B0 RID: 41648
	private bool IsOptionShow;

	// Token: 0x0400A2B1 RID: 41649
	private PlotSkipComponent SkipComp;

	// Token: 0x0400A2B2 RID: 41650
	private PlotReviewComponent ReviewComp;

	// Token: 0x0400A2B3 RID: 41651
	private bool IsVisible = true;

	// Token: 0x0400A2B4 RID: 41652
	private bool ImmersiveInputWakeState = true;

	// Token: 0x0400A2B5 RID: 41653
	private bool? MainButtonsTweenShown;

	// Token: 0x0400A2B6 RID: 41654
	private bool? SkipTweenShown;

	// Token: 0x0400A2B7 RID: 41655
	private bool? ReviewTweenShown;

	// Token: 0x0400A2B8 RID: 41656
	private bool PendingImmersiveSleep;

	// Token: 0x0400A2B9 RID: 41657
	private TimerHandle PendingImmersiveSleepTimerId;

	// Token: 0x0400A2BA RID: 41658
	private TimerHandle SizeChangedTimerId;

	// Token: 0x0400A2BB RID: 41659
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap;

	// Token: 0x0400A2BC RID: 41660
	private PlotOptionItem SelectedPlotOptionItem;

	// Token: 0x0400A2BD RID: 41661
	private EPlotLevel? Level;

	// Token: 0x0400A2BE RID: 41662
	private EPlotLevel? SubtitleLevel;

	// Token: 0x0400A2BF RID: 41663
	[Nullable(1)]
	public List<PlotOption> CurOption = new List<PlotOption>();

	// Token: 0x0400A2C0 RID: 41664
	private float FadeTimePhoto;

	// Token: 0x0400A2C1 RID: 41665
	private bool IsFadeInPhoto;

	// Token: 0x0400A2C2 RID: 41666
	private bool TickPhotoFade;

	// Token: 0x0400A2C3 RID: 41667
	private bool IsAlreadyHavePhoto;

	// Token: 0x0400A2C4 RID: 41668
	private bool? IsFullPhoto;

	// Token: 0x0400A2C5 RID: 41669
	private bool IsBlackBgShow;

	// Token: 0x0400A2C6 RID: 41670
	private bool CanShowAutoButtonByPlotConfig = true;

	// Token: 0x0400A2C7 RID: 41671
	private bool CanShowHideButtonByPlotConfig = true;

	// Token: 0x0400A2C8 RID: 41672
	private bool CanShowReviewButtonByPlotConfig = true;

	// Token: 0x0400A2C9 RID: 41673
	[Nullable(1)]
	private readonly Dictionary<string, bool> DisableInteractSources = new Dictionary<string, bool>();

	// Token: 0x0400A2CA RID: 41674
	private UUITexture BgWidget;

	// Token: 0x0400A2CB RID: 41675
	private UUITexture BgWidgetFront;

	// Token: 0x0400A2CC RID: 41676
	private UUITexture WidgetMiddle;

	// Token: 0x0400A2CD RID: 41677
	private UUISprite BgWidgetMiddle;

	// Token: 0x0400A2CE RID: 41678
	private CustomPromise<bool> PlotFadeShowPromise;

	// Token: 0x0400A2CF RID: 41679
	private CustomPromise<bool> PlotFadeHidePromise;

	// Token: 0x0400A2D0 RID: 41680
	private Action<ITalkItem> PlotViewPhotoCallback;

	// Token: 0x0400A2D1 RID: 41681
	private ETalkBackgroundType? NowBackgroundConfig;

	// Token: 0x0400A2D2 RID: 41682
	private UUIItem SonUi;

	// Token: 0x0400A2D3 RID: 41683
	private UUIItem FullscreenAdaptAnchor;

	// Token: 0x0400A2D4 RID: 41684
	public PlotChildView SonUiInclude;

	// Token: 0x0400A2D5 RID: 41685
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<string, PlotChildView> SonUiIncludeMap;

	// Token: 0x0400A2D6 RID: 41686
	private TimerHandle BlockOptionTimer;

	// Token: 0x0400A2D7 RID: 41687
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Queue<SpineQueueInfo> SpineQueue;

	// Token: 0x0400A2D8 RID: 41688
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Queue<PlotChildView> SonUiQueue;

	// Token: 0x0400A2D9 RID: 41689
	private UUISliderComponent OptionLimitBar;

	// Token: 0x0400A2DA RID: 41690
	private UUISliderComponent AutoSelectTimeBar;

	// Token: 0x0400A2DB RID: 41691
	[Nullable(1)]
	private readonly PlotAutoSelectOptionComponent AutoSelectOptionComponent = new PlotAutoSelectOptionComponent();

	// Token: 0x0400A2DC RID: 41692
	[Nullable(1)]
	private readonly PlotAudioDelegate AudioDelegate = new PlotAudioDelegate();

	// Token: 0x0400A2DD RID: 41693
	private TimerHandle AudioPlayTimer;

	// Token: 0x0400A2DE RID: 41694
	private TimerHandle DelayAutoPlayTimer;

	// Token: 0x0400A2DF RID: 41695
	private float TextScrollViewPrefabHeight;

	// Token: 0x0400A2E0 RID: 41696
	private TimerHandle ScrollStartTimer;

	// Token: 0x0400A2E1 RID: 41697
	public bool HasChildViewPreloaded;

	// Token: 0x0400A2E2 RID: 41698
	private bool MuteTimeLimitedOption;

	// Token: 0x0400A2E3 RID: 41699
	private float ScrollTotalTime;

	// Token: 0x0400A2E4 RID: 41700
	private float CurrentAnimTime;

	// Token: 0x0400A2E5 RID: 41701
	private TimerHandle TextScrollAnimTimer;

	// Token: 0x0400A2E6 RID: 41702
	private TimerHandle DelayTextScrollAnimTimer;

	// Token: 0x0400A2E7 RID: 41703
	private IPostAkEventType LastEndEvent;

	// Token: 0x0400A2E8 RID: 41704
	private bool TickIconAlpha;

	// Token: 0x0400A2E9 RID: 41705
	private BP_KuroMasterSeqEvent_C EventObject;

	// Token: 0x02008CBD RID: 36029
	[NullableContext(0)]
	private enum EPlotChildCom
	{
		// Token: 0x0402F587 RID: 193927
		BtnAuto,
		// Token: 0x0402F588 RID: 193928
		BtnNextPage,
		// Token: 0x0402F589 RID: 193929
		BtnSkip,
		// Token: 0x0402F58A RID: 193930
		PlotText,
		// Token: 0x0402F58B RID: 193931
		NPCName,
		// Token: 0x0402F58C RID: 193932
		TxtList,
		// Token: 0x0402F58D RID: 193933
		OptionItem,
		// Token: 0x0402F58E RID: 193934
		OptionLayout,
		// Token: 0x0402F58F RID: 193935
		TextList,
		// Token: 0x0402F590 RID: 193936
		PlotBg,
		// Token: 0x0402F591 RID: 193937
		PlotTextUHD,
		// Token: 0x0402F592 RID: 193938
		PanelLine,
		// Token: 0x0402F593 RID: 193939
		TxtFloat,
		// Token: 0x0402F594 RID: 193940
		ScreenEffect,
		// Token: 0x0402F595 RID: 193941
		AutoPlayManualItem,
		// Token: 0x0402F596 RID: 193942
		AutuPlaySemiAutoItem,
		// Token: 0x0402F597 RID: 193943
		AutuPlayAutoItem,
		// Token: 0x0402F598 RID: 193944
		NPCTitle,
		// Token: 0x0402F599 RID: 193945
		BtnHide,
		// Token: 0x0402F59A RID: 193946
		NextIcon,
		// Token: 0x0402F59B RID: 193947
		WaitingPoint,
		// Token: 0x0402F59C RID: 193948
		BlackScreenBg,
		// Token: 0x0402F59D RID: 193949
		PhotoScreenBg,
		// Token: 0x0402F59E RID: 193950
		PhotoScreenBgFront,
		// Token: 0x0402F59F RID: 193951
		DoingText,
		// Token: 0x0402F5A0 RID: 193952
		PhotoScreenMiddle,
		// Token: 0x0402F5A1 RID: 193953
		PhotoScreenBgMiddle,
		// Token: 0x0402F5A2 RID: 193954
		TextScrollView,
		// Token: 0x0402F5A3 RID: 193955
		OptionAdjustItem,
		// Token: 0x0402F5A4 RID: 193956
		PnlBg,
		// Token: 0x0402F5A5 RID: 193957
		PnlInfo,
		// Token: 0x0402F5A6 RID: 193958
		SonUi,
		// Token: 0x0402F5A7 RID: 193959
		BlockOption,
		// Token: 0x0402F5A8 RID: 193960
		BtnReview,
		// Token: 0x0402F5A9 RID: 193961
		OptionLimitBar,
		// Token: 0x0402F5AA RID: 193962
		VideoLayout,
		// Token: 0x0402F5AB RID: 193963
		AniSkipIn,
		// Token: 0x0402F5AC RID: 193964
		AniSkipOut,
		// Token: 0x0402F5AD RID: 193965
		AniReviewIn,
		// Token: 0x0402F5AE RID: 193966
		AniReviewOut,
		// Token: 0x0402F5AF RID: 193967
		AniAutoHideIn,
		// Token: 0x0402F5B0 RID: 193968
		AniAutoHideOut,
		// Token: 0x0402F5B1 RID: 193969
		TextDebugInfo,
		// Token: 0x0402F5B2 RID: 193970
		FullscreenAdaptAnchor,
		// Token: 0x0402F5B3 RID: 193971
		ImportantList,
		// Token: 0x0402F5B4 RID: 193972
		PnlLayout02,
		// Token: 0x0402F5B5 RID: 193973
		TextScrollViewCopy,
		// Token: 0x0402F5B6 RID: 193974
		ImportantOptionTipsIcon,
		// Token: 0x0402F5B7 RID: 193975
		ImportantOptionTipsText,
		// Token: 0x0402F5B8 RID: 193976
		AutoSelectTimeBar,
		// Token: 0x0402F5B9 RID: 193977
		AutoSelectText,
		// Token: 0x0402F5BA RID: 193978
		AniAutoTextIn,
		// Token: 0x0402F5BB RID: 193979
		AniAutoTextOut
	}
}
