using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200331A RID: 13082
public class RedDotDangoCommonReward : RedDotBase
{
	// Token: 0x0601B5F1 RID: 112113 RVA: 0x00835780 File Offset: 0x00833980
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshAbyssRewardRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B5F2 RID: 112114 RVA: 0x0083579E File Offset: 0x0083399E
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshAbyssRewardRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B5F3 RID: 112115 RVA: 0x008357BC File Offset: 0x008339BC
	protected override bool OnCheck(int uId = 0)
	{
		if (uId == 0)
		{
			return false;
		}
		ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(uId);
		return activityById != null && (activityById as DangoAbyssActivityData).GetRewardTypeIfHaveCanTakeReward(EAbyssShopType.Common);
	}
}
