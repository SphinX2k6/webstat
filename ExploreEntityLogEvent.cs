using System;
using System.Runtime.CompilerServices;

// Token: 0x020021AA RID: 8618
[NullableContext(1)]
[Nullable(0)]
public class ExploreEntityLogEvent : PlayerCommonLogData
{
	// Token: 0x17001401 RID: 5121
	// (get) Token: 0x060104F9 RID: 66809 RVA: 0x00476B6B File Offset: 0x00474D6B
	// (set) Token: 0x060104FA RID: 66810 RVA: 0x00476B73 File Offset: 0x00474D73
	public override string event_id { get; set; } = "1172";

	// Token: 0x04007FE8 RID: 32744
	public int i_config_id;

	// Token: 0x04007FE9 RID: 32745
	public int i_type;

	// Token: 0x04007FEA RID: 32746
	public int interaction;

	// Token: 0x04007FEB RID: 32747
	public int i_status;

	// Token: 0x04007FEC RID: 32748
	public int i_result;

	// Token: 0x04007FED RID: 32749
	public float f_pos_x;

	// Token: 0x04007FEE RID: 32750
	public float f_pos_y;

	// Token: 0x04007FEF RID: 32751
	public float f_pos_z;

	// Token: 0x04007FF0 RID: 32752
	public int i_area_id;

	// Token: 0x04007FF1 RID: 32753
	public int i_father_area_id;
}
