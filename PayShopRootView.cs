using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020023BE RID: 9150
[NullableContext(1)]
[Nullable(0)]
public class PayShopRootView : UiTickViewBase
{
	// Token: 0x06011A6D RID: 72301 RVA: 0x004D842A File Offset: 0x004D662A
	public PayShopRootView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011A6E RID: 72302 RVA: 0x004D8455 File Offset: 0x004D6655
	protected override void OnBeforeCreate()
	{
		this.PayShopViewData = (this.OpenParam as PayShopViewData);
	}

	// Token: 0x06011A6F RID: 72303 RVA: 0x004D8468 File Offset: 0x004D6668
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickService));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickShopRuleButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011A70 RID: 72304 RVA: 0x004D8660 File Offset: 0x004D6860
	protected override UniTask OnBeforeStartAsync()
	{
		PayShopRootView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PayShopRootView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011A71 RID: 72305 RVA: 0x004D86A3 File Offset: 0x004D68A3
	protected override void OnBeforeShow()
	{
		TotalTopUpPageActivityEnterPanel totalTopUpEnterItem = this.TotalTopUpEnterItem;
		if (totalTopUpEnterItem == null)
		{
			return;
		}
		totalTopUpEnterItem.PlayStartSequence();
	}

	// Token: 0x06011A72 RID: 72306 RVA: 0x004D86B8 File Offset: 0x004D68B8
	protected override void OnStart()
	{
		CommonTabComponentData<PayShopTabItem> data = new CommonTabComponentData<PayShopTabItem>(new Func<UUIItem, int?, PayShopTabItem>(this.TabItemProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
		this.TabComponent = new TabComponentWithCaptionItem<PayShopTabItem>(base.GetItem(0), data, new Action(this.BackClick), false);
		this.TabViewComponent = new TabViewComponent<PayShopDefine.EPayShopTabType>(base.GetItem(1), EKeyMode.Default);
		this.RefreshUid();
		this.PayShopId = null;
		base.GetButton(6).RootUIComp.Get().SetRaycastTarget(true);
		this.CountDownText = base.GetText(3);
		this.CountDownTextActive = base.GetItem(2).bIsUIActive;
		base.GetItem(2).SetUIActive(false);
		this.CountDownTextActive = false;
		this.TabComponent.SetTitle("");
		this.TabComponent.SetTitleIconVisible(false);
		this.BindServiceRedDot();
		this.RefreshShopRuleButtonState();
		this.RefreshTotalTopUpEnterItem();
	}

	// Token: 0x06011A73 RID: 72307 RVA: 0x004D87AF File Offset: 0x004D69AF
	private void BindServiceRedDot()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.CustomerService, base.GetItem(7), null, 0);
	}

	// Token: 0x06011A74 RID: 72308 RVA: 0x004D87C6 File Offset: 0x004D69C6
	private void UnBindServiceRedDot()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.CustomerService, base.GetItem(7), 0);
	}

	// Token: 0x06011A75 RID: 72309 RVA: 0x004D87DC File Offset: 0x004D69DC
	private void OnClickService()
	{
		Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.XXJ, "PayShop:Root 打开客服反馈", default(ReadOnlySpan<ValueTuple<string, object>>));
		ControllerBase<KuroSdkController>.Instance.OpenCustomerService(EKuroSdkOpenCustomerServerType.Pay);
	}

	// Token: 0x06011A76 RID: 72310 RVA: 0x004D8810 File Offset: 0x004D6A10
	private void OnClickShopRuleButton()
	{
		string text = "";
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		if (packageLanguage == "ko")
		{
			text = ConfigBase<CommonConfig>.Instance.GetKoShopRuleUrl();
		}
		else if (packageLanguage == "ja")
		{
			text = ConfigBase<CommonConfig>.Instance.GetJaShopRuleUrl();
		}
		if (text != "")
		{
			ControllerBase<KuroSdkController>.Instance.OpenExternalUrl(text);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:Root 打开商城规则失败，没有配置链接";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("url", text);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06011A77 RID: 72311 RVA: 0x004D88A0 File Offset: 0x004D6AA0
	private void RefreshShopRuleButtonState()
	{
		string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
		bool uiactive = packageLanguage == "ko" || packageLanguage == "ja";
		base.GetButton(9).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x06011A78 RID: 72312 RVA: 0x004D88F0 File Offset: 0x004D6AF0
	private void RefreshTotalTopUpEnterItem()
	{
		PayShopViewData payShopViewData = this.PayShopViewData;
		int? num;
		if (payShopViewData == null)
		{
			num = null;
		}
		else
		{
			List<int> showShopIdList = payShopViewData.ShowShopIdList;
			num = ((showShopIdList != null) ? new int?(showShopIdList.Count) : null);
		}
		int? num2 = num;
		bool flag = num2.GetValueOrDefault() == 0;
		TotalTopUpController instance = ControllerBase<TotalTopUpController>.Instance;
		bool flag2 = instance != null && instance.CheckCurrentTotalUpRunning();
		bool uiActive = flag && flag2;
		TotalTopUpPageActivityEnterPanel totalTopUpEnterItem = this.TotalTopUpEnterItem;
		if (totalTopUpEnterItem == null)
		{
			return;
		}
		totalTopUpEnterItem.SetUiActive(uiActive);
	}

	// Token: 0x06011A79 RID: 72313 RVA: 0x004D8961 File Offset: 0x004D6B61
	private void BackClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x06011A7A RID: 72314 RVA: 0x004D896C File Offset: 0x004D6B6C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, new Action<IEnumerable<PayShopDefine.EPayShopTabType>>(this.RefreshAllPayShop));
		Singleton<EventSystem>.Instance.Add(EEventName.SwitchPayShopTabItem, new Action<PayShopDefine.EPayShopTabType, int>(this.SwitchPayShopTabItem));
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.RefreshGoods));
		Singleton<EventSystem>.Instance.Add<PayShopDefine.EPayShopTabType>(EEventName.SwitchPayShopView, new Action<PayShopDefine.EPayShopTabType>(this.SwitchPayShop));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.RefreshPayShop));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.RefreshGoodsList));
		Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<int, HashSet<int>>>(EEventName.UnLockGoods, new Action<IReadOnlyDictionary<int, HashSet<int>>>(this.UnLockGoods));
		Singleton<EventSystem>.Instance.Add(EEventName.ShopVersionCodeChange, new Action(this.ShopVersionCodeChange));
		Singleton<EventSystem>.Instance.Add<string, IReadOnlyList<string>>(EEventName.RefreshShopAccumulateCurrency, new Action<string, IReadOnlyList<string>>(this.OnAccumulateCurrencyUpdate));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.TryRefreshRootShopMoney, new Action<IReadOnlyList<int>>(this.TryRefreshRootShopMoney));
		Singleton<EventSystem>.Instance.Add<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccessForRefresh));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOutForRefresh));
	}

	// Token: 0x06011A7B RID: 72315 RVA: 0x004D8ACC File Offset: 0x004D6CCC
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, new Action<IEnumerable<PayShopDefine.EPayShopTabType>>(this.RefreshAllPayShop));
		Singleton<EventSystem>.Instance.Remove(EEventName.SwitchPayShopTabItem, new Action<PayShopDefine.EPayShopTabType, int>(this.SwitchPayShopTabItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.RefreshGoods));
		Singleton<EventSystem>.Instance.Remove<PayShopDefine.EPayShopTabType>(EEventName.SwitchPayShopView, new Action<PayShopDefine.EPayShopTabType>(this.SwitchPayShop));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshPayShop, new Action<int, bool>(this.RefreshPayShop));
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.RefreshGoodsList));
		Singleton<EventSystem>.Instance.Remove(EEventName.UnLockGoods, new Action<IReadOnlyDictionary<int, HashSet<int>>>(this.UnLockGoods));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShopVersionCodeChange, new Action(this.ShopVersionCodeChange));
		Singleton<EventSystem>.Instance.Remove<string, IReadOnlyList<string>>(EEventName.RefreshShopAccumulateCurrency, new Action<string, IReadOnlyList<string>>(this.OnAccumulateCurrencyUpdate));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<int>>(EEventName.TryRefreshRootShopMoney, new Action<IReadOnlyList<int>>(this.TryRefreshRootShopMoney));
		Singleton<EventSystem>.Instance.Remove<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccessForRefresh));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOutForRefresh));
	}

	// Token: 0x06011A7C RID: 72316 RVA: 0x004D8C29 File Offset: 0x004D6E29
	private PayShopTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new PayShopTabItem();
	}

	// Token: 0x06011A7D RID: 72317 RVA: 0x004D8C30 File Offset: 0x004D6E30
	private void ToggleCallBack(int index)
	{
		int num = this.TabShopList[index];
		int payShopInfoDynamicTabId = ModelBase<PayShopModel>.Instance.GetPayShopInfoDynamicTabId((PayShopDefine.EPayShopTabType)num);
		EUiTabViewName euiTabViewName = (EUiTabViewName)ConfigBase<DynamicTabConfig>.Instance.GetTabViewConfById(payShopInfoDynamicTabId).ChildViewName;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:Root 点击切换界面";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", euiTabViewName);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.RefreshServiceButton(new int?(num));
		this.TargetPayShopId = new PayShopDefine.EPayShopTabType?((PayShopDefine.EPayShopTabType)num);
		ControllerBase<PayShopController>.Instance.SendRequestPayShopUpdate((PayShopDefine.EPayShopTabType)num, true, null);
	}

	// Token: 0x06011A7E RID: 72318 RVA: 0x004D8CC0 File Offset: 0x004D6EC0
	private CommonTabData GetCommonData(int index)
	{
		int payShopId = this.TabShopList[index];
		UiDynamicTab? tabInfoByPayShopIdId = ModelBase<PayShopModel>.Instance.GetTabInfoByPayShopIdId(payShopId);
		return new CommonTabData(tabInfoByPayShopIdId.Value.Icon, new CommonTabTitleData(tabInfoByPayShopIdId.Value.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x06011A7F RID: 72319 RVA: 0x004D8D14 File Offset: 0x004D6F14
	protected override void OnAfterShow()
	{
		if (this.PayShopId == null)
		{
			this.SelectDefaultPayShop();
			this.RefreshCountDownText();
			return;
		}
		this.TabViewComponent.SetCurrentTabViewState(true);
	}

	// Token: 0x06011A80 RID: 72320 RVA: 0x004D8D3C File Offset: 0x004D6F3C
	private void RefreshServiceButton(int? payShopId)
	{
		UUIItem item = base.GetItem(5);
		if (payShopId == null)
		{
			item.SetUIActive(false);
			return;
		}
		if (!ControllerBase<KuroSdkController>.Instance.NeedShowCustomerService())
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(payShopId.GetValueOrDefault() == 100);
	}

	// Token: 0x06011A81 RID: 72321 RVA: 0x004D8D88 File Offset: 0x004D6F88
	private void RefreshUid()
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), "FriendMyUid", new <>z__ReadOnlySingleElementList<object>(ModelBase<FunctionModel>.Instance.PlayerId.ToString()));
	}

	// Token: 0x06011A82 RID: 72322 RVA: 0x004D8DC2 File Offset: 0x004D6FC2
	protected override void OnAfterHide()
	{
		this.TabViewComponent.SetCurrentTabViewState(false);
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk == null)
		{
			return;
		}
		platformSdk.HidePlayStationStoreIcon();
	}

	// Token: 0x06011A83 RID: 72323 RVA: 0x004D8DE4 File Offset: 0x004D6FE4
	protected override void OnBeforeDestroy()
	{
		this.UnBindServiceRedDot();
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		if (this.TabViewComponent != null)
		{
			this.TabViewComponent.DestroyTabViewComponent();
			this.TabViewComponent = null;
		}
		this.TabShopList.Clear();
	}

	// Token: 0x06011A84 RID: 72324 RVA: 0x004D8E38 File Offset: 0x004D7038
	protected UniTask RefreshCurrency(PayShopDefine.EPayShopTabType payShopId)
	{
		PayShopRootView.<RefreshCurrency>d__38 <RefreshCurrency>d__;
		<RefreshCurrency>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCurrency>d__.<>4__this = this;
		<RefreshCurrency>d__.payShopId = payShopId;
		<RefreshCurrency>d__.<>1__state = -1;
		<RefreshCurrency>d__.<>t__builder.Start<PayShopRootView.<RefreshCurrency>d__38>(ref <RefreshCurrency>d__);
		return <RefreshCurrency>d__.<>t__builder.Task;
	}

	// Token: 0x06011A85 RID: 72325 RVA: 0x004D8E83 File Offset: 0x004D7083
	private void TryRefreshRootShopMoney(IReadOnlyList<int> money)
	{
		this.RefreshCurrencyByMoney(money);
	}

	// Token: 0x06011A86 RID: 72326 RVA: 0x004D8E90 File Offset: 0x004D7090
	private UniTask RefreshCurrencyByMoney(IReadOnlyList<int> money)
	{
		PayShopRootView.<RefreshCurrencyByMoney>d__40 <RefreshCurrencyByMoney>d__;
		<RefreshCurrencyByMoney>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCurrencyByMoney>d__.<>4__this = this;
		<RefreshCurrencyByMoney>d__.money = money;
		<RefreshCurrencyByMoney>d__.<>1__state = -1;
		<RefreshCurrencyByMoney>d__.<>t__builder.Start<PayShopRootView.<RefreshCurrencyByMoney>d__40>(ref <RefreshCurrencyByMoney>d__);
		return <RefreshCurrencyByMoney>d__.<>t__builder.Task;
	}

	// Token: 0x06011A87 RID: 72327 RVA: 0x004D8EDC File Offset: 0x004D70DC
	private void SelectDefaultPayShop()
	{
		PayShopViewData payShopViewData = this.PayShopViewData;
		PayShopJumpParam payShopJumpParam;
		if (payShopViewData == null)
		{
			payShopJumpParam = null;
		}
		else
		{
			Func<PayShopJumpParam> jumpTabResolver = payShopViewData.JumpTabResolver;
			payShopJumpParam = ((jumpTabResolver != null) ? jumpTabResolver() : null);
		}
		PayShopJumpParam payShopJumpParam2 = payShopJumpParam;
		if (payShopJumpParam2 != null && this.PayShopViewData != null)
		{
			this.PayShopViewData.PayShopId = payShopJumpParam2.PayShopId;
			this.PayShopViewData.SwitchId = new int?(payShopJumpParam2.SwitchId);
		}
		this.TabShopList = this.BuildTabShopList();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:Root 页签数据";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TabShopList", this.TabShopList);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (this.PayShopViewData != null && this.PayShopViewData.PayShopId != PayShopDefine.EPayShopTabType.Default)
		{
			int num = this.TabShopList.IndexOf((int)this.PayShopViewData.PayShopId);
			this.RefreshTabItem(this.TabShopList, (num < 0) ? 0 : num);
			return;
		}
		this.RefreshTabItem(this.TabShopList, 0);
	}

	// Token: 0x06011A88 RID: 72328 RVA: 0x004D8FC0 File Offset: 0x004D71C0
	private List<int> BuildTabShopList()
	{
		bool iosAuditFirstDownloadTip = Singleton<BaseConfigController>.Instance.GetIosAuditFirstDownloadTip();
		PayShopViewData payShopViewData = this.PayShopViewData;
		bool flag;
		if (payShopViewData == null)
		{
			flag = false;
		}
		else
		{
			List<int> showShopIdList = payShopViewData.ShowShopIdList;
			int? num = (showShopIdList != null) ? new int?(showShopIdList.Count) : null;
			int num2 = 0;
			flag = (num.GetValueOrDefault() > num2 & num != null);
		}
		List<int> list;
		if (flag)
		{
			list = new List<int>(this.PayShopViewData.ShowShopIdList);
		}
		else
		{
			list = new List<int>();
			foreach (PayShopDefine.EPayShopTabType epayShopTabType in ModelBase<PayShopModel>.Instance.GetPayShopIdList())
			{
				int payShopInfoTabViewType = ModelBase<PayShopModel>.Instance.GetPayShopInfoTabViewType(epayShopTabType);
				if (iosAuditFirstDownloadTip)
				{
					if (PayShopDefine.iosLimitModePayShopViewType.Contains((PayShopDefine.EShopTabViewType)payShopInfoTabViewType))
					{
						list.Add((int)epayShopTabType);
					}
				}
				else if (PayShopDefine.payShopViewTabType.Contains((PayShopDefine.EShopTabViewType)payShopInfoTabViewType))
				{
					list.Add((int)epayShopTabType);
				}
			}
		}
		List<int> list2 = new List<int>();
		foreach (int num3 in list)
		{
			if (ModelBase<PayShopModel>.Instance.IsPayShopVisible((PayShopDefine.EPayShopTabType)num3))
			{
				list2.Add(num3);
			}
		}
		return list2;
	}

	// Token: 0x06011A89 RID: 72329 RVA: 0x004D9110 File Offset: 0x004D7310
	private void OnPayItemSuccessForRefresh(PayItemSuccess _)
	{
		this.TryRefreshTabShopList();
	}

	// Token: 0x06011A8A RID: 72330 RVA: 0x004D9118 File Offset: 0x004D7318
	private void OnGoodsSoldOutForRefresh(int _)
	{
		this.TryRefreshTabShopList();
	}

	// Token: 0x06011A8B RID: 72331 RVA: 0x004D9120 File Offset: 0x004D7320
	private unsafe void TryRefreshTabShopList()
	{
		if (this.TabComponent == null)
		{
			return;
		}
		List<int> list = this.BuildTabShopList();
		if (this.IsSameShopList(this.TabShopList, list))
		{
			return;
		}
		PayShopDefine.EPayShopTabType? payShopId = this.PayShopId;
		int num = 0;
		if (payShopId != null)
		{
			int num2 = list.IndexOf((int)payShopId.Value);
			if (num2 >= 0)
			{
				num = num2;
			}
		}
		this.TabShopList = list;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:Root TabShopList可见性变更";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TabShopList", list);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SelectIndex", num);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.RefreshTabItem(this.TabShopList, num);
	}

	// Token: 0x06011A8C RID: 72332 RVA: 0x004D91E4 File Offset: 0x004D73E4
	private bool IsSameShopList(List<int> a, List<int> b)
	{
		if (a.Count != b.Count)
		{
			return false;
		}
		for (int i = 0; i < a.Count; i++)
		{
			if (a[i] != b[i])
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06011A8D RID: 72333 RVA: 0x004D9225 File Offset: 0x004D7425
	private void RefreshAllPayShop(IEnumerable<PayShopDefine.EPayShopTabType> idList)
	{
		this.RefreshTabItem(this.TabShopList, 0);
	}

	// Token: 0x06011A8E RID: 72334 RVA: 0x004D9234 File Offset: 0x004D7434
	private void RefreshTabItem(List<int> numberList, int selectedIndex = 0)
	{
		int length = numberList.Count;
		Action callBack = delegate()
		{
			for (int i = 0; i < length; i++)
			{
				PayShopTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(i);
				int num = this.TabShopList[i];
				UUIText nameTextComponent = tabItemByIndex.GetNameTextComponent();
				UiDynamicTab value = ModelBase<PayShopModel>.Instance.GetTabInfoByPayShopIdId(num).Value;
				tabItemByIndex.RefreshContentItem((PayShopDefine.EPayShopTabType)num);
				tabItemByIndex.BindRedDot(ERedDotName.PayShopInstance, new int?(num));
				Singleton<LguiUtil>.Instance.SetLocalTextNew(nameTextComponent, value.TabName, Array.Empty<object>());
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Shop;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "PayShop:Root 选择页签";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Index", selectedIndex);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			TabComponentWithCaptionItem<PayShopTabItem> tabComponent = this.TabComponent;
			if (tabComponent == null)
			{
				return;
			}
			tabComponent.SelectToggleByIndex(selectedIndex, false);
		};
		this.TabComponent.RefreshTabItemByLength(length, callBack);
	}

	// Token: 0x06011A8F RID: 72335 RVA: 0x004D9280 File Offset: 0x004D7480
	public void SwitchPayShopTabItem(PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		int index = this.TabShopList.IndexOf((int)payShopId);
		if (this.PayShopViewData != null)
		{
			this.PayShopViewData.SwitchId = new int?(tabId);
		}
		else
		{
			this.PayShopViewData = new PayShopViewData();
			this.PayShopViewData.PayShopId = payShopId;
			this.PayShopViewData.SwitchId = new int?(tabId);
		}
		this.TabComponent.SelectToggleByIndex(index, true);
	}

	// Token: 0x06011A90 RID: 72336 RVA: 0x004D92EC File Offset: 0x004D74EC
	private void RefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		PayShopDefine.EPayShopTabType? payShopId = this.PayShopId;
		if (shopId == payShopId.GetValueOrDefault() & payShopId != null)
		{
			((IUiTabViewRefresh)this.TabViewComponent.GetCurrentTabView()).RefreshView(tabId);
		}
	}

	// Token: 0x06011A91 RID: 72337 RVA: 0x004D9330 File Offset: 0x004D7530
	private unsafe void SwitchPayShop(PayShopDefine.EPayShopTabType payShopId)
	{
		PayShopDefine.EPayShopTabType? targetPayShopId = this.TargetPayShopId;
		if (!(targetPayShopId.GetValueOrDefault() == payShopId & targetPayShopId != null))
		{
			return;
		}
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk != null)
		{
			platformSdk.HidePlayStationStoreIcon();
		}
		int payShopInfoDynamicTabId = ModelBase<PayShopModel>.Instance.GetPayShopInfoDynamicTabId(payShopId);
		EUiTabViewName euiTabViewName = (EUiTabViewName)ConfigBase<DynamicTabConfig>.Instance.GetTabViewConfById(payShopInfoDynamicTabId).ChildViewName;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:Root 切换界面";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ViewName", euiTabViewName);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "Switch";
		PayShopViewData payShopViewData = this.PayShopViewData;
		ptr = new ValueTuple<string, object>(item, (payShopViewData != null) ? payShopViewData.SwitchId : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		TabComponentWithCaptionItem<PayShopTabItem> tabComponent = this.TabComponent;
		if (tabComponent != null)
		{
			tabComponent.SetTitleIconVisible(true);
		}
		this.PayShopId = new PayShopDefine.EPayShopTabType?(payShopId);
		this.RefreshCurrency(payShopId);
		int index = this.TabShopList.IndexOf((int)payShopId);
		PayShopTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		if (payShopId == PayShopDefine.EPayShopTabType.Recommend)
		{
			TabViewComponent<PayShopDefine.EPayShopTabType> tabViewComponent = this.TabViewComponent;
			EUiTabViewName viewName = euiTabViewName;
			CommonTabItemBase tabItem = tabItemByIndex;
			PayShopViewData payShopViewData2 = this.PayShopViewData;
			tabViewComponent.ToggleCallBack(payShopId, viewName, tabItem, (payShopViewData2 != null) ? payShopViewData2.RecommendId : null, null);
		}
		else
		{
			TabViewComponent<PayShopDefine.EPayShopTabType> tabViewComponent2 = this.TabViewComponent;
			EUiTabViewName viewName2 = euiTabViewName;
			CommonTabItemBase tabItem2 = tabItemByIndex;
			PayShopViewData payShopViewData3 = this.PayShopViewData;
			tabViewComponent2.ToggleCallBack(payShopId, viewName2, tabItem2, (payShopViewData3 != null) ? payShopViewData3.SwitchId : null, null);
		}
		TabComponentWithCaptionItem<PayShopTabItem> tabComponent2 = this.TabComponent;
		if (tabComponent2 != null)
		{
			tabComponent2.LateScrollToToggleByIndex(index);
		}
		this.UpdateGoodsList();
		this.UpdateInterval = new double?(0.0);
		if (this.PayShopViewData != null)
		{
			this.PayShopViewData.SwitchId = null;
			this.PayShopViewData.RecommendId = null;
		}
		if (payShopId == PayShopDefine.EPayShopTabType.Recharge)
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.PayShopRechargeRedDot, true);
			Singleton<EventSystem>.Instance.Emit<PayShopDefine.EPayShopTabType>(EEventName.RefreshPayShopInstanceRedDot, payShopId);
		}
	}

	// Token: 0x06011A92 RID: 72338 RVA: 0x004D9540 File Offset: 0x004D7740
	private void RefreshPayShop(int payShopId, bool ifItemRefresh)
	{
		if (ifItemRefresh)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PayShopRefresh);
			Action value = delegate()
			{
				this.UpdatePayShopView();
				this.CloseExchangePopView();
			};
			confirmBoxDataNew.FunctionMap.Add(1, value);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.XXJ, "PayShop:Root 商品数据不同步,打开弹窗", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x06011A93 RID: 72339 RVA: 0x004D95A0 File Offset: 0x004D77A0
	private void UpdatePayShopView()
	{
		((IUiTabViewRefresh)this.TabViewComponent.GetCurrentTabView()).RefreshView(null);
		this.UpdateGoodsList();
		CommonDefine.ICountDown payShopCountDownData = ModelBase<PayShopModel>.Instance.GetPayShopCountDownData(this.PayShopId.Value);
		if (payShopCountDownData != null && payShopCountDownData.RemainingTime > Singleton<TimeUtil>.Instance.TimeDeviation)
		{
			this.UpdateInterval = new double?(payShopCountDownData.RemainingTime * 1000.0);
		}
		this.SendRequestState = false;
		this.TryRefreshTabShopList();
	}

	// Token: 0x06011A94 RID: 72340 RVA: 0x004D961C File Offset: 0x004D781C
	private void RefreshGoodsList(IReadOnlySet<int> tabSet)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PayShopRefresh);
		Action value = delegate()
		{
			((IUiTabViewRefresh)this.TabViewComponent.GetCurrentTabView()).RefreshView(tabSet);
			this.UpdateGoodsList();
			this.CloseExchangePopView();
		};
		confirmBoxDataNew.FunctionMap.Add(1, value);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06011A95 RID: 72341 RVA: 0x004D966C File Offset: 0x004D786C
	private void ShopVersionCodeChange()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PayShopRefresh);
		Action value = delegate()
		{
			base.CloseMe(null);
			this.CloseExchangePopView();
		};
		confirmBoxDataNew.FunctionMap.Add(1, value);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.XXJ, "PayShop:Root 商品VersionCode不同步,打开弹窗", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06011A96 RID: 72342 RVA: 0x004D96C6 File Offset: 0x004D78C6
	private void OnAccumulateCurrencyUpdate(string textId, IReadOnlyList<string> args)
	{
		PayShopAccumulateItem accumulateItem = this.AccumulateItem;
		if (accumulateItem != null)
		{
			accumulateItem.SetUiActive(true);
		}
		PayShopAccumulateItem accumulateItem2 = this.AccumulateItem;
		if (accumulateItem2 == null)
		{
			return;
		}
		accumulateItem2.RefreshTextById(textId, args);
	}

	// Token: 0x06011A97 RID: 72343 RVA: 0x004D96EC File Offset: 0x004D78EC
	private void CloseExchangePopView()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.GiftPackageDetailsView, null);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ExchangePopView, null);
	}

	// Token: 0x06011A98 RID: 72344 RVA: 0x004D9710 File Offset: 0x004D7910
	private void UnLockGoods(IReadOnlyDictionary<int, HashSet<int>> payShopSet)
	{
		HashSet<int> @params;
		if (payShopSet.TryGetValue((int)this.PayShopId.Value, out @params))
		{
			((IUiTabViewRefresh)this.TabViewComponent.GetCurrentTabView()).RefreshView(@params);
		}
	}

	// Token: 0x06011A99 RID: 72345 RVA: 0x004D9748 File Offset: 0x004D7948
	protected void UpdateTime(float delta)
	{
		if (this.UpdateInterval == null)
		{
			return;
		}
		double? updateInterval = this.UpdateInterval;
		double num = 0.0;
		if (updateInterval.GetValueOrDefault() > num & updateInterval != null)
		{
			this.UpdateInterval -= (double)delta;
			return;
		}
		this.RefreshCountDownText();
		CommonDefine.ICountDown payShopCountDownData = ModelBase<PayShopModel>.Instance.GetPayShopCountDownData(this.PayShopId.Value);
		if (payShopCountDownData != null)
		{
			this.UpdateInterval = new double?(payShopCountDownData.RemainingTime * 1000.0);
		}
	}

	// Token: 0x06011A9A RID: 72346 RVA: 0x004D97F8 File Offset: 0x004D79F8
	protected void RefreshCountDownText()
	{
		if (this.PayShopId == null)
		{
			this.CountDownTextActive = false;
			base.GetItem(2).SetUIActive(false);
			this.UpdateInterval = null;
			return;
		}
		CommonDefine.ICountDown payShopCountDownData = ModelBase<PayShopModel>.Instance.GetPayShopCountDownData(this.PayShopId.Value);
		if (payShopCountDownData == null)
		{
			this.CountDownTextActive = false;
			base.GetItem(2).SetUIActive(false);
			this.UpdateInterval = null;
			return;
		}
		if (payShopCountDownData.CountDownText == null)
		{
			this.CountDownTextActive = false;
			base.GetItem(2).SetUIActive(false);
			if (this.UpdateInterval != null)
			{
				double? updateInterval = this.UpdateInterval;
				double num = 0.0;
				if ((updateInterval.GetValueOrDefault() <= num & updateInterval != null) && !this.SendRequestState)
				{
					ControllerBase<PayShopController>.Instance.SendRequestPayShopUpdate(this.PayShopId.Value, false, null);
					this.SendRequestState = true;
				}
			}
			this.UpdateInterval = null;
			return;
		}
		if (!this.CountDownTextActive)
		{
			base.GetItem(2).SetUIActive(true);
			this.CountDownTextActive = true;
		}
		string endTimeShowText = PayShopGoods.GetEndTimeShowText(ModelBase<PayShopModel>.Instance.GetPayShopUpdateTime(this.PayShopId.Value));
		Singleton<LguiUtil>.Instance.SetLocalText(this.CountDownText, "RefreshTime", new <>z__ReadOnlySingleElementList<object>(endTimeShowText));
	}

	// Token: 0x06011A9B RID: 72347 RVA: 0x004D9943 File Offset: 0x004D7B43
	protected void UpdateGoodsList()
	{
		this.GoodsList = ModelBase<PayShopModel>.Instance.GetNeedCheckGoods(this.PayShopId.Value);
		this.AllowTick = true;
	}

	// Token: 0x06011A9C RID: 72348 RVA: 0x004D9968 File Offset: 0x004D7B68
	protected void TickGoodList()
	{
		if (!this.AllowTick)
		{
			return;
		}
		if (this.GoodsList == null || this.GoodsList.Count <= 0)
		{
			this.AllowTick = false;
			return;
		}
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		foreach (PayShopGoods payShopGoods in this.GoodsList)
		{
			if (payShopGoods.NeedUpdate())
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
		string message = "请求刷新商品";
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

	// Token: 0x06011A9D RID: 72349 RVA: 0x004D9A84 File Offset: 0x004D7C84
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		this.TickGoodList();
		this.UpdateTime(delta);
		TotalTopUpPageActivityEnterPanel totalTopUpEnterItem = this.TotalTopUpEnterItem;
		if (totalTopUpEnterItem == null)
		{
			return;
		}
		totalTopUpEnterItem.OnTick();
	}

	// Token: 0x04008A62 RID: 35426
	protected PayShopDefine.EPayShopTabType? PayShopId = new PayShopDefine.EPayShopTabType?(PayShopDefine.EPayShopTabType.Recommend);

	// Token: 0x04008A63 RID: 35427
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponentWithCaptionItem<PayShopTabItem> TabComponent;

	// Token: 0x04008A64 RID: 35428
	[Nullable(2)]
	protected TabViewComponent<PayShopDefine.EPayShopTabType> TabViewComponent;

	// Token: 0x04008A65 RID: 35429
	protected List<int> TabShopList = new List<int>();

	// Token: 0x04008A66 RID: 35430
	protected bool CountDownTextActive;

	// Token: 0x04008A67 RID: 35431
	[Nullable(2)]
	protected UUIText CountDownText;

	// Token: 0x04008A68 RID: 35432
	protected double? UpdateInterval;

	// Token: 0x04008A69 RID: 35433
	protected List<PayShopGoods> GoodsList = new List<PayShopGoods>();

	// Token: 0x04008A6A RID: 35434
	protected bool AllowTick;

	// Token: 0x04008A6B RID: 35435
	private bool SendRequestState;

	// Token: 0x04008A6C RID: 35436
	[Nullable(2)]
	protected PayShopViewData PayShopViewData;

	// Token: 0x04008A6D RID: 35437
	private PayShopDefine.EPayShopTabType? TargetPayShopId;

	// Token: 0x04008A6E RID: 35438
	[Nullable(2)]
	private PayShopAccumulateItem AccumulateItem;

	// Token: 0x04008A6F RID: 35439
	[Nullable(2)]
	private TotalTopUpPageActivityEnterPanel TotalTopUpEnterItem;

	// Token: 0x020086DF RID: 34527
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402D9C6 RID: 186822
		CaptionItem,
		// Token: 0x0402D9C7 RID: 186823
		Content,
		// Token: 0x0402D9C8 RID: 186824
		TimeItem,
		// Token: 0x0402D9C9 RID: 186825
		TimeText,
		// Token: 0x0402D9CA RID: 186826
		UidText,
		// Token: 0x0402D9CB RID: 186827
		ServiceItem,
		// Token: 0x0402D9CC RID: 186828
		ServiceButton,
		// Token: 0x0402D9CD RID: 186829
		ServiceRedDot,
		// Token: 0x0402D9CE RID: 186830
		ExchangeShopTip,
		// Token: 0x0402D9CF RID: 186831
		ShopRuleButton,
		// Token: 0x0402D9D0 RID: 186832
		AccumulateCurrencyItem
	}
}
