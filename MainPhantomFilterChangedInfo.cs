using System;

// Token: 0x02002501 RID: 9473
public class MainPhantomFilterChangedInfo : IMainPhantomFilterChangedInfo
{
	// Token: 0x17001760 RID: 5984
	// (get) Token: 0x06012648 RID: 75336 RVA: 0x0050E934 File Offset: 0x0050CB34
	// (set) Token: 0x06012649 RID: 75337 RVA: 0x0050E93C File Offset: 0x0050CB3C
	public int MonsterId { get; set; }

	// Token: 0x17001761 RID: 5985
	// (get) Token: 0x0601264A RID: 75338 RVA: 0x0050E945 File Offset: 0x0050CB45
	// (set) Token: 0x0601264B RID: 75339 RVA: 0x0050E94D File Offset: 0x0050CB4D
	public int FetterGroupId { get; set; }

	// Token: 0x17001762 RID: 5986
	// (get) Token: 0x0601264C RID: 75340 RVA: 0x0050E956 File Offset: 0x0050CB56
	// (set) Token: 0x0601264D RID: 75341 RVA: 0x0050E95E File Offset: 0x0050CB5E
	public int Cost { get; set; }

	// Token: 0x17001763 RID: 5987
	// (get) Token: 0x0601264E RID: 75342 RVA: 0x0050E967 File Offset: 0x0050CB67
	// (set) Token: 0x0601264F RID: 75343 RVA: 0x0050E96F File Offset: 0x0050CB6F
	public bool IsDeselect { get; set; }
}
