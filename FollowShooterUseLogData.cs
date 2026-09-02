using System;
using System.Runtime.CompilerServices;

// Token: 0x0200213C RID: 8508
[NullableContext(1)]
[Nullable(0)]
public class FollowShooterUseLogData : UnitLogData
{
	// Token: 0x17001396 RID: 5014
	// (get) Token: 0x060103B5 RID: 66485 RVA: 0x00475942 File Offset: 0x00473B42
	// (set) Token: 0x060103B6 RID: 66486 RVA: 0x0047594A File Offset: 0x00473B4A
	public override string event_id { get; set; } = "1025";

	// Token: 0x04007E24 RID: 32292
	public int i_father_area_id;

	// Token: 0x04007E25 RID: 32293
	public int i_area_id;

	// Token: 0x04007E26 RID: 32294
	public double f_pos_x;

	// Token: 0x04007E27 RID: 32295
	public double f_pos_y;

	// Token: 0x04007E28 RID: 32296
	public double f_pos_z;

	// Token: 0x04007E29 RID: 32297
	public int i_has_target;
}
