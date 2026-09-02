using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E17 RID: 28183
	[NullableContext(1)]
	[Nullable(0)]
	public class GetNextStepsContext
	{
		// Token: 0x0604469D RID: 280221 RVA: 0x011C57C8 File Offset: 0x011C39C8
		public GetNextStepsContext(LevelAiPlan plan, bool bIsExecutingPlan, List<LevelAiPlanStepId> outStepIds)
		{
			this.Plan = plan;
			this.IsExecutingPlan = bIsExecutingPlan;
			this.OutStepIds = outStepIds;
			this.NumSubmittedSteps = 0;
		}

		// Token: 0x0604469E RID: 280222 RVA: 0x011C57EC File Offset: 0x011C39EC
		public void SubmitPlanStep(LevelAiPlanStepId planStepId)
		{
			this.OutStepIds.Add(planStepId);
			this.NumSubmittedSteps++;
		}

		// Token: 0x0604469F RID: 280223 RVA: 0x011C5808 File Offset: 0x011C3A08
		public int AddNextStepsAfter(LevelAiPlanStepId inStepId)
		{
			if (!this.Plan.HasLevel(inStepId.LevelIndex))
			{
				return 0;
			}
			int numSubmittedSteps = this.NumSubmittedSteps;
			LevelAiPlanLevel levelAiPlanLevel = this.Plan.Levels[inStepId.LevelIndex];
			for (int i = inStepId.StepIndex + 1; i < levelAiPlanLevel.Steps.Count; i++)
			{
				LevelAiPlanStep levelAiPlanStep = levelAiPlanLevel.Steps[i];
				LevelAiPlanStepId thisStepId = new LevelAiPlanStepId(inStepId.LevelIndex, i);
				levelAiPlanStep.Node.GetNextSteps(this, thisStepId);
				if (this.NumSubmittedSteps - numSubmittedSteps > 0)
				{
					return this.NumSubmittedSteps - numSubmittedSteps;
				}
			}
			if (!levelAiPlanLevel.ParentStepId.Equal(LevelAiPlanStepId.None))
			{
				return this.AddNextStepsAfter(levelAiPlanLevel.ParentStepId);
			}
			return this.NumSubmittedSteps - numSubmittedSteps;
		}

		// Token: 0x060446A0 RID: 280224 RVA: 0x011C58C5 File Offset: 0x011C3AC5
		public int GetNumSubmittedSteps()
		{
			return this.NumSubmittedSteps;
		}

		// Token: 0x060446A1 RID: 280225 RVA: 0x011C58CD File Offset: 0x011C3ACD
		[return: Nullable(2)]
		public LevelAiPlanStep GetStep(LevelAiPlanStepId inStepId)
		{
			return this.Plan.GetStep(inStepId);
		}

		// Token: 0x0402613C RID: 155964
		private readonly LevelAiPlan Plan;

		// Token: 0x0402613D RID: 155965
		private readonly List<LevelAiPlanStepId> OutStepIds;

		// Token: 0x0402613E RID: 155966
		private int NumSubmittedSteps;

		// Token: 0x0402613F RID: 155967
		public bool IsExecutingPlan;
	}
}
