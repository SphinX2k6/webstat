using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RacingBets.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002742 RID: 10050
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsRewardView : UiTickViewBase
{
	// Token: 0x06013D8E RID: 81294 RVA: 0x00588246 File Offset: 0x00586446
	public RacingBetsRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013D8F RID: 81295 RVA: 0x00588250 File Offset: 0x00586450
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickCloseBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013D90 RID: 81296 RVA: 0x005883BE File Offset: 0x005865BE
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsRewardRefresh, new Action(this.RefreshView));
		Singleton<EventSystem>.Instance.Add<RacingBetsSeasonData>(EEventName.OnRacingBetsDataRefresh, new Action<RacingBetsSeasonData>(this.RefreshView));
	}

	// Token: 0x06013D91 RID: 81297 RVA: 0x005883F8 File Offset: 0x005865F8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsRewardRefresh, new Action(this.RefreshView));
		Singleton<EventSystem>.Instance.Remove<RacingBetsSeasonData>(EEventName.OnRacingBetsDataRefresh, new Action<RacingBetsSeasonData>(this.RefreshView));
	}

	// Token: 0x06013D92 RID: 81298 RVA: 0x00588432 File Offset: 0x00586632
	protected override void OnTick(float _)
	{
		this.RefreshTimeText();
	}

	// Token: 0x06013D93 RID: 81299 RVA: 0x0058843C File Offset: 0x0058663C
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsRewardView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsRewardView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013D94 RID: 81300 RVA: 0x00588480 File Offset: 0x00586680
	protected override void OnStart()
	{
		double num = Singleton<TimeUtil>.Instance.SetTimeSecond(Singleton<TimeUtil>.Instance.GetNextDayTimeStamp());
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double remainTime = num - serverTime;
		LguiUtil instance = Singleton<LguiUtil>.Instance;
		UUIText text = base.GetText(4);
		string textStringId = "Dango_DailyTask_Countdown";
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(remainTime);
		instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlySingleElementList<object>(((remainTimeDataFormat != null) ? remainTimeDataFormat.CountDownText : null) ?? ""));
	}

	// Token: 0x06013D95 RID: 81301 RVA: 0x005884EA File Offset: 0x005866EA
	private void RefreshView()
	{
		this.RefreshView(null);
	}

	// Token: 0x06013D96 RID: 81302 RVA: 0x005884F4 File Offset: 0x005866F4
	private void RefreshView(RacingBetsSeasonData data)
	{
		if (this.CurGroupRewardData == null)
		{
			return;
		}
		foreach (RacingBetsRewardTabItem racingBetsRewardTabItem in this.TabLayout.GetLayoutItemList())
		{
			racingBetsRewardTabItem.RefreshItem();
		}
		List<RacingBetsRewardData> rewardDataList = this.CurGroupRewardData.GetRewardDataList();
		this.RewardLayout.RefreshByData(rewardDataList, null, false);
	}

	// Token: 0x06013D97 RID: 81303 RVA: 0x0058856C File Offset: 0x0058676C
	private void RefreshTimeText()
	{
		UUIText text = base.GetText(4);
		if (this.CurGroupRewardData == null)
		{
			text.SetUIActive(false);
			return;
		}
		double num = Singleton<TimeUtil>.Instance.SetTimeSecond(Singleton<TimeUtil>.Instance.GetNextDayTimeStamp());
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double remainTime = num - serverTime;
		LguiUtil instance = Singleton<LguiUtil>.Instance;
		UUIText uiText = text;
		string textStringId = "Dango_DailyTask_Countdown";
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(remainTime);
		instance.SetLocalTextNew(uiText, textStringId, new <>z__ReadOnlySingleElementList<object>(((remainTimeDataFormat != null) ? remainTimeDataFormat.CountDownText : null) ?? ""));
		text.SetUIActive(true);
	}

	// Token: 0x06013D98 RID: 81304 RVA: 0x005885EF File Offset: 0x005867EF
	private RacingBetsRewardItem RewardItemProxyCreate()
	{
		RacingBetsRewardItem racingBetsRewardItem = new RacingBetsRewardItem();
		racingBetsRewardItem.BindClickGetButtonCallBack(new Action(this.OnClickGetButton));
		return racingBetsRewardItem;
	}

	// Token: 0x06013D99 RID: 81305 RVA: 0x00588608 File Offset: 0x00586808
	private RacingBetsRewardTabItem TabItemProxyCreate()
	{
		RacingBetsRewardTabItem racingBetsRewardTabItem = new RacingBetsRewardTabItem();
		racingBetsRewardTabItem.BindClickToggleCallBack(new Action<RacingBetsGroupRewardData>(this.OnClickTabToggle));
		return racingBetsRewardTabItem;
	}

	// Token: 0x06013D9A RID: 81306 RVA: 0x00588624 File Offset: 0x00586824
	private void OnClickTabToggle(RacingBetsGroupRewardData groupData)
	{
		if (this.CurGroupRewardData == groupData)
		{
			return;
		}
		this.CurGroupRewardData = groupData;
		int gridIndex = this.GroupDataList.FindIndex((RacingBetsGroupRewardData data) => data == groupData);
		this.TabLayout.SelectGridProxy(gridIndex, false);
		List<RacingBetsRewardData> rewardDataList = groupData.GetRewardDataList();
		this.RewardLayout.RefreshByData(rewardDataList, null, false);
		this.RefreshTimeText();
	}

	// Token: 0x06013D9B RID: 81307 RVA: 0x005886A0 File Offset: 0x005868A0
	private void OnClickGetButton()
	{
		List<int> list = new List<int>();
		RacingBetsGroupRewardData curGroupRewardData = this.CurGroupRewardData;
		List<RacingBetsRewardData> list2 = (curGroupRewardData != null) ? curGroupRewardData.GetRewardDataList() : null;
		if (list2 != null)
		{
			foreach (RacingBetsRewardData racingBetsRewardData in list2)
			{
				if (racingBetsRewardData.CanReceiveReward())
				{
					list.Add(racingBetsRewardData.Id);
				}
			}
		}
		ControllerBase<RacingBetsController>.Instance.RacingBetsRepeatedTaskRewardRequest(list);
	}

	// Token: 0x06013D9C RID: 81308 RVA: 0x00588724 File Offset: 0x00586924
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x04009A66 RID: 39526
	[Nullable(2)]
	private RacingBetsGroupRewardData CurGroupRewardData;

	// Token: 0x04009A67 RID: 39527
	private List<RacingBetsGroupRewardData> GroupDataList;

	// Token: 0x04009A68 RID: 39528
	private GenericLayout<RacingBetsRewardTabItem, RacingBetsGroupRewardData> TabLayout;

	// Token: 0x04009A69 RID: 39529
	private GenericLayout<RacingBetsRewardItem, RacingBetsRewardData> RewardLayout;

	// Token: 0x02008B08 RID: 35592
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402EE49 RID: 192073
		CloseBtn,
		// Token: 0x0402EE4A RID: 192074
		TogLayout,
		// Token: 0x0402EE4B RID: 192075
		RewardLayout,
		// Token: 0x0402EE4C RID: 192076
		ContentItem,
		// Token: 0x0402EE4D RID: 192077
		TimeText,
		// Token: 0x0402EE4E RID: 192078
		MaskButton,
		// Token: 0x0402EE4F RID: 192079
		TitleText
	}
}
