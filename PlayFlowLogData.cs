using System;
using System.Runtime.CompilerServices;

// Token: 0x02002131 RID: 8497
[NullableContext(1)]
[Nullable(0)]
public class PlayFlowLogData : PlayerCommonLogData
{
	// Token: 0x1700138C RID: 5004
	// (get) Token: 0x06010393 RID: 66451 RVA: 0x004756DB File Offset: 0x004738DB
	// (set) Token: 0x06010394 RID: 66452 RVA: 0x004756E3 File Offset: 0x004738E3
	public override string event_id { get; set; } = "1010";

	// Token: 0x04007DEB RID: 32235
	public int i_bubble_type;

	// Token: 0x04007DEC RID: 32236
	public string s_flow_file = "";

	// Token: 0x04007DED RID: 32237
	public int i_flow_id;

	// Token: 0x04007DEE RID: 32238
	public int i_flow_status_id;

	// Token: 0x04007DEF RID: 32239
	public int i_config_id;

	// Token: 0x04007DF0 RID: 32240
	public int i_area_id;

	// Token: 0x04007DF1 RID: 32241
	public int i_father_area_id;

	// Token: 0x04007DF2 RID: 32242
	public float f_pos_x;

	// Token: 0x04007DF3 RID: 32243
	public float f_pos_y;

	// Token: 0x04007DF4 RID: 32244
	public float f_pos_z;
}
