using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023C9 RID: 9161
[NullableContext(1)]
[Nullable(0)]
public class RogueShopTabView : UiTabViewBase, IUiTabViewRefresh
{
	// Token: 0x06011B48 RID: 72520 RVA: 0x004DC87C File Offset: 0x004DAA7C
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

	// Token: 0x06011B49 RID: 72521 RVA: 0x004DC95B File Offset: 0x004DAB5B
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOut));
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
	}

	// Token: 0x06011B4A RID: 72522 RVA: 0x004DC995 File Offset: 0x004DAB95
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOut));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
	}

	// Token: 0x06011B4B RID: 72523 RVA: 0x004DC9CF File Offset: 0x004DABCF
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		if (this.CurrentShopId == (int)shopId && this.CurrentSelectTabId == tabId)
		{
			this.LoopScrollView.RefreshAllGridProxies();
		}
	}

	// Token: 0x06011B4C RID: 72524 RVA: 0x004DC9EE File Offset: 0x004DABEE
	private void OnGoodsSoldOut(int goodsId)
	{
		this.RefreshLoopScroll(this.CurrentSelectTabId);
	}

	// Token: 0x06011B4D RID: 72525 RVA: 0x004DC9FC File Offset: 0x004DABFC
	protected override void OnStart()
	{
		this.TabGroup = new TabComponent<PayShopSwitchItem>(base.GetHorizontalLayout(2).GetRootComponent(), new Func<UUIItem, int?, PayShopSwitchItem>(this.TabItemProxyCreate), new Action<int>(this.ToggleCallBack), base.GetItem(3));
		UUIItem scrollItem = this.GetScrollItem();
		this.LoopScrollView = new LoopScrollView<GridProxyAbstract<IPayShopUnionData>, IPayShopUnionData>(base.GetLoopScrollViewComponent(1), scrollItem.GetOwner() as AUIBaseActor, new Func<GridProxyAbstract<IPayShopUnionData>>(this.InitItem), false);
		base.GetItem(0).SetUIActive(false);
		base.GetItem(6).SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "Rogue_Shop_Sold_out", Array.Empty<object>());
	}

	// Token: 0x06011B4E RID: 72526 RVA: 0x004DCAB3 File Offset: 0x004DACB3
	protected UUIItem GetScrollItem()
	{
		return base.GetItem(0);
	}

	// Token: 0x06011B4F RID: 72527 RVA: 0x004DCABC File Offset: 0x004DACBC
	protected PayShopItem InitItem()
	{
		return new PayShopItem();
	}

	// Token: 0x06011B50 RID: 72528 RVA: 0x004DCAC3 File Offset: 0x004DACC3
	private PayShopSwitchItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new PayShopSwitchItem();
	}

	// Token: 0x06011B51 RID: 72529 RVA: 0x004DCACC File Offset: 0x004DACCC
	private void ToggleCallBack(int tabIndex)
	{
		List<int> payShopTabIdList = ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.CurrentShopId, true);
		this.CurrentSelectTabId = payShopTabIdList[tabIndex];
		this.RefreshLoopScroll(this.CurrentSelectTabId);
	}

	// Token: 0x06011B52 RID: 72530 RVA: 0x004DCB04 File Offset: 0x004DAD04
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

	// Token: 0x06011B53 RID: 72531 RVA: 0x004DCBDC File Offset: 0x004DADDC
	protected IPayShopUnionData GetProxyData(int gridIndex)
	{
		return this.PayShopGoodsList[gridIndex];
	}

	// Token: 0x06011B54 RID: 72532 RVA: 0x004DCBEC File Offset: 0x004DADEC
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

	// Token: 0x06011B55 RID: 72533 RVA: 0x004DCC85 File Offset: 0x004DAE85
	protected virtual void OnDiscountShopAfterShow()
	{
	}

	// Token: 0x06011B56 RID: 72534 RVA: 0x004DCC87 File Offset: 0x004DAE87
	private void AddTimer()
	{
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.OnRefreshTimer();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x06011B57 RID: 72535 RVA: 0x004DCCB2 File Offset: 0x004DAEB2
	private void RemoveTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06011B58 RID: 72536 RVA: 0x004DCCD4 File Offset: 0x004DAED4
	private void OnRefreshTimer()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.DiscountShopTimerRefresh);
	}

	// Token: 0x06011B59 RID: 72537 RVA: 0x004DCCE8 File Offset: 0x004DAEE8
	private void UpdateTabs(int selectIndex)
	{
		RogueShopTabView.<>c__DisplayClass25_0 CS$<>8__locals1 = new RogueShopTabView.<>c__DisplayClass25_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.selectIndex = selectIndex;
		CS$<>8__locals1.tabIdList = ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.CurrentShopId, true);
		int count = CS$<>8__locals1.tabIdList.Count;
		this.TabGroup.ResetLastSelectTab();
		this.TabGroup.RefreshTabItemByLength(count, new Action(CS$<>8__locals1.<UpdateTabs>g__CallBack|0));
	}

	// Token: 0x06011B5A RID: 72538 RVA: 0x004DCD4F File Offset: 0x004DAF4F
	[NullableContext(2)]
	public void RefreshView(object @params)
	{
		if (@params is int)
		{
			return;
		}
		this.RefreshLoopScroll(this.CurrentSelectTabId);
	}

	// Token: 0x06011B5B RID: 72539 RVA: 0x004DCD66 File Offset: 0x004DAF66
	protected override void OnBeforeHide()
	{
		this.RemoveTimer();
	}

	// Token: 0x06011B5C RID: 72540 RVA: 0x004DCD6E File Offset: 0x004DAF6E
	protected override void OnBeforeDestroy()
	{
		this.TabGroup.Destroy(null);
		this.LoopScrollView.ClearGridProxies();
	}

	// Token: 0x04008AAF RID: 35503
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponent<PayShopSwitchItem> TabGroup;

	// Token: 0x04008AB0 RID: 35504
	protected List<IPayShopUnionData> PayShopGoodsList = new List<IPayShopUnionData>();

	// Token: 0x04008AB1 RID: 35505
	protected int CurrentSelectTabId;

	// Token: 0x04008AB2 RID: 35506
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	protected LoopScrollView<GridProxyAbstract<IPayShopUnionData>, IPayShopUnionData> LoopScrollView;

	// Token: 0x04008AB3 RID: 35507
	private int CurrentShopId;

	// Token: 0x04008AB4 RID: 35508
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04008AB5 RID: 35509
	private const int TIMEGAP = 1000;

	// Token: 0x020086FD RID: 34557
	[NullableContext(0)]
	private enum EDiscountShopComponent
	{
		// Token: 0x0402DA54 RID: 186964
		ScrollerItem,
		// Token: 0x0402DA55 RID: 186965
		Scroller,
		// Token: 0x0402DA56 RID: 186966
		HoriGroupScroller,
		// Token: 0x0402DA57 RID: 186967
		TabItem,
		// Token: 0x0402DA58 RID: 186968
		TabPanel,
		// Token: 0x0402DA59 RID: 186969
		TitleTips,
		// Token: 0x0402DA5A RID: 186970
		ScrollerItemRecharge,
		// Token: 0x0402DA5B RID: 186971
		PanelItem,
		// Token: 0x0402DA5C RID: 186972
		EmptyItem,
		// Token: 0x0402DA5D RID: 186973
		EmptyText
	}
}
