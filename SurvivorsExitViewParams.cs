using System;

// Token: 0x02002B7B RID: 11131
public class SurvivorsExitViewParams : ISurvivorsExitViewParams
{
	// Token: 0x17001CDD RID: 7389
	// (get) Token: 0x0601629D RID: 90781 RVA: 0x0062683B File Offset: 0x00624A3B
	// (set) Token: 0x0601629E RID: 90782 RVA: 0x00626843 File Offset: 0x00624A43
	public bool IsExternal { get; set; }

	// Token: 0x17001CDE RID: 7390
	// (get) Token: 0x0601629F RID: 90783 RVA: 0x0062684C File Offset: 0x00624A4C
	// (set) Token: 0x060162A0 RID: 90784 RVA: 0x00626854 File Offset: 0x00624A54
	public int Batch { get; set; }

	// Token: 0x17001CDF RID: 7391
	// (get) Token: 0x060162A1 RID: 90785 RVA: 0x0062685D File Offset: 0x00624A5D
	// (set) Token: 0x060162A2 RID: 90786 RVA: 0x00626865 File Offset: 0x00624A65
	public int MaxBatch { get; set; }
}
