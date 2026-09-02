using System;
using System.Runtime.CompilerServices;

// Token: 0x02002195 RID: 8597
[NullableContext(1)]
[Nullable(0)]
public class ActivityPreWarmOpenLogEvent : PlayerCommonLogData
{
	// Token: 0x170013ED RID: 5101
	// (get) Token: 0x060104BC RID: 66748 RVA: 0x004767F9 File Offset: 0x004749F9
	// (set) Token: 0x060104BD RID: 66749 RVA: 0x00476801 File Offset: 0x00474A01
	public override string event_id { get; set; } = "1811";

	// Token: 0x04007F85 RID: 32645
	public int i_activity_id;

	// Token: 0x04007F86 RID: 32646
	public int i_chapter_id;
}
