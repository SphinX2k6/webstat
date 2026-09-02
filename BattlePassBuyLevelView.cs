using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002374 RID: 9076
[NullableContext(1)]
[Nullable(0)]
public class BattlePassBuyLevelView : UiViewBase
{
	// Token: 0x060115E3 RID: 71139 RVA: 0x004C8D4C File Offset: 0x004C6F4C
	public BattlePassBuyLevelView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060115E4 RID: 71140 RVA: 0x004C8D58 File Offset: 0x004C6F58
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickCancel));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickBuy));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060115E5 RID: 71141 RVA: 0x004C8F2B File Offset: 0x004C712B
	private void OnClickCancel()
	{
		base.CloseMe(null);
	}

	// Token: 0x060115E6 RID: 71142 RVA: 0x004C8F34 File Offset: 0x004C7134
	private void OnClickBuy()
	{
		ControllerBase<BattlePassController>.Instance.RequestBuyBattlePassLevel(this.NumberSelect.GetSelectNumber());
		base.CloseMe(null);
	}

	// Token: 0x060115E7 RID: 71143 RVA: 0x004C8F54 File Offset: 0x004C7154
	protected override void OnStart()
	{
		this.CurrentLevel = ModelBase<BattlePassModel>.Instance.BattlePassLevel;
		BattlePass value = ConfigBase<BattlePassConfig>.Instance.GetBattlePassData(ModelBase<BattlePassModel>.Instance.BattlePassId).Value;
		this.CostId = value.ConsumeId;
		ItemInfo value2 = ConfigBase<ItemConfig>.Instance.GetConfig(this.CostId).Value;
		this.CostCount = value.ConsumeCount;
		base.SetTextureByPath(value2.IconSmall, base.GetTexture(8), null, null);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(9), "CurrencyNotEnough", new <>z__ReadOnlySingleElementList<object>(ConfigMultiTextLang.GetLocalTextNew(value2.Name, null)));
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(0), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
		this.RewardList = new List<TItem>();
	}

	// Token: 0x060115E8 RID: 71144 RVA: 0x004C9035 File Offset: 0x004C7235
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BattlePassMainViewHide, new Action(this.OnMainViewHide));
	}

	// Token: 0x060115E9 RID: 71145 RVA: 0x004C9053 File Offset: 0x004C7253
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BattlePassMainViewHide, new Action(this.OnMainViewHide));
	}

	// Token: 0x060115EA RID: 71146 RVA: 0x004C9071 File Offset: 0x004C7271
	private void OnMainViewHide()
	{
		base.CloseMe(null);
	}

	// Token: 0x060115EB RID: 71147 RVA: 0x004C907C File Offset: 0x004C727C
	protected override void OnBeforeShow()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		CommonPopViewBase commonPopViewBase = (childPopView != null) ? childPopView.PopItem : null;
		if (commonPopViewBase != null)
		{
			commonPopViewBase.SetCurrencyItemList(new int[]
			{
				this.CostId
			}).Forget();
			CommonCurrencyItem commonCurrencyItem = commonPopViewBase.GetCurrencyComponent().GetCurrencyItemList()[0];
			commonCurrencyItem.SetBeforeButtonFunction(new Action(this.BeforeEnterPayShop));
			commonCurrencyItem.SetToPayShopFunction();
		}
		this.NumberSelect = new NumberSelectComponent(base.GetItem(5));
		INumberSelectData data = new INumberSelectData
		{
			MaxNumber = ModelBase<BattlePassModel>.Instance.GetMaxLevel() - this.CurrentLevel,
			GetExchangeTableText = new Func<int, TableTextArgNew>(this.GetExchangeTableText),
			ValueChangeFunction = new Action<int>(this.ValueChangeFunction)
		};
		this.NumberSelect.Init(data);
	}

	// Token: 0x060115EC RID: 71148 RVA: 0x004C9140 File Offset: 0x004C7340
	private void BeforeEnterPayShop()
	{
		base.CloseMe(null);
	}

	// Token: 0x060115ED RID: 71149 RVA: 0x004C9149 File Offset: 0x004C7349
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x060115EE RID: 71150 RVA: 0x004C9150 File Offset: 0x004C7350
	private TableTextArgNew GetExchangeTableText(int selectValue)
	{
		return new TableTextArgNew("Text_BattlePassLevelBuy2_Text", new <>z__ReadOnlySingleElementList<object>(selectValue));
	}

	// Token: 0x060115EF RID: 71151 RVA: 0x004C9167 File Offset: 0x004C7367
	private void ValueChangeFunction(int selectValue)
	{
		this.Refresh(selectValue);
	}

	// Token: 0x060115F0 RID: 71152 RVA: 0x004C9170 File Offset: 0x004C7370
	private void Refresh(int buyLevel)
	{
		int num = this.CurrentLevel + buyLevel;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Text_BattlePassLevelBuy1_Text", new <>z__ReadOnlySingleElementList<object>(num));
		int num2 = buyLevel * this.CostCount;
		UUIText text = base.GetText(6);
		text.SetText(num2.ToString(), true);
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.CostId, 0);
		UUIItem uuiitem = text;
		bool bUseChangeColor = itemCountByConfigId < num2;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		base.GetButton(3).SetSelfInteractive(itemCountByConfigId >= num2);
		base.GetItem(7).SetUIActive(itemCountByConfigId < num2);
		this.TargetLevel = num;
		if (!this.IsRefreshingGrids)
		{
			this.RefreshGrids();
		}
	}

	// Token: 0x060115F1 RID: 71153 RVA: 0x004C922C File Offset: 0x004C742C
	private void RefreshGrids()
	{
		int targetLevel = this.TargetLevel;
		if (targetLevel > 0)
		{
			this.TargetLevel = 0;
			this.RefreshingGrids(targetLevel).ContinueWith(new Action(this.RefreshGrids)).Forget();
		}
	}

	// Token: 0x060115F2 RID: 71154 RVA: 0x004C9268 File Offset: 0x004C7468
	private UniTask RefreshingGrids(int targetLevel)
	{
		BattlePassBuyLevelView.<RefreshingGrids>d__24 <RefreshingGrids>d__;
		<RefreshingGrids>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshingGrids>d__.<>4__this = this;
		<RefreshingGrids>d__.targetLevel = targetLevel;
		<RefreshingGrids>d__.<>1__state = -1;
		<RefreshingGrids>d__.<>t__builder.Start<BattlePassBuyLevelView.<RefreshingGrids>d__24>(ref <RefreshingGrids>d__);
		return <RefreshingGrids>d__.<>t__builder.Task;
	}

	// Token: 0x060115F3 RID: 71155 RVA: 0x004C92B3 File Offset: 0x004C74B3
	protected override void OnDestroy()
	{
		this.TargetLevel = 0;
		this.RewardScrollView = null;
		this.RewardList.Clear();
		this.RewardList = null;
		this.NumberSelect.Destroy(null);
		this.NumberSelect = null;
	}

	// Token: 0x0400887E RID: 34942
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x0400887F RID: 34943
	[Nullable(2)]
	private List<TItem> RewardList;

	// Token: 0x04008880 RID: 34944
	[Nullable(2)]
	private NumberSelectComponent NumberSelect;

	// Token: 0x04008881 RID: 34945
	private int CurrentLevel;

	// Token: 0x04008882 RID: 34946
	private int CostId;

	// Token: 0x04008883 RID: 34947
	private int CostCount;

	// Token: 0x04008884 RID: 34948
	private int TargetLevel;

	// Token: 0x04008885 RID: 34949
	private bool IsRefreshingGrids;

	// Token: 0x02008689 RID: 34441
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402D81B RID: 186395
		ItemScrollView,
		// Token: 0x0402D81C RID: 186396
		TxtTitle,
		// Token: 0x0402D81D RID: 186397
		BtnCancel,
		// Token: 0x0402D81E RID: 186398
		BtnBuy,
		// Token: 0x0402D81F RID: 186399
		TxtDescribe,
		// Token: 0x0402D820 RID: 186400
		NumberControlItem,
		// Token: 0x0402D821 RID: 186401
		TxtCost,
		// Token: 0x0402D822 RID: 186402
		InsufficientTip,
		// Token: 0x0402D823 RID: 186403
		IconCost,
		// Token: 0x0402D824 RID: 186404
		TxtInsufficient
	}
}
