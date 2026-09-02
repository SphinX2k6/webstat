using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005247 RID: 21063
	[NullableContext(1)]
	public interface IRogueBattleRoleAffixDetailOpenParam
	{
		// Token: 0x17008CC3 RID: 36035
		// (get) Token: 0x06035EF2 RID: 220914
		// (set) Token: 0x06035EF3 RID: 220915
		int Index { get; set; }

		// Token: 0x17008CC4 RID: 36036
		// (get) Token: 0x06035EF4 RID: 220916
		// (set) Token: 0x06035EF5 RID: 220917
		List<int> AffixIds { get; set; }

		// Token: 0x17008CC5 RID: 36037
		// (get) Token: 0x06035EF6 RID: 220918
		// (set) Token: 0x06035EF7 RID: 220919
		int RoleId { get; set; }
	}
}
