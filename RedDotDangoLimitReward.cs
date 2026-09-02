using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200331E RID: 13086
public class RedDotDangoLimitReward : RedDotBase
{
	// Token: 0x0601B606 RID: 112134 RVA: 0x008359FC File Offset: 0x00833BFC
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshAbyssRewardRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B607 RID: 112135 RVA: 0x00835A1A File Offset: 0x00833C1A
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshAbyssRewardRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B608 RID: 112136 RVA: 0x00835A38 File Offset: 0x00833C38
	protected override bool OnCheck(int uId = 0)
	{
		if (uId == 0)
		{
			return false;
		}
		ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(uId);
		return activityById != null && (activityById as DangoAbyssActivityData).GetRewardTypeIfHaveCanTakeReward(EAbyssShopType.Limit);
	}
}
