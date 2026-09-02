using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200521F RID: 21023
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleDiscountTagComponent : MediumItemGridComponent
	{
		// Token: 0x06035E0F RID: 220687 RVA: 0x00D8F8ED File Offset: 0x00D8DAED
		protected override string GetResourceId()
		{
			return "UiItem_ItemDiscountTag";
		}

		// Token: 0x06035E10 RID: 220688 RVA: 0x00D8F8F4 File Offset: 0x00D8DAF4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06035E11 RID: 220689 RVA: 0x00D8F918 File Offset: 0x00D8DB18
		protected override void OnRefresh(object data)
		{
			RogueResGainData rogueResGainData = (RogueResGainData)data;
			if (rogueResGainData.RogueResShopToken == null)
			{
				return;
			}
			int sourcePrice = rogueResGainData.RogueResShopToken.SourcePrice;
			int num = (int)Math.Floor((double)rogueResGainData.RogueResShopToken.CurPrice / (double)sourcePrice * 100.0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "RogueInfoViewShopDiscount", new <>z__ReadOnlySingleElementList<object>((100 - num).ToString()));
		}
	}
}
