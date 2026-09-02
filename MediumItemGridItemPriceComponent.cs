using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019C7 RID: 6599
public class MediumItemGridItemPriceComponent : MediumItemGridComponent
{
	// Token: 0x0600BD6E RID: 48494 RVA: 0x00323F11 File Offset: 0x00322111
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemDiscount";
	}

	// Token: 0x0600BD6F RID: 48495 RVA: 0x00323F18 File Offset: 0x00322118
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BD70 RID: 48496 RVA: 0x00323F84 File Offset: 0x00322184
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		IMediumItemPrice mediumItemPrice = data as IMediumItemPrice;
		if (mediumItemPrice == null)
		{
			this.SetActive(false);
			return;
		}
		this.SetPrice(mediumItemPrice.CurPrice, mediumItemPrice.OriginalPrice, mediumItemPrice.CurrencyNotEnough);
		this.SetTexture(mediumItemPrice.TexPath);
		this.SetActive(true);
	}

	// Token: 0x0600BD71 RID: 48497 RVA: 0x00323FD0 File Offset: 0x003221D0
	public void SetPrice(int curPrice, int? originalPrice, bool? notEnough = null)
	{
		if (originalPrice != null)
		{
			int? num = originalPrice;
			if (!(curPrice == num.GetValueOrDefault() & num != null))
			{
				string textStringId = notEnough.GetValueOrDefault() ? "RogueInfoViewShopPriceWithDiscount_NE" : "RogueInfoViewShopPriceWithDiscount";
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, new <>z__ReadOnlyArray<object>(new object[]
				{
					curPrice,
					originalPrice
				}));
				return;
			}
		}
		string textStringId2 = notEnough.GetValueOrDefault() ? "RogueInfoViewShopPrice_NE" : "RogueInfoViewShopPrice";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId2, new <>z__ReadOnlySingleElementList<object>(curPrice));
	}

	// Token: 0x0600BD72 RID: 48498 RVA: 0x00324078 File Offset: 0x00322278
	[NullableContext(2)]
	public void SetTexture(string path)
	{
		UUITexture texture = base.GetTexture(0);
		if (texture != null)
		{
			texture.SetUIActive(false);
		}
		if (!string.IsNullOrEmpty(path))
		{
			base.SetTextureShowUntilLoaded(path, texture, null);
		}
	}

	// Token: 0x02007CC5 RID: 31941
	private class EComponents
	{
		// Token: 0x0402A970 RID: 174448
		public const int TexIcon = 0;

		// Token: 0x0402A971 RID: 174449
		public const int TxtPrice = 1;
	}
}
