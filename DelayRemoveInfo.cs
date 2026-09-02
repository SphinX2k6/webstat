using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003198 RID: 12696
public class DelayRemoveInfo
{
	// Token: 0x0601A560 RID: 107872 RVA: 0x007C23BA File Offset: 0x007C05BA
	[NullableContext(1)]
	public DelayRemoveInfo(AActor actor)
	{
		this.Actor = actor;
	}

	// Token: 0x0400D46B RID: 54379
	public double Counter;

	// Token: 0x0400D46C RID: 54380
	[Nullable(2)]
	public AActor Actor;
}
