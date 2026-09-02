using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032ED RID: 13037
public class RedDotActivityRegressRecommend : RedDotBase
{
	// Token: 0x0601B52A RID: 111914 RVA: 0x00833FCF File Offset: 0x008321CF
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B52B RID: 111915 RVA: 0x00833FED File Offset: 0x008321ED
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B52C RID: 111916 RVA: 0x0083400B File Offset: 0x0083220B
	protected override bool OnCheck(int uId = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		return activityData != null && activityData.CheckRecommendRedDot();
	}
}
