using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005250 RID: 21072
	[NullableContext(1)]
	public interface IRogueBattleEnvironmentInfo
	{
		// Token: 0x17008CDB RID: 36059
		// (get) Token: 0x06035F26 RID: 220966
		// (set) Token: 0x06035F27 RID: 220967
		string Icon { get; set; }

		// Token: 0x17008CDC RID: 36060
		// (get) Token: 0x06035F28 RID: 220968
		// (set) Token: 0x06035F29 RID: 220969
		string TextId { get; set; }

		// Token: 0x17008CDD RID: 36061
		// (get) Token: 0x06035F2A RID: 220970
		// (set) Token: 0x06035F2B RID: 220971
		List<string> Param { get; set; }
	}
}
