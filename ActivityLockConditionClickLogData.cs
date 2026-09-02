using System;
using System.Runtime.CompilerServices;

// Token: 0x02002141 RID: 8513
[NullableContext(1)]
[Nullable(0)]
public class ActivityLockConditionClickLogData : PlayerCommonLogData
{
	// Token: 0x1700139B RID: 5019
	// (get) Token: 0x060103C4 RID: 66500 RVA: 0x004759F6 File Offset: 0x00473BF6
	// (set) Token: 0x060103C5 RID: 66501 RVA: 0x004759FE File Offset: 0x00473BFE
	public override string event_id { get; set; } = "1029";

	// Token: 0x04007E3F RID: 32319
	public int i_activity_id;

	// Token: 0x04007E40 RID: 32320
	public int i_activity_type;
}
