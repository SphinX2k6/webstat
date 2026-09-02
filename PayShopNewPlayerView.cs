using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020023C5 RID: 9157
[NullableContext(1)]
[Nullable(0)]
public class PayShopNewPlayerView : DiscountShopView
{
	// Token: 0x06011AF6 RID: 72438 RVA: 0x004DB067 File Offset: 0x004D9267
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(7, typeof(UUIItem)));
	}

	// Token: 0x06011AF7 RID: 72439 RVA: 0x004DB08A File Offset: 0x004D928A
	protected override void AddEventListener()
	{
		base.AddEventListener();
		Singleton<EventSystem>.Instance.Add<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06011AF8 RID: 72440 RVA: 0x004DB0AE File Offset: 0x004D92AE
	protected override void RemoveEventListener()
	{
		base.RemoveEventListener();
		Singleton<EventSystem>.Instance.Remove<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06011AF9 RID: 72441 RVA: 0x004DB0D2 File Offset: 0x004D92D2
	protected override UUIItem GetScrollItem()
	{
		return base.GetItem(6);
	}

	// Token: 0x06011AFA RID: 72442 RVA: 0x004DB0DB File Offset: 0x004D92DB
	protected override GridProxyAbstract<IPayShopUnionData> InitItem()
	{
		return new PayShopBigItem();
	}

	// Token: 0x06011AFB RID: 72443 RVA: 0x004DB0E2 File Offset: 0x004D92E2
	private void OnPayItemSuccess(PayItemSuccess notify)
	{
		base.TryRefreshTabs();
		this.RefreshLoopScroll(this.CurrentSelectTabId);
	}

	// Token: 0x06011AFC RID: 72444 RVA: 0x004DB0F8 File Offset: 0x004D92F8
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

	// Token: 0x06011AFD RID: 72445 RVA: 0x004DB154 File Offset: 0x004D9354
	protected override void OnStart()
	{
		base.OnStart();
		this.SubViewComponent = new TabViewComponent<int>(base.GetItem(7), EKeyMode.Default);
		base.GetItem(7).SetUIActive(false);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:NewPlayer 界面Start";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", base.GetViewName());
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06011AFE RID: 72446 RVA: 0x004DB1B4 File Offset: 0x004D93B4
	protected override void RefreshLoopScroll(int tabId)
	{
		if (base.IsDestroyOrDestroying)
		{
			return;
		}
		if (tabId == 1)
		{
			base.GetLoopScrollViewComponent(1).RootUIComp.Get().SetUIActive(false);
			base.GetItem(8).SetUIActive(false);
			base.GetItem(7).SetUIActive(true);
			int selectedIndex = this.TabGroup.GetSelectedIndex();
			TabViewComponent<int> subViewComponent = this.SubViewComponent;
			if (subViewComponent != null)
			{
				subViewComponent.ToggleCallBack(selectedIndex, EUiTabViewName.NewPlayerWeekCardView, this.TabGroup.GetTabItemByIndex(selectedIndex), null, null);
			}
			Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.XXJ, "PayShopNewPlayerView Reload(WeekCardView)", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		base.GetItem(7).SetUIActive(false);
		TabViewComponent<int> subViewComponent2 = this.SubViewComponent;
		if (subViewComponent2 != null)
		{
			subViewComponent2.SetCurrentTabViewState(false);
		}
		base.RefreshLoopScroll(tabId);
		Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.XXJ, "PayShopNewPlayerView Reload", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06011AFF RID: 72447 RVA: 0x004DB2A0 File Offset: 0x004D94A0
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		PayShopNewPlayerView.<OnBeforeShowAsyncImplement>d__11 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<PayShopNewPlayerView.<OnBeforeShowAsyncImplement>d__11>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06011B00 RID: 72448 RVA: 0x004DB2E3 File Offset: 0x004D94E3
	protected override void OnBeforeShow()
	{
		base.GetItem(4).SetUIActive(true);
		this.TabGroup.SetActive(true);
	}

	// Token: 0x06011B01 RID: 72449 RVA: 0x004DB2FE File Offset: 0x004D94FE
	protected override void OnBeforeDestroy()
	{
		if (this.SubViewComponent != null)
		{
			this.SubViewComponent.DestroyTabViewComponent();
			this.SubViewComponent = null;
		}
		base.OnBeforeDestroy();
	}

	// Token: 0x04008A96 RID: 35478
	private bool OnShowRequestInfo;

	// Token: 0x04008A97 RID: 35479
	[Nullable(2)]
	private TabViewComponent<int> SubViewComponent;
}
