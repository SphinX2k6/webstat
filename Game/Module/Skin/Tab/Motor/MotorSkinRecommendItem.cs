using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Skin.Tab.Motor
{
	// Token: 0x02004F6C RID: 20332
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorSkinRecommendItem : UiPanelBase
	{
		// Token: 0x060346FF RID: 214783 RVA: 0x00D1EC34 File Offset: 0x00D1CE34
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
				new ValueTuple<int, Type>(14, typeof(UUITexture)),
				new ValueTuple<int, Type>(15, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickBuyButton))
			};
		}

		// Token: 0x06034700 RID: 214784 RVA: 0x00D1EDD8 File Offset: 0x00D1CFD8
		private void OnClickBuyButton()
		{
			MotorSkinBuyDetailViewData motorSkinBuyDetailViewData = MotorSkinBuyDetailViewData.Create(new List<ShopMotorSkinData>
			{
				this.CurrentRoleSkinData
			});
			motorSkinBuyDetailViewData.SetIndex(0);
			motorSkinBuyDetailViewData.SetPreviewTitle("MotorSkinShopTitle_Text");
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorSkinBuyDetailView, motorSkinBuyDetailViewData, null);
			OnClickRecommendSkinButtonLogEvent onClickRecommendSkinButtonLogEvent = new OnClickRecommendSkinButtonLogEvent();
			onClickRecommendSkinButtonLogEvent.i_operation_type = 1;
			ControllerBase<LogReportController>.Instance.LogReport(onClickRecommendSkinButtonLogEvent);
		}

		// Token: 0x06034701 RID: 214785 RVA: 0x00D1EE38 File Offset: 0x00D1D038
		protected override UniTask OnBeforeStartAsync()
		{
			MotorSkinRecommendItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorSkinRecommendItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034702 RID: 214786 RVA: 0x00D1EE7B File Offset: 0x00D1D07B
		protected override void OnStart()
		{
			this.ItemLayout = new GenericLayout<SkinRewardItemGrid, SkinRewardData>(base.GetHorizontalLayout(0), new Func<SkinRewardItemGrid>(this.InitGridItem), null, false, true);
		}

		// Token: 0x06034703 RID: 214787 RVA: 0x00D1EE9E File Offset: 0x00D1D09E
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

		// Token: 0x06034704 RID: 214788 RVA: 0x00D1EECC File Offset: 0x00D1D0CC
		public void Refresh(int recommendId)
		{
			this.RecommendData = ModelBase<PayShopModel>.Instance.GetRecommendDataById(recommendId);
			PayShopGoods payShopGoodsById = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(this.RecommendData.RecommendId);
			if (payShopGoodsById != null)
			{
				this.CurrentRoleSkinData = ShopMotorSkinData.Create(payShopGoodsById);
				TotalTopUpPayAdditiveTagItem totalTopUpTagItem = this.TotalTopUpTagItem;
				if (totalTopUpTagItem != null)
				{
					totalTopUpTagItem.RefreshByGoodsId(payShopGoodsById.GetGoodsId());
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Shop;
				ELogAuthor author = ELogAuthor.LJQ;
				string message = "PayShopData is null";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", recommendId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.RefreshView();
		}

		// Token: 0x06034705 RID: 214789 RVA: 0x00D1EF5C File Offset: 0x00D1D15C
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

		// Token: 0x06034706 RID: 214790 RVA: 0x00D1EFE4 File Offset: 0x00D1D1E4
		private void RefreshTimeText(ShopMotorSkinData data)
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
					if (discountTimeData is string)
					{
						text2.SetText((string)discountTimeData, true);
						return;
					}
					Singleton<LguiUtil>.Instance.SetLocalText(text2, ((CommonDefine.IRemainTime)discountTimeData).TextId, new <>z__ReadOnlySingleElementList<object>(((CommonDefine.IRemainTime)discountTimeData).TimeValue));
					return;
				}
			}
		}

		// Token: 0x06034707 RID: 214791 RVA: 0x00D1F0F4 File Offset: 0x00D1D2F4
		private void RefreshSkinName(ShopMotorSkinData data)
		{
			if (data == null)
			{
				base.GetText(3).SetText("", true);
				return;
			}
			string name = data.GetMotorSkinData().GetName();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), name, Array.Empty<object>());
		}

		// Token: 0x06034708 RID: 214792 RVA: 0x00D1F13C File Offset: 0x00D1D33C
		private void RefreshSubName(ShopMotorSkinData data)
		{
			if (data == null)
			{
				base.GetText(4).SetText("", true);
				return;
			}
			string name = data.GetMotorSkinData().GetName();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), name, Array.Empty<object>());
		}

		// Token: 0x06034709 RID: 214793 RVA: 0x00D1F184 File Offset: 0x00D1D384
		private void RefreshBuyItemIcon(ShopMotorSkinData data)
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

		// Token: 0x0603470A RID: 214794 RVA: 0x00D1F1E4 File Offset: 0x00D1D3E4
		private void RefreshSourcePriceText(ShopMotorSkinData data)
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

		// Token: 0x0603470B RID: 214795 RVA: 0x00D1F280 File Offset: 0x00D1D480
		private void RefreshNowPriceText(ShopMotorSkinData data)
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

		// Token: 0x0603470C RID: 214796 RVA: 0x00D1F2E4 File Offset: 0x00D1D4E4
		private void RefreshBuyButtonState(ShopMotorSkinData data)
		{
			if (data == null)
			{
				base.GetButton(7).RootUIComp.Get().SetUIActive(false);
				base.GetItem(15).SetUIActive(false);
				return;
			}
			bool ifCanBuy = data.GetIfCanBuy();
			base.GetButton(7).RootUIComp.Get().SetUIActive(ifCanBuy);
			base.GetItem(15).SetUIActive(ifCanBuy);
		}

		// Token: 0x0603470D RID: 214797 RVA: 0x00D1F34C File Offset: 0x00D1D54C
		private void RefreshHaveItem(ShopMotorSkinData data)
		{
			if (data == null)
			{
				base.GetItem(8).SetUIActive(false);
				return;
			}
			bool ifCanBuy = data.GetIfCanBuy();
			base.GetItem(8).SetUIActive(!ifCanBuy);
		}

		// Token: 0x0603470E RID: 214798 RVA: 0x00D1F384 File Offset: 0x00D1D584
		private void RefreshLayout(ShopMotorSkinData data)
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
				List<TItem> allReward = data.GetAllReward();
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

		// Token: 0x0603470F RID: 214799 RVA: 0x00D1F46C File Offset: 0x00D1D66C
		private void RefreshCouponDiscount(ShopMotorSkinData data)
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

		// Token: 0x0401E354 RID: 123732
		private ShopMotorSkinData CurrentRoleSkinData;

		// Token: 0x0401E355 RID: 123733
		private PayShopRecommendData RecommendData;

		// Token: 0x0401E356 RID: 123734
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<SkinRewardItemGrid, SkinRewardData> ItemLayout;

		// Token: 0x0401E357 RID: 123735
		private TotalTopUpPayAdditiveTagItem TotalTopUpTagItem;

		// Token: 0x0200AF87 RID: 44935
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x04036776 RID: 223094
			RewardHorizontalLayout,
			// Token: 0x04036777 RID: 223095
			RewardItem,
			// Token: 0x04036778 RID: 223096
			TimeText,
			// Token: 0x04036779 RID: 223097
			SkinNameText,
			// Token: 0x0403677A RID: 223098
			SkinSubNameText,
			// Token: 0x0403677B RID: 223099
			NowPrice,
			// Token: 0x0403677C RID: 223100
			BeforePrice,
			// Token: 0x0403677D RID: 223101
			BuyButton,
			// Token: 0x0403677E RID: 223102
			HaveItem,
			// Token: 0x0403677F RID: 223103
			BuyItemIcon,
			// Token: 0x04036780 RID: 223104
			TimeLimitBg,
			// Token: 0x04036781 RID: 223105
			TimeLimitItem,
			// Token: 0x04036782 RID: 223106
			ItemCoupon,
			// Token: 0x04036783 RID: 223107
			TextCouponDiscount,
			// Token: 0x04036784 RID: 223108
			TextureCouponIcon,
			// Token: 0x04036785 RID: 223109
			TotalTopUpTagRoot
		}
	}
}
