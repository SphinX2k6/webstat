using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003361 RID: 13153
public class RedDotMoonChasingMainlineTab : RedDotBase
{
	// Token: 0x0601B727 RID: 112423 RVA: 0x00837F03 File Offset: 0x00836103
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.MoonChasingAllQuest);
	}

	// Token: 0x0601B728 RID: 112424 RVA: 0x00837F0F File Offset: 0x0083610F
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MoonChasingRefreshQuestRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B729 RID: 112425 RVA: 0x00837F2D File Offset: 0x0083612D
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MoonChasingRefreshQuestRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B72A RID: 112426 RVA: 0x00837F4B File Offset: 0x0083614B
	protected override bool OnCheck(int uId = 0)
	{
		ControllerBase<ActivityMoonChasingController>.Instance.RefreshActivityRedDot();
		return ModelBase<MoonChasingModel>.Instance.CheckMainlineRedDot();
	}
}
