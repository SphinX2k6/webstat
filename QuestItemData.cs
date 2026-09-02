using System;

// Token: 0x0200266C RID: 9836
public class QuestItemData
{
	// Token: 0x0601360D RID: 79373 RVA: 0x0056595B File Offset: 0x00563B5B
	public QuestItemData(int questId, int questType)
	{
		this.QuestId = questId;
		this.QuestType = questType;
	}

	// Token: 0x0400973A RID: 38714
	public readonly int QuestId;

	// Token: 0x0400973B RID: 38715
	public readonly int QuestType;
}
