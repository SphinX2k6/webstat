using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E1B RID: 28187
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiPlanner
	{
		// Token: 0x1700A369 RID: 41833
		// (get) Token: 0x060446DD RID: 280285 RVA: 0x011C6B45 File Offset: 0x011C4D45
		public bool WasCanceled
		{
			get
			{
				return this.WasCanceledInternal;
			}
		}

		// Token: 0x060446DE RID: 280286 RVA: 0x011C6B4D File Offset: 0x011C4D4D
		public void SetUp(LevelAi asset, CharacterPlanComponent owner)
		{
			this.OwnerComponent = owner;
			this.StartingPlan = new LevelAiPlan(asset, this.OwnerComponent.WorldState.MakeCopy());
		}

		// Token: 0x060446DF RID: 280287 RVA: 0x011C6B74 File Offset: 0x011C4D74
		public void StartPlanning()
		{
			if (this.IsPlanning)
			{
				return;
			}
			LevelAiPlan startingPlan = this.StartingPlan;
			this.Clear();
			this.Frontier.Push(startingPlan);
			this.IsPlanning = true;
			this.DoPlanning();
		}

		// Token: 0x060446E0 RID: 280288 RVA: 0x011C6BB0 File Offset: 0x011C4DB0
		public void CancelPlanning()
		{
			this.WasCanceledInternal = true;
			this.FinishedPlan = null;
			this.IsPlanning = false;
		}

		// Token: 0x060446E1 RID: 280289 RVA: 0x011C6BC8 File Offset: 0x011C4DC8
		public void DoPlanning()
		{
			if (this.WasCanceledInternal)
			{
				return;
			}
			for (;;)
			{
				this.CurrentPlanToExpand = this.DeQueueCurrentBestPlan();
				if (this.CurrentPlanToExpand == null)
				{
					break;
				}
				if (this.CurrentPlanToExpand.IsComplete())
				{
					goto Block_3;
				}
				this.MakeExpansionsOfCurrentPlan();
			}
			this.EndPlanning();
			return;
			Block_3:
			this.FinishedPlan = this.CurrentPlanToExpand;
			this.EndPlanning();
		}

		// Token: 0x060446E2 RID: 280290 RVA: 0x011C6C20 File Offset: 0x011C4E20
		private void EndPlanning()
		{
			this.ClearIntermediateState();
			this.Frontier.Clear();
			this.OnPlanningFinished(this, this.FinishedPlan);
			this.IsPlanning = false;
		}

		// Token: 0x060446E3 RID: 280291 RVA: 0x011C6C4C File Offset: 0x011C4E4C
		public void Clear()
		{
			this.ClearIntermediateState();
			this.StartingPlan = null;
			this.Frontier.Clear();
			this.FinishedPlan = null;
		}

		// Token: 0x060446E4 RID: 280292 RVA: 0x011C6C6D File Offset: 0x011C4E6D
		private void ClearIntermediateState()
		{
			this.CurrentPlanToExpand = null;
			this.CurrentPlanStepId.Reset();
		}

		// Token: 0x060446E5 RID: 280293 RVA: 0x011C6C81 File Offset: 0x011C4E81
		[NullableContext(2)]
		private LevelAiPlan DeQueueCurrentBestPlan()
		{
			if (!this.Frontier.Empty)
			{
				return this.Frontier.Pop();
			}
			return null;
		}

		// Token: 0x060446E6 RID: 280294 RVA: 0x011C6CA0 File Offset: 0x011C4EA0
		private void MakeExpansionsOfCurrentPlan()
		{
			if (!this.CurrentPlanToExpand.FindStepToAddAfter(this.CurrentPlanStepId) || this.CurrentPlanStepId.Equal(LevelAiPlanStepId.None))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelAi;
				ELogAuthor author = ELogAuthor.CJH;
				string message = "没有未完成的任务层";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Owner", this.OwnerComponent.GetCreatureDataComponent().GetPbDataId());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			IEnumerable<LevelAiStandaloneNode> nextNodes = this.CurrentPlanToExpand.GetNextNodes(this.CurrentPlanStepId);
			LevelAiWorldState worldState = this.CurrentPlanToExpand.GetWorldState(this.CurrentPlanStepId);
			foreach (LevelAiStandaloneNode levelAiStandaloneNode in nextNodes)
			{
				this.OwnerComponent.WorldStateProxy = worldState;
				if (LevelAiPlanner.EnterDecorators(levelAiStandaloneNode))
				{
					PlanningContext context = new PlanningContext(this, levelAiStandaloneNode, this.CurrentPlanToExpand, this.CurrentPlanStepId, worldState);
					levelAiStandaloneNode.MakePlanExpansions(context, worldState);
				}
			}
			this.ClearIntermediateState();
		}

		// Token: 0x060446E7 RID: 280295 RVA: 0x011C6DA0 File Offset: 0x011C4FA0
		private static bool EnterDecorators(LevelAiStandaloneNode node)
		{
			return LevelAiPlanner.<EnterDecorators>g__checkCondition|20_0(node.Decorators);
		}

		// Token: 0x060446E8 RID: 280296 RVA: 0x011C6DB2 File Offset: 0x011C4FB2
		public void SubmitCandidatePlan(LevelAiPlan candidatePlan)
		{
			this.Frontier.Push(candidatePlan);
		}

		// Token: 0x060446EA RID: 280298 RVA: 0x011C6E00 File Offset: 0x011C5000
		[CompilerGenerated]
		internal static bool <EnterDecorators>g__checkCondition|20_0(List<LevelAiDecorator> decorators)
		{
			ELevelAiDecoratorCheckResult elevelAiDecoratorCheckResult = ELevelAiDecoratorCheckResult.Passed;
			foreach (LevelAiDecorator levelAiDecorator in decorators)
			{
				if (levelAiDecorator != null)
				{
					ELevelAiDecoratorCheckResult val = levelAiDecorator.WrappedCheckCondition(ELevelAiDecoratorCheckType.PlanEnter);
					elevelAiDecoratorCheckResult = (ELevelAiDecoratorCheckResult)Math.Min((int)elevelAiDecoratorCheckResult, (int)val);
					if (elevelAiDecoratorCheckResult != ELevelAiDecoratorCheckResult.Passed)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x04026151 RID: 155985
		[Nullable(2)]
		private CharacterPlanComponent OwnerComponent;

		// Token: 0x04026152 RID: 155986
		[Nullable(2)]
		private LevelAiPlan CurrentPlanToExpand;

		// Token: 0x04026153 RID: 155987
		private readonly LevelAiPlanStepId CurrentPlanStepId = new LevelAiPlanStepId(-1, -1);

		// Token: 0x04026154 RID: 155988
		[Nullable(2)]
		private LevelAiPlan StartingPlan;

		// Token: 0x04026155 RID: 155989
		[Nullable(2)]
		private LevelAiPlan FinishedPlan;

		// Token: 0x04026156 RID: 155990
		private bool WasCanceledInternal;

		// Token: 0x04026157 RID: 155991
		private readonly PriorityQueue<LevelAiPlan> Frontier = new PriorityQueue<LevelAiPlan>((LevelAiPlan a, LevelAiPlan b) => a.Cost - b.Cost);

		// Token: 0x04026158 RID: 155992
		private bool IsPlanning;

		// Token: 0x04026159 RID: 155993
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<LevelAiPlanner, LevelAiPlan> OnPlanningFinished;
	}
}
