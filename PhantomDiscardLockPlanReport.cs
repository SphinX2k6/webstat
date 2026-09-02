using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020021BC RID: 8636
[NullableContext(1)]
[Nullable(0)]
public class PhantomDiscardLockPlanReport : PlayerCommonLogData
{
	// Token: 0x17001410 RID: 5136
	// (get) Token: 0x06010529 RID: 66857 RVA: 0x00476E17 File Offset: 0x00475017
	// (set) Token: 0x0601052A RID: 66858 RVA: 0x00476E1F File Offset: 0x0047501F
	public override string event_id { get; set; } = "1845";

	// Token: 0x0400804F RID: 32847
	public int i_suit_id;

	// Token: 0x04008050 RID: 32848
	public int i_success;

	// Token: 0x04008051 RID: 32849
	public int i_type;

	// Token: 0x04008052 RID: 32850
	public int i_if_finish;

	// Token: 0x04008053 RID: 32851
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<PhantomDiscardPlanPlanLogData> o_setting_plan;
}
