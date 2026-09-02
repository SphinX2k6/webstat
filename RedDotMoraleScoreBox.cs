using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200336A RID: 13162
public class RedDotMoraleScoreBox : RedDotBase
{
	// Token: 0x0601B750 RID: 112464 RVA: 0x00838292 File Offset: 0x00836492
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.Morale);
	}

	// Token: 0x0601B751 RID: 112465 RVA: 0x0083829E File Offset: 0x0083649E
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateMoraleScoreBox, new Action(base.EventCheck));
	}

	// Token: 0x0601B752 RID: 112466 RVA: 0x008382BC File Offset: 0x008364BC
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateMoraleScoreBox, new Action(base.EventCheck));
	}

	// Token: 0x0601B753 RID: 112467 RVA: 0x008382DA File Offset: 0x008364DA
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MoraleModel>.Instance.RedDotScoreBox();
	}
}
