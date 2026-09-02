using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Inventory;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001F04 RID: 7940
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryEquipGridItem : HonamiStoryGridItemBase
{
	// Token: 0x0600ED05 RID: 60677 RVA: 0x00409C70 File Offset: 0x00407E70
	public HonamiStoryEquipGridItem(bool needItem, HonamiStoryBackpackPanelBase panel = null, HonamiStoryItemDataBase itemData = null) : base(needItem, panel, itemData)
	{
	}

	// Token: 0x0600ED06 RID: 60678 RVA: 0x00409C7B File Offset: 0x00407E7B
	public int GetPosition()
	{
		if (this.Data != null)
		{
			return this.Data.GetPosition();
		}
		return this.Position;
	}

	// Token: 0x0600ED07 RID: 60679 RVA: 0x00409C98 File Offset: 0x00407E98
	public bool GetIsUnlock()
	{
		HonamiStoryRoleEquipData roleItemDataByPosition = ModelBase<HonamiStoryModel>.Instance.GetRoleItemDataByPosition(this.GetPosition());
		List<HonamiStoryRoleEquipSlotData> slotList = roleItemDataByPosition.GetSlotList();
		int honamiStoryPluginIndex = roleItemDataByPosition.GetHonamiStoryPluginIndex(this.GetPosition());
		return slotList[honamiStoryPluginIndex].GetIsUnlock();
	}

	// Token: 0x0600ED08 RID: 60680 RVA: 0x00409CD4 File Offset: 0x00407ED4
	[NullableContext(0)]
	public ValueTuple<bool, bool> GetSlotUnlockConfig()
	{
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(false);
		HonamiStoryRoleEquipData roleItemDataByPosition = ModelBase<HonamiStoryModel>.Instance.GetRoleItemDataByPosition(this.GetPosition());
		List<HonamiStoryRoleEquipSlotData> slotList = roleItemDataByPosition.GetSlotList();
		int honamiStoryPluginIndex = roleItemDataByPosition.GetHonamiStoryPluginIndex(this.GetPosition());
		HonamiStoryRoleEquipSlotData honamiStoryRoleEquipSlotData = slotList[honamiStoryPluginIndex];
		bool flag = activityData != null && activityData.GetPreGuideQuestFinishState();
		bool flag2 = !honamiStoryRoleEquipSlotData.GetIsUnlock() && (honamiStoryPluginIndex == 0 || slotList[honamiStoryPluginIndex - 1].GetIsUnlock());
		bool flag3 = HonamiStoryUtil.CheckInHonamiStoryDungeon();
		bool item = flag && flag2 && !flag3;
		return new ValueTuple<bool, bool>(honamiStoryRoleEquipSlotData.GetIsUnlock(), item);
	}

	// Token: 0x0600ED09 RID: 60681 RVA: 0x00409D68 File Offset: 0x00407F68
	public void SetPosition(int position)
	{
		this.Position = position;
	}

	// Token: 0x0600ED0A RID: 60682 RVA: 0x00409D74 File Offset: 0x00407F74
	public unsafe override void Refresh(HonamiStoryItemDataBase data, int position)
	{
		this.Data = data;
		if (data == null)
		{
			HonamiStoryItemGridItem itemGridItem = this.ItemGridItem;
			if (itemGridItem != null)
			{
				itemGridItem.SetUiActive(false);
			}
			ValueTuple<bool, bool> slotUnlockConfig = this.GetSlotUnlockConfig();
			bool item = slotUnlockConfig.Item1;
			bool item2 = slotUnlockConfig.Item2;
			this.IsFirstLock = item2;
			this.SpriteBg.SetUIActive(item);
			this.SetLockEnable(!item, item2);
			if (item)
			{
				this.RefreshState();
			}
			base.ClearSequence();
			return;
		}
		this.SetLockEnable(false, false);
		this.SetCanPlaceEnable(false);
		HonamiStoryRoleEquipData roleItemDataByPosition = ModelBase<HonamiStoryModel>.Instance.GetRoleItemDataByPosition(this.GetPosition());
		if (roleItemDataByPosition == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "获取位置失败";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GetPos", this.GetPosition());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DataPos", data.GetPosition());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("incId", data.GetIncId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("id", data.GetItemId());
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return;
		}
		bool isActive = roleItemDataByPosition.CheckRoleItemBuffIsActive((HonamiStoryEquipItemData)data);
		if (this.ItemGridItem == null)
		{
			base.InitItemGridItem(data, -1).ContinueWith(delegate()
			{
				this.PlayNewlyPickedUpSweepAnimation(data);
				this.UpdateActivateSequence(isActive);
			});
			return;
		}
		this.ItemGridItem.SetUiActive(true);
		HonamiStoryItemQuality? qualityConfig = data.GetQualityConfig();
		this.ItemGridItem.Refresh(data, position != -1);
		this.SetSpriteByPath(qualityConfig.Value.GridBg, this.SpriteBg, false, null, null);
		base.PlayNewlyPickedUpSweepAnimation(data);
		this.UpdateActivateSequence(isActive);
	}

	// Token: 0x0600ED0B RID: 60683 RVA: 0x00409F93 File Offset: 0x00408193
	private void UpdateActivateSequence(bool isActive)
	{
		if (isActive)
		{
			base.PlaySequenceByName("Activate");
			return;
		}
		base.ClearSequence();
	}

	// Token: 0x0600ED0C RID: 60684 RVA: 0x00409FAB File Offset: 0x004081AB
	[NullableContext(1)]
	protected override HonamiStoryItemGridItem CreateGridItem([Nullable(2)] HonamiStoryItemDataBase data)
	{
		return new HonamiStoryEquipItemGridItem(data);
	}

	// Token: 0x0600ED0D RID: 60685 RVA: 0x00409FB4 File Offset: 0x004081B4
	protected void SetLockEnable(bool isEnable, bool isFirstLock)
	{
		if (!isEnable && this.LockStateItem == null)
		{
			return;
		}
		if (this.LockStateItem == null)
		{
			this.LockStateItem = new HonamiStorySlotLockStateItem();
			this.LockStateItem.CreateThenShowByResourceIdAsync("UiItem_HonamiStoryItemStateAdd", this.RootItem, false).ContinueWith(new Action(this.RefreshLockState));
			return;
		}
		if (!this.LockStateItem.InAsyncLoading())
		{
			this.RefreshLockState();
		}
	}

	// Token: 0x0600ED0E RID: 60686 RVA: 0x0040A020 File Offset: 0x00408220
	public void RefreshLockState()
	{
		if (this.LockStateItem == null)
		{
			return;
		}
		ValueTuple<bool, bool> slotUnlockConfig = this.GetSlotUnlockConfig();
		bool item = slotUnlockConfig.Item1;
		bool item2 = slotUnlockConfig.Item2;
		int activityId = ModelBase<HonamiStoryModel>.Instance.ActivityId;
		HonamiStoryRoleEquipData roleItemDataByPosition = ModelBase<HonamiStoryModel>.Instance.GetRoleItemDataByPosition(this.GetPosition());
		List<HonamiStoryRoleEquipSlotData> slotList = roleItemDataByPosition.GetSlotList();
		int honamiStoryPluginIndex = roleItemDataByPosition.GetHonamiStoryPluginIndex(this.GetPosition());
		HonamiStoryRoleEquipSlotData honamiStoryRoleEquipSlotData = slotList[honamiStoryPluginIndex];
		HonamiStoryPluginSlot value = ConfigBase<HonamiStoryConfig>.Instance.GetSlotUnlockConfig(honamiStoryRoleEquipSlotData.GetSlotId()).Value;
		int outCoinItemId = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryActivityConfig(activityId).Value.OutCoinItemId;
		int num = value.ConsumeItems()[outCoinItemId];
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(outCoinItemId, 0);
		this.LockStateItem.RefreshState(!item, item2, itemCountByConfigId >= num);
	}

	// Token: 0x0600ED0F RID: 60687 RVA: 0x0040A0F8 File Offset: 0x004082F8
	protected void SetCanPlaceEnable(bool isEnable)
	{
		HonamiStoryItemGridPlacementItem placeStateItem = this.PlaceStateItem;
		if (placeStateItem != null)
		{
			placeStateItem.SetUiActive(isEnable);
		}
		if (isEnable)
		{
			HonamiStoryItemGridPlacementItem placeStateItem2 = this.PlaceStateItem;
			if (placeStateItem2 != null)
			{
				placeStateItem2.Refresh();
			}
		}
		if (isEnable && this.PlaceStateItem == null)
		{
			this.PlaceStateItem = new HonamiStoryItemGridPlacementItem();
			this.PlaceStateItem.CreateThenShowByResourceIdAsync("UiItem_HonamiStoryItemStatePut", this.RootItem, false).ContinueWith(delegate()
			{
				EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
				bool flag = backpackLogicState == EHonamiStoryBackpackLogicState.TipsWithPlugins || backpackLogicState == EHonamiStoryBackpackLogicState.DraggingPlugins;
				this.PlaceStateItem.SetUiActive(flag);
				if (flag)
				{
					this.PlaceStateItem.Refresh();
				}
			});
		}
	}

	// Token: 0x0600ED10 RID: 60688 RVA: 0x0040A16C File Offset: 0x0040836C
	protected override void DoClickedGridButton()
	{
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		if (backpackLogicState == EHonamiStoryBackpackLogicState.Normal)
		{
			if (this.GetIsUnlock())
			{
				return;
			}
			if (this.IsFirstLock)
			{
				this.UnlockSlot();
				return;
			}
			HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(false);
			bool flag = activityData != null && activityData.GetPreGuideQuestFinishState();
			if (!HonamiStoryUtil.CheckInHonamiStoryDungeon() && flag)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_CantUnlockLastSlot", Array.Empty<object>());
				return;
			}
		}
		else if (backpackLogicState == EHonamiStoryBackpackLogicState.TipsWithPlugins)
		{
			if (!this.GetIsUnlock())
			{
				ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().CloseTips();
				return;
			}
			ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().DoTipsWithPluginsInstead(this.GetPosition(), null);
			return;
		}
		else if (backpackLogicState == EHonamiStoryBackpackLogicState.Instead)
		{
			if (!this.GetIsUnlock())
			{
				ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().CloseTips();
				return;
			}
			ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().DoTipsWithPluginsInstead(this.GetPosition(), null);
		}
	}

	// Token: 0x0600ED11 RID: 60689 RVA: 0x0040A242 File Offset: 0x00408442
	public void SetIsEnable(bool value)
	{
		HonamiStoryItemGridItem itemGridItem = this.ItemGridItem;
		if (itemGridItem == null)
		{
			return;
		}
		itemGridItem.SetIsEnable(value);
	}

	// Token: 0x0600ED12 RID: 60690 RVA: 0x0040A258 File Offset: 0x00408458
	private void UnlockSlot()
	{
		HonamiStoryEquipGridItem.<>c__DisplayClass17_0 CS$<>8__locals1 = new HonamiStoryEquipGridItem.<>c__DisplayClass17_0();
		int activityId = ModelBase<HonamiStoryModel>.Instance.ActivityId;
		CS$<>8__locals1.roleEquipData = ModelBase<HonamiStoryModel>.Instance.GetRoleItemDataByPosition(this.GetPosition());
		List<HonamiStoryRoleEquipSlotData> slotList = CS$<>8__locals1.roleEquipData.GetSlotList();
		int honamiStoryPluginIndex = CS$<>8__locals1.roleEquipData.GetHonamiStoryPluginIndex(this.GetPosition());
		CS$<>8__locals1.slotData = slotList[honamiStoryPluginIndex];
		HonamiStoryPluginSlot value = ConfigBase<HonamiStoryConfig>.Instance.GetSlotUnlockConfig(CS$<>8__locals1.slotData.GetSlotId()).Value;
		CS$<>8__locals1.itemId = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryActivityConfig(activityId).Value.OutCoinItemId;
		CS$<>8__locals1.needCount = value.ConsumeItems()[CS$<>8__locals1.itemId];
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(CS$<>8__locals1.itemId);
		string value2 = string.Empty;
		if (itemConfigData != null && !string.IsNullOrEmpty(itemConfigData.IconSmall))
		{
			value2 = itemConfigData.IconSmall;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<texture=");
		stringBuilder.Append(value2);
		stringBuilder.Append("/>");
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.HonamiStorySlotUnlockConfirm);
		confirmBoxDataNew.FunctionMap.Add(2, new Action(CS$<>8__locals1.<UnlockSlot>g__Cb|0));
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			CS$<>8__locals1.needCount.ToString(),
			stringBuilder.ToString()
		});
		if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(CS$<>8__locals1.itemId, 0) < CS$<>8__locals1.needCount)
		{
			confirmBoxDataNew.SetTipsBgRed = true;
			confirmBoxDataNew.SetTableTextArgNew("Text_NotEnoughItem_Text", Array.Empty<object>());
			confirmBoxDataNew.InteractionMap[1] = false;
		}
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600ED13 RID: 60691 RVA: 0x0040A408 File Offset: 0x00408608
	public void RefreshState()
	{
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		if (backpackLogicState == EHonamiStoryBackpackLogicState.Normal)
		{
			this.SetSpriteByPath("/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity28/HonamiStory/HonamiStoryBackpack/SP_GridEmpty.SP_GridEmpty", this.SpriteBg, false, null, null);
			this.SetCanPlaceEnable(false);
			return;
		}
		if (backpackLogicState == EHonamiStoryBackpackLogicState.TipsWithPlugins || backpackLogicState == EHonamiStoryBackpackLogicState.DraggingPlugins)
		{
			this.SetCanPlaceEnable(!Singleton<Info>.Instance.IsInGamepad());
			return;
		}
		if (backpackLogicState == EHonamiStoryBackpackLogicState.Tips)
		{
			this.SetCanPlaceEnable(false);
			return;
		}
		if (backpackLogicState == EHonamiStoryBackpackLogicState.Instead)
		{
			this.SetCanPlaceEnable(true);
		}
	}

	// Token: 0x0600ED14 RID: 60692 RVA: 0x0040A47A File Offset: 0x0040867A
	protected override void OnBtnPointDown()
	{
	}

	// Token: 0x0600ED15 RID: 60693 RVA: 0x0040A47C File Offset: 0x0040867C
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		if (!(configParams[0] == "AddBtn") || this.LockStateItem == null || !this.LockStateItem.IsUiActiveInHierarchy() || !this.IsFirstLock)
		{
			return null;
		}
		UUIItem btnItem = base.GetBtnItem();
		if (btnItem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			btnItem,
			btnItem
		};
	}

	// Token: 0x040071E4 RID: 29156
	private int Position;

	// Token: 0x040071E5 RID: 29157
	private bool IsFirstLock;

	// Token: 0x040071E6 RID: 29158
	private HonamiStorySlotLockStateItem LockStateItem;

	// Token: 0x040071E7 RID: 29159
	private HonamiStoryItemGridPlacementItem PlaceStateItem;
}
