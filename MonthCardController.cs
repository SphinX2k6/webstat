using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020023A4 RID: 9124
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class MonthCardController : UiControllerBase<MonthCardController>
{
	// Token: 0x06011944 RID: 72004 RVA: 0x004D1F74 File Offset: 0x004D0174
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x06011945 RID: 72005 RVA: 0x004D1F77 File Offset: 0x004D0177
	private void SetMonthCardRemainDays(int value)
	{
		ModelBase<MonthCardModel>.Instance.SetRemainDays(value);
		Singleton<EventSystem>.Instance.Emit(EEventName.ReceiveMonthCardDataEvent);
	}

	// Token: 0x06011946 RID: 72006 RVA: 0x004D1F94 File Offset: 0x004D0194
	public UniTask RequestMonthCardData()
	{
		MonthCardController.<RequestMonthCardData>d__2 <RequestMonthCardData>d__;
		<RequestMonthCardData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestMonthCardData>d__.<>4__this = this;
		<RequestMonthCardData>d__.<>1__state = -1;
		<RequestMonthCardData>d__.<>t__builder.Start<MonthCardController.<RequestMonthCardData>d__2>(ref <RequestMonthCardData>d__);
		return <RequestMonthCardData>d__.<>t__builder.Task;
	}

	// Token: 0x06011947 RID: 72007 RVA: 0x004D1FD7 File Offset: 0x004D01D7
	private void OnTryOpenMonthCardRewardView()
	{
		this.TryOpenMonthCardRewardView(false);
	}

	// Token: 0x06011948 RID: 72008 RVA: 0x004D1FE0 File Offset: 0x004D01E0
	private void OnLoadingNetDataDone()
	{
		this.RequestMonthCardData().Forget();
	}

	// Token: 0x06011949 RID: 72009 RVA: 0x004D1FF0 File Offset: 0x004D01F0
	private unsafe void OnReceiveDailyRewardNotify(MonthCardDailyRewardNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		int count = notify.Count;
		int itemId = notify.ItemId;
		int days = notify.Days;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "MonthCard:【月卡每日奖励】信息推送 - MonthCardDailyRewardNotify";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Count", count);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("itemId", itemId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("remainDays", days);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		TItem value = new TItem(new InventoryDefine.GetItemData(itemId, 0), count);
		ModelBase<MonthCardModel>.Instance.ServerDailyReward = new TItem?(value);
		ModelBase<MonthCardModel>.Instance.CanShowDailyRewardView = true;
		this.SetMonthCardRemainDays(days);
		this.TryOpenMonthCardRewardView(true);
	}

	// Token: 0x0601194A RID: 72010 RVA: 0x004D20C4 File Offset: 0x004D02C4
	private void OnMonthCardUse(MonthCardUseNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		int days = notify.Days;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "MonthCard:【月卡购买通知】-MonthCardBuyNotify-信息推送";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("remainDays", days);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		TItem value = new TItem(new InventoryDefine.GetItemData(notify.ItemId, 0), notify.Count);
		ModelBase<MonthCardModel>.Instance.ServerOnceReward = new TItem?(value);
		if (ModelBase<MonthCardModel>.Instance.GetRemainDays() < 0)
		{
			ModelBase<MonthCardModel>.Instance.CanShowDailyRewardView = true;
		}
		this.SetMonthCardRemainDays(days);
		if (ModelBase<GameModeModel>.Instance.WorldDoneAndLoadingClosed)
		{
			TItem? serverOnceReward = ModelBase<MonthCardModel>.Instance.ServerOnceReward;
			int itemId = serverOnceReward.Value.ItemData.ItemId;
			if (itemId != 0)
			{
				RewardItemData item = new RewardItemData(itemId, serverOnceReward.Value.Count, null, EDropItemType.Normal);
				List<RewardItemData> rewardItemDataList = new List<RewardItemData>
				{
					item
				};
				int monthCardRewardId = ConfigBase<PayShopConfig>.Instance.GetMonthCardRewardId();
				ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(monthCardRewardId, rewardItemDataList, new Action(this.TryOpenMonthCardRewardViewInShop));
				return;
			}
			this.TryOpenMonthCardRewardViewInShop();
		}
	}

	// Token: 0x0601194B RID: 72011 RVA: 0x004D21D6 File Offset: 0x004D03D6
	private void TryOpenMonthCardRewardViewInShop()
	{
		if (ModelBase<MonthCardModel>.Instance.CanShowDailyRewardView)
		{
			this.OpenMonthCardRewardView(false);
		}
	}

	// Token: 0x0601194C RID: 72012 RVA: 0x004D21EC File Offset: 0x004D03EC
	private void TryOpenMonthCardRewardView(bool isInstantly = false)
	{
		if (ModelBase<MonthCardModel>.Instance.CanShowDailyRewardView)
		{
			SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.MonthCard, ESplashScreenType.Config, delegate()
			{
				this.OpenMonthCardRewardView(true);
			});
			ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, isInstantly);
		}
	}

	// Token: 0x0601194D RID: 72013 RVA: 0x004D2225 File Offset: 0x004D0425
	private void OpenMonthCardRewardView(bool isBySplashScreen)
	{
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MonthCardRewardView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MonthCardRewardView, isBySplashScreen, null);
		}
	}

	// Token: 0x0601194E RID: 72014 RVA: 0x004D2250 File Offset: 0x004D0450
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnItemUse, new Action<int, int>(this.OnItemUse));
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnTryOpenMonthCardRewardView));
	}

	// Token: 0x0601194F RID: 72015 RVA: 0x004D22B4 File Offset: 0x004D04B4
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemUse, new Action<int, int>(this.OnItemUse));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnTryOpenMonthCardRewardView));
	}

	// Token: 0x06011950 RID: 72016 RVA: 0x004D2318 File Offset: 0x004D0518
	private void OnItemUse(int configId, int itemNum)
	{
		ItemInfo value = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(configId).Value;
		int? num = null;
		int value2;
		if (value.Parameters().TryGetValue(13, out value2))
		{
			num = new int?(value2);
		}
		int value3;
		if (num == null && value.Parameters().TryGetValue(14, out value3))
		{
			num = new int?(value3);
		}
		if (num != null)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("UseMonthCard", Array.Empty<object>());
		}
	}

	// Token: 0x06011951 RID: 72017 RVA: 0x004D239C File Offset: 0x004D059C
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<MonthCardDailyRewardNotify>(ENotifyMessageId.MonthCardDailyRewardNotify, new Action<MonthCardDailyRewardNotify, Net.CallbackStatus>(this.OnReceiveDailyRewardNotify));
		Singleton<Net>.Instance.Register<MonthCardUseNotify>(ENotifyMessageId.MonthCardUseNotify, new Action<MonthCardUseNotify, Net.CallbackStatus>(this.OnMonthCardUse));
	}

	// Token: 0x06011952 RID: 72018 RVA: 0x004D23D6 File Offset: 0x004D05D6
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MonthCardDailyRewardNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MonthCardUseNotify);
	}
}
