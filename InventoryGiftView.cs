using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200202A RID: 8234
[NullableContext(1)]
[Nullable(0)]
public class InventoryGiftView : UiViewBase
{
	// Token: 0x0600FA58 RID: 64088 RVA: 0x004494A5 File Offset: 0x004476A5
	public InventoryGiftView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FA59 RID: 64089 RVA: 0x004494C4 File Offset: 0x004476C4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickConfirm));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickErrorConfirm));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.ClickClose));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600FA5A RID: 64090 RVA: 0x00449676 File Offset: 0x00447876
	protected void ClickClose()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.InventoryGiftView, null);
	}

	// Token: 0x0600FA5B RID: 64091 RVA: 0x00449688 File Offset: 0x00447888
	protected void OnClickConfirm()
	{
		List<int> list = new List<int>();
		int count = this.SelectedItemList.Count;
		for (int i = 0; i < count; i++)
		{
			list.Add(this.SelectedItemList[i].ItemId);
		}
		InventoryGiftController instance = ControllerBase<InventoryGiftController>.Instance;
		int configId = this.InventoryGiftData.ConfigId;
		NumberSelectComponent numberSelect = this.NumberSelect;
		instance.SendItemGiftUseRequest(configId, (numberSelect != null) ? numberSelect.GetSelectNumber() : 1, list.ToArray());
	}

	// Token: 0x0600FA5C RID: 64092 RVA: 0x004496F8 File Offset: 0x004478F8
	protected void OnClickErrorConfirm()
	{
		int availableNum = this.InventoryGiftData.GiftPackage.AvailableNum;
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("SelectGiftItem", new object[]
		{
			availableNum
		});
	}

	// Token: 0x0600FA5D RID: 64093 RVA: 0x00449734 File Offset: 0x00447934
	protected override void OnStart()
	{
		this.InventoryGiftData = (this.OpenParam as InventoryGiftData);
		this.ItemList = this.InventoryGiftData.ItemList;
		this.LoopScrollView = new LoopScrollView<InventoryGiftItem, GiftItemData>(base.GetLoopScrollViewComponent(3), base.GetItem(4).GetOwner() as AUIBaseActor, new Func<InventoryGiftItem>(this.InitItem), false);
		this.LoopScrollView.ReloadProxyData(new Func<int, GiftItemData>(this.GetScrollViewData), this.ItemList.Length, false, false);
		this.ConfirmButton = base.GetButton(1);
		this.ConfirmErrorButton = base.GetButton(2);
		this.ConfirmButtonInteractionGroup = (this.ConfirmButton.GetOwner().GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup);
		this.DescText = base.GetText(5);
		this.TitleText = base.GetText(0);
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.InventoryGiftData.ConfigId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TitleText, itemConfigData.Name, Array.Empty<object>());
		this.NumberSelect = new NumberSelectComponent(base.GetItem(7));
		INumberSelectData numberSelectData = new INumberSelectData();
		numberSelectData.MaxNumber = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.InventoryGiftData.ConfigId, 0);
		numberSelectData.GetExchangeTableText = new Func<int, TableTextArgNew>(this.GetExchangeTableText);
		numberSelectData.ValueChangeFunction = delegate(int _)
		{
		};
		INumberSelectData data = numberSelectData;
		if (this.CheckIfGiftItem())
		{
			this.NumberSelect.SetLimitMaxValue(ConfigBase<CommonConfig>.Instance.GetGiftMaxNineNineNine());
		}
		this.NumberSelect.Init(data);
		if (this.InventoryGiftData.InitializedSelectedId != null)
		{
			for (int i = 0; i < this.ItemList.Length; i++)
			{
				GiftItemData giftItemData = this.ItemList[i];
				int itemId = giftItemData.ItemId;
				int? initializedSelectedId = this.InventoryGiftData.InitializedSelectedId;
				if (itemId == initializedSelectedId.GetValueOrDefault() & initializedSelectedId != null)
				{
					this.SelectedItemList.Add(giftItemData);
					this.LoopScrollView.ScrollToGridIndex(i, false);
					this.LoopScrollView.SelectGridProxy(i, true);
					break;
				}
			}
		}
		if (this.InventoryGiftData.SelectedCount != null)
		{
			this.NumberSelect.ChangeValue(this.InventoryGiftData.SelectedCount.Value, true);
		}
		this.RefreshSelectCountInfo();
	}

	// Token: 0x0600FA5E RID: 64094 RVA: 0x00449984 File Offset: 0x00447B84
	private bool CheckIfGiftItem()
	{
		int configId = this.InventoryGiftData.ConfigId;
		if (configId == 0)
		{
			return false;
		}
		InventoryDefine.EItemType? itemType = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(configId).ItemType;
		return itemType.GetValueOrDefault() == InventoryDefine.EItemType.Gift;
	}

	// Token: 0x0600FA5F RID: 64095 RVA: 0x004499BE File Offset: 0x00447BBE
	private TableTextArgNew GetExchangeTableText(int selectValue)
	{
		return new TableTextArgNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("ItemUseCount"), new <>z__ReadOnlySingleElementList<object>(selectValue));
	}

	// Token: 0x0600FA60 RID: 64096 RVA: 0x004499E0 File Offset: 0x00447BE0
	protected override void OnAfterShow()
	{
		if (this.InventoryGiftData == null)
		{
			this.SetConfirmButtonState(false);
			return;
		}
		int availableNum = this.InventoryGiftData.GiftPackage.AvailableNum;
		bool confirmButtonState = this.SelectedItemList.Count == availableNum;
		this.SetConfirmButtonState(confirmButtonState);
	}

	// Token: 0x0600FA61 RID: 64097 RVA: 0x00449A24 File Offset: 0x00447C24
	protected override void OnAfterHide()
	{
		Singleton<UiBlurLogic>.Instance.ResumeTopUiRenderAfterBlur();
	}

	// Token: 0x0600FA62 RID: 64098 RVA: 0x00449A30 File Offset: 0x00447C30
	protected override void OnBeforeDestroy()
	{
		this.LoopScrollView = null;
		this.ItemList = Array.Empty<GiftItemData>();
		this.SelectedItemList = new List<GiftItemData>();
		this.InventoryGiftData = null;
		this.ConfirmButtonInteractionGroup = null;
		this.ConfirmButton = null;
		this.ConfirmErrorButton = null;
		this.DescText = null;
		this.TitleText = null;
		NumberSelectComponent numberSelect = this.NumberSelect;
		if (numberSelect != null)
		{
			numberSelect.Destroy(null);
		}
		this.NumberSelect = null;
	}

	// Token: 0x0600FA63 RID: 64099 RVA: 0x00449AA0 File Offset: 0x00447CA0
	private InventoryGiftItem InitItem()
	{
		InventoryGiftItem inventoryGiftItem = new InventoryGiftItem();
		inventoryGiftItem.Initialize(null);
		inventoryGiftItem.SetOnToggleStateChangeFunction(new Action<UUIExtendToggle, UUIButtonComponent, bool, GiftItemData>(this.OnToggleStateChangeFunction));
		inventoryGiftItem.SetOnReduceFunction(new Action<GiftItemData>(this.OnReduceFunction));
		inventoryGiftItem.SetIsSelectOn(new Func<GiftItemData, bool>(this.OnIsSelectOnFunction));
		return inventoryGiftItem;
	}

	// Token: 0x0600FA64 RID: 64100 RVA: 0x00449AEF File Offset: 0x00447CEF
	private GiftItemData GetScrollViewData(int gridIndex)
	{
		return this.ItemList[gridIndex];
	}

	// Token: 0x0600FA65 RID: 64101 RVA: 0x00449AFC File Offset: 0x00447CFC
	protected void OnToggleStateChangeFunction(UUIExtendToggle toggle, UUIButtonComponent reduceButton, bool isSelected, GiftItemData itemData)
	{
		int availableNum = this.InventoryGiftData.GiftPackage.AvailableNum;
		if (isSelected)
		{
			if (this.SelectedItemList.Count == availableNum)
			{
				GiftItemData obj = this.SelectedItemList[0];
				this.SelectedItemList.RemoveAt(0);
				LoopScrollView<InventoryGiftItem, GiftItemData> loopScrollView = this.LoopScrollView;
				if (loopScrollView != null)
				{
					InventoryGiftItem inventoryGiftItem = loopScrollView.UnsafeGetGridProxy(this.ItemList.IndexOf(obj), false);
					if (inventoryGiftItem != null)
					{
						inventoryGiftItem.RefreshSelectState();
					}
				}
			}
			this.SelectedItemList.Add(itemData);
		}
		else
		{
			int index = this.SelectedItemList.IndexOf(itemData);
			this.SelectedItemList.RemoveAt(index);
		}
		this.RefreshSelectCountInfo();
	}

	// Token: 0x0600FA66 RID: 64102 RVA: 0x00449B9C File Offset: 0x00447D9C
	protected void OnReduceFunction(GiftItemData itemData)
	{
		int num = this.SelectedItemList.IndexOf(itemData);
		if (num == -1)
		{
			return;
		}
		this.SelectedItemList.RemoveAt(num);
		this.RefreshSelectCountInfo();
	}

	// Token: 0x0600FA67 RID: 64103 RVA: 0x00449BCD File Offset: 0x00447DCD
	protected bool OnIsSelectOnFunction(GiftItemData itemData)
	{
		return this.SelectedItemList.Contains(itemData);
	}

	// Token: 0x0600FA68 RID: 64104 RVA: 0x00449BDC File Offset: 0x00447DDC
	protected void RefreshSelectCountInfo()
	{
		int availableNum = this.InventoryGiftData.GiftPackage.AvailableNum;
		int count = this.SelectedItemList.Count;
		Singleton<LguiUtil>.Instance.SetLocalText(this.DescText, "SelectRewardFromPool", new <>z__ReadOnlyArray<object>(new object[]
		{
			availableNum,
			count,
			availableNum
		}));
		bool confirmButtonState = count == availableNum;
		this.SetConfirmButtonState(confirmButtonState);
	}

	// Token: 0x0600FA69 RID: 64105 RVA: 0x00449C50 File Offset: 0x00447E50
	private void SetConfirmButtonState(bool isShow)
	{
		this.ConfirmButtonInteractionGroup.SetInteractable(isShow);
		this.ConfirmErrorButton.RootUIComp.Get().SetUIActive(!isShow);
	}

	// Token: 0x04007839 RID: 30777
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<InventoryGiftItem, GiftItemData> LoopScrollView;

	// Token: 0x0400783A RID: 30778
	private GiftItemData[] ItemList = Array.Empty<GiftItemData>();

	// Token: 0x0400783B RID: 30779
	private List<GiftItemData> SelectedItemList = new List<GiftItemData>();

	// Token: 0x0400783C RID: 30780
	[Nullable(2)]
	private InventoryGiftData InventoryGiftData;

	// Token: 0x0400783D RID: 30781
	[Nullable(2)]
	private UUIInteractionGroup ConfirmButtonInteractionGroup;

	// Token: 0x0400783E RID: 30782
	[Nullable(2)]
	private UUIButtonComponent ConfirmButton;

	// Token: 0x0400783F RID: 30783
	[Nullable(2)]
	private UUIButtonComponent ConfirmErrorButton;

	// Token: 0x04007840 RID: 30784
	[Nullable(2)]
	private UUIText DescText;

	// Token: 0x04007841 RID: 30785
	[Nullable(2)]
	private UUIText TitleText;

	// Token: 0x04007842 RID: 30786
	[Nullable(2)]
	private NumberSelectComponent NumberSelect;

	// Token: 0x020083D0 RID: 33744
	[NullableContext(0)]
	private enum EInventoryGiftViewDefine
	{
		// Token: 0x0402CB09 RID: 183049
		TitleText,
		// Token: 0x0402CB0A RID: 183050
		ConfirmButton,
		// Token: 0x0402CB0B RID: 183051
		ConfirmErrorButton,
		// Token: 0x0402CB0C RID: 183052
		LoopScrollView,
		// Token: 0x0402CB0D RID: 183053
		LoopScrollItem,
		// Token: 0x0402CB0E RID: 183054
		DescText,
		// Token: 0x0402CB0F RID: 183055
		CancelButton,
		// Token: 0x0402CB10 RID: 183056
		NumberSelect
	}
}
