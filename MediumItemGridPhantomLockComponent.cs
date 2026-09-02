using System;
using System.Runtime.CompilerServices;

// Token: 0x020019D0 RID: 6608
public class MediumItemGridPhantomLockComponent : MediumItemGridVisibleComponent
{
	// Token: 0x0600BDAB RID: 48555 RVA: 0x003245EE File Offset: 0x003227EE
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemVisionLock";
	}
}
