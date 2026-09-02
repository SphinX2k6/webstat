using System;
using System.Runtime.CompilerServices;

// Token: 0x02002178 RID: 8568
[NullableContext(1)]
[Nullable(0)]
public class KingShipLogEvent : PlayerCommonLogData
{
	// Token: 0x170013D0 RID: 5072
	// (get) Token: 0x06010465 RID: 66661 RVA: 0x004763A3 File Offset: 0x004745A3
	// (set) Token: 0x06010466 RID: 66662 RVA: 0x004763AB File Offset: 0x004745AB
	public override string event_id { get; set; } = "1801";

	// Token: 0x04007F2C RID: 32556
	public int i_step_id;
}
