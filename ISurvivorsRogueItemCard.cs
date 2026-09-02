using System;

// Token: 0x02002B9A RID: 11162
public interface ISurvivorsRogueItemCard : ISurvivorsRogueCardBase
{
	// Token: 0x17001D30 RID: 7472
	// (get) Token: 0x060163CD RID: 91085
	ESurvivorsRogueItemType Type { get; }

	// Token: 0x17001D31 RID: 7473
	// (get) Token: 0x060163CE RID: 91086
	int Id { get; }

	// Token: 0x17001D32 RID: 7474
	// (get) Token: 0x060163CF RID: 91087
	bool? IsNew { get; }
}
