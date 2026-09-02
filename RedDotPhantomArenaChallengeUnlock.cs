using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena;

// Token: 0x0200338C RID: 13196
public class RedDotPhantomArenaChallengeUnlock : RedDotBase
{
	// Token: 0x0601B7F9 RID: 112633 RVA: 0x0083985C File Offset: 0x00837A5C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaChallengeUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7FA RID: 112634 RVA: 0x0083987A File Offset: 0x00837A7A
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaChallengeUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7FB RID: 112635 RVA: 0x00839898 File Offset: 0x00837A98
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PhantomArenaModel>.Instance.GetChallengeUnlockRedDotById(uId);
	}
}
