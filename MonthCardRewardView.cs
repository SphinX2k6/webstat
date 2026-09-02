using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023A6 RID: 9126
public class MonthCardRewardView : UiViewBase
{
	// Token: 0x0601195F RID: 72031 RVA: 0x004D2864 File Offset: 0x004D0A64
	[NullableContext(1)]
	public MonthCardRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011960 RID: 72032 RVA: 0x004D2870 File Offset: 0x004D0A70
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedClose));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011961 RID: 72033 RVA: 0x004D2916 File Offset: 0x004D0B16
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.ReceiveMonthCardDataEvent, new Action(this.OnRefreshView));
	}

	// Token: 0x06011962 RID: 72034 RVA: 0x004D2934 File Offset: 0x004D0B34
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ReceiveMonthCardDataEvent, new Action(this.OnRefreshView));
	}

	// Token: 0x06011963 RID: 72035 RVA: 0x004D2954 File Offset: 0x004D0B54
	private void OnClickedClose()
	{
		MonthCardRewardView.<>c__DisplayClass7_0 CS$<>8__locals1 = new MonthCardRewardView.<>c__DisplayClass7_0();
		UiInteractLogReport.ReportSpaceKeyInteract(EUiInteractSpaceKeyType.MouthCard);
		RewardItemData item = new RewardItemData(this.RewardId, this.RewardCount, null, EDropItemType.Normal);
		List<RewardItemData> rewardItemDataList = new List<RewardItemData>
		{
			item
		};
		int monthCardRewardId = ConfigBase<PayShopConfig>.Instance.GetMonthCardRewardId();
		CS$<>8__locals1.isBySplashScreen = (bool)this.OpenParam;
		ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(monthCardRewardId, rewardItemDataList, new Action(CS$<>8__locals1.<OnClickedClose>g__closeCallback|0));
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x06011964 RID: 72036 RVA: 0x004D29E4 File Offset: 0x004D0BE4
	protected override void OnBeforeShow()
	{
		TItem? localDailyReward = ModelBase<MonthCardModel>.Instance.LocalDailyReward;
		this.RewardId = localDailyReward.Value.ItemData.ItemId;
		this.RewardCount = localDailyReward.Value.Count;
		this.RefreshView();
		this.UiViewSequence.PlaySequence("Loop", false, null);
	}

	// Token: 0x06011965 RID: 72037 RVA: 0x004D2A45 File Offset: 0x004D0C45
	private void OnRefreshView()
	{
		this.RefreshView();
	}

	// Token: 0x06011966 RID: 72038 RVA: 0x004D2A50 File Offset: 0x004D0C50
	private void RefreshView()
	{
		ModelBase<MonthCardModel>.Instance.CanShowDailyRewardView = false;
		base.GetText(1).SetText(ModelBase<MonthCardModel>.Instance.GetRemainDays().ToString(), true);
	}

	// Token: 0x04008997 RID: 35223
	private int RewardId;

	// Token: 0x04008998 RID: 35224
	private int RewardCount;

	// Token: 0x020086B8 RID: 34488
	private enum EMonthCardRewardViewComponents
	{
		// Token: 0x0402D921 RID: 186657
		CloseButton,
		// Token: 0x0402D922 RID: 186658
		RemainDaysText
	}
}
