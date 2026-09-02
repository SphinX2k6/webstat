using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

// Token: 0x02003176 RID: 12662
[NullableContext(1)]
public interface IPendingMonsterGroup
{
	// Token: 0x170023B1 RID: 9137
	// (get) Token: 0x0601A3D9 RID: 107481
	// (set) Token: 0x0601A3DA RID: 107482
	[Nullable(2)]
	GroupAiComponent GroupComp { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170023B2 RID: 9138
	// (get) Token: 0x0601A3DB RID: 107483
	// (set) Token: 0x0601A3DC RID: 107484
	HashSet<int> RegisteredPbDataIds { get; set; }
}
