using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020024A4 RID: 9380
[NullableContext(1)]
[Nullable(0)]
public class CostCombinationData : ICostCombinationData
{
	// Token: 0x170016F2 RID: 5874
	// (get) Token: 0x06012328 RID: 74536 RVA: 0x005016D0 File Offset: 0x004FF8D0
	// (set) Token: 0x06012329 RID: 74537 RVA: 0x005016D8 File Offset: 0x004FF8D8
	public int CostId { get; set; }

	// Token: 0x170016F3 RID: 5875
	// (get) Token: 0x0601232A RID: 74538 RVA: 0x005016E1 File Offset: 0x004FF8E1
	// (set) Token: 0x0601232B RID: 74539 RVA: 0x005016E9 File Offset: 0x004FF8E9
	public List<int> Costs { get; set; }

	// Token: 0x170016F4 RID: 5876
	// (get) Token: 0x0601232C RID: 74540 RVA: 0x005016F2 File Offset: 0x004FF8F2
	// (set) Token: 0x0601232D RID: 74541 RVA: 0x005016FA File Offset: 0x004FF8FA
	public int Usage { get; set; }
}
