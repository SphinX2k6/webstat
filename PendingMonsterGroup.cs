using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

// Token: 0x02003177 RID: 12663
[NullableContext(1)]
[Nullable(0)]
public class PendingMonsterGroup : IPendingMonsterGroup
{
	// Token: 0x170023B3 RID: 9139
	// (get) Token: 0x0601A3DD RID: 107485 RVA: 0x007B6BA4 File Offset: 0x007B4DA4
	// (set) Token: 0x0601A3DE RID: 107486 RVA: 0x007B6BAC File Offset: 0x007B4DAC
	[Nullable(2)]
	public GroupAiComponent GroupComp { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170023B4 RID: 9140
	// (get) Token: 0x0601A3DF RID: 107487 RVA: 0x007B6BB5 File Offset: 0x007B4DB5
	// (set) Token: 0x0601A3E0 RID: 107488 RVA: 0x007B6BBD File Offset: 0x007B4DBD
	public HashSet<int> RegisteredPbDataIds { get; set; } = new HashSet<int>();
}
