using System;
using System.Runtime.CompilerServices;

// Token: 0x020021B4 RID: 8628
[NullableContext(1)]
[Nullable(0)]
public class PeriodicActivityRedAppearReport : PlayerCommonLogData
{
	// Token: 0x17001409 RID: 5129
	// (get) Token: 0x06010513 RID: 66835 RVA: 0x00476D08 File Offset: 0x00474F08
	// (set) Token: 0x06010514 RID: 66836 RVA: 0x00476D10 File Offset: 0x00474F10
	public override string event_id { get; set; } = "1838";

	// Token: 0x04008034 RID: 32820
	public int i_activity_id;

	// Token: 0x04008035 RID: 32821
	public int i_round;
}
