using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001535 RID: 5429
[NullableContext(1)]
[Nullable(0)]
public class RegressBpPayView : UiViewBase
{
	// Token: 0x0600982E RID: 38958 RVA: 0x0027D6B0 File Offset: 0x0027B8B0
	public RegressBpPayView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600982F RID: 38959 RVA: 0x0027D6BC File Offset: 0x0027B8BC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnClose)),
			new ValueTuple<int, Delegate>(9, new Action(this.OnClickBtnGold))
		};
	}

	// Token: 0x06009830 RID: 38960 RVA: 0x0027D804 File Offset: 0x0027BA04
	protected override UniTask OnBeforeStartAsync()
	{
		RegressBpPayView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RegressBpPayView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009831 RID: 38961 RVA: 0x0027D847 File Offset: 0x0027BA47
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06009832 RID: 38962 RVA: 0x0027D865 File Offset: 0x0027BA65
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06009833 RID: 38963 RVA: 0x0027D883 File Offset: 0x0027BA83
	private void OnPayItemSuccess(PayItemSuccess notify)
	{
		base.CloseMe(null);
	}

	// Token: 0x06009834 RID: 38964 RVA: 0x0027D88C File Offset: 0x0027BA8C
	protected override void OnBeforeShow()
	{
		this.StartTimer();
		this.RefreshTitle();
		this.RefreshRewardLayout();
		this.RefreshPayInfo();
		base.GetItem(10).SetUIActive(false);
	}

	// Token: 0x06009835 RID: 38965 RVA: 0x0027D8B4 File Offset: 0x0027BAB4
	protected override void OnBeforeHide()
	{
		this.ClearTimer();
	}

	// Token: 0x06009836 RID: 38966 RVA: 0x0027D8BC File Offset: 0x0027BABC
	protected override void OnBeforeDestroy()
	{
		this.ClearTimer();
		this.RewardLayout = null;
	}

	// Token: 0x06009837 RID: 38967 RVA: 0x0027D8CB File Offset: 0x0027BACB
	private void OnClickBtnClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x06009838 RID: 38968 RVA: 0x0027D8D4 File Offset: 0x0027BAD4
	private void OnClickBtnGold()
	{
		int payGiftId = 46;
		ControllerBase<PayGiftController>.Instance.SdkPay(payGiftId);
	}

	// Token: 0x06009839 RID: 38969 RVA: 0x0027D8EF File Offset: 0x0027BAEF
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600983A RID: 38970 RVA: 0x0027D8F8 File Offset: 0x0027BAF8
	private void RefreshRewardLayout()
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		int? num = (activityData != null) ? new int?(activityData.Id) : null;
		if (num == null)
		{
			return;
		}
		RegressDisposableReward? regressDisposableReward = ConfigBase<ActivityRegressConfig>.Instance.GetRegressDisposableReward(num.Value);
		if (regressDisposableReward == null)
		{
			return;
		}
		List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(regressDisposableReward.Value.HighRewardPreviewId);
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		if (rewardLayout == null)
		{
			return;
		}
		rewardLayout.RefreshByData(dropPackagePreviewItemList, null, false);
	}

	// Token: 0x0600983B RID: 38971 RVA: 0x0027D980 File Offset: 0x0027BB80
	private void RefreshPayInfo()
	{
		UUIText text = base.GetText(7);
		UUIText text2 = base.GetText(8);
		if (text == null || text2 == null)
		{
			return;
		}
		PayGiftModel instance = ModelBase<PayGiftModel>.Instance;
		PayPackageData payPackageData = (instance != null) ? instance.GetPayGiftDataById(46) : null;
		if (payPackageData == null)
		{
			text.SetText("", true);
			text2.SetUIActive(false);
			return;
		}
		PayShopGoods payShopGoods = payPackageData.GetPayShopGoods();
		bool flag = payShopGoods.IsDirect();
		IPriceData priceData = payShopGoods.GetPriceData();
		if (flag)
		{
			text.SetText(payShopGoods.GetDirectPriceText(), true);
		}
		else
		{
			text.SetText(priceData.NowPrice.ToString(), true);
		}
		int? originalPrice = priceData.OriginalPrice;
		if (originalPrice == null)
		{
			text2.SetUIActive(false);
			return;
		}
		text2.SetUIActive(true);
		text2.SetText("<s>" + originalPrice.Value.ToString() + "</s>", true);
	}

	// Token: 0x0600983C RID: 38972 RVA: 0x0027DA53 File Offset: 0x0027BC53
	private void StartTimer()
	{
		this.ClearTimer();
		this.TimerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.OnTimerRefresh), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
	}

	// Token: 0x0600983D RID: 38973 RVA: 0x0027DA8C File Offset: 0x0027BC8C
	private void RefreshTitle()
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(activityData, null);
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		base.GetText(2).SetUIActive(item);
		if (item)
		{
			base.GetText(2).SetText(item2, true);
		}
	}

	// Token: 0x0600983E RID: 38974 RVA: 0x0027DADB File Offset: 0x0027BCDB
	private void OnTimerRefresh(float gap)
	{
		this.RefreshTitle();
	}

	// Token: 0x0600983F RID: 38975 RVA: 0x0027DAE3 File Offset: 0x0027BCE3
	private void ClearTimer()
	{
		if (TimerSystem.Instance.Has(this.TimerHandle))
		{
			TimerSystem.Instance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x04004680 RID: 18048
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04004681 RID: 18049
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x020078E7 RID: 30951
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040298E3 RID: 170211
		public const int BtnMask = 0;

		// Token: 0x040298E4 RID: 170212
		public const int BtnClose = 1;

		// Token: 0x040298E5 RID: 170213
		public const int TxtTime = 2;

		// Token: 0x040298E6 RID: 170214
		public const int TxtTitle = 3;

		// Token: 0x040298E7 RID: 170215
		public const int TxtDesc = 4;

		// Token: 0x040298E8 RID: 170216
		public const int PanelGrid = 5;

		// Token: 0x040298E9 RID: 170217
		public const int ItemReward = 6;

		// Token: 0x040298EA RID: 170218
		public const int TxtCost = 7;

		// Token: 0x040298EB RID: 170219
		public const int TxtDiscount = 8;

		// Token: 0x040298EC RID: 170220
		public const int BtnGold = 9;

		// Token: 0x040298ED RID: 170221
		public const int PanelRedDot = 10;
	}
}
