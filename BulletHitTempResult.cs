using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E02 RID: 11778
public class BulletHitTempResult
{
	// Token: 0x0400B804 RID: 47108
	public int Index;

	// Token: 0x0400B805 RID: 47109
	public double DistSquared;

	// Token: 0x0400B806 RID: 47110
	[Nullable(1)]
	public Vector ImpactPoint = Vector.Create();

	// Token: 0x0400B807 RID: 47111
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public TWeakObjectPtr<UPrimitiveComponent>? Component;

	// Token: 0x0400B808 RID: 47112
	[Nullable(2)]
	public AActor Actor;

	// Token: 0x0400B809 RID: 47113
	public int HitItem;
}
