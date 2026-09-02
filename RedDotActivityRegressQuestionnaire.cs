using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032EC RID: 13036
public class RedDotActivityRegressQuestionnaire : RedDotBase
{
	// Token: 0x0601B526 RID: 111910 RVA: 0x00833F74 File Offset: 0x00832174
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B527 RID: 111911 RVA: 0x00833F92 File Offset: 0x00832192
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B528 RID: 111912 RVA: 0x00833FB0 File Offset: 0x008321B0
	protected override bool OnCheck(int uId = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		return activityData != null && activityData.CheckShowQuestionnaireRedDot();
	}
}
