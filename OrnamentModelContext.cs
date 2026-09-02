using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002C6D RID: 11373
[NullableContext(1)]
[Nullable(0)]
public class OrnamentModelContext : IOrnamentModelContext
{
	// Token: 0x17001DE0 RID: 7648
	// (get) Token: 0x06016CFE RID: 93438 RVA: 0x00654C72 File Offset: 0x00652E72
	// (set) Token: 0x06016CFF RID: 93439 RVA: 0x00654C7A File Offset: 0x00652E7A
	public int ModelId { get; set; }

	// Token: 0x17001DE1 RID: 7649
	// (get) Token: 0x06016D00 RID: 93440 RVA: 0x00654C83 File Offset: 0x00652E83
	// (set) Token: 0x06016D01 RID: 93441 RVA: 0x00654C8B File Offset: 0x00652E8B
	public bool HideInUi { get; set; }

	// Token: 0x17001DE2 RID: 7650
	// (get) Token: 0x06016D02 RID: 93442 RVA: 0x00654C94 File Offset: 0x00652E94
	// (set) Token: 0x06016D03 RID: 93443 RVA: 0x00654C9C File Offset: 0x00652E9C
	public List<long> OrnamentUiBuff { get; set; }
}
