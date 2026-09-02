using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;

// Token: 0x02003385 RID: 13189
public class PersonalCardRedDot : RedDotBase
{
	// Token: 0x0601B7D8 RID: 112600 RVA: 0x008393B3 File Offset: 0x008375B3
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPersonalCardRefreshRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B7D9 RID: 112601 RVA: 0x008393D1 File Offset: 0x008375D1
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPersonalCardRefreshRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B7DA RID: 112602 RVA: 0x008393EF File Offset: 0x008375EF
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PersonalModel>.Instance.GetPersonalCardRedDotState();
	}
}
