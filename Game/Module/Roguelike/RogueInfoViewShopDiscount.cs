using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005178 RID: 20856
	public class RogueInfoViewShopDiscount : MediumItemGridComponent
	{
		// Token: 0x06035AAA RID: 219818 RVA: 0x00D7AF56 File Offset: 0x00D79156
		[NullableContext(1)]
		protected override string GetResourceId()
		{
			return "UiItem_ItemDiscount";
		}

		// Token: 0x06035AAB RID: 219819 RVA: 0x00D7AF60 File Offset: 0x00D79160
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035AAC RID: 219820 RVA: 0x00D7AFCC File Offset: 0x00D791CC
		[NullableContext(2)]
		protected override void OnRefresh(object param = null)
		{
			RogueGainEntry rogueGainEntry = param as RogueGainEntry;
			if (rogueGainEntry == null)
			{
				return;
			}
			if (rogueGainEntry.IsDiscounted())
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RogueInfoViewShopPriceWithDiscount", new <>z__ReadOnlyArray<object>(new object[]
				{
					rogueGainEntry.CurrentPrice,
					rogueGainEntry.OriginalPrice
				}));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RogueInfoViewShopPrice", new <>z__ReadOnlySingleElementList<object>(rogueGainEntry.OriginalPrice));
			}
			if (rogueGainEntry.ShopItemCoinId != 0)
			{
				RogueCurrency? rogueCurrencyConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCurrencyConfig(rogueGainEntry.ShopItemCoinId);
				base.SetTextureByPath(((rogueCurrencyConfig != null) ? rogueCurrencyConfig.GetValueOrDefault().IconSmall : null) ?? "", base.GetTexture(0), null, null);
			}
		}

		// Token: 0x0200B12D RID: 45357
		private class ERogueInfoViewShopDiscountDefine
		{
			// Token: 0x04036F3E RID: 225086
			public const int TexIcon = 0;

			// Token: 0x04036F3F RID: 225087
			public const int TxtPrice = 1;
		}
	}
}
