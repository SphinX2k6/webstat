using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B21 RID: 23329
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreScoreBelongHalfArea : IRewardExploreScoreBelongHalfArea
	{
		// Token: 0x170096D2 RID: 38610
		// (get) Token: 0x0603B069 RID: 241769 RVA: 0x00EF2745 File Offset: 0x00EF0945
		// (set) Token: 0x0603B06A RID: 241770 RVA: 0x00EF274D File Offset: 0x00EF094D
		public List<IRewardExploreScoreBelongHalfAreaItem> ItemList { get; set; }

		// Token: 0x170096D3 RID: 38611
		// (get) Token: 0x0603B06B RID: 241771 RVA: 0x00EF2756 File Offset: 0x00EF0956
		// (set) Token: 0x0603B06C RID: 241772 RVA: 0x00EF275E File Offset: 0x00EF095E
		public int FullScore { get; set; }

		// Token: 0x170096D4 RID: 38612
		// (get) Token: 0x0603B06D RID: 241773 RVA: 0x00EF2767 File Offset: 0x00EF0967
		// (set) Token: 0x0603B06E RID: 241774 RVA: 0x00EF276F File Offset: 0x00EF096F
		public bool IfNewRecord { get; set; }
	}
}
