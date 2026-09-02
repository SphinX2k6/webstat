using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002322 RID: 8994
[NullableContext(1)]
public interface IMusicSortViewOpenParams
{
	// Token: 0x17001530 RID: 5424
	// (get) Token: 0x060111C9 RID: 70089
	// (set) Token: 0x060111CA RID: 70090
	IReadOnlyList<int> MusicList { get; set; }

	// Token: 0x17001531 RID: 5425
	// (get) Token: 0x060111CB RID: 70091
	// (set) Token: 0x060111CC RID: 70092
	Action<List<int>> OnCallback { get; set; }
}
