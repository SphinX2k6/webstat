using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020017DF RID: 6111
[NullableContext(2)]
public interface IVisionRefineResultViewParam
{
	// Token: 0x17000E28 RID: 3624
	// (get) Token: 0x0600AD85 RID: 44421
	// (set) Token: 0x0600AD86 RID: 44422
	PhantomPolishResponse Response { get; set; }

	// Token: 0x17000E29 RID: 3625
	// (get) Token: 0x0600AD87 RID: 44423
	// (set) Token: 0x0600AD88 RID: 44424
	PhantomBatchPolishResponse ResponseBatch { get; set; }

	// Token: 0x17000E2A RID: 3626
	// (get) Token: 0x0600AD89 RID: 44425
	// (set) Token: 0x0600AD8A RID: 44426
	bool ShowTips { get; set; }

	// Token: 0x17000E2B RID: 3627
	// (get) Token: 0x0600AD8B RID: 44427
	// (set) Token: 0x0600AD8C RID: 44428
	int? PropIndexId { get; set; }
}
