using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023BF RID: 9151
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerShopTabView : UiTabViewBase, IUiTabViewRefresh
{
	// Token: 0x06011AA0 RID: 72352 RVA: 0x004D9AC8 File Offset: 0x004D7CC8
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
			new ValueTuple<int, Type>(9, typeof(UUIText))
		};
	}

	// Token: 0x06011AA1 RID: 72353 RVA: 0x004D9BA7 File Offset: 0x004D7DA7
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOut));
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
	}

	// Token: 0x06011AA2 RID: 72354 RVA: 0x004D9BE1 File Offset: 0x004D7DE1
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOut));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
	}

	// Token: 0x06011AA3 RID: 72355 RVA: 0x004D9C1B File Offset: 0x004D7E1B
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		if (this.CurrentShopId == (int)shopId && this.CurrentSelectTabId == tabId)
		{
			this.LoopScrollView.RefreshAllGridProxies();
		}
	}

	// Token: 0x06011AA4 RID: 72356 RVA: 0x004D9C3A File Offset: 0x004D7E3A
	private void OnGoodsSoldOut(int goodsId)
	{
		this.RefreshLoopScroll(this.CurrentSelectTabId);
	}

	// Token: 0x06011AA5 RID: 72357 RVA: 0x004D9C48 File Offset: 0x004D7E48
	protected override void OnStart()
	{
		this.TabGroup = new TabComponent<PayShopSwitchItem>(base.GetHorizontalLayout(2).GetRootComponent(), new Func<UUIItem, int?, PayShopSwitchItem>(this.TabItemProxyCreate), new Action<int>(this.ToggleCallBack), base.GetItem(3));
		UUIItem scrollItem = this.GetScrollItem();
		this.LoopScrollView = new LoopScrollView<PayShopItem, IPayShopUnionData>(base.GetLoopScrollViewComponent(1), scrollItem.GetOwner() as AUIBaseActor, new Func<PayShopItem>(this.InitItem), false);
		base.GetItem(0).SetUIActive(false);
		base.GetItem(6).SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
		this.TabGroup.SelectToggleByIndex(0, false, true);
	}

	// Token: 0x06011AA6 RID: 72358 RVA: 0x004D9CF1 File Offset: 0x004D7EF1
	protected UUIItem GetScrollItem()
	{
		return base.GetItem(0);
	}

	// Token: 0x06011AA7 RID: 72359 RVA: 0x004D9CFA File Offset: 0x004D7EFA
	protected PayShopItem InitItem()
	{
		return new PayShopItem();
	}

	// Token: 0x06011AA8 RID: 72360 RVA: 0x004D9D01 File Offset: 0x004D7F01
	private PayShopSwitchItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new PayShopSwitchItem();
	}

	// Token: 0x06011AA9 RID: 72361 RVA: 0x004D9D08 File Offset: 0x004D7F08
	private void ToggleCallBack(int tabIndex)
	{
		List<int> payShopTabIdList = ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.CurrentShopId, true);
		this.CurrentSelectTabId = payShopTabIdList[tabIndex];
		this.RefreshLoopScroll(this.CurrentSelectTabId);
	}

	// Token: 0x06011AAA RID: 72362 RVA: 0x004D9D40 File Offset: 0x004D7F40
	protected void RefreshLoopScroll(int tabId)
	{
		List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)this.CurrentShopId, tabId, true);
		this.PayShopGoodsList.Clear();
		foreach (PayShopGoods item in payShopTabData)
		{
			this.PayShopGoodsList.Add(item);
		}
		this.LoopScrollView.ReloadProxyData(new Func<int, IPayShopUnionData>(this.GetProxyData), this.PayShopGoodsList.Count, false, false);
		base.GetLoopScrollViewComponent(1).RootUIComp.Get().SetUIActive(this.PayShopGoodsList.Count > 0);
		base.GetItem(8).SetUIActive(this.PayShopGoodsList.Count <= 0);
	}

	// Token: 0x06011AAB RID: 72363 RVA: 0x004D9E18 File Offset: 0x004D8018
	protected IPayShopUnionData GetProxyData(int gridIndex)
	{
		return this.PayShopGoodsList[gridIndex];
	}

	// Token: 0x06011AAC RID: 72364 RVA: 0x004D9E28 File Offset: 0x004D8028
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
		this.UpdateTabs(num);
		this.AddTimer();
		this.OnDiscountShopAfterShow();
	}

	// Token: 0x06011AAD RID: 72365 RVA: 0x004D9EC1 File Offset: 0x004D80C1
	protected virtual void OnDiscountShopAfterShow()
	{
	}

	// Token: 0x06011AAE RID: 72366 RVA: 0x004D9EC3 File Offset: 0x004D80C3
	private void AddTimer()
	{
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.OnRefreshTimer();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x06011AAF RID: 72367 RVA: 0x004D9EEE File Offset: 0x004D80EE
	private void RemoveTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06011AB0 RID: 72368 RVA: 0x004D9F10 File Offset: 0x004D8110
	private void OnRefreshTimer()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.DiscountShopTimerRefresh);
	}

	// Token: 0x06011AB1 RID: 72369 RVA: 0x004D9F24 File Offset: 0x004D8124
	private void UpdateTabs(int selectIndex)
	{
		BabelTowerShopTabView.<>c__DisplayClass25_0 CS$<>8__locals1 = new BabelTowerShopTabView.<>c__DisplayClass25_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.selectIndex = selectIndex;
		CS$<>8__locals1.tabIdList = ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.CurrentShopId, true);
		int count = CS$<>8__locals1.tabIdList.Count;
		this.TabGroup.ResetLastSelectTab();
		this.TabGroup.RefreshTabItemByLength(count, new Action(CS$<>8__locals1.<UpdateTabs>g__CallBack|0));
	}

	// Token: 0x06011AB2 RID: 72370 RVA: 0x004D9F8B File Offset: 0x004D818B
	[NullableContext(2)]
	public void RefreshView(object @params)
	{
		if (@params is int)
		{
			return;
		}
		this.RefreshLoopScroll(this.CurrentSelectTabId);
	}

	// Token: 0x06011AB3 RID: 72371 RVA: 0x004D9FA2 File Offset: 0x004D81A2
	protected override void OnBeforeHide()
	{
		this.RemoveTimer();
	}

	// Token: 0x06011AB4 RID: 72372 RVA: 0x004D9FAA File Offset: 0x004D81AA
	protected override void OnBeforeDestroy()
	{
		this.TabGroup.Destroy(null);
		this.LoopScrollView.ClearGridProxies();
	}

	// Token: 0x04008A70 RID: 35440
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponent<PayShopSwitchItem> TabGroup;

	// Token: 0x04008A71 RID: 35441
	protected List<IPayShopUnionData> PayShopGoodsList = new List<IPayShopUnionData>();

	// Token: 0x04008A72 RID: 35442
	protected int CurrentSelectTabId;

	// Token: 0x04008A73 RID: 35443
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<PayShopItem, IPayShopUnionData> LoopScrollView;

	// Token: 0x04008A74 RID: 35444
	private int CurrentShopId;

	// Token: 0x04008A75 RID: 35445
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04008A76 RID: 35446
	private const int TIMEGAP = 1000;

	// Token: 0x020086E5 RID: 34533
	[NullableContext(0)]
	private enum EDiscountShopComponent
	{
		// Token: 0x0402D9E8 RID: 186856
		ScrollerItem,
		// Token: 0x0402D9E9 RID: 186857
		Scroller,
		// Token: 0x0402D9EA RID: 186858
		HoriGroupScroller,
		// Token: 0x0402D9EB RID: 186859
		TabItem,
		// Token: 0x0402D9EC RID: 186860
		TabPanel,
		// Token: 0x0402D9ED RID: 186861
		TitleTips,
		// Token: 0x0402D9EE RID: 186862
		ScrollerItemRecharge,
		// Token: 0x0402D9EF RID: 186863
		PanelItem,
		// Token: 0x0402D9F0 RID: 186864
		EmptyItem,
		// Token: 0x0402D9F1 RID: 186865
		EmptyText
	}
}
