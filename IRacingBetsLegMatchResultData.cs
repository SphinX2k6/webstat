using System;
using System.Runtime.CompilerServices;

// Token: 0x020026FC RID: 9980
[NullableContext(1)]
public interface IRacingBetsLegMatchResultData
{
	// Token: 0x170018FC RID: 6396
	// (get) Token: 0x06013AF9 RID: 80633
	// (set) Token: 0x06013AFA RID: 80634
	int DangoId { get; set; }

	// Token: 0x170018FD RID: 6397
	// (get) Token: 0x06013AFB RID: 80635
	// (set) Token: 0x06013AFC RID: 80636
	int Rank { get; set; }

	// Token: 0x170018FE RID: 6398
	// (get) Token: 0x06013AFD RID: 80637
	// (set) Token: 0x06013AFE RID: 80638
	bool HasAdvanced { get; set; }

	// Token: 0x170018FF RID: 6399
	// (get) Token: 0x06013AFF RID: 80639
	// (set) Token: 0x06013B00 RID: 80640
	ERacingBetsLegMatchType LegMatchType { get; set; }

	// Token: 0x17001900 RID: 6400
	// (get) Token: 0x06013B01 RID: 80641
	// (set) Token: 0x06013B02 RID: 80642
	bool IsChampion { get; set; }

	// Token: 0x17001901 RID: 6401
	// (get) Token: 0x06013B03 RID: 80643
	// (set) Token: 0x06013B04 RID: 80644
	ERacingBetsLegMatchResultType ResultShowType { get; set; }

	// Token: 0x17001902 RID: 6402
	// (get) Token: 0x06013B05 RID: 80645
	// (set) Token: 0x06013B06 RID: 80646
	string AdvancedNextMatchName { get; set; }

	// Token: 0x17001903 RID: 6403
	// (get) Token: 0x06013B07 RID: 80647
	// (set) Token: 0x06013B08 RID: 80648
	string LoserNextMatchName { get; set; }
}
