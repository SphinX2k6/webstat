using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005249 RID: 21065
	[NullableContext(1)]
	public interface IRogueBattleMapFetterTabInfo
	{
		// Token: 0x17008CC9 RID: 36041
		// (get) Token: 0x06035EFF RID: 220927
		// (set) Token: 0x06035F00 RID: 220928
		bool IsSelected { get; set; }

		// Token: 0x17008CCA RID: 36042
		// (get) Token: 0x06035F01 RID: 220929
		// (set) Token: 0x06035F02 RID: 220930
		List<int> Config { get; set; }
	}
}
