using System;
using System.Runtime.CompilerServices;

// Token: 0x02002177 RID: 8567
[NullableContext(1)]
[Nullable(0)]
public class TetrisRoundLogEvent : PlayerCommonLogData
{
	// Token: 0x170013CF RID: 5071
	// (get) Token: 0x06010462 RID: 66658 RVA: 0x004762A0 File Offset: 0x004744A0
	// (set) Token: 0x06010463 RID: 66659 RVA: 0x004762A8 File Offset: 0x004744A8
	public override string event_id { get; set; } = "1915";

	// Token: 0x04007F0A RID: 32522
	public int i_activity_id;

	// Token: 0x04007F0B RID: 32523
	public int i_inst_id;

	// Token: 0x04007F0C RID: 32524
	public int i_type;

	// Token: 0x04007F0D RID: 32525
	public int i_first_pass;

	// Token: 0x04007F0E RID: 32526
	public string s_trace_id = "";

	// Token: 0x04007F0F RID: 32527
	public int i_if_back;

	// Token: 0x04007F10 RID: 32528
	public int i_inst_diff;

	// Token: 0x04007F11 RID: 32529
	public int i_round;

	// Token: 0x04007F12 RID: 32530
	public int i_result;

	// Token: 0x04007F13 RID: 32531
	public int i_display_mode;

	// Token: 0x04007F14 RID: 32532
	public int i_get_score;

	// Token: 0x04007F15 RID: 32533
	public int if_con_combo;

	// Token: 0x04007F16 RID: 32534
	public int i_combo_max;

	// Token: 0x04007F17 RID: 32535
	public string o_reward_items_new = "";

	// Token: 0x04007F18 RID: 32536
	public string i_first_tab = "";

	// Token: 0x04007F19 RID: 32537
	public int i_count;

	// Token: 0x04007F1A RID: 32538
	public int i_cost_time;

	// Token: 0x04007F1B RID: 32539
	public string o_line_start1 = "";

	// Token: 0x04007F1C RID: 32540
	public string o_line_start2 = "";

	// Token: 0x04007F1D RID: 32541
	public string o_line_start3 = "";

	// Token: 0x04007F1E RID: 32542
	public string o_line_start4 = "";

	// Token: 0x04007F1F RID: 32543
	public string o_line_start5 = "";

	// Token: 0x04007F20 RID: 32544
	public string o_line_start6 = "";

	// Token: 0x04007F21 RID: 32545
	public string o_line_start7 = "";

	// Token: 0x04007F22 RID: 32546
	public string o_line_start8 = "";

	// Token: 0x04007F23 RID: 32547
	public string o_line_end1 = "";

	// Token: 0x04007F24 RID: 32548
	public string o_line_end2 = "";

	// Token: 0x04007F25 RID: 32549
	public string o_line_end3 = "";

	// Token: 0x04007F26 RID: 32550
	public string o_line_end4 = "";

	// Token: 0x04007F27 RID: 32551
	public string o_line_end5 = "";

	// Token: 0x04007F28 RID: 32552
	public string o_line_end6 = "";

	// Token: 0x04007F29 RID: 32553
	public string o_line_end7 = "";

	// Token: 0x04007F2A RID: 32554
	public string o_line_end8 = "";
}
