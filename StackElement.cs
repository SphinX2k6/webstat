using System;
using System.Runtime.CompilerServices;

// Token: 0x020034DB RID: 13531
[NullableContext(1)]
[Nullable(0)]
public class StackElement : IStackElement
{
	// Token: 0x170026E0 RID: 9952
	// (get) Token: 0x0601C94F RID: 117071 RVA: 0x008915EF File Offset: 0x0088F7EF
	// (set) Token: 0x0601C950 RID: 117072 RVA: 0x008915F7 File Offset: 0x0088F7F7
	public string Node { get; set; } = "";

	// Token: 0x170026E1 RID: 9953
	// (get) Token: 0x0601C951 RID: 117073 RVA: 0x00891600 File Offset: 0x0088F800
	// (set) Token: 0x0601C952 RID: 117074 RVA: 0x00891608 File Offset: 0x0088F808
	public bool Traversing { get; set; }
}
