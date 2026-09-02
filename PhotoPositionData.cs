using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020025E5 RID: 9701
[NullableContext(1)]
[Nullable(0)]
public class PhotoPositionData : IPositionData
{
	// Token: 0x170017C9 RID: 6089
	// (get) Token: 0x06012FEA RID: 77802 RVA: 0x00542298 File Offset: 0x00540498
	// (set) Token: 0x06012FEB RID: 77803 RVA: 0x005422A0 File Offset: 0x005404A0
	public string Id { get; set; } = "";

	// Token: 0x170017CA RID: 6090
	// (get) Token: 0x06012FEC RID: 77804 RVA: 0x005422A9 File Offset: 0x005404A9
	// (set) Token: 0x06012FED RID: 77805 RVA: 0x005422B1 File Offset: 0x005404B1
	public FVector2D Vector { get; set; } = new FVector2D(0f, 0f);

	// Token: 0x170017CB RID: 6091
	// (get) Token: 0x06012FEE RID: 77806 RVA: 0x005422BA File Offset: 0x005404BA
	// (set) Token: 0x06012FEF RID: 77807 RVA: 0x005422C2 File Offset: 0x005404C2
	public bool NotShow { get; set; }

	// Token: 0x170017CC RID: 6092
	// (get) Token: 0x06012FF0 RID: 77808 RVA: 0x005422CB File Offset: 0x005404CB
	// (set) Token: 0x06012FF1 RID: 77809 RVA: 0x005422D3 File Offset: 0x005404D3
	public bool IsOptional { get; set; }

	// Token: 0x170017CD RID: 6093
	// (get) Token: 0x06012FF2 RID: 77810 RVA: 0x005422DC File Offset: 0x005404DC
	// (set) Token: 0x06012FF3 RID: 77811 RVA: 0x005422E4 File Offset: 0x005404E4
	public bool IsOptionalFinished { get; set; }
}
