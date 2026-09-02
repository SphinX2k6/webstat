using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200158B RID: 5515
public class ActivityRunItem : UiPanelBase, IGridProxy<int>
{
	// Token: 0x17000D31 RID: 3377
	// (get) Token: 0x06009B1B RID: 39707 RVA: 0x00289F17 File Offset: 0x00288117
	// (set) Token: 0x06009B1C RID: 39708 RVA: 0x00289F1F File Offset: 0x0028811F
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IScrollViewDelegate<IGridProxy<int>, int> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17000D32 RID: 3378
	// (get) Token: 0x06009B1D RID: 39709 RVA: 0x00289F28 File Offset: 0x00288128
	// (set) Token: 0x06009B1E RID: 39710 RVA: 0x00289F30 File Offset: 0x00288130
	public int GridIndex { get; set; }

	// Token: 0x17000D33 RID: 3379
	// (get) Token: 0x06009B1F RID: 39711 RVA: 0x00289F39 File Offset: 0x00288139
	// (set) Token: 0x06009B20 RID: 39712 RVA: 0x00289F41 File Offset: 0x00288141
	public int DisplayIndex { get; set; }

	// Token: 0x06009B21 RID: 39713 RVA: 0x00289F4A File Offset: 0x0028814A
	[NullableContext(1)]
	public object GetKey(int data, int gridIndex)
	{
		return null;
	}

	// Token: 0x06009B22 RID: 39714 RVA: 0x00289F50 File Offset: 0x00288150
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

	// Token: 0x06009B23 RID: 39715 RVA: 0x0028A07C File Offset: 0x0028827C
	protected override void OnStart()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(scrollViewWithScrollbar, new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
		this.AddEventListener();
	}

	// Token: 0x06009B24 RID: 39716 RVA: 0x0028A0B2 File Offset: 0x002882B2
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnGetRunActivityReward, new Action<int>(this.OnGetRunActivityReward));
	}

	// Token: 0x06009B25 RID: 39717 RVA: 0x0028A0D0 File Offset: 0x002882D0
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnGetRunActivityReward, new Action<int>(this.OnGetRunActivityReward));
	}

	// Token: 0x06009B26 RID: 39718 RVA: 0x0028A0EE File Offset: 0x002882EE
	private void OnGetRunActivityReward(int score)
	{
		if (score == this.CurrentScore)
		{
			this.RefreshContentState();
		}
	}

	// Token: 0x06009B27 RID: 39719 RVA: 0x0028A0FF File Offset: 0x002882FF
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x06009B28 RID: 39720 RVA: 0x0028A101 File Offset: 0x00288301
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x06009B29 RID: 39721 RVA: 0x0028A103 File Offset: 0x00288303
	[NullableContext(1)]
	private CommonItemSmallItemGrid CreatePropItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06009B2A RID: 39722 RVA: 0x0028A10C File Offset: 0x0028830C
	private void OnClickFinishButton()
	{
		int scoreIndex = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId).GetScoreIndex(this.CurrentScore);
		ControllerBase<ActivityRunController>.Instance.RequestTakeChallengeReward(ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId, scoreIndex);
	}

	// Token: 0x06009B2B RID: 39723 RVA: 0x0028A14E File Offset: 0x0028834E
	public void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.CurrentScore = data;
		this.RefreshTitle();
		this.RefreshReward();
		this.RefreshContentState();
	}

	// Token: 0x06009B2C RID: 39724 RVA: 0x0028A169 File Offset: 0x00288369
	public void Clear()
	{
	}

	// Token: 0x06009B2D RID: 39725 RVA: 0x0028A16B File Offset: 0x0028836B
	private void RefreshTitle()
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "ActivityRunPointNeed", new <>z__ReadOnlySingleElementList<object>(this.CurrentScore.ToString()));
	}

	// Token: 0x06009B2E RID: 39726 RVA: 0x0028A194 File Offset: 0x00288394
	private void RefreshReward()
	{
		ActivityRunData activityRunData = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId);
		int scoreIndex = activityRunData.GetScoreIndex(this.CurrentScore);
		List<TItem> scoreIndexPreviewItem = activityRunData.GetScoreIndexPreviewItem(scoreIndex);
		this.RewardScrollView.RefreshByData(scoreIndexPreviewItem, null, false);
	}

	// Token: 0x06009B2F RID: 39727 RVA: 0x0028A1D8 File Offset: 0x002883D8
	private void RefreshContentState()
	{
		ActivityRunData activityRunData = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId);
		EActivityRunStateEnum scoreIndexCannotGetReward = activityRunData.GetScoreIndexCannotGetReward(activityRunData.GetScoreIndex(this.CurrentScore));
		base.GetText(2).SetUIActive(false);
		UUIItem uuiitem = base.GetButton(4).RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(false);
		}
		base.GetItem(5).SetUIActive(false);
		base.GetSprite(3).SetUIActive(false);
		if (scoreIndexCannotGetReward == EActivityRunStateEnum.UnFinished)
		{
			base.GetText(2).SetUIActive(true);
			return;
		}
		if (scoreIndexCannotGetReward != EActivityRunStateEnum.CanGetReward)
		{
			if (scoreIndexCannotGetReward == EActivityRunStateEnum.HaveGetReward)
			{
				base.GetSprite(3).SetUIActive(true);
			}
			return;
		}
		base.GetItem(5).SetUIActive(true);
		UUIItem uuiitem2 = base.GetButton(4).RootUIComp.Get();
		if (uuiitem2 == null)
		{
			return;
		}
		uuiitem2.SetUIActive(true);
	}

	// Token: 0x06009B30 RID: 39728 RVA: 0x0028A2A5 File Offset: 0x002884A5
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
	}

	// Token: 0x0400476A RID: 18282
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x0400476B RID: 18283
	private int CurrentScore;

	// Token: 0x02007953 RID: 31059
	private class EComponents
	{
		// Token: 0x04029ADB RID: 170715
		public const int Title = 0;

		// Token: 0x04029ADC RID: 170716
		public const int ItemScroller = 1;

		// Token: 0x04029ADD RID: 170717
		public const int UnFinishedText = 2;

		// Token: 0x04029ADE RID: 170718
		public const int SprDone = 3;

		// Token: 0x04029ADF RID: 170719
		public const int FinishButton = 4;

		// Token: 0x04029AE0 RID: 170720
		public const int FinishedItem = 5;
	}
}
