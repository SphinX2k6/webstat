using System;
using System.Runtime.CompilerServices;

// Token: 0x0200213B RID: 8507
[NullableContext(1)]
[Nullable(0)]
public class ScanSkillUseLogData : UnitLogData
{
	// Token: 0x17001395 RID: 5013
	// (get) Token: 0x060103B2 RID: 66482 RVA: 0x0047591E File Offset: 0x00473B1E
	// (set) Token: 0x060103B3 RID: 66483 RVA: 0x00475926 File Offset: 0x00473B26
	public override string event_id { get; set; } = "1014";

	// Token: 0x04007E1D RID: 32285
	public int i_father_area_id;

	// Token: 0x04007E1E RID: 32286
	public int i_area_id;

	// Token: 0x04007E1F RID: 32287
	public float f_pos_x;

	// Token: 0x04007E20 RID: 32288
	public float f_pos_y;

	// Token: 0x04007E21 RID: 32289
	public float f_pos_z;

	// Token: 0x04007E22 RID: 32290
	public int i_has_target;
}
