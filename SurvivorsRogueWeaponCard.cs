using System;

// Token: 0x02002B99 RID: 11161
public class SurvivorsRogueWeaponCard : SurvivorsRogueCardBaseData, ISurvivorsRogueWeaponCard, ISurvivorsRogueCardBase
{
	// Token: 0x060163C6 RID: 91078 RVA: 0x0062985A File Offset: 0x00627A5A
	public SurvivorsRogueWeaponCard()
	{
		base.Type = ESurvivorsRogueItemType.Weapon;
	}

	// Token: 0x17001D2D RID: 7469
	// (get) Token: 0x060163C7 RID: 91079 RVA: 0x00629869 File Offset: 0x00627A69
	// (set) Token: 0x060163C8 RID: 91080 RVA: 0x00629871 File Offset: 0x00627A71
	public int? PropertyId { get; set; }

	// Token: 0x17001D2E RID: 7470
	// (get) Token: 0x060163C9 RID: 91081 RVA: 0x0062987A File Offset: 0x00627A7A
	// (set) Token: 0x060163CA RID: 91082 RVA: 0x00629882 File Offset: 0x00627A82
	public int? LvUpCount { get; set; }

	// Token: 0x17001D2F RID: 7471
	// (get) Token: 0x060163CB RID: 91083 RVA: 0x0062988B File Offset: 0x00627A8B
	// (set) Token: 0x060163CC RID: 91084 RVA: 0x00629893 File Offset: 0x00627A93
	public bool? WeaponBondInfo { get; set; }
}
