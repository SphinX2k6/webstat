using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003369 RID: 13161
public class RedDotMoraleFlagBox : RedDotBase
{
	// Token: 0x0601B74B RID: 112459 RVA: 0x00838236 File Offset: 0x00836436
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.Morale);
	}

	// Token: 0x0601B74C RID: 112460 RVA: 0x00838242 File Offset: 0x00836442
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateMoraleFlagBox, new Action(base.EventCheck));
	}

	// Token: 0x0601B74D RID: 112461 RVA: 0x00838260 File Offset: 0x00836460
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateMoraleFlagBox, new Action(base.EventCheck));
	}

	// Token: 0x0601B74E RID: 112462 RVA: 0x0083827E File Offset: 0x0083647E
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MoraleModel>.Instance.RedDotFlagBox();
	}
}
