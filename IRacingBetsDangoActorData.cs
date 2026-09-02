using System;
using System.Runtime.CompilerServices;

// Token: 0x02002701 RID: 9985
[NullableContext(1)]
public interface IRacingBetsDangoActorData
{
	// Token: 0x17001912 RID: 6418
	// (get) Token: 0x06013B27 RID: 80679
	// (set) Token: 0x06013B28 RID: 80680
	EUiModelUseWay UiModelUseWay { get; set; }

	// Token: 0x17001913 RID: 6419
	// (get) Token: 0x06013B29 RID: 80681
	// (set) Token: 0x06013B2A RID: 80682
	int DangoId { get; set; }

	// Token: 0x17001914 RID: 6420
	// (get) Token: 0x06013B2B RID: 80683
	// (set) Token: 0x06013B2C RID: 80684
	int Odds { get; set; }

	// Token: 0x17001915 RID: 6421
	// (get) Token: 0x06013B2D RID: 80685
	// (set) Token: 0x06013B2E RID: 80686
	string DangoPointCase { get; set; }

	// Token: 0x17001916 RID: 6422
	// (get) Token: 0x06013B2F RID: 80687
	// (set) Token: 0x06013B30 RID: 80688
	string DangoCamera { get; set; }

	// Token: 0x17001917 RID: 6423
	// (get) Token: 0x06013B31 RID: 80689
	// (set) Token: 0x06013B32 RID: 80690
	float DangoOffset { get; set; }

	// Token: 0x17001918 RID: 6424
	// (get) Token: 0x06013B33 RID: 80691
	// (set) Token: 0x06013B34 RID: 80692
	bool IsAbuDango { get; set; }
}
