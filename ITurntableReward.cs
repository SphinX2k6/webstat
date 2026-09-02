using System;

// Token: 0x020015EE RID: 5614
public interface ITurntableReward
{
	// Token: 0x17000D5B RID: 3419
	// (get) Token: 0x06009E4B RID: 40523
	// (set) Token: 0x06009E4C RID: 40524
	int Id { get; set; }

	// Token: 0x17000D5C RID: 3420
	// (get) Token: 0x06009E4D RID: 40525
	// (set) Token: 0x06009E4E RID: 40526
	int RoundId { get; set; }

	// Token: 0x17000D5D RID: 3421
	// (get) Token: 0x06009E4F RID: 40527
	// (set) Token: 0x06009E50 RID: 40528
	bool IsClaimed { get; set; }

	// Token: 0x17000D5E RID: 3422
	// (get) Token: 0x06009E51 RID: 40529
	// (set) Token: 0x06009E52 RID: 40530
	TItem RewardItem { get; set; }

	// Token: 0x17000D5F RID: 3423
	// (get) Token: 0x06009E53 RID: 40531
	// (set) Token: 0x06009E54 RID: 40532
	bool IsSpecial { get; set; }
}
