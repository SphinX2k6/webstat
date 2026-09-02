using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020023C8 RID: 9160
public class PayShopSkinView : UiTabViewBase, IUiTabViewRefresh
{
	// Token: 0x06011B38 RID: 72504 RVA: 0x004DC214 File Offset: 0x004DA414
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
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
	}

	// Token: 0x06011B39 RID: 72505 RVA: 0x004DC2DC File Offset: 0x004DA4DC
	protected override void OnStart()
	{
		this.TabGroup = new TabComponent<PayShopSwitchItem>(base.GetHorizontalLayout(2).GetRootComponent(), new Func<UUIItem, int?, PayShopSwitchItem>(this.TabItemProxyCreate), new Action<int>(this.ToggleCallBack), base.GetItem(3));
		base.GetLoopScrollViewComponent(1).RootUIComp.Get().SetUIActive(false);
		base.GetItem(0).SetUIActive(false);
		base.GetItem(6).SetUIActive(false);
		this.TabViewComponent = new TabViewComponent<int>(base.GetItem(7), EKeyMode.Default);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "PayShop:TabView 界面Start";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", base.GetViewName());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06011B3A RID: 72506 RVA: 0x004DC392 File Offset: 0x004DA592
	[NullableContext(1)]
	private PayShopSwitchItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new PayShopSwitchItem();
	}

	// Token: 0x06011B3B RID: 72507 RVA: 0x004DC39C File Offset: 0x004DA59C
	private void ToggleCallBack(int gridIndex)
	{
		this.CurrentSelectTabId = this.TabList[gridIndex];
		int currentSelectTabId = this.CurrentSelectTabId;
		EUiTabViewName viewName = PayShopDefine.SkinTabView[(PayShopDefine.ESkinTabType)currentSelectTabId];
		PayShopSwitchItem tabItemByIndex = this.TabGroup.GetTabItemByIndex(gridIndex);
		this.TabViewComponent.ToggleCallBack(currentSelectTabId, viewName, tabItemByIndex, this.CurrentShopId, null);
		OnClickPayShopTabLogEvent onClickPayShopTabLogEvent = new OnClickPayShopTabLogEvent();
		onClickPayShopTabLogEvent.i_shop_id = this.CurrentShopId;
		onClickPayShopTabLogEvent.i_tab_id = currentSelectTabId;
		ControllerBase<LogReportController>.Instance.LogReport(onClickPayShopTabLogEvent);
		this.TryRefreshRootShopMoney();
	}

	// Token: 0x06011B3C RID: 72508 RVA: 0x004DC428 File Offset: 0x004DA628
	private void TryRefreshRootShopMoney()
	{
		PayShopTabData payShopTabDataByPayShopIdAndTabId = ModelBase<PayShopModel>.Instance.GetPayShopTabDataByPayShopIdAndTabId((PayShopDefine.EPayShopTabType)this.CurrentShopId, this.CurrentSelectTabId);
		List<int> list = ((payShopTabDataByPayShopIdAndTabId != null) ? payShopTabDataByPayShopIdAndTabId.MoneyList : null) ?? new List<int>();
		List<int> list2 = (list.Count > 0) ? list : ModelBase<PayShopModel>.Instance.GetPayShopInfoMoney((PayShopDefine.EPayShopTabType)this.CurrentShopId);
		if (list2.Count > 0)
		{
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.TryRefreshRootShopMoney, list2);
		}
	}

	// Token: 0x06011B3D RID: 72509 RVA: 0x004DC498 File Offset: 0x004DA698
	protected override void OnBeforeShow()
	{
		this.CurrentShopId = (int)this.Params;
		base.GetText(5).SetUIActive(false);
		this.RefreshSkinTabs();
	}

	// Token: 0x06011B3E RID: 72510 RVA: 0x004DC4BE File Offset: 0x004DA6BE
	protected override void OnHideUiTabViewBase(bool fromToggle)
	{
		if (fromToggle)
		{
			this.TabGroup.ResetSelectIndex();
		}
		this.NeedCheckGoodsList.Clear();
	}

	// Token: 0x06011B3F RID: 72511 RVA: 0x004DC4DC File Offset: 0x004DA6DC
	protected override void OnAfterShow()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "PayShop:TabView 界面AfterShow";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", base.GetViewName());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06011B40 RID: 72512 RVA: 0x004DC515 File Offset: 0x004DA715
	protected override void OnBeforeHide()
	{
		this.TabViewComponent.SetCurrentTabViewState(false);
	}

	// Token: 0x06011B41 RID: 72513 RVA: 0x004DC524 File Offset: 0x004DA724
	private UniTask UpdateTabs()
	{
		PayShopSkinView.<UpdateTabs>d__18 <UpdateTabs>d__;
		<UpdateTabs>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateTabs>d__.<>4__this = this;
		<UpdateTabs>d__.<>1__state = -1;
		<UpdateTabs>d__.<>t__builder.Start<PayShopSkinView.<UpdateTabs>d__18>(ref <UpdateTabs>d__);
		return <UpdateTabs>d__.<>t__builder.Task;
	}

	// Token: 0x06011B42 RID: 72514 RVA: 0x004DC567 File Offset: 0x004DA767
	protected override void OnBeforeDestroy()
	{
		this.TabGroup.Destroy(null);
		if (this.TabViewComponent != null)
		{
			this.TabViewComponent.DestroyTabViewComponent();
			this.TabViewComponent = null;
		}
	}

	// Token: 0x06011B43 RID: 72515 RVA: 0x004DC58F File Offset: 0x004DA78F
	[NullableContext(2)]
	public void RefreshView(object @params)
	{
		this.RefreshSkinTabs();
	}

	// Token: 0x06011B44 RID: 72516 RVA: 0x004DC598 File Offset: 0x004DA798
	protected override void OnTickUiTabViewBase(float deltaTime)
	{
		if (!this.AllowTick)
		{
			return;
		}
		if (this.NeedCheckGoodsList.Count <= 0)
		{
			this.AllowTick = false;
			return;
		}
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		int count = this.NeedCheckGoodsList.Count;
		for (int i = 0; i < count; i++)
		{
			PayShopGoods payShopGoods = this.NeedCheckGoodsList[i];
			if (payShopGoods.NeedUpdate() || payShopGoods.NeedDown())
			{
				if (payShopGoods.IsDirect())
				{
					list.Add(payShopGoods.GetGoodsId());
				}
				else
				{
					list2.Add(payShopGoods.GetGoodsId());
				}
			}
		}
		if (list2.Count <= 0 && list.Count <= 0)
		{
			return;
		}
		this.AllowTick = false;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "PayShop:Skin 请求刷新商品";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("goodsList", list2);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (list2.Count > 0)
		{
			ControllerBase<PayShopController>.Instance.SendRequestPayShopItemUpdate(list2.ToArray());
		}
		if (list.Count > 0)
		{
			ControllerBase<PayGiftController>.Instance.SendPayGiftInfoRequest(true);
		}
	}

	// Token: 0x06011B45 RID: 72517 RVA: 0x004DC6A0 File Offset: 0x004DA8A0
	private void UpdateGoodsList()
	{
		List<PayShopGoods> payShopGoodsByTabType = ModelBase<PayShopModel>.Instance.GetPayShopGoodsByTabType(PayShopDefine.EPayShopTabType.SkinShop, 3);
		List<PayShopGoods> list = new List<PayShopGoods>();
		int count = payShopGoodsByTabType.Count;
		for (int i = 0; i < count; i++)
		{
			PayShopGoods payShopGoods = payShopGoodsByTabType[i];
			if (payShopGoods.IsShowInShop() && (payShopGoods.InUpdateTime() || payShopGoods.InUnPermanentSellTime() || payShopGoods.WillSell()))
			{
				list.Add(payShopGoods);
			}
		}
		this.NeedCheckGoodsList.Clear();
		this.NeedCheckGoodsList.AddRange(list);
		this.AllowTick = (this.NeedCheckGoodsList.Count > 0);
	}

	// Token: 0x06011B46 RID: 72518 RVA: 0x004DC734 File Offset: 0x004DA934
	private void RefreshSkinTabs()
	{
		List<int> payShopTableList = ModelBase<PayShopModel>.Instance.GetPayShopTableList(6);
		this.UpdateGoodsList();
		this.TabList.Clear();
		int count = payShopTableList.Count;
		for (int i = 0; i < count; i++)
		{
			int num = payShopTableList[i];
			if (num != 3)
			{
				this.TabList.Add(num);
			}
			else if (ModelBase<PayShopModel>.Instance.GetPayShopTabData(PayShopDefine.EPayShopTabType.SkinShop, num, true).Count > 0)
			{
				this.TabList.Add(num);
			}
		}
		int openIndex = 0;
		if (this.ExtraParams != null && this.IsFirstOpen)
		{
			this.IsFirstOpen = false;
			int num2 = (int)this.ExtraParams;
			int count2 = this.TabList.Count;
			for (int j = 0; j < count2; j++)
			{
				if (this.TabList[j] == num2)
				{
					openIndex = j;
					break;
				}
			}
		}
		else
		{
			openIndex = this.TabGroup.TryGetSelectedIndex(openIndex);
		}
		this.UpdateTabs().ContinueWith(delegate()
		{
			this.TabGroup.SelectToggleByIndex(openIndex, true, true);
			this.TabViewComponent.SetCurrentTabViewState(true);
		}).Forget();
	}

	// Token: 0x04008AA7 RID: 35495
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponent<PayShopSwitchItem> TabGroup;

	// Token: 0x04008AA8 RID: 35496
	[Nullable(2)]
	protected TabViewComponent<int> TabViewComponent;

	// Token: 0x04008AA9 RID: 35497
	[Nullable(1)]
	protected List<int> TabList = new List<int>();

	// Token: 0x04008AAA RID: 35498
	protected int CurrentSelectTabId;

	// Token: 0x04008AAB RID: 35499
	private int CurrentShopId;

	// Token: 0x04008AAC RID: 35500
	[Nullable(1)]
	private readonly List<PayShopGoods> NeedCheckGoodsList = new List<PayShopGoods>();

	// Token: 0x04008AAD RID: 35501
	private bool AllowTick;

	// Token: 0x04008AAE RID: 35502
	private bool IsFirstOpen = true;

	// Token: 0x020086FA RID: 34554
	private enum EComponent
	{
		// Token: 0x0402DA45 RID: 186949
		ScrollerItem,
		// Token: 0x0402DA46 RID: 186950
		Scroller,
		// Token: 0x0402DA47 RID: 186951
		GroupScroller,
		// Token: 0x0402DA48 RID: 186952
		TabItem,
		// Token: 0x0402DA49 RID: 186953
		TabPanel,
		// Token: 0x0402DA4A RID: 186954
		TitleTips,
		// Token: 0x0402DA4B RID: 186955
		ScrollerItemRecharge,
		// Token: 0x0402DA4C RID: 186956
		PanelContent
	}
}
