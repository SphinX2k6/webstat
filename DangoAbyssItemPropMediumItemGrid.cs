using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02001AEA RID: 6890
public class DangoAbyssItemPropMediumItemGrid : SelectablePropMediumItemGrid
{
	// Token: 0x0600C652 RID: 50770 RVA: 0x0034696C File Offset: 0x00344B6C
	[NullableContext(1)]
	public override void RefreshUi(SelectablePropData data)
	{
		AbyssPluginItemInfo pluginItemInfoById = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(data.IncId);
		AbyssQuality? abyssQualityByPluginItemId = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityByPluginItemId(data.ItemId);
		if (pluginItemInfoById == null || abyssQualityByPluginItemId == null)
		{
			return;
		}
		TItemConfig config = pluginItemInfoById.GetConfig();
		DangoRoleHeadInfo dangoRoleHeadInfo = new DangoRoleHeadInfo
		{
			DangoConfigId = new int?(pluginItemInfoById.GetRoleId())
		};
		PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.ItemId),
			BottomTextId = config.As<AbyssItem>().Value.Name,
			IsLockVisible = new bool?(pluginItemInfoById.GetIsLock()),
			DangoRoleHeadInfo = dangoRoleHeadInfo,
			IsDisable = new bool?(!this.StateForEquip && !pluginItemInfoById.GetCanRecovery())
		};
		if (this.StateForEquip)
		{
			base.SetReduceButton(null);
		}
		else
		{
			LongPressButton reduceButtonInfo = new LongPressButton
			{
				IsVisible = new bool?(data.SelectedCount > 0),
				LongPressConfigId = new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne)
			};
			propMediumItemGrid.ReduceButtonInfo = reduceButtonInfo;
		}
		base.Apply<PropMediumItemGrid>(propMediumItemGrid);
	}

	// Token: 0x0600C653 RID: 50771 RVA: 0x00346A84 File Offset: 0x00344C84
	public override void OnSelected(bool fireEvent)
	{
		if (fireEvent)
		{
			this.SetSelected(true, true);
			if (this.StateForEquip)
			{
				base.SetReduceButton(null);
				return;
			}
			LongPressButton reduceButton = new LongPressButton
			{
				IsVisible = new bool?(true),
				LongPressConfigId = new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne)
			};
			base.SetReduceButton(reduceButton);
		}
	}

	// Token: 0x04005F0B RID: 24331
	public bool StateForEquip = true;
}
