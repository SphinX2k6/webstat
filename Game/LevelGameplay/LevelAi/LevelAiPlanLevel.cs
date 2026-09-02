using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E15 RID: 28181
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiPlanLevel
	{
		// Token: 0x06044690 RID: 280208 RVA: 0x011C52C0 File Offset: 0x011C34C0
		public LevelAiPlanLevel(LevelAiWorldState worldStateAtLevelStart, [Nullable(2)] LevelAiPlanStepId parentStepId = null)
		{
			this.WorldStateAtLevelStart = worldStateAtLevelStart;
			this.RootSubNodesInfo = new SubNodesInfo();
			this.ParentStepId = new LevelAiPlanStepId(-1, -1);
			if (parentStepId != null)
			{
				this.ParentStepId.CopyFrom(parentStepId);
			}
			else
			{
				this.ParentStepId.CopyFrom(LevelAiPlanStepId.None);
			}
			this.Cost = 0;
		}

		// Token: 0x06044691 RID: 280209 RVA: 0x011C5328 File Offset: 0x011C3528
		public LevelAiPlanLevel MakeCopy()
		{
			LevelAiPlanLevel levelAiPlanLevel = new LevelAiPlanLevel(this.WorldStateAtLevelStart, this.ParentStepId);
			levelAiPlanLevel.Steps.Capacity = this.Steps.Count;
			for (int i = 0; i < this.Steps.Count; i++)
			{
				levelAiPlanLevel.Steps.Add(this.Steps[i]);
			}
			levelAiPlanLevel.Cost = this.Cost;
			return levelAiPlanLevel;
		}

		// Token: 0x04026134 RID: 155956
		public List<LevelAiPlanStep> Steps = new List<LevelAiPlanStep>();

		// Token: 0x04026135 RID: 155957
		public SubNodesInfo RootSubNodesInfo;

		// Token: 0x04026136 RID: 155958
		public LevelAiPlanStepId ParentStepId;

		// Token: 0x04026137 RID: 155959
		public LevelAiWorldState WorldStateAtLevelStart;

		// Token: 0x04026138 RID: 155960
		public int Cost;
	}
}
