using System;
using System.Runtime.CompilerServices;

// Token: 0x02002180 RID: 8576
[NullableContext(1)]
[Nullable(0)]
public class MotorSummonGetOnLogEvent : PlayerCommonLogData
{
	// Token: 0x170013D8 RID: 5080
	// (get) Token: 0x0601047D RID: 66685 RVA: 0x004764E4 File Offset: 0x004746E4
	// (set) Token: 0x0601047E RID: 66686 RVA: 0x004764EC File Offset: 0x004746EC
	public override string event_id { get; set; } = "2003";

	// Token: 0x04007F3C RID: 32572
	public float pos_x;

	// Token: 0x04007F3D RID: 32573
	public float pos_y;

	// Token: 0x04007F3E RID: 32574
	public float pos_z;

	// Token: 0x04007F3F RID: 32575
	public int operation_type;
}
