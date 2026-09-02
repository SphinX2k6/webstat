using System;

// Token: 0x02002B9B RID: 11163
public class SurvivorsRogueItemCard : SurvivorsRogueCardBaseData, ISurvivorsRogueItemCard, ISurvivorsRogueCardBase, ISurvivorsHandbookItemDataBase
{
	// Token: 0x060163D0 RID: 91088 RVA: 0x0062989C File Offset: 0x00627A9C
	public SurvivorsRogueItemCard()
	{
		base.Type = ESurvivorsRogueItemType.Normal;
	}

	// Token: 0x17001D33 RID: 7475
	// (get) Token: 0x060163D1 RID: 91089 RVA: 0x006298AB File Offset: 0x00627AAB
	// (set) Token: 0x060163D2 RID: 91090 RVA: 0x006298B3 File Offset: 0x00627AB3
	public bool? IsNew { get; set; }
}
