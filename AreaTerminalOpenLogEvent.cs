using System;
using System.Runtime.CompilerServices;

// Token: 0x020021C9 RID: 8649
[NullableContext(1)]
[Nullable(0)]
public class AreaTerminalOpenLogEvent : PlayerCommonLogData
{
	// Token: 0x1700141D RID: 5149
	// (get) Token: 0x06010550 RID: 66896 RVA: 0x0047702D File Offset: 0x0047522D
	// (set) Token: 0x06010551 RID: 66897 RVA: 0x00477035 File Offset: 0x00475235
	public override string event_id { get; set; } = "1925";

	// Token: 0x04008091 RID: 32913
	public int i_type;
}
