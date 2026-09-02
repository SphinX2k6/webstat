using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033D4 RID: 13268
public class RedDotDrinksUnlockLevel : RedDotBase
{
	// Token: 0x0601B95A RID: 112986 RVA: 0x0083CA0D File Offset: 0x0083AC0D
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnDrinksUnlockClickedNotify, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.SpringManorFunctionOpenNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B95B RID: 112987 RVA: 0x0083CA47 File Offset: 0x0083AC47
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnDrinksUnlockClickedNotify, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.SpringManorFunctionOpenNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B95C RID: 112988 RVA: 0x0083CA81 File Offset: 0x0083AC81
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<DrinksModel>.Instance.CheckRedDot();
	}

	// Token: 0x0601B95D RID: 112989 RVA: 0x0083CA8D File Offset: 0x0083AC8D
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.SpringManorGameEntrance);
	}
}
