using System;
using System.Runtime.CompilerServices;

// Token: 0x0200217E RID: 8574
[NullableContext(1)]
[Nullable(0)]
public class MotorFirstSightLogEvent : PlayerCommonLogData
{
	// Token: 0x170013D6 RID: 5078
	// (get) Token: 0x06010477 RID: 66679 RVA: 0x0047649C File Offset: 0x0047469C
	// (set) Token: 0x06010478 RID: 66680 RVA: 0x004764A4 File Offset: 0x004746A4
	public override string event_id { get; set; } = "2001";

	// Token: 0x04007F37 RID: 32567
	public float i_view_switching;
}
