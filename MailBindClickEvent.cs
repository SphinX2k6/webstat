using System;
using System.Runtime.CompilerServices;

// Token: 0x02002159 RID: 8537
[NullableContext(1)]
[Nullable(0)]
public class MailBindClickEvent : PlayerCommonLogData
{
	// Token: 0x170013B1 RID: 5041
	// (get) Token: 0x06010408 RID: 66568 RVA: 0x00475D6B File Offset: 0x00473F6B
	// (set) Token: 0x06010409 RID: 66569 RVA: 0x00475D73 File Offset: 0x00473F73
	public override string event_id { get; set; } = "1051";

	// Token: 0x04007E8C RID: 32396
	public int i_language;

	// Token: 0x04007E8D RID: 32397
	public int i_if_binded;
}
