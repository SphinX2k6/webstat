using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003374 RID: 13172
public class RedDotMotorcycleDiyDecorationPartTab : RedDotBase
{
	// Token: 0x0601B786 RID: 112518 RVA: 0x00838ACE File Offset: 0x00836CCE
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B787 RID: 112519 RVA: 0x00838AD1 File Offset: 0x00836CD1
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B788 RID: 112520 RVA: 0x00838B0B File Offset: 0x00836D0B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B789 RID: 112521 RVA: 0x00838B45 File Offset: 0x00836D45
	protected override bool OnCheck(int uId = 0)
	{
		return !ModelBase<MotorcycleDiyModel>.Instance.RedDotIsPreview(EOutlookType.Decoration, new int?(uId)) && ModelBase<MotorcycleDiyModel>.Instance.RedDotHasNewDecorationByPart(uId);
	}
}
