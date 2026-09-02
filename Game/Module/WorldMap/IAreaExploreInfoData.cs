using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B40 RID: 19264
	[NullableContext(1)]
	public interface IAreaExploreInfoData
	{
		// Token: 0x1700863E RID: 34366
		// (get) Token: 0x06032434 RID: 205876
		// (set) Token: 0x06032435 RID: 205877
		int AreaId { get; set; }

		// Token: 0x1700863F RID: 34367
		// (get) Token: 0x06032436 RID: 205878
		// (set) Token: 0x06032437 RID: 205879
		List<IOneExploreItemData> ExploreProgress { get; set; }

		// Token: 0x17008640 RID: 34368
		// (get) Token: 0x06032438 RID: 205880
		// (set) Token: 0x06032439 RID: 205881
		float ExplorePercent { get; set; }
	}
}
