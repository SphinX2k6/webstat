using System;

// Token: 0x0200129D RID: 4765
public interface ICollectionQuestState
{
	// Token: 0x17000AD1 RID: 2769
	// (get) Token: 0x06007F9B RID: 32667
	// (set) Token: 0x06007F9C RID: 32668
	int QuestState { get; set; }

	// Token: 0x17000AD2 RID: 2770
	// (get) Token: 0x06007F9D RID: 32669
	// (set) Token: 0x06007F9E RID: 32670
	bool ClaimedReward { get; set; }

	// Token: 0x17000AD3 RID: 2771
	// (get) Token: 0x06007F9F RID: 32671
	// (set) Token: 0x06007FA0 RID: 32672
	long QuestUnlockStamp { get; set; }
}
