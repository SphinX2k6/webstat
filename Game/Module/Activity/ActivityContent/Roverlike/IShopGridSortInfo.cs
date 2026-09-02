using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006420 RID: 25632
	[NullableContext(1)]
	internal interface IShopGridSortInfo
	{
		// Token: 0x17009DEE RID: 40430
		// (get) Token: 0x0604057F RID: 263551
		// (set) Token: 0x06040580 RID: 263552
		IRoverlikeGameShopGridData Data { get; set; }

		// Token: 0x17009DEF RID: 40431
		// (get) Token: 0x06040581 RID: 263553
		// (set) Token: 0x06040582 RID: 263554
		int OriginalIndex { get; set; }
	}
}
