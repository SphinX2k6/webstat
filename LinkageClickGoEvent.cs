using System;
using System.Runtime.CompilerServices;

// Token: 0x0200215F RID: 8543
[NullableContext(1)]
[Nullable(0)]
public class LinkageClickGoEvent : PlayerCommonLogData
{
	// Token: 0x170013B7 RID: 5047
	// (get) Token: 0x0601041A RID: 66586 RVA: 0x00475E59 File Offset: 0x00474059
	// (set) Token: 0x0601041B RID: 66587 RVA: 0x00475E61 File Offset: 0x00474061
	public override string event_id { get; set; } = "1059";

	// Token: 0x04007EA4 RID: 32420
	public int i_activity_id;

	// Token: 0x04007EA5 RID: 32421
	public int i_activity_type;

	// Token: 0x04007EA6 RID: 32422
	public int i_id;
}
