using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.MusicalInstrument;
using CSharpScript.Game.Module.RecallQuest.Model;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200202D RID: 8237
[NullableContext(1)]
[Nullable(0)]
[GeneratePropertyAccessMethod(false)]
public class InventoryView : UiViewBase
{
	// Token: 0x0600FA7B RID: 64123 RVA: 0x0044A388 File Offset: 0x00448588
	public InventoryView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FA7C RID: 64124 RVA: 0x0044A3EC File Offset: 0x004485EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 24;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 7;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnClickedDestroyEnterButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnClickedDestroyExitButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(20, new Action(this.OnClickedDestroyExecuteButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(18, new Action<EToggleState>(this.OnClickedAllSelect));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(21, new Action(this.OnClickedManage));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(22, new Action(this.OnClickedRecovery));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(23, new Action(this.OnClickedPhantomPlan));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600FA7D RID: 64125 RVA: 0x0044A854 File Offset: 0x00448A54
	private void InitButtonRelationMap()
	{
		this.TipsButtonIndexMap = new Dictionary<ItemViewDefine.ETipsButtonType, int>();
		this.TipsButtonRelationMap = new Dictionary<ItemViewDefine.ETipsButtonType, IButtonInfo>();
		this.TipsButtonRelationMap.Add(ItemViewDefine.ETipsButtonType.Use, new ButtonInfo
		{
			Function = new Action<int>(this.OnClickedUseItemButton),
			Text = "HotKeyText_UseItemTips_Name",
			Index = 0
		});
		this.TipsButtonRelationMap.Add(ItemViewDefine.ETipsButtonType.RouletteEquip, new ButtonInfo
		{
			Function = new Action<int>(this.OnClickedSpecialItemFuncUseButton),
			Text = "Text_ButtonTextConfirm_Text",
			Index = 0
		});
		this.TipsButtonRelationMap.Add(ItemViewDefine.ETipsButtonType.WeaponCultivate, new ButtonInfo
		{
			Function = new Action<int>(this.OnClickedWeaponCultivateButton),
			Text = "Text_BagFosterButton_Text",
			Index = 0
		});
		this.TipsButtonRelationMap.Add(ItemViewDefine.ETipsButtonType.VisionCultivate, new ButtonInfo
		{
			Function = new Action<int>(this.OnClickedVisionCultivateButton),
			Text = "Text_BagFosterButton_Text",
			Index = 0
		});
		this.TipsButtonRelationMap.Add(ItemViewDefine.ETipsButtonType.FragmentMemory, new ButtonInfo
		{
			Function = new Action<int>(this.OnClickFragmentMemoryButton),
			Text = "Text_FragmentMemoryButton_Text",
			Index = 0
		});
		this.TipsButtonRelationMap.Add(ItemViewDefine.ETipsButtonType.EquipBuffItem, new ButtonInfo
		{
			Function = new Action<int>(this.OnClickedUseItemButton),
			Text = "Mask_Wear_01",
			Index = 0
		});
		this.TipsButtonRelationMap.Add(ItemViewDefine.ETipsButtonType.QuestReview, new ButtonInfo
		{
			Function = new Action<int>(this.OnClickedQuestReviewButton),
			Text = "Item_70140005_UseTip",
			Index = 0
		});
		this.TipsButtonRelationMap.Add(ItemViewDefine.ETipsButtonType.ChineseZither, new ButtonInfo
		{
			Function = new Action<int>(this.OnClickedChineseZitherButton),
			Text = "HotKeyText_UseItemTips_Name",
			Index = 0
		});
	}

	// Token: 0x0600FA7E RID: 64126 RVA: 0x0044AA20 File Offset: 0x00448C20
	protected override UniTask OnBeforeStartAsync()
	{
		InventoryView.<OnBeforeStartAsync>d__31 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<InventoryView.<OnBeforeStartAsync>d__31>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FA7F RID: 64127 RVA: 0x0044AA63 File Offset: 0x00448C63
	private void RefreshCurrencyShow()
	{
		if (this.CommonCurrencyItem1 == null || this.CommonCurrencyItem2 == null)
		{
			return;
		}
		if (ModelBase<InventoryModel>.Instance.SupportInventoryViewShowCurrency())
		{
			this.CommonCurrencyItem1.ShowAsync().Forget<bool>();
			this.CommonCurrencyItem2.ShowAsync().Forget<bool>();
		}
	}

	// Token: 0x0600FA80 RID: 64128 RVA: 0x0044AAA2 File Offset: 0x00448CA2
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionRefineSubNeedAck);
	}

	// Token: 0x0600FA81 RID: 64129 RVA: 0x0044AAB4 File Offset: 0x00448CB4
	protected override void OnAfterPlayStartSequence()
	{
		int selectedIndex = this.TabComponent.GetSelectedIndex();
		this.TabComponent.ScrollToToggleByIndex(selectedIndex);
	}

	// Token: 0x0600FA82 RID: 64130 RVA: 0x0044AADC File Offset: 0x00448CDC
	protected override void OnBeforeShow()
	{
		int selectedTypeIndex = ModelBase<InventoryModel>.Instance.GetSelectedTypeIndex();
		this.TabComponent.SelectToggleByIndex(selectedTypeIndex, true);
		this.SelectedItemTypeHandle(selectedTypeIndex);
	}

	// Token: 0x0600FA83 RID: 64131 RVA: 0x0044AB08 File Offset: 0x00448D08
	protected override void OnAfterShow()
	{
		this.RefreshAllItemList();
		this.RequestInvalidItemInfo();
	}

	// Token: 0x0600FA84 RID: 64132 RVA: 0x0044AB18 File Offset: 0x00448D18
	protected override void OnBeforeDestroy()
	{
		foreach (AccessPathButton accessPathButton in this.AccessPathButtonList)
		{
			accessPathButton.Destroy(null);
		}
		this.RemoveItemCdTimer();
		this.ClearAllItemViewData();
		this.AccessPathButtonList.Clear();
		this.SelectedItemIndex = 0;
		this.SelectedItemViewData = null;
		this.ItemScrollView = null;
		this.FilterSortEntrance.Destroy(null);
		this.CommonCurrencyItem1.Destroy(null);
		this.CommonCurrencyItem1 = null;
		this.CommonCurrencyItem2.Destroy(null);
		this.CommonCurrencyItem2 = null;
		this.ItemTipsComponent.Destroy(null);
		this.ItemTipsComponent = null;
		this.TabMarkPositions = null;
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		instance.SaveNewCommonItemConfigIdList();
		instance.SaveNewAttributeItemUniqueIdList();
		instance.SaveRedDotCommonItemConfigIdList();
		instance.SaveRedDotAttributeItemUniqueIdList();
	}

	// Token: 0x0600FA85 RID: 64133 RVA: 0x0044AC1C File Offset: 0x00448E1C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<WeaponItem>, bool, bool>(EEventName.OnAddWeaponItemList, new Action<IReadOnlyList<WeaponItem>, bool, bool>(this.OnAddWeaponItemList));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<Aki.Protocol.PhantomItem>, bool>(EEventName.OnAddPhantomItemList, new Action<IReadOnlyList<Aki.Protocol.PhantomItem>, bool>(this.OnAddPhantomItemList));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnRemoveWeaponItem, new Action<IReadOnlyList<int>>(this.OnRemoveWeaponItem));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnRemovePhantomItem, new Action<IReadOnlyList<int>>(this.OnRemovePhantomItem));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnItemFuncValueBatchChange, new Action<IReadOnlyList<int>>(this.OnItemFuncValueBatchChange));
		Singleton<EventSystem>.Instance.Add<int, long, int>(EEventName.OnUseBuffItem, new Action<int, long, int>(this.OnUseBuffItem));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.OnEquipBuffItemUpdate, new Action<int, bool>(this.OnEquipBuffItemUpdate));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnItemUse, new Action<int, int>(this.OnItemUse));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
		Singleton<EventSystem>.Instance.Add<int?>(EEventName.OnSpecialItemUpdate, new Action<int?>(this.OnSpecialItemUpdate));
		Singleton<EventSystem>.Instance.Add<Dictionary<int, int>>(EEventName.NotifyInvalidItem, new Action<Dictionary<int, int>>(this.OnNotifyInvalidItem));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<TItem>, IReadOnlyList<TItem>>(EEventName.NotifyExpireConvertItem, new Action<IReadOnlyList<TItem>, IReadOnlyList<TItem>>(this.OnNotifyExpireConvertItem));
		Singleton<EventSystem>.Instance.Add(EEventName.RoleDevTargetRoleIdChange, new Action(this.OnRoleDevelopInventoryRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.RoleDevelopNeedItemsChanged, new Action(this.OnRoleDevelopInventoryRefresh));
	}

	// Token: 0x0600FA86 RID: 64134 RVA: 0x0044AE00 File Offset: 0x00449000
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddWeaponItemList, new Action<IReadOnlyList<WeaponItem>, bool, bool>(this.OnAddWeaponItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddPhantomItemList, new Action<IReadOnlyList<Aki.Protocol.PhantomItem>, bool>(this.OnAddPhantomItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveWeaponItem, new Action<IReadOnlyList<int>>(this.OnRemoveWeaponItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemovePhantomItem, new Action<IReadOnlyList<int>>(this.OnRemovePhantomItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueBatchChange, new Action<IReadOnlyList<int>>(this.OnItemFuncValueBatchChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUseBuffItem, new Action<int, long, int>(this.OnUseBuffItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnEquipBuffItemUpdate, new Action<int, bool>(this.OnEquipBuffItemUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemUse, new Action<int, int>(this.OnItemUse));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSpecialItemUpdate, new Action<int?>(this.OnSpecialItemUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.NotifyInvalidItem, new Action<Dictionary<int, int>>(this.OnNotifyInvalidItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.NotifyExpireConvertItem, new Action<IReadOnlyList<TItem>, IReadOnlyList<TItem>>(this.OnNotifyExpireConvertItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleDevTargetRoleIdChange, new Action(this.OnRoleDevelopInventoryRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleDevelopNeedItemsChanged, new Action(this.OnRoleDevelopInventoryRefresh));
	}

	// Token: 0x0600FA87 RID: 64135 RVA: 0x0044AFE4 File Offset: 0x004491E4
	private void TryActivateRefreshItemCdTimer()
	{
		this.CurrentCdItemMap.Clear();
		ModelBase<BuffItemModel>.Instance.GetInCdBuffItemMap(this.CurrentCdItemMap);
		if (this.CurrentCdItemMap.Count <= 0)
		{
			this.RemoveItemCdTimer();
			return;
		}
		this.RefreshItemCdTime();
		if (!TimerSystem.GameplayTimeInstance.Has(this.RefreshCdTimerId))
		{
			this.RefreshCdTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnRefreshCdDisplay), 500f, 1f, null, null, true);
		}
		this.RefreshTimeDilation();
	}

	// Token: 0x0600FA88 RID: 64136 RVA: 0x0044B068 File Offset: 0x00449268
	private void RemoveItemCdTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.RefreshCdTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RefreshCdTimerId);
		}
		this.RefreshCdTimerId = null;
	}

	// Token: 0x0600FA89 RID: 64137 RVA: 0x0044B094 File Offset: 0x00449294
	private void OnRefreshCdDisplay(float delta)
	{
		this.RefreshItemCdTime();
	}

	// Token: 0x0600FA8A RID: 64138 RVA: 0x0044B09C File Offset: 0x0044929C
	private void RefreshItemCdTime()
	{
		List<int> list = new List<int>();
		foreach (BuffItemData buffItemData in this.CurrentCdItemMap.Values)
		{
			int itemConfigId = buffItemData.ItemConfigId;
			for (int i = 0; i < this.ItemViewDataList.Count; i++)
			{
				if (this.ItemViewDataList[i].GetConfigId() == itemConfigId && this.ItemScrollView.IsGridDisplaying(i))
				{
					InventoryMediumItemGrid inventoryMediumItemGrid = this.ItemScrollView.UnsafeGetGridProxy(i, false);
					if (inventoryMediumItemGrid != null)
					{
						inventoryMediumItemGrid.RefreshCoolDown();
					}
				}
			}
			if (buffItemData.GetBuffItemRemainCdTime() <= 0.0)
			{
				list.Add(itemConfigId);
			}
		}
		foreach (int num in list)
		{
			this.CurrentCdItemMap.Remove(num);
			if (num == this.SelectedItemViewData.GetConfigId())
			{
				this.SetTipsButtonEnableByType(ItemViewDefine.ETipsButtonType.Use, true);
			}
		}
	}

	// Token: 0x0600FA8B RID: 64139 RVA: 0x0044B1D0 File Offset: 0x004493D0
	private void RequestInvalidItemInfo()
	{
		ControllerBase<InventoryController>.Instance.InvalidItemCheckRequest();
	}

	// Token: 0x0600FA8C RID: 64140 RVA: 0x0044B1DC File Offset: 0x004493DC
	private void OnNotifyInvalidItem(Dictionary<int, int> itemMap)
	{
		if (!this.IsInvalidItemViewShow)
		{
			this.ShowInvalidItemConfirmBox(itemMap);
			return;
		}
		this.InvalidItemTempList.Add(itemMap);
	}

	// Token: 0x0600FA8D RID: 64141 RVA: 0x0044B1FC File Offset: 0x004493FC
	private void CheckInvalidItem()
	{
		if (this.InvalidItemTempList.Count > 0)
		{
			List<Dictionary<int, int>> invalidItemTempList = this.InvalidItemTempList;
			Dictionary<int, int> itemMap = invalidItemTempList[invalidItemTempList.Count - 1];
			this.InvalidItemTempList.RemoveAt(this.InvalidItemTempList.Count - 1);
			this.ShowInvalidItemConfirmBox(itemMap);
		}
	}

	// Token: 0x0600FA8E RID: 64142 RVA: 0x0044B24C File Offset: 0x0044944C
	private void ShowInvalidItemConfirmBox(Dictionary<int, int> itemMap)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ItemInvalidTips);
		confirmBoxDataNew.IsMultipleView = true;
		confirmBoxDataNew.ItemIdMap = itemMap;
		confirmBoxDataNew.SetCloseFunction(delegate
		{
			this.IsInvalidItemViewShow = false;
			this.CheckInvalidItem();
		});
		this.IsInvalidItemViewShow = true;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600FA8F RID: 64143 RVA: 0x0044B298 File Offset: 0x00449498
	private void OnNotifyExpireConvertItem(IReadOnlyList<TItem> beforeItemList, IReadOnlyList<TItem> afterItemList)
	{
		ItemExpiredAutoConvertTipsViewDefine itemExpiredAutoConvertTipsViewDefine = new ItemExpiredAutoConvertTipsViewDefine();
		itemExpiredAutoConvertTipsViewDefine.BeforeItemList = beforeItemList;
		itemExpiredAutoConvertTipsViewDefine.AfterItemList = afterItemList;
		itemExpiredAutoConvertTipsViewDefine.TitleText = "AutoConvertText_1";
		itemExpiredAutoConvertTipsViewDefine.BeforeTitleText = "AutoConvertText_2";
		itemExpiredAutoConvertTipsViewDefine.AfterTitleText = "AutoConvertText_3";
		itemExpiredAutoConvertTipsViewDefine.OnConfirmCallBack = delegate(int _)
		{
			this.CheckExpireConvertItem();
		};
		this.CacheExpireShowDataList.Add(itemExpiredAutoConvertTipsViewDefine);
		this.CheckExpireConvertItem();
	}

	// Token: 0x0600FA90 RID: 64144 RVA: 0x0044B300 File Offset: 0x00449500
	private void CheckExpireConvertItem()
	{
		if (this.CacheExpireShowDataList.Count > 0)
		{
			ItemExpiredAutoConvertTipsViewDefine data = this.CacheExpireShowDataList[this.CacheExpireShowDataList.Count - 1];
			this.CacheExpireShowDataList.RemoveAt(this.CacheExpireShowDataList.Count - 1);
			this.ShowExpireConvertItemConfirmBox(data);
		}
	}

	// Token: 0x0600FA91 RID: 64145 RVA: 0x0044B353 File Offset: 0x00449553
	private void ShowExpireConvertItemConfirmBox(ItemExpiredAutoConvertTipsViewDefine data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ItemExpiredAutoConvertTipsView, data, null);
	}

	// Token: 0x0600FA92 RID: 64146 RVA: 0x0044B366 File Offset: 0x00449566
	private void OnClickedDestroyExitButton()
	{
		if (this.ViewMode == ItemViewDefine.EItemOperationMode.Destruction)
		{
			this.SetViewMode(ItemViewDefine.EItemOperationMode.Normal);
		}
	}

	// Token: 0x0600FA93 RID: 64147 RVA: 0x0044B378 File Offset: 0x00449578
	private void OnClickedDestroyEnterButton()
	{
		if (this.ViewMode == ItemViewDefine.EItemOperationMode.Normal)
		{
			this.SetViewMode(ItemViewDefine.EItemOperationMode.Destruction);
		}
	}

	// Token: 0x0600FA94 RID: 64148 RVA: 0x0044B38C File Offset: 0x0044958C
	private void OnClickedUseItemButton(int _)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		global::ItemViewData selectedItemData = instance.GetSelectedItemData();
		if (selectedItemData == null)
		{
			return;
		}
		this.RemoveItemViewNewFlag(selectedItemData);
		if (selectedItemData.GetRedDotDisableRule() == InventoryDefine.ERedDotDisableRule.AfterUse)
		{
			this.RemoveItemViewRedDot(selectedItemData);
		}
		InventoryDefine.EItemDataType itemDataType = selectedItemData.GetItemDataType();
		if (itemDataType == InventoryDefine.EItemDataType.CommonItem)
		{
			instance.SaveNewCommonItemConfigIdList();
			instance.SaveRedDotCommonItemConfigIdList();
		}
		else
		{
			instance.SaveNewAttributeItemUniqueIdList();
			instance.SaveRedDotAttributeItemUniqueIdList();
		}
		int num = this.ItemViewDataList.IndexOf(selectedItemData);
		if (num >= 0)
		{
			this.ItemScrollView.RefreshGridProxy(num);
		}
		this.SetTipsButtonRedDotVisibleByType(ItemViewDefine.ETipsButtonType.Use, false);
		this.RefreshSameConfigIdItemView(selectedItemData);
		if (itemDataType == InventoryDefine.EItemDataType.CalabashSkinItem)
		{
			ControllerBase<SkinController>.Instance.SkipToCalabashSkinView(selectedItemData.GetConfigId());
			return;
		}
		ControllerBase<InventoryController>.Instance.TryUseItem(selectedItemData.GetConfigId(), 1);
	}

	// Token: 0x0600FA95 RID: 64149 RVA: 0x0044B43C File Offset: 0x0044963C
	private void OnClickedSpecialItemFuncUseButton(int _)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		global::ItemViewData selectedItemData = instance.GetSelectedItemData();
		if (selectedItemData == null)
		{
			return;
		}
		this.RemoveItemViewNewFlag(selectedItemData);
		if (selectedItemData.GetRedDotDisableRule() == InventoryDefine.ERedDotDisableRule.AfterUse)
		{
			this.RemoveItemViewRedDot(selectedItemData);
		}
		if (selectedItemData.GetItemDataType() == InventoryDefine.EItemDataType.CommonItem)
		{
			instance.SaveNewCommonItemConfigIdList();
			instance.SaveRedDotCommonItemConfigIdList();
		}
		else
		{
			instance.SaveNewAttributeItemUniqueIdList();
			instance.SaveRedDotAttributeItemUniqueIdList();
		}
		this.RefreshSameConfigIdItemView(selectedItemData);
		if (ControllerBase<SpecialItemController>.Instance.AutoEquipOrUnEquipSpecialItem(selectedItemData.GetConfigId()))
		{
			Singleton<UiManager>.Instance.ResetToBattleView(null);
		}
	}

	// Token: 0x0600FA96 RID: 64150 RVA: 0x0044B4BC File Offset: 0x004496BC
	private void OnClickedWeaponCultivateButton(int _)
	{
		global::ItemViewData selectedItemData = ModelBase<InventoryModel>.Instance.GetSelectedItemData();
		if (selectedItemData == null)
		{
			return;
		}
		SkipTaskManager.Run(ESkipName.SkipToWeaponRoot, new object[]
		{
			selectedItemData.GetUniqueId()
		});
	}

	// Token: 0x0600FA97 RID: 64151 RVA: 0x0044B4F4 File Offset: 0x004496F4
	private void OnClickedVisionCultivateButton(int _)
	{
		global::ItemViewData selectedItemData = ModelBase<InventoryModel>.Instance.GetSelectedItemData();
		if (selectedItemData == null)
		{
			return;
		}
		SkipTaskManager.Run(ESkipName.SkipToVisionIntensifyView, new object[]
		{
			selectedItemData.GetUniqueId()
		});
	}

	// Token: 0x0600FA98 RID: 64152 RVA: 0x0044B52A File Offset: 0x0044972A
	private void OnClickFragmentMemoryButton(int _)
	{
		ControllerBase<FragmentMemoryController>.Instance.OpenFragmentMemoryView();
	}

	// Token: 0x0600FA99 RID: 64153 RVA: 0x0044B536 File Offset: 0x00449736
	private void OnClickedPhantomPlan()
	{
		ControllerBase<InventoryController>.Instance.OpenManageConfigNewView();
	}

	// Token: 0x0600FA9A RID: 64154 RVA: 0x0044B542 File Offset: 0x00449742
	private void OnClickedCloseButton()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.InventoryView, null);
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PowerView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.PowerView, null);
		}
	}

	// Token: 0x0600FA9B RID: 64155 RVA: 0x0044B578 File Offset: 0x00449778
	private void OnClickedQuestReviewButton(int _)
	{
		SpecialItemConfig instance = ConfigBase<SpecialItemConfig>.Instance;
		global::ItemViewData selectedItemViewData = this.SelectedItemViewData;
		SpecialItem? config = instance.GetConfig((selectedItemViewData != null) ? selectedItemViewData.GetConfigId() : 0);
		if (config != null)
		{
			SpecialItem value = config.Value;
			int entryId = 0;
			if (value.ParametersLength > 0)
			{
				string text = value.Parameters(0);
				if (!string.IsNullOrEmpty(text))
				{
					int.TryParse(text, out entryId);
				}
			}
			ControllerBase<QuestReviewController>.Instance.OpenQuestReview(entryId, true);
		}
	}

	// Token: 0x0600FA9C RID: 64156 RVA: 0x0044B5E8 File Offset: 0x004497E8
	private void OnClickedChineseZitherButton(int _)
	{
		int restrictConditionGroupId = ConfigBase<InventoryConfig>.Instance.GetItemConfig(80700051).Value.RestrictConditionGroupId;
		if (restrictConditionGroupId > 0 && ControllerBase<LevelGeneralController>.Instance.CheckCondition(restrictConditionGroupId.ToString(), null, false, Array.Empty<object>()))
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(restrictConditionGroupId);
			if (conditionGroupHintText != null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(conditionGroupHintText, Array.Empty<object>());
			}
			return;
		}
		ControllerBase<MusicalInstrumentController>.Instance.Enter(new MusicalInstrumentEnterParam
		{
			Type = EInstrumentType.ChineseZither
		}).Forget();
	}

	// Token: 0x0600FA9D RID: 64157 RVA: 0x0044B669 File Offset: 0x00449869
	private void OnAddWeaponItemList(IReadOnlyList<WeaponItem> weaponItem, bool bAddFromRole, bool bShowNewTips)
	{
		this.RefreshInventoryView();
	}

	// Token: 0x0600FA9E RID: 64158 RVA: 0x0044B671 File Offset: 0x00449871
	private void OnAddPhantomItemList(IReadOnlyList<Aki.Protocol.PhantomItem> weaponItem, bool isCatch)
	{
		this.RefreshInventoryView();
	}

	// Token: 0x0600FA9F RID: 64159 RVA: 0x0044B679 File Offset: 0x00449879
	private void OnCommonItemCountAnyChange(int configId, int count)
	{
		this.RefreshInventoryView();
	}

	// Token: 0x0600FAA0 RID: 64160 RVA: 0x0044B681 File Offset: 0x00449881
	private void OnRoleDevelopInventoryRefresh()
	{
		this.RefreshInventoryView();
	}

	// Token: 0x0600FAA1 RID: 64161 RVA: 0x0044B689 File Offset: 0x00449889
	private void OnRemoveWeaponItem(IReadOnlyList<int> uniqueIdList)
	{
		this.RefreshInventoryView();
	}

	// Token: 0x0600FAA2 RID: 64162 RVA: 0x0044B691 File Offset: 0x00449891
	private void OnRemovePhantomItem(IReadOnlyList<int> uniqueIdList)
	{
		this.RefreshInventoryView();
	}

	// Token: 0x0600FAA3 RID: 64163 RVA: 0x0044B69C File Offset: 0x0044989C
	private void OnUseBuffItem(int itemConfigId, long endCdTimeStamp, int useCount)
	{
		this.TryActivateRefreshItemCdTimer();
		if (ConfigBase<BuffItemConfig>.Instance.IsBuffItem(itemConfigId))
		{
			double buffItemRemainCdTime = ModelBase<BuffItemModel>.Instance.GetBuffItemRemainCdTime(itemConfigId);
			this.SetTipsButtonEnableByType(ItemViewDefine.ETipsButtonType.Use, buffItemRemainCdTime <= 0.0);
		}
	}

	// Token: 0x0600FAA4 RID: 64164 RVA: 0x0044B6E0 File Offset: 0x004498E0
	private void OnEquipBuffItemUpdate(int itemConfigId, bool equipped)
	{
		if (this.SelectedItemViewData == null)
		{
			return;
		}
		ItemDataBase itemDataBase = this.SelectedItemViewData.GetItemDataBase();
		if (itemDataBase.IsBuffEquipItem())
		{
			this.RefreshBuffEquipItemFunction(itemDataBase);
		}
	}

	// Token: 0x0600FAA5 RID: 64165 RVA: 0x0044B711 File Offset: 0x00449911
	private void OnItemUse(int configId, int useCount)
	{
	}

	// Token: 0x0600FAA6 RID: 64166 RVA: 0x0044B713 File Offset: 0x00449913
	private void RefreshInventoryView()
	{
		this.SetViewMode(this.ViewMode);
		this.RefreshAllItemList();
	}

	// Token: 0x0600FAA7 RID: 64167 RVA: 0x0044B728 File Offset: 0x00449928
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName != EUiViewName.UseBuffItemView)
		{
			return;
		}
		this.LevelSequencePlayer.StopSequenceByKey("Tc", false, false);
		this.LevelSequencePlayer.PlaySequencePurely("Tc", false, true, null, null, false);
		global::ItemViewData itemViewData = this.ItemViewDataList[this.SelectedItemIndex];
		if (itemViewData != null)
		{
			this.SelectedItem(itemViewData);
		}
	}

	// Token: 0x0600FAA8 RID: 64168 RVA: 0x0044B78E File Offset: 0x0044998E
	private void OnChangedTimeScale()
	{
		this.RefreshTimeDilation();
	}

	// Token: 0x0600FAA9 RID: 64169 RVA: 0x0044B798 File Offset: 0x00449998
	private void RefreshTimeDilation()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.RefreshCdTimerId))
		{
			float timeDilation = Singleton<Time>.Instance.TimeDilation;
			if (timeDilation <= 0f)
			{
				return;
			}
			TimerSystem.GameplayTimeInstance.ChangeDilation(this.RefreshCdTimerId, timeDilation, null);
		}
	}

	// Token: 0x0600FAAA RID: 64170 RVA: 0x0044B7E0 File Offset: 0x004499E0
	private void OnItemFuncValueChange(int uniqueId)
	{
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(uniqueId);
		if (attributeItemData == null)
		{
			return;
		}
		for (int i = 0; i < this.ItemViewDataList.Count; i++)
		{
			global::ItemViewData itemViewData = this.ItemViewDataList[i];
			if (itemViewData.GetUniqueId() == uniqueId)
			{
				itemViewData.SetIsLock(attributeItemData.GetIsLock());
				itemViewData.SetIsDeprecate(attributeItemData.GetIsDeprecated());
				itemViewData.RemoveNewItem();
				this.ItemScrollView.RefreshGridProxy(i);
				return;
			}
		}
	}

	// Token: 0x0600FAAB RID: 64171 RVA: 0x0044B854 File Offset: 0x00449A54
	private void OnItemFuncValueBatchChange(IReadOnlyList<int> uniqueIdList)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		HashSet<int> hashSet = new HashSet<int>(uniqueIdList);
		for (int i = 0; i < this.ItemViewDataList.Count; i++)
		{
			global::ItemViewData itemViewData = this.ItemViewDataList[i];
			if (hashSet.Contains(itemViewData.GetUniqueId()))
			{
				AttributeItemData attributeItemData = instance.GetAttributeItemData(itemViewData.GetUniqueId());
				if (attributeItemData != null)
				{
					itemViewData.SetIsLock(attributeItemData.GetIsLock());
					itemViewData.SetIsDeprecate(attributeItemData.GetIsDeprecated());
					itemViewData.RemoveNewItem();
					this.ItemScrollView.RefreshGridProxy(i);
				}
			}
		}
	}

	// Token: 0x0600FAAC RID: 64172 RVA: 0x0044B8E0 File Offset: 0x00449AE0
	private void RefreshNormalItemFunction(ItemDataBase itemData)
	{
		int configId = itemData.GetConfigId();
		bool isShowUseButton = itemData.GetIsShowUseButton();
		if (isShowUseButton)
		{
			this.RefreshButtonByTypeList(new List<ItemViewDefine.ETipsButtonType>
			{
				ItemViewDefine.ETipsButtonType.Use
			});
		}
		if (itemData.IsBuffItem() && isShowUseButton)
		{
			double buffItemRemainCdTime = ModelBase<BuffItemModel>.Instance.GetBuffItemRemainCdTime(configId);
			this.SetTipsButtonEnableByType(ItemViewDefine.ETipsButtonType.Use, buffItemRemainCdTime <= 0.0);
		}
		if (itemData.GetRedDotDisableRule() == InventoryDefine.ERedDotDisableRule.AfterUse)
		{
			this.SetTipsButtonRedDotVisibleByType(ItemViewDefine.ETipsButtonType.Use, itemData.HasRedDot());
			return;
		}
		this.SetTipsButtonRedDotVisibleByType(ItemViewDefine.ETipsButtonType.Use, false);
	}

	// Token: 0x0600FAAD RID: 64173 RVA: 0x0044B95C File Offset: 0x00449B5C
	private void RefreshBuffEquipItemFunction(ItemDataBase itemData)
	{
		bool flag = itemData.IsBuffEquippedItem();
		string text = flag ? "Mask_Remove_01" : "Mask_Wear_01";
		if (!flag && ModelBase<BuffItemModel>.Instance.IsEquippedBuffCategory((EBuffItemEquipCategory)ConfigBase<BuffItemConfig>.Instance.GetBuffEquipItemCategory(itemData.GetConfigId())))
		{
			text = "Instead";
		}
		this.SetTipsButtonTextByType(ItemViewDefine.ETipsButtonType.EquipBuffItem, text, null);
	}

	// Token: 0x0600FAAE RID: 64174 RVA: 0x0044B9AC File Offset: 0x00449BAC
	private List<ItemViewDefine.ETipsButtonType> GetTipsButtonListByCurrentItemData(ItemDataBase dataBase)
	{
		List<ItemViewDefine.ETipsButtonType> list = new List<ItemViewDefine.ETipsButtonType>();
		if (this.SelectedItemViewData == null)
		{
			return list;
		}
		InventoryDefine.EItemType itemType = this.SelectedItemViewData.GetItemType();
		if (itemType != InventoryDefine.EItemType.Weapon)
		{
			if (itemType != InventoryDefine.EItemType.Phantom)
			{
				ItemInfo? itemInfo;
				if (itemType == InventoryDefine.EItemType.SpecialItem)
				{
					SpecialItem? config = ConfigBase<SpecialItemConfig>.Instance.GetConfig(dataBase.GetConfigId());
					if (config != null)
					{
						SpecialItem value = config.Value;
						if (value.UseButtonAdditionParamLength > 0)
						{
							for (int i = 0; i < value.UseButtonAdditionParamLength; i++)
							{
								ItemViewDefine.ETipsButtonType etipsButtonType = (ItemViewDefine.ETipsButtonType)value.UseButtonAdditionParam(i);
								if (etipsButtonType != ItemViewDefine.ETipsButtonType.RouletteEquip || ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(false))
								{
									list.Add(etipsButtonType);
								}
							}
						}
						else if (ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(false) && value.SpecialItemType == 0)
						{
							list.Add(ItemViewDefine.ETipsButtonType.RouletteEquip);
						}
					}
				}
				else if (dataBase.GetConfig().As<ItemInfo>() != null && itemInfo.GetValueOrDefault().ShowUseButton)
				{
					if (dataBase.IsBuffEquipItem())
					{
						list.Add(ItemViewDefine.ETipsButtonType.EquipBuffItem);
					}
					else
					{
						list.Add(ItemViewDefine.ETipsButtonType.Use);
					}
				}
			}
			else
			{
				list.Add(ItemViewDefine.ETipsButtonType.VisionCultivate);
			}
		}
		else
		{
			list.Add(ItemViewDefine.ETipsButtonType.WeaponCultivate);
		}
		return list;
	}

	// Token: 0x0600FAAF RID: 64175 RVA: 0x0044BAD4 File Offset: 0x00449CD4
	private void RefreshSpecialItemText()
	{
		if (this.SelectedItemViewData == null)
		{
			return;
		}
		int configId = this.SelectedItemViewData.GetConfigId();
		int? equipSpecialItemId = ModelBase<SpecialItemModel>.Instance.GetEquipSpecialItemId();
		int? num = equipSpecialItemId;
		string text;
		if (configId == num.GetValueOrDefault() & num != null)
		{
			text = "UnEquip";
		}
		else if (equipSpecialItemId != null)
		{
			text = "Instead";
		}
		else
		{
			text = "Equip";
		}
		this.SetTipsButtonTextByType(ItemViewDefine.ETipsButtonType.RouletteEquip, text, null);
	}

	// Token: 0x0600FAB0 RID: 64176 RVA: 0x0044BB3F File Offset: 0x00449D3F
	private void InitializeFilterSortComponent()
	{
		this.FilterSortEntrance = new FilterSortEntrance<global::ItemViewData>(base.GetItem(12), new TUpdateDataListFunction<global::ItemViewData>(this.OnFilterSortRefresh));
	}

	// Token: 0x0600FAB1 RID: 64177 RVA: 0x0044BB60 File Offset: 0x00449D60
	private void ClearFilterSortComponentData(ItemViewDefine.EItemOperationMode viewMode)
	{
		foreach (ItemMainType itemMainType in this.ItemTypeList)
		{
			ItemMainType? itemMainTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemMainTypeConfig(itemMainType.Id);
			if (itemMainTypeConfig != null)
			{
				ItemMainType value = itemMainTypeConfig.Value;
				int groupId = (viewMode == ItemViewDefine.EItemOperationMode.Normal) ? value.UseWayId : value.DestroyUseWayId;
				this.FilterSortEntrance.ClearData((EFilterSortGroupId)groupId);
			}
		}
	}

	// Token: 0x0600FAB2 RID: 64178 RVA: 0x0044BBF4 File Offset: 0x00449DF4
	private void RefreshFilterSortPerformance(InventoryDefine.EItemMainTypeId itemMainType)
	{
		ItemMainType? itemMainTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemMainTypeConfig((int)itemMainType);
		bool flag = false;
		if (itemMainTypeConfig != null)
		{
			flag = itemMainTypeConfig.Value.BFilterSortVisible;
		}
		int useWayId = 0;
		ItemMainType value = ConfigBase<InventoryConfig>.Instance.GetItemMainTypeConfig((int)itemMainType).Value;
		ItemViewDefine.EItemOperationMode viewMode = this.ViewMode;
		if (viewMode != ItemViewDefine.EItemOperationMode.Normal)
		{
			if (viewMode == ItemViewDefine.EItemOperationMode.Destruction)
			{
				useWayId = value.DestroyUseWayId;
				bool flag2 = this.DestroyViewMode == ItemViewDefine.EDestroyViewMode.Default;
				this.FilterSortEntrance.SetUiActive(flag && flag2);
			}
		}
		else
		{
			useWayId = value.UseWayId;
			this.FilterSortEntrance.SetUiActive(flag);
		}
		List<global::ItemViewData> list = this.GenerateItemViewData(itemMainType);
		this.RefreshFilterSort(useWayId, list);
		this.RefreshCapacity(itemMainType, list);
	}

	// Token: 0x0600FAB3 RID: 64179 RVA: 0x0044BCA8 File Offset: 0x00449EA8
	private void RefreshPhantomManageButton(InventoryDefine.EItemMainTypeId itemMainType)
	{
		base.SetButtonUiActive(21, itemMainType == InventoryDefine.EItemMainTypeId.Phantom && this.ViewMode == ItemViewDefine.EItemOperationMode.Normal);
		bool flag = ModelBase<FunctionModel>.Instance.IsOpen(10096);
		base.SetButtonUiActive(22, flag && itemMainType == InventoryDefine.EItemMainTypeId.Phantom && this.ViewMode == ItemViewDefine.EItemOperationMode.Normal);
		base.SetButtonUiActive(23, flag && itemMainType == InventoryDefine.EItemMainTypeId.Phantom && this.ViewMode == ItemViewDefine.EItemOperationMode.Normal);
	}

	// Token: 0x0600FAB4 RID: 64180 RVA: 0x0044BD14 File Offset: 0x00449F14
	private void RefreshFilterSort(int useWayId, List<global::ItemViewData> itemDataList)
	{
		EFilterSortConfigId saveConfigId = (this.ViewMode == ItemViewDefine.EItemOperationMode.Normal) ? EFilterSortConfigId.InventoryView : EFilterSortConfigId.InventoryDestroy;
		this.FilterSortEntrance.UpdateDataWithConfig((EFilterSortGroupId)useWayId, saveConfigId, itemDataList);
	}

	// Token: 0x0600FAB5 RID: 64181 RVA: 0x0044BD3C File Offset: 0x00449F3C
	private bool ShouldApplyDevelopDeficitPinSort()
	{
		RoleDevelopModel instance = ModelBase<RoleDevelopModel>.Instance;
		return instance != null && instance.DevTargetRoleId != 0 && ModelBase<InventoryModel>.Instance.IsResourceOrMaterialTab();
	}

	// Token: 0x0600FAB6 RID: 64182 RVA: 0x0044BD68 File Offset: 0x00449F68
	private List<global::ItemViewData> ApplyDevelopDeficitPinSort(List<global::ItemViewData> itemViewDataList)
	{
		if (!this.ShouldApplyDevelopDeficitPinSort())
		{
			return itemViewDataList;
		}
		RoleDevelopModel instance = ModelBase<RoleDevelopModel>.Instance;
		List<global::ItemViewData> list = new List<global::ItemViewData>();
		List<global::ItemViewData> list2 = new List<global::ItemViewData>();
		foreach (global::ItemViewData itemViewData in itemViewDataList)
		{
			if (instance.GetDevelopRoleNeedItemDeficitCount(itemViewData.GetConfigId()) > 0)
			{
				list.Add(itemViewData);
			}
			else
			{
				list2.Add(itemViewData);
			}
		}
		list.AddRange(list2);
		return list;
	}

	// Token: 0x0600FAB7 RID: 64183 RVA: 0x0044BDF8 File Offset: 0x00449FF8
	[NullableContext(2)]
	private global::ItemViewData GetCurrentTabMarkViewData()
	{
		int selectedTypeIndex = ModelBase<InventoryModel>.Instance.GetSelectedTypeIndex();
		int num = this.TabMarkPositions[selectedTypeIndex];
		if (num != -1 && this.ItemViewDataList.Count > num)
		{
			return this.ItemViewDataList[num];
		}
		if (this.ItemViewDataList.Count <= 0)
		{
			return null;
		}
		return this.ItemViewDataList[0];
	}

	// Token: 0x0600FAB8 RID: 64184 RVA: 0x0044BE54 File Offset: 0x0044A054
	private void OnFilterSortRefresh(List<global::ItemViewData> list, bool isOutSideChange, EFilterSortType operationType)
	{
		this.IsReloadData = true;
		List<global::ItemViewData> list2 = list;
		if (this.ViewMode == ItemViewDefine.EItemOperationMode.Normal)
		{
			list2 = this.ApplyDevelopDeficitPinSort(list2);
		}
		if (this.ViewMode == ItemViewDefine.EItemOperationMode.Destruction)
		{
			List<global::ItemViewData> list3 = new List<global::ItemViewData>();
			List<global::ItemViewData> list4 = new List<global::ItemViewData>();
			foreach (global::ItemViewData itemViewData in list2)
			{
				if (itemViewData.GetSelectOn())
				{
					list3.Add(itemViewData);
				}
				else
				{
					list4.Add(itemViewData);
				}
			}
			list3.AddRange(list4);
			list2 = list3;
			this.SetDestroyAllSelectedState(null, new bool?(false));
		}
		this.ItemViewDataList = list2;
		this.RefreshItemScrollView(list2);
		if (this.IsReSelectType)
		{
			this.SelectGridIndexByOpenParam(list2);
			this.SelectedItem(this.GetCurrentTabMarkViewData());
		}
		else if (operationType == EFilterSortType.Sort)
		{
			this.SelectedItem((list2.Count > 0) ? list2[0] : null);
		}
		else
		{
			global::ItemViewData itemViewData2 = null;
			if (this.SelectedItemViewData != null && this.ItemViewDataList.Contains(this.SelectedItemViewData))
			{
				itemViewData2 = this.SelectedItemViewData;
			}
			this.SelectedItem(itemViewData2 ?? ((list2.Count > 0) ? list2[0] : null));
		}
		this.IsReloadData = false;
		this.IsReSelectType = false;
	}

	// Token: 0x0600FAB9 RID: 64185 RVA: 0x0044BFA4 File Offset: 0x0044A1A4
	private void RefreshItemScrollView(List<global::ItemViewData> itemViewDataList)
	{
		if (this.ItemScrollView == null)
		{
			return;
		}
		int count = itemViewDataList.Count;
		this.ItemScrollView.RefreshByData(itemViewDataList, false, delegate
		{
			this.RefreshNoneItemVisible(itemViewDataList.Count <= 0);
		}, true);
		if (count <= 0)
		{
			ModelBase<InventoryModel>.Instance.SetSelectedItemViewData(null);
		}
	}

	// Token: 0x0600FABA RID: 64186 RVA: 0x0044C008 File Offset: 0x0044A208
	private void InitializeItemScrollView()
	{
		UUIItem item = base.GetItem(7);
		AUIBaseActor gridActor = item.GetOwner() as AUIBaseActor;
		item.SetUIActive(true);
		this.ItemScrollView = new LoopScrollView<InventoryMediumItemGrid, global::ItemViewData>(base.GetLoopScrollViewComponent(6), gridActor, new Func<InventoryMediumItemGrid>(this.OnGridProxyCreate), false);
		item.SetUIActive(false);
	}

	// Token: 0x0600FABB RID: 64187 RVA: 0x0044C058 File Offset: 0x0044A258
	private void InitializePayShopCurrencyItem()
	{
		this.CommonCurrencyItem1.RefreshTemp(2, null);
		this.CommonCurrencyItem1.SetToPayShopFunction();
		this.CommonCurrencyItem1.RefreshAddButtonActive();
		this.CommonCurrencyItem2.RefreshTemp(3, null);
		this.CommonCurrencyItem2.SetToPayShopFunction();
		this.CommonCurrencyItem2.RefreshAddButtonActive();
	}

	// Token: 0x0600FABC RID: 64188 RVA: 0x0044C0AB File Offset: 0x0044A2AB
	private InventoryMediumItemGrid OnGridProxyCreate()
	{
		InventoryMediumItemGrid inventoryMediumItemGrid = new InventoryMediumItemGrid();
		inventoryMediumItemGrid.BindOnItemButtonClickedCallback(new Action<global::ItemViewData>(this.OnItemButtonClicked));
		return inventoryMediumItemGrid;
	}

	// Token: 0x0600FABD RID: 64189 RVA: 0x0044C0C4 File Offset: 0x0044A2C4
	private void InitItemTypeList()
	{
		this.ItemTypeList = ModelBase<InventoryModel>.Instance.GetOpenIdMainTypeConfig();
		if (this.ItemTypeList.Count <= 0)
		{
			return;
		}
		this.ItemTypeList.Sort((ItemMainType aTypeConfig, ItemMainType bTypeConfig) => aTypeConfig.SequenceId - bTypeConfig.SequenceId);
	}

	// Token: 0x0600FABE RID: 64190 RVA: 0x0044C11C File Offset: 0x0044A31C
	private UniTask CreateAllItemMainTypeButton(int index)
	{
		InventoryView.<CreateAllItemMainTypeButton>d__95 <CreateAllItemMainTypeButton>d__;
		<CreateAllItemMainTypeButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateAllItemMainTypeButton>d__.<>4__this = this;
		<CreateAllItemMainTypeButton>d__.index = index;
		<CreateAllItemMainTypeButton>d__.<>1__state = -1;
		<CreateAllItemMainTypeButton>d__.<>t__builder.Start<InventoryView.<CreateAllItemMainTypeButton>d__95>(ref <CreateAllItemMainTypeButton>d__);
		return <CreateAllItemMainTypeButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600FABF RID: 64191 RVA: 0x0044C168 File Offset: 0x0044A368
	private List<CommonTabItemData> GetTabItemData(List<ItemMainType> tabData)
	{
		int count = tabData.Count;
		List<CommonTabItemData> list = this.TabComponent.CreateTabItemDataByLength(count);
		for (int i = 0; i < count; i++)
		{
			ItemMainType itemMainType = this.ItemTypeList[i];
			list[i].RedDotName = this.GetRedDotNameByItemId(itemMainType.Id);
		}
		return list;
	}

	// Token: 0x0600FAC0 RID: 64192 RVA: 0x0044C1BC File Offset: 0x0044A3BC
	private ERedDotName? GetRedDotNameByItemId(int id)
	{
		ERedDotName? result = null;
		switch (id)
		{
		case 0:
			result = new ERedDotName?(ERedDotName.InventoryVirtual);
			break;
		case 1:
			result = new ERedDotName?(ERedDotName.InventoryCommon);
			break;
		case 2:
			result = new ERedDotName?(ERedDotName.InventoryWeapon);
			break;
		case 3:
			result = new ERedDotName?(ERedDotName.InventoryPhantom);
			break;
		case 4:
			result = new ERedDotName?(ERedDotName.InventoryCollection);
			break;
		case 5:
			result = new ERedDotName?(ERedDotName.InventoryMaterial);
			break;
		case 6:
			result = new ERedDotName?(ERedDotName.InventoryMission);
			break;
		case 7:
			result = new ERedDotName?(ERedDotName.InventorySpecial);
			break;
		case 8:
			result = new ERedDotName?(ERedDotName.InventoryCard);
			break;
		}
		return result;
	}

	// Token: 0x0600FAC1 RID: 64193 RVA: 0x0044C25F File Offset: 0x0044A45F
	[NullableContext(2)]
	private CommonTabItem ProxyCreateTabItem(UUIItem uiItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x0600FAC2 RID: 64194 RVA: 0x0044C268 File Offset: 0x0044A468
	private void OnTypeButtonClicked(int index)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		if (instance.GetSelectedTypeIndex() == index)
		{
			return;
		}
		this.SaveCurrentMarkPosition();
		instance.SetSelectedTypeIndex(index);
		this.SelectedItemTypeHandle(index);
		if (index == 1)
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "InventoryPhantomTab");
		}
	}

	// Token: 0x0600FAC3 RID: 64195 RVA: 0x0044C2B4 File Offset: 0x0044A4B4
	private CommonTabData GetCommonData(int index)
	{
		ItemMainType itemMainType = this.ItemTypeList[index];
		return new CommonTabData(itemMainType.Icon, new CommonTabTitleData(itemMainType.Name, Array.Empty<object>()), null);
	}

	// Token: 0x0600FAC4 RID: 64196 RVA: 0x0044C2EC File Offset: 0x0044A4EC
	private void SelectedCurrentIndex()
	{
		int selectedTypeIndex = ModelBase<InventoryModel>.Instance.GetSelectedTypeIndex();
		this.SelectedItemTypeHandle(selectedTypeIndex);
	}

	// Token: 0x0600FAC5 RID: 64197 RVA: 0x0044C30C File Offset: 0x0044A50C
	private void SelectedItemTypeHandle(int index)
	{
		this.IsReSelectType = true;
		int id = this.ItemTypeList[index].Id;
		this.RefreshFilterSortPerformance((InventoryDefine.EItemMainTypeId)id);
		this.RefreshPhantomManageButton((InventoryDefine.EItemMainTypeId)id);
		this.TryActivateRefreshItemCdTimer();
		this.RefreshMaxCapacityNoticeAnimation();
	}

	// Token: 0x0600FAC6 RID: 64198 RVA: 0x0044C350 File Offset: 0x0044A550
	private List<global::ItemViewData> GenerateItemViewData(InventoryDefine.EItemMainTypeId itemMainType)
	{
		this.ClearAllItemViewData();
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		foreach (ItemDataBase itemDataBase in instance.GetItemDataBaseByMainType(itemMainType))
		{
			if (itemDataBase.IsShowInInventory())
			{
				CommonItemData commonItemData = itemDataBase as CommonItemData;
				if (commonItemData != null)
				{
					int maxStackCount = commonItemData.GetMaxStackCount();
					if (maxStackCount > 0)
					{
						ItemInfo value = commonItemData.GetConfig().As<ItemInfo>().Value;
						int configId = commonItemData.GetConfigId();
						this.NewCommonItemViewData(value.Id, commonItemData.GetCount(), maxStackCount, value.QualityId, false, false, instance.IsNewCommonItem(configId, 0), instance.IsCommonItemHasRedDot(configId, 0), commonItemData);
					}
				}
				else
				{
					InventoryDefine.IItemViewDataInfo itemViewDataInfo = itemDataBase.GetItemViewDataInfo(this.ViewMode);
					if (itemViewDataInfo != null)
					{
						this.NewItemViewData(itemViewDataInfo);
					}
				}
			}
		}
		return this.ItemViewDataList;
	}

	// Token: 0x0600FAC7 RID: 64199 RVA: 0x0044C444 File Offset: 0x0044A644
	private void ClearAllItemViewData()
	{
		this.ItemViewDataList.Clear();
		this.ItemViewDataMap.Clear();
	}

	// Token: 0x0600FAC8 RID: 64200 RVA: 0x0044C45C File Offset: 0x0044A65C
	private void RefreshAllItemList()
	{
		if (this.ItemTypeList == null)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (ItemMainType itemMainType in this.ItemTypeList)
		{
			int inventoryItemGridCountByMainType = ModelBase<InventoryModel>.Instance.GetInventoryItemGridCountByMainType((InventoryDefine.EItemMainTypeId)itemMainType.Id);
			ItemMainType? itemMainTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemMainTypeConfig(itemMainType.Id);
			if (itemMainTypeConfig != null)
			{
				ItemMainType value = itemMainTypeConfig.Value;
				int packageId = value.PackageId;
				PackageCapacity? packageConfig = ConfigBase<InventoryConfig>.Instance.GetPackageConfig(packageId);
				if (packageConfig != null)
				{
					int capacity = packageConfig.Value.Capacity;
					if (inventoryItemGridCountByMainType >= capacity && itemMainType.Id != 3)
					{
						string item = ConfigMultiTextLang.GetLocalTextNew(value.Name, null) + " ";
						list.Add(item);
					}
				}
			}
		}
		this.RefreshMaxCapacityNoticeAnimation();
		if (ControllerBase<InventoryController>.Instance.CheckAndShowPhantomTips())
		{
			return;
		}
		bool flag = list.Count > 0;
		if (!this.IsMaxCapacityViewShow && flag)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string value2 in list)
			{
				stringBuilder.Append(value2);
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.InventoryCapacityMax);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				stringBuilder.ToString()
			});
			this.IsMaxCapacityViewShow = true;
			confirmBoxDataNew.FunctionMap.Add(1, delegate
			{
				this.IsMaxCapacityViewShow = false;
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}

	// Token: 0x0600FAC9 RID: 64201 RVA: 0x0044C620 File Offset: 0x0044A820
	private void RefreshMaxCapacityNoticeAnimation()
	{
		int selectedTypeIndex = ModelBase<InventoryModel>.Instance.GetSelectedTypeIndex();
		ItemMainType itemMainType = this.ItemTypeList[selectedTypeIndex];
		int inventoryItemGridCountByMainType = ModelBase<InventoryModel>.Instance.GetInventoryItemGridCountByMainType((InventoryDefine.EItemMainTypeId)itemMainType.Id);
		int packageId = ConfigBase<InventoryConfig>.Instance.GetItemMainTypeConfig(itemMainType.Id).Value.PackageId;
		int capacity = ConfigBase<InventoryConfig>.Instance.GetPackageConfig(packageId).Value.Capacity;
		bool flag = inventoryItemGridCountByMainType >= capacity && itemMainType.Id != 3;
		if (this.IsMaxCapacityFlag != flag)
		{
			this.PlayMaxCapacityNoticeSequence(flag);
			this.IsMaxCapacityFlag = flag;
		}
	}

	// Token: 0x0600FACA RID: 64202 RVA: 0x0044C6C8 File Offset: 0x0044A8C8
	private void PlayMaxCapacityNoticeSequence(bool isOn)
	{
		if (isOn)
		{
			this.UiViewSequence.PlaySequence("Notice", false, null);
			return;
		}
		this.UiViewSequence.StopSequenceByKey("Notice", false, true);
	}

	// Token: 0x0600FACB RID: 64203 RVA: 0x0044C708 File Offset: 0x0044A908
	private global::ItemViewData NewItemViewData(InventoryDefine.IItemViewDataInfo itemViewInfo)
	{
		global::ItemViewData itemViewData = new global::ItemViewData(itemViewInfo);
		foreach (global::ItemViewData itemViewData2 in new List<global::ItemViewData>(this.SelectItemSet))
		{
			if (itemViewData2.IsEqual(itemViewData, new bool?(true)))
			{
				itemViewData.SetSelectOn(itemViewData2.GetSelectOn());
				itemViewData.SetSelectNum(itemViewData2.GetSelectNum());
				break;
			}
		}
		this.ItemViewDataList.Add(itemViewData);
		int configId = itemViewInfo.ConfigId;
		HashSet<global::ItemViewData> hashSet;
		if (!this.ItemViewDataMap.TryGetValue(configId, out hashSet))
		{
			hashSet = new HashSet<global::ItemViewData>();
			this.ItemViewDataMap.Add(configId, hashSet);
		}
		hashSet.Add(itemViewData);
		return itemViewData;
	}

	// Token: 0x0600FACC RID: 64204 RVA: 0x0044C7CC File Offset: 0x0044A9CC
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private HashSet<global::ItemViewData> GetItemViewDataSetByConfigId(int configId)
	{
		HashSet<global::ItemViewData> result;
		if (this.ItemViewDataMap.TryGetValue(configId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600FACD RID: 64205 RVA: 0x0044C7EC File Offset: 0x0044A9EC
	private void NewCommonItemViewData(int configId, int count, int stackCount, int qualityId, bool isLock, bool isDeprecate, bool isNewItem, bool hasRedDot, CommonItemData commonItemData)
	{
		if (stackCount <= 0)
		{
			return;
		}
		int num = count;
		int num2 = 0;
		InventoryDefine.ItemViewDataInfo itemViewDataInfo = new InventoryDefine.ItemViewDataInfo(configId, stackCount, 0, qualityId, isLock, isDeprecate, isNewItem, InventoryDefine.EItemDataType.CommonItem, commonItemData, hasRedDot, this.ViewMode, false, 0);
		while (num - stackCount > 0)
		{
			this.NewItemViewData(new InventoryDefine.ItemViewDataInfo(configId, stackCount, 0, qualityId, isLock, isDeprecate, isNewItem, InventoryDefine.EItemDataType.CommonItem, commonItemData, hasRedDot, this.ViewMode, false, 0)
			{
				Count = stackCount,
				StackId = num2
			});
			num -= stackCount;
			num2++;
		}
		itemViewDataInfo.Count = num;
		itemViewDataInfo.StackId = num2;
		this.NewItemViewData(itemViewDataInfo);
	}

	// Token: 0x0600FACE RID: 64206 RVA: 0x0044C87C File Offset: 0x0044AA7C
	[NullableContext(2)]
	private void SelectedItem(global::ItemViewData selectedItemViewData)
	{
		if (selectedItemViewData == null)
		{
			this.HideDescription();
			return;
		}
		InventoryDefine.ERedDotDisableRule redDotDisableRule = selectedItemViewData.GetRedDotDisableRule();
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		this.RemoveItemViewNewFlag(selectedItemViewData);
		if (redDotDisableRule == InventoryDefine.ERedDotDisableRule.AfterSelect || redDotDisableRule == InventoryDefine.ERedDotDisableRule.ServerFirstSelect)
		{
			this.RemoveItemViewRedDot(selectedItemViewData);
		}
		if (selectedItemViewData.GetItemDataType() == InventoryDefine.EItemDataType.CommonItem)
		{
			instance.SaveNewCommonItemConfigIdList();
			instance.SaveRedDotCommonItemConfigIdList();
		}
		else
		{
			instance.SaveNewAttributeItemUniqueIdList();
			instance.SaveRedDotAttributeItemUniqueIdList();
		}
		this.RefreshSelectedItemView(selectedItemViewData);
		this.RefreshSameConfigIdItemView(selectedItemViewData);
		this.RefreshItemDescription(selectedItemViewData);
		this.SaveCurrentMarkPosition();
		if (this.ViewMode == ItemViewDefine.EItemOperationMode.Destruction)
		{
			this.RefreshDestroyModeViewByItem(selectedItemViewData, this.IsReloadData);
			if (!this.IsReloadData)
			{
				this.TrySetItemDestroyModeSelectOn(!selectedItemViewData.GetSelectOn(), selectedItemViewData);
			}
		}
	}

	// Token: 0x0600FACF RID: 64207 RVA: 0x0044C928 File Offset: 0x0044AB28
	private void RefreshCapacity(InventoryDefine.EItemMainTypeId itemMainTypeId, List<global::ItemViewData> allItemDataList)
	{
		InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
		ItemMainType? itemMainTypeConfig = instance.GetItemMainTypeConfig((int)itemMainTypeId);
		if (itemMainTypeConfig != null)
		{
			ItemMainType value = itemMainTypeConfig.Value;
			string name = value.Name;
			int packageId = value.PackageId;
			PackageCapacity? packageConfig = instance.GetPackageConfig(packageId);
			if (packageConfig != null)
			{
				PackageCapacity value2 = packageConfig.Value;
				UUIText text = base.GetText(5);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, name, Array.Empty<object>());
				int count = allItemDataList.Count;
				int capacity = value2.Capacity;
				UUIText text2 = base.GetText(2);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
				if (count >= capacity)
				{
					UUIText uuitext = text2;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 2);
					defaultInterpolatedStringHandler.AppendLiteral("<color=red>");
					defaultInterpolatedStringHandler.AppendFormatted<int>(count);
					defaultInterpolatedStringHandler.AppendLiteral("</color>/");
					defaultInterpolatedStringHandler.AppendFormatted<int>(capacity);
					uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
					Singleton<AudioSystem>.Instance.PostEvent("ui_inventory_capacity_full");
					return;
				}
				UUIText uuitext2 = text2;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(count);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(capacity);
				uuitext2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}
	}

	// Token: 0x0600FAD0 RID: 64208 RVA: 0x0044CA4C File Offset: 0x0044AC4C
	private void RefreshNoneItemVisible(bool bVisible)
	{
		UUIItem item = base.GetItem(4);
		ULGUIBehaviour loopScrollViewComponent = base.GetLoopScrollViewComponent(6);
		item.SetUIActive(bVisible);
		loopScrollViewComponent.RootUIComp.Get().SetUIActive(!bVisible);
		this.RefreshDestroyEnterButton();
		if (bVisible && this.ViewMode == ItemViewDefine.EItemOperationMode.Destruction)
		{
			this.SetDestroyViewMode(ItemViewDefine.EDestroyViewMode.Default);
		}
	}

	// Token: 0x0600FAD1 RID: 64209 RVA: 0x0044CAA0 File Offset: 0x0044ACA0
	private void OnItemButtonClicked(global::ItemViewData itemViewData)
	{
		if (this.SelectedItemViewData == itemViewData)
		{
			int gridIndex = this.ItemViewDataList.IndexOf(itemViewData);
			this.ItemScrollView.DeselectCurrentGridProxy(false);
			this.ItemScrollView.SelectGridProxy(gridIndex, false);
			if (this.ViewMode == ItemViewDefine.EItemOperationMode.Destruction)
			{
				this.TrySetItemDestroyModeSelectOn(!itemViewData.GetSelectOn(), itemViewData);
			}
			return;
		}
		this.SelectedItem(itemViewData);
	}

	// Token: 0x0600FAD2 RID: 64210 RVA: 0x0044CB00 File Offset: 0x0044AD00
	private void SaveCurrentMarkPosition()
	{
		int selectedTypeIndex = ModelBase<InventoryModel>.Instance.GetSelectedTypeIndex();
		this.TabMarkPositions[selectedTypeIndex] = this.ItemScrollView.GetSelectedGridIndex();
	}

	// Token: 0x0600FAD3 RID: 64211 RVA: 0x0044CB2C File Offset: 0x0044AD2C
	private void RefreshSelectedItemView(global::ItemViewData itemViewData)
	{
		if (this.SelectedItemViewData != null)
		{
			this.ItemScrollView.DeselectCurrentGridProxy(false);
		}
		int num = this.ItemViewDataList.IndexOf(itemViewData);
		if (!this.ItemScrollView.IsGridDisplaying(num))
		{
			this.ItemScrollView.ScrollToGridIndex(num, true);
		}
		this.SelectedItemViewData = itemViewData;
		this.SelectedItemIndex = num;
		ModelBase<InventoryModel>.Instance.SetSelectedItemViewData(itemViewData);
		this.ItemScrollView.SelectGridProxy(num, true);
		this.ItemScrollView.RefreshGridProxy(num);
		this.RefreshItemTipsFunction(itemViewData);
	}

	// Token: 0x0600FAD4 RID: 64212 RVA: 0x0044CBB0 File Offset: 0x0044ADB0
	private void RemoveItemViewNewFlag(global::ItemViewData removeItemViewData)
	{
		removeItemViewData.RemoveNewItem();
		if (removeItemViewData.GetUniqueId() > 0)
		{
			return;
		}
		HashSet<global::ItemViewData> itemViewDataSetByConfigId = this.GetItemViewDataSetByConfigId(removeItemViewData.GetConfigId());
		if (itemViewDataSetByConfigId == null)
		{
			return;
		}
		foreach (global::ItemViewData itemViewData in itemViewDataSetByConfigId)
		{
			if (itemViewData != removeItemViewData)
			{
				itemViewData.RemoveNewItem();
			}
		}
	}

	// Token: 0x0600FAD5 RID: 64213 RVA: 0x0044CC24 File Offset: 0x0044AE24
	private void RemoveItemViewRedDot(global::ItemViewData removeItemViewData)
	{
		removeItemViewData.RemoveRedDotItem();
		if (removeItemViewData.GetUniqueId() > 0)
		{
			return;
		}
		HashSet<global::ItemViewData> itemViewDataSetByConfigId = this.GetItemViewDataSetByConfigId(removeItemViewData.GetConfigId());
		if (itemViewDataSetByConfigId == null)
		{
			return;
		}
		foreach (global::ItemViewData itemViewData in itemViewDataSetByConfigId)
		{
			if (itemViewData != removeItemViewData)
			{
				itemViewData.RemoveRedDotItem();
			}
		}
	}

	// Token: 0x0600FAD6 RID: 64214 RVA: 0x0044CC98 File Offset: 0x0044AE98
	private void RefreshSameConfigIdItemView(global::ItemViewData checkItemViewData)
	{
		if (checkItemViewData.GetUniqueId() > 0)
		{
			return;
		}
		HashSet<global::ItemViewData> itemViewDataSetByConfigId = this.GetItemViewDataSetByConfigId(checkItemViewData.GetConfigId());
		if (itemViewDataSetByConfigId == null)
		{
			return;
		}
		foreach (global::ItemViewData itemViewData in itemViewDataSetByConfigId)
		{
			if (itemViewData != checkItemViewData)
			{
				int gridIndex = this.ItemViewDataList.IndexOf(itemViewData);
				this.ItemScrollView.RefreshGridProxy(gridIndex);
			}
		}
	}

	// Token: 0x0600FAD7 RID: 64215 RVA: 0x0044CD18 File Offset: 0x0044AF18
	public void RefreshItemTipsFunction(global::ItemViewData itemViewData)
	{
		InventoryDefine.EItemType itemType = this.SelectedItemViewData.GetItemType();
		ItemDataBase itemDataBase = itemViewData.GetItemDataBase();
		this.ItemTipsComponent.ClearButtonList();
		List<ItemViewDefine.ETipsButtonType> tipsButtonListByCurrentItemData = this.GetTipsButtonListByCurrentItemData(itemDataBase);
		this.RefreshButtonByTypeList(tipsButtonListByCurrentItemData);
		if (itemType == InventoryDefine.EItemType.SpecialItem)
		{
			if (ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(false) && !tipsButtonListByCurrentItemData.Contains(ItemViewDefine.ETipsButtonType.FragmentMemory) && !tipsButtonListByCurrentItemData.Contains(ItemViewDefine.ETipsButtonType.QuestReview))
			{
				this.RefreshSpecialItemText();
				return;
			}
		}
		else if (itemType != InventoryDefine.EItemType.Phantom && itemType != InventoryDefine.EItemType.Weapon)
		{
			if (itemDataBase.IsBuffEquipItem())
			{
				this.RefreshBuffEquipItemFunction(itemDataBase);
				return;
			}
			this.RefreshNormalItemFunction(itemDataBase);
		}
	}

	// Token: 0x0600FAD8 RID: 64216 RVA: 0x0044CDA0 File Offset: 0x0044AFA0
	public void RefreshItemDescription(global::ItemViewData itemViewData)
	{
		ItemDataBase itemDataBase = itemViewData.GetItemDataBase();
		int configId = itemDataBase.GetConfigId();
		int uniqueId = itemDataBase.GetUniqueId();
		ItemTipsData tipsDataById = ItemTipsComponentUtilTool.GetTipsDataById(configId, new int?(uniqueId), null);
		tipsDataById.ShowPreview = false;
		this.ItemTipsComponent.SetPreviewVisible(tipsDataById.PreviewType != ESkipName.NoSkip);
		ItemViewDefine.EItemOperationMode viewMode = this.ViewMode;
		if (viewMode != ItemViewDefine.EItemOperationMode.Normal)
		{
			if (viewMode == ItemViewDefine.EItemOperationMode.Destruction)
			{
				IGetWayItemData[] array = tipsDataById.GetWayData ?? Array.Empty<IGetWayItemData>();
				IGetWayItemData[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].Function = new Action(this.ForbiddenJumpFunction);
				}
				tipsDataById.GetWayData = array;
				this.ItemTipsComponent.RefreshTips(tipsDataById);
				this.ItemTipsComponent.SetVisible(true);
				this.ItemTipsComponent.SetTipsComponentLockButton(false);
			}
		}
		else
		{
			this.ItemTipsComponent.RefreshTips(tipsDataById);
			this.ItemTipsComponent.SetVisible(true);
		}
		this.LevelSequencePlayer.StopCurrentSequence(false, false);
	}

	// Token: 0x0600FAD9 RID: 64217 RVA: 0x0044CE8E File Offset: 0x0044B08E
	private void OnSpecialItemUpdate(int? itemId)
	{
		this.RefreshSpecialItemText();
	}

	// Token: 0x0600FADA RID: 64218 RVA: 0x0044CE96 File Offset: 0x0044B096
	private void ForbiddenJumpFunction()
	{
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ItemDestroyNotJump", Array.Empty<object>());
	}

	// Token: 0x0600FADB RID: 64219 RVA: 0x0044CEAC File Offset: 0x0044B0AC
	private void HideDescription()
	{
		this.ItemTipsComponent.SetVisible(false);
	}

	// Token: 0x0600FADC RID: 64220 RVA: 0x0044CEBC File Offset: 0x0044B0BC
	private void SetTipsButtonEnableByType(ItemViewDefine.ETipsButtonType type, bool bEnable)
	{
		int num;
		if (this.TipsButtonIndexMap.TryGetValue(type, out num) && num != 0)
		{
			this.ItemTipsComponent.SetButtonEnableByIndex(num, bEnable);
		}
	}

	// Token: 0x0600FADD RID: 64221 RVA: 0x0044CEEC File Offset: 0x0044B0EC
	private void SetTipsButtonTextByType(ItemViewDefine.ETipsButtonType type, string text, [Nullable(new byte[]
	{
		2,
		1
	})] string[] @params = null)
	{
		if (this.TipsButtonIndexMap.ContainsKey(type))
		{
			int index;
			this.TipsButtonIndexMap.TryGetValue(type, out index);
			this.ItemTipsComponent.SetButtonTextByIndex(index, text, @params);
		}
	}

	// Token: 0x0600FADE RID: 64222 RVA: 0x0044CF28 File Offset: 0x0044B128
	private void SetTipsButtonRedDotVisibleByType(ItemViewDefine.ETipsButtonType type, bool bVisible)
	{
		int index;
		if (this.TipsButtonIndexMap.TryGetValue(type, out index))
		{
			this.ItemTipsComponent.SetButtonRedDotVisible(index, bVisible);
		}
	}

	// Token: 0x0600FADF RID: 64223 RVA: 0x0044CF54 File Offset: 0x0044B154
	private void RefreshButtonByTypeList(List<ItemViewDefine.ETipsButtonType> typeList)
	{
		int num = 0;
		List<IButtonInfo> list = new List<IButtonInfo>();
		this.TipsButtonIndexMap.Clear();
		foreach (ItemViewDefine.ETipsButtonType key in typeList)
		{
			IButtonInfo buttonInfo;
			if (!this.TipsButtonRelationMap.TryGetValue(key, out buttonInfo))
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.YYZ, "背包Tips按钮功能设置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			buttonInfo.Index = num;
			this.TipsButtonIndexMap.Add(key, num);
			list.Add(buttonInfo);
			num++;
		}
		this.ItemTipsComponent.RefreshButton(list);
	}

	// Token: 0x0600FAE0 RID: 64224 RVA: 0x0044D00C File Offset: 0x0044B20C
	private bool IsDestroyModeSelectMax()
	{
		return this.SelectItemSet.Count == 100;
	}

	// Token: 0x0600FAE1 RID: 64225 RVA: 0x0044D020 File Offset: 0x0044B220
	protected void SetViewMode(ItemViewDefine.EItemOperationMode viewMode)
	{
		ItemViewDefine.EItemOperationMode viewMode2 = this.ViewMode;
		this.ViewMode = viewMode;
		this.SelectItemSet.Clear();
		UUIButtonComponent button = base.GetButton(14);
		UUIButtonComponent button2 = base.GetButton(20);
		UUIExtendToggle extendToggle = base.GetExtendToggle(18);
		UUIItem item = base.GetItem(15);
		UUIText text = base.GetText(16);
		UUIText text2 = base.GetText(17);
		if (viewMode2 != this.ViewMode)
		{
			this.ClearFilterSortComponentData(viewMode2);
		}
		this.TabComponent.NeedCaptionSwitchWithToggle = (this.ViewMode == ItemViewDefine.EItemOperationMode.Normal);
		int selectedTypeIndex = ModelBase<InventoryModel>.Instance.GetSelectedTypeIndex();
		this.TabComponent.SelectToggleByIndex(selectedTypeIndex, true);
		this.SelectedCurrentIndex();
		this.RefreshDestroyEnterButton();
		ItemViewDefine.EItemOperationMode viewMode3 = this.ViewMode;
		if (viewMode3 != ItemViewDefine.EItemOperationMode.Normal)
		{
			if (viewMode3 == ItemViewDefine.EItemOperationMode.Destruction)
			{
				this.TabComponent.SetTitle(ConfigMultiTextLang.GetLocalTextNew("Text_ItemRecycle_text", null));
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_DestroyModeIcon");
				this.TabComponent.SetTitleIcon(resourcePath);
				this.TabComponent.SetCloseBtnShowState(false);
				button.RootUIComp.Get().SetUIActive(true);
				this.ItemTipsComponent.SetButtonPanelVisible(false);
				button2.RootUIComp.Get().SetUIActive(true);
				item.SetUIActive(true);
				this.RefreshTotalSelectOnNum();
				text2.SetUIActive(true);
			}
		}
		else
		{
			this.TabComponent.SetCloseBtnShowState(true);
			button.RootUIComp.Get().SetUIActive(false);
			this.ItemTipsComponent.SetButtonPanelVisible(true);
			extendToggle.RootUIComp.Get().SetUIActive(false);
			button2.RootUIComp.Get().SetUIActive(false);
			this.NumberSelect.SetUiActive(false);
			item.SetUIActive(false);
			text.SetUIActive(false);
			text2.SetUIActive(false);
		}
		if (viewMode2 == this.ViewMode)
		{
			return;
		}
		string sequenceName = (viewMode2 == ItemViewDefine.EItemOperationMode.Normal) ? "DestroyShow" : "DestroyHide";
		this.UiViewSequence.PlaySequence(sequenceName, true, null);
	}

	// Token: 0x0600FAE2 RID: 64226 RVA: 0x0044D224 File Offset: 0x0044B424
	protected void SetDestroyViewMode(ItemViewDefine.EDestroyViewMode destroyViewMode)
	{
		this.DestroyViewMode = destroyViewMode;
		UUIText text = base.GetText(16);
		switch (this.DestroyViewMode)
		{
		case ItemViewDefine.EDestroyViewMode.Default:
		{
			int selectedTypeIndex = ModelBase<InventoryModel>.Instance.GetSelectedTypeIndex();
			int id = this.ItemTypeList[selectedTypeIndex].Id;
			ItemMainType? itemMainTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemMainTypeConfig(id);
			bool flag = false;
			if (itemMainTypeConfig != null)
			{
				flag = itemMainTypeConfig.Value.BFilterSortVisible;
			}
			if (!flag)
			{
				text.ShowTextNew("Text_ItemRecycleChooseTip_text");
			}
			text.SetUIActive(!flag);
			this.FilterSortEntrance.SetUiActive(flag);
			this.SetDestroyAllSelectedState(new bool?(flag), null);
			this.NumberSelect.SetUiActive(false);
			break;
		}
		case ItemViewDefine.EDestroyViewMode.Disabled:
			text.SetUIActive(true);
			text.ShowTextNew("Text_ItemRecycleLimited_text");
			this.NumberSelect.SetUiActive(false);
			this.FilterSortEntrance.SetUiActive(false);
			this.SetDestroyAllSelectedState(new bool?(false), null);
			break;
		case ItemViewDefine.EDestroyViewMode.Multiple:
			text.SetUIActive(false);
			this.NumberSelect.SetUiActive(true);
			this.FilterSortEntrance.SetUiActive(false);
			this.SetDestroyAllSelectedState(new bool?(false), null);
			break;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Inventory;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "切换摧毁模式表现";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Mode", this.DestroyViewMode.ToString());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600FAE3 RID: 64227 RVA: 0x0044D3A8 File Offset: 0x0044B5A8
	private void RefreshDestroyModeViewByItem(global::ItemViewData itemViewData, bool isReloadData)
	{
		if (!itemViewData.IsItemCanDestroy())
		{
			this.SetDestroyViewMode(isReloadData ? ItemViewDefine.EDestroyViewMode.Default : ItemViewDefine.EDestroyViewMode.Disabled);
			return;
		}
		InventoryDefine.EItemDataType itemDataType = itemViewData.GetItemDataType();
		if (itemDataType != InventoryDefine.EItemDataType.CommonItem)
		{
			if (itemDataType - InventoryDefine.EItemDataType.WeaponItem > 1)
			{
				return;
			}
			this.SetDestroyViewMode(ItemViewDefine.EDestroyViewMode.Default);
		}
		else
		{
			this.SetDestroyViewMode(isReloadData ? ItemViewDefine.EDestroyViewMode.Default : ItemViewDefine.EDestroyViewMode.Multiple);
			if (!isReloadData)
			{
				this.RefreshNumberSelect(itemViewData);
				return;
			}
		}
	}

	// Token: 0x0600FAE4 RID: 64228 RVA: 0x0044D400 File Offset: 0x0044B600
	[NullableContext(2)]
	private void TrySetItemDestroyModeSelectOn(bool isSelectedOn, global::ItemViewData itemViewData)
	{
		if (itemViewData == null)
		{
			return;
		}
		if (this.IsDestroyModeSelectMax() && isSelectedOn)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ItemDestroyCountLimit", Array.Empty<object>());
			return;
		}
		if (!itemViewData.IsItemCanDestroy())
		{
			if (this.DestroyViewMode != ItemViewDefine.EDestroyViewMode.Disabled)
			{
				this.SetDestroyViewMode(ItemViewDefine.EDestroyViewMode.Disabled);
			}
			return;
		}
		int num = this.ItemViewDataList.IndexOf(itemViewData);
		if (num < 0)
		{
			return;
		}
		foreach (global::ItemViewData itemViewData2 in new List<global::ItemViewData>(this.SelectItemSet))
		{
			if (itemViewData2.IsEqual(itemViewData, new bool?(true)))
			{
				this.SelectItemSet.Remove(itemViewData2);
				break;
			}
		}
		if (isSelectedOn)
		{
			this.SelectItemSet.Add(itemViewData);
			itemViewData.SetSelectNum(1);
		}
		else
		{
			itemViewData.SetSelectNum(0);
		}
		itemViewData.SetSelectOn(isSelectedOn);
		this.ItemScrollView.RefreshGridProxy(num);
		this.RefreshSelectOnPerformance(isSelectedOn, itemViewData);
	}

	// Token: 0x0600FAE5 RID: 64229 RVA: 0x0044D4F8 File Offset: 0x0044B6F8
	private void RefreshSelectOnPerformance(bool isSelectedOn, global::ItemViewData itemViewData)
	{
		this.RefreshTotalSelectOnNum();
		ItemViewDefine.EDestroyViewMode destroyViewMode = this.DestroyViewMode;
		if (destroyViewMode != ItemViewDefine.EDestroyViewMode.Default)
		{
			if (destroyViewMode != ItemViewDefine.EDestroyViewMode.Multiple)
			{
				return;
			}
			if (isSelectedOn)
			{
				this.RefreshNumberSelect(this.SelectedItemViewData);
				return;
			}
			this.SetDestroyViewMode(ItemViewDefine.EDestroyViewMode.Default);
		}
		else if (isSelectedOn)
		{
			this.RefreshDestroyModeViewByItem(itemViewData, false);
			return;
		}
	}

	// Token: 0x0600FAE6 RID: 64230 RVA: 0x0044D540 File Offset: 0x0044B740
	protected void SetDestroyAllSelectedState(bool? isShow = null, bool? isOn = null)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(18);
		if (isShow != null)
		{
			extendToggle.RootUIComp.Get().SetUIActive(isShow.Value);
		}
		if (isOn != null)
		{
			extendToggle.SetToggleState(isOn.Value ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600FAE7 RID: 64231 RVA: 0x0044D59C File Offset: 0x0044B79C
	private void RefreshTotalSelectOnNum()
	{
		int count = this.SelectItemSet.Count;
		UUIText text = base.GetText(17);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Text_ItemRecycleChosenTotal_text", new <>z__ReadOnlyArray<object>(new object[]
		{
			count.ToString(),
			100.ToString()
		}));
	}

	// Token: 0x0600FAE8 RID: 64232 RVA: 0x0044D5F0 File Offset: 0x0044B7F0
	private void RefreshDestroyEnterButton()
	{
		ULGUIBehaviour button = base.GetButton(13);
		bool flag = this.ViewMode == ItemViewDefine.EItemOperationMode.Destruction;
		bool flag2 = this.ItemScrollView.EndGridIndex >= 0;
		button.RootUIComp.Get().SetUIActive(!flag && flag2 && !ModelBase<RecallQuestModel>.Instance.IsInRecallInstance());
	}

	// Token: 0x0600FAE9 RID: 64233 RVA: 0x0044D64C File Offset: 0x0044B84C
	protected void OnClickedDestroyExecuteButton()
	{
		InventoryView.<>c__DisplayClass140_0 CS$<>8__locals1 = new InventoryView.<>c__DisplayClass140_0();
		CS$<>8__locals1.<>4__this = this;
		if (this.ViewMode != ItemViewDefine.EItemOperationMode.Destruction)
		{
			return;
		}
		if (this.SelectItemSet.Count == 0)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ItemDestroyNotChoose", Array.Empty<object>());
			return;
		}
		bool flag = false;
		bool flag2 = false;
		CS$<>8__locals1.ifHighQuality = false;
		CS$<>8__locals1.itemList = new List<DecomposeItemInfo>();
		List<global::ItemViewData> list = new List<global::ItemViewData>(this.SelectItemSet);
		list.Sort(new Comparison<global::ItemViewData>(this.SortViewDataConfigId));
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			int num = 0;
			while (i + 1 < count && list[i].GetConfigId() == list[i + 1].GetConfigId() && list[i].GetUniqueId() == 0 && list[i + 1].GetUniqueId() == 0)
			{
				num += list[i].GetSelectNum();
				i++;
			}
			DecomposeItemInfo decomposeItemInfo = DecomposeItemInfo.Create();
			decomposeItemInfo.ItemId = list[i].GetConfigId();
			decomposeItemInfo.IncrId = list[i].GetUniqueId();
			decomposeItemInfo.Count = num + list[i].GetSelectNum();
			CS$<>8__locals1.itemList.Add(decomposeItemInfo);
			if (decomposeItemInfo.IncrId > 0 && ModelBase<VisionEquipGroupModel>.Instance.CheckVisionListIfInGroup(new List<int>
			{
				decomposeItemInfo.IncrId
			}))
			{
				flag = true;
			}
			if (list[i].GetQuality() >= 4)
			{
				CS$<>8__locals1.ifHighQuality = true;
			}
			if (flag || (!flag2 & CS$<>8__locals1.ifHighQuality))
			{
				flag2 = true;
			}
		}
		if (ModelBase<InventoryModel>.Instance.IsConfirmDestruction || !flag2)
		{
			CS$<>8__locals1.<OnClickedDestroyExecuteButton>g__confirmCallback|0();
			return;
		}
		if (flag)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DestroyVisionInGroup);
			confirmBoxDataNew.FunctionMap.Add(2, new Action(CS$<>8__locals1.<OnClickedDestroyExecuteButton>g__openConfirmDestroyConfirm|1));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		CS$<>8__locals1.<OnClickedDestroyExecuteButton>g__openConfirmDestroyConfirm|1();
	}

	// Token: 0x0600FAEA RID: 64234 RVA: 0x0044D840 File Offset: 0x0044BA40
	private void OnClickedNotShowConfirm(bool toggleState)
	{
		ModelBase<InventoryModel>.Instance.IsConfirmDestruction = toggleState;
	}

	// Token: 0x0600FAEB RID: 64235 RVA: 0x0044D84D File Offset: 0x0044BA4D
	private void OnClickedAllSelect(EToggleState toggleState)
	{
		if (this.ViewMode != ItemViewDefine.EItemOperationMode.Destruction)
		{
			return;
		}
		this.<OnClickedAllSelect>g__selectAll|142_0(toggleState == EToggleState.ETT_Checked);
	}

	// Token: 0x0600FAEC RID: 64236 RVA: 0x0044D864 File Offset: 0x0044BA64
	private void OnClickedManage()
	{
		global::ItemViewData selectedItemViewData = this.SelectedItemViewData;
		int num = (selectedItemViewData != null) ? selectedItemViewData.GetUniqueId() : 0;
		global::ItemViewData selectedItemViewData2 = this.SelectedItemViewData;
		if (selectedItemViewData2 == null || selectedItemViewData2.GetItemDataType() != InventoryDefine.EItemDataType.PhantomItem)
		{
			num = 0;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomManageView, num, null);
	}

	// Token: 0x0600FAED RID: 64237 RVA: 0x0044D8B6 File Offset: 0x0044BAB6
	private void OnClickedRecovery()
	{
		ControllerBase<CalabashController>.Instance.JumpToCalabashRootView(EUiTabViewName.VisionRecoveryTabView, null);
	}

	// Token: 0x0600FAEE RID: 64238 RVA: 0x0044D8C8 File Offset: 0x0044BAC8
	protected int SortViewDataSelectOn(global::ItemViewData dataA, global::ItemViewData dataB)
	{
		int num = (dataA.GetSelectOn() > false) ? 1 : 0;
		return ((dataB.GetSelectOn() > false) ? 1 : 0) - num;
	}

	// Token: 0x0600FAEF RID: 64239 RVA: 0x0044D8EA File Offset: 0x0044BAEA
	protected int SortViewDataConfigId(global::ItemViewData dataA, global::ItemViewData dataB)
	{
		return dataA.GetConfigId() - dataB.GetConfigId();
	}

	// Token: 0x0600FAF0 RID: 64240 RVA: 0x0044D8FC File Offset: 0x0044BAFC
	[NullableContext(2)]
	private void RefreshNumberSelect(global::ItemViewData itemViewData)
	{
		if (itemViewData == null)
		{
			return;
		}
		INumberSelectData data = new INumberSelectData
		{
			MaxNumber = itemViewData.GetCount(),
			GetExchangeTableText = new Func<int, TableTextArgNew>(this.GetExchangeTableText),
			ValueChangeFunction = new Action<int>(this.ValueChangeFunction)
		};
		this.NumberSelect.Init(data);
	}

	// Token: 0x0600FAF1 RID: 64241 RVA: 0x0044D94F File Offset: 0x0044BB4F
	private TableTextArgNew GetExchangeTableText(int selectValue)
	{
		return new TableTextArgNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("ItemRecycleCount"), new <>z__ReadOnlySingleElementList<object>(selectValue));
	}

	// Token: 0x0600FAF2 RID: 64242 RVA: 0x0044D970 File Offset: 0x0044BB70
	private void ValueChangeFunction(int selectValue)
	{
		if (this.SelectedItemViewData == null)
		{
			return;
		}
		int num = this.ItemViewDataList.IndexOf(this.SelectedItemViewData);
		if (num < 0)
		{
			return;
		}
		this.SelectedItemViewData.SetSelectNum(selectValue);
		this.ItemScrollView.RefreshGridProxy(num);
	}

	// Token: 0x0600FAF3 RID: 64243 RVA: 0x0044D9B8 File Offset: 0x0044BBB8
	private unsafe void SelectTypeIndexByOpenParam()
	{
		if (this.OpenParam == null)
		{
			return;
		}
		if (!(this.OpenParam is int))
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.CB, "跳转参数类型错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int num = (int)this.OpenParam;
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(num);
		if (attributeItemData == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Inventory;
			ELogAuthor author = ELogAuthor.CB;
			string message = "要定位的背包物品不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("uniqueId", num);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		InventoryDefine.EItemMainTypeId? mainType = attributeItemData.GetMainType();
		int num2 = this.ItemTypeList.FindIndex((ItemMainType item) => item.Id == (int)mainType.Value);
		if (num2 != -1)
		{
			ModelBase<InventoryModel>.Instance.SetSelectedTypeIndex(num2);
			return;
		}
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module2 = ELogModule.Inventory;
		ELogAuthor author2 = ELogAuthor.CB;
		string message2 = "要定位的物品找不到对应页签";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("uniqueId", num);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("mainType", mainType);
		instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0600FAF4 RID: 64244 RVA: 0x0044DAE0 File Offset: 0x0044BCE0
	private void SelectGridIndexByOpenParam(List<global::ItemViewData> itemViewDataList)
	{
		if (this.OpenParam == null)
		{
			return;
		}
		if (!(this.OpenParam is int))
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.CB, "跳转参数类型错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int uniqueId = (int)this.OpenParam;
		int num = itemViewDataList.FindIndex((global::ItemViewData item) => item.GetUniqueId() == uniqueId);
		if (num != -1)
		{
			this.SaveCurrentMarkPositionByGridIndex(num);
		}
		else
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Inventory;
			ELogAuthor author = ELogAuthor.CB;
			string message = "要定位的物品找不到对应格子";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("uniqueId", uniqueId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.OpenParam = null;
	}

	// Token: 0x0600FAF5 RID: 64245 RVA: 0x0044DB90 File Offset: 0x0044BD90
	private void SaveCurrentMarkPositionByGridIndex(int gridIndex)
	{
		int selectedTypeIndex = ModelBase<InventoryModel>.Instance.GetSelectedTypeIndex();
		this.TabMarkPositions[selectedTypeIndex] = gridIndex;
	}

	// Token: 0x0600FAF6 RID: 64246 RVA: 0x0044DBB4 File Offset: 0x0044BDB4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "Filter"))
		{
			return null;
		}
		UUIItem filterToggleItem = this.FilterSortEntrance.GetFilterToggleItem();
		if (filterToggleItem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			filterToggleItem,
			filterToggleItem
		};
	}

	// Token: 0x0600FAF7 RID: 64247 RVA: 0x0044DBF4 File Offset: 0x0044BDF4
	[NullableContext(0)]
	public virtual bool TryGetMember(string key, out object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 8:
				if (key == "ViewMode")
				{
					value = this.ViewMode;
					return true;
				}
				break;
			case 12:
			{
				char c = key[1];
				if (c != 'a')
				{
					switch (c)
					{
					case 's':
						if (key == "IsReloadData")
						{
							value = this.IsReloadData;
							return true;
						}
						break;
					case 't':
						if (key == "ItemTypeList")
						{
							value = this.ItemTypeList;
							return true;
						}
						break;
					case 'u':
						if (key == "NumberSelect")
						{
							value = this.NumberSelect;
							return true;
						}
						break;
					}
				}
				else if (key == "TabComponent")
				{
					value = this.TabComponent;
					return true;
				}
				break;
			}
			case 13:
				if (key == "SelectItemSet")
				{
					value = this.SelectItemSet;
					return true;
				}
				break;
			case 14:
			{
				char c = key[1];
				if (c != 's')
				{
					if (c == 't')
					{
						if (key == "ItemScrollView")
						{
							value = this.ItemScrollView;
							return true;
						}
					}
				}
				else if (key == "IsReSelectType")
				{
					value = this.IsReSelectType;
					return true;
				}
				break;
			}
			case 15:
			{
				char c = key[0];
				if (c != 'D')
				{
					if (c == 'I')
					{
						if (key == "ItemViewDataMap")
						{
							value = this.ItemViewDataMap;
							return true;
						}
					}
				}
				else if (key == "DestroyViewMode")
				{
					value = this.DestroyViewMode;
					return true;
				}
				break;
			}
			case 16:
			{
				char c = key[0];
				if (c <= 'I')
				{
					if (c != 'C')
					{
						if (c == 'I')
						{
							if (key == "ItemViewDataList")
							{
								value = this.ItemViewDataList;
								return true;
							}
						}
					}
					else if (key == "CurrentCdItemMap")
					{
						value = this.CurrentCdItemMap;
						return true;
					}
				}
				else if (c != 'R')
				{
					if (c == 'T')
					{
						if (key == "TabMarkPositions")
						{
							value = this.TabMarkPositions;
							return true;
						}
					}
				}
				else if (key == "RefreshCdTimerId")
				{
					value = this.RefreshCdTimerId;
					return true;
				}
				break;
			}
			case 17:
			{
				char c = key[1];
				if (c != 'e')
				{
					if (c != 's')
					{
						if (c == 't')
						{
							if (key == "ItemTipsComponent")
							{
								value = this.ItemTipsComponent;
								return true;
							}
						}
					}
					else if (key == "IsMaxCapacityFlag")
					{
						value = this.IsMaxCapacityFlag;
						return true;
					}
				}
				else if (key == "SelectedItemIndex")
				{
					value = this.SelectedItemIndex;
					return true;
				}
				break;
			}
			case 18:
			{
				char c = key[0];
				if (c != 'F')
				{
					if (c == 'T')
					{
						if (key == "TipsButtonIndexMap")
						{
							value = this.TipsButtonIndexMap;
							return true;
						}
					}
				}
				else if (key == "FilterSortEntrance")
				{
					value = this.FilterSortEntrance;
					return true;
				}
				break;
			}
			case 19:
			{
				char c = key[18];
				if (c <= '2')
				{
					if (c != '1')
					{
						if (c == '2')
						{
							if (key == "CommonCurrencyItem2")
							{
								value = this.CommonCurrencyItem2;
								return true;
							}
						}
					}
					else if (key == "CommonCurrencyItem1")
					{
						value = this.CommonCurrencyItem1;
						return true;
					}
				}
				else if (c != 'r')
				{
					if (c == 't')
					{
						if (key == "InvalidItemTempList")
						{
							value = this.InvalidItemTempList;
							return true;
						}
					}
				}
				else if (key == "LevelSequencePlayer")
				{
					value = this.LevelSequencePlayer;
					return true;
				}
				break;
			}
			case 20:
			{
				char c = key[0];
				if (c != 'A')
				{
					if (c == 'S')
					{
						if (key == "SelectedItemViewData")
						{
							value = this.SelectedItemViewData;
							return true;
						}
					}
				}
				else if (key == "AccessPathButtonList")
				{
					value = this.AccessPathButtonList;
					return true;
				}
				break;
			}
			case 21:
			{
				char c = key[2];
				if (c != 'I')
				{
					if (c != 'M')
					{
						if (c == 'p')
						{
							if (key == "TipsButtonRelationMap")
							{
								value = this.TipsButtonRelationMap;
								return true;
							}
						}
					}
					else if (key == "IsMaxCapacityViewShow")
					{
						value = this.IsMaxCapacityViewShow;
						return true;
					}
				}
				else if (key == "IsInvalidItemViewShow")
				{
					value = this.IsInvalidItemViewShow;
					return true;
				}
				break;
			}
			case 23:
				if (key == "CacheExpireShowDataList")
				{
					value = this.CacheExpireShowDataList;
					return true;
				}
				break;
			case 27:
				if (key == "IsExpireConvertItemViewShow")
				{
					value = this.IsExpireConvertItemViewShow;
					return true;
				}
				break;
			}
		}
		value = null;
		return false;
	}

	// Token: 0x0600FAF8 RID: 64248 RVA: 0x0044E198 File Offset: 0x0044C398
	[NullableContext(0)]
	public virtual void SetMember(string key, object value)
	{
		if (key != null)
		{
			switch (key.Length)
			{
			case 8:
				if (key == "ViewMode")
				{
					this.ViewMode = (ItemViewDefine.EItemOperationMode)value;
					return;
				}
				break;
			case 12:
			{
				char c = key[1];
				if (c != 'a')
				{
					switch (c)
					{
					case 's':
						if (key == "IsReloadData")
						{
							this.IsReloadData = (bool)value;
							return;
						}
						break;
					case 't':
						if (key == "ItemTypeList")
						{
							this.ItemTypeList = (List<ItemMainType>)value;
							return;
						}
						break;
					case 'u':
						if (key == "NumberSelect")
						{
							this.NumberSelect = (NumberSelectComponent)value;
							return;
						}
						break;
					}
				}
				else if (key == "TabComponent")
				{
					this.TabComponent = (TabComponentWithCaptionItem<CommonTabItem>)value;
					return;
				}
				break;
			}
			case 14:
			{
				char c = key[1];
				if (c != 's')
				{
					if (c == 't')
					{
						if (key == "ItemScrollView")
						{
							this.ItemScrollView = (LoopScrollView<InventoryMediumItemGrid, global::ItemViewData>)value;
							return;
						}
					}
				}
				else if (key == "IsReSelectType")
				{
					this.IsReSelectType = (bool)value;
					return;
				}
				break;
			}
			case 15:
				if (key == "DestroyViewMode")
				{
					this.DestroyViewMode = (ItemViewDefine.EDestroyViewMode)value;
					return;
				}
				break;
			case 16:
			{
				char c = key[0];
				if (c != 'I')
				{
					if (c != 'R')
					{
						if (c == 'T')
						{
							if (key == "TabMarkPositions")
							{
								this.TabMarkPositions = (int[])value;
								return;
							}
						}
					}
					else if (key == "RefreshCdTimerId")
					{
						this.RefreshCdTimerId = (TimerHandle)value;
						return;
					}
				}
				else if (key == "ItemViewDataList")
				{
					this.ItemViewDataList = (List<global::ItemViewData>)value;
					return;
				}
				break;
			}
			case 17:
			{
				char c = key[1];
				if (c != 'e')
				{
					if (c != 's')
					{
						if (c == 't')
						{
							if (key == "ItemTipsComponent")
							{
								this.ItemTipsComponent = (ItemTipsWithButtonComponent)value;
								return;
							}
						}
					}
					else if (key == "IsMaxCapacityFlag")
					{
						this.IsMaxCapacityFlag = (bool)value;
						return;
					}
				}
				else if (key == "SelectedItemIndex")
				{
					int selectedItemIndex;
					if (value is double)
					{
						double num = (double)value;
						selectedItemIndex = (int)num;
					}
					else if (value is float)
					{
						float num2 = (float)value;
						selectedItemIndex = (int)num2;
					}
					else if (value is int)
					{
						int num3 = (int)value;
						selectedItemIndex = num3;
					}
					else if (value is long)
					{
						long num4 = (long)value;
						selectedItemIndex = (int)num4;
					}
					else
					{
						selectedItemIndex = (int)value;
					}
					this.SelectedItemIndex = selectedItemIndex;
					return;
				}
				break;
			}
			case 18:
			{
				char c = key[0];
				if (c != 'F')
				{
					if (c == 'T')
					{
						if (key == "TipsButtonIndexMap")
						{
							this.TipsButtonIndexMap = (Dictionary<ItemViewDefine.ETipsButtonType, int>)value;
							return;
						}
					}
				}
				else if (key == "FilterSortEntrance")
				{
					this.FilterSortEntrance = (FilterSortEntrance<global::ItemViewData>)value;
					return;
				}
				break;
			}
			case 19:
			{
				char c = key[18];
				if (c <= '2')
				{
					if (c != '1')
					{
						if (c == '2')
						{
							if (key == "CommonCurrencyItem2")
							{
								this.CommonCurrencyItem2 = (CommonCurrencyItem)value;
								return;
							}
						}
					}
					else if (key == "CommonCurrencyItem1")
					{
						this.CommonCurrencyItem1 = (CommonCurrencyItem)value;
						return;
					}
				}
				else if (c != 'r')
				{
					if (c == 't')
					{
						if (key == "InvalidItemTempList")
						{
							this.InvalidItemTempList = (List<Dictionary<int, int>>)value;
							return;
						}
					}
				}
				else if (key == "LevelSequencePlayer")
				{
					this.LevelSequencePlayer = (LevelSequencePlayer)value;
					return;
				}
				break;
			}
			case 20:
				if (key == "SelectedItemViewData")
				{
					this.SelectedItemViewData = (global::ItemViewData)value;
					return;
				}
				break;
			case 21:
			{
				char c = key[2];
				if (c != 'I')
				{
					if (c != 'M')
					{
						if (c == 'p')
						{
							if (key == "TipsButtonRelationMap")
							{
								this.TipsButtonRelationMap = (Dictionary<ItemViewDefine.ETipsButtonType, IButtonInfo>)value;
								return;
							}
						}
					}
					else if (key == "IsMaxCapacityViewShow")
					{
						this.IsMaxCapacityViewShow = (bool)value;
						return;
					}
				}
				else if (key == "IsInvalidItemViewShow")
				{
					this.IsInvalidItemViewShow = (bool)value;
					return;
				}
				break;
			}
			case 27:
				if (key == "IsExpireConvertItemViewShow")
				{
					this.IsExpireConvertItemViewShow = (bool)value;
					return;
				}
				break;
			}
		}
		throw new KeyNotFoundException("设置InventoryView成员属性失败" + key + ")");
	}

	// Token: 0x0600FAFC RID: 64252 RVA: 0x0044E700 File Offset: 0x0044C900
	[CompilerGenerated]
	private void <OnClickedAllSelect>g__selectAll|142_0(bool selectOn)
	{
		if (this.IsDestroyModeSelectMax() && selectOn)
		{
			return;
		}
		foreach (global::ItemViewData itemViewData in this.ItemViewDataList)
		{
			if (itemViewData.IsItemCanDestroy() && itemViewData.GetUniqueId() != 0)
			{
				this.TrySetItemDestroyModeSelectOn(selectOn, itemViewData);
			}
			if (this.IsDestroyModeSelectMax() && selectOn)
			{
				break;
			}
		}
	}

	// Token: 0x04007861 RID: 30817
	[Nullable(2)]
	private global::ItemViewData SelectedItemViewData;

	// Token: 0x04007862 RID: 30818
	private int SelectedItemIndex;

	// Token: 0x04007863 RID: 30819
	private readonly List<AccessPathButton> AccessPathButtonList = new List<AccessPathButton>();

	// Token: 0x04007864 RID: 30820
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<InventoryMediumItemGrid, global::ItemViewData> ItemScrollView;

	// Token: 0x04007865 RID: 30821
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<global::ItemViewData> FilterSortEntrance;

	// Token: 0x04007866 RID: 30822
	[Nullable(2)]
	private TimerHandle RefreshCdTimerId;

	// Token: 0x04007867 RID: 30823
	private readonly Dictionary<int, BuffItemData> CurrentCdItemMap = new Dictionary<int, BuffItemData>();

	// Token: 0x04007868 RID: 30824
	[Nullable(2)]
	private CommonCurrencyItem CommonCurrencyItem1;

	// Token: 0x04007869 RID: 30825
	[Nullable(2)]
	private CommonCurrencyItem CommonCurrencyItem2;

	// Token: 0x0400786A RID: 30826
	private List<global::ItemViewData> ItemViewDataList = new List<global::ItemViewData>();

	// Token: 0x0400786B RID: 30827
	private readonly Dictionary<int, HashSet<global::ItemViewData>> ItemViewDataMap = new Dictionary<int, HashSet<global::ItemViewData>>();

	// Token: 0x0400786C RID: 30828
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithCaptionItem<CommonTabItem> TabComponent;

	// Token: 0x0400786D RID: 30829
	[Nullable(2)]
	private List<ItemMainType> ItemTypeList;

	// Token: 0x0400786E RID: 30830
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400786F RID: 30831
	[Nullable(2)]
	private ItemTipsWithButtonComponent ItemTipsComponent;

	// Token: 0x04007870 RID: 30832
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Dictionary<ItemViewDefine.ETipsButtonType, IButtonInfo> TipsButtonRelationMap;

	// Token: 0x04007871 RID: 30833
	[Nullable(2)]
	protected Dictionary<ItemViewDefine.ETipsButtonType, int> TipsButtonIndexMap;

	// Token: 0x04007872 RID: 30834
	[Nullable(2)]
	private int[] TabMarkPositions;

	// Token: 0x04007873 RID: 30835
	private ItemViewDefine.EItemOperationMode ViewMode;

	// Token: 0x04007874 RID: 30836
	[Nullable(2)]
	private NumberSelectComponent NumberSelect;

	// Token: 0x04007875 RID: 30837
	private bool IsReloadData;

	// Token: 0x04007876 RID: 30838
	private bool IsReSelectType;

	// Token: 0x04007877 RID: 30839
	private bool IsMaxCapacityViewShow;

	// Token: 0x04007878 RID: 30840
	private bool IsMaxCapacityFlag;

	// Token: 0x04007879 RID: 30841
	protected List<Dictionary<int, int>> InvalidItemTempList = new List<Dictionary<int, int>>();

	// Token: 0x0400787A RID: 30842
	protected bool IsInvalidItemViewShow;

	// Token: 0x0400787B RID: 30843
	private readonly List<ItemExpiredAutoConvertTipsViewDefine> CacheExpireShowDataList = new List<ItemExpiredAutoConvertTipsViewDefine>();

	// Token: 0x0400787C RID: 30844
	protected bool IsExpireConvertItemViewShow;

	// Token: 0x0400787D RID: 30845
	private ItemViewDefine.EDestroyViewMode DestroyViewMode;

	// Token: 0x0400787E RID: 30846
	private readonly HashSet<global::ItemViewData> SelectItemSet = new HashSet<global::ItemViewData>();
}
