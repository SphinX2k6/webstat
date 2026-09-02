using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003310 RID: 13072
public class RedDotCalabashTab : RedDotBase
{
	// Token: 0x0601B5C8 RID: 112072 RVA: 0x008352C1 File Offset: 0x008334C1
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionCalabash);
	}

	// Token: 0x0601B5C9 RID: 112073 RVA: 0x008352CC File Offset: 0x008334CC
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.GetCalabashReward, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotRefreshCalabash, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.CurWorldLevelChange, new Action(base.EventCheck));
	}

	// Token: 0x0601B5CA RID: 112074 RVA: 0x00835330 File Offset: 0x00833530
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GetCalabashReward, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotRefreshCalabash, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.CurWorldLevelChange, new Action(base.EventCheck));
	}

	// Token: 0x0601B5CB RID: 112075 RVA: 0x00835391 File Offset: 0x00833591
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<CalabashModel>.Instance.CheckCanReceiveReward();
	}
}
