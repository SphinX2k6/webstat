using System;
using System.Runtime.CompilerServices;

// Token: 0x020029CF RID: 10703
[NullableContext(2)]
[Nullable(0)]
public class ShipTowerReviewViewParams
{
	// Token: 0x17001BDD RID: 7133
	// (get) Token: 0x06015562 RID: 87394 RVA: 0x005E9CD4 File Offset: 0x005E7ED4
	// (set) Token: 0x06015563 RID: 87395 RVA: 0x005E9CDC File Offset: 0x005E7EDC
	public int SeasonId { get; set; }

	// Token: 0x17001BDE RID: 7134
	// (get) Token: 0x06015564 RID: 87396 RVA: 0x005E9CE5 File Offset: 0x005E7EE5
	// (set) Token: 0x06015565 RID: 87397 RVA: 0x005E9CED File Offset: 0x005E7EED
	public CustomPromise<bool> Promise { get; set; }
}
