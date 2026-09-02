using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200337F RID: 13183
public class RedDotMowingRiskBuffAll : RedDotBase
{
	// Token: 0x0601B7BC RID: 112572 RVA: 0x00838FF4 File Offset: 0x008371F4
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MowingRiskOnRefreshBuffAllRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B7BD RID: 112573 RVA: 0x00839012 File Offset: 0x00837212
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MowingRiskOnRefreshBuffAllRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B7BE RID: 112574 RVA: 0x00839030 File Offset: 0x00837230
	protected override bool OnCheck(int uId = 0)
	{
		return false;
	}
}
