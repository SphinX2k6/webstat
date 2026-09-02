using System;

// Token: 0x02001301 RID: 4865
public interface IDangoMonopolyRoundRewardItemData
{
	// Token: 0x17000B1B RID: 2843
	// (get) Token: 0x06008444 RID: 33860
	bool IsReceived { get; }

	// Token: 0x17000B1C RID: 2844
	// (get) Token: 0x06008445 RID: 33861
	bool IsCanReceived { get; }

	// Token: 0x17000B1D RID: 2845
	// (get) Token: 0x06008446 RID: 33862
	int ItemId { get; }

	// Token: 0x17000B1E RID: 2846
	// (get) Token: 0x06008447 RID: 33863
	int Count { get; }

	// Token: 0x17000B1F RID: 2847
	// (get) Token: 0x06008448 RID: 33864
	int BoardId { get; }

	// Token: 0x17000B20 RID: 2848
	// (get) Token: 0x06008449 RID: 33865
	bool IsCurrent { get; }

	// Token: 0x17000B21 RID: 2849
	// (get) Token: 0x0600844A RID: 33866
	int Position { get; }
}
