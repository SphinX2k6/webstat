using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011F4 RID: 4596
[NullableContext(1)]
public interface IBabelTowerMutexGroupData
{
	// Token: 0x17000A6D RID: 2669
	// (get) Token: 0x060079B5 RID: 31157
	// (set) Token: 0x060079B6 RID: 31158
	int MutexId { get; set; }

	// Token: 0x17000A6E RID: 2670
	// (get) Token: 0x060079B7 RID: 31159
	// (set) Token: 0x060079B8 RID: 31160
	int GroupId { get; set; }

	// Token: 0x17000A6F RID: 2671
	// (get) Token: 0x060079B9 RID: 31161
	// (set) Token: 0x060079BA RID: 31162
	List<int> DeTermList { get; set; }

	// Token: 0x17000A70 RID: 2672
	// (get) Token: 0x060079BB RID: 31163
	// (set) Token: 0x060079BC RID: 31164
	bool? IsNecessary { get; set; }

	// Token: 0x17000A71 RID: 2673
	// (get) Token: 0x060079BD RID: 31165
	// (set) Token: 0x060079BE RID: 31166
	int? CurrentDeTermId { get; set; }
}
