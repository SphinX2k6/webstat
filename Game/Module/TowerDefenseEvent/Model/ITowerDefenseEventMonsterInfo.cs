using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E8B RID: 20107
	[NullableContext(2)]
	public interface ITowerDefenseEventMonsterInfo : ITowerDefenseEventCombatInfo, ITowerDefenseEventConfigInfo
	{
		// Token: 0x170088F5 RID: 35061
		// (get) Token: 0x06033F1E RID: 212766
		// (set) Token: 0x06033F1F RID: 212767
		ETowerDefenseEventMonsterDeathType DeathType { get; set; }

		// Token: 0x170088F6 RID: 35062
		// (get) Token: 0x06033F20 RID: 212768
		// (set) Token: 0x06033F21 RID: 212769
		int BuffRadius { get; set; }

		// Token: 0x170088F7 RID: 35063
		// (get) Token: 0x06033F22 RID: 212770
		// (set) Token: 0x06033F23 RID: 212771
		List<int> BuffIds { get; set; }

		// Token: 0x170088F8 RID: 35064
		// (get) Token: 0x06033F24 RID: 212772
		// (set) Token: 0x06033F25 RID: 212773
		List<int> SpawnIds { get; set; }

		// Token: 0x170088F9 RID: 35065
		// (get) Token: 0x06033F26 RID: 212774
		// (set) Token: 0x06033F27 RID: 212775
		int PolluteRadius { get; set; }
	}
}
