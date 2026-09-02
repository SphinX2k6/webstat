using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003128 RID: 12584
[NullableContext(1)]
public interface ISkillBattleContext
{
	// Token: 0x17002354 RID: 9044
	// (get) Token: 0x0601A0E2 RID: 106722
	// (set) Token: 0x0601A0E3 RID: 106723
	int VisionId { get; set; }

	// Token: 0x17002355 RID: 9045
	// (get) Token: 0x0601A0E4 RID: 106724
	// (set) Token: 0x0601A0E5 RID: 106725
	List<string> BattleFlags { get; set; }
}
