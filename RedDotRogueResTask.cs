using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PermanentRogue;

// Token: 0x020033B7 RID: 13239
public class RedDotRogueResTask : RedDotBase
{
	// Token: 0x0601B8C4 RID: 112836 RVA: 0x0083AED1 File Offset: 0x008390D1
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PermanentRogueRewardUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B8C5 RID: 112837 RVA: 0x0083AEEF File Offset: 0x008390EF
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PermanentRogueRewardUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B8C6 RID: 112838 RVA: 0x0083AF0D File Offset: 0x0083910D
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<ActivityPermanentRogueModel>.Instance.CheckAllTaskRedDot();
	}
}
