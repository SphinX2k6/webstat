using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053CE RID: 21454
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotView : UiTickViewBase, ISimulatePlot
	{
		// Token: 0x06036BA6 RID: 224166 RVA: 0x00DE0388 File Offset: 0x00DDE588
		[NullableContext(1)]
		public PlotView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x17008DB7 RID: 36279
		// (get) Token: 0x06036BA7 RID: 224167 RVA: 0x00DE03DE File Offset: 0x00DDE5DE
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

		// Token: 0x17008DB8 RID: 36280
		// (get) Token: 0x06036BA8 RID: 224168 RVA: 0x00DE03F1 File Offset: 0x00DDE5F1
		public ITalkItem CurrentSubtitle
		{
			get
			{
				return this.CommonLogic.CurrentContent;
			}
		}

		// Token: 0x17008DB9 RID: 36281
		// (get) Token: 0x06036BA9 RID: 224169 RVA: 0x00DE03FE File Offset: 0x00DDE5FE
		public bool HasOptions
		{
			get
			{
				return this.CurrentSubtitle != null && this.CurrentSubtitle.Options != null && this.CurrentSubtitle.Options.Count != 0;
			}
		}

		// Token: 0x06036BAA RID: 224170 RVA: 0x00DE042C File Offset: 0x00DDE62C
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
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnAutoClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(18, new Action(this.OnBtnHideClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(33, new Action(this.OnBtnReviewClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06036BAB RID: 224171 RVA: 0x00DE0BDC File Offset: 0x00DDEDDC
		protected override void OnStart()
		{
			base.GetRootItem().GetRenderCanvas().bPostTickUpdate = false;
			UUIScrollViewComponent scrollView = base.GetScrollView(27);
			if (scrollView != null)
			{
				scrollView.SetCanScroll(false);
			}
			if (scrollView != null)
			{
				scrollView.SetRayCastTargetForScrollView(false);
			}
			UUIText text = base.GetText(42);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			this.CommonLogic = new PlotTextCommonLogic(base.GetItem(3), base.GetText(4), base.GetText(17), base.GetText(5), base.GetItem(11), scrollView, this, base.GetLayoutBase(7), base.GetItem(6), base.GetSlider(34), this.UiViewSequence, base.GetItem(32), base.GetItem(28), base.GetItem(44), base.GetTexture(47), base.GetText(48), delegate(string path, UUITexture texture)
			{
				base.SetTextureByPath(path, texture, null, null);
			}, base.GetSlider(49), delegate()
			{
				this.UpdateAutoPlayButton();
			}, base.GetItem(45));
			this.CommonLogic.SetPlotContentAnimFinishCallback(new Action(this.HandleSubtitleAnimFinished));
			base.GetButton(2).RootUIComp.Get().SetUIActive(false);
			this.SkipComp = new PlotSkipComponent(base.GetButton(2), new Action(this.OnSkip), new Action(this.OnSkipPop), null, new Action(this.OnSkipCancel), null, null);
			this.SkipComp.EnableSkipButton(false);
			base.GetButton(33).RootUIComp.Get().SetUIActive(false);
			this.ReviewComp = new PlotReviewComponent(base.GetButton(33), new Action(this.OnBtnReviewClick));
			this.ReviewComp.EnableReviewButton(false);
			this.SkipSubtitleTipItem = base.GetItem(19);
			this.SkipSubtitleTipItemActive(false);
			this.ShowWaitingPoint(false);
			this.UpdateByPlotConfig();
			this.AddScreenEffectPlotRoot();
			this.InitTweenAnim(36);
			this.InitTweenAnim(37);
			this.InitTweenAnim(38);
			this.InitTweenAnim(39);
			this.InitTweenAnim(40);
			this.InitTweenAnim(41);
			this.InitTweenAnim(51);
			this.InitTweenAnim(52);
			this.FadeTimePhoto = 0f;
			this.FadeTimeBlackScreen = 0f;
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
			this.BlackBgWidget = base.GetSprite(21);
			if (this.BlackBgWidget != null)
			{
				this.BlackBgWidget.SetAlpha(0f);
			}
			this.IsVisible = true;
		}

		// Token: 0x06036BAC RID: 224172 RVA: 0x00DE0ECC File Offset: 0x00DDF0CC
		private void ShowBlackBg(bool isShow, bool useAnim = true)
		{
			if (isShow == this.IsShowBlackBg)
			{
				return;
			}
			this.IsShowBlackBg = isShow;
			if (isShow)
			{
				base.GetSprite(9).SetUIActive(true);
				if (useAnim)
				{
					base.PlaySequence("PlotStart", null, false);
					return;
				}
			}
			else
			{
				if (useAnim)
				{
					base.PlaySequence("PlotClose", null, false);
					return;
				}
				base.GetSprite(9).SetUIActive(false);
			}
		}

		// Token: 0x06036BAD RID: 224173 RVA: 0x00DE0F2C File Offset: 0x00DDF12C
		private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
		{
			this.UpdateAutoSelectText();
			EPlotLevel? subtitleLevel = ModelBase<PlotModel>.Instance.PlotConfig.SubtitleLevel;
			if (subtitleLevel.GetValueOrDefault() != EPlotLevel.LevelC || !ModelBase<PlotModel>.Instance.IsUseNewLevelBStyle())
			{
				return;
			}
			UUIItem item = base.GetItem(45);
			if (item != null)
			{
				item.SetAnchorOffsetY(PlotView.GetPnlLayout02OffsetY(now));
			}
		}

		// Token: 0x06036BAE RID: 224174 RVA: 0x00DE0F7E File Offset: 0x00DDF17E
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

		// Token: 0x06036BAF RID: 224175 RVA: 0x00DE0F9C File Offset: 0x00DDF19C
		private void UpdatePnlLayout02Offset()
		{
			EPlotLevel? subtitleLevel = ModelBase<PlotModel>.Instance.PlotConfig.SubtitleLevel;
			UUIItem item = base.GetItem(45);
			if (subtitleLevel.GetValueOrDefault() == EPlotLevel.LevelC && ModelBase<PlotModel>.Instance.IsUseNewLevelBStyle())
			{
				if (item != null)
				{
					item.SetAnchorOffsetY(PlotView.GetPnlLayout02OffsetY(Singleton<Info>.Instance.InputControllerMainType));
					return;
				}
			}
			else if (item != null)
			{
				item.SetAnchorOffsetY(0f);
			}
		}

		// Token: 0x06036BB0 RID: 224176 RVA: 0x00DE1000 File Offset: 0x00DDF200
		protected override UniTask OnPlayingStartSequenceAsync()
		{
			PlotView.<OnPlayingStartSequenceAsync>d__65 <OnPlayingStartSequenceAsync>d__;
			<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingStartSequenceAsync>d__.<>4__this = this;
			<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
			<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<PlotView.<OnPlayingStartSequenceAsync>d__65>(ref <OnPlayingStartSequenceAsync>d__);
			return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036BB1 RID: 224177 RVA: 0x00DE1044 File Offset: 0x00DDF244
		protected override UniTask OnPlayingCloseSequenceAsync()
		{
			PlotView.<OnPlayingCloseSequenceAsync>d__66 <OnPlayingCloseSequenceAsync>d__;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
			<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<PlotView.<OnPlayingCloseSequenceAsync>d__66>(ref <OnPlayingCloseSequenceAsync>d__);
			return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036BB2 RID: 224178 RVA: 0x00DE1087 File Offset: 0x00DDF287
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

		// Token: 0x06036BB3 RID: 224179 RVA: 0x00DE10BF File Offset: 0x00DDF2BF
		private void InitButtonsVisibilityByImmersiveMode()
		{
			if (Singleton<InputManager>.Instance.IsImmersiveMouseModeEnabled())
			{
				this.ImmersiveInputWakeState = Singleton<InputManager>.Instance.IsShowMouseCursor();
				this.UpdatePlotButtonsVisibility(this.ImmersiveInputWakeState);
			}
		}

		// Token: 0x06036BB4 RID: 224180 RVA: 0x00DE10EC File Offset: 0x00DDF2EC
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Emit<EUiViewName, bool>(EEventName.PlotViewChange, this.ViewInfo.Name, false);
			ModelBase<PlotModel>.Instance.OptionEnable = true;
			this.IsAlreadyHavePhoto = false;
			this.FadeTimePhoto = 0f;
			this.FadeTimeBlackScreen = 0f;
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
			base.GetItem(32).SetUIActive(false);
			this.CloseChildView().Forget();
			this.ClearPendingImmersiveSleep();
		}

		// Token: 0x06036BB5 RID: 224181 RVA: 0x00DE1194 File Offset: 0x00DDF394
		protected override void OnBeforeDestroy()
		{
			this.CommonLogic.Clear();
			this.ClearPendingImmersiveSleep();
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
			PlotReviewComponent reviewComp = this.ReviewComp;
			if (reviewComp != null)
			{
				reviewComp.OnClear();
			}
			this.ReviewComp = null;
		}

		// Token: 0x06036BB6 RID: 224182 RVA: 0x00DE1200 File Offset: 0x00DDF400
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
			Singleton<EventSystem>.Instance.Add<ShowTalk>(EEventName.PlotStartShowTalk, new Action<ShowTalk>(this.OnShowTalkStart));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerPlotForward, new Action<float>(this.OnNavigationTriggerPlotForward));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerPlotRight, new Action<float>(this.OnNavigationTriggerPlotRight));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerPlotZoom, new Action<float>(this.OnNavigationTriggerPlotZoom));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Add<ETermExplanationViewType>(EEventName.OnTermExplanationViewOpening, new Action<ETermExplanationViewType>(this.OnTermExplanationViewOpen));
			Singleton<EventSystem>.Instance.Add(EEventName.OnTermExplanationViewClosed, new Action(this.OnTermExplanationViewClose));
			Singleton<EventSystem>.Instance.Add<EInputControllerMainType, bool>(EEventName.OnImmersiveInputStateChange, new Action<EInputControllerMainType, bool>(this.OnImmersiveInputStateChange));
			Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
			Singleton<EventSystem>.Instance.Add(EEventName.UIViewPortSizeChanged, new Action(this.OnSizeChanged));
			ControllerBase<InputDistributeController>.Instance.BindTouch(0, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouchPlotVisible));
			this.SkipComp.AddEventListener();
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.EnableSkipPlot, new Action<bool>(this.OnEnableSkipPlotRestoreTween));
			UUIDraggableComponent uuidraggableComponent = base.GetButton(1).RootUIComp.Get().GetOwner().GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent;
			if (uuidraggableComponent != null)
			{
				uuidraggableComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDragCallBack));
				uuidraggableComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallBack));
				uuidraggableComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndDragCallBack));
				uuidraggableComponent.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnBtnSubtitleSkipClick));
				uuidraggableComponent.OnPointerScrollCallBack.Bind(this.OnPointerScrollCallBack);
			}
			UUIItem item = base.GetItem(3);
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlink(base.GetText(5), ETermExplanationViewType.Center, ETermExplanationReportType.Plot, ETermExplanationViewAttachDirection.Up, item, null, null, ETermExplanationGroup.Default, 0, ETermExplanationViewStyle.Default);
		}

		// Token: 0x06036BB7 RID: 224183 RVA: 0x00DE1558 File Offset: 0x00DDF758
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
			Singleton<EventSystem>.Instance.Remove<ShowTalk>(EEventName.PlotStartShowTalk, new Action<ShowTalk>(this.OnShowTalkStart));
			Singleton<EventSystem>.Instance.Remove<float>(EEventName.NavigationTriggerPlotForward, new Action<float>(this.OnNavigationTriggerPlotForward));
			Singleton<EventSystem>.Instance.Remove<float>(EEventName.NavigationTriggerPlotRight, new Action<float>(this.OnNavigationTriggerPlotRight));
			Singleton<EventSystem>.Instance.Remove<float>(EEventName.NavigationTriggerPlotZoom, new Action<float>(this.OnNavigationTriggerPlotZoom));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Remove<ETermExplanationViewType>(EEventName.OnTermExplanationViewOpening, new Action<ETermExplanationViewType>(this.OnTermExplanationViewOpen));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnTermExplanationViewClosed, new Action(this.OnTermExplanationViewClose));
			Singleton<EventSystem>.Instance.Remove<EInputControllerMainType, bool>(EEventName.OnImmersiveInputStateChange, new Action<EInputControllerMainType, bool>(this.OnImmersiveInputStateChange));
			Singleton<EventSystem>.Instance.Remove<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.UIViewPortSizeChanged, new Action(this.OnSizeChanged));
			PlotSkipComponent skipComp = this.SkipComp;
			if (skipComp != null)
			{
				skipComp.RemoveEventListener();
			}
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.EnableSkipPlot, new Action<bool>(this.OnEnableSkipPlotRestoreTween));
			ControllerBase<InputDistributeController>.Instance.UnBindTouch(0, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouchPlotVisible));
			UUIDraggableComponent uuidraggableComponent = base.GetButton(1).RootUIComp.Get().GetOwner().GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent;
			if (uuidraggableComponent != null)
			{
				uuidraggableComponent.OnPointerBeginDragCallBack.Unbind();
				uuidraggableComponent.OnPointerDragCallBack.Unbind();
				uuidraggableComponent.OnPointerEndDragCallBack.Unbind();
				uuidraggableComponent.OnPointerUpCallBack.Unbind();
				uuidraggableComponent.OnPointerScrollCallBack.Unbind();
			}
			ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(5));
		}

		// Token: 0x06036BB8 RID: 224184 RVA: 0x00DE1864 File Offset: 0x00DDFA64
		private void OnSizeChanged()
		{
			base.GetRootItem().GetRenderCanvas().bPostTickUpdate = true;
			TimerSystem.Instance.Next(delegate(float _)
			{
				if (base.GetRootItem().IsValid())
				{
					base.GetRootItem().GetRenderCanvas().bPostTickUpdate = false;
				}
			}, null, null);
		}

		// Token: 0x06036BB9 RID: 224185 RVA: 0x00DE1890 File Offset: 0x00DDFA90
		private void OnTermExplanationViewOpen(ETermExplanationViewType _)
		{
			this.MuteAutoPlay(true);
		}

		// Token: 0x06036BBA RID: 224186 RVA: 0x00DE1899 File Offset: 0x00DDFA99
		private void OnTermExplanationViewClose()
		{
			this.MuteAutoPlay(false);
		}

		// Token: 0x06036BBB RID: 224187 RVA: 0x00DE18A4 File Offset: 0x00DDFAA4
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

		// Token: 0x06036BBC RID: 224188 RVA: 0x00DE1900 File Offset: 0x00DDFB00
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
			PlotTextCommonLogic commonLogic = this.CommonLogic;
			if (commonLogic == null)
			{
				return;
			}
			commonLogic.OnImmersiveInputStateChange();
		}

		// Token: 0x06036BBD RID: 224189 RVA: 0x00DE1964 File Offset: 0x00DDFB64
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

		// Token: 0x06036BBE RID: 224190 RVA: 0x00DE19E7 File Offset: 0x00DDFBE7
		private void ClearPendingImmersiveSleep()
		{
			this.PendingImmersiveSleep = false;
			if (this.PendingImmersiveSleepTimerId != null && TimerSystem.Instance.Has(this.PendingImmersiveSleepTimerId))
			{
				TimerSystem.Instance.Remove(this.PendingImmersiveSleepTimerId);
			}
			this.PendingImmersiveSleepTimerId = null;
		}

		// Token: 0x06036BBF RID: 224191 RVA: 0x00DE1A24 File Offset: 0x00DDFC24
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
			this.TweenAnimMap.Add(componentType, list);
		}

		// Token: 0x06036BC0 RID: 224192 RVA: 0x00DE1A98 File Offset: 0x00DDFC98
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

		// Token: 0x06036BC1 RID: 224193 RVA: 0x00DE1AF4 File Offset: 0x00DDFCF4
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

		// Token: 0x06036BC2 RID: 224194 RVA: 0x00DE1B50 File Offset: 0x00DDFD50
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

		// Token: 0x06036BC3 RID: 224195 RVA: 0x00DE1C74 File Offset: 0x00DDFE74
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

		// Token: 0x06036BC4 RID: 224196 RVA: 0x00DE1D7E File Offset: 0x00DDFF7E
		private void OnEnableSkipPlotRestoreTween(bool _)
		{
			this.RestorePlotButtonsVisibility();
		}

		// Token: 0x06036BC5 RID: 224197 RVA: 0x00DE1D88 File Offset: 0x00DDFF88
		private void MuteAutoPlay(bool isMute)
		{
			if (isMute)
			{
				this.CommonLogic.MuteTimeLimitedOption = true;
				ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState = EAutoPlayState.Manual;
				TimerHandle delayId = this.DelayId;
				if (delayId != null)
				{
					delayId.Pause();
				}
				this.UpdateAutoPlayButton();
				this.CommonLogic.OnAutoPlayStateChanged();
				return;
			}
			this.CommonLogic.MuteTimeLimitedOption = false;
			PlotConfig plotConfig = ModelBase<PlotModel>.Instance.PlotConfig;
			plotConfig.AutoPlayState = plotConfig.AutoPlayStateCache;
			this.UpdateAutoPlayButton();
			this.CommonLogic.OnAutoPlayStateChanged();
			if (TimerSystem.Instance.Has(this.DelayId) && this.DelayId.IsPause())
			{
				TimerHandle delayId2 = this.DelayId;
				if (delayId2 != null)
				{
					delayId2.Resume();
				}
			}
			if (plotConfig.AutoPlayState != EAutoPlayState.Manual && this.IsSubtitleFinishDelay)
			{
				this.SkipSubtitleTipItemActive(false);
				this.HandleSubtitleActions();
			}
		}

		// Token: 0x06036BC6 RID: 224198 RVA: 0x00DE1E58 File Offset: 0x00DE0058
		[NullableContext(1)]
		private void OnShowTalkStart(ShowTalk inShowTalk)
		{
			PlotSkipComponent skipComp = this.SkipComp;
			if (skipComp == null)
			{
				return;
			}
			skipComp.AddSummary(inShowTalk.TalkOutline);
		}

		// Token: 0x06036BC7 RID: 224199 RVA: 0x00DE1E70 File Offset: 0x00DE0070
		private void OnNavigationTriggerPlotForward(float value)
		{
			ControllerBase<InputController>.Instance.InputAxis(EInputAxis.LookUp, value, true);
		}

		// Token: 0x06036BC8 RID: 224200 RVA: 0x00DE1E83 File Offset: 0x00DE0083
		private void OnNavigationTriggerPlotRight(float value)
		{
			ControllerBase<InputController>.Instance.InputAxis(EInputAxis.Turn, value, true);
		}

		// Token: 0x06036BC9 RID: 224201 RVA: 0x00DE1E98 File Offset: 0x00DE0098
		private void OnNavigationTriggerPlotZoom(float value)
		{
			if (value == 0f)
			{
				return;
			}
			float num = value * 1.2f;
			ControllerBase<InputController>.Instance.InputAxis(EInputAxis.Zoom, -num, true);
		}

		// Token: 0x06036BCA RID: 224202 RVA: 0x00DE1EC8 File Offset: 0x00DE00C8
		private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!ModelBase<PlotModel>.Instance.CanControlView)
			{
				return;
			}
			this.CurrentDragPosition = new FVector?(eventData.GetLocalPointInPlane());
		}

		// Token: 0x06036BCB RID: 224203 RVA: 0x00DE1EE8 File Offset: 0x00DE00E8
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

		// Token: 0x06036BCC RID: 224204 RVA: 0x00DE1FA9 File Offset: 0x00DE01A9
		private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!ModelBase<PlotModel>.Instance.CanControlView)
			{
				return;
			}
			this.CurrentDragPosition = null;
		}

		// Token: 0x06036BCD RID: 224205 RVA: 0x00DE1FC4 File Offset: 0x00DE01C4
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

		// Token: 0x06036BCE RID: 224206 RVA: 0x00DE1FF0 File Offset: 0x00DE01F0
		public void SimulateClickSubtitle()
		{
			if (Singleton<Info>.Instance.IsBuildShipping)
			{
				return;
			}
			this.OnBtnSubtitleSkipClick(null);
		}

		// Token: 0x06036BCF RID: 224207 RVA: 0x00DE2008 File Offset: 0x00DE0208
		public void SimulateClickOption()
		{
			if (Singleton<Info>.Instance.IsBuildShipping)
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

		// Token: 0x06036BD0 RID: 224208 RVA: 0x00DE2054 File Offset: 0x00DE0254
		private void OnSkip()
		{
			this.MuteAutoPlay(false);
			this.ShowUiExceptPhoto();
			ControllerBase<FlowController>.Instance.BackgroundFlow("UI点击跳过(PlotView)", true, false, true);
		}

		// Token: 0x06036BD1 RID: 224209 RVA: 0x00DE2078 File Offset: 0x00DE0278
		private void UpdateByPlotConfig()
		{
			this.SkipComp.EnableSkipButton(false);
			PlotConfig plotConfig = ModelBase<PlotModel>.Instance.PlotConfig;
			this.ClearOptions();
			bool canPause = plotConfig.CanPause;
			UUIItem uuiitem = base.GetButton(0).RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(canPause);
			}
			base.GetButton(18).RootUIComp.Get().SetUIActive(canPause);
			this.ReviewComp.EnableReviewButton(canPause);
			UUIItem uuiitem2 = base.GetButton(1).RootUIComp.Get();
			if (uuiitem2 != null)
			{
				uuiitem2.SetUIActive(true);
			}
			this.UpdateAutoPlayButton();
			this.IsShowBlackBg = true;
			base.GetSprite(9).SetUIActive(this.IsShowBlackBg);
			this.RestorePlotButtonsVisibility();
		}

		// Token: 0x06036BD2 RID: 224210 RVA: 0x00DE2134 File Offset: 0x00DE0334
		[NullableContext(1)]
		private void UpdateSeqSubtitle(ITalkItem inPlotSubtitleInfo)
		{
			this.RemoveDelayTimer();
			this.IsSubtitleFinishDelay = false;
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
				flag = (inPlotSubtitleInfo as ITalkItemSystemOption).OptionConfig.KeepPreTalkItem.GetValueOrDefault();
			}
			if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC && num > 20f)
			{
				if (!flag)
				{
					this.ShowBlackBg(false, true);
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
					this.ShowBlackBg(false, true);
				}
				this.ClearOptions();
				this.HandleSubtitleActions();
				return;
			}
			this.PlaySubtitle(inPlotSubtitleInfo);
		}

		// Token: 0x06036BD3 RID: 224211 RVA: 0x00DE22A1 File Offset: 0x00DE04A1
		private void ShowOptions()
		{
			this.UpdatePnlLayout02Offset();
			this.CommonLogic.ShowOptions();
		}

		// Token: 0x06036BD4 RID: 224212 RVA: 0x00DE22B4 File Offset: 0x00DE04B4
		private void ClearOptions()
		{
			this.CommonLogic.ClearOptions();
		}

		// Token: 0x06036BD5 RID: 224213 RVA: 0x00DE22C1 File Offset: 0x00DE04C1
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

		// Token: 0x06036BD6 RID: 224214 RVA: 0x00DE22EA File Offset: 0x00DE04EA
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

		// Token: 0x06036BD7 RID: 224215 RVA: 0x00DE2314 File Offset: 0x00DE0514
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

		// Token: 0x06036BD8 RID: 224216 RVA: 0x00DE2388 File Offset: 0x00DE0588
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

		// Token: 0x06036BD9 RID: 224217 RVA: 0x00DE23EE File Offset: 0x00DE05EE
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

		// Token: 0x06036BDA RID: 224218 RVA: 0x00DE241B File Offset: 0x00DE061B
		[NullableContext(1)]
		private void HandlePortraitVisible(SetHeadIconVisible headIconInfo, Action callback)
		{
			this.CommonLogic.HandlePortraitVisible(this.RootItem, headIconInfo, callback);
		}

		// Token: 0x06036BDB RID: 224219 RVA: 0x00DE2430 File Offset: 0x00DE0630
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

		// Token: 0x06036BDC RID: 224220 RVA: 0x00DE24A4 File Offset: 0x00DE06A4
		[NullableContext(1)]
		private void PlaySubtitle(ITalkItem currentContent)
		{
			this.ClearOptions();
			EPlotLevel? subtitleLevel = ModelBase<PlotModel>.Instance.PlotConfig.SubtitleLevel;
			UUIItem item = base.GetItem(45);
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
			if (subtitleLevel.GetValueOrDefault() == EPlotLevel.LevelC && ModelBase<PlotModel>.Instance.IsUseNewLevelBStyle())
			{
				this.ShowBlackBg(false, false);
				base.GetItem(3).SetAlpha(1f);
				if (uuisizeControlByOther != null)
				{
					uuisizeControlByOther.MinHeight = 60;
				}
				if (item != null)
				{
					item.SetAnchorOffsetY(PlotView.GetPnlLayout02OffsetY(Singleton<Info>.Instance.InputControllerMainType));
				}
			}
			else
			{
				this.ShowBlackBg(true, true);
				if (uuisizeControlByOther != null)
				{
					uuisizeControlByOther.MinHeight = 174;
				}
				if (item != null)
				{
					item.SetAnchorOffsetY(0f);
				}
			}
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
				currentContent.WaitTime = new float?(waitTime.Value);
			}
			float? num = waitTime;
			double? num2 = (num != null) ? new double?((double)num.GetValueOrDefault()) : null;
			double minWaitingTime = ModelBase<PlotModel>.Instance.PlotTemplate.MinWaitingTime;
			if (num2.GetValueOrDefault() < minWaitingTime & num2 != null)
			{
				waitTime = new float?((float)ModelBase<PlotModel>.Instance.PlotTemplate.MinWaitingTime);
				currentContent.WaitTime = new float?(waitTime.Value);
			}
			waitTime = new float?((float)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)waitTime.Value));
			num = waitTime;
			float num3 = (float)20;
			if (num.GetValueOrDefault() < num3 & num != null)
			{
				this.SkipSubtitleTipItemActive(true);
				this.ShowWaitingPoint(false);
				this.CanJumpToNextTalk = true;
				return;
			}
			this.SkipSubtitleTipItemActive(false);
			this.ShowWaitingPoint(true);
			this.WaitingSkipTimerId = TimerSystem.Instance.Delay(delegate(float _)
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
					this.DelayHandleSubtitleActions();
				}
				this.SkipSubtitleTipItemActive(true);
			}, waitTime.Value, null, null, true, 1f);
		}

		// Token: 0x06036BDD RID: 224221 RVA: 0x00DE26EF File Offset: 0x00DE08EF
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
			this.DelayHandleSubtitleActions();
		}

		// Token: 0x06036BDE RID: 224222 RVA: 0x00DE272C File Offset: 0x00DE092C
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
			num *= 1000f;
			TimerHandle delayId = null;
			delayId = TimerSystem.Instance.Delay(delegate(float _)
			{
				if (this.DelayId == delayId)
				{
					this.DelayId = null;
				}
				this.IsSubtitleFinishDelay = true;
				if (ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState != EAutoPlayState.Manual)
				{
					this.SkipSubtitleTipItemActive(false);
					this.HandleSubtitleActions();
				}
			}, Math.Max(this.CommonLogic.PlayDelayTime.GetValueOrDefault(), num), null, null, true, 1f);
			this.DelayId = delayId;
		}

		// Token: 0x06036BDF RID: 224223 RVA: 0x00DE2814 File Offset: 0x00DE0A14
		private void HandleSubtitleActions()
		{
			this.CanJumpToNextTalk = false;
			this.IsSubtitleFinishDelay = false;
			this.RemoveDelayTimer();
			if (this.CommonLogic.IsInteraction)
			{
				this.PlayNextPreTalk();
				return;
			}
			ControllerBase<FlowController>.Instance.FlowShowTalk.SubmitSubtitle(this.CommonLogic.CurrentContent);
		}

		// Token: 0x06036BE0 RID: 224224 RVA: 0x00DE2863 File Offset: 0x00DE0A63
		private void InitInteractOptions()
		{
			this.CommonLogic.InitInteractOptions();
		}

		// Token: 0x06036BE1 RID: 224225 RVA: 0x00DE2870 File Offset: 0x00DE0A70
		private void PlayNextPreTalk()
		{
			this.PreTalkIndex++;
			if (this.PreTalkIndex < this.PreTalkItems.Count)
			{
				this.CommonLogic.ClearPlotContent(false);
				ITalkItem talkItem = this.PreTalkItems[this.PreTalkIndex];
				this.CommonLogic.PlaySubtitle(talkItem);
				this.PlaySubtitle(talkItem);
				return;
			}
			if (this.PreTalkIndex == this.PreTalkItems.Count)
			{
				this.InitInteractOptions();
			}
		}

		// Token: 0x06036BE2 RID: 224226 RVA: 0x00DE28EC File Offset: 0x00DE0AEC
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

		// Token: 0x06036BE3 RID: 224227 RVA: 0x00DE2A4C File Offset: 0x00DE0C4C
		protected void OnBtnAutoClick()
		{
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
			if (eautoPlayState > EAutoPlayState.Manual && this.IsSubtitleFinishDelay)
			{
				this.SkipSubtitleTipItemActive(false);
				this.HandleSubtitleActions();
			}
			this.CommonLogic.OnAutoPlayStateChanged();
			this.UpdateAutoPlayButton();
		}

		// Token: 0x06036BE4 RID: 224228 RVA: 0x00DE2AD5 File Offset: 0x00DE0CD5
		private void OnSkipPop()
		{
			this.MuteAutoPlay(true);
			this.HideUiExceptPhoto();
		}

		// Token: 0x06036BE5 RID: 224229 RVA: 0x00DE2AE4 File Offset: 0x00DE0CE4
		private void OnSkipCancel()
		{
			this.MuteAutoPlay(false);
			this.ShowUiExceptPhoto();
		}

		// Token: 0x06036BE6 RID: 224230 RVA: 0x00DE2AF3 File Offset: 0x00DE0CF3
		private void OnBtnHideClick()
		{
			this.HideUiExceptPhoto();
			this.IsVisible = false;
			this.MuteAutoPlay(true);
		}

		// Token: 0x06036BE7 RID: 224231 RVA: 0x00DE2B09 File Offset: 0x00DE0D09
		private void OnBtnReviewClick()
		{
			if (ControllerBase<FlowController>.Instance.OpenPlotReviewView())
			{
				this.HideUiExceptPhoto();
				this.MuteAutoPlay(true);
			}
		}

		// Token: 0x06036BE8 RID: 224232 RVA: 0x00DE2B24 File Offset: 0x00DE0D24
		private void OnOpenView(EUiViewName viewName, int _)
		{
			if (viewName == EUiViewName.PlotReviewView)
			{
				Singleton<AudioSystem>.Instance.PostEvent("plot_review_enter");
			}
		}

		// Token: 0x06036BE9 RID: 224233 RVA: 0x00DE2B43 File Offset: 0x00DE0D43
		private void OnCloseView(EUiViewName viewName, int _)
		{
			if (viewName == EUiViewName.PlotReviewView)
			{
				Singleton<AudioSystem>.Instance.PostEvent("plot_review_exit");
				this.IsVisible = true;
				this.ShowUiExceptPhoto();
				this.MuteAutoPlay(false);
				this.RestorePlotButtonsVisibility();
			}
		}

		// Token: 0x06036BEA RID: 224234 RVA: 0x00DE2B7C File Offset: 0x00DE0D7C
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

		// Token: 0x06036BEB RID: 224235 RVA: 0x00DE2BAC File Offset: 0x00DE0DAC
		private void ShowWaitingPoint(bool enable)
		{
			base.GetItem(20).SetUIActive(enable);
		}

		// Token: 0x06036BEC RID: 224236 RVA: 0x00DE2BBC File Offset: 0x00DE0DBC
		private void RemoveDelayTimer()
		{
			if (TimerSystem.Instance.Has(this.DelayId))
			{
				TimerSystem.Instance.Remove(this.DelayId);
			}
			this.DelayId = null;
		}

		// Token: 0x06036BED RID: 224237 RVA: 0x00DE2BE8 File Offset: 0x00DE0DE8
		public void RemoveWaitSkipTimer()
		{
			if (TimerSystem.Instance.Has(this.WaitingSkipTimerId))
			{
				TimerSystem.Instance.Remove(this.WaitingSkipTimerId);
			}
			this.WaitingSkipTimerId = null;
		}

		// Token: 0x06036BEE RID: 224238 RVA: 0x00DE2C14 File Offset: 0x00DE0E14
		private void HideAll(bool isHidden)
		{
			this.RootItem.SetUIActive(!isHidden);
		}

		// Token: 0x06036BEF RID: 224239 RVA: 0x00DE2C25 File Offset: 0x00DE0E25
		[NullableContext(1)]
		private void OnInputAnyKey(bool bPress, FKey key)
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
			this.MuteAutoPlay(false);
			this.TrySchedulePendingImmersiveSleep();
		}

		// Token: 0x06036BF0 RID: 224240 RVA: 0x00DE2C4E File Offset: 0x00DE0E4E
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
			this.TrySchedulePendingImmersiveSleep();
		}

		// Token: 0x06036BF1 RID: 224241 RVA: 0x00DE2C75 File Offset: 0x00DE0E75
		private void OnPlotViewBgFadePhoto(bool isFadeIn, bool isFull, string path, Action callback)
		{
			this.DoOnPlotViewBgFadePhoto(isFadeIn, isFull, path, callback);
		}

		// Token: 0x06036BF2 RID: 224242 RVA: 0x00DE2C84 File Offset: 0x00DE0E84
		private UniTask DoOnPlotViewBgFadePhoto(bool isFadeIn, bool isFull, string path, Action callback)
		{
			PlotView.<DoOnPlotViewBgFadePhoto>d__132 <DoOnPlotViewBgFadePhoto>d__;
			<DoOnPlotViewBgFadePhoto>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DoOnPlotViewBgFadePhoto>d__.<>4__this = this;
			<DoOnPlotViewBgFadePhoto>d__.isFadeIn = isFadeIn;
			<DoOnPlotViewBgFadePhoto>d__.isFull = isFull;
			<DoOnPlotViewBgFadePhoto>d__.path = path;
			<DoOnPlotViewBgFadePhoto>d__.callback = callback;
			<DoOnPlotViewBgFadePhoto>d__.<>1__state = -1;
			<DoOnPlotViewBgFadePhoto>d__.<>t__builder.Start<PlotView.<DoOnPlotViewBgFadePhoto>d__132>(ref <DoOnPlotViewBgFadePhoto>d__);
			return <DoOnPlotViewBgFadePhoto>d__.<>t__builder.Task;
		}

		// Token: 0x06036BF3 RID: 224243 RVA: 0x00DE2CE8 File Offset: 0x00DE0EE8
		private void OnPlotViewBgFadeBlackScreen(bool isFadeIn, Action callback)
		{
			this.DoOnPlotViewBgFadeBlackScreen(isFadeIn, callback);
		}

		// Token: 0x06036BF4 RID: 224244 RVA: 0x00DE2CF4 File Offset: 0x00DE0EF4
		private UniTask DoOnPlotViewBgFadeBlackScreen(bool isFadeIn, Action callback)
		{
			PlotView.<DoOnPlotViewBgFadeBlackScreen>d__134 <DoOnPlotViewBgFadeBlackScreen>d__;
			<DoOnPlotViewBgFadeBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DoOnPlotViewBgFadeBlackScreen>d__.<>4__this = this;
			<DoOnPlotViewBgFadeBlackScreen>d__.isFadeIn = isFadeIn;
			<DoOnPlotViewBgFadeBlackScreen>d__.callback = callback;
			<DoOnPlotViewBgFadeBlackScreen>d__.<>1__state = -1;
			<DoOnPlotViewBgFadeBlackScreen>d__.<>t__builder.Start<PlotView.<DoOnPlotViewBgFadeBlackScreen>d__134>(ref <DoOnPlotViewBgFadeBlackScreen>d__);
			return <DoOnPlotViewBgFadeBlackScreen>d__.<>t__builder.Task;
		}

		// Token: 0x06036BF5 RID: 224245 RVA: 0x00DE2D47 File Offset: 0x00DE0F47
		private void ClearPlotSubtitle()
		{
			this.ClearPlotView();
			this.CommonLogic.ClearPlotContent(false);
		}

		// Token: 0x06036BF6 RID: 224246 RVA: 0x00DE2D5C File Offset: 0x00DE0F5C
		private void ClearPlotView()
		{
			this.RemoveWaitSkipTimer();
			this.RemoveDelayTimer();
			this.ClearOptions();
			base.GetItem(3).SetUIActive(false);
			base.GetText(4).SetUIActive(false);
			base.GetText(17).SetUIActive(false);
			base.GetItem(11).SetUIActive(false);
		}

		// Token: 0x06036BF7 RID: 224247 RVA: 0x00DE2DB4 File Offset: 0x00DE0FB4
		public void AddScreenEffectPlotRoot()
		{
			AUIContainerActor screenEffectPlotRoot = null;
			BP_ScreenEffectSystem_C instance = ScreenEffectSystem.GetInstance();
			if (!instance.IsValid())
			{
				return;
			}
			instance.GetScreenEffectPlotRoot(ref screenEffectPlotRoot);
			this.ScreenEffectPlotRoot = screenEffectPlotRoot;
			UUIItem item = base.GetItem(13);
			AUIContainerActor screenEffectPlotRoot2 = this.ScreenEffectPlotRoot;
			if (screenEffectPlotRoot2 != null && screenEffectPlotRoot2.IsValid())
			{
				this.ScreenEffectPlotRoot.K2_AttachRootComponentTo(item, default(FName), EAttachLocation.KeepRelativeOffset, true);
			}
		}

		// Token: 0x06036BF8 RID: 224248 RVA: 0x00DE2E15 File Offset: 0x00DE1015
		public void RemoveScreenEffectPlotRoot()
		{
			AUIContainerActor screenEffectPlotRoot = this.ScreenEffectPlotRoot;
			if (screenEffectPlotRoot != null && screenEffectPlotRoot.IsValid())
			{
				this.ScreenEffectPlotRoot.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
			}
			this.ScreenEffectPlotRoot = null;
		}

		// Token: 0x06036BF9 RID: 224249 RVA: 0x00DE2E40 File Offset: 0x00DE1040
		private void AddTickPhoto()
		{
			this.TickPhotoFade = true;
		}

		// Token: 0x06036BFA RID: 224250 RVA: 0x00DE2E49 File Offset: 0x00DE1049
		private void RemoveTickPhoto()
		{
			this.TickPhotoFade = false;
		}

		// Token: 0x06036BFB RID: 224251 RVA: 0x00DE2E54 File Offset: 0x00DE1054
		private float GetCurrentPercentPhoto()
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
					return 0f;
				}
				this.BgWidget.SetAlpha(rangePct);
			}
			return rangePct;
		}

		// Token: 0x06036BFC RID: 224252 RVA: 0x00DE2EC8 File Offset: 0x00DE10C8
		private float GetCurrentPercentPhotoMiddle()
		{
			float rangePct = Singleton<MathUtils>.Instance.GetRangePct(0f, 1000f, this.FadeTimePhoto);
			if (!this.IsFadeInPhoto && this.WidgetMiddle.GetAlpha() <= 0f)
			{
				return 0f;
			}
			this.WidgetMiddle.SetAlpha(rangePct);
			return rangePct;
		}

		// Token: 0x06036BFD RID: 224253 RVA: 0x00DE2F20 File Offset: 0x00DE1120
		private void OnFadeTickPhoto(float deltaTime)
		{
			if (this.FadeTimePhoto < 0f)
			{
				this.FadeTimePhoto = 0f;
			}
			if (this.FadeTimePhoto > 1000f)
			{
				this.FadeTimePhoto = 1000f;
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

		// Token: 0x06036BFE RID: 224254 RVA: 0x00DE3004 File Offset: 0x00DE1204
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
					ControllerBase<PlotController>.Instance.ResetViewControl();
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
				ControllerBase<PlotController>.Instance.ResetViewControl();
			}
			if (this.PlotViewPhotoCallback != null)
			{
				this.PlotViewPhotoCallback(null);
			}
		}

		// Token: 0x06036BFF RID: 224255 RVA: 0x00DE3230 File Offset: 0x00DE1430
		public UniTask FadeInBgPhoto(string path = null, Action callback = null)
		{
			PlotView.<FadeInBgPhoto>d__145 <FadeInBgPhoto>d__;
			<FadeInBgPhoto>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FadeInBgPhoto>d__.<>4__this = this;
			<FadeInBgPhoto>d__.path = path;
			<FadeInBgPhoto>d__.callback = callback;
			<FadeInBgPhoto>d__.<>1__state = -1;
			<FadeInBgPhoto>d__.<>t__builder.Start<PlotView.<FadeInBgPhoto>d__145>(ref <FadeInBgPhoto>d__);
			return <FadeInBgPhoto>d__.<>t__builder.Task;
		}

		// Token: 0x06036C00 RID: 224256 RVA: 0x00DE3284 File Offset: 0x00DE1484
		public UniTask FadeOutBgPhoto(Action callback = null)
		{
			PlotView.<FadeOutBgPhoto>d__146 <FadeOutBgPhoto>d__;
			<FadeOutBgPhoto>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FadeOutBgPhoto>d__.<>4__this = this;
			<FadeOutBgPhoto>d__.callback = callback;
			<FadeOutBgPhoto>d__.<>1__state = -1;
			<FadeOutBgPhoto>d__.<>t__builder.Start<PlotView.<FadeOutBgPhoto>d__146>(ref <FadeOutBgPhoto>d__);
			return <FadeOutBgPhoto>d__.<>t__builder.Task;
		}

		// Token: 0x06036C01 RID: 224257 RVA: 0x00DE32D0 File Offset: 0x00DE14D0
		public UniTask FadeInBgPhotoMiddle(string path = null, Action callback = null)
		{
			PlotView.<FadeInBgPhotoMiddle>d__147 <FadeInBgPhotoMiddle>d__;
			<FadeInBgPhotoMiddle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FadeInBgPhotoMiddle>d__.<>4__this = this;
			<FadeInBgPhotoMiddle>d__.path = path;
			<FadeInBgPhotoMiddle>d__.callback = callback;
			<FadeInBgPhotoMiddle>d__.<>1__state = -1;
			<FadeInBgPhotoMiddle>d__.<>t__builder.Start<PlotView.<FadeInBgPhotoMiddle>d__147>(ref <FadeInBgPhotoMiddle>d__);
			return <FadeInBgPhotoMiddle>d__.<>t__builder.Task;
		}

		// Token: 0x06036C02 RID: 224258 RVA: 0x00DE3324 File Offset: 0x00DE1524
		public UniTask FadeOutBgPhotoMiddle(Action callback = null)
		{
			PlotView.<FadeOutBgPhotoMiddle>d__148 <FadeOutBgPhotoMiddle>d__;
			<FadeOutBgPhotoMiddle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FadeOutBgPhotoMiddle>d__.<>4__this = this;
			<FadeOutBgPhotoMiddle>d__.callback = callback;
			<FadeOutBgPhotoMiddle>d__.<>1__state = -1;
			<FadeOutBgPhotoMiddle>d__.<>t__builder.Start<PlotView.<FadeOutBgPhotoMiddle>d__148>(ref <FadeOutBgPhotoMiddle>d__);
			return <FadeOutBgPhotoMiddle>d__.<>t__builder.Task;
		}

		// Token: 0x06036C03 RID: 224259 RVA: 0x00DE336F File Offset: 0x00DE156F
		private void AddTickBlackScreen()
		{
			this.TickBlackScreenFade = true;
		}

		// Token: 0x06036C04 RID: 224260 RVA: 0x00DE3378 File Offset: 0x00DE1578
		private void RemoveTickBlackScreen()
		{
			this.TickBlackScreenFade = false;
		}

		// Token: 0x06036C05 RID: 224261 RVA: 0x00DE3384 File Offset: 0x00DE1584
		private float GetCurrentPercentBlackScreen()
		{
			float rangePct = Singleton<MathUtils>.Instance.GetRangePct(0f, 1000f, this.FadeTimeBlackScreen);
			this.BlackBgWidget.SetAlpha(rangePct);
			return rangePct;
		}

		// Token: 0x06036C06 RID: 224262 RVA: 0x00DE33BC File Offset: 0x00DE15BC
		private void OnFadeTickBlackScreen(float deltaTime)
		{
			if (this.FadeTimeBlackScreen < 0f)
			{
				this.FadeTimeBlackScreen = 0f;
			}
			if (this.FadeTimeBlackScreen > 1000f)
			{
				this.FadeTimeBlackScreen = 1000f;
			}
			if (this.IsFadeInBlackScreen)
			{
				this.FadeTimeBlackScreen += deltaTime;
				if (this.GetCurrentPercentBlackScreen() > 1f)
				{
					this.RemoveTickBlackScreen();
					this.OnCloseEventBlackScreen();
					return;
				}
			}
			else
			{
				this.FadeTimeBlackScreen -= deltaTime;
				if (this.GetCurrentPercentBlackScreen() < 0f)
				{
					this.RemoveTickBlackScreen();
					this.OnCloseEventBlackScreen();
				}
			}
		}

		// Token: 0x06036C07 RID: 224263 RVA: 0x00DE3450 File Offset: 0x00DE1650
		private void OnCloseEventBlackScreen()
		{
			if (this.IsFadeInBlackScreen && this.PlotFadeHidePromise != null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "Plot黑幕FadeIn结束", default(ReadOnlySpan<ValueTuple<string, object>>));
				CustomPromise<bool> plotFadeHidePromise = this.PlotFadeHidePromise;
				this.PlotFadeHidePromise = null;
				plotFadeHidePromise.SetResult(true);
			}
			else if (!this.IsFadeInBlackScreen && this.PlotFadeShowPromise != null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "Plot黑幕FadeOut结束", default(ReadOnlySpan<ValueTuple<string, object>>));
				CustomPromise<bool> plotFadeShowPromise = this.PlotFadeShowPromise;
				this.PlotFadeShowPromise = null;
				plotFadeShowPromise.SetResult(true);
			}
			if (this.PlotViewBlackScreenCallback != null)
			{
				this.PlotViewBlackScreenCallback(null);
			}
		}

		// Token: 0x06036C08 RID: 224264 RVA: 0x00DE34F8 File Offset: 0x00DE16F8
		public UniTask FadeInBgBlackScreen(Action callback = null)
		{
			PlotView.<FadeInBgBlackScreen>d__154 <FadeInBgBlackScreen>d__;
			<FadeInBgBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FadeInBgBlackScreen>d__.<>4__this = this;
			<FadeInBgBlackScreen>d__.callback = callback;
			<FadeInBgBlackScreen>d__.<>1__state = -1;
			<FadeInBgBlackScreen>d__.<>t__builder.Start<PlotView.<FadeInBgBlackScreen>d__154>(ref <FadeInBgBlackScreen>d__);
			return <FadeInBgBlackScreen>d__.<>t__builder.Task;
		}

		// Token: 0x06036C09 RID: 224265 RVA: 0x00DE3544 File Offset: 0x00DE1744
		public UniTask FadeOutBgBlackScreen(Action callback = null)
		{
			PlotView.<FadeOutBgBlackScreen>d__155 <FadeOutBgBlackScreen>d__;
			<FadeOutBgBlackScreen>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FadeOutBgBlackScreen>d__.<>4__this = this;
			<FadeOutBgBlackScreen>d__.callback = callback;
			<FadeOutBgBlackScreen>d__.<>1__state = -1;
			<FadeOutBgBlackScreen>d__.<>t__builder.Start<PlotView.<FadeOutBgBlackScreen>d__155>(ref <FadeOutBgBlackScreen>d__);
			return <FadeOutBgBlackScreen>d__.<>t__builder.Task;
		}

		// Token: 0x06036C0A RID: 224266 RVA: 0x00DE3590 File Offset: 0x00DE1790
		public UniTask OpenChildView(int id, bool isLoop)
		{
			PlotView.<OpenChildView>d__158 <OpenChildView>d__;
			<OpenChildView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenChildView>d__.<>4__this = this;
			<OpenChildView>d__.id = id;
			<OpenChildView>d__.isLoop = isLoop;
			<OpenChildView>d__.<>1__state = -1;
			<OpenChildView>d__.<>t__builder.Start<PlotView.<OpenChildView>d__158>(ref <OpenChildView>d__);
			return <OpenChildView>d__.<>t__builder.Task;
		}

		// Token: 0x06036C0B RID: 224267 RVA: 0x00DE35E4 File Offset: 0x00DE17E4
		public UniTask CloseChildView()
		{
			PlotView.<CloseChildView>d__159 <CloseChildView>d__;
			<CloseChildView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseChildView>d__.<>4__this = this;
			<CloseChildView>d__.<>1__state = -1;
			<CloseChildView>d__.<>t__builder.Start<PlotView.<CloseChildView>d__159>(ref <CloseChildView>d__);
			return <CloseChildView>d__.<>t__builder.Task;
		}

		// Token: 0x0401F87A RID: 129146
		private const int FADE_TIME = 1000;

		// Token: 0x0401F87B RID: 129147
		private const float ROTATE_RATE_X = 0.06f;

		// Token: 0x0401F87C RID: 129148
		private const float ROTATE_RATE_Y = 0.03f;

		// Token: 0x0401F87D RID: 129149
		private const float ZOOM_RATE = 1.2f;

		// Token: 0x0401F87E RID: 129150
		[Nullable(1)]
		private const string DEFAULT_PATH = "/Game/Aki/UI/UIResources/Common/Image/T_CommonDefault_UI.T_CommonDefault_UI";

		// Token: 0x0401F87F RID: 129151
		[Nullable(1)]
		private const string CLICK_AUDIO_EVENT = "play_ui_ia_spl_plot_next";

		// Token: 0x0401F880 RID: 129152
		private const float PLOT_AUTO_HIDE_MOUSE_DELAY = 3000f;

		// Token: 0x0401F881 RID: 129153
		[Nullable(1)]
		private const string AUTO_SELECT_TEXT_HALF_AUTO = "HotKeyText_HalfAutoPlot_Name";

		// Token: 0x0401F882 RID: 129154
		[Nullable(1)]
		private const string AUTO_SELECT_TEXT_AUTO = "HotKeyText_AutoPlot_Name";

		// Token: 0x0401F883 RID: 129155
		[Nullable(1)]
		private const string AUTO_SELECT_TEXT_CANCEL_AUTO = "HotKeyText_CancelAutoPlot_Name";

		// Token: 0x0401F884 RID: 129156
		[Nullable(1)]
		public List<PlotOption> CurOption = new List<PlotOption>();

		// Token: 0x0401F885 RID: 129157
		private TimerHandle DelayId;

		// Token: 0x0401F886 RID: 129158
		private TimerHandle WaitingSkipTimerId;

		// Token: 0x0401F887 RID: 129159
		public PawnInteractController InteractController;

		// Token: 0x0401F888 RID: 129160
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ITalkItem> PreTalkItems;

		// Token: 0x0401F889 RID: 129161
		private int PreTalkIndex;

		// Token: 0x0401F88A RID: 129162
		private bool CanJumpToNextTalk;

		// Token: 0x0401F88B RID: 129163
		private UUIItem SkipSubtitleTipItem;

		// Token: 0x0401F88C RID: 129164
		private AUIContainerActor ScreenEffectPlotRoot;

		// Token: 0x0401F88D RID: 129165
		private PlotSkipComponent SkipComp;

		// Token: 0x0401F88E RID: 129166
		private PlotReviewComponent ReviewComp;

		// Token: 0x0401F88F RID: 129167
		private PlotTextCommonLogic CommonLogic;

		// Token: 0x0401F890 RID: 129168
		private bool ImmersiveInputWakeState;

		// Token: 0x0401F891 RID: 129169
		private bool? MainButtonsTweenShown;

		// Token: 0x0401F892 RID: 129170
		private bool? SkipTweenShown;

		// Token: 0x0401F893 RID: 129171
		private bool? ReviewTweenShown;

		// Token: 0x0401F894 RID: 129172
		private bool PendingImmersiveSleep;

		// Token: 0x0401F895 RID: 129173
		private TimerHandle PendingImmersiveSleepTimerId;

		// Token: 0x0401F896 RID: 129174
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap;

		// Token: 0x0401F897 RID: 129175
		private bool TickBlackScreenFade;

		// Token: 0x0401F898 RID: 129176
		private bool TickPhotoFade;

		// Token: 0x0401F899 RID: 129177
		private UUITexture BgWidget;

		// Token: 0x0401F89A RID: 129178
		private UUITexture BgWidgetFront;

		// Token: 0x0401F89B RID: 129179
		private UUITexture WidgetMiddle;

		// Token: 0x0401F89C RID: 129180
		private UUISprite BgWidgetMiddle;

		// Token: 0x0401F89D RID: 129181
		private UUISprite BlackBgWidget;

		// Token: 0x0401F89E RID: 129182
		private CustomPromise<bool> PlotFadeShowPromise;

		// Token: 0x0401F89F RID: 129183
		private CustomPromise<bool> PlotFadeHidePromise;

		// Token: 0x0401F8A0 RID: 129184
		private Action<ITalkItem> PlotViewPhotoCallback;

		// Token: 0x0401F8A1 RID: 129185
		private Action<ITalkItem> PlotViewBlackScreenCallback;

		// Token: 0x0401F8A2 RID: 129186
		private float FadeTimePhoto;

		// Token: 0x0401F8A3 RID: 129187
		private float FadeTimeBlackScreen;

		// Token: 0x0401F8A4 RID: 129188
		private bool IsFadeInPhoto;

		// Token: 0x0401F8A5 RID: 129189
		private bool IsFadeInBlackScreen;

		// Token: 0x0401F8A6 RID: 129190
		private bool IsVisible = true;

		// Token: 0x0401F8A7 RID: 129191
		private bool IsAlreadyHavePhoto;

		// Token: 0x0401F8A8 RID: 129192
		private bool? IsFullPhoto;

		// Token: 0x0401F8A9 RID: 129193
		private bool IsShowBlackBg;

		// Token: 0x0401F8AA RID: 129194
		private FVector? CurrentDragPosition;

		// Token: 0x0401F8AB RID: 129195
		private TimerHandle StartDelayTimer;

		// Token: 0x0401F8AC RID: 129196
		private bool IsSubtitleFinishDelay;

		// Token: 0x0401F8AD RID: 129197
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private readonly Action<ULGUIPointerEventData> OnPointerScrollCallBack = delegate(ULGUIPointerEventData eventData)
		{
			if (!ModelBase<PlotModel>.Instance.CanControlView)
			{
				return;
			}
			float value = eventData.scrollAxisValue * 1.2f;
			ControllerBase<InputController>.Instance.InputAxis(EInputAxis.Zoom, value, true);
		};

		// Token: 0x0401F8AE RID: 129198
		private PlotChildView ChildView;

		// Token: 0x0401F8AF RID: 129199
		[Nullable(1)]
		private string ChildViewName = "";

		// Token: 0x0200B34B RID: 45899
		[NullableContext(0)]
		private enum EPlotChildCom
		{
			// Token: 0x04037899 RID: 227481
			BtnAuto,
			// Token: 0x0403789A RID: 227482
			BtnNextPage,
			// Token: 0x0403789B RID: 227483
			BtnSkip,
			// Token: 0x0403789C RID: 227484
			PlotText,
			// Token: 0x0403789D RID: 227485
			NPCName,
			// Token: 0x0403789E RID: 227486
			TxtList,
			// Token: 0x0403789F RID: 227487
			OptionItem,
			// Token: 0x040378A0 RID: 227488
			OptionLayout,
			// Token: 0x040378A1 RID: 227489
			TextList,
			// Token: 0x040378A2 RID: 227490
			PlotBg,
			// Token: 0x040378A3 RID: 227491
			PlotTextUHD,
			// Token: 0x040378A4 RID: 227492
			PanelLine,
			// Token: 0x040378A5 RID: 227493
			TxtFloat,
			// Token: 0x040378A6 RID: 227494
			ScreenEffect,
			// Token: 0x040378A7 RID: 227495
			AutoPlayManualItem,
			// Token: 0x040378A8 RID: 227496
			AutoPlaySemiAutoItem,
			// Token: 0x040378A9 RID: 227497
			AutoPlayAutoItem,
			// Token: 0x040378AA RID: 227498
			NPCTitle,
			// Token: 0x040378AB RID: 227499
			BtnHide,
			// Token: 0x040378AC RID: 227500
			NextIcon,
			// Token: 0x040378AD RID: 227501
			WaitingPoint,
			// Token: 0x040378AE RID: 227502
			BlackScreenBg,
			// Token: 0x040378AF RID: 227503
			PhotoScreenBg,
			// Token: 0x040378B0 RID: 227504
			PhotoScreenBgFront,
			// Token: 0x040378B1 RID: 227505
			DoingText,
			// Token: 0x040378B2 RID: 227506
			PhotoScreenMiddle,
			// Token: 0x040378B3 RID: 227507
			PhotoScreenBgMiddle,
			// Token: 0x040378B4 RID: 227508
			TextScrollView,
			// Token: 0x040378B5 RID: 227509
			OptionAdjustItem,
			// Token: 0x040378B6 RID: 227510
			PnlBg,
			// Token: 0x040378B7 RID: 227511
			PnlInfo,
			// Token: 0x040378B8 RID: 227512
			SonUi,
			// Token: 0x040378B9 RID: 227513
			BlockOption,
			// Token: 0x040378BA RID: 227514
			BtnReview,
			// Token: 0x040378BB RID: 227515
			OptionLimitBar,
			// Token: 0x040378BC RID: 227516
			VideoLayout,
			// Token: 0x040378BD RID: 227517
			AniSkipIn,
			// Token: 0x040378BE RID: 227518
			AniSkipOut,
			// Token: 0x040378BF RID: 227519
			AniReviewIn,
			// Token: 0x040378C0 RID: 227520
			AniReviewOut,
			// Token: 0x040378C1 RID: 227521
			AniAutoHideIn,
			// Token: 0x040378C2 RID: 227522
			AniAutoHideOut,
			// Token: 0x040378C3 RID: 227523
			TextDebugInfo,
			// Token: 0x040378C4 RID: 227524
			FullscreenAdaptAnchor,
			// Token: 0x040378C5 RID: 227525
			ImportantList,
			// Token: 0x040378C6 RID: 227526
			PnlLayout02,
			// Token: 0x040378C7 RID: 227527
			TextScrollViewCopy,
			// Token: 0x040378C8 RID: 227528
			ImportantOptionTipsIcon,
			// Token: 0x040378C9 RID: 227529
			ImportantOptionTipsText,
			// Token: 0x040378CA RID: 227530
			AutoSelectTimeBar,
			// Token: 0x040378CB RID: 227531
			AutoSelectText,
			// Token: 0x040378CC RID: 227532
			AniAutoTextIn,
			// Token: 0x040378CD RID: 227533
			AniAutoTextOut
		}
	}
}
