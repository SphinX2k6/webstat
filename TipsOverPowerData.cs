using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.PayShop;

// Token: 0x0200198A RID: 6538
[NullableContext(1)]
[Nullable(0)]
public class TipsOverPowerData : ItemTipsData
{
	// Token: 0x0600BBEC RID: 48108 RVA: 0x0031EB09 File Offset: 0x0031CD09
	public TipsOverPowerData(ItemTipsParam data) : base(data)
	{
		this.ItemType = EItemTipsType.OverPower;
	}

	// Token: 0x0600BBED RID: 48109 RVA: 0x0031EB1C File Offset: 0x0031CD1C
	public PayShopGoods ConvertToPayShopGoods()
	{
		PayShopGoodsData payShopGoodsData = new PayShopGoodsData();
		payShopGoodsData.PhraseFromTempData(this.ConfigId, 0);
		PayShopGoods payShopGoods = new PayShopGoods(PayShopDefine.EPayShopTabType.None);
		payShopGoods.SetGoodsData(payShopGoodsData);
		return payShopGoods;
	}
}
