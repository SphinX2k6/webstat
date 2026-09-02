using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032E6 RID: 13030
public class RedDotActivityRegressBpReward : RedDotBase
{
	// Token: 0x0601B50C RID: 111884 RVA: 0x00833D2C File Offset: 0x00831F2C
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.ActivityRegressBp);
	}

	// Token: 0x0601B50D RID: 111885 RVA: 0x00833D38 File Offset: 0x00831F38
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B50E RID: 111886 RVA: 0x00833D56 File Offset: 0x00831F56
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B50F RID: 111887 RVA: 0x00833D74 File Offset: 0x00831F74
	protected override bool OnCheck(int uId = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		return activityData != null && activityData.CheckRegressScoreRewardReached();
	}
}
