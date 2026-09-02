using System;
using System.Runtime.CompilerServices;

// Token: 0x020021B5 RID: 8629
[NullableContext(1)]
[Nullable(0)]
public class PeriodicActivityRedClearReport : PlayerCommonLogData
{
	// Token: 0x1700140A RID: 5130
	// (get) Token: 0x06010516 RID: 66838 RVA: 0x00476D2C File Offset: 0x00474F2C
	// (set) Token: 0x06010517 RID: 66839 RVA: 0x00476D34 File Offset: 0x00474F34
	public override string event_id { get; set; } = "1839";

	// Token: 0x04008037 RID: 32823
	public int i_activity_id;

	// Token: 0x04008038 RID: 32824
	public int i_round;

	// Token: 0x04008039 RID: 32825
	public int i_result;

	// Token: 0x0400803A RID: 32826
	public int i_way;
}
