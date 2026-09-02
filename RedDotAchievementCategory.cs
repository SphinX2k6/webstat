using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02000FD6 RID: 4054
public class RedDotAchievementCategory : RedDotBase
{
	// Token: 0x06006869 RID: 26729 RVA: 0x001B367D File Offset: 0x001B187D
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshAchievementRedPoint, new Action(base.EventCheck));
	}

	// Token: 0x0600686A RID: 26730 RVA: 0x001B369B File Offset: 0x001B189B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshAchievementRedPoint, new Action(base.EventCheck));
	}

	// Token: 0x0600686B RID: 26731 RVA: 0x001B36B9 File Offset: 0x001B18B9
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0600686C RID: 26732 RVA: 0x001B36BC File Offset: 0x001B18BC
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<AchievementModel>.Instance.GetCategoryRedPointState(uId);
	}
}
