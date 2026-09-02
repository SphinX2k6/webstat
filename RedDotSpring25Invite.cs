using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033CF RID: 13263
public class RedDotSpring25Invite : RedDotBase
{
	// Token: 0x0601B943 RID: 112963 RVA: 0x0083C5F1 File Offset: 0x0083A7F1
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25InviteDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25ActivityParseDone, new Action(base.EventCheck));
	}

	// Token: 0x0601B944 RID: 112964 RVA: 0x0083C62B File Offset: 0x0083A82B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25InviteDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25ActivityParseDone, new Action(base.EventCheck));
	}

	// Token: 0x0601B945 RID: 112965 RVA: 0x0083C665 File Offset: 0x0083A865
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<Spring25Model>.Instance.IsInviteAvailableExternal;
	}
}
