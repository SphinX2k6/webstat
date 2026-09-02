using System;

// Token: 0x020020A8 RID: 8360
public class KingShipResultViewData : IKingShipResultViewData
{
	// Token: 0x17001309 RID: 4873
	// (get) Token: 0x0600FF49 RID: 65353 RVA: 0x004619FA File Offset: 0x0045FBFA
	// (set) Token: 0x0600FF4A RID: 65354 RVA: 0x00461A02 File Offset: 0x0045FC02
	public int CardId { get; set; }

	// Token: 0x1700130A RID: 4874
	// (get) Token: 0x0600FF4B RID: 65355 RVA: 0x00461A0B File Offset: 0x0045FC0B
	// (set) Token: 0x0600FF4C RID: 65356 RVA: 0x00461A13 File Offset: 0x0045FC13
	public int ReignsId { get; set; }

	// Token: 0x1700130B RID: 4875
	// (get) Token: 0x0600FF4D RID: 65357 RVA: 0x00461A1C File Offset: 0x0045FC1C
	// (set) Token: 0x0600FF4E RID: 65358 RVA: 0x00461A24 File Offset: 0x0045FC24
	public bool IsSuccess { get; set; }

	// Token: 0x1700130C RID: 4876
	// (get) Token: 0x0600FF4F RID: 65359 RVA: 0x00461A2D File Offset: 0x0045FC2D
	// (set) Token: 0x0600FF50 RID: 65360 RVA: 0x00461A35 File Offset: 0x0045FC35
	public int NextReignsId { get; set; }
}
