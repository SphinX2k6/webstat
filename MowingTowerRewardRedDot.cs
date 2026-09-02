using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003380 RID: 13184
public class MowingTowerRewardRedDot : RedDotBase
{
	// Token: 0x0601B7C0 RID: 112576 RVA: 0x0083903B File Offset: 0x0083723B
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshMowingTowerRewardRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B7C1 RID: 112577 RVA: 0x00839059 File Offset: 0x00837259
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshMowingTowerRewardRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B7C2 RID: 112578 RVA: 0x00839078 File Offset: 0x00837278
	protected override bool OnCheck(int uId = 0)
	{
		ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(uId);
		return activityById != null && (activityById as MowingTowerData).HaveRewardCanTake();
	}
}
