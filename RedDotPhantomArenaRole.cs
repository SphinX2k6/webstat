using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena;

// Token: 0x02003393 RID: 13203
public class RedDotPhantomArenaRole : RedDotBase
{
	// Token: 0x0601B816 RID: 112662 RVA: 0x00839A18 File Offset: 0x00837C18
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotPhantomArenaActivity);
	}

	// Token: 0x0601B817 RID: 112663 RVA: 0x00839A24 File Offset: 0x00837C24
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhantomArenaRoleRewardUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B818 RID: 112664 RVA: 0x00839A42 File Offset: 0x00837C42
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhantomArenaRoleRewardUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B819 RID: 112665 RVA: 0x00839A60 File Offset: 0x00837C60
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B81A RID: 112666 RVA: 0x00839A63 File Offset: 0x00837C63
	protected override bool OnCheck(int uId = 0)
	{
		return uId != 0 && ModelBase<PhantomArenaModel>.Instance.GetRoleRewardRedDot(uId);
	}
}
