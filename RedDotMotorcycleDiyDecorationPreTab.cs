using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003376 RID: 13174
public class RedDotMotorcycleDiyDecorationPreTab : RedDotBase
{
	// Token: 0x0601B790 RID: 112528 RVA: 0x00838BC9 File Offset: 0x00836DC9
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B791 RID: 112529 RVA: 0x00838BCC File Offset: 0x00836DCC
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B792 RID: 112530 RVA: 0x00838BEA File Offset: 0x00836DEA
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B793 RID: 112531 RVA: 0x00838C08 File Offset: 0x00836E08
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MotorcycleDiyModel>.Instance.RedDotIsPreviewInAnyPart(EOutlookType.Decoration);
	}
}
