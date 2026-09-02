using System;
using System.Runtime.CompilerServices;

// Token: 0x0200217F RID: 8575
[NullableContext(1)]
[Nullable(0)]
public class MotorDriftLogEvent : PlayerCommonLogData
{
	// Token: 0x170013D7 RID: 5079
	// (get) Token: 0x0601047A RID: 66682 RVA: 0x004764C0 File Offset: 0x004746C0
	// (set) Token: 0x0601047B RID: 66683 RVA: 0x004764C8 File Offset: 0x004746C8
	public override string event_id { get; set; } = "2002";

	// Token: 0x04007F39 RID: 32569
	public float i_drift_distance;

	// Token: 0x04007F3A RID: 32570
	public float i_drift_time;
}
