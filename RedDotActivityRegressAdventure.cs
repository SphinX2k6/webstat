using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032E4 RID: 13028
public class RedDotActivityRegressAdventure : RedDotBase
{
	// Token: 0x0601B507 RID: 111879 RVA: 0x00833C85 File Offset: 0x00831E85
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B508 RID: 111880 RVA: 0x00833CA3 File Offset: 0x00831EA3
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B509 RID: 111881 RVA: 0x00833CC4 File Offset: 0x00831EC4
	protected override bool OnCheck(int uId = 0)
	{
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		bool? flag = (activityData != null) ? new bool?(activityData.CheckAdventureRedDot()) : null;
		ActivityNewPlayerSupportData activityData2 = ControllerBase<ActivityNewPlayerSupportController>.Instance.ActivityData;
		if (activityData2 == null)
		{
			return flag.GetValueOrDefault();
		}
		return flag.GetValueOrDefault() || activityData2.IsAdventureEntranceRedDot();
	}
}
