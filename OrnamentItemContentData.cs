using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Ornament;
using CSharpScript.Game.Module.PayShop;

// Token: 0x020023D1 RID: 9169
public class OrnamentItemContentData
{
	// Token: 0x04008AC7 RID: 35527
	[Nullable(2)]
	public ShopRoleOrnamentData ShopRoleOrnamentData;

	// Token: 0x04008AC8 RID: 35528
	[Nullable(1)]
	public List<PayShopGoods> AllData = new List<PayShopGoods>();
}
