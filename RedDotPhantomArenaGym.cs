using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena;

// Token: 0x0200338E RID: 13198
public class RedDotPhantomArenaGym : RedDotBase
{
	// Token: 0x0601B800 RID: 112640 RVA: 0x008398C4 File Offset: 0x00837AC4
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotPhantomArenaActivity);
	}

	// Token: 0x0601B801 RID: 112641 RVA: 0x008398D0 File Offset: 0x00837AD0
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaChallengeUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B802 RID: 112642 RVA: 0x008398EE File Offset: 0x00837AEE
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaChallengeUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B803 RID: 112643 RVA: 0x0083990C File Offset: 0x00837B0C
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B804 RID: 112644 RVA: 0x0083990F File Offset: 0x00837B0F
	protected override bool OnCheck(int uId = 0)
	{
		return uId != 0 && ModelBase<PhantomArenaModel>.Instance.GetGymRedDot(uId);
	}
}
