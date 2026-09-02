using System;

// Token: 0x02002707 RID: 9991
public interface IDangoMatchRoleData
{
	// Token: 0x17001938 RID: 6456
	// (get) Token: 0x06013B76 RID: 80758
	// (set) Token: 0x06013B77 RID: 80759
	int GroupMatchId { get; set; }

	// Token: 0x17001939 RID: 6457
	// (get) Token: 0x06013B78 RID: 80760
	// (set) Token: 0x06013B79 RID: 80761
	int DangoId { get; set; }

	// Token: 0x1700193A RID: 6458
	// (get) Token: 0x06013B7A RID: 80762
	// (set) Token: 0x06013B7B RID: 80763
	bool IsMatchFinished { get; set; }

	// Token: 0x1700193B RID: 6459
	// (get) Token: 0x06013B7C RID: 80764
	// (set) Token: 0x06013B7D RID: 80765
	bool IsPromote { get; set; }

	// Token: 0x1700193C RID: 6460
	// (get) Token: 0x06013B7E RID: 80766
	// (set) Token: 0x06013B7F RID: 80767
	bool IsBasicGroupMatch { get; set; }
}
