using System;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005E08 RID: 24072
	public interface IRewardData
	{
		// Token: 0x17009912 RID: 39186
		// (get) Token: 0x0603C93F RID: 248127
		// (set) Token: 0x0603C940 RID: 248128
		int RewardId { get; set; }

		// Token: 0x17009913 RID: 39187
		// (get) Token: 0x0603C941 RID: 248129
		// (set) Token: 0x0603C942 RID: 248130
		int Count { get; set; }

		// Token: 0x17009914 RID: 39188
		// (get) Token: 0x0603C943 RID: 248131
		// (set) Token: 0x0603C944 RID: 248132
		bool IsGet { get; set; }
	}
}
