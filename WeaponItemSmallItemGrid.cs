using System;
using System.Runtime.CompilerServices;

// Token: 0x02002D12 RID: 11538
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeaponItemSmallItemGrid : LoopScrollSmallItemGrid<WeaponDataBase>
{
	// Token: 0x06017488 RID: 95368 RVA: 0x0067408E File Offset: 0x0067228E
	protected override void OnRefresh(WeaponDataBase data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x06017489 RID: 95369 RVA: 0x00674098 File Offset: 0x00672298
	public void Refresh(WeaponDataBase data)
	{
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.GetItemId())
		};
		base.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x0601748A RID: 95370 RVA: 0x006740CA File Offset: 0x006722CA
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}
}
