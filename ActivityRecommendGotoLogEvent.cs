using System;
using System.Runtime.CompilerServices;

// Token: 0x02002183 RID: 8579
[NullableContext(1)]
[Nullable(0)]
public class ActivityRecommendGotoLogEvent : PlayerCommonLogData
{
	// Token: 0x170013DB RID: 5083
	// (get) Token: 0x06010486 RID: 66694 RVA: 0x00476550 File Offset: 0x00474750
	// (set) Token: 0x06010487 RID: 66695 RVA: 0x00476558 File Offset: 0x00474758
	public override string event_id { get; set; } = "2006";

	// Token: 0x04007F48 RID: 32584
	public int i_task_type;

	// Token: 0x04007F49 RID: 32585
	public int i_goto_id;
}
