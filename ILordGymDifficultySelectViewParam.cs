using System;

// Token: 0x02002202 RID: 8706
public interface ILordGymDifficultySelectViewParam
{
	// Token: 0x1700144C RID: 5196
	// (get) Token: 0x060106E0 RID: 67296
	// (set) Token: 0x060106E1 RID: 67297
	int LordEntranceSetId { get; set; }

	// Token: 0x1700144D RID: 5197
	// (get) Token: 0x060106E2 RID: 67298
	// (set) Token: 0x060106E3 RID: 67299
	int LordEntranceId { get; set; }

	// Token: 0x1700144E RID: 5198
	// (get) Token: 0x060106E4 RID: 67300
	// (set) Token: 0x060106E5 RID: 67301
	bool IsPlaySpecialSequence { get; set; }

	// Token: 0x1700144F RID: 5199
	// (get) Token: 0x060106E6 RID: 67302
	// (set) Token: 0x060106E7 RID: 67303
	int DefaultLordId { get; set; }
}
