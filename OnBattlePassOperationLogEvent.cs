using System;
using System.Runtime.CompilerServices;

// Token: 0x02002158 RID: 8536
[NullableContext(1)]
[Nullable(0)]
public class OnBattlePassOperationLogEvent : PlayerCommonLogData
{
	// Token: 0x170013B0 RID: 5040
	// (get) Token: 0x06010405 RID: 66565 RVA: 0x00475D47 File Offset: 0x00473F47
	// (set) Token: 0x06010406 RID: 66566 RVA: 0x00475D4F File Offset: 0x00473F4F
	public override string event_id { get; set; } = "1832";

	// Token: 0x04007E8A RID: 32394
	public int i_operation_type;
}
