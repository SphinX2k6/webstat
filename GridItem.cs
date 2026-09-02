using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

// Token: 0x02001C8D RID: 7309
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GridItem : LoopScrollSmallItemGrid<GridItemData>
{
	// Token: 0x0600D5EF RID: 54767 RVA: 0x00391C53 File Offset: 0x0038FE53
	protected override void OnRefresh(GridItemData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x0600D5F0 RID: 54768 RVA: 0x00391C5C File Offset: 0x0038FE5C
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x0600D5F1 RID: 54769 RVA: 0x00391C5F File Offset: 0x0038FE5F
	protected override void OnExtendToggleClicked()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ConfigId, true, null);
	}

	// Token: 0x0600D5F2 RID: 54770 RVA: 0x00391C74 File Offset: 0x0038FE74
	public void Refresh(GridItemData data)
	{
		if (data != null && data.Data != null)
		{
			InventoryDefine.IGetItemData itemData = data.Data.Value.ItemData;
			int count = data.Data.Value.Count;
			this.ConfigId = itemData.ItemId;
			bool getRewardState = data.GetRewardState;
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = data,
				ItemConfigId = new int?(this.ConfigId),
				BottomText = ((count > 0) ? count.ToString() : ""),
				IsReceivedVisible = new bool?(getRewardState)
			};
			base.Apply<PropSmallItemGrid>(parameters);
		}
	}

	// Token: 0x04006575 RID: 25973
	private int ConfigId;
}
