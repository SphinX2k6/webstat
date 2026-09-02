using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020023F0 RID: 9200
[NullableContext(2)]
[Nullable(0)]
public class GiftPackageDetailsView : UiViewBase
{
	// Token: 0x06011CD3 RID: 72915 RVA: 0x004E57CC File Offset: 0x004E39CC
	[NullableContext(1)]
	public GiftPackageDetailsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011CD4 RID: 72916 RVA: 0x004E57DC File Offset: 0x004E39DC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 18;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIInteractionGroup));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.CancelClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011CD5 RID: 72917 RVA: 0x004E5A9C File Offset: 0x004E3C9C
	private void CancelClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06011CD6 RID: 72918 RVA: 0x004E5AA8 File Offset: 0x004E3CA8
	private void ConfirmClick()
	{
		if (this.GoodsData.PayPackageType.GetValueOrDefault() == EPayGiftType.CdkGift)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CdkGiftBuyConfirm);
			confirmBoxDataNew.FunctionMap[2] = new Action(this.DoConfirmPurchase);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.DoConfirmPurchase();
	}

	// Token: 0x06011CD7 RID: 72919 RVA: 0x004E5B00 File Offset: 0x004E3D00
	private void DoConfirmPurchase()
	{
		if (this.IsEnoughMoney() && this.GoodsData.IfPayGift())
		{
			ControllerBase<PayGiftController>.Instance.SdkPay(this.GoodsData.Id);
			base.CloseMe(null);
			return;
		}
		if (this.IsEnoughMoney() && !this.GoodsData.IfPayGift())
		{
			ControllerBase<PayShopController>.Instance.SendRequestPayShopBuy(this.GoodsData.Id, 1);
			base.CloseMe(null);
			return;
		}
		if (this.GoodsData.Price.Id == 4)
		{
			ControllerBase<PayShopController>.Instance.OpenPayShopViewToRecharge();
			base.CloseMe(null);
			return;
		}
		TableTextArgNew tableTextArgNew = new TableTextArgNew(ConfigBase<InventoryConfig>.Instance.GetItemConfig(this.GoodsData.Price.Id).Value.Name, Array.Empty<object>());
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ShopResourceNotEnough", new object[]
		{
			tableTextArgNew
		});
	}

	// Token: 0x06011CD8 RID: 72920 RVA: 0x004E5BE8 File Offset: 0x004E3DE8
	protected override void OnBeforeCreate()
	{
		ExchangePopData exchangePopData = (ExchangePopData)this.OpenParam;
		this.Goods = exchangePopData.PayShopGoods;
		this.GoodsData = this.Goods.GetGoodsData();
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.GoodsData.ItemId);
		this.Id = null;
		foreach (KeyValuePair<int, int> keyValuePair in itemConfigData.Parameters)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			if (!string.IsNullOrEmpty(Enum.GetName(typeof(EItemFunctionType), key)))
			{
				this.ItemType = (EItemFunctionType)key;
				this.Id = new int?(value);
				break;
			}
		}
		if (this.Id == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "检查道具ID的参数（Parameters）字段 是否 表示为正确的指向道具id的参数";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("道具ID", this.GoodsData.ItemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x06011CD9 RID: 72921 RVA: 0x004E5D08 File Offset: 0x004E3F08
	protected override UniTask OnCreateAsync()
	{
		GiftPackageDetailsView.<OnCreateAsync>d__17 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>4__this = this;
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<GiftPackageDetailsView.<OnCreateAsync>d__17>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011CDA RID: 72922 RVA: 0x004E5D4C File Offset: 0x004E3F4C
	[NullableContext(1)]
	private UniTask InitItem(PayShopGoods data)
	{
		GiftPackageDetailsView.<InitItem>d__18 <InitItem>d__;
		<InitItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitItem>d__.<>4__this = this;
		<InitItem>d__.data = data;
		<InitItem>d__.<>1__state = -1;
		<InitItem>d__.<>t__builder.Start<GiftPackageDetailsView.<InitItem>d__18>(ref <InitItem>d__);
		return <InitItem>d__.<>t__builder.Task;
	}

	// Token: 0x06011CDB RID: 72923 RVA: 0x004E5D97 File Offset: 0x004E3F97
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PayShopGoodsBuy, new Action(this.CancelClick));
	}

	// Token: 0x06011CDC RID: 72924 RVA: 0x004E5DB5 File Offset: 0x004E3FB5
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PayShopGoodsBuy, new Action(this.CancelClick));
	}

	// Token: 0x06011CDD RID: 72925 RVA: 0x004E5DD4 File Offset: 0x004E3FD4
	protected override void OnStart()
	{
		if (this.Id == null)
		{
			return;
		}
		this.ConfirmBtn = new ButtonItem(base.GetItem(5));
		this.ConfirmBtn.SetFunction(delegate(int _)
		{
			this.ConfirmClick();
		});
		UUIItem item = base.GetItem(1);
		if (this.ItemType == EItemFunctionType.AutoOpenMonthCard)
		{
			this.LoadedItem = new GiftPackageMonthlyCardItem(this.Id.Value, item);
		}
		else if (this.ItemType == EItemFunctionType.AutoOpenGift || this.ItemType == EItemFunctionType.ManualOpenGift)
		{
			this.LoadedItem = new GiftPackageSupplyPackItem(this.Id.Value, item, this.Goods);
		}
		PayShopItem payShopItem = this.PayShopItem;
		if (payShopItem != null)
		{
			UUIItem originalItem = payShopItem.GetOriginalItem();
			if (originalItem != null)
			{
				originalItem.SetUIParent(base.GetItem(0), false);
			}
		}
		IGiftDisplayItem skinItem = this.SkinItem;
		if (skinItem != null)
		{
			UUIItem originalItem2 = skinItem.GetOriginalItem();
			if (originalItem2 != null)
			{
				originalItem2.SetUIParent(base.GetItem(0), false);
			}
		}
		PayShopItem payShopItem2 = this.PayShopItem;
		if (payShopItem2 != null)
		{
			payShopItem2.SetActive(true);
		}
		IGiftDisplayItem skinItem2 = this.SkinItem;
		if (skinItem2 == null)
		{
			return;
		}
		skinItem2.SetActive(true);
	}

	// Token: 0x06011CDE RID: 72926 RVA: 0x004E5EE0 File Offset: 0x004E40E0
	protected override void OnBeforeShow()
	{
		PayShopItem payShopItem = this.PayShopItem;
		if (payShopItem != null)
		{
			payShopItem.HidePackageViewElement();
		}
		this.RefreshPayShopItemLeftTimeTextShowState();
		PayShopItem payShopItem2 = this.PayShopItem;
		if (payShopItem2 != null)
		{
			payShopItem2.Refresh(this.Goods, false, 0);
		}
		IGiftDisplayItem skinItem = this.SkinItem;
		if (skinItem != null)
		{
			skinItem.Refresh(this.Goods, false, 0);
		}
		this.SetInteractionGroup();
		this.RefreshReSellText();
		this.RefreshCurrency().Forget();
		this.RefreshCloudGameTip();
		this.RefreshItemCouponTip();
		this.RefreshTotalTopUpTips();
	}

	// Token: 0x06011CDF RID: 72927 RVA: 0x004E5F60 File Offset: 0x004E4160
	private void RefreshPayShopItemLeftTimeTextShowState()
	{
		int monthCardShopId = ConfigBase<PayShopConfig>.Instance.GetMonthCardShopId();
		PayShopGoods goods = this.Goods;
		if (goods != null && goods.GetGoodsId() == monthCardShopId)
		{
			PayShopItem payShopItem = this.PayShopItem;
			if (payShopItem == null)
			{
				return;
			}
			payShopItem.SetLeftTimeTextShowState(true);
		}
	}

	// Token: 0x06011CE0 RID: 72928 RVA: 0x004E5FA0 File Offset: 0x004E41A0
	private UniTask RefreshCurrency()
	{
		GiftPackageDetailsView.<RefreshCurrency>d__24 <RefreshCurrency>d__;
		<RefreshCurrency>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCurrency>d__.<>4__this = this;
		<RefreshCurrency>d__.<>1__state = -1;
		<RefreshCurrency>d__.<>t__builder.Start<GiftPackageDetailsView.<RefreshCurrency>d__24>(ref <RefreshCurrency>d__);
		return <RefreshCurrency>d__.<>t__builder.Task;
	}

	// Token: 0x06011CE1 RID: 72929 RVA: 0x004E5FE3 File Offset: 0x004E41E3
	private void RefreshCloudGameTip()
	{
		base.GetItem(9).SetUIActive(this.Goods.HasCloudGameInfo() && !this.Goods.GetIfNeedExtraLimitText());
	}

	// Token: 0x06011CE2 RID: 72930 RVA: 0x004E6010 File Offset: 0x004E4210
	private void RefreshItemCouponTip()
	{
		UUIItem item = base.GetItem(10);
		UUITexture texture = base.GetTexture(12);
		UUIText text = base.GetText(11);
		CommonItemData availableCouponItem = this.Goods.GetAvailableCouponItem();
		if (availableCouponItem == null || this.Goods.IsDirect() || !this.Goods.GetPriceData().Enough || this.Goods.GetIfNeedExtraLimitText())
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		int availableCouponDiscount = this.Goods.GetAvailableCouponDiscount();
		int currencyId = this.Goods.GetPriceData().CurrencyId;
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(currencyId);
		string text2 = "<texture=" + ((itemConfig != null) ? itemConfig.GetValueOrDefault().IconSmall : null) + ",0.6/>";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "ItemInfo_50020_Tip", new <>z__ReadOnlyArray<object>(new object[]
		{
			availableCouponDiscount,
			text2
		}));
		base.SetTextureByPath(availableCouponItem.GetConfig().As<ItemInfo>().Value.IconSmall, texture, null, null);
	}

	// Token: 0x06011CE3 RID: 72931 RVA: 0x004E6138 File Offset: 0x004E4338
	private void RefreshTotalTopUpTips()
	{
		UUIItem item = base.GetItem(15);
		TotalTopUpController instance = ControllerBase<TotalTopUpController>.Instance;
		TotalTopUpData totalTopUpData = (instance != null) ? instance.GetSingleActivityData() : null;
		if (totalTopUpData == null)
		{
			item.SetUIActive(false);
			return;
		}
		int num = 0;
		int num2;
		if (totalTopUpData.GoodsScoreMap != null && totalTopUpData.GoodsScoreMap.TryGetValue(this.GoodsData.Id, out num2))
		{
			num = num2;
		}
		if (num <= 0)
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		base.GetText(16).SetText(num.ToString(), true);
		UUITexture texture = base.GetTexture(17);
		TotalTopUpData totalTopUpData2 = totalTopUpData;
		string text = (totalTopUpData2.ViewConfig != null) ? totalTopUpData2.ViewConfig.GetValueOrDefault().ScoreIcon : null;
		if (!string.IsNullOrEmpty(text))
		{
			base.SetTextureByPath(text, texture, null, null);
		}
	}

	// Token: 0x06011CE4 RID: 72932 RVA: 0x004E6203 File Offset: 0x004E4403
	private void BeforeEnterPayShop()
	{
		base.CloseMe(null);
	}

	// Token: 0x06011CE5 RID: 72933 RVA: 0x004E620C File Offset: 0x004E440C
	protected override void OnBeforeDestroy()
	{
		if (this.LoadedItem != null)
		{
			this.LoadedItem.Destroy(null);
		}
		this.RemoveResellTimer();
	}

	// Token: 0x06011CE6 RID: 72934 RVA: 0x004E6228 File Offset: 0x004E4428
	protected void RemoveResellTimer()
	{
		if (this.ResellTimerId != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.ResellTimerId);
			this.ResellTimerId = null;
		}
	}

	// Token: 0x06011CE7 RID: 72935 RVA: 0x004E624C File Offset: 0x004E444C
	private void RefreshReSellText()
	{
		this.RemoveResellTimer();
		string exchangePopViewResellText = this.Goods.GetExchangePopViewResellText();
		if (this.Goods.GetIfNeedExtraLimitText())
		{
			string extraLimitText = this.Goods.GetExtraLimitText();
			if (!string.IsNullOrEmpty(extraLimitText))
			{
				this.SetResellItemShowState(true);
				base.GetText(8).ShowTextNew(extraLimitText);
			}
			return;
		}
		if (!this.Goods.GetPriceData().Enough)
		{
			if (!string.IsNullOrEmpty(exchangePopViewResellText))
			{
				base.GetText(8).ShowTextNew(exchangePopViewResellText);
				return;
			}
			this.SetResellItemShowState(true);
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.Goods.GetPriceData().CurrencyId);
			if (itemConfigData != null)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(itemConfigData.Name, null);
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.Goods.GetPriceData().CurrencyId, 0);
				int num = this.Goods.GetPriceData().NowPrice - itemCountByConfigId;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "CurrencyNotEnoughDetailed", new <>z__ReadOnlyArray<object>(new object[]
				{
					localTextNew,
					num
				}));
			}
			return;
		}
		else
		{
			ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> countDownData = this.Goods.GetCountDownData();
			if (countDownData.Item1 != EPayCountTimeType.Resell)
			{
				this.SetResellItemShowState(false);
				base.GetText(8).SetUIActive(false);
				return;
			}
			this.SetResellItemShowState(true);
			if (!string.IsNullOrEmpty(exchangePopViewResellText))
			{
				base.GetText(8).ShowTextNew(exchangePopViewResellText);
			}
			this.ResellTimerId = TimerSystem.RealTimeInstance.Delay(delegate(float _)
			{
				this.RefreshReSellText();
			}, (float)countDownData.Item3 * 1000f, null, null, true, 1f);
			return;
		}
	}

	// Token: 0x06011CE8 RID: 72936 RVA: 0x004E63D9 File Offset: 0x004E45D9
	private void SetResellItemShowState(bool state)
	{
		base.GetItem(7).SetUIActive(state);
		this.RefreshDisclaimerText(state);
	}

	// Token: 0x06011CE9 RID: 72937 RVA: 0x004E63F0 File Offset: 0x004E45F0
	private void RefreshDisclaimerText(bool resellItemShowState)
	{
		PayShopGoodsData goodsData = this.GoodsData;
		string text = (goodsData != null) ? goodsData.DisclaimerText : null;
		bool flag = !string.IsNullOrEmpty(text) && !resellItemShowState;
		base.GetItem(13).SetUIActive(flag);
		if (flag)
		{
			base.GetText(14).SetText(text, true);
		}
	}

	// Token: 0x06011CEA RID: 72938 RVA: 0x004E6440 File Offset: 0x004E4640
	protected bool IsEnoughMoney()
	{
		return this.GoodsData.IsDirect() || this.Goods.GetPriceData().Enough;
	}

	// Token: 0x06011CEB RID: 72939 RVA: 0x004E6464 File Offset: 0x004E4664
	protected void SetInteractionGroup()
	{
		UUIInteractionGroup interactionGroup = base.GetInteractionGroup(6);
		IPriceData priceData = this.Goods.GetPriceData();
		bool flag = priceData.CurrencyId != 4 && !priceData.Enough;
		if (this.Goods.IsLocked() || this.Goods.IsSoldOut() || !this.Goods.IfCanBuy() || flag)
		{
			interactionGroup.SetInteractable(false);
			return;
		}
		interactionGroup.SetInteractable(true);
		ButtonItem confirmBtn = this.ConfirmBtn;
		if (confirmBtn == null)
		{
			return;
		}
		confirmBtn.SetLocalTextNew(priceData.Enough ? "PrefabTextItem_2105804973_Text" : "CurrencyNotEnoughGo", Array.Empty<object>());
	}

	// Token: 0x04008B4C RID: 35660
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly IGiftItemRegistryEntry[] GiftItemRegistry = new IGiftItemRegistryEntry[]
	{
		new IGiftItemRegistryEntry
		{
			Check = ((PayShopGoods data) => data.CheckIfRoleSkinGoods()),
			Resource = "UiItem_ShopSkinItem",
			Create = (() => new PayShopSkinItem())
		},
		new IGiftItemRegistryEntry
		{
			Check = ((PayShopGoods data) => data.CheckIfFlySkinGoods()),
			Resource = "UiItem_ShopSkinItem",
			Create = (() => new PayShopFlySkinItem())
		},
		new IGiftItemRegistryEntry
		{
			Check = ((PayShopGoods data) => data.CheckIfOrnamentGoods()),
			Resource = "UiItem_ShopSkinItem",
			Create = (() => new PayShopOrnamentItem())
		}
	};

	// Token: 0x04008B4D RID: 35661
	private PayShopItem PayShopItem;

	// Token: 0x04008B4E RID: 35662
	private IGiftDisplayItem SkinItem;

	// Token: 0x04008B4F RID: 35663
	protected PayShopGoods Goods;

	// Token: 0x04008B50 RID: 35664
	protected PayShopGoodsData GoodsData;

	// Token: 0x04008B51 RID: 35665
	protected TimerHandle ResellTimerId;

	// Token: 0x04008B52 RID: 35666
	protected ButtonItem ConfirmBtn;

	// Token: 0x04008B53 RID: 35667
	private EItemFunctionType ItemType = EItemFunctionType.ManualOpenGift;

	// Token: 0x04008B54 RID: 35668
	private UiPanelBase LoadedItem;

	// Token: 0x04008B55 RID: 35669
	private int? Id;

	// Token: 0x02008726 RID: 34598
	[NullableContext(0)]
	private class EGiftPackageDetailsViewDefine
	{
		// Token: 0x0402DB72 RID: 187250
		public const int GiftItem = 0;

		// Token: 0x0402DB73 RID: 187251
		public const int GiftDetailItem = 1;

		// Token: 0x0402DB74 RID: 187252
		public const int EndTimeItem = 2;

		// Token: 0x0402DB75 RID: 187253
		public const int EndTimeText = 3;

		// Token: 0x0402DB76 RID: 187254
		public const int CancelButton = 4;

		// Token: 0x0402DB77 RID: 187255
		public const int ConfirmButton = 5;

		// Token: 0x0402DB78 RID: 187256
		public const int InteractionGroup = 6;

		// Token: 0x0402DB79 RID: 187257
		public const int ReSellItem = 7;

		// Token: 0x0402DB7A RID: 187258
		public const int ReSellText = 8;

		// Token: 0x0402DB7B RID: 187259
		public const int CloudGameTip = 9;

		// Token: 0x0402DB7C RID: 187260
		public const int ItemCouponTip = 10;

		// Token: 0x0402DB7D RID: 187261
		public const int TextCouponDiscount = 11;

		// Token: 0x0402DB7E RID: 187262
		public const int TextureCouponIcon = 12;

		// Token: 0x0402DB7F RID: 187263
		public const int DisclaimerPanel = 13;

		// Token: 0x0402DB80 RID: 187264
		public const int DisclaimerText = 14;

		// Token: 0x0402DB81 RID: 187265
		public const int ItemTotalTopUpTips = 15;

		// Token: 0x0402DB82 RID: 187266
		public const int TextTotalTopUpTips = 16;

		// Token: 0x0402DB83 RID: 187267
		public const int TextureTotalTopUpIcon = 17;
	}
}
