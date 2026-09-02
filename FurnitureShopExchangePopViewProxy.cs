using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001030 RID: 4144
public class FurnitureShopExchangePopViewProxy : CommonGameplayShopExchangePopViewProxy
{
	// Token: 0x06006BDE RID: 27614 RVA: 0x001C453C File Offset: 0x001C273C
	public override void UpdateShopItemData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		FurnitureShopExchangeItemProxy furnitureShopExchangeItemProxy = new FurnitureShopExchangeItemProxy();
		furnitureShopExchangeItemProxy.UpdateFromPayShopGoods(this.GoodsData);
		base.ShopItemProxy = furnitureShopExchangeItemProxy;
	}

	// Token: 0x06006BDF RID: 27615 RVA: 0x001C456B File Offset: 0x001C276B
	public override void UpdateShopItemResource()
	{
		base.ShopItemResource = "PnlDIYShopItem";
	}

	// Token: 0x06006BE0 RID: 27616 RVA: 0x001C4578 File Offset: 0x001C2778
	[NullableContext(1)]
	public override UiPanelBase ShopItemCreate()
	{
		this.ShopItem = new FurnitureExchangeShopItem();
		return this.ShopItem;
	}

	// Token: 0x06006BE1 RID: 27617 RVA: 0x001C458C File Offset: 0x001C278C
	public override void ShopItemRefresh()
	{
		FurnitureExchangeShopItem furnitureExchangeShopItem = this.ShopItem as FurnitureExchangeShopItem;
		if (furnitureExchangeShopItem == null || base.ShopItemProxy == null)
		{
			return;
		}
		furnitureExchangeShopItem.RefreshByData((FurnitureShopExchangeItemProxy)base.ShopItemProxy);
	}

	// Token: 0x06006BE2 RID: 27618 RVA: 0x001C45C2 File Offset: 0x001C27C2
	public override void UpdateTipTitleItem()
	{
		base.TipTitleItemVisible = false;
	}
}
