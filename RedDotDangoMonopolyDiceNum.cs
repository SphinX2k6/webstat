using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003322 RID: 13090
public class RedDotDangoMonopolyDiceNum : RedDotBase
{
	// Token: 0x0601B621 RID: 112161 RVA: 0x00835E1D File Offset: 0x0083401D
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.DangoMonopoly);
	}

	// Token: 0x0601B622 RID: 112162 RVA: 0x00835E29 File Offset: 0x00834029
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateDangoMonopolyNum, new Action(base.EventCheck));
	}

	// Token: 0x0601B623 RID: 112163 RVA: 0x00835E47 File Offset: 0x00834047
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateDangoMonopolyNum, new Action(base.EventCheck));
	}

	// Token: 0x0601B624 RID: 112164 RVA: 0x00835E65 File Offset: 0x00834065
	protected override bool OnCheck(int uId = 0)
	{
		ActivityDangoMonopolyData data = ControllerBase<ActivityDangoMonopolyController>.Instance.GetData();
		return data != null && data.IsCanUseDice();
	}
}
