using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200518B RID: 20875
	public class RoguelikeMemoryRewardItemData
	{
		// Token: 0x0401ED20 RID: 126240
		[Nullable(2)]
		public SeasonReward SeasonReward;

		// Token: 0x0401ED21 RID: 126241
		public Aki.Config.RogueSeasonReward? Config;
	}
}
