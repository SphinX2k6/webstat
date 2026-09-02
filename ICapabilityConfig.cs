using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000E3D RID: 3645
[NullableContext(1)]
public interface ICapabilityConfig
{
	// Token: 0x170005C3 RID: 1475
	// (get) Token: 0x06005739 RID: 22329
	// (set) Token: 0x0600573A RID: 22330
	List<int> Tags { get; set; }

	// Token: 0x170005C4 RID: 1476
	// (get) Token: 0x0600573B RID: 22331
	// (set) Token: 0x0600573C RID: 22332
	ETickingGroup? TickGroup { get; set; }

	// Token: 0x170005C5 RID: 1477
	// (get) Token: 0x0600573D RID: 22333
	// (set) Token: 0x0600573E RID: 22334
	int TickGroupOrder { get; set; }

	// Token: 0x170005C6 RID: 1478
	// (get) Token: 0x0600573F RID: 22335
	// (set) Token: 0x06005740 RID: 22336
	ETickingGroup? InactiveTickGroup { get; set; }

	// Token: 0x170005C7 RID: 1479
	// (get) Token: 0x06005741 RID: 22337
	// (set) Token: 0x06005742 RID: 22338
	int? InactiveTickGroupOrder { get; set; }

	// Token: 0x170005C8 RID: 1480
	// (get) Token: 0x06005743 RID: 22339
	// (set) Token: 0x06005744 RID: 22340
	List<int> InterruptsTags { get; set; }
}
