using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001E10 RID: 7696
[NullableContext(1)]
[Nullable(0)]
public class TrialChallenge : ITrialChallenge
{
	// Token: 0x170011C1 RID: 4545
	// (get) Token: 0x0600E33A RID: 58170 RVA: 0x003D30A2 File Offset: 0x003D12A2
	// (set) Token: 0x0600E33B RID: 58171 RVA: 0x003D30AA File Offset: 0x003D12AA
	public int BoardId { get; set; }

	// Token: 0x170011C2 RID: 4546
	// (get) Token: 0x0600E33C RID: 58172 RVA: 0x003D30B3 File Offset: 0x003D12B3
	// (set) Token: 0x0600E33D RID: 58173 RVA: 0x003D30BB File Offset: 0x003D12BB
	public IReadOnlyList<ITrialSubChallenge> SubChallenges { get; set; }
}
