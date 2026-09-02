using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002321 RID: 8993
[NullableContext(1)]
[Nullable(0)]
public class MusicSortViewOpenParams : IMusicSortViewOpenParams
{
	// Token: 0x1700152E RID: 5422
	// (get) Token: 0x060111C4 RID: 70084 RVA: 0x004B3A42 File Offset: 0x004B1C42
	// (set) Token: 0x060111C5 RID: 70085 RVA: 0x004B3A4A File Offset: 0x004B1C4A
	public IReadOnlyList<int> MusicList { get; set; } = new List<int>();

	// Token: 0x1700152F RID: 5423
	// (get) Token: 0x060111C6 RID: 70086 RVA: 0x004B3A53 File Offset: 0x004B1C53
	// (set) Token: 0x060111C7 RID: 70087 RVA: 0x004B3A5B File Offset: 0x004B1C5B
	public Action<List<int>> OnCallback { get; set; }
}
