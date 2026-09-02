using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;

// Token: 0x02001494 RID: 5268
public class PinballExchangeShopItemProxy : CommonGameplayShopItemProxy
{
	// Token: 0x06009370 RID: 37744 RVA: 0x0026ECA8 File Offset: 0x0026CEA8
	[NullableContext(1)]
	public override void UpdateFromPayShopGoods(PayShopGoods data)
	{
		this.GoodsData = data;
		this.UpdateBottomBgVisible();
		this.UpdateRaycastTarget();
		this.UpdateRedDot();
		this.UpdatePriceData();
		this.UpdateItemName();
		this.UpdateQualityData();
		this.UpdateItemIconData();
		this.UpdateSoldOutData();
		this.UpdateBuyLimitCountText();
		base.UpdateDiscountData();
	}

	// Token: 0x06009371 RID: 37745 RVA: 0x0026ECF8 File Offset: 0x0026CEF8
	public override void UpdateBottomBgVisible()
	{
		base.BottomBgVisible = false;
	}

	// Token: 0x06009372 RID: 37746 RVA: 0x0026ED01 File Offset: 0x0026CF01
	public new void UpdateRaycastTarget()
	{
		base.RaycastTarget = false;
	}

	// Token: 0x06009373 RID: 37747 RVA: 0x0026ED0A File Offset: 0x0026CF0A
	public new void UpdateRedDot()
	{
		base.RedDotVisible = false;
	}

	// Token: 0x06009374 RID: 37748 RVA: 0x0026ED13 File Offset: 0x0026CF13
	public override void UpdatePriceData()
	{
		base.PriceItemVisible = false;
	}

	// Token: 0x06009375 RID: 37749 RVA: 0x0026ED1C File Offset: 0x0026CF1C
	public override void UpdateQualityData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		CSharpScript.Game.Module.PayShop.IItemData itemData = this.GoodsData.GetItemData();
		if (itemData == null)
		{
			return;
		}
		string payShopItemQualitySpriteByItemIdAndQuality = ModelBase<PayShopModel>.Instance.GetPayShopItemQualitySpriteByItemIdAndQuality(itemData.ItemId, itemData.Quality);
		base.QualitySpritePath = payShopItemQualitySpriteByItemIdAndQuality;
	}

	// Token: 0x06009376 RID: 37750 RVA: 0x0026ED60 File Offset: 0x0026CF60
	public override void UpdateItemIconData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		base.ItemId = this.GoodsData.GetGoodsData().ItemId;
	}

	// Token: 0x06009377 RID: 37751 RVA: 0x0026ED84 File Offset: 0x0026CF84
	public override void UpdateItemName()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		PayShopGoodsData goodsData = this.GoodsData.GetGoodsData();
		int num = (goodsData != null) ? goodsData.ItemId : 0;
		if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(num)) == InventoryDefine.EItemDataType.PinballWeaponItem)
		{
			PinballWeaponConfig? pinballWeaponConfigById = ConfigBase<PinballConfig>.Instance.GetPinballWeaponConfigById(num);
			if (pinballWeaponConfigById != null)
			{
				base.ItemNameTextData.SetData(new TableTextArgNew(pinballWeaponConfigById.Value.Name, Array.Empty<object>()));
				return;
			}
		}
		base.UpdateItemName();
	}
}
