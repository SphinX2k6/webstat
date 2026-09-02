using System;

// Token: 0x02002B4E RID: 11086
internal interface IDiffAreaInfo
{
	// Token: 0x17001CC6 RID: 7366
	// (get) Token: 0x0601619B RID: 90523
	// (set) Token: 0x0601619C RID: 90524
	ESurvivorsLevelDiff Diff { get; set; }

	// Token: 0x17001CC7 RID: 7367
	// (get) Token: 0x0601619D RID: 90525
	// (set) Token: 0x0601619E RID: 90526
	int LowerBoundLevelId { get; set; }

	// Token: 0x17001CC8 RID: 7368
	// (get) Token: 0x0601619F RID: 90527
	// (set) Token: 0x060161A0 RID: 90528
	float LowerBoundPosY { get; set; }
}
