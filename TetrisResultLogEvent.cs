using System;
using System.Runtime.CompilerServices;

// Token: 0x02002176 RID: 8566
[NullableContext(1)]
[Nullable(0)]
public class TetrisResultLogEvent : PlayerCommonLogData
{
	// Token: 0x170013CE RID: 5070
	// (get) Token: 0x0601045F RID: 66655 RVA: 0x00476202 File Offset: 0x00474402
	// (set) Token: 0x06010460 RID: 66656 RVA: 0x0047620A File Offset: 0x0047440A
	public override string event_id { get; set; } = "1914";

	// Token: 0x04007EF2 RID: 32498
	public int i_activity_id;

	// Token: 0x04007EF3 RID: 32499
	public int i_inst_id;

	// Token: 0x04007EF4 RID: 32500
	public int i_type;

	// Token: 0x04007EF5 RID: 32501
	public int i_first_pass;

	// Token: 0x04007EF6 RID: 32502
	public string s_trace_id = "";

	// Token: 0x04007EF7 RID: 32503
	public int i_if_back;

	// Token: 0x04007EF8 RID: 32504
	public int i_inst_diff;

	// Token: 0x04007EF9 RID: 32505
	public int i_result;

	// Token: 0x04007EFA RID: 32506
	public int i_display_mode;

	// Token: 0x04007EFB RID: 32507
	public int i_get_score;

	// Token: 0x04007EFC RID: 32508
	public int i_combo_max;

	// Token: 0x04007EFD RID: 32509
	public string o_reward_items_new = "";

	// Token: 0x04007EFE RID: 32510
	public int i_round;

	// Token: 0x04007EFF RID: 32511
	public int i_count;

	// Token: 0x04007F00 RID: 32512
	public int i_cost_time;

	// Token: 0x04007F01 RID: 32513
	public string i_first_tab = "";

	// Token: 0x04007F02 RID: 32514
	public string i_second_tab = "";

	// Token: 0x04007F03 RID: 32515
	public string o_line_end1 = "";

	// Token: 0x04007F04 RID: 32516
	public string o_line_end2 = "";

	// Token: 0x04007F05 RID: 32517
	public string o_line_end3 = "";

	// Token: 0x04007F06 RID: 32518
	public string o_line_end4 = "";

	// Token: 0x04007F07 RID: 32519
	public string o_line_end5 = "";

	// Token: 0x04007F08 RID: 32520
	public string o_line_end6 = "";
}
