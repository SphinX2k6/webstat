using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B20 RID: 23328
	[NullableContext(1)]
	public interface IRewardExploreScoreBelongHalfArea
	{
		// Token: 0x170096CF RID: 38607
		// (get) Token: 0x0603B063 RID: 241763
		// (set) Token: 0x0603B064 RID: 241764
		List<IRewardExploreScoreBelongHalfAreaItem> ItemList { get; set; }

		// Token: 0x170096D0 RID: 38608
		// (get) Token: 0x0603B065 RID: 241765
		// (set) Token: 0x0603B066 RID: 241766
		int FullScore { get; set; }

		// Token: 0x170096D1 RID: 38609
		// (get) Token: 0x0603B067 RID: 241767
		// (set) Token: 0x0603B068 RID: 241768
		bool IfNewRecord { get; set; }
	}
}
