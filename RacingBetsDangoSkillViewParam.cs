using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002736 RID: 10038
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDangoSkillViewParam : IRacingBetsDangoSkillViewParam
{
	// Token: 0x1700195C RID: 6492
	// (get) Token: 0x06013CD4 RID: 81108 RVA: 0x0058310D File Offset: 0x0058130D
	// (set) Token: 0x06013CD5 RID: 81109 RVA: 0x00583115 File Offset: 0x00581315
	public List<RacingBetsDungeonDangoInfo> DangoList { get; set; }

	// Token: 0x1700195D RID: 6493
	// (get) Token: 0x06013CD6 RID: 81110 RVA: 0x0058311E File Offset: 0x0058131E
	// (set) Token: 0x06013CD7 RID: 81111 RVA: 0x00583126 File Offset: 0x00581326
	[Nullable(2)]
	public Action CloseCallback { [NullableContext(2)] get; [NullableContext(2)] set; }
}
