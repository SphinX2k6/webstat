using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x02001096 RID: 4246
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FurnitureHandBookItem : LoopScrollMediumItemGrid<IFurnitureHandBookItemData>
{
	// Token: 0x06006EBD RID: 28349 RVA: 0x001CCED4 File Offset: 0x001CB0D4
	[NullableContext(1)]
	protected override void OnRefresh(IFurnitureHandBookItemData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			ItemConfigId = new int?(data.FurnitureConfig.Id),
			IsLockVisible = new bool?(data.IsLock),
			BottomTextId = data.FurnitureConfig.Name,
			Data = data,
			QualityId = new int?(data.FurnitureConfig.QualityId),
			IsRedDotVisible = new bool?(data.RedDotVisible),
			IsDisable = new bool?(data.IsLock)
		};
		base.Apply<PropMediumItemGrid>(parameters);
		this.SetSelected(isSelected, false);
	}

	// Token: 0x06006EBE RID: 28350 RVA: 0x001CCF80 File Offset: 0x001CB180
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
		IFurnitureHandBookItemData itemData = this.ItemData;
		if (itemData != null && itemData.RedDotVisible)
		{
			this.ItemData.RedDotVisible = false;
			FurnitureController instance = ControllerBase<FurnitureController>.Instance;
			IFurnitureHandBookItemData itemData2 = this.ItemData;
			instance.SetFurnitureHandBookItemRedDotAsRead((itemData2 != null) ? itemData2.FurnitureConfig.Id : 0);
			base.SetRedDotVisible(new bool?(false));
		}
	}

	// Token: 0x06006EBF RID: 28351 RVA: 0x001CCFE5 File Offset: 0x001CB1E5
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x06006EC0 RID: 28352 RVA: 0x001CCFF0 File Offset: 0x001CB1F0
	public object GetKey()
	{
		IFurnitureHandBookItemData itemData = this.ItemData;
		return (itemData != null) ? new int?(itemData.FurnitureConfig.Id) : null;
	}

	// Token: 0x040034CC RID: 13516
	private IFurnitureHandBookItemData ItemData;
}
