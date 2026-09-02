using System;
using System.Runtime.CompilerServices;

// Token: 0x020021DA RID: 8666
[NullableContext(1)]
[Nullable(0)]
public class WeeklyChallengeEndTimeRefreshLogEvent : PlayerCommonLogData
{
	// Token: 0x1700142B RID: 5163
	// (get) Token: 0x0601057D RID: 66941 RVA: 0x004772BD File Offset: 0x004754BD
	// (set) Token: 0x0601057E RID: 66942 RVA: 0x004772C5 File Offset: 0x004754C5
	public override string event_id { get; set; } = "1935";

	// Token: 0x040080D7 RID: 32983
	public int i_season_id;
}
