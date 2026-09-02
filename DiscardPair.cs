using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001EF6 RID: 7926
[NullableContext(1)]
[Nullable(0)]
public class DiscardPair : IDiscardPair
{
	// Token: 0x17001220 RID: 4640
	// (get) Token: 0x0600EBF8 RID: 60408 RVA: 0x00402672 File Offset: 0x00400872
	// (set) Token: 0x0600EBF9 RID: 60409 RVA: 0x0040267A File Offset: 0x0040087A
	public UUIItem NotActive { get; set; }

	// Token: 0x17001221 RID: 4641
	// (get) Token: 0x0600EBFA RID: 60410 RVA: 0x00402683 File Offset: 0x00400883
	// (set) Token: 0x0600EBFB RID: 60411 RVA: 0x0040268B File Offset: 0x0040088B
	public UUIItem Active { get; set; }
}
