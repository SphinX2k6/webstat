using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena;

// Token: 0x0200338A RID: 13194
public class RedDotPhantomArenaBadgeReward : RedDotBase
{
	// Token: 0x0601B7ED RID: 112621 RVA: 0x00839792 File Offset: 0x00837992
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotPhantomArenaCollect);
	}

	// Token: 0x0601B7EE RID: 112622 RVA: 0x0083979E File Offset: 0x0083799E
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B7EF RID: 112623 RVA: 0x008397A1 File Offset: 0x008379A1
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaBadgeRewardUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7F0 RID: 112624 RVA: 0x008397BF File Offset: 0x008379BF
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaBadgeRewardUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7F1 RID: 112625 RVA: 0x008397DD File Offset: 0x008379DD
	protected override bool OnCheck(int uId = 0)
	{
		return uId != 0 && ModelBase<PhantomArenaModel>.Instance.GetBadgeRewardRedDot(uId);
	}
}
