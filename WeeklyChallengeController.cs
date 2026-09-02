using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002D26 RID: 11558
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class WeeklyChallengeController : UiControllerBase<WeeklyChallengeController>
{
	// Token: 0x06017538 RID: 95544 RVA: 0x00677E4A File Offset: 0x0067604A
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x06017539 RID: 95545 RVA: 0x00677E4D File Offset: 0x0067604D
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<WeeklyFrameworkInfoUpdateNotify>(ENotifyMessageId.WeeklyFrameworkInfoUpdateNotify, new Action<WeeklyFrameworkInfoUpdateNotify, Net.CallbackStatus>(this.OnReceiveWeeklyFrameworkUpdateNotify));
	}

	// Token: 0x0601753A RID: 95546 RVA: 0x00677E6B File Offset: 0x0067606B
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.WeeklyFrameworkInfoUpdateNotify);
	}

	// Token: 0x0601753B RID: 95547 RVA: 0x00677E7D File Offset: 0x0067607D
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
	}

	// Token: 0x0601753C RID: 95548 RVA: 0x00677E9B File Offset: 0x0067609B
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
	}

	// Token: 0x0601753D RID: 95549 RVA: 0x00677EB9 File Offset: 0x006760B9
	private void OnLoadingNetDataDone()
	{
		ModelBase<WeeklyChallengeModel>.Instance.InitGoalData();
		this.RequestWeeklyFrameworkInfo().Forget<bool>();
	}

	// Token: 0x0601753E RID: 95550 RVA: 0x00677ED0 File Offset: 0x006760D0
	[NullableContext(0)]
	public UniTask<bool> RequestWeeklyFrameworkInfo()
	{
		WeeklyChallengeController.<RequestWeeklyFrameworkInfo>d__6 <RequestWeeklyFrameworkInfo>d__;
		<RequestWeeklyFrameworkInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestWeeklyFrameworkInfo>d__.<>1__state = -1;
		<RequestWeeklyFrameworkInfo>d__.<>t__builder.Start<WeeklyChallengeController.<RequestWeeklyFrameworkInfo>d__6>(ref <RequestWeeklyFrameworkInfo>d__);
		return <RequestWeeklyFrameworkInfo>d__.<>t__builder.Task;
	}

	// Token: 0x0601753F RID: 95551 RVA: 0x00677F0C File Offset: 0x0067610C
	public void RequestWeeklyFrameworkScoreReward(List<int> taskIds)
	{
		WeeklyChallengeController.<>c__DisplayClass7_0 CS$<>8__locals1 = new WeeklyChallengeController.<>c__DisplayClass7_0();
		CS$<>8__locals1.taskIds = taskIds;
		WeeklyFrameworkScoreRewardRequest weeklyFrameworkScoreRewardRequest = WeeklyFrameworkScoreRewardRequest.Create();
		weeklyFrameworkScoreRewardRequest.TaskIds.AddRange(CS$<>8__locals1.taskIds);
		Singleton<Net>.Instance.Call<WeeklyFrameworkScoreRewardResponse>(ERequestMessageId.WeeklyFrameworkScoreRewardRequest, weeklyFrameworkScoreRewardRequest, new Action<WeeklyFrameworkScoreRewardResponse, Net.CallbackStatus>(CS$<>8__locals1.<RequestWeeklyFrameworkScoreReward>g__ResponseAction|0), 0);
	}

	// Token: 0x06017540 RID: 95552 RVA: 0x00677F5A File Offset: 0x0067615A
	private void OnReceiveWeeklyFrameworkUpdateNotify(WeeklyFrameworkInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<WeeklyChallengeModel>.Instance.RefreshData(notify.FrameworkInfo);
	}
}
