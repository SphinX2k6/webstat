using System;
using System.Runtime.CompilerServices;

// Token: 0x02002129 RID: 8489
[NullableContext(1)]
[Nullable(0)]
public class ElevatorUsedRecord : PlayerCommonLogData
{
	// Token: 0x17001385 RID: 4997
	// (get) Token: 0x0601037D RID: 66429 RVA: 0x0047535B File Offset: 0x0047355B
	// (set) Token: 0x0601037E RID: 66430 RVA: 0x00475363 File Offset: 0x00473563
	public override string event_id { get; set; } = "11";

	// Token: 0x04007D55 RID: 32085
	public string i_area_id = "";

	// Token: 0x04007D56 RID: 32086
	public string i_config_id = "";

	// Token: 0x04007D57 RID: 32087
	public string i_state_id = "";

	// Token: 0x04007D58 RID: 32088
	public string f_player_pos_x = "";

	// Token: 0x04007D59 RID: 32089
	public string f_player_pos_y = "";

	// Token: 0x04007D5A RID: 32090
	public string f_player_pos_z = "";
}
