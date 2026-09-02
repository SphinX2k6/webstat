using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023CF RID: 9167
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FlySkinItemContent : GridProxyAbstract<FlySkinItemContentData>
{
	// Token: 0x06011B83 RID: 72579 RVA: 0x004DD8C8 File Offset: 0x004DBAC8
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
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUITexture)),
			new ValueTuple<int, Type>(23, typeof(UUIText)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUITexture)),
			new ValueTuple<int, Type>(27, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBuyButton))
		};
	}

	// Token: 0x06011B84 RID: 72580 RVA: 0x004DDB24 File Offset: 0x004DBD24
	private void OnClickBuyButton()
	{
		List<PayShopGoods> allData = this.CurrentShopFlySkinData.AllData;
		List<ShopFlySkinData> list = new List<ShopFlySkinData>();
		int count = allData.Count;
		for (int i = 0; i < count; i++)
		{
			ShopFlySkinData item = ShopFlySkinData.Create(allData[i]);
			list.Add(item);
		}
		FlySkinBuyDetailViewData flySkinBuyDetailViewData = FlySkinBuyDetailViewData.Create(list);
		flySkinBuyDetailViewData.SetIndex(this.CurrentIndex);
		flySkinBuyDetailViewData.SetPreviewTitle("FlySkinShopTitle_Text");
		PayShopGoods payShopGoods = list[this.CurrentIndex].GetPayShopGoods();
		OnClickPayShopItemLogEvent onClickPayShopItemLogEvent = new OnClickPayShopItemLogEvent();
		onClickPayShopItemLogEvent.i_id = payShopGoods.GetGoodsId();
		onClickPayShopItemLogEvent.i_shop_id = (int)payShopGoods.PayShopId;
		onClickPayShopItemLogEvent.i_tab_id = payShopGoods.GetGoodsData().TabId;
		ControllerBase<LogReportController>.Instance.LogReport(onClickPayShopItemLogEvent);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FlySkinBuyDetailView, flySkinBuyDetailViewData, null);
	}

	// Token: 0x06011B85 RID: 72581 RVA: 0x004DDBF8 File Offset: 0x004DBDF8
	[NullableContext(1)]
	public override void Refresh(FlySkinItemContentData data, bool isSelected, int gridIndex)
	{
		ShopFlySkinData shopFlySkinData = data.ShopFlySkinData;
		this.CurrentShopFlySkinData = data;
		this.CurrentIndex = gridIndex;
		this.RefreshRoleTexture(shopFlySkinData);
		this.RefreshWeaponTexture();
		this.RefreshBuyLimitText(shopFlySkinData);
		this.RefreshSubNameText(shopFlySkinData);
		this.RefreshNowPriceText(shopFlySkinData);
		this.RefreshSourcePriceText(shopFlySkinData);
		this.RefreshDiscountTimeText(shopFlySkinData);
		this.RefreshDiscountText(shopFlySkinData);
		this.RefreshBuyItemIcon(shopFlySkinData);
		this.RefreshBuyLimitItemState(shopFlySkinData);
		this.RefreshFinishBuyItemState(shopFlySkinData);
		this.RefreshRedDotState(shopFlySkinData);
		this.RefreshTextureBg(shopFlySkinData);
		this.RefreshTextureTopBg(shopFlySkinData);
		this.RefreshEffectItem(shopFlySkinData);
		this.RefreshExtraReward(shopFlySkinData);
	}

	// Token: 0x06011B86 RID: 72582 RVA: 0x004DDC8C File Offset: 0x004DBE8C
	[NullableContext(1)]
	private void RefreshEffectItem(ShopFlySkinData data)
	{
		bool uiactive = data.GetFlySkinData().GetSkinGrade() == 1;
		base.GetItem(17).SetUIActive(uiactive);
		base.GetItem(16).SetUIActive(uiactive);
	}

	// Token: 0x06011B87 RID: 72583 RVA: 0x004DDCC4 File Offset: 0x004DBEC4
	[NullableContext(1)]
	private void RefreshRedDotState(ShopFlySkinData data)
	{
		bool ifNeedRemind = data.GetCurrentGoodsData().GetIfNeedRemind();
		base.GetItem(13).SetUIActive(ifNeedRemind);
	}

	// Token: 0x06011B88 RID: 72584 RVA: 0x004DDCEC File Offset: 0x004DBEEC
	[NullableContext(1)]
	private void RefreshBuyLimitItemState(ShopFlySkinData data)
	{
		bool ifCanBuy = data.GetIfCanBuy();
		base.GetItem(11).SetUIActive(ifCanBuy);
	}

	// Token: 0x06011B89 RID: 72585 RVA: 0x004DDD10 File Offset: 0x004DBF10
	[NullableContext(1)]
	private void RefreshFinishBuyItemState(ShopFlySkinData data)
	{
		bool uiactive = !data.GetIfCanBuy();
		base.GetItem(12).SetUIActive(uiactive);
	}

	// Token: 0x06011B8A RID: 72586 RVA: 0x004DDD38 File Offset: 0x004DBF38
	[NullableContext(1)]
	private void RefreshRoleTexture(ShopFlySkinData data)
	{
		string previewTextureInPayShop = data.GetPreviewTextureInPayShop();
		base.SetTextureByPath(previewTextureInPayShop, base.GetTexture(1), null, null);
	}

	// Token: 0x06011B8B RID: 72587 RVA: 0x004DDD64 File Offset: 0x004DBF64
	private void RefreshWeaponTexture()
	{
		UUITexture texture = base.GetTexture(2);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(false);
	}

	// Token: 0x06011B8C RID: 72588 RVA: 0x004DDD78 File Offset: 0x004DBF78
	private void RefreshSourcePriceText(ShopFlySkinData data)
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

	// Token: 0x06011B8D RID: 72589 RVA: 0x004DDE0C File Offset: 0x004DC00C
	private void RefreshNowPriceText(ShopFlySkinData data)
	{
		if (data == null)
		{
			base.GetText(5).SetText("", true);
			return;
		}
		if (data.GetIfDirect())
		{
			string directPriceText = data.GetDirectPriceText();
			base.GetText(5).SetText(directPriceText, true);
			return;
		}
		int nowPrice = data.GetPriceData().NowPrice;
		base.GetText(5).SetText(nowPrice.ToString(), true);
	}

	// Token: 0x06011B8E RID: 72590 RVA: 0x004DDE70 File Offset: 0x004DC070
	private void RefreshBuyItemIcon(ShopFlySkinData data)
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

	// Token: 0x06011B8F RID: 72591 RVA: 0x004DDED0 File Offset: 0x004DC0D0
	[NullableContext(1)]
	private void RefreshBuyLimitText(ShopFlySkinData data)
	{
		string shopTipsText = data.GetPayShopGoods().GetShopTipsText();
		base.GetText(3).SetText(shopTipsText, true);
	}

	// Token: 0x06011B90 RID: 72592 RVA: 0x004DDEF8 File Offset: 0x004DC0F8
	[NullableContext(1)]
	private void RefreshSubNameText(ShopFlySkinData data)
	{
		string name = data.GetPayShopGoods().GetItemData().Name;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), name, Array.Empty<object>());
	}

	// Token: 0x06011B91 RID: 72593 RVA: 0x004DDF30 File Offset: 0x004DC130
	private void RefreshDiscountTimeText(ShopFlySkinData data)
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
		string text2 = discountTimeData as string;
		if (text2 != null)
		{
			text.SetText(text2, true);
			return;
		}
		CommonDefine.IRemainTime remainTime = discountTimeData as CommonDefine.IRemainTime;
		if (remainTime != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, remainTime.TextId, new <>z__ReadOnlySingleElementList<object>(remainTime.TimeValue));
		}
	}

	// Token: 0x06011B92 RID: 72594 RVA: 0x004DDFBC File Offset: 0x004DC1BC
	private void RefreshDiscountText(ShopFlySkinData data)
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

	// Token: 0x06011B93 RID: 72595 RVA: 0x004DE008 File Offset: 0x004DC208
	private void RefreshTextureBg(ShopFlySkinData data)
	{
		if (data == null)
		{
			base.GetTexture(14).SetUIActive(false);
			return;
		}
		string resourceId = (data.GetFlySkinData().GetSkinGrade() == 1) ? "T_ShopRoleItemBg1" : "T_ShopRoleItemBg";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureByPath(resourcePath, base.GetTexture(14), null, null);
	}

	// Token: 0x06011B94 RID: 72596 RVA: 0x004DE06C File Offset: 0x004DC26C
	private void RefreshTextureTopBg(ShopFlySkinData data)
	{
		if (data == null)
		{
			base.GetTexture(15).SetUIActive(false);
			return;
		}
		string resourceId = (data.GetFlySkinData().GetSkinGrade() == 1) ? "T_ShopRoleItemTopBg1" : "T_ShopRoleItemTopBg";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureByPath(resourcePath, base.GetTexture(15), null, null);
	}

	// Token: 0x06011B95 RID: 72597 RVA: 0x004DE0D0 File Offset: 0x004DC2D0
	private void RefreshExtraReward(ShopFlySkinData data)
	{
		UUITexture texture = base.GetTexture(26);
		UUIItem item = base.GetItem(25);
		texture.SetUIActive(true);
		item.SetUIActive(true);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_UiShopSkinIcon_Fly");
		base.SetTextureByPath(resourcePath, texture, null, null);
		UUIItem item2 = base.GetItem(21);
		if (data == null)
		{
			item2.SetUIActive(false);
			return;
		}
		List<TItem> otherReward = data.GetOtherReward();
		TItem? titem = (otherReward.Count > 0) ? new TItem?(otherReward[0]) : null;
		if (titem == null)
		{
			item2.SetUIActive(false);
			return;
		}
		int itemId = titem.Value.ItemData.ItemId;
		int count = titem.Value.Count;
		base.GetItem(27).SetUIActive(true);
		item2.SetUIActive(true);
		base.SetItemIcon(base.GetTexture(22), itemId, null, null);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("x");
		defaultInterpolatedStringHandler.AppendFormatted<int>(count);
		string newText = defaultInterpolatedStringHandler.ToStringAndClear();
		base.GetText(23).SetText(newText, true);
	}

	// Token: 0x04008AC2 RID: 35522
	private FlySkinItemContentData CurrentShopFlySkinData;

	// Token: 0x04008AC3 RID: 35523
	private int CurrentIndex;

	// Token: 0x02008703 RID: 34563
	[NullableContext(0)]
	private enum ESkinItemComponent
	{
		// Token: 0x0402DA80 RID: 187008
		BuyButton,
		// Token: 0x0402DA81 RID: 187009
		RoleTexture,
		// Token: 0x0402DA82 RID: 187010
		TextureWeapon,
		// Token: 0x0402DA83 RID: 187011
		BuyLimitText,
		// Token: 0x0402DA84 RID: 187012
		SubNameText,
		// Token: 0x0402DA85 RID: 187013
		NowPrice,
		// Token: 0x0402DA86 RID: 187014
		BeforePrice,
		// Token: 0x0402DA87 RID: 187015
		DiscountItem,
		// Token: 0x0402DA88 RID: 187016
		DiscountText,
		// Token: 0x0402DA89 RID: 187017
		TimeText,
		// Token: 0x0402DA8A RID: 187018
		BuyItemIcon,
		// Token: 0x0402DA8B RID: 187019
		LimitBuyItem,
		// Token: 0x0402DA8C RID: 187020
		FinishBuyItem,
		// Token: 0x0402DA8D RID: 187021
		NewItem,
		// Token: 0x0402DA8E RID: 187022
		TextureBg,
		// Token: 0x0402DA8F RID: 187023
		TextureTopBg,
		// Token: 0x0402DA90 RID: 187024
		EffectBItem,
		// Token: 0x0402DA91 RID: 187025
		EffectAItem,
		// Token: 0x0402DA92 RID: 187026
		ExtraItemRoot = 21,
		// Token: 0x0402DA93 RID: 187027
		TextureExtraReward,
		// Token: 0x0402DA94 RID: 187028
		TextExtraReward,
		// Token: 0x0402DA95 RID: 187029
		ItemTypeIcon = 25,
		// Token: 0x0402DA96 RID: 187030
		TextureTypeIcon,
		// Token: 0x0402DA97 RID: 187031
		ItemExtraReward
	}
}
