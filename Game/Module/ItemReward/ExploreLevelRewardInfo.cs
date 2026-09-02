using System;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B13 RID: 23315
	public class ExploreLevelRewardInfo : RewardInfo, IExploreLevelRewardInfo, IRewardInfo
	{
		// Token: 0x170096A9 RID: 38569
		// (get) Token: 0x0603B010 RID: 241680 RVA: 0x00EF25B9 File Offset: 0x00EF07B9
		// (set) Token: 0x0603B011 RID: 241681 RVA: 0x00EF25C1 File Offset: 0x00EF07C1
		public int CurrentExploreLevel { get; set; }

		// Token: 0x170096AA RID: 38570
		// (get) Token: 0x0603B012 RID: 241682 RVA: 0x00EF25CA File Offset: 0x00EF07CA
		// (set) Token: 0x0603B013 RID: 241683 RVA: 0x00EF25D2 File Offset: 0x00EF07D2
		public int TargetExploreLevel { get; set; }
	}
}
