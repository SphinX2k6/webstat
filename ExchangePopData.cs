using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;

// Token: 0x020023E9 RID: 9193
[NullableContext(2)]
[Nullable(0)]
public class ExchangePopData : UiPopViewData
{
	// Token: 0x04008B38 RID: 35640
	public int GoodsId;

	// Token: 0x04008B39 RID: 35641
	public PayShopGoods PayShopGoods;

	// Token: 0x04008B3A RID: 35642
	[Nullable(1)]
	public string ShopItemResource = "";

	// Token: 0x04008B3B RID: 35643
	public Func<int> GetMaxBuyCount;

	// Token: 0x04008B3C RID: 35644
	public Func<bool> CheckIfCanBuy;
}
