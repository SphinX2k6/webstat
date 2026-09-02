using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B1C RID: 23324
	[NullableContext(1)]
	public interface IRewardExploreTargetReached
	{
		// Token: 0x170096C5 RID: 38597
		// (get) Token: 0x0603B04D RID: 241741
		// (set) Token: 0x0603B04E RID: 241742
		List<string> Target { get; set; }

		// Token: 0x170096C6 RID: 38598
		// (get) Token: 0x0603B04F RID: 241743
		// (set) Token: 0x0603B050 RID: 241744
		string DescriptionTextId { get; set; }

		// Token: 0x170096C7 RID: 38599
		// (get) Token: 0x0603B051 RID: 241745
		// (set) Token: 0x0603B052 RID: 241746
		bool IsReached { get; set; }
	}
}
