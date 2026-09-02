using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FeiXue
{
	// Token: 0x0200684B RID: 26699
	[NullableContext(2)]
	[Nullable(0)]
	public class FeiXuePreheatMainView : UiViewBase
	{
		// Token: 0x060428A3 RID: 272547 RVA: 0x011143A0 File Offset: 0x011125A0
		[NullableContext(1)]
		public FeiXuePreheatMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060428A4 RID: 272548 RVA: 0x01114430 File Offset: 0x01112630
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUISprite)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUISprite)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUISprite)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUISprite)),
				new ValueTuple<int, Type>(20, typeof(UUIItem)),
				new ValueTuple<int, Type>(21, typeof(UUIItem)),
				new ValueTuple<int, Type>(22, typeof(UUITexture)),
				new ValueTuple<int, Type>(23, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(24, typeof(UUIItem)),
				new ValueTuple<int, Type>(25, typeof(UUIText)),
				new ValueTuple<int, Type>(26, typeof(UUIItem)),
				new ValueTuple<int, Type>(27, typeof(UUIItem)),
				new ValueTuple<int, Type>(28, typeof(UUIItem)),
				new ValueTuple<int, Type>(29, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(30, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(23, new Action(this.OnClickRewardButton)),
				new ValueTuple<int, Delegate>(29, new Action(this.OnClickCheckDetailButton))
			};
		}

		// Token: 0x060428A5 RID: 272549 RVA: 0x01114745 File Offset: 0x01112945
		protected override void OnBeforeShow()
		{
			this.UiViewSequence.HideSequenceName = "HideView_01";
		}

		// Token: 0x060428A6 RID: 272550 RVA: 0x01114758 File Offset: 0x01112958
		protected override UniTask OnBeforeStartAsync()
		{
			FeiXuePreheatMainView.<OnBeforeStartAsync>d__26 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FeiXuePreheatMainView.<OnBeforeStartAsync>d__26>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060428A7 RID: 272551 RVA: 0x0111479C File Offset: 0x0111299C
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseButtonClicked));
			this.CaptionItem.SetHelpBtnActive(true);
			this.CaptionItem.SetHelpCallBack(new Action(this.OnBtnHelpBtn));
			this.ActivityData = (this.OpenParam as ActivityFeiXuePreheatData);
			if (this.ActivityData == null)
			{
				return;
			}
			this.RefreshTaskItemView();
			this.RefreshCompleteShow();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x060428A8 RID: 272552 RVA: 0x01114848 File Offset: 0x01112A48
		protected override void OnAfterPlayStartSequence()
		{
			this.PlayQuestSequence();
		}

		// Token: 0x060428A9 RID: 272553 RVA: 0x01114854 File Offset: 0x01112A54
		private UniTask PlayQuestSequence()
		{
			FeiXuePreheatMainView.<PlayQuestSequence>d__29 <PlayQuestSequence>d__;
			<PlayQuestSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayQuestSequence>d__.<>4__this = this;
			<PlayQuestSequence>d__.<>1__state = -1;
			<PlayQuestSequence>d__.<>t__builder.Start<FeiXuePreheatMainView.<PlayQuestSequence>d__29>(ref <PlayQuestSequence>d__);
			return <PlayQuestSequence>d__.<>t__builder.Task;
		}

		// Token: 0x060428AA RID: 272554 RVA: 0x01114897 File Offset: 0x01112A97
		[NullableContext(1)]
		private void OnPlaySequenceEvent(string sequenceName, string eventName)
		{
		}

		// Token: 0x060428AB RID: 272555 RVA: 0x0111489C File Offset: 0x01112A9C
		private UniTask PlayAllDoneAnimation()
		{
			FeiXuePreheatMainView.<PlayAllDoneAnimation>d__31 <PlayAllDoneAnimation>d__;
			<PlayAllDoneAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAllDoneAnimation>d__.<>4__this = this;
			<PlayAllDoneAnimation>d__.<>1__state = -1;
			<PlayAllDoneAnimation>d__.<>t__builder.Start<FeiXuePreheatMainView.<PlayAllDoneAnimation>d__31>(ref <PlayAllDoneAnimation>d__);
			return <PlayAllDoneAnimation>d__.<>t__builder.Task;
		}

		// Token: 0x060428AC RID: 272556 RVA: 0x011148DF File Offset: 0x01112ADF
		[NullableContext(1)]
		private string GetSequenceTypeByIndex(int index)
		{
			if (index >= this.SequenceTypeMapping.Count)
			{
				return "Done_1";
			}
			return this.SequenceTypeMapping[index];
		}

		// Token: 0x060428AD RID: 272557 RVA: 0x01114904 File Offset: 0x01112B04
		private UniTask PlayDoneAnimationByIndex(int index)
		{
			FeiXuePreheatMainView.<PlayDoneAnimationByIndex>d__33 <PlayDoneAnimationByIndex>d__;
			<PlayDoneAnimationByIndex>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayDoneAnimationByIndex>d__.<>4__this = this;
			<PlayDoneAnimationByIndex>d__.index = index;
			<PlayDoneAnimationByIndex>d__.<>1__state = -1;
			<PlayDoneAnimationByIndex>d__.<>t__builder.Start<FeiXuePreheatMainView.<PlayDoneAnimationByIndex>d__33>(ref <PlayDoneAnimationByIndex>d__);
			return <PlayDoneAnimationByIndex>d__.<>t__builder.Task;
		}

		// Token: 0x060428AE RID: 272558 RVA: 0x01114950 File Offset: 0x01112B50
		private UniTask PlaySearchInAnimationByIndex(int index)
		{
			FeiXuePreheatMainView.<PlaySearchInAnimationByIndex>d__34 <PlaySearchInAnimationByIndex>d__;
			<PlaySearchInAnimationByIndex>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySearchInAnimationByIndex>d__.<>4__this = this;
			<PlaySearchInAnimationByIndex>d__.index = index;
			<PlaySearchInAnimationByIndex>d__.<>1__state = -1;
			<PlaySearchInAnimationByIndex>d__.<>t__builder.Start<FeiXuePreheatMainView.<PlaySearchInAnimationByIndex>d__34>(ref <PlaySearchInAnimationByIndex>d__);
			return <PlaySearchInAnimationByIndex>d__.<>t__builder.Task;
		}

		// Token: 0x060428AF RID: 272559 RVA: 0x0111499C File Offset: 0x01112B9C
		private UniTask PlaySearchingLoopAnimationByIndex(int index)
		{
			FeiXuePreheatMainView.<PlaySearchingLoopAnimationByIndex>d__35 <PlaySearchingLoopAnimationByIndex>d__;
			<PlaySearchingLoopAnimationByIndex>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySearchingLoopAnimationByIndex>d__.<>4__this = this;
			<PlaySearchingLoopAnimationByIndex>d__.index = index;
			<PlaySearchingLoopAnimationByIndex>d__.<>1__state = -1;
			<PlaySearchingLoopAnimationByIndex>d__.<>t__builder.Start<FeiXuePreheatMainView.<PlaySearchingLoopAnimationByIndex>d__35>(ref <PlaySearchingLoopAnimationByIndex>d__);
			return <PlaySearchingLoopAnimationByIndex>d__.<>t__builder.Task;
		}

		// Token: 0x060428B0 RID: 272560 RVA: 0x011149E7 File Offset: 0x01112BE7
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x060428B1 RID: 272561 RVA: 0x01114A05 File Offset: 0x01112C05
		private void OnRefreshCommonActivityRedDot(int id)
		{
			if (this.ActivityData == null)
			{
				return;
			}
			if (id != this.ActivityData.Id)
			{
				return;
			}
			this.RefreshTaskItemView();
			this.RefreshCompleteShow();
		}

		// Token: 0x060428B2 RID: 272562 RVA: 0x01114A2C File Offset: 0x01112C2C
		private void RefreshTaskItemView()
		{
			List<FeiXuePreheatTaskData> taskDataList = this.ActivityData.GetTaskDataList();
			this.RefreshLeftShow(taskDataList);
			this.RefreshMiddleShow(taskDataList);
			this.RefreshRightShow(taskDataList);
		}

		// Token: 0x060428B3 RID: 272563 RVA: 0x01114A5C File Offset: 0x01112C5C
		[NullableContext(1)]
		private void RefreshLeftShow(List<FeiXuePreheatTaskData> dataList)
		{
			if (dataList.Count != this.PanelDayLeftList.Count)
			{
				return;
			}
			int lastFinishedTaskIndex = this.ActivityData.GetLastFinishedTaskIndex();
			bool flag = lastFinishedTaskIndex >= 0 && !this.ActivityData.GetHasPlayFinishAnimation(lastFinishedTaskIndex);
			if (this.ActivityData.IsAllTaskDone() && !flag)
			{
				foreach (FeiXueDayLeftPanel feiXueDayLeftPanel in this.PanelDayLeftList)
				{
					feiXueDayLeftPanel.SetAllFinishState();
				}
				return;
			}
			for (int i = 0; i < dataList.Count; i++)
			{
				FeiXuePreheatTaskData feiXuePreheatTaskData = dataList[i];
				if (i == lastFinishedTaskIndex && !this.ActivityData.GetHasPlayFinishAnimation(lastFinishedTaskIndex))
				{
					this.PanelDayLeftList[i].SetPanelItemActive(false);
				}
				else
				{
					this.PanelDayLeftList[i].SetPanelItemActive(feiXuePreheatTaskData.IsUnclaimed || feiXuePreheatTaskData.IsFinished);
				}
			}
		}

		// Token: 0x060428B4 RID: 272564 RVA: 0x01114B64 File Offset: 0x01112D64
		[NullableContext(1)]
		private void RefreshMiddleShow(List<FeiXuePreheatTaskData> dataList)
		{
			if (dataList.Count != this.PanelDayMiddleList.Count)
			{
				return;
			}
			int lastFinishedTaskIndex = this.ActivityData.GetLastFinishedTaskIndex();
			for (int i = 0; i < dataList.Count; i++)
			{
				FeiXuePreheatTaskData feiXuePreheatTaskData = dataList[i];
				if (i == lastFinishedTaskIndex && !this.ActivityData.GetHasPlayFinishAnimation(lastFinishedTaskIndex))
				{
					this.PanelDayMiddleList[i].SetUIActive(false);
				}
				else
				{
					this.PanelDayMiddleList[i].SetUIActive(feiXuePreheatTaskData.IsUnclaimed || feiXuePreheatTaskData.IsFinished);
				}
			}
		}

		// Token: 0x060428B5 RID: 272565 RVA: 0x01114BF8 File Offset: 0x01112DF8
		[NullableContext(1)]
		private void RefreshRightShow(List<FeiXuePreheatTaskData> dataList)
		{
			if (dataList.Count != this.PanelDayRightList.Count)
			{
				return;
			}
			int lastFinishedTaskIndex = this.ActivityData.GetLastFinishedTaskIndex();
			int firstDoingTaskIndex = this.ActivityData.GetFirstDoingTaskIndex();
			for (int i = 0; i < dataList.Count; i++)
			{
				FeiXuePreheatTaskData feiXuePreheatTaskData = dataList[i];
				EFeiXueQuestState efeiXueQuestState = feiXuePreheatTaskData.IsDoing ? EFeiXueQuestState.IsDoing : ((feiXuePreheatTaskData.IsUnclaimed || feiXuePreheatTaskData.IsFinished) ? EFeiXueQuestState.Finish : EFeiXueQuestState.Lock);
				if (i == lastFinishedTaskIndex && !this.ActivityData.GetHasPlayFinishAnimation(lastFinishedTaskIndex))
				{
					efeiXueQuestState--;
				}
				else if (i == firstDoingTaskIndex && !this.ActivityData.GetHasPlaySearchInAnimation(firstDoingTaskIndex))
				{
					efeiXueQuestState--;
				}
				this.PanelDayRightList[i].SetPanelItemActive(efeiXueQuestState);
			}
		}

		// Token: 0x060428B6 RID: 272566 RVA: 0x01114CB0 File Offset: 0x01112EB0
		private void RefreshCompleteShow()
		{
			bool flag = this.ActivityData.IsAllTaskDone();
			base.GetItem(24).SetUIActive(this.ActivityData.IsExistClaimableTask());
			UUIText text = base.GetText(25);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActivityData.GetFinishedTaskNum());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActivityData.GetTotalTaskNum());
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			bool flag2 = flag && this.ActivityData.GetHasPlayAllDoneAnimation();
			if (flag2)
			{
				base.GetItem(26).SetUIActive(false);
			}
			else
			{
				base.GetItem(26).SetUIActive(true);
				FeiXuePreheatTaskData feiXuePreheatTaskData = flag ? this.ActivityData.GetLastTaskData() : this.ActivityData.GetBtnGoShowTaskData();
				if (feiXuePreheatTaskData != null)
				{
					this.BtnGo.RefreshBtnView(feiXuePreheatTaskData, this.ActivityData);
				}
			}
			FeiXueCheckDetailItem feiXueCheckDetailItem = this.FeiXueCheckDetailItem;
			if (feiXueCheckDetailItem != null)
			{
				feiXueCheckDetailItem.SetUiActive(flag2);
			}
			base.GetItem(30).SetUIActive(!flag2);
			base.GetItem(27).SetUIActive(flag2);
			base.GetItem(28).SetUIActive(!flag2);
		}

		// Token: 0x060428B7 RID: 272567 RVA: 0x01114DD5 File Offset: 0x01112FD5
		private void OnClickRewardButton()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FeiXuePreheatRewardView, this.ActivityData, null);
		}

		// Token: 0x060428B8 RID: 272568 RVA: 0x01114DED File Offset: 0x01112FED
		private void OnCloseButtonClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x060428B9 RID: 272569 RVA: 0x01114DF8 File Offset: 0x01112FF8
		private void OnBtnHelpBtn()
		{
			int helpId = this.ActivityData.GetHelpId();
			ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
		}

		// Token: 0x060428BA RID: 272570 RVA: 0x01114E1C File Offset: 0x0111301C
		private void OnClickCheckDetailButton()
		{
			this.UiViewSequence.HideSequenceName = "HideView_02";
			ControllerBase<InfoDisplayController>.Instance.OpenInfoDisplay(71600010, null, null, false, null);
		}

		// Token: 0x040250B7 RID: 151735
		private PopupCaptionItem CaptionItem;

		// Token: 0x040250B8 RID: 151736
		private FeiXueGoBtnItem BtnGo;

		// Token: 0x040250B9 RID: 151737
		private FeiXueCheckDetailItem FeiXueCheckDetailItem;

		// Token: 0x040250BA RID: 151738
		private FeiXueDayLeftPanel PanelDay1L;

		// Token: 0x040250BB RID: 151739
		private FeiXueDayLeftPanel PanelDay2L;

		// Token: 0x040250BC RID: 151740
		private FeiXueDayLeftPanel PanelDay3L;

		// Token: 0x040250BD RID: 151741
		private FeiXueDayLeftPanel PanelDay4L;

		// Token: 0x040250BE RID: 151742
		private FeiXueDayLeftPanel PanelDay5L;

		// Token: 0x040250BF RID: 151743
		private FeiXueDayLeftPanel PanelDay6L;

		// Token: 0x040250C0 RID: 151744
		private FeiXueDayLeftPanel PanelDay7L;

		// Token: 0x040250C1 RID: 151745
		private FeiXueDayRightPanel PanelDay1R;

		// Token: 0x040250C2 RID: 151746
		private FeiXueDayRightPanel PanelDay2R;

		// Token: 0x040250C3 RID: 151747
		private FeiXueDayRightPanel PanelDay3R;

		// Token: 0x040250C4 RID: 151748
		private FeiXueDayRightPanel PanelDay4R;

		// Token: 0x040250C5 RID: 151749
		private FeiXueDayRightPanel PanelDay5R;

		// Token: 0x040250C6 RID: 151750
		private FeiXueDayRightPanel PanelDay6R;

		// Token: 0x040250C7 RID: 151751
		private FeiXueDayRightPanel PanelDay7R;

		// Token: 0x040250C8 RID: 151752
		[Nullable(1)]
		private List<FeiXueDayLeftPanel> PanelDayLeftList = new List<FeiXueDayLeftPanel>();

		// Token: 0x040250C9 RID: 151753
		[Nullable(1)]
		private List<UUISprite> PanelDayMiddleList = new List<UUISprite>();

		// Token: 0x040250CA RID: 151754
		[Nullable(1)]
		private List<FeiXueDayRightPanel> PanelDayRightList = new List<FeiXueDayRightPanel>();

		// Token: 0x040250CB RID: 151755
		private ActivityFeiXuePreheatData ActivityData;

		// Token: 0x040250CC RID: 151756
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040250CD RID: 151757
		[Nullable(1)]
		private readonly List<string> SequenceTypeMapping = new List<string>
		{
			"Done_1",
			"Done_2",
			"Done_3",
			"Done_4",
			"Done_5",
			"Done_6",
			"Done_7"
		};
	}
}
