using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

// Token: 0x0200174A RID: 5962
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class NewSoundDetectRewardItem : LoopScrollSmallItemGrid<INewSoundDetectRewardItemData>
{
	// Token: 0x0600A7C7 RID: 42951 RVA: 0x002CAA8C File Offset: 0x002C8C8C
	protected override void OnRefresh(INewSoundDetectRewardItemData data, bool isSelected, int gridIndex)
	{
		InventoryDefine.IGetItemData itemData = data.ItemData.ItemData;
		int count = data.ItemData.Count;
		this.ConfigId = itemData.ItemId;
		bool haveFinish = data.HaveFinish;
		PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
		propSmallItemGrid.Data = data;
		propSmallItemGrid.IsReceivedVisible = new bool?(haveFinish);
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
		PropSmallItemGrid parameters = propSmallItemGrid;
		base.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x0600A7C8 RID: 42952 RVA: 0x002CAB1E File Offset: 0x002C8D1E
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x0600A7C9 RID: 42953 RVA: 0x002CAB21 File Offset: 0x002C8D21
	protected override void OnExtendToggleClicked()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ConfigId, true, null);
	}

	// Token: 0x04004F35 RID: 20277
	private int ConfigId = -1;
}
