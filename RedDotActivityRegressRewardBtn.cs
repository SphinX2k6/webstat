using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032EE RID: 13038
public class RedDotActivityRegressRewardBtn : RedDotBase
{
	// Token: 0x0601B52E RID: 111918 RVA: 0x0083402A File Offset: 0x0083222A
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B52F RID: 111919 RVA: 0x00834048 File Offset: 0x00832248
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B530 RID: 111920 RVA: 0x00834066 File Offset: 0x00832266
	protected override bool OnCheck(int uId = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		return activityData != null && activityData.CheckRegressRewardBtnReached();
	}
}
