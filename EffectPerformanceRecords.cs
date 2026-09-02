using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000BDA RID: 3034
public class EffectPerformanceRecords
{
	// Token: 0x040004CC RID: 1228
	public int TickCount;

	// Token: 0x040004CD RID: 1229
	public float Duration;

	// Token: 0x040004CE RID: 1230
	[Nullable(1)]
	public List<EffectPerformanceStatistics> Records = new List<EffectPerformanceStatistics>();
}
