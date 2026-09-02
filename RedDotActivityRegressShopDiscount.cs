using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032EF RID: 13039
public class RedDotActivityRegressShopDiscount : RedDotBase
{
	// Token: 0x0601B532 RID: 111922 RVA: 0x00834085 File Offset: 0x00832285
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B533 RID: 111923 RVA: 0x008340A3 File Offset: 0x008322A3
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B534 RID: 111924 RVA: 0x008340C1 File Offset: 0x008322C1
	protected override bool OnCheck(int uId = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		return activityData != null && activityData.CheckShopRedDot();
	}
}
