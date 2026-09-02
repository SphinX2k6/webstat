using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001563 RID: 5475
public class ActivityRegressTaskSubView : ActivityRegressTaskSubViewBase
{
	// Token: 0x060099A4 RID: 39332 RVA: 0x002838FC File Offset: 0x00281AFC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIDynScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x060099A5 RID: 39333 RVA: 0x002839E8 File Offset: 0x00281BE8
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressTaskSubView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressTaskSubView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060099A6 RID: 39334 RVA: 0x00283A2B File Offset: 0x00281C2B
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		this.RefreshView();
	}

	// Token: 0x060099A7 RID: 39335 RVA: 0x00283A39 File Offset: 0x00281C39
	protected override void OnUpdate()
	{
		this.RefreshView();
	}

	// Token: 0x060099A8 RID: 39336 RVA: 0x00283A41 File Offset: 0x00281C41
	protected override void OnAfterHide()
	{
		base.OnAfterHide();
		this.ClearTimer();
	}

	// Token: 0x060099A9 RID: 39337 RVA: 0x00283A4F File Offset: 0x00281C4F
	protected override void OnBeforeDestroy()
	{
		if (this.ContentGenericLayout != null)
		{
			this.ContentGenericLayout.ClearChildren();
			this.ContentGenericLayout = null;
		}
		this.TaskDynamicScrollItemList = null;
	}

	// Token: 0x060099AA RID: 39338 RVA: 0x00283A72 File Offset: 0x00281C72
	private void ClearTimer()
	{
		if (TimerSystem.Instance.Has(this.RefreshTimerHandle))
		{
			TimerSystem.Instance.Remove(this.RefreshTimerHandle);
			this.RefreshTimerHandle = null;
		}
	}

	// Token: 0x060099AB RID: 39339 RVA: 0x00283A9E File Offset: 0x00281C9E
	protected override void OnStart()
	{
		base.OnStart();
		this.RecallTaskScoreRewardLayout = new GenericScrollViewNew<ActivityRegressTaskLayoutItemPanel, ActivityRegressTaskScoreRewardGridData>(base.GetScrollViewWithScrollbar(1), new Func<ActivityRegressTaskLayoutItemPanel>(this.InitScoreRewardGridItem), null, false, null);
	}

	// Token: 0x060099AC RID: 39340 RVA: 0x00283AC8 File Offset: 0x00281CC8
	[NullableContext(1)]
	private ActivityRegressTaskDynamicScrollItem CreateItemFunc(ActivityRegressTaskDynamicData data, UUIItem uiItem, int index)
	{
		ActivityRegressTaskDynamicScrollItem activityRegressTaskDynamicScrollItem = new ActivityRegressTaskDynamicScrollItem();
		this.TaskDynamicScrollItemList.Add(activityRegressTaskDynamicScrollItem);
		return activityRegressTaskDynamicScrollItem;
	}

	// Token: 0x060099AD RID: 39341 RVA: 0x00283AE8 File Offset: 0x00281CE8
	[NullableContext(1)]
	private ActivityRegressTaskLayoutItemPanel InitScoreRewardGridItem()
	{
		return new ActivityRegressTaskLayoutItemPanel();
	}

	// Token: 0x060099AE RID: 39342 RVA: 0x00283AF0 File Offset: 0x00281CF0
	private void RefreshScoreRewards()
	{
		UUIText text = base.GetText(3);
		int regressTaskScore = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetRegressTaskScore();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("x");
		defaultInterpolatedStringHandler.AppendFormatted<int>(regressTaskScore);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		List<ActivityRegressTaskScoreRewardGridData> regressMainTaskScoreRewardGridDataArr = ModelBase<ActivityRegressModel>.Instance.GetRegressMainTaskScoreRewardGridDataArr();
		int index = -1;
		for (int i = 0; i < regressMainTaskScoreRewardGridDataArr.Count; i++)
		{
			if (regressMainTaskScoreRewardGridDataArr[i].RewardState == ERegressRewardState.Reached)
			{
				index = i;
				break;
			}
		}
		if (index == -1)
		{
			for (int j = 0; j < regressMainTaskScoreRewardGridDataArr.Count; j++)
			{
				if (regressMainTaskScoreRewardGridDataArr[j].RewardState == ERegressRewardState.UnReach)
				{
					index = j;
					break;
				}
			}
		}
		index = ((index != -1) ? index : 0);
		this.RecallTaskScoreRewardLayout.RefreshByData(regressMainTaskScoreRewardGridDataArr, delegate
		{
			UUIItem itemByIndex = this.RecallTaskScoreRewardLayout.GetItemByIndex(index);
			this.RecallTaskScoreRewardLayout.LateScrollTo(itemByIndex, null, false);
		}, false);
		this.RefreshMainTaskScoreRewardRedDotIndexes(regressMainTaskScoreRewardGridDataArr);
	}

	// Token: 0x060099AF RID: 39343 RVA: 0x00283BFC File Offset: 0x00281DFC
	private void RefreshRegressTasks()
	{
		List<ActivityRegressTaskDynamicData> regressMainTaskGridDataGroupByTypeAndSortedArr = ModelBase<ActivityRegressModel>.Instance.GetRegressMainTaskGridDataGroupByTypeAndSortedArr();
		this.ContentGenericLayout.RefreshByData(regressMainTaskGridDataGroupByTypeAndSortedArr.ToArray(), false, false);
	}

	// Token: 0x060099B0 RID: 39344 RVA: 0x00283C28 File Offset: 0x00281E28
	private void RefreshView()
	{
		this.RefreshScoreRewards();
		this.RefreshRegressTasks();
		base.GetItem(4).SetUIActive(ModelBase<ActivityRegressModel>.Instance.Grade == ERegressGrade.Normal);
		base.GetItem(5).SetUIActive(ModelBase<ActivityRegressModel>.Instance.Grade == ERegressGrade.Hyper);
		base.GetTexture(6).SetUIActive(ModelBase<ActivityRegressModel>.Instance.Grade == ERegressGrade.Hyper);
	}

	// Token: 0x060099B1 RID: 39345 RVA: 0x00283C8C File Offset: 0x00281E8C
	[NullableContext(1)]
	private void RefreshMainTaskScoreRewardRedDotIndexes(List<ActivityRegressTaskScoreRewardGridData> gridDataList)
	{
		if (!ModelBase<ActivityRegressModel>.Instance.ActivityData.CheckRegressScoreRewardReached())
		{
			this.MinAndMaxScoreRewardIndexTuple = new ValueTuple<int?, int?>(null, null);
			return;
		}
		int num = gridDataList.Count;
		int num2 = -1;
		for (int i = 0; i < gridDataList.Count; i++)
		{
			if (gridDataList[i].RewardState == ERegressRewardState.Reached)
			{
				if (i < num)
				{
					num = i;
				}
				if (i > num2)
				{
					num2 = i;
				}
			}
		}
		this.MinAndMaxScoreRewardIndexTuple = new ValueTuple<int?, int?>(new int?(num), new int?(num2));
	}

	// Token: 0x060099B2 RID: 39346 RVA: 0x00283D14 File Offset: 0x00281F14
	private void OnScrollUpdateRedDot(FVector2D _)
	{
		if (this.MinAndMaxScoreRewardIndexTuple.Item1 == null && this.MinAndMaxScoreRewardIndexTuple.Item2 == null)
		{
			base.GetItem(7).SetUIActive(false);
			base.GetItem(8).SetUIActive(false);
			return;
		}
		int displayGridStartIndex = this.ContentGenericLayout.GetDisplayGridStartIndex();
		int displayGridEndIndex = this.ContentGenericLayout.GetDisplayGridEndIndex();
		int valueOrDefault = this.MinAndMaxScoreRewardIndexTuple.Item1.GetValueOrDefault(displayGridStartIndex);
		int valueOrDefault2 = this.MinAndMaxScoreRewardIndexTuple.Item2.GetValueOrDefault(displayGridEndIndex);
		base.GetItem(7).SetUIActive(valueOrDefault < displayGridStartIndex);
		base.GetItem(8).SetUIActive(valueOrDefault2 > displayGridEndIndex);
	}

	// Token: 0x040046F1 RID: 18161
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<ActivityRegressTaskDynamicScrollItem, ActivityRegressTaskDynamicItem, ActivityRegressTaskDynamicData> ContentGenericLayout;

	// Token: 0x040046F2 RID: 18162
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ActivityRegressTaskDynamicScrollItem> TaskDynamicScrollItemList;

	// Token: 0x040046F3 RID: 18163
	[Nullable(2)]
	private TimerHandle RefreshTimerHandle;

	// Token: 0x040046F4 RID: 18164
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ActivityRegressTaskLayoutItemPanel, ActivityRegressTaskScoreRewardGridData> RecallTaskScoreRewardLayout;

	// Token: 0x040046F5 RID: 18165
	private ValueTuple<int?, int?> MinAndMaxScoreRewardIndexTuple = new ValueTuple<int?, int?>(null, null);

	// Token: 0x02007927 RID: 31015
	private class EComponents
	{
		// Token: 0x04029A12 RID: 170514
		public const int DynScrollView = 0;

		// Token: 0x04029A13 RID: 170515
		public const int RewardScrollView = 1;

		// Token: 0x04029A14 RID: 170516
		public const int PnlItem = 2;

		// Token: 0x04029A15 RID: 170517
		public const int TxtNum = 3;

		// Token: 0x04029A16 RID: 170518
		public const int PnlNor = 4;

		// Token: 0x04029A17 RID: 170519
		public const int PnlSenior = 5;

		// Token: 0x04029A18 RID: 170520
		public const int TexSeniorBg = 6;

		// Token: 0x04029A19 RID: 170521
		public const int LeftRedPoint = 7;

		// Token: 0x04029A1A RID: 170522
		public const int RightRedPoint = 8;
	}
}
