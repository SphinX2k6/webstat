using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FeedbackReward
{
	// Token: 0x02005D87 RID: 23943
	[NullableContext(1)]
	[Nullable(0)]
	public class FeedbackRewardMainView : UiViewBase
	{
		// Token: 0x0603C49E RID: 246942 RVA: 0x00F4C585 File Offset: 0x00F4A785
		public FeedbackRewardMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C49F RID: 246943 RVA: 0x00F4C5B0 File Offset: 0x00F4A7B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickLeftBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickRightBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickDetailBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C4A0 RID: 246944 RVA: 0x00F4C894 File Offset: 0x00F4AA94
		protected override UniTask OnBeforeStartAsync()
		{
			FeedbackRewardMainView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FeedbackRewardMainView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C4A1 RID: 246945 RVA: 0x00F4C8D7 File Offset: 0x00F4AAD7
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FeedbackRewardRefresh, new Action(this.FeedbackRewardRefresh));
		}

		// Token: 0x0603C4A2 RID: 246946 RVA: 0x00F4C8F5 File Offset: 0x00F4AAF5
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FeedbackRewardRefresh, new Action(this.FeedbackRewardRefresh));
		}

		// Token: 0x0603C4A3 RID: 246947 RVA: 0x00F4C914 File Offset: 0x00F4AB14
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(delegate
			{
				base.CloseMe(null);
			});
			this.RewardScrollView = new GenericScrollViewNew<RewardItem, int>(base.GetScrollViewWithScrollbar(15), new Func<RewardItem>(this.InitRewardItem), null, false, null);
			this.TaskLayout = new GenericLayout<TaskItem, int>(base.GetVerticalLayout(12), new Func<TaskItem>(this.InitTaskItem), null, false, true);
			foreach (int num in this.ShowRewardList)
			{
				if (ModelBase<FeedbackRewardModel>.Instance.GetFeedbackRewardState(num) != EFeedbackRewardState.Claimed)
				{
					this.CurrentShowRewardIndex = this.ShowRewardList.IndexOf(num);
					break;
				}
			}
			this.RefreshRewardPanel();
			this.RefreshRewardLayout();
			this.RefreshTaskPanel();
		}

		// Token: 0x0603C4A4 RID: 246948 RVA: 0x00F4CA04 File Offset: 0x00F4AC04
		private RewardItem InitRewardItem()
		{
			return new RewardItem();
		}

		// Token: 0x0603C4A5 RID: 246949 RVA: 0x00F4CA0B File Offset: 0x00F4AC0B
		private TaskItem InitTaskItem()
		{
			return new TaskItem();
		}

		// Token: 0x0603C4A6 RID: 246950 RVA: 0x00F4CA14 File Offset: 0x00F4AC14
		private void RefreshRewardPanel()
		{
			int num = this.ShowRewardList[this.CurrentShowRewardIndex];
			GivebackScoreReward? givebackScoreRewardById = ConfigBase<FeedbackRewardConfig>.Instance.GetGivebackScoreRewardById(num);
			if (givebackScoreRewardById == null)
			{
				return;
			}
			string texturePath = StringUtils.IsEmpty(givebackScoreRewardById.Value.IconLarge) ? null : givebackScoreRewardById.Value.IconLarge;
			RewardPanel rewardPanelItem = this.RewardPanelItem;
			if (rewardPanelItem != null)
			{
				rewardPanelItem.RefreshItem(texturePath, new int?(givebackScoreRewardById.Value.PlayerTitleId));
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), givebackScoreRewardById.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), givebackScoreRewardById.Value.DesText, Array.Empty<object>());
			base.GetButton(3).RootUIComp.Get().SetUIActive(givebackScoreRewardById.Value.ShowType != 1);
			base.GetButton(2).RootUIComp.Get().SetUIActive(this.CurrentShowRewardIndex < this.ShowRewardList.Count - 1);
			base.GetButton(1).RootUIComp.Get().SetUIActive(this.CurrentShowRewardIndex > 0);
			foreach (PageItem pageItem in this.PageList)
			{
				pageItem.RefreshItem(this.CurrentShowRewardIndex == this.PageList.IndexOf(pageItem));
			}
			EFeedbackRewardState feedbackRewardState = ModelBase<FeedbackRewardModel>.Instance.GetFeedbackRewardState(num);
			base.GetItem(6).SetUIActive(feedbackRewardState == EFeedbackRewardState.Finish);
			base.GetItem(7).SetUIActive(feedbackRewardState == EFeedbackRewardState.Claimed);
			GenericScrollViewNew<RewardItem, int> rewardScrollView = this.RewardScrollView;
			foreach (RewardItem rewardItem in (((rewardScrollView != null) ? rewardScrollView.GetScrollItemList() : null) ?? new List<RewardItem>()))
			{
				rewardItem.SetPreviewVisible(rewardItem.RewardId == num);
			}
		}

		// Token: 0x0603C4A7 RID: 246951 RVA: 0x00F4CC50 File Offset: 0x00F4AE50
		private void RefreshRewardLayout()
		{
			GenericScrollViewNew<RewardItem, int> rewardScrollView = this.RewardScrollView;
			if (rewardScrollView != null)
			{
				rewardScrollView.RefreshByData(this.RewardList, delegate
				{
					GenericScrollViewNew<RewardItem, int> rewardScrollView2 = this.RewardScrollView;
					List<RewardItem> list = ((rewardScrollView2 != null) ? rewardScrollView2.GetScrollItemList() : null) ?? new List<RewardItem>();
					bool flag = false;
					foreach (RewardItem rewardItem in list)
					{
						if (ModelBase<FeedbackRewardModel>.Instance.GetFeedbackRewardState(rewardItem.RewardId) == EFeedbackRewardState.UnFinish && !flag)
						{
							GenericScrollViewNew<RewardItem, int> rewardScrollView3 = this.RewardScrollView;
							if (rewardScrollView3 != null)
							{
								rewardScrollView3.LateScrollTo(rewardItem.GetRootItem(), null, false);
							}
							flag = true;
						}
						rewardItem.SetPreviewVisible(rewardItem.RewardId == this.ShowRewardList[this.CurrentShowRewardIndex]);
					}
				}, false);
			}
			base.GetText(14).SetText(Math.Min(ModelBase<FeedbackRewardModel>.Instance.CurrentPointCount, ModelBase<FeedbackRewardModel>.Instance.MaxShowScore).ToString(), true);
		}

		// Token: 0x0603C4A8 RID: 246952 RVA: 0x00F4CCB0 File Offset: 0x00F4AEB0
		private void RefreshTaskPanel()
		{
			base.GetArtText(11).SetText(ModelBase<FeedbackRewardModel>.Instance.CurrentLoginDayCount.ToString());
			List<int> feedbackTaskList = ModelBase<FeedbackRewardModel>.Instance.GetFeedbackTaskList();
			GenericLayout<TaskItem, int> taskLayout = this.TaskLayout;
			if (taskLayout == null)
			{
				return;
			}
			taskLayout.RefreshByData(feedbackTaskList, null, false);
		}

		// Token: 0x0603C4A9 RID: 246953 RVA: 0x00F4CCF8 File Offset: 0x00F4AEF8
		private void OnClickLeftBtn()
		{
			if (this.CurrentShowRewardIndex <= 0)
			{
				return;
			}
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.PlaySequence("Switch_Left", false, null);
			}
			this.CurrentShowRewardIndex--;
		}

		// Token: 0x0603C4AA RID: 246954 RVA: 0x00F4CD40 File Offset: 0x00F4AF40
		private void OnClickRightBtn()
		{
			if (this.CurrentShowRewardIndex >= this.ShowRewardList.Count - 1)
			{
				return;
			}
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.PlaySequence("Switch_Right", false, null);
			}
			this.CurrentShowRewardIndex++;
		}

		// Token: 0x0603C4AB RID: 246955 RVA: 0x00F4CD94 File Offset: 0x00F4AF94
		private void OnClickDetailBtn()
		{
			int id = this.ShowRewardList[this.CurrentShowRewardIndex];
			GivebackScoreReward? givebackScoreRewardById = ConfigBase<FeedbackRewardConfig>.Instance.GetGivebackScoreRewardById(id);
			if (givebackScoreRewardById == null || givebackScoreRewardById.Value.SkipParam <= 0)
			{
				return;
			}
			if (givebackScoreRewardById.Value.ShowType == 3)
			{
				ControllerBase<ItemController>.Instance.OpenTitleTipsByItemId(givebackScoreRewardById.Value.SkipParam);
				return;
			}
			if (givebackScoreRewardById.Value.ShowType == 2)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.FlySkinShowView, givebackScoreRewardById.Value.SkipParam, null);
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(givebackScoreRewardById.Value.SkipParam, true, null);
		}

		// Token: 0x0603C4AC RID: 246956 RVA: 0x00F4CE5C File Offset: 0x00F4B05C
		private void FeedbackRewardRefresh()
		{
			foreach (int num in this.ShowRewardList)
			{
				if (ModelBase<FeedbackRewardModel>.Instance.GetFeedbackRewardState(num) != EFeedbackRewardState.Claimed)
				{
					this.CurrentShowRewardIndex = this.ShowRewardList.IndexOf(num);
					break;
				}
			}
			this.RefreshRewardPanel();
			this.RefreshRewardLayout();
		}

		// Token: 0x0603C4AD RID: 246957 RVA: 0x00F4CED8 File Offset: 0x00F4B0D8
		private void OnPlaySequenceEvent(string sequenceName, string eventName)
		{
			if (eventName == "Sequence_Item_Switch")
			{
				this.RefreshRewardPanel();
			}
		}

		// Token: 0x04021E80 RID: 138880
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04021E81 RID: 138881
		private readonly List<PageItem> PageList = new List<PageItem>();

		// Token: 0x04021E82 RID: 138882
		private List<int> RewardList = new List<int>();

		// Token: 0x04021E83 RID: 138883
		private readonly List<int> ShowRewardList = new List<int>();

		// Token: 0x04021E84 RID: 138884
		private int CurrentShowRewardIndex;

		// Token: 0x04021E85 RID: 138885
		[Nullable(2)]
		private RewardPanel RewardPanelItem;

		// Token: 0x04021E86 RID: 138886
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<RewardItem, int> RewardScrollView;

		// Token: 0x04021E87 RID: 138887
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<TaskItem, int> TaskLayout;

		// Token: 0x0200BDB7 RID: 48567
		[NullableContext(0)]
		private enum ECompDefine
		{
			// Token: 0x0403A6C6 RID: 239302
			CaptionItem,
			// Token: 0x0403A6C7 RID: 239303
			LeftBtn,
			// Token: 0x0403A6C8 RID: 239304
			RightBtn,
			// Token: 0x0403A6C9 RID: 239305
			DetailBtn,
			// Token: 0x0403A6CA RID: 239306
			RewardDesText,
			// Token: 0x0403A6CB RID: 239307
			RewardNameText,
			// Token: 0x0403A6CC RID: 239308
			CanGetItem,
			// Token: 0x0403A6CD RID: 239309
			HaveGetItem,
			// Token: 0x0403A6CE RID: 239310
			PageLayout,
			// Token: 0x0403A6CF RID: 239311
			PageItem,
			// Token: 0x0403A6D0 RID: 239312
			RewardRootItem,
			// Token: 0x0403A6D1 RID: 239313
			DayText,
			// Token: 0x0403A6D2 RID: 239314
			TaskLayout,
			// Token: 0x0403A6D3 RID: 239315
			TaskItem,
			// Token: 0x0403A6D4 RID: 239316
			PointText,
			// Token: 0x0403A6D5 RID: 239317
			RewardScrollView,
			// Token: 0x0403A6D6 RID: 239318
			RewardItem
		}
	}
}
