using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003377 RID: 13175
public class RedDotMotorcycleDiyDecorationTab : RedDotBase
{
	// Token: 0x0601B795 RID: 112533 RVA: 0x00838C1D File Offset: 0x00836E1D
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B796 RID: 112534 RVA: 0x00838C20 File Offset: 0x00836E20
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B797 RID: 112535 RVA: 0x00838C5A File Offset: 0x00836E5A
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B798 RID: 112536 RVA: 0x00838C94 File Offset: 0x00836E94
	protected override bool OnCheck(int uId = 0)
	{
		return !ModelBase<MotorcycleDiyModel>.Instance.RedDotIsPreviewInAnyPart(EOutlookType.Decoration) && ModelBase<MotorcycleDiyModel>.Instance.RedDotHasNewDecorationByAnyPart();
	}
}
