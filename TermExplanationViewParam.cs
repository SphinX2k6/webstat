using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002BAB RID: 11179
[NullableContext(1)]
[Nullable(0)]
public class TermExplanationViewParam : ITermExplanationViewParam
{
	// Token: 0x17001D4C RID: 7500
	// (get) Token: 0x06016421 RID: 91169 RVA: 0x0062B037 File Offset: 0x00629237
	// (set) Token: 0x06016422 RID: 91170 RVA: 0x0062B03F File Offset: 0x0062923F
	public List<string> HyperLinkList { get; set; } = new List<string>();

	// Token: 0x17001D4D RID: 7501
	// (get) Token: 0x06016423 RID: 91171 RVA: 0x0062B048 File Offset: 0x00629248
	// (set) Token: 0x06016424 RID: 91172 RVA: 0x0062B050 File Offset: 0x00629250
	[Nullable(2)]
	public string FocusedHyperLink { [NullableContext(2)] get; [NullableContext(2)] set; }
}
