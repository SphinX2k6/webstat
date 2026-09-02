using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003364 RID: 13156
public class RedDotMoonChasingRole : RedDotBase
{
	// Token: 0x0601B735 RID: 112437 RVA: 0x0083801E File Offset: 0x0083621E
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.MoonChasingDelegation);
	}

	// Token: 0x0601B736 RID: 112438 RVA: 0x0083802A File Offset: 0x0083622A
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MoonChasingRefreshRoleRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B737 RID: 112439 RVA: 0x00838048 File Offset: 0x00836248
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MoonChasingRefreshRoleRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B738 RID: 112440 RVA: 0x00838066 File Offset: 0x00836266
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MoonChasingModel>.Instance.CheckRoleRedDotState();
	}
}
