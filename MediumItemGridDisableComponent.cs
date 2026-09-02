using System;
using System.Runtime.CompilerServices;

// Token: 0x020019BF RID: 6591
public class MediumItemGridDisableComponent : MediumItemGridVisibleComponent
{
	// Token: 0x0600BD3D RID: 48445 RVA: 0x00323B03 File Offset: 0x00321D03
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemDark";
	}

	// Token: 0x0600BD3E RID: 48446 RVA: 0x00323B0A File Offset: 0x00321D0A
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}
}
