using System;
using System.Runtime.CompilerServices;

// Token: 0x0200213A RID: 8506
[NullableContext(1)]
[Nullable(0)]
public class ManipulateSkillUseLogData : UnitLogData
{
	// Token: 0x17001394 RID: 5012
	// (get) Token: 0x060103AF RID: 66479 RVA: 0x004758FA File Offset: 0x00473AFA
	// (set) Token: 0x060103B0 RID: 66480 RVA: 0x00475902 File Offset: 0x00473B02
	public override string event_id { get; set; } = "1013";

	// Token: 0x04007E16 RID: 32278
	public int i_father_area_id;

	// Token: 0x04007E17 RID: 32279
	public int i_area_id;

	// Token: 0x04007E18 RID: 32280
	public float f_pos_x;

	// Token: 0x04007E19 RID: 32281
	public float f_pos_y;

	// Token: 0x04007E1A RID: 32282
	public float f_pos_z;

	// Token: 0x04007E1B RID: 32283
	public int i_has_target;
}
