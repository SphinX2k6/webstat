using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E50 RID: 20048
	[NullableContext(2)]
	[Nullable(0)]
	public class TrapDefenseShopView : UiViewBase
	{
		// Token: 0x06033CF0 RID: 212208 RVA: 0x00CF3C83 File Offset: 0x00CF1E83
		[NullableContext(1)]
		public TrapDefenseShopView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033CF1 RID: 212209 RVA: 0x00CF3C8C File Offset: 0x00CF1E8C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 18;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
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
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnRefreshButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033CF2 RID: 212210 RVA: 0x00CF3F4C File Offset: 0x00CF214C
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseShopView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseShopView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033CF3 RID: 212211 RVA: 0x00CF3F90 File Offset: 0x00CF2190
		protected override void OnStart()
		{
			TermExplanationRegistryParam param = new TermExplanationRegistryParam
			{
				UiText = base.GetText(10),
				ViewType = ETermExplanationViewType.Side,
				ReportType = ETermExplanationReportType.TrapDefenseBuff,
				AttachDirection = new ETermExplanationViewAttachDirection?(ETermExplanationViewAttachDirection.Left)
			};
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
		}

		// Token: 0x06033CF4 RID: 212212 RVA: 0x00CF3FD8 File Offset: 0x00CF21D8
		protected override void OnAfterShow()
		{
			if (this.NeedRefreshAfterShow)
			{
				this.NeedRefreshAfterShow = false;
				this.OnShopRefresh();
				return;
			}
			if (this.DefaultGoods != null && ModelBase<TrapDefenseModel>.Instance.ViewModelShop.SelectedGoods == null)
			{
				ModelBase<TrapDefenseModel>.Instance.ViewModelShop.SelectGoods(this.DefaultGoods);
			}
		}

		// Token: 0x06033CF5 RID: 212213 RVA: 0x00CF4029 File Offset: 0x00CF2229
		protected override void OnBeforeHide()
		{
			this.NeedRefreshAfterShow = true;
		}

		// Token: 0x06033CF6 RID: 212214 RVA: 0x00CF4032 File Offset: 0x00CF2232
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseShopRefresh, new Action(this.OnShopRefresh));
		}

		// Token: 0x06033CF7 RID: 212215 RVA: 0x00CF4050 File Offset: 0x00CF2250
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseShopRefresh, new Action(this.OnShopRefresh));
		}

		// Token: 0x06033CF8 RID: 212216 RVA: 0x00CF4070 File Offset: 0x00CF2270
		protected override void OnBeforeDestroy()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelShop.RemoveOnSelectGoodsDelegate(new Action<ITrapDefenseShopGoods>(this.OnSelectGoods));
			ModelBase<TrapDefenseModel>.Instance.ViewModelShop.OnViewClose();
			ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(10));
			this.NeedRefreshAfterShow = false;
		}

		// Token: 0x06033CF9 RID: 212217 RVA: 0x00CF40C0 File Offset: 0x00CF22C0
		private UniTask RefreshGoodsPanel()
		{
			TrapDefenseShopView.<RefreshGoodsPanel>d__19 <RefreshGoodsPanel>d__;
			<RefreshGoodsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshGoodsPanel>d__.<>4__this = this;
			<RefreshGoodsPanel>d__.<>1__state = -1;
			<RefreshGoodsPanel>d__.<>t__builder.Start<TrapDefenseShopView.<RefreshGoodsPanel>d__19>(ref <RefreshGoodsPanel>d__);
			return <RefreshGoodsPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06033CFA RID: 212218 RVA: 0x00CF4104 File Offset: 0x00CF2304
		[NullableContext(1)]
		private void RefreshGoodsDetail(ITrapDefenseShopGoods goods)
		{
			if (goods == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.TowerDefense, ELogAuthor.HYF, "刷新塔防商店时，商品信息不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), goods.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), goods.Desc, goods.DescArgs ?? Array.Empty<string>());
			INumberSelectData data = new INumberSelectData
			{
				MaxNumber = goods.CanPurchaseNum,
				ValueChangeFunction = new Action<int>(this.OnSliderNumberChange)
			};
			this.NumberSelectComponent.Init(data);
			this.NumberSelectComponent.SetUiActive(goods.CanPurchaseNum > 1);
			base.GetItem(11).SetUIActive(!goods.Disable);
			this.PurchaseButton.SetUiActive(!goods.Disable);
			base.GetItem(9).SetUIActive(goods.Disable);
			if (goods.DisableReason == ETrapDefenseShopGoodsUnavailableReason.InventoryCountReachLimit)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), ETrapDefenseTextKey.ShopGoodsInventoryCountReachLimit.ToString(), Array.Empty<object>());
				return;
			}
			if (goods.DisableReason == ETrapDefenseShopGoodsUnavailableReason.SoldOut)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), ETrapDefenseTextKey.ShopGoodsSoldOut.ToString(), Array.Empty<object>());
			}
		}

		// Token: 0x06033CFB RID: 212219 RVA: 0x00CF4259 File Offset: 0x00CF2459
		[NullableContext(1)]
		private void OnSelectGoods(ITrapDefenseShopGoods goods)
		{
			this.RefreshGoodsDetail(goods);
		}

		// Token: 0x06033CFC RID: 212220 RVA: 0x00CF4264 File Offset: 0x00CF2464
		private void OnSliderNumberChange(int value)
		{
			ITrapDefenseShopGoods trapDefenseShopGoods = ModelBase<TrapDefenseModel>.Instance.ViewModelShop.SelectedGoods ?? this.DefaultGoods;
			if (trapDefenseShopGoods == null)
			{
				return;
			}
			bool flag = ModelBase<TrapDefenseModel>.Instance.BattleData.GetGoldNum() >= (long)(trapDefenseShopGoods.CurrentPrice * value);
			base.GetText(14).SetText((trapDefenseShopGoods.CurrentPrice * value).ToString(), true);
			base.GetText(14).SetColor(flag ? this.OriginalCostTextColor.Value : FColor.FromHex("9D2437FF"));
			UUIItem text = base.GetText(15);
			int? originalPrice = trapDefenseShopGoods.OriginalPrice;
			int currentPrice = trapDefenseShopGoods.CurrentPrice;
			text.SetUIActive(!(originalPrice.GetValueOrDefault() == currentPrice & originalPrice != null));
			UUIText text2 = base.GetText(15);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("<s>");
			defaultInterpolatedStringHandler.AppendFormatted<int>(trapDefenseShopGoods.OriginalPrice.GetValueOrDefault() * value);
			defaultInterpolatedStringHandler.AppendLiteral("</s>");
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), ETrapDefenseTextKey.ShopPurchaseNum.ToString(), new <>z__ReadOnlySingleElementList<object>(value));
		}

		// Token: 0x06033CFD RID: 212221 RVA: 0x00CF439C File Offset: 0x00CF259C
		private void OnPurchaseButtonClick(int _)
		{
			ITrapDefenseShopGoods selectedGoods = ModelBase<TrapDefenseModel>.Instance.ViewModelShop.SelectedGoods;
			if (selectedGoods == null)
			{
				return;
			}
			int selectNumber = this.NumberSelectComponent.GetSelectNumber();
			if (selectNumber <= 0)
			{
				return;
			}
			if (ModelBase<TrapDefenseModel>.Instance.BattleData.GetGoldNum() < (long)(selectedGoods.CurrentPrice * selectNumber))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrapDefenseNotEnoughGold", Array.Empty<object>());
				return;
			}
			ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseShopPurchase(selectedGoods.Id, selectedGoods.Type, selectNumber);
		}

		// Token: 0x06033CFE RID: 212222 RVA: 0x00CF441C File Offset: 0x00CF261C
		private void OnRefreshButtonClick()
		{
			long goldNum = ModelBase<TrapDefenseModel>.Instance.BattleData.GetGoldNum();
			int refreshCost = ModelBase<TrapDefenseModel>.Instance.ShopData.RefreshCost;
			if (goldNum < (long)refreshCost)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(ETrapDefenseTextKey.TrapDefenseShopNoCost.ToString(), Array.Empty<object>());
				return;
			}
			ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseShopRefresh();
		}

		// Token: 0x06033CFF RID: 212223 RVA: 0x00CF4478 File Offset: 0x00CF2678
		private void OnShopRefresh()
		{
			this.RefreshGoodsPanel().Forget();
			ITrapDefenseShopGoods selectedGoods = ModelBase<TrapDefenseModel>.Instance.ViewModelShop.SelectedGoods;
			TrapDefenseShopData shopData = ModelBase<TrapDefenseModel>.Instance.ShopData;
			bool flag = shopData.ItemGoodsMap.ContainsKey(selectedGoods.Id) || shopData.BuffGoodsMap.ContainsKey(selectedGoods.Id);
			ModelBase<TrapDefenseModel>.Instance.ViewModelShop.SelectGoods(flag ? selectedGoods : this.DefaultGoods);
			this.CostItem.UpdateGoldCostNum();
		}

		// Token: 0x0401DFA1 RID: 122785
		private PopupCaptionItem Caption;

		// Token: 0x0401DFA2 RID: 122786
		private NumberSelectComponent NumberSelectComponent;

		// Token: 0x0401DFA3 RID: 122787
		private ButtonItem PurchaseButton;

		// Token: 0x0401DFA4 RID: 122788
		private TrapDefenseGoldCostItem CostItem;

		// Token: 0x0401DFA5 RID: 122789
		private TrapDefenseShopCheckBuffItem CheckBuffItem;

		// Token: 0x0401DFA6 RID: 122790
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<TrapDefenseShopGoodsContainerItem, TrapDefenseShopGoodsListData> ScrollView;

		// Token: 0x0401DFA7 RID: 122791
		private ITrapDefenseShopGoods DefaultGoods;

		// Token: 0x0401DFA8 RID: 122792
		private FColor? OriginalCostTextColor;

		// Token: 0x0401DFA9 RID: 122793
		private bool NeedRefreshAfterShow;

		// Token: 0x0200ADEA RID: 44522
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403600D RID: 221197
			public const int ItemCaption = 0;

			// Token: 0x0403600E RID: 221198
			public const int BtnRefresh = 1;

			// Token: 0x0403600F RID: 221199
			public const int ScrollView = 2;

			// Token: 0x04036010 RID: 221200
			public const int TextRefresh = 3;

			// Token: 0x04036011 RID: 221201
			public const int TextureRefreshIcon = 4;

			// Token: 0x04036012 RID: 221202
			public const int TextRefreshCost = 5;

			// Token: 0x04036013 RID: 221203
			public const int TextItemDetailName = 6;

			// Token: 0x04036014 RID: 221204
			public const int ItemPurchase = 7;

			// Token: 0x04036015 RID: 221205
			public const int ItemBtnPurchase = 8;

			// Token: 0x04036016 RID: 221206
			public const int ItemUnavailable = 9;

			// Token: 0x04036017 RID: 221207
			public const int TextItemDetailDesc = 10;

			// Token: 0x04036018 RID: 221208
			public const int ItemPrice = 11;

			// Token: 0x04036019 RID: 221209
			public const int TextPriceLabel = 12;

			// Token: 0x0403601A RID: 221210
			public const int TextureCostIcon = 13;

			// Token: 0x0403601B RID: 221211
			public const int TextPrice = 14;

			// Token: 0x0403601C RID: 221212
			public const int TextOriginalPrice = 15;

			// Token: 0x0403601D RID: 221213
			public const int ItemNumSlider = 16;

			// Token: 0x0403601E RID: 221214
			public const int TextUnavailable = 17;
		}
	}
}
