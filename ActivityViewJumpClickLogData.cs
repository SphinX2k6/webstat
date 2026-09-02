using System;
using System.Runtime.CompilerServices;

// Token: 0x02002140 RID: 8512
[NullableContext(1)]
[Nullable(0)]
public class ActivityViewJumpClickLogData : PlayerCommonLogData
{
	// Token: 0x1700139A RID: 5018
	// (get) Token: 0x060103C1 RID: 66497 RVA: 0x004759D2 File Offset: 0x00473BD2
	// (set) Token: 0x060103C2 RID: 66498 RVA: 0x004759DA File Offset: 0x00473BDA
	public override string event_id { get; set; } = "1021";

	// Token: 0x04007E3B RID: 32315
	public int i_activity_id;

	// Token: 0x04007E3C RID: 32316
	public int i_activity_type;

	// Token: 0x04007E3D RID: 32317
	public int i_unlock;
}
