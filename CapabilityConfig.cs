using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000E3E RID: 3646
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class CapabilityConfig : ICapabilityConfig
{
	// Token: 0x170005C9 RID: 1481
	// (get) Token: 0x06005745 RID: 22341 RVA: 0x00105435 File Offset: 0x00103635
	// (set) Token: 0x06005746 RID: 22342 RVA: 0x0010543D File Offset: 0x0010363D
	[RequiredMember]
	public List<int> Tags { get; set; }

	// Token: 0x170005CA RID: 1482
	// (get) Token: 0x06005747 RID: 22343 RVA: 0x00105446 File Offset: 0x00103646
	// (set) Token: 0x06005748 RID: 22344 RVA: 0x0010544E File Offset: 0x0010364E
	public ETickingGroup? TickGroup { get; set; }

	// Token: 0x170005CB RID: 1483
	// (get) Token: 0x06005749 RID: 22345 RVA: 0x00105457 File Offset: 0x00103657
	// (set) Token: 0x0600574A RID: 22346 RVA: 0x0010545F File Offset: 0x0010365F
	[RequiredMember]
	public int TickGroupOrder { get; set; }

	// Token: 0x170005CC RID: 1484
	// (get) Token: 0x0600574B RID: 22347 RVA: 0x00105468 File Offset: 0x00103668
	// (set) Token: 0x0600574C RID: 22348 RVA: 0x00105470 File Offset: 0x00103670
	public ETickingGroup? InactiveTickGroup { get; set; }

	// Token: 0x170005CD RID: 1485
	// (get) Token: 0x0600574D RID: 22349 RVA: 0x00105479 File Offset: 0x00103679
	// (set) Token: 0x0600574E RID: 22350 RVA: 0x00105481 File Offset: 0x00103681
	public int? InactiveTickGroupOrder { get; set; }

	// Token: 0x170005CE RID: 1486
	// (get) Token: 0x0600574F RID: 22351 RVA: 0x0010548A File Offset: 0x0010368A
	// (set) Token: 0x06005750 RID: 22352 RVA: 0x00105492 File Offset: 0x00103692
	[RequiredMember]
	public List<int> InterruptsTags { get; set; }

	// Token: 0x06005751 RID: 22353 RVA: 0x0010549B File Offset: 0x0010369B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public CapabilityConfig()
	{
	}
}
