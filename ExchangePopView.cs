using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020023EA RID: 9194
[NullableContext(2)]
[Nullable(0)]
public class ExchangePopView : UiViewBase
{
	// Token: 0x1700166E RID: 5742
	// (get) Token: 0x06011CA1 RID: 72865 RVA: 0x004E4633 File Offset: 0x004E2833
	private int BuyCount
	{
		get
		{
			return this.NumberSelect.GetSelectNumber();
		}
	}

	// Token: 0x06011CA2 RID: 72866 RVA: 0x004E4640 File Offset: 0x004E2840
	[NullableContext(1)]
	public ExchangePopView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011CA3 RID: 72867 RVA: 0x004E4650 File Offset: 0x004E2850
	protected unsafe override void OnRegisterComponent()
	{
		int num = 19;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
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
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.CancelClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.ConfirmClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011CA4 RID: 72868 RVA: 0x004E4958 File Offset: 0x004E2B58
	protected override void OnBeforeCreate()
	{
		ExchangePopData exchangePopData = (ExchangePopData)this.OpenParam;
		this.Goods = exchangePopData.PayShopGoods;
	}

	// Token: 0x06011CA5 RID: 72869 RVA: 0x004E4980 File Offset: 0x004E2B80
	protected override UniTask OnCreateAsync()
	{
		ExchangePopView.<OnCreateAsync>d__14 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>4__this = this;
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<ExchangePopView.<OnCreateAsync>d__14>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011CA6 RID: 72870 RVA: 0x004E49C3 File Offset: 0x004E2BC3
	private void CancelClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06011CA7 RID: 72871 RVA: 0x004E49CC File Offset: 0x004E2BCC
	private void ConfirmClick()
	{
		PayShopGoodsData goodsData = this.Goods.GetGoodsData();
		if (!this.IsEnoughMoney())
		{
			TableTextArgNew tableTextArgNew = new TableTextArgNew(ConfigBase<InventoryConfig>.Instance.GetItemConfigData(goodsData.Price.Id).Name, Array.Empty<object>());
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ShopResourceNotEnough", new object[]
			{
				tableTextArgNew
			});
			return;
		}
		ExchangePopData exchangePopData = (ExchangePopData)this.OpenParam;
		if (exchangePopData.CheckIfCanBuy != null && !exchangePopData.CheckIfCanBuy())
		{
			return;
		}
		if (this.NeedShowSecondConfirm())
		{
			this.ShowBuySecondConfirmBox();
			return;
		}
		this.SendBuyRequest();
	}

	// Token: 0x06011CA8 RID: 72872 RVA: 0x004E4A64 File Offset: 0x004E2C64
	private bool NeedShowSecondConfirm()
	{
		PayShopGoodsData goodsData = this.Goods.GetGoodsData();
		return goodsData != null && goodsData.ConfirmLimitCount > 0 && this.BuyCount >= goodsData.ConfirmLimitCount;
	}

	// Token: 0x06011CA9 RID: 72873 RVA: 0x004E4AA0 File Offset: 0x004E2CA0
	private void ShowBuySecondConfirmBox()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BuyItemSecondConfirm);
		confirmBoxDataNew.CanClickDuringTimer = false;
		confirmBoxDataNew.FunctionMap[2] = new Action(this.SendBuyRequest);
		PayShopGoodsData goodsData = this.Goods.GetGoodsData();
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(goodsData.Price.Id);
		string str = StringUtils.Format("<texture={0}>", new string[]
		{
			itemConfigData.IconSmall
		});
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(itemConfigData.Name, null);
		int num = this.BuyCount * goodsData.GetNowPrice();
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(goodsData.ItemId);
		string str2 = StringUtils.Format("<texture={0}>", new string[]
		{
			itemConfigData2.IconSmall
		});
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(itemConfigData2.Name, null);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			str + localTextNew,
			num.ToString(),
			str2 + localTextNew2,
			this.BuyCount.ToString()
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06011CAA RID: 72874 RVA: 0x004E4BB8 File Offset: 0x004E2DB8
	private void SendBuyRequest()
	{
		PayShopGoodsData goodsData = this.Goods.GetGoodsData();
		ControllerBase<PayShopController>.Instance.SendRequestPayShopBuy(goodsData.Id, this.BuyCount);
	}

	// Token: 0x06011CAB RID: 72875 RVA: 0x004E4BE7 File Offset: 0x004E2DE7
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PayShopGoodsBuy, new Action(this.CancelClick));
		Singleton<EventSystem>.Instance.Add(EEventName.DiscountShopTimerRefresh, new Action(this.OnDiscountShopTimerRefresh));
	}

	// Token: 0x06011CAC RID: 72876 RVA: 0x004E4C21 File Offset: 0x004E2E21
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PayShopGoodsBuy, new Action(this.CancelClick));
		Singleton<EventSystem>.Instance.Remove(EEventName.DiscountShopTimerRefresh, new Action(this.OnDiscountShopTimerRefresh));
	}

	// Token: 0x06011CAD RID: 72877 RVA: 0x004E4C5B File Offset: 0x004E2E5B
	private void OnDiscountShopTimerRefresh()
	{
		this.RefreshView();
	}

	// Token: 0x06011CAE RID: 72878 RVA: 0x004E4C63 File Offset: 0x004E2E63
	[NullableContext(1)]
	private TableTextArgNew GetExchangeTableText(int selectValue)
	{
		return new TableTextArgNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("BugCount"), new <>z__ReadOnlySingleElementList<object>(selectValue));
	}

	// Token: 0x06011CAF RID: 72879 RVA: 0x004E4C84 File Offset: 0x004E2E84
	private void ValueChangeFunction(int selectValue)
	{
		this.SetPrice();
	}

	// Token: 0x06011CB0 RID: 72880 RVA: 0x004E4C8C File Offset: 0x004E2E8C
	protected override void OnStart()
	{
		this.SetMaxCanBuyCount();
		this.BuyInteractionGroup = (base.GetButton(7).GetOwner().GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup);
		this.NumberSelect = new NumberSelectComponent(base.GetItem(9));
		INumberSelectData data = new INumberSelectData
		{
			MaxNumber = this.BuyCountMax,
			GetExchangeTableText = new Func<int, TableTextArgNew>(this.GetExchangeTableText),
			ValueChangeFunction = new Action<int>(this.ValueChangeFunction)
		};
		this.NumberSelect.Init(data);
		this.NumberSelect.SetMaxBtnShowState(this.Goods.GetGoodsData().IsBuyMaxButton);
		this.RefreshNumberSelectComponentButtonState();
		base.GetItem(13).SetUIActive(true);
	}

	// Token: 0x06011CB1 RID: 72881 RVA: 0x004E4D49 File Offset: 0x004E2F49
	private void RefreshNumberSelectComponentButtonState()
	{
		if (this.NumberSelect.GetIfLimit())
		{
			this.NumberSelect.SetAddReduceButtonActive(true);
			this.NumberSelect.SetAddReduceButtonInteractive(false);
		}
	}

	// Token: 0x06011CB2 RID: 72882 RVA: 0x004E4D70 File Offset: 0x004E2F70
	protected override void OnBeforeShow()
	{
		base.GetText(10).SetUIActive(false);
		base.GetText(16).SetUIActive(false);
		this.RefreshView();
		this.SetPriceIcon();
		this.RefreshCurrency().Forget();
	}

	// Token: 0x06011CB3 RID: 72883 RVA: 0x004E4DA8 File Offset: 0x004E2FA8
	private void RefreshView()
	{
		UUIItem item = base.GetItem(2);
		this.ShowItem.GetOriginalItem().SetUIParent(item, false);
		this.ShowItem.HideExchangePopViewElement();
		if (this.Goods.GetGoodsData().HasOnceBuyLimit())
		{
			this.ShowItem.SetNeedShowOnceBuyLimit(true);
		}
		this.ShowItem.Refresh(this.Goods, false, 0);
		this.SetEndTime();
		this.SetInteractionGroup();
		this.SetNameAndDescribe();
		this.RefreshReSellText();
		this.RefreshLeftTimeText();
		this.RefreshTimeItem();
		this.RefreshCurrentNum();
	}

	// Token: 0x06011CB4 RID: 72884 RVA: 0x004E4E38 File Offset: 0x004E3038
	private UniTask RefreshCurrency()
	{
		ExchangePopView.<RefreshCurrency>d__29 <RefreshCurrency>d__;
		<RefreshCurrency>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCurrency>d__.<>4__this = this;
		<RefreshCurrency>d__.<>1__state = -1;
		<RefreshCurrency>d__.<>t__builder.Start<ExchangePopView.<RefreshCurrency>d__29>(ref <RefreshCurrency>d__);
		return <RefreshCurrency>d__.<>t__builder.Task;
	}

	// Token: 0x06011CB5 RID: 72885 RVA: 0x004E4E7B File Offset: 0x004E307B
	private void BeforeEnterPayShop()
	{
		base.CloseMe(null);
	}

	// Token: 0x06011CB6 RID: 72886 RVA: 0x004E4E84 File Offset: 0x004E3084
	protected override void OnBeforeDestroy()
	{
		this.NumberSelect.Destroy(null);
		this.ShowItem.Destroy(null);
		this.RemoveResellTimer();
	}

	// Token: 0x06011CB7 RID: 72887 RVA: 0x004E4EA4 File Offset: 0x004E30A4
	protected void SetMaxCanBuyCount()
	{
		ExchangePopData exchangePopData = (ExchangePopData)this.OpenParam;
		if (exchangePopData.GetMaxBuyCount != null)
		{
			this.BuyCountMax = exchangePopData.GetMaxBuyCount();
			return;
		}
		PayShopGoodsData goodsData = this.Goods.GetGoodsData();
		int id = goodsData.Price.Id;
		int num = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(id, 0) / goodsData.GetNowPrice();
		if (goodsData.HasBuyLimit())
		{
			this.BuyCountMax = Math.Min(goodsData.GetRemainingCount(), num);
		}
		else
		{
			this.BuyCountMax = num;
		}
		if (goodsData.HasOnceBuyLimit())
		{
			this.BuyCountMax = Math.Min(this.BuyCountMax, goodsData.OnceBuyLimit);
		}
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(goodsData.ItemId);
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(goodsData.ItemId));
		if (itemConfigData != null && itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleItem && itemConfigData.ShowTypes.ToList<int>().Contains(30))
		{
			this.BuyCountMax = 1;
		}
		if (itemConfigData.ShowTypes.ToList<int>().Contains(30))
		{
			int[] resonantItemRoleId = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(goodsData.ItemId);
			int num2 = ModelBase<RoleModel>.Instance.GetRoleLeftResonantCountWithInventoryItem(resonantItemRoleId[0]);
			num2 = ((num2 == 0) ? 1 : num2);
			this.BuyCountMax = ((this.BuyCountMax > num2) ? num2 : this.BuyCountMax);
		}
	}

	// Token: 0x06011CB8 RID: 72888 RVA: 0x004E4FF0 File Offset: 0x004E31F0
	protected void SetEndTime()
	{
		ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> countDownData = this.Goods.GetCountDownData();
		if (countDownData.Item3 == 0.0)
		{
			base.GetItem(15).SetUIActive(false);
			this.CurrentEndTimeShowState = false;
			return;
		}
		CommonDefine.IPayShowCountDownRemainTime item = this.Goods.GetCountDownData().Item2;
		base.GetText(14).SetUIActive(countDownData.Item1 == EPayCountTimeType.NeverResell);
		if (countDownData.Item1 == EPayCountTimeType.NeverResell)
		{
			base.GetText(14).ShowTextNew("DownShopItem");
		}
		else if (countDownData.Item1 == EPayCountTimeType.Resell)
		{
			base.GetText(14).ShowTextNew("ReUpShopItem");
		}
		else if (countDownData.Item1 == EPayCountTimeType.Discount)
		{
			base.GetText(14).ShowTextNew("DiscountItem");
		}
		if (item != null)
		{
			base.GetItem(15).SetUIActive(true);
			this.CurrentEndTimeShowState = true;
			UUIText text = base.GetText(1);
			CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = item as CommonDefine.PayShowCountDownRemainTime<string>;
			if (payShowCountDownRemainTime != null)
			{
				text.SetText(payShowCountDownRemainTime.Value, true);
				return;
			}
			CommonDefine.IRemainTime remainTime = item as CommonDefine.IRemainTime;
			if (remainTime != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, remainTime.TextId, new <>z__ReadOnlySingleElementList<object>(remainTime.TimeValue));
				return;
			}
		}
		else
		{
			base.GetItem(15).SetUIActive(false);
			this.CurrentEndTimeShowState = false;
		}
	}

	// Token: 0x06011CB9 RID: 72889 RVA: 0x004E512C File Offset: 0x004E332C
	protected void SetInteractionGroup()
	{
		if (this.Goods.IsLocked() || this.Goods.IsSoldOut() || !this.Goods.IfCanBuy() || !this.Goods.GetPriceData().Enough)
		{
			this.BuyInteractionGroup.SetInteractable(false);
			return;
		}
		this.BuyInteractionGroup.SetInteractable(true);
	}

	// Token: 0x06011CBA RID: 72890 RVA: 0x004E518C File Offset: 0x004E338C
	protected void SetPriceIcon()
	{
		PayShopGoodsData goodsData = this.Goods.GetGoodsData();
		UUITexture texture = base.GetTexture(3);
		base.SetItemIcon(texture, goodsData.Price.Id, null, null);
		base.GetText(4).SetText((this.BuyCount * goodsData.GetNowPrice()).ToString(), true);
	}

	// Token: 0x06011CBB RID: 72891 RVA: 0x004E51EC File Offset: 0x004E33EC
	protected void SetPrice()
	{
		PayShopGoodsData goodsData = this.Goods.GetGoodsData();
		UUIText text = base.GetText(4);
		int num = this.BuyCount * goodsData.GetNowPrice();
		bool flag = this.IsEnoughMoney();
		UUIItem uuiitem = text;
		bool bUseChangeColor = !flag;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		text.SetText(num.ToString(), true);
	}

	// Token: 0x06011CBC RID: 72892 RVA: 0x004E524C File Offset: 0x004E344C
	protected void SetNameAndDescribe()
	{
		PayShopGoodsData goodsData = this.Goods.GetGoodsData();
		string key;
		if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(goodsData.ItemId)) == InventoryDefine.EItemDataType.RoleItem)
		{
			key = ConfigBase<RoleConfig>.Instance.GetRoleConfig(goodsData.ItemId).Value.Introduction;
		}
		else
		{
			key = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(goodsData.ItemId).AttributesDescription;
		}
		base.GetText(5).ShowTextNew(key);
	}

	// Token: 0x06011CBD RID: 72893 RVA: 0x004E52CC File Offset: 0x004E34CC
	protected bool IsEnoughMoney()
	{
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfig = this.Goods.GetGoodsData().GetItemConfig();
		if (itemConfig != null)
		{
			int[] showTypes = itemConfig.ShowTypes;
			if (showTypes != null && showTypes.ToList<int>().Contains(30))
			{
				int roleId = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(this.Goods.GetGoodsData().ItemId)[0];
				int roleLeftResonantCountWithInventoryItem = ModelBase<RoleModel>.Instance.GetRoleLeftResonantCountWithInventoryItem(roleId);
				if (this.BuyCount > roleLeftResonantCountWithInventoryItem)
				{
					return false;
				}
			}
		}
		PayShopGoodsData goodsData = this.Goods.GetGoodsData();
		int id = goodsData.Price.Id;
		return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(id, 0) >= goodsData.GetNowPrice() * this.BuyCount;
	}

	// Token: 0x06011CBE RID: 72894 RVA: 0x004E5374 File Offset: 0x004E3574
	private void RefreshTimeItem()
	{
		string buyLimitText = this.Goods.GetBuyLimitText();
		bool uiactive = this.CurrentEndTimeShowState || !string.IsNullOrEmpty(buyLimitText);
		base.GetItem(8).SetUIActive(uiactive);
	}

	// Token: 0x06011CBF RID: 72895 RVA: 0x004E53B0 File Offset: 0x004E35B0
	private void RefreshLeftTimeText()
	{
		string exchangeViewShopTipsText = this.Goods.GetExchangeViewShopTipsText();
		UUIText text;
		if (this.CurrentEndTimeShowState)
		{
			text = base.GetText(10);
		}
		else
		{
			text = base.GetText(16);
		}
		text.SetUIActive(exchangeViewShopTipsText != "");
		text.SetText(exchangeViewShopTipsText, true);
		if (text != null)
		{
			text.SetColor(FColor.FromHex("FED12E"));
		}
	}

	// Token: 0x06011CC0 RID: 72896 RVA: 0x004E5414 File Offset: 0x004E3614
	private void RefreshCurrentNum()
	{
		PayShopGoodsData goodsData = this.Goods.GetGoodsData();
		if (goodsData.IsShowHaveNum)
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(goodsData.ItemId, 0);
			base.GetItem(17).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(18), "CurrentHoldText", new <>z__ReadOnlySingleElementList<object>(itemCountByConfigId));
			return;
		}
		base.GetItem(17).SetUIActive(false);
	}

	// Token: 0x06011CC1 RID: 72897 RVA: 0x004E5486 File Offset: 0x004E3686
	protected void RemoveResellTimer()
	{
		if (this.ResellTimerId != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.ResellTimerId);
			this.ResellTimerId = null;
		}
	}

	// Token: 0x06011CC2 RID: 72898 RVA: 0x004E54A8 File Offset: 0x004E36A8
	private void RefreshReSellText()
	{
		this.RemoveResellTimer();
		string exchangePopViewResellText = this.Goods.GetExchangePopViewResellText();
		if (this.Goods.GetIfNeedExtraLimitText())
		{
			string extraLimitText = this.Goods.GetExtraLimitText();
			if (!string.IsNullOrEmpty(extraLimitText))
			{
				base.GetItem(11).SetUIActive(true);
				base.GetText(12).ShowTextNew(extraLimitText);
			}
			return;
		}
		if (!this.Goods.GetPriceData().Enough)
		{
			base.GetItem(11).SetUIActive(true);
			if (!string.IsNullOrEmpty(exchangePopViewResellText))
			{
				base.GetText(12).ShowTextNew(exchangePopViewResellText);
				return;
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.Goods.GetPriceData().CurrencyId).Name, null);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(12), "CurrencyNotEnough", new <>z__ReadOnlySingleElementList<object>(localTextNew));
			return;
		}
		else
		{
			ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> countDownData = this.Goods.GetCountDownData();
			if (countDownData.Item1 != EPayCountTimeType.Resell && !this.Goods.GetPriceData().Enough)
			{
				base.GetItem(11).SetUIActive(true);
				string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(this.Goods.GetPriceData().CurrencyId).Value.Name, null);
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(12), "CurrencyNotEnough", new <>z__ReadOnlySingleElementList<object>(localTextNew2));
				return;
			}
			if (countDownData.Item2 == null)
			{
				base.GetItem(11).SetUIActive(false);
				base.GetText(12).SetUIActive(false);
				return;
			}
			if (!string.IsNullOrEmpty(exchangePopViewResellText))
			{
				base.GetItem(11).SetUIActive(true);
				base.GetText(12).ShowTextNew(exchangePopViewResellText);
			}
			else
			{
				base.GetItem(11).SetUIActive(false);
			}
			if (countDownData.Item3 > 0.0)
			{
				this.ResellTimerId = TimerSystem.RealTimeInstance.Delay(delegate(float _)
				{
					this.RefreshReSellText();
				}, (float)countDownData.Item3 * 1000f, null, null, false, 1f);
			}
			return;
		}
	}

	// Token: 0x04008B3D RID: 35645
	[Nullable(1)]
	private const string COLOR = "FED12E";

	// Token: 0x04008B3E RID: 35646
	private PayShopItem ShowItem;

	// Token: 0x04008B3F RID: 35647
	protected PayShopGoods Goods;

	// Token: 0x04008B40 RID: 35648
	private bool CurrentEndTimeShowState = true;

	// Token: 0x04008B41 RID: 35649
	private UUIInteractionGroup BuyInteractionGroup;

	// Token: 0x04008B42 RID: 35650
	protected TimerHandle ResellTimerId;

	// Token: 0x04008B43 RID: 35651
	private int BuyCountMax;

	// Token: 0x04008B44 RID: 35652
	private NumberSelectComponent NumberSelect;

	// Token: 0x02008722 RID: 34594
	[NullableContext(0)]
	private class EExchangePopViewDefine
	{
		// Token: 0x0402DB54 RID: 187220
		public const int EndTimeIcon = 0;

		// Token: 0x0402DB55 RID: 187221
		public const int EndTimeText = 1;

		// Token: 0x0402DB56 RID: 187222
		public const int ItemAttach = 2;

		// Token: 0x0402DB57 RID: 187223
		public const int CurrencyIcon = 3;

		// Token: 0x0402DB58 RID: 187224
		public const int CurrencyCount = 4;

		// Token: 0x0402DB59 RID: 187225
		public const int DescribeText = 5;

		// Token: 0x0402DB5A RID: 187226
		public const int CancelButton = 6;

		// Token: 0x0402DB5B RID: 187227
		public const int ConfirmButton = 7;

		// Token: 0x0402DB5C RID: 187228
		public const int DateTitleItem = 8;

		// Token: 0x0402DB5D RID: 187229
		public const int NumberSelect = 9;

		// Token: 0x0402DB5E RID: 187230
		public const int LeftTimeText = 10;

		// Token: 0x0402DB5F RID: 187231
		public const int ReSellItem = 11;

		// Token: 0x0402DB60 RID: 187232
		public const int ReSellText = 12;

		// Token: 0x0402DB61 RID: 187233
		public const int ItemPanel = 13;

		// Token: 0x0402DB62 RID: 187234
		public const int DownItemText = 14;

		// Token: 0x0402DB63 RID: 187235
		public const int EndTimeItem = 15;

		// Token: 0x0402DB64 RID: 187236
		public const int LeftLimitText = 16;

		// Token: 0x0402DB65 RID: 187237
		public const int ItemCurrentNum = 17;

		// Token: 0x0402DB66 RID: 187238
		public const int TextCurrentNum = 18;
	}
}
