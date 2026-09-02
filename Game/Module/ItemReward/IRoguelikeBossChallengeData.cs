using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B38 RID: 23352
	[NullableContext(1)]
	public interface IRoguelikeBossChallengeData
	{
		// Token: 0x1700971D RID: 38685
		// (get) Token: 0x0603B10B RID: 241931
		// (set) Token: 0x0603B10C RID: 241932
		bool IsNewRecord { get; set; }

		// Token: 0x1700971E RID: 38686
		// (get) Token: 0x0603B10D RID: 241933
		// (set) Token: 0x0603B10E RID: 241934
		int PassTime { get; set; }

		// Token: 0x1700971F RID: 38687
		// (get) Token: 0x0603B10F RID: 241935
		// (set) Token: 0x0603B110 RID: 241936
		int InstId { get; set; }

		// Token: 0x17009720 RID: 38688
		// (get) Token: 0x0603B111 RID: 241937
		// (set) Token: 0x0603B112 RID: 241938
		int BossTotalCount { get; set; }

		// Token: 0x17009721 RID: 38689
		// (get) Token: 0x0603B113 RID: 241939
		// (set) Token: 0x0603B114 RID: 241940
		IReadOnlyList<int> FinishedBossIdList { get; set; }

		// Token: 0x17009722 RID: 38690
		// (get) Token: 0x0603B115 RID: 241941
		// (set) Token: 0x0603B116 RID: 241942
		int? CurrentBossId { get; set; }
	}
}
