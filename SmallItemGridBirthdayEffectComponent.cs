using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A15 RID: 6677
public class SmallItemGridBirthdayEffectComponent : SmallItemGridVisibleComponent
{
	// Token: 0x0600BFC2 RID: 49090 RVA: 0x0032BCC8 File Offset: 0x00329EC8
	[NullableContext(2)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBShinning";
	}

	// Token: 0x0600BFC3 RID: 49091 RVA: 0x0032BCCF File Offset: 0x00329ECF
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Top;
	}
}
