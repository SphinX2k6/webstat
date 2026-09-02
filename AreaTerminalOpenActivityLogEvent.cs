using System;
using System.Runtime.CompilerServices;

// Token: 0x020021CB RID: 8651
[NullableContext(1)]
[Nullable(0)]
public class AreaTerminalOpenActivityLogEvent : PlayerCommonLogData
{
	// Token: 0x1700141F RID: 5151
	// (get) Token: 0x06010556 RID: 66902 RVA: 0x00477075 File Offset: 0x00475275
	// (set) Token: 0x06010557 RID: 66903 RVA: 0x0047707D File Offset: 0x0047527D
	public override string event_id { get; set; } = "1923";

	// Token: 0x04008094 RID: 32916
	public int i_id;

	// Token: 0x04008095 RID: 32917
	public int i_type;
}
