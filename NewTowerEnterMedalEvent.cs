using System;
using System.Runtime.CompilerServices;

// Token: 0x0200216F RID: 8559
[NullableContext(1)]
[Nullable(0)]
public class NewTowerEnterMedalEvent : PlayerCommonLogData
{
	// Token: 0x170013C7 RID: 5063
	// (get) Token: 0x0601044A RID: 66634 RVA: 0x004760E5 File Offset: 0x004742E5
	// (set) Token: 0x0601044B RID: 66635 RVA: 0x004760ED File Offset: 0x004742ED
	public override string event_id { get; set; } = "1069";

	// Token: 0x04007ED4 RID: 32468
	public int i_activity_id;

	// Token: 0x04007ED5 RID: 32469
	public int i_season_id;
}
