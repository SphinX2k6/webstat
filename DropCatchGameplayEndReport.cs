using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020021C0 RID: 8640
[NullableContext(1)]
[Nullable(0)]
public class DropCatchGameplayEndReport : PlayerCommonLogData
{
	// Token: 0x17001414 RID: 5140
	// (get) Token: 0x06010535 RID: 66869 RVA: 0x00476EC8 File Offset: 0x004750C8
	// (set) Token: 0x06010536 RID: 66870 RVA: 0x00476ED0 File Offset: 0x004750D0
	public override string event_id { get; set; } = "1849";

	// Token: 0x04008060 RID: 32864
	public int i_activity_id;

	// Token: 0x04008061 RID: 32865
	public int i_inst_id;

	// Token: 0x04008062 RID: 32866
	public int i_first_pass;

	// Token: 0x04008063 RID: 32867
	public string s_trace_id = "";

	// Token: 0x04008064 RID: 32868
	public int i_result;

	// Token: 0x04008065 RID: 32869
	public int i_reason;

	// Token: 0x04008066 RID: 32870
	public int i_get_score;

	// Token: 0x04008067 RID: 32871
	public int i_skill_times;

	// Token: 0x04008068 RID: 32872
	public int i_cost_time;

	// Token: 0x04008069 RID: 32873
	public int i_add_time;

	// Token: 0x0400806A RID: 32874
	[Nullable(2)]
	public List<int> o_item_report;
}
