using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020023C2 RID: 9154
[NullableContext(1)]
[Nullable(0)]
public class PayPackageShopView : DiscountShopView
{
	// Token: 0x06011ADA RID: 72410 RVA: 0x004DAA3D File Offset: 0x004D8C3D
	protected override void AddEventListener()
	{
		base.AddEventListener();
		Singleton<EventSystem>.Instance.Add<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06011ADB RID: 72411 RVA: 0x004DAA61 File Offset: 0x004D8C61
	protected override void RemoveEventListener()
	{
		base.RemoveEventListener();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06011ADC RID: 72412 RVA: 0x004DAA85 File Offset: 0x004D8C85
	protected override UUIItem GetScrollItem()
	{
		return base.GetItem(6);
	}

	// Token: 0x06011ADD RID: 72413 RVA: 0x004DAA8E File Offset: 0x004D8C8E
	protected override GridProxyAbstract<IPayShopUnionData> InitItem()
	{
		return new PayShopBigItem();
	}

	// Token: 0x06011ADE RID: 72414 RVA: 0x004DAA95 File Offset: 0x004D8C95
	private void OnPayItemSuccess(PayItemSuccess notify)
	{
		base.TryRefreshTabs();
		this.RefreshLoopScroll(this.CurrentSelectTabId);
	}

	// Token: 0x06011ADF RID: 72415 RVA: 0x004DAAAC File Offset: 0x004D8CAC
	private void OnRefreshPayGiftList()
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

	// Token: 0x06011AE0 RID: 72416 RVA: 0x004DAB08 File Offset: 0x004D8D08
	protected override void RefreshLoopScroll(int tabId)
	{
		if (base.IsDestroyOrDestroying)
		{
			return;
		}
		this.PayShopGoodsList = ModelBase<PayShopModel>.Instance.GetPayShopTabData(PayShopDefine.EPayShopTabType.GiftBag, tabId, true).Cast<IPayShopUnionData>().ToList<IPayShopUnionData>();
		this.LoopScrollView.ReloadProxyData(new Func<int, IPayShopUnionData>(base.GetProxyData), this.PayShopGoodsList.Count, false, false);
		base.GetLoopScrollViewComponent(1).RootUIComp.Get().SetUIActive(this.PayShopGoodsList.Count > 0);
		base.GetItem(8).SetUIActive(this.PayShopGoodsList.Count <= 0);
		base.CheckIfNeedShowPlayStationStoreIcon();
		Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.XXJ, "PayPackageShopView Reload", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06011AE1 RID: 72417 RVA: 0x004DABC8 File Offset: 0x004D8DC8
	protected unsafe override void UpdateTabs(int selectIndex, bool bScrollTo = false)
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
	}

	// Token: 0x06011AE2 RID: 72418 RVA: 0x004DACC8 File Offset: 0x004D8EC8
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		PayPackageShopView.<OnBeforeShowAsyncImplement>d__9 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<PayPackageShopView.<OnBeforeShowAsyncImplement>d__9>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06011AE3 RID: 72419 RVA: 0x004DAD0B File Offset: 0x004D8F0B
	protected override void OnBeforeShow()
	{
		base.GetItem(4).SetUIActive(true);
		this.TabGroup.SetActive(true);
	}

	// Token: 0x04008A8E RID: 35470
	private bool OnShowRequestInfo;
}
