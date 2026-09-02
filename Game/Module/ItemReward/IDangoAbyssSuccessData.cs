using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B32 RID: 23346
	[NullableContext(1)]
	public interface IDangoAbyssSuccessData
	{
		// Token: 0x17009711 RID: 38673
		// (get) Token: 0x0603B0F0 RID: 241904
		// (set) Token: 0x0603B0F1 RID: 241905
		List<RewardItemData> RewardItemData { get; set; }

		// Token: 0x17009712 RID: 38674
		// (get) Token: 0x0603B0F2 RID: 241906
		// (set) Token: 0x0603B0F3 RID: 241907
		float Progress { get; set; }
	}
}
