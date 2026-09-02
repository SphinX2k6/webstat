using System;
using System.Runtime.CompilerServices;

// Token: 0x020021B7 RID: 8631
[NullableContext(1)]
[Nullable(0)]
public class PeriodicActivityRewardClearReport : PlayerCommonLogData
{
	// Token: 0x1700140C RID: 5132
	// (get) Token: 0x0601051C RID: 66844 RVA: 0x00476D74 File Offset: 0x00474F74
	// (set) Token: 0x0601051D RID: 66845 RVA: 0x00476D7C File Offset: 0x00474F7C
	public override string event_id { get; set; } = "1841";

	// Token: 0x04008040 RID: 32832
	public int i_activity_id;

	// Token: 0x04008041 RID: 32833
	public int i_round;

	// Token: 0x04008042 RID: 32834
	public int i_step_id;

	// Token: 0x04008043 RID: 32835
	public int i_way;
}
