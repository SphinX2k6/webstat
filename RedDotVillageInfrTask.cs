using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.VillageInfr;

// Token: 0x020033EB RID: 13291
public class RedDotVillageInfrTask : RedDotBase
{
	// Token: 0x0601B9B6 RID: 113078 RVA: 0x0083D31B File Offset: 0x0083B51B
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.VillageInfr);
	}

	// Token: 0x0601B9B7 RID: 113079 RVA: 0x0083D327 File Offset: 0x0083B527
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.VillageInfrActivityTaskDataUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.VillageInfrScoreRewardDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B9B8 RID: 113080 RVA: 0x0083D361 File Offset: 0x0083B561
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.VillageInfrActivityTaskDataUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.VillageInfrScoreRewardDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B9B9 RID: 113081 RVA: 0x0083D39B File Offset: 0x0083B59B
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<VillageInfrModel>.Instance.GetTaskRedDot() || ModelBase<VillageInfrModel>.Instance.HasScoreReward();
	}
}
