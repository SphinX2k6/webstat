using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020023A7 RID: 9127
[NullableContext(2)]
[Nullable(0)]
public class MonthCardView : UiTabViewBase
{
	// Token: 0x06011967 RID: 72039 RVA: 0x004D2A88 File Offset: 0x004D0C88
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickedHelpButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011968 RID: 72040 RVA: 0x004D2CA0 File Offset: 0x004D0EA0
	protected override UniTask OnBeforeStartAsync()
	{
		MonthCardView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MonthCardView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011969 RID: 72041 RVA: 0x004D2CE4 File Offset: 0x004D0EE4
	private UniTask BuildRewardItems()
	{
		MonthCardView.<BuildRewardItems>d__9 <BuildRewardItems>d__;
		<BuildRewardItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<BuildRewardItems>d__.<>4__this = this;
		<BuildRewardItems>d__.<>1__state = -1;
		<BuildRewardItems>d__.<>t__builder.Start<MonthCardView.<BuildRewardItems>d__9>(ref <BuildRewardItems>d__);
		return <BuildRewardItems>d__.<>t__builder.Task;
	}

	// Token: 0x0601196A RID: 72042 RVA: 0x004D2D27 File Offset: 0x004D0F27
	protected override void OnBeforeShow()
	{
		this.RefreshView();
		this.CheckIfNeedShowPlayStationStoreIcon(ESdkDialogResult.No);
	}

	// Token: 0x0601196B RID: 72043 RVA: 0x004D2D38 File Offset: 0x004D0F38
	protected override void OnStart()
	{
		this.BuyButtonItem = new ButtonAndTextItem(base.GetItem(4));
		this.BuyButtonItem.BindCallback(new Action(this.OnClickedBuyButton));
		TItem? localOnceReward = ModelBase<MonthCardModel>.Instance.LocalOnceReward;
		TItem? localDailyReward = ModelBase<MonthCardModel>.Instance.LocalDailyReward;
		this.OnceRewardItem.Refresh(localOnceReward.Value.ItemData.ItemId, localOnceReward.Value.Count);
		this.DailyRewardItem.Refresh(localDailyReward.Value.ItemData.ItemId, localDailyReward.Value.Count);
		this.OnReceiveMonthCardData();
		this.RefreshPrice();
		this.RefreshCloudGameInfo();
		base.GetText(9).ShowTextNew("MonthCardDes_1");
		UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
		((tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null).PlayLevelSequenceByName("Loop", false, null, false);
		this.TotalTopUpTagItem.RefreshByGoodsId(42);
	}

	// Token: 0x0601196C RID: 72044 RVA: 0x004D2E2C File Offset: 0x004D102C
	private bool CheckSdkProductInfoConfirmIfCanShow()
	{
		if (!Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().NeedConfirmSdkProductInfo())
		{
			return true;
		}
		string productId = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(42).GetGetPayGiftData().ProductId;
		if (ModelBase<PayItemModel>.Instance.GetProductInfoByGoodsId(productId) != null)
		{
			return true;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CannotFindSdkProduct);
		confirmBoxDataNew.FunctionMap.Add(1, new Action(MonthCardView.<CheckSdkProductInfoConfirmIfCanShow>g__confirmCallback|12_0));
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		this.OpenThirdPartyMessageBox().Forget();
		return false;
	}

	// Token: 0x0601196D RID: 72045 RVA: 0x004D2EB4 File Offset: 0x004D10B4
	private UniTask OpenThirdPartyMessageBox()
	{
		MonthCardView.<OpenThirdPartyMessageBox>d__13 <OpenThirdPartyMessageBox>d__;
		<OpenThirdPartyMessageBox>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenThirdPartyMessageBox>d__.<>1__state = -1;
		<OpenThirdPartyMessageBox>d__.<>t__builder.Start<MonthCardView.<OpenThirdPartyMessageBox>d__13>(ref <OpenThirdPartyMessageBox>d__);
		return <OpenThirdPartyMessageBox>d__.<>t__builder.Task;
	}

	// Token: 0x0601196E RID: 72046 RVA: 0x004D2EF0 File Offset: 0x004D10F0
	private void RefreshPrice()
	{
		PayShopGoods payShopGoodsById = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(42);
		base.GetText(3).SetText(payShopGoodsById.GetDirectPriceText(), true);
	}

	// Token: 0x0601196F RID: 72047 RVA: 0x004D2F20 File Offset: 0x004D1120
	private void RefreshCloudGameInfo()
	{
		PayShopGoods payShopGoodsById = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(42);
		bool flag = payShopGoodsById.HasCloudGameInfo();
		UUIText text = base.GetText(10);
		UUITexture texture = base.GetTexture(11);
		text.SetUIActive(flag);
		texture.SetUIActive(flag);
		if (flag)
		{
			text.SetText(payShopGoodsById.GetCloudGameDesc(), true);
			base.SetTextureShowUntilLoaded(payShopGoodsById.GetCloudGameIcon(), texture, null);
		}
	}

	// Token: 0x06011970 RID: 72048 RVA: 0x004D2F7F File Offset: 0x004D117F
	protected override void OnBeforeHide()
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk == null)
		{
			return;
		}
		platformSdk.HidePlayStationStoreIcon();
	}

	// Token: 0x06011971 RID: 72049 RVA: 0x004D2F95 File Offset: 0x004D1195
	protected override void OnBeforeDestroy()
	{
		ButtonAndTextItem buyButtonItem = this.BuyButtonItem;
		if (buyButtonItem != null)
		{
			buyButtonItem.Destroy(null);
		}
		this.BuyButtonItem = null;
	}

	// Token: 0x06011972 RID: 72050 RVA: 0x004D2FB0 File Offset: 0x004D11B0
	private void OnClickedHelpButton()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(9);
	}

	// Token: 0x06011973 RID: 72051 RVA: 0x004D2FC0 File Offset: 0x004D11C0
	private void OnClickedBuyButton()
	{
		if (!this.CanBuyMonthCard)
		{
			return;
		}
		PayShopGoods payShopGoodsById = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(42);
		ControllerBase<PayGiftController>.Instance.SdkPay(payShopGoodsById.GetGoodsData().Id);
	}

	// Token: 0x06011974 RID: 72052 RVA: 0x004D2FF8 File Offset: 0x004D11F8
	private void OnReceiveMonthCardData()
	{
		this.RefreshView();
	}

	// Token: 0x06011975 RID: 72053 RVA: 0x004D3000 File Offset: 0x004D1200
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.ReceiveMonthCardDataEvent, new Action(this.OnReceiveMonthCardData));
		Singleton<EventSystem>.Instance.Add<ESdkDialogResult>(EEventName.SdkPayEnd, new Action<ESdkDialogResult>(this.CheckIfNeedShowPlayStationStoreIcon));
	}

	// Token: 0x06011976 RID: 72054 RVA: 0x004D3037 File Offset: 0x004D1237
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ReceiveMonthCardDataEvent, new Action(this.OnReceiveMonthCardData));
		Singleton<EventSystem>.Instance.Remove(EEventName.SdkPayEnd, new <>f__AnonymousDelegate2<ESdkDialogResult>(this.CheckIfNeedShowPlayStationStoreIcon));
	}

	// Token: 0x06011977 RID: 72055 RVA: 0x004D306E File Offset: 0x004D126E
	private void CheckIfNeedShowPlayStationStoreIcon(ESdkDialogResult eSdkDialogResult = ESdkDialogResult.No)
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk == null)
		{
			return;
		}
		platformSdk.ShowPlayStationStoreIcon(0);
	}

	// Token: 0x06011978 RID: 72056 RVA: 0x004D3088 File Offset: 0x004D1288
	protected override void OnAfterShow()
	{
		UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
		((tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null).PlayLevelSequenceByName("Start", false, null, false);
		ModelBase<MonthCardModel>.Instance.RefreshNextShowPayButtonRedDotTime();
		this.QueryProductPriceAndRefresh().Forget();
	}

	// Token: 0x06011979 RID: 72057 RVA: 0x004D30D4 File Offset: 0x004D12D4
	private UniTask QueryProductPriceAndRefresh()
	{
		MonthCardView.<QueryProductPriceAndRefresh>d__25 <QueryProductPriceAndRefresh>d__;
		<QueryProductPriceAndRefresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<QueryProductPriceAndRefresh>d__.<>4__this = this;
		<QueryProductPriceAndRefresh>d__.<>1__state = -1;
		<QueryProductPriceAndRefresh>d__.<>t__builder.Start<MonthCardView.<QueryProductPriceAndRefresh>d__25>(ref <QueryProductPriceAndRefresh>d__);
		return <QueryProductPriceAndRefresh>d__.<>t__builder.Task;
	}

	// Token: 0x0601197A RID: 72058 RVA: 0x004D3118 File Offset: 0x004D1318
	private void RefreshRemainDays()
	{
		bool flag = ModelBase<MonthCardModel>.Instance.GetRemainDays() >= 0;
		base.GetItem(0).SetUIActive(flag);
		base.GetText(1).SetUIActive(flag);
		if (flag)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(ModelBase<MonthCardModel>.Instance.GetRemainDayText("f55e66"), true);
		}
	}

	// Token: 0x0601197B RID: 72059 RVA: 0x004D3174 File Offset: 0x004D1374
	public void RefreshView()
	{
		this.RefreshRemainDays();
		this.RefreshBuyInfo();
	}

	// Token: 0x0601197C RID: 72060 RVA: 0x004D3184 File Offset: 0x004D1384
	private void RefreshBuyInfo()
	{
		bool flag = ModelBase<MonthCardModel>.Instance.IsRemainDayInMaxLimit();
		UUIItem item = base.GetItem(8);
		UUIItem item2 = base.GetItem(7);
		if (flag)
		{
			this.CanBuyMonthCard = true;
			this.BuyButtonItem.RefreshEnable(true);
			this.BuyButtonItem.SetActive(true);
			item2.SetUIActive(true);
			item.SetUIActive(false);
			TotalTopUpPayAdditiveTagItem totalTopUpTagItem = this.TotalTopUpTagItem;
			if (totalTopUpTagItem == null)
			{
				return;
			}
			totalTopUpTagItem.RefreshByGoodsId(42);
			return;
		}
		else
		{
			this.CanBuyMonthCard = false;
			this.BuyButtonItem.RefreshEnable(false);
			this.BuyButtonItem.SetActive(false);
			item2.SetUIActive(false);
			item.SetUIActive(true);
			TotalTopUpPayAdditiveTagItem totalTopUpTagItem2 = this.TotalTopUpTagItem;
			if (totalTopUpTagItem2 == null)
			{
				return;
			}
			totalTopUpTagItem2.SetUiActive(false);
			return;
		}
	}

	// Token: 0x0601197E RID: 72062 RVA: 0x004D3233 File Offset: 0x004D1433
	[CompilerGenerated]
	internal static void <CheckSdkProductInfoConfirmIfCanShow>g__confirmCallback|12_0()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.PayShopRootView, null);
	}

	// Token: 0x04008999 RID: 35225
	private ButtonAndTextItem BuyButtonItem;

	// Token: 0x0400899A RID: 35226
	private GetItemPanel OnceRewardItem;

	// Token: 0x0400899B RID: 35227
	private GetItemPanel DailyRewardItem;

	// Token: 0x0400899C RID: 35228
	private TotalTopUpPayAdditiveTagItem TotalTopUpTagItem;

	// Token: 0x0400899D RID: 35229
	private bool CanBuyMonthCard;

	// Token: 0x0400899E RID: 35230
	private const int MONTH_CARD_HELP_ID = 9;

	// Token: 0x020086BA RID: 34490
	[NullableContext(0)]
	private enum EMonthlyCardComponents
	{
		// Token: 0x0402D925 RID: 186661
		TextReceived,
		// Token: 0x0402D926 RID: 186662
		TextRemaining,
		// Token: 0x0402D927 RID: 186663
		ButtonHelp,
		// Token: 0x0402D928 RID: 186664
		TextPrice,
		// Token: 0x0402D929 RID: 186665
		ButtonBuy,
		// Token: 0x0402D92A RID: 186666
		OnceRewardItem,
		// Token: 0x0402D92B RID: 186667
		DailyRewardItem,
		// Token: 0x0402D92C RID: 186668
		TextRepeatBuy,
		// Token: 0x0402D92D RID: 186669
		PanelBuyLimit,
		// Token: 0x0402D92E RID: 186670
		TextDesc,
		// Token: 0x0402D92F RID: 186671
		CloudGameDesc,
		// Token: 0x0402D930 RID: 186672
		CloudGameIcon,
		// Token: 0x0402D931 RID: 186673
		TotalTopUpTagRoot
	}
}
