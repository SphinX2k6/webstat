using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02002047 RID: 8263
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ItemExchangeController : UiControllerBase<ItemExchangeController>
{
	// Token: 0x1700129A RID: 4762
	// (get) Token: 0x0600FBC3 RID: 64451 RVA: 0x004521FE File Offset: 0x004503FE
	public bool NeedPop
	{
		get
		{
			return this.NeedPopInternal;
		}
	}

	// Token: 0x0600FBC4 RID: 64452 RVA: 0x00452206 File Offset: 0x00450406
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.ItemExchangeInfoRequest));
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(this.ItemExchange));
	}

	// Token: 0x0600FBC5 RID: 64453 RVA: 0x00452240 File Offset: 0x00450440
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.ItemExchangeInfoRequest));
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(this.ItemExchange));
	}

	// Token: 0x0600FBC6 RID: 64454 RVA: 0x0045227C File Offset: 0x0045047C
	private void ItemExchange()
	{
		LoginDefine.ELoginStatus loginStatus = ModelBase<LoginModel>.Instance.GetLoginStatus();
		if (loginStatus < LoginDefine.ELoginStatus.EnterGameRet)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ItemExchange;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "登录状态错误, 无法请求物品兑换数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("loginStatus", loginStatus);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.ItemExchangeInfoRequest();
	}

	// Token: 0x0600FBC7 RID: 64455 RVA: 0x004522D0 File Offset: 0x004504D0
	private void ItemExchangeInfoRequest()
	{
		ItemExchangeInfoRequest message = Aki.Protocol.ItemExchangeInfoRequest.Create();
		Singleton<Net>.Instance.Call<ItemExchangeInfoResponse>(ERequestMessageId.ItemExchangeInfoRequest, message, delegate(ItemExchangeInfoResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<ItemExchangeModel>.Instance.InitItemExchangeTimeInfo(response.ItemExchangeInfos.ToList<ItemExchangeInfo>());
		}, 0);
	}

	// Token: 0x0600FBC8 RID: 64456 RVA: 0x00452313 File Offset: 0x00450513
	private void ItemExchangeRequest(int itemId, int exchangeTimes)
	{
		this.ItemExchangeRequest(itemId, exchangeTimes, true, null);
	}

	// Token: 0x0600FBC9 RID: 64457 RVA: 0x00452320 File Offset: 0x00450520
	public void ItemExchangeRequest(int itemId, int exchangeTimes, bool needPop = true, Action<int, int> callback = null)
	{
		if (exchangeTimes == 0)
		{
			return;
		}
		this.NeedPopInternal = needPop;
		ItemExchangeRequest itemExchangeRequest = Aki.Protocol.ItemExchangeRequest.Create();
		itemExchangeRequest.ItemId = itemId;
		itemExchangeRequest.ExchangeTimes = exchangeTimes;
		Singleton<Net>.Instance.Call<ItemExchangeResponse>(ERequestMessageId.ItemExchangeRequest, itemExchangeRequest, delegate(ItemExchangeResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			this.NeedPopInternal = true;
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19403, null, true, true);
				return;
			}
			ModelBase<ItemExchangeModel>.Instance.AddExchangeTime(itemId, exchangeTimes);
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.ItemExChangeResponse, response.ItemId, response.ItemCount);
			if (callback != null)
			{
				callback(response.ItemId, response.ItemCount);
			}
		}, 0);
	}

	// Token: 0x0600FBCA RID: 64458 RVA: 0x0045239C File Offset: 0x0045059C
	public void OpenExchangeViewByItemId(int itemId, Action<int, int> confirmCallBack = null, bool confirmNoClose = false)
	{
		CommonExchangeData commonExchangeData = new CommonExchangeData();
		commonExchangeData.InitByItemId(itemId);
		commonExchangeData.ConfirmNoClose = confirmNoClose;
		commonExchangeData.ConfirmCallBack = confirmCallBack;
		if (commonExchangeData.ConfirmCallBack == null)
		{
			commonExchangeData.ConfirmCallBack = new Action<int, int>(this.ItemExchangeRequest);
		}
		this.OpenExchangeViewByData(commonExchangeData);
	}

	// Token: 0x0600FBCB RID: 64459 RVA: 0x004523E8 File Offset: 0x004505E8
	[NullableContext(1)]
	public void OpenExchangeViewByData(CommonExchangeData data)
	{
		CommonExchangeViewData commonExchangeViewData = new CommonExchangeViewData();
		int maxExChangeTime = ModelBase<ItemExchangeModel>.Instance.GetMaxExChangeTime(data.GetDestItemId());
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(data.GetSrcItemId(), 0);
		commonExchangeViewData.GetGainCount = ((int itemId, int exchangeCount) => ModelBase<ItemExchangeModel>.Instance.GetCurExchangeInfo(itemId, exchangeCount).GainCount);
		commonExchangeViewData.GetConsumeCount = ((int itemId, int exchangeCount) => ModelBase<ItemExchangeModel>.Instance.GetCurExchangeInfo(itemId, exchangeCount).ConsumeCount);
		commonExchangeViewData.GetConsumeTotalCount = ((int consumeCount, int exchangeTime) => consumeCount * exchangeTime);
		commonExchangeViewData.CreateData(data, maxExChangeTime, itemCountByConfigId);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonExchangeView, commonExchangeViewData, null);
	}

	// Token: 0x040078D6 RID: 30934
	private bool NeedPopInternal = true;
}
