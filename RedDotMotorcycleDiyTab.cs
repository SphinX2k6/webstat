using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200336C RID: 13164
public class RedDotMotorcycleDiyTab : RedDotBase
{
	// Token: 0x0601B75B RID: 112475 RVA: 0x00838515 File Offset: 0x00836715
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B75C RID: 112476 RVA: 0x00838518 File Offset: 0x00836718
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiySceneItemUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B75D RID: 112477 RVA: 0x0083857C File Offset: 0x0083677C
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiySceneItemUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B75E RID: 112478 RVA: 0x008385DD File Offset: 0x008367DD
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MotorcycleDiyModel>.Instance.RedDotForDiyTab();
	}
}
