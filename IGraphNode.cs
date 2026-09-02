using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x020034C7 RID: 13511
[NullableContext(1)]
public interface IGraphNode
{
	// Token: 0x170026BD RID: 9917
	// (get) Token: 0x0601C8DF RID: 116959
	// (set) Token: 0x0601C8E0 RID: 116960
	Func<UniTask> Run { get; set; }

	// Token: 0x170026BE RID: 9918
	// (get) Token: 0x0601C8E1 RID: 116961
	// (set) Token: 0x0601C8E2 RID: 116962
	int? Priority { get; set; }
}
