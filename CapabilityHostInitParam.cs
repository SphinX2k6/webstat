using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000E4A RID: 3658
[NullableContext(2)]
[Nullable(0)]
[RequiredMember]
public class CapabilityHostInitParam : ICapabilityHostInitParam
{
	// Token: 0x170005F4 RID: 1524
	// (get) Token: 0x060057B6 RID: 22454 RVA: 0x001055F5 File Offset: 0x001037F5
	// (set) Token: 0x060057B7 RID: 22455 RVA: 0x001055FD File Offset: 0x001037FD
	[Nullable(1)]
	[RequiredMember]
	public object Id { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170005F5 RID: 1525
	// (get) Token: 0x060057B8 RID: 22456 RVA: 0x00105606 File Offset: 0x00103806
	// (set) Token: 0x060057B9 RID: 22457 RVA: 0x0010560E File Offset: 0x0010380E
	public Func<bool> IsValid { get; set; }

	// Token: 0x170005F6 RID: 1526
	// (get) Token: 0x060057BA RID: 22458 RVA: 0x00105617 File Offset: 0x00103817
	// (set) Token: 0x060057BB RID: 22459 RVA: 0x0010561F File Offset: 0x0010381F
	public Func<AActor> GetBoundActor { get; set; }

	// Token: 0x060057BC RID: 22460 RVA: 0x00105628 File Offset: 0x00103828
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public CapabilityHostInitParam()
	{
	}
}
