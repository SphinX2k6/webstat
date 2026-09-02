using System;

// Token: 0x020017D7 RID: 6103
public interface IRefineAttrItemData
{
	// Token: 0x17000E04 RID: 3588
	// (get) Token: 0x0600AD3A RID: 44346
	// (set) Token: 0x0600AD3B RID: 44347
	int PropItemId { get; set; }

	// Token: 0x17000E05 RID: 3589
	// (get) Token: 0x0600AD3C RID: 44348
	// (set) Token: 0x0600AD3D RID: 44349
	int PropIndexId { get; set; }

	// Token: 0x17000E06 RID: 3590
	// (get) Token: 0x0600AD3E RID: 44350
	// (set) Token: 0x0600AD3F RID: 44351
	bool IsRecommend { get; set; }

	// Token: 0x17000E07 RID: 3591
	// (get) Token: 0x0600AD40 RID: 44352
	// (set) Token: 0x0600AD41 RID: 44353
	bool IsDisable { get; set; }
}
