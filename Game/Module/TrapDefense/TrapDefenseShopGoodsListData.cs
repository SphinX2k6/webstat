using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DF8 RID: 19960
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseShopGoodsListData : ITrapDefenseShopGoodsListData
	{
		// Token: 0x170088BA RID: 35002
		// (get) Token: 0x060339C7 RID: 211399 RVA: 0x00CE4BFB File Offset: 0x00CE2DFB
		// (set) Token: 0x060339C8 RID: 211400 RVA: 0x00CE4C03 File Offset: 0x00CE2E03
		public ETrapDefenseShopGoodsType Type { get; set; }

		// Token: 0x170088BB RID: 35003
		// (get) Token: 0x060339C9 RID: 211401 RVA: 0x00CE4C0C File Offset: 0x00CE2E0C
		// (set) Token: 0x060339CA RID: 211402 RVA: 0x00CE4C14 File Offset: 0x00CE2E14
		public List<ITrapDefenseShopGoods> GoodsList { get; set; } = new List<ITrapDefenseShopGoods>();
	}
}
