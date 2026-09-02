using System;

// Token: 0x02002724 RID: 10020
public interface IRacingBetsMatchTableDangoItemData
{
	// Token: 0x1700194E RID: 6478
	// (get) Token: 0x06013C2C RID: 80940
	// (set) Token: 0x06013C2D RID: 80941
	int DangoId { get; set; }

	// Token: 0x1700194F RID: 6479
	// (get) Token: 0x06013C2E RID: 80942
	// (set) Token: 0x06013C2F RID: 80943
	bool IsNeedCheer { get; set; }

	// Token: 0x17001950 RID: 6480
	// (get) Token: 0x06013C30 RID: 80944
	// (set) Token: 0x06013C31 RID: 80945
	bool IsMatchFinished { get; set; }

	// Token: 0x17001951 RID: 6481
	// (get) Token: 0x06013C32 RID: 80946
	// (set) Token: 0x06013C33 RID: 80947
	bool IsPromote { get; set; }

	// Token: 0x17001952 RID: 6482
	// (get) Token: 0x06013C34 RID: 80948
	// (set) Token: 0x06013C35 RID: 80949
	bool IsNeedPlayLevelSequence { get; set; }

	// Token: 0x17001953 RID: 6483
	// (get) Token: 0x06013C36 RID: 80950
	// (set) Token: 0x06013C37 RID: 80951
	bool IsCurMatch { get; set; }
}
