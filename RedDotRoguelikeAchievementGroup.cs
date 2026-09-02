using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033AC RID: 13228
public class RedDotRoguelikeAchievementGroup : RedDotBase
{
	// Token: 0x0601B88E RID: 112782 RVA: 0x0083A835 File Offset: 0x00838A35
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAchievementGroupDataNotify, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B88F RID: 112783 RVA: 0x0083A853 File Offset: 0x00838A53
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnAchievementGroupDataNotify, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B890 RID: 112784 RVA: 0x0083A874 File Offset: 0x00838A74
	protected override bool OnCheck(int uId = 0)
	{
		AchievementGroupData achievementGroupData = ModelBase<AchievementModel>.Instance.GetAchievementGroupData(new int?(uId));
		return achievementGroupData != null && achievementGroupData.SmallItemRedPoint();
	}
}
