using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E14 RID: 28180
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiPlanStep
	{
		// Token: 0x0604468F RID: 280207 RVA: 0x011C5289 File Offset: 0x011C3489
		public LevelAiPlanStep(LevelAiStandaloneNode node, LevelAiWorldState worldState, int cost = 0, int subLevelIndex = -1)
		{
			this.Node = node;
			this.WorldState = worldState;
			this.SubNodesInfo = new SubNodesInfo();
			this.SubLevelIndex = subLevelIndex;
			this.Cost = Math.Max(0, cost);
		}

		// Token: 0x0402612F RID: 155951
		public LevelAiStandaloneNode Node;

		// Token: 0x04026130 RID: 155952
		public SubNodesInfo SubNodesInfo;

		// Token: 0x04026131 RID: 155953
		public int SubLevelIndex;

		// Token: 0x04026132 RID: 155954
		public LevelAiWorldState WorldState;

		// Token: 0x04026133 RID: 155955
		public int Cost;
	}
}
