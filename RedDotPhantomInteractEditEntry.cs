using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003396 RID: 13206
public class RedDotPhantomInteractEditEntry : RedDotBase
{
	// Token: 0x0601B829 RID: 112681 RVA: 0x00839B7D File Offset: 0x00837D7D
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PhantomInteractModel>.Instance.CheckAnyPhantomInteractUnlockRedDot();
	}

	// Token: 0x0601B82A RID: 112682 RVA: 0x00839B89 File Offset: 0x00837D89
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PhantomInteractNewUnlock, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B82B RID: 112683 RVA: 0x00839BA7 File Offset: 0x00837DA7
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PhantomInteractNewUnlock, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B82C RID: 112684 RVA: 0x00839BC5 File Offset: 0x00837DC5
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}
}
