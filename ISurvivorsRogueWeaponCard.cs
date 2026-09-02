using System;

// Token: 0x02002B98 RID: 11160
public interface ISurvivorsRogueWeaponCard : ISurvivorsRogueCardBase
{
	// Token: 0x17001D28 RID: 7464
	// (get) Token: 0x060163C1 RID: 91073
	ESurvivorsRogueItemType Type { get; }

	// Token: 0x17001D29 RID: 7465
	// (get) Token: 0x060163C2 RID: 91074
	int Id { get; }

	// Token: 0x17001D2A RID: 7466
	// (get) Token: 0x060163C3 RID: 91075
	int? PropertyId { get; }

	// Token: 0x17001D2B RID: 7467
	// (get) Token: 0x060163C4 RID: 91076
	int? LvUpCount { get; }

	// Token: 0x17001D2C RID: 7468
	// (get) Token: 0x060163C5 RID: 91077
	bool? WeaponBondInfo { get; }
}
