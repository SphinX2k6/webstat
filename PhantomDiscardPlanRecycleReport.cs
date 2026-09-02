using System;
using System.Runtime.CompilerServices;

// Token: 0x020021B9 RID: 8633
[NullableContext(1)]
[Nullable(0)]
public class PhantomDiscardPlanRecycleReport : PlayerCommonLogData
{
	// Token: 0x1700140D RID: 5133
	// (get) Token: 0x06010520 RID: 66848 RVA: 0x00476DAB File Offset: 0x00474FAB
	// (set) Token: 0x06010521 RID: 66849 RVA: 0x00476DB3 File Offset: 0x00474FB3
	public override string event_id { get; set; } = "1842";

	// Token: 0x04008048 RID: 32840
	public int i_type;

	// Token: 0x04008049 RID: 32841
	public int i_operation;
}
