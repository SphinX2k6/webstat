using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.TrainingDegree;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B1B RID: 23323
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreBar : IRewardExploreBar
	{
		// Token: 0x170096C4 RID: 38596
		// (get) Token: 0x0603B04A RID: 241738 RVA: 0x00EF26C7 File Offset: 0x00EF08C7
		// (set) Token: 0x0603B04B RID: 241739 RVA: 0x00EF26CF File Offset: 0x00EF08CF
		public TrainingData TrainingData { get; set; }
	}
}
