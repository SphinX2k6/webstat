using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;

// Token: 0x02003388 RID: 13192
public class PersonalTitleRedDot : RedDotBase
{
	// Token: 0x0601B7E4 RID: 112612 RVA: 0x0083957F File Offset: 0x0083777F
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPlayerTitleRefreshRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B7E5 RID: 112613 RVA: 0x0083959D File Offset: 0x0083779D
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerTitleRefreshRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B7E6 RID: 112614 RVA: 0x008395BB File Offset: 0x008377BB
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PersonalModel>.Instance.GetPersonalTitleRedDotState();
	}
}
