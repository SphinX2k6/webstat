using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200336D RID: 13165
public class RedDotMotorcycleLevelTab : RedDotBase
{
	// Token: 0x0601B760 RID: 112480 RVA: 0x008385F1 File Offset: 0x008367F1
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B761 RID: 112481 RVA: 0x008385F4 File Offset: 0x008367F4
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B762 RID: 112482 RVA: 0x00838612 File Offset: 0x00836812
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B763 RID: 112483 RVA: 0x00838630 File Offset: 0x00836830
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MotorcycleDevelopModel>.Instance.RedDotHasLevelUpReward();
	}
}
