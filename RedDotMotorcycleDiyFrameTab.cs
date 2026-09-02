using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003379 RID: 13177
public class RedDotMotorcycleDiyFrameTab : RedDotBase
{
	// Token: 0x0601B79F RID: 112543 RVA: 0x00838D21 File Offset: 0x00836F21
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B7A0 RID: 112544 RVA: 0x00838D24 File Offset: 0x00836F24
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7A1 RID: 112545 RVA: 0x00838D5E File Offset: 0x00836F5E
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7A2 RID: 112546 RVA: 0x00838D98 File Offset: 0x00836F98
	protected override bool OnCheck(int uId = 0)
	{
		return !ModelBase<MotorcycleDiyModel>.Instance.RedDotIsPreviewInAnyPart(EOutlookType.Frame) && ModelBase<MotorcycleDiyModel>.Instance.RedDotHasNewFrame();
	}
}
