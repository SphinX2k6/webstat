using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003381 RID: 13185
public class RedDotNewPlayerSupportAdventure : RedDotBase
{
	// Token: 0x0601B7C4 RID: 112580 RVA: 0x008390A9 File Offset: 0x008372A9
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7C5 RID: 112581 RVA: 0x008390C7 File Offset: 0x008372C7
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7C6 RID: 112582 RVA: 0x008390E8 File Offset: 0x008372E8
	protected override bool OnCheck(int uId = 0)
	{
		ActivityNewPlayerSupportData activityData = ControllerBase<ActivityNewPlayerSupportController>.Instance.ActivityData;
		return activityData != null && activityData.IsAdventureEntranceRedDot();
	}
}
