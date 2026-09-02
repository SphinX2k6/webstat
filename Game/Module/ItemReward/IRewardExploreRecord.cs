using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B24 RID: 23332
	[NullableContext(1)]
	public interface IRewardExploreRecord
	{
		// Token: 0x170096DB RID: 38619
		// (get) Token: 0x0603B07D RID: 241789
		// (set) Token: 0x0603B07E RID: 241790
		string TitleTextId { get; set; }

		// Token: 0x170096DC RID: 38620
		// (get) Token: 0x0603B07F RID: 241791
		// (set) Token: 0x0603B080 RID: 241792
		string Record { get; set; }

		// Token: 0x170096DD RID: 38621
		// (get) Token: 0x0603B081 RID: 241793
		// (set) Token: 0x0603B082 RID: 241794
		int? RecordRollingTo { get; set; }

		// Token: 0x170096DE RID: 38622
		// (get) Token: 0x0603B083 RID: 241795
		// (set) Token: 0x0603B084 RID: 241796
		bool IsNewRecord { get; set; }
	}
}
