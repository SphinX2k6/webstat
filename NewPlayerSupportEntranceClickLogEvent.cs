using System;
using System.Runtime.CompilerServices;

// Token: 0x02002182 RID: 8578
[NullableContext(1)]
[Nullable(0)]
public class NewPlayerSupportEntranceClickLogEvent : PlayerCommonLogData
{
	// Token: 0x170013DA RID: 5082
	// (get) Token: 0x06010483 RID: 66691 RVA: 0x0047652C File Offset: 0x0047472C
	// (set) Token: 0x06010484 RID: 66692 RVA: 0x00476534 File Offset: 0x00474734
	public override string event_id { get; set; } = "2005";

	// Token: 0x04007F46 RID: 32582
	public int i_entrance_id;
}
