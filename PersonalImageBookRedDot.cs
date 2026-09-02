using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;

// Token: 0x02003386 RID: 13190
public class PersonalImageBookRedDot : RedDotBase
{
	// Token: 0x0601B7DC RID: 112604 RVA: 0x00839403 File Offset: 0x00837603
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPersonalTipStateSet, new Action(base.EventCheck));
	}

	// Token: 0x0601B7DD RID: 112605 RVA: 0x00839421 File Offset: 0x00837621
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPersonalTipStateSet, new Action(base.EventCheck));
	}

	// Token: 0x0601B7DE RID: 112606 RVA: 0x0083943F File Offset: 0x0083763F
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PersonalModel>.Instance.CheckCanShowPersonalTip();
	}
}
