using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002AF2 RID: 10994
[NullableContext(1)]
[Nullable(0)]
internal class SurvivorsShopViewInfo : ISurvivorsShopViewInfo
{
	// Token: 0x17001C95 RID: 7317
	// (get) Token: 0x06015FBF RID: 90047 RVA: 0x0061A0B4 File Offset: 0x006182B4
	// (set) Token: 0x06015FC0 RID: 90048 RVA: 0x0061A0BC File Offset: 0x006182BC
	public List<GoodsDetail> DataList { get; set; }

	// Token: 0x17001C96 RID: 7318
	// (get) Token: 0x06015FC1 RID: 90049 RVA: 0x0061A0C5 File Offset: 0x006182C5
	// (set) Token: 0x06015FC2 RID: 90050 RVA: 0x0061A0CD File Offset: 0x006182CD
	public int RefreshItemId { get; set; }

	// Token: 0x17001C97 RID: 7319
	// (get) Token: 0x06015FC3 RID: 90051 RVA: 0x0061A0D6 File Offset: 0x006182D6
	// (set) Token: 0x06015FC4 RID: 90052 RVA: 0x0061A0DE File Offset: 0x006182DE
	public int RefreshCost { get; set; }
}
