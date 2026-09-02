using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Ornament;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020023E1 RID: 9185
[Nullable(new byte[]
{
	0,
	1
})]
public class PayShopOrnamentItem : GridProxyAbstract<PayShopGoods>, IGiftDisplayItem
{
	// Token: 0x06011C51 RID: 72785 RVA: 0x004E2F94 File Offset: 0x004E1194
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06011C52 RID: 72786 RVA: 0x004E3108 File Offset: 0x004E1308
	[NullableContext(2)]
	public override void Refresh(PayShopGoods data, bool isSelected, int gridIndex)
	{
		ShopRoleOrnamentData shopRoleOrnamentData = ShopRoleOrnamentData.Create(data);
		RoleOrnamentData roleOrnamentData = ModelBase<RoleOrnamentModel>.Instance.GetRoleOrnamentData(shopRoleOrnamentData.GetItemId());
		base.SetTextureByPath(roleOrnamentData.GetPreviewTextureInPop(), base.GetTexture(0), null, null);
		bool ifDirect = shopRoleOrnamentData.GetIfDirect();
		base.GetTexture(1).SetUIActive(!ifDirect);
		if (ifDirect)
		{
			string directPriceText = shopRoleOrnamentData.GetDirectPriceText();
			base.GetText(2).SetText(directPriceText, true);
			base.GetText(3).SetText("", true);
		}
		else
		{
			IPriceData priceData = shopRoleOrnamentData.GetPriceData();
			base.SetItemIcon(base.GetTexture(1), priceData.CurrencyId, null, null);
			int nowPrice = priceData.NowPrice;
			base.GetText(2).SetText(nowPrice.ToString(), true);
			int? originalPrice = priceData.OriginalPrice;
			if (originalPrice == null)
			{
				base.GetText(3).SetUIActive(false);
			}
			else
			{
				base.GetText(3).SetUIActive(true);
				base.GetText(3).SetText("<s>" + originalPrice.ToString() + "</s>", true);
			}
		}
		UUISprite sprite = base.GetSprite(8);
		if (sprite != null)
		{
			sprite.SetUIActive(false);
		}
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		base.GetItem(6).SetUIActive(false);
		base.GetItem(7).SetUIActive(false);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_ShopSkinBg");
		base.SetTextureByPath(resourcePath, base.GetTexture(5), null, null);
	}

	// Token: 0x0200871A RID: 34586
	private class EComponent
	{
		// Token: 0x0402DB2A RID: 187178
		public const int OrnamentTexture = 0;

		// Token: 0x0402DB2B RID: 187179
		public const int BuyItemIcon = 1;

		// Token: 0x0402DB2C RID: 187180
		public const int NowPrice = 2;

		// Token: 0x0402DB2D RID: 187181
		public const int BeforePrice = 3;

		// Token: 0x0402DB2E RID: 187182
		public const int SuitWeaponTexture = 4;

		// Token: 0x0402DB2F RID: 187183
		public const int TextureBg = 5;

		// Token: 0x0402DB30 RID: 187184
		public const int EffectAItem = 6;

		// Token: 0x0402DB31 RID: 187185
		public const int EffectBItem = 7;

		// Token: 0x0402DB32 RID: 187186
		public const int SpriteMask = 8;

		// Token: 0x0402DB33 RID: 187187
		public const int ItemWeaponPanel = 9;
	}
}
