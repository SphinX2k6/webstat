using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200159C RID: 5532
[NullableContext(1)]
[Nullable(0)]
public class ScratchTicketRoundResult : IScratchTicketRoundResult
{
	// Token: 0x17000D3D RID: 3389
	// (get) Token: 0x06009B9E RID: 39838 RVA: 0x0028BAC6 File Offset: 0x00289CC6
	// (set) Token: 0x06009B9F RID: 39839 RVA: 0x0028BACE File Offset: 0x00289CCE
	public List<ScratchTicketRewardResult> RewardList { get; set; }

	// Token: 0x17000D3E RID: 3390
	// (get) Token: 0x06009BA0 RID: 39840 RVA: 0x0028BAD7 File Offset: 0x00289CD7
	// (set) Token: 0x06009BA1 RID: 39841 RVA: 0x0028BADF File Offset: 0x00289CDF
	public float DelayInterval { get; set; }

	// Token: 0x17000D3F RID: 3391
	// (get) Token: 0x06009BA2 RID: 39842 RVA: 0x0028BAE8 File Offset: 0x00289CE8
	// (set) Token: 0x06009BA3 RID: 39843 RVA: 0x0028BAF0 File Offset: 0x00289CF0
	public string SequenceName { get; set; }
}
