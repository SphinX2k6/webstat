using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003302 RID: 13058
public class RedDotBattlePass : RedDotBase
{
	// Token: 0x0601B585 RID: 112005 RVA: 0x00834B7F File Offset: 0x00832D7F
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattleViewMenu);
	}

	// Token: 0x0601B586 RID: 112006 RVA: 0x00834B87 File Offset: 0x00832D87
	protected override void AddActiveEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateBattlePassTaskEvent, new Action(base.OnActiveEvent));
	}

	// Token: 0x0601B587 RID: 112007 RVA: 0x00834BA5 File Offset: 0x00832DA5
	protected override void AddDisActiveEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnBattlePassExpireEvent, new Action(base.OnDisActiveEvent));
	}
}
