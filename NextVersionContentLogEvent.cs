using System;
using System.Runtime.CompilerServices;

// Token: 0x020021C3 RID: 8643
[NullableContext(1)]
[Nullable(0)]
public class NextVersionContentLogEvent : PlayerCommonLogData
{
	// Token: 0x17001417 RID: 5143
	// (get) Token: 0x0601053E RID: 66878 RVA: 0x00476F3F File Offset: 0x0047513F
	// (set) Token: 0x0601053F RID: 66879 RVA: 0x00476F47 File Offset: 0x00475147
	public override string event_id { get; set; } = "1813";

	// Token: 0x04008072 RID: 32882
	public int i_activity_id;

	// Token: 0x04008073 RID: 32883
	public int i_second_tab;

	// Token: 0x04008074 RID: 32884
	public int i_third_tab;
}
