using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003324 RID: 13092
public class RedDotDangoMonopolyTask : RedDotBase
{
	// Token: 0x0601B62B RID: 112171 RVA: 0x00835EEB File Offset: 0x008340EB
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.DangoMonopoly);
	}

	// Token: 0x0601B62C RID: 112172 RVA: 0x00835EF7 File Offset: 0x008340F7
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateDangoMonopolyTask, new Action(base.EventCheck));
	}

	// Token: 0x0601B62D RID: 112173 RVA: 0x00835F15 File Offset: 0x00834115
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateDangoMonopolyTask, new Action(base.EventCheck));
	}

	// Token: 0x0601B62E RID: 112174 RVA: 0x00835F33 File Offset: 0x00834133
	protected override bool OnCheck(int uId = 0)
	{
		ActivityDangoMonopolyData data = ControllerBase<ActivityDangoMonopolyController>.Instance.GetData();
		return data != null && data.IsRedDotDiceTask();
	}
}
