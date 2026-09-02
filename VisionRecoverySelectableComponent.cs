using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x02001A0B RID: 6667
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionRecoverySelectableComponent<[Nullable(0)] T> : SelectableComponent<T> where T : ItemDataBase
{
	// Token: 0x0600BF13 RID: 48915 RVA: 0x00328E7C File Offset: 0x0032707C
	protected override SelectablePropMediumItemGrid InitItem()
	{
		SelectablePropVisionRecoveryItemGrid selectablePropVisionRecoveryItemGrid = new SelectablePropVisionRecoveryItemGrid();
		selectablePropVisionRecoveryItemGrid.BindLongPress(LongPressButtonItem.ELongPressConfigId.LongPressOne, delegate(bool _1, ItemGridBase _2, [Nullable(2)] object _3)
		{
			base.AddFunction(_1, _2, _3);
		}, new Func<ItemGridBase, object, bool>(base.CanItemLongPress));
		selectablePropVisionRecoveryItemGrid.BindReduceLongPress(delegate(bool _1, MediumItemGrid _2, object _3)
		{
			base.ReduceFunction(_1, _2, _3);
		});
		selectablePropVisionRecoveryItemGrid.BindAfterApply(new Action<SelectablePropMediumItemGrid>(base.OnAfterApplyMediumItemGrid));
		selectablePropVisionRecoveryItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(base.OnCanExecuteChange));
		return selectablePropVisionRecoveryItemGrid;
	}

	// Token: 0x0600BF14 RID: 48916 RVA: 0x00328EE4 File Offset: 0x003270E4
	protected override bool CanAddMaterial(SelectablePropData propData, bool isShowTip = false)
	{
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(propData.IncId);
		if (phantomBattleData == null)
		{
			return false;
		}
		if (phantomBattleData.GetPhantomLevel() > 0 || phantomBattleData.GetExp() > 0)
		{
			if (isShowTip)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Text_EchoFull_Text", Array.Empty<object>());
			}
			return false;
		}
		if (propData.GetIsLock())
		{
			if (isShowTip)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponLockTipsText", Array.Empty<object>());
			}
			return false;
		}
		ISelectedData selectedData = base.GetSelectedData(propData);
		if (selectedData != null && selectedData.SelectedCount > 0 && selectedData.SelectedCount == propData.Count)
		{
			return false;
		}
		if (selectedData == null && this.SelectedDataList.Count >= this.MaxSize)
		{
			if (isShowTip)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Text_EchoLimit_Text", Array.Empty<object>());
			}
			return false;
		}
		if (propData.OnlyGold && phantomBattleData.GetQuality() < 5)
		{
			if (isShowTip)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DirectionalFusion_OnlyGold", Array.Empty<object>());
			}
			return false;
		}
		return this.Data.CheckIfCanAddFunction == null || this.Data.CheckIfCanAddFunction(this.SelectedDataList, propData.IncId, propData.ItemId, 1);
	}
}
