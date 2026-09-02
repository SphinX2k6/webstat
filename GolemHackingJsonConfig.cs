using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020010B0 RID: 4272
[NullableContext(1)]
[Nullable(0)]
public class GolemHackingJsonConfig
{
	// Token: 0x17000908 RID: 2312
	// (get) Token: 0x06006F5C RID: 28508 RVA: 0x001CFA52 File Offset: 0x001CDC52
	// (set) Token: 0x06006F5D RID: 28509 RVA: 0x001CFA5A File Offset: 0x001CDC5A
	public int MatrixSize { get; set; }

	// Token: 0x17000909 RID: 2313
	// (get) Token: 0x06006F5E RID: 28510 RVA: 0x001CFA63 File Offset: 0x001CDC63
	// (set) Token: 0x06006F5F RID: 28511 RVA: 0x001CFA6B File Offset: 0x001CDC6B
	public List<GolemHackingGridJsonConfig> PresetCodes { get; set; }
}
