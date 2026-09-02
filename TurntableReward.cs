using System;

// Token: 0x020015EF RID: 5615
public class TurntableReward : ITurntableReward
{
	// Token: 0x17000D60 RID: 3424
	// (get) Token: 0x06009E55 RID: 40533 RVA: 0x00297319 File Offset: 0x00295519
	// (set) Token: 0x06009E56 RID: 40534 RVA: 0x00297321 File Offset: 0x00295521
	public int Id { get; set; }

	// Token: 0x17000D61 RID: 3425
	// (get) Token: 0x06009E57 RID: 40535 RVA: 0x0029732A File Offset: 0x0029552A
	// (set) Token: 0x06009E58 RID: 40536 RVA: 0x00297332 File Offset: 0x00295532
	public int RoundId { get; set; }

	// Token: 0x17000D62 RID: 3426
	// (get) Token: 0x06009E59 RID: 40537 RVA: 0x0029733B File Offset: 0x0029553B
	// (set) Token: 0x06009E5A RID: 40538 RVA: 0x00297343 File Offset: 0x00295543
	public bool IsClaimed { get; set; }

	// Token: 0x17000D63 RID: 3427
	// (get) Token: 0x06009E5B RID: 40539 RVA: 0x0029734C File Offset: 0x0029554C
	// (set) Token: 0x06009E5C RID: 40540 RVA: 0x00297354 File Offset: 0x00295554
	public TItem RewardItem { get; set; }

	// Token: 0x17000D64 RID: 3428
	// (get) Token: 0x06009E5D RID: 40541 RVA: 0x0029735D File Offset: 0x0029555D
	// (set) Token: 0x06009E5E RID: 40542 RVA: 0x00297365 File Offset: 0x00295565
	public bool IsSpecial { get; set; }
}
