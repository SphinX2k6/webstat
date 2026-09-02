using System;
using System.Runtime.CompilerServices;

// Token: 0x02002114 RID: 8468
[NullableContext(1)]
[Nullable(0)]
public class HangUpTimeLogData : PlayerCommonLogData
{
	// Token: 0x17001375 RID: 4981
	// (get) Token: 0x06010347 RID: 66375 RVA: 0x00474CDB File Offset: 0x00472EDB
	// (set) Token: 0x06010348 RID: 66376 RVA: 0x00474CE3 File Offset: 0x00472EE3
	public override string event_id { get; set; } = "7";

	// Token: 0x04007C7A RID: 31866
	public string f_hang_up_time = "";
}
