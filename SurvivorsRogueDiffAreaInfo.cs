using System;

// Token: 0x02002B4F RID: 11087
public class SurvivorsRogueDiffAreaInfo : IDiffAreaInfo
{
	// Token: 0x17001CC9 RID: 7369
	// (get) Token: 0x060161A1 RID: 90529 RVA: 0x00621E28 File Offset: 0x00620028
	// (set) Token: 0x060161A2 RID: 90530 RVA: 0x00621E30 File Offset: 0x00620030
	public ESurvivorsLevelDiff Diff { get; set; }

	// Token: 0x17001CCA RID: 7370
	// (get) Token: 0x060161A3 RID: 90531 RVA: 0x00621E39 File Offset: 0x00620039
	// (set) Token: 0x060161A4 RID: 90532 RVA: 0x00621E41 File Offset: 0x00620041
	public int LowerBoundLevelId { get; set; }

	// Token: 0x17001CCB RID: 7371
	// (get) Token: 0x060161A5 RID: 90533 RVA: 0x00621E4A File Offset: 0x0062004A
	// (set) Token: 0x060161A6 RID: 90534 RVA: 0x00621E52 File Offset: 0x00620052
	public float LowerBoundPosY { get; set; }
}
