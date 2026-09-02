using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020021AE RID: 8622
[NullableContext(1)]
[Nullable(0)]
public class DrinksGameplayResultLogEvent : PlayerCommonLogData
{
	// Token: 0x17001405 RID: 5125
	// (get) Token: 0x06010505 RID: 66821 RVA: 0x00476C1C File Offset: 0x00474E1C
	// (set) Token: 0x06010506 RID: 66822 RVA: 0x00476C24 File Offset: 0x00474E24
	public override string event_id { get; set; } = "1834";

	// Token: 0x04008004 RID: 32772
	public int i_activity_id;

	// Token: 0x04008005 RID: 32773
	public int i_role_id;

	// Token: 0x04008006 RID: 32774
	public int i_inst_id;

	// Token: 0x04008007 RID: 32775
	public int i_first_pass;

	// Token: 0x04008008 RID: 32776
	public int i_result;

	// Token: 0x04008009 RID: 32777
	public int i_first_tab;

	// Token: 0x0400800A RID: 32778
	public int i_first_count;

	// Token: 0x0400800B RID: 32779
	public int i_second_tab;

	// Token: 0x0400800C RID: 32780
	public int i_second_count;

	// Token: 0x0400800D RID: 32781
	public int i_third_tab = -1;

	// Token: 0x0400800E RID: 32782
	public int i_fourth_tab = -1;

	// Token: 0x0400800F RID: 32783
	public int i_fifth_tab = -1;

	// Token: 0x04008010 RID: 32784
	public int i_cost_time;

	// Token: 0x04008011 RID: 32785
	public int i_require_id;

	// Token: 0x04008012 RID: 32786
	public List<int> o_score_buff = new List<int>();

	// Token: 0x04008013 RID: 32787
	public string s_trace_id = "";
}
