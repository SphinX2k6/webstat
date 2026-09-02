using System;

// Token: 0x0200159A RID: 5530
public class ScratchTicketRewardResult : IScratchTicketRewardResult
{
	// Token: 0x17000D37 RID: 3383
	// (get) Token: 0x06009B91 RID: 39825 RVA: 0x0028BA8B File Offset: 0x00289C8B
	// (set) Token: 0x06009B92 RID: 39826 RVA: 0x0028BA93 File Offset: 0x00289C93
	public int Index { get; set; }

	// Token: 0x17000D38 RID: 3384
	// (get) Token: 0x06009B93 RID: 39827 RVA: 0x0028BA9C File Offset: 0x00289C9C
	// (set) Token: 0x06009B94 RID: 39828 RVA: 0x0028BAA4 File Offset: 0x00289CA4
	public EScratchDirectionType DirectionType { get; set; }

	// Token: 0x17000D39 RID: 3385
	// (get) Token: 0x06009B95 RID: 39829 RVA: 0x0028BAAD File Offset: 0x00289CAD
	// (set) Token: 0x06009B96 RID: 39830 RVA: 0x0028BAB5 File Offset: 0x00289CB5
	public ECellSequenceType SequenceType { get; set; }
}
