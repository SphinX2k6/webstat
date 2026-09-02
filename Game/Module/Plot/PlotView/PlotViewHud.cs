using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.Module.Plot.Sequence.Assistant;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053CF RID: 21455
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotViewHud : UiTickViewBase, ISimulatePlot
	{
		// Token: 0x06036C11 RID: 224273 RVA: 0x00DE36BF File Offset: 0x00DE18BF
		public void SimulateClickSubtitle()
		{
		}

		// Token: 0x06036C12 RID: 224274 RVA: 0x00DE36C1 File Offset: 0x00DE18C1
		public void SimulateClickOption()
		{
		}

		// Token: 0x17008DBA RID: 36282
		// (get) Token: 0x06036C13 RID: 224275 RVA: 0x00DE36C3 File Offset: 0x00DE18C3
		[Nullable(2)]
		public ITalkItem CurrentSubtitle
		{
			[NullableContext(2)]
			get
			{
				return this.CommonLogic.CurrentContent;
			}
		}

		// Token: 0x06036C14 RID: 224276 RVA: 0x00DE36D0 File Offset: 0x00DE18D0
		public PlotViewHud(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036C15 RID: 224277 RVA: 0x00DE36E8 File Offset: 0x00DE18E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISliderComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036C16 RID: 224278 RVA: 0x00DE38C4 File Offset: 0x00DE1AC4
		protected override void OnStart()
		{
			UUIScrollViewComponent scrollView = base.GetScrollView(8);
			if (scrollView != null)
			{
				scrollView.SetCanScroll(false);
			}
			if (scrollView != null)
			{
				scrollView.SetRayCastTargetForScrollView(false);
			}
			this.CommonLogic = new PlotTextCommonLogic(base.GetItem(4), base.GetText(0), base.GetText(1), base.GetText(2), base.GetItem(3), scrollView, this, base.GetLayoutBase(10), base.GetItem(11), base.GetSlider(12), this.UiViewSequence, null, null, null, null, null, null, null, null, null);
			this.CommonLogic.SetPlotContentAnimFinishCallback(new Action(this.HandleSubtitleAnimFinished));
			this.SetPlotPosition();
			this.SetTextWidth();
			this.IsHang = false;
		}

		// Token: 0x06036C17 RID: 224279 RVA: 0x00DE3970 File Offset: 0x00DE1B70
		protected override UniTask OnBeforeStartAsync()
		{
			PlotViewHud.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PlotViewHud.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036C18 RID: 224280 RVA: 0x00DE39B4 File Offset: 0x00DE1BB4
		private UniTask OpenEntitySequenceViewAsync()
		{
			PlotViewHud.<OpenEntitySequenceViewAsync>d__23 <OpenEntitySequenceViewAsync>d__;
			<OpenEntitySequenceViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenEntitySequenceViewAsync>d__.<>4__this = this;
			<OpenEntitySequenceViewAsync>d__.<>1__state = -1;
			<OpenEntitySequenceViewAsync>d__.<>t__builder.Start<PlotViewHud.<OpenEntitySequenceViewAsync>d__23>(ref <OpenEntitySequenceViewAsync>d__);
			return <OpenEntitySequenceViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036C19 RID: 224281 RVA: 0x00DE39F8 File Offset: 0x00DE1BF8
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<UUIItem> GetEntitySequenceButtonRootAsync()
		{
			PlotViewHud.<GetEntitySequenceButtonRootAsync>d__24 <GetEntitySequenceButtonRootAsync>d__;
			<GetEntitySequenceButtonRootAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<UUIItem>.Create();
			<GetEntitySequenceButtonRootAsync>d__.<>1__state = -1;
			<GetEntitySequenceButtonRootAsync>d__.<>t__builder.Start<PlotViewHud.<GetEntitySequenceButtonRootAsync>d__24>(ref <GetEntitySequenceButtonRootAsync>d__);
			return <GetEntitySequenceButtonRootAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036C1A RID: 224282 RVA: 0x00DE3A33 File Offset: 0x00DE1C33
		private void HandleSubtitleAnimFinished()
		{
			if (this.IsControlEntitySequenceBridge())
			{
				return;
			}
			this.DelayHandleSubtitleActions();
		}

		// Token: 0x06036C1B RID: 224283 RVA: 0x00DE3A44 File Offset: 0x00DE1C44
		private void DelayHandleSubtitleActions()
		{
			if (this.IsControlEntitySequenceBridge())
			{
				return;
			}
			this.RemoveDelayTimer();
			float num = ModelBase<PlotModel>.Instance.PlotGlobalConfig.EndWaitTimeLevelD * 1000f;
			TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
			TTimerAction action = new TTimerAction(this.HandleSubtitleActions);
			float? playDelayTime = this.CommonLogic.PlayDelayTime;
			float num2 = num;
			this.DelayTimer = gameplayTimeInstance.Delay(action, (playDelayTime.GetValueOrDefault() <= num2 & playDelayTime != null) ? num : this.CommonLogic.PlayDelayTime.GetValueOrDefault(), null, null, true, 1f);
		}

		// Token: 0x06036C1C RID: 224284 RVA: 0x00DE3AD2 File Offset: 0x00DE1CD2
		private void HandleSubtitleActions(float _)
		{
			this.RemoveDelayTimer();
			this.IsInSubtitle = false;
			if (this.IsControlEntitySequenceBridge())
			{
				return;
			}
			ControllerBase<FlowController>.Instance.FlowShowTalk.SubmitSubtitle(this.CommonLogic.CurrentContent);
		}

		// Token: 0x06036C1D RID: 224285 RVA: 0x00DE3B04 File Offset: 0x00DE1D04
		private void RemoveDelayTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.DelayTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DelayTimer);
			}
			this.DelayTimer = null;
		}

		// Token: 0x06036C1E RID: 224286 RVA: 0x00DE3B30 File Offset: 0x00DE1D30
		protected override UniTask OnPlayingCloseSequenceAsync()
		{
			PlotViewHud.<OnPlayingCloseSequenceAsync>d__29 <OnPlayingCloseSequenceAsync>d__;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
			<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<PlotViewHud.<OnPlayingCloseSequenceAsync>d__29>(ref <OnPlayingCloseSequenceAsync>d__);
			return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036C1F RID: 224287 RVA: 0x00DE3B74 File Offset: 0x00DE1D74
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<ITalkItem>(EEventName.UpdatePlotSubtitle, new Action<ITalkItem>(this.UpdatePlotSubtitle));
			Singleton<EventSystem>.Instance.Add<SetHeadIconVisible, Action>(EEventName.UpdatePortraitVisible, new Action<SetHeadIconVisible, Action>(this.HandlePortraitVisible));
			Singleton<EventSystem>.Instance.Add(EEventName.ClearPlotSubtitle, new Action(this.ClearPlotSubtitle));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.HangPlotViewHud, new Action<bool>(this.OnHang));
			Singleton<EventSystem>.Instance.Add<UiParam>(EEventName.UpdatePlotUiParam, new Action<UiParam>(this.UpdateUiParam));
			Singleton<EventSystem>.Instance.Add(EEventName.ShowPlotSubtitleOptions, new Action(this.ShowOptions));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			ControllerBase<SequenceController>.Instance.Event.Add(ESequenceEventName.UpdateSeqSubtitle, new Action<PlotSubtitleConfig>(this.UpdateSequenceSubtitle));
			ControllerBase<SequenceController>.Instance.Event.Add(ESequenceEventName.HandlePlotOptionSelected, new Action<int>(this.HandlePlotOptionSelected));
			ControllerBase<SequenceController>.Instance.Event.Add(ESequenceEventName.HandleSeqSubtitleEnd, new Action<int, bool>(this.HandleSeqSubtitleEnd));
			ControllerBase<SequenceController>.Instance.Event.Add(ESequenceEventName.HandleSubSequenceStop, new Action(this.HandleSubSequenceStop));
		}

		// Token: 0x06036C20 RID: 224288 RVA: 0x00DE3CBC File Offset: 0x00DE1EBC
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<ITalkItem>(EEventName.UpdatePlotSubtitle, new Action<ITalkItem>(this.UpdatePlotSubtitle));
			Singleton<EventSystem>.Instance.Remove<SetHeadIconVisible, Action>(EEventName.UpdatePortraitVisible, new Action<SetHeadIconVisible, Action>(this.HandlePortraitVisible));
			Singleton<EventSystem>.Instance.Remove(EEventName.ClearPlotSubtitle, new Action(this.ClearPlotSubtitle));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.HangPlotViewHud, new Action<bool>(this.OnHang));
			Singleton<EventSystem>.Instance.Remove<UiParam>(EEventName.UpdatePlotUiParam, new Action<UiParam>(this.UpdateUiParam));
			Singleton<EventSystem>.Instance.Remove(EEventName.ShowPlotSubtitleOptions, new Action(this.ShowOptions));
			Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			ControllerBase<SequenceController>.Instance.Event.Remove(ESequenceEventName.UpdateSeqSubtitle, new Action<PlotSubtitleConfig>(this.UpdateSequenceSubtitle));
			ControllerBase<SequenceController>.Instance.Event.Remove(ESequenceEventName.HandlePlotOptionSelected, new Action<int>(this.HandlePlotOptionSelected));
			ControllerBase<SequenceController>.Instance.Event.Remove(ESequenceEventName.HandleSeqSubtitleEnd, new Action<int, bool>(this.HandleSeqSubtitleEnd));
			ControllerBase<SequenceController>.Instance.Event.Remove(ESequenceEventName.HandleSubSequenceStop, new Action(this.HandleSubSequenceStop));
		}

		// Token: 0x06036C21 RID: 224289 RVA: 0x00DE3E01 File Offset: 0x00DE2001
		private void OnInputControllerChange(EInputControllerType _1, EInputControllerType _2)
		{
			if (this.HasBindActionGamepad || this.HasBindActionOther)
			{
				this.HandleActionBinding(false);
				this.HandleActionBinding(true);
			}
			EntitySequenceView entitySequenceView = this.EntitySequenceView;
			if (entitySequenceView != null)
			{
				entitySequenceView.RefreshActionBinding();
			}
			this.RefreshEntitySequenceParentAsync().Forget();
		}

		// Token: 0x06036C22 RID: 224290 RVA: 0x00DE3E40 File Offset: 0x00DE2040
		private UniTask RefreshEntitySequenceParentAsync()
		{
			PlotViewHud.<RefreshEntitySequenceParentAsync>d__33 <RefreshEntitySequenceParentAsync>d__;
			<RefreshEntitySequenceParentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshEntitySequenceParentAsync>d__.<>4__this = this;
			<RefreshEntitySequenceParentAsync>d__.<>1__state = -1;
			<RefreshEntitySequenceParentAsync>d__.<>t__builder.Start<PlotViewHud.<RefreshEntitySequenceParentAsync>d__33>(ref <RefreshEntitySequenceParentAsync>d__);
			return <RefreshEntitySequenceParentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036C23 RID: 224291 RVA: 0x00DE3E83 File Offset: 0x00DE2083
		private void ShowOptions()
		{
			this.IsInOption = true;
			this.CommonLogic.ShowOptions();
			this.BindInput();
		}

		// Token: 0x06036C24 RID: 224292 RVA: 0x00DE3E9D File Offset: 0x00DE209D
		private void ClearOptions()
		{
			this.IsInOption = false;
			this.CommonLogic.ClearOptions();
			this.UnbindInput();
		}

		// Token: 0x06036C25 RID: 224293 RVA: 0x00DE3EB8 File Offset: 0x00DE20B8
		private void UpdateSequenceSubtitle(PlotSubtitleConfig inPlotSubtitleInfo)
		{
			if (!this.IsControlEntitySequenceBridge())
			{
				return;
			}
			ITalkItem subtitles = inPlotSubtitleInfo.Subtitles;
			if (subtitles == null)
			{
				return;
			}
			this.SetControlEntityHudVisible(true);
			this.CurrentSequenceSubtitleId = subtitles.Id;
			this.UpdatePlotSubtitle(subtitles);
		}

		// Token: 0x06036C26 RID: 224294 RVA: 0x00DE3EF3 File Offset: 0x00DE20F3
		private void UpdatePlotSubtitle(ITalkItem inPlotSubtitleInfo)
		{
			if (this.IsHang)
			{
				return;
			}
			this.IsInSubtitle = true;
			this.ClearOptions();
			this.CommonLogic.UpdatePlotSubtitle(inPlotSubtitleInfo);
		}

		// Token: 0x06036C27 RID: 224295 RVA: 0x00DE3F17 File Offset: 0x00DE2117
		private void HandlePortraitVisible(SetHeadIconVisible headIconInfo, Action callback)
		{
			this.CommonLogic.HandlePortraitVisible(this.RootItem, headIconInfo, callback);
		}

		// Token: 0x06036C28 RID: 224296 RVA: 0x00DE3F2C File Offset: 0x00DE212C
		private void ClearPlotSubtitle()
		{
			this.IsInSubtitle = false;
			this.CommonLogic.ClearPlotContent(false);
			this.ClearOptions();
			this.RemoveDelayTimer();
			this.ResumeSequenceForControlEntityOption();
			this.CurrentSequenceSubtitleId = -1;
		}

		// Token: 0x06036C29 RID: 224297 RVA: 0x00DE3F5A File Offset: 0x00DE215A
		private void ClearSubtitleDisplayOnEnd()
		{
			this.IsInSubtitle = false;
			this.CommonLogic.ClearPlotContent(true);
			this.RemoveDelayTimer();
			this.CurrentSequenceSubtitleId = -1;
		}

		// Token: 0x06036C2A RID: 224298 RVA: 0x00DE3F7C File Offset: 0x00DE217C
		private void HandleSeqSubtitleEnd(int id, bool isSkip)
		{
			if (!this.IsControlEntitySequenceBridge())
			{
				return;
			}
			ITalkItem currentSubtitle = this.CurrentSubtitle;
			if (((currentSubtitle != null) ? currentSubtitle.Id : this.CurrentSequenceSubtitleId) != id)
			{
				return;
			}
			if (isSkip)
			{
				this.ClearPlotSubtitle();
				this.SetControlEntityHudVisible(false);
				return;
			}
			ITalkItem talkItem = currentSubtitle ?? ModelBase<PlotModel>.Instance.CurTalkItem;
			if (talkItem != null && this.CheckHasSubtitleOptions(talkItem))
			{
				this.ClearSubtitleDisplayOnEnd();
				this.PauseSequenceForControlEntityOption();
				this.ShowOptions();
				return;
			}
			this.ClearPlotSubtitle();
			this.SetControlEntityHudVisible(false);
		}

		// Token: 0x06036C2B RID: 224299 RVA: 0x00DE3FFB File Offset: 0x00DE21FB
		private void HandlePlotOptionSelected(int inOptionIndex)
		{
			if (!this.IsControlEntitySequenceBridge())
			{
				return;
			}
			this.ClearPlotSubtitle();
			this.SetControlEntityHudVisible(false);
		}

		// Token: 0x06036C2C RID: 224300 RVA: 0x00DE4013 File Offset: 0x00DE2213
		private void HandleSubSequenceStop()
		{
			if (!this.IsControlEntitySequenceBridge())
			{
				return;
			}
			this.ClearPlotSubtitle();
			this.SetControlEntityHudVisible(false);
		}

		// Token: 0x06036C2D RID: 224301 RVA: 0x00DE402B File Offset: 0x00DE222B
		private void OnHang(bool isHang = false)
		{
			this.OnHang(isHang, false);
		}

		// Token: 0x06036C2E RID: 224302 RVA: 0x00DE4038 File Offset: 0x00DE2238
		private void OnHang(bool isHang = false, bool bSetActive = true)
		{
			if (this.IsHang == isHang)
			{
				return;
			}
			if (!isHang && base.IsHideOrHiding)
			{
				return;
			}
			this.IsHang = isHang;
			if (isHang)
			{
				if (bSetActive)
				{
					base.SetUiActive(false);
				}
				this.PauseSubtitle();
				this.PauseOptions();
				ControllerBase<FlowController>.Instance.CountDownSkip(true);
				return;
			}
			if (bSetActive)
			{
				base.SetUiActive(true);
			}
			this.ResumeSubtitle();
			this.ResumeOptions();
			ControllerBase<FlowController>.Instance.CountDownSkip(false);
		}

		// Token: 0x06036C2F RID: 224303 RVA: 0x00DE40A8 File Offset: 0x00DE22A8
		protected override void OnAfterPlayStartSequence()
		{
			this.AttachView();
		}

		// Token: 0x06036C30 RID: 224304 RVA: 0x00DE40B0 File Offset: 0x00DE22B0
		protected override void OnAfterShow()
		{
			Singleton<EventSystem>.Instance.Emit<EUiViewName, bool>(EEventName.PlotViewChange, this.ViewInfo.Name, true);
			PlotModel instance = ModelBase<PlotModel>.Instance;
			this.OnHang(instance != null && instance.HangViewHud, false);
			this.SetEnableTranslucent(ModelBase<PlotModel>.Instance.TranslucentHud);
			this.IsControlEntityHudVisible = true;
		}

		// Token: 0x06036C31 RID: 224305 RVA: 0x00DE4108 File Offset: 0x00DE2308
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Emit<EUiViewName, bool>(EEventName.PlotViewChange, this.ViewInfo.Name, false);
			this.OnHang(true, false);
			this.IsControlEntityHudVisible = false;
		}

		// Token: 0x06036C32 RID: 224306 RVA: 0x00DE4138 File Offset: 0x00DE2338
		protected override void OnBeforeDestroy()
		{
			this.EntitySequenceAttachToken++;
			PlotTextCommonLogic commonLogic = this.CommonLogic;
			if (commonLogic != null)
			{
				commonLogic.Clear();
			}
			ControllerBase<FlowController>.Instance.CountDownSkip(false);
			this.ResumeSequenceForControlEntityOption();
			this.IsControlEntityHudVisible = false;
			if (this.EntitySequenceView != null)
			{
				this.EntitySequenceView.CloseAsync().Forget();
				this.EntitySequenceView = null;
			}
		}

		// Token: 0x06036C33 RID: 224307 RVA: 0x00DE419B File Offset: 0x00DE239B
		private bool IsControlEntitySequenceBridge()
		{
			return ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.ControlEntity;
		}

		// Token: 0x06036C34 RID: 224308 RVA: 0x00DE41B4 File Offset: 0x00DE23B4
		private bool CheckHasSubtitleOptions(ITalkItem subtitle)
		{
			if (subtitle.Type.GetValueOrDefault() != ETalkItemType.SystemOption)
			{
				List<ITalkOption> options = subtitle.Options;
				return ((options != null) ? options.Count : 0) > 0;
			}
			return true;
		}

		// Token: 0x06036C35 RID: 224309 RVA: 0x00DE41E9 File Offset: 0x00DE23E9
		private void PauseSequenceForControlEntityOption()
		{
			if (this.PauseByControlEntityOption)
			{
				return;
			}
			this.PauseByControlEntityOption = true;
			ControllerBase<SequenceController>.Instance.PauseSequence("ControlEntityHudOption");
		}

		// Token: 0x06036C36 RID: 224310 RVA: 0x00DE420C File Offset: 0x00DE240C
		private void ResumeSequenceForControlEntityOption()
		{
			if (!this.PauseByControlEntityOption)
			{
				return;
			}
			this.PauseByControlEntityOption = false;
			ControllerBase<SequenceController>.Instance.ResumeSequence("ControlEntityHudOption", null);
		}

		// Token: 0x06036C37 RID: 224311 RVA: 0x00DE4244 File Offset: 0x00DE2444
		private void SetControlEntityHudVisible(bool visible)
		{
			if (!this.IsControlEntitySequenceBridge() || this.IsControlEntityHudVisible == visible)
			{
				return;
			}
			this.IsControlEntityHudVisible = visible;
			base.SetUiActive(visible);
			if (visible)
			{
				UUIText text = base.GetText(2);
				if (text != null)
				{
					text.SetUIActive(false);
				}
				UUIText text2 = base.GetText(0);
				if (text2 != null)
				{
					text2.SetUIActive(false);
				}
				UUIText text3 = base.GetText(1);
				if (text3 != null)
				{
					text3.SetUIActive(false);
				}
				UUIItem item = base.GetItem(3);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
			}
		}

		// Token: 0x06036C38 RID: 224312 RVA: 0x00DE42C0 File Offset: 0x00DE24C0
		private void SetPlotPosition()
		{
			UiParam uiParam = this.OpenParam as UiParam;
			if (uiParam == null || uiParam.Position == null || uiParam.ViewName == null)
			{
				return;
			}
			if (uiParam.ViewName == EUiViewName.BattleView)
			{
				return;
			}
			UUIItem item = base.GetItem(4);
			if (uiParam.Position.GetValueOrDefault() == EPlotLowLevelPosition.Right)
			{
				item.SetUIParent(base.GetItem(6), false);
			}
			else if (uiParam.Position.GetValueOrDefault() == EPlotLowLevelPosition.Center)
			{
				item.SetUIParent(base.GetItem(7), false);
			}
			else
			{
				item.SetUIParent(base.GetItem(5), false);
			}
			item.SetAnchorOffsetX(0f);
		}

		// Token: 0x06036C39 RID: 224313 RVA: 0x00DE438C File Offset: 0x00DE258C
		private void SetTextWidth()
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			UiParam uiParam = this.OpenParam as UiParam;
			if (uiParam == null || uiParam.TextWidth == null)
			{
				return;
			}
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetWidth((float)uiParam.TextWidth.Value);
		}

		// Token: 0x06036C3A RID: 224314 RVA: 0x00DE43E8 File Offset: 0x00DE25E8
		private void AttachView()
		{
			UiParam uiParam = this.OpenParam as UiParam;
			if (uiParam == null || uiParam.ViewName == null)
			{
				return;
			}
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(uiParam.ViewName.Value);
			if (viewByName == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[PlotViewHud] 父界面已经不在，子界面直接关闭";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("parent", uiParam.ViewName);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.CloseMe(null);
				return;
			}
			viewByName.AddChild(this);
			if (viewByName.IsHideOrHiding)
			{
				base.Hide(null);
			}
		}

		// Token: 0x06036C3B RID: 224315 RVA: 0x00DE4486 File Offset: 0x00DE2686
		private void UpdateUiParam(UiParam param)
		{
			this.OpenParam = param;
			this.AttachView();
			this.SetTextWidth();
			this.SetPlotPosition();
		}

		// Token: 0x06036C3C RID: 224316 RVA: 0x00DE44A1 File Offset: 0x00DE26A1
		private void PauseSubtitle()
		{
			if (ModelBase<PlotModel>.Instance.CurTalkItem == null)
			{
				return;
			}
			this.CommonLogic.PauseSubtitle();
			if (this.DelayTimer != null)
			{
				this.DelayTimer.Pause();
			}
		}

		// Token: 0x06036C3D RID: 224317 RVA: 0x00DE44D0 File Offset: 0x00DE26D0
		private void ResumeSubtitle()
		{
			if (ModelBase<PlotModel>.Instance.CurTalkItem == null)
			{
				return;
			}
			if (!this.IsInSubtitle)
			{
				this.UpdatePlotSubtitle(ModelBase<PlotModel>.Instance.CurTalkItem);
				return;
			}
			this.CommonLogic.ResumeSubtitle(ModelBase<PlotModel>.Instance.CurTalkItem);
			if (this.DelayTimer != null)
			{
				this.DelayTimer.Resume();
			}
		}

		// Token: 0x06036C3E RID: 224318 RVA: 0x00DE452C File Offset: 0x00DE272C
		private void PauseOptions()
		{
			if (!this.IsInOption)
			{
				return;
			}
			this.CommonLogic.MuteTimeLimitedOption = true;
			this.UnbindInput();
		}

		// Token: 0x06036C3F RID: 224319 RVA: 0x00DE4549 File Offset: 0x00DE2749
		private void ResumeOptions()
		{
			if (!ModelBase<PlotModel>.Instance.InOptions)
			{
				return;
			}
			if (!this.IsInOption)
			{
				this.ShowOptions();
				return;
			}
			this.CommonLogic.MuteTimeLimitedOption = false;
			this.BindInput();
		}

		// Token: 0x06036C40 RID: 224320 RVA: 0x00DE457C File Offset: 0x00DE277C
		private void BindInput()
		{
			if (ModelBase<PlotModel>.Instance.TimeLimitedOptionTag)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.TimeLimitedOptionTag = true;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData != null)
			{
				childViewData.HideBattleView(EBattleUiVisibleReason.Plot, new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
				{
					EBattleUiChild.Joystick,
					EBattleUiChild.ScreenEffect
				}), 0);
			}
			this.HandleActionBinding(true);
		}

		// Token: 0x06036C41 RID: 224321 RVA: 0x00DE45E0 File Offset: 0x00DE27E0
		private void UnbindInput()
		{
			if (!ModelBase<PlotModel>.Instance.TimeLimitedOptionTag)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.TimeLimitedOptionTag = false;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData != null)
			{
				childViewData.ShowBattleView(EBattleUiVisibleReason.Plot, 0);
			}
			this.HandleActionBinding(false);
		}

		// Token: 0x06036C42 RID: 224322 RVA: 0x00DE4630 File Offset: 0x00DE2830
		private void HandleActionBinding(bool bBind)
		{
			if (!bBind)
			{
				if (this.HasBindActionGamepad)
				{
					this.HasBindActionGamepad = false;
					ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit("D级限时选项-1", new TInputHandle<InputDistributeDefine.EActionType>(this.SelectedOne));
					ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit("D级限时选项-2", new TInputHandle<InputDistributeDefine.EActionType>(this.SelectedTwo));
				}
				if (this.HasBindActionOther)
				{
					this.HasBindActionOther = false;
					ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit("切换角色1", new TInputHandle<InputDistributeDefine.EActionType>(this.SelectedOne));
					ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit("切换角色2", new TInputHandle<InputDistributeDefine.EActionType>(this.SelectedTwo));
				}
				return;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				if (this.HasBindActionGamepad)
				{
					return;
				}
				ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit("D级限时选项-1", new TInputHandle<InputDistributeDefine.EActionType>(this.SelectedOne));
				ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit("D级限时选项-2", new TInputHandle<InputDistributeDefine.EActionType>(this.SelectedTwo));
				this.HasBindActionGamepad = true;
				return;
			}
			else
			{
				if (this.HasBindActionOther)
				{
					return;
				}
				ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit("切换角色1", new TInputHandle<InputDistributeDefine.EActionType>(this.SelectedOne));
				ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit("切换角色2", new TInputHandle<InputDistributeDefine.EActionType>(this.SelectedTwo));
				this.HasBindActionOther = true;
				return;
			}
		}

		// Token: 0x06036C43 RID: 224323 RVA: 0x00DE4767 File Offset: 0x00DE2967
		private void SelectedOne(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			this.SelectedOption(0);
		}

		// Token: 0x06036C44 RID: 224324 RVA: 0x00DE4770 File Offset: 0x00DE2970
		private void SelectedTwo(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			this.SelectedOption(1);
		}

		// Token: 0x06036C45 RID: 224325 RVA: 0x00DE477C File Offset: 0x00DE297C
		private void SelectedOption(int index)
		{
			if (this.CommonLogic.Options == null)
			{
				return;
			}
			this.CommonLogic.Options.First((PlotOptionItem item) => item.OptionIndex == index).OptionClick(new bool?(true));
		}

		// Token: 0x06036C46 RID: 224326 RVA: 0x00DE47CB File Offset: 0x00DE29CB
		public void SetEnableTranslucent(bool enable)
		{
			if (enable)
			{
				UUIItem rootItem = base.GetRootItem();
				if (rootItem == null)
				{
					return;
				}
				rootItem.SetAlpha(0.6f);
				return;
			}
			else
			{
				UUIItem rootItem2 = base.GetRootItem();
				if (rootItem2 == null)
				{
					return;
				}
				rootItem2.SetAlpha(1f);
				return;
			}
		}

		// Token: 0x06036C47 RID: 224327 RVA: 0x00DE47FB File Offset: 0x00DE29FB
		protected override void OnTick(float delta)
		{
			this.CommonLogic.OnTick(delta);
		}

		// Token: 0x0401F8B0 RID: 129200
		private const float TRANSLUCENT_ALPHA = 0.6f;

		// Token: 0x0401F8B1 RID: 129201
		private const string CONTROL_ENTITY_OPTION_PAUSE = "ControlEntityHudOption";

		// Token: 0x0401F8B2 RID: 129202
		private PlotTextCommonLogic CommonLogic;

		// Token: 0x0401F8B3 RID: 129203
		[Nullable(2)]
		private TimerHandle DelayTimer;

		// Token: 0x0401F8B4 RID: 129204
		private bool IsInSubtitle;

		// Token: 0x0401F8B5 RID: 129205
		private bool IsInOption;

		// Token: 0x0401F8B6 RID: 129206
		private bool IsHang;

		// Token: 0x0401F8B7 RID: 129207
		private bool HasBindActionGamepad;

		// Token: 0x0401F8B8 RID: 129208
		private bool HasBindActionOther;

		// Token: 0x0401F8B9 RID: 129209
		private bool PauseByControlEntityOption;

		// Token: 0x0401F8BA RID: 129210
		private int CurrentSequenceSubtitleId = -1;

		// Token: 0x0401F8BB RID: 129211
		private bool IsControlEntityHudVisible = true;

		// Token: 0x0401F8BC RID: 129212
		[Nullable(2)]
		private EntitySequenceView EntitySequenceView;

		// Token: 0x0401F8BD RID: 129213
		private int EntitySequenceAttachToken;

		// Token: 0x0200B361 RID: 45921
		[NullableContext(0)]
		private enum ECompDefine
		{
			// Token: 0x04037926 RID: 227622
			NpcName,
			// Token: 0x04037927 RID: 227623
			NpcTitle,
			// Token: 0x04037928 RID: 227624
			Content,
			// Token: 0x04037929 RID: 227625
			LineItem,
			// Token: 0x0403792A RID: 227626
			PlotItem,
			// Token: 0x0403792B RID: 227627
			LeftPoint,
			// Token: 0x0403792C RID: 227628
			RightPoint,
			// Token: 0x0403792D RID: 227629
			CenterPoint,
			// Token: 0x0403792E RID: 227630
			TextScrollView,
			// Token: 0x0403792F RID: 227631
			OptionPanel,
			// Token: 0x04037930 RID: 227632
			OptionLayout,
			// Token: 0x04037931 RID: 227633
			OptionItem,
			// Token: 0x04037932 RID: 227634
			OptionLimitBar
		}
	}
}
