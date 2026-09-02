using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02000FD5 RID: 4053
public class RedDotAchievement : RedDotBase
{
	// Token: 0x06006865 RID: 26725 RVA: 0x001B362D File Offset: 0x001B182D
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshAchievementRedPoint, new Action(base.EventCheck));
	}

	// Token: 0x06006866 RID: 26726 RVA: 0x001B364B File Offset: 0x001B184B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshAchievementRedPoint, new Action(base.EventCheck));
	}

	// Token: 0x06006867 RID: 26727 RVA: 0x001B3669 File Offset: 0x001B1869
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<AchievementModel>.Instance.GetAchievementRedPointState();
	}
}
