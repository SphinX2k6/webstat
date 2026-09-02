using System;

// Token: 0x020015DF RID: 5599
public class TowerGuideRewardItem : ITowerGuideRewardItem
{
	// Token: 0x17000D53 RID: 3411
	// (get) Token: 0x06009D89 RID: 40329 RVA: 0x00293D41 File Offset: 0x00291F41
	// (set) Token: 0x06009D8A RID: 40330 RVA: 0x00293D49 File Offset: 0x00291F49
	public TItem Item { get; set; }

	// Token: 0x17000D54 RID: 3412
	// (get) Token: 0x06009D8B RID: 40331 RVA: 0x00293D52 File Offset: 0x00291F52
	// (set) Token: 0x06009D8C RID: 40332 RVA: 0x00293D5A File Offset: 0x00291F5A
	public bool IsLock { get; set; }

	// Token: 0x17000D55 RID: 3413
	// (get) Token: 0x06009D8D RID: 40333 RVA: 0x00293D63 File Offset: 0x00291F63
	// (set) Token: 0x06009D8E RID: 40334 RVA: 0x00293D6B File Offset: 0x00291F6B
	public bool IsReceivableVisible { get; set; }
}
