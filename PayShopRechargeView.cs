using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020023C6 RID: 9158
[NullableContext(1)]
[Nullable(0)]
public class PayShopRechargeView : UiTabViewBase, IUiTabViewRefresh
{
	// Token: 0x06011B04 RID: 72452 RVA: 0x004DB338 File Offset: 0x004D9538
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

	// Token: 0x06011B05 RID: 72453 RVA: 0x004DB418 File Offset: 0x004D9618
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOut));
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add<ESdkDialogResult>(EEventName.SdkPayEnd, new Action<ESdkDialogResult>(this.OnSdkPayEnd));
		Singleton<EventSystem>.Instance.Add<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06011B06 RID: 72454 RVA: 0x004DB494 File Offset: 0x004D9694
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOut));
		Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove<ESdkDialogResult>(EEventName.SdkPayEnd, new Action<ESdkDialogResult>(this.OnSdkPayEnd));
		Singleton<EventSystem>.Instance.Remove<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06011B07 RID: 72455 RVA: 0x004DB50E File Offset: 0x004D970E
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		if (this.CurrentShopId == (int)shopId && this.CurrentSelectTabId == tabId)
		{
			this.TryRefreshTabs();
			this.LoopScrollView.RefreshAllGridProxies();
		}
	}

	// Token: 0x06011B08 RID: 72456 RVA: 0x004DB533 File Offset: 0x004D9733
	private void OnGoodsSoldOut(int goodsId)
	{
		this.RefreshLoopScroll(this.CurrentSelectTabId);
	}

	// Token: 0x06011B09 RID: 72457 RVA: 0x004DB544 File Offset: 0x004D9744
	protected override void OnStart()
	{
		this.TabGroup = new TabComponent<PayShopSwitchItem>(base.GetHorizontalLayout(2).GetRootComponent(), new Func<UUIItem, int?, PayShopSwitchItem>(this.TabItemProxyCreate), new Action<int>(this.ToggleCallBack), base.GetItem(3));
		UUIItem scrollItem = this.GetScrollItem();
		this.LoopScrollView = new LoopScrollView<PayShopBigItem, IPayShopUnionData>(base.GetLoopScrollViewComponent(1), scrollItem.GetOwner() as AUIBaseActor, new Func<PayShopBigItem>(this.InitItem), false);
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

	// Token: 0x06011B0A RID: 72458 RVA: 0x004DB60B File Offset: 0x004D980B
	protected UUIItem GetScrollItem()
	{
		return base.GetItem(6);
	}

	// Token: 0x06011B0B RID: 72459 RVA: 0x004DB614 File Offset: 0x004D9814
	protected PayShopBigItem InitItem()
	{
		PayShopBigItem payShopBigItem = new PayShopBigItem();
		payShopBigItem.SetOnClickRechargeCallback(delegate(PayItemData data)
		{
			OnClickRechargeItemLogEvent onClickRechargeItemLogEvent = new OnClickRechargeItemLogEvent();
			onClickRechargeItemLogEvent.i_id = data.PayItemId;
			onClickRechargeItemLogEvent.i_shop_id = 100;
			ControllerBase<LogReportController>.Instance.LogReport(onClickRechargeItemLogEvent);
		});
		return payShopBigItem;
	}

	// Token: 0x06011B0C RID: 72460 RVA: 0x004DB640 File Offset: 0x004D9840
	protected IPayShopUnionData GetProxyData(int gridIndex)
	{
		return this.PayShopGoodsList[gridIndex];
	}

	// Token: 0x06011B0D RID: 72461 RVA: 0x004DB64E File Offset: 0x004D984E
	private PayShopSwitchItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new PayShopSwitchItem();
	}

	// Token: 0x06011B0E RID: 72462 RVA: 0x004DB658 File Offset: 0x004D9858
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
		OnClickPayShopTabLogEvent onClickPayShopTabLogEvent = new OnClickPayShopTabLogEvent();
		onClickPayShopTabLogEvent.i_shop_id = this.CurrentShopId;
		onClickPayShopTabLogEvent.i_tab_id = this.CurrentSelectTabId;
		ControllerBase<LogReportController>.Instance.LogReport(onClickPayShopTabLogEvent);
	}

	// Token: 0x06011B0F RID: 72463 RVA: 0x004DB6E8 File Offset: 0x004D98E8
	protected void RefreshLoopScroll(int tabId)
	{
		List<PayItemData> dataList = ModelBase<PayItemModel>.Instance.GetDataList();
		List<PayItemData> list = new List<PayItemData>();
		int count = dataList.Count;
		for (int i = 0; i < count; i++)
		{
			PayItemData payItemData = dataList[i];
			if (payItemData.GetIfCanShow())
			{
				list.Add(payItemData);
			}
		}
		list.Sort((PayItemData payItem1, PayItemData payItem2) => payItem1.ItemCount - payItem2.ItemCount);
		this.PayShopGoodsList.Clear();
		int count2 = list.Count;
		for (int j = 0; j < count2; j++)
		{
			this.PayShopGoodsList.Add(list[j]);
		}
		this.CheckSdkProductInfoConfirmIfCanShow(list);
		this.LoopScrollView.ReloadProxyData(new Func<int, IPayShopUnionData>(this.GetProxyData), this.PayShopGoodsList.Count, false, false);
		base.GetLoopScrollViewComponent(1).RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x06011B10 RID: 72464 RVA: 0x004DB7DC File Offset: 0x004D99DC
	private bool CheckSdkProductInfoConfirmIfCanShow(List<PayItemData> currentShowData)
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (!((platformSdk != null) ? new bool?(platformSdk.NeedConfirmSdkProductInfo()) : null).GetValueOrDefault())
		{
			return true;
		}
		if (currentShowData.Count > 0)
		{
			return true;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CannotFindSdkProduct);
		Action value = delegate()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.PayShopRootView, null);
		};
		confirmBoxDataNew.FunctionMap.Add(1, value);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		this.OpenThirdPartyMessageBox().Forget();
		return false;
	}

	// Token: 0x06011B11 RID: 72465 RVA: 0x004DB87C File Offset: 0x004D9A7C
	private UniTask OpenThirdPartyMessageBox()
	{
		PayShopRechargeView.<OpenThirdPartyMessageBox>d__24 <OpenThirdPartyMessageBox>d__;
		<OpenThirdPartyMessageBox>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenThirdPartyMessageBox>d__.<>1__state = -1;
		<OpenThirdPartyMessageBox>d__.<>t__builder.Start<PayShopRechargeView.<OpenThirdPartyMessageBox>d__24>(ref <OpenThirdPartyMessageBox>d__);
		return <OpenThirdPartyMessageBox>d__.<>t__builder.Task;
	}

	// Token: 0x06011B12 RID: 72466 RVA: 0x004DB8B8 File Offset: 0x004D9AB8
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		PayShopRechargeView.<OnBeforeShowAsyncImplement>d__25 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<PayShopRechargeView.<OnBeforeShowAsyncImplement>d__25>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06011B13 RID: 72467 RVA: 0x004DB8FC File Offset: 0x004D9AFC
	protected override void OnBeforeShow()
	{
		base.GetItem(4).SetUIActive(false);
		this.TabGroup.SetActive(false);
		OnClickPayShopTabLogEvent onClickPayShopTabLogEvent = new OnClickPayShopTabLogEvent();
		onClickPayShopTabLogEvent.i_shop_id = this.CurrentShopId;
		ControllerBase<LogReportController>.Instance.LogReport(onClickPayShopTabLogEvent);
	}

	// Token: 0x06011B14 RID: 72468 RVA: 0x004DB93F File Offset: 0x004D9B3F
	protected override void OnShowUiTabViewFromToggle()
	{
		this.TabShowState = true;
		this.AfterShowUiTabViewFromToggle();
	}

	// Token: 0x06011B15 RID: 72469 RVA: 0x004DB94E File Offset: 0x004D9B4E
	protected void AfterShowUiTabViewFromToggle()
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk == null)
		{
			return;
		}
		platformSdk.ShowPlayStationStoreIcon(0);
	}

	// Token: 0x06011B16 RID: 72470 RVA: 0x004DB965 File Offset: 0x004D9B65
	protected override void OnHideUiTabViewBase(bool fromToggle)
	{
		this.RemoveTimer();
		this.TabShowState = false;
		this.AfterHideTabViewBase(fromToggle);
	}

	// Token: 0x06011B17 RID: 72471 RVA: 0x004DB97B File Offset: 0x004D9B7B
	protected void AfterHideTabViewBase(bool fromToggle)
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk == null)
		{
			return;
		}
		platformSdk.HidePlayStationStoreIcon();
	}

	// Token: 0x06011B18 RID: 72472 RVA: 0x004DB994 File Offset: 0x004D9B94
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

	// Token: 0x06011B19 RID: 72473 RVA: 0x004DBA2D File Offset: 0x004D9C2D
	protected virtual void OnDiscountShopAfterShow()
	{
		base.GetText(5).SetUIActive(true);
	}

	// Token: 0x06011B1A RID: 72474 RVA: 0x004DBA3C File Offset: 0x004D9C3C
	private void AddTimer()
	{
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.OnRefreshTimer();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x06011B1B RID: 72475 RVA: 0x004DBA67 File Offset: 0x004D9C67
	private void RemoveTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06011B1C RID: 72476 RVA: 0x004DBA89 File Offset: 0x004D9C89
	private void OnRefreshTimer()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.DiscountShopTimerRefresh);
	}

	// Token: 0x06011B1D RID: 72477 RVA: 0x004DBA9C File Offset: 0x004D9C9C
	protected void TryRefreshTabs()
	{
		List<int> payShopTabIdList = ModelBase<PayShopModel>.Instance.GetPayShopTabIdList((PayShopDefine.EPayShopTabType)this.CurrentShopId, true);
		if (this.CurTabNum == payShopTabIdList.Count)
		{
			return;
		}
		int num = payShopTabIdList.FindIndex((int tabId) => tabId == this.CurrentSelectTabId);
		this.UpdateTabs((num == -1) ? 0 : num);
	}

	// Token: 0x06011B1E RID: 72478 RVA: 0x004DBAEC File Offset: 0x004D9CEC
	protected unsafe void UpdateTabs(int selectIndex)
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
		};
		this.TabGroup.RefreshTabItemByLength(count, callBack);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Shop;
		ELogAuthor author2 = ELogAuthor.XXJ;
		string message2 = "PayShop:TabView 选择页签";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", base.GetViewName());
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06011B1F RID: 72479 RVA: 0x004DBBE5 File Offset: 0x004D9DE5
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

	// Token: 0x06011B20 RID: 72480 RVA: 0x004DBC02 File Offset: 0x004D9E02
	private void OnPayItemSuccess(PayItemSuccess notify)
	{
	}

	// Token: 0x06011B21 RID: 72481 RVA: 0x004DBC04 File Offset: 0x004D9E04
	private void OnRefreshPayItemList()
	{
		if (!this.OnShowRequestInfo)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RefreshChargeView);
			Action value = delegate()
			{
				this.RefreshLoopScroll(this.CurrentSelectTabId);
			};
			confirmBoxDataNew.FunctionMap.Add(1, value);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
		else
		{
			this.RefreshLoopScroll(this.CurrentSelectTabId);
		}
		this.OnShowRequestInfo = false;
	}

	// Token: 0x06011B22 RID: 72482 RVA: 0x004DBC5F File Offset: 0x004D9E5F
	private void OnSdkPayEnd(ESdkDialogResult _)
	{
		this.CheckIfNeedShowPlayStationStoreIcon();
	}

	// Token: 0x06011B23 RID: 72483 RVA: 0x004DBC68 File Offset: 0x004D9E68
	private void CheckIfNeedShowPlayStationStoreIcon()
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

	// Token: 0x04008A98 RID: 35480
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponent<PayShopSwitchItem> TabGroup;

	// Token: 0x04008A99 RID: 35481
	protected List<IPayShopUnionData> PayShopGoodsList = new List<IPayShopUnionData>();

	// Token: 0x04008A9A RID: 35482
	protected int CurrentSelectTabId;

	// Token: 0x04008A9B RID: 35483
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<PayShopBigItem, IPayShopUnionData> LoopScrollView;

	// Token: 0x04008A9C RID: 35484
	protected int CurrentShopId;

	// Token: 0x04008A9D RID: 35485
	protected int CurTabNum;

	// Token: 0x04008A9E RID: 35486
	private bool OnShowRequestInfo;

	// Token: 0x04008A9F RID: 35487
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04008AA0 RID: 35488
	private bool TabShowState;

	// Token: 0x04008AA1 RID: 35489
	private const int TIMEGAP = 1000;

	// Token: 0x020086F0 RID: 34544
	[NullableContext(0)]
	private enum EDiscountShopComponent
	{
		// Token: 0x0402DA18 RID: 186904
		ScrollerItem,
		// Token: 0x0402DA19 RID: 186905
		Scroller,
		// Token: 0x0402DA1A RID: 186906
		HoriGroupScroller,
		// Token: 0x0402DA1B RID: 186907
		TabItem,
		// Token: 0x0402DA1C RID: 186908
		TabPanel,
		// Token: 0x0402DA1D RID: 186909
		TitleTips,
		// Token: 0x0402DA1E RID: 186910
		ScrollerItemNew,
		// Token: 0x0402DA1F RID: 186911
		PanelItem,
		// Token: 0x0402DA20 RID: 186912
		EmptyItem,
		// Token: 0x0402DA21 RID: 186913
		EmptyText
	}
}
