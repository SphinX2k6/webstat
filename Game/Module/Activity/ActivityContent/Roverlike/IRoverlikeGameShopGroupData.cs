using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006419 RID: 25625
	[NullableContext(1)]
	public interface IRoverlikeGameShopGroupData
	{
		// Token: 0x17009DE8 RID: 40424
		// (get) Token: 0x0604054D RID: 263501
		// (set) Token: 0x0604054E RID: 263502
		ERoverlikeGameShopItemType GroupType { get; set; }

		// Token: 0x17009DE9 RID: 40425
		// (get) Token: 0x0604054F RID: 263503
		// (set) Token: 0x06040550 RID: 263504
		string TitleTextKey { get; set; }

		// Token: 0x17009DEA RID: 40426
		// (get) Token: 0x06040551 RID: 263505
		// (set) Token: 0x06040552 RID: 263506
		List<IRoverlikeGameShopGridData> Grids { get; set; }
	}
}
