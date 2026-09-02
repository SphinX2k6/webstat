using System;
using System.Runtime.CompilerServices;

// Token: 0x02000F82 RID: 3970
[NullableContext(2)]
public interface ISurvivorsRogueActivityEntityInfo : ISurvivorsRogueCombatInfo, ISurvivorsRogueConfigInfo
{
	// Token: 0x170007C4 RID: 1988
	// (get) Token: 0x060064AF RID: 25775
	// (set) Token: 0x060064B0 RID: 25776
	int ConfigId { get; set; }

	// Token: 0x170007C5 RID: 1989
	// (get) Token: 0x060064B1 RID: 25777
	// (set) Token: 0x060064B2 RID: 25778
	ESurvivorsRogueMonsterDeathType DeathType { get; set; }

	// Token: 0x170007C6 RID: 1990
	// (get) Token: 0x060064B3 RID: 25779
	// (set) Token: 0x060064B4 RID: 25780
	int BuffRadius { get; set; }

	// Token: 0x170007C7 RID: 1991
	// (get) Token: 0x060064B5 RID: 25781
	// (set) Token: 0x060064B6 RID: 25782
	int[] BuffIds { get; set; }

	// Token: 0x170007C8 RID: 1992
	// (get) Token: 0x060064B7 RID: 25783
	// (set) Token: 0x060064B8 RID: 25784
	int[] SpawnIds { get; set; }

	// Token: 0x170007C9 RID: 1993
	// (get) Token: 0x060064B9 RID: 25785
	// (set) Token: 0x060064BA RID: 25786
	int PolluteRadius { get; set; }
}
