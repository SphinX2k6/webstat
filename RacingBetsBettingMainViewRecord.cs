using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200270E RID: 9998
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsBettingMainViewRecord : IRacingBetsBettingMainViewRecord
{
	// Token: 0x1700194C RID: 6476
	// (get) Token: 0x06013BA1 RID: 80801 RVA: 0x0057D5A9 File Offset: 0x0057B7A9
	// (set) Token: 0x06013BA2 RID: 80802 RVA: 0x0057D5B1 File Offset: 0x0057B7B1
	public int SeasonId { get; set; }

	// Token: 0x1700194D RID: 6477
	// (get) Token: 0x06013BA3 RID: 80803 RVA: 0x0057D5BA File Offset: 0x0057B7BA
	// (set) Token: 0x06013BA4 RID: 80804 RVA: 0x0057D5C2 File Offset: 0x0057B7C2
	public List<int> EnteredLegMatchIds { get; set; }
}
