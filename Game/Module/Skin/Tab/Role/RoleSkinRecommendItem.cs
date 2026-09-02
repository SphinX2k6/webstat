using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Skin.Tab.Role
{
	// Token: 0x02004F68 RID: 20328
	[NullableContext(2)]
	[Nullable(0)]
	public class RoleSkinRecommendItem : UiPanelBase
	{
		// Token: 0x060346E1 RID: 214753 RVA: 0x00D1E1F4 File Offset: 0x00D1C3F4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUITexture)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIText)),
				new ValueTuple<int, Type>(14, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickBuyButton))
			};
		}

		// Token: 0x060346E2 RID: 214754 RVA: 0x00D1E380 File Offset: 0x00D1C580
		private void OnClickBuyButton()
		{
			SkinBuyDetailViewData skinBuyDetailViewData = SkinBuyDetailViewData.Create(new List<ShopSkinData>
			{
				this.CurrentRoleSkinData
			});
			skinBuyDetailViewData.SetPreviewTitle("RoleSkinPreviewTitle_Text");
			skinBuyDetailViewData.SetIndex(0);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SkinBuyDetailView, skinBuyDetailViewData, null);
			OnClickRecommendSkinButtonLogEvent onClickRecommendSkinButtonLogEvent = new OnClickRecommendSkinButtonLogEvent();
			onClickRecommendSkinButtonLogEvent.i_operation_type = 1;
			ControllerBase<LogReportController>.Instance.LogReport(onClickRecommendSkinButtonLogEvent);
		}

		// Token: 0x060346E3 RID: 214755 RVA: 0x00D1E3DF File Offset: 0x00D1C5DF
		protected override void OnStart()
		{
			this.ItemLayout = new GenericLayout<SkinRewardItemGrid, SkinRewardData>(base.GetHorizontalLayout(0), new Func<SkinRewardItemGrid>(this.InitGridItem), null, false, true);
		}

		// Token: 0x060346E4 RID: 214756 RVA: 0x00D1E402 File Offset: 0x00D1C602
		[NullableContext(1)]
		private SkinRewardItemGrid InitGridItem()
		{
			SkinRewardItemGrid skinRewardItemGrid = new SkinRewardItemGrid();
			skinRewardItemGrid.OnClickRecommendSkinButtonCallback = delegate(int itemId)
			{
				OnClickRecommendSkinButtonLogEvent onClickRecommendSkinButtonLogEvent = new OnClickRecommendSkinButtonLogEvent();
				onClickRecommendSkinButtonLogEvent.i_operation_type = 0;
				onClickRecommendSkinButtonLogEvent.i_item_id = itemId;
				ControllerBase<LogReportController>.Instance.LogReport(onClickRecommendSkinButtonLogEvent);
			};
			return skinRewardItemGrid;
		}

		// Token: 0x060346E5 RID: 214757 RVA: 0x00D1E430 File Offset: 0x00D1C630
		public void Refresh(int recommendId)
		{
			this.RecommendData = ModelBase<PayShopModel>.Instance.GetRecommendDataById(recommendId);
			PayShopGoods payShopGoods = ModelBase<PayShopModel>.Instance.GetPayShopGoods(this.RecommendData.RecommendId);
			if (payShopGoods != null)
			{
				this.CurrentRoleSkinData = ShopSkinData.Create(payShopGoods);
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Shop;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "PayShopData is null";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", recommendId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.RefreshView();
		}

		// Token: 0x060346E6 RID: 214758 RVA: 0x00D1E4AC File Offset: 0x00D1C6AC
		private void RefreshView()
		{
			this.RefreshTimeText(this.CurrentRoleSkinData);
			this.RefreshSkinName(this.CurrentRoleSkinData);
			this.RefreshSubName(this.CurrentRoleSkinData);
			this.RefreshBuyItemIcon(this.CurrentRoleSkinData);
			this.RefreshSourcePriceText(this.CurrentRoleSkinData);
			this.RefreshNowPriceText(this.CurrentRoleSkinData);
			this.RefreshBuyButtonState(this.CurrentRoleSkinData);
			this.RefreshHaveItem(this.CurrentRoleSkinData);
			this.RefreshLayout(this.CurrentRoleSkinData);
			this.RefreshCouponDiscount(this.CurrentRoleSkinData);
		}

		// Token: 0x060346E7 RID: 214759 RVA: 0x00D1E534 File Offset: 0x00D1C734
		private void RefreshTimeText(ShopSkinData data)
		{
			if (data == null)
			{
				UUIText text = base.GetText(2);
				if (text != null)
				{
					text.SetText("", true);
				}
				UUIItem item = base.GetItem(10);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				UUIItem item2 = base.GetItem(11);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
			else
			{
				object discountTimeData = data.GetDiscountTimeData();
				if (discountTimeData == null)
				{
					base.GetText(2).SetUIActive(false);
					UUIItem item3 = base.GetItem(10);
					if (item3 != null)
					{
						item3.SetUIActive(false);
					}
					UUIItem item4 = base.GetItem(11);
					if (item4 == null)
					{
						return;
					}
					item4.SetUIActive(false);
					return;
				}
				else
				{
					base.GetText(2).SetUIActive(true);
					UUIItem item5 = base.GetItem(10);
					if (item5 != null)
					{
						item5.SetUIActive(true);
					}
					UUIItem item6 = base.GetItem(11);
					if (item6 != null)
					{
						item6.SetUIActive(true);
					}
					UUIText text2 = base.GetText(2);
					if (discountTimeData is CommonDefine.PayShowCountDownRemainTime<string>)
					{
						text2.SetText(((CommonDefine.PayShowCountDownRemainTime<string>)discountTimeData).Value, true);
						return;
					}
					Singleton<LguiUtil>.Instance.SetLocalText(text2, ((CommonDefine.PayShowCountDownRemainTime<CommonDefine.IRemainTime>)discountTimeData).Value.TextId, new <>z__ReadOnlySingleElementList<object>(((CommonDefine.PayShowCountDownRemainTime<CommonDefine.IRemainTime>)discountTimeData).Value.TimeValue));
					return;
				}
			}
		}

		// Token: 0x060346E8 RID: 214760 RVA: 0x00D1E650 File Offset: 0x00D1C850
		private void RefreshSkinName(ShopSkinData data)
		{
			if (data == null)
			{
				base.GetText(3).SetText("", true);
				return;
			}
			string titleName = data.GetRoleSkinData().GetTitleName();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), titleName, Array.Empty<object>());
		}

		// Token: 0x060346E9 RID: 214761 RVA: 0x00D1E698 File Offset: 0x00D1C898
		private void RefreshSubName(ShopSkinData data)
		{
			if (data == null)
			{
				base.GetText(4).SetText("", true);
				return;
			}
			string subTitle = data.GetRoleSkinData().GetSubTitle();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), subTitle, Array.Empty<object>());
		}

		// Token: 0x060346EA RID: 214762 RVA: 0x00D1E6E0 File Offset: 0x00D1C8E0
		private void RefreshBuyItemIcon(ShopSkinData data)
		{
			if (data == null)
			{
				base.GetTexture(9).SetUIActive(false);
				return;
			}
			bool ifDirect = data.GetIfDirect();
			base.GetTexture(9).SetUIActive(!ifDirect);
			if (!ifDirect)
			{
				IPriceData priceData = data.GetPriceData();
				base.SetItemIcon(base.GetTexture(9), priceData.CurrencyId, null, null);
			}
		}

		// Token: 0x060346EB RID: 214763 RVA: 0x00D1E740 File Offset: 0x00D1C940
		private void RefreshSourcePriceText(ShopSkinData data)
		{
			if (data == null)
			{
				base.GetText(6).SetText("", true);
				return;
			}
			if (data.GetIfDirect())
			{
				base.GetText(6).SetText("", true);
				return;
			}
			int? originalPrice = data.GetPriceData().OriginalPrice;
			if (originalPrice == null)
			{
				base.GetText(6).SetUIActive(false);
				return;
			}
			base.GetText(6).SetUIActive(true);
			base.GetText(6).SetText("<s>" + originalPrice.Value.ToString() + "</s>", true);
		}

		// Token: 0x060346EC RID: 214764 RVA: 0x00D1E7DC File Offset: 0x00D1C9DC
		private void RefreshNowPriceText(ShopSkinData data)
		{
			if (data == null)
			{
				base.GetText(5).SetText("", true);
				return;
			}
			if (data.GetIfDirect())
			{
				string directPriceText = data.GetDirectPriceText();
				base.GetText(5).SetText(directPriceText, true);
				return;
			}
			int nowPrice = data.GetPriceData().NowPrice;
			base.GetText(5).SetText(nowPrice.ToString(), true);
		}

		// Token: 0x060346ED RID: 214765 RVA: 0x00D1E840 File Offset: 0x00D1CA40
		private void RefreshBuyButtonState(ShopSkinData data)
		{
			if (data == null)
			{
				base.GetButton(7).RootUIComp.Get().SetUIActive(false);
				return;
			}
			bool ifCanBuy = data.GetIfCanBuy();
			base.GetButton(7).RootUIComp.Get().SetUIActive(ifCanBuy);
		}

		// Token: 0x060346EE RID: 214766 RVA: 0x00D1E88C File Offset: 0x00D1CA8C
		private void RefreshHaveItem(ShopSkinData data)
		{
			if (data == null)
			{
				base.GetItem(8).SetUIActive(false);
				return;
			}
			bool ifCanBuy = data.GetIfCanBuy();
			base.GetItem(8).SetUIActive(!ifCanBuy);
		}

		// Token: 0x060346EF RID: 214767 RVA: 0x00D1E8C4 File Offset: 0x00D1CAC4
		private void RefreshLayout(ShopSkinData data)
		{
			if (data == null)
			{
				GenericLayout<SkinRewardItemGrid, SkinRewardData> itemLayout = this.ItemLayout;
				if (itemLayout == null)
				{
					return;
				}
				itemLayout.SetActive(false);
				return;
			}
			else
			{
				TItem[] allReward = data.GetAllReward();
				List<SkinRewardData> list = new List<SkinRewardData>();
				foreach (TItem titem in allReward)
				{
					SkinRewardData skinRewardData = new SkinRewardData();
					TItem value = new TItem(new InventoryDefine.GetItemData(titem.ItemData.ItemId, titem.ItemData.IncId), titem.Count);
					skinRewardData.ItemData = new TItem?(value);
					skinRewardData.FinishState = data.GetCurrentGoodsData().IsSoldOut();
					list.Add(skinRewardData);
				}
				GenericLayout<SkinRewardItemGrid, SkinRewardData> itemLayout2 = this.ItemLayout;
				if (itemLayout2 != null)
				{
					itemLayout2.SetActive(list.Count != 0);
				}
				GenericLayout<SkinRewardItemGrid, SkinRewardData> itemLayout3 = this.ItemLayout;
				if (itemLayout3 == null)
				{
					return;
				}
				itemLayout3.RefreshByData(list, null, false);
				return;
			}
		}

		// Token: 0x060346F0 RID: 214768 RVA: 0x00D1E990 File Offset: 0x00D1CB90
		private void RefreshCouponDiscount(ShopSkinData data)
		{
			if (data == null)
			{
				base.GetItem(12).SetUIActive(false);
				return;
			}
			CommonItemData availableCouponItem = data.GetCurrentGoodsData().GetAvailableCouponItem();
			if (availableCouponItem == null)
			{
				base.GetItem(12).SetUIActive(false);
				return;
			}
			base.GetItem(12).SetUIActive(true);
			int availableCouponDiscount = data.GetCurrentGoodsData().GetAvailableCouponDiscount();
			base.GetText(13).SetText((-availableCouponDiscount).ToString(), true);
			UUITexture texture = base.GetTexture(14);
			base.SetTextureByPath(availableCouponItem.GetConfig().As<ItemInfo>().Value.IconSmall, texture, null, null);
		}

		// Token: 0x0401E34B RID: 123723
		private ShopSkinData CurrentRoleSkinData;

		// Token: 0x0401E34C RID: 123724
		private PayShopRecommendData RecommendData;

		// Token: 0x0401E34D RID: 123725
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<SkinRewardItemGrid, SkinRewardData> ItemLayout;

		// Token: 0x0200AF81 RID: 44929
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x04036757 RID: 223063
			RewardHorizontalLayout,
			// Token: 0x04036758 RID: 223064
			RewardItem,
			// Token: 0x04036759 RID: 223065
			TimeText,
			// Token: 0x0403675A RID: 223066
			SkinNameText,
			// Token: 0x0403675B RID: 223067
			SkinSubNameText,
			// Token: 0x0403675C RID: 223068
			NowPrice,
			// Token: 0x0403675D RID: 223069
			BeforePrice,
			// Token: 0x0403675E RID: 223070
			BuyButton,
			// Token: 0x0403675F RID: 223071
			HaveItem,
			// Token: 0x04036760 RID: 223072
			BuyItemIcon,
			// Token: 0x04036761 RID: 223073
			TimeLimitBg,
			// Token: 0x04036762 RID: 223074
			TimeLimitItem,
			// Token: 0x04036763 RID: 223075
			ItemCoupon,
			// Token: 0x04036764 RID: 223076
			TextCouponDiscount,
			// Token: 0x04036765 RID: 223077
			TextureCouponIcon
		}
	}
}
