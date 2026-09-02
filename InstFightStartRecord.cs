using System;
using System.Runtime.CompilerServices;

// Token: 0x02002121 RID: 8481
[NullableContext(1)]
[Nullable(0)]
public class InstFightStartRecord : PlayerCommonLogData
{
	// Token: 0x1700137D RID: 4989
	// (get) Token: 0x06010363 RID: 66403 RVA: 0x00474F4E File Offset: 0x0047314E
	// (set) Token: 0x06010364 RID: 66404 RVA: 0x00474F56 File Offset: 0x00473156
	public override string event_id { get; set; } = "102800";

	// Token: 0x06010365 RID: 66405 RVA: 0x00474F5F File Offset: 0x0047315F
	public void Clear()
	{
		this.i_start_time = 0.0;
		this.i_area_index = 0;
	}

	// Token: 0x04007D1A RID: 32026
	public int i_inst_id;

	// Token: 0x04007D1B RID: 32027
	public string s_fight_id = "";

	// Token: 0x04007D1C RID: 32028
	public string s_fight_roles = "";

	// Token: 0x04007D1D RID: 32029
	public double i_start_time;

	// Token: 0x04007D1E RID: 32030
	public int i_area_index;
}
