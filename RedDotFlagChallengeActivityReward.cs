using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FlagChallenge;

// Token: 0x02003330 RID: 13104
public class RedDotFlagChallengeActivityReward : RedDotBase
{
	// Token: 0x0601B659 RID: 112217 RVA: 0x00836327 File Offset: 0x00834527
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnFlagChallengeTaskUpdate, new Action<int>(this.OnFlagChallengeTaskUpdate));
	}

	// Token: 0x0601B65A RID: 112218 RVA: 0x00836345 File Offset: 0x00834545
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeTaskUpdate, new Action<int>(this.OnFlagChallengeTaskUpdate));
	}

	// Token: 0x0601B65B RID: 112219 RVA: 0x00836364 File Offset: 0x00834564
	protected override bool OnCheck(int uId = 0)
	{
		FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(uId);
		return flagChallengeData != null && flagChallengeData.HasCanReceiveTask();
	}

	// Token: 0x0601B65C RID: 112220 RVA: 0x00836388 File Offset: 0x00834588
	private void OnFlagChallengeTaskUpdate(int activityId)
	{
		base.EventCheck();
	}
}
