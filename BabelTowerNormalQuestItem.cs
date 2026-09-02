using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001237 RID: 4663
public class BabelTowerNormalQuestItem : GridProxyAbstract<int>
{
	// Token: 0x06007C32 RID: 31794 RVA: 0x0020A400 File Offset: 0x00208600
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickGetRewardBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007C33 RID: 31795 RVA: 0x0020A54B File Offset: 0x0020874B
	protected override void OnStart()
	{
		this.RewardScrollerView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(1), new Func<CommonItemSmallItemGrid>(this.InitRewardItem), null, false, null);
	}

	// Token: 0x06007C34 RID: 31796 RVA: 0x0020A570 File Offset: 0x00208770
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		BabelTowerTask babelTowerNormalQuest = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerNormalQuest(data);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), babelTowerNormalQuest.Title, Array.Empty<object>());
		List<TItem> data2 = (babelTowerNormalQuest.DropId > 0) ? ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(babelTowerNormalQuest.DropId) : new List<TItem>();
		GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScrollerView = this.RewardScrollerView;
		if (rewardScrollerView != null)
		{
			rewardScrollerView.RefreshByData(data2, null, false);
		}
		BabelTowerData babelTowerData = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData();
		ActivityTask activityTask;
		babelTowerData.NormalQuest.TryGetValue(data, out activityTask);
		ActivityTaskState activityTaskState = (activityTask != null) ? activityTask.Status : ActivityTaskState.ActivityTaskRunning;
		base.GetButton(3).RootUIComp.Get().SetUIActive(activityTaskState == ActivityTaskState.ActivityTaskFinish);
		base.GetItem(6).SetUIActive(activityTaskState == ActivityTaskState.ActivityTaskTaken);
		bool flag = activityTaskState == ActivityTaskState.ActivityTaskRunning;
		base.GetText(5).SetUIActive(flag);
		base.GetItem(4).SetUIActive(activityTaskState == ActivityTaskState.ActivityTaskTaken);
		if (!flag)
		{
			return;
		}
		BabelActivityLevelInfo babelActivityLevelInfo;
		babelTowerData.NormalLevelDataMap.TryGetValue(babelTowerNormalQuest.LevelId, out babelActivityLevelInfo);
		if (babelActivityLevelInfo == null)
		{
			babelTowerData.HardLevelDataMap.TryGetValue(babelTowerNormalQuest.LevelId, out babelActivityLevelInfo);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "BabelTowerTaskDoing", Array.Empty<object>());
		if (babelActivityLevelInfo != null)
		{
			long num = Singleton<MathUtils>.Instance.LongToNumber(babelActivityLevelInfo.UnlockTime);
			if (Singleton<TimeUtil>.Instance.GetServerTimeStamp() < (double)num)
			{
				CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat((double)((long)(((double)num - Singleton<TimeUtil>.Instance.GetServerTimeStamp()) * Singleton<TimeUtil>.Instance.Millisecond)));
				base.GetText(5).SetText(remainTimeDataFormat.CountDownText ?? "", true);
			}
		}
	}

	// Token: 0x06007C35 RID: 31797 RVA: 0x0020A714 File Offset: 0x00208914
	private void OnClickGetRewardBtn()
	{
		List<int> finishedTaskIds = ControllerBase<BabelTowerController>.Instance.GetBabelTowerData().GetFinishedTaskIds();
		if (finishedTaskIds.Count > 0)
		{
			ControllerBase<BabelTowerController>.Instance.BabelTowerMultiTaskRewardRequest(finishedTaskIds);
		}
	}

	// Token: 0x06007C36 RID: 31798 RVA: 0x0020A745 File Offset: 0x00208945
	[NullableContext(1)]
	private CommonItemSmallItemGrid InitRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x04003B65 RID: 15205
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollerView;

	// Token: 0x0200759F RID: 30111
	private class EComponentDefine
	{
		// Token: 0x04028954 RID: 166228
		public const int TitleText = 0;

		// Token: 0x04028955 RID: 166229
		public const int RewardScrollerView = 1;

		// Token: 0x04028956 RID: 166230
		public const int RewardItem = 2;

		// Token: 0x04028957 RID: 166231
		public const int GetRewardBtn = 3;

		// Token: 0x04028958 RID: 166232
		public const int MaskItem = 4;

		// Token: 0x04028959 RID: 166233
		public const int DoingText = 5;

		// Token: 0x0402895A RID: 166234
		public const int FishingItem = 6;
	}
}
