using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020012B0 RID: 4784
[NullableContext(1)]
[Nullable(0)]
public class ActivityCorniceMeetingRewardItem : UiPanelBase, IGridProxy<ActivityCorniceMeetingRewardItemData>
{
	// Token: 0x17000AE6 RID: 2790
	// (get) Token: 0x06008056 RID: 32854 RVA: 0x0021E6E9 File Offset: 0x0021C8E9
	// (set) Token: 0x06008057 RID: 32855 RVA: 0x0021E6F1 File Offset: 0x0021C8F1
	public IScrollViewDelegate<IGridProxy<ActivityCorniceMeetingRewardItemData>, ActivityCorniceMeetingRewardItemData> ScrollViewDelegate { get; set; }

	// Token: 0x17000AE7 RID: 2791
	// (get) Token: 0x06008058 RID: 32856 RVA: 0x0021E6FA File Offset: 0x0021C8FA
	// (set) Token: 0x06008059 RID: 32857 RVA: 0x0021E702 File Offset: 0x0021C902
	public int GridIndex { get; set; }

	// Token: 0x17000AE8 RID: 2792
	// (get) Token: 0x0600805A RID: 32858 RVA: 0x0021E70B File Offset: 0x0021C90B
	// (set) Token: 0x0600805B RID: 32859 RVA: 0x0021E713 File Offset: 0x0021C913
	public int DisplayIndex { get; set; }

	// Token: 0x0600805C RID: 32860 RVA: 0x0021E71C File Offset: 0x0021C91C
	public object GetKey(ActivityCorniceMeetingRewardItemData data, int gridIndex)
	{
		return null;
	}

	// Token: 0x0600805D RID: 32861 RVA: 0x0021E720 File Offset: 0x0021C920
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickFinishButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600805E RID: 32862 RVA: 0x0021E84C File Offset: 0x0021CA4C
	protected override void OnStart()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(scrollViewWithScrollbar, new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
	}

	// Token: 0x0600805F RID: 32863 RVA: 0x0021E87C File Offset: 0x0021CA7C
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x06008060 RID: 32864 RVA: 0x0021E87E File Offset: 0x0021CA7E
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x06008061 RID: 32865 RVA: 0x0021E880 File Offset: 0x0021CA80
	private CommonItemSmallItemGrid CreatePropItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06008062 RID: 32866 RVA: 0x0021E887 File Offset: 0x0021CA87
	private void OnClickFinishButton()
	{
		Action onClickFinishBtnCb = this.OnClickFinishBtnCb;
		if (onClickFinishBtnCb == null)
		{
			return;
		}
		onClickFinishBtnCb();
	}

	// Token: 0x06008063 RID: 32867 RVA: 0x0021E899 File Offset: 0x0021CA99
	public void Refresh(ActivityCorniceMeetingRewardItemData data, bool isSelected, int gridIndex)
	{
		this.CurrentScore = data.RewardId;
		this.OnClickFinishBtnCb = data.OnClickFinishBtnCb;
		this.RefreshTitle();
		this.RefreshReward();
		this.RefreshContentState();
	}

	// Token: 0x06008064 RID: 32868 RVA: 0x0021E8C5 File Offset: 0x0021CAC5
	public void Clear()
	{
	}

	// Token: 0x06008065 RID: 32869 RVA: 0x0021E8C7 File Offset: 0x0021CAC7
	private void RefreshTitle()
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData().TaskTitleTextId, new <>z__ReadOnlySingleElementList<object>(this.CurrentScore.ToString()));
	}

	// Token: 0x06008066 RID: 32870 RVA: 0x0021E8FC File Offset: 0x0021CAFC
	private void RefreshReward()
	{
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		List<TItem> scoreIndexPreviewItem = currentActivityData.GetScoreIndexPreviewItem(currentActivityData.CurrentSelectLevelPlayId, this.CurrentScore);
		this.RewardScrollView.RefreshByData(scoreIndexPreviewItem, null, false);
	}

	// Token: 0x06008067 RID: 32871 RVA: 0x0021E934 File Offset: 0x0021CB34
	private void RefreshContentState()
	{
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		ECorniceMeetingRewardState rewardState = currentActivityData.GetRewardState(currentActivityData.CurrentSelectLevelPlayId, this.GridIndex);
		base.GetText(2).SetUIActive(false);
		base.GetButton(4).RootUIComp.Get().SetUIActive(false);
		base.GetItem(5).SetUIActive(false);
		base.GetSprite(3).SetUIActive(false);
		if (rewardState == ECorniceMeetingRewardState.Unfinished)
		{
			base.GetText(2).SetUIActive(true);
			return;
		}
		if (rewardState == ECorniceMeetingRewardState.Finished)
		{
			base.GetItem(5).SetUIActive(true);
			base.GetButton(4).RootUIComp.Get().SetUIActive(true);
			return;
		}
		if (rewardState == ECorniceMeetingRewardState.Rewarded)
		{
			base.GetSprite(3).SetUIActive(true);
		}
	}

	// Token: 0x04003D42 RID: 15682
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x04003D43 RID: 15683
	private int CurrentScore;

	// Token: 0x04003D44 RID: 15684
	[Nullable(2)]
	private Action OnClickFinishBtnCb;

	// Token: 0x02007624 RID: 30244
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028B9C RID: 166812
		public const int Title = 0;

		// Token: 0x04028B9D RID: 166813
		public const int ItemScroller = 1;

		// Token: 0x04028B9E RID: 166814
		public const int UnFinishedText = 2;

		// Token: 0x04028B9F RID: 166815
		public const int SprDone = 3;

		// Token: 0x04028BA0 RID: 166816
		public const int FinishButton = 4;

		// Token: 0x04028BA1 RID: 166817
		public const int FinishedItem = 5;
	}
}
