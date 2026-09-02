using System;
using System.Runtime.CompilerServices;

// Token: 0x0200212A RID: 8490
[NullableContext(1)]
[Nullable(0)]
public class DeathRecord : PlayerCommonLogData
{
	// Token: 0x17001386 RID: 4998
	// (get) Token: 0x06010380 RID: 66432 RVA: 0x004753CC File Offset: 0x004735CC
	// (set) Token: 0x06010381 RID: 66433 RVA: 0x004753D4 File Offset: 0x004735D4
	public override string event_id { get; set; } = "102706";

	// Token: 0x04007D5C RID: 32092
	public int i_area_id;

	// Token: 0x04007D5D RID: 32093
	public int i_area_level;

	// Token: 0x04007D5E RID: 32094
	public float f_x;

	// Token: 0x04007D5F RID: 32095
	public float f_y;

	// Token: 0x04007D60 RID: 32096
	public float f_z;

	// Token: 0x04007D61 RID: 32097
	public int i_death_role_id;

	// Token: 0x04007D62 RID: 32098
	public int i_death_reason;
}
