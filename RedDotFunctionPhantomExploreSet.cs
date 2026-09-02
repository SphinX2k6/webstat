using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003341 RID: 13121
public class RedDotFunctionPhantomExploreSet : RedDotBase
{
	// Token: 0x0601B69F RID: 112287 RVA: 0x00836C65 File Offset: 0x00834E65
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattleViewMenu);
	}

	// Token: 0x0601B6A0 RID: 112288 RVA: 0x00836C6D File Offset: 0x00834E6D
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RouletteRefreshNew, new Action(base.EventCheck));
	}

	// Token: 0x0601B6A1 RID: 112289 RVA: 0x00836C8B File Offset: 0x00834E8B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RouletteRefreshNew, new Action(base.EventCheck));
	}

	// Token: 0x0601B6A2 RID: 112290 RVA: 0x00836CAC File Offset: 0x00834EAC
	protected override bool OnCheck(int uId = 0)
	{
		bool flag = ModelBase<RouletteModel>.Instance.CheckHasAnyNewItem();
		bool flag2 = ModelBase<PhantomInteractModel>.Instance.CheckAnyPhantomInteractUnlockRedDot();
		return flag || flag2;
	}
}
