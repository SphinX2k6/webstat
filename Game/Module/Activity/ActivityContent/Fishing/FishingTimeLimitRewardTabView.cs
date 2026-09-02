using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200678E RID: 26510
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingTimeLimitRewardTabView : UiTabViewBase
	{
		// Token: 0x06042145 RID: 270661 RVA: 0x010F42D4 File Offset: 0x010F24D4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042146 RID: 270662 RVA: 0x010F43C4 File Offset: 0x010F25C4
		protected override UniTask OnBeforeStartAsync()
		{
			FishingTimeLimitRewardTabView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingTimeLimitRewardTabView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042147 RID: 270663 RVA: 0x010F4408 File Offset: 0x010F2608
		protected override void OnStart()
		{
			FishingActivity activityConfig = this.ActivityDataBase.GetActivityConfig();
			WeaponTrialData weaponTrialData = new WeaponTrialData();
			weaponTrialData.SetTrialId(activityConfig.PreviewWeaponId, true);
			this.WeaponItem.Refresh(weaponTrialData.GetItemId(), false);
			this.WeaponItem.SetLookButtonVisible(true);
			this.WeaponItem.BindWeaponPreviewFunction(new int[]
			{
				activityConfig.PreviewWeaponId
			}, 0);
		}

		// Token: 0x06042148 RID: 270664 RVA: 0x010F446F File Offset: 0x010F266F
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FishingTimeLimitRewardListRefresh, new Action(this.RefreshCurrentTaskLayout));
			Singleton<EventSystem>.Instance.Add(EEventName.FishingTimeLimitRewardProgressRefresh, new Action(this.RefreshProgressItem));
		}

		// Token: 0x06042149 RID: 270665 RVA: 0x010F44AC File Offset: 0x010F26AC
		protected override void OnBeforeShow()
		{
			UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
			LevelSequencePlayer levelSequencePlayer = (tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0604214A RID: 270666 RVA: 0x010F44E8 File Offset: 0x010F26E8
		protected override void OnBeforeHide()
		{
			UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
			LevelSequencePlayer levelSequencePlayer = (tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		}

		// Token: 0x0604214B RID: 270667 RVA: 0x010F4521 File Offset: 0x010F2721
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingTimeLimitRewardListRefresh, new Action(this.RefreshCurrentTaskLayout));
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingTimeLimitRewardProgressRefresh, new Action(this.RefreshProgressItem));
		}

		// Token: 0x0604214C RID: 270668 RVA: 0x010F455B File Offset: 0x010F275B
		private FishingRewardTargetTabItem TabItemProxyCreate()
		{
			return new FishingRewardTargetTabItem();
		}

		// Token: 0x0604214D RID: 270669 RVA: 0x010F4564 File Offset: 0x010F2764
		private List<FishingRewardTargetTabData> CreateTabItemDataList(IEnumerable<FishingActivityGroup> tabList)
		{
			List<FishingRewardTargetTabData> list = new List<FishingRewardTargetTabData>();
			int num = 0;
			foreach (FishingActivityGroup fishingActivityGroup in tabList)
			{
				list.Add(new FishingRewardTargetTabData
				{
					NameTextId = fishingActivityGroup.GroupName,
					Index = num,
					ClickedCallback = new Action<int>(this.TabCallBack),
					RefreshRedDot = ((int tabIndex) => this.ActivityDataBase.GetTimeLimitTasksRedDotStateByGroupId(tabIndex))
				});
				num++;
			}
			return list;
		}

		// Token: 0x0604214E RID: 270670 RVA: 0x010F4600 File Offset: 0x010F2800
		private void TabCallBack(int index)
		{
			if (this.CurrentTabIndex != index && this.CurrentTabIndex != -1)
			{
				FishingRewardTargetTabItem layoutItemByIndex = this.TabLayout.GetLayoutItemByIndex(this.CurrentTabIndex);
				if (layoutItemByIndex != null)
				{
					layoutItemByIndex.SetToggleState(false, false);
				}
			}
			this.CurrentTabIndex = index;
			this.RefreshTaskLayout(this.CurrentTabIndex, true);
		}

		// Token: 0x0604214F RID: 270671 RVA: 0x010F4651 File Offset: 0x010F2851
		private FishingRewardTaskItem TaskItemProxyCreate()
		{
			return new FishingRewardTaskItem();
		}

		// Token: 0x06042150 RID: 270672 RVA: 0x010F4658 File Offset: 0x010F2858
		private void RefreshCurrentTaskLayout()
		{
			foreach (FishingRewardTargetTabItem fishingRewardTargetTabItem in this.TabLayout.GetLayoutItemList())
			{
				fishingRewardTargetTabItem.RefreshRedDot();
			}
			this.RefreshTaskLayout(this.CurrentTabIndex, false);
		}

		// Token: 0x06042151 RID: 270673 RVA: 0x010F46BC File Offset: 0x010F28BC
		private void RefreshTaskLayout(int tabIndex, bool reset)
		{
			ActivityTaskData[] timeLimitTasksByGroupId = this.ActivityDataBase.GetTimeLimitTasksByGroupId(tabIndex + 1);
			this.TaskLayout.RefreshByData(this.CreateTaskDataList(timeLimitTasksByGroupId), delegate
			{
				if (reset)
				{
					this.TaskLayout.ScrollToTop(0);
				}
			}, true);
		}

		// Token: 0x06042152 RID: 270674 RVA: 0x010F470C File Offset: 0x010F290C
		private List<FishingTaskData> CreateTaskDataList(IEnumerable<ActivityTaskData> taskDataList)
		{
			List<FishingTaskData> list = new List<FishingTaskData>();
			foreach (ActivityTaskData activityTaskData in taskDataList)
			{
				FishingActivityLimitTask? fishingActivityLimitTask = ConfigBase<FishingConfig>.Instance.GetFishingActivityLimitTask(activityTaskData.Id);
				list.Add(new FishingTaskData
				{
					TaskId = activityTaskData.Id,
					Status = activityTaskData.Status,
					Current = activityTaskData.Current,
					Target = activityTaskData.Target,
					JumpId = fishingActivityLimitTask.Value.JumpId,
					TitleTextId = fishingActivityLimitTask.Value.TaskName,
					RewardList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(fishingActivityLimitTask.Value.DropId),
					ReceiveDelegate = new Action<int>(this.TaskReceiveFunc)
				});
			}
			return list;
		}

		// Token: 0x06042153 RID: 270675 RVA: 0x010F4810 File Offset: 0x010F2A10
		private void TaskReceiveFunc(int taskId)
		{
			ActivityFishingController.FishingActivityLimitRewardRequest(taskId);
		}

		// Token: 0x06042154 RID: 270676 RVA: 0x010F4818 File Offset: 0x010F2A18
		private void RefreshProgressItem()
		{
			FishingRewardProgressData[] allMilestoneReward = this.ActivityDataBase.GetAllMilestoneReward();
			int milestoneRewardMaxCount = this.ActivityDataBase.MilestoneRewardMaxCount;
			int milestoneRewardItemAccumulate = this.ActivityDataBase.MilestoneRewardItemAccumulate;
			this.ProgressItem.RefreshProgressItem(milestoneRewardItemAccumulate, milestoneRewardMaxCount, allMilestoneReward).Forget();
		}

		// Token: 0x06042155 RID: 270677 RVA: 0x010F485C File Offset: 0x010F2A5C
		private void OnClickGetProgressReward()
		{
			int[] allAvailableGetMilestoneRewardIds = this.ActivityDataBase.GetAllAvailableGetMilestoneRewardIds();
			if (allAvailableGetMilestoneRewardIds.Length != 0)
			{
				ActivityFishingController.FishingActivityMilestoneRewardRequest(allAvailableGetMilestoneRewardIds.ToList<int>());
			}
		}

		// Token: 0x04024D63 RID: 150883
		private GenericLayout<FishingRewardTargetTabItem, FishingRewardTargetTabData> TabLayout;

		// Token: 0x04024D64 RID: 150884
		private GenericScrollViewNew<FishingRewardTaskItem, FishingTaskData> TaskLayout;

		// Token: 0x04024D65 RID: 150885
		private ActivityWeaponDescribeComponent WeaponItem;

		// Token: 0x04024D66 RID: 150886
		private FishingRewardProgressPanel ProgressItem;

		// Token: 0x04024D67 RID: 150887
		private ActivityFishingData ActivityDataBase;

		// Token: 0x04024D68 RID: 150888
		private int CurrentTabIndex = -1;

		// Token: 0x0200C7AC RID: 51116
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D789 RID: 251785
			public const int WeaponPreview = 0;

			// Token: 0x0403D78A RID: 251786
			public const int TabLayout = 1;

			// Token: 0x0403D78B RID: 251787
			public const int TabItem = 2;

			// Token: 0x0403D78C RID: 251788
			public const int TaskLayout = 3;

			// Token: 0x0403D78D RID: 251789
			public const int TaskItem = 4;

			// Token: 0x0403D78E RID: 251790
			public const int ProgressItem = 5;
		}
	}
}
