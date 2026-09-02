using System;
using System.Runtime.CompilerServices;

// Token: 0x020021AD RID: 8621
[NullableContext(1)]
[Nullable(0)]
public class DrinksGameplayInviteLogEvent : PlayerCommonLogData
{
	// Token: 0x17001404 RID: 5124
	// (get) Token: 0x06010502 RID: 66818 RVA: 0x00476BED File Offset: 0x00474DED
	// (set) Token: 0x06010503 RID: 66819 RVA: 0x00476BF5 File Offset: 0x00474DF5
	public override string event_id { get; set; } = "1833";

	// Token: 0x04007FFE RID: 32766
	public int i_activity_id;

	// Token: 0x04007FFF RID: 32767
	public int i_role_id;

	// Token: 0x04008000 RID: 32768
	public int i_inst_id;

	// Token: 0x04008001 RID: 32769
	public int i_first_pass;

	// Token: 0x04008002 RID: 32770
	public string s_trace_id = "";
}
