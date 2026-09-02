using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x020034C8 RID: 13512
[NullableContext(1)]
[Nullable(0)]
public class GraphNodeImpl : IGraphNode
{
	// Token: 0x170026BF RID: 9919
	// (get) Token: 0x0601C8E3 RID: 116963 RVA: 0x0088FC22 File Offset: 0x0088DE22
	// (set) Token: 0x0601C8E4 RID: 116964 RVA: 0x0088FC2A File Offset: 0x0088DE2A
	public Func<UniTask> Run { get; set; }

	// Token: 0x170026C0 RID: 9920
	// (get) Token: 0x0601C8E5 RID: 116965 RVA: 0x0088FC33 File Offset: 0x0088DE33
	// (set) Token: 0x0601C8E6 RID: 116966 RVA: 0x0088FC3B File Offset: 0x0088DE3B
	public int? Priority { get; set; }
}
