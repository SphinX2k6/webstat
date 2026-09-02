using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F2F RID: 7983
[NullableContext(1)]
[Nullable(0)]
public class BtnGo : UiPanelBase
{
	// Token: 0x0600EEBF RID: 61119 RVA: 0x00413F84 File Offset: 0x00412184
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnGoBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600EEC0 RID: 61120 RVA: 0x004140B0 File Offset: 0x004122B0
	public void SetPnlSelectLv(HonamiStoryLevelInfoView panel)
	{
		this.PnlSelectLv = panel;
		this.IsFreeSelect = ModelBase<FunctionModel>.Instance.IsOpen(10121);
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		if (activityData == null)
		{
			return;
		}
		this.CostItemId = activityData.OutCoinItemId;
	}

	// Token: 0x0600EEC1 RID: 61121 RVA: 0x004140F5 File Offset: 0x004122F5
	public void SetCostData(Dictionary<int, int> itemCountMap)
	{
		this.ItemCountMap = itemCountMap;
		this.RefreshView();
	}

	// Token: 0x0600EEC2 RID: 61122 RVA: 0x00414104 File Offset: 0x00412304
	public void RefreshView()
	{
		UUITexture texture = base.GetTexture(3);
		UUIText text = base.GetText(4);
		UUIItem item = base.GetItem(5);
		int num = this.PnlSelectLv.GetCurSafeLeavePrice();
		int num2;
		if (this.IsFreeSelect && this.ItemCountMap.TryGetValue(this.CostItemId, out num2))
		{
			num += num2;
		}
		bool uiactive = num > 0;
		item.SetUIActive(uiactive);
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.CostItemId);
		if (itemConfigData == null)
		{
			return;
		}
		base.SetTextureByPath(itemConfigData.Icon, texture, null, null);
		this.NeedCount = num;
		text.SetText(this.NeedCount.ToString(), true);
		bool flag = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.CostItemId, 0) >= this.NeedCount;
		UUIItem uuiitem = text;
		bool bUseChangeColor = !flag;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x0600EEC3 RID: 61123 RVA: 0x004141E4 File Offset: 0x004123E4
	private void SetLoadingPerform(bool isTower)
	{
		if (isTower)
		{
			ControllerBase<HonamiStoryController>.Instance.SetHonamiStoryLoadingInfoByTimingOnly(EHonamiStoryLoadingTimingType.Tower);
			return;
		}
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		if (activityData == null)
		{
			return;
		}
		if (activityData.IsAllAreaPass())
		{
			ControllerBase<HonamiStoryController>.Instance.SetHonamiStoryLoadingInfoByTimingOnly(EHonamiStoryLoadingTimingType.FreeExplore);
			return;
		}
		int currentProgressAreaDataId = activityData.GetCurrentProgressAreaDataId();
		HonamiStoryAreaData honamiStoryAreaData = activityData.GetHonamiStoryAreaData(currentProgressAreaDataId);
		if (honamiStoryAreaData == null || !honamiStoryAreaData.IsAreaCanEnter)
		{
			return;
		}
		int mainBTId = honamiStoryAreaData.Config.Value.MainBTId;
		ControllerBase<HonamiStoryController>.Instance.SetHonamiStoryLoadingInfoByBtId(mainBTId);
	}

	// Token: 0x0600EEC4 RID: 61124 RVA: 0x00414264 File Offset: 0x00412464
	private void OnGoBtnClick()
	{
		int[] allRoleIdList = ModelBase<HonamiStoryModel>.Instance.GetAllRoleIdList();
		bool flag;
		if (allRoleIdList != null && allRoleIdList.Length != 0)
		{
			flag = allRoleIdList.All((int id) => id == 0);
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_Tips_TeamUnderstaffed", Array.Empty<object>());
			return;
		}
		if (this.PnlSelectLv == null)
		{
			return;
		}
		if (ModelBase<HonamiStoryModel>.Instance.GetBackPackData(1, false).GetOverflowCapacity() > 0)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.HonamiStoryStorageFullConfirm);
			confirmBoxDataNew.FunctionMap.Add(2, new Action(this.OnTeamBtnClick));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.CostItemId, 0) < this.NeedCount)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_InsufficientBalance", Array.Empty<object>());
			return;
		}
		bool flag2 = this.PnlSelectLv.GetCurTarget.GetValueOrDefault() == ETarget.Tower;
		bool isBuy = this.PnlSelectLv.GetIsBuySafe;
		if (flag2)
		{
			isBuy = false;
			if (LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySelectLvTowerUnLockBtnGoRedDot, false))
			{
				LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySelectLvTowerUnLockBtnGoRedDot, false);
			}
		}
		this.SetLoadingPerform(flag2);
		ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryItemEnterRequest(flag2, this.PnlSelectLv.GetCurDangerLv, isBuy);
	}

	// Token: 0x0600EEC5 RID: 61125 RVA: 0x004143A2 File Offset: 0x004125A2
	public void SetRedDotShow(bool isShow)
	{
		base.GetItem(2).SetUIActive(isShow);
	}

	// Token: 0x0600EEC6 RID: 61126 RVA: 0x004143B1 File Offset: 0x004125B1
	private void OnTeamBtnClick()
	{
		ControllerBase<HonamiStoryController>.Instance.OpenHonamiStoryBag();
	}

	// Token: 0x040072D1 RID: 29393
	private int NeedCount;

	// Token: 0x040072D2 RID: 29394
	private int CostItemId;

	// Token: 0x040072D3 RID: 29395
	[Nullable(2)]
	private HonamiStoryLevelInfoView PnlSelectLv;

	// Token: 0x040072D4 RID: 29396
	private bool IsFreeSelect;

	// Token: 0x040072D5 RID: 29397
	private Dictionary<int, int> ItemCountMap = new Dictionary<int, int>();
}
