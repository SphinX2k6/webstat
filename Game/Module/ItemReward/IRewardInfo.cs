using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B08 RID: 23304
	[NullableContext(2)]
	public interface IRewardInfo
	{
		// Token: 0x1700964D RID: 38477
		// (get) Token: 0x0603AF53 RID: 241491
		// (set) Token: 0x0603AF54 RID: 241492
		ERewardInfoType Type { get; set; }

		// Token: 0x1700964E RID: 38478
		// (get) Token: 0x0603AF55 RID: 241493
		// (set) Token: 0x0603AF56 RID: 241494
		EUiViewName ViewName { get; set; }

		// Token: 0x1700964F RID: 38479
		// (get) Token: 0x0603AF57 RID: 241495
		// (set) Token: 0x0603AF58 RID: 241496
		string AudioId { get; set; }
	}
}
