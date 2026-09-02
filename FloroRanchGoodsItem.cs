using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C5E RID: 7262
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchGoodsItem : GridProxyAbstract<FloroRanchShopItemDataBase>
{
	// Token: 0x0600D3EF RID: 54255 RVA: 0x00387DDC File Offset: 0x00385FDC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickGoodsItem));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D3F0 RID: 54256 RVA: 0x00387FF4 File Offset: 0x003861F4
	public override void Refresh(FloroRanchShopItemDataBase data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		base.SetTextureByPath(this.Data.GetIcon(), base.GetTexture(2), null, null);
		FloroRanchRarityData qualityData = this.Data.GetQualityData();
		this.SetSpriteByPath(qualityData.GetRarityShopItemBg(), base.GetSprite(3), true, null, null);
		UUIItem item = base.GetItem(11);
		if (item != null)
		{
			item.SetUIActive(this.Data.GetIsSpecialPhantom());
		}
		FloroRanchCurrencyData diamondData = ModelBase<FloroRanchGamePlayModel>.Instance.DiamondData;
		base.SetTextureByPath(diamondData.ConfigData.GetSmallIcon(), base.GetTexture(4), null, null);
		int price = this.Data.Price;
		bool flag = diamondData.GetAmount() >= price;
		UUIText text = base.GetText(5);
		text.SetText(price.ToString(), true);
		UUIItem uuiitem = text;
		bool bUseChangeColor = !flag;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		UUIText text2 = base.GetText(6);
		if (text2 != null)
		{
			text2.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(7);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(9);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		if (data.Type == FloroRanchShopItemType.ShopToy)
		{
			FloroRanchRaceData toyRaceData = data.GetToyRaceData();
			if (toyRaceData != null)
			{
				base.SetTextureByPath(toyRaceData.SmallIcon, base.GetTexture(10), null, null);
				UUIItem item4 = base.GetItem(9);
				if (item4 != null)
				{
					item4.SetUIActive(true);
				}
			}
		}
		UUIItem item5 = base.GetItem(8);
		if (item5 != null)
		{
			item5.SetUIActive(this.Data.IsSold);
		}
		global::FloroRanchActivityData currentActivityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		if (currentActivityData == null)
		{
			return;
		}
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		EFloroRanchCardType? efloroRanchCardType = null;
		if (data.Type == FloroRanchShopItemType.ShopToy)
		{
			efloroRanchCardType = new EFloroRanchCardType?(EFloroRanchCardType.Toy);
		}
		else if (data.Type == FloroRanchShopItemType.Card)
		{
			efloroRanchCardType = new EFloroRanchCardType?(EFloroRanchCardType.Phantom);
		}
		bool flag2 = efloroRanchCardType != null && currentActivityData.IsSubDungeonRecommendItem(subInstanceId, data.Id, efloroRanchCardType.Value);
		UUISprite sprite = base.GetSprite(12);
		if (!flag2)
		{
			if (sprite != null)
			{
				sprite.SetUIActive(false);
				return;
			}
		}
		else if (sprite != null)
		{
			sprite.SetUIActive(true);
		}
	}

	// Token: 0x0600D3F1 RID: 54257 RVA: 0x0038821D File Offset: 0x0038641D
	public void BindClickCallback(Action<FloroRanchShopItemDataBase> callback)
	{
		this.ClickCallback = callback;
	}

	// Token: 0x0600D3F2 RID: 54258 RVA: 0x00388226 File Offset: 0x00386426
	private void OnClickGoodsItem(EToggleState toggleState)
	{
		Action<FloroRanchShopItemDataBase> clickCallback = this.ClickCallback;
		if (clickCallback == null)
		{
			return;
		}
		clickCallback(this.Data);
	}

	// Token: 0x0600D3F3 RID: 54259 RVA: 0x0038823E File Offset: 0x0038643E
	public void SetSelectState(bool isSelect)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x040064D0 RID: 25808
	public FloroRanchShopItemDataBase Data;

	// Token: 0x040064D1 RID: 25809
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<FloroRanchShopItemDataBase> ClickCallback;

	// Token: 0x02007F72 RID: 32626
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B638 RID: 177720
		public const int Toggle = 0;

		// Token: 0x0402B639 RID: 177721
		public const int GoodsItem = 1;

		// Token: 0x0402B63A RID: 177722
		public const int GoodsIconTexture = 2;

		// Token: 0x0402B63B RID: 177723
		public const int GoodsQualitySprite = 3;

		// Token: 0x0402B63C RID: 177724
		public const int PriceIconTexture = 4;

		// Token: 0x0402B63D RID: 177725
		public const int CurPrice = 5;

		// Token: 0x0402B63E RID: 177726
		public const int OldPrice = 6;

		// Token: 0x0402B63F RID: 177727
		public const int RedDot = 7;

		// Token: 0x0402B640 RID: 177728
		public const int SoldMask = 8;

		// Token: 0x0402B641 RID: 177729
		public const int ToyRaceItem = 9;

		// Token: 0x0402B642 RID: 177730
		public const int ToyRaceIcon = 10;

		// Token: 0x0402B643 RID: 177731
		public const int ItemPhantomIcon = 11;

		// Token: 0x0402B644 RID: 177732
		public const int RecommendSprite = 12;
	}
}
