using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200270C RID: 9996
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsSettlementMainViewRecord : IRacingBetsSettlementMainViewRecord
{
	// Token: 0x17001948 RID: 6472
	// (get) Token: 0x06013B98 RID: 80792 RVA: 0x0057D57F File Offset: 0x0057B77F
	// (set) Token: 0x06013B99 RID: 80793 RVA: 0x0057D587 File Offset: 0x0057B787
	public int SeasonId { get; set; }

	// Token: 0x17001949 RID: 6473
	// (get) Token: 0x06013B9A RID: 80794 RVA: 0x0057D590 File Offset: 0x0057B790
	// (set) Token: 0x06013B9B RID: 80795 RVA: 0x0057D598 File Offset: 0x0057B798
	public List<int> ViewedLegMatchIds { get; set; }
}
