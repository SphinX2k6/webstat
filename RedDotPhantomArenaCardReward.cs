using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena;

// Token: 0x0200338B RID: 13195
public class RedDotPhantomArenaCardReward : RedDotBase
{
	// Token: 0x0601B7F3 RID: 112627 RVA: 0x008397F7 File Offset: 0x008379F7
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotPhantomArenaCollect);
	}

	// Token: 0x0601B7F4 RID: 112628 RVA: 0x00839803 File Offset: 0x00837A03
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B7F5 RID: 112629 RVA: 0x00839806 File Offset: 0x00837A06
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhantomArenaCardRewardUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B7F6 RID: 112630 RVA: 0x00839824 File Offset: 0x00837A24
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhantomArenaCardRewardUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B7F7 RID: 112631 RVA: 0x00839842 File Offset: 0x00837A42
	protected override bool OnCheck(int uId = 0)
	{
		return uId != 0 && ModelBase<PhantomArenaModel>.Instance.GetCardRewardRedDot(uId);
	}
}
