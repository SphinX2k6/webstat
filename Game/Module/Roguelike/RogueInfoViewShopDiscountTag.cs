using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005177 RID: 20855
	public class RogueInfoViewShopDiscountTag : MediumItemGridComponent
	{
		// Token: 0x06035AA6 RID: 219814 RVA: 0x00D7AEC0 File Offset: 0x00D790C0
		[NullableContext(1)]
		protected override string GetResourceId()
		{
			return "UiItem_ItemDiscountTag";
		}

		// Token: 0x06035AA7 RID: 219815 RVA: 0x00D7AEC8 File Offset: 0x00D790C8
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

		// Token: 0x06035AA8 RID: 219816 RVA: 0x00D7AF10 File Offset: 0x00D79110
		[NullableContext(2)]
		protected override void OnRefresh(object param = null)
		{
			RogueGainEntry rogueGainEntry = param as RogueGainEntry;
			if (rogueGainEntry == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "RogueInfoViewShopDiscount", new <>z__ReadOnlySingleElementList<object>(rogueGainEntry.Discounted.ToString()));
		}

		// Token: 0x0200B12C RID: 45356
		private class ERogueInfoViewShopDiscountTagDefine
		{
			// Token: 0x04036F3D RID: 225085
			public const int TxtDiscount = 0;
		}
	}
}
