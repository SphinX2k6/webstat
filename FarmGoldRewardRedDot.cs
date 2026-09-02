using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.FarmGold;

// Token: 0x02003325 RID: 13093
public class FarmGoldRewardRedDot : RedDotBase
{
	// Token: 0x0601B630 RID: 112176 RVA: 0x00835F52 File Offset: 0x00834152
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.FarmGoldRefreshRewardRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B631 RID: 112177 RVA: 0x00835F70 File Offset: 0x00834170
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.FarmGoldRefreshRewardRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B632 RID: 112178 RVA: 0x00835F90 File Offset: 0x00834190
	protected override bool OnCheck(int uId = 0)
	{
		ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(uId);
		return activityById != null && (activityById as FarmGoldData).HaveRewardCanTake();
	}
}
