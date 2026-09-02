using System;
using System.Runtime.CompilerServices;

// Token: 0x020023FA RID: 9210
[NullableContext(1)]
[Nullable(0)]
public class WeekCostData : IWeekCostData
{
	// Token: 0x17001679 RID: 5753
	// (get) Token: 0x06011D2E RID: 73006 RVA: 0x004E73E5 File Offset: 0x004E55E5
	// (set) Token: 0x06011D2F RID: 73007 RVA: 0x004E73ED File Offset: 0x004E55ED
	public string Tips { get; set; }

	// Token: 0x1700167A RID: 5754
	// (get) Token: 0x06011D30 RID: 73008 RVA: 0x004E73F6 File Offset: 0x004E55F6
	// (set) Token: 0x06011D31 RID: 73009 RVA: 0x004E73FE File Offset: 0x004E55FE
	public int ItemId { get; set; }

	// Token: 0x1700167B RID: 5755
	// (get) Token: 0x06011D32 RID: 73010 RVA: 0x004E7407 File Offset: 0x004E5607
	// (set) Token: 0x06011D33 RID: 73011 RVA: 0x004E740F File Offset: 0x004E560F
	public int Count { get; set; }
}
