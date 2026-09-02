using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003367 RID: 13159
public class RedDotMoraleAreaBuff : RedDotBase
{
	// Token: 0x0601B744 RID: 112452 RVA: 0x008381C6 File Offset: 0x008363C6
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.MoraleBuff);
	}

	// Token: 0x0601B745 RID: 112453 RVA: 0x008381D2 File Offset: 0x008363D2
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateMoraleAreaBuff, new Action(base.EventCheck));
	}

	// Token: 0x0601B746 RID: 112454 RVA: 0x008381F0 File Offset: 0x008363F0
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateMoraleAreaBuff, new Action(base.EventCheck));
	}

	// Token: 0x0601B747 RID: 112455 RVA: 0x0083820E File Offset: 0x0083640E
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MoraleModel>.Instance.RedDotAreaBuff();
	}
}
