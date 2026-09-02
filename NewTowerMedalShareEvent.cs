using System;
using System.Runtime.CompilerServices;

// Token: 0x02002172 RID: 8562
[NullableContext(1)]
[Nullable(0)]
public class NewTowerMedalShareEvent : PlayerCommonLogData
{
	// Token: 0x170013CA RID: 5066
	// (get) Token: 0x06010453 RID: 66643 RVA: 0x00476151 File Offset: 0x00474351
	// (set) Token: 0x06010454 RID: 66644 RVA: 0x00476159 File Offset: 0x00474359
	public override string event_id { get; set; } = "1072";

	// Token: 0x04007EDF RID: 32479
	public int i_season_id;

	// Token: 0x04007EE0 RID: 32480
	public string s_item_id = "";
}
