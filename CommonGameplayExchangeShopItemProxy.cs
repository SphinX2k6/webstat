using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;

// Token: 0x02002394 RID: 9108
public class CommonGameplayExchangeShopItemProxy : CommonGameplayShopItemProxy
{
	// Token: 0x060117A8 RID: 71592 RVA: 0x004CF6E9 File Offset: 0x004CD8E9
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
	}

	// Token: 0x060117A9 RID: 71593 RVA: 0x004CF722 File Offset: 0x004CD922
	public new void UpdateBottomBgVisible()
	{
		base.BottomBgVisible = false;
	}

	// Token: 0x060117AA RID: 71594 RVA: 0x004CF72B File Offset: 0x004CD92B
	public new void UpdateRaycastTarget()
	{
		base.RaycastTarget = false;
	}

	// Token: 0x060117AB RID: 71595 RVA: 0x004CF734 File Offset: 0x004CD934
	public new void UpdateRedDot()
	{
		base.RedDotVisible = false;
	}

	// Token: 0x060117AC RID: 71596 RVA: 0x004CF73D File Offset: 0x004CD93D
	public new void UpdatePriceData()
	{
		base.PriceItemVisible = false;
	}

	// Token: 0x060117AD RID: 71597 RVA: 0x004CF746 File Offset: 0x004CD946
	public override void UpdateItemName()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		base.ItemNameTextData.SetContent(this.GoodsData.GetGoodsData().GetGoodsName(Singleton<LanguageSystem>.Instance.PackageLanguage));
	}

	// Token: 0x060117AE RID: 71598 RVA: 0x004CF778 File Offset: 0x004CD978
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

	// Token: 0x060117AF RID: 71599 RVA: 0x004CF7BC File Offset: 0x004CD9BC
	public override void UpdateItemIconData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		base.ItemId = this.GoodsData.GetGoodsData().ItemId;
	}

	// Token: 0x060117B0 RID: 71600 RVA: 0x004CF7E0 File Offset: 0x004CD9E0
	public override void UpdateSoldOutData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		base.SoldOutItemVisible = (this.GoodsData.IsLimitGoods() && this.GoodsData.IsSoldOut());
		if (base.SoldOutItemVisible)
		{
			if (this.GoodsData.CheckIfMonthCardItem())
			{
				base.SoldOutTextData.SetData(new TableTextArgNew("MonthlyCardMax", Array.Empty<object>()));
				return;
			}
			base.SoldOutTextData.SetData(new TableTextArgNew("SoldOut", Array.Empty<object>()));
		}
	}
}
