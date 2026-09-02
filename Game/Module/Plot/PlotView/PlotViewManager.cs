using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.Module.Plot.TipsTalk;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053D4 RID: 21460
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotViewManager
	{
		// Token: 0x06036C5F RID: 224351 RVA: 0x00DE48C8 File Offset: 0x00DE2AC8
		public void RegisterEvent()
		{
			Singleton<EventSystem>.Instance.Add<EUiViewName, bool>(EEventName.PlotViewChange, new Action<EUiViewName, bool>(this.OnPlotViewChange));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnTutorialTipExistChanged, new Action<bool>(this.InterruptHud));
			Singleton<EventSystem>.Instance.Add<EUiViewName>(EEventName.OpenViewFail, new Action<EUiViewName>(this.OpenViewFail));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiSlowTimeVisibleChanged, new Action<bool>(this.OnBattleUiSlowTimeVisibleChanged));
		}

		// Token: 0x06036C60 RID: 224352 RVA: 0x00DE4974 File Offset: 0x00DE2B74
		public void UnRegisterEvent()
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName, bool>(EEventName.PlotViewChange, new Action<EUiViewName, bool>(this.OnPlotViewChange));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnTutorialTipExistChanged, new Action<bool>(this.InterruptHud));
			Singleton<EventSystem>.Instance.Remove<EUiViewName>(EEventName.OpenViewFail, new Action<EUiViewName>(this.OpenViewFail));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.BattleUiSlowTimeVisibleChanged, new Action<bool>(this.OnBattleUiSlowTimeVisibleChanged));
		}

		// Token: 0x06036C61 RID: 224353 RVA: 0x00DE4A20 File Offset: 0x00DE2C20
		private unsafe void OnPlotViewChange(EUiViewName name, bool isShow)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[PlotView] ViewChange";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isShow", isShow);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (this.IsSwitching && this.SwitchToView != name)
			{
				return;
			}
			if (this.CurrentView != name)
			{
				return;
			}
			if (isShow && !this.ViewEnable)
			{
				return;
			}
			this.IsShowing = isShow;
			if (this.IsShowing)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Plot;
				ELogAuthor author2 = ELogAuthor.FZX;
				string message2 = "[PlotView] 界面显示，打开完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("open", this.CurrentView);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.HandleCurrentViewShown().Forget();
			}
		}

		// Token: 0x06036C62 RID: 224354 RVA: 0x00DE4B33 File Offset: 0x00DE2D33
		public EUiViewName? GetCurrentViewName()
		{
			return this.CurrentView;
		}

		// Token: 0x06036C63 RID: 224355 RVA: 0x00DE4B3B File Offset: 0x00DE2D3B
		private void OnOpenView(EUiViewName viewName, int viewId)
		{
		}

		// Token: 0x06036C64 RID: 224356 RVA: 0x00DE4B3D File Offset: 0x00DE2D3D
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			this.ViewCloseCheck(viewName);
		}

		// Token: 0x06036C65 RID: 224357 RVA: 0x00DE4B48 File Offset: 0x00DE2D48
		private void OpenViewFail(EUiViewName viewName)
		{
			if (!this.ViewEnable || viewName != this.CurrentView)
			{
				return;
			}
			Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.FZX, "[PlotView] 剧情界面打开失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CurrentView = null;
			this.CurrentViewOwnerId = null;
			this.IsShowing = false;
			this.ViewEnable = false;
			this.IsLock = true;
			this.FinishSwitching();
			this.DoCallback(false);
			this.CancelPendingViewOperations();
			ControllerBase<FlowController>.Instance.BackgroundFlow("剧情界面打开失败 跳过剧情", false, false, false);
			this.CheckPending();
		}

		// Token: 0x06036C66 RID: 224358 RVA: 0x00DE4BF6 File Offset: 0x00DE2DF6
		public void OnUpdateSubtitle(ITalkItem talkItem)
		{
			ModelBase<PlotModel>.Instance.CurTalkItem = talkItem;
			Singleton<EventSystem>.Instance.Emit<ITalkItem, bool>(EEventName.PlotShowTalk, talkItem, true);
			ControllerBase<FlowController>.Instance.RecordTalkItem(talkItem);
		}

		// Token: 0x06036C67 RID: 224359 RVA: 0x00DE4C20 File Offset: 0x00DE2E20
		public bool UpdateTipsSubtitle(ITalkItem talkItem)
		{
			if (this.TipsView == null)
			{
				return false;
			}
			this.OnUpdateSubtitle(talkItem);
			this.TipsView.RefreshSubtitle(talkItem);
			return true;
		}

		// Token: 0x06036C68 RID: 224360 RVA: 0x00DE4C40 File Offset: 0x00DE2E40
		public void OnSubmitSubtitle()
		{
			Singleton<EventSystem>.Instance.Emit<ITalkItem, bool>(EEventName.PlotShowTalk, ModelBase<PlotModel>.Instance.CurTalkItem, false);
			ModelBase<PlotModel>.Instance.CurTalkItem = null;
		}

		// Token: 0x06036C69 RID: 224361 RVA: 0x00DE4C68 File Offset: 0x00DE2E68
		public void OnShowOptions()
		{
			ModelBase<PlotModel>.Instance.InOptions = true;
		}

		// Token: 0x06036C6A RID: 224362 RVA: 0x00DE4C78 File Offset: 0x00DE2E78
		public void UpdatePlotSubtitle(ITalkItem talkItem)
		{
			PlotViewManager.<>c__DisplayClass24_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass24_0();
			CS$<>8__locals1.talkItem = talkItem;
			this.OnUpdateSubtitle(CS$<>8__locals1.talkItem);
			this.RunWhenCurrentViewReady("UpdatePlotSubtitle", delegate
			{
				PlotViewManager.<>c__DisplayClass24_0.<<UpdatePlotSubtitle>b__0>d <<UpdatePlotSubtitle>b__0>d;
				<<UpdatePlotSubtitle>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<UpdatePlotSubtitle>b__0>d.<>4__this = CS$<>8__locals1;
				<<UpdatePlotSubtitle>b__0>d.<>1__state = -1;
				<<UpdatePlotSubtitle>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass24_0.<<UpdatePlotSubtitle>b__0>d>(ref <<UpdatePlotSubtitle>b__0>d);
				return <<UpdatePlotSubtitle>b__0>d.<>t__builder.Task;
			}, null).Forget<bool>();
		}

		// Token: 0x06036C6B RID: 224363 RVA: 0x00DE4CBB File Offset: 0x00DE2EBB
		public void ShowPlotSubtitleOptions()
		{
			this.OnShowOptions();
			this.RunWhenCurrentViewReady("ShowPlotSubtitleOptions", delegate
			{
				PlotViewManager.<>c.<<ShowPlotSubtitleOptions>b__25_0>d <<ShowPlotSubtitleOptions>b__25_0>d;
				<<ShowPlotSubtitleOptions>b__25_0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<ShowPlotSubtitleOptions>b__25_0>d.<>1__state = -1;
				<<ShowPlotSubtitleOptions>b__25_0>d.<>t__builder.Start<PlotViewManager.<>c.<<ShowPlotSubtitleOptions>b__25_0>d>(ref <<ShowPlotSubtitleOptions>b__25_0>d);
				return <<ShowPlotSubtitleOptions>b__25_0>d.<>t__builder.Task;
			}, null).Forget<bool>();
		}

		// Token: 0x06036C6C RID: 224364 RVA: 0x00DE4CF4 File Offset: 0x00DE2EF4
		public void EmitPlotStartShowTalk(ShowTalk showTalk)
		{
			PlotViewManager.<>c__DisplayClass26_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass26_0();
			CS$<>8__locals1.showTalk = showTalk;
			this.RunWhenCurrentViewReady("PlotStartShowTalk", delegate
			{
				PlotViewManager.<>c__DisplayClass26_0.<<EmitPlotStartShowTalk>b__0>d <<EmitPlotStartShowTalk>b__0>d;
				<<EmitPlotStartShowTalk>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<EmitPlotStartShowTalk>b__0>d.<>4__this = CS$<>8__locals1;
				<<EmitPlotStartShowTalk>b__0>d.<>1__state = -1;
				<<EmitPlotStartShowTalk>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass26_0.<<EmitPlotStartShowTalk>b__0>d>(ref <<EmitPlotStartShowTalk>b__0>d);
				return <<EmitPlotStartShowTalk>b__0>d.<>t__builder.Task;
			}, null).Forget<bool>();
		}

		// Token: 0x06036C6D RID: 224365 RVA: 0x00DE4D2C File Offset: 0x00DE2F2C
		public void UpdatePortraitVisible(SetHeadIconVisible config, Action callback)
		{
			PlotViewManager.<>c__DisplayClass27_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass27_0();
			CS$<>8__locals1.config = config;
			CS$<>8__locals1.callback = callback;
			this.RunWhenCurrentViewReady("UpdatePortraitVisible", delegate
			{
				PlotViewManager.<>c__DisplayClass27_0.<<UpdatePortraitVisible>b__0>d <<UpdatePortraitVisible>b__0>d;
				<<UpdatePortraitVisible>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<UpdatePortraitVisible>b__0>d.<>4__this = CS$<>8__locals1;
				<<UpdatePortraitVisible>b__0>d.<>1__state = -1;
				<<UpdatePortraitVisible>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass27_0.<<UpdatePortraitVisible>b__0>d>(ref <<UpdatePortraitVisible>b__0>d);
				return <<UpdatePortraitVisible>b__0>d.<>t__builder.Task;
			}, CS$<>8__locals1.callback).Forget<bool>();
		}

		// Token: 0x06036C6E RID: 224366 RVA: 0x00DE4D70 File Offset: 0x00DE2F70
		public void ClearPlotSubtitle(long? ownerId = null)
		{
			if (!this.CheckOwner("ClearPlotSubtitle", ownerId))
			{
				return;
			}
			this.RunWhenCurrentViewReady("ClearPlotSubtitle", delegate
			{
				PlotViewManager.<>c.<<ClearPlotSubtitle>b__28_0>d <<ClearPlotSubtitle>b__28_0>d;
				<<ClearPlotSubtitle>b__28_0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<ClearPlotSubtitle>b__28_0>d.<>1__state = -1;
				<<ClearPlotSubtitle>b__28_0>d.<>t__builder.Start<PlotViewManager.<>c.<<ClearPlotSubtitle>b__28_0>d>(ref <<ClearPlotSubtitle>b__28_0>d);
				return <<ClearPlotSubtitle>b__28_0>d.<>t__builder.Task;
			}, null).Forget<bool>();
		}

		// Token: 0x06036C6F RID: 224367 RVA: 0x00DE4DBC File Offset: 0x00DE2FBC
		public void HidePlotUi(bool isHidden, long? ownerId = null)
		{
			PlotViewManager.<>c__DisplayClass29_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass29_0();
			CS$<>8__locals1.isHidden = isHidden;
			if (!this.CheckOwner("HidePlotUi", ownerId))
			{
				return;
			}
			this.RunWhenCurrentViewReady("HidePlotUi", delegate
			{
				PlotViewManager.<>c__DisplayClass29_0.<<HidePlotUi>b__0>d <<HidePlotUi>b__0>d;
				<<HidePlotUi>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<HidePlotUi>b__0>d.<>4__this = CS$<>8__locals1;
				<<HidePlotUi>b__0>d.<>1__state = -1;
				<<HidePlotUi>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass29_0.<<HidePlotUi>b__0>d>(ref <<HidePlotUi>b__0>d);
				return <<HidePlotUi>b__0>d.<>t__builder.Task;
			}, null).Forget<bool>();
		}

		// Token: 0x06036C70 RID: 224368 RVA: 0x00DE4E04 File Offset: 0x00DE3004
		[NullableContext(2)]
		public void PlotViewBgFadePhoto(bool isFadeIn, bool isFull, string path = null, Action callback = null)
		{
			PlotViewManager.<>c__DisplayClass30_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass30_0();
			CS$<>8__locals1.isFadeIn = isFadeIn;
			CS$<>8__locals1.isFull = isFull;
			CS$<>8__locals1.path = path;
			CS$<>8__locals1.callback = callback;
			this.RunWithPlotView("PlotViewBgFadePhoto", delegate(PlotView _)
			{
				PlotViewManager.<>c__DisplayClass30_0.<<PlotViewBgFadePhoto>b__0>d <<PlotViewBgFadePhoto>b__0>d;
				<<PlotViewBgFadePhoto>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<PlotViewBgFadePhoto>b__0>d.<>4__this = CS$<>8__locals1;
				<<PlotViewBgFadePhoto>b__0>d.<>1__state = -1;
				<<PlotViewBgFadePhoto>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass30_0.<<PlotViewBgFadePhoto>b__0>d>(ref <<PlotViewBgFadePhoto>b__0>d);
				return <<PlotViewBgFadePhoto>b__0>d.<>t__builder.Task;
			}, CS$<>8__locals1.callback).Forget<bool>();
		}

		// Token: 0x06036C71 RID: 224369 RVA: 0x00DE4E58 File Offset: 0x00DE3058
		[NullableContext(2)]
		public void PlotViewBgFadeBlackScreen(bool isFadeIn, Action callback = null)
		{
			PlotViewManager.<>c__DisplayClass31_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass31_0();
			CS$<>8__locals1.isFadeIn = isFadeIn;
			CS$<>8__locals1.callback = callback;
			this.RunWhenCurrentViewReady("PlotViewBgFadeBlackScreen", delegate
			{
				PlotViewManager.<>c__DisplayClass31_0.<<PlotViewBgFadeBlackScreen>b__0>d <<PlotViewBgFadeBlackScreen>b__0>d;
				<<PlotViewBgFadeBlackScreen>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<PlotViewBgFadeBlackScreen>b__0>d.<>4__this = CS$<>8__locals1;
				<<PlotViewBgFadeBlackScreen>b__0>d.<>1__state = -1;
				<<PlotViewBgFadeBlackScreen>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass31_0.<<PlotViewBgFadeBlackScreen>b__0>d>(ref <<PlotViewBgFadeBlackScreen>b__0>d);
				return <<PlotViewBgFadeBlackScreen>b__0>d.<>t__builder.Task;
			}, CS$<>8__locals1.callback).Forget<bool>();
		}

		// Token: 0x06036C72 RID: 224370 RVA: 0x00DE4E9C File Offset: 0x00DE309C
		public void PlotDoingTextShow(bool isShow)
		{
			PlotViewManager.<>c__DisplayClass32_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass32_0();
			CS$<>8__locals1.isShow = isShow;
			this.RunWithPlotSubtitleViewChecked("PlotDoingTextShow", delegate
			{
				PlotViewManager.<>c__DisplayClass32_0.<<PlotDoingTextShow>b__0>d <<PlotDoingTextShow>b__0>d;
				<<PlotDoingTextShow>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<PlotDoingTextShow>b__0>d.<>4__this = CS$<>8__locals1;
				<<PlotDoingTextShow>b__0>d.<>1__state = -1;
				<<PlotDoingTextShow>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass32_0.<<PlotDoingTextShow>b__0>d>(ref <<PlotDoingTextShow>b__0>d);
				return <<PlotDoingTextShow>b__0>d.<>t__builder.Task;
			}, null).Forget<bool>();
		}

		// Token: 0x06036C73 RID: 224371 RVA: 0x00DE4ED4 File Offset: 0x00DE30D4
		[NullableContext(2)]
		public void EnableInteractPlot(bool enable, bool? includeSubtitleButton = null, string reason = null, string skipLock = null)
		{
			PlotViewManager.<>c__DisplayClass33_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass33_0();
			CS$<>8__locals1.enable = enable;
			CS$<>8__locals1.includeSubtitleButton = includeSubtitleButton;
			CS$<>8__locals1.reason = reason;
			CS$<>8__locals1.skipLock = skipLock;
			this.RunWithPlotSubtitleViewChecked("EnableInteractPlot", delegate
			{
				PlotViewManager.<>c__DisplayClass33_0.<<EnableInteractPlot>b__0>d <<EnableInteractPlot>b__0>d;
				<<EnableInteractPlot>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<EnableInteractPlot>b__0>d.<>4__this = CS$<>8__locals1;
				<<EnableInteractPlot>b__0>d.<>1__state = -1;
				<<EnableInteractPlot>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass33_0.<<EnableInteractPlot>b__0>d>(ref <<EnableInteractPlot>b__0>d);
				return <<EnableInteractPlot>b__0>d.<>t__builder.Task;
			}, null).Forget<bool>();
		}

		// Token: 0x06036C74 RID: 224372 RVA: 0x00DE4F24 File Offset: 0x00DE3124
		public void UpdateSeqSubtitle(PlotSubtitleConfig subtitle)
		{
			PlotViewManager.<>c__DisplayClass34_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass34_0();
			CS$<>8__locals1.subtitle = subtitle;
			this.RunWhenCurrentViewReady("UpdateSeqSubtitle", delegate
			{
				PlotViewManager.<>c__DisplayClass34_0.<<UpdateSeqSubtitle>b__0>d <<UpdateSeqSubtitle>b__0>d;
				<<UpdateSeqSubtitle>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<UpdateSeqSubtitle>b__0>d.<>4__this = CS$<>8__locals1;
				<<UpdateSeqSubtitle>b__0>d.<>1__state = -1;
				<<UpdateSeqSubtitle>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass34_0.<<UpdateSeqSubtitle>b__0>d>(ref <<UpdateSeqSubtitle>b__0>d);
				return <<UpdateSeqSubtitle>b__0>d.<>t__builder.Task;
			}, null).Forget<bool>();
		}

		// Token: 0x06036C75 RID: 224373 RVA: 0x00DE4F5C File Offset: 0x00DE315C
		public void HandleSeqSubtitleEnd(int id, bool isSkip)
		{
			PlotViewManager.<>c__DisplayClass35_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass35_0();
			CS$<>8__locals1.id = id;
			CS$<>8__locals1.isSkip = isSkip;
			this.RunWhenCurrentViewReady("HandleSeqSubtitleEnd", delegate
			{
				PlotViewManager.<>c__DisplayClass35_0.<<HandleSeqSubtitleEnd>b__0>d <<HandleSeqSubtitleEnd>b__0>d;
				<<HandleSeqSubtitleEnd>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<HandleSeqSubtitleEnd>b__0>d.<>4__this = CS$<>8__locals1;
				<<HandleSeqSubtitleEnd>b__0>d.<>1__state = -1;
				<<HandleSeqSubtitleEnd>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass35_0.<<HandleSeqSubtitleEnd>b__0>d>(ref <<HandleSeqSubtitleEnd>b__0>d);
				return <<HandleSeqSubtitleEnd>b__0>d.<>t__builder.Task;
			}, null).Forget<bool>();
		}

		// Token: 0x06036C76 RID: 224374 RVA: 0x00DE4F9C File Offset: 0x00DE319C
		public void HandlePlotOptionSelected(int option)
		{
			PlotViewManager.<>c__DisplayClass36_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass36_0();
			CS$<>8__locals1.option = option;
			this.RunWhenCurrentViewReady("HandlePlotOptionSelected", delegate
			{
				PlotViewManager.<>c__DisplayClass36_0.<<HandlePlotOptionSelected>b__0>d <<HandlePlotOptionSelected>b__0>d;
				<<HandlePlotOptionSelected>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<HandlePlotOptionSelected>b__0>d.<>4__this = CS$<>8__locals1;
				<<HandlePlotOptionSelected>b__0>d.<>1__state = -1;
				<<HandlePlotOptionSelected>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass36_0.<<HandlePlotOptionSelected>b__0>d>(ref <<HandlePlotOptionSelected>b__0>d);
				return <<HandlePlotOptionSelected>b__0>d.<>t__builder.Task;
			}, null).Forget<bool>();
		}

		// Token: 0x06036C77 RID: 224375 RVA: 0x00DE4FD3 File Offset: 0x00DE31D3
		public void HandleSubSequenceStop()
		{
			this.RunWhenCurrentViewReady("HandleSubSequenceStop", delegate
			{
				PlotViewManager.<>c.<<HandleSubSequenceStop>b__37_0>d <<HandleSubSequenceStop>b__37_0>d;
				<<HandleSubSequenceStop>b__37_0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<HandleSubSequenceStop>b__37_0>d.<>1__state = -1;
				<<HandleSubSequenceStop>b__37_0>d.<>t__builder.Start<PlotViewManager.<>c.<<HandleSubSequenceStop>b__37_0>d>(ref <<HandleSubSequenceStop>b__37_0>d);
				return <<HandleSubSequenceStop>b__37_0>d.<>t__builder.Task;
			}, null).Forget<bool>();
		}

		// Token: 0x06036C78 RID: 224376 RVA: 0x00DE5005 File Offset: 0x00DE3205
		public void HangPlotViewHud(bool isHang)
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, isHang);
		}

		// Token: 0x06036C79 RID: 224377 RVA: 0x00DE5018 File Offset: 0x00DE3218
		[NullableContext(0)]
		public UniTask<bool> RunWithPlotView([Nullable(1)] string name, [Nullable(new byte[]
		{
			1,
			1,
			0,
			2
		})] Func<PlotView, UniTask<object>> operation, [Nullable(2)] Action onCancel = null)
		{
			PlotViewManager.<>c__DisplayClass39_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass39_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.name = name;
			CS$<>8__locals1.operation = operation;
			return this.RunWhenCurrentViewReady(CS$<>8__locals1.name, delegate
			{
				PlotViewManager.<>c__DisplayClass39_0.<<RunWithPlotView>b__0>d <<RunWithPlotView>b__0>d;
				<<RunWithPlotView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<RunWithPlotView>b__0>d.<>4__this = CS$<>8__locals1;
				<<RunWithPlotView>b__0>d.<>1__state = -1;
				<<RunWithPlotView>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass39_0.<<RunWithPlotView>b__0>d>(ref <<RunWithPlotView>b__0>d);
				return <<RunWithPlotView>b__0>d.<>t__builder.Task;
			}, onCancel);
		}

		// Token: 0x06036C7A RID: 224378 RVA: 0x00DE505C File Offset: 0x00DE325C
		[return: Nullable(0)]
		public UniTask<bool> RunWithPlotSubtitleViewChecked(string name, PlotUiAsyncOperation operation, [Nullable(2)] Action onCancel = null)
		{
			PlotViewManager.<>c__DisplayClass40_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass40_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.name = name;
			CS$<>8__locals1.operation = operation;
			return this.RunWhenCurrentViewReady(CS$<>8__locals1.name, delegate
			{
				PlotViewManager.<>c__DisplayClass40_0.<<RunWithPlotSubtitleViewChecked>b__0>d <<RunWithPlotSubtitleViewChecked>b__0>d;
				<<RunWithPlotSubtitleViewChecked>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<RunWithPlotSubtitleViewChecked>b__0>d.<>4__this = CS$<>8__locals1;
				<<RunWithPlotSubtitleViewChecked>b__0>d.<>1__state = -1;
				<<RunWithPlotSubtitleViewChecked>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass40_0.<<RunWithPlotSubtitleViewChecked>b__0>d>(ref <<RunWithPlotSubtitleViewChecked>b__0>d);
				return <<RunWithPlotSubtitleViewChecked>b__0>d.<>t__builder.Task;
			}, onCancel);
		}

		// Token: 0x06036C7B RID: 224379 RVA: 0x00DE50A0 File Offset: 0x00DE32A0
		[NullableContext(0)]
		public UniTask<bool> RunWithPlotSubtitleView([Nullable(1)] string name, [Nullable(new byte[]
		{
			1,
			1,
			0,
			2
		})] Func<PlotSubtitleView, UniTask<object>> operation, [Nullable(2)] Action onCancel = null)
		{
			PlotViewManager.<>c__DisplayClass41_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass41_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.name = name;
			CS$<>8__locals1.operation = operation;
			return this.RunWhenCurrentViewReady(CS$<>8__locals1.name, delegate
			{
				PlotViewManager.<>c__DisplayClass41_0.<<RunWithPlotSubtitleView>b__0>d <<RunWithPlotSubtitleView>b__0>d;
				<<RunWithPlotSubtitleView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<RunWithPlotSubtitleView>b__0>d.<>4__this = CS$<>8__locals1;
				<<RunWithPlotSubtitleView>b__0>d.<>1__state = -1;
				<<RunWithPlotSubtitleView>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass41_0.<<RunWithPlotSubtitleView>b__0>d>(ref <<RunWithPlotSubtitleView>b__0>d);
				return <<RunWithPlotSubtitleView>b__0>d.<>t__builder.Task;
			}, onCancel);
		}

		// Token: 0x06036C7C RID: 224380 RVA: 0x00DE50E4 File Offset: 0x00DE32E4
		[return: Nullable(0)]
		public UniTask<bool> RunWithPlotSubtitleView(string name, Func<PlotSubtitleView, UniTask> operation, [Nullable(2)] Action onCancel = null)
		{
			PlotViewManager.<>c__DisplayClass42_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass42_0();
			CS$<>8__locals1.operation = operation;
			return this.RunWithPlotSubtitleView(name, delegate(PlotSubtitleView view)
			{
				PlotViewManager.<>c__DisplayClass42_0.<<RunWithPlotSubtitleView>b__0>d <<RunWithPlotSubtitleView>b__0>d;
				<<RunWithPlotSubtitleView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
				<<RunWithPlotSubtitleView>b__0>d.<>4__this = CS$<>8__locals1;
				<<RunWithPlotSubtitleView>b__0>d.view = view;
				<<RunWithPlotSubtitleView>b__0>d.<>1__state = -1;
				<<RunWithPlotSubtitleView>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass42_0.<<RunWithPlotSubtitleView>b__0>d>(ref <<RunWithPlotSubtitleView>b__0>d);
				return <<RunWithPlotSubtitleView>b__0>d.<>t__builder.Task;
			}, onCancel);
		}

		// Token: 0x06036C7D RID: 224381 RVA: 0x00DE5112 File Offset: 0x00DE3312
		public void OnSelectedOptions()
		{
			ModelBase<PlotModel>.Instance.InOptions = false;
		}

		// Token: 0x06036C7E RID: 224382 RVA: 0x00DE5120 File Offset: 0x00DE3320
		private void InterruptHud(bool isHang)
		{
			if (isHang)
			{
				ModelBase<PlotModel>.Instance.HangViewHud = true;
				Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "[PlotView] 引导界面打开挂起HUD剧情", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.HangPlotViewHud(true);
				return;
			}
			ModelBase<PlotModel>.Instance.HangViewHud = false;
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "[PlotView] 引导界面解除挂起HUD剧情", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.HangPlotViewHud(false);
		}

		// Token: 0x06036C7F RID: 224383 RVA: 0x00DE5190 File Offset: 0x00DE3390
		private void OnBattleUiSlowTimeVisibleChanged(bool visible)
		{
			if (this.GetCurrentViewName() == EUiViewName.PlotViewHUD)
			{
				PlotViewHud plotViewHud = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PlotViewHUD) as PlotViewHud;
				if (plotViewHud != null)
				{
					plotViewHud.SetEnableTranslucent(visible);
				}
			}
			ModelBase<PlotModel>.Instance.TranslucentHud = visible;
		}

		// Token: 0x06036C80 RID: 224384 RVA: 0x00DE51F0 File Offset: 0x00DE33F0
		private void ViewCloseCheck(EUiViewName viewName)
		{
			if (this.IsSwitching && this.SwitchFromView == viewName)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[PlotView] 旧剧情界面按计划关闭";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", this.SwitchFromView);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.HandleSwitchFromViewClosed().Forget();
				return;
			}
			if (this.CurrentView != viewName)
			{
				return;
			}
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Plot;
			ELogAuthor author2 = ELogAuthor.FZX;
			string message2 = "[PlotView] 剧情界面关闭";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("viewName", this.CurrentView);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.CurrentView = null;
			this.CurrentViewOwnerId = null;
			this.IsShowing = false;
			this.CancelPendingViewOperations();
			if (this.ViewEnable)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.FZX, "[PlotView] 剧情界面意外关闭，跳过当前剧情", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ViewEnable = false;
				this.IsLock = true;
				this.FinishSwitching();
				this.DoCallback(false);
				ControllerBase<FlowController>.Instance.BackgroundFlow("剧情界面意外关闭 跳过剧情", false, false, false);
			}
			this.CheckPending();
		}

		// Token: 0x06036C81 RID: 224385 RVA: 0x00DE5339 File Offset: 0x00DE3539
		[NullableContext(2)]
		public void OpenPlotView(EUiViewName viewName, TCallback callback = null, UiParam uiParam = null, long? ownerId = null)
		{
			this.Open(viewName, uiParam, callback, ownerId);
		}

		// Token: 0x06036C82 RID: 224386 RVA: 0x00DE5346 File Offset: 0x00DE3546
		public void ClosePlotView(long? ownerId = null)
		{
			this.Close(ownerId);
		}

		// Token: 0x06036C83 RID: 224387 RVA: 0x00DE5350 File Offset: 0x00DE3550
		public UniTask OpenTipsView(EPromptStyle style, UiParam param)
		{
			PlotViewManager.<OpenTipsView>d__49 <OpenTipsView>d__;
			<OpenTipsView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenTipsView>d__.<>4__this = this;
			<OpenTipsView>d__.style = style;
			<OpenTipsView>d__.param = param;
			<OpenTipsView>d__.<>1__state = -1;
			<OpenTipsView>d__.<>t__builder.Start<PlotViewManager.<OpenTipsView>d__49>(ref <OpenTipsView>d__);
			return <OpenTipsView>d__.<>t__builder.Task;
		}

		// Token: 0x06036C84 RID: 224388 RVA: 0x00DE53A3 File Offset: 0x00DE35A3
		public void CloseTipsView()
		{
			if (this.TipsView != null)
			{
				this.TipsView.CloseAsync().Forget();
			}
			this.TipsView = null;
		}

		// Token: 0x06036C85 RID: 224389 RVA: 0x00DE53C4 File Offset: 0x00DE35C4
		[NullableContext(2)]
		private unsafe void Open(EUiViewName viewName, UiParam param = null, TCallback callback = null, long? ownerId = null)
		{
			PlotViewManager.<>c__DisplayClass51_0 CS$<>8__locals1 = new PlotViewManager.<>c__DisplayClass51_0();
			CS$<>8__locals1.param = param;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[PlotView] 请求打开界面";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("new", viewName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("current", this.CurrentView);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ownerId", ownerId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (this.IsLock)
			{
				this.AddPending(new ViewHandle(new EUiViewName?(viewName), CS$<>8__locals1.param, callback, ownerId));
				return;
			}
			if (this.CurrentView == viewName)
			{
				if (ownerId != null)
				{
					this.CurrentViewOwnerId = ownerId;
				}
				this.RunWhenCurrentViewReady("UpdatePlotUiParam", delegate
				{
					PlotViewManager.<>c__DisplayClass51_0.<<Open>b__0>d <<Open>b__0>d;
					<<Open>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
					<<Open>b__0>d.<>4__this = CS$<>8__locals1;
					<<Open>b__0>d.<>1__state = -1;
					<<Open>b__0>d.<>t__builder.Start<PlotViewManager.<>c__DisplayClass51_0.<<Open>b__0>d>(ref <<Open>b__0>d);
					return <<Open>b__0>d.<>t__builder.Task;
				}, null).Forget<bool>();
				Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "[PlotView] 重复打开", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.WaitOpenCallback(callback);
				this.ContinuePendingAfterSkip();
				return;
			}
			if (this.CurrentView != null)
			{
				this.OpenBeforeClose(viewName, CS$<>8__locals1.param, callback, ownerId);
				return;
			}
			this.IsLock = true;
			this.ViewEnable = true;
			this.CurrentView = new EUiViewName?(viewName);
			this.CurrentViewOwnerId = ownerId;
			this.WaitOpenCallback(callback);
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Plot;
			ELogAuthor author2 = ELogAuthor.FZX;
			string message2 = "[PlotView] 打开";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("open", viewName);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.OpenViewByName(viewName, CS$<>8__locals1.param);
		}

		// Token: 0x06036C86 RID: 224390 RVA: 0x00DE5580 File Offset: 0x00DE3780
		[NullableContext(2)]
		private unsafe void OpenBeforeClose(EUiViewName viewName, UiParam param = null, TCallback callback = null, long? ownerId = null)
		{
			if (this.IsSwitching)
			{
				this.AddPending(new ViewHandle(new EUiViewName?(viewName), param, callback, ownerId));
				return;
			}
			this.IsSwitching = true;
			this.SwitchFromView = this.CurrentView;
			this.SwitchToView = new EUiViewName?(viewName);
			this.IsLock = true;
			this.IsShowing = false;
			this.ViewEnable = true;
			this.CancelPendingViewOperations();
			this.CurrentView = new EUiViewName?(viewName);
			this.CurrentViewOwnerId = ownerId;
			this.WaitOpenCallback(callback);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[PlotView] 剧情界面切换，先开新后关旧";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("from", this.SwitchFromView);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("to", this.SwitchToView);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.OpenViewByName(viewName, param);
		}

		// Token: 0x06036C87 RID: 224391 RVA: 0x00DE5670 File Offset: 0x00DE3870
		[NullableContext(2)]
		private unsafe void OpenViewByName(EUiViewName viewName, UiParam param = null)
		{
			int num = 2;
			List<EUiViewName> list = new List<EUiViewName>(num);
			CollectionsMarshal.SetCount<EUiViewName>(list, num);
			Span<EUiViewName> span = CollectionsMarshal.AsSpan<EUiViewName>(list);
			int num2 = 0;
			*span[num2] = EUiViewName.PlotViewHUD;
			num2++;
			*span[num2] = EUiViewName.ActivityGamePlayPlotView;
			if (list.Contains(viewName))
			{
				Singleton<UiManager>.Instance.OpenView(viewName, param, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenViewByPlot(viewName, param, null);
		}

		// Token: 0x06036C88 RID: 224392 RVA: 0x00DE56E0 File Offset: 0x00DE38E0
		private unsafe void Close(long? ownerId = null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[PlotView] 请求关闭界面";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("current", this.CurrentView);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ownerId", ownerId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("currentOwnerId", this.CurrentViewOwnerId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (!this.CheckOwner("ClosePlotView", ownerId))
			{
				this.ContinuePendingAfterSkip();
				return;
			}
			if (this.IsLock)
			{
				this.AddPending(new ViewHandle(null, null, null, ownerId));
				return;
			}
			if (this.CurrentView == null)
			{
				this.ContinuePendingAfterSkip();
				return;
			}
			this.IsLock = true;
			this.ViewEnable = false;
			this.CancelPendingViewOperations();
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Plot;
			ELogAuthor author2 = ELogAuthor.FZX;
			string message2 = "[PlotView] 关闭";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("close", this.CurrentView);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<UiManager>.Instance.CloseView(this.CurrentView.Value, null);
		}

		// Token: 0x06036C89 RID: 224393 RVA: 0x00DE5815 File Offset: 0x00DE3A15
		[NullableContext(2)]
		public void WaitOpenCallback(TCallback callback = null)
		{
			if (callback == null)
			{
				return;
			}
			if (!this.ViewEnable)
			{
				callback(false);
				return;
			}
			if (!this.IsShowing)
			{
				this.Callbacks.Add(callback);
				return;
			}
			callback(true);
		}

		// Token: 0x06036C8A RID: 224394 RVA: 0x00DE5848 File Offset: 0x00DE3A48
		[NullableContext(2)]
		public void RemoveCallback(TCallback callback = null)
		{
			if (callback == null)
			{
				return;
			}
			this.Callbacks.Remove(callback);
		}

		// Token: 0x06036C8B RID: 224395 RVA: 0x00DE585C File Offset: 0x00DE3A5C
		private void DoCallback(bool result)
		{
			HashSet<TCallback> callbacks = this.Callbacks;
			this.Callbacks = new HashSet<TCallback>();
			foreach (TCallback tcallback in callbacks)
			{
				if (tcallback != null)
				{
					tcallback(result);
				}
			}
		}

		// Token: 0x06036C8C RID: 224396 RVA: 0x00DE58C0 File Offset: 0x00DE3AC0
		private void CheckPending()
		{
			this.IsLock = false;
			if (this.PendingHandle.Size == 0)
			{
				return;
			}
			ViewHandle viewHandle = this.PendingHandle.Pop();
			if (viewHandle != null && viewHandle.ViewName != null)
			{
				this.Open(viewHandle.ViewName.Value, viewHandle.Param, viewHandle.Callback, viewHandle.OwnerId);
				return;
			}
			this.Close((viewHandle != null) ? viewHandle.OwnerId : null);
		}

		// Token: 0x06036C8D RID: 224397 RVA: 0x00DE5942 File Offset: 0x00DE3B42
		private void ContinuePendingAfterSkip()
		{
			if (this.IsLock)
			{
				return;
			}
			this.CheckPending();
		}

		// Token: 0x06036C8E RID: 224398 RVA: 0x00DE5954 File Offset: 0x00DE3B54
		private unsafe void AddPending(ViewHandle handle)
		{
			this.PendingHandle.Push(handle);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[PlotView] 操作进入缓存";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Handle";
			EUiViewName? viewName = handle.ViewName;
			ptr = new ValueTuple<string, object>(item, (viewName != null) ? viewName.GetValueOrDefault() : "CloseView");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ownerId", handle.OwnerId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06036C8F RID: 224399 RVA: 0x00DE59EC File Offset: 0x00DE3BEC
		[return: Nullable(0)]
		public unsafe UniTask<bool> RunWhenCurrentViewReady(string name, PlotUiAsyncOperation operation, [Nullable(2)] Action onCancel = null)
		{
			CustomPromise<bool> customPromise = new CustomPromise<bool>();
			if (!this.CanQueueViewOperation())
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[PlotView] 剧情界面不存在，操作取消";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("operation", name);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				if (onCancel != null)
				{
					onCancel();
				}
				customPromise.SetResult(false);
				return customPromise.Promise;
			}
			PlotUiOperationHandle plotUiOperationHandle = new PlotUiOperationHandle(name, this.CurrentView.Value, operation, customPromise, onCancel);
			if (this.CanRunViewOperation())
			{
				this.ExecuteViewOperation(plotUiOperationHandle).Forget();
				return customPromise.Promise;
			}
			this.PendingViewOperations.Add(plotUiOperationHandle);
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Plot;
			ELogAuthor author2 = ELogAuthor.FZX;
			string message2 = "[PlotView] UI操作进入缓存";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("operation", name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("view", plotUiOperationHandle.TargetView);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return customPromise.Promise;
		}

		// Token: 0x06036C90 RID: 224400 RVA: 0x00DE5AE4 File Offset: 0x00DE3CE4
		private UniTask HandleCurrentViewShown()
		{
			PlotViewManager.<HandleCurrentViewShown>d__62 <HandleCurrentViewShown>d__;
			<HandleCurrentViewShown>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleCurrentViewShown>d__.<>4__this = this;
			<HandleCurrentViewShown>d__.<>1__state = -1;
			<HandleCurrentViewShown>d__.<>t__builder.Start<PlotViewManager.<HandleCurrentViewShown>d__62>(ref <HandleCurrentViewShown>d__);
			return <HandleCurrentViewShown>d__.<>t__builder.Task;
		}

		// Token: 0x06036C91 RID: 224401 RVA: 0x00DE5B28 File Offset: 0x00DE3D28
		private UniTask HandleSwitchFromViewClosed()
		{
			PlotViewManager.<HandleSwitchFromViewClosed>d__63 <HandleSwitchFromViewClosed>d__;
			<HandleSwitchFromViewClosed>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleSwitchFromViewClosed>d__.<>4__this = this;
			<HandleSwitchFromViewClosed>d__.<>1__state = -1;
			<HandleSwitchFromViewClosed>d__.<>t__builder.Start<PlotViewManager.<HandleSwitchFromViewClosed>d__63>(ref <HandleSwitchFromViewClosed>d__);
			return <HandleSwitchFromViewClosed>d__.<>t__builder.Task;
		}

		// Token: 0x06036C92 RID: 224402 RVA: 0x00DE5B6B File Offset: 0x00DE3D6B
		private bool CanQueueViewOperation()
		{
			return this.CurrentView != null;
		}

		// Token: 0x06036C93 RID: 224403 RVA: 0x00DE5B78 File Offset: 0x00DE3D78
		private unsafe bool CheckOwner(string operation, long? ownerId = null)
		{
			if (ownerId != null)
			{
				long? num = ownerId;
				long? currentViewOwnerId = this.CurrentViewOwnerId;
				if (!(num.GetValueOrDefault() == currentViewOwnerId.GetValueOrDefault() & num != null == (currentViewOwnerId != null)))
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Plot;
					ELogAuthor author = ELogAuthor.FZX;
					string message = "[PlotView] UI操作归属不匹配，操作跳过";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("operation", operation);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("current", this.CurrentView);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ownerId", ownerId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("currentOwnerId", this.CurrentViewOwnerId);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
					return false;
				}
			}
			return true;
		}

		// Token: 0x06036C94 RID: 224404 RVA: 0x00DE5C59 File Offset: 0x00DE3E59
		private bool CanRunViewOperation()
		{
			return (!this.IsSwitching || this.SwitchFromView == null) && (this.ViewEnable && this.IsShowing) && this.GetCurrentView() != null;
		}

		// Token: 0x06036C95 RID: 224405 RVA: 0x00DE5C8D File Offset: 0x00DE3E8D
		[NullableContext(2)]
		private object GetCurrentView()
		{
			if (this.CurrentView == null)
			{
				return null;
			}
			return Singleton<UiManager>.Instance.GetViewByName(this.CurrentView.Value);
		}

		// Token: 0x06036C96 RID: 224406 RVA: 0x00DE5CB4 File Offset: 0x00DE3EB4
		private UniTask FlushPendingViewOperations()
		{
			PlotViewManager.<FlushPendingViewOperations>d__68 <FlushPendingViewOperations>d__;
			<FlushPendingViewOperations>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FlushPendingViewOperations>d__.<>4__this = this;
			<FlushPendingViewOperations>d__.<>1__state = -1;
			<FlushPendingViewOperations>d__.<>t__builder.Start<PlotViewManager.<FlushPendingViewOperations>d__68>(ref <FlushPendingViewOperations>d__);
			return <FlushPendingViewOperations>d__.<>t__builder.Task;
		}

		// Token: 0x06036C97 RID: 224407 RVA: 0x00DE5CF8 File Offset: 0x00DE3EF8
		private UniTask ExecuteNextPendingViewOperation()
		{
			PlotViewManager.<ExecuteNextPendingViewOperation>d__69 <ExecuteNextPendingViewOperation>d__;
			<ExecuteNextPendingViewOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteNextPendingViewOperation>d__.<>4__this = this;
			<ExecuteNextPendingViewOperation>d__.<>1__state = -1;
			<ExecuteNextPendingViewOperation>d__.<>t__builder.Start<PlotViewManager.<ExecuteNextPendingViewOperation>d__69>(ref <ExecuteNextPendingViewOperation>d__);
			return <ExecuteNextPendingViewOperation>d__.<>t__builder.Task;
		}

		// Token: 0x06036C98 RID: 224408 RVA: 0x00DE5D3C File Offset: 0x00DE3F3C
		private UniTask ExecuteViewOperation(PlotUiOperationHandle handle)
		{
			PlotViewManager.<ExecuteViewOperation>d__70 <ExecuteViewOperation>d__;
			<ExecuteViewOperation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteViewOperation>d__.handle = handle;
			<ExecuteViewOperation>d__.<>1__state = -1;
			<ExecuteViewOperation>d__.<>t__builder.Start<PlotViewManager.<ExecuteViewOperation>d__70>(ref <ExecuteViewOperation>d__);
			return <ExecuteViewOperation>d__.<>t__builder.Task;
		}

		// Token: 0x06036C99 RID: 224409 RVA: 0x00DE5D7F File Offset: 0x00DE3F7F
		private void CancelPendingViewOperations()
		{
			while (this.PendingViewOperations.Count > 0)
			{
				this.CancelViewOperation(this.PendingViewOperations[0]);
				this.PendingViewOperations.RemoveAt(0);
			}
		}

		// Token: 0x06036C9A RID: 224410 RVA: 0x00DE5DAF File Offset: 0x00DE3FAF
		private void CancelViewOperation(PlotUiOperationHandle handle)
		{
			Action onCancel = handle.OnCancel;
			if (onCancel != null)
			{
				onCancel();
			}
			handle.ResultPromise.SetResult(false);
		}

		// Token: 0x06036C9B RID: 224411 RVA: 0x00DE5DCE File Offset: 0x00DE3FCE
		private void FinishSwitching()
		{
			this.IsSwitching = false;
			this.SwitchFromView = null;
			this.SwitchToView = null;
		}

		// Token: 0x0401F8C7 RID: 129223
		private EUiViewName? CurrentView;

		// Token: 0x0401F8C8 RID: 129224
		private long? CurrentViewOwnerId;

		// Token: 0x0401F8C9 RID: 129225
		private HashSet<TCallback> Callbacks = new HashSet<TCallback>();

		// Token: 0x0401F8CA RID: 129226
		private bool IsShowing;

		// Token: 0x0401F8CB RID: 129227
		private bool ViewEnable;

		// Token: 0x0401F8CC RID: 129228
		private bool IsLock;

		// Token: 0x0401F8CD RID: 129229
		private readonly Queue<ViewHandle> PendingHandle = new Queue<ViewHandle>(4);

		// Token: 0x0401F8CE RID: 129230
		[Nullable(2)]
		private PlotTipsViewBase TipsView;

		// Token: 0x0401F8CF RID: 129231
		private readonly List<PlotUiOperationHandle> PendingViewOperations = new List<PlotUiOperationHandle>();

		// Token: 0x0401F8D0 RID: 129232
		private bool IsFlushingViewOperation;

		// Token: 0x0401F8D1 RID: 129233
		private EUiViewName? SwitchFromView;

		// Token: 0x0401F8D2 RID: 129234
		private EUiViewName? SwitchToView;

		// Token: 0x0401F8D3 RID: 129235
		private bool IsSwitching;
	}
}
