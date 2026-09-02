using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016F8 RID: 5880
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerSeasonRewardView : UiTickViewBase
{
	// Token: 0x0600A2F0 RID: 41712 RVA: 0x002B02CC File Offset: 0x002AE4CC
	[NullableContext(1)]
	public WheelTowerSeasonRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A2F1 RID: 41713 RVA: 0x002B02D8 File Offset: 0x002AE4D8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIMultiTemplateScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A2F2 RID: 41714 RVA: 0x002B04B4 File Offset: 0x002AE6B4
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerSeasonRewardView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerSeasonRewardView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A2F3 RID: 41715 RVA: 0x002B04F8 File Offset: 0x002AE6F8
	protected override void OnTick(float delta)
	{
		if (this.TaskGridCount <= 0 || this.TaskLoopScroll == null)
		{
			return;
		}
		for (int i = 0; i < this.TaskGridCount; i++)
		{
			ISyncGridProxy proxyByGridIndex = this.TaskLoopScroll.GetProxyByGridIndex(i);
			WheelTowerSeasonTaskItem wheelTowerSeasonTaskItem = proxyByGridIndex as WheelTowerSeasonTaskItem;
			if (wheelTowerSeasonTaskItem == null)
			{
				WheelTowerSeasonTaskCategoryItem wheelTowerSeasonTaskCategoryItem = proxyByGridIndex as WheelTowerSeasonTaskCategoryItem;
				if (wheelTowerSeasonTaskCategoryItem != null)
				{
					wheelTowerSeasonTaskCategoryItem.OnTick();
				}
			}
			else
			{
				wheelTowerSeasonTaskItem.OnTick();
			}
		}
	}

	// Token: 0x0600A2F4 RID: 41716 RVA: 0x002B055C File Offset: 0x002AE75C
	[NullableContext(1)]
	private List<IWheelTowerSeasonScoreData> GetSeasonScoreDataList()
	{
		int seasonScoreItemId = ConfigBase<WheelTowerConfig>.Instance.GetSeasonScoreItemId(this.SeasonId);
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(seasonScoreItemId, 0);
		IReadOnlyList<NewTowerSeasonSAward> readOnlyList = ConfigBase<WheelTowerConfig>.Instance.GetSeasonScoreRewardConfigList(this.SeasonId) ?? Array.Empty<NewTowerSeasonSAward>();
		List<IWheelTowerSeasonScoreData> list = new List<IWheelTowerSeasonScoreData>();
		int totalScore = (readOnlyList.Count > 0) ? readOnlyList[readOnlyList.Count - 1].Score : 0;
		int prevScore = 0;
		foreach (NewTowerSeasonSAward newTowerSeasonSAward in readOnlyList)
		{
			list.Add(new WheelTowerSeasonScoreData
			{
				Score = newTowerSeasonSAward.Score,
				PrevScore = prevScore,
				TotalScore = totalScore,
				CurScore = itemCountByConfigId,
				IsReceived = this.ActivityData.IsSeasonScoreRewardReceived(newTowerSeasonSAward.Id),
				DropId = newTowerSeasonSAward.DropId,
				MotorPreviewId = newTowerSeasonSAward.MotorPreviewId,
				WeaponPreviewId = newTowerSeasonSAward.WeaponPreviewId,
				PreviewIcon = newTowerSeasonSAward.PreviewIcon
			});
			prevScore = newTowerSeasonSAward.Score;
		}
		return list;
	}

	// Token: 0x0600A2F5 RID: 41717 RVA: 0x002B0694 File Offset: 0x002AE894
	private void RefreshInfo()
	{
		this.RefreshTitle();
		this.RefreshDesc();
		this.RefreshRewardInfo();
		this.RefreshTaskScroll();
		this.RefreshProgressItem();
		this.RefreshMedalEntry();
	}

	// Token: 0x0600A2F6 RID: 41718 RVA: 0x002B06BC File Offset: 0x002AE8BC
	private void RefreshTitle()
	{
		NewTowerSeason? seasonConfig = ConfigBase<WheelTowerConfig>.Instance.GetSeasonConfig(this.SeasonId);
		if (seasonConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), seasonConfig.Value.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "WheelTower_SeasonReward_EndVersion", new <>z__ReadOnlySingleElementList<object>(seasonConfig.Value.EndVersionId));
		base.SetTextureByPath(seasonConfig.Value.SmallIcon, base.GetTexture(6), null, null);
		base.SetTextureByPath(seasonConfig.Value.VersionIconMain, base.GetTexture(7), null, null);
	}

	// Token: 0x0600A2F7 RID: 41719 RVA: 0x002B077F File Offset: 0x002AE97F
	private void RefreshDesc()
	{
		UUIItem item = base.GetItem(11);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600A2F8 RID: 41720 RVA: 0x002B0794 File Offset: 0x002AE994
	private void RefreshRewardInfo()
	{
		WheelTowerSeasonRewardInfoPanel rewardInfoPanel = this.RewardInfoPanel;
		if (rewardInfoPanel == null)
		{
			return;
		}
		rewardInfoPanel.RefreshDataList(this.GetSeasonScoreDataList());
	}

	// Token: 0x0600A2F9 RID: 41721 RVA: 0x002B07AC File Offset: 0x002AE9AC
	private void RefreshTaskScroll()
	{
		WheelTowerData activityData = this.ActivityData;
		List<ActivityTaskData> list = (from task in ((activityData != null) ? activityData.GetSeasonTaskList() : null) ?? new List<ActivityTaskData>()
		orderby task.Status
		select task).ThenBy(delegate(ActivityTaskData task)
		{
			NewTowerSeasonAward? seasonTaskRewardConfig2 = ConfigBase<WheelTowerConfig>.Instance.GetSeasonTaskRewardConfig(task.Id);
			if (seasonTaskRewardConfig2 == null)
			{
				return task.Id;
			}
			return seasonTaskRewardConfig2.Value.Index;
		}).ToList<ActivityTaskData>();
		List<ActivityTaskData> list2 = new List<ActivityTaskData>();
		List<ActivityTaskData> list3 = new List<ActivityTaskData>();
		foreach (ActivityTaskData activityTaskData in list)
		{
			NewTowerSeasonAward? seasonTaskRewardConfig = ConfigBase<WheelTowerConfig>.Instance.GetSeasonTaskRewardConfig(activityTaskData.Id);
			if (seasonTaskRewardConfig != null)
			{
				if (seasonTaskRewardConfig.Value.CycleId > 0)
				{
					list2.Add(activityTaskData);
				}
				else
				{
					list3.Add(activityTaskData);
				}
			}
		}
		List<IMultiTemplateGridData> list4 = new List<IMultiTemplateGridData>();
		if (list2.Count > 0)
		{
			list4.Add(new <WheelTowerSeasonRewardView>F374E42E7655038950DBBBE437EEFD57A3D495E1FD4395DB7A595CC9EA351A727__CategoryGridData(ETaskCategory.Cycle));
			foreach (ActivityTaskData data in list2)
			{
				list4.Add(new <WheelTowerSeasonRewardView>F374E42E7655038950DBBBE437EEFD57A3D495E1FD4395DB7A595CC9EA351A727__TaskGridData(data, new Action(this.OnClickGetTaskReward)));
			}
		}
		if (list3.Count > 0)
		{
			list4.Add(new <WheelTowerSeasonRewardView>F374E42E7655038950DBBBE437EEFD57A3D495E1FD4395DB7A595CC9EA351A727__CategoryGridData(ETaskCategory.Challenge));
			foreach (ActivityTaskData data2 in list3)
			{
				list4.Add(new <WheelTowerSeasonRewardView>F374E42E7655038950DBBBE437EEFD57A3D495E1FD4395DB7A595CC9EA351A727__TaskGridData(data2, new Action(this.OnClickGetTaskReward)));
			}
		}
		MultiTemplateScrollView taskLoopScroll = this.TaskLoopScroll;
		if (taskLoopScroll != null)
		{
			taskLoopScroll.RefreshByData(new MultiTemplateScrollViewRefreshContext(list4));
		}
		this.TaskGridCount = list4.Count;
	}

	// Token: 0x0600A2FA RID: 41722 RVA: 0x002B099C File Offset: 0x002AEB9C
	private void RefreshProgressItem()
	{
		int seasonScoreItemId = ConfigBase<WheelTowerConfig>.Instance.GetSeasonScoreItemId(this.SeasonId);
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(seasonScoreItemId, 0);
		WheelTowerSeasonScoreProgressItem scoreProgressItem = this.ScoreProgressItem;
		if (scoreProgressItem == null)
		{
			return;
		}
		scoreProgressItem.Refresh(itemCountByConfigId, this.GetSeasonScoreDataList());
	}

	// Token: 0x0600A2FB RID: 41723 RVA: 0x002B09DE File Offset: 0x002AEBDE
	private void RefreshMedalEntry()
	{
		WheelTowerSeasonMedalEntryItem medalEntryItem = this.MedalEntryItem;
		if (medalEntryItem == null)
		{
			return;
		}
		medalEntryItem.Refresh(this.SeasonId);
	}

	// Token: 0x0600A2FC RID: 41724 RVA: 0x002B09F8 File Offset: 0x002AEBF8
	private void PlaySwitchTween()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.StopSequenceByKey("Switch", false, false);
		}
		UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
		if (uiViewSequence2 == null)
		{
			return;
		}
		uiViewSequence2.PlaySequence("Switch", false, null);
	}

	// Token: 0x0600A2FD RID: 41725 RVA: 0x002B0A3C File Offset: 0x002AEC3C
	private void OnClickGetTaskReward()
	{
		ControllerBase<WheelTowerController>.Instance.RequestSeasonTaskReceive().ContinueWith(delegate()
		{
			this.RefreshTaskScroll();
			this.RefreshProgressItem();
		});
	}

	// Token: 0x0600A2FE RID: 41726 RVA: 0x002B0A5A File Offset: 0x002AEC5A
	private void OnClickGetProgressReward()
	{
		ControllerBase<WheelTowerController>.Instance.RequestSeasonScoreReceive().ContinueWith(delegate()
		{
			this.RefreshRewardInfo();
			this.RefreshProgressItem();
		});
	}

	// Token: 0x0600A2FF RID: 41727 RVA: 0x002B0A78 File Offset: 0x002AEC78
	private void OnClickClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x04004D73 RID: 19827
	private WheelTowerData ActivityData;

	// Token: 0x04004D74 RID: 19828
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004D75 RID: 19829
	private WheelTowerSeasonRewardInfoPanel RewardInfoPanel;

	// Token: 0x04004D76 RID: 19830
	private MultiTemplateScrollView TaskLoopScroll;

	// Token: 0x04004D77 RID: 19831
	private WheelTowerSeasonScoreProgressItem ScoreProgressItem;

	// Token: 0x04004D78 RID: 19832
	private WheelTowerSeasonMedalEntryItem MedalEntryItem;

	// Token: 0x04004D79 RID: 19833
	private int SeasonId;

	// Token: 0x04004D7A RID: 19834
	private int TaskGridCount;
}
