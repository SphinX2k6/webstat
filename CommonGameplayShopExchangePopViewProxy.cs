using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;

// Token: 0x02002395 RID: 9109
[NullableContext(1)]
[Nullable(0)]
public class CommonGameplayShopExchangePopViewProxy : AbstractGameplayShopExchangePopViewProxy
{
	// Token: 0x060117B2 RID: 71602 RVA: 0x004CF86C File Offset: 0x004CDA6C
	public virtual void UpdateShopItemData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		CommonGameplayExchangeShopItemProxy commonGameplayExchangeShopItemProxy = new CommonGameplayExchangeShopItemProxy();
		commonGameplayExchangeShopItemProxy.UpdateFromPayShopGoods(this.GoodsData);
		base.ShopItemProxy = commonGameplayExchangeShopItemProxy;
		this.UpdateShopItemResource();
	}

	// Token: 0x060117B3 RID: 71603 RVA: 0x004CF8A1 File Offset: 0x004CDAA1
	public virtual void UpdateShopItemResource()
	{
		base.ShopItemResource = "UiItem_ShopItem";
	}

	// Token: 0x060117B4 RID: 71604 RVA: 0x004CF8B0 File Offset: 0x004CDAB0
	public virtual void UpdateTipTitleItem()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		string buyLimitText = this.GoodsData.GetBuyLimitText();
		base.TipTitleItemVisible = !StringUtils.IsEmpty(buyLimitText);
	}

	// Token: 0x060117B5 RID: 71605 RVA: 0x004CF8E4 File Offset: 0x004CDAE4
	public void UpdateCurrency()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		int currencyId = this.GoodsData.GetPriceData().CurrencyId;
		base.CurrencyId = currencyId;
		base.CurrencyIdList = new List<int>
		{
			currencyId
		};
	}

	// Token: 0x060117B6 RID: 71606 RVA: 0x004CF924 File Offset: 0x004CDB24
	public void UpdatePrice()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		int nowPrice = this.GoodsData.GetGoodsData().GetNowPrice();
		base.Price = nowPrice;
	}

	// Token: 0x060117B7 RID: 71607 RVA: 0x004CF954 File Offset: 0x004CDB54
	public void UpdateDescribeText()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		TableTextArgNew data = new TableTextArgNew(ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.GoodsData.GetGoodsData().ItemId).AttributesDescription, Array.Empty<object>());
		base.DescribeTextData.SetData(data);
	}

	// Token: 0x060117B8 RID: 71608 RVA: 0x004CF9A0 File Offset: 0x004CDBA0
	public void UpdateLeftTime()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> countDownData = this.GoodsData.GetCountDownData();
		if (countDownData.Item3 == 0.0)
		{
			base.LeftTimeItemVisible = false;
			return;
		}
		base.LeftTimeTextVisible = (countDownData.Item1 == EPayCountTimeType.NeverResell);
		if (base.LeftTimeTextVisible)
		{
			base.LeftTimeTextData.SetData(new TableTextArgNew("DownShopItem", Array.Empty<object>()));
		}
		CommonDefine.IPayShowCountDownRemainTime item = countDownData.Item2;
		bool flag = item != null;
		base.LeftTimeItemVisible = flag;
		if (flag)
		{
			CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = item as CommonDefine.PayShowCountDownRemainTime<string>;
			if (payShowCountDownRemainTime != null)
			{
				base.LeftTimeTextData.SetContent(payShowCountDownRemainTime.Value);
				return;
			}
			CommonDefine.IRemainTime remainTime = item as CommonDefine.IRemainTime;
			if (remainTime != null)
			{
				base.LeftTimeTextData.SetData(new TableTextArgNew(remainTime.TextId, new <>z__ReadOnlySingleElementList<object>(remainTime.TimeValue)));
			}
		}
	}

	// Token: 0x060117B9 RID: 71609 RVA: 0x004CFA74 File Offset: 0x004CDC74
	public void UpdateLockData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		if (this.GoodsData.GetIfNeedExtraLimitText())
		{
			string extraLimitText = this.GoodsData.GetExtraLimitText();
			if (extraLimitText != null)
			{
				base.LockItemVisible = true;
				base.LockTextData.SetData(new TableTextArgNew(extraLimitText, Array.Empty<object>()));
				return;
			}
			base.LockItemVisible = false;
			return;
		}
		else if (!this.CheckMoneyEnough())
		{
			base.LockItemVisible = true;
			string exchangePopViewResellText = this.GoodsData.GetExchangePopViewResellText();
			if (!StringUtils.IsEmpty(exchangePopViewResellText))
			{
				base.LockTextData.SetData(new TableTextArgNew(exchangePopViewResellText, Array.Empty<object>()));
				return;
			}
			string currencyName = this.GetCurrencyName();
			base.LockTextData.SetData(new TableTextArgNew("CurrencyNotEnough", new <>z__ReadOnlySingleElementList<object>(currencyName)));
			return;
		}
		else
		{
			if (this.GoodsData.GetCountDownData().Item2 == null)
			{
				base.LockItemVisible = false;
				return;
			}
			string exchangePopViewResellText2 = this.GoodsData.GetExchangePopViewResellText();
			if (!StringUtils.IsEmpty(exchangePopViewResellText2))
			{
				base.LockItemVisible = true;
				base.LockTextData.SetData(new TableTextArgNew(exchangePopViewResellText2, Array.Empty<object>()));
				return;
			}
			base.LockItemVisible = false;
			return;
		}
	}

	// Token: 0x060117BA RID: 71610 RVA: 0x004CFB7C File Offset: 0x004CDD7C
	private string GetCurrencyName()
	{
		if (this.GoodsData == null)
		{
			return "";
		}
		int currencyId = this.GoodsData.GetPriceData().CurrencyId;
		return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InventoryConfig>.Instance.GetItemConfigData(currencyId).Name, null) ?? "";
	}

	// Token: 0x060117BB RID: 71611 RVA: 0x004CFBC7 File Offset: 0x004CDDC7
	public void UpdateFromPayShopGoods(PayShopGoods payShopGoods)
	{
		this.GoodsData = payShopGoods;
		this.UpdateShopItemData();
		this.UpdateTipTitleItem();
		this.UpdateCurrency();
		this.UpdatePrice();
		this.UpdateDescribeText();
		this.UpdateLeftTime();
		this.UpdateLockData();
	}

	// Token: 0x060117BC RID: 71612 RVA: 0x004CFBFC File Offset: 0x004CDDFC
	public override void OnConfirmButtonClick(int viewId)
	{
		if (this.GoodsData == null)
		{
			return;
		}
		if (!this.CheckMoneyEnough())
		{
			PayShopGoodsData goodsData = this.GoodsData.GetGoodsData();
			TableTextArgNew tableTextArgNew = new TableTextArgNew(ConfigBase<InventoryConfig>.Instance.GetItemConfigData(goodsData.Price.Id).Name, Array.Empty<object>());
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ShopResourceNotEnough", new object[]
			{
				tableTextArgNew
			});
			return;
		}
		this.SendBuyRequest(delegate(bool buySuccess, [Nullable(new byte[]
		{
			2,
			1
		})] List<ActivityBuyItem> buyFailedItems)
		{
			if (buySuccess)
			{
				Singleton<UiManager>.Instance.CloseViewById(viewId, null);
			}
		});
	}

	// Token: 0x060117BD RID: 71613 RVA: 0x004CFC84 File Offset: 0x004CDE84
	protected void SendBuyRequest([Nullable(new byte[]
	{
		2,
		2,
		1
	})] Action<bool, List<ActivityBuyItem>> callBack = null)
	{
		if (this.GoodsData == null)
		{
			return;
		}
		PayShopGoodsData goodsData = this.GoodsData.GetGoodsData();
		List<ActivityBuyItem> list = new List<ActivityBuyItem>();
		ActivityBuyItem activityBuyItem = ActivityBuyItem.Create();
		activityBuyItem.Id = goodsData.Id;
		activityBuyItem.Count = base.BuyCount;
		list.Add(activityBuyItem);
		ControllerBase<PayShopController>.Instance.ActivityPayShopBuyRequest(list, callBack);
	}

	// Token: 0x060117BE RID: 71614 RVA: 0x004CFCE0 File Offset: 0x004CDEE0
	public override bool CheckConfirmButtonCanInteract()
	{
		if (this.GoodsData == null)
		{
			return false;
		}
		bool flag = this.GoodsData.IfCanBuy();
		bool enough = this.GoodsData.GetPriceData().Enough;
		bool flag2 = this.GoodsData.IsLocked();
		bool flag3 = this.GoodsData.IsSoldOut();
		return flag && enough && !flag2 && !flag3;
	}

	// Token: 0x060117BF RID: 71615 RVA: 0x004CFD38 File Offset: 0x004CDF38
	public override UiPanelBase ShopItemCreate()
	{
		this.ShopItem = new GameplayShopItem();
		return this.ShopItem;
	}

	// Token: 0x060117C0 RID: 71616 RVA: 0x004CFD4B File Offset: 0x004CDF4B
	public override void ShopItemRefresh()
	{
		if (this.ShopItem == null || base.ShopItemProxy == null)
		{
			return;
		}
		GameplayShopItem gameplayShopItem = this.ShopItem as GameplayShopItem;
		if (gameplayShopItem == null)
		{
			return;
		}
		gameplayShopItem.RefreshByData((IGameplayShopItemProxy)base.ShopItemProxy);
	}

	// Token: 0x060117C1 RID: 71617 RVA: 0x004CFD80 File Offset: 0x004CDF80
	public override bool CheckMoneyEnough()
	{
		if (this.GoodsData == null)
		{
			return false;
		}
		PayShopGoodsData goodsData = this.GoodsData.GetGoodsData();
		int id = goodsData.Price.Id;
		return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(id, 0) >= goodsData.GetNowPrice() * base.BuyCount;
	}

	// Token: 0x060117C2 RID: 71618 RVA: 0x004CFDCD File Offset: 0x004CDFCD
	public override void OnResellTimeRefresh()
	{
	}

	// Token: 0x0400892D RID: 35117
	[Nullable(2)]
	protected PayShopGoods GoodsData;

	// Token: 0x0400892E RID: 35118
	[Nullable(2)]
	public UiPanelBase ShopItem;
}
