using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000014 RID: 20
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class PendingActor
{
	// Token: 0x06000028 RID: 40 RVA: 0x000021B5 File Offset: 0x000003B5
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public PendingActor()
	{
	}

	// Token: 0x04000001 RID: 1
	[RequiredMember]
	public AActor Actor;

	// Token: 0x04000002 RID: 2
	[RequiredMember]
	public string Klass;

	// Token: 0x04000003 RID: 3
	public int ReasonId;
}
