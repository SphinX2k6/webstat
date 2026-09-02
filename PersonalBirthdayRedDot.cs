using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003384 RID: 13188
public class PersonalBirthdayRedDot : RedDotBase
{
	// Token: 0x0601B7D4 RID: 112596 RVA: 0x0083932B File Offset: 0x0083752B
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnBirthChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFunctionOpenUpdateNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B7D5 RID: 112597 RVA: 0x00839365 File Offset: 0x00837565
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBirthChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdateNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B7D6 RID: 112598 RVA: 0x0083939F File Offset: 0x0083759F
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<BirthdayModel>.Instance.GetBirthdayRedDotState();
	}
}
