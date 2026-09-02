using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B23 RID: 23331
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreScoreBelongHalfAreaItem : IRewardExploreScoreBelongHalfAreaItem
	{
		// Token: 0x170096D8 RID: 38616
		// (get) Token: 0x0603B076 RID: 241782 RVA: 0x00EF2780 File Offset: 0x00EF0980
		// (set) Token: 0x0603B077 RID: 241783 RVA: 0x00EF2788 File Offset: 0x00EF0988
		public string Target { get; set; }

		// Token: 0x170096D9 RID: 38617
		// (get) Token: 0x0603B078 RID: 241784 RVA: 0x00EF2791 File Offset: 0x00EF0991
		// (set) Token: 0x0603B079 RID: 241785 RVA: 0x00EF2799 File Offset: 0x00EF0999
		public string DescriptionTextId { get; set; }

		// Token: 0x170096DA RID: 38618
		// (get) Token: 0x0603B07A RID: 241786 RVA: 0x00EF27A2 File Offset: 0x00EF09A2
		// (set) Token: 0x0603B07B RID: 241787 RVA: 0x00EF27AA File Offset: 0x00EF09AA
		public ETeamBelong Belong { get; set; }
	}
}
