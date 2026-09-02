using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02001590 RID: 5520
public class RedDotActivityRun : RedDotBase
{
	// Token: 0x06009B6D RID: 39789 RVA: 0x0028B593 File Offset: 0x00289793
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshRunActivityRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x06009B6E RID: 39790 RVA: 0x0028B5B1 File Offset: 0x002897B1
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshRunActivityRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x06009B6F RID: 39791 RVA: 0x0028B5D0 File Offset: 0x002897D0
	protected override bool OnCheck(int uid = 0)
	{
		ActivityRunData activityRunData = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(uid);
		return activityRunData != null && activityRunData.GetRedPoint();
	}
}
