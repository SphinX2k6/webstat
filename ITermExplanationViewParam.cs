using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002BAA RID: 11178
[NullableContext(1)]
public interface ITermExplanationViewParam
{
	// Token: 0x17001D4A RID: 7498
	// (get) Token: 0x0601641D RID: 91165
	// (set) Token: 0x0601641E RID: 91166
	List<string> HyperLinkList { get; set; }

	// Token: 0x17001D4B RID: 7499
	// (get) Token: 0x0601641F RID: 91167
	// (set) Token: 0x06016420 RID: 91168
	[Nullable(2)]
	string FocusedHyperLink { [NullableContext(2)] get; [NullableContext(2)] set; }
}
