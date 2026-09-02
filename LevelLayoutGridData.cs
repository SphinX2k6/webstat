using System;

// Token: 0x02002882 RID: 10370
public class LevelLayoutGridData : ILevelLayoutGridData
{
	// Token: 0x17001AC1 RID: 6849
	// (get) Token: 0x0601486C RID: 84076 RVA: 0x005B1D5D File Offset: 0x005AFF5D
	// (set) Token: 0x0601486D RID: 84077 RVA: 0x005B1D65 File Offset: 0x005AFF65
	public bool IsChosen { get; set; }

	// Token: 0x17001AC2 RID: 6850
	// (get) Token: 0x0601486E RID: 84078 RVA: 0x005B1D6E File Offset: 0x005AFF6E
	// (set) Token: 0x0601486F RID: 84079 RVA: 0x005B1D76 File Offset: 0x005AFF76
	public bool IsAvailable { get; set; }

	// Token: 0x17001AC3 RID: 6851
	// (get) Token: 0x06014870 RID: 84080 RVA: 0x005B1D7F File Offset: 0x005AFF7F
	// (set) Token: 0x06014871 RID: 84081 RVA: 0x005B1D87 File Offset: 0x005AFF87
	public int LevelContent { get; set; }
}
