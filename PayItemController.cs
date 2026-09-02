using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002370 RID: 9072
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PayItemController : UiControllerBase<PayItemController>
{
	// Token: 0x060115B0 RID: 71088 RVA: 0x004C7D94 File Offset: 0x004C5F94
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<PayItemSuccessNotify>(ENotifyMessageId.PayItemSuccessNotify, delegate(PayItemSuccessNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify != null)
			{
				PayItemSuccess p = new PayItemSuccess
				{
					PayItemId = notify.Id,
					OrderId = notify.ReceiptId,
					ItemId = notify.ItemId,
					ItemCount = notify.ItemCount
				};
				Singleton<EventSystem>.Instance.Emit<PayItemSuccess>(EEventName.OnPayItemSuccess, p);
			}
			this.CutWaitPayResponseTimer();
			ModelBase<PayItemModel>.Instance.CleanPayingItemName();
		});
		Singleton<Net>.Instance.Register<ResetSpecialBonusNotify>(ENotifyMessageId.ResetSpecialBonusNotify, new Action<ResetSpecialBonusNotify, Net.CallbackStatus>(this.ResetSpecialBonusNotify));
	}

	// Token: 0x060115B1 RID: 71089 RVA: 0x004C7DCE File Offset: 0x004C5FCE
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ResetSpecialBonusNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PayItemSuccessNotify);
	}

	// Token: 0x060115B2 RID: 71090 RVA: 0x004C7DF0 File Offset: 0x004C5FF0
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnGetPlayerBasicInfo, new Action(this.OnLoginSuccess));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
	}

	// Token: 0x060115B3 RID: 71091 RVA: 0x004C7E54 File Offset: 0x004C6054
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGetPlayerBasicInfo, new Action(this.OnLoginSuccess));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
	}

	// Token: 0x060115B4 RID: 71092 RVA: 0x004C7EB5 File Offset: 0x004C60B5
	private void OnLoginSuccess()
	{
		this.RequestSdkCheckout(ECheckoutReason.Login);
	}

	// Token: 0x060115B5 RID: 71093 RVA: 0x004C7EBE File Offset: 0x004C60BE
	protected override bool OnClear()
	{
		this.CutWaitPayResponseTimer();
		return true;
	}

	// Token: 0x060115B6 RID: 71094 RVA: 0x004C7EC7 File Offset: 0x004C60C7
	[NullableContext(2)]
	private void ResetSpecialBonusNotify(ResetSpecialBonusNotify message, Net.CallbackStatus status)
	{
		ModelBase<PayItemModel>.Instance.ResetSpecialBonus(message.Ids.ToArray<int>());
	}

	// Token: 0x060115B7 RID: 71095 RVA: 0x004C7EE0 File Offset: 0x004C60E0
	private void SendBuyPayItemRequest(int payItemId)
	{
		PayItemRequest payItemRequest = PayItemRequest.Create();
		payItemRequest.Id = payItemId;
		payItemRequest.Version = ModelBase<PayItemModel>.Instance.Version;
		ModelBase<PayItemModel>.Instance.UpdatePayingItemName(payItemId);
		Singleton<Net>.Instance.Call<PayItemResponse>(ERequestMessageId.PayItemRequest, payItemRequest, delegate(PayItemResponse response, Net.CallbackStatus status)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20637, null, true, true);
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Shop;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "PayShop:ShopItem 充值请求成功,调用SDK接口";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", payItemId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ISDKPayment paymentInfo = ModelBase<PayItemModel>.Instance.CreateSdkPayment(payItemId, response.ReceiptId, response.CallbackUrl);
			SdkPayGetServerBillEvent sdkPayGetServerBillEvent = new SdkPayGetServerBillEvent();
			sdkPayGetServerBillEvent.s_sdk_pay_order = response.ReceiptId;
			ControllerBase<LogReportController>.Instance.LogReport(sdkPayGetServerBillEvent);
			ControllerBase<KuroSdkController>.Instance.SdkPay(paymentInfo);
		}, 0);
	}

	// Token: 0x060115B8 RID: 71096 RVA: 0x004C7F49 File Offset: 0x004C6149
	private void CutWaitPayResponseTimer()
	{
		ControllerBase<KuroSdkController>.Instance.CancelCurrentWaitPayItemTimer(true);
	}

	// Token: 0x060115B9 RID: 71097 RVA: 0x004C7F58 File Offset: 0x004C6158
	public UniTask<bool> QueryPayItemInfoAsync()
	{
		PayItemController.<QueryPayItemInfoAsync>d__11 <QueryPayItemInfoAsync>d__;
		<QueryPayItemInfoAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<QueryPayItemInfoAsync>d__.<>4__this = this;
		<QueryPayItemInfoAsync>d__.<>1__state = -1;
		<QueryPayItemInfoAsync>d__.<>t__builder.Start<PayItemController.<QueryPayItemInfoAsync>d__11>(ref <QueryPayItemInfoAsync>d__);
		return <QueryPayItemInfoAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060115BA RID: 71098 RVA: 0x004C7F9C File Offset: 0x004C619C
	public UniTask<bool> SendPayItemInfoRequestAsync()
	{
		PayItemController.<SendPayItemInfoRequestAsync>d__12 <SendPayItemInfoRequestAsync>d__;
		<SendPayItemInfoRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SendPayItemInfoRequestAsync>d__.<>1__state = -1;
		<SendPayItemInfoRequestAsync>d__.<>t__builder.Start<PayItemController.<SendPayItemInfoRequestAsync>d__12>(ref <SendPayItemInfoRequestAsync>d__);
		return <SendPayItemInfoRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060115BB RID: 71099 RVA: 0x004C7FD8 File Offset: 0x004C61D8
	public UniTask<bool> QueryProductInfoAsync([Nullable(1)] List<string> productIds)
	{
		PayItemController.<QueryProductInfoAsync>d__13 <QueryProductInfoAsync>d__;
		<QueryProductInfoAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<QueryProductInfoAsync>d__.productIds = productIds;
		<QueryProductInfoAsync>d__.<>1__state = -1;
		<QueryProductInfoAsync>d__.<>t__builder.Start<PayItemController.<QueryProductInfoAsync>d__13>(ref <QueryProductInfoAsync>d__);
		return <QueryProductInfoAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060115BC RID: 71100 RVA: 0x004C801C File Offset: 0x004C621C
	[NullableContext(1)]
	public unsafe void SdkPayNew(string productId)
	{
		if (this.CheckoutDialogTimerHandle != null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Pay, ELogAuthor.TL, "SdkPayNew failed, duplicate pay request", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		string productLabelByGoodsId = ModelBase<PayItemModel>.Instance.GetProductLabelByGoodsId(productId);
		if (productLabelByGoodsId == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Pay, ELogAuthor.TL, "SdkPayNew failed, psnProductLabel is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		string productChannelGoodsIdByGoodsId = ModelBase<PayItemModel>.Instance.GetProductChannelGoodsIdByGoodsId(productId);
		bool flag = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().OpenCheckoutDialog(productLabelByGoodsId, productId, productChannelGoodsIdByGoodsId ?? "");
		if (!flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Pay;
			ELogAuthor author = ELogAuthor.TL;
			string message = "SdkPayNew failed, OpenCheckoutDialog failed";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("psnProductId", productLabelByGoodsId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("result", flag);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.CheckoutDialogTimerHandle = TimerSystem.Instance.Forever(delegate(float _)
		{
			ESdkDialogResult esdkDialogResult = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().PollCheckoutDialogResult();
			if (esdkDialogResult != ESdkDialogResult.Waiting)
			{
				if (esdkDialogResult == ESdkDialogResult.Yes)
				{
					this.RequestSdkCheckout(ECheckoutReason.AfterPay);
					if (this.CheckoutDialogTimerHandle != null)
					{
						TimerSystem.Instance.Remove(this.CheckoutDialogTimerHandle);
					}
					this.CheckoutDialogTimerHandle = null;
					Singleton<EventSystem>.Instance.Emit<ESdkDialogResult>(EEventName.SdkPayEnd, ESdkDialogResult.Yes);
					return;
				}
				if (this.CheckoutDialogTimerHandle != null)
				{
					TimerSystem.Instance.Remove(this.CheckoutDialogTimerHandle);
				}
				this.CheckoutDialogTimerHandle = null;
				Singleton<EventSystem>.Instance.Emit<ESdkDialogResult>(EEventName.SdkPayEnd, ESdkDialogResult.No);
			}
		}, 500f, 1f, null, null, true);
	}

	// Token: 0x060115BD RID: 71101 RVA: 0x004C8134 File Offset: 0x004C6334
	public void SdkPay(int payItemId)
	{
		if (this.CurrentBlockBetaState && FeatureRestrictionTemplate.TemplateForPioneerClient.Check())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BetaDisableCharge);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		if (this.CurrentBlockIosPayState && Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
		{
			ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.IosCloseRecharge);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
			return;
		}
		if (!Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			this.SendBuyPayItemRequest(payItemId);
			return;
		}
		string productIdByPayItemId = ConfigBase<PayItemConfig>.Instance.GetProductIdByPayItemId(payItemId);
		if (productIdByPayItemId == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Pay, ELogAuthor.TL, "SdkPay failed, productId is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (((platformSdk != null) ? new bool?(platformSdk.NeedShowSdkProductInfoBeforePay()) : null).GetValueOrDefault())
		{
			DisplayProductInfo productInfoByGoodsId = ModelBase<PayItemModel>.Instance.GetProductInfoByGoodsId(productIdByPayItemId);
			Action<string> onClickConfirmBtn = delegate(string id)
			{
				ControllerBase<PayItemController>.Instance.SdkPayNew(id);
			};
			SdkPayProductInformationViewData param = SdkPayProductInformationViewData.Create(productInfoByGoodsId.Name, productInfoByGoodsId.Desc, productIdByPayItemId, onClickConfirmBtn);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SdkPayProductInformationView, param, null);
			throw new NotImplementedException("SdkPay");
		}
		this.SdkPayNew(productIdByPayItemId);
	}

	// Token: 0x060115BE RID: 71102 RVA: 0x004C827C File Offset: 0x004C647C
	[NullableContext(1)]
	private string GetRoleId()
	{
		if (ModelBase<PlayerInfoModel>.Instance.GetId() != null)
		{
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int num = 0;
			if (!(id.GetValueOrDefault() == num & id != null))
			{
				return ModelBase<PlayerInfoModel>.Instance.GetId().ToString();
			}
		}
		if (ModelBase<LoginModel>.Instance.GetCreatePlayerId() != 0)
		{
			return ModelBase<LoginModel>.Instance.GetCreatePlayerId().ToString();
		}
		return "";
	}

	// Token: 0x060115BF RID: 71103 RVA: 0x004C82FC File Offset: 0x004C64FC
	public void RequestSdkCheckout(ECheckoutReason reason)
	{
		if (!Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn)
		{
			return;
		}
		if (ModelBase<LoginModel>.Instance.SdkAccessToken == "")
		{
			return;
		}
		string roleId = this.GetRoleId();
		if (roleId == "")
		{
			return;
		}
		ISdkRequestCheckoutProductParam sdkRequestCheckoutProductParam = new ISdkRequestCheckoutProductParam
		{
			AccessToken = ModelBase<LoginModel>.Instance.SdkAccessToken,
			ServerId = ModelBase<LoginModel>.Instance.GetServerId(),
			ServerName = ModelBase<LoginModel>.Instance.GetServerName(),
			RoleId = roleId,
			RoleName = ModelBase<FunctionModel>.Instance.GetPlayerName()
		};
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Pay;
		ELogAuthor author = ELogAuthor.TL;
		string message = "RequestSdkCheckout SDK销单";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("param", sdkRequestCheckoutProductParam);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().RequestCheckoutProduct(sdkRequestCheckoutProductParam, delegate(string msg, bool needReLogin, bool suc)
		{
			if (!suc)
			{
				if (needReLogin)
				{
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ServerMaintenance);
					confirmBoxDataNew.SetTextArgs(new string[]
					{
						msg
					});
					confirmBoxDataNew.SetCloseFunction(delegate
					{
						ControllerBase<ReConnectController>.Instance.Logout(ELogoutReason.SdkRenewAccessTokenFailed);
					});
					ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
					return;
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Pay;
				ELogAuthor author2 = ELogAuthor.TL;
				string message2 = "RequestSdkCheckout SDK销单";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("msg", msg);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
		}, reason);
	}

	// Token: 0x060115C0 RID: 71104 RVA: 0x004C83E9 File Offset: 0x004C65E9
	private void OnWorldDone()
	{
		if (ModelBase<FunctionModel>.Instance.IsOpen(10010))
		{
			this.SendPayItemInfoRequestAsync();
		}
	}

	// Token: 0x060115C1 RID: 71105 RVA: 0x004C8403 File Offset: 0x004C6603
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
		this.SendPayItemInfoRequestAsync();
	}

	// Token: 0x04008865 RID: 34917
	public bool CurrentBlockIosPayState;

	// Token: 0x04008866 RID: 34918
	public bool CurrentBlockBetaState = true;

	// Token: 0x04008867 RID: 34919
	[Nullable(2)]
	private TimerHandle CheckoutDialogTimerHandle;
}
