using System;
using System.Runtime.CompilerServices;

// Token: 0x020019D4 RID: 6612
public class MediumItemGridReceivedComponent : MediumItemGridVisibleComponent
{
	// Token: 0x0600BDB8 RID: 48568 RVA: 0x003247A7 File Offset: 0x003229A7
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemReceived";
	}

	// Token: 0x0600BDB9 RID: 48569 RVA: 0x003247AE File Offset: 0x003229AE
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}
}
