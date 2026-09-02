using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E1D RID: 28189
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiStandaloneNode : LevelAiNode
	{
		// Token: 0x060446F2 RID: 280306 RVA: 0x011C718F File Offset: 0x011C538F
		public virtual void MakePlanExpansions(PlanningContext context, LevelAiWorldState worldState)
		{
		}

		// Token: 0x060446F3 RID: 280307 RVA: 0x011C7191 File Offset: 0x011C5391
		public virtual void GetNextSteps(GetNextStepsContext context, LevelAiPlanStepId thisStepId)
		{
			context.SubmitPlanStep(thisStepId);
		}

		// Token: 0x060446F4 RID: 280308 RVA: 0x011C719A File Offset: 0x011C539A
		public virtual bool OnSubLevelStepFinished(LevelAiPlanInstance planInstance, LevelAiPlanStepId thisStepId, LevelAiPlanStepId finishedSubLevelStepId, ELevelAiNodeResult result, bool bFinishedLevel)
		{
			return true;
		}

		// Token: 0x0402615C RID: 155996
		public bool PlanNextNodesAfterThis = true;

		// Token: 0x0402615D RID: 155997
		public List<LevelAiStandaloneNode> NextNodes = new List<LevelAiStandaloneNode>();

		// Token: 0x0402615E RID: 155998
		public List<LevelAiDecorator> Decorators = new List<LevelAiDecorator>();
	}
}
