using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002405 RID: 9221
[NullableContext(1)]
[Nullable(0)]
public class WeekCardView : UiTabViewBase
{
	// Token: 0x06011D63 RID: 73059 RVA: 0x004E7DF4 File Offset: 0x004E5FF4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickHelpButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011D64 RID: 73060 RVA: 0x004E800C File Offset: 0x004E620C
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.ReceiveWeekCardDataEvent, new Action(this.OnReceiveMonthCardDataEvent));
		Singleton<EventSystem>.Instance.Add(EEventName.DiscountShopTimerRefresh, new Action(this.OnDiscountShopTimerRefresh));
		Singleton<EventSystem>.Instance.Add<ESdkDialogResult>(EEventName.SdkPayEnd, new Action<ESdkDialogResult>(this.CheckIfNeedShowPlayStationStoreIcon));
	}

	// Token: 0x06011D65 RID: 73061 RVA: 0x004E806C File Offset: 0x004E626C
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ReceiveWeekCardDataEvent, new Action(this.OnReceiveMonthCardDataEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.DiscountShopTimerRefresh, new Action(this.OnDiscountShopTimerRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.SdkPayEnd, new Action<ESdkDialogResult>(this.CheckIfNeedShowPlayStationStoreIcon));
	}

	// Token: 0x06011D66 RID: 73062 RVA: 0x004E80CC File Offset: 0x004E62CC
	protected override UniTask OnBeforeStartAsync()
	{
		WeekCardView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeekCardView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011D67 RID: 73063 RVA: 0x004E810F File Offset: 0x004E630F
	protected override void OnBeforeHide()
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk == null)
		{
			return;
		}
		platformSdk.HidePlayStationStoreIcon();
	}

	// Token: 0x06011D68 RID: 73064 RVA: 0x004E8128 File Offset: 0x004E6328
	protected override void OnAfterShow()
	{
		UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
		((tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null).PlayLevelSequenceByName("Start", false, null, false);
		WeekCardViewModel vm = this.Vm;
		if (vm == null)
		{
			return;
		}
		vm.OnAfterShow();
	}

	// Token: 0x06011D69 RID: 73065 RVA: 0x004E816C File Offset: 0x004E636C
	private bool CheckSdkProductInfoConfirmIfCanShow(int payGiftDataId)
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (!((platformSdk != null) ? new bool?(platformSdk.NeedConfirmSdkProductInfo()) : null).GetValueOrDefault())
		{
			return true;
		}
		string productId = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(payGiftDataId).GetGetPayGiftData().ProductId;
		if (ModelBase<PayItemModel>.Instance.GetProductInfoByGoodsId(productId) != null)
		{
			return true;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CannotFindSdkProduct);
		Action value = delegate()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.PayShopRootView, null);
		};
		confirmBoxDataNew.FunctionMap.Add(1, value);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		this.OpenThirdPartyMessageBox().Forget();
		return false;
	}

	// Token: 0x06011D6A RID: 73066 RVA: 0x004E8228 File Offset: 0x004E6428
	private UniTask OpenThirdPartyMessageBox()
	{
		WeekCardView.<OpenThirdPartyMessageBox>d__15 <OpenThirdPartyMessageBox>d__;
		<OpenThirdPartyMessageBox>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenThirdPartyMessageBox>d__.<>1__state = -1;
		<OpenThirdPartyMessageBox>d__.<>t__builder.Start<WeekCardView.<OpenThirdPartyMessageBox>d__15>(ref <OpenThirdPartyMessageBox>d__);
		return <OpenThirdPartyMessageBox>d__.<>t__builder.Task;
	}

	// Token: 0x06011D6B RID: 73067 RVA: 0x004E8264 File Offset: 0x004E6464
	private UniTask CreateCardItems()
	{
		WeekCardView.<CreateCardItems>d__16 <CreateCardItems>d__;
		<CreateCardItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateCardItems>d__.<>4__this = this;
		<CreateCardItems>d__.<>1__state = -1;
		<CreateCardItems>d__.<>t__builder.Start<WeekCardView.<CreateCardItems>d__16>(ref <CreateCardItems>d__);
		return <CreateCardItems>d__.<>t__builder.Task;
	}

	// Token: 0x06011D6C RID: 73068 RVA: 0x004E82A8 File Offset: 0x004E64A8
	private UniTask CreateSendCostItem()
	{
		WeekCardView.<CreateSendCostItem>d__17 <CreateSendCostItem>d__;
		<CreateSendCostItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateSendCostItem>d__.<>4__this = this;
		<CreateSendCostItem>d__.<>1__state = -1;
		<CreateSendCostItem>d__.<>t__builder.Start<WeekCardView.<CreateSendCostItem>d__17>(ref <CreateSendCostItem>d__);
		return <CreateSendCostItem>d__.<>t__builder.Task;
	}

	// Token: 0x06011D6D RID: 73069 RVA: 0x004E82EB File Offset: 0x004E64EB
	private void CreateTotalCostItem()
	{
		this.TotalRewardLayout = new GenericLayout<WeekCardCostGrid, IWeekCostData>(base.GetHorizontalLayout(5), () => new WeekCardCostGrid(), null, false, true);
	}

	// Token: 0x06011D6E RID: 73070 RVA: 0x004E8324 File Offset: 0x004E6524
	private UniTask CreateBuyButton()
	{
		WeekCardView.<CreateBuyButton>d__19 <CreateBuyButton>d__;
		<CreateBuyButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateBuyButton>d__.<>4__this = this;
		<CreateBuyButton>d__.<>1__state = -1;
		<CreateBuyButton>d__.<>t__builder.Start<WeekCardView.<CreateBuyButton>d__19>(ref <CreateBuyButton>d__);
		return <CreateBuyButton>d__.<>t__builder.Task;
	}

	// Token: 0x06011D6F RID: 73071 RVA: 0x004E8367 File Offset: 0x004E6567
	protected override void OnStart()
	{
		this.RefreshAllView();
	}

	// Token: 0x06011D70 RID: 73072 RVA: 0x004E836F File Offset: 0x004E656F
	private void RefreshAllView()
	{
		this.RefreshCountDown();
		this.RefreshWeekCardItems();
		this.RefreshBuyButton();
		this.RefreshTotalCost();
		this.RefreshSendCostItem();
		this.RefreshPrice();
		this.RefreshTitle();
		this.RefreshDiscountSprite();
	}

	// Token: 0x06011D71 RID: 73073 RVA: 0x004E83A4 File Offset: 0x004E65A4
	private void RefreshDiscountSprite()
	{
		WeekCardViewModel vm = this.Vm;
		base.TrySetSpriteByPath((vm != null) ? vm.GetDiscountTexturePath() : null, base.GetSprite(12), false, null, null);
	}

	// Token: 0x06011D72 RID: 73074 RVA: 0x004E83DC File Offset: 0x004E65DC
	private bool RefreshCountDown()
	{
		WeekCardViewModel vm = this.Vm;
		double num = (vm != null) ? vm.GetCountDownLeftSec() : 0.0;
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3((num > 0.0) ? num : 0.0);
		LguiUtil instance = Singleton<LguiUtil>.Instance;
		UUIText text = base.GetText(4);
		WeekCardViewModel vm2 = this.Vm;
		instance.SetLocalTextNew(text, ((vm2 != null) ? vm2.GetCountDownTextKey() : null) ?? "", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText ?? ""));
		WeekCardItem[] weekCardItems = this.WeekCardItems;
		for (int i = 0; i < weekCardItems.Length; i++)
		{
			weekCardItems[i].RefreshTime();
		}
		bool flag = num <= 0.0;
		bool result = flag && !this.CountDownExpired;
		this.CountDownExpired = flag;
		return result;
	}

	// Token: 0x06011D73 RID: 73075 RVA: 0x004E84B0 File Offset: 0x004E66B0
	private void RefreshWeekCardItems()
	{
		for (int i = 0; i < this.WeekCardItems.Length; i++)
		{
			WeekCardViewModel vm = this.Vm;
			WeekCardContentInfo weekCardContentInfo = (vm != null) ? vm.GetWeekCardContentInfo(i) : null;
			if (weekCardContentInfo != null)
			{
				this.WeekCardItems[i].Refresh(this.Vm, weekCardContentInfo);
			}
		}
	}

	// Token: 0x06011D74 RID: 73076 RVA: 0x004E84FC File Offset: 0x004E66FC
	private void RefreshBuyButton()
	{
		WeekCardViewModel vm = this.Vm;
		bool flag = vm != null && vm.IsBuy();
		this.BuyButton.SetEnableClick(!flag);
		ButtonItem buyButton = this.BuyButton;
		WeekCardViewModel vm2 = this.Vm;
		buyButton.SetLocalTextNew(((vm2 != null) ? vm2.GetBuyButtonText() : null) ?? "", Array.Empty<object>());
	}

	// Token: 0x06011D75 RID: 73077 RVA: 0x004E8556 File Offset: 0x004E6756
	private void RefreshTotalCost()
	{
		GenericLayout<WeekCardCostGrid, IWeekCostData> totalRewardLayout = this.TotalRewardLayout;
		WeekCardViewModel vm = this.Vm;
		totalRewardLayout.RefreshByData(((vm != null) ? vm.GetTotalRewardData() : null) ?? new List<IWeekCostData>(), null, false);
	}

	// Token: 0x06011D76 RID: 73078 RVA: 0x004E8580 File Offset: 0x004E6780
	private void RefreshSendCostItem()
	{
		WeekCardViewModel vm = this.Vm;
		IWeekScoreData weekScoreData = (vm != null) ? vm.GetSendCostItemData() : null;
		if (weekScoreData == null)
		{
			this.SendCostItem.SetUiActive(false);
			return;
		}
		this.SendCostItem.SetUiActive(true);
		this.SendCostItem.Refresh(weekScoreData);
	}

	// Token: 0x06011D77 RID: 73079 RVA: 0x004E85C8 File Offset: 0x004E67C8
	private void RefreshPrice()
	{
		UUIText text = base.GetText(9);
		WeekCardViewModel vm = this.Vm;
		text.SetText(((vm != null) ? vm.GetPrice() : null) ?? "", true);
	}

	// Token: 0x06011D78 RID: 73080 RVA: 0x004E85F4 File Offset: 0x004E67F4
	private void RefreshTitle()
	{
		WeekCardViewModel vm = this.Vm;
		string text = (vm != null) ? vm.GetTitleTextKey() : null;
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), text, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), text, Array.Empty<object>());
	}

	// Token: 0x06011D79 RID: 73081 RVA: 0x004E864D File Offset: 0x004E684D
	private void OnReceiveMonthCardDataEvent()
	{
		this.RefreshAllView();
	}

	// Token: 0x06011D7A RID: 73082 RVA: 0x004E8658 File Offset: 0x004E6858
	private void OnClickHelpButton()
	{
		WeekCardViewModel vm = this.Vm;
		int? num = (vm != null) ? vm.GetHelpGroupId() : null;
		if (num == null)
		{
			return;
		}
		ControllerBase<HelpController>.Instance.OpenHelpById(num.Value);
	}

	// Token: 0x06011D7B RID: 73083 RVA: 0x004E869B File Offset: 0x004E689B
	private void OnClickBuyButton(int _)
	{
		WeekCardViewModel vm = this.Vm;
		if (vm != null && vm.IsBuy())
		{
			return;
		}
		WeekCardViewModel vm2 = this.Vm;
		if (vm2 == null)
		{
			return;
		}
		vm2.OnBuy();
	}

	// Token: 0x06011D7C RID: 73084 RVA: 0x004E86C2 File Offset: 0x004E68C2
	private void OnDiscountShopTimerRefresh()
	{
		if (this.RefreshCountDown())
		{
			this.TryEmitRefreshTips();
		}
	}

	// Token: 0x06011D7D RID: 73085 RVA: 0x004E86D2 File Offset: 0x004E68D2
	private void CheckIfNeedShowPlayStationStoreIcon(ESdkDialogResult eSdkDialogResult)
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk == null)
		{
			return;
		}
		platformSdk.ShowPlayStationStoreIcon(0);
	}

	// Token: 0x06011D7E RID: 73086 RVA: 0x004E86E9 File Offset: 0x004E68E9
	protected void TryEmitRefreshTips()
	{
		ControllerBase<PayShopController>.Instance.ClosePayShopGoodDetailPopView();
		if (ControllerBase<ConfirmBoxController>.Instance.CheckIsConfirmBoxOpen())
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.RefreshPayShop, 1, true);
	}

	// Token: 0x04008B85 RID: 35717
	private readonly ButtonItem BuyButton = new ButtonItem(null);

	// Token: 0x04008B86 RID: 35718
	private readonly WeekCardItem[] WeekCardItems = new WeekCardItem[]
	{
		new WeekCardItem(),
		new WeekCardItem(),
		new WeekCardItem()
	};

	// Token: 0x04008B87 RID: 35719
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WeekCardCostGrid, IWeekCostData> TotalRewardLayout;

	// Token: 0x04008B88 RID: 35720
	private readonly WeekCardScoreItem SendCostItem = new WeekCardScoreItem();

	// Token: 0x04008B89 RID: 35721
	private EWeekCardKind Kind;

	// Token: 0x04008B8A RID: 35722
	[Nullable(2)]
	private WeekCardViewModel Vm;

	// Token: 0x04008B8B RID: 35723
	private bool CountDownExpired;

	// Token: 0x02008738 RID: 34616
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402DBC6 RID: 187334
		public const int CardItem1 = 0;

		// Token: 0x0402DBC7 RID: 187335
		public const int CardItem2 = 1;

		// Token: 0x0402DBC8 RID: 187336
		public const int CardItem3 = 2;

		// Token: 0x0402DBC9 RID: 187337
		public const int CostItemSend = 3;

		// Token: 0x0402DBCA RID: 187338
		public const int TextLeftTime = 4;

		// Token: 0x0402DBCB RID: 187339
		public const int PanelTotalReward = 5;

		// Token: 0x0402DBCC RID: 187340
		public const int CostItemTotal = 6;

		// Token: 0x0402DBCD RID: 187341
		public const int BtnBuy = 7;

		// Token: 0x0402DBCE RID: 187342
		public const int BtnHelp = 8;

		// Token: 0x0402DBCF RID: 187343
		public const int TextPrice = 9;

		// Token: 0x0402DBD0 RID: 187344
		public const int TitleText = 10;

		// Token: 0x0402DBD1 RID: 187345
		public const int TitleTextOutline = 11;

		// Token: 0x0402DBD2 RID: 187346
		public const int SpriteDiscount = 12;
	}
}
