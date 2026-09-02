using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;

// Token: 0x020033CA RID: 13258
public class RedDotShipTowerReward : RedDotBase
{
	// Token: 0x0601B91E RID: 112926 RVA: 0x0083BEB1 File Offset: 0x0083A0B1
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.ShipTower);
	}

	// Token: 0x0601B91F RID: 112927 RVA: 0x0083BEBA File Offset: 0x0083A0BA
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateShipTowerReward, new Action(base.EventCheck));
	}

	// Token: 0x0601B920 RID: 112928 RVA: 0x0083BED8 File Offset: 0x0083A0D8
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateShipTowerReward, new Action(base.EventCheck));
	}

	// Token: 0x0601B921 RID: 112929 RVA: 0x0083BEF6 File Offset: 0x0083A0F6
	protected override bool OnCheck(int uId = 0)
	{
		bool flag = ModelBase<ShipTowerModel>.Instance.IsCanReceiveAward();
		if (flag)
		{
			ModelBase<AdventureGuideModel>.Instance.ReportPeriodicActivityRewardAppear(EDungeonSubType.ShipTower);
			return flag;
		}
		ModelBase<AdventureGuideModel>.Instance.ReportPeriodicActivityRewardClear(EDungeonSubType.ShipTower);
		return flag;
	}
}
