using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032F0 RID: 13040
public class RedDotActivityRegressTrialRole : RedDotBase
{
	// Token: 0x0601B536 RID: 111926 RVA: 0x008340E0 File Offset: 0x008322E0
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B537 RID: 111927 RVA: 0x008340FE File Offset: 0x008322FE
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B538 RID: 111928 RVA: 0x0083411C File Offset: 0x0083231C
	protected override bool OnCheck(int uId = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		return activityData != null && activityData.CheckTrialRoleRedDot();
	}
}
