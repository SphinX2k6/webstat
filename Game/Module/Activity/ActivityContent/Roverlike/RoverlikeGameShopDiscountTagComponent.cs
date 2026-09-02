using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200641B RID: 25627
	public class RoverlikeGameShopDiscountTagComponent : MediumItemGridComponent
	{
		// Token: 0x0604055A RID: 263514 RVA: 0x0107D373 File Offset: 0x0107B573
		[NullableContext(1)]
		protected override string GetResourceId()
		{
			return "UiItem_ItemDiscountTag";
		}

		// Token: 0x0604055B RID: 263515 RVA: 0x0107D37C File Offset: 0x0107B57C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604055C RID: 263516 RVA: 0x0107D3C4 File Offset: 0x0107B5C4
		[NullableContext(2)]
		protected override void OnRefresh(object data)
		{
			IRoverlikeGameShopGridData roverlikeGameShopGridData = data as IRoverlikeGameShopGridData;
			if (roverlikeGameShopGridData == null)
			{
				return;
			}
			bool flag = roverlikeGameShopGridData.OriginalPrice > roverlikeGameShopGridData.FinalPrice;
			if (roverlikeGameShopGridData.IsBought || !flag)
			{
				this.SetActive(false);
				return;
			}
			int originalPrice = roverlikeGameShopGridData.OriginalPrice;
			int num = (int)Math.Floor((double)roverlikeGameShopGridData.FinalPrice / (double)originalPrice * 100.0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "RogueInfoViewShopDiscount", new <>z__ReadOnlySingleElementList<object>((100 - num).ToString()));
			this.SetActive(true);
		}

		// Token: 0x0200C484 RID: 50308
		private class EComponents
		{
			// Token: 0x0403C7D5 RID: 247765
			public const int TxtDiscount = 0;
		}
	}
}
