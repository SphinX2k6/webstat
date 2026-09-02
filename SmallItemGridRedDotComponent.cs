using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A36 RID: 6710
public class SmallItemGridRedDotComponent : SmallItemGridVisibleComponent
{
	// Token: 0x0600C034 RID: 49204 RVA: 0x0032C9BC File Offset: 0x0032ABBC
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemRedDot";
	}

	// Token: 0x0600C035 RID: 49205 RVA: 0x0032C9C3 File Offset: 0x0032ABC3
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Top;
	}
}
