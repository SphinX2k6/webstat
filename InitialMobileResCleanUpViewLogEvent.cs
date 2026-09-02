using System;
using System.Runtime.CompilerServices;

// Token: 0x0200219E RID: 8606
[NullableContext(1)]
[Nullable(0)]
public class InitialMobileResCleanUpViewLogEvent : CommonLogData
{
	// Token: 0x170013F6 RID: 5110
	// (get) Token: 0x060104D7 RID: 66775 RVA: 0x0047695E File Offset: 0x00474B5E
	// (set) Token: 0x060104D8 RID: 66776 RVA: 0x00476966 File Offset: 0x00474B66
	public override string event_id { get; set; } = "1712";

	// Token: 0x04007FB4 RID: 32692
	public int i_remaining_space;

	// Token: 0x04007FB5 RID: 32693
	public int i_type;

	// Token: 0x04007FB6 RID: 32694
	public string s_trace_id = "";

	// Token: 0x04007FB7 RID: 32695
	public string unique_id = "";

	// Token: 0x04007FB8 RID: 32696
	public string player_id = "";
}
