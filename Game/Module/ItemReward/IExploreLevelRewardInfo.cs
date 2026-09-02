using System;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B12 RID: 23314
	public interface IExploreLevelRewardInfo : IRewardInfo
	{
		// Token: 0x170096A7 RID: 38567
		// (get) Token: 0x0603B00C RID: 241676
		// (set) Token: 0x0603B00D RID: 241677
		int CurrentExploreLevel { get; set; }

		// Token: 0x170096A8 RID: 38568
		// (get) Token: 0x0603B00E RID: 241678
		// (set) Token: 0x0603B00F RID: 241679
		int TargetExploreLevel { get; set; }
	}
}
