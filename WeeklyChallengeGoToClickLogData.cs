using System;
using System.Runtime.CompilerServices;

// Token: 0x02002142 RID: 8514
[NullableContext(1)]
[Nullable(0)]
public class WeeklyChallengeGoToClickLogData : PlayerCommonLogData
{
	// Token: 0x1700139C RID: 5020
	// (get) Token: 0x060103C7 RID: 66503 RVA: 0x00475A1A File Offset: 0x00473C1A
	// (set) Token: 0x060103C8 RID: 66504 RVA: 0x00475A22 File Offset: 0x00473C22
	public override string event_id { get; set; } = "1031";

	// Token: 0x04007E42 RID: 32322
	public int i_activity_id;

	// Token: 0x04007E43 RID: 32323
	public int i_activity_type;

	// Token: 0x04007E44 RID: 32324
	public int i_unlock;
}
