using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x02001977 RID: 6519
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ItemInteractionMediumItemGrid : LoopScrollMediumItemGrid<ItemInteractionPanelItemData>
{
	// Token: 0x0600BB5C RID: 47964 RVA: 0x0031C430 File Offset: 0x0031A630
	protected override void OnRefresh(ItemInteractionPanelItemData data, bool isSelected, int gridIndex)
	{
		this.ItemInteractionPanelItemData = data;
		int itemConfigId = data.ItemConfigId;
		this.ItemCount = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemConfigId, 0);
		int currentCount = data.GetCurrentCount();
		int needCount = data.NeedCount;
		PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(itemConfigId),
			IsDisable = new bool?(!data.IsEnable())
		};
		if (currentCount > 0)
		{
			propMediumItemGrid.BottomTextId = "ItemCountSelected";
			propMediumItemGrid.BottomTextParameter = new object[]
			{
				currentCount,
				this.ItemCount
			};
			propMediumItemGrid.ReduceButtonInfo = new LongPressButton
			{
				IsVisible = new bool?(true),
				LongPressConfigId = new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne)
			};
		}
		else if (this.ItemCount < needCount)
		{
			propMediumItemGrid.BottomTextId = "ItemCountNotEnough";
			propMediumItemGrid.BottomTextParameter = new object[]
			{
				this.ItemCount
			};
		}
		else
		{
			propMediumItemGrid.BottomText = this.ItemCount.ToString();
		}
		base.Apply<PropMediumItemGrid>(propMediumItemGrid);
		this.SetSelected(data.IsSelected, true);
	}

	// Token: 0x0600BB5D RID: 47965 RVA: 0x0031C544 File Offset: 0x0031A744
	public override void OnSelected(bool fireEvent)
	{
		if (this.ItemInteractionPanelItemData != null)
		{
			this.ItemInteractionPanelItemData.IsSelected = true;
		}
		this.SetSelected(true, false);
	}

	// Token: 0x0600BB5E RID: 47966 RVA: 0x0031C562 File Offset: 0x0031A762
	public override void OnDeselected(bool fireEvent)
	{
		if (this.ItemInteractionPanelItemData != null)
		{
			this.ItemInteractionPanelItemData.IsSelected = false;
		}
		this.SetSelected(false, false);
	}

	// Token: 0x0400587E RID: 22654
	private int ItemCount;

	// Token: 0x0400587F RID: 22655
	[Nullable(2)]
	private ItemInteractionPanelItemData ItemInteractionPanelItemData;
}
