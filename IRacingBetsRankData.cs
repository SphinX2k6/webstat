using System;
using System.Runtime.CompilerServices;

// Token: 0x02002703 RID: 9987
[NullableContext(1)]
public interface IRacingBetsRankData
{
	// Token: 0x17001920 RID: 6432
	// (get) Token: 0x06013B44 RID: 80708
	// (set) Token: 0x06013B45 RID: 80709
	int PlayerId { get; set; }

	// Token: 0x17001921 RID: 6433
	// (get) Token: 0x06013B46 RID: 80710
	// (set) Token: 0x06013B47 RID: 80711
	int PlayerHeadPhoto { get; set; }

	// Token: 0x17001922 RID: 6434
	// (get) Token: 0x06013B48 RID: 80712
	// (set) Token: 0x06013B49 RID: 80713
	int RankNum { get; set; }

	// Token: 0x17001923 RID: 6435
	// (get) Token: 0x06013B4A RID: 80714
	// (set) Token: 0x06013B4B RID: 80715
	string Name { get; set; }

	// Token: 0x17001924 RID: 6436
	// (get) Token: 0x06013B4C RID: 80716
	// (set) Token: 0x06013B4D RID: 80717
	int HitNum { get; set; }

	// Token: 0x17001925 RID: 6437
	// (get) Token: 0x06013B4E RID: 80718
	// (set) Token: 0x06013B4F RID: 80719
	int CashNum { get; set; }
}
