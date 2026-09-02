using System;
using System.Runtime.CompilerServices;

// Token: 0x020021CF RID: 8655
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerRankChangeEvent : PlayerCommonLogData
{
	// Token: 0x17001423 RID: 5155
	// (get) Token: 0x06010562 RID: 66914 RVA: 0x00477105 File Offset: 0x00475305
	// (set) Token: 0x06010563 RID: 66915 RVA: 0x0047710D File Offset: 0x0047530D
	public override string event_id { get; set; } = "1931";

	// Token: 0x040080A0 RID: 32928
	public int i_best_star;

	// Token: 0x040080A1 RID: 32929
	public int i_current_star;

	// Token: 0x040080A2 RID: 32930
	public int i_target_star;

	// Token: 0x040080A3 RID: 32931
	public int i_dungeon_id;

	// Token: 0x040080A4 RID: 32932
	public string s_trace_id = "";

	// Token: 0x040080A5 RID: 32933
	public string s_battle_id = "";

	// Token: 0x040080A6 RID: 32934
	public int i_old_exp;

	// Token: 0x040080A7 RID: 32935
	public int i_new_exp;

	// Token: 0x040080A8 RID: 32936
	public int i_old_level;

	// Token: 0x040080A9 RID: 32937
	public int i_new_level;
}
