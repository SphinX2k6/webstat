using System;

// Token: 0x02002C27 RID: 11303
public class TutorialViewParam : ITutorialViewParam
{
	// Token: 0x17001DC1 RID: 7617
	// (get) Token: 0x060169E2 RID: 92642 RVA: 0x00646BEA File Offset: 0x00644DEA
	// (set) Token: 0x060169E3 RID: 92643 RVA: 0x00646BF2 File Offset: 0x00644DF2
	public int? TutorialId { get; set; }

	// Token: 0x17001DC2 RID: 7618
	// (get) Token: 0x060169E4 RID: 92644 RVA: 0x00646BFB File Offset: 0x00644DFB
	// (set) Token: 0x060169E5 RID: 92645 RVA: 0x00646C03 File Offset: 0x00644E03
	public EExclusiveTutorialType? ExclusiveType { get; set; }
}
