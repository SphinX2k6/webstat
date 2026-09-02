using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

// Token: 0x02002A41 RID: 10817
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SkinRewardItemGrid : LoopScrollSmallItemGrid<SkinRewardData>
{
	// Token: 0x06015A8A RID: 88714 RVA: 0x00603563 File Offset: 0x00601763
	protected override void OnRefresh(SkinRewardData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data, isSelected, gridIndex);
	}

	// Token: 0x06015A8B RID: 88715 RVA: 0x00603570 File Offset: 0x00601770
	public override void Refresh(SkinRewardData data, bool isSelected, int gridIndex)
	{
		TItem value = data.ItemData.Value;
		InventoryDefine.IGetItemData itemData = value.ItemData;
		int num = 0;
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemData.ItemId));
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.VirtualItem || itemDataTypeByConfigId == InventoryDefine.EItemDataType.CommonItem)
		{
			num = value.Count;
		}
		this.ConfigId = itemData.ItemId;
		PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
		propSmallItemGrid.Data = data;
		propSmallItemGrid.ItemConfigId = new int?(this.ConfigId);
		propSmallItemGrid.IsReceivedVisible = new bool?(data.FinishState);
		string bottomText;
		if (num <= 0)
		{
			bottomText = "";
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		propSmallItemGrid.BottomText = bottomText;
		PropSmallItemGrid parameters = propSmallItemGrid;
		base.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x06015A8C RID: 88716 RVA: 0x00603623 File Offset: 0x00601823
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x06015A8D RID: 88717 RVA: 0x00603626 File Offset: 0x00601826
	protected override void OnExtendToggleClicked()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ConfigId, false, null);
		Action<int> onClickRecommendSkinButtonCallback = this.OnClickRecommendSkinButtonCallback;
		if (onClickRecommendSkinButtonCallback == null)
		{
			return;
		}
		onClickRecommendSkinButtonCallback(this.ConfigId);
	}

	// Token: 0x0400A660 RID: 42592
	private int ConfigId;

	// Token: 0x0400A661 RID: 42593
	[Nullable(2)]
	public Action<int> OnClickRecommendSkinButtonCallback;
}
