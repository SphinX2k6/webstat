using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200335E RID: 13150
public class RedDotMoonChasingBuilding : RedDotBase
{
	// Token: 0x0601B71B RID: 112411 RVA: 0x00837DC7 File Offset: 0x00835FC7
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TrackMoonHandbookUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MoonChasingRefreshBuildingRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B71C RID: 112412 RVA: 0x00837E01 File Offset: 0x00836001
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TrackMoonHandbookUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MoonChasingRefreshBuildingRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B71D RID: 112413 RVA: 0x00837E3B File Offset: 0x0083603B
	protected override bool OnCheck(int uId = 0)
	{
		ControllerBase<ActivityMoonChasingController>.Instance.RefreshActivityRedDot();
		return ModelBase<MoonChasingBuildingModel>.Instance.CheckAllBuildingRedDotState();
	}
}
