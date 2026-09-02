using System;
using System.Runtime.CompilerServices;

// Token: 0x02002175 RID: 8565
[NullableContext(1)]
[Nullable(0)]
public class TetrisStartLogEvent : PlayerCommonLogData
{
	// Token: 0x170013CD RID: 5069
	// (get) Token: 0x0601045C RID: 66652 RVA: 0x004761D3 File Offset: 0x004743D3
	// (set) Token: 0x0601045D RID: 66653 RVA: 0x004761DB File Offset: 0x004743DB
	public override string event_id { get; set; } = "1913";

	// Token: 0x04007EEC RID: 32492
	public int i_activity_id;

	// Token: 0x04007EED RID: 32493
	public int i_inst_id;

	// Token: 0x04007EEE RID: 32494
	public int i_type;

	// Token: 0x04007EEF RID: 32495
	public int i_first_pass;

	// Token: 0x04007EF0 RID: 32496
	public string s_trace_id = "";
}
