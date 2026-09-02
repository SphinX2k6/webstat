using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E42 RID: 3650
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ICapabilityBlockEntry
{
	// Token: 0x170005CF RID: 1487
	// (get) Token: 0x06005768 RID: 22376 RVA: 0x001054A3 File Offset: 0x001036A3
	// (set) Token: 0x06005769 RID: 22377 RVA: 0x001054AB File Offset: 0x001036AB
	[RequiredMember]
	public int Tag { get; set; }

	// Token: 0x170005D0 RID: 1488
	// (get) Token: 0x0600576A RID: 22378 RVA: 0x001054B4 File Offset: 0x001036B4
	// (set) Token: 0x0600576B RID: 22379 RVA: 0x001054BC File Offset: 0x001036BC
	[RequiredMember]
	public object Instigator { get; set; }

	// Token: 0x0600576C RID: 22380 RVA: 0x001054C5 File Offset: 0x001036C5
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ICapabilityBlockEntry()
	{
	}
}
