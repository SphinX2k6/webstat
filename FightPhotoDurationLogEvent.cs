using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020021D5 RID: 8661
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoDurationLogEvent : PlayerCommonLogData
{
	// Token: 0x17001426 RID: 5158
	// (get) Token: 0x0601056E RID: 66926 RVA: 0x004771E8 File Offset: 0x004753E8
	// (set) Token: 0x0601056F RID: 66927 RVA: 0x004771F0 File Offset: 0x004753F0
	public override string event_id { get; set; } = "1932";

	// Token: 0x040080BD RID: 32957
	public int i_total_duration;

	// Token: 0x040080BE RID: 32958
	public int i_add_time;

	// Token: 0x040080BF RID: 32959
	public List<int> o_team_character = new List<int>();

	// Token: 0x040080C0 RID: 32960
	public List<FightPhotoTeamSkinData> o_team_suit = new List<FightPhotoTeamSkinData>();

	// Token: 0x040080C1 RID: 32961
	public int i_result;

	// Token: 0x040080C2 RID: 32962
	public int i_inst_id;

	// Token: 0x040080C3 RID: 32963
	public int i_inst_diff;

	// Token: 0x040080C4 RID: 32964
	public string s_trace_id = "";
}
