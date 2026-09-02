using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;

// Token: 0x0200181B RID: 6171
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionRefineMaterialItem : LoopScrollMediumItemGrid<ISelectedData>
{
	// Token: 0x0600AFBE RID: 44990 RVA: 0x002ED9F0 File Offset: 0x002EBBF0
	protected override void OnRefresh(ISelectedData data, bool isSelected, int gridIndex)
	{
		int count = data.Count;
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(data.ItemId, 0);
		string bottomText = "";
		if (count <= 0)
		{
			bottomText = itemCountByConfigId.ToString();
		}
		else if (itemCountByConfigId < count)
		{
			bottomText = StringUtils.Format("Text_ItemNotEnoughText_Text", new string[]
			{
				itemCountByConfigId.ToString(),
				count.ToString()
			});
		}
		else if (itemCountByConfigId >= count)
		{
			bottomText = StringUtils.Format("Text_ItemEnoughText_Text", new string[]
			{
				itemCountByConfigId.ToString(),
				count.ToString()
			});
		}
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.ItemId),
			BottomText = bottomText
		};
		base.Apply<PropMediumItemGrid>(parameters);
	}

	// Token: 0x0600AFBF RID: 44991 RVA: 0x002EDAAA File Offset: 0x002EBCAA
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x0600AFC0 RID: 44992 RVA: 0x002EDAB0 File Offset: 0x002EBCB0
	protected override void OnExtendToggleClicked()
	{
		ISelectedData selectedData = this.Data as ISelectedData;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(selectedData.ItemId, true, null);
	}
}
