using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200337C RID: 13180
public class RedDotMotorcycleDiyStickerPreTab : RedDotBase
{
	// Token: 0x0601B7AE RID: 112558 RVA: 0x00838EB6 File Offset: 0x008370B6
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B7AF RID: 112559 RVA: 0x00838EB9 File Offset: 0x008370B9
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7B0 RID: 112560 RVA: 0x00838ED7 File Offset: 0x008370D7
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7B1 RID: 112561 RVA: 0x00838EF5 File Offset: 0x008370F5
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MotorcycleDiyModel>.Instance.RedDotIsPreviewInAnyPart(EOutlookType.Sticker);
	}
}
