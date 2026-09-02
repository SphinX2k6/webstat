using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A33 RID: 6707
public class SmallItemGridOrnamentConflictComponent : SmallItemGridVisibleComponent
{
	// Token: 0x0600C029 RID: 49193 RVA: 0x0032C904 File Offset: 0x0032AB04
	[NullableContext(2)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemAccessoriesTag";
	}

	// Token: 0x0600C02A RID: 49194 RVA: 0x0032C90B File Offset: 0x0032AB0B
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}
}
