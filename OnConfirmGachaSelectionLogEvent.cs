using System;
using System.Runtime.CompilerServices;

// Token: 0x02002151 RID: 8529
[NullableContext(1)]
[Nullable(0)]
public class OnConfirmGachaSelectionLogEvent : PlayerCommonLogData
{
	// Token: 0x170013A9 RID: 5033
	// (get) Token: 0x060103F0 RID: 66544 RVA: 0x00475C4B File Offset: 0x00473E4B
	// (set) Token: 0x060103F1 RID: 66545 RVA: 0x00475C53 File Offset: 0x00473E53
	public override string event_id { get; set; } = "1855";

	// Token: 0x04007E72 RID: 32370
	public int i_type;

	// Token: 0x04007E73 RID: 32371
	public int i_roleid_id;

	// Token: 0x04007E74 RID: 32372
	public int i_time_left;
}
