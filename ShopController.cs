using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020029F4 RID: 10740
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ShopController : UiControllerBase<ShopController>
{
	// Token: 0x060156D4 RID: 87764 RVA: 0x005EFD9D File Offset: 0x005EDF9D
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(this.OnCrossDay));
	}

	// Token: 0x060156D5 RID: 87765 RVA: 0x005EFDBB File Offset: 0x005EDFBB
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(this.OnCrossDay));
	}

	// Token: 0x060156D6 RID: 87766 RVA: 0x005EFDD9 File Offset: 0x005EDFD9
	private void OnCrossDay()
	{
		this.SendShopInfoRequest(ModelBase<ShopModel>.Instance.VersionId).ContinueWith(delegate(bool success)
		{
			if (success)
			{
				EventSystem instance = Singleton<EventSystem>.Instance;
				EEventName name = EEventName.ShopUpdate;
				ShopItemFullInfo openItemInfo = ModelBase<ShopModel>.Instance.OpenItemInfo;
				instance.Emit<int?>(name, (openItemInfo != null) ? new int?(openItemInfo.ShopId) : null);
			}
		});
	}

	// Token: 0x060156D7 RID: 87767 RVA: 0x005EFE10 File Offset: 0x005EE010
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ShopInfoNotify>(ENotifyMessageId.ShopInfoNotify, delegate(ShopInfoNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			Singleton<Log>.Instance.Info(ELogModule.Shop, ELogAuthor.YSQ, "Receive ShopInfoNotify", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<ShopModel>.Instance.VersionId = notify.VersionStr;
			ModelBase<ShopModel>.Instance.UpdateShopListData(notify.ShopList.ToList<ShopInfo>());
		});
		Singleton<Net>.Instance.Register<ShopUnlockNotify>(ENotifyMessageId.ShopUnlockNotify, delegate(ShopUnlockNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Shop;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "Receive ShopUnlockNotify";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("unlockList", notify.UnlockList);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.OnShopUnlockNotify(notify);
		});
		Singleton<Net>.Instance.Register<ShopInfoUpdateNotify>(ENotifyMessageId.ShopInfoUpdateNotify, this.OnShopInfoUpdateNotify);
	}

	// Token: 0x060156D8 RID: 87768 RVA: 0x005EFE7E File Offset: 0x005EE07E
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ShopInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ShopUnlockNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ShopInfoUpdateNotify);
	}

	// Token: 0x060156D9 RID: 87769 RVA: 0x005EFEB0 File Offset: 0x005EE0B0
	public bool OpenShop(int shopId, string uiCameraName = null, Action<bool, int> finishCallback = null)
	{
		if (ModelBase<ShopModel>.Instance.IsOpen(shopId))
		{
			if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ShopView))
			{
				ShopOpenParam param = new ShopOpenParam
				{
					ShopId = shopId,
					UiCameraName = uiCameraName
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.ShopView, param, delegate(bool success, int viewId)
				{
					Action<bool, int> finishCallback2 = finishCallback;
					if (finishCallback2 == null)
					{
						return;
					}
					finishCallback2(success, viewId);
				});
				return true;
			}
		}
		else if (GlobalData.World != null)
		{
			string shopName = ConfigBase<ShopConfig>.Instance.GetShopName(ModelBase<ShopModel>.Instance.GetShopConfig(shopId).Value.ShopName);
			if (shopName != null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ShopNotOpenTip", new object[]
				{
					shopName
				});
			}
		}
		return false;
	}

	// Token: 0x060156DA RID: 87770 RVA: 0x005EFF68 File Offset: 0x005EE168
	public unsafe void SendShopBuyRequest(int shopId, int itemId, int moneyId, int count, Action callback = null)
	{
		ShopBuyRequest shopBuyRequest = ShopBuyRequest.Create();
		shopBuyRequest.VersionStr = ModelBase<ShopModel>.Instance.VersionId;
		shopBuyRequest.ShopId = shopId;
		shopBuyRequest.Id = itemId;
		shopBuyRequest.MoneyId = moneyId;
		shopBuyRequest.Num = count;
		shopBuyRequest.InteractEntityId = ModelBase<ShopModel>.Instance.CurrentInteractCreatureDataLongId.GetValueOrDefault();
		Singleton<Net>.Instance.Call<ShopBuyResponse>(ERequestMessageId.ShopBuyRequest, shopBuyRequest, delegate(ShopBuyResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<ShopModel>.Instance.UpdateItemData(response);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Shop;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "购买物品成功";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", response.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buyCount", response.BoughtCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("response", response);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.BoughtItem, shopId, itemId);
				if (callback != null)
				{
					callback();
					return;
				}
			}
			else
			{
				string textByErrorId = ConfigBase<ErrorCodeConfig>.Instance.GetTextByErrorId(response.ErrorCode);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(textByErrorId);
				Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.BoughtItem, 0, 0);
			}
		}, 0);
	}

	// Token: 0x060156DB RID: 87771 RVA: 0x005F0000 File Offset: 0x005EE200
	[NullableContext(0)]
	public UniTask<bool> SendShopInfoRequest([Nullable(1)] string version)
	{
		ShopController.<SendShopInfoRequest>d__7 <SendShopInfoRequest>d__;
		<SendShopInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SendShopInfoRequest>d__.version = version;
		<SendShopInfoRequest>d__.<>1__state = -1;
		<SendShopInfoRequest>d__.<>t__builder.Start<ShopController.<SendShopInfoRequest>d__7>(ref <SendShopInfoRequest>d__);
		return <SendShopInfoRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060156DC RID: 87772 RVA: 0x005F0044 File Offset: 0x005EE244
	public UniTask SendShopUpdateRequestAsync(int shopId)
	{
		ShopController.<SendShopUpdateRequestAsync>d__8 <SendShopUpdateRequestAsync>d__;
		<SendShopUpdateRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SendShopUpdateRequestAsync>d__.shopId = shopId;
		<SendShopUpdateRequestAsync>d__.<>1__state = -1;
		<SendShopUpdateRequestAsync>d__.<>t__builder.Start<ShopController.<SendShopUpdateRequestAsync>d__8>(ref <SendShopUpdateRequestAsync>d__);
		return <SendShopUpdateRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060156DD RID: 87773 RVA: 0x005F0088 File Offset: 0x005EE288
	public void SendShopUpdateRequest(int shopId)
	{
		ShopUpdateRequest shopUpdateRequest = ShopUpdateRequest.Create();
		shopUpdateRequest.ShopId = shopId;
		Singleton<Net>.Instance.Call<ShopUpdateResponse>(ERequestMessageId.ShopUpdateRequest, shopUpdateRequest, delegate(ShopUpdateResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<ShopModel>.Instance.UpdateShopData(response.Info);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26930, null, true, true);
		}, 0);
	}

	// Token: 0x060156DE RID: 87774 RVA: 0x005F00D4 File Offset: 0x005EE2D4
	[NullableContext(1)]
	public unsafe void OnShopUnlockNotify(ShopUnlockNotify notify)
	{
		foreach (UnlockInfo unlockInfo in notify.UnlockList)
		{
			if (ModelBase<ShopModel>.Instance.GetShopInfo(unlockInfo.ShopId) != null)
			{
				ShopItemInfoNew shopItem = ModelBase<ShopModel>.Instance.GetShopItem(unlockInfo.ShopId, unlockInfo.Id);
				if (shopItem != null)
				{
					shopItem.Lock = false;
					Singleton<EventSystem>.Instance.Emit(EEventName.OnGoodUnlock);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Shop;
					ELogAuthor author = ELogAuthor.YZY;
					string message = "新商品解锁";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", unlockInfo.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buyCount", unlockInfo.ShopId);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					Singleton<EventSystem>.Instance.Emit<int?>(EEventName.ShopUpdate, new int?(unlockInfo.ShopId));
				}
			}
		}
	}

	// Token: 0x0400A4E0 RID: 42208
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	public readonly Action<ShopInfoUpdateNotify, Net.CallbackStatus> OnShopInfoUpdateNotify = delegate(ShopInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<ShopModel>.Instance.UpdateShopData(notify.ShopInfo);
	};
}
