using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033D8 RID: 13272
public class TowerDefenseInstanceRedDot : RedDotBase
{
	// Token: 0x0601B96E RID: 113006 RVA: 0x0083CC32 File Offset: 0x0083AE32
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TowerDefenseOnInstanceInfoUpdateNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B96F RID: 113007 RVA: 0x0083CC50 File Offset: 0x0083AE50
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefenseOnInstanceInfoUpdateNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B970 RID: 113008 RVA: 0x0083CC6E File Offset: 0x0083AE6E
	protected override bool OnCheck(int uId = 0)
	{
		return ControllerBase<TowerDefenseController>.Instance.CheckHasNewStage();
	}
}
