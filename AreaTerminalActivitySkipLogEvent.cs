using System;
using System.Runtime.CompilerServices;

// Token: 0x020021CC RID: 8652
[NullableContext(1)]
[Nullable(0)]
public class AreaTerminalActivitySkipLogEvent : PlayerCommonLogData
{
	// Token: 0x17001420 RID: 5152
	// (get) Token: 0x06010559 RID: 66905 RVA: 0x00477099 File Offset: 0x00475299
	// (set) Token: 0x0601055A RID: 66906 RVA: 0x004770A1 File Offset: 0x004752A1
	public override string event_id { get; set; } = "1924";

	// Token: 0x04008097 RID: 32919
	public int i_id;

	// Token: 0x04008098 RID: 32920
	public int i_type;
}
