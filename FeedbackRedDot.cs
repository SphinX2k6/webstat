using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003326 RID: 13094
public class FeedbackRedDot : RedDotBase
{
	// Token: 0x0601B634 RID: 112180 RVA: 0x00835FC1 File Offset: 0x008341C1
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattleViewMenu);
	}

	// Token: 0x0601B635 RID: 112181 RVA: 0x00835FC9 File Offset: 0x008341C9
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.FeedbackRewardRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B636 RID: 112182 RVA: 0x00835FE7 File Offset: 0x008341E7
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.FeedbackRewardRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B637 RID: 112183 RVA: 0x00836005 File Offset: 0x00834205
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FeedbackRewardModel>.Instance.CheckRedDot();
	}
}
