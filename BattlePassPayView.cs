using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200237E RID: 9086
[NullableContext(1)]
[Nullable(0)]
public class BattlePassPayView : UiViewBase
{
	// Token: 0x06011692 RID: 71314 RVA: 0x004CC2A5 File Offset: 0x004CA4A5
	public BattlePassPayView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011693 RID: 71315 RVA: 0x004CC2B0 File Offset: 0x004CA4B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 16;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickPrimaryPayBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickHighPayBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickExitBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickDetailBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011694 RID: 71316 RVA: 0x004CC598 File Offset: 0x004CA798
	protected override UniTask OnBeforeStartAsync()
	{
		BattlePassPayView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BattlePassPayView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011695 RID: 71317 RVA: 0x004CC5D4 File Offset: 0x004CA7D4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnReceiveBattlePassPaid, new Action(this.OnClickExitBtn));
		Singleton<EventSystem>.Instance.Add<ESdkDialogResult>(EEventName.SdkPayEnd, new Action<ESdkDialogResult>(this.SdkPayEnd));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x06011696 RID: 71318 RVA: 0x004CC648 File Offset: 0x004CA848
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnReceiveBattlePassPaid, new Action(this.OnClickExitBtn));
		Singleton<EventSystem>.Instance.Remove(EEventName.SdkPayEnd, new Action<ESdkDialogResult>(this.SdkPayEnd));
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x06011697 RID: 71319 RVA: 0x004CC6BB File Offset: 0x004CA8BB
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName != EUiViewName.SdkPayProductInformationView)
		{
			PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
			if (platformSdk == null)
			{
				return;
			}
			platformSdk.ShowPlayStationStoreIcon(0);
		}
	}

	// Token: 0x06011698 RID: 71320 RVA: 0x004CC6DF File Offset: 0x004CA8DF
	private void OnOpenView(EUiViewName viewName, int viewId)
	{
		if (viewName != EUiViewName.SdkPayProductInformationView)
		{
			Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().HidePlayStationStoreIcon();
		}
	}

	// Token: 0x06011699 RID: 71321 RVA: 0x004CC6FD File Offset: 0x004CA8FD
	private void OnClickExitBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601169A RID: 71322 RVA: 0x004CC706 File Offset: 0x004CA906
	private void SdkPayEnd(ESdkDialogResult eSdkDialogResult)
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk == null)
		{
			return;
		}
		platformSdk.ShowPlayStationStoreIcon(0);
	}

	// Token: 0x0601169B RID: 71323 RVA: 0x004CC71D File Offset: 0x004CA91D
	private void OnClickPrimaryPayBtn()
	{
		ControllerBase<BattlePassController>.Instance.PayPrimaryBattlePass();
	}

	// Token: 0x0601169C RID: 71324 RVA: 0x004CC729 File Offset: 0x004CA929
	private void OnClickHighPayBtn()
	{
		ControllerBase<BattlePassController>.Instance.PayHighBattlePass();
	}

	// Token: 0x0601169D RID: 71325 RVA: 0x004CC738 File Offset: 0x004CA938
	private void OnClickDetailBtn()
	{
		WeaponPreviewViewParam param = new WeaponPreviewViewParam
		{
			WeaponDataList = ModelBase<BattlePassModel>.Instance.GetWeaponDataList().ToArray(),
			SelectedIndex = 0,
			WeaponObservers = (this.OpenParam as WeaponSkeletalObserverHandles)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponPreviewView, param, null);
	}

	// Token: 0x0601169E RID: 71326 RVA: 0x004CC78C File Offset: 0x004CA98C
	protected override void OnStart()
	{
		this.PrimaryRewardList = new List<TItem>();
		this.HighRewardList = new List<TItem>();
		ConfigBase<BattlePassConfig>.Instance.GetBattlePassUnlockReward(EBattlePassUnlockType.Primary, this.PrimaryRewardList);
		ConfigBase<BattlePassConfig>.Instance.GetBattlePassUnlockReward(EBattlePassUnlockType.Upgrade, this.HighRewardList);
		this.PrimaryGridLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetGridLayout(1), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, true);
		this.HighGridLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetGridLayout(4), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, true);
		this.PrimaryGridLayout.RefreshByData(this.PrimaryRewardList, null, false);
		this.HighGridLayout.RefreshByData(this.HighRewardList, null, false);
		this.PassEndTime = ModelBase<BattlePassModel>.Instance.GetBattlePassEndTime();
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.RefreshLeftTime), 1000f, 1f, null, null, true);
		this.RefreshLeftTime(0f);
		this.RefreshButtonView();
		this.CheckSdkProductInfoConfirmIfCanShow();
	}

	// Token: 0x0601169F RID: 71327 RVA: 0x004CC88A File Offset: 0x004CAA8A
	protected override void OnBeforeShow()
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk == null)
		{
			return;
		}
		platformSdk.ShowPlayStationStoreIcon(0);
	}

	// Token: 0x060116A0 RID: 71328 RVA: 0x004CC8A1 File Offset: 0x004CAAA1
	protected override void OnAfterShow()
	{
		this.QueryProductPriceAndRefresh().Forget();
	}

	// Token: 0x060116A1 RID: 71329 RVA: 0x004CC8B0 File Offset: 0x004CAAB0
	private UniTask QueryProductPriceAndRefresh()
	{
		BattlePassPayView.<QueryProductPriceAndRefresh>d__23 <QueryProductPriceAndRefresh>d__;
		<QueryProductPriceAndRefresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<QueryProductPriceAndRefresh>d__.<>4__this = this;
		<QueryProductPriceAndRefresh>d__.<>1__state = -1;
		<QueryProductPriceAndRefresh>d__.<>t__builder.Start<BattlePassPayView.<QueryProductPriceAndRefresh>d__23>(ref <QueryProductPriceAndRefresh>d__);
		return <QueryProductPriceAndRefresh>d__.<>t__builder.Task;
	}

	// Token: 0x060116A2 RID: 71330 RVA: 0x004CC8F4 File Offset: 0x004CAAF4
	private bool CheckSdkProductInfoConfirmIfCanShow()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().NeedConfirmSdkProductInfo())
		{
			foreach (int id in this.GetNeedRequestGoodId())
			{
				string productId = ModelBase<PayGiftModel>.Instance.GetPayGiftDataById(id).ProductId;
				if (ModelBase<PayItemModel>.Instance.GetProductInfoByGoodsId(productId) == null)
				{
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CannotFindSdkProduct);
					confirmBoxDataNew.FunctionMap.Add(1, new Action(BattlePassPayView.<CheckSdkProductInfoConfirmIfCanShow>g__confirmCallback|24_0));
					confirmBoxDataNew.IsEscViewTriggerCallBack = false;
					ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
					this.OpenThirdPartyMessageBox().Forget();
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060116A3 RID: 71331 RVA: 0x004CC994 File Offset: 0x004CAB94
	private UniTask OpenThirdPartyMessageBox()
	{
		BattlePassPayView.<OpenThirdPartyMessageBox>d__25 <OpenThirdPartyMessageBox>d__;
		<OpenThirdPartyMessageBox>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenThirdPartyMessageBox>d__.<>1__state = -1;
		<OpenThirdPartyMessageBox>d__.<>t__builder.Start<BattlePassPayView.<OpenThirdPartyMessageBox>d__25>(ref <OpenThirdPartyMessageBox>d__);
		return <OpenThirdPartyMessageBox>d__.<>t__builder.Task;
	}

	// Token: 0x060116A4 RID: 71332 RVA: 0x004CC9CF File Offset: 0x004CABCF
	private int[] GetNeedRequestGoodId()
	{
		return new int[]
		{
			ModelBase<BattlePassModel>.Instance.GetPrimaryBattlePassGoodsId(),
			ModelBase<BattlePassModel>.Instance.GetHighBattlePassGoodsId(),
			ModelBase<BattlePassModel>.Instance.GetSupplyBattlePassGoodsId()
		};
	}

	// Token: 0x060116A5 RID: 71333 RVA: 0x004CC9FE File Offset: 0x004CABFE
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x060116A6 RID: 71334 RVA: 0x004CCA05 File Offset: 0x004CAC05
	protected override void OnBeforeHide()
	{
		Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().HidePlayStationStoreIcon();
	}

	// Token: 0x060116A7 RID: 71335 RVA: 0x004CCA18 File Offset: 0x004CAC18
	protected override void OnBeforeDestroy()
	{
		this.PrimaryRewardList.Clear();
		this.PrimaryRewardList = null;
		this.HighRewardList.Clear();
		this.HighRewardList = null;
		this.PrimaryGridLayout = null;
		this.HighGridLayout = null;
		this.TimerHandle.Remove();
		this.TimerHandle = null;
		Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().HidePlayStationStoreIcon();
	}

	// Token: 0x060116A8 RID: 71336 RVA: 0x004CCA7C File Offset: 0x004CAC7C
	private void RefreshButtonView()
	{
		BattlePassPayStatus payType = ModelBase<BattlePassModel>.Instance.PayType;
		base.GetItem(9).SetUIActive(payType == BattlePassPayStatus.NoPaid);
		base.GetItem(11).SetUIActive(payType > BattlePassPayStatus.NoPaid);
		base.GetItem(10).SetUIActive(payType != BattlePassPayStatus.Advanced);
		base.GetItem(12).SetUIActive(payType == BattlePassPayStatus.Advanced);
		if (payType == BattlePassPayStatus.NoPaid)
		{
			PayShopGoods payShopGoodsById = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(ModelBase<BattlePassModel>.Instance.GetPrimaryBattlePassGoodsId());
			string text = (payShopGoodsById != null) ? payShopGoodsById.GetDirectPriceText() : null;
			base.GetText(2).SetText(text ?? "", true);
			PayShopGoods payShopGoodsById2 = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(ModelBase<BattlePassModel>.Instance.GetHighBattlePassGoodsId());
			string text2 = (payShopGoodsById2 != null) ? payShopGoodsById2.GetDirectPriceText() : null;
			base.GetText(5).SetText(text2 ?? "", true);
		}
		else if (payType == BattlePassPayStatus.Paid)
		{
			PayShopGoods payShopGoodsById3 = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(ModelBase<BattlePassModel>.Instance.GetSupplyBattlePassGoodsId());
			string text3 = (payShopGoodsById3 != null) ? payShopGoodsById3.GetDirectPriceText() : null;
			base.GetText(5).SetText(text3 ?? "", true);
		}
		this.RefreshCloudGameInfo();
	}

	// Token: 0x060116A9 RID: 71337 RVA: 0x004CCB94 File Offset: 0x004CAD94
	private void RefreshCloudGameInfo()
	{
		UUIText text = base.GetText(13);
		UUIText text2 = base.GetText(14);
		UUIItem item = base.GetItem(15);
		BattlePassPayStatus payType = ModelBase<BattlePassModel>.Instance.PayType;
		PayShopGoods payShopGoodsById = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(ModelBase<BattlePassModel>.Instance.GetPrimaryBattlePassGoodsId());
		if (!payShopGoodsById.HasCloudGameInfo())
		{
			text.SetUIActive(false);
			text2.SetUIActive(false);
			item.SetUIActive(false);
			return;
		}
		int id = (payType == BattlePassPayStatus.Paid) ? ModelBase<BattlePassModel>.Instance.GetSupplyBattlePassGoodsId() : ModelBase<BattlePassModel>.Instance.GetHighBattlePassGoodsId();
		PayShopGoods payShopGoodsById2 = ModelBase<PayGiftModel>.Instance.GetPayShopGoodsById(id);
		text.SetUIActive(payType != BattlePassPayStatus.Advanced);
		text2.SetUIActive(true);
		item.SetUIActive(true);
		text.SetText(payShopGoodsById.GetCloudGameDesc(), true);
		text2.SetText(payShopGoodsById2.GetCloudGameDesc(), true);
	}

	// Token: 0x060116AA RID: 71338 RVA: 0x004CCC60 File Offset: 0x004CAE60
	public void RefreshLeftTime(float _)
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = (double)this.PassEndTime - serverTime;
		if (num < 0.0)
		{
			return;
		}
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(num);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "Text_GachaRemainingTime_Text", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText));
	}

	// Token: 0x060116AB RID: 71339 RVA: 0x004CCCBC File Offset: 0x004CAEBC
	[CompilerGenerated]
	internal static void <CheckSdkProductInfoConfirmIfCanShow>g__confirmCallback|24_0()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.BattlePassPayView, null);
	}

	// Token: 0x040088B0 RID: 34992
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> PrimaryGridLayout;

	// Token: 0x040088B1 RID: 34993
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> HighGridLayout;

	// Token: 0x040088B2 RID: 34994
	[Nullable(2)]
	private List<TItem> PrimaryRewardList;

	// Token: 0x040088B3 RID: 34995
	[Nullable(2)]
	private List<TItem> HighRewardList;

	// Token: 0x040088B4 RID: 34996
	private long PassEndTime;

	// Token: 0x040088B5 RID: 34997
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x040088B6 RID: 34998
	private const int PLAYSTATIONICONPOSITION = 0;

	// Token: 0x02008694 RID: 34452
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402D850 RID: 186448
		ExitBtn,
		// Token: 0x0402D851 RID: 186449
		PrimaryGrid,
		// Token: 0x0402D852 RID: 186450
		PrimaryPrice,
		// Token: 0x0402D853 RID: 186451
		PrimaryPayBtn,
		// Token: 0x0402D854 RID: 186452
		HighGrid,
		// Token: 0x0402D855 RID: 186453
		HighPrice,
		// Token: 0x0402D856 RID: 186454
		HighPayBtn,
		// Token: 0x0402D857 RID: 186455
		TxtCountDown,
		// Token: 0x0402D858 RID: 186456
		DetailBtn,
		// Token: 0x0402D859 RID: 186457
		PrimaryBuyItem,
		// Token: 0x0402D85A RID: 186458
		HighBuyItem,
		// Token: 0x0402D85B RID: 186459
		PrimaryDoneItem,
		// Token: 0x0402D85C RID: 186460
		HighDoneItem,
		// Token: 0x0402D85D RID: 186461
		PrimaryCloudGameDesc,
		// Token: 0x0402D85E RID: 186462
		HighCloudGameDesc,
		// Token: 0x0402D85F RID: 186463
		CloudGameTip
	}
}
