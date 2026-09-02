using System;
using System.Runtime.CompilerServices;

// Token: 0x02001716 RID: 5910
[NullableContext(2)]
[Nullable(0)]
public class WuWuLogisticsInfoItemData : IWuWuLogisticsInfoItemData
{
	// Token: 0x17000D9E RID: 3486
	// (get) Token: 0x0600A449 RID: 42057 RVA: 0x002B6DC2 File Offset: 0x002B4FC2
	// (set) Token: 0x0600A44A RID: 42058 RVA: 0x002B6DCA File Offset: 0x002B4FCA
	public int CfgId { get; set; }

	// Token: 0x17000D9F RID: 3487
	// (get) Token: 0x0600A44B RID: 42059 RVA: 0x002B6DD3 File Offset: 0x002B4FD3
	// (set) Token: 0x0600A44C RID: 42060 RVA: 0x002B6DDB File Offset: 0x002B4FDB
	public bool IsToday { get; set; }

	// Token: 0x17000DA0 RID: 3488
	// (get) Token: 0x0600A44D RID: 42061 RVA: 0x002B6DE4 File Offset: 0x002B4FE4
	// (set) Token: 0x0600A44E RID: 42062 RVA: 0x002B6DEC File Offset: 0x002B4FEC
	public string Content { get; set; }
}
