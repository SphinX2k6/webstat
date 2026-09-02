using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002735 RID: 10037
[NullableContext(1)]
public interface IRacingBetsDangoSkillViewParam
{
	// Token: 0x1700195A RID: 6490
	// (get) Token: 0x06013CD0 RID: 81104
	// (set) Token: 0x06013CD1 RID: 81105
	List<RacingBetsDungeonDangoInfo> DangoList { get; set; }

	// Token: 0x1700195B RID: 6491
	// (get) Token: 0x06013CD2 RID: 81106
	// (set) Token: 0x06013CD3 RID: 81107
	[Nullable(2)]
	Action CloseCallback { [NullableContext(2)] get; [NullableContext(2)] set; }
}
