using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000E4B RID: 3659
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class HostDefaultScheduleCacheEntry
{
	// Token: 0x170005F7 RID: 1527
	// (get) Token: 0x060057BD RID: 22461 RVA: 0x00105630 File Offset: 0x00103830
	// (set) Token: 0x060057BE RID: 22462 RVA: 0x00105638 File Offset: 0x00103838
	[RequiredMember]
	public int Generation { get; set; }

	// Token: 0x170005F8 RID: 1528
	// (get) Token: 0x060057BF RID: 22463 RVA: 0x00105641 File Offset: 0x00103841
	// (set) Token: 0x060057C0 RID: 22464 RVA: 0x00105649 File Offset: 0x00103849
	[RequiredMember]
	public List<IScheduledEntry> Schedule { get; set; }

	// Token: 0x060057C1 RID: 22465 RVA: 0x00105652 File Offset: 0x00103852
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public HostDefaultScheduleCacheEntry()
	{
	}
}
