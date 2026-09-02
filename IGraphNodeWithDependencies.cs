using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020034CA RID: 13514
[NullableContext(1)]
public interface IGraphNodeWithDependencies : IGraphNode
{
	// Token: 0x170026C3 RID: 9923
	// (get) Token: 0x0601C8EC RID: 116972
	// (set) Token: 0x0601C8ED RID: 116973
	HashSet<string> DependsOn { get; set; }

	// Token: 0x170026C4 RID: 9924
	// (get) Token: 0x0601C8EE RID: 116974
	// (set) Token: 0x0601C8EF RID: 116975
	HashSet<string> DependedOnBy { get; set; }

	// Token: 0x170026C5 RID: 9925
	// (get) Token: 0x0601C8F0 RID: 116976
	// (set) Token: 0x0601C8F1 RID: 116977
	bool Failed { get; set; }
}
