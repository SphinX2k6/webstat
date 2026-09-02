using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020034D4 RID: 13524
[NullableContext(1)]
[Nullable(0)]
public class GraphNodeInfo
{
	// Token: 0x170026D5 RID: 9941
	// (get) Token: 0x0601C91D RID: 117021 RVA: 0x008901A9 File Offset: 0x0088E3A9
	// (set) Token: 0x0601C91E RID: 117022 RVA: 0x008901B1 File Offset: 0x0088E3B1
	public List<string> Parents { get; set; } = new List<string>();

	// Token: 0x170026D6 RID: 9942
	// (get) Token: 0x0601C91F RID: 117023 RVA: 0x008901BA File Offset: 0x0088E3BA
	// (set) Token: 0x0601C920 RID: 117024 RVA: 0x008901C2 File Offset: 0x0088E3C2
	public List<string> Children { get; set; } = new List<string>();
}
