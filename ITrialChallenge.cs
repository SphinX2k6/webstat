using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001E0F RID: 7695
[NullableContext(1)]
public interface ITrialChallenge
{
	// Token: 0x170011BF RID: 4543
	// (get) Token: 0x0600E336 RID: 58166
	// (set) Token: 0x0600E337 RID: 58167
	int BoardId { get; set; }

	// Token: 0x170011C0 RID: 4544
	// (get) Token: 0x0600E338 RID: 58168
	// (set) Token: 0x0600E339 RID: 58169
	IReadOnlyList<ITrialSubChallenge> SubChallenges { get; set; }
}
