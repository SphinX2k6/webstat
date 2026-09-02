using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EED RID: 24301
	[NullableContext(1)]
	public interface IBossPilingLevelDetailInfo
	{
		// Token: 0x17009A1E RID: 39454
		// (get) Token: 0x0603D0EA RID: 250090
		// (set) Token: 0x0603D0EB RID: 250091
		bool IsFirst { get; set; }

		// Token: 0x17009A1F RID: 39455
		// (get) Token: 0x0603D0EC RID: 250092
		// (set) Token: 0x0603D0ED RID: 250093
		List<BossPilingLevelDescInfo> LevelList { get; set; }
	}
}
