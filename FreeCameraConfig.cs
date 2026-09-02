using System;
using UnrealEngine;

// Token: 0x02001138 RID: 4408
internal class FreeCameraConfig : IFreeCameraConfig
{
	// Token: 0x1700095C RID: 2396
	// (get) Token: 0x06007365 RID: 29541 RVA: 0x001E2EED File Offset: 0x001E10ED
	// (set) Token: 0x06007366 RID: 29542 RVA: 0x001E2EF5 File Offset: 0x001E10F5
	public FVectorDouble Pos { get; set; }

	// Token: 0x1700095D RID: 2397
	// (get) Token: 0x06007367 RID: 29543 RVA: 0x001E2EFE File Offset: 0x001E10FE
	// (set) Token: 0x06007368 RID: 29544 RVA: 0x001E2F06 File Offset: 0x001E1106
	public FRotator Rot { get; set; }

	// Token: 0x1700095E RID: 2398
	// (get) Token: 0x06007369 RID: 29545 RVA: 0x001E2F0F File Offset: 0x001E110F
	// (set) Token: 0x0600736A RID: 29546 RVA: 0x001E2F17 File Offset: 0x001E1117
	public float Fov { get; set; }

	// Token: 0x1700095F RID: 2399
	// (get) Token: 0x0600736B RID: 29547 RVA: 0x001E2F20 File Offset: 0x001E1120
	// (set) Token: 0x0600736C RID: 29548 RVA: 0x001E2F28 File Offset: 0x001E1128
	public float Radius { get; set; }

	// Token: 0x17000960 RID: 2400
	// (get) Token: 0x0600736D RID: 29549 RVA: 0x001E2F31 File Offset: 0x001E1131
	// (set) Token: 0x0600736E RID: 29550 RVA: 0x001E2F39 File Offset: 0x001E1139
	public float Interval { get; set; }

	// Token: 0x17000961 RID: 2401
	// (get) Token: 0x0600736F RID: 29551 RVA: 0x001E2F42 File Offset: 0x001E1142
	// (set) Token: 0x06007370 RID: 29552 RVA: 0x001E2F4A File Offset: 0x001E114A
	public float InterpDuration { get; set; }
}
