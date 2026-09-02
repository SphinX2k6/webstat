using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000E49 RID: 3657
[NullableContext(2)]
public interface ICapabilityHostInitParam
{
	// Token: 0x170005F1 RID: 1521
	// (get) Token: 0x060057B0 RID: 22448
	// (set) Token: 0x060057B1 RID: 22449
	[Nullable(1)]
	object Id { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170005F2 RID: 1522
	// (get) Token: 0x060057B2 RID: 22450
	// (set) Token: 0x060057B3 RID: 22451
	Func<bool> IsValid { get; set; }

	// Token: 0x170005F3 RID: 1523
	// (get) Token: 0x060057B4 RID: 22452
	// (set) Token: 0x060057B5 RID: 22453
	Func<AActor> GetBoundActor { get; set; }
}
