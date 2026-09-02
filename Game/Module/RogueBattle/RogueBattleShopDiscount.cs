using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005221 RID: 21025
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleShopDiscount : MediumItemGridComponent
	{
		// Token: 0x06035E13 RID: 220691 RVA: 0x00D8F990 File Offset: 0x00D8DB90
		protected override string GetResourceId()
		{
			return "UiItem_ItemDiscount";
		}

		// Token: 0x06035E14 RID: 220692 RVA: 0x00D8F997 File Offset: 0x00D8DB97
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(0, typeof(UUITexture))
			};
		}

		// Token: 0x06035E15 RID: 220693 RVA: 0x00D8F9D0 File Offset: 0x00D8DBD0
		protected override void OnRefresh(object data)
		{
			RogueResGainData rogueResGainData = (RogueResGainData)data;
			if (rogueResGainData.RogueResShopToken == null)
			{
				return;
			}
			RogueResShopToken rogueResShopToken = rogueResGainData.RogueResShopToken;
			if (rogueResShopToken.CurPrice != rogueResShopToken.SourcePrice)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RogueInfoViewShopPriceWithDiscount", new <>z__ReadOnlyArray<object>(new object[]
				{
					rogueResShopToken.CurPrice,
					rogueResShopToken.SourcePrice
				}));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "RogueInfoViewShopPrice", new <>z__ReadOnlySingleElementList<object>(rogueResShopToken.SourcePrice));
			}
			if (rogueResShopToken.ItemId != 0)
			{
				RogueCurrency? rogueCurrencyConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCurrencyConfig(rogueResShopToken.ItemId);
				base.SetTextureByPath(((rogueCurrencyConfig != null) ? rogueCurrencyConfig.GetValueOrDefault().IconSmall : null) ?? string.Empty, base.GetTexture(0), null, null);
			}
		}
	}
}
