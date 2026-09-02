using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;

// Token: 0x02003387 RID: 13191
public class PersonalizeInfoRedDot : RedDotBase
{
	// Token: 0x0601B7E0 RID: 112608 RVA: 0x00839454 File Offset: 0x00837654
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPersonalCardRefreshRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPlayerTitleRefreshRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnBirthChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFunctionOpenUpdateNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B7E1 RID: 112609 RVA: 0x008394D4 File Offset: 0x008376D4
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPersonalCardRefreshRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerTitleRefreshRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBirthChange, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdateNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B7E2 RID: 112610 RVA: 0x00839551 File Offset: 0x00837751
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PersonalModel>.Instance.GetPersonalCardRedDotState() || ModelBase<PersonalModel>.Instance.GetPersonalTitleRedDotState() || ModelBase<BirthdayModel>.Instance.GetBirthdayRedDotState();
	}
}
