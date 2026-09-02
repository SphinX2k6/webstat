using System;
using System.Runtime.CompilerServices;

// Token: 0x0200217B RID: 8571
[NullableContext(1)]
[Nullable(0)]
public class HoldHandExitLogEvent : PlayerCommonLogData
{
	// Token: 0x170013D3 RID: 5075
	// (get) Token: 0x0601046E RID: 66670 RVA: 0x0047641A File Offset: 0x0047461A
	// (set) Token: 0x0601046F RID: 66671 RVA: 0x00476422 File Offset: 0x00474622
	public override string event_id { get; set; } = "160302";

	// Token: 0x04007F32 RID: 32562
	public string reason = "";
}
