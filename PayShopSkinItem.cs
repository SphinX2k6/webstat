using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020023E6 RID: 9190
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PayShopSkinItem : GridProxyAbstract<PayShopGoods>, IGiftDisplayItem
{
	// Token: 0x06011C7E RID: 72830 RVA: 0x004E3C4C File Offset: 0x004E1E4C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06011C7F RID: 72831 RVA: 0x004E3D7C File Offset: 0x004E1F7C
	public override void Refresh(PayShopGoods data, bool isSelected, int gridIndex)
	{
		this.ShopSkinData = ShopSkinData.Create(data);
		this.RefreshRoleIcon(this.ShopSkinData);
		this.RefreshBuyItemIcon(this.ShopSkinData);
		this.RefreshNowPriceText(this.ShopSkinData);
		this.RefreshSourcePriceText(this.ShopSkinData);
		this.RefreshSuitWeaponIcon(this.ShopSkinData);
		this.RefreshTextureBg(this.ShopSkinData);
		this.RefreshEffectItem(this.ShopSkinData);
	}

	// Token: 0x06011C80 RID: 72832 RVA: 0x004E3DEC File Offset: 0x004E1FEC
	[NullableContext(1)]
	private void RefreshEffectItem(ShopSkinData data)
	{
		bool uiactive = data.GetRoleSkinData().GetSuitWeaponSkinId() > 0;
		base.GetItem(6).SetUIActive(uiactive);
		base.GetItem(7).SetUIActive(uiactive);
	}

	// Token: 0x06011C81 RID: 72833 RVA: 0x004E3E24 File Offset: 0x004E2024
	private void RefreshRoleIcon(ShopSkinData data)
	{
		base.SetTextureByPath(data.GetPayShopPreviewBuyRoleTexturePath(), base.GetTexture(0), null, null);
	}

	// Token: 0x06011C82 RID: 72834 RVA: 0x004E3E50 File Offset: 0x004E2050
	private void RefreshSuitWeaponIcon(ShopSkinData data)
	{
		if (data == null)
		{
			base.GetTexture(4).SetUIActive(false);
			return;
		}
		string payShopPreviewBuyRoleSuitWeaponTexturePath = data.GetPayShopPreviewBuyRoleSuitWeaponTexturePath();
		if (payShopPreviewBuyRoleSuitWeaponTexturePath == "" || payShopPreviewBuyRoleSuitWeaponTexturePath == null)
		{
			base.GetTexture(4).SetUIActive(false);
			return;
		}
		base.GetTexture(4).SetUIActive(true);
		base.SetTextureByPath(payShopPreviewBuyRoleSuitWeaponTexturePath, base.GetTexture(4), null, null);
	}

	// Token: 0x06011C83 RID: 72835 RVA: 0x004E3EB8 File Offset: 0x004E20B8
	private void RefreshBuyItemIcon(ShopSkinData data)
	{
		if (data == null)
		{
			base.GetTexture(1).SetUIActive(false);
			return;
		}
		bool ifDirect = data.GetIfDirect();
		base.GetTexture(1).SetUIActive(!ifDirect);
		if (!ifDirect)
		{
			IPriceData priceData = data.GetPriceData();
			base.SetItemIcon(base.GetTexture(1), priceData.CurrencyId, null, null);
		}
	}

	// Token: 0x06011C84 RID: 72836 RVA: 0x004E3F14 File Offset: 0x004E2114
	private void RefreshSourcePriceText(ShopSkinData data)
	{
		if (data == null)
		{
			base.GetText(3).SetText("", true);
			return;
		}
		if (data.GetIfDirect())
		{
			base.GetText(3).SetText("", true);
			return;
		}
		int? originalPrice = data.GetPriceData().OriginalPrice;
		if (originalPrice == null)
		{
			base.GetText(3).SetUIActive(false);
			return;
		}
		base.GetText(3).SetUIActive(true);
		base.GetText(3).SetText("<s>" + originalPrice.ToString() + "</s>", true);
	}

	// Token: 0x06011C85 RID: 72837 RVA: 0x004E3FAC File Offset: 0x004E21AC
	private void RefreshNowPriceText(ShopSkinData data)
	{
		if (data == null)
		{
			base.GetText(2).SetText("", true);
			return;
		}
		if (data.GetIfDirect())
		{
			string directPriceText = data.GetDirectPriceText();
			base.GetText(2).SetText(directPriceText, true);
			return;
		}
		int nowPrice = data.GetPriceData().NowPrice;
		base.GetText(2).SetText(nowPrice.ToString(), true);
	}

	// Token: 0x06011C86 RID: 72838 RVA: 0x004E4010 File Offset: 0x004E2210
	private void RefreshTextureBg(ShopSkinData data)
	{
		if (data == null)
		{
			base.GetTexture(5).SetUIActive(false);
			return;
		}
		string resourceId = (data.GetRoleSkinData().GetSuitWeaponSkinId() > 0) ? "T_ShopSkinBg1" : "T_ShopSkinBg";
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		base.SetTextureByPath(resourcePath, base.GetTexture(5), null, null);
	}

	// Token: 0x04008B34 RID: 35636
	private ShopSkinData ShopSkinData;

	// Token: 0x0200871F RID: 34591
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402DB43 RID: 187203
		public const int RoleTexture = 0;

		// Token: 0x0402DB44 RID: 187204
		public const int BuyItemIcon = 1;

		// Token: 0x0402DB45 RID: 187205
		public const int NowPrice = 2;

		// Token: 0x0402DB46 RID: 187206
		public const int BeforePrice = 3;

		// Token: 0x0402DB47 RID: 187207
		public const int SuitWeaponTexture = 4;

		// Token: 0x0402DB48 RID: 187208
		public const int TextureBg = 5;

		// Token: 0x0402DB49 RID: 187209
		public const int EffectAItem = 6;

		// Token: 0x0402DB4A RID: 187210
		public const int EffectBItem = 7;
	}
}
