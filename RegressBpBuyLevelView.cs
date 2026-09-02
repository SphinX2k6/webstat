using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200152F RID: 5423
[NullableContext(1)]
[Nullable(0)]
public class RegressBpBuyLevelView : UiViewBase
{
	// Token: 0x060097EC RID: 38892 RVA: 0x0027C67D File Offset: 0x0027A87D
	public RegressBpBuyLevelView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060097ED RID: 38893 RVA: 0x0027C688 File Offset: 0x0027A888
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickCancel)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickBuy))
		};
	}

	// Token: 0x060097EE RID: 38894 RVA: 0x0027C7B8 File Offset: 0x0027A9B8
	private void OnClickCancel()
	{
		base.CloseMe(null);
	}

	// Token: 0x060097EF RID: 38895 RVA: 0x0027C7C1 File Offset: 0x0027A9C1
	private void OnClickBuy()
	{
		ControllerBase<ActivityRegressController>.Instance.RequestBuyBattlePassLevel(this.NumberSelect.GetSelectNumber());
		base.CloseMe(null);
	}

	// Token: 0x060097F0 RID: 38896 RVA: 0x0027C7E0 File Offset: 0x0027A9E0
	protected override void OnStart()
	{
		this.CurrentLevel = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetCurLevelProgressData().Level;
		RegressDisposableReward? regressDisposableReward = ConfigBase<ActivityRegressConfig>.Instance.GetRegressDisposableReward(ModelBase<ActivityRegressModel>.Instance.ActivityData.Id);
		if (regressDisposableReward == null)
		{
			return;
		}
		this.CostId = regressDisposableReward.Value.BuyLvConsumeItem;
		ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(this.CostId);
		this.CostCount = regressDisposableReward.Value.BuyLvConsumeNum;
		base.SetTextureByPath(config.Value.IconSmall, base.GetTexture(8), null, null);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(9), "CurrencyNotEnough", new <>z__ReadOnlySingleElementList<object>(ConfigMultiTextLang.GetLocalTextNew(config.Value.Name, null)));
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(0), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
		this.RewardList = new List<TItem>();
	}

	// Token: 0x060097F1 RID: 38897 RVA: 0x0027C8EF File Offset: 0x0027AAEF
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BattlePassMainViewHide, new Action(this.OnMainViewHide));
	}

	// Token: 0x060097F2 RID: 38898 RVA: 0x0027C90D File Offset: 0x0027AB0D
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BattlePassMainViewHide, new Action(this.OnMainViewHide));
	}

	// Token: 0x060097F3 RID: 38899 RVA: 0x0027C92B File Offset: 0x0027AB2B
	private void OnMainViewHide()
	{
		base.CloseMe(null);
	}

	// Token: 0x060097F4 RID: 38900 RVA: 0x0027C934 File Offset: 0x0027AB34
	protected override void OnBeforeShow()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		CommonPopViewBase commonPopViewBase = (childPopView != null) ? childPopView.PopItem : null;
		if (commonPopViewBase != null)
		{
			commonPopViewBase.SetCurrencyItemList(new int[]
			{
				this.CostId
			});
			CommonCurrencyItem commonCurrencyItem = commonPopViewBase.GetCurrencyComponent().GetCurrencyItemList()[0];
			commonCurrencyItem.SetBeforeButtonFunction(new Action(this.BeforeEnterPayShop));
			commonCurrencyItem.SetToPayShopFunction();
		}
		this.NumberSelect = new NumberSelectComponent(base.GetItem(5));
		INumberSelectData data = new INumberSelectData
		{
			MaxNumber = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetMaxLevel() - this.CurrentLevel,
			GetExchangeTableText = new Func<int, TableTextArgNew>(this.GetExchangeTableText),
			ValueChangeFunction = new Action<int>(this.ValueChangeFunction)
		};
		this.NumberSelect.Init(data);
	}

	// Token: 0x060097F5 RID: 38901 RVA: 0x0027C9F9 File Offset: 0x0027ABF9
	private void BeforeEnterPayShop()
	{
		base.CloseMe(null);
	}

	// Token: 0x060097F6 RID: 38902 RVA: 0x0027CA02 File Offset: 0x0027AC02
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x060097F7 RID: 38903 RVA: 0x0027CA09 File Offset: 0x0027AC09
	private TableTextArgNew GetExchangeTableText(int selectValue)
	{
		return new TableTextArgNew("Text_BattlePassLevelBuy2_Text", new <>z__ReadOnlySingleElementList<object>(selectValue));
	}

	// Token: 0x060097F8 RID: 38904 RVA: 0x0027CA20 File Offset: 0x0027AC20
	private void ValueChangeFunction(int selectValue)
	{
		this.Refresh(selectValue);
	}

	// Token: 0x060097F9 RID: 38905 RVA: 0x0027CA2C File Offset: 0x0027AC2C
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

	// Token: 0x060097FA RID: 38906 RVA: 0x0027CAE8 File Offset: 0x0027ACE8
	private void RefreshGrids()
	{
		if (this.TargetLevel > 0)
		{
			int targetLevel = this.TargetLevel;
			this.TargetLevel = 0;
			this.RefreshingGridsAsync(targetLevel).ContinueWith(new Action(this.RefreshGrids));
		}
	}

	// Token: 0x060097FB RID: 38907 RVA: 0x0027CB28 File Offset: 0x0027AD28
	private UniTask RefreshingGridsAsync(int targetLevel)
	{
		RegressBpBuyLevelView.<RefreshingGridsAsync>d__24 <RefreshingGridsAsync>d__;
		<RefreshingGridsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshingGridsAsync>d__.<>4__this = this;
		<RefreshingGridsAsync>d__.targetLevel = targetLevel;
		<RefreshingGridsAsync>d__.<>1__state = -1;
		<RefreshingGridsAsync>d__.<>t__builder.Start<RegressBpBuyLevelView.<RefreshingGridsAsync>d__24>(ref <RefreshingGridsAsync>d__);
		return <RefreshingGridsAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060097FC RID: 38908 RVA: 0x0027CB73 File Offset: 0x0027AD73
	protected override void OnDestroy()
	{
		this.TargetLevel = 0;
		this.RewardScrollView = null;
		this.RewardList = null;
		this.NumberSelect.Destroy(null);
		this.NumberSelect = null;
	}

	// Token: 0x0400466E RID: 18030
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x0400466F RID: 18031
	[Nullable(2)]
	private List<TItem> RewardList;

	// Token: 0x04004670 RID: 18032
	[Nullable(2)]
	private NumberSelectComponent NumberSelect;

	// Token: 0x04004671 RID: 18033
	private int CurrentLevel;

	// Token: 0x04004672 RID: 18034
	private int CostId;

	// Token: 0x04004673 RID: 18035
	private int CostCount;

	// Token: 0x04004674 RID: 18036
	private int TargetLevel;

	// Token: 0x04004675 RID: 18037
	private bool IsRefreshingGrids;

	// Token: 0x020078DE RID: 30942
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040298AD RID: 170157
		public const int ItemScrollView = 0;

		// Token: 0x040298AE RID: 170158
		public const int TxtTitle = 1;

		// Token: 0x040298AF RID: 170159
		public const int BtnCancel = 2;

		// Token: 0x040298B0 RID: 170160
		public const int BtnBuy = 3;

		// Token: 0x040298B1 RID: 170161
		public const int TxtDescribe = 4;

		// Token: 0x040298B2 RID: 170162
		public const int NumberControlItem = 5;

		// Token: 0x040298B3 RID: 170163
		public const int TxtCost = 6;

		// Token: 0x040298B4 RID: 170164
		public const int InsufficientTip = 7;

		// Token: 0x040298B5 RID: 170165
		public const int IconCost = 8;

		// Token: 0x040298B6 RID: 170166
		public const int TxtInsufficient = 9;
	}
}
