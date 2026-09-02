using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A3F RID: 6719
public class SmallItemGridStarReceivableComponent : SmallItemGridVisibleComponent
{
	// Token: 0x0600C066 RID: 49254 RVA: 0x0032D113 File Offset: 0x0032B313
	[NullableContext(2)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBReceivableA";
	}

	// Token: 0x0600C067 RID: 49255 RVA: 0x0032D11A File Offset: 0x0032B31A
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}
}
