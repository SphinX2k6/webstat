using System;
using System.Runtime.CompilerServices;

// Token: 0x02002145 RID: 8517
[NullableContext(1)]
[Nullable(0)]
public class ActivityPreheatLogData : PlayerCommonLogData
{
	// Token: 0x1700139D RID: 5021
	// (get) Token: 0x060103CC RID: 66508 RVA: 0x00475A4E File Offset: 0x00473C4E
	// (set) Token: 0x060103CD RID: 66509 RVA: 0x00475A56 File Offset: 0x00473C56
	public override string event_id { get; set; } = "1030";

	// Token: 0x04007E50 RID: 32336
	public int i_activity_id;

	// Token: 0x04007E51 RID: 32337
	public int i_activity_type;

	// Token: 0x04007E52 RID: 32338
	public int i_time_left;

	// Token: 0x04007E53 RID: 32339
	public int i_type;
}
