using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.VillageInfr;

// Token: 0x020033EA RID: 13290
public class RedDotVillageInfr : RedDotBase
{
	// Token: 0x0601B9B2 RID: 113074 RVA: 0x0083D260 File Offset: 0x0083B460
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.VillageInfrVillageDataUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.VillageInfrActivityTaskDataUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.VillageInfrScoreRewardDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B9B3 RID: 113075 RVA: 0x0083D2C1 File Offset: 0x0083B4C1
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.VillageInfrVillageDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B9B4 RID: 113076 RVA: 0x0083D2E0 File Offset: 0x0083B4E0
	protected override bool OnCheck(int uId = 0)
	{
		VillageInfrModel instance = ModelBase<VillageInfrModel>.Instance;
		return instance.HasTreeCanLevelUp() || instance.GetCanVillageLevelUp() || instance.HasScoreReward() || instance.GetTaskRedDot();
	}
}
