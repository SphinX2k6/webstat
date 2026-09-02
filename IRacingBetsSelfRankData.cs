using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002705 RID: 9989
[NullableContext(1)]
public interface IRacingBetsSelfRankData
{
	// Token: 0x1700192C RID: 6444
	// (get) Token: 0x06013B5D RID: 80733
	// (set) Token: 0x06013B5E RID: 80734
	RacingBetsRankStatus RankStatus { get; set; }

	// Token: 0x1700192D RID: 6445
	// (get) Token: 0x06013B5F RID: 80735
	// (set) Token: 0x06013B60 RID: 80736
	int RankNum { get; set; }

	// Token: 0x1700192E RID: 6446
	// (get) Token: 0x06013B61 RID: 80737
	// (set) Token: 0x06013B62 RID: 80738
	int HeadIcon { get; set; }

	// Token: 0x1700192F RID: 6447
	// (get) Token: 0x06013B63 RID: 80739
	// (set) Token: 0x06013B64 RID: 80740
	string Name { get; set; }

	// Token: 0x17001930 RID: 6448
	// (get) Token: 0x06013B65 RID: 80741
	// (set) Token: 0x06013B66 RID: 80742
	int HitNum { get; set; }

	// Token: 0x17001931 RID: 6449
	// (get) Token: 0x06013B67 RID: 80743
	// (set) Token: 0x06013B68 RID: 80744
	int CashNum { get; set; }
}
