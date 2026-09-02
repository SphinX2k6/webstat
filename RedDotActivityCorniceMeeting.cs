using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020012B6 RID: 4790
public class RedDotActivityCorniceMeeting : RedDotBase
{
	// Token: 0x060080A1 RID: 32929 RVA: 0x0021FB3F File Offset: 0x0021DD3F
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCorniceMeetingRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x060080A2 RID: 32930 RVA: 0x0021FB5D File Offset: 0x0021DD5D
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCorniceMeetingRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x060080A3 RID: 32931 RVA: 0x0021FB7C File Offset: 0x0021DD7C
	protected override bool OnCheck(int uid)
	{
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		if (currentActivityData == null)
		{
			return false;
		}
		ActivityCorniceMeetingLevelEntryData levelEntryData = currentActivityData.GetLevelEntryData(uid);
		return levelEntryData != null && levelEntryData.GetRedDot();
	}
}
