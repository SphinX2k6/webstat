using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

// Token: 0x020023AD RID: 9133
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PayShopController : UiControllerBase<PayShopController>
{
	// Token: 0x060119AA RID: 72106 RVA: 0x004D3E38 File Offset: 0x004D2038
	protected override void OnRegisterNetEvent()
	{
		Net instance = Singleton<Net>.Instance;
		ENotifyMessageId id = ENotifyMessageId.PayShopInfoNotify;
		Action<PayShopInfoNotify, Net.CallbackStatus> callback;
		if ((callback = PayShopController.<>O.<0>__NotifyPayShopInfo) == null)
		{
			callback = (PayShopController.<>O.<0>__NotifyPayShopInfo = new Action<PayShopInfoNotify, Net.CallbackStatus>(PayShopController.NotifyPayShopInfo));
		}
		instance.Register<PayShopInfoNotify>(id, callback);
		Net instance2 = Singleton<Net>.Instance;
		ENotifyMessageId id2 = ENotifyMessageId.PayShopUnlockNotify;
		Action<PayShopUnlockNotify, Net.CallbackStatus> callback2;
		if ((callback2 = PayShopController.<>O.<1>__NotifyPayShopUnlock) == null)
		{
			callback2 = (PayShopController.<>O.<1>__NotifyPayShopUnlock = new Action<PayShopUnlockNotify, Net.CallbackStatus>(PayShopController.NotifyPayShopUnlock));
		}
		instance2.Register<PayShopUnlockNotify>(id2, callback2);
		Net instance3 = Singleton<Net>.Instance;
		ENotifyMessageId id3 = ENotifyMessageId.PayShopDirectBuyNotify;
		Action<PayShopDirectBuyNotify, Net.CallbackStatus> callback3;
		if ((callback3 = PayShopController.<>O.<2>__NotifyPayShopDirectBuy) == null)
		{
			callback3 = (PayShopController.<>O.<2>__NotifyPayShopDirectBuy = new Action<PayShopDirectBuyNotify, Net.CallbackStatus>(PayShopController.NotifyPayShopDirectBuy));
		}
		instance3.Register<PayShopDirectBuyNotify>(id3, callback3);
		Net instance4 = Singleton<Net>.Instance;
		ENotifyMessageId id4 = ENotifyMessageId.PayShopConditionFinishNotify;
		Action<PayShopConditionFinishNotify, Net.CallbackStatus> callback4;
		if ((callback4 = PayShopController.<>O.<3>__NotifyPayShopConditionFinish) == null)
		{
			callback4 = (PayShopController.<>O.<3>__NotifyPayShopConditionFinish = new Action<PayShopConditionFinishNotify, Net.CallbackStatus>(PayShopController.NotifyPayShopConditionFinish));
		}
		instance4.Register<PayShopConditionFinishNotify>(id4, callback4);
	}

	// Token: 0x060119AB RID: 72107 RVA: 0x004D3EF4 File Offset: 0x004D20F4
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PayShopInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PayShopUnlockNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PayShopDirectBuyNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PayShopConditionFinishNotify);
	}

	// Token: 0x060119AC RID: 72108 RVA: 0x004D3F41 File Offset: 0x004D2141
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
	}

	// Token: 0x060119AD RID: 72109 RVA: 0x004D3F7B File Offset: 0x004D217B
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
	}

	// Token: 0x060119AE RID: 72110 RVA: 0x004D3FB8 File Offset: 0x004D21B8
	private static void NotifyPayShopInfo(PayShopInfoNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.YZY;
		string message2 = "PayShop:ShopItem NotifyPayShopInfo 接收到商品信息更新";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("version", message.Version);
		instance.Info(module, author, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		RepeatedField<PayShopInfo> infos = message.Infos;
		ModelBase<PayShopModel>.Instance.Version = message.Version;
		ModelBase<PayShopModel>.Instance.SetPayShopInfoList(infos.ToList<PayShopInfo>());
		ModelBase<PayShopModel>.Instance.SetPayShopTabData(message.PayShopTabConfigs.ToList<PayShopTabConfigInfo>());
		ModelBase<PayShopModel>.Instance.SetPayShopRecommendData(message.PayShopRecommends.ToList<PayShopRecommendConfigInfo>());
		ControllerBase<PayGiftController>.Instance.OnShopInfoNotify(message);
	}

	// Token: 0x060119AF RID: 72111 RVA: 0x004D4050 File Offset: 0x004D2250
	private static void NotifyPayShopUnlock(PayShopUnlockNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		RepeatedField<int> unlockList = message.UnlockList;
		ModelBase<PayShopModel>.Instance.UnLockPayShopGoods(unlockList.ToList<int>());
	}

	// Token: 0x060119B0 RID: 72112 RVA: 0x004D4074 File Offset: 0x004D2274
	private static void NotifyPayShopConditionFinish(PayShopConditionFinishNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		RepeatedField<Aki.Protocol.PayShopItem> items = message.Items;
		ModelBase<PayShopModel>.Instance.SetPayShopGoodsList(items.ToList<Aki.Protocol.PayShopItem>());
		Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.YZY, "PayShop:ShopItem NotifyPayShopConditionFinish 接收到商品信息更新", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<EventSystem>.Instance.Emit<List<Aki.Protocol.PayShopItem>>(EEventName.OnPayShopConditionFinish, items.ToList<Aki.Protocol.PayShopItem>());
	}

	// Token: 0x060119B1 RID: 72113 RVA: 0x004D40CC File Offset: 0x004D22CC
	private unsafe static void NotifyPayShopDirectBuy(PayShopDirectBuyNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.YZY;
		string message2 = "PayShop:ShopItem NotifyPayShopDirectBuy 接收到直购结构";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", message.ShopItemId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("count", message.ItemCount);
		instance.Info(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		Singleton<KuroSdkReport>.Instance.OnPayShopDirectBuy(message.ShopItemId);
		int shopItemId = message.ShopItemId;
		if (message.ShopItemId != 0)
		{
			ModelBase<PayShopModel>.Instance.UpdatePayShopGoodsCount(message.ShopItemId, message.ItemCount);
		}
		if (message.ShopItemId != 42 && message.ShopItemId != 43 && message.ShopItemId != 44)
		{
			int shopItemId2 = message.ShopItemId;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.PayShopGoodsBuy);
	}

	// Token: 0x060119B2 RID: 72114 RVA: 0x004D41AD File Offset: 0x004D23AD
	private void OnWorldDone()
	{
		if (ModelBase<FunctionModel>.Instance.IsOpen(10010))
		{
			this.SendRequestPayShopInfo(false, 0);
		}
	}

	// Token: 0x060119B3 RID: 72115 RVA: 0x004D41C9 File Offset: 0x004D23C9
	private void OnFunctionOpenUpdate(EFunctionType functionType, bool isOpen)
	{
		if (functionType != EFunctionType.Shop)
		{
			return;
		}
		if (!isOpen)
		{
			return;
		}
		this.SendRequestPayShopInfo(false, 0);
	}

	// Token: 0x060119B4 RID: 72116 RVA: 0x004D41E4 File Offset: 0x004D23E4
	[NullableContext(0)]
	public UniTask<bool> SendRequestPayShopInfo(bool needErrorCode = true, int timeoutMs = 0)
	{
		PayShopController.<SendRequestPayShopInfo>d__10 <SendRequestPayShopInfo>d__;
		<SendRequestPayShopInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SendRequestPayShopInfo>d__.needErrorCode = needErrorCode;
		<SendRequestPayShopInfo>d__.timeoutMs = timeoutMs;
		<SendRequestPayShopInfo>d__.<>1__state = -1;
		<SendRequestPayShopInfo>d__.<>t__builder.Start<PayShopController.<SendRequestPayShopInfo>d__10>(ref <SendRequestPayShopInfo>d__);
		return <SendRequestPayShopInfo>d__.<>t__builder.Task;
	}

	// Token: 0x060119B5 RID: 72117 RVA: 0x004D4230 File Offset: 0x004D2430
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<PayShopUpdateResponse> SendRequestPayShopUpdateAsync(PayShopDefine.EPayShopTabType payShopId, bool isSwitch)
	{
		PayShopController.<SendRequestPayShopUpdateAsync>d__11 <SendRequestPayShopUpdateAsync>d__;
		<SendRequestPayShopUpdateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<PayShopUpdateResponse>.Create();
		<SendRequestPayShopUpdateAsync>d__.<>4__this = this;
		<SendRequestPayShopUpdateAsync>d__.payShopId = payShopId;
		<SendRequestPayShopUpdateAsync>d__.isSwitch = isSwitch;
		<SendRequestPayShopUpdateAsync>d__.<>1__state = -1;
		<SendRequestPayShopUpdateAsync>d__.<>t__builder.Start<PayShopController.<SendRequestPayShopUpdateAsync>d__11>(ref <SendRequestPayShopUpdateAsync>d__);
		return <SendRequestPayShopUpdateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060119B6 RID: 72118 RVA: 0x004D4284 File Offset: 0x004D2484
	[NullableContext(2)]
	public unsafe void SendRequestPayShopUpdate(PayShopDefine.EPayShopTabType payShopId, bool isSwitch, Action<PayShopUpdateResponse> responseCallback = null)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:Root 请求刷新商城数据";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ShopId", payShopId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsSwitch", isSwitch);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		PayShopUpdateRequest payShopUpdateRequest = PayShopUpdateRequest.Create();
		payShopUpdateRequest.Id = (int)payShopId;
		Singleton<Net>.Instance.Call<PayShopUpdateResponse>(ERequestMessageId.PayShopUpdateRequest, payShopUpdateRequest, delegate(PayShopUpdateResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				Action<PayShopUpdateResponse> responseCallback2 = responseCallback;
				if (responseCallback2 == null)
				{
					return;
				}
				responseCallback2(null);
				return;
			}
			else if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				PayShopInfo payShopInfo = response.Info;
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Shop;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "PayShop:Root 请求刷新商城数据成功";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("ShopId", payShopId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("IsSwitch", isSwitch);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				ModelBase<PayShopModel>.Instance.SetPayShopInfo(payShopInfo);
				bool ifNeedQueryProductInfoForce = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetIfNeedQueryProductInfoForce();
				Action callback = delegate()
				{
					if (isSwitch)
					{
						Singleton<EventSystem>.Instance.Emit<PayShopDefine.EPayShopTabType>(EEventName.SwitchPayShopView, (PayShopDefine.EPayShopTabType)payShopInfo.Id);
					}
					else
					{
						Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.RefreshPayShop, payShopInfo.Id, true);
					}
					Action<PayShopUpdateResponse> responseCallback4 = responseCallback;
					if (responseCallback4 == null)
					{
						return;
					}
					responseCallback4(response);
				};
				if (!ifNeedQueryProductInfoForce)
				{
					callback();
					return;
				}
				List<string> shopQueryProductIdArray = this.GetShopQueryProductIdArray(payShopId);
				if (shopQueryProductIdArray != null && shopQueryProductIdArray.Count > 0)
				{
					ControllerBase<PayItemController>.Instance.QueryProductInfoAsync(shopQueryProductIdArray).ContinueWith(delegate(bool _)
					{
						callback();
					});
					return;
				}
				callback();
				return;
			}
			else
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24637, null, true, true);
				Action<PayShopUpdateResponse> responseCallback3 = responseCallback;
				if (responseCallback3 == null)
				{
					return;
				}
				responseCallback3(response);
				return;
			}
		}, 0);
	}

	// Token: 0x060119B7 RID: 72119 RVA: 0x004D434C File Offset: 0x004D254C
	private List<string> GetShopQueryProductIdArray(PayShopDefine.EPayShopTabType payShopId)
	{
		List<string> list = new List<string>();
		if (payShopId == PayShopDefine.EPayShopTabType.Recharge)
		{
			foreach (PayItemData payItemData in ModelBase<PayItemModel>.Instance.GetDataList())
			{
				list.Add(payItemData.ProductId);
			}
		}
		if (PayShopDefine.payGiftRoutedShopSet.Contains(payShopId))
		{
			foreach (PayPackageData payPackageData in ModelBase<PayGiftModel>.Instance.GetPayGiftDataList())
			{
				list.Add(payPackageData.ProductId);
			}
		}
		return list;
	}

	// Token: 0x060119B8 RID: 72120 RVA: 0x004D4410 File Offset: 0x004D2610
	public void OpenBuySkinDetailView(PayShopGoods good)
	{
		if (!good.IsDirect())
		{
			this.OpenBuyViewByGoodsId(good, null);
			return;
		}
		int id = good.GetGoodsData().Id;
		ControllerBase<PayGiftController>.Instance.SdkPay(id);
		OnOpenGiftPackageDetailsViewLogEvent onOpenGiftPackageDetailsViewLogEvent = new OnOpenGiftPackageDetailsViewLogEvent();
		onOpenGiftPackageDetailsViewLogEvent.i_id = id;
		onOpenGiftPackageDetailsViewLogEvent.i_shop_id = (int)good.PayShopId;
		onOpenGiftPackageDetailsViewLogEvent.i_tab_id = good.GetGoodsData().TabId;
		onOpenGiftPackageDetailsViewLogEvent.i_buy_through_third_party = ((good.IfPayGift() > false) ? 1 : 0);
		ControllerBase<LogReportController>.Instance.LogReport(onOpenGiftPackageDetailsViewLogEvent);
	}

	// Token: 0x060119B9 RID: 72121 RVA: 0x004D448C File Offset: 0x004D268C
	public void SendRequestPayShopItemUpdate(int[] goodsIdList)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "PayShop:ShopItem 请求刷新商品列表";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("goodsIdList", goodsIdList);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		PayShopItemUpdateRequest payShopItemUpdateRequest = PayShopItemUpdateRequest.Create();
		payShopItemUpdateRequest.ShopItemIds.AddRange(goodsIdList);
		Singleton<Net>.Instance.Call<PayShopItemUpdateResponse>(ERequestMessageId.PayShopItemUpdateRequest, payShopItemUpdateRequest, delegate(PayShopItemUpdateResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				RepeatedField<Aki.Protocol.PayShopItem> items = response.Items;
				ModelBase<PayShopModel>.Instance.SetPayShopGoodsList(items.ToList<Aki.Protocol.PayShopItem>());
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19714, null, true, true);
		}, 0);
	}

	// Token: 0x060119BA RID: 72122 RVA: 0x004D4504 File Offset: 0x004D2704
	public unsafe void SendRequestPayShopBuy(int goodsId, int count = 1)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:ShopItem 请求购买商品";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", goodsId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Count", count);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		PayShopGoodsData goodsData = ModelBase<PayShopModel>.Instance.GetPayShopGoods(goodsId).GetGoodsData();
		this.SendRequestPayShopNormalBuy(goodsId, count, goodsData);
	}

	// Token: 0x060119BB RID: 72123 RVA: 0x004D4588 File Offset: 0x004D2788
	protected unsafe void SendRequestPayShopNormalBuy(int goodsId, int buyCount, PayShopGoodsData payShopData)
	{
		PayShopBuyRequest payShopBuyRequest = PayShopBuyRequest.Create();
		payShopBuyRequest.Id = goodsId;
		payShopBuyRequest.Count = buyCount;
		payShopBuyRequest.Version = ModelBase<PayShopModel>.Instance.Version;
		Singleton<Net>.Instance.Call<PayShopBuyResponse>(ERequestMessageId.PayShopBuyRequest, payShopBuyRequest, delegate(PayShopBuyResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Shop;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "PayShop:ShopItem 购买商品成功";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", goodsId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Count", buyCount);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				ModelBase<PayShopModel>.Instance.UpdatePayShopGoodsCount(response.Id, response.Count);
				Singleton<EventSystem>.Instance.Emit(EEventName.PayShopGoodsBuy);
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrPayShopDataChanged)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Shop;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "PayShop:ShopItem 商品数据不同步,通知versioncode变化";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id", goodsId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Count", buyCount);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.RefreshPayShop, payShopData.ShopId, false);
				Singleton<EventSystem>.Instance.Emit(EEventName.ShopVersionCodeChange);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23114, null, true, true);
		}, 0);
	}

	// Token: 0x060119BC RID: 72124 RVA: 0x004D45FC File Offset: 0x004D27FC
	public void ActivityPayShopBuyRequest(List<ActivityBuyItem> buyItems, [Nullable(new byte[]
	{
		2,
		2,
		1
	})] Action<bool, List<ActivityBuyItem>> callback = null)
	{
		if (buyItems.Count == 0)
		{
			return;
		}
		int id = buyItems[0].Id;
		PayShopGoodsData goodsData = ModelBase<PayShopModel>.Instance.GetPayShopGoods(id).GetGoodsData();
		this.ActivityPayShopBuyRequestInternal(buyItems, goodsData, callback);
	}

	// Token: 0x060119BD RID: 72125 RVA: 0x004D463C File Offset: 0x004D283C
	private void ActivityPayShopBuyRequestInternal(List<ActivityBuyItem> buyItems, PayShopGoodsData payShopData, [Nullable(new byte[]
	{
		2,
		2,
		1
	})] Action<bool, List<ActivityBuyItem>> callback = null)
	{
		ActivityPayShopBuyRequest activityPayShopBuyRequest = Aki.Protocol.ActivityPayShopBuyRequest.Create();
		activityPayShopBuyRequest.BuyItems.AddRange(buyItems);
		activityPayShopBuyRequest.Version = ModelBase<PayShopModel>.Instance.Version;
		Singleton<Net>.Instance.Call<ActivityPayShopBuyResponse>(ERequestMessageId.ActivityPayShopBuyRequest, activityPayShopBuyRequest, delegate(ActivityPayShopBuyResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response != null)
			{
				RepeatedField<ActivityBuyItem> buyItems2 = response.BuyItems;
				bool flag = buyItems2.Count != buyItems.Count;
				if (flag)
				{
					Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.LZK, "[PayShop] 部分活动商品购买失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				else
				{
					Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.LZK, "[PayShop] 活动商品购买成功", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				foreach (ActivityBuyItem activityBuyItem in buyItems)
				{
					ModelBase<PayShopModel>.Instance.UpdateActivityPayShopGoodsCount(activityBuyItem.Id, activityBuyItem.Count);
				}
				Singleton<EventSystem>.Instance.Emit<int, IReadOnlyList<ActivityBuyItem>, string>(EEventName.ActivityPayShopGoodsBuy, payShopData.ShopId, buyItems, ModelBase<PayShopModel>.Instance.Version);
				if (flag)
				{
					List<ActivityBuyItem> list = new List<ActivityBuyItem>();
					foreach (ActivityBuyItem activityBuyItem2 in buyItems)
					{
						bool flag2 = false;
						using (IEnumerator<ActivityBuyItem> enumerator2 = buyItems2.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								if (enumerator2.Current.Id == activityBuyItem2.Id)
								{
									flag2 = true;
									break;
								}
							}
						}
						if (!flag2)
						{
							list.Add(activityBuyItem2);
						}
					}
					Action<bool, List<ActivityBuyItem>> callback2 = callback;
					if (callback2 != null)
					{
						callback2(true, list);
					}
				}
				else
				{
					Action<bool, List<ActivityBuyItem>> callback3 = callback;
					if (callback3 != null)
					{
						callback3(true, null);
					}
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28167, null, true, true);
				}
				return;
			}
			Action<bool, List<ActivityBuyItem>> callback4 = callback;
			if (callback4 == null)
			{
				return;
			}
			callback4(false, null);
		}, 0);
	}

	// Token: 0x060119BE RID: 72126 RVA: 0x004D46A8 File Offset: 0x004D28A8
	public void OpenGiftDetailsView(PayShopGoods good)
	{
		Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.XXJ, "PayShop:ShopItem 打开礼包界面", default(ReadOnlySpan<ValueTuple<string, object>>));
		ExchangePopData exchangePopData = new ExchangePopData();
		exchangePopData.PayShopGoods = good;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GiftPackageDetailsView, exchangePopData, null);
		if (PayShopDefine.payGiftRoutedShopSet.Contains(good.PayShopId) || good.PayShopId == PayShopDefine.EPayShopTabType.SkinShop)
		{
			OnOpenGiftPackageDetailsViewLogEvent onOpenGiftPackageDetailsViewLogEvent = new OnOpenGiftPackageDetailsViewLogEvent();
			onOpenGiftPackageDetailsViewLogEvent.i_id = good.GetGoodsData().Id;
			onOpenGiftPackageDetailsViewLogEvent.i_shop_id = (int)good.PayShopId;
			onOpenGiftPackageDetailsViewLogEvent.i_tab_id = good.GetGoodsData().TabId;
			onOpenGiftPackageDetailsViewLogEvent.i_buy_through_third_party = ((good.IfPayGift() > false) ? 1 : 0);
			ControllerBase<LogReportController>.Instance.LogReport(onOpenGiftPackageDetailsViewLogEvent);
		}
	}

	// Token: 0x060119BF RID: 72127 RVA: 0x004D4758 File Offset: 0x004D2958
	[NullableContext(2)]
	public void OpenExchangePopView(int goodsId, PayShopExchangeExtraData extraData = null)
	{
		Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.XXJ, "PayShop:ShopItem 打开兑换界面", default(ReadOnlySpan<ValueTuple<string, object>>));
		ExchangePopData exchangePopData = new ExchangePopData();
		PayShopGoods payShopGoods = ModelBase<PayShopModel>.Instance.GetPayShopGoods(goodsId);
		exchangePopData.PayShopGoods = payShopGoods;
		exchangePopData.ShopItemResource = "UiItem_ShopItem";
		exchangePopData.GetMaxBuyCount = ((extraData != null) ? extraData.GetMaxBuyCount : null);
		exchangePopData.CheckIfCanBuy = ((extraData != null) ? extraData.CheckIfCanBuy : null);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ExchangePopView, exchangePopData, null);
		if ((payShopGoods != null && payShopGoods.PayShopId == PayShopDefine.EPayShopTabType.ExchangeEntry) || (payShopGoods != null && payShopGoods.PayShopId == PayShopDefine.EPayShopTabType.ActivityShop))
		{
			OnClickPayShopItemLogEvent onClickPayShopItemLogEvent = new OnClickPayShopItemLogEvent();
			onClickPayShopItemLogEvent.i_id = goodsId;
			onClickPayShopItemLogEvent.i_shop_id = (int)payShopGoods.PayShopId;
			onClickPayShopItemLogEvent.i_tab_id = payShopGoods.GetGoodsData().TabId;
			ControllerBase<LogReportController>.Instance.LogReport(onClickPayShopItemLogEvent);
		}
	}

	// Token: 0x060119C0 RID: 72128 RVA: 0x004D4828 File Offset: 0x004D2A28
	public void OpenBuyViewByGoodsId(PayShopGoods good, [Nullable(2)] PayShopExchangeExtraData extraData = null)
	{
		int id = good.GetGoodsData().Id;
		good.SaveRemindState((long)Singleton<TimeUtil>.Instance.GetServerTime());
		if (good.CheckIfMonthCardItem())
		{
			this.OpenGiftDetailsView(good);
			return;
		}
		if (good.GetGoodsData().GetRewardItemType().GetValueOrDefault() == InventoryDefine.EItemType.Gift)
		{
			int? giftId = good.GetGoodsData().GetGiftId();
			if (giftId != null)
			{
				GiftPackageConfig instance = ConfigBase<GiftPackageConfig>.Instance;
				GiftPackage? giftPackage = (instance != null) ? instance.GetGiftPackageConfig(giftId.Value) : null;
				if (giftPackage != null && giftPackage.GetValueOrDefault().Type == GiftType.Fixed)
				{
					this.OpenGiftDetailsView(good);
					return;
				}
			}
			this.OpenExchangePopView(id, extraData);
			return;
		}
		this.OpenExchangePopView(id, extraData);
	}

	// Token: 0x060119C1 RID: 72129 RVA: 0x004D48EA File Offset: 0x004D2AEA
	[NullableContext(2)]
	public void OpenPayShopView(PayShopViewData data = null, TOpenViewCallBack finishCallback = null)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10010))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FunctionDisable", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PayShopRootView, data, finishCallback);
	}

	// Token: 0x060119C2 RID: 72130 RVA: 0x004D4924 File Offset: 0x004D2B24
	public void OpenPayShopViewWithTab(PayShopDefine.EPayShopTabType tab, int switchId)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10010))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FunctionDisable", Array.Empty<object>());
			return;
		}
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PayShopRootView))
		{
			this.OpenPayShopView(new PayShopViewData
			{
				PayShopId = tab,
				SwitchId = new int?(switchId)
			}, null);
			return;
		}
		Singleton<EventSystem>.Instance.Emit<PayShopDefine.EPayShopTabType, int>(EEventName.SwitchPayShopTabItem, tab, switchId);
	}

	// Token: 0x060119C3 RID: 72131 RVA: 0x004D499C File Offset: 0x004D2B9C
	public void OpenPayShopViewWithTabResolver(Func<PayShopJumpParam> tabResolver)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10010))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FunctionDisable", Array.Empty<object>());
			return;
		}
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PayShopRootView))
		{
			this.OpenPayShopView(new PayShopViewData
			{
				JumpTabResolver = tabResolver
			}, null);
			return;
		}
		PayShopJumpParam payShopJumpParam = tabResolver();
		Singleton<EventSystem>.Instance.Emit<PayShopDefine.EPayShopTabType, int>(EEventName.SwitchPayShopTabItem, payShopJumpParam.PayShopId, payShopJumpParam.SwitchId);
	}

	// Token: 0x060119C4 RID: 72132 RVA: 0x004D4A1C File Offset: 0x004D2C1C
	public void OpenPayShopViewToRecharge()
	{
		if (ControllerBase<PayItemController>.Instance.CurrentBlockBetaState && FeatureRestrictionTemplate.TemplateForPioneerClient.Check())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BetaDisableCharge);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PayShopRootView))
		{
			this.OpenPayShopView(new PayShopViewData
			{
				PayShopId = PayShopDefine.EPayShopTabType.Recharge
			}, null);
			return;
		}
		Singleton<EventSystem>.Instance.Emit<PayShopDefine.EPayShopTabType, int>(EEventName.SwitchPayShopTabItem, PayShopDefine.EPayShopTabType.Recharge, 1);
	}

	// Token: 0x060119C5 RID: 72133 RVA: 0x004D4A94 File Offset: 0x004D2C94
	public void ClosePayShopGoodDetailPopView()
	{
		foreach (EUiViewName euiViewName in new List<EUiViewName>
		{
			EUiViewName.ExchangePopView,
			EUiViewName.GiftPackageDetailsView
		})
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(euiViewName))
			{
				Singleton<UiManager>.Instance.CloseView(euiViewName, null);
			}
		}
	}

	// Token: 0x020086C7 RID: 34503
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402D952 RID: 186706
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<PayShopInfoNotify, Net.CallbackStatus> <0>__NotifyPayShopInfo;

		// Token: 0x0402D953 RID: 186707
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<PayShopUnlockNotify, Net.CallbackStatus> <1>__NotifyPayShopUnlock;

		// Token: 0x0402D954 RID: 186708
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<PayShopDirectBuyNotify, Net.CallbackStatus> <2>__NotifyPayShopDirectBuy;

		// Token: 0x0402D955 RID: 186709
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<PayShopConditionFinishNotify, Net.CallbackStatus> <3>__NotifyPayShopConditionFinish;
	}
}
