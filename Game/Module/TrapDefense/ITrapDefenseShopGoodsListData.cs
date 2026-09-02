using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DF7 RID: 19959
	[NullableContext(1)]
	public interface ITrapDefenseShopGoodsListData
	{
		// Token: 0x170088B8 RID: 35000
		// (get) Token: 0x060339C3 RID: 211395
		// (set) Token: 0x060339C4 RID: 211396
		ETrapDefenseShopGoodsType Type { get; set; }

		// Token: 0x170088B9 RID: 35001
		// (get) Token: 0x060339C5 RID: 211397
		// (set) Token: 0x060339C6 RID: 211398
		List<ITrapDefenseShopGoods> GoodsList { get; set; }
	}
}
