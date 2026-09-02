using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x02001B04 RID: 6916
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoAbyssSelectableComponent<[Nullable(0)] T> : SelectableComponent<T> where T : ItemDataBase
{
	// Token: 0x0600C733 RID: 50995 RVA: 0x0034B1E0 File Offset: 0x003493E0
	public DangoAbyssSelectableComponent(bool stateForEquip)
	{
		this.StateForEquip = stateForEquip;
	}

	// Token: 0x0600C734 RID: 50996 RVA: 0x0034B1F8 File Offset: 0x003493F8
	[PreserveBaseOverrides]
	protected new virtual DangoAbyssItemPropMediumItemGrid InitItem()
	{
		DangoAbyssItemPropMediumItemGrid dangoAbyssItemPropMediumItemGrid = new DangoAbyssItemPropMediumItemGrid();
		dangoAbyssItemPropMediumItemGrid.StateForEquip = this.StateForEquip;
		dangoAbyssItemPropMediumItemGrid.BindReduceLongPress(delegate(bool _1, MediumItemGrid _2, object _3)
		{
			base.ReduceFunction(_1, _2, _3);
		});
		dangoAbyssItemPropMediumItemGrid.BindLongPress(LongPressButtonItem.ELongPressConfigId.LongPressOne, delegate(bool _1, ItemGridBase _2, [Nullable(2)] object _3)
		{
			base.AddFunction(_1, _2, _3);
		}, new Func<ItemGridBase, object, bool>(base.CanItemLongPress));
		dangoAbyssItemPropMediumItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(base.OnCanExecuteChange));
		return dangoAbyssItemPropMediumItemGrid;
	}

	// Token: 0x0600C735 RID: 50997 RVA: 0x0034B25C File Offset: 0x0034945C
	protected override bool CanAddMaterial(SelectablePropData propData, bool isShowTip = false)
	{
		AbyssPluginItemInfo pluginItemInfoById = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(propData.IncId);
		if (pluginItemInfoById.GetIsLock() && !this.StateForEquip)
		{
			if (isShowTip)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponLockTipsText", Array.Empty<object>());
			}
			return false;
		}
		if (!pluginItemInfoById.GetCanRecovery() && !this.StateForEquip)
		{
			if (isShowTip)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("EquipLockTipsText", Array.Empty<object>());
			}
			return false;
		}
		ISelectedData selectedData = base.GetSelectedData(propData);
		if (selectedData != null)
		{
			int selectedCount = selectedData.SelectedCount;
			if (selectedData.SelectedCount == propData.Count)
			{
				return false;
			}
		}
		if (selectedData == null && this.SelectedDataList.Count >= this.MaxSize && !this.Data.IsSingleSelected)
		{
			if (isShowTip)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponFullMaterialText", Array.Empty<object>());
			}
			return false;
		}
		return this.Data.CheckIfCanAddFunction == null || this.Data.CheckIfCanAddFunction(this.SelectedDataList, propData.IncId, propData.ItemId, 1);
	}

	// Token: 0x0600C736 RID: 50998 RVA: 0x0034B360 File Offset: 0x00349560
	public void RemoveAndRefresh(int uniqueId)
	{
		int loopScrollViewIndex = base.GetLoopScrollViewIndex(uniqueId, -1);
		AbyssPluginItemInfo pluginItemInfoById = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(uniqueId);
		if (loopScrollViewIndex < 0 || pluginItemInfoById == null)
		{
			return;
		}
		if (pluginItemInfoById.GetIsLock())
		{
			base.RemoveSelectedDataByIncId(uniqueId);
		}
		base.RefreshAllByDisplay();
		base.UpdateChangeItemSelectList();
	}

	// Token: 0x04005F6A RID: 24426
	private readonly bool StateForEquip = true;
}
