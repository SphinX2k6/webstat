using System;

// Token: 0x02002B96 RID: 11158
public interface ISurvivorsRogueCharacterCard : ISurvivorsRogueCardBase
{
	// Token: 0x17001D22 RID: 7458
	// (get) Token: 0x060163B8 RID: 91064
	ESurvivorsRogueItemType Type { get; }

	// Token: 0x17001D23 RID: 7459
	// (get) Token: 0x060163B9 RID: 91065
	int Id { get; }

	// Token: 0x17001D24 RID: 7460
	// (get) Token: 0x060163BA RID: 91066
	int? PropertyId { get; }

	// Token: 0x17001D25 RID: 7461
	// (get) Token: 0x060163BB RID: 91067
	int? LvUpCount { get; }
}
