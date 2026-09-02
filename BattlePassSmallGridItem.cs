using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002386 RID: 9094
public class BattlePassSmallGridItem : CommonItemSmallItemGrid
{
	// Token: 0x060116E0 RID: 71392 RVA: 0x004CE0A0 File Offset: 0x004CC2A0
	public void RefreshItem(TItem data, EBattlePassItemType type)
	{
		InventoryDefine.IGetItemData itemData = data.ItemData;
		int count = data.Count;
		this.ConfigId = itemData.ItemId;
		PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
		propSmallItemGrid.Data = data;
		propSmallItemGrid.ItemConfigId = new int?(this.ConfigId);
		string bottomText;
		if (count <= 0)
		{
			bottomText = "";
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(count);
			bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		propSmallItemGrid.BottomText = bottomText;
		propSmallItemGrid.IsReceivedVisible = new bool?(type == EBattlePassItemType.HasGet);
		propSmallItemGrid.IsLockVisible = new bool?(type == EBattlePassItemType.Locked);
		propSmallItemGrid.IsReceivableVisible = new bool?(type == EBattlePassItemType.CanGet);
		PropSmallItemGrid parameters = propSmallItemGrid;
		base.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x060116E1 RID: 71393 RVA: 0x004CE147 File Offset: 0x004CC347
	protected override void OnExtendToggleClicked()
	{
	}
}
