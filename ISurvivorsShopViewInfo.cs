using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002AF0 RID: 10992
[NullableContext(1)]
public interface ISurvivorsShopViewInfo
{
	// Token: 0x17001C92 RID: 7314
	// (get) Token: 0x06015FB0 RID: 90032
	List<GoodsDetail> DataList { get; }

	// Token: 0x17001C93 RID: 7315
	// (get) Token: 0x06015FB1 RID: 90033
	int RefreshItemId { get; }

	// Token: 0x17001C94 RID: 7316
	// (get) Token: 0x06015FB2 RID: 90034
	int RefreshCost { get; }
}
