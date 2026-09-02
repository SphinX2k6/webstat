using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;

// Token: 0x020033AB RID: 13227
public class RedDotRoguelikeAchievement : RedDotBase
{
	// Token: 0x0601B88A RID: 112778 RVA: 0x0083A7DB File Offset: 0x008389DB
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshAchievementRedPoint, new Action(base.EventCheck));
	}

	// Token: 0x0601B88B RID: 112779 RVA: 0x0083A7F9 File Offset: 0x008389F9
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshAchievementRedPoint, new Action(base.EventCheck));
	}

	// Token: 0x0601B88C RID: 112780 RVA: 0x0083A817 File Offset: 0x00838A17
	protected override bool OnCheck(int uId = 0)
	{
		ControllerBase<ActivityRogueController>.Instance.RefreshActivityRedDot();
		return ModelBase<RoguelikeModel>.Instance.GetRoguelikeAchievementRedDot();
	}
}
