using System;
using System.Runtime.CompilerServices;

// Token: 0x02002171 RID: 8561
[NullableContext(1)]
[Nullable(0)]
public class NewTowerClickMedalSkipEvent : PlayerCommonLogData
{
	// Token: 0x170013C9 RID: 5065
	// (get) Token: 0x06010450 RID: 66640 RVA: 0x0047612D File Offset: 0x0047432D
	// (set) Token: 0x06010451 RID: 66641 RVA: 0x00476135 File Offset: 0x00474335
	public override string event_id { get; set; } = "1071";

	// Token: 0x04007EDB RID: 32475
	public int i_activity_id;

	// Token: 0x04007EDC RID: 32476
	public int i_season_id;

	// Token: 0x04007EDD RID: 32477
	public int i_item_id;
}
