using System;

// Token: 0x02000F62 RID: 3938
public interface IPinballBattleActivityEntityInfo : IPinballBattleCombatInfo, IPinballBattleConfigInfo
{
	// Token: 0x17000774 RID: 1908
	// (get) Token: 0x0600635C RID: 25436
	// (set) Token: 0x0600635D RID: 25437
	int ConfigId { get; set; }

	// Token: 0x17000775 RID: 1909
	// (get) Token: 0x0600635E RID: 25438
	// (set) Token: 0x0600635F RID: 25439
	EPinballBattleMonsterDeathType DeathType { get; set; }
}
