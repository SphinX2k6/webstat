using System;
using System.Runtime.CompilerServices;

// Token: 0x02002170 RID: 8560
[NullableContext(1)]
[Nullable(0)]
public class NewTowerClickMedalEvent : PlayerCommonLogData
{
	// Token: 0x170013C8 RID: 5064
	// (get) Token: 0x0601044D RID: 66637 RVA: 0x00476109 File Offset: 0x00474309
	// (set) Token: 0x0601044E RID: 66638 RVA: 0x00476111 File Offset: 0x00474311
	public override string event_id { get; set; } = "1070";

	// Token: 0x04007ED7 RID: 32471
	public int i_activity_id;

	// Token: 0x04007ED8 RID: 32472
	public int i_season_id;

	// Token: 0x04007ED9 RID: 32473
	public int i_item_id;
}
