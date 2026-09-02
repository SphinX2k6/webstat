using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

// Token: 0x020015FA RID: 5626
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ActivitySmallItemGrid : LoopScrollSmallItemGrid<IItemGridData>
{
	// Token: 0x06009E8D RID: 40589 RVA: 0x00297DEB File Offset: 0x00295FEB
	protected override void OnRefresh(IItemGridData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x06009E8E RID: 40590 RVA: 0x00297DF4 File Offset: 0x00295FF4
	public void Refresh(IItemGridData data)
	{
		TItem item = data.Item;
		int count = item.Count;
		this.ConfigId = item.ItemData.ItemId;
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
		propSmallItemGrid.IsReceivedVisible = new bool?(data.HasClaimed);
		PropSmallItemGrid parameters = propSmallItemGrid;
		base.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x06009E8F RID: 40591 RVA: 0x00297E7F File Offset: 0x0029607F
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x06009E90 RID: 40592 RVA: 0x00297E82 File Offset: 0x00296082
	protected override void OnExtendToggleClicked()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ConfigId, true, null);
	}

	// Token: 0x040048ED RID: 18669
	private int ConfigId;
}
