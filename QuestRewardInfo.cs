using System;

// Token: 0x02002660 RID: 9824
public class QuestRewardInfo
{
	// Token: 0x0601359F RID: 79263 RVA: 0x005628DB File Offset: 0x00560ADB
	public QuestRewardInfo(int itemId, int itemCount)
	{
		this.ItemId = itemId;
		this.ItemCount = itemCount;
	}

	// Token: 0x04009718 RID: 38680
	public readonly int ItemId;

	// Token: 0x04009719 RID: 38681
	public readonly int ItemCount;
}
