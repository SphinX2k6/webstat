using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001F0E RID: 7950
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryItemGridItem : UiPanelBase
{
	// Token: 0x0600ED73 RID: 60787 RVA: 0x0040BED3 File Offset: 0x0040A0D3
	public HonamiStoryItemGridItem(HonamiStoryItemDataBase itemData)
	{
		this.ItemData = itemData;
	}

	// Token: 0x0600ED74 RID: 60788 RVA: 0x0040BEF0 File Offset: 0x0040A0F0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickedToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600ED75 RID: 60789 RVA: 0x0040C01A File Offset: 0x0040A21A
	protected override void OnStart()
	{
		if (!this.IsForDrag)
		{
			this.DraggableComponent = base.GetExtendToggle(0);
			return;
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetEnable(false);
	}

	// Token: 0x0600ED76 RID: 60790 RVA: 0x0040C044 File Offset: 0x0040A244
	protected override void OnBeforeDestroy()
	{
		this.LockItem = null;
	}

	// Token: 0x0600ED77 RID: 60791 RVA: 0x0040C050 File Offset: 0x0040A250
	[NullableContext(1)]
	public void Refresh(HonamiStoryItemDataBase data, bool needCheckOverflow)
	{
		this.ItemData = data;
		HonamiStoryModel instance = ModelBase<HonamiStoryModel>.Instance;
		UUITexture texture = base.GetTexture(1);
		if (texture == null)
		{
			return;
		}
		bool flag = this.IsForDrag ? data.GetIsDragCross() : data.GetIsCross();
		int baseGridWidth = data.GetBaseGridWidth(flag);
		int baseGridHeight = data.GetBaseGridHeight(flag);
		int num;
		int num2;
		if (this.BackpackType != EHonamiStoryBackpackType.Player)
		{
			EHonamiStoryBackpack backpackId = Singleton<HonamiStoryDefine>.Instance.HonamiBackpackTypeMap[this.BackpackType];
			HonamiStoryBackpackData backPackData = instance.GetBackPackData((int)backpackId, false);
			num = backPackData.GetCellWidth() * baseGridWidth + (baseGridWidth - 1) * backPackData.GetCellHorizontalInterval();
			num2 = backPackData.GetCellHeight() * baseGridHeight + (baseGridHeight - 1) * backPackData.GetCellVerticalInterval();
		}
		else
		{
			HonamiStoryPlayerBackpackData playerBackpackData = instance.GetPlayerBackpackData();
			num = playerBackpackData.GetCellWidth() * baseGridWidth + (baseGridWidth - 1) * playerBackpackData.GetCellHorizontalInterval();
			num2 = playerBackpackData.GetCellHeight() * baseGridHeight + (baseGridHeight - 1) * playerBackpackData.GetCellVerticalInterval();
		}
		this.RootItem.SetWidth((float)num);
		this.RootItem.SetHeight((float)num2);
		texture.SetWidth((float)(flag ? num2 : num));
		texture.SetHeight((float)(flag ? num : num2));
		base.SetTextureShowUntilLoaded(data.GetIconBackpack(), texture, null);
		texture.SetUIActive(true);
		FRotator frotator = flag ? instance.TransRotation : instance.NormalRotation;
		texture.SetUIRelativeRotation(frotator);
		this.RefreshLogicData();
	}

	// Token: 0x0600ED78 RID: 60792 RVA: 0x0040C1AB File Offset: 0x0040A3AB
	[NullableContext(1)]
	public UUIItem GetPanelForHover()
	{
		return base.GetItem(5);
	}

	// Token: 0x0600ED79 RID: 60793 RVA: 0x0040C1B4 File Offset: 0x0040A3B4
	protected void SetLockItemEnable(bool isLock, bool needMask)
	{
		if (this.IsForDrag)
		{
			return;
		}
		HonamiStoryItemLockStateItem lockItem = this.LockItem;
		if (lockItem != null)
		{
			lockItem.SetUiActive(isLock);
		}
		if (this.ItemData != null)
		{
			HonamiStoryItemLockStateItem lockItem2 = this.LockItem;
			if (lockItem2 != null)
			{
				lockItem2.RefreshMask(needMask, this.ItemData, this.BackpackType);
			}
		}
		if (isLock && this.LockItem == null && this.ItemData != null)
		{
			this.LockItem = new HonamiStoryItemLockStateItem();
			this.LockItem.CreateThenShowByResourceIdAsync("UiItem_HonamiStoryItemTagLock", this.RootItem, false).ContinueWith(delegate()
			{
				HonamiStoryItemLockStateItem lockItem3 = this.LockItem;
				if (lockItem3 != null)
				{
					lockItem3.SetUiActive(isLock);
				}
				HonamiStoryItemLockStateItem lockItem4 = this.LockItem;
				if (lockItem4 == null)
				{
					return;
				}
				lockItem4.RefreshMask(needMask, this.ItemData, this.BackpackType);
			});
		}
	}

	// Token: 0x0600ED7A RID: 60794 RVA: 0x0040C274 File Offset: 0x0040A474
	protected void SetSellItemEnable(bool isSell)
	{
		HonamiStoryItemSellAllItem sellItem = this.SellItem;
		if (sellItem != null)
		{
			sellItem.SetUiActive(isSell);
		}
		if (this.ItemData != null)
		{
			HonamiStoryItemSellAllItem sellItem2 = this.SellItem;
			if (sellItem2 != null)
			{
				sellItem2.SetSelected(this.ItemData.GetIsSelected());
			}
		}
		this.SetSellItemValueEnable(isSell);
		if (isSell && this.SellItem == null && this.ItemData != null)
		{
			this.SellItem = new HonamiStoryItemSellAllItem();
			this.SellItem.CreateThenShowByResourceIdAsync("UiItem_HonamiStoryItemTagSell", base.GetItem(2), false).ContinueWith(delegate()
			{
				bool flag = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState() == EHonamiStoryBackpackLogicState.Sell && !this.ItemData.IsLock();
				HonamiStoryItemSellAllItem sellItem3 = this.SellItem;
				if (sellItem3 != null)
				{
					sellItem3.SetUiActive(flag);
				}
				HonamiStoryItemSellAllItem sellItem4 = this.SellItem;
				if (sellItem4 == null)
				{
					return;
				}
				sellItem4.SetSelected(flag && this.ItemData.GetIsSelected());
			});
		}
	}

	// Token: 0x0600ED7B RID: 60795 RVA: 0x0040C308 File Offset: 0x0040A508
	protected void SetSellItemValueEnable(bool isSell)
	{
		HonamiStoryItemSellValueItem sellValueItem = this.SellValueItem;
		if (sellValueItem != null)
		{
			sellValueItem.SetUiActive(isSell);
		}
		if (isSell && this.ItemData != null)
		{
			HonamiStoryItemSellValueItem sellValueItem2 = this.SellValueItem;
			if (sellValueItem2 != null)
			{
				sellValueItem2.Refresh(this.ItemData);
			}
		}
		if (isSell && this.SellItem == null)
		{
			this.SellValueItem = new HonamiStoryItemSellValueItem();
			this.SellValueItem.CreateThenShowByResourceIdAsync("PnlItemCost", base.GetItem(2), false).ContinueWith(delegate()
			{
				bool flag = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState() == EHonamiStoryBackpackLogicState.Sell && this.ItemData != null && !this.ItemData.IsLock();
				HonamiStoryItemSellValueItem sellValueItem3 = this.SellValueItem;
				if (sellValueItem3 != null)
				{
					sellValueItem3.SetUiActive(flag);
				}
				if (flag && this.ItemData != null)
				{
					this.SellValueItem.Refresh(this.ItemData);
				}
			});
		}
	}

	// Token: 0x0600ED7C RID: 60796 RVA: 0x0040C389 File Offset: 0x0040A589
	[NullableContext(1)]
	public UUIItem GetTipsRoot()
	{
		return base.GetItem(4);
	}

	// Token: 0x0600ED7D RID: 60797 RVA: 0x0040C392 File Offset: 0x0040A592
	public HonamiStoryItemDataBase GetData()
	{
		return this.ItemData;
	}

	// Token: 0x0600ED7E RID: 60798 RVA: 0x0040C39A File Offset: 0x0040A59A
	public int GetIncId()
	{
		HonamiStoryItemDataBase itemData = this.ItemData;
		if (itemData == null)
		{
			return -1;
		}
		return itemData.GetIncId();
	}

	// Token: 0x0600ED7F RID: 60799 RVA: 0x0040C3AD File Offset: 0x0040A5AD
	public void SetBackpackType(EHonamiStoryBackpackType type)
	{
		this.BackpackType = type;
	}

	// Token: 0x0600ED80 RID: 60800 RVA: 0x0040C3B6 File Offset: 0x0040A5B6
	public EHonamiStoryBackpackType GetBackpackType()
	{
		return this.BackpackType;
	}

	// Token: 0x0600ED81 RID: 60801 RVA: 0x0040C3C0 File Offset: 0x0040A5C0
	public void SetIsForDrag(bool value)
	{
		this.IsForDrag = value;
		if (value)
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.BackpackType = (HonamiStoryUtil.CheckInHonamiStoryDungeon() ? EHonamiStoryBackpackType.Backpack : EHonamiStoryBackpackType.Inventory);
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetSelfInteractive(false);
			}
			this.DragGridFrame = new HonamiStoryDragItemFrameItem();
			this.DragGridFrame.CreateThenShowByResourceIdAsync("UiItem_HonamiStoryItemDrag", base.GetItem(2), false);
		}
	}

	// Token: 0x0600ED82 RID: 60802 RVA: 0x0040C445 File Offset: 0x0040A645
	public void SetCanOpenTips(bool value)
	{
		this.CanOpenTips = value;
	}

	// Token: 0x0600ED83 RID: 60803 RVA: 0x0040C450 File Offset: 0x0040A650
	public void SetOverFlowEnable(bool enable)
	{
		if (!enable)
		{
			UiPanelBase overflowItem = this.OverflowItem;
			if (overflowItem == null)
			{
				return;
			}
			overflowItem.SetUiActive(false);
			return;
		}
		else
		{
			if (this.OverflowItem == null)
			{
				this.OverflowItem = new UiPanelBase();
				this.OverflowItem.CreateThenShowByResourceIdAsync("UiItem_HonamiStoryItemTagOverflow", base.GetItem(2), false).ContinueWith(delegate()
				{
					HonamiStoryBackpackData backPackData = ModelBase<HonamiStoryModel>.Instance.GetBackPackData(1, false);
					int row = this.ItemData.GetRow();
					int heightCount = backPackData.GetHeightCount(false);
					bool uiActive = row + this.ItemData.GetGridHeight() > heightCount;
					UiPanelBase overflowItem2 = this.OverflowItem;
					if (overflowItem2 == null)
					{
						return;
					}
					overflowItem2.SetUiActive(uiActive);
				});
				return;
			}
			if (!this.OverflowItem.InAsyncLoading())
			{
				this.OverflowItem.SetUiActive(true);
			}
			return;
		}
	}

	// Token: 0x0600ED84 RID: 60804 RVA: 0x0040C4CC File Offset: 0x0040A6CC
	protected virtual void RefreshLogicData()
	{
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		if (this.ItemData != null)
		{
			this.SetLockItemEnable(this.ItemData.IsLock(), backpackLogicState == EHonamiStoryBackpackLogicState.Sell);
		}
		if (backpackLogicState != EHonamiStoryBackpackLogicState.Normal)
		{
			if (backpackLogicState == EHonamiStoryBackpackLogicState.Sell)
			{
				if (this.ItemData != null && this.ItemData.IsLock())
				{
					this.SetSellItemEnable(false);
					return;
				}
				this.SetSellItemEnable(true);
			}
			return;
		}
		this.SetSellItemEnable(false);
		HonamiStoryItemSellAllItem sellItem = this.SellItem;
		if (sellItem == null)
		{
			return;
		}
		sellItem.SetUiActive(false);
	}

	// Token: 0x0600ED85 RID: 60805 RVA: 0x0040C548 File Offset: 0x0040A748
	protected virtual void ExecuteDoubleClickLogic()
	{
		if (this.BackpackType == EHonamiStoryBackpackType.Inventory)
		{
			this.NormalBagDoubleClick();
			return;
		}
		if (this.BackpackType == EHonamiStoryBackpackType.Backpack)
		{
			if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryBackpackView) != null)
			{
				this.NormalBagDoubleClick();
				return;
			}
			if (this.ItemData != null && this.ItemData.IsLock())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_TryDiscardLockItem", Array.Empty<object>());
				return;
			}
			if (this.ItemData != null)
			{
				ModelBase<HonamiStoryModel>.Instance.SetItemIntoBag(this.ItemData, EHonamiStoryBackpack.Backpack, EHonamiStoryBackpack.PickUpBox);
				return;
			}
		}
		else if (this.BackpackType == EHonamiStoryBackpackType.PickUpBox)
		{
			int position = this.ItemData.GetPosition();
			ModelBase<HonamiStoryModel>.Instance.QuickPickUpFromPickUpBox(this.ItemData, position);
		}
	}

	// Token: 0x0600ED86 RID: 60806 RVA: 0x0040C5F4 File Offset: 0x0040A7F4
	protected void NormalBagDoubleClick()
	{
		if (this.ItemData.GetItemType() == EHonamiStoryItemType.Plugin)
		{
			int position = this.ItemData.GetPosition();
			if (!ModelBase<HonamiStoryModel>.Instance.QuickEquipFromBackpack(this.ItemData, position))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_ShowTips_CantQuickEquip", Array.Empty<object>());
				return;
			}
		}
		else
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_CantEquipNormalItem", Array.Empty<object>());
		}
	}

	// Token: 0x0600ED87 RID: 60807 RVA: 0x0040C658 File Offset: 0x0040A858
	protected virtual void DoLogicStateFunc(EHonamiStoryBackpackLogicState state)
	{
		if (state == EHonamiStoryBackpackLogicState.Sell)
		{
			this.DoSellLogic();
			return;
		}
		if (state == EHonamiStoryBackpackLogicState.Tips || state == EHonamiStoryBackpackLogicState.TipsWithPlugins)
		{
			HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
			HonamiStoryItemTipsBase tipsItem = backpackLogic.TipsItem;
			HonamiStoryItemDataBase itemDataOut = tipsItem.GetItemDataOut();
			backpackLogic.CloseTips();
			if (this.ItemData == itemDataOut)
			{
				tipsItem.SetItemDataOut(itemDataOut);
			}
			this.OnClickedToggle(EToggleState.ETT_UnChecked);
			return;
		}
		if (state == EHonamiStoryBackpackLogicState.Instead)
		{
			UUIExtendToggle draggableComponent = this.DraggableComponent;
			if (draggableComponent != null)
			{
				draggableComponent.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
			if (ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().OnClickGrid(this.ItemData, new Action(this.OnTipsCallback), this))
			{
				this.ExecuteDoubleClickLogic();
			}
		}
	}

	// Token: 0x0600ED88 RID: 60808 RVA: 0x0040C6FC File Offset: 0x0040A8FC
	public void DoSellLogic()
	{
		if (this.ItemData.IsLock())
		{
			this.DraggableComponent.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
		ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().RegisterSingleSellItem(this.ItemData);
		this.RefreshLogicData();
		UUIExtendToggle draggableComponent = this.DraggableComponent;
		if (draggableComponent == null)
		{
			return;
		}
		draggableComponent.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600ED89 RID: 60809 RVA: 0x0040C757 File Offset: 0x0040A957
	public void CancelToggleSelect()
	{
		this.DraggableComponent.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600ED8A RID: 60810 RVA: 0x0040C76C File Offset: 0x0040A96C
	public void PlayMoveItemSeq()
	{
		if (!this.IsForDrag || !HonamiStoryUtil.IsMobileView())
		{
			return;
		}
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayOrReplaySequenceByName("MoveUp", false, null);
	}

	// Token: 0x0600ED8B RID: 60811 RVA: 0x0040C7A8 File Offset: 0x0040A9A8
	protected void OnTipsCallback()
	{
		Action onClickedGridTipsCb = this.OnClickedGridTipsCb;
		if (onClickedGridTipsCb == null)
		{
			return;
		}
		onClickedGridTipsCb();
	}

	// Token: 0x0600ED8C RID: 60812 RVA: 0x0040C7BC File Offset: 0x0040A9BC
	protected void OnClickedToggle(EToggleState _)
	{
		if (!this.CanOpenTips)
		{
			this.CancelToggleSelect();
			return;
		}
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		EHonamiStoryBackpackLogicState logicState = backpackLogic.GetLogicState();
		if (logicState == EHonamiStoryBackpackLogicState.Normal)
		{
			if (backpackLogic.OnClickGrid(this.ItemData, new Action(this.OnTipsCallback), this))
			{
				backpackLogic.TipsItem.SetItemDataOut(null);
				this.ExecuteDoubleClickLogic();
			}
			return;
		}
		this.DoLogicStateFunc(logicState);
	}

	// Token: 0x0600ED8D RID: 60813 RVA: 0x0040C822 File Offset: 0x0040AA22
	public void OnHideCallback()
	{
		this.CancelToggleSelect();
	}

	// Token: 0x0600ED8E RID: 60814 RVA: 0x0040C82A File Offset: 0x0040AA2A
	public void SetIsEnable(bool value)
	{
		UUIExtendToggle draggableComponent = this.DraggableComponent;
		if (draggableComponent == null)
		{
			return;
		}
		draggableComponent.SetSelfInteractive(value);
	}

	// Token: 0x04007212 RID: 29202
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04007213 RID: 29203
	public Action OnClickedGridTipsCb;

	// Token: 0x04007214 RID: 29204
	[Nullable(1)]
	public UUIExtendToggle DraggableComponent;

	// Token: 0x04007215 RID: 29205
	protected EHonamiStoryBackpackType BackpackType = EHonamiStoryBackpackType.Backpack;

	// Token: 0x04007216 RID: 29206
	protected HonamiStoryItemLockStateItem LockItem;

	// Token: 0x04007217 RID: 29207
	protected HonamiStoryItemSellAllItem SellItem;

	// Token: 0x04007218 RID: 29208
	protected HonamiStoryItemSellValueItem SellValueItem;

	// Token: 0x04007219 RID: 29209
	protected UiPanelBase OverflowItem;

	// Token: 0x0400721A RID: 29210
	protected HonamiStoryDragItemFrameItem DragGridFrame;

	// Token: 0x0400721B RID: 29211
	private bool IsForDrag;

	// Token: 0x0400721C RID: 29212
	private bool CanOpenTips = true;

	// Token: 0x0400721D RID: 29213
	protected HonamiStoryItemDataBase ItemData;

	// Token: 0x0200826D RID: 33389
	[NullableContext(0)]
	private enum EItem
	{
		// Token: 0x0402C3B0 RID: 181168
		Toggle,
		// Token: 0x0402C3B1 RID: 181169
		TexIcon,
		// Token: 0x0402C3B2 RID: 181170
		PanelState,
		// Token: 0x0402C3B3 RID: 181171
		PanelGrid,
		// Token: 0x0402C3B4 RID: 181172
		PanelTips,
		// Token: 0x0402C3B5 RID: 181173
		PanelOffset
	}
}
