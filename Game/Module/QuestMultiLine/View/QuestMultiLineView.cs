using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.Module.QuestMultiLine.View.Items;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View
{
	// Token: 0x02005327 RID: 21287
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMultiLineView : UiTickViewBase
	{
		// Token: 0x0603650C RID: 222476 RVA: 0x00DB083A File Offset: 0x00DAEA3A
		public QuestMultiLineView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x17008D2C RID: 36140
		// (get) Token: 0x0603650D RID: 222477 RVA: 0x00DB0859 File Offset: 0x00DAEA59
		[Nullable(2)]
		public new QuestMultiLineViewParams OpenParam
		{
			[NullableContext(2)]
			get
			{
				return this.OpenParam as QuestMultiLineViewParams;
			}
		}

		// Token: 0x0603650E RID: 222478 RVA: 0x00DB0868 File Offset: 0x00DAEA68
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
		}

		// Token: 0x0603650F RID: 222479 RVA: 0x00DB0930 File Offset: 0x00DAEB30
		protected override UniTask OnBeforeStartAsync()
		{
			QuestMultiLineView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<QuestMultiLineView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036510 RID: 222480 RVA: 0x00DB0974 File Offset: 0x00DAEB74
		private UniTask PrepareViewAsync()
		{
			QuestMultiLineView.<PrepareViewAsync>d__19 <PrepareViewAsync>d__;
			<PrepareViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PrepareViewAsync>d__.<>4__this = this;
			<PrepareViewAsync>d__.<>1__state = -1;
			<PrepareViewAsync>d__.<>t__builder.Start<QuestMultiLineView.<PrepareViewAsync>d__19>(ref <PrepareViewAsync>d__);
			return <PrepareViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036511 RID: 222481 RVA: 0x00DB09B8 File Offset: 0x00DAEBB8
		private UniTask PrepareNormalTimePointView(QuestMultiLineTimePointData curShowTimePoint)
		{
			QuestMultiLineView.<PrepareNormalTimePointView>d__20 <PrepareNormalTimePointView>d__;
			<PrepareNormalTimePointView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PrepareNormalTimePointView>d__.<>4__this = this;
			<PrepareNormalTimePointView>d__.curShowTimePoint = curShowTimePoint;
			<PrepareNormalTimePointView>d__.<>1__state = -1;
			<PrepareNormalTimePointView>d__.<>t__builder.Start<QuestMultiLineView.<PrepareNormalTimePointView>d__20>(ref <PrepareNormalTimePointView>d__);
			return <PrepareNormalTimePointView>d__.<>t__builder.Task;
		}

		// Token: 0x06036512 RID: 222482 RVA: 0x00DB0A04 File Offset: 0x00DAEC04
		private void PlayEnterAnimations()
		{
			QuestMultiLineTimePointData firstShowTimePoint = this.FirstShowTimePoint;
			this.FirstShowTimePoint = null;
			if (firstShowTimePoint == null || QuestMultiLineUtils.IsBranchSelectTimePoint(firstShowTimePoint))
			{
				return;
			}
			if (this.PlayTimePointComponentAnim)
			{
				this.PlayStartSequencerAsync(firstShowTimePoint);
				return;
			}
			base.PlaySequenceAsync("TimeLine_In", false, false, null);
			this.MapPanel.PlayAllComponentsAppearStart();
			Dictionary<int, bool> fightAreas = ((firstShowTimePoint != null) ? firstShowTimePoint.FightingAreaMap : null) ?? new Dictionary<int, bool>();
			this.RefreshAreaStatus(fightAreas);
			if (this.HasActiveFightArea(fightAreas))
			{
				this.PlayFightLightAsync();
			}
			string title = firstShowTimePoint.Title;
			string desc = firstShowTimePoint.Desc;
			if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(desc))
			{
				base.PlaySequenceAsync("Tips_In", false, false, null);
			}
		}

		// Token: 0x06036513 RID: 222483 RVA: 0x00DB0AC0 File Offset: 0x00DAECC0
		private UniTask PlayStartSequencerAsync(QuestMultiLineTimePointData curShowTimePoint)
		{
			QuestMultiLineView.<PlayStartSequencerAsync>d__22 <PlayStartSequencerAsync>d__;
			<PlayStartSequencerAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartSequencerAsync>d__.<>4__this = this;
			<PlayStartSequencerAsync>d__.curShowTimePoint = curShowTimePoint;
			<PlayStartSequencerAsync>d__.<>1__state = -1;
			<PlayStartSequencerAsync>d__.<>t__builder.Start<QuestMultiLineView.<PlayStartSequencerAsync>d__22>(ref <PlayStartSequencerAsync>d__);
			return <PlayStartSequencerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036514 RID: 222484 RVA: 0x00DB0B0B File Offset: 0x00DAED0B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<List<QuestMultiLineTimePointData>>(EEventName.QuestMultiLineTimePointChange, new Action<List<QuestMultiLineTimePointData>>(this.OnTimePointChange));
		}

		// Token: 0x06036515 RID: 222485 RVA: 0x00DB0B2C File Offset: 0x00DAED2C
		protected override void OnRemoveEventListener()
		{
			QuestMultiLineAnimationSequencer sequencer = this.Sequencer;
			if (sequencer != null)
			{
				sequencer.Stop();
			}
			UniTaskCompletionSource startSequenceFinishedResolve = this.StartSequenceFinishedResolve;
			if (startSequenceFinishedResolve != null)
			{
				startSequenceFinishedResolve.TrySetResult();
			}
			this.StartSequenceFinishedResolve = null;
			Singleton<EventSystem>.Instance.Remove(EEventName.QuestMultiLineTimePointChange, new Action<List<QuestMultiLineTimePointData>>(this.OnTimePointChange));
		}

		// Token: 0x06036516 RID: 222486 RVA: 0x00DB0B7F File Offset: 0x00DAED7F
		protected override void OnAfterPlayStartSequence()
		{
			base.OnAfterPlayStartSequence();
			UniTaskCompletionSource startSequenceFinishedResolve = this.StartSequenceFinishedResolve;
			if (startSequenceFinishedResolve != null)
			{
				startSequenceFinishedResolve.TrySetResult();
			}
			this.StartSequenceFinishedResolve = null;
			if (this.EarlyPrepare)
			{
				this.PlayEnterAnimations();
			}
		}

		// Token: 0x06036517 RID: 222487 RVA: 0x00DB0BB0 File Offset: 0x00DAEDB0
		protected override void OnStart()
		{
			PopupCaptionItem popupCaptionItem = new PopupCaptionItem(base.GetItem(1));
			popupCaptionItem.SetCloseCallBack(new Action(this.OnCloseBtnClick));
			popupCaptionItem.SetHelpCallBack(new Action(this.OnHelpBtnClick));
			popupCaptionItem.CreateHomeBtn(EUiViewName.QuestMultiLineView, null, true);
			QuestMultiLineTimeLinePanel timeLinePanel = this.TimeLinePanel;
			if (timeLinePanel != null)
			{
				timeLinePanel.SetTimePointFunction(new Action<QuestMultiLineTimePointData>(this.OnClickTimePoint));
			}
			QuestMultiLineTipsPanel tipsPanel = this.TipsPanel;
			if (tipsPanel != null)
			{
				tipsPanel.SetUiActive(false);
			}
			QuestMultiLineTipsPanel tipsPanel2 = this.TipsPanel;
			if (tipsPanel2 != null)
			{
				tipsPanel2.SetHideCallback(new Action(this.OnTipsHide));
			}
			QuestMultiLineTipsPanel tipsPanel3 = this.TipsPanel;
			if (tipsPanel3 != null)
			{
				tipsPanel3.SetHideSelfBtnInterceptor(new Func<bool>(this.OnTipsHideSelfBtnIntercept));
			}
			if (!this.EarlyPrepare)
			{
				this.RefreshView();
			}
		}

		// Token: 0x06036518 RID: 222488 RVA: 0x00DB0C71 File Offset: 0x00DAEE71
		protected override void OnAfterShow()
		{
			QuestMultiLineMapPanel mapPanel = this.MapPanel;
			if (mapPanel == null)
			{
				return;
			}
			mapPanel.MapShow();
		}

		// Token: 0x06036519 RID: 222489 RVA: 0x00DB0C83 File Offset: 0x00DAEE83
		protected override void OnBeforeHide()
		{
			QuestMultiLineMapPanel mapPanel = this.MapPanel;
			if (mapPanel == null)
			{
				return;
			}
			mapPanel.MapHide();
		}

		// Token: 0x0603651A RID: 222490 RVA: 0x00DB0C95 File Offset: 0x00DAEE95
		protected override void OnTick(float delta)
		{
			QuestMultiLineMapPanel mapPanel = this.MapPanel;
			if (mapPanel == null)
			{
				return;
			}
			mapPanel.OnTick(delta);
		}

		// Token: 0x0603651B RID: 222491 RVA: 0x00DB0CA8 File Offset: 0x00DAEEA8
		private UniTask RefreshView()
		{
			QuestMultiLineView.<RefreshView>d__30 <RefreshView>d__;
			<RefreshView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshView>d__.<>4__this = this;
			<RefreshView>d__.<>1__state = -1;
			<RefreshView>d__.<>t__builder.Start<QuestMultiLineView.<RefreshView>d__30>(ref <RefreshView>d__);
			return <RefreshView>d__.<>t__builder.Task;
		}

		// Token: 0x0603651C RID: 222492 RVA: 0x00DB0CEC File Offset: 0x00DAEEEC
		[NullableContext(2)]
		private QuestMultiLineTimePointData ResolveCurrentTimePoint()
		{
			QuestMultiLineTimePointData curShowTimePoint = this.GetCurShowTimePoint();
			if (curShowTimePoint != null)
			{
				return curShowTimePoint;
			}
			Singleton<Log>.Instance.Error(ELogModule.QuestMultiLine, ELogAuthor.CCJ, "没有解锁的时间点", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (this.TimePoints == null || this.TimePoints.Count <= 0)
			{
				return null;
			}
			return this.TimePoints[0];
		}

		// Token: 0x0603651D RID: 222493 RVA: 0x00DB0D48 File Offset: 0x00DAEF48
		private void RefreshBranchSelectView(QuestMultiLineTimePointData curShowTimePoint)
		{
			QuestMultiLineTimeLinePanel timeLinePanel = this.TimeLinePanel;
			if (timeLinePanel != null)
			{
				timeLinePanel.SetUiActive(false);
			}
			QuestMultiLineSelectPanel selectPanel = this.SelectPanel;
			if (selectPanel != null)
			{
				selectPanel.SetUiActive(true);
			}
			this.RefreshSelectPanel(curShowTimePoint);
			this.RefreshComponents(new List<QuestMultiLineComponentData>());
			this.RefreshAreaStatus(new Dictionary<int, bool>());
			this.MapPanel.RefreshFullScreenNiagara(false, curShowTimePoint.ScreenEffect);
		}

		// Token: 0x0603651E RID: 222494 RVA: 0x00DB0DA8 File Offset: 0x00DAEFA8
		private UniTask RefreshNormalTimePointView(QuestMultiLineTimePointData curShowTimePoint)
		{
			QuestMultiLineView.<RefreshNormalTimePointView>d__33 <RefreshNormalTimePointView>d__;
			<RefreshNormalTimePointView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshNormalTimePointView>d__.<>4__this = this;
			<RefreshNormalTimePointView>d__.curShowTimePoint = curShowTimePoint;
			<RefreshNormalTimePointView>d__.<>1__state = -1;
			<RefreshNormalTimePointView>d__.<>t__builder.Start<QuestMultiLineView.<RefreshNormalTimePointView>d__33>(ref <RefreshNormalTimePointView>d__);
			return <RefreshNormalTimePointView>d__.<>t__builder.Task;
		}

		// Token: 0x0603651F RID: 222495 RVA: 0x00DB0DF4 File Offset: 0x00DAEFF4
		private UniTask RunSequencerAsync(QuestMultiLineTimePointData curShowTimePoint)
		{
			QuestMultiLineView.<RunSequencerAsync>d__34 <RunSequencerAsync>d__;
			<RunSequencerAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunSequencerAsync>d__.<>4__this = this;
			<RunSequencerAsync>d__.curShowTimePoint = curShowTimePoint;
			<RunSequencerAsync>d__.<>1__state = -1;
			<RunSequencerAsync>d__.<>t__builder.Start<QuestMultiLineView.<RunSequencerAsync>d__34>(ref <RunSequencerAsync>d__);
			return <RunSequencerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036520 RID: 222496 RVA: 0x00DB0E40 File Offset: 0x00DAF040
		private void RefreshTaskDescPanel(QuestMultiLineTimePointData curShowTimePoint, bool playAnim = true)
		{
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			if (QuestMultiLineUtils.IsBranchSelectTimePoint(curShowTimePoint))
			{
				item.SetUIActive(false);
				return;
			}
			string title = curShowTimePoint.Title;
			string desc = curShowTimePoint.Desc;
			if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(desc))
			{
				item.SetUIActive(false);
				return;
			}
			item.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), title, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), desc, Array.Empty<object>());
			if (playAnim)
			{
				base.PlaySequenceAsync("Tips_In", false, false, null);
			}
		}

		// Token: 0x06036521 RID: 222497 RVA: 0x00DB0EE0 File Offset: 0x00DAF0E0
		private UniTask RunBranchSelectSequencerAsync(List<QuestMultiLineComponentData> components, List<int> fightAreas)
		{
			QuestMultiLineView.<RunBranchSelectSequencerAsync>d__36 <RunBranchSelectSequencerAsync>d__;
			<RunBranchSelectSequencerAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunBranchSelectSequencerAsync>d__.<>4__this = this;
			<RunBranchSelectSequencerAsync>d__.components = components;
			<RunBranchSelectSequencerAsync>d__.fightAreas = fightAreas;
			<RunBranchSelectSequencerAsync>d__.<>1__state = -1;
			<RunBranchSelectSequencerAsync>d__.<>t__builder.Start<QuestMultiLineView.<RunBranchSelectSequencerAsync>d__36>(ref <RunBranchSelectSequencerAsync>d__);
			return <RunBranchSelectSequencerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036522 RID: 222498 RVA: 0x00DB0F34 File Offset: 0x00DAF134
		private UniTask RefreshMap()
		{
			QuestMultiLineView.<RefreshMap>d__37 <RefreshMap>d__;
			<RefreshMap>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshMap>d__.<>4__this = this;
			<RefreshMap>d__.<>1__state = -1;
			<RefreshMap>d__.<>t__builder.Start<QuestMultiLineView.<RefreshMap>d__37>(ref <RefreshMap>d__);
			return <RefreshMap>d__.<>t__builder.Task;
		}

		// Token: 0x06036523 RID: 222499 RVA: 0x00DB0F78 File Offset: 0x00DAF178
		private UniTask RefreshTimeLine(List<QuestMultiLineTimePointData> timePoints)
		{
			QuestMultiLineView.<RefreshTimeLine>d__38 <RefreshTimeLine>d__;
			<RefreshTimeLine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTimeLine>d__.<>4__this = this;
			<RefreshTimeLine>d__.timePoints = timePoints;
			<RefreshTimeLine>d__.<>1__state = -1;
			<RefreshTimeLine>d__.<>t__builder.Start<QuestMultiLineView.<RefreshTimeLine>d__38>(ref <RefreshTimeLine>d__);
			return <RefreshTimeLine>d__.<>t__builder.Task;
		}

		// Token: 0x06036524 RID: 222500 RVA: 0x00DB0FC3 File Offset: 0x00DAF1C3
		private void RefreshComponents(List<QuestMultiLineComponentData> components)
		{
			this.MapPanel.RefreshComponents(components);
			this.MapPanel.SetComponentFunction(new Action<QuestMultiLineComponentData>(this.OnClickComponent));
		}

		// Token: 0x06036525 RID: 222501 RVA: 0x00DB0FE9 File Offset: 0x00DAF1E9
		private void RefreshAreaStatus(Dictionary<int, bool> fightAreas)
		{
			this.MapPanel.RefreshFightArea(fightAreas);
		}

		// Token: 0x06036526 RID: 222502 RVA: 0x00DB0FF8 File Offset: 0x00DAF1F8
		private bool HasActiveFightArea(Dictionary<int, bool> fightAreas)
		{
			using (Dictionary<int, bool>.ValueCollection.Enumerator enumerator = fightAreas.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06036527 RID: 222503 RVA: 0x00DB104C File Offset: 0x00DAF24C
		private void ShowComponentTips(QuestMultiLineComponentData componentData)
		{
			QuestMultiLineTipsPanel tipsPanel = this.TipsPanel;
			if (tipsPanel != null)
			{
				tipsPanel.RefreshTips(componentData);
			}
			if (this.TipsPanel != null)
			{
				this.TipsPanel.ShowAndPlayStartAsync();
			}
		}

		// Token: 0x06036528 RID: 222504 RVA: 0x00DB1074 File Offset: 0x00DAF274
		private void RefreshSelectPanel(QuestMultiLineTimePointData timePointData)
		{
			this.SelectPanel.RefreshPanel(timePointData);
		}

		// Token: 0x06036529 RID: 222505 RVA: 0x00DB1084 File Offset: 0x00DAF284
		[NullableContext(2)]
		private QuestMultiLineTimePointData GetCurShowTimePoint()
		{
			if (this.TimePoints == null)
			{
				return null;
			}
			foreach (QuestMultiLineTimePointData questMultiLineTimePointData in this.TimePoints)
			{
				if (questMultiLineTimePointData.Id == this.ShowTimePointId)
				{
					return questMultiLineTimePointData;
				}
			}
			for (int i = this.TimePoints.Count - 1; i >= 0; i--)
			{
				QuestMultiLineTimePointData questMultiLineTimePointData2 = this.TimePoints[i];
				if (questMultiLineTimePointData2.IsUnLock)
				{
					this.ShowTimePointId = questMultiLineTimePointData2.Id;
					return questMultiLineTimePointData2;
				}
			}
			return null;
		}

		// Token: 0x0603652A RID: 222506 RVA: 0x00DB1130 File Offset: 0x00DAF330
		private void OnHelpBtnClick()
		{
			if (this.Sequencer != null && this.Sequencer.IsPlaying)
			{
				return;
			}
			ControllerBase<HelpController>.Instance.OpenHelpById(617);
		}

		// Token: 0x0603652B RID: 222507 RVA: 0x00DB1157 File Offset: 0x00DAF357
		private void OnCloseBtnClick()
		{
			QuestMultiLineAnimationSequencer sequencer = this.Sequencer;
			if (sequencer != null)
			{
				sequencer.Stop();
			}
			QuestMultiLineMapPanel mapPanel = this.MapPanel;
			if (mapPanel != null)
			{
				mapPanel.StopComponentMoveAlongPath();
			}
			base.CloseMe(null);
		}

		// Token: 0x0603652C RID: 222508 RVA: 0x00DB1184 File Offset: 0x00DAF384
		private void OnClickTimePoint(QuestMultiLineTimePointData timePoint)
		{
			if (this.Sequencer != null && this.Sequencer.IsPlaying)
			{
				return;
			}
			if (timePoint.Id == this.ShowTimePointId)
			{
				return;
			}
			this.PlayTimePointComponentAnim = false;
			this.ShowTimePointId = timePoint.Id;
			this.RefreshMap();
		}

		// Token: 0x0603652D RID: 222509 RVA: 0x00DB11D0 File Offset: 0x00DAF3D0
		private void OnSelectBranch(int branchPageId, int branchId)
		{
			List<QuestMultiLineBranchData> branchData = this.GetCurShowTimePoint().BranchPageData.BranchData;
			QuestMultiLineBranchData questMultiLineBranchData = null;
			foreach (QuestMultiLineBranchData questMultiLineBranchData2 in branchData)
			{
				if (questMultiLineBranchData2.BranchId == branchId)
				{
					questMultiLineBranchData = questMultiLineBranchData2;
					break;
				}
			}
			if (questMultiLineBranchData == null || this.MapPanel == null)
			{
				return;
			}
			base.PlaySequenceAsync((branchId == branchData[0].BranchId) ? "Select_L" : "Select_R", false, false, null);
			List<int> list = new List<int>();
			foreach (int item in questMultiLineBranchData.FightingAreas)
			{
				list.Add(item);
			}
			this.BranchPlayPromise = this.RunBranchSelectSequencerAsync(questMultiLineBranchData.Components, list);
		}

		// Token: 0x0603652E RID: 222510 RVA: 0x00DB12BC File Offset: 0x00DAF4BC
		private UniTask OnEnsureBranch(int branchPageId, int branchId)
		{
			QuestMultiLineView.<OnEnsureBranch>d__49 <OnEnsureBranch>d__;
			<OnEnsureBranch>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnEnsureBranch>d__.<>4__this = this;
			<OnEnsureBranch>d__.branchPageId = branchPageId;
			<OnEnsureBranch>d__.branchId = branchId;
			<OnEnsureBranch>d__.<>1__state = -1;
			<OnEnsureBranch>d__.<>t__builder.Start<QuestMultiLineView.<OnEnsureBranch>d__49>(ref <OnEnsureBranch>d__);
			return <OnEnsureBranch>d__.<>t__builder.Task;
		}

		// Token: 0x0603652F RID: 222511 RVA: 0x00DB1310 File Offset: 0x00DAF510
		[NullableContext(2)]
		private QuestMultiLineComponentData FindBranchMainRole(int branchId)
		{
			QuestMultiLineTimePointData curShowTimePoint = this.GetCurShowTimePoint();
			List<QuestMultiLineBranchData> list;
			if (curShowTimePoint == null)
			{
				list = null;
			}
			else
			{
				QuestMultiLineBranchPageData branchPageData = curShowTimePoint.BranchPageData;
				list = ((branchPageData != null) ? branchPageData.BranchData : null);
			}
			List<QuestMultiLineBranchData> list2 = list;
			if (list2 == null)
			{
				return null;
			}
			foreach (QuestMultiLineBranchData questMultiLineBranchData in list2)
			{
				if (questMultiLineBranchData.BranchId == branchId)
				{
					foreach (QuestMultiLineComponentData questMultiLineComponentData in questMultiLineBranchData.Components)
					{
						if (questMultiLineComponentData.Type == 1)
						{
							return questMultiLineComponentData;
						}
					}
					return null;
				}
			}
			return null;
		}

		// Token: 0x06036530 RID: 222512 RVA: 0x00DB13DC File Offset: 0x00DAF5DC
		private void OnTimePointChange(List<QuestMultiLineTimePointData> timePoints)
		{
			this.TimePoints = timePoints;
			if (this.Sequencer != null && this.Sequencer.IsPlaying)
			{
				return;
			}
			this.RefreshView();
		}

		// Token: 0x06036531 RID: 222513 RVA: 0x00DB1404 File Offset: 0x00DAF604
		private void OnClickComponent(QuestMultiLineComponentData componentData)
		{
			if (this.Sequencer != null && this.Sequencer.IsPlaying)
			{
				return;
			}
			QuestMultiLineTimePointData curShowTimePoint = this.GetCurShowTimePoint();
			if (curShowTimePoint != null && QuestMultiLineUtils.IsBranchSelectTimePoint(curShowTimePoint))
			{
				return;
			}
			this.ShowComponentTips(componentData);
		}

		// Token: 0x06036532 RID: 222514 RVA: 0x00DB1441 File Offset: 0x00DAF641
		private void OnTipsHide()
		{
			QuestMultiLineMapPanel mapPanel = this.MapPanel;
			if (mapPanel == null)
			{
				return;
			}
			mapPanel.ClearAllComponentSelection();
		}

		// Token: 0x06036533 RID: 222515 RVA: 0x00DB1453 File Offset: 0x00DAF653
		private bool OnTipsHideSelfBtnIntercept()
		{
			QuestMultiLineMapPanel mapPanel = this.MapPanel;
			return mapPanel != null && mapPanel.TryClickComponentAtMousePosition();
		}

		// Token: 0x06036534 RID: 222516 RVA: 0x00DB1468 File Offset: 0x00DAF668
		public UniTask PlayFightLightAsync()
		{
			QuestMultiLineView.<PlayFightLightAsync>d__55 <PlayFightLightAsync>d__;
			<PlayFightLightAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayFightLightAsync>d__.<>4__this = this;
			<PlayFightLightAsync>d__.<>1__state = -1;
			<PlayFightLightAsync>d__.<>t__builder.Start<QuestMultiLineView.<PlayFightLightAsync>d__55>(ref <PlayFightLightAsync>d__);
			return <PlayFightLightAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036535 RID: 222517 RVA: 0x00DB14AC File Offset: 0x00DAF6AC
		private UniTask PlayUiOutAsync()
		{
			QuestMultiLineView.<PlayUiOutAsync>d__56 <PlayUiOutAsync>d__;
			<PlayUiOutAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayUiOutAsync>d__.<>4__this = this;
			<PlayUiOutAsync>d__.<>1__state = -1;
			<PlayUiOutAsync>d__.<>t__builder.Start<QuestMultiLineView.<PlayUiOutAsync>d__56>(ref <PlayUiOutAsync>d__);
			return <PlayUiOutAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036536 RID: 222518 RVA: 0x00DB14EF File Offset: 0x00DAF6EF
		public void DebugDrawPath(IReadOnlyList<Vector> points)
		{
		}

		// Token: 0x06036537 RID: 222519 RVA: 0x00DB14F1 File Offset: 0x00DAF6F1
		public void DebugPlayBranchConfirmAnim(int? branchId = null)
		{
		}

		// Token: 0x06036538 RID: 222520 RVA: 0x00DB14F4 File Offset: 0x00DAF6F4
		private UniTask RunDebugBranchConfirmAnim(int? branchId = null)
		{
			QuestMultiLineView.<RunDebugBranchConfirmAnim>d__59 <RunDebugBranchConfirmAnim>d__;
			<RunDebugBranchConfirmAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunDebugBranchConfirmAnim>d__.<>4__this = this;
			<RunDebugBranchConfirmAnim>d__.branchId = branchId;
			<RunDebugBranchConfirmAnim>d__.<>1__state = -1;
			<RunDebugBranchConfirmAnim>d__.<>t__builder.Start<QuestMultiLineView.<RunDebugBranchConfirmAnim>d__59>(ref <RunDebugBranchConfirmAnim>d__);
			return <RunDebugBranchConfirmAnim>d__.<>t__builder.Task;
		}

		// Token: 0x06036539 RID: 222521 RVA: 0x00DB1540 File Offset: 0x00DAF740
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.TZJ, "QuestMultiLineView 引导 ExtraParam 不能为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			if (configParams[0] == "TimePoint")
			{
				if (configParams.Length < 2)
				{
					Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.TZJ, "QuestMultiLineView TimePoint 引导参数缺失", default(ReadOnlySpan<ValueTuple<string, object>>));
					return null;
				}
				int num;
				if (!int.TryParse(configParams[1], out num) || num <= 0)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Guide;
					ELogAuthor author = ELogAuthor.TZJ;
					string message = "QuestMultiLineView TimePoint 引导参数非法";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("param", configParams[1]);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return null;
				}
				QuestMultiLineTimeLinePanel timeLinePanel = this.TimeLinePanel;
				UUIItem uuiitem = (timeLinePanel != null) ? timeLinePanel.GetGuideTimePointUiItem(num - 1) : null;
				if (uuiitem == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem,
					uuiitem
				};
			}
			else
			{
				if (!(configParams[0] == "Component"))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Guide;
					ELogAuthor author2 = ELogAuthor.TZJ;
					string message2 = "QuestMultiLineView 引导 ExtraParam 类型未知";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("key", configParams[0]);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return null;
				}
				if (configParams.Length < 2)
				{
					Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.TZJ, "QuestMultiLineView Component 引导参数缺失", default(ReadOnlySpan<ValueTuple<string, object>>));
					return null;
				}
				int num2;
				if (!int.TryParse(configParams[1], out num2) || num2 <= 0)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Guide;
					ELogAuthor author3 = ELogAuthor.TZJ;
					string message3 = "QuestMultiLineView Component 引导参数非法";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("param", configParams[1]);
					instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					return null;
				}
				QuestMultiLineMapPanel mapPanel = this.MapPanel;
				UUIItem uuiitem2 = (mapPanel != null) ? mapPanel.GetGuideComponentUiItem(num2) : null;
				if (uuiitem2 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem2,
					uuiitem2
				};
			}
		}

		// Token: 0x0401F3AE RID: 127918
		private const int EARLY_PREPARE_TIME_POINT_ID = 2;

		// Token: 0x0401F3AF RID: 127919
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<QuestMultiLineTimePointData> TimePoints;

		// Token: 0x0401F3B0 RID: 127920
		private int ShowTimePointId;

		// Token: 0x0401F3B1 RID: 127921
		private bool PlayTimePointComponentAnim;

		// Token: 0x0401F3B2 RID: 127922
		[Nullable(2)]
		private QuestMultiLineMapPanel MapPanel;

		// Token: 0x0401F3B3 RID: 127923
		[Nullable(2)]
		private QuestMultiLineTimeLinePanel TimeLinePanel;

		// Token: 0x0401F3B4 RID: 127924
		[Nullable(2)]
		private QuestMultiLineSelectPanel SelectPanel;

		// Token: 0x0401F3B5 RID: 127925
		[Nullable(2)]
		private QuestMultiLineTipsPanel TipsPanel;

		// Token: 0x0401F3B6 RID: 127926
		[Nullable(2)]
		private QuestMultiLineAnimationSequencer Sequencer;

		// Token: 0x0401F3B7 RID: 127927
		private UniTask BranchPlayPromise = UniTask.CompletedTask;

		// Token: 0x0401F3B8 RID: 127928
		private UniTask StartSequenceFinishedTask = UniTask.CompletedTask;

		// Token: 0x0401F3B9 RID: 127929
		[Nullable(2)]
		private UniTaskCompletionSource StartSequenceFinishedResolve;

		// Token: 0x0401F3BA RID: 127930
		private bool EarlyPrepare;

		// Token: 0x0401F3BB RID: 127931
		[Nullable(2)]
		private QuestMultiLineTimePointData FirstShowTimePoint;
	}
}
