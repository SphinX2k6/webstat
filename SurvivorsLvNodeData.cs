using System;

// Token: 0x02002B69 RID: 11113
public class SurvivorsLvNodeData : ISurvivorsLvNodeData
{
	// Token: 0x17001CD0 RID: 7376
	// (get) Token: 0x0601624A RID: 90698 RVA: 0x006251A6 File Offset: 0x006233A6
	// (set) Token: 0x0601624B RID: 90699 RVA: 0x006251AE File Offset: 0x006233AE
	public int Lv { get; set; }

	// Token: 0x17001CD1 RID: 7377
	// (get) Token: 0x0601624C RID: 90700 RVA: 0x006251B7 File Offset: 0x006233B7
	// (set) Token: 0x0601624D RID: 90701 RVA: 0x006251BF File Offset: 0x006233BF
	public bool IsImportant { get; set; }

	// Token: 0x17001CD2 RID: 7378
	// (get) Token: 0x0601624E RID: 90702 RVA: 0x006251C8 File Offset: 0x006233C8
	// (set) Token: 0x0601624F RID: 90703 RVA: 0x006251D0 File Offset: 0x006233D0
	public ESurvivorsLvState State { get; set; }
}
