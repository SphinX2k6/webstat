using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain
{
	// Token: 0x0200664D RID: 26189
	[NullableContext(1)]
	[Nullable(0)]
	public class NewbieMainSubView : ActivitySubViewBase
	{
		// Token: 0x0604163D RID: 267837 RVA: 0x010C61F0 File Offset: 0x010C43F0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604163E RID: 267838 RVA: 0x010C6320 File Offset: 0x010C4520
		protected override UniTask OnBeforeStartAsync()
		{
			NewbieMainSubView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<NewbieMainSubView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604163F RID: 267839 RVA: 0x010C6363 File Offset: 0x010C4563
		private NewbieMainRewardItem CreateRewardItem()
		{
			NewbieMainRewardItem newbieMainRewardItem = new NewbieMainRewardItem();
			newbieMainRewardItem.SetClickCallback(delegate(NewbieMainRewardItemData data)
			{
				this.GetRewardAsync(data);
			});
			return newbieMainRewardItem;
		}

		// Token: 0x06041640 RID: 267840 RVA: 0x010C637C File Offset: 0x010C457C
		private NewbieMainTabItem CreateTabItem()
		{
			return new NewbieMainTabItem
			{
				OnClickTab = new Action<NewbieMainTabItemData>(this.OnClickTabCard)
			};
		}

		// Token: 0x06041641 RID: 267841 RVA: 0x010C6395 File Offset: 0x010C4595
		protected override void OnAddEventListener()
		{
			base.OnAddEventListener();
			Singleton<EventSystem>.Instance.Add(EEventName.OnNewbieMainTaskUpdate, new Action(this.OnNewbieMainTaskUpdateHandler));
		}

		// Token: 0x06041642 RID: 267842 RVA: 0x010C63B9 File Offset: 0x010C45B9
		protected override void OnRemoveEventListener()
		{
			base.OnRemoveEventListener();
			Singleton<EventSystem>.Instance.Remove(EEventName.OnNewbieMainTaskUpdate, new Action(this.OnNewbieMainTaskUpdateHandler));
		}

		// Token: 0x06041643 RID: 267843 RVA: 0x010C63DD File Offset: 0x010C45DD
		protected override void OnSequenceStart(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				GenericScrollViewNew<NewbieMainTabItem, NewbieMainTabItemData> tabScrollView = this.TabScrollView;
				if (tabScrollView == null)
				{
					return;
				}
				tabScrollView.PlayTurnAnimation();
			}
		}

		// Token: 0x06041644 RID: 267844 RVA: 0x010C63FC File Offset: 0x010C45FC
		private void OnNewbieMainTaskUpdateHandler()
		{
			this.OnRefreshView();
		}

		// Token: 0x06041645 RID: 267845 RVA: 0x010C6404 File Offset: 0x010C4604
		protected override void OnTimer(float gap)
		{
			this.RefreshTimerText();
		}

		// Token: 0x06041646 RID: 267846 RVA: 0x010C640C File Offset: 0x010C460C
		protected override void OnRefreshView()
		{
			if (this.ActivityBaseData == null)
			{
				return;
			}
			this.RefreshTitleText();
			this.RefreshActivityDescText();
			this.RefreshTimerText();
			this.UpdateTabDataList();
			this.UpdateRewardDataList();
			this.RefreshTabList();
			this.RefreshRewardList();
			this.RefreshCompletedCount();
		}

		// Token: 0x06041647 RID: 267847 RVA: 0x010C6448 File Offset: 0x010C4648
		private void RefreshTitleText()
		{
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			string text = (activityBaseData != null) ? ((activityBaseData.LocalConfig != null) ? activityBaseData.LocalConfig.GetValueOrDefault().Title : null) : null;
			if (text != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), text, Array.Empty<object>());
			}
		}

		// Token: 0x06041648 RID: 267848 RVA: 0x010C649C File Offset: 0x010C469C
		private void RefreshActivityDescText()
		{
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			string text = (activityBaseData != null) ? ((activityBaseData.LocalConfig != null) ? activityBaseData.LocalConfig.GetValueOrDefault().Desc : null) : null;
			if (text != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), text, Array.Empty<object>());
			}
		}

		// Token: 0x06041649 RID: 267849 RVA: 0x010C64F0 File Offset: 0x010C46F0
		private void RefreshTimerText()
		{
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			base.GetText(7).SetUIActive(item);
			if (item)
			{
				base.GetText(7).SetText(item2, true);
			}
		}

		// Token: 0x0604164A RID: 267850 RVA: 0x010C652E File Offset: 0x010C472E
		private void RefreshTabList()
		{
			GenericScrollViewNew<NewbieMainTabItem, NewbieMainTabItemData> tabScrollView = this.TabScrollView;
			if (tabScrollView == null)
			{
				return;
			}
			tabScrollView.RefreshByData(this.TabDataList, null, false);
		}

		// Token: 0x0604164B RID: 267851 RVA: 0x010C6548 File Offset: 0x010C4748
		private List<NewbieMainTabItemData> BuildTabDisplayDataList()
		{
			if (this.ActivityBaseData == null)
			{
				return new List<NewbieMainTabItemData>();
			}
			NewbieMainData newbieMainData = this.ActivityBaseData as NewbieMainData;
			if (newbieMainData == null)
			{
				return new List<NewbieMainTabItemData>();
			}
			List<NewbieMainTabItemData> list = new List<NewbieMainTabItemData>();
			foreach (KeyValuePair<int, NewbieMainTabData> keyValuePair in newbieMainData.GetAllTabData())
			{
				int key = keyValuePair.Key;
				NewbieMainTabData value = keyValuePair.Value;
				NewbieMainActTab? tabById = ConfigBase<NewbieMainConfig>.Instance.GetTabById(key);
				if (tabById != null)
				{
					list.Add(new NewbieMainTabItemData
					{
						TabData = value,
						TabConfig = tabById.Value,
						ProgressingTask = null,
						State = ENewbieMainTabState.Lock,
						IsNew = false
					});
				}
			}
			list.Sort(delegate(NewbieMainTabItemData a, NewbieMainTabItemData b)
			{
				if (a.TabConfig.Type != b.TabConfig.Type)
				{
					return a.TabConfig.Type - b.TabConfig.Type;
				}
				return b.TabConfig.Id - a.TabConfig.Id;
			});
			NewbieMainTabItemData newbieMainTabItemData = list.Find((NewbieMainTabItemData d) => d.TabConfig.Type == 1);
			if (newbieMainTabItemData != null)
			{
				newbieMainTabItemData.IsNew = true;
			}
			return list;
		}

		// Token: 0x0604164C RID: 267852 RVA: 0x010C6678 File Offset: 0x010C4878
		private void UpdateTabDataList()
		{
			if (this.ActivityBaseData == null)
			{
				return;
			}
			NewbieMainData newbieMainData = this.ActivityBaseData as NewbieMainData;
			if (newbieMainData == null)
			{
				return;
			}
			NewbieMainModel instance = ModelBase<NewbieMainModel>.Instance;
			foreach (NewbieMainTabItemData newbieMainTabItemData in this.TabDataList)
			{
				NewbieMainTabData tabData = newbieMainData.GetTabData(newbieMainTabItemData.TabConfig.Id);
				if (tabData != null)
				{
					if (instance.IsAllTasksCompleted(newbieMainTabItemData.TabConfig.Id, tabData))
					{
						newbieMainTabItemData.State = (newbieMainTabItemData.TabConfig.IsEnd ? ENewbieMainTabState.Finished : ENewbieMainTabState.Completed);
						newbieMainTabItemData.ProgressingTask = null;
					}
					else if (newbieMainTabItemData.TabConfig.Type == 2)
					{
						newbieMainTabItemData.State = (instance.IsAllAcceptedTasksCompleted(newbieMainTabItemData.TabConfig.Id, tabData) ? ENewbieMainTabState.Completed : ENewbieMainTabState.InProgress);
						newbieMainTabItemData.ProgressingTask = null;
					}
					else if (instance.IsFirstQuestInActive(newbieMainTabItemData.TabConfig.Id))
					{
						newbieMainTabItemData.State = ENewbieMainTabState.Lock;
						newbieMainTabItemData.ProgressingTask = null;
						newbieMainTabItemData.ProgressingQuestId = 0;
					}
					else
					{
						NewbieMainTaskQuestInfo firstUncompletedTask = instance.GetFirstUncompletedTask(newbieMainTabItemData.TabConfig, tabData);
						newbieMainTabItemData.State = ENewbieMainTabState.InProgress;
						newbieMainTabItemData.ProgressingTask = ((firstUncompletedTask != null) ? new NewbieMainActTask?(firstUncompletedTask.Task) : null);
						newbieMainTabItemData.ProgressingQuestId = ((firstUncompletedTask != null) ? firstUncompletedTask.QuestId : 0);
					}
				}
			}
		}

		// Token: 0x0604164D RID: 267853 RVA: 0x010C6804 File Offset: 0x010C4A04
		private void UpdateRewardDataList()
		{
			if (this.ActivityBaseData == null)
			{
				return;
			}
			NewbieMainData newbieMainData = this.ActivityBaseData as NewbieMainData;
			if (newbieMainData == null)
			{
				return;
			}
			int progressScore = newbieMainData.ProgressScore;
			foreach (NewbieMainRewardItemData newbieMainRewardItemData in this.RewardDataList)
			{
				if (newbieMainData.IsScoreRewardTaken(newbieMainRewardItemData.Id))
				{
					newbieMainRewardItemData.State = ENewbieScoreRewardState.Claimed;
					newbieMainRewardItemData.Progress = 1f;
				}
				else if (progressScore >= newbieMainRewardItemData.Score)
				{
					newbieMainRewardItemData.State = ENewbieScoreRewardState.Claimable;
					newbieMainRewardItemData.Progress = 1f;
				}
				else
				{
					newbieMainRewardItemData.State = ENewbieScoreRewardState.UnAchieved;
					int num = newbieMainRewardItemData.Score - newbieMainRewardItemData.SrcScore;
					newbieMainRewardItemData.Progress = ((num > 0) ? Math.Max(0f, (float)(progressScore - newbieMainRewardItemData.SrcScore) / (float)num) : 0f);
				}
			}
		}

		// Token: 0x0604164E RID: 267854 RVA: 0x010C68F4 File Offset: 0x010C4AF4
		private void OnClickTabCard(NewbieMainTabItemData tabItemData)
		{
			if (tabItemData.TabConfig.Type == 1)
			{
				this.HandleMainTabClick(tabItemData);
				return;
			}
			if (tabItemData.TabConfig.Type == 2)
			{
				this.HandleRoleTabClick(tabItemData);
			}
		}

		// Token: 0x0604164F RID: 267855 RVA: 0x010C6924 File Offset: 0x010C4B24
		private void HandleMainTabClick(NewbieMainTabItemData tabItemData)
		{
			if (tabItemData.State == ENewbieMainTabState.Finished)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("NewPlayer_TaskAwards_012", Array.Empty<object>());
				return;
			}
			if (tabItemData.State == ENewbieMainTabState.Completed)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("NewPlayer_TaskAwards_013", Array.Empty<object>());
				return;
			}
			if (tabItemData.State != ENewbieMainTabState.Lock)
			{
				if (tabItemData.ProgressingQuestId > 0)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, tabItemData.ProgressingQuestId, null);
				}
				return;
			}
			int directTrainActivityId = tabItemData.TabConfig.DirectTrainActivityId;
			if (directTrainActivityId <= 0)
			{
				return;
			}
			DirectTrainModel instance = ModelBase<DirectTrainModel>.Instance;
			DirectTrainSubActivityViewModel directTrainSubActivityViewModel = (instance != null) ? instance.BuildSubActivityViewModel(directTrainActivityId) : null;
			if (directTrainSubActivityViewModel == null)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DirectTrainDetailView, directTrainSubActivityViewModel, null);
		}

		// Token: 0x06041650 RID: 267856 RVA: 0x010C69D4 File Offset: 0x010C4BD4
		private void HandleRoleTabClick(NewbieMainTabItemData tabItemData)
		{
			if (tabItemData.State == ENewbieMainTabState.Finished)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("NewPlayer_TaskAwards_015", Array.Empty<object>());
				return;
			}
			if (tabItemData.State == ENewbieMainTabState.Completed)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("NewPlayer_TaskAwards_014", Array.Empty<object>());
				return;
			}
			global::RoleQuest firstShowRoleQuest = ModelBase<ActivityRegressModel>.Instance.GetFirstShowRoleQuest();
			if (firstShowRoleQuest == null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("NewPlayer_TaskAwards_011", Array.Empty<object>());
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, firstShowRoleQuest.Id, null);
		}

		// Token: 0x06041651 RID: 267857 RVA: 0x010C6A5C File Offset: 0x010C4C5C
		private List<NewbieMainRewardItemData> BuildScoreRewardDisplayDataList()
		{
			if (this.ActivityBaseData == null)
			{
				return new List<NewbieMainRewardItemData>();
			}
			IReadOnlyList<NewbieMainActReward> rewardListByActivityId = ConfigBase<NewbieMainConfig>.Instance.GetRewardListByActivityId(this.ActivityBaseData.Id);
			if (rewardListByActivityId == null)
			{
				return new List<NewbieMainRewardItemData>();
			}
			List<NewbieMainRewardItemData> list = new List<NewbieMainRewardItemData>();
			foreach (NewbieMainActReward newbieMainActReward in rewardListByActivityId)
			{
				list.Add(new NewbieMainRewardItemData
				{
					Id = newbieMainActReward.Id,
					SrcScore = 0,
					Score = newbieMainActReward.Score,
					Progress = 0f,
					State = ENewbieScoreRewardState.UnAchieved,
					PreviewReward = this.GetDropPreviewReward(newbieMainActReward.DropId)
				});
			}
			list.Sort((NewbieMainRewardItemData a, NewbieMainRewardItemData b) => a.Score - b.Score);
			for (int i = 0; i < list.Count; i++)
			{
				list[i].SrcScore = ((i > 0) ? list[i - 1].Score : 0);
			}
			return list;
		}

		// Token: 0x06041652 RID: 267858 RVA: 0x010C6B80 File Offset: 0x010C4D80
		private TItem? GetDropPreviewReward(int dropId)
		{
			if (dropId <= 0)
			{
				return null;
			}
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(dropId);
			if (dropPackagePreviewItemList == null || dropPackagePreviewItemList.Count == 0)
			{
				return null;
			}
			return new TItem?(dropPackagePreviewItemList[0]);
		}

		// Token: 0x06041653 RID: 267859 RVA: 0x010C6BC8 File Offset: 0x010C4DC8
		private void RefreshRewardList()
		{
			if (this.RewardScrollView == null)
			{
				return;
			}
			this.RewardScrollView.RefreshByData(this.RewardDataList, new Action(this.ScrollToFirstClaimableReward), false);
		}

		// Token: 0x06041654 RID: 267860 RVA: 0x010C6BF4 File Offset: 0x010C4DF4
		private void ScrollToFirstClaimableReward()
		{
			int num = -1;
			for (int i = 0; i < this.RewardDataList.Count; i++)
			{
				if (this.RewardDataList[i].State == ENewbieScoreRewardState.Claimable)
				{
					num = i;
					break;
				}
			}
			if (num >= 0)
			{
				this.RewardScrollView.LateScrollToLeft(num);
			}
		}

		// Token: 0x06041655 RID: 267861 RVA: 0x010C6C48 File Offset: 0x010C4E48
		private void GetRewardAsync(NewbieMainRewardItemData data)
		{
			if (this.ActivityBaseData == null)
			{
				return;
			}
			NewbieMainData newbieMainData = this.ActivityBaseData as NewbieMainData;
			if (newbieMainData == null)
			{
				return;
			}
			if (data.State != ENewbieScoreRewardState.Claimable)
			{
				if (data.PreviewReward != null)
				{
					ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(data.PreviewReward.Value.ItemData.ItemId, true, null);
				}
				return;
			}
			List<int> list = new List<int>();
			foreach (NewbieMainRewardItemData newbieMainRewardItemData in this.RewardDataList)
			{
				if (newbieMainRewardItemData.State == ENewbieScoreRewardState.Claimable)
				{
					list.Add(newbieMainRewardItemData.Id);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			NewbieMainController.RequestFetchScoreRewardAsync(newbieMainData.Id, list, delegate(bool success)
			{
				if (success)
				{
					this.OnRefreshView();
				}
			});
		}

		// Token: 0x06041656 RID: 267862 RVA: 0x010C6D24 File Offset: 0x010C4F24
		private void RefreshCompletedCount()
		{
			if (this.ActivityBaseData == null)
			{
				return;
			}
			NewbieMainData newbieMainData = this.ActivityBaseData as NewbieMainData;
			if (newbieMainData == null)
			{
				return;
			}
			int progressScore = newbieMainData.ProgressScore;
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetText(progressScore.ToString(), true);
		}

		// Token: 0x0402491F RID: 149791
		private List<NewbieMainTabItemData> TabDataList = new List<NewbieMainTabItemData>();

		// Token: 0x04024920 RID: 149792
		private List<NewbieMainRewardItemData> RewardDataList = new List<NewbieMainRewardItemData>();

		// Token: 0x04024921 RID: 149793
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<NewbieMainRewardItem, NewbieMainRewardItemData> RewardScrollView;

		// Token: 0x04024922 RID: 149794
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<NewbieMainTabItem, NewbieMainTabItemData> TabScrollView;

		// Token: 0x0200C669 RID: 50793
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D14F RID: 250191
			public const int TitleText = 0;

			// Token: 0x0403D150 RID: 250192
			public const int ActivityDescText = 1;

			// Token: 0x0403D151 RID: 250193
			public const int RewardCountText = 2;

			// Token: 0x0403D152 RID: 250194
			public const int RewardScrollView = 3;

			// Token: 0x0403D153 RID: 250195
			public const int RewardTemplateItem = 4;

			// Token: 0x0403D154 RID: 250196
			public const int TabScrollView = 5;

			// Token: 0x0403D155 RID: 250197
			public const int TabTemplateItem = 6;

			// Token: 0x0403D156 RID: 250198
			public const int TimeText = 7;
		}
	}
}
