using System;
using System.Runtime.CompilerServices;

// Token: 0x020019CE RID: 6606
public class MediumItemGridMainVisionComponent : MediumItemGridVisibleComponent
{
	// Token: 0x0600BDA6 RID: 48550 RVA: 0x003245CD File Offset: 0x003227CD
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemMainVision";
	}

	// Token: 0x0600BDA7 RID: 48551 RVA: 0x003245D4 File Offset: 0x003227D4
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}
}
