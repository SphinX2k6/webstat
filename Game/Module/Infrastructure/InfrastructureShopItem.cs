using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C6D RID: 23661
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InfrastructureShopItem : GridProxyAbstract<PayShopGoods>
	{
		// Token: 0x170097ED RID: 38893
		// (get) Token: 0x0603BCB1 RID: 244913 RVA: 0x00F288C9 File Offset: 0x00F26AC9
		private PayShopItemBaseSt ItemBaseSt
		{
			get
			{
				PayShopGoods data = this.Data;
				if (data == null)
				{
					return null;
				}
				return data.ConvertToPayShopBaseSt();
			}
		}

		// Token: 0x0603BCB2 RID: 244914 RVA: 0x00F288DC File Offset: 0x00F26ADC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickShopItem));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BCB3 RID: 244915 RVA: 0x00F28AD0 File Offset: 0x00F26CD0
		public override void Refresh(PayShopGoods data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RefreshTexture();
			this.RefreshQualityTexture();
			this.RefreshShopItemName();
			this.RefreshPrice();
			this.RefreshWarnState();
		}

		// Token: 0x0603BCB4 RID: 244916 RVA: 0x00F28AF8 File Offset: 0x00F26CF8
		private void RefreshTexture()
		{
			PayShopItemBaseSt payShopItemBaseSt = this.Data.ConvertToPayShopBaseSt();
			UUITexture texture = base.GetTexture(1);
			if (payShopItemBaseSt.IfRechargeItem)
			{
				base.SetTextureByPath(payShopItemBaseSt.StageImage, texture, null, null);
				return;
			}
			if (!string.IsNullOrEmpty(payShopItemBaseSt.ShowStageImage))
			{
				base.SetTextureByPath(payShopItemBaseSt.ShowStageImage, texture, null, null);
				return;
			}
			base.SetItemIcon(texture, payShopItemBaseSt.ItemId, null, null);
		}

		// Token: 0x0603BCB5 RID: 244917 RVA: 0x00F28B78 File Offset: 0x00F26D78
		private void RefreshQualityTexture()
		{
			string itemQualityColor = ConfigBase<InfrastructureConfig>.Instance.GetItemQualityColor(this.ItemBaseSt.Quality);
			UUISprite sprite = base.GetSprite(2);
			if (sprite == null)
			{
				return;
			}
			sprite.SetColor(FColor.FromHex(itemQualityColor));
		}

		// Token: 0x0603BCB6 RID: 244918 RVA: 0x00F28BB2 File Offset: 0x00F26DB2
		private void RefreshShopItemName()
		{
			base.GetText(4).SetText(this.ItemBaseSt.ItemName, true);
		}

		// Token: 0x0603BCB7 RID: 244919 RVA: 0x00F28BCC File Offset: 0x00F26DCC
		private void RefreshPrice()
		{
			UUITexture texture = base.GetTexture(5);
			if (this.ItemBaseSt.IsDirect)
			{
				texture.SetUIActive(false);
				return;
			}
			IPriceData priceData = this.ItemBaseSt.PriceData;
			if (priceData.NowPrice == 0)
			{
				texture.SetUIActive(false);
				return;
			}
			texture.SetUIActive(true);
			base.SetItemIcon(texture, priceData.CurrencyId, null, null);
			UUIText text = base.GetText(6);
			text.SetText(priceData.NowPrice.ToString(), true);
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(80700004, 0);
			UUIItem uuiitem = text;
			bool bUseChangeColor = itemCountByConfigId < priceData.NowPrice;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x0603BCB8 RID: 244920 RVA: 0x00F28C80 File Offset: 0x00F26E80
		private void RefreshWarnState()
		{
			bool flag = !this.Data.IfCanBuy();
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(9);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			if (flag)
			{
				UUIText text = base.GetText(8);
				if (text != null)
				{
					text.SetText(this.Data.GetConditionLimitText(), true);
				}
			}
			else if (this.Data.IsSoldOut())
			{
				UUIItem item3 = base.GetItem(9);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
			}
			UUIText text2 = base.GetText(11);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(this.Data.GetBuyLimitText(), true);
		}

		// Token: 0x0603BCB9 RID: 244921 RVA: 0x00F28D25 File Offset: 0x00F26F25
		private void OnClickShopItem()
		{
			if (!this.Data.IfCanBuy())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("JijianTask_Rewardsunlocked", Array.Empty<object>());
				return;
			}
			ControllerBase<PayShopController>.Instance.OpenBuyViewByGoodsId(this.Data, null);
		}

		// Token: 0x04021992 RID: 137618
		private PayShopGoods Data;

		// Token: 0x0200BD1A RID: 48410
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403A474 RID: 238708
			public const int ShopItem = 0;

			// Token: 0x0403A475 RID: 238709
			public const int TextureBigIcon = 1;

			// Token: 0x0403A476 RID: 238710
			public const int SpriteQualityLight = 2;

			// Token: 0x0403A477 RID: 238711
			public const int PanelItemDescription = 3;

			// Token: 0x0403A478 RID: 238712
			public const int TextItemName = 4;

			// Token: 0x0403A479 RID: 238713
			public const int TextureCostIcon = 5;

			// Token: 0x0403A47A RID: 238714
			public const int TextCostNum = 6;

			// Token: 0x0403A47B RID: 238715
			public const int PanelWarning = 7;

			// Token: 0x0403A47C RID: 238716
			public const int TextWarning = 8;

			// Token: 0x0403A47D RID: 238717
			public const int PanelOut = 9;

			// Token: 0x0403A47E RID: 238718
			public const int TextOut = 10;

			// Token: 0x0403A47F RID: 238719
			public const int TextTime = 11;
		}
	}
}
