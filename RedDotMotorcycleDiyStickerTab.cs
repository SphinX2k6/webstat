using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200337D RID: 13181
public class RedDotMotorcycleDiyStickerTab : RedDotBase
{
	// Token: 0x0601B7B3 RID: 112563 RVA: 0x00838F0A File Offset: 0x0083710A
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B7B4 RID: 112564 RVA: 0x00838F0D File Offset: 0x0083710D
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7B5 RID: 112565 RVA: 0x00838F47 File Offset: 0x00837147
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7B6 RID: 112566 RVA: 0x00838F81 File Offset: 0x00837181
	protected override bool OnCheck(int uId = 0)
	{
		return !ModelBase<MotorcycleDiyModel>.Instance.RedDotIsPreviewInAnyPart(EOutlookType.Sticker) && ModelBase<MotorcycleDiyModel>.Instance.RedDotHasNewStickerByAnyPart();
	}
}
