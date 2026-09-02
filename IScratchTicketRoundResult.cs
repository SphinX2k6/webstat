using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200159B RID: 5531
[NullableContext(1)]
public interface IScratchTicketRoundResult
{
	// Token: 0x17000D3A RID: 3386
	// (get) Token: 0x06009B98 RID: 39832
	// (set) Token: 0x06009B99 RID: 39833
	List<ScratchTicketRewardResult> RewardList { get; set; }

	// Token: 0x17000D3B RID: 3387
	// (get) Token: 0x06009B9A RID: 39834
	// (set) Token: 0x06009B9B RID: 39835
	float DelayInterval { get; set; }

	// Token: 0x17000D3C RID: 3388
	// (get) Token: 0x06009B9C RID: 39836
	// (set) Token: 0x06009B9D RID: 39837
	string SequenceName { get; set; }
}
