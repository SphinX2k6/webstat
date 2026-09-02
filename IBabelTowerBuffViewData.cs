using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011FB RID: 4603
[NullableContext(1)]
public interface IBabelTowerBuffViewData
{
	// Token: 0x17000A91 RID: 2705
	// (get) Token: 0x06007A01 RID: 31233
	// (set) Token: 0x06007A02 RID: 31234
	List<IBabelTowerBuffItemData> BuffDataList { get; set; }

	// Token: 0x17000A92 RID: 2706
	// (get) Token: 0x06007A03 RID: 31235
	// (set) Token: 0x06007A04 RID: 31236
	List<IBabelTowerBuffItemData> DeTermDataList { get; set; }
}
