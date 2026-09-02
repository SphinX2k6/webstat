using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x02006199 RID: 24985
	public class QuestRewardViewParam
	{
		// Token: 0x04023699 RID: 145049
		public bool IsShowExpItem;

		// Token: 0x0402369A RID: 145050
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public int[][] RewardList;

		// Token: 0x0402369B RID: 145051
		public int AreaId;

		// Token: 0x0402369C RID: 145052
		public int BeforeContributionLevel;

		// Token: 0x0402369D RID: 145053
		public int BeforeContributionValue;
	}
}
