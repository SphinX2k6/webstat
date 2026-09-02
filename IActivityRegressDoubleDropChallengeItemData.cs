using System;
using Aki.Config;

// Token: 0x02001557 RID: 5463
public struct IActivityRegressDoubleDropChallengeItemData
{
	// Token: 0x17000D1C RID: 3356
	// (get) Token: 0x0600994C RID: 39244 RVA: 0x00282260 File Offset: 0x00280460
	// (set) Token: 0x0600994D RID: 39245 RVA: 0x00282268 File Offset: 0x00280468
	public EActivityRegressDoubleDropEntryType Type { readonly get; set; }

	// Token: 0x17000D1D RID: 3357
	// (get) Token: 0x0600994E RID: 39246 RVA: 0x00282271 File Offset: 0x00280471
	// (set) Token: 0x0600994F RID: 39247 RVA: 0x00282279 File Offset: 0x00280479
	public RegressDoubleDrop Config { readonly get; set; }
}
