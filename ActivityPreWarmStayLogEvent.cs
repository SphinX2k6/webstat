using System;
using System.Runtime.CompilerServices;

// Token: 0x02002196 RID: 8598
[NullableContext(1)]
[Nullable(0)]
public class ActivityPreWarmStayLogEvent : PlayerCommonLogData
{
	// Token: 0x170013EE RID: 5102
	// (get) Token: 0x060104BF RID: 66751 RVA: 0x0047681D File Offset: 0x00474A1D
	// (set) Token: 0x060104C0 RID: 66752 RVA: 0x00476825 File Offset: 0x00474A25
	public override string event_id { get; set; } = "1812";

	// Token: 0x04007F88 RID: 32648
	public int i_activity_id;

	// Token: 0x04007F89 RID: 32649
	public int i_chapter_id;

	// Token: 0x04007F8A RID: 32650
	public double i_cost_time;
}
