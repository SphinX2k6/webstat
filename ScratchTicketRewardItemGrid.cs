using System;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

// Token: 0x020015A5 RID: 5541
public class ScratchTicketRewardItemGrid : LoopScrollSmallItemGrid<TItem>
{
	// Token: 0x06009C0E RID: 39950 RVA: 0x0028D755 File Offset: 0x0028B955
	protected override void OnRefresh(TItem data, bool isSelected, int gridIndex)
	{
		this._Refresh(data);
	}

	// Token: 0x06009C0F RID: 39951 RVA: 0x0028D760 File Offset: 0x0028B960
	private void _Refresh(TItem data)
	{
		InventoryDefine.IGetItemData itemData = data.ItemData;
		int count = data.Count;
		this.ConfigId = itemData.ItemId;
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			ItemConfigId = new int?(this.ConfigId),
			BottomText = count.ToString(),
			IsReceivedVisible = new bool?(count == 0)
		};
		base.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x06009C10 RID: 39952 RVA: 0x0028D7CD File Offset: 0x0028B9CD
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x06009C11 RID: 39953 RVA: 0x0028D7D0 File Offset: 0x0028B9D0
	protected override void OnExtendToggleClicked()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ConfigId, true, null);
	}

	// Token: 0x040047D2 RID: 18386
	private int ConfigId;
}
