using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200336F RID: 13167
public class RedDotMotorcycleTaskTab : RedDotBase
{
	// Token: 0x0601B76A RID: 112490 RVA: 0x0083869D File Offset: 0x0083689D
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B76B RID: 112491 RVA: 0x008386A0 File Offset: 0x008368A0
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDevelopTaskUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B76C RID: 112492 RVA: 0x008386DA File Offset: 0x008368DA
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDevelopTaskUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B76D RID: 112493 RVA: 0x00838714 File Offset: 0x00836914
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MotorcycleDevelopModel>.Instance.RedDotCanGetAnyTaskReward();
	}
}
