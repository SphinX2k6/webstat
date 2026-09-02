using System;

// Token: 0x02001291 RID: 4753
public class ChessTransmitData : IChessTransmitData
{
	// Token: 0x17000ACD RID: 2765
	// (get) Token: 0x06007F39 RID: 32569 RVA: 0x0021A352 File Offset: 0x00218552
	// (set) Token: 0x06007F3A RID: 32570 RVA: 0x0021A35A File Offset: 0x0021855A
	public int ItemId { get; set; }

	// Token: 0x17000ACE RID: 2766
	// (get) Token: 0x06007F3B RID: 32571 RVA: 0x0021A363 File Offset: 0x00218563
	// (set) Token: 0x06007F3C RID: 32572 RVA: 0x0021A36B File Offset: 0x0021856B
	public int TargetPointId { get; set; }

	// Token: 0x17000ACF RID: 2767
	// (get) Token: 0x06007F3D RID: 32573 RVA: 0x0021A374 File Offset: 0x00218574
	// (set) Token: 0x06007F3E RID: 32574 RVA: 0x0021A37C File Offset: 0x0021857C
	public int High { get; set; }
}
