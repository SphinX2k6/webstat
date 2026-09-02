using System;

// Token: 0x02001599 RID: 5529
public interface IScratchTicketRewardResult
{
	// Token: 0x17000D34 RID: 3380
	// (get) Token: 0x06009B8B RID: 39819
	// (set) Token: 0x06009B8C RID: 39820
	int Index { get; set; }

	// Token: 0x17000D35 RID: 3381
	// (get) Token: 0x06009B8D RID: 39821
	// (set) Token: 0x06009B8E RID: 39822
	EScratchDirectionType DirectionType { get; set; }

	// Token: 0x17000D36 RID: 3382
	// (get) Token: 0x06009B8F RID: 39823
	// (set) Token: 0x06009B90 RID: 39824
	ECellSequenceType SequenceType { get; set; }
}
