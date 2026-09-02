using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Shop;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;

// Token: 0x0200149A RID: 5274
[NullableContext(1)]
[Nullable(0)]
public class PinballShopExchangePopViewProxy : AbstractGameplayShopExchangePopViewProxy
{
	// Token: 0x0600938F RID: 37775 RVA: 0x0026F3EC File Offset: 0x0026D5EC
	public void UpdateShopItemData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		PinballExchangeShopItemProxy pinballExchangeShopItemProxy = new PinballExchangeShopItemProxy();
		pinballExchangeShopItemProxy.UpdateFromPayShopGoods(this.GoodsData);
		base.ShopItemProxy = pinballExchangeShopItemProxy;
	}

	// Token: 0x06009390 RID: 37776 RVA: 0x0026F41B File Offset: 0x0026D61B
	public void UpdateShopItemResource()
	{
		base.ShopItemResource = "UiItem_CatapultStoryShopItem";
	}

	// Token: 0x06009391 RID: 37777 RVA: 0x0026F428 File Offset: 0x0026D628
	public void UpdateTipTitleItem()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		string buyLimitText = this.GoodsData.GetBuyLimitText();
		base.TipTitleItemVisible = !StringUtils.IsEmpty(buyLimitText);
		if (base.TipTitleItemVisible)
		{
			base.LimitTextData.SetData(new TableTextArgNew(buyLimitText, Array.Empty<object>()));
		}
	}

	// Token: 0x06009392 RID: 37778 RVA: 0x0026F478 File Offset: 0x0026D678
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
		base.CurrencyItemResourceId = "UiItem_CostBtn";
	}

	// Token: 0x06009393 RID: 37779 RVA: 0x0026F4C4 File Offset: 0x0026D6C4
	public void UpdatePrice()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		int nowPrice = this.GoodsData.GetGoodsData().GetNowPrice();
		base.Price = nowPrice;
	}

	// Token: 0x06009394 RID: 37780 RVA: 0x0026F4F4 File Offset: 0x0026D6F4
	public void UpdateDescribeText()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		string attributesDescription = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.GoodsData.GetGoodsData().ItemId).AttributesDescription;
		base.DescribeTextData.SetData(new TableTextArgNew(attributesDescription, Array.Empty<object>()));
	}

	// Token: 0x06009395 RID: 37781 RVA: 0x0026F540 File Offset: 0x0026D740
	public void UpdateLeftTime()
	{
		base.LeftTimeItemVisible = false;
		base.LeftTimeTextVisible = false;
	}

	// Token: 0x06009396 RID: 37782 RVA: 0x0026F550 File Offset: 0x0026D750
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

	// Token: 0x06009397 RID: 37783 RVA: 0x0026F658 File Offset: 0x0026D858
	private string GetCurrencyName()
	{
		if (this.GoodsData == null)
		{
			return "";
		}
		int currencyId = this.GoodsData.GetPriceData().CurrencyId;
		return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InventoryConfig>.Instance.GetItemConfigData(currencyId).Name, null) ?? "";
	}

	// Token: 0x06009398 RID: 37784 RVA: 0x0026F6A4 File Offset: 0x0026D8A4
	public void UpdateLimitTextData()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		string buyLimitText = this.GoodsData.GetBuyLimitText();
		base.LimitTextItemVisible = !StringUtils.IsEmpty(buyLimitText);
		if (base.LimitTextItemVisible)
		{
			base.LimitTextData.SetContent(buyLimitText);
		}
	}

	// Token: 0x06009399 RID: 37785 RVA: 0x0026F6EC File Offset: 0x0026D8EC
	public void UpdateFromPayShopGoods(PayShopGoods payShopGoods)
	{
		this.GoodsData = payShopGoods;
		this.UpdateShopItemData();
		this.UpdateShopItemResource();
		this.UpdateTipTitleItem();
		this.UpdateCurrency();
		this.UpdatePrice();
		this.UpdateDescribeText();
		this.UpdateLeftTime();
		this.UpdateLimitTextData();
		this.UpdateLockData();
		this.UpdateMaxBuyCount();
		this.UpdateExchangeTableTextId();
	}

	// Token: 0x0600939A RID: 37786 RVA: 0x0026F744 File Offset: 0x0026D944
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

	// Token: 0x0600939B RID: 37787 RVA: 0x0026F7CC File Offset: 0x0026D9CC
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
		PayShopBuyRequest payShopBuyRequest = PayShopBuyRequest.Create();
		payShopBuyRequest.Id = goodsData.Id;
		payShopBuyRequest.Count = base.BuyCount;
		payShopBuyRequest.Version = ModelBase<PayShopModel>.Instance.Version;
		Singleton<Net>.Instance.Call<PayShopBuyResponse>(ERequestMessageId.PayShopBuyRequest, payShopBuyRequest, delegate(PayShopBuyResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				Action<bool, List<ActivityBuyItem>> callBack2 = callBack;
				if (callBack2 == null)
				{
					return;
				}
				callBack2(false, null);
				return;
			}
			else if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				ModelBase<PayShopModel>.Instance.UpdatePayShopGoodsCount(response.Id, response.Count);
				List<ActivityBuyItem> p = new List<ActivityBuyItem>
				{
					new ActivityBuyItem
					{
						Id = response.Id,
						Count = response.Count
					}
				};
				Singleton<EventSystem>.Instance.Emit<int, IReadOnlyList<ActivityBuyItem>, string>(EEventName.ActivityPayShopGoodsBuy, goodsData.ShopId, p, ModelBase<PayShopModel>.Instance.Version);
				Singleton<EventSystem>.Instance.Emit(EEventName.PayShopGoodsBuy);
				Action<bool, List<ActivityBuyItem>> callBack3 = callBack;
				if (callBack3 == null)
				{
					return;
				}
				callBack3(true, null);
				return;
			}
			else
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23114, null, true, true);
				Action<bool, List<ActivityBuyItem>> callBack4 = callBack;
				if (callBack4 == null)
				{
					return;
				}
				callBack4(false, null);
				return;
			}
		}, 0);
	}

	// Token: 0x0600939C RID: 37788 RVA: 0x0026F850 File Offset: 0x0026DA50
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

	// Token: 0x0600939D RID: 37789 RVA: 0x0026F8A8 File Offset: 0x0026DAA8
	public override UiPanelBase ShopItemCreate()
	{
		this.ShopItem = new PinballShopItem();
		return this.ShopItem;
	}

	// Token: 0x0600939E RID: 37790 RVA: 0x0026F8BC File Offset: 0x0026DABC
	public override void ShopItemRefresh()
	{
		PinballShopItem pinballShopItem = this.ShopItem as PinballShopItem;
		PinballExchangeShopItemProxy pinballExchangeShopItemProxy = base.ShopItemProxy as PinballExchangeShopItemProxy;
		if (pinballShopItem == null || pinballExchangeShopItemProxy == null)
		{
			return;
		}
		pinballShopItem.RefreshByData(pinballExchangeShopItemProxy);
		pinballShopItem.HideItemCost();
		pinballShopItem.SetItemFrameVisible(false);
	}

	// Token: 0x0600939F RID: 37791 RVA: 0x0026F8FC File Offset: 0x0026DAFC
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

	// Token: 0x060093A0 RID: 37792 RVA: 0x0026F949 File Offset: 0x0026DB49
	public override void OnResellTimeRefresh()
	{
		this.UpdateLeftTime();
		this.UpdateLockData();
	}

	// Token: 0x060093A1 RID: 37793 RVA: 0x0026F958 File Offset: 0x0026DB58
	public void UpdateMaxBuyCount()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		PayShopGoodsData goodsData = this.GoodsData.GetGoodsData();
		if (goodsData == null)
		{
			return;
		}
		int id = goodsData.Price.Id;
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(id, 0);
		int nowPrice = goodsData.GetNowPrice();
		int num = (nowPrice > 0) ? (itemCountByConfigId / nowPrice) : int.MaxValue;
		int num2;
		if (goodsData.HasBuyLimit())
		{
			num2 = Math.Min(goodsData.GetRemainingCount(), num);
		}
		else
		{
			num2 = num;
		}
		if (goodsData.HasOnceBuyLimit())
		{
			num2 = Math.Min(num2, goodsData.OnceBuyLimit);
		}
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(goodsData.ItemId);
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(goodsData.ItemId));
		if (itemConfigData != null && itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleItem && itemConfigData.ShowTypes.Contains(30))
		{
			num2 = 1;
		}
		if (itemConfigData.ShowTypes.Contains(30))
		{
			int[] resonantItemRoleId = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(goodsData.ItemId);
			int num3 = ModelBase<RoleModel>.Instance.GetRoleLeftResonantCountWithInventoryItem(resonantItemRoleId[0]);
			num3 = ((num3 == 0) ? 1 : num3);
			num2 = ((num2 > num3) ? num3 : num2);
		}
		base.MaxBuyCount = num2;
	}

	// Token: 0x060093A2 RID: 37794 RVA: 0x0026FA7A File Offset: 0x0026DC7A
	public void UpdateExchangeTableTextId()
	{
		base.ExchangeTableTextId = "";
	}

	// Token: 0x04004444 RID: 17476
	[Nullable(2)]
	protected PayShopGoods GoodsData;

	// Token: 0x04004445 RID: 17477
	[Nullable(2)]
	public UiPanelBase ShopItem;
}
