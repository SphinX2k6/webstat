using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020025FB RID: 9723
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PowerController : UiControllerBase<PowerController>
{
	// Token: 0x170017D1 RID: 6097
	// (get) Token: 0x060130E7 RID: 78055 RVA: 0x00548623 File Offset: 0x00546823
	protected override bool IsTickEvenPausedInternal
	{
		get
		{
			return true;
		}
	}

	// Token: 0x060130E8 RID: 78056 RVA: 0x00548626 File Offset: 0x00546826
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<EnergyUpdateNotify>(ENotifyMessageId.EnergyUpdateNotify, delegate(EnergyUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<PowerModel>.Instance.UpdatePowerData(notify.UpdateInfoList.ToArray<EnergyInfo>());
		});
	}

	// Token: 0x060130E9 RID: 78057 RVA: 0x00548657 File Offset: 0x00546857
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EnergyUpdateNotify);
	}

	// Token: 0x060130EA RID: 78058 RVA: 0x00548669 File Offset: 0x00546869
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BackLoginView, this.OnBackLoginView);
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
	}

	// Token: 0x060130EB RID: 78059 RVA: 0x0054869D File Offset: 0x0054689D
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BackLoginView, this.OnBackLoginView);
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
	}

	// Token: 0x060130EC RID: 78060 RVA: 0x005486D4 File Offset: 0x005468D4
	public void OpenPowerView(EPowerMenuType powerMenuType = EPowerMenuType.Supply, int requirePower = 0)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10017))
		{
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PowerView))
		{
			return;
		}
		if (ModelBase<PowerModel>.Instance.PowerCount >= ConfigBase<PowerConfig>.Instance.GetPowerChargeLimit())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PowerBound", Array.Empty<object>());
			return;
		}
		this.UpdatePowerShopData().ContinueWith(delegate()
		{
			bool flag = requirePower == 0;
			ModelBase<PowerModel>.Instance.CurrentNeedPower = (flag ? 60 : requirePower);
			int autoClosePowerCount = flag ? ConfigBase<PowerConfig>.Instance.GetPowerChargeLimit() : (requirePower + ModelBase<PowerModel>.Instance.PowerCount);
			PowerConfirmBoxData param = new PowerConfirmBoxData(ModelBase<PowerModel>.Instance.PowerCount, powerMenuType, !flag, autoClosePowerCount);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PowerView, param, null);
		});
	}

	// Token: 0x060130ED RID: 78061 RVA: 0x0054875C File Offset: 0x0054695C
	private UniTask TryExchangePowerRecoveryItem(int itemId, int num)
	{
		PowerController.<TryExchangePowerRecoveryItem>d__13 <TryExchangePowerRecoveryItem>d__;
		<TryExchangePowerRecoveryItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryExchangePowerRecoveryItem>d__.<>4__this = this;
		<TryExchangePowerRecoveryItem>d__.itemId = itemId;
		<TryExchangePowerRecoveryItem>d__.num = num;
		<TryExchangePowerRecoveryItem>d__.<>1__state = -1;
		<TryExchangePowerRecoveryItem>d__.<>t__builder.Start<PowerController.<TryExchangePowerRecoveryItem>d__13>(ref <TryExchangePowerRecoveryItem>d__);
		return <TryExchangePowerRecoveryItem>d__.<>t__builder.Task;
	}

	// Token: 0x060130EE RID: 78062 RVA: 0x005487B0 File Offset: 0x005469B0
	private UniTask UpdatePowerShopData()
	{
		PowerController.<UpdatePowerShopData>d__14 <UpdatePowerShopData>d__;
		<UpdatePowerShopData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdatePowerShopData>d__.<>1__state = -1;
		<UpdatePowerShopData>d__.<>t__builder.Start<PowerController.<UpdatePowerShopData>d__14>(ref <UpdatePowerShopData>d__);
		return <UpdatePowerShopData>d__.<>t__builder.Task;
	}

	// Token: 0x060130EF RID: 78063 RVA: 0x005487EC File Offset: 0x005469EC
	private void OnLoadingNetDataDone()
	{
		this.SendUpdatePowerRequest(ModelBase<PowerModel>.Instance.PowerItemKeyArray);
		this.CancelTimer();
		this.CheckPowerTimer = TimerSystem.Instance.Forever(new TTimerAction(this.OnPowerTimer), 500f, 1f, null, null, true);
	}

	// Token: 0x060130F0 RID: 78064 RVA: 0x00548838 File Offset: 0x00546A38
	private void CancelTimer()
	{
		if (this.CheckPowerTimer == null)
		{
			return;
		}
		TimerSystem.Instance.Remove(this.CheckPowerTimer);
		this.CheckPowerTimer = null;
	}

	// Token: 0x060130F1 RID: 78065 RVA: 0x0054885B File Offset: 0x00546A5B
	private void OnPowerTimer(float _)
	{
		ModelBase<PowerModel>.Instance.UpdatePowerRenewTimer();
	}

	// Token: 0x060130F2 RID: 78066 RVA: 0x00548867 File Offset: 0x00546A67
	public bool GetIfCanRequestNewPower()
	{
		return Singleton<TimeUtil>.Instance.GetServerTime() - this.CurrentRequestPowerTime > 1.0;
	}

	// Token: 0x060130F3 RID: 78067 RVA: 0x00548888 File Offset: 0x00546A88
	public void SendUpdatePowerRequest(int[] itemList)
	{
		EnergySyncRequest energySyncRequest = EnergySyncRequest.Create();
		energySyncRequest.Ids.AddRange(itemList);
		this.CurrentRequestPowerTime = Singleton<TimeUtil>.Instance.GetServerTime();
		Singleton<Net>.Instance.Call<EnergySyncResponse>(ERequestMessageId.EnergySyncRequest, energySyncRequest, delegate(EnergySyncResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrCode == Aki.Protocol.ErrorCode.Success)
			{
				ModelBase<PowerModel>.Instance.UpdatePowerData(response.SyncInfoList.ToArray<EnergyInfo>());
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 17149, null, true, true);
		}, 0);
	}

	// Token: 0x060130F4 RID: 78068 RVA: 0x005488E8 File Offset: 0x00546AE8
	public unsafe void OpenOverPowerExchangeView()
	{
		PowerData powerDataById = ModelBase<PowerModel>.Instance.GetPowerDataById(5);
		PowerData powerDataById2 = ModelBase<PowerModel>.Instance.GetPowerDataById(6);
		int num = ConfigBase<PowerConfig>.Instance.GetPowerChargeLimit() - powerDataById.GetCurrentPower();
		if (num == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ConfigMultiTextLang.GetLocalTextNew("PowerMaxCannotExchange", null));
			return;
		}
		if (powerDataById2.GetCurrentPower() == 0)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigItemInfoById.GetConfig(6, true).Value.Name, null);
			string text = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("PowerPropsCannotExchange", null), new string[]
			{
				localTextNew
			});
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(text);
			return;
		}
		CommonExchangeData commonExchangeData = new CommonExchangeData();
		commonExchangeData.InitBySrcAndDestItemId(6, 5, new int?(powerDataById2.GetCurrentPower()), new int?(powerDataById.GetCurrentPower()));
		commonExchangeData.ConfirmCallBack = delegate(int itemId, int exChangeTime)
		{
			ShopFixed value = ModelBase<PowerModel>.Instance.GetOverPowerShopConfig().Value;
			int moneyId = 6;
			if (value.PriceLength > 0)
			{
				moneyId = value.Price(0).Value.Key;
			}
			ControllerBase<ShopController>.Instance.SendShopBuyRequest(value.ShopId, value.Id, moneyId, exChangeTime, delegate
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PowerBuySucceed", new object[]
				{
					exChangeTime.ToString()
				});
			});
		};
		CommonExchangeViewData commonExchangeViewData = new CommonExchangeViewData();
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(commonExchangeData.GetSrcItemId(), 0);
		commonExchangeViewData.GetGainCount = ((int itemId, int exchangeCount) => exchangeCount);
		commonExchangeViewData.GetConsumeCount = ((int itemId, int exchangeCount) => exchangeCount);
		commonExchangeViewData.GetConsumeTotalCount = ((int consumeCount, int exchangeTime) => exchangeTime);
		CommonExchangeViewData commonExchangeViewData2 = commonExchangeViewData;
		int num2 = 2;
		List<int> list = new List<int>(num2);
		CollectionsMarshal.SetCount<int>(list, num2);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int num3 = 0;
		*span[num3] = 6;
		num3++;
		*span[num3] = 5;
		commonExchangeViewData2.ShowCurrencyList = list;
		if (ModelBase<PowerModel>.Instance.CurrentNeedPower > 0)
		{
			commonExchangeViewData.StartSliderValue = ((ModelBase<PowerModel>.Instance.CurrentNeedPower <= powerDataById2.GetCurrentPower()) ? ModelBase<PowerModel>.Instance.CurrentNeedPower : powerDataById2.GetCurrentPower());
		}
		int num4 = ConfigBase<PowerConfig>.Instance.GetSingleTimeExchangePowerLimit();
		if (num < ConfigBase<PowerConfig>.Instance.GetSingleTimeExchangePowerLimit())
		{
			num4 = num;
		}
		if (num4 > powerDataById2.GetCurrentPower())
		{
			num4 = powerDataById2.GetCurrentPower();
		}
		commonExchangeViewData.StartSliderValue = ((commonExchangeViewData.StartSliderValue > num4) ? num4 : commonExchangeViewData.StartSliderValue);
		commonExchangeViewData.CreateData(commonExchangeData, num4, itemCountByConfigId);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonExchangeView, commonExchangeViewData, null);
	}

	// Token: 0x060130F5 RID: 78069 RVA: 0x00548B44 File Offset: 0x00546D44
	public UniTask OpenPowerRecoveryExchangeView(EPowerRecoveryItem powerRecoveryItemId)
	{
		PowerController.<OpenPowerRecoveryExchangeView>d__21 <OpenPowerRecoveryExchangeView>d__;
		<OpenPowerRecoveryExchangeView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenPowerRecoveryExchangeView>d__.<>4__this = this;
		<OpenPowerRecoveryExchangeView>d__.powerRecoveryItemId = powerRecoveryItemId;
		<OpenPowerRecoveryExchangeView>d__.<>1__state = -1;
		<OpenPowerRecoveryExchangeView>d__.<>t__builder.Start<PowerController.<OpenPowerRecoveryExchangeView>d__21>(ref <OpenPowerRecoveryExchangeView>d__);
		return <OpenPowerRecoveryExchangeView>d__.<>t__builder.Task;
	}

	// Token: 0x060130F6 RID: 78070 RVA: 0x00548B90 File Offset: 0x00546D90
	public UniTask UseSinglePowerRecoveryItem()
	{
		PowerController.<UseSinglePowerRecoveryItem>d__22 <UseSinglePowerRecoveryItem>d__;
		<UseSinglePowerRecoveryItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UseSinglePowerRecoveryItem>d__.<>1__state = -1;
		<UseSinglePowerRecoveryItem>d__.<>t__builder.Start<PowerController.<UseSinglePowerRecoveryItem>d__22>(ref <UseSinglePowerRecoveryItem>d__);
		return <UseSinglePowerRecoveryItem>d__.<>t__builder.Task;
	}

	// Token: 0x060130F7 RID: 78071 RVA: 0x00548BCC File Offset: 0x00546DCC
	public void ExchangePower(PowerItemInfo itemInfo, int costCount, [Nullable(2)] Action callback = null)
	{
		int itemId = itemInfo.ItemId;
		if (itemId == 6)
		{
			this.OpenOverPowerExchangeView();
			return;
		}
		if (itemId != 10800)
		{
			ControllerBase<ShopController>.Instance.SendShopBuyRequest(itemInfo.ShopId, itemInfo.GoodsId, itemInfo.ItemId, costCount, callback);
			return;
		}
		this.OpenPowerRecoveryExchangeView((EPowerRecoveryItem)itemInfo.ItemId);
	}

	// Token: 0x060130F8 RID: 78072 RVA: 0x00548C21 File Offset: 0x00546E21
	public override bool Clear()
	{
		this.CancelTimer();
		return base.Clear();
	}

	// Token: 0x040094AE RID: 38062
	private const int DEFAULTEXCHANGETIME = 60;

	// Token: 0x040094AF RID: 38063
	private const int REQUESTPOWERGAP = 1;

	// Token: 0x040094B0 RID: 38064
	private const int CHECKPOWERGAP = 500;

	// Token: 0x040094B1 RID: 38065
	[Nullable(2)]
	private TimerHandle CheckPowerTimer;

	// Token: 0x040094B2 RID: 38066
	private double CurrentRequestPowerTime;

	// Token: 0x040094B3 RID: 38067
	private readonly Action OnBackLoginView = delegate()
	{
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PowerView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.PowerView, null);
		}
	};
}
