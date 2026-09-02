using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020023C7 RID: 9159
[NullableContext(1)]
[Nullable(0)]
public class PayShopRecommendView : UiTabViewBase, IUiTabViewRefresh
{
	// Token: 0x06011B28 RID: 72488 RVA: 0x004DBD1C File Offset: 0x004D9F1C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06011B29 RID: 72489 RVA: 0x004DBD8C File Offset: 0x004D9F8C
	protected override void OnStart()
	{
		this.TabGroup = new TabComponent<PayShopRecommendSwitchItem>(base.GetHorizontalLayout(0).GetRootComponent(), new Func<UUIItem, int?, PayShopRecommendSwitchItem>(this.TabItemProxyCreate), new Action<int>(this.ToggleCallBack), base.GetItem(1));
		this.TabViewComponent = new TabViewComponent<int>(base.GetItem(3), EKeyMode.Index);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:TabView 界面Start";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", base.GetViewName());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06011B2A RID: 72490 RVA: 0x004DBE10 File Offset: 0x004DA010
	protected override void OnTickUiTabViewBase(float deltaTime)
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if (serverTime - this.LastUpdateTime >= 1.0)
		{
			this.LastUpdateTime = serverTime;
			Singleton<EventSystem>.Instance.Emit(EEventName.DiscountShopTimerRefresh);
		}
	}

	// Token: 0x06011B2B RID: 72491 RVA: 0x004DBE52 File Offset: 0x004DA052
	private PayShopRecommendSwitchItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new PayShopRecommendSwitchItem();
	}

	// Token: 0x06011B2C RID: 72492 RVA: 0x004DBE5C File Offset: 0x004DA05C
	private void ToggleCallBack(int gridIndex)
	{
		PayShopRecommendView.RecommendData recommendData = this.TabRecommendData[gridIndex];
		EUiTabViewName value = recommendData.TabViewName.Value;
		PayShopRecommendSwitchItem tabItemByIndex = this.TabGroup.GetTabItemByIndex(gridIndex);
		int id = recommendData.Id;
		this.TabViewComponent.ToggleCallBack(gridIndex, value, tabItemByIndex, id, new int?(recommendData.Id));
		OnClickPayShopTabLogEvent onClickPayShopTabLogEvent = new OnClickPayShopTabLogEvent();
		onClickPayShopTabLogEvent.i_shop_id = 1;
		onClickPayShopTabLogEvent.i_tab_id = recommendData.Id;
		ControllerBase<LogReportController>.Instance.LogReport(onClickPayShopTabLogEvent);
	}

	// Token: 0x06011B2D RID: 72493 RVA: 0x004DBEDD File Offset: 0x004DA0DD
	protected override void OnShowUiTabViewFromToggle()
	{
		this.RefreshTab();
	}

	// Token: 0x06011B2E RID: 72494 RVA: 0x004DBEE5 File Offset: 0x004DA0E5
	protected override void OnShowUiTabViewFromView()
	{
		this.TabViewComponent.SetCurrentTabViewState(true);
	}

	// Token: 0x06011B2F RID: 72495 RVA: 0x004DBEF3 File Offset: 0x004DA0F3
	protected override void OnHideUiTabViewBase(bool fromToggle)
	{
		this.TabViewComponent.SetCurrentTabViewState(false);
	}

	// Token: 0x06011B30 RID: 72496 RVA: 0x004DBF04 File Offset: 0x004DA104
	private void RefreshTab()
	{
		this.InitRecommendData();
		int openTab = 0;
		if (this.ExtraParams != null)
		{
			int num = (int)this.ExtraParams;
			for (int i = 0; i < this.TabRecommendData.Count; i++)
			{
				if (this.TabRecommendData[i].Id == num)
				{
					openTab = i;
					break;
				}
			}
		}
		this.TabGroup.ResetLastSelectTab();
		this.UpdateTabs().ContinueWith(delegate()
		{
			this.TabGroup.SelectToggleByIndex(openTab, true, true);
			this.TabViewComponent.SetCurrentTabViewState(true);
		}).Forget();
	}

	// Token: 0x06011B31 RID: 72497 RVA: 0x004DBF9C File Offset: 0x004DA19C
	private void InitRecommendData()
	{
		this.TabRecommendData.Clear();
		List<PayShopRecommendData> needShowRecommendData = ModelBase<PayShopModel>.Instance.GetNeedShowRecommendData();
		int count = needShowRecommendData.Count;
		int i = 0;
		while (i < count)
		{
			PayShopRecommendData payShopRecommendData = needShowRecommendData[i];
			PayShopRecommendView.RecommendData recommendData = new PayShopRecommendView.RecommendData();
			if (payShopRecommendData.RecommendType == 1)
			{
				recommendData.TabViewName = new EUiTabViewName?(PayShopDefine.RecommendTabView[PayShopDefine.ERecommendTabType.MonthCard]);
				goto IL_CE;
			}
			if (payShopRecommendData.RecommendType == 2)
			{
				recommendData.TabViewName = new EUiTabViewName?(PayShopDefine.RecommendTabView[PayShopDefine.ERecommendTabType.RoleSkinRecommendView]);
				goto IL_CE;
			}
			if (payShopRecommendData.RecommendType == 3)
			{
				if (ModelBase<WeekCardModel>.Instance.GetViewModel(EWeekCardKind.Normal).IsKindOpen())
				{
					recommendData.TabViewName = new EUiTabViewName?(PayShopDefine.RecommendTabView[PayShopDefine.ERecommendTabType.WeekCard]);
					goto IL_CE;
				}
			}
			else
			{
				if (payShopRecommendData.RecommendType == 4)
				{
					recommendData.TabViewName = new EUiTabViewName?(PayShopDefine.RecommendTabView[PayShopDefine.ERecommendTabType.MotorSkin]);
					goto IL_CE;
				}
				goto IL_CE;
			}
			IL_157:
			i++;
			continue;
			IL_CE:
			recommendData.TabName = payShopRecommendData.TabName;
			recommendData.TabImage = payShopRecommendData.TabImage;
			recommendData.Param = payShopRecommendData.RecommendId;
			recommendData.Id = payShopRecommendData.Id;
			recommendData.Sort = payShopRecommendData.Sort;
			int boughtParam = (payShopRecommendData.RecommendType == 4 || payShopRecommendData.RecommendType == 2) ? payShopRecommendData.RecommendId : -1;
			recommendData.HasBought = ModelBase<PayShopModel>.Instance.CheckRecommendHasBought(payShopRecommendData.RecommendType, boughtParam);
			this.TabRecommendData.Add(recommendData);
			goto IL_157;
		}
		this.TabRecommendData.Sort(new Comparison<PayShopRecommendView.RecommendData>(this.CompareSortListItems));
	}

	// Token: 0x06011B32 RID: 72498 RVA: 0x004DC122 File Offset: 0x004DA322
	private int CompareSortListItems(PayShopRecommendView.RecommendData a, PayShopRecommendView.RecommendData b)
	{
		if (a.HasBought == b.HasBought)
		{
			return a.Sort.CompareTo(b.Sort);
		}
		if (!a.HasBought)
		{
			return -1;
		}
		return 1;
	}

	// Token: 0x06011B33 RID: 72499 RVA: 0x004DC150 File Offset: 0x004DA350
	protected override void OnAfterShow()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:TabView 界面AfterShow";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", base.GetViewName());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06011B34 RID: 72500 RVA: 0x004DC18C File Offset: 0x004DA38C
	private UniTask UpdateTabs()
	{
		PayShopRecommendView.<UpdateTabs>d__19 <UpdateTabs>d__;
		<UpdateTabs>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateTabs>d__.<>4__this = this;
		<UpdateTabs>d__.<>1__state = -1;
		<UpdateTabs>d__.<>t__builder.Start<PayShopRecommendView.<UpdateTabs>d__19>(ref <UpdateTabs>d__);
		return <UpdateTabs>d__.<>t__builder.Task;
	}

	// Token: 0x06011B35 RID: 72501 RVA: 0x004DC1CF File Offset: 0x004DA3CF
	protected override void OnBeforeDestroy()
	{
		this.TabGroup.Destroy(null);
		if (this.TabViewComponent != null)
		{
			this.TabViewComponent.DestroyTabViewComponent();
			this.TabViewComponent = null;
		}
	}

	// Token: 0x06011B36 RID: 72502 RVA: 0x004DC1F7 File Offset: 0x004DA3F7
	[NullableContext(2)]
	public void RefreshView(object @params)
	{
		this.RefreshTab();
	}

	// Token: 0x04008AA2 RID: 35490
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponent<PayShopRecommendSwitchItem> TabGroup;

	// Token: 0x04008AA3 RID: 35491
	[Nullable(2)]
	protected TabViewComponent<int> TabViewComponent;

	// Token: 0x04008AA4 RID: 35492
	protected int CurrentSelectTabId;

	// Token: 0x04008AA5 RID: 35493
	private double LastUpdateTime;

	// Token: 0x04008AA6 RID: 35494
	private readonly List<PayShopRecommendView.RecommendData> TabRecommendData = new List<PayShopRecommendView.RecommendData>();

	// Token: 0x020086F6 RID: 34550
	[NullableContext(0)]
	public enum EPayShopRecommendViewDefine
	{
		// Token: 0x0402DA33 RID: 186931
		GroupScroller,
		// Token: 0x0402DA34 RID: 186932
		TabItem,
		// Token: 0x0402DA35 RID: 186933
		TabPanel,
		// Token: 0x0402DA36 RID: 186934
		PanelContent
	}

	// Token: 0x020086F7 RID: 34551
	[Nullable(0)]
	private class RecommendData
	{
		// Token: 0x0402DA37 RID: 186935
		public EUiTabViewName? TabViewName;

		// Token: 0x0402DA38 RID: 186936
		[Nullable(2)]
		public object Param;

		// Token: 0x0402DA39 RID: 186937
		public string TabName = string.Empty;

		// Token: 0x0402DA3A RID: 186938
		public int Id;

		// Token: 0x0402DA3B RID: 186939
		public int Sort;

		// Token: 0x0402DA3C RID: 186940
		public string TabImage = "";

		// Token: 0x0402DA3D RID: 186941
		public bool HasBought;
	}
}
