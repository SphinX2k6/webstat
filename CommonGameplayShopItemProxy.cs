using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;

// Token: 0x02002396 RID: 9110
[NullableContext(1)]
[Nullable(0)]
public class CommonGameplayShopItemProxy : AbstractGameplayShopItemProxy
{
	// Token: 0x060117C4 RID: 71620 RVA: 0x004CFDD8 File Offset: 0x004CDFD8
	public virtual void UpdatePriceData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		IPriceData priceData = this.GoodsData.GetPriceData();
		base.CurrencyId = priceData.CurrencyId;
		string nowPriceTextColor = "FFEF6FFF";
		if (priceData.OwnNumber() < priceData.NowPrice)
		{
			nowPriceTextColor = "F55E66FF";
		}
		base.NowPriceTextColor = nowPriceTextColor;
		if (priceData.NowPrice == 0)
		{
			base.CurrencyIconVisible = false;
			base.NowPriceTextData.SetData(new TableTextArgNew("ShopDiscountLabel_4", Array.Empty<object>()));
		}
		else
		{
			base.CurrencyIconVisible = true;
			base.NowPriceTextData.SetContent(priceData.NowPrice.ToString());
		}
		int? originalPrice = priceData.OriginalPrice;
		base.OriginalPriceVisible = (originalPrice != null && priceData.InDiscountTime);
		if (base.OriginalPriceVisible)
		{
			base.OriginalPriceTextData.SetContent("<s>" + originalPrice.ToString() + "</s>");
		}
	}

	// Token: 0x060117C5 RID: 71621 RVA: 0x004CFEC5 File Offset: 0x004CE0C5
	public virtual void UpdateItemName()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		base.ItemNameTextData.SetContent(this.GoodsData.GetGoodsData().GetGoodsName(Singleton<LanguageSystem>.Instance.PackageLanguage));
	}

	// Token: 0x060117C6 RID: 71622 RVA: 0x004CFEF8 File Offset: 0x004CE0F8
	public void UpdateDiscountData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		base.DiscountItemVisible = this.GoodsData.HasDiscount();
		if (base.DiscountItemVisible)
		{
			base.DiscountTextData.SetContent(StringUtils.Format("-{0}%", new string[]
			{
				this.GoodsData.GetDiscount().ToString()
			}));
		}
	}

	// Token: 0x060117C7 RID: 71623 RVA: 0x004CFF58 File Offset: 0x004CE158
	public void UpdateLockData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		base.LockItemVisible = !this.GoodsData.IfCanBuy();
		if (base.LockItemVisible)
		{
			base.LockTextData.SetData(new TableTextArgNew(this.GoodsData.GetConditionTextId(), Array.Empty<object>()));
		}
	}

	// Token: 0x060117C8 RID: 71624 RVA: 0x004CFFAC File Offset: 0x004CE1AC
	public virtual void UpdateSoldOutData()
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

	// Token: 0x060117C9 RID: 71625 RVA: 0x004D0030 File Offset: 0x004CE230
	public virtual void UpdateQualityData()
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

	// Token: 0x060117CA RID: 71626 RVA: 0x004D0074 File Offset: 0x004CE274
	public virtual void UpdateItemIconData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		base.ItemId = this.GoodsData.GetGoodsData().ItemId;
	}

	// Token: 0x060117CB RID: 71627 RVA: 0x004D0098 File Offset: 0x004CE298
	public virtual void UpdateBuyLimitCountText()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		string shopTipsText = this.GoodsData.GetShopTipsText();
		if (shopTipsText != null && !StringUtils.IsEmpty(shopTipsText))
		{
			base.BuyLimitCountTextVisible = true;
			base.BuyLimitCountTextData.SetContent(shopTipsText);
			return;
		}
		base.BuyLimitCountTextVisible = false;
	}

	// Token: 0x060117CC RID: 71628 RVA: 0x004D00E0 File Offset: 0x004CE2E0
	public virtual void UpdateRedDot()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		base.RedDotVisible = this.GoodsData.GetIfNeedRemind();
	}

	// Token: 0x060117CD RID: 71629 RVA: 0x004D00FC File Offset: 0x004CE2FC
	public void UpdateLabel()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		int discountLabel = this.GoodsData.GetDiscountLabel();
		base.LabelVisible = (discountLabel > 0 && this.GoodsData.InLabelShowTime());
		if (base.LabelVisible)
		{
			string shopDiscountLabel = ConfigBase<PayShopConfig>.Instance.GetShopDiscountLabel(discountLabel);
			base.LabelTextData.SetData(new TableTextArgNew(shopDiscountLabel, Array.Empty<object>()));
		}
	}

	// Token: 0x060117CE RID: 71630 RVA: 0x004D0160 File Offset: 0x004CE360
	public virtual void UpdateLeftTime()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> countDownData = this.GoodsData.GetCountDownData();
		EPayCountTimeType item = countDownData.Item1;
		CommonDefine.IPayShowCountDownRemainTime item2 = countDownData.Item2;
		base.LeftTimeItemVisible = (item2 != null && item != EPayCountTimeType.Resell);
		if (base.LeftTimeItemVisible)
		{
			CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = item2 as CommonDefine.PayShowCountDownRemainTime<string>;
			if (payShowCountDownRemainTime != null)
			{
				base.LeftTimeTextData.SetContent(payShowCountDownRemainTime.Value);
				return;
			}
			CommonDefine.IRemainTime remainTime = item2 as CommonDefine.IRemainTime;
			if (remainTime != null)
			{
				base.LeftTimeTextData.SetData(new TableTextArgNew(remainTime.TextId, new <>z__ReadOnlySingleElementList<object>(remainTime.TimeValue)));
			}
		}
	}

	// Token: 0x060117CF RID: 71631 RVA: 0x004D01F8 File Offset: 0x004CE3F8
	public void UpdateReSell()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		string resellText = this.GoodsData.GetResellText();
		base.ReSellItemVisible = (resellText != null && !StringUtils.IsEmpty(resellText));
		if (base.ReSellItemVisible)
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById(resellText);
			base.ReSellTextData.SetContent(textById);
		}
	}

	// Token: 0x060117D0 RID: 71632 RVA: 0x004D024F File Offset: 0x004CE44F
	public void UpdateRaycastTarget()
	{
		base.RaycastTarget = true;
	}

	// Token: 0x060117D1 RID: 71633 RVA: 0x004D0258 File Offset: 0x004CE458
	public virtual void UpdateBottomBgVisible()
	{
		base.BottomBgVisible = true;
	}

	// Token: 0x060117D2 RID: 71634 RVA: 0x004D0261 File Offset: 0x004CE461
	public override void OnBuyButtonClick()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		GameplayShopUtil.OpenExchangePopView(this.GoodsData);
	}

	// Token: 0x060117D3 RID: 71635 RVA: 0x004D0278 File Offset: 0x004CE478
	public virtual void UpdateFromPayShopGoods(PayShopGoods payShopGoods)
	{
		this.GoodsData = payShopGoods;
		this.UpdatePriceData();
		this.UpdateItemName();
		this.UpdateDiscountData();
		this.UpdateLockData();
		this.UpdateSoldOutData();
		this.UpdateQualityData();
		this.UpdateItemIconData();
		this.UpdateBuyLimitCountText();
		this.UpdateRedDot();
		this.UpdateLabel();
		this.UpdateLeftTime();
		this.UpdateReSell();
		this.UpdateRaycastTarget();
		this.UpdateBottomBgVisible();
	}

	// Token: 0x0400892F RID: 35119
	private const string NORMALCOLOR = "FFEF6FFF";

	// Token: 0x04008930 RID: 35120
	private const string REDCOLOR = "F55E66FF";

	// Token: 0x04008931 RID: 35121
	[Nullable(2)]
	public PayShopGoods GoodsData;
}
