using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001719 RID: 5913
[NullableContext(1)]
[Nullable(0)]
public class WuWuLogisticsMissionItem : GridProxyAbstract<int>
{
	// Token: 0x0600A453 RID: 42067 RVA: 0x002B6F34 File Offset: 0x002B5134
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
	}

	// Token: 0x0600A454 RID: 42068 RVA: 0x002B6FFC File Offset: 0x002B51FC
	protected override void OnStart()
	{
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(2), new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, null);
		this.ConfirmQuick = new ButtonItem(base.GetButton(6).RootUIComp);
		this.ConfirmQuick.SetFunction(new Action<int>(this.OnClickReceive));
	}

	// Token: 0x0600A455 RID: 42069 RVA: 0x002B705D File Offset: 0x002B525D
	public void SetClickCallback(Action<int> callback)
	{
		this.ClickCallback = callback;
	}

	// Token: 0x0600A456 RID: 42070 RVA: 0x002B7066 File Offset: 0x002B5266
	private CommonItemSmallItemGrid InitGridItem()
	{
		return new CommonItemSmallItemGrid
		{
			ShowReceivedCallBack = ((TItem _) => this.IsHadReward)
		};
	}

	// Token: 0x0600A457 RID: 42071 RVA: 0x002B7080 File Offset: 0x002B5280
	public override void Refresh(int taskId, bool isSelected, int gridIndex)
	{
		this.TaskId = taskId;
		this.IsHadReward = false;
		WuWuWeekTask? weekTaskById = ConfigBase<WuWuLogisticsConfig>.Instance.GetWeekTaskById(taskId);
		if (weekTaskById == null)
		{
			return;
		}
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.ShowTextNew(weekTaskById.Value.Title);
		}
		int activityId = ControllerBase<WuWuLogisticsActivityController>.Instance.ActivityId;
		WuWuLogisticsActivityData wuWuLogisticsActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as WuWuLogisticsActivityData;
		WuWuTaskData wuWuTaskData = (wuWuLogisticsActivityData != null) ? wuWuLogisticsActivityData.GetTaskById(taskId) : null;
		if (wuWuTaskData == null)
		{
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.SetUIActive(false);
			}
			this.UpdateStateInfoItem(EWuWuTaskState.Running);
			this.RefreshRewardItems(weekTaskById.Value.DropId);
			return;
		}
		this.IsHadReward = wuWuTaskData.IsRewarded;
		this.RefreshRewardItems(weekTaskById.Value.DropId);
		int progress = wuWuTaskData.Progress;
		int targetProgress = wuWuTaskData.TargetProgress;
		string conditionProgress = this.GetConditionProgress((EWuWuTaskConditionProgressShowType)weekTaskById.Value.ProgressType, progress, targetProgress);
		UUIText text3 = base.GetText(1);
		if (text3 != null)
		{
			text3.SetUIActive(true);
		}
		UUIText text4 = base.GetText(1);
		if (text4 != null)
		{
			text4.SetText(conditionProgress, true);
		}
		this.UpdateStateInfoItem(wuWuTaskData.State);
	}

	// Token: 0x0600A458 RID: 42072 RVA: 0x002B71B0 File Offset: 0x002B53B0
	private void UpdateStateInfoItem(EWuWuTaskState state)
	{
		bool uiactive = state == EWuWuTaskState.Running;
		bool flag = state == EWuWuTaskState.Finish;
		bool flag2 = state == EWuWuTaskState.Taken;
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(uiactive);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 != null)
		{
			item2.SetUIActive(flag || flag2);
		}
		UUIItem item3 = base.GetItem(7);
		if (item3 != null)
		{
			item3.SetUIActive(flag2);
		}
		UUIButtonComponent button = base.GetButton(6);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag);
		}
		ButtonItem confirmQuick = this.ConfirmQuick;
		if (confirmQuick == null)
		{
			return;
		}
		confirmQuick.SetRedDotVisible(flag);
	}

	// Token: 0x0600A459 RID: 42073 RVA: 0x002B7238 File Offset: 0x002B5438
	[NullableContext(2)]
	private string GetConditionProgress(EWuWuTaskConditionProgressShowType type, int progress, int target)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (type == EWuWuTaskConditionProgressShowType.ShowCompleteCount)
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(progress);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		if (type != EWuWuTaskConditionProgressShowType.ShowTargetConditionProgress)
		{
			return null;
		}
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(progress);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(target);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600A45A RID: 42074 RVA: 0x002B7298 File Offset: 0x002B5498
	private void RefreshRewardItems(int dropId)
	{
		if (dropId <= 0)
		{
			return;
		}
		List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(dropId);
		GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScrollView = this.RewardScrollView;
		if (rewardScrollView == null)
		{
			return;
		}
		rewardScrollView.RefreshByData(dropPackagePreviewItemList, null, false);
	}

	// Token: 0x0600A45B RID: 42075 RVA: 0x002B72C9 File Offset: 0x002B54C9
	private void OnClickReceive(int data)
	{
		Action<int> clickCallback = this.ClickCallback;
		if (clickCallback == null)
		{
			return;
		}
		clickCallback(this.TaskId);
	}

	// Token: 0x04004E05 RID: 19973
	private int TaskId;

	// Token: 0x04004E06 RID: 19974
	private Action<int> ClickCallback = delegate(int _)
	{
	};

	// Token: 0x04004E07 RID: 19975
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x04004E08 RID: 19976
	[Nullable(2)]
	protected ButtonItem ConfirmQuick;

	// Token: 0x04004E09 RID: 19977
	private bool IsHadReward;
}
