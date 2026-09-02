using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena;

// Token: 0x0200338F RID: 13199
public class RedDotPhantomArenaLevelReward : RedDotBase
{
	// Token: 0x0601B806 RID: 112646 RVA: 0x00839929 File Offset: 0x00837B29
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaMasterInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B807 RID: 112647 RVA: 0x00839947 File Offset: 0x00837B47
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaMasterInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B808 RID: 112648 RVA: 0x00839965 File Offset: 0x00837B65
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B809 RID: 112649 RVA: 0x00839968 File Offset: 0x00837B68
	protected override bool OnCheck(int uId = 0)
	{
		return uId != 0 && ModelBase<PhantomArenaModel>.Instance.GetMasterLevelRewardRedDot(uId);
	}
}
