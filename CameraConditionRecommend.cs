using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001329 RID: 4905
[NullableContext(1)]
[Nullable(0)]
public class CameraConditionRecommend : ICameraConditionRecommend
{
	// Token: 0x17000B6D RID: 2925
	// (get) Token: 0x060085B5 RID: 34229 RVA: 0x00233119 File Offset: 0x00231319
	// (set) Token: 0x060085B6 RID: 34230 RVA: 0x00233121 File Offset: 0x00231321
	public HashSet<int> FilterIds { get; set; }

	// Token: 0x17000B6E RID: 2926
	// (get) Token: 0x060085B7 RID: 34231 RVA: 0x0023312A File Offset: 0x0023132A
	// (set) Token: 0x060085B8 RID: 34232 RVA: 0x00233132 File Offset: 0x00231332
	public HashSet<int> FrameIds { get; set; }
}
