using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;

// Token: 0x02001031 RID: 4145
[NullableContext(1)]
[Nullable(0)]
public class FurnitureShopGridItemProxy
{
	// Token: 0x06006BE4 RID: 27620 RVA: 0x001C45D4 File Offset: 0x001C27D4
	public void UpdateFromPayShopGoods(PayShopGoods data)
	{
		this.FurnitureShopItemProxy.UpdateFromPayShopGoods(data);
		this.AtmosphereText = ModelBase<FurnitureModel>.Instance.GetFurnitureConfigByGoodsData(data).Atmosphere.ToString();
	}

	// Token: 0x0400334C RID: 13132
	public FurnitureShopItemProxy FurnitureShopItemProxy = new FurnitureShopItemProxy();

	// Token: 0x0400334D RID: 13133
	public string AtmosphereText = "";
}
