using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003371 RID: 13169
public class RedDotMotorcycleTreeTypeTaskTab : RedDotBase
{
	// Token: 0x0601B775 RID: 112501 RVA: 0x00838869 File Offset: 0x00836A69
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B776 RID: 112502 RVA: 0x0083886C File Offset: 0x00836A6C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopTaskUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B777 RID: 112503 RVA: 0x008388A6 File Offset: 0x00836AA6
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopTaskUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B778 RID: 112504 RVA: 0x008388E0 File Offset: 0x00836AE0
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MotorcycleDevelopModel>.Instance.RedDotCanGetTaskReward(new int?(uId));
	}
}
