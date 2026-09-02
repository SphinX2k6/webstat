using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003323 RID: 13091
public class RedDotDangoMonopolyRound : RedDotBase
{
	// Token: 0x0601B626 RID: 112166 RVA: 0x00835E84 File Offset: 0x00834084
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.DangoMonopoly);
	}

	// Token: 0x0601B627 RID: 112167 RVA: 0x00835E90 File Offset: 0x00834090
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateDangoMonopolyRound, new Action(base.EventCheck));
	}

	// Token: 0x0601B628 RID: 112168 RVA: 0x00835EAE File Offset: 0x008340AE
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateDangoMonopolyRound, new Action(base.EventCheck));
	}

	// Token: 0x0601B629 RID: 112169 RVA: 0x00835ECC File Offset: 0x008340CC
	protected override bool OnCheck(int uId = 0)
	{
		ActivityDangoMonopolyData data = ControllerBase<ActivityDangoMonopolyController>.Instance.GetData();
		return data != null && data.IsRoundReward();
	}
}
