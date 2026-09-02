using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023CC RID: 9164
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SkinItemContent : GridProxyAbstract<SkinItemContentData>
{
	// Token: 0x06011B67 RID: 72551 RVA: 0x004DCEE8 File Offset: 0x004DB0E8
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
			new ValueTuple<int, Type>(24, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBuyButton))
		};
	}

	// Token: 0x06011B68 RID: 72552 RVA: 0x004DD114 File Offset: 0x004DB314
	private void OnClickBuyButton()
	{
		List<PayShopGoods> allData = this.CurrentShopSkinData.AllData;
		List<ShopSkinData> list = new List<ShopSkinData>();
		int count = allData.Count;
		for (int i = 0; i < count; i++)
		{
			ShopSkinData item = ShopSkinData.Create(allData[i]);
			list.Add(item);
		}
		SkinBuyDetailViewData skinBuyDetailViewData = SkinBuyDetailViewData.Create(list);
		skinBuyDetailViewData.SetIndex(this.CurrentIndex);
		skinBuyDetailViewData.SetPreviewTitle("RoleSkinShopTitle_Text");
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SkinBuyDetailView, skinBuyDetailViewData, null);
	}

	// Token: 0x06011B69 RID: 72553 RVA: 0x004DD190 File Offset: 0x004DB390
	public override void Refresh(SkinItemContentData data, bool isSelected, int gridIndex)
	{
		ShopSkinData shopSkinData = data.ShopSkinData;
		this.CurrentShopSkinData = data;
		this.CurrentIndex = gridIndex;
		this.RefreshRoleTexture(shopSkinData);
		this.RefreshWeaponTexture(shopSkinData);
		this.RefreshBuyLimitText(shopSkinData);
		this.RefreshSubNameText(shopSkinData);
		this.RefreshNowPriceText(shopSkinData);
		this.RefreshSourcePriceText(shopSkinData);
		this.RefreshDiscountTimeText(shopSkinData);
		this.RefreshDiscountText(shopSkinData);
		this.RefreshBuyItemIcon(shopSkinData);
		this.RefreshBuyLimitItemState(shopSkinData);
		this.RefreshFinishBuyItemState(shopSkinData);
		this.RefreshRedDotState(shopSkinData);
		this.RefreshTextureBg(shopSkinData);
		this.RefreshTextureTopBg(shopSkinData);
		this.RefreshEffectItem(shopSkinData);
		this.RefreshCouponItem(shopSkinData);
	}

	// Token: 0x06011B6A RID: 72554 RVA: 0x004DD224 File Offset: 0x004DB424
	private void RefreshEffectItem(ShopSkinData data)
	{
		bool uiactive = data.GetRoleSkinData().GetSuitWeaponSkinId() > 0;
		base.GetItem(17).SetUIActive(uiactive);
		base.GetItem(16).SetUIActive(uiactive);
	}

	// Token: 0x06011B6B RID: 72555 RVA: 0x004DD25C File Offset: 0x004DB45C
	private void RefreshRedDotState(ShopSkinData data)
	{
		bool ifNeedRemind = data.GetCurrentGoodsData().GetIfNeedRemind();
		base.GetItem(13).SetUIActive(ifNeedRemind);
	}

	// Token: 0x06011B6C RID: 72556 RVA: 0x004DD284 File Offset: 0x004DB484
	private void RefreshBuyLimitItemState(ShopSkinData data)
	{
		bool ifCanBuy = data.GetIfCanBuy();
		base.GetItem(11).SetUIActive(ifCanBuy);
	}

	// Token: 0x06011B6D RID: 72557 RVA: 0x004DD2A8 File Offset: 0x004DB4A8
	private void RefreshFinishBuyItemState(ShopSkinData data)
	{
		bool uiactive = !data.GetIfCanBuy();
		base.GetItem(12).SetUIActive(uiactive);
	}

	// Token: 0x06011B6E RID: 72558 RVA: 0x004DD2D0 File Offset: 0x004DB4D0
	private void RefreshRoleTexture(ShopSkinData data)
	{
		string payShopPreviewRoleTexturePath = data.GetPayShopPreviewRoleTexturePath();
		base.SetTextureByPath(payShopPreviewRoleTexturePath, base.GetTexture(1), null, null);
	}

	// Token: 0x06011B6F RID: 72559 RVA: 0x004DD2FC File Offset: 0x004DB4FC
	private void RefreshWeaponTexture(ShopSkinData data)
	{
		string payShopPreviewBuyRoleSuitWeaponTexturePath = data.GetPayShopPreviewBuyRoleSuitWeaponTexturePath();
		if (!(payShopPreviewBuyRoleSuitWeaponTexturePath == ""))
		{
			UUITexture texture = base.GetTexture(2);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			base.SetTextureByPath(payShopPreviewBuyRoleSuitWeaponTexturePath, base.GetTexture(2), null, null);
			return;
		}
		UUITexture texture2 = base.GetTexture(2);
		if (texture2 == null)
		{
			return;
		}
		texture2.SetUIActive(false);
	}

	// Token: 0x06011B70 RID: 72560 RVA: 0x004DD35C File Offset: 0x004DB55C
	[NullableContext(2)]
	private void RefreshSourcePriceText(ShopSkinData data)
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

	// Token: 0x06011B71 RID: 72561 RVA: 0x004DD3F0 File Offset: 0x004DB5F0
	[NullableContext(2)]
	private void RefreshNowPriceText(ShopSkinData data)
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

	// Token: 0x06011B72 RID: 72562 RVA: 0x004DD454 File Offset: 0x004DB654
	[NullableContext(2)]
	private void RefreshBuyItemIcon(ShopSkinData data)
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

	// Token: 0x06011B73 RID: 72563 RVA: 0x004DD4B4 File Offset: 0x004DB6B4
	private void RefreshBuyLimitText(ShopSkinData data)
	{
		string shopTipsText = data.GetPayShopGoods().GetShopTipsText();
		base.GetText(3).SetText(shopTipsText, true);
	}

	// Token: 0x06011B74 RID: 72564 RVA: 0x004DD4DC File Offset: 0x004DB6DC
	private void RefreshSubNameText(ShopSkinData data)
	{
		string titleName = data.GetRoleSkinData().GetTitleName();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), titleName, Array.Empty<object>());
	}

	// Token: 0x06011B75 RID: 72565 RVA: 0x004DD50C File Offset: 0x004DB70C
	[NullableContext(2)]
	private void RefreshDiscountTimeText(ShopSkinData data)
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
		CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = discountTimeData as CommonDefine.PayShowCountDownRemainTime<string>;
		if (payShowCountDownRemainTime != null)
		{
			text.SetText(payShowCountDownRemainTime.Value, true);
			return;
		}
		CommonDefine.PayShowCountDownRemainTime<CommonDefine.IRemainTime> payShowCountDownRemainTime2 = discountTimeData as CommonDefine.PayShowCountDownRemainTime<CommonDefine.IRemainTime>;
		if (payShowCountDownRemainTime2 != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, payShowCountDownRemainTime2.Value.TextId, new <>z__ReadOnlySingleElementList<object>(payShowCountDownRemainTime2.Value.TimeValue));
		}
	}

	// Token: 0x06011B76 RID: 72566 RVA: 0x004DD5A8 File Offset: 0x004DB7A8
	[NullableContext(2)]
	private void RefreshDiscountText(ShopSkinData data)
	{
		if (data == null)
		{
			base.GetItem(7).SetUIActive(false);
			return;
		}
		string discountText = data.GetDiscountText();
		base.GetItem(24).SetUIActive(discountText != "");
		base.GetText(8).SetText(discountText, true);
	}

	// Token: 0x06011B77 RID: 72567 RVA: 0x004DD5F4 File Offset: 0x004DB7F4
	[NullableContext(2)]
	private void RefreshTextureBg(ShopSkinData data)
	{
		if (data == null)
		{
			base.GetTexture(14).SetUIActive(false);
			return;
		}
		string resourceId = (data.GetRoleSkinData().GetSuitWeaponSkinId() > 0) ? "T_ShopRoleItemBg1" : "T_ShopRoleItemBg";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureByPath(resourcePath, base.GetTexture(14), null, null);
	}

	// Token: 0x06011B78 RID: 72568 RVA: 0x004DD658 File Offset: 0x004DB858
	[NullableContext(2)]
	private void RefreshTextureTopBg(ShopSkinData data)
	{
		if (data == null)
		{
			base.GetTexture(15).SetUIActive(false);
			return;
		}
		string resourceId = (data.GetRoleSkinData().GetSuitWeaponSkinId() > 0) ? "T_ShopRoleItemTopBg1" : "T_ShopRoleItemTopBg";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureByPath(resourcePath, base.GetTexture(15), null, null);
	}

	// Token: 0x06011B79 RID: 72569 RVA: 0x004DD6BC File Offset: 0x004DB8BC
	[NullableContext(2)]
	private void RefreshCouponItem(ShopSkinData data)
	{
		if (data == null)
		{
			base.GetItem(18).SetUIActive(false);
			return;
		}
		CommonItemData availableCouponItem = data.GetCurrentGoodsData().GetAvailableCouponItem();
		if (availableCouponItem == null)
		{
			base.GetItem(18).SetUIActive(false);
			return;
		}
		base.GetItem(18).SetUIActive(true);
		int availableCouponDiscount = data.GetCurrentGoodsData().GetAvailableCouponDiscount();
		UUIText text = base.GetText(19);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("-");
		defaultInterpolatedStringHandler.AppendFormatted<int>(availableCouponDiscount);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.SetTextureByPath(availableCouponItem.GetConfig().As<ItemInfo>().Value.IconSmall, base.GetTexture(20), null, null);
	}

	// Token: 0x04008ABB RID: 35515
	[Nullable(2)]
	private SkinItemContentData CurrentShopSkinData;

	// Token: 0x04008ABC RID: 35516
	private int CurrentIndex;

	// Token: 0x02008701 RID: 34561
	[NullableContext(0)]
	private enum ESkinItemComponent
	{
		// Token: 0x0402DA66 RID: 186982
		BuyButton,
		// Token: 0x0402DA67 RID: 186983
		RoleTexture,
		// Token: 0x0402DA68 RID: 186984
		TextureWeapon,
		// Token: 0x0402DA69 RID: 186985
		BuyLimitText,
		// Token: 0x0402DA6A RID: 186986
		SubNameText,
		// Token: 0x0402DA6B RID: 186987
		NowPrice,
		// Token: 0x0402DA6C RID: 186988
		BeforePrice,
		// Token: 0x0402DA6D RID: 186989
		DiscountItem,
		// Token: 0x0402DA6E RID: 186990
		DiscountText,
		// Token: 0x0402DA6F RID: 186991
		TimeText,
		// Token: 0x0402DA70 RID: 186992
		BuyItemIcon,
		// Token: 0x0402DA71 RID: 186993
		LimitBuyItem,
		// Token: 0x0402DA72 RID: 186994
		FinishBuyItem,
		// Token: 0x0402DA73 RID: 186995
		NewItem,
		// Token: 0x0402DA74 RID: 186996
		TextureBg,
		// Token: 0x0402DA75 RID: 186997
		TextureTopBg,
		// Token: 0x0402DA76 RID: 186998
		EffectBItem,
		// Token: 0x0402DA77 RID: 186999
		EffectAItem,
		// Token: 0x0402DA78 RID: 187000
		ItemCoupon,
		// Token: 0x0402DA79 RID: 187001
		TextCoupon,
		// Token: 0x0402DA7A RID: 187002
		TextureCoupon,
		// Token: 0x0402DA7B RID: 187003
		DiscountTextRootItem = 24
	}
}
