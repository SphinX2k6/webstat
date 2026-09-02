using System;
using System.Runtime.CompilerServices;

// Token: 0x02002139 RID: 8505
[NullableContext(1)]
[Nullable(0)]
public class HookSkillUseLogData : UnitLogData
{
	// Token: 0x17001393 RID: 5011
	// (get) Token: 0x060103AC RID: 66476 RVA: 0x004758D6 File Offset: 0x00473AD6
	// (set) Token: 0x060103AD RID: 66477 RVA: 0x004758DE File Offset: 0x00473ADE
	public override string event_id { get; set; } = "1012";

	// Token: 0x04007E0F RID: 32271
	public int i_father_area_id;

	// Token: 0x04007E10 RID: 32272
	public int i_area_id;

	// Token: 0x04007E11 RID: 32273
	public float f_pos_x;

	// Token: 0x04007E12 RID: 32274
	public float f_pos_y;

	// Token: 0x04007E13 RID: 32275
	public float f_pos_z;

	// Token: 0x04007E14 RID: 32276
	public int i_has_target;
}
