using System;
using System.Runtime.CompilerServices;

// Token: 0x02001C41 RID: 7233
[NullableContext(1)]
[Nullable(0)]
public struct FloroRanchShopTipViewParam
{
	// Token: 0x04006475 RID: 25717
	public int ToyPoint;

	// Token: 0x04006476 RID: 25718
	public Action<int> SellCallback;

	// Token: 0x04006477 RID: 25719
	public Action<bool> ShowToyListCallback;
}
