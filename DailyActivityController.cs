using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001A95 RID: 6805
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class DailyActivityController : UiControllerBase<DailyActivityController>
{
	// Token: 0x0600C2EA RID: 49898 RVA: 0x00335D00 File Offset: 0x00333F00
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0600C2EB RID: 49899 RVA: 0x00335D04 File Offset: 0x00333F04
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<LivenessUpdateNotify>(ENotifyMessageId.LivenessUpdateNotify, new Action<LivenessUpdateNotify, Net.CallbackStatus>(this.OnReceiveDailyActivityUpdateNotify));
		Singleton<Net>.Instance.Register<LivenessRefreshNotify>(ENotifyMessageId.LivenessRefreshNotify, new Action<LivenessRefreshNotify, Net.CallbackStatus>(this.OnReceiveDailyActivityRefreshNotify));
		Singleton<Net>.Instance.Register<LivenessCountUpdateNotify>(ENotifyMessageId.LivenessCountUpdateNotify, new Action<LivenessCountUpdateNotify, Net.CallbackStatus>(this.OnReceiveDailyActivityValueNotify));
	}

	// Token: 0x0600C2EC RID: 49900 RVA: 0x00335D65 File Offset: 0x00333F65
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LivenessUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LivenessRefreshNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LivenessCountUpdateNotify);
	}

	// Token: 0x0600C2ED RID: 49901 RVA: 0x00335D97 File Offset: 0x00333F97
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(this.OnCrossDay));
	}

	// Token: 0x0600C2EE RID: 49902 RVA: 0x00335DD1 File Offset: 0x00333FD1
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(this.OnCrossDay));
	}

	// Token: 0x0600C2EF RID: 49903 RVA: 0x00335E0B File Offset: 0x0033400B
	private void OnLoadingNetDataDone()
	{
		ModelBase<DailyActivityModel>.Instance.InitGoalData();
		this.RequestDailyActivityData().Forget<bool>();
	}

	// Token: 0x0600C2F0 RID: 49904 RVA: 0x00335E22 File Offset: 0x00334022
	private void OnCrossDay()
	{
		this.RequestDailyActivityData().ContinueWith(delegate(bool success)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.DailyUpdateNotify);
		}).Forget();
	}

	// Token: 0x0600C2F1 RID: 49905 RVA: 0x00335E54 File Offset: 0x00334054
	[NullableContext(0)]
	public UniTask<bool> RequestDailyActivityData()
	{
		DailyActivityController.<RequestDailyActivityData>d__7 <RequestDailyActivityData>d__;
		<RequestDailyActivityData>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestDailyActivityData>d__.<>1__state = -1;
		<RequestDailyActivityData>d__.<>t__builder.Start<DailyActivityController.<RequestDailyActivityData>d__7>(ref <RequestDailyActivityData>d__);
		return <RequestDailyActivityData>d__.<>t__builder.Task;
	}

	// Token: 0x0600C2F2 RID: 49906 RVA: 0x00335E90 File Offset: 0x00334090
	[NullableContext(0)]
	public UniTask<bool> RequestDailyActivityTaskRewardAsync([Nullable(1)] List<int> taskIds)
	{
		DailyActivityController.<RequestDailyActivityTaskRewardAsync>d__8 <RequestDailyActivityTaskRewardAsync>d__;
		<RequestDailyActivityTaskRewardAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestDailyActivityTaskRewardAsync>d__.taskIds = taskIds;
		<RequestDailyActivityTaskRewardAsync>d__.<>1__state = -1;
		<RequestDailyActivityTaskRewardAsync>d__.<>t__builder.Start<DailyActivityController.<RequestDailyActivityTaskRewardAsync>d__8>(ref <RequestDailyActivityTaskRewardAsync>d__);
		return <RequestDailyActivityTaskRewardAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C2F3 RID: 49907 RVA: 0x00335ED4 File Offset: 0x003340D4
	public void RequestDailyActivityReward(List<int> goalIds, [Nullable(2)] Action onRewardClose = null)
	{
		DailyActivityController.<>c__DisplayClass9_0 CS$<>8__locals1 = new DailyActivityController.<>c__DisplayClass9_0();
		CS$<>8__locals1.onRewardClose = onRewardClose;
		LivenessTakeRequest livenessTakeRequest = LivenessTakeRequest.Create();
		livenessTakeRequest.Ids.AddRange(goalIds);
		Singleton<Net>.Instance.Call<LivenessTakeResponse>(ERequestMessageId.LivenessTakeRequest, livenessTakeRequest, new Action<LivenessTakeResponse, Net.CallbackStatus>(CS$<>8__locals1.<RequestDailyActivityReward>g__responseAction|0), 0);
	}

	// Token: 0x0600C2F4 RID: 49908 RVA: 0x00335F1D File Offset: 0x0033411D
	private void OnReceiveDailyActivityUpdateNotify(LivenessUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<DailyActivityModel>.Instance.UpdateDailyActivityData(notify.LivenessInfo);
	}

	// Token: 0x0600C2F5 RID: 49909 RVA: 0x00335F2F File Offset: 0x0033412F
	private void OnReceiveDailyActivityRefreshNotify(LivenessRefreshNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<DailyActivityModel>.Instance.RefreshDailyActivityData(notify.LivenessInfo);
	}

	// Token: 0x0600C2F6 RID: 49910 RVA: 0x00335F41 File Offset: 0x00334141
	private void OnReceiveDailyActivityValueNotify(LivenessCountUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<DailyActivityModel>.Instance.RefreshActivityValue(notify.LivenessCount);
	}

	// Token: 0x0600C2F7 RID: 49911 RVA: 0x00335F54 File Offset: 0x00334154
	public void RequestAllAvailableActivityReward()
	{
		Dictionary<int, DailyActivityDefine.IActivityGoalData> dailyActivityGoalMap = ModelBase<DailyActivityModel>.Instance.DailyActivityGoalMap;
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, DailyActivityDefine.IActivityGoalData> keyValuePair in dailyActivityGoalMap)
		{
			int key = keyValuePair.Key;
			if (keyValuePair.Value.State == EDailyActiveState.FinishedAndNotTaken)
			{
				list.Add(key);
			}
		}
		this.RequestDailyActivityReward(list, null);
	}
}
