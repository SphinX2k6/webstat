using System;
using System.Runtime.CompilerServices;

// Token: 0x0200213D RID: 8509
[NullableContext(1)]
[Nullable(0)]
public class ExploreToolGeneralUseLogData : UnitLogData
{
	// Token: 0x17001397 RID: 5015
	// (get) Token: 0x060103B8 RID: 66488 RVA: 0x00475966 File Offset: 0x00473B66
	// (set) Token: 0x060103B9 RID: 66489 RVA: 0x0047596E File Offset: 0x00473B6E
	public override string event_id { get; set; } = "";

	// Token: 0x04007E2B RID: 32299
	public int i_father_area_id;

	// Token: 0x04007E2C RID: 32300
	public int i_area_id;

	// Token: 0x04007E2D RID: 32301
	public float f_pos_x;

	// Token: 0x04007E2E RID: 32302
	public float f_pos_y;

	// Token: 0x04007E2F RID: 32303
	public float f_pos_z;

	// Token: 0x04007E30 RID: 32304
	public int i_skill_id;

	// Token: 0x04007E31 RID: 32305
	public int i_entity_configId;
}
