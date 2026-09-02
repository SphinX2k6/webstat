using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032E8 RID: 13032
public class RedDotActivityRegressConstantTask : RedDotBase
{
	// Token: 0x0601B516 RID: 111894 RVA: 0x00833DFA File Offset: 0x00831FFA
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B517 RID: 111895 RVA: 0x00833E18 File Offset: 0x00832018
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B518 RID: 111896 RVA: 0x00833E36 File Offset: 0x00832036
	protected override bool OnCheck(int uId = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		if (activityData == null || !activityData.HasReachableConstantTask())
		{
			ActivityRegressData activityData2 = ModelBase<ActivityRegressModel>.Instance.ActivityData;
			return activityData2 != null && activityData2.CheckRegressScoreRewardReached();
		}
		return true;
	}
}
