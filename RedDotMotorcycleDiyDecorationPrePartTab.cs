using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003375 RID: 13173
public class RedDotMotorcycleDiyDecorationPrePartTab : RedDotBase
{
	// Token: 0x0601B78B RID: 112523 RVA: 0x00838B6F File Offset: 0x00836D6F
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B78C RID: 112524 RVA: 0x00838B72 File Offset: 0x00836D72
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B78D RID: 112525 RVA: 0x00838B90 File Offset: 0x00836D90
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B78E RID: 112526 RVA: 0x00838BAE File Offset: 0x00836DAE
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MotorcycleDiyModel>.Instance.RedDotIsPreview(EOutlookType.Decoration, new int?(uId));
	}
}
