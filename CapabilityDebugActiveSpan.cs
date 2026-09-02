using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E46 RID: 3654
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class CapabilityDebugActiveSpan : ICapabilityDebugActiveSpan
{
	// Token: 0x170005E6 RID: 1510
	// (get) Token: 0x06005798 RID: 22424 RVA: 0x0010555D File Offset: 0x0010375D
	// (set) Token: 0x06005799 RID: 22425 RVA: 0x00105565 File Offset: 0x00103765
	[RequiredMember]
	public string CapabilityId { get; set; }

	// Token: 0x170005E7 RID: 1511
	// (get) Token: 0x0600579A RID: 22426 RVA: 0x0010556E File Offset: 0x0010376E
	// (set) Token: 0x0600579B RID: 22427 RVA: 0x00105576 File Offset: 0x00103776
	[RequiredMember]
	public string GameObjectId { get; set; }

	// Token: 0x170005E8 RID: 1512
	// (get) Token: 0x0600579C RID: 22428 RVA: 0x0010557F File Offset: 0x0010377F
	// (set) Token: 0x0600579D RID: 22429 RVA: 0x00105587 File Offset: 0x00103787
	[RequiredMember]
	public string ClassName { get; set; }

	// Token: 0x170005E9 RID: 1513
	// (get) Token: 0x0600579E RID: 22430 RVA: 0x00105590 File Offset: 0x00103790
	// (set) Token: 0x0600579F RID: 22431 RVA: 0x00105598 File Offset: 0x00103798
	[RequiredMember]
	public double StartTime { get; set; }

	// Token: 0x170005EA RID: 1514
	// (get) Token: 0x060057A0 RID: 22432 RVA: 0x001055A1 File Offset: 0x001037A1
	// (set) Token: 0x060057A1 RID: 22433 RVA: 0x001055A9 File Offset: 0x001037A9
	[RequiredMember]
	public double EndTime { get; set; }

	// Token: 0x060057A2 RID: 22434 RVA: 0x001055B2 File Offset: 0x001037B2
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public CapabilityDebugActiveSpan()
	{
	}
}
