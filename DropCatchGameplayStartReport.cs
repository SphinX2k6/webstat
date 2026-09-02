using System;
using System.Runtime.CompilerServices;

// Token: 0x020021BF RID: 8639
[NullableContext(1)]
[Nullable(0)]
public class DropCatchGameplayStartReport : PlayerCommonLogData
{
	// Token: 0x17001413 RID: 5139
	// (get) Token: 0x06010532 RID: 66866 RVA: 0x00476E99 File Offset: 0x00475099
	// (set) Token: 0x06010533 RID: 66867 RVA: 0x00476EA1 File Offset: 0x004750A1
	public override string event_id { get; set; } = "1848";

	// Token: 0x0400805B RID: 32859
	public int i_activity_id;

	// Token: 0x0400805C RID: 32860
	public int i_inst_id;

	// Token: 0x0400805D RID: 32861
	public int i_first_pass;

	// Token: 0x0400805E RID: 32862
	public string s_trace_id = "";
}
