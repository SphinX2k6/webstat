using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200319E RID: 12702
[NullableContext(1)]
[Nullable(0)]
public class NpcInterestLookAtParamGroupImpl : INpcInterestLookAtParamGroup
{
	// Token: 0x170023D7 RID: 9175
	// (get) Token: 0x0601A598 RID: 107928 RVA: 0x007C3811 File Offset: 0x007C1A11
	// (set) Token: 0x0601A599 RID: 107929 RVA: 0x007C3819 File Offset: 0x007C1A19
	public string Key { get; set; }

	// Token: 0x170023D8 RID: 9176
	// (get) Token: 0x0601A59A RID: 107930 RVA: 0x007C3822 File Offset: 0x007C1A22
	// (set) Token: 0x0601A59B RID: 107931 RVA: 0x007C382A File Offset: 0x007C1A2A
	public IList<int> PbDataIds { get; set; }

	// Token: 0x170023D9 RID: 9177
	// (get) Token: 0x0601A59C RID: 107932 RVA: 0x007C3833 File Offset: 0x007C1A33
	// (set) Token: 0x0601A59D RID: 107933 RVA: 0x007C383B File Offset: 0x007C1A3B
	public IList<INpcInterestLookAtParam> Params { get; set; }
}
