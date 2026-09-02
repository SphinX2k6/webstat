using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena;

// Token: 0x02003395 RID: 13205
public class RedDotPhantomArenaTaskReward : RedDotBase
{
	// Token: 0x0601B823 RID: 112675 RVA: 0x00839B1D File Offset: 0x00837D1D
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotPhantomArenaLimitReward);
	}

	// Token: 0x0601B824 RID: 112676 RVA: 0x00839B29 File Offset: 0x00837D29
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhantomArenaTaskAwardUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B825 RID: 112677 RVA: 0x00839B47 File Offset: 0x00837D47
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhantomArenaTaskAwardUpdate, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B826 RID: 112678 RVA: 0x00839B65 File Offset: 0x00837D65
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B827 RID: 112679 RVA: 0x00839B68 File Offset: 0x00837D68
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PhantomArenaModel>.Instance.CheckTaskRedDot(uId);
	}
}
