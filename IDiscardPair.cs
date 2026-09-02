using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001EF5 RID: 7925
[NullableContext(1)]
public interface IDiscardPair
{
	// Token: 0x1700121E RID: 4638
	// (get) Token: 0x0600EBF4 RID: 60404
	// (set) Token: 0x0600EBF5 RID: 60405
	UUIItem NotActive { get; set; }

	// Token: 0x1700121F RID: 4639
	// (get) Token: 0x0600EBF6 RID: 60406
	// (set) Token: 0x0600EBF7 RID: 60407
	UUIItem Active { get; set; }
}
