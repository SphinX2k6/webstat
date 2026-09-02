using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023C3 RID: 9155
[NullableContext(1)]
[Nullable(0)]
public class PayShopExchangeEntryView : UiTabViewBase, IUiTabViewRefresh
{
	// Token: 0x06011AE6 RID: 72422 RVA: 0x004DAD3C File Offset: 0x004D8F3C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06011AE7 RID: 72423 RVA: 0x004DAD98 File Offset: 0x004D8F98
	protected override void OnStart()
	{
		this.TabLayout = new GenericScrollView<PayShopSecondTabItem>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<PayShopSecondTabItem>(this.InitTabItem), null);
		UUIItem item = base.GetItem(2);
		this.LoopScrollView = new LoopScrollView<PayShopGiftItem, PayShopGoods>(base.GetLoopScrollViewComponent(1), item.GetOwner() as AUIBaseActor, new Func<PayShopGiftItem>(this.InitItem), false);
	}

	// Token: 0x06011AE8 RID: 72424 RVA: 0x004DADF8 File Offset: 0x004D8FF8
	protected void RefreshTabItem()
	{
		List<int> payShopTabIdList = ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.Params, true);
		this.CurrentTabId = payShopTabIdList[0];
		this.TabLayout.RefreshByData<int>(payShopTabIdList, null);
		this.SelectTabItem();
	}

	// Token: 0x06011AE9 RID: 72425 RVA: 0x004DAE44 File Offset: 0x004D9044
	protected void SelectTabItem()
	{
		if (this.CurrentTabId != 0)
		{
			PayShopSecondTabItem scrollItemByKey = this.TabLayout.GetScrollItemByKey(this.CurrentTabId);
			if (scrollItemByKey != null)
			{
				scrollItemByKey.SetToggleState(true);
			}
		}
	}

	// Token: 0x06011AEA RID: 72426 RVA: 0x004DAE7A File Offset: 0x004D907A
	protected void RefreshLoopScroll()
	{
		this.PayShopGoodsList = ModelBase<PayShopModel>.Instance.GetPayShopTabData(PayShopDefine.EPayShopTabType.ExchangeEntry, this.CurrentTabId, true);
		this.LoopScrollView.ReloadProxyData(new Func<int, PayShopGoods>(this.GetProxyData), this.PayShopGoodsList.Count, false, false);
	}

	// Token: 0x06011AEB RID: 72427 RVA: 0x004DAEB8 File Offset: 0x004D90B8
	protected override void OnBeforeShow()
	{
		this.RefreshTabItem();
		this.LoopScrollView.ClearGridProxies();
		this.RefreshLoopScroll();
	}

	// Token: 0x06011AEC RID: 72428 RVA: 0x004DAED1 File Offset: 0x004D90D1
	protected override void OnBeforeHide()
	{
		this.LoopScrollView.ClearGridProxies();
	}

	// Token: 0x06011AED RID: 72429 RVA: 0x004DAEDE File Offset: 0x004D90DE
	protected override void OnBeforeDestroy()
	{
		if (this.TabLayout != null)
		{
			this.TabLayout.ClearChildren();
			this.TabLayout = null;
		}
	}

	// Token: 0x06011AEE RID: 72430 RVA: 0x004DAEFC File Offset: 0x004D90FC
	private ILayoutItem<PayShopSecondTabItem> InitTabItem(object tabId, UUIItem uiItem, int index)
	{
		PayShopSecondTabItem payShopSecondTabItem = new PayShopSecondTabItem(uiItem);
		payShopSecondTabItem.SetName(PayShopDefine.EPayShopTabType.ExchangeEntry, (int)tabId);
		payShopSecondTabItem.SetToggleFunction(new Action<int>(this.TabToggleFunction));
		return new LayoutItem<PayShopSecondTabItem>
		{
			Key = (int)tabId,
			Value = payShopSecondTabItem
		};
	}

	// Token: 0x06011AEF RID: 72431 RVA: 0x004DAF4C File Offset: 0x004D914C
	private void TabToggleFunction(int tabId)
	{
		if (this.CurrentTabId != 0)
		{
			PayShopSecondTabItem scrollItemByKey = this.TabLayout.GetScrollItemByKey(this.CurrentTabId);
			if (scrollItemByKey != null)
			{
				scrollItemByKey.SetToggleState(false);
			}
		}
		this.CurrentTabId = tabId;
		this.LoopScrollView.ClearGridProxies();
		this.RefreshLoopScroll();
	}

	// Token: 0x06011AF0 RID: 72432 RVA: 0x004DAF9A File Offset: 0x004D919A
	private PayShopGiftItem InitItem()
	{
		PayShopGiftItem payShopGiftItem = new PayShopGiftItem(EQualityPathType.PathType1, null);
		payShopGiftItem.SetToggleFunction(new Action<int>(this.OpenExchangeView));
		return payShopGiftItem;
	}

	// Token: 0x06011AF1 RID: 72433 RVA: 0x004DAFB5 File Offset: 0x004D91B5
	private void OpenExchangeView(int goodsId)
	{
		ControllerBase<PayShopController>.Instance.OpenExchangePopView(goodsId, null);
	}

	// Token: 0x06011AF2 RID: 72434 RVA: 0x004DAFC3 File Offset: 0x004D91C3
	private PayShopGoods GetProxyData(int gridIndex)
	{
		return this.PayShopGoodsList[gridIndex];
	}

	// Token: 0x06011AF3 RID: 72435 RVA: 0x004DAFD4 File Offset: 0x004D91D4
	[NullableContext(2)]
	public void RefreshView(object @params)
	{
		if (@params is int)
		{
			int num = (int)@params;
			if (this.CurrentTabId != num)
			{
				this.CurrentTabId = num;
				this.SelectTabItem();
			}
			this.LoopScrollView.ClearGridProxies();
			this.RefreshLoopScroll();
			return;
		}
		HashSet<int> hashSet = @params as HashSet<int>;
		if (hashSet != null && hashSet.Contains(this.CurrentTabId))
		{
			this.LoopScrollView.ClearGridProxies();
			this.RefreshLoopScroll();
		}
	}

	// Token: 0x04008A8F RID: 35471
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<PayShopGiftItem, PayShopGoods> LoopScrollView;

	// Token: 0x04008A90 RID: 35472
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollView<PayShopSecondTabItem> TabLayout;

	// Token: 0x04008A91 RID: 35473
	protected int CurrentTabId;

	// Token: 0x04008A92 RID: 35474
	protected List<PayShopGoods> PayShopGoodsList = new List<PayShopGoods>();

	// Token: 0x04008A93 RID: 35475
	protected Dictionary<int, int> PayShopGoodsMap = new Dictionary<int, int>();

	// Token: 0x020086EE RID: 34542
	[NullableContext(0)]
	private enum EPayShopExchangeEntryViewDefine
	{
		// Token: 0x0402DA0D RID: 186893
		TabRootLayout,
		// Token: 0x0402DA0E RID: 186894
		ScrollView,
		// Token: 0x0402DA0F RID: 186895
		ScrollItem
	}
}
