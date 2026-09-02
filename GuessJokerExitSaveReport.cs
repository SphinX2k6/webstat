using System;
using System.Runtime.CompilerServices;

// Token: 0x020021B3 RID: 8627
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerExitSaveReport : PlayerCommonLogData
{
	// Token: 0x17001408 RID: 5128
	// (get) Token: 0x06010510 RID: 66832 RVA: 0x00476CD9 File Offset: 0x00474ED9
	// (set) Token: 0x06010511 RID: 66833 RVA: 0x00476CE1 File Offset: 0x00474EE1
	public override string event_id { get; set; } = "1837";

	// Token: 0x0400802E RID: 32814
	public int i_level_id;

	// Token: 0x0400802F RID: 32815
	public string s_trace_id = "";

	// Token: 0x04008030 RID: 32816
	public int i_turn_id;

	// Token: 0x04008031 RID: 32817
	public int i_role_hp;

	// Token: 0x04008032 RID: 32818
	public int i_enemy_hp;
}
