using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003382 RID: 13186
public class RedDotNewPlayerSupportTrialRoleEntrance : RedDotBase
{
	// Token: 0x0601B7C8 RID: 112584 RVA: 0x00839114 File Offset: 0x00837314
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.CurWorldLevelChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnActivityNewPlayerSupportEntranceRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int, int>(EEventName.OnGroupTrialRoleChanged, new Action<int, int, int>(this.OnGroupTrialRoleChanged));
	}

	// Token: 0x0601B7C9 RID: 112585 RVA: 0x00839178 File Offset: 0x00837378
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CurWorldLevelChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityNewPlayerSupportEntranceRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int, int>(EEventName.OnGroupTrialRoleChanged, new Action<int, int, int>(this.OnGroupTrialRoleChanged));
	}

	// Token: 0x0601B7CA RID: 112586 RVA: 0x008391DC File Offset: 0x008373DC
	protected override bool OnCheck(int uId = 0)
	{
		ActivityNewPlayerSupportData activityData = ControllerBase<ActivityNewPlayerSupportController>.Instance.ActivityData;
		return activityData != null && (activityData.IsTrialRoleUpgradeRedPoint() || activityData.IsTrialRoleEntranceRedDot());
	}

	// Token: 0x0601B7CB RID: 112587 RVA: 0x00839209 File Offset: 0x00837409
	private void OnGroupTrialRoleChanged(int preRoleId, int curRoleId, int groupId)
	{
		base.EventCheck();
	}
}
