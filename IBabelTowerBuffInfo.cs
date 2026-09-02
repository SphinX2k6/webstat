using System;

// Token: 0x020011EA RID: 4586
public interface IBabelTowerBuffInfo
{
	// Token: 0x17000A3B RID: 2619
	// (get) Token: 0x0600794C RID: 31052
	// (set) Token: 0x0600794D RID: 31053
	int Id { get; set; }

	// Token: 0x17000A3C RID: 2620
	// (get) Token: 0x0600794E RID: 31054
	// (set) Token: 0x0600794F RID: 31055
	EBabelTowerBuffState State { get; set; }

	// Token: 0x17000A3D RID: 2621
	// (get) Token: 0x06007950 RID: 31056
	// (set) Token: 0x06007951 RID: 31057
	int? LevelId { get; set; }

	// Token: 0x17000A3E RID: 2622
	// (get) Token: 0x06007952 RID: 31058
	// (set) Token: 0x06007953 RID: 31059
	bool IsRecommend { get; set; }
}
