using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032EA RID: 13034
public class RedDotActivityRegressDisposableReward : RedDotBase
{
	// Token: 0x0601B51E RID: 111902 RVA: 0x00833EC4 File Offset: 0x008320C4
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B51F RID: 111903 RVA: 0x00833EE2 File Offset: 0x008320E2
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B520 RID: 111904 RVA: 0x00833F00 File Offset: 0x00832100
	protected override bool OnCheck(int uId = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		return activityData != null && activityData.CheckDisposableRewardRedDot();
	}
}
