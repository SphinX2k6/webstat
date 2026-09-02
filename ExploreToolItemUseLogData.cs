using System;
using System.Runtime.CompilerServices;

// Token: 0x02002138 RID: 8504
[NullableContext(1)]
[Nullable(0)]
public class ExploreToolItemUseLogData : PlayerCommonLogData
{
	// Token: 0x17001392 RID: 5010
	// (get) Token: 0x060103A9 RID: 66473 RVA: 0x004758B2 File Offset: 0x00473AB2
	// (set) Token: 0x060103AA RID: 66474 RVA: 0x004758BA File Offset: 0x00473ABA
	public override string event_id { get; set; } = "1015";

	// Token: 0x04007E08 RID: 32264
	public int i_father_area_id;

	// Token: 0x04007E09 RID: 32265
	public int i_area_id;

	// Token: 0x04007E0A RID: 32266
	public float f_pos_x;

	// Token: 0x04007E0B RID: 32267
	public float f_pos_y;

	// Token: 0x04007E0C RID: 32268
	public float f_pos_z;

	// Token: 0x04007E0D RID: 32269
	public int i_item_id;
}
