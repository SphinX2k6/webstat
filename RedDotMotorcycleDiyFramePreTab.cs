using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003378 RID: 13176
public class RedDotMotorcycleDiyFramePreTab : RedDotBase
{
	// Token: 0x0601B79A RID: 112538 RVA: 0x00838CB7 File Offset: 0x00836EB7
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B79B RID: 112539 RVA: 0x00838CBA File Offset: 0x00836EBA
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B79C RID: 112540 RVA: 0x00838CD8 File Offset: 0x00836ED8
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B79D RID: 112541 RVA: 0x00838CF8 File Offset: 0x00836EF8
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MotorcycleDiyModel>.Instance.RedDotIsPreview(EOutlookType.Frame, null);
	}
}
