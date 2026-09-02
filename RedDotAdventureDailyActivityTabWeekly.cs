using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020032F8 RID: 13048
public class RedDotAdventureDailyActivityTabWeekly : RedDotBase
{
	// Token: 0x0601B55A RID: 111962 RVA: 0x008345AA File Offset: 0x008327AA
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.AdventureDailyActivityTab);
	}

	// Token: 0x0601B55B RID: 111963 RVA: 0x008345B4 File Offset: 0x008327B4
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyChallengeRefresh, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyChallengeRewardStateChanged, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyChallengeScoreChanged, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyChallengeRefreshRedDotChanged, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnServerStorageInfoInited, new Action(base.EventCheck));
	}

	// Token: 0x0601B55C RID: 111964 RVA: 0x00834650 File Offset: 0x00832850
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyChallengeRefresh, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyChallengeRewardStateChanged, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyChallengeScoreChanged, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyChallengeRefreshRedDotChanged, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnServerStorageInfoInited, new Action(base.EventCheck));
	}

	// Token: 0x0601B55D RID: 111965 RVA: 0x008346EC File Offset: 0x008328EC
	protected override bool OnCheck(int uId = 0)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.AdventureGuide) || !ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.WeeklyChallenge) || ModelBase<WeeklyChallengeModel>.Instance.WeeklyConfigId == 0)
		{
			return false;
		}
		long weeklyEndTime = ModelBase<WeeklyChallengeModel>.Instance.WeeklyEndTime;
		return weeklyEndTime > 0L && ((long)ModelBase<DailyActivityModel>.Instance.GetFirstOpenTabTime(DailyActivityDefine.EDailyActivityMainTab.Weekly).GetValueOrDefault() != weeklyEndTime || ModelBase<WeeklyChallengeModel>.Instance.CheckIsRewardWaitTake());
	}
}
