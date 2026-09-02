using System;
using System.Runtime.CompilerServices;

// Token: 0x020011A0 RID: 4512
[RequiredMember]
public class ArtemisActivityCertificationViewParams
{
	// Token: 0x060076AE RID: 30382 RVA: 0x001F119D File Offset: 0x001EF39D
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ArtemisActivityCertificationViewParams()
	{
	}

	// Token: 0x0400396B RID: 14699
	[RequiredMember]
	public bool IsPlayFixedDone;

	// Token: 0x0400396C RID: 14700
	[Nullable(1)]
	[RequiredMember]
	public Action Callback;
}
