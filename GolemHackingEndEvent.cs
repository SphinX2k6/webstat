using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020021C5 RID: 8645
[NullableContext(1)]
[Nullable(0)]
public class GolemHackingEndEvent : PlayerCommonLogData
{
	// Token: 0x17001419 RID: 5145
	// (get) Token: 0x06010544 RID: 66884 RVA: 0x00476F92 File Offset: 0x00475192
	// (set) Token: 0x06010545 RID: 66885 RVA: 0x00476F9A File Offset: 0x0047519A
	public override string event_id { get; set; } = "1922";

	// Token: 0x0400807B RID: 32891
	public int i_id;

	// Token: 0x0400807C RID: 32892
	public int i_first_pass;

	// Token: 0x0400807D RID: 32893
	public int i_result;

	// Token: 0x0400807E RID: 32894
	public int i_pass_time;

	// Token: 0x0400807F RID: 32895
	public int i_total_duration;

	// Token: 0x04008080 RID: 32896
	public string s_trace_id = "";

	// Token: 0x04008081 RID: 32897
	[Nullable(2)]
	public List<int> o_path;

	// Token: 0x04008082 RID: 32898
	public int i_count;

	// Token: 0x04008083 RID: 32899
	public int i_recount;

	// Token: 0x04008084 RID: 32900
	public int i_false_count;
}
