using System;

// Token: 0x020020C7 RID: 8391
public class LevelUpViewViedData : ILevelUpViewViedData
{
	// Token: 0x17001344 RID: 4932
	// (get) Token: 0x0601007D RID: 65661 RVA: 0x004671BA File Offset: 0x004653BA
	// (set) Token: 0x0601007E RID: 65662 RVA: 0x004671C2 File Offset: 0x004653C2
	public bool AddExp { get; set; }

	// Token: 0x17001345 RID: 4933
	// (get) Token: 0x0601007F RID: 65663 RVA: 0x004671CB File Offset: 0x004653CB
	// (set) Token: 0x06010080 RID: 65664 RVA: 0x004671D3 File Offset: 0x004653D3
	public int PreLevel { get; set; }

	// Token: 0x17001346 RID: 4934
	// (get) Token: 0x06010081 RID: 65665 RVA: 0x004671DC File Offset: 0x004653DC
	// (set) Token: 0x06010082 RID: 65666 RVA: 0x004671E4 File Offset: 0x004653E4
	public int PreExp { get; set; }

	// Token: 0x17001347 RID: 4935
	// (get) Token: 0x06010083 RID: 65667 RVA: 0x004671ED File Offset: 0x004653ED
	// (set) Token: 0x06010084 RID: 65668 RVA: 0x004671F5 File Offset: 0x004653F5
	public int CurLevel { get; set; }

	// Token: 0x17001348 RID: 4936
	// (get) Token: 0x06010085 RID: 65669 RVA: 0x004671FE File Offset: 0x004653FE
	// (set) Token: 0x06010086 RID: 65670 RVA: 0x00467206 File Offset: 0x00465406
	public int CurExp { get; set; }
}
