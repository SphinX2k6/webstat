using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

// Token: 0x02000FDF RID: 4063
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AchievementGridItem : LoopScrollSmallItemGrid<AchievementGridItemData>
{
	// Token: 0x060068C1 RID: 26817 RVA: 0x001B4BEA File Offset: 0x001B2DEA
	protected override void OnRefresh(AchievementGridItemData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data, isSelected, gridIndex);
	}

	// Token: 0x060068C2 RID: 26818 RVA: 0x001B4BF5 File Offset: 0x001B2DF5
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x060068C3 RID: 26819 RVA: 0x001B4BF8 File Offset: 0x001B2DF8
	protected override void OnExtendToggleClicked()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ConfigId, true, null);
	}

	// Token: 0x060068C4 RID: 26820 RVA: 0x001B4C0C File Offset: 0x001B2E0C
	public override void Refresh(AchievementGridItemData data, bool isSelected, int gridIndex)
	{
		if (data != null && data.Data != null)
		{
			InventoryDefine.IGetItemData itemData = data.Data.Value.ItemData;
			int count = data.Data.Value.Count;
			this.ConfigId = itemData.ItemId;
			bool getRewardState = data.GetRewardState;
			PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
			propSmallItemGrid.Data = data;
			propSmallItemGrid.ItemConfigId = new int?(this.ConfigId);
			SmallItemGridBase smallItemGridBase = propSmallItemGrid;
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
			smallItemGridBase.BottomText = bottomText;
			propSmallItemGrid.IsReceivedVisible = new bool?(getRewardState);
			base.Apply<PropSmallItemGrid>(propSmallItemGrid);
		}
	}

	// Token: 0x040031D8 RID: 12760
	private int ConfigId;
}
