using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020017E0 RID: 6112
[NullableContext(2)]
[Nullable(0)]
public class VisionRefineResultViewParam : IVisionRefineResultViewParam
{
	// Token: 0x17000E2C RID: 3628
	// (get) Token: 0x0600AD8D RID: 44429 RVA: 0x002E315F File Offset: 0x002E135F
	// (set) Token: 0x0600AD8E RID: 44430 RVA: 0x002E3167 File Offset: 0x002E1367
	public PhantomPolishResponse Response { get; set; }

	// Token: 0x17000E2D RID: 3629
	// (get) Token: 0x0600AD8F RID: 44431 RVA: 0x002E3170 File Offset: 0x002E1370
	// (set) Token: 0x0600AD90 RID: 44432 RVA: 0x002E3178 File Offset: 0x002E1378
	public PhantomBatchPolishResponse ResponseBatch { get; set; }

	// Token: 0x17000E2E RID: 3630
	// (get) Token: 0x0600AD91 RID: 44433 RVA: 0x002E3181 File Offset: 0x002E1381
	// (set) Token: 0x0600AD92 RID: 44434 RVA: 0x002E3189 File Offset: 0x002E1389
	public bool ShowTips { get; set; }

	// Token: 0x17000E2F RID: 3631
	// (get) Token: 0x0600AD93 RID: 44435 RVA: 0x002E3192 File Offset: 0x002E1392
	// (set) Token: 0x0600AD94 RID: 44436 RVA: 0x002E319A File Offset: 0x002E139A
	public int? PropIndexId { get; set; }
}
