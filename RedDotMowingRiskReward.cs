using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200337E RID: 13182
public class RedDotMowingRiskReward : RedDotBase
{
	// Token: 0x0601B7B8 RID: 112568 RVA: 0x00838FA4 File Offset: 0x008371A4
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MowingRiskOnRefreshRewardRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B7B9 RID: 112569 RVA: 0x00838FC2 File Offset: 0x008371C2
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MowingRiskOnRefreshRewardRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B7BA RID: 112570 RVA: 0x00838FE0 File Offset: 0x008371E0
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MowingRiskModel>.Instance.HasAnyReward;
	}
}
