using System;

// Token: 0x0200129E RID: 4766
public class CollectionQuestState : ICollectionQuestState
{
	// Token: 0x17000AD4 RID: 2772
	// (get) Token: 0x06007FA1 RID: 32673 RVA: 0x0021B70E File Offset: 0x0021990E
	// (set) Token: 0x06007FA2 RID: 32674 RVA: 0x0021B716 File Offset: 0x00219916
	public int QuestState { get; set; }

	// Token: 0x17000AD5 RID: 2773
	// (get) Token: 0x06007FA3 RID: 32675 RVA: 0x0021B71F File Offset: 0x0021991F
	// (set) Token: 0x06007FA4 RID: 32676 RVA: 0x0021B727 File Offset: 0x00219927
	public bool ClaimedReward { get; set; }

	// Token: 0x17000AD6 RID: 2774
	// (get) Token: 0x06007FA5 RID: 32677 RVA: 0x0021B730 File Offset: 0x00219930
	// (set) Token: 0x06007FA6 RID: 32678 RVA: 0x0021B738 File Offset: 0x00219938
	public long QuestUnlockStamp { get; set; }
}
