using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020023C1 RID: 9153
[NullableContext(1)]
[Nullable(0)]
public class DiscountShopView : UiTabViewBase, IUiTabViewRefresh
{
	// Token: 0x06011AB7 RID: 72375 RVA: 0x004D9FE0 File Offset: 0x004D81E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIScrollViewWithScrollbarComponent))
		};
	}

	// Token: 0x06011AB8 RID: 72376 RVA: 0x004DA0F0 File Offset: 0x004D82F0
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOut));
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add<ESdkDialogResult>(EEventName.SdkPayEnd, new Action<ESdkDialogResult>(this.OnSdkPayEnd));
	}

	// Token: 0x06011AB9 RID: 72377 RVA: 0x004DA150 File Offset: 0x004D8350
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOut));
		Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove<ESdkDialogResult>(EEventName.SdkPayEnd, new Action<ESdkDialogResult>(this.OnSdkPayEnd));
	}

	// Token: 0x06011ABA RID: 72378 RVA: 0x004DA1AE File Offset: 0x004D83AE
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		if (this.CurrentShopId == (int)shopId && this.CurrentSelectTabId == tabId)
		{
			this.TryRefreshTabs();
			this.LoopScrollView.RefreshAllGridProxies();
		}
	}

	// Token: 0x06011ABB RID: 72379 RVA: 0x004DA1D3 File Offset: 0x004D83D3
	private void OnGoodsSoldOut(int goodsId)
	{
		this.RefreshLoopScroll(this.CurrentSelectTabId);
	}

	// Token: 0x06011ABC RID: 72380 RVA: 0x004DA1E4 File Offset: 0x004D83E4
	protected override void OnStart()
	{
		this.TabGroup = new TabComponent<PayShopSwitchItem>(base.GetHorizontalLayout(2).GetRootComponent(), new Func<UUIItem, int?, PayShopSwitchItem>(this.TabItemProxyCreate), new Action<int>(this.ToggleCallBack), base.GetItem(3));
		UUIItem scrollItem = this.GetScrollItem();
		this.LoopScrollView = new LoopScrollView<GridProxyAbstract<IPayShopUnionData>, IPayShopUnionData>(base.GetLoopScrollViewComponent(1), scrollItem.GetOwner() as AUIBaseActor, new Func<GridProxyAbstract<IPayShopUnionData>>(this.InitItem), false);
		base.GetItem(0).SetUIActive(false);
		base.GetItem(6).SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:TabView 界面Start";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", base.GetViewName());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06011ABD RID: 72381 RVA: 0x004DA2AC File Offset: 0x004D84AC
	protected virtual UUIItem GetScrollItem()
	{
		return base.GetItem(0);
	}

	// Token: 0x06011ABE RID: 72382 RVA: 0x004DA2B5 File Offset: 0x004D84B5
	protected virtual GridProxyAbstract<IPayShopUnionData> InitItem()
	{
		return new PayShopItem();
	}

	// Token: 0x06011ABF RID: 72383 RVA: 0x004DA2BC File Offset: 0x004D84BC
	private PayShopSwitchItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new PayShopSwitchItem();
	}

	// Token: 0x06011AC0 RID: 72384 RVA: 0x004DA2C4 File Offset: 0x004D84C4
	private void ToggleCallBack(int tabIndex)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:TabView 点击刷新商品";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", base.GetViewName());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		List<int> payShopTabIdList = ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.CurrentShopId, true);
		this.CurrentSelectTabId = payShopTabIdList[tabIndex];
		this.RefreshLoopScroll(this.CurrentSelectTabId);
		this.RefreshTipsText();
		OnClickPayShopTabLogEvent onClickPayShopTabLogEvent = new OnClickPayShopTabLogEvent();
		onClickPayShopTabLogEvent.i_shop_id = this.CurrentShopId;
		onClickPayShopTabLogEvent.i_tab_id = this.CurrentSelectTabId;
		ControllerBase<LogReportController>.Instance.LogReport(onClickPayShopTabLogEvent);
		this.TryRefreshRootShopMoney();
	}

	// Token: 0x06011AC1 RID: 72385 RVA: 0x004DA360 File Offset: 0x004D8560
	private void TryRefreshRootShopMoney()
	{
		PayShopTabData payShopTabDataByPayShopIdAndTabId = ModelBase<PayShopModel>.Instance.GetPayShopTabDataByPayShopIdAndTabId((PayShopDefine.EPayShopTabType)this.CurrentShopId, this.CurrentSelectTabId);
		if (payShopTabDataByPayShopIdAndTabId != null)
		{
			List<int> moneyList = payShopTabDataByPayShopIdAndTabId.MoneyList;
			if (moneyList.Count > 0)
			{
				Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.TryRefreshRootShopMoney, moneyList);
			}
		}
	}

	// Token: 0x06011AC2 RID: 72386 RVA: 0x004DA3A8 File Offset: 0x004D85A8
	private void RefreshTipsText()
	{
		PayShopTabData payShopTabDataByPayShopIdAndTabId = ModelBase<PayShopModel>.Instance.GetPayShopTabDataByPayShopIdAndTabId((PayShopDefine.EPayShopTabType)this.CurrentShopId, this.CurrentSelectTabId);
		if (this.CurrentShopId == 4 && payShopTabDataByPayShopIdAndTabId != null && payShopTabDataByPayShopIdAndTabId.BeginTime > 0L && payShopTabDataByPayShopIdAndTabId.EndTime > 0L)
		{
			double num = (double)payShopTabDataByPayShopIdAndTabId.EndTime - Singleton<TimeUtil>.Instance.GetServerTime();
			if (num <= 0.0)
			{
				num = 0.0;
			}
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat9(num);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "ExchangeEntryLeftTimeText", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "ExchangeEntryTipsText", Array.Empty<object>());
		}
		base.GetText(10).SetUIActive(this.CurrentShopId == 4);
	}

	// Token: 0x06011AC3 RID: 72387 RVA: 0x004DA478 File Offset: 0x004D8678
	protected virtual void RefreshLoopScroll(int tabId)
	{
		this.PayShopGoodsList = ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)this.CurrentShopId, tabId, true).Cast<IPayShopUnionData>().ToList<IPayShopUnionData>();
		this.LoopScrollView.ReloadProxyData(new Func<int, IPayShopUnionData>(this.GetProxyData), this.PayShopGoodsList.Count, false, false);
		base.GetLoopScrollViewComponent(1).RootUIComp.Get().SetUIActive(this.PayShopGoodsList.Count > 0);
		base.GetItem(8).SetUIActive(this.PayShopGoodsList.Count <= 0);
		this.CheckIfNeedShowPlayStationStoreIcon();
	}

	// Token: 0x06011AC4 RID: 72388 RVA: 0x004DA515 File Offset: 0x004D8715
	private void OnSdkPayEnd(ESdkDialogResult _)
	{
		this.CheckIfNeedShowPlayStationStoreIcon();
	}

	// Token: 0x06011AC5 RID: 72389 RVA: 0x004DA520 File Offset: 0x004D8720
	protected void CheckIfNeedShowPlayStationStoreIcon()
	{
		if (!this.TabShowState)
		{
			return;
		}
		bool flag = false;
		int count = this.PayShopGoodsList.Count;
		for (int i = 0; i < count; i++)
		{
			PayShopGoods payShopGoods = this.PayShopGoodsList[i] as PayShopGoods;
			flag = (payShopGoods == null || payShopGoods.IsDirect());
			if (flag)
			{
				break;
			}
		}
		if (flag)
		{
			PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
			if (platformSdk == null)
			{
				return;
			}
			platformSdk.ShowPlayStationStoreIcon(0);
			return;
		}
		else
		{
			PlatformSdkNew platformSdk2 = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
			if (platformSdk2 == null)
			{
				return;
			}
			platformSdk2.HidePlayStationStoreIcon();
			return;
		}
	}

	// Token: 0x06011AC6 RID: 72390 RVA: 0x004DA5A0 File Offset: 0x004D87A0
	protected IPayShopUnionData GetProxyData(int gridIndex)
	{
		return this.PayShopGoodsList[gridIndex];
	}

	// Token: 0x06011AC7 RID: 72391 RVA: 0x004DA5B0 File Offset: 0x004D87B0
	protected override void OnAfterShow()
	{
		this.CurrentShopId = (int)this.Params;
		int num = 0;
		if (this.ExtraParams != null)
		{
			int switchId = (int)this.ExtraParams;
			List<int> payShopTabIdList = ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.CurrentShopId, true);
			num = payShopTabIdList.FindIndex((int tabId) => tabId == switchId);
			num = Singleton<MathUtils>.Instance.Clamp(num, 0, payShopTabIdList.Count - 1);
		}
		base.GetText(5).SetUIActive(false);
		this.UpdateTabs(num, true);
		this.AddTimer();
		this.OnDiscountShopAfterShow();
		this.QueryProductPriceAndRefresh().Forget();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:TabView 界面AfterShow";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", base.GetViewName());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06011AC8 RID: 72392 RVA: 0x004DA681 File Offset: 0x004D8881
	protected virtual void OnDiscountShopAfterShow()
	{
	}

	// Token: 0x06011AC9 RID: 72393 RVA: 0x004DA683 File Offset: 0x004D8883
	private void AddTimer()
	{
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.OnRefreshTimer();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x06011ACA RID: 72394 RVA: 0x004DA6AE File Offset: 0x004D88AE
	private void RemoveTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06011ACB RID: 72395 RVA: 0x004DA6D0 File Offset: 0x004D88D0
	private void CheckTabChange()
	{
		if (!this.NeedCheckTabChange)
		{
			return;
		}
		bool flag = false;
		if (ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.CurrentShopId, true).Count != this.CurTabNum)
		{
			flag = true;
		}
		if (flag)
		{
			this.NeedCheckTabChange = false;
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.RefreshPayShop, this.CurrentShopId, true);
		}
	}

	// Token: 0x06011ACC RID: 72396 RVA: 0x004DA72C File Offset: 0x004D892C
	private void OnRefreshTimer()
	{
		List<int> payShopTabIdList = ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.CurrentShopId, true);
		foreach (KeyValuePair<int, PayShopSwitchItem> keyValuePair in this.TabGroup.GetTabItemMap())
		{
			keyValuePair.Value.RefreshCountDown((PayShopDefine.EPayShopTabType)this.CurrentShopId, payShopTabIdList[keyValuePair.Key]);
		}
		this.RefreshTipsText();
		this.CheckTabChange();
		Singleton<EventSystem>.Instance.Emit(EEventName.DiscountShopTimerRefresh);
	}

	// Token: 0x06011ACD RID: 72397 RVA: 0x004DA7CC File Offset: 0x004D89CC
	protected void TryRefreshTabs()
	{
		List<int> payShopTabIdList = ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.CurrentShopId, true);
		if (this.CurTabNum == payShopTabIdList.Count)
		{
			return;
		}
		int num = payShopTabIdList.FindIndex((int tabId) => tabId == this.CurrentSelectTabId);
		this.UpdateTabs((num == -1) ? 0 : num, false);
	}

	// Token: 0x06011ACE RID: 72398 RVA: 0x004DA81C File Offset: 0x004D8A1C
	protected unsafe virtual void UpdateTabs(int selectIndex, bool bScrollTo = false)
	{
		List<int> tabIdList = ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.CurrentShopId, true);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:TabView 页签数据";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ViewName", base.GetViewName());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Data", tabIdList);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		int count = tabIdList.Count;
		this.CurTabNum = count;
		this.TabGroup.ResetLastSelectTab();
		Action callBack = delegate()
		{
			foreach (KeyValuePair<int, PayShopSwitchItem> keyValuePair in this.TabGroup.GetTabItemMap())
			{
				int key = keyValuePair.Key;
				PayShopSwitchItem value = keyValuePair.Value;
				value.UpdateView((PayShopDefine.EPayShopTabType)this.CurrentShopId, tabIdList[key]);
				value.BindRedDot(ERedDotName.PayShopTab, tabIdList[key]);
			}
			this.TabGroup.SelectToggleByIndex(selectIndex, true, true);
			if (bScrollTo)
			{
				this.LateScrollToTab(selectIndex);
			}
		};
		this.TabGroup.RefreshTabItemByLength(count, callBack);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Shop;
		ELogAuthor author2 = ELogAuthor.XXJ;
		string message2 = "PayShop:TabView 选择页签";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", base.GetViewName());
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.NeedCheckTabChange = true;
	}

	// Token: 0x06011ACF RID: 72399 RVA: 0x004DA923 File Offset: 0x004D8B23
	[NullableContext(2)]
	public void RefreshView(object @params)
	{
		if (@params is int)
		{
			return;
		}
		this.TryRefreshTabs();
		this.RefreshLoopScroll(this.CurrentSelectTabId);
	}

	// Token: 0x06011AD0 RID: 72400 RVA: 0x004DA940 File Offset: 0x004D8B40
	protected override void OnShowUiTabViewFromToggle()
	{
		this.TabShowState = true;
		this.AfterShowUiTabViewFromToggle();
	}

	// Token: 0x06011AD1 RID: 72401 RVA: 0x004DA94F File Offset: 0x004D8B4F
	protected virtual void AfterShowUiTabViewFromToggle()
	{
	}

	// Token: 0x06011AD2 RID: 72402 RVA: 0x004DA951 File Offset: 0x004D8B51
	protected virtual void AfterHideTabViewBase(bool fromToggle)
	{
	}

	// Token: 0x06011AD3 RID: 72403 RVA: 0x004DA953 File Offset: 0x004D8B53
	protected override void OnHideUiTabViewBase(bool fromToggle)
	{
		this.RemoveTimer();
		this.TabShowState = false;
		this.AfterHideTabViewBase(fromToggle);
	}

	// Token: 0x06011AD4 RID: 72404 RVA: 0x004DA969 File Offset: 0x004D8B69
	protected override void OnBeforeDestroy()
	{
		this.TabGroup.Destroy(null);
		this.LoopScrollView.ClearGridProxies();
	}

	// Token: 0x06011AD5 RID: 72405 RVA: 0x004DA984 File Offset: 0x004D8B84
	private UniTask QueryProductPriceAndRefresh()
	{
		DiscountShopView.<QueryProductPriceAndRefresh>d__40 <QueryProductPriceAndRefresh>d__;
		<QueryProductPriceAndRefresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<QueryProductPriceAndRefresh>d__.<>4__this = this;
		<QueryProductPriceAndRefresh>d__.<>1__state = -1;
		<QueryProductPriceAndRefresh>d__.<>t__builder.Start<DiscountShopView.<QueryProductPriceAndRefresh>d__40>(ref <QueryProductPriceAndRefresh>d__);
		return <QueryProductPriceAndRefresh>d__.<>t__builder.Task;
	}

	// Token: 0x06011AD6 RID: 72406 RVA: 0x004DA9C8 File Offset: 0x004D8BC8
	public void LateScrollToTab(int index)
	{
		PayShopSwitchItem tabItem = this.TabGroup.GetTabItemByIndex(index);
		UUIScrollViewWithScrollbarComponent scrollView = base.GetScrollViewWithScrollbar(11);
		TTimerAction <>9__1;
		scrollView.OnLateUpdate.Bind(delegate(float _)
		{
			TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
			TTimerAction action;
			if ((action = <>9__1) == null)
			{
				action = (<>9__1 = delegate(float _)
				{
					if (!scrollView.IsValid())
					{
						return;
					}
					scrollView.ScrollTo(tabItem.GetRootItem(), false);
				});
			}
			gameplayTimeInstance.Next(action, null, null);
			scrollView.OnLateUpdate.Unbind();
		});
	}

	// Token: 0x04008A84 RID: 35460
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponent<PayShopSwitchItem> TabGroup;

	// Token: 0x04008A85 RID: 35461
	protected List<IPayShopUnionData> PayShopGoodsList = new List<IPayShopUnionData>();

	// Token: 0x04008A86 RID: 35462
	protected int CurrentSelectTabId;

	// Token: 0x04008A87 RID: 35463
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	protected LoopScrollView<GridProxyAbstract<IPayShopUnionData>, IPayShopUnionData> LoopScrollView;

	// Token: 0x04008A88 RID: 35464
	protected int CurrentShopId;

	// Token: 0x04008A89 RID: 35465
	protected int CurTabNum;

	// Token: 0x04008A8A RID: 35466
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04008A8B RID: 35467
	private bool TabShowState;

	// Token: 0x04008A8C RID: 35468
	private const int TIMEGAP = 1000;

	// Token: 0x04008A8D RID: 35469
	private bool NeedCheckTabChange;
}
