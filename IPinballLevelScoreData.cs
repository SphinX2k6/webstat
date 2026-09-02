using System;

// Token: 0x020014A6 RID: 5286
public interface IPinballLevelScoreData
{
	// Token: 0x17000C44 RID: 3140
	// (get) Token: 0x0600940B RID: 37899
	// (set) Token: 0x0600940C RID: 37900
	int CurScore { get; set; }

	// Token: 0x17000C45 RID: 3141
	// (get) Token: 0x0600940D RID: 37901
	// (set) Token: 0x0600940E RID: 37902
	int ConfigScore { get; set; }

	// Token: 0x17000C46 RID: 3142
	// (get) Token: 0x0600940F RID: 37903
	// (set) Token: 0x06009410 RID: 37904
	int ConfigDropId { get; set; }
}
