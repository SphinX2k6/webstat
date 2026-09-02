using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E2B RID: 28203
	public class LevelAiTaskSuccess : LevelAiTask
	{
		// Token: 0x06044746 RID: 280390 RVA: 0x011C8A57 File Offset: 0x011C6C57
		[NullableContext(1)]
		protected override void CreatePlanSteps(PlanningContext context, LevelAiWorldState worldStateAfterTask)
		{
			context.SubmitCandidatePlanStep(this, worldStateAfterTask, this.Cost);
		}

		// Token: 0x04026189 RID: 156041
		public int Cost;
	}
}
