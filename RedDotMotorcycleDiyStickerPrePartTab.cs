using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200337B RID: 13179
public class RedDotMotorcycleDiyStickerPrePartTab : RedDotBase
{
	// Token: 0x0601B7A9 RID: 112553 RVA: 0x00838E5C File Offset: 0x0083705C
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B7AA RID: 112554 RVA: 0x00838E5F File Offset: 0x0083705F
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7AB RID: 112555 RVA: 0x00838E7D File Offset: 0x0083707D
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoRedDotUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B7AC RID: 112556 RVA: 0x00838E9B File Offset: 0x0083709B
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MotorcycleDiyModel>.Instance.RedDotIsPreview(EOutlookType.Sticker, new int?(uId));
	}
}
