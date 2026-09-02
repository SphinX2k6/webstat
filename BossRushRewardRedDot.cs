using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200330E RID: 13070
public class BossRushRewardRedDot : RedDotBase
{
	// Token: 0x0601B5C2 RID: 112066 RVA: 0x00835243 File Offset: 0x00833443
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.BossRefreshBossRushRewardRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B5C3 RID: 112067 RVA: 0x00835261 File Offset: 0x00833461
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.BossRefreshBossRushRewardRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B5C4 RID: 112068 RVA: 0x00835280 File Offset: 0x00833480
	protected override bool OnCheck(int uId = 0)
	{
		ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(uId);
		return activityById != null && (activityById as BossRushData).HaveRewardCanTake();
	}
}
