using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B39 RID: 23353
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeBossChallengeData : IRoguelikeBossChallengeData
	{
		// Token: 0x17009723 RID: 38691
		// (get) Token: 0x0603B117 RID: 241943 RVA: 0x00EF2A47 File Offset: 0x00EF0C47
		// (set) Token: 0x0603B118 RID: 241944 RVA: 0x00EF2A4F File Offset: 0x00EF0C4F
		public bool IsNewRecord { get; set; }

		// Token: 0x17009724 RID: 38692
		// (get) Token: 0x0603B119 RID: 241945 RVA: 0x00EF2A58 File Offset: 0x00EF0C58
		// (set) Token: 0x0603B11A RID: 241946 RVA: 0x00EF2A60 File Offset: 0x00EF0C60
		public int PassTime { get; set; }

		// Token: 0x17009725 RID: 38693
		// (get) Token: 0x0603B11B RID: 241947 RVA: 0x00EF2A69 File Offset: 0x00EF0C69
		// (set) Token: 0x0603B11C RID: 241948 RVA: 0x00EF2A71 File Offset: 0x00EF0C71
		public int InstId { get; set; }

		// Token: 0x17009726 RID: 38694
		// (get) Token: 0x0603B11D RID: 241949 RVA: 0x00EF2A7A File Offset: 0x00EF0C7A
		// (set) Token: 0x0603B11E RID: 241950 RVA: 0x00EF2A82 File Offset: 0x00EF0C82
		public int BossTotalCount { get; set; }

		// Token: 0x17009727 RID: 38695
		// (get) Token: 0x0603B11F RID: 241951 RVA: 0x00EF2A8B File Offset: 0x00EF0C8B
		// (set) Token: 0x0603B120 RID: 241952 RVA: 0x00EF2A93 File Offset: 0x00EF0C93
		public IReadOnlyList<int> FinishedBossIdList { get; set; }

		// Token: 0x17009728 RID: 38696
		// (get) Token: 0x0603B121 RID: 241953 RVA: 0x00EF2A9C File Offset: 0x00EF0C9C
		// (set) Token: 0x0603B122 RID: 241954 RVA: 0x00EF2AA4 File Offset: 0x00EF0CA4
		public int? CurrentBossId { get; set; }
	}
}
