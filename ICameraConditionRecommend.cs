using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001328 RID: 4904
[NullableContext(1)]
public interface ICameraConditionRecommend
{
	// Token: 0x17000B6B RID: 2923
	// (get) Token: 0x060085B1 RID: 34225
	// (set) Token: 0x060085B2 RID: 34226
	HashSet<int> FilterIds { get; set; }

	// Token: 0x17000B6C RID: 2924
	// (get) Token: 0x060085B3 RID: 34227
	// (set) Token: 0x060085B4 RID: 34228
	HashSet<int> FrameIds { get; set; }
}
