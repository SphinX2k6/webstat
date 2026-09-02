using System;
using System.Runtime.CompilerServices;

// Token: 0x0200148C RID: 5260
public class RewardGridItem : SmallItemGrid
{
	// Token: 0x0600933D RID: 37693 RVA: 0x0026DBF7 File Offset: 0x0026BDF7
	protected override bool OnCanExecuteChange()
	{
		return false;
	}

	// Token: 0x0600933E RID: 37694 RVA: 0x0026DBFC File Offset: 0x0026BDFC
	[NullableContext(1)]
	public void RefreshByData(IItemData data)
	{
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.ItemId),
			BottomText = data.Count.ToString(),
			IsReceivedVisible = new bool?(false)
		};
		base.Apply<PropSmallItemGrid>(parameters);
	}
}
