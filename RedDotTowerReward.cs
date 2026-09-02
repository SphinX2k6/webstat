using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;

// Token: 0x020033D9 RID: 13273
public class RedDotTowerReward : RedDotBase
{
	// Token: 0x0601B972 RID: 113010 RVA: 0x0083CC82 File Offset: 0x0083AE82
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnTowerRewardReceived, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotTowerReward, new Action(base.EventCheck));
	}

	// Token: 0x0601B973 RID: 113011 RVA: 0x0083CCBC File Offset: 0x0083AEBC
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTowerRewardReceived, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotTowerReward, new Action(base.EventCheck));
	}

	// Token: 0x0601B974 RID: 113012 RVA: 0x0083CCF6 File Offset: 0x0083AEF6
	protected override bool OnCheck(int uId = 0)
	{
		if (ModelBase<TowerModel>.Instance.CanGetReward())
		{
			AdventureGuideModel instance = ModelBase<AdventureGuideModel>.Instance;
			if (instance != null)
			{
				instance.ReportPeriodicActivityRewardAppear(EDungeonSubType.LoopTower);
			}
		}
		else
		{
			AdventureGuideModel instance2 = ModelBase<AdventureGuideModel>.Instance;
			if (instance2 != null)
			{
				instance2.ReportPeriodicActivityRewardClear(EDungeonSubType.LoopTower);
			}
		}
		return ModelBase<TowerModel>.Instance.CanGetReward();
	}
}
