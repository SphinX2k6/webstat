using System;

// Token: 0x020015DE RID: 5598
public interface ITowerGuideRewardItem
{
	// Token: 0x17000D50 RID: 3408
	// (get) Token: 0x06009D83 RID: 40323
	// (set) Token: 0x06009D84 RID: 40324
	TItem Item { get; set; }

	// Token: 0x17000D51 RID: 3409
	// (get) Token: 0x06009D85 RID: 40325
	// (set) Token: 0x06009D86 RID: 40326
	bool IsLock { get; set; }

	// Token: 0x17000D52 RID: 3410
	// (get) Token: 0x06009D87 RID: 40327
	// (set) Token: 0x06009D88 RID: 40328
	bool IsReceivableVisible { get; set; }
}
