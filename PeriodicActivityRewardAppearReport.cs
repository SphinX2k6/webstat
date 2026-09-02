using System;
using System.Runtime.CompilerServices;

// Token: 0x020021B6 RID: 8630
[NullableContext(1)]
[Nullable(0)]
public class PeriodicActivityRewardAppearReport : PlayerCommonLogData
{
	// Token: 0x1700140B RID: 5131
	// (get) Token: 0x06010519 RID: 66841 RVA: 0x00476D50 File Offset: 0x00474F50
	// (set) Token: 0x0601051A RID: 66842 RVA: 0x00476D58 File Offset: 0x00474F58
	public override string event_id { get; set; } = "1840";

	// Token: 0x0400803C RID: 32828
	public int i_activity_id;

	// Token: 0x0400803D RID: 32829
	public int i_round;

	// Token: 0x0400803E RID: 32830
	public int i_step_id;
}
