using System;
using System.Runtime.CompilerServices;

// Token: 0x02002194 RID: 8596
[NullableContext(1)]
[Nullable(0)]
public class CustomServiceLogEvent : PlayerCommonLogData
{
	// Token: 0x170013EC RID: 5100
	// (get) Token: 0x060104B9 RID: 66745 RVA: 0x004767CA File Offset: 0x004749CA
	// (set) Token: 0x060104BA RID: 66746 RVA: 0x004767D2 File Offset: 0x004749D2
	public override string event_id { get; set; } = "1810";

	// Token: 0x04007F82 RID: 32642
	public string s_trace_id = "";

	// Token: 0x04007F83 RID: 32643
	public int log_status;
}
