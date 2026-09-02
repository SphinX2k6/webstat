using System;
using UnrealEngine;

// Token: 0x02002026 RID: 8230
public class DestroyPreviewGrid : LoopScrollSmallItemGrid<TItem>
{
	// Token: 0x0600FA36 RID: 64054 RVA: 0x004489FC File Offset: 0x00446BFC
	protected override void OnRefresh(TItem data, bool isSelected, int gridIndex)
	{
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			BottomText = data.Count.ToString(),
			ItemConfigId = new int?(data.ItemData.ItemId)
		};
		base.Apply<PropSmallItemGrid>(parameters);
		this.SetSelected(false, false);
	}

	// Token: 0x0600FA37 RID: 64055 RVA: 0x00448A52 File Offset: 0x00446C52
	protected override void OnStart()
	{
		base.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
	}

	// Token: 0x0600FA38 RID: 64056 RVA: 0x00448A79 File Offset: 0x00446C79
	public override void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600FA39 RID: 64057 RVA: 0x00448A7B File Offset: 0x00446C7B
	public override void OnDeselected(bool fireEvent)
	{
	}
}
