using System;

// Token: 0x02002079 RID: 8313
public class CostData : ICostData
{
	// Token: 0x170012DD RID: 4829
	// (get) Token: 0x0600FD53 RID: 64851 RVA: 0x0045798E File Offset: 0x00455B8E
	// (set) Token: 0x0600FD54 RID: 64852 RVA: 0x00457996 File Offset: 0x00455B96
	public int ItemId { get; set; }

	// Token: 0x170012DE RID: 4830
	// (get) Token: 0x0600FD55 RID: 64853 RVA: 0x0045799F File Offset: 0x00455B9F
	// (set) Token: 0x0600FD56 RID: 64854 RVA: 0x004579A7 File Offset: 0x00455BA7
	public int Count { get; set; }

	// Token: 0x170012DF RID: 4831
	// (get) Token: 0x0600FD57 RID: 64855 RVA: 0x004579B0 File Offset: 0x00455BB0
	// (set) Token: 0x0600FD58 RID: 64856 RVA: 0x004579B8 File Offset: 0x00455BB8
	public int Cost { get; set; }
}
