using System;
using System.Runtime.CompilerServices;

// Token: 0x02002128 RID: 8488
[NullableContext(1)]
[Nullable(0)]
public class TriggerBuffDamageRecord : PlayerCommonLogData
{
	// Token: 0x17001384 RID: 4996
	// (get) Token: 0x0601037A RID: 66426 RVA: 0x004752DD File Offset: 0x004734DD
	// (set) Token: 0x0601037B RID: 66427 RVA: 0x004752E5 File Offset: 0x004734E5
	public override string event_id { get; set; } = "6";

	// Token: 0x04007D4D RID: 32077
	public string i_area_id = "";

	// Token: 0x04007D4E RID: 32078
	public string s_buff_id = "";

	// Token: 0x04007D4F RID: 32079
	public string f_time = "";

	// Token: 0x04007D50 RID: 32080
	public string f_player_pos_x = "";

	// Token: 0x04007D51 RID: 32081
	public string f_player_pos_y = "";

	// Token: 0x04007D52 RID: 32082
	public string f_player_pos_z = "";

	// Token: 0x04007D53 RID: 32083
	public string i_damage = "";
}
