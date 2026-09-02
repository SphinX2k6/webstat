using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Ornament;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023D2 RID: 9170
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class OrnamentItemContent : GridProxyAbstract<OrnamentItemContentData>
{
	// Token: 0x06011B9F RID: 72607 RVA: 0x004DE344 File Offset: 0x004DC544
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUITexture)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUITexture)),
			new ValueTuple<int, Type>(15, typeof(UUITexture)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUITexture)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUITexture)),
			new ValueTuple<int, Type>(23, typeof(UUIText)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBuyButton))
		};
	}

	// Token: 0x06011BA0 RID: 72608 RVA: 0x004DE5FC File Offset: 0x004DC7FC
	private void OnClickBuyButton()
	{
		if (this.CurrentOrnamentData == null)
		{
			return;
		}
		PayShopGoods payShopGoods = this.CurrentOrnamentData.GetPayShopGoods();
		if (payShopGoods != null)
		{
			payShopGoods.SaveRemindState((long)Singleton<TimeUtil>.Instance.GetServerTime());
		}
		if (this.CurrentOrnamentData != null)
		{
			this.RefreshRedDotState(this.CurrentOrnamentData);
		}
		RoleOrnamentShowViewParams param = new RoleOrnamentShowViewParams
		{
			OrnamentId = this.CurrentOrnamentData.GetItemId(),
			BuyDetailData = this.CurrentOrnamentData
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleOrnamentShowView, param, null);
	}

	// Token: 0x06011BA1 RID: 72609 RVA: 0x004DE67C File Offset: 0x004DC87C
	[NullableContext(1)]
	public override void Refresh(OrnamentItemContentData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		this.CurrentOrnamentData = data.ShopRoleOrnamentData;
		this.RefreshRoleTexture(this.CurrentOrnamentData);
		this.RefreshBuyLimitText(this.CurrentOrnamentData);
		this.RefreshSubNameText(this.CurrentOrnamentData);
		this.RefreshNowPriceText(this.CurrentOrnamentData);
		this.RefreshSourcePriceText(this.CurrentOrnamentData);
		this.RefreshDiscountText(this.CurrentOrnamentData);
		this.RefreshBuyItemIcon(this.CurrentOrnamentData);
		this.RefreshBuyLimitItemState(this.CurrentOrnamentData);
		this.RefreshFinishBuyItemState(this.CurrentOrnamentData);
		this.RefreshRedDotState(this.CurrentOrnamentData);
		this.RefreshDiscountTimeText(this.CurrentOrnamentData);
		this.RefreshTextureBg(this.CurrentOrnamentData);
		this.RefreshTextureTopBg(this.CurrentOrnamentData);
		this.RefreshEffectItem(this.CurrentOrnamentData);
		this.RefreshExtraReward(this.CurrentOrnamentData);
		this.RefreshCouponItem(this.CurrentOrnamentData);
		this.RefreshSellTimeText(this.CurrentOrnamentData);
	}

	// Token: 0x06011BA2 RID: 72610 RVA: 0x004DE768 File Offset: 0x004DC968
	[NullableContext(1)]
	private void RefreshEffectItem(ShopRoleOrnamentData data)
	{
		base.GetItem(17).SetUIActive(false);
		base.GetItem(16).SetUIActive(false);
	}

	// Token: 0x06011BA3 RID: 72611 RVA: 0x004DE788 File Offset: 0x004DC988
	private void RefreshExtraReward(ShopRoleOrnamentData data)
	{
		UUIItem item = base.GetItem(21);
		if (data == null)
		{
			item.SetUIActive(false);
			return;
		}
		List<TItem> otherReward = data.GetOtherReward();
		TItem? titem = (otherReward.Count > 0) ? new TItem?(otherReward[0]) : null;
		if (titem == null)
		{
			item.SetUIActive(false);
			return;
		}
		int itemId = titem.Value.ItemData.ItemId;
		int count = titem.Value.Count;
		base.GetItem(27).SetUIActive(true);
		item.SetUIActive(true);
		base.SetItemIcon(base.GetTexture(22), itemId, null, null);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("x");
		defaultInterpolatedStringHandler.AppendFormatted<int>(count);
		string newText = defaultInterpolatedStringHandler.ToStringAndClear();
		base.GetText(23).SetText(newText, true);
	}

	// Token: 0x06011BA4 RID: 72612 RVA: 0x004DE86C File Offset: 0x004DCA6C
	[NullableContext(1)]
	private void RefreshRedDotState(ShopRoleOrnamentData data)
	{
		bool ifNeedRemind = data.GetCurrentGoodsData().GetIfNeedRemind();
		base.GetItem(13).SetUIActive(ifNeedRemind);
	}

	// Token: 0x06011BA5 RID: 72613 RVA: 0x004DE894 File Offset: 0x004DCA94
	[NullableContext(1)]
	private void RefreshBuyLimitItemState(ShopRoleOrnamentData data)
	{
		bool ifCanBuy = data.GetIfCanBuy();
		base.GetItem(11).SetUIActive(ifCanBuy);
	}

	// Token: 0x06011BA6 RID: 72614 RVA: 0x004DE8B8 File Offset: 0x004DCAB8
	[NullableContext(1)]
	private void RefreshFinishBuyItemState(ShopRoleOrnamentData data)
	{
		bool uiactive = !data.GetIfCanBuy();
		base.GetItem(12).SetUIActive(uiactive);
	}

	// Token: 0x06011BA7 RID: 72615 RVA: 0x004DE8E0 File Offset: 0x004DCAE0
	private void RefreshRoleTexture(ShopRoleOrnamentData data)
	{
		if (data == null)
		{
			base.GetTexture(1).SetUIActive(false);
			return;
		}
		string previewTextureInPayShop = data.GetPreviewTextureInPayShop();
		base.SetTextureByPath(previewTextureInPayShop, base.GetTexture(1), null, null);
	}

	// Token: 0x06011BA8 RID: 72616 RVA: 0x004DE920 File Offset: 0x004DCB20
	private void RefreshSourcePriceText(ShopRoleOrnamentData data)
	{
		if (data == null)
		{
			base.GetText(6).SetText("", true);
			return;
		}
		if (data.GetIfDirect())
		{
			base.GetText(6).SetUIActive(false);
			return;
		}
		int? originalPrice = data.GetPriceData().OriginalPrice;
		if (originalPrice == null)
		{
			base.GetText(6).SetUIActive(false);
			return;
		}
		base.GetText(6).SetUIActive(true);
		base.GetText(6).SetText("<s>" + originalPrice.ToString() + "</s>", true);
	}

	// Token: 0x06011BA9 RID: 72617 RVA: 0x004DE9B4 File Offset: 0x004DCBB4
	private void RefreshNowPriceText(ShopRoleOrnamentData data)
	{
		if (data == null)
		{
			base.GetText(5).SetText("", true);
			return;
		}
		if (data.GetIfDirect())
		{
			base.GetText(5).SetText(data.GetDirectPriceText(), true);
			return;
		}
		base.GetText(5).SetText(data.GetPriceData().NowPrice.ToString(), true);
	}

	// Token: 0x06011BAA RID: 72618 RVA: 0x004DEA14 File Offset: 0x004DCC14
	private void RefreshBuyItemIcon(ShopRoleOrnamentData data)
	{
		if (data == null)
		{
			base.GetTexture(10).SetUIActive(false);
			return;
		}
		bool ifDirect = data.GetIfDirect();
		base.GetTexture(10).SetUIActive(!ifDirect);
		if (!ifDirect)
		{
			IPriceData priceData = data.GetPriceData();
			base.SetItemIcon(base.GetTexture(10), priceData.CurrencyId, null, null);
		}
	}

	// Token: 0x06011BAB RID: 72619 RVA: 0x004DEA74 File Offset: 0x004DCC74
	[NullableContext(1)]
	private void RefreshBuyLimitText(ShopRoleOrnamentData data)
	{
		string shopTipsText = data.GetPayShopGoods().GetShopTipsText();
		base.GetText(3).SetText(shopTipsText, true);
	}

	// Token: 0x06011BAC RID: 72620 RVA: 0x004DEA9C File Offset: 0x004DCC9C
	[NullableContext(1)]
	private void RefreshSubNameText(ShopRoleOrnamentData data)
	{
		string titleName = data.GetTitleName();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), titleName, Array.Empty<object>());
	}

	// Token: 0x06011BAD RID: 72621 RVA: 0x004DEAC8 File Offset: 0x004DCCC8
	private void RefreshDiscountText(ShopRoleOrnamentData data)
	{
		if (data == null)
		{
			base.GetItem(7).SetUIActive(false);
			return;
		}
		string discountText = data.GetDiscountText();
		base.GetItem(7).SetUIActive(discountText != "");
		base.GetText(8).SetText(discountText, true);
	}

	// Token: 0x06011BAE RID: 72622 RVA: 0x004DEB14 File Offset: 0x004DCD14
	private void RefreshTextureBg(ShopRoleOrnamentData data)
	{
		if (data == null)
		{
			base.GetTexture(14).SetUIActive(false);
			return;
		}
		string resourceId = "T_ShopRoleItemBg";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureByPath(resourcePath, base.GetTexture(14), null, null);
	}

	// Token: 0x06011BAF RID: 72623 RVA: 0x004DEB60 File Offset: 0x004DCD60
	private void RefreshTextureTopBg(ShopRoleOrnamentData data)
	{
		if (data == null)
		{
			base.GetTexture(15).SetUIActive(false);
			return;
		}
		string resourceId = "T_ShopRoleItemTopBg";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureByPath(resourcePath, base.GetTexture(15), null, null);
	}

	// Token: 0x06011BB0 RID: 72624 RVA: 0x004DEBAC File Offset: 0x004DCDAC
	private void RefreshDiscountTimeText(ShopRoleOrnamentData data)
	{
		if (data == null)
		{
			base.GetItem(7).SetUIActive(false);
			return;
		}
		object discountTimeData = data.GetDiscountTimeData();
		if (discountTimeData == null)
		{
			base.GetItem(7).SetUIActive(false);
			return;
		}
		base.GetItem(7).SetUIActive(true);
		UUIText text = base.GetText(9);
		Singleton<LguiUtil>.Instance.SetLocalText(text, ((CommonDefine.IRemainTime)discountTimeData).TextId, new <>z__ReadOnlySingleElementList<object>(((CommonDefine.IRemainTime)discountTimeData).TimeValue));
	}

	// Token: 0x06011BB1 RID: 72625 RVA: 0x004DEC24 File Offset: 0x004DCE24
	private void RefreshCouponItem(ShopRoleOrnamentData data)
	{
		UUIItem item = base.GetItem(18);
		if (data == null)
		{
			item.SetUIActive(false);
			return;
		}
		CommonItemData availableCouponItem = data.GetCurrentGoodsData().GetAvailableCouponItem();
		if (availableCouponItem == null)
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		int availableCouponDiscount = data.GetCurrentGoodsData().GetAvailableCouponDiscount();
		UUIText text = base.GetText(19);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("-");
		defaultInterpolatedStringHandler.AppendFormatted<int>(availableCouponDiscount);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.SetTextureByPath(availableCouponItem.GetConfig().As<ItemInfo>().Value.IconSmall, base.GetTexture(20), null, null);
	}

	// Token: 0x06011BB2 RID: 72626 RVA: 0x004DECD8 File Offset: 0x004DCED8
	private void RefreshSellTimeText(ShopRoleOrnamentData data)
	{
		UUIText text = base.GetText(9);
		if (data == null)
		{
			text.SetUIActive(false);
			return;
		}
		PayShopGoods currentGoodsData = data.GetCurrentGoodsData();
		if (currentGoodsData.HasDiscount())
		{
			return;
		}
		if (!currentGoodsData.InUnPermanentSellTime())
		{
			text.SetUIActive(false);
			return;
		}
		base.GetItem(24).SetUIActive(false);
		base.GetItem(7).SetUIActive(true);
		text.SetUIActive(true);
		CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = (CommonDefine.PayShowCountDownRemainTime<string>)currentGoodsData.GetEndTimeRemainData();
		text.SetText(payShowCountDownRemainTime.Value, true);
	}

	// Token: 0x04008AC9 RID: 35529
	private OrnamentItemContentData CurrentData;

	// Token: 0x04008ACA RID: 35530
	private ShopRoleOrnamentData CurrentOrnamentData;

	// Token: 0x02008705 RID: 34565
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DA9C RID: 187036
		BuyButton,
		// Token: 0x0402DA9D RID: 187037
		RoleTexture,
		// Token: 0x0402DA9E RID: 187038
		TextureWeapon,
		// Token: 0x0402DA9F RID: 187039
		BuyLimitText,
		// Token: 0x0402DAA0 RID: 187040
		SubNameText,
		// Token: 0x0402DAA1 RID: 187041
		NowPrice,
		// Token: 0x0402DAA2 RID: 187042
		BeforePrice,
		// Token: 0x0402DAA3 RID: 187043
		DiscountItem,
		// Token: 0x0402DAA4 RID: 187044
		DiscountText,
		// Token: 0x0402DAA5 RID: 187045
		TimeText,
		// Token: 0x0402DAA6 RID: 187046
		BuyItemIcon,
		// Token: 0x0402DAA7 RID: 187047
		LimitBuyItem,
		// Token: 0x0402DAA8 RID: 187048
		FinishBuyItem,
		// Token: 0x0402DAA9 RID: 187049
		NewItem,
		// Token: 0x0402DAAA RID: 187050
		TextureBg,
		// Token: 0x0402DAAB RID: 187051
		TextureTopBg,
		// Token: 0x0402DAAC RID: 187052
		EffectBItem,
		// Token: 0x0402DAAD RID: 187053
		EffectAItem,
		// Token: 0x0402DAAE RID: 187054
		ItemCoupon,
		// Token: 0x0402DAAF RID: 187055
		TextCoupon,
		// Token: 0x0402DAB0 RID: 187056
		TextureCoupon,
		// Token: 0x0402DAB1 RID: 187057
		ExtraItemRoot,
		// Token: 0x0402DAB2 RID: 187058
		TextureExtraReward,
		// Token: 0x0402DAB3 RID: 187059
		TextExtraReward,
		// Token: 0x0402DAB4 RID: 187060
		ItemDiscountSprite,
		// Token: 0x0402DAB5 RID: 187061
		ItemTypeRoot,
		// Token: 0x0402DAB6 RID: 187062
		TextureItemType,
		// Token: 0x0402DAB7 RID: 187063
		ItemRewardRoot
	}
}
