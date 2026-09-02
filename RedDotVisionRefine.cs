using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003312 RID: 13074
public class RedDotVisionRefine : RedDotBase
{
	// Token: 0x0601B5D1 RID: 112081 RVA: 0x00835403 File Offset: 0x00833603
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnVisionRefineStorage, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotStart, new Action(base.EventCheck));
	}

	// Token: 0x0601B5D2 RID: 112082 RVA: 0x0083543D File Offset: 0x0083363D
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionRefineStorage, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotStart, new Action(base.EventCheck));
	}

	// Token: 0x0601B5D3 RID: 112083 RVA: 0x00835477 File Offset: 0x00833677
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetVisionRefineRedDot();
	}
}
