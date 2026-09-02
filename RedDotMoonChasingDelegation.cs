using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200335F RID: 13151
public class RedDotMoonChasingDelegation : RedDotBase
{
	// Token: 0x0601B71F RID: 112415 RVA: 0x00837E59 File Offset: 0x00836059
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MoonChasingRefreshDelegationRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B720 RID: 112416 RVA: 0x00837E77 File Offset: 0x00836077
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MoonChasingRefreshDelegationRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B721 RID: 112417 RVA: 0x00837E95 File Offset: 0x00836095
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MoonChasingModel>.Instance.CheckDelegationRedDotState();
	}
}
