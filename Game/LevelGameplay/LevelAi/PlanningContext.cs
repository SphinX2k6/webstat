using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E1A RID: 28186
	[NullableContext(2)]
	[Nullable(0)]
	public class PlanningContext
	{
		// Token: 0x1700A367 RID: 41831
		// (get) Token: 0x060446D6 RID: 280278 RVA: 0x011C69E2 File Offset: 0x011C4BE2
		public int CurrentLevelIndex
		{
			get
			{
				return this.CurrentPlanStepId.LevelIndex;
			}
		}

		// Token: 0x1700A368 RID: 41832
		// (get) Token: 0x060446D7 RID: 280279 RVA: 0x011C69EF File Offset: 0x011C4BEF
		public int CurrentStepIndex
		{
			get
			{
				return this.CurrentPlanStepId.StepIndex;
			}
		}

		// Token: 0x060446D8 RID: 280280 RVA: 0x011C69FC File Offset: 0x011C4BFC
		[NullableContext(1)]
		public PlanningContext(LevelAiPlanner planner, LevelAiStandaloneNode addingNode, LevelAiPlan planToExpand, LevelAiPlanStepId currentPlanStepId, LevelAiWorldState worldState)
		{
			this.Planner = planner;
			this.AddingNode = addingNode;
			this.PlanToExpand = planToExpand;
			this.CurrentPlanStepId = currentPlanStepId;
			this.WorldState = worldState;
		}

		// Token: 0x060446D9 RID: 280281 RVA: 0x011C6A2C File Offset: 0x011C4C2C
		[return: TupleElementNames(new string[]
		{
			"PlanCopy",
			"OutAddedStep",
			"OutAddedStepId"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public ValueTuple<LevelAiPlan, LevelAiPlanStep, LevelAiPlanStepId> MakePlanCopyWithAddedStep()
		{
			LevelAiPlan levelAiPlan = this.PlanToExpand.MakeCopy();
			LevelAiPlanLevel levelAiPlanLevel = levelAiPlan.Levels[this.CurrentPlanStepId.LevelIndex];
			LevelAiPlanStep levelAiPlanStep = new LevelAiPlanStep(this.AddingNode, this.WorldState, 0, -1);
			levelAiPlanLevel.Steps.Add(levelAiPlanStep);
			LevelAiPlanStepId item = new LevelAiPlanStepId(this.CurrentPlanStepId.LevelIndex, levelAiPlanLevel.Steps.Count - 1);
			return new ValueTuple<LevelAiPlan, LevelAiPlanStep, LevelAiPlanStepId>(levelAiPlan, levelAiPlanStep, item);
		}

		// Token: 0x060446DA RID: 280282 RVA: 0x011C6AA0 File Offset: 0x011C4CA0
		[NullableContext(1)]
		public int AddLevel(LevelAiPlan newPlan, [Nullable(2)] LevelAiPlanStepId parentStepId = null)
		{
			if (parentStepId == null)
			{
				parentStepId = LevelAiPlanStepId.None;
			}
			newPlan.Levels.Add(new LevelAiPlanLevel(this.WorldState, parentStepId));
			return newPlan.Levels.Count - 1;
		}

		// Token: 0x060446DB RID: 280283 RVA: 0x011C6AD0 File Offset: 0x011C4CD0
		[NullableContext(1)]
		public void SubmitCandidatePlanStep(LevelAiTask task, LevelAiWorldState worldState, int cost)
		{
			LevelAiPlan levelAiPlan = this.PlanToExpand.MakeCopy();
			LevelAiPlanStep item = new LevelAiPlanStep(task, worldState, cost, -1);
			LevelAiPlanLevel levelAiPlanLevel = levelAiPlan.Levels[this.CurrentPlanStepId.LevelIndex];
			levelAiPlanLevel.Steps.Add(item);
			levelAiPlanLevel.Cost += cost;
			levelAiPlan.Cost += cost;
			this.SubmitCandidatePlan(levelAiPlan);
		}

		// Token: 0x060446DC RID: 280284 RVA: 0x011C6B37 File Offset: 0x011C4D37
		[NullableContext(1)]
		public void SubmitCandidatePlan(LevelAiPlan candidatePlan)
		{
			this.Planner.SubmitCandidatePlan(candidatePlan);
		}

		// Token: 0x0402614C RID: 155980
		private readonly LevelAiPlanner Planner;

		// Token: 0x0402614D RID: 155981
		private readonly LevelAiStandaloneNode AddingNode;

		// Token: 0x0402614E RID: 155982
		private readonly LevelAiPlan PlanToExpand;

		// Token: 0x0402614F RID: 155983
		private readonly LevelAiPlanStepId CurrentPlanStepId;

		// Token: 0x04026150 RID: 155984
		private readonly LevelAiWorldState WorldState;
	}
}
