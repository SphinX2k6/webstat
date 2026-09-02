using System;
using System.Runtime.CompilerServices;

// Token: 0x020021C4 RID: 8644
[NullableContext(1)]
[Nullable(0)]
public class GolemHackingStartEvent : PlayerCommonLogData
{
	// Token: 0x17001418 RID: 5144
	// (get) Token: 0x06010541 RID: 66881 RVA: 0x00476F63 File Offset: 0x00475163
	// (set) Token: 0x06010542 RID: 66882 RVA: 0x00476F6B File Offset: 0x0047516B
	public override string event_id { get; set; } = "1921";

	// Token: 0x04008076 RID: 32886
	public int i_id;

	// Token: 0x04008077 RID: 32887
	public int i_type;

	// Token: 0x04008078 RID: 32888
	public int i_first_pass;

	// Token: 0x04008079 RID: 32889
	public string s_trace_id = "";
}
