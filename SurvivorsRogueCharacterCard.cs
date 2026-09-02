using System;

// Token: 0x02002B97 RID: 11159
public class SurvivorsRogueCharacterCard : SurvivorsRogueCardBaseData, ISurvivorsRogueCharacterCard, ISurvivorsRogueCardBase
{
	// Token: 0x060163BC RID: 91068 RVA: 0x00629829 File Offset: 0x00627A29
	public SurvivorsRogueCharacterCard()
	{
		base.Type = ESurvivorsRogueItemType.Character;
	}

	// Token: 0x17001D26 RID: 7462
	// (get) Token: 0x060163BD RID: 91069 RVA: 0x00629838 File Offset: 0x00627A38
	// (set) Token: 0x060163BE RID: 91070 RVA: 0x00629840 File Offset: 0x00627A40
	public int? PropertyId { get; set; }

	// Token: 0x17001D27 RID: 7463
	// (get) Token: 0x060163BF RID: 91071 RVA: 0x00629849 File Offset: 0x00627A49
	// (set) Token: 0x060163C0 RID: 91072 RVA: 0x00629851 File Offset: 0x00627A51
	public int? LvUpCount { get; set; }
}
