using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200337A RID: 13178
public class RedDotMotorcycleDiyStickerPartTab : RedDotBase
{
	// Token: 0x0601B7A4 RID: 112548 RVA: 0x00838DBB File Offset: 0x00836FBB
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B7A5 RID: 112549 RVA: 0x00838DBE File Offset: 0x00836FBE
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7A6 RID: 112550 RVA: 0x00838DF8 File Offset: 0x00836FF8
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7A7 RID: 112551 RVA: 0x00838E32 File Offset: 0x00837032
	protected override bool OnCheck(int uId = 0)
	{
		return !ModelBase<MotorcycleDiyModel>.Instance.RedDotIsPreview(EOutlookType.Sticker, new int?(uId)) && ModelBase<MotorcycleDiyModel>.Instance.RedDotHasNewStickerByPart(uId);
	}
}
