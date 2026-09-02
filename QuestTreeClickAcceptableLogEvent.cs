using System;
using System.Runtime.CompilerServices;

// Token: 0x02002193 RID: 8595
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeClickAcceptableLogEvent : PlayerCommonLogData
{
	// Token: 0x170013EB RID: 5099
	// (get) Token: 0x060104B6 RID: 66742 RVA: 0x004767A6 File Offset: 0x004749A6
	// (set) Token: 0x060104B7 RID: 66743 RVA: 0x004767AE File Offset: 0x004749AE
	public override string event_id { get; set; } = "1917";

	// Token: 0x04007F80 RID: 32640
	public int i_chapter_id;
}
