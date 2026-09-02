using System;

// Token: 0x0200128B RID: 4747
public class ChessItemParams : IChessItemParams
{
	// Token: 0x17000AC6 RID: 2758
	// (get) Token: 0x06007F21 RID: 32545 RVA: 0x0021A07B File Offset: 0x0021827B
	// (set) Token: 0x06007F22 RID: 32546 RVA: 0x0021A083 File Offset: 0x00218283
	public int Id { get; set; }

	// Token: 0x17000AC7 RID: 2759
	// (get) Token: 0x06007F23 RID: 32547 RVA: 0x0021A08C File Offset: 0x0021828C
	// (set) Token: 0x06007F24 RID: 32548 RVA: 0x0021A094 File Offset: 0x00218294
	public long CreatureDataId { get; set; }

	// Token: 0x17000AC8 RID: 2760
	// (get) Token: 0x06007F25 RID: 32549 RVA: 0x0021A09D File Offset: 0x0021829D
	// (set) Token: 0x06007F26 RID: 32550 RVA: 0x0021A0A5 File Offset: 0x002182A5
	public bool RotationIsForward { get; set; }

	// Token: 0x17000AC9 RID: 2761
	// (get) Token: 0x06007F27 RID: 32551 RVA: 0x0021A0AE File Offset: 0x002182AE
	// (set) Token: 0x06007F28 RID: 32552 RVA: 0x0021A0B6 File Offset: 0x002182B6
	public int InitPointId { get; set; }
}
