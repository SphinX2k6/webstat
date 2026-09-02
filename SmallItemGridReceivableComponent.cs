using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A13 RID: 6675
public class SmallItemGridReceivableComponent : SmallItemGridVisibleComponent
{
	// Token: 0x0600BFBD RID: 49085 RVA: 0x0032BCA7 File Offset: 0x00329EA7
	[NullableContext(2)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBReceivable";
	}

	// Token: 0x0600BFBE RID: 49086 RVA: 0x0032BCAE File Offset: 0x00329EAE
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}
}
