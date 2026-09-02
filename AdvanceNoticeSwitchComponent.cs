using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001199 RID: 4505
[NullableContext(1)]
[Nullable(0)]
public class AdvanceNoticeSwitchComponent
{
	// Token: 0x0600767C RID: 30332 RVA: 0x001F057C File Offset: 0x001EE77C
	public void Initialize(UUIButtonComponent contentLeftArrowButton, UUIButtonComponent contentRightArrowButton, UUIScrollViewWithScrollbarComponent thumbScrollView, UUIItem thumbTemplateItem)
	{
		if (this.IsInitialized)
		{
			return;
		}
		this.IsInitialized = true;
		this.ContentLeftArrowButton = contentLeftArrowButton;
		this.ContentRightArrowButton = contentRightArrowButton;
		this.ThumbScrollViewComponent = thumbScrollView;
		this.ThumbTemplateItem = thumbTemplateItem;
		this.ThumbScrollView = new GenericScrollViewNew<AdvanceNoticeThumbItem, AdvanceNoticeThumbItemData>(this.ThumbScrollViewComponent, new Func<AdvanceNoticeThumbItem>(this.CreateThumbItem), this.ThumbTemplateItem.GetOwner() as AUIBaseActor, false, null);
	}

	// Token: 0x0600767D RID: 30333 RVA: 0x001F05E5 File Offset: 0x001EE7E5
	private AdvanceNoticeThumbItem CreateThumbItem()
	{
		return new AdvanceNoticeThumbItem
		{
			OnItemToggleClickDelegate = new Action<AdvanceNoticeThumbItemData, int>(this.OnThumbItemClicked),
			CanItemToggleChangeDelegate = new Func<AdvanceNoticeThumbItemData, int, bool>(this.CanThumbItemToggleChange)
		};
	}

	// Token: 0x0600767E RID: 30334 RVA: 0x001F0610 File Offset: 0x001EE810
	public void Refresh(AdvanceNoticeViewModel viewModel)
	{
		this.ViewModel = viewModel;
		this.DataCheck();
		GenericScrollViewNew<AdvanceNoticeThumbItem, AdvanceNoticeThumbItemData> thumbScrollView = this.ThumbScrollView;
		if (thumbScrollView != null)
		{
			thumbScrollView.RefreshByData(this.ViewModel.AdvanceNoticeThumbItemDataList, new Action(this.LateScrollTo), false);
		}
		this.RefreshContent();
	}

	// Token: 0x0600767F RID: 30335 RVA: 0x001F0650 File Offset: 0x001EE850
	private void LateScrollTo()
	{
		UUIScrollViewWithScrollbarComponent thumbScrollViewComponent = this.ThumbScrollViewComponent;
		if (thumbScrollViewComponent == null || !thumbScrollViewComponent.IsValid())
		{
			return;
		}
		if (this.ViewModel == null)
		{
			return;
		}
		GenericScrollViewNew<AdvanceNoticeThumbItem, AdvanceNoticeThumbItemData> thumbScrollView = this.ThumbScrollView;
		AdvanceNoticeThumbItem advanceNoticeThumbItem = (thumbScrollView != null) ? thumbScrollView.GetScrollItemByIndex(this.ViewModel.CurrentSubTabIndex) : null;
		if (advanceNoticeThumbItem != null)
		{
			GenericScrollViewNew<AdvanceNoticeThumbItem, AdvanceNoticeThumbItemData> thumbScrollView2 = this.ThumbScrollView;
			if (thumbScrollView2 == null)
			{
				return;
			}
			thumbScrollView2.LateScrollTo(advanceNoticeThumbItem.GetRootItem(), null, false);
		}
	}

	// Token: 0x06007680 RID: 30336 RVA: 0x001F06B7 File Offset: 0x001EE8B7
	public void RefreshContent()
	{
		this.RefreshContentArrowActive();
	}

	// Token: 0x06007681 RID: 30337 RVA: 0x001F06C0 File Offset: 0x001EE8C0
	public void DataCheck()
	{
		if (this.ViewModel == null)
		{
			return;
		}
		List<AdvanceNoticeThumbItemData> advanceNoticeThumbItemDataList = this.ViewModel.AdvanceNoticeThumbItemDataList;
		for (int i = 0; i < advanceNoticeThumbItemDataList.Count; i++)
		{
			advanceNoticeThumbItemDataList[i].IsSelected = (i == this.ViewModel.CurrentSubTabIndex);
		}
	}

	// Token: 0x06007682 RID: 30338 RVA: 0x001F070D File Offset: 0x001EE90D
	private void OnThumbItemClicked(AdvanceNoticeThumbItemData data, int gridIndex)
	{
		if (!this.TabIdCheck(data.TabId))
		{
			return;
		}
		this.SelectThumb(gridIndex);
		AdvanceNoticeViewModel viewModel = this.ViewModel;
		if (viewModel == null)
		{
			return;
		}
		viewModel.ClickTabLogEvent();
	}

	// Token: 0x06007683 RID: 30339 RVA: 0x001F0735 File Offset: 0x001EE935
	private bool CanThumbItemToggleChange(AdvanceNoticeThumbItemData data, int gridIndex)
	{
		return this.TabIdCheck(data.TabId);
	}

	// Token: 0x06007684 RID: 30340 RVA: 0x001F0743 File Offset: 0x001EE943
	private bool TabIdCheck(int tabId)
	{
		return tabId == this.ViewModel.TabId;
	}

	// Token: 0x06007685 RID: 30341 RVA: 0x001F0754 File Offset: 0x001EE954
	public void SelectThumb(int gridIndex)
	{
		if (this.ViewModel == null || !this.CheckIndexInRange(gridIndex))
		{
			return;
		}
		if (this.ViewModel.CurrentSubTabIndex == gridIndex)
		{
			return;
		}
		int currentSubTabIndex = this.ViewModel.CurrentSubTabIndex;
		if (currentSubTabIndex != -1)
		{
			GenericScrollViewNew<AdvanceNoticeThumbItem, AdvanceNoticeThumbItemData> thumbScrollView = this.ThumbScrollView;
			AdvanceNoticeThumbItem advanceNoticeThumbItem = (thumbScrollView != null) ? thumbScrollView.GetScrollItemByIndex(currentSubTabIndex) : null;
			if (advanceNoticeThumbItem != null)
			{
				advanceNoticeThumbItem.RefreshToggleState(false);
			}
		}
		this.ViewModel.CurrentSubTabIndex = gridIndex;
		GenericScrollViewNew<AdvanceNoticeThumbItem, AdvanceNoticeThumbItemData> thumbScrollView2 = this.ThumbScrollView;
		AdvanceNoticeThumbItem advanceNoticeThumbItem2 = (thumbScrollView2 != null) ? thumbScrollView2.GetScrollItemByIndex(gridIndex) : null;
		if (advanceNoticeThumbItem2 != null)
		{
			advanceNoticeThumbItem2.RefreshToggleState(true);
			UUIScrollViewWithScrollbarComponent thumbScrollViewComponent = this.ThumbScrollViewComponent;
			if (thumbScrollViewComponent != null)
			{
				thumbScrollViewComponent.ScrollTo(advanceNoticeThumbItem2.GetRootItem(), true);
			}
		}
		this.RefreshContent();
		this.ViewModel.OnSwitchSubTab(gridIndex);
	}

	// Token: 0x06007686 RID: 30342 RVA: 0x001F0804 File Offset: 0x001EEA04
	public void SelectPreviousThumb()
	{
		if (this.ViewModel == null)
		{
			return;
		}
		this.SelectThumb(this.ViewModel.CurrentSubTabIndex - 1);
	}

	// Token: 0x06007687 RID: 30343 RVA: 0x001F0822 File Offset: 0x001EEA22
	public void SelectNextThumb()
	{
		if (this.ViewModel == null)
		{
			return;
		}
		this.SelectThumb(this.ViewModel.CurrentSubTabIndex + 1);
	}

	// Token: 0x06007688 RID: 30344 RVA: 0x001F0840 File Offset: 0x001EEA40
	public bool CheckIndexInRange(int index)
	{
		return index >= 0 && index < this.ViewModel.AdvanceNoticeThumbItemDataList.Count;
	}

	// Token: 0x06007689 RID: 30345 RVA: 0x001F085C File Offset: 0x001EEA5C
	public void RefreshContentArrowActive()
	{
		if (this.ViewModel == null)
		{
			return;
		}
		int count = this.ViewModel.AdvanceNoticeThumbItemDataList.Count;
		this.ContentLeftArrowButton.RootUIComp.Get().SetUIActive(this.ViewModel.CurrentSubTabIndex > 0);
		this.ContentRightArrowButton.RootUIComp.Get().SetUIActive(this.ViewModel.CurrentSubTabIndex < count - 1);
	}

	// Token: 0x04003950 RID: 14672
	[Nullable(2)]
	private AdvanceNoticeViewModel ViewModel;

	// Token: 0x04003951 RID: 14673
	[Nullable(2)]
	private UUIButtonComponent ContentLeftArrowButton;

	// Token: 0x04003952 RID: 14674
	[Nullable(2)]
	private UUIButtonComponent ContentRightArrowButton;

	// Token: 0x04003953 RID: 14675
	[Nullable(2)]
	private UUIScrollViewWithScrollbarComponent ThumbScrollViewComponent;

	// Token: 0x04003954 RID: 14676
	[Nullable(2)]
	private UUIItem ThumbTemplateItem;

	// Token: 0x04003955 RID: 14677
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<AdvanceNoticeThumbItem, AdvanceNoticeThumbItemData> ThumbScrollView;

	// Token: 0x04003956 RID: 14678
	private bool IsInitialized;
}
