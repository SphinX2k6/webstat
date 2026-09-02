using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A18 RID: 6680
public class SmallItemGridCookUpComponent : SmallItemGridVisibleComponent
{
	// Token: 0x0600BFC9 RID: 49097 RVA: 0x0032BD1A File Offset: 0x00329F1A
	[NullableContext(2)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBCooking";
	}

	// Token: 0x0600BFCA RID: 49098 RVA: 0x0032BD21 File Offset: 0x00329F21
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}
}
