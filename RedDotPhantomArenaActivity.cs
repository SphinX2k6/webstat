using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena;

// Token: 0x02003389 RID: 13193
public class RedDotPhantomArenaActivity : RedDotBase
{
	// Token: 0x0601B7E8 RID: 112616 RVA: 0x008395D0 File Offset: 0x008377D0
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaChallengeUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaMasterInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhantomArenaRoleRewardUpdate, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhantomArenaCardRewardUpdate, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaBadgeRewardUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhantomArenaTaskAwardUpdate, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaShopOpen, new Action(base.EventCheck));
	}

	// Token: 0x0601B7E9 RID: 112617 RVA: 0x008396A4 File Offset: 0x008378A4
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaChallengeUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaMasterInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhantomArenaRoleRewardUpdate, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhantomArenaCardRewardUpdate, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaBadgeRewardUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhantomArenaTaskAwardUpdate, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaShopOpen, new Action(base.EventCheck));
	}

	// Token: 0x0601B7EA RID: 112618 RVA: 0x00839775 File Offset: 0x00837975
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B7EB RID: 112619 RVA: 0x00839778 File Offset: 0x00837978
	protected override bool OnCheck(int uId = 0)
	{
		return uId != 0 && ModelBase<PhantomArenaModel>.Instance.GetPhantomArenaButtonRedDot(uId);
	}
}
