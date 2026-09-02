using System;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B14 RID: 23316
	public interface ITowerDefenceRewardInfo : IRewardInfo
	{
		// Token: 0x170096AB RID: 38571
		// (get) Token: 0x0603B015 RID: 241685
		// (set) Token: 0x0603B016 RID: 241686
		bool IsSuccess { get; set; }

		// Token: 0x170096AC RID: 38572
		// (get) Token: 0x0603B017 RID: 241687
		// (set) Token: 0x0603B018 RID: 241688
		int Score { get; set; }

		// Token: 0x170096AD RID: 38573
		// (get) Token: 0x0603B019 RID: 241689
		// (set) Token: 0x0603B01A RID: 241690
		int RecordScore { get; set; }
	}
}
