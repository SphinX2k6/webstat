using System;
using System.Runtime.CompilerServices;

// Token: 0x020034D9 RID: 13529
[NullableContext(1)]
[Nullable(0)]
public class GraphNodeWithCyclicDependency : IGraphNodeWithCyclicDependency
{
	// Token: 0x170026DD RID: 9949
	// (get) Token: 0x0601C947 RID: 117063 RVA: 0x008915A0 File Offset: 0x0088F7A0
	// (set) Token: 0x0601C948 RID: 117064 RVA: 0x008915A8 File Offset: 0x0088F7A8
	public bool HasCycle { get; set; }

	// Token: 0x170026DE RID: 9950
	// (get) Token: 0x0601C949 RID: 117065 RVA: 0x008915B1 File Offset: 0x0088F7B1
	// (set) Token: 0x0601C94A RID: 117066 RVA: 0x008915B9 File Offset: 0x0088F7B9
	public string[] Cycle { get; set; } = new string[0];
}
