using System;

// Token: 0x020015EC RID: 5612
public interface ITurntableQuestInfo
{
	// Token: 0x17000D57 RID: 3415
	// (get) Token: 0x06009E42 RID: 40514
	// (set) Token: 0x06009E43 RID: 40515
	int QuestState { get; set; }

	// Token: 0x17000D58 RID: 3416
	// (get) Token: 0x06009E44 RID: 40516
	// (set) Token: 0x06009E45 RID: 40517
	long QuestUnlockStamp { get; set; }
}
