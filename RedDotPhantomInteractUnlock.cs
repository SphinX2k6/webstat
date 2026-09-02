using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003398 RID: 13208
public class RedDotPhantomInteractUnlock : RedDotBase
{
	// Token: 0x0601B833 RID: 112691 RVA: 0x00839C23 File Offset: 0x00837E23
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PhantomInteractModel>.Instance.CheckPhantomInteractUnlockRedDot(uId);
	}

	// Token: 0x0601B834 RID: 112692 RVA: 0x00839C30 File Offset: 0x00837E30
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PhantomInteractNewUnlock, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B835 RID: 112693 RVA: 0x00839C4E File Offset: 0x00837E4E
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PhantomInteractNewUnlock, new Action<int>(base.EventCheckWithUid));
	}
}
