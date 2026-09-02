using System;

// Token: 0x020015ED RID: 5613
public class TurntableQuestInfo : ITurntableQuestInfo
{
	// Token: 0x17000D59 RID: 3417
	// (get) Token: 0x06009E46 RID: 40518 RVA: 0x002972EF File Offset: 0x002954EF
	// (set) Token: 0x06009E47 RID: 40519 RVA: 0x002972F7 File Offset: 0x002954F7
	public int QuestState { get; set; }

	// Token: 0x17000D5A RID: 3418
	// (get) Token: 0x06009E48 RID: 40520 RVA: 0x00297300 File Offset: 0x00295500
	// (set) Token: 0x06009E49 RID: 40521 RVA: 0x00297308 File Offset: 0x00295508
	public long QuestUnlockStamp { get; set; }
}
