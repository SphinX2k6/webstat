using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032E3 RID: 13027
public class RedDotActivityRecallTaskEntryButton : RedDotBase
{
	// Token: 0x0601B503 RID: 111875 RVA: 0x00833BC7 File Offset: 0x00831DC7
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
	}

	// Token: 0x0601B504 RID: 111876 RVA: 0x00833C01 File Offset: 0x00831E01
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
	}

	// Token: 0x0601B505 RID: 111877 RVA: 0x00833C3C File Offset: 0x00831E3C
	protected override bool OnCheck(int uId = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		return activityData != null && (activityData.CheckHaveTaskRewardCanGet() || activityData.CheckRegressScoreRewardReached() || ModelBase<ActivityRegressModel>.Instance.ShouldShowDoubleDropRedDot() || activityData.HasReachableCultivateTask());
	}
}
