using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003356 RID: 13142
public class RedDotInviteNewbie : RedDotBase
{
	// Token: 0x0601B6FA RID: 112378 RVA: 0x00837AEC File Offset: 0x00835CEC
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.InviteNewbieEntered, new Action(base.EventCheck));
	}

	// Token: 0x0601B6FB RID: 112379 RVA: 0x00837B0A File Offset: 0x00835D0A
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.InviteNewbieEntered, new Action(base.EventCheck));
	}

	// Token: 0x0601B6FC RID: 112380 RVA: 0x00837B28 File Offset: 0x00835D28
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<InviteNewbieModel>.Instance.HasRedDot;
	}
}
