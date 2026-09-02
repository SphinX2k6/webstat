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

// Token: 0x02001C37 RID: 7223
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchLimitRewardView : UiViewBase
{
	// Token: 0x0600D271 RID: 53873 RVA: 0x0037F103 File Offset: 0x0037D303
	public FloroRanchLimitRewardView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D272 RID: 53874 RVA: 0x0037F114 File Offset: 0x0037D314
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnCardDetailBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D273 RID: 53875 RVA: 0x0037F2C4 File Offset: 0x0037D4C4
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchLimitRewardView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchLimitRewardView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D274 RID: 53876 RVA: 0x0037F307 File Offset: 0x0037D507
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshView));
	}

	// Token: 0x0600D275 RID: 53877 RVA: 0x0037F325 File Offset: 0x0037D525
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshView));
	}

	// Token: 0x0600D276 RID: 53878 RVA: 0x0037F344 File Offset: 0x0037D544
	private void RefreshTaskLayout()
	{
		List<FloroRanchTaskData> taskDataByTabType = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true).GetTaskDataByTabType(this.CurTaskTabType);
		this.TaskLayout.RefreshByData(taskDataByTabType, delegate
		{
			this.TaskLayout.ScrollToTop(0);
		}, true);
	}

	// Token: 0x0600D277 RID: 53879 RVA: 0x0037F384 File Offset: 0x0037D584
	private void RefreshProgressItem()
	{
		List<FloroRanchMilestoneData> floroRanchMilestoneDataList = this.ActivityData.GetFloroRanchMilestoneDataList();
		int milestoneItemCount = this.ActivityData.GetMilestoneItemCount();
		this.ProgressItem.RefreshProgressItem((float)milestoneItemCount, floroRanchMilestoneDataList);
	}

	// Token: 0x0600D278 RID: 53880 RVA: 0x0037F3B8 File Offset: 0x0037D5B8
	private void RefreshTimeText()
	{
		if (!this.ActivityData.IsInLimitTime())
		{
			this.RemoveTimeHandle();
			ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
			return;
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityData.GetLimitTimeActivityEndTime(), localTextNew);
		UUIText text = base.GetText(9);
		if (text == null)
		{
			return;
		}
		text.SetText(remainTimeText, true);
	}

	// Token: 0x0600D279 RID: 53881 RVA: 0x0037F41A File Offset: 0x0037D61A
	private void RemoveTimeHandle()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x0600D27A RID: 53882 RVA: 0x0037F43C File Offset: 0x0037D63C
	protected override void OnBeforeDestroy()
	{
		this.RemoveTimeHandle();
	}

	// Token: 0x0600D27B RID: 53883 RVA: 0x0037F444 File Offset: 0x0037D644
	private void OnRefreshView(int activityId)
	{
		if (this.ActivityData.Id == activityId)
		{
			this.TabLayout.RefreshWithoutDataSync();
			this.RefreshTaskLayout();
			this.RefreshProgressItem();
		}
	}

	// Token: 0x0600D27C RID: 53884 RVA: 0x0037F46B File Offset: 0x0037D66B
	private void OnTabClickCallBack(int gridIndex, EFloroRanchTaskTabType taskTabType)
	{
		this.TabLayout.SelectGridProxy(gridIndex, false);
		this.CurTaskTabType = taskTabType;
		this.RefreshTaskLayout();
	}

	// Token: 0x0600D27D RID: 53885 RVA: 0x0037F488 File Offset: 0x0037D688
	private void OnTaskClickCallBack()
	{
		List<int> floroRanchReceivableTaskIds = this.ActivityData.GetFloroRanchReceivableTaskIds(true, this.CurTaskTabType);
		ControllerBase<FloroRanchController>.Instance.RequestTaskReward(floroRanchReceivableTaskIds.ToArray());
	}

	// Token: 0x0600D27E RID: 53886 RVA: 0x0037F4B8 File Offset: 0x0037D6B8
	private void OnClickGetProgressReward()
	{
		List<int> floroRanchReceivableMilestoneIds = this.ActivityData.GetFloroRanchReceivableMilestoneIds();
		if (floroRanchReceivableMilestoneIds.Count > 0)
		{
			ControllerBase<FloroRanchController>.Instance.RequestMilestoneReward(floroRanchReceivableMilestoneIds.ToArray());
		}
	}

	// Token: 0x0600D27F RID: 53887 RVA: 0x0037F4EA File Offset: 0x0037D6EA
	private FloroRanchTaskTabItem CreateTabItem()
	{
		return new FloroRanchTaskTabItem
		{
			OnToggleCallBack = new Action<int, EFloroRanchTaskTabType>(this.OnTabClickCallBack)
		};
	}

	// Token: 0x0600D280 RID: 53888 RVA: 0x0037F503 File Offset: 0x0037D703
	private FloroRanchTaskItem CreateTaskItem()
	{
		return new FloroRanchTaskItem
		{
			OnGetBtnClick = new Action(this.OnTaskClickCallBack)
		};
	}

	// Token: 0x0600D281 RID: 53889 RVA: 0x0037F51C File Offset: 0x0037D71C
	private void OnCardDetailBtnClick()
	{
		int cardItemId = this.ActivityData.GetFloroRanchParamConfig().CardItemId;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(cardItemId, true, null);
	}

	// Token: 0x0600D282 RID: 53890 RVA: 0x0037F54A File Offset: 0x0037D74A
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400644B RID: 25675
	private FloroRanchActivityData ActivityData;

	// Token: 0x0400644C RID: 25676
	private EFloroRanchTaskTabType CurTaskTabType = EFloroRanchTaskTabType.Dungeon;

	// Token: 0x0400644D RID: 25677
	private GenericLayout<FloroRanchTaskTabItem, FloroRanchTaskTab> TabLayout;

	// Token: 0x0400644E RID: 25678
	private GenericScrollViewNew<FloroRanchTaskItem, FloroRanchTaskData> TaskLayout;

	// Token: 0x0400644F RID: 25679
	private TimerHandle TimerHandle;

	// Token: 0x04006450 RID: 25680
	private FloroRanchMilestoneItem ProgressItem;

	// Token: 0x02007F32 RID: 32562
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B4A6 RID: 177318
		public const int ItemCaption = 0;

		// Token: 0x0402B4A7 RID: 177319
		public const int TextureCardImage = 1;

		// Token: 0x0402B4A8 RID: 177320
		public const int TextCardName = 2;

		// Token: 0x0402B4A9 RID: 177321
		public const int ScrollLayoutTask = 3;

		// Token: 0x0402B4AA RID: 177322
		public const int ItemTask = 4;

		// Token: 0x0402B4AB RID: 177323
		public const int ButtonCardDetail = 5;

		// Token: 0x0402B4AC RID: 177324
		public const int LayoutTab = 6;

		// Token: 0x0402B4AD RID: 177325
		public const int ItemTab = 7;

		// Token: 0x0402B4AE RID: 177326
		public const int ItemProgress = 8;

		// Token: 0x0402B4AF RID: 177327
		public const int TextRemainTime = 9;
	}
}
