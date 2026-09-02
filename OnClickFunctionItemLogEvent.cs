using System;
using System.Runtime.CompilerServices;

// Token: 0x02002150 RID: 8528
[NullableContext(1)]
[Nullable(0)]
public class OnClickFunctionItemLogEvent : PlayerCommonLogData
{
	// Token: 0x170013A8 RID: 5032
	// (get) Token: 0x060103ED RID: 66541 RVA: 0x00475C27 File Offset: 0x00473E27
	// (set) Token: 0x060103EE RID: 66542 RVA: 0x00475C2F File Offset: 0x00473E2F
	public override string event_id { get; set; } = "1854";

	// Token: 0x04007E6F RID: 32367
	public int i_id;

	// Token: 0x04007E70 RID: 32368
	public int i_type;
}
