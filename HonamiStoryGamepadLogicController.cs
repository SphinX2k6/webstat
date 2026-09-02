using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001EED RID: 7917
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryGamepadLogicController
{
	// Token: 0x0600EA8B RID: 60043 RVA: 0x003F9CC7 File Offset: 0x003F7EC7
	public void InitInteract(UUIItem attachPanel)
	{
		if (this.InteractController == null)
		{
			this.InteractController = new HonamiStoryGamepadInteractController();
		}
	}

	// Token: 0x0600EA8C RID: 60044 RVA: 0x003F9CDC File Offset: 0x003F7EDC
	public void RegisterPanel(HonamiStoryBackpackPanelBase panel)
	{
		this.InteractController.RegisterPanel(panel);
	}

	// Token: 0x0600EA8D RID: 60045 RVA: 0x003F9CEA File Offset: 0x003F7EEA
	public void RegisterBtnToGrid(UUIItem btnItem, HonamiStoryGridItemBase gridItem)
	{
		this.BtnMap[btnItem] = gridItem;
	}

	// Token: 0x0600EA8E RID: 60046 RVA: 0x003F9CF9 File Offset: 0x003F7EF9
	public void RegisterItemToGrid(UUIItem realItem, HonamiStoryGridItemBase gridItem)
	{
		this.ItemToGridMap[realItem] = gridItem;
	}

	// Token: 0x0600EA8F RID: 60047 RVA: 0x003F9D08 File Offset: 0x003F7F08
	[NullableContext(2)]
	public void SetCurItem(HonamiStoryItemGridItem item)
	{
		this.CurItem = item;
		int? num;
		if (item == null)
		{
			num = null;
		}
		else
		{
			HonamiStoryItemDataBase data = item.GetData();
			num = ((data != null) ? new int?(data.GetIncId()) : null);
		}
		int? num2 = num;
		this.CurItemDataId = num2.GetValueOrDefault(-1);
	}

	// Token: 0x0600EA90 RID: 60048 RVA: 0x003F9D58 File Offset: 0x003F7F58
	public void SetScrollingPosition(int position)
	{
		this.CurScrollingPosition = position;
	}

	// Token: 0x0600EA91 RID: 60049 RVA: 0x003F9D61 File Offset: 0x003F7F61
	[NullableContext(2)]
	public HonamiStoryItemGridItem GetCurItem()
	{
		return this.CurItem;
	}

	// Token: 0x0600EA92 RID: 60050 RVA: 0x003F9D69 File Offset: 0x003F7F69
	[NullableContext(2)]
	public HonamiStoryItemGridItem GetSelectItem()
	{
		return null;
	}

	// Token: 0x0600EA93 RID: 60051 RVA: 0x003F9D6C File Offset: 0x003F7F6C
	public int GetScrollingPosition()
	{
		return this.CurScrollingPosition;
	}

	// Token: 0x0600EA94 RID: 60052 RVA: 0x003F9D74 File Offset: 0x003F7F74
	[return: Nullable(2)]
	public HonamiStoryGridItemBase GetGridItemByAnyItem(UUIItem anyItem)
	{
		HonamiStoryGridItemBase honamiStoryGridItemBase = null;
		this.BtnMap.TryGetValue(anyItem, out honamiStoryGridItemBase);
		if (honamiStoryGridItemBase == null)
		{
			this.ItemToGridMap.TryGetValue(anyItem, out honamiStoryGridItemBase);
		}
		return honamiStoryGridItemBase;
	}

	// Token: 0x0600EA95 RID: 60053 RVA: 0x003F9DA8 File Offset: 0x003F7FA8
	[return: Nullable(2)]
	public HonamiStoryGridItemBase GetGridItemByBtnItem(UUIItem btnItem)
	{
		HonamiStoryGridItemBase result;
		if (this.BtnMap.TryGetValue(btnItem, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600EA96 RID: 60054 RVA: 0x003F9DC8 File Offset: 0x003F7FC8
	public int GetCurPanelIndex()
	{
		return this.CurPanelIndex;
	}

	// Token: 0x0600EA97 RID: 60055 RVA: 0x003F9DD0 File Offset: 0x003F7FD0
	public HonamiStoryGamepadInteractController GetInteractController()
	{
		return this.InteractController;
	}

	// Token: 0x0600EA98 RID: 60056 RVA: 0x003F9DD8 File Offset: 0x003F7FD8
	public int GetBackpackTypeByPanelIndex(int index)
	{
		int result = -1;
		if (index == 1)
		{
			result = 3;
		}
		else if (index == 2)
		{
			result = ((this.IsInGame() > false) ? 1 : 0);
		}
		else if (index == 3)
		{
			result = 2;
		}
		return result;
	}

	// Token: 0x0600EA99 RID: 60057 RVA: 0x003F9E06 File Offset: 0x003F8006
	public bool IsInGame()
	{
		return HonamiStoryUtil.CheckInHonamiStoryDungeon();
	}

	// Token: 0x0600EA9A RID: 60058 RVA: 0x003F9E10 File Offset: 0x003F8010
	[NullableContext(0)]
	private ValueTuple<int, bool> GetMousePositionNearlyPanelData()
	{
		Vector2D mouseViewportPosition = ControllerBase<UiNavigationNewController>.Instance.GetMouseViewportPosition();
		if (mouseViewportPosition == null)
		{
			return new ValueTuple<int, bool>(-1, false);
		}
		int count = this.InteractController.PanelBaseList.Count;
		int item = -1;
		bool item2 = false;
		for (int i = 0; i < count; i++)
		{
			HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase = this.InteractController.PanelBaseList[i];
			this.TempPivot.Set(0.0, 0.0);
			UUIItem rootItem = honamiStoryBackpackPanelBase.GetRootItem();
			bool bIsScaledByDPI = true;
			FVector2D fvector2D = this.TempPivot.ToUeVector2D(false);
			FVector2D positionInViewportWithPivot = rootItem.GetPositionInViewportWithPivot(bIsScaledByDPI, fvector2D);
			this.TempPivot.Set(1.0, 1.0);
			UUIItem rootItem2 = honamiStoryBackpackPanelBase.GetRootItem();
			bool bIsScaledByDPI2 = true;
			fvector2D = this.TempPivot.ToUeVector2D(false);
			FVector2D positionInViewportWithPivot2 = rootItem2.GetPositionInViewportWithPivot(bIsScaledByDPI2, fvector2D);
			if (mouseViewportPosition.X < (double)positionInViewportWithPivot.X)
			{
				break;
			}
			item2 = (mouseViewportPosition.X <= (double)positionInViewportWithPivot2.X);
			item = i;
		}
		return new ValueTuple<int, bool>(item, item2);
	}

	// Token: 0x0600EA9B RID: 60059 RVA: 0x003F9F14 File Offset: 0x003F8114
	public void JumpToPrevPanelNew()
	{
		ValueTuple<int, bool> mousePositionNearlyPanelData = this.GetMousePositionNearlyPanelData();
		int item = mousePositionNearlyPanelData.Item1;
		int index;
		if (mousePositionNearlyPanelData.Item2)
		{
			index = ((item - 1 < 0) ? (this.InteractController.PanelBaseList.Count - 1) : (item - 1));
		}
		else
		{
			index = ((item < 0) ? (this.InteractController.PanelBaseList.Count - 1) : item);
		}
		HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase = this.InteractController.PanelBaseList[index];
		if (honamiStoryBackpackPanelBase != null)
		{
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationMousePositionForView(honamiStoryBackpackPanelBase.GetRootItem());
		}
	}

	// Token: 0x0600EA9C RID: 60060 RVA: 0x003F9F98 File Offset: 0x003F8198
	public void JumpToNextPanelNew()
	{
		int item = this.GetMousePositionNearlyPanelData().Item1;
		int index = (item + 1 > this.InteractController.PanelBaseList.Count - 1) ? 0 : (item + 1);
		HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase = this.InteractController.PanelBaseList[index];
		if (honamiStoryBackpackPanelBase != null)
		{
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationMousePositionForView(honamiStoryBackpackPanelBase.GetRootItem());
		}
	}

	// Token: 0x0600EA9D RID: 60061 RVA: 0x003F9FF4 File Offset: 0x003F81F4
	public void SetPanelIndexByGridItem(HonamiStoryGridItemBase gridItem)
	{
		this.CurPanelIndex = this.InteractController.GetPanelIndexByGridItem(gridItem);
		HonamiStoryItemDataBase data = gridItem.GetData();
		if (data != null)
		{
			this.CurPosition = data.GetPosition();
			return;
		}
		this.CurPosition = gridItem.GetEmptyPosition();
	}

	// Token: 0x0600EA9E RID: 60062 RVA: 0x003FA038 File Offset: 0x003F8238
	public void SetFocusByGridItem(HonamiStoryGridItemBase gridItem)
	{
		if (gridItem.Data == null)
		{
			return;
		}
		if (gridItem.Data.GetIncId() != this.CurItemDataId)
		{
			return;
		}
		UUIItem btnItem = gridItem.GetBtnItem();
		if (btnItem != null)
		{
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationMousePositionForView(btnItem);
		}
	}

	// Token: 0x0600EA9F RID: 60063 RVA: 0x003FA078 File Offset: 0x003F8278
	private HonamiStoryGridItemBase FindSuitableGridByItemList(List<HonamiStoryGridItemBase> list)
	{
		HonamiStoryGridItemBase result = list[0];
		foreach (HonamiStoryGridItemBase honamiStoryGridItemBase in list)
		{
			if (honamiStoryGridItemBase.GetItemGridItem() != null)
			{
				result = honamiStoryGridItemBase;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600EAA0 RID: 60064 RVA: 0x003FA0D4 File Offset: 0x003F82D4
	public void SetFocusByCurPanelIndex()
	{
		int backpackTypeByPanelIndex = this.GetBackpackTypeByPanelIndex(this.CurPanelIndex);
		HonamiStoryGridItemBase focusByGridItem;
		if (this.JumpMap.TryGetValue(this.CurPanelIndex, out focusByGridItem))
		{
			this.SetFocusByGridItem(focusByGridItem);
			return;
		}
		List<HonamiStoryGridItemBase> gridItemListByBackpackType = this.InteractController.GetGridItemListByBackpackType(backpackTypeByPanelIndex);
		HonamiStoryGridItemBase honamiStoryGridItemBase = this.FindSuitableGridByItemList(gridItemListByBackpackType);
		if (honamiStoryGridItemBase != null)
		{
			this.SetFocusByGridItem(honamiStoryGridItemBase);
		}
	}

	// Token: 0x0600EAA1 RID: 60065 RVA: 0x003FA12A File Offset: 0x003F832A
	public void PickUp(HonamiStoryGridItemBase targetItem)
	{
		this.CurSelectItem = targetItem.GetItemGridItem();
		this.InteractController.OnPickUp(targetItem);
	}

	// Token: 0x0600EAA2 RID: 60066 RVA: 0x003FA144 File Offset: 0x003F8344
	public void PutDown(HonamiStoryGridItemBase targetItem)
	{
		this.InteractController.OnPutDown(targetItem);
		this.CurSelectItem = null;
	}

	// Token: 0x0600EAA3 RID: 60067 RVA: 0x003FA15C File Offset: 0x003F835C
	private void HideAllTips()
	{
		HonamiStoryBackpackView honamiStoryBackpackView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryBackpackView) as HonamiStoryBackpackView;
		if (honamiStoryBackpackView != null)
		{
			honamiStoryBackpackView.HideAllTips();
		}
		HonamiStoryPickUpBackpackView honamiStoryPickUpBackpackView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryPickUpBackpackView) as HonamiStoryPickUpBackpackView;
		if (honamiStoryPickUpBackpackView != null)
		{
			honamiStoryPickUpBackpackView.HideAllTips();
		}
	}

	// Token: 0x0600EAA4 RID: 60068 RVA: 0x003FA1A5 File Offset: 0x003F83A5
	public void Reset()
	{
		this.Cancel();
	}

	// Token: 0x0600EAA5 RID: 60069 RVA: 0x003FA1AD File Offset: 0x003F83AD
	public void SwitchToKeyboardState()
	{
		this.Cancel();
	}

	// Token: 0x0600EAA6 RID: 60070 RVA: 0x003FA1B8 File Offset: 0x003F83B8
	public void SwitchToGamepadState(bool isPickUp = false)
	{
		bool lockUseDragState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState() == EHonamiStoryBackpackLogicState.Sell;
		ControllerBase<UiNavigationNewController>.Instance.SetLockUseDragState(lockUseDragState);
		this.SetDefaultFocus(isPickUp);
	}

	// Token: 0x0600EAA7 RID: 60071 RVA: 0x003FA1E8 File Offset: 0x003F83E8
	public void CancelOperationByGamepad()
	{
		if (this.CurSelectItem != null)
		{
			HonamiStoryGridItemBase gridItemByAnyItem = this.GetGridItemByAnyItem(this.CurSelectItem.GetRootItem());
			if (gridItemByAnyItem != null)
			{
				gridItemByAnyItem.MarkUseCancel();
			}
		}
		this.Cancel();
	}

	// Token: 0x0600EAA8 RID: 60072 RVA: 0x003FA21E File Offset: 0x003F841E
	public void SetDefaultFocus(bool isPickUp = false)
	{
		this.CurPanelIndex = (isPickUp ? 3 : 2);
		this.SetFocusByCurPanelIndex();
	}

	// Token: 0x0600EAA9 RID: 60073 RVA: 0x003FA234 File Offset: 0x003F8434
	private bool IsGamepadInCurItem()
	{
		if (this.CurItem == null)
		{
			return false;
		}
		ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
		return pointerEventData != null && HonamiStoryUtil.CheckEventDataInItemViewport(pointerEventData, this.CurItem.GetRootItem(), true);
	}

	// Token: 0x0600EAAA RID: 60074 RVA: 0x003FA274 File Offset: 0x003F8474
	public void Cancel()
	{
		if (this.CurSelectItem != null)
		{
			HonamiStoryGridItemBase gridItemByAnyItem = this.GetGridItemByAnyItem(this.CurSelectItem.GetRootItem());
			if (gridItemByAnyItem != null)
			{
				this.SetPanelIndexByGridItem(gridItemByAnyItem);
			}
		}
		this.HideAllTips();
		this.InteractController.Reset();
		if (this.IsGamepadInCurItem())
		{
			this.TriggerCurItemEnterGrid();
		}
		else
		{
			this.CurItem = null;
			this.CurItemDataId = -1;
		}
		this.CurSelectItem = null;
	}

	// Token: 0x0600EAAB RID: 60075 RVA: 0x003FA2DC File Offset: 0x003F84DC
	public void Discard()
	{
		if (this.CurItem == null)
		{
			return;
		}
		HonamiStoryItemDataBase data = this.CurItem.GetData();
		if (data == null)
		{
			return;
		}
		EHonamiStoryBackpack ehonamiStoryBackpack = (this.CurItem.GetBackpackType() == EHonamiStoryBackpackType.Backpack) ? EHonamiStoryBackpack.Backpack : EHonamiStoryBackpack.Player;
		HonamiStoryBackpackData backPackData = ModelBase<HonamiStoryModel>.Instance.GetBackPackData(3, false);
		if (backPackData == null)
		{
			return;
		}
		if (backPackData.GetCapacity() <= 0)
		{
			ControllerBase<HonamiStoryController>.Instance.RequestDiscardItem(data, ehonamiStoryBackpack);
			ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
			return;
		}
		if (ModelBase<HonamiStoryModel>.Instance.SetItemIntoBag(data, ehonamiStoryBackpack, EHonamiStoryBackpack.PickUpBox))
		{
			ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
		}
	}

	// Token: 0x0600EAAC RID: 60076 RVA: 0x003FA364 File Offset: 0x003F8564
	public UniTask SellSingleOne()
	{
		HonamiStoryGamepadLogicController.<SellSingleOne>d__44 <SellSingleOne>d__;
		<SellSingleOne>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SellSingleOne>d__.<>4__this = this;
		<SellSingleOne>d__.<>1__state = -1;
		<SellSingleOne>d__.<>t__builder.Start<HonamiStoryGamepadLogicController.<SellSingleOne>d__44>(ref <SellSingleOne>d__);
		return <SellSingleOne>d__.<>t__builder.Task;
	}

	// Token: 0x0600EAAD RID: 60077 RVA: 0x003FA3A8 File Offset: 0x003F85A8
	public void QuickEquipOn()
	{
		if (this.CurItem == null)
		{
			return;
		}
		HonamiStoryItemDataBase data = this.CurItem.GetData();
		if (data == null)
		{
			return;
		}
		EHonamiStoryBackpackType backpackType = this.CurItem.GetBackpackType();
		int position = data.GetPosition();
		if (backpackType == EHonamiStoryBackpackType.Backpack || backpackType == EHonamiStoryBackpackType.Inventory)
		{
			if (data.GetItemType() != EHonamiStoryItemType.Plugin)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_CantEquipNormalItem", Array.Empty<object>());
				return;
			}
			if (!ModelBase<HonamiStoryModel>.Instance.QuickEquipFromBackpack(data, position))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_ShowTips_CantQuickEquip", Array.Empty<object>());
				return;
			}
		}
		else if (backpackType == EHonamiStoryBackpackType.PickUpBox)
		{
			ModelBase<HonamiStoryModel>.Instance.QuickPickUpFromPickUpBox(data, position);
		}
	}

	// Token: 0x0600EAAE RID: 60078 RVA: 0x003FA43C File Offset: 0x003F863C
	public void QuickEquipOff()
	{
		if (this.CurItem == null)
		{
			return;
		}
		HonamiStoryItemDataBase data = this.CurItem.GetData();
		if (data == null)
		{
			return;
		}
		EHonamiStoryBackpack toBackpack = this.IsInGame() ? EHonamiStoryBackpack.Backpack : EHonamiStoryBackpack.Inventory;
		if (!ModelBase<HonamiStoryModel>.Instance.SetItemIntoBag(data, EHonamiStoryBackpack.Player, toBackpack))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_NoEnoughSpace", Array.Empty<object>());
		}
	}

	// Token: 0x0600EAAF RID: 60079 RVA: 0x003FA494 File Offset: 0x003F8694
	public UniTask SetLockStatus()
	{
		HonamiStoryGamepadLogicController.<SetLockStatus>d__47 <SetLockStatus>d__;
		<SetLockStatus>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetLockStatus>d__.<>4__this = this;
		<SetLockStatus>d__.<>1__state = -1;
		<SetLockStatus>d__.<>t__builder.Start<HonamiStoryGamepadLogicController.<SetLockStatus>d__47>(ref <SetLockStatus>d__);
		return <SetLockStatus>d__.<>t__builder.Task;
	}

	// Token: 0x0600EAB0 RID: 60080 RVA: 0x003FA4D8 File Offset: 0x003F86D8
	public void Collect()
	{
		if (this.CurItem == null)
		{
			return;
		}
		HonamiStoryItemDataBase data = this.CurItem.GetData();
		if (data == null)
		{
			return;
		}
		int position = data.GetPosition();
		ModelBase<HonamiStoryModel>.Instance.QuickPickUpFromPickUpBox(data, position);
	}

	// Token: 0x0600EAB1 RID: 60081 RVA: 0x003FA514 File Offset: 0x003F8714
	public void TriggerCurItemEnterGrid()
	{
		if (this.CurItem != null)
		{
			HonamiStoryGridItemBase gridItemByAnyItem = this.GetGridItemByAnyItem(this.CurItem.GetRootItem());
			if (gridItemByAnyItem != null)
			{
				gridItemByAnyItem.TriggerOnEnterGridCb();
			}
		}
	}

	// Token: 0x04007115 RID: 28949
	[Nullable(2)]
	private HonamiStoryItemGridItem CurItem;

	// Token: 0x04007116 RID: 28950
	[Nullable(2)]
	private HonamiStoryItemGridItem CurSelectItem;

	// Token: 0x04007117 RID: 28951
	private int CurItemDataId = -1;

	// Token: 0x04007118 RID: 28952
	private HonamiStoryGamepadInteractController InteractController;

	// Token: 0x04007119 RID: 28953
	private int CurPanelIndex = 1;

	// Token: 0x0400711A RID: 28954
	private int CurPosition = -1;

	// Token: 0x0400711B RID: 28955
	private int CurScrollingPosition = -1;

	// Token: 0x0400711C RID: 28956
	private readonly Dictionary<int, HonamiStoryGridItemBase> JumpMap = new Dictionary<int, HonamiStoryGridItemBase>();

	// Token: 0x0400711D RID: 28957
	private readonly Dictionary<UUIItem, HonamiStoryGridItemBase> BtnMap = new Dictionary<UUIItem, HonamiStoryGridItemBase>();

	// Token: 0x0400711E RID: 28958
	private readonly Dictionary<UUIItem, HonamiStoryGridItemBase> ItemToGridMap = new Dictionary<UUIItem, HonamiStoryGridItemBase>();

	// Token: 0x0400711F RID: 28959
	private readonly Vector2D TempPivot = Vector2D.Create();
}
