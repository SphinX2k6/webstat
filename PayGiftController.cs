using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020023A9 RID: 9129
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PayGiftController : UiControllerBase<PayGiftController>
{
	// Token: 0x06011984 RID: 72068 RVA: 0x004D33B1 File Offset: 0x004D15B1
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<PayGiftSuccessNotify>(ENotifyMessageId.PayGiftSuccessNotify, new Action<PayGiftSuccessNotify, Net.CallbackStatus>(this.PayGiftSuccessNotify));
	}

	// Token: 0x06011985 RID: 72069 RVA: 0x004D33CF File Offset: 0x004D15CF
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PayGiftSuccessNotify);
	}

	// Token: 0x06011986 RID: 72070 RVA: 0x004D33E1 File Offset: 0x004D15E1
	public void OnShopInfoNotify(PayShopInfoNotify message)
	{
		ModelBase<PayGiftModel>.Instance.Version = message.PayGiftShopInfo.Version;
		ModelBase<PayGiftModel>.Instance.InitDataByServer(message.PayGiftShopInfo.Gifts.ToList<PayGiftInfo>(), false);
	}

	// Token: 0x06011987 RID: 72071 RVA: 0x004D3413 File Offset: 0x004D1613
	[NullableContext(2)]
	public void OnShopInfoReceive(PayGiftShopInfo message)
	{
		if (message != null)
		{
			ModelBase<PayGiftModel>.Instance.Version = message.Version;
			ModelBase<PayGiftModel>.Instance.InitDataByServer(message.Gifts.ToList<PayGiftInfo>(), false);
		}
	}

	// Token: 0x06011988 RID: 72072 RVA: 0x004D3440 File Offset: 0x004D1640
	private void PayGiftSuccessNotify(PayGiftSuccessNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ControllerBase<KuroSdkController>.Instance.CancelCurrentWaitPayItemTimer(true);
		PayItemSuccess p = new PayItemSuccess
		{
			PayItemId = notify.Id,
			OrderId = notify.ReceiptId,
			ItemId = notify.ItemId,
			ItemCount = notify.ItemCount
		};
		ModelBase<PayGiftModel>.Instance.GetPayGiftDataById(notify.PayGiftInfo.Id).Phrase(notify.PayGiftInfo);
		Singleton<KuroSdkReport>.Instance.OnPayShopDirectBuy(notify.Id);
		Singleton<EventSystem>.Instance.Emit<PayItemSuccess>(EEventName.OnPayItemSuccess, p);
	}

	// Token: 0x06011989 RID: 72073 RVA: 0x004D34D0 File Offset: 0x004D16D0
	public UniTask QueryPayGiftInfoAsync()
	{
		PayGiftController.<QueryPayGiftInfoAsync>d__5 <QueryPayGiftInfoAsync>d__;
		<QueryPayGiftInfoAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<QueryPayGiftInfoAsync>d__.<>1__state = -1;
		<QueryPayGiftInfoAsync>d__.<>t__builder.Start<PayGiftController.<QueryPayGiftInfoAsync>d__5>(ref <QueryPayGiftInfoAsync>d__);
		return <QueryPayGiftInfoAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601198A RID: 72074 RVA: 0x004D350C File Offset: 0x004D170C
	[NullableContext(0)]
	public UniTask<bool> SendPayGiftInfoRequestAsync()
	{
		PayGiftController.<SendPayGiftInfoRequestAsync>d__6 <SendPayGiftInfoRequestAsync>d__;
		<SendPayGiftInfoRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SendPayGiftInfoRequestAsync>d__.<>1__state = -1;
		<SendPayGiftInfoRequestAsync>d__.<>t__builder.Start<PayGiftController.<SendPayGiftInfoRequestAsync>d__6>(ref <SendPayGiftInfoRequestAsync>d__);
		return <SendPayGiftInfoRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601198B RID: 72075 RVA: 0x004D3548 File Offset: 0x004D1748
	public void SendPayGiftInfoRequest(bool needRefreshEvent = false)
	{
		PayGiftInfoRequest payGiftInfoRequest = PayGiftInfoRequest.Create();
		payGiftInfoRequest.Version = ModelBase<PayGiftModel>.Instance.Version;
		Singleton<Net>.Instance.Call<PayGiftInfoResponse>(ERequestMessageId.PayGiftInfoRequest, payGiftInfoRequest, delegate(PayGiftInfoResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response != null)
			{
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27137, null, true, true);
				}
				if (response.Version == "" || response.Infos == null)
				{
					return;
				}
				ModelBase<PayGiftModel>.Instance.Version = response.Version;
				ModelBase<PayGiftModel>.Instance.InitDataByServer(response.Infos.ToList<PayGiftInfo>(), needRefreshEvent);
				List<PayPackageData> dataList = ModelBase<PayGiftModel>.Instance.GetDataList();
				List<string> list = new List<string>();
				foreach (PayPackageData payPackageData in dataList)
				{
					list.Add(payPackageData.ProductId);
				}
				ControllerBase<PayItemController>.Instance.QueryProductInfoAsync(list);
			}
		}, 0);
	}

	// Token: 0x0601198C RID: 72076 RVA: 0x004D3598 File Offset: 0x004D1798
	private void SendPayGiftRequest(int payGiftId)
	{
		PayPackageData payGiftDataById = ModelBase<PayGiftModel>.Instance.GetPayGiftDataById(payGiftId);
		if (payGiftDataById != null && payGiftDataById.NeedConsoleRulePrompt && Singleton<Info>.Instance.IsHomeConsolePlatform())
		{
			ModelBase<PayShopModel>.Instance.ConsoleExtraPerformancePayGiftId = payGiftId;
		}
		else
		{
			ModelBase<PayShopModel>.Instance.ConsoleExtraPerformancePayGiftId = 0;
		}
		PayGiftRequest payGiftRequest = PayGiftRequest.Create();
		payGiftRequest.Id = payGiftId;
		payGiftRequest.Version = ModelBase<PayGiftModel>.Instance.Version;
		Singleton<Net>.Instance.Call<PayGiftResponse>(ERequestMessageId.PayGiftRequest, payGiftRequest, delegate(PayGiftResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			PayShopGoods payShopGoodsById = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(payGiftId);
			if (response.ErrorCode == ErrorCode.Success)
			{
				string itemName = ConfigBase<ItemConfig>.Instance.GetItemName(payShopGoodsById.GetGoodsData().ItemId);
				string itemDesc = ConfigBase<ItemConfig>.Instance.GetItemDesc(payShopGoodsById.GetGoodsData().ItemId);
				SdkPayGetServerBillEvent sdkPayGetServerBillEvent = new SdkPayGetServerBillEvent();
				sdkPayGetServerBillEvent.s_sdk_pay_order = response.ReceiptId;
				ControllerBase<LogReportController>.Instance.LogReport(sdkPayGetServerBillEvent);
				ControllerBase<KuroSdkController>.Instance.SdkPay(payShopGoodsById.GetGetPayGiftData().PayId, response.ReceiptId, itemName, itemDesc, response.CallbackUrl);
				return;
			}
			if (response.ErrorCode == ErrorCode.ErrPayShopDataChanged)
			{
				this.SendPayGiftInfoRequest(false);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19809, null, true, true);
		}, 0);
	}

	// Token: 0x0601198D RID: 72077 RVA: 0x004D3640 File Offset: 0x004D1840
	public void SdkPay(int payGiftId)
	{
		if (ControllerBase<PayItemController>.Instance.CurrentBlockBetaState && ConfigBase<CommonConfig>.Instance.GetBetaBlockRecharge().GetValueOrDefault())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BetaDisableCharge);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		if (FeatureRestrictionTemplate.TemplateForPioneerClient.Check() && payGiftId == 42)
		{
			ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.BetaDisableCharge);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
			return;
		}
		if (ControllerBase<PayItemController>.Instance.CurrentBlockIosPayState && Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
		{
			ConfirmBoxDataNew confirmBoxDataNew3 = new ConfirmBoxDataNew(EConfirmBoxConfigId.IosCloseRecharge);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew3);
		}
		if (!Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			this.SendPayGiftRequest(payGiftId);
			return;
		}
		PayShopGoods payShopGoodsById = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(payGiftId);
		string text;
		if (payShopGoodsById == null)
		{
			text = null;
		}
		else
		{
			PayPackageData getPayGiftData = payShopGoodsById.GetGetPayGiftData();
			text = ((getPayGiftData != null) ? getPayGiftData.ProductId : null);
		}
		string text2 = text;
		if (text2 == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Pay, ELogAuthor.TL, "PayGiftController SdkPay failed, productId is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (((platformSdk != null) ? new bool?(platformSdk.NeedShowSdkProductInfoBeforePay()) : null).GetValueOrDefault())
		{
			DisplayProductInfo productInfoByGoodsId = ModelBase<PayItemModel>.Instance.GetProductInfoByGoodsId(text2);
			Action<string> onClickConfirmBtn = delegate(string id)
			{
				ControllerBase<PayItemController>.Instance.SdkPayNew(id);
			};
			SdkPayProductInformationViewData param = SdkPayProductInformationViewData.Create(productInfoByGoodsId.Name, productInfoByGoodsId.Desc, text2, onClickConfirmBtn);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SdkPayProductInformationView, param, null);
			return;
		}
		ControllerBase<PayItemController>.Instance.SdkPayNew(text2);
	}
}
