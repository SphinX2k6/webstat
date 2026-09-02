using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;

// Token: 0x0200149B RID: 5275
[NullableContext(1)]
[Nullable(0)]
public class PinballShopItemProxy : CommonGameplayShopItemProxy
{
	// Token: 0x17000C30 RID: 3120
	// (get) Token: 0x060093A4 RID: 37796 RVA: 0x0026FA8F File Offset: 0x0026DC8F
	// (set) Token: 0x060093A5 RID: 37797 RVA: 0x0026FA97 File Offset: 0x0026DC97
	public override string BigItemIconTexturePath { get; set; } = "";

	// Token: 0x17000C31 RID: 3121
	// (get) Token: 0x060093A6 RID: 37798 RVA: 0x0026FAA0 File Offset: 0x0026DCA0
	// (set) Token: 0x060093A7 RID: 37799 RVA: 0x0026FAA8 File Offset: 0x0026DCA8
	public override bool BigItemIconVisible { get; set; }

	// Token: 0x17000C32 RID: 3122
	// (get) Token: 0x060093A8 RID: 37800 RVA: 0x0026FAB1 File Offset: 0x0026DCB1
	// (set) Token: 0x060093A9 RID: 37801 RVA: 0x0026FAB9 File Offset: 0x0026DCB9
	public override bool ItemBgItemVisible { get; set; } = true;

	// Token: 0x060093AA RID: 37802 RVA: 0x0026FAC4 File Offset: 0x0026DCC4
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

	// Token: 0x060093AB RID: 37803 RVA: 0x0026FB08 File Offset: 0x0026DD08
	public override void UpdateItemIconData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		base.ItemId = this.GoodsData.GetGoodsData().ItemId;
	}

	// Token: 0x060093AC RID: 37804 RVA: 0x0026FB2C File Offset: 0x0026DD2C
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

	// Token: 0x060093AD RID: 37805 RVA: 0x0026FBB0 File Offset: 0x0026DDB0
	public new void UpdateBuyLimitCountText()
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

	// Token: 0x060093AE RID: 37806 RVA: 0x0026FBF8 File Offset: 0x0026DDF8
	public new void UpdateLabel()
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

	// Token: 0x060093AF RID: 37807 RVA: 0x0026FC5C File Offset: 0x0026DE5C
	public new void UpdateRedDot()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		bool ifNeedRemind = this.GoodsData.GetIfNeedRemind();
		base.RedDotVisible = ifNeedRemind;
	}

	// Token: 0x060093B0 RID: 37808 RVA: 0x0026FC88 File Offset: 0x0026DE88
	public new void UpdateLeftTime()
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

	// Token: 0x060093B1 RID: 37809 RVA: 0x0026FD20 File Offset: 0x0026DF20
	public new void UpdateReSell()
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

	// Token: 0x060093B2 RID: 37810 RVA: 0x0026FD78 File Offset: 0x0026DF78
	public override void OnBuyButtonClick()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		PinballShopExchangePopViewProxy pinballShopExchangePopViewProxy = new PinballShopExchangePopViewProxy();
		pinballShopExchangePopViewProxy.UpdateFromPayShopGoods(this.GoodsData);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballExchangePopView, pinballShopExchangePopViewProxy, null);
	}

	// Token: 0x060093B3 RID: 37811 RVA: 0x0026FDB4 File Offset: 0x0026DFB4
	public override void UpdateFromPayShopGoods(PayShopGoods payShopGoods)
	{
		this.GoodsData = payShopGoods;
		this.UpdatePriceData();
		this.UpdateItemName();
		base.UpdateDiscountData();
		base.UpdateLockData();
		this.UpdateSoldOutData();
		this.UpdateQualityData();
		this.UpdateItemIconData();
		this.UpdateBuyLimitCountText();
		this.UpdateRedDot();
		this.UpdateLabel();
		this.UpdateLeftTime();
		this.UpdateReSell();
		base.UpdateRaycastTarget();
		this.UpdateBottomBgVisible();
	}
}
