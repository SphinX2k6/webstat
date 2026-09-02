using System;
using System.Runtime.CompilerServices;

// Token: 0x0200213F RID: 8511
[NullableContext(1)]
[Nullable(0)]
public class ActivityTabViewOpenLogData : PlayerCommonLogData
{
	// Token: 0x17001399 RID: 5017
	// (get) Token: 0x060103BE RID: 66494 RVA: 0x004759AE File Offset: 0x00473BAE
	// (set) Token: 0x060103BF RID: 66495 RVA: 0x004759B6 File Offset: 0x00473BB6
	public override string event_id { get; set; } = "1020";

	// Token: 0x04007E35 RID: 32309
	public int i_activity_id;

	// Token: 0x04007E36 RID: 32310
	public int i_activity_type;

	// Token: 0x04007E37 RID: 32311
	public int i_time_left;

	// Token: 0x04007E38 RID: 32312
	public int i_unlock;

	// Token: 0x04007E39 RID: 32313
	public int i_type;
}
