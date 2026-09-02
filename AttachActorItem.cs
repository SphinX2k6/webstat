using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003487 RID: 13447
[NullableContext(2)]
[Nullable(0)]
public class AttachActorItem
{
	// Token: 0x0400E444 RID: 58436
	public int Id;

	// Token: 0x0400E445 RID: 58437
	public int EntityId;

	// Token: 0x0400E446 RID: 58438
	public string Reason;

	// Token: 0x0400E447 RID: 58439
	public AActor Actor;

	// Token: 0x0400E448 RID: 58440
	public string Name;

	// Token: 0x0400E449 RID: 58441
	public string ParentActorName;

	// Token: 0x0400E44A RID: 58442
	public EDetachType? DetachType;
}
