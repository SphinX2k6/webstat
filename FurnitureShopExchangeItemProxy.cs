using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;

// Token: 0x0200102F RID: 4143
[NullableContext(1)]
[Nullable(0)]
public class FurnitureShopExchangeItemProxy
{
	// Token: 0x06006BDC RID: 27612 RVA: 0x001C44E4 File Offset: 0x001C26E4
	public void UpdateFromPayShopGoods(PayShopGoods data)
	{
		this.FurnitureShopItemProxy.UpdateFromPayShopGoods(data);
		this.AtmosphereText = ModelBase<FurnitureModel>.Instance.GetFurnitureConfigByGoodsData(data).Atmosphere.ToString();
	}

	// Token: 0x0400334A RID: 13130
	public CommonGameplayExchangeShopItemProxy FurnitureShopItemProxy = new CommonGameplayExchangeShopItemProxy();

	// Token: 0x0400334B RID: 13131
	public string AtmosphereText = "";
}
