using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A31 RID: 6705
public class SmallItemGridNewFlagComponent : SmallItemGridVisibleComponent
{
	// Token: 0x0600C022 RID: 49186 RVA: 0x0032C8B1 File Offset: 0x0032AAB1
	[NullableContext(2)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBTagNew";
	}

	// Token: 0x0600C023 RID: 49187 RVA: 0x0032C8B8 File Offset: 0x0032AAB8
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Top;
	}
}
