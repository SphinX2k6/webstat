using System;
using System.Runtime.CompilerServices;

// Token: 0x020012CC RID: 4812
public class DailyAdventureSmallGridItem : SmallItemGrid
{
	// Token: 0x0600813E RID: 33086 RVA: 0x00222A58 File Offset: 0x00220C58
	[NullableContext(1)]
	public void Refresh(IItemGridData data, bool isReceivableVisible, bool isLock)
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
		propSmallItemGrid.IsReceivableVisible = new bool?(isReceivableVisible);
		propSmallItemGrid.IsLockVisible = new bool?(isLock);
		PropSmallItemGrid parameters = propSmallItemGrid;
		base.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x0600813F RID: 33087 RVA: 0x00222AFB File Offset: 0x00220CFB
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x06008140 RID: 33088 RVA: 0x00222AFE File Offset: 0x00220CFE
	protected override void OnExtendToggleClicked()
	{
	}

	// Token: 0x04003DB8 RID: 15800
	private int ConfigId;
}
