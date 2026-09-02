using System;

// Token: 0x020017D8 RID: 6104
public class RefineAttrItemData : IRefineAttrItemData
{
	// Token: 0x17000E08 RID: 3592
	// (get) Token: 0x0600AD42 RID: 44354 RVA: 0x002E3015 File Offset: 0x002E1215
	// (set) Token: 0x0600AD43 RID: 44355 RVA: 0x002E301D File Offset: 0x002E121D
	public int PropItemId { get; set; }

	// Token: 0x17000E09 RID: 3593
	// (get) Token: 0x0600AD44 RID: 44356 RVA: 0x002E3026 File Offset: 0x002E1226
	// (set) Token: 0x0600AD45 RID: 44357 RVA: 0x002E302E File Offset: 0x002E122E
	public int PropIndexId { get; set; }

	// Token: 0x17000E0A RID: 3594
	// (get) Token: 0x0600AD46 RID: 44358 RVA: 0x002E3037 File Offset: 0x002E1237
	// (set) Token: 0x0600AD47 RID: 44359 RVA: 0x002E303F File Offset: 0x002E123F
	public bool IsRecommend { get; set; }

	// Token: 0x17000E0B RID: 3595
	// (get) Token: 0x0600AD48 RID: 44360 RVA: 0x002E3048 File Offset: 0x002E1248
	// (set) Token: 0x0600AD49 RID: 44361 RVA: 0x002E3050 File Offset: 0x002E1250
	public bool IsDisable { get; set; }
}
