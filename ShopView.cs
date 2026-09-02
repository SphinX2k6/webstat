using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029FD RID: 10749
[NullableContext(2)]
[Nullable(0)]
public class ShopView : UiTickViewBase, IUiCameraBehavior
{
	// Token: 0x17001BF7 RID: 7159
	// (get) Token: 0x06015708 RID: 87816 RVA: 0x005F07F2 File Offset: 0x005EE9F2
	public Shop ShopInfo
	{
		get
		{
			return ModelBase<ShopModel>.Instance.GetShopInfo(this.ShopId);
		}
	}

	// Token: 0x17001BF8 RID: 7160
	// (get) Token: 0x06015709 RID: 87817 RVA: 0x005F0804 File Offset: 0x005EEA04
	private uint? RefreshTime
	{
		get
		{
			Shop shopInfo = this.ShopInfo;
			if (shopInfo == null)
			{
				return null;
			}
			return new uint?(shopInfo.UpdateTime);
		}
	}

	// Token: 0x17001BF9 RID: 7161
	// (get) Token: 0x0601570A RID: 87818 RVA: 0x005F082F File Offset: 0x005EEA2F
	// (set) Token: 0x0601570B RID: 87819 RVA: 0x005F0837 File Offset: 0x005EEA37
	public int? SecondsToRefresh
	{
		get
		{
			return this.SecondsToRefreshInner;
		}
		set
		{
			if (value != null && value.Value <= 0 && this.SecondsToRefreshInner != null && this.SecondsToRefreshInner.Value > 0)
			{
				this.ShowRefreshBox();
			}
			this.SecondsToRefreshInner = value;
		}
	}

	// Token: 0x0601570C RID: 87820 RVA: 0x005F0874 File Offset: 0x005EEA74
	[NullableContext(1)]
	public ShopView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601570D RID: 87821 RVA: 0x005F0888 File Offset: 0x005EEA88
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		IShopOpenParam shopOpenParam = this.OpenParam as IShopOpenParam;
		string handleName = "";
		if (shopOpenParam != null && shopOpenParam.UiCameraName != null && shopOpenParam.UiCameraName != "")
		{
			handleName = shopOpenParam.UiCameraName;
		}
		else if (shopOpenParam != null)
		{
			handleName = ConfigBase<ShopConfig>.Instance.GetShopInfoConfig(shopOpenParam.ShopId).UiCamera;
		}
		this.ViewHandleData = Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(handleName, true, true, "1001", false, null, null);
	}

	// Token: 0x0601570E RID: 87822 RVA: 0x005F090C File Offset: 0x005EEB0C
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		Singleton<UiCameraAnimationManager>.Instance.PopCameraHandle(this.ViewHandleData, null);
	}

	// Token: 0x0601570F RID: 87823 RVA: 0x005F0920 File Offset: 0x005EEB20
	protected override void OnBeforeCreate()
	{
		IShopOpenParam shopOpenParam = this.OpenParam as IShopOpenParam;
		if (shopOpenParam != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ShopView");
			defaultInterpolatedStringHandler.AppendFormatted<int>(10000 + shopOpenParam.ShopId);
			string commonPopBgKey = defaultInterpolatedStringHandler.ToStringAndClear();
			this.ViewInfo.CommonPopBgKey = commonPopBgKey;
		}
	}

	// Token: 0x06015710 RID: 87824 RVA: 0x005F0978 File Offset: 0x005EEB78
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x06015711 RID: 87825 RVA: 0x005F0A2C File Offset: 0x005EEC2C
	[NullableContext(1)]
	private void OnExtendToggleStateChanged(MediumItemGridExtendCallback callbackParameter)
	{
		ShopItemFullInfo shopItemFullInfo = callbackParameter.Data as ShopItemFullInfo;
		if (this.ShopItemInfoList == null || shopItemFullInfo == null)
		{
			return;
		}
		int num = this.ShopItemInfoList.IndexOf(shopItemFullInfo);
		this.ShopItemScrollView.DeselectCurrentGridProxy(false);
		if (num < 0)
		{
			return;
		}
		this.ShopItemScrollView.SelectGridProxy(num, false);
	}

	// Token: 0x06015712 RID: 87826 RVA: 0x005F0A7C File Offset: 0x005EEC7C
	protected override UniTask OnBeforeStartAsync()
	{
		ShopView.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShopView.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015713 RID: 87827 RVA: 0x005F0AC0 File Offset: 0x005EECC0
	protected override void OnStart()
	{
		IShopOpenParam shopOpenParam = this.OpenParam as IShopOpenParam;
		if (shopOpenParam != null)
		{
			this.ShopId = shopOpenParam.ShopId;
		}
		this.ShopItemScrollView = new LoopScrollView<ShopMediumItemGrid, ShopItemFullInfo>(base.GetLoopScrollViewComponent(4), base.GetItem(6).GetOwner() as AUIBaseActor, delegate()
		{
			ShopMediumItemGrid shopMediumItemGrid = new ShopMediumItemGrid();
			shopMediumItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnExtendToggleStateChanged));
			return shopMediumItemGrid;
		}, false);
		IUiPopFrameInterface childPopView = this.ChildPopView;
		if (childPopView != null)
		{
			childPopView.PopItem.SetMaskResponsibleState(false);
		}
		this.UpdateCurrency();
		this.SetShopName();
		this.RefreshShopItemList(true, false);
		this.RefreshTimeOnTick();
		UUIItem item = base.GetItem(1);
		bool uiactive;
		if (this.RefreshTime != null)
		{
			uint? refreshTime = this.RefreshTime;
			uint num = 0U;
			uiactive = (refreshTime.GetValueOrDefault() > num & refreshTime != null);
		}
		else
		{
			uiactive = false;
		}
		item.SetUIActive(uiactive);
		ModelBase<ShopModel>.Instance.CurrentInteractCreatureDataLongId = ModelBase<InteractionModel>.Instance.InteractCreatureDataLongId;
	}

	// Token: 0x06015714 RID: 87828 RVA: 0x005F0B98 File Offset: 0x005EED98
	private void ShowNpcName(ShopInfo shopInfo)
	{
		string newText = "";
		Entity entity = Singleton<EntitySystem>.Instance.Get(ModelBase<ShopModel>.Instance.InteractTarget);
		if (entity != null)
		{
			PawnInfoManageComponent component = entity.GetComponent<PawnInfoManageComponent>();
			newText = (((component != null) ? component.PawnName : null) ?? "");
		}
		base.GetText(2).SetText(newText, true);
	}

	// Token: 0x06015715 RID: 87829 RVA: 0x005F0BF0 File Offset: 0x005EEDF0
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OpenItemInfo, new Action(this.OpenItemInfoEvent));
		Singleton<EventSystem>.Instance.Add(EEventName.CloseItemInfo, new Action(this.CloseItemInfoEvent));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BoughtItem, new Action<int, int>(this.OnBuyItem));
		Singleton<EventSystem>.Instance.Add<int?>(EEventName.ShopUpdate, new Action<int?>(this.OnShopUpdate));
	}

	// Token: 0x06015716 RID: 87830 RVA: 0x005F0C70 File Offset: 0x005EEE70
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenItemInfo, new Action(this.OpenItemInfoEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseItemInfo, new Action(this.CloseItemInfoEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.BoughtItem, new Action<int, int>(this.OnBuyItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.ShopUpdate, new Action<int?>(this.OnShopUpdate));
	}

	// Token: 0x06015717 RID: 87831 RVA: 0x005F0CF0 File Offset: 0x005EEEF0
	private void OnSequenceFinish()
	{
		ShopPanelData shopPanelData = new ShopPanelData();
		ShopItemFullInfo openItemInfo = ModelBase<ShopModel>.Instance.OpenItemInfo;
		shopPanelData.ItemId = openItemInfo.ItemId;
		shopPanelData.ParamData = openItemInfo.Id;
		shopPanelData.CurrencyId = openItemInfo.GetMoneyId();
		shopPanelData.SingleBuyCount = openItemInfo.StackSize;
		shopPanelData.SingleBuyPrice = openItemInfo.DefaultPrice.CoinPrice;
		shopPanelData.BoughtCount = openItemInfo.BoughtCount;
		shopPanelData.BuyLimit = openItemInfo.BuyLimit;
		shopPanelData.IsLock = openItemInfo.IsLocked;
		shopPanelData.LockText = openItemInfo.LockInfo;
		shopPanelData.InSellTime = openItemInfo.InSellTime();
		shopPanelData.BuySuccessFunction = new TBuySuccess(this.RequestServer);
		this.ShopItemInfoPanelInternal.UpdatePanel(shopPanelData);
	}

	// Token: 0x06015718 RID: 87832 RVA: 0x005F0DAE File Offset: 0x005EEFAE
	[NullableContext(1)]
	private void RequestServer(int itemId, int buyCount, int currencyId, object param)
	{
		ControllerBase<ShopController>.Instance.SendShopBuyRequest(this.ShopId, (int)param, currencyId, buyCount, delegate
		{
			ShopPanelData shopPanelData = new ShopPanelData();
			ModelBase<ShopModel>.Instance.OpenItemInfo = ModelBase<ShopModel>.Instance.GetShopItemFullInfoByShopIdAndItemId(this.ShopId, ModelBase<ShopModel>.Instance.OpenItemInfo.Id);
			ShopItemFullInfo openItemInfo = ModelBase<ShopModel>.Instance.OpenItemInfo;
			shopPanelData.ItemId = openItemInfo.ItemId;
			shopPanelData.ParamData = openItemInfo.Id;
			shopPanelData.CurrencyId = openItemInfo.GetMoneyId();
			shopPanelData.SingleBuyCount = openItemInfo.StackSize;
			shopPanelData.SingleBuyPrice = openItemInfo.DefaultPrice.CoinPrice;
			shopPanelData.BoughtCount = openItemInfo.BoughtCount;
			shopPanelData.BuyLimit = openItemInfo.BuyLimit;
			shopPanelData.IsLock = openItemInfo.IsLocked;
			shopPanelData.LockText = openItemInfo.LockInfo;
			shopPanelData.InSellTime = openItemInfo.InSellTime();
			shopPanelData.BuySuccessFunction = new TBuySuccess(this.RequestServer);
			this.ShopItemInfoPanelInternal.UpdatePanel(shopPanelData);
		});
	}

	// Token: 0x06015719 RID: 87833 RVA: 0x005F0DD5 File Offset: 0x005EEFD5
	protected override void OnTick(float delta)
	{
		this.RefreshTimeOnTick();
	}

	// Token: 0x0601571A RID: 87834 RVA: 0x005F0DE0 File Offset: 0x005EEFE0
	private void RefreshTimeOnTick()
	{
		if (this.RefreshTime != null)
		{
			uint? refreshTime = this.RefreshTime;
			uint num = 0U;
			if (!(refreshTime.GetValueOrDefault() == num & refreshTime != null))
			{
				string text = this.FormatCountdown();
				if (text != null)
				{
					Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "RefreshTime", new <>z__ReadOnlySingleElementList<object>(text));
				}
				return;
			}
		}
		base.GetItem(1).SetUIActive(false);
	}

	// Token: 0x0601571B RID: 87835 RVA: 0x005F0E50 File Offset: 0x005EF050
	protected override void OnBeforeDestroy()
	{
		List<ShopItemFullInfo> shopItemInfoList = this.ShopItemInfoList;
		if (shopItemInfoList != null)
		{
			shopItemInfoList.Clear();
		}
		if (this.ShopItemScrollView != null)
		{
			this.ShopItemScrollView.ClearGridProxies();
		}
		if (this.ShopItemInfoPanelInternal != null)
		{
			this.ShopItemInfoPanelInternal.Destroy(null);
		}
		foreach (CommonCurrencyItem commonCurrencyItem in this.CurrencyItemList)
		{
			commonCurrencyItem.Destroy(null);
		}
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor != null)
		{
			rootActor.OnSequencePlayEvent.Unbind();
		}
	}

	// Token: 0x0601571C RID: 87836 RVA: 0x005F0EF0 File Offset: 0x005EF0F0
	private void OnBuyItem(int shopId, int id)
	{
		this.RefreshShopItemList(false, false);
		this.UpdateCurrency();
	}

	// Token: 0x0601571D RID: 87837 RVA: 0x005F0F00 File Offset: 0x005EF100
	private void OnShopUpdate(int? shopId)
	{
		int shopId2 = this.ShopId;
		int? num = shopId;
		if (shopId2 == num.GetValueOrDefault() & num != null)
		{
			this.RefreshShopItemList(false, true);
		}
	}

	// Token: 0x0601571E RID: 87838 RVA: 0x005F0F30 File Offset: 0x005EF130
	private void OpenItemInfoEvent()
	{
		base.PlaySequence("Sle", new Action(this.OnSequenceFinish), false);
		ModelBase<ShopModel>.Instance.OpenItemInfo = ModelBase<ShopModel>.Instance.GetShopItemFullInfoByShopIdAndItemId(this.ShopId, ModelBase<ShopModel>.Instance.OpenItemInfo.Id);
		ShopPanelData shopPanelData = new ShopPanelData();
		ShopItemFullInfo openItemInfo = ModelBase<ShopModel>.Instance.OpenItemInfo;
		shopPanelData.ItemId = openItemInfo.ItemId;
		shopPanelData.ParamData = openItemInfo.Id;
		shopPanelData.CurrencyId = openItemInfo.GetMoneyId();
		shopPanelData.SingleBuyCount = openItemInfo.StackSize;
		shopPanelData.SingleBuyPrice = openItemInfo.DefaultPrice.CoinPrice;
		shopPanelData.BoughtCount = openItemInfo.BoughtCount;
		shopPanelData.BuyLimit = openItemInfo.BuyLimit;
		shopPanelData.IsLock = openItemInfo.IsLocked;
		shopPanelData.LockText = openItemInfo.LockInfo;
		shopPanelData.InSellTime = openItemInfo.InSellTime();
		shopPanelData.BuySuccessFunction = new TBuySuccess(this.RequestServer);
		this.ShopItemInfoPanelInternal.UpdatePanel(shopPanelData);
	}

	// Token: 0x0601571F RID: 87839 RVA: 0x005F1030 File Offset: 0x005EF230
	private void CloseItemInfoEvent()
	{
		if (this.UiViewSequence != null)
		{
			this.UiViewSequence.PlaySequence("UnSle", false, null);
		}
	}

	// Token: 0x06015720 RID: 87840 RVA: 0x005F105F File Offset: 0x005EF25F
	protected void SetShopName()
	{
	}

	// Token: 0x06015721 RID: 87841 RVA: 0x005F1064 File Offset: 0x005EF264
	protected void UpdateCurrency()
	{
		ShopInfo? shopConfig = ModelBase<ShopModel>.Instance.GetShopConfig(this.ShopId);
		if (shopConfig != null)
		{
			this.ShowNpcName(shopConfig.Value);
		}
	}

	// Token: 0x06015722 RID: 87842 RVA: 0x005F1098 File Offset: 0x005EF298
	protected void RefreshShopItemList(bool isFirstRefresh = false, bool refreshItemInfo = false)
	{
		ShopView.<>c__DisplayClass37_0 CS$<>8__locals1 = new ShopView.<>c__DisplayClass37_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.isFirstRefresh = isFirstRefresh;
		CS$<>8__locals1.refreshItemInfo = refreshItemInfo;
		UiAsyncTask task = new UiAsyncTask("ShopView.RefreshShopItemList", delegate()
		{
			ShopView.<>c__DisplayClass37_0.<<RefreshShopItemList>b__0>d <<RefreshShopItemList>b__0>d;
			<<RefreshShopItemList>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshShopItemList>b__0>d.<>4__this = CS$<>8__locals1;
			<<RefreshShopItemList>b__0>d.<>1__state = -1;
			<<RefreshShopItemList>b__0>d.<>t__builder.Start<ShopView.<>c__DisplayClass37_0.<<RefreshShopItemList>b__0>d>(ref <<RefreshShopItemList>b__0>d);
			return <<RefreshShopItemList>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x06015723 RID: 87843 RVA: 0x005F10E0 File Offset: 0x005EF2E0
	protected string FormatCountdown()
	{
		uint? refreshTime = this.RefreshTime;
		if (refreshTime == null)
		{
			return null;
		}
		int num = (int)Math.Truncate(refreshTime.Value - Singleton<TimeUtil>.Instance.GetServerTime());
		this.SecondsToRefresh = new int?(num);
		if (num <= 0)
		{
			ControllerBase<ShopController>.Instance.SendShopUpdateRequest(this.ShopId);
			return null;
		}
		return ShopUtils.FormatTime(num);
	}

	// Token: 0x06015724 RID: 87844 RVA: 0x005F1144 File Offset: 0x005EF344
	private void ShowRefreshBox()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ShowTimeDownTips);
		Action value = delegate()
		{
			ControllerBase<ShopController>.Instance.SendShopUpdateRequest(this.ShopId);
		};
		confirmBoxDataNew.FunctionMap[1] = value;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0400A4FB RID: 42235
	private int ShopId;

	// Token: 0x0400A4FC RID: 42236
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<ShopMediumItemGrid, ShopItemFullInfo> ShopItemScrollView;

	// Token: 0x0400A4FD RID: 42237
	private ShopItemInfoDetailPanel ShopItemInfoPanelInternal;

	// Token: 0x0400A4FE RID: 42238
	[Nullable(1)]
	private readonly List<CommonCurrencyItem> CurrencyItemList = new List<CommonCurrencyItem>();

	// Token: 0x0400A4FF RID: 42239
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ShopItemFullInfo> ShopItemInfoList;

	// Token: 0x0400A500 RID: 42240
	private int? SecondsToRefreshInner;

	// Token: 0x0400A501 RID: 42241
	private UiCameraHandleData ViewHandleData;

	// Token: 0x02008D78 RID: 36216
	[NullableContext(0)]
	private enum EShopViewDefine
	{
		// Token: 0x0402F904 RID: 194820
		RefreshTimeText,
		// Token: 0x0402F905 RID: 194821
		RefreshTimeItem,
		// Token: 0x0402F906 RID: 194822
		NpcName,
		// Token: 0x0402F907 RID: 194823
		DialogueText,
		// Token: 0x0402F908 RID: 194824
		ScrollView,
		// Token: 0x0402F909 RID: 194825
		InfoPanel,
		// Token: 0x0402F90A RID: 194826
		GridItem
	}
}
