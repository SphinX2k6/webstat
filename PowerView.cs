using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002605 RID: 9733
[NullableContext(1)]
[Nullable(0)]
public class PowerView : UiTickViewBase
{
	// Token: 0x0601312C RID: 78124 RVA: 0x005497D7 File Offset: 0x005479D7
	public PowerView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601312D RID: 78125 RVA: 0x005497E8 File Offset: 0x005479E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 16;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISliderComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.CancelClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.ConfirmClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601312E RID: 78126 RVA: 0x00549A88 File Offset: 0x00547C88
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPowerChanged, new Action(this.OnPowerChange));
		Singleton<EventSystem>.Instance.Add(EEventName.BoughtItem, new Action<int, int>(this.OnBuySuccess));
		Singleton<EventSystem>.Instance.Add(EEventName.OnGoodUnlock, new Action(this.OnGoodUnlock));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnPlayerCurrencyChange));
	}

	// Token: 0x0601312F RID: 78127 RVA: 0x00549B08 File Offset: 0x00547D08
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPowerChanged, new Action(this.OnPowerChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.BoughtItem, new Action<int, int>(this.OnBuySuccess));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGoodUnlock, new Action(this.OnGoodUnlock));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnPlayerCurrencyChange));
	}

	// Token: 0x06013130 RID: 78128 RVA: 0x00549B85 File Offset: 0x00547D85
	protected override void OnBeforeShow()
	{
		this.RefreshCurrency();
	}

	// Token: 0x06013131 RID: 78129 RVA: 0x00549B90 File Offset: 0x00547D90
	private UniTask RefreshCurrency()
	{
		PowerView.<RefreshCurrency>d__17 <RefreshCurrency>d__;
		<RefreshCurrency>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCurrency>d__.<>4__this = this;
		<RefreshCurrency>d__.<>1__state = -1;
		<RefreshCurrency>d__.<>t__builder.Start<PowerView.<RefreshCurrency>d__17>(ref <RefreshCurrency>d__);
		return <RefreshCurrency>d__.<>t__builder.Task;
	}

	// Token: 0x06013132 RID: 78130 RVA: 0x00549BD4 File Offset: 0x00547DD4
	protected override void OnStart()
	{
		UUIItem item2 = base.GetItem(11);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIButtonComponent button = base.GetButton(13);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		ControllerBase<PowerController>.Instance.SendUpdatePowerRequest(new int[]
		{
			5,
			6
		});
		this.PowerNaturalLimit = ConfigBase<PowerConfig>.Instance.GetPowerNaturalLimit();
		this.PowerChargeLimit = ConfigBase<PowerConfig>.Instance.GetPowerChargeLimit();
		this.PowerConfirmBoxData = (this.OpenParam as PowerConfirmBoxData);
		this.RefreshViewByBoxData();
		this.PowerPropScrollView = new GenericScrollView<MediumItemGrid>(base.GetScrollViewWithScrollbar(7), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<MediumItemGrid>(this.RefreshScrollView), null);
		this.PowerItemInfos = this.GetPowerRecoverItem();
		this.PowerPropScrollView.RefreshByData<PowerItemInfo>(this.PowerItemInfos, null);
		this.StartSelectedIndex = 0;
		if (ModelBase<PowerModel>.Instance.GetPowerDataById(6).GetCurrentPower() == 0)
		{
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(10800, 0) == 0)
			{
				this.StartSelectedIndex = this.PowerItemInfos.FindIndex((PowerItemInfo item) => item.ItemId == 3);
			}
			else
			{
				this.StartSelectedIndex = this.PowerItemInfos.FindIndex((PowerItemInfo item) => item.ItemId == 10800);
			}
		}
		else
		{
			this.StartSelectedIndex = this.PowerItemInfos.FindIndex((PowerItemInfo item) => item.ItemId == 6);
		}
		this.SelectedItemInfo = this.PowerItemInfos[this.StartSelectedIndex];
		this.SelectedItemGrid = this.PowerPropScrollView.GetScrollItemList()[this.StartSelectedIndex];
		this.SelectedItemGrid.SetSelected(true, false);
		this.UpdateDisplayItem(this.SelectedItemInfo);
	}

	// Token: 0x06013133 RID: 78131 RVA: 0x00549DB8 File Offset: 0x00547FB8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<PowerItemInfo> GetPowerRecoverItem()
	{
		List<PowerItemInfo> list = new List<PowerItemInfo>();
		foreach (PowerItemInfo powerItemInfo in ModelBase<PowerModel>.Instance.PowerItemInfoList)
		{
			if (powerItemInfo.StackValue > 0 || !powerItemInfo.IsHideWhenZero)
			{
				list.Add(powerItemInfo);
			}
		}
		return list;
	}

	// Token: 0x06013134 RID: 78132 RVA: 0x00549E28 File Offset: 0x00548028
	protected override void OnBeforeDestroy()
	{
		if (this.PowerPropScrollView == null)
		{
			return;
		}
		this.PowerPropScrollView.ClearChildren();
		this.PowerPropScrollView = null;
	}

	// Token: 0x06013135 RID: 78133 RVA: 0x00549E48 File Offset: 0x00548048
	protected override void OnTick(float delta)
	{
		this.RefreshRecoveryText();
		PowerItemInfo selectedItemInfo = this.SelectedItemInfo;
		this.RefreshRecoveryItem((selectedItemInfo != null) ? new int?(selectedItemInfo.ItemId) : null);
	}

	// Token: 0x06013136 RID: 78134 RVA: 0x00549E80 File Offset: 0x00548080
	private void UpdateCountDown(string fullRecoveryText, string nextRecoveryText)
	{
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetText(fullRecoveryText, true);
		}
		UUIText text2 = base.GetText(4);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(nextRecoveryText, true);
	}

	// Token: 0x06013137 RID: 78135 RVA: 0x00549EAC File Offset: 0x005480AC
	private void RefreshViewByBoxData()
	{
		if (this.PowerConfirmBoxData == null)
		{
			return;
		}
		switch (this.PowerConfirmBoxData.Type)
		{
		case EPowerMenuType.Enough:
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(6), "PowerGetReward", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(10), "PowerRewardCost", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "PowerCostAndReward", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "PowerCancel", Array.Empty<object>());
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(9);
			if (verticalLayout == null)
			{
				return;
			}
			UUIItem rootComponent = verticalLayout.GetRootComponent();
			if (rootComponent == null)
			{
				return;
			}
			rootComponent.SetUIActive(false);
			return;
		}
		case EPowerMenuType.DisEnough:
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(6), "PowerGetReward", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(10), "PowerRewardCostFail", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "PowerCostAndReward", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "PowerCancel", Array.Empty<object>());
			UUIVerticalLayout verticalLayout2 = base.GetVerticalLayout(9);
			if (verticalLayout2 == null)
			{
				return;
			}
			UUIItem rootComponent2 = verticalLayout2.GetRootComponent();
			if (rootComponent2 == null)
			{
				return;
			}
			rootComponent2.SetUIActive(false);
			return;
		}
		case EPowerMenuType.Supply:
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(6), "PowerTitle", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "PowerCancel", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "PowerConfirm", Array.Empty<object>());
			return;
		default:
			return;
		}
	}

	// Token: 0x06013138 RID: 78136 RVA: 0x0054A048 File Offset: 0x00548248
	private void CancelClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06013139 RID: 78137 RVA: 0x0054A054 File Offset: 0x00548254
	private void ConfirmClick()
	{
		if (this.PowerConfirmBoxData == null || this.SelectedItemInfo == null)
		{
			return;
		}
		EPowerMenuType type = this.PowerConfirmBoxData.Type;
		if (type == EPowerMenuType.DisEnough)
		{
			base.CloseMe(null);
			ControllerBase<PowerController>.Instance.OpenPowerView(EPowerMenuType.Supply, 0);
			return;
		}
		if (type != EPowerMenuType.Supply)
		{
			base.CloseMe(null);
			return;
		}
		if (ModelBase<PowerModel>.Instance.PowerCount + this.SelectedItemInfo.RenewValue > this.PowerChargeLimit)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PowerBound", Array.Empty<object>());
			return;
		}
		if (this.SelectedItemInfo.RemainCount == 0 && this.SelectedItemInfo.ItemId != 6)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ConfigMultiTextLang.GetLocalTextNew("Text_PowerDescribe_Astrite_Not", null));
			return;
		}
		if (this.SelectedItemInfo.CostValue > this.SelectedItemInfo.StackValue)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(this.SelectedItemInfo.ItemName, null);
			string text = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("PowerPropsCannotExchange", null), new string[]
			{
				localTextNew
			});
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(text);
			return;
		}
		int costCount = 1;
		ControllerBase<PowerController>.Instance.ExchangePower(this.SelectedItemInfo, costCount, null);
	}

	// Token: 0x0601313A RID: 78138 RVA: 0x0054A170 File Offset: 0x00548370
	private void SetDisplayItemInfo(MediumItemGridExtendCallback callbackParameter)
	{
		PowerItemInfo powerItemInfo = callbackParameter.Data as PowerItemInfo;
		ItemGridBase mediumItemGrid = callbackParameter.MediumItemGrid;
		ItemGridBase selectedItemGrid = this.SelectedItemGrid;
		if (selectedItemGrid != null)
		{
			selectedItemGrid.SetSelected(false, false);
		}
		this.SelectedItemGrid = mediumItemGrid;
		this.SelectedItemInfo = powerItemInfo;
		this.UpdateDisplayItem(powerItemInfo);
	}

	// Token: 0x0601313B RID: 78139 RVA: 0x0054A1B8 File Offset: 0x005483B8
	private void UpdateDisplayItem(PowerItemInfo itemInfo)
	{
		this.RefreshNameText(itemInfo);
		this.RefreshViewByItemId(itemInfo.ItemId);
	}

	// Token: 0x0601313C RID: 78140 RVA: 0x0054A1D0 File Offset: 0x005483D0
	private void RefreshNameText(PowerItemInfo itemInfo)
	{
		if (itemInfo.ItemId != 6)
		{
			string textStringId = (itemInfo.ItemId == 3) ? "Text_PowerDescribe_Astrite_Text" : "Text_PowerDescribe_Text";
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(itemInfo.ItemName, null);
			int num = (itemInfo.RemainCount < 0) ? 0 : itemInfo.RemainCount;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), textStringId, new <>z__ReadOnlyArray<object>(new object[]
			{
				itemInfo.CostValue,
				localTextNew,
				itemInfo.RenewValue,
				num
			}));
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "GetOverPower", Array.Empty<object>());
	}

	// Token: 0x0601313D RID: 78141 RVA: 0x0054A27E File Offset: 0x0054847E
	private void RefreshViewByItemId(int itemId)
	{
		this.RefreshRecoveryItem(new int?(itemId));
	}

	// Token: 0x0601313E RID: 78142 RVA: 0x0054A28C File Offset: 0x0054848C
	private void RefreshRecoveryItem(int? itemId)
	{
		if (itemId == null)
		{
			return;
		}
		this.RefreshPowerFullItem();
		PowerData powerDataById = ModelBase<PowerModel>.Instance.GetPowerDataById(5);
		UUIItem item = base.GetItem(11);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(powerDataById.GetPowerRecoveryMode() == EPowerRecoveryMode.Update);
	}

	// Token: 0x0601313F RID: 78143 RVA: 0x0054A2D0 File Offset: 0x005484D0
	private void RefreshRecoveryText()
	{
		PowerItemInfo selectedItemInfo = this.SelectedItemInfo;
		int? num = (selectedItemInfo != null) ? new int?(selectedItemInfo.ItemId) : null;
		if (num.GetValueOrDefault() == 3 || num.GetValueOrDefault() == 5 || num.GetValueOrDefault() == 6 || num.GetValueOrDefault() == 10800)
		{
			PowerData powerDataById = ModelBase<PowerModel>.Instance.GetPowerDataById(5);
			this.UpdateCountDown(powerDataById.GetFullRecoverText(), powerDataById.GetNextTimerRecoverText());
		}
	}

	// Token: 0x06013140 RID: 78144 RVA: 0x0054A348 File Offset: 0x00548548
	private void RefreshPowerFullItem()
	{
		PowerData powerDataById = ModelBase<PowerModel>.Instance.GetPowerDataById(5);
		UUIItem item = base.GetItem(15);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(powerDataById.CheckPowerIfMax());
	}

	// Token: 0x06013141 RID: 78145 RVA: 0x0054A37C File Offset: 0x0054857C
	private void OnPowerChange()
	{
		float inValue = (float)ModelBase<PowerModel>.Instance.PowerCount / (float)this.PowerNaturalLimit;
		UUISliderComponent slider = base.GetSlider(14);
		if (slider != null)
		{
			slider.SetValue(inValue, true);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.PowerModule;
		ELogAuthor author = ELogAuthor.LK;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 2);
		defaultInterpolatedStringHandler.AppendLiteral("补充时打印体力");
		defaultInterpolatedStringHandler.AppendFormatted<int>(ModelBase<PowerModel>.Instance.PowerCount);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.PowerNaturalLimit);
		instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		this.PowerItemInfos = this.GetPowerRecoverItem();
		GenericScrollView<MediumItemGrid> powerPropScrollView = this.PowerPropScrollView;
		if (powerPropScrollView != null)
		{
			powerPropScrollView.RefreshByData<PowerItemInfo>(this.PowerItemInfos, null);
		}
		if (this.PowerConfirmBoxData == null)
		{
			return;
		}
		int autoClosePowerCount = this.PowerConfirmBoxData.AutoClosePowerCount;
		if (autoClosePowerCount > 0 && ModelBase<PowerModel>.Instance.PowerCount >= autoClosePowerCount)
		{
			base.CloseMe(null);
			return;
		}
		if (this.PowerConfirmBoxData.UpdateCurrentNeedPower)
		{
			int num = ModelBase<PowerModel>.Instance.PowerCount - this.PowerConfirmBoxData.PowerCount;
			ModelBase<PowerModel>.Instance.CurrentNeedPower = Math.Max(ModelBase<PowerModel>.Instance.CurrentNeedPower - num, 0);
		}
		this.PowerConfirmBoxData.PowerCount = ModelBase<PowerModel>.Instance.PowerCount;
	}

	// Token: 0x06013142 RID: 78146 RVA: 0x0054A4C4 File Offset: 0x005486C4
	private void OnPlayerCurrencyChange(int itemId)
	{
		if (itemId == 3)
		{
			this.PowerItemInfos = this.GetPowerRecoverItem();
			GenericScrollView<MediumItemGrid> powerPropScrollView = this.PowerPropScrollView;
			if (powerPropScrollView != null)
			{
				powerPropScrollView.RefreshByData<PowerItemInfo>(this.PowerItemInfos, null);
			}
		}
		if (this.SelectedItemInfo != null)
		{
			this.UpdateDisplayItem(this.SelectedItemInfo);
		}
		MediumItemGrid payItemGrid = this.PayItemGrid;
		if (payItemGrid == null)
		{
			return;
		}
		payItemGrid.SetBottomText(ModelBase<PlayerInfoModel>.Instance.GetPlayerMoney(3).ToString());
	}

	// Token: 0x06013143 RID: 78147 RVA: 0x0054A538 File Offset: 0x00548738
	private void OnBuySuccess(int shopId, int goodsId)
	{
		if (shopId == 0 || goodsId == 0)
		{
			return;
		}
		if (this.PowerPropScrollView != null)
		{
			PowerItemInfo selectedItemInfo = this.SelectedItemInfo;
			if (selectedItemInfo == null || selectedItemInfo.ItemId != 6)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PowerBuySucceed", new object[]
				{
					this.SelectedItemInfo.RenewValue.ToString()
				});
			}
		}
		this.PowerItemInfos = this.GetPowerRecoverItem();
		GenericScrollView<MediumItemGrid> powerPropScrollView = this.PowerPropScrollView;
		if (powerPropScrollView != null)
		{
			powerPropScrollView.RefreshByData<PowerItemInfo>(this.PowerItemInfos, null);
		}
		if (this.SelectedItemInfo != null)
		{
			this.UpdateDisplayItem(this.SelectedItemInfo);
		}
	}

	// Token: 0x06013144 RID: 78148 RVA: 0x0054A5D8 File Offset: 0x005487D8
	private void OnGoodUnlock()
	{
		this.PowerItemInfos = this.GetPowerRecoverItem();
		GenericScrollView<MediumItemGrid> powerPropScrollView = this.PowerPropScrollView;
		if (powerPropScrollView == null)
		{
			return;
		}
		powerPropScrollView.RefreshByData<PowerItemInfo>(this.PowerItemInfos, null);
	}

	// Token: 0x06013145 RID: 78149 RVA: 0x0054A610 File Offset: 0x00548810
	private ILayoutItem<MediumItemGrid> RefreshScrollView(object rawItemInfo, UUIItem uiItem, int index)
	{
		PowerItemInfo powerItemInfo = (PowerItemInfo)rawItemInfo;
		MediumItemGrid mediumItemGrid = new MediumItemGrid();
		mediumItemGrid.Initialize(uiItem.GetOwner());
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = powerItemInfo,
			ItemConfigId = new int?(powerItemInfo.ItemId),
			BottomText = powerItemInfo.StackValue.ToString()
		};
		mediumItemGrid.Apply<PropMediumItemGrid>(parameters);
		mediumItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.SetDisplayItemInfo));
		if (powerItemInfo.CostValue > powerItemInfo.StackValue || powerItemInfo.RemainCount == 0)
		{
			mediumItemGrid.SetBottomTextColor("9D2437FF");
		}
		else
		{
			mediumItemGrid.SetBottomTextColor("FFFFFFFF");
		}
		if (powerItemInfo.ItemId == 3)
		{
			this.PayItemGrid = mediumItemGrid;
		}
		return new LayoutItem<MediumItemGrid>
		{
			Key = index,
			Value = mediumItemGrid
		};
	}

	// Token: 0x040094DD RID: 38109
	private const string COUN_NOT_ENOUGH_COLOR = "9D2437FF";

	// Token: 0x040094DE RID: 38110
	private const string WHITE_COLOR = "FFFFFFFF";

	// Token: 0x040094DF RID: 38111
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<MediumItemGrid> PowerPropScrollView;

	// Token: 0x040094E0 RID: 38112
	[Nullable(2)]
	private MediumItemGrid PayItemGrid;

	// Token: 0x040094E1 RID: 38113
	[Nullable(2)]
	private PowerConfirmBoxData PowerConfirmBoxData;

	// Token: 0x040094E2 RID: 38114
	[Nullable(2)]
	private PowerItemInfo SelectedItemInfo;

	// Token: 0x040094E3 RID: 38115
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<PowerItemInfo> PowerItemInfos;

	// Token: 0x040094E4 RID: 38116
	private int PowerNaturalLimit;

	// Token: 0x040094E5 RID: 38117
	private int PowerChargeLimit;

	// Token: 0x040094E6 RID: 38118
	[Nullable(2)]
	private ItemGridBase SelectedItemGrid;

	// Token: 0x040094E7 RID: 38119
	private int StartSelectedIndex = -1;

	// Token: 0x02008990 RID: 35216
	[NullableContext(0)]
	private enum EPowerWidget
	{
		// Token: 0x0402E693 RID: 190099
		CancelButton,
		// Token: 0x0402E694 RID: 190100
		CancelText,
		// Token: 0x0402E695 RID: 190101
		ConfirmButton,
		// Token: 0x0402E696 RID: 190102
		ConfirmText,
		// Token: 0x0402E697 RID: 190103
		Power1,
		// Token: 0x0402E698 RID: 190104
		Power2,
		// Token: 0x0402E699 RID: 190105
		Title,
		// Token: 0x0402E69A RID: 190106
		ScrollView,
		// Token: 0x0402E69B RID: 190107
		ContentText,
		// Token: 0x0402E69C RID: 190108
		ContainerProp,
		// Token: 0x0402E69D RID: 190109
		CommonDescribe,
		// Token: 0x0402E69E RID: 190110
		Recover,
		// Token: 0x0402E69F RID: 190111
		Group,
		// Token: 0x0402E6A0 RID: 190112
		ConfirmButton2,
		// Token: 0x0402E6A1 RID: 190113
		PowerSlider,
		// Token: 0x0402E6A2 RID: 190114
		PowerFullItem
	}
}
