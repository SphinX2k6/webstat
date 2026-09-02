using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B22 RID: 23330
	[NullableContext(1)]
	public interface IRewardExploreScoreBelongHalfAreaItem
	{
		// Token: 0x170096D5 RID: 38613
		// (get) Token: 0x0603B070 RID: 241776
		// (set) Token: 0x0603B071 RID: 241777
		string Target { get; set; }

		// Token: 0x170096D6 RID: 38614
		// (get) Token: 0x0603B072 RID: 241778
		// (set) Token: 0x0603B073 RID: 241779
		string DescriptionTextId { get; set; }

		// Token: 0x170096D7 RID: 38615
		// (get) Token: 0x0603B074 RID: 241780
		// (set) Token: 0x0603B075 RID: 241781
		ETeamBelong Belong { get; set; }
	}
}
