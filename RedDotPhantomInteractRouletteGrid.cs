using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003397 RID: 13207
public class RedDotPhantomInteractRouletteGrid : RedDotBase
{
	// Token: 0x0601B82E RID: 112686 RVA: 0x00839BD0 File Offset: 0x00837DD0
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PhantomInteractModel>.Instance.CheckAnyPhantomInteractUnlockRedDot();
	}

	// Token: 0x0601B82F RID: 112687 RVA: 0x00839BDC File Offset: 0x00837DDC
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.PhantomInteractNewUnlock, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B830 RID: 112688 RVA: 0x00839BFA File Offset: 0x00837DFA
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.PhantomInteractNewUnlock, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B831 RID: 112689 RVA: 0x00839C18 File Offset: 0x00837E18
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}
}
