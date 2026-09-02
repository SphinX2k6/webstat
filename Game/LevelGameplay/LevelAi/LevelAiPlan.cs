using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E16 RID: 28182
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiPlan
	{
		// Token: 0x06044692 RID: 280210 RVA: 0x011C5397 File Offset: 0x011C3597
		public LevelAiPlan(LevelAi asset, [Nullable(2)] LevelAiWorldState worldStateAtLevelStart)
		{
			this.LevelAiAsset = asset;
			if (worldStateAtLevelStart != null)
			{
				this.Levels.Add(new LevelAiPlanLevel(worldStateAtLevelStart, null));
			}
			this.Cost = 0;
		}

		// Token: 0x06044693 RID: 280211 RVA: 0x011C53CD File Offset: 0x011C35CD
		public bool HasLevel(int levelIndex)
		{
			return levelIndex < this.Levels.Count && this.Levels[levelIndex] != null;
		}

		// Token: 0x06044694 RID: 280212 RVA: 0x011C53F0 File Offset: 0x011C35F0
		public bool HasStep(LevelAiPlanStepId stepId, int levelIndex = 0)
		{
			if (!this.HasLevel(stepId.LevelIndex) || !this.HasLevel(levelIndex))
			{
				return false;
			}
			if (stepId.LevelIndex == levelIndex)
			{
				LevelAiPlanLevel levelAiPlanLevel = this.Levels[levelIndex];
				return stepId.StepIndex < levelAiPlanLevel.Steps.Count && levelAiPlanLevel.Steps[stepId.StepIndex] != null;
			}
			return stepId.LevelIndex != 0 && this.HasStep(this.Levels[stepId.LevelIndex].ParentStepId, levelIndex);
		}

		// Token: 0x06044695 RID: 280213 RVA: 0x011C5480 File Offset: 0x011C3680
		[return: Nullable(2)]
		public LevelAiPlanStep GetStep(LevelAiPlanStepId stepId)
		{
			if (stepId == null)
			{
				return null;
			}
			if (stepId.LevelIndex >= this.Levels.Count)
			{
				return null;
			}
			LevelAiPlanLevel levelAiPlanLevel = this.Levels[stepId.LevelIndex];
			if (levelAiPlanLevel == null)
			{
				return null;
			}
			return levelAiPlanLevel.Steps[stepId.StepIndex];
		}

		// Token: 0x06044696 RID: 280214 RVA: 0x011C54D0 File Offset: 0x011C36D0
		public bool IsComplete()
		{
			for (int i = 0; i < this.Levels.Count; i++)
			{
				if (!this.IsLevelComplete(i))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06044697 RID: 280215 RVA: 0x011C5500 File Offset: 0x011C3700
		public bool IsLevelComplete(int levelIndex)
		{
			if (!this.HasLevel(levelIndex))
			{
				return false;
			}
			LevelAiPlanLevel levelAiPlanLevel = this.Levels[levelIndex];
			if (levelAiPlanLevel.Steps.Count == 0)
			{
				return false;
			}
			int index = levelAiPlanLevel.Steps.Count - 1;
			LevelAiPlanStep levelAiPlanStep = levelAiPlanLevel.Steps[index];
			bool flag = levelAiPlanStep.SubLevelIndex != -1;
			if (flag || (levelAiPlanStep.Node != null && !levelAiPlanStep.Node.PlanNextNodesAfterThis))
			{
				return !flag || this.IsLevelComplete(levelAiPlanStep.SubLevelIndex);
			}
			return levelAiPlanStep.Node.NextNodes.Count == 0;
		}

		// Token: 0x06044698 RID: 280216 RVA: 0x011C559C File Offset: 0x011C379C
		public bool FindStepToAddAfter(LevelAiPlanStepId outPlanStepId)
		{
			for (int i = this.Levels.Count - 1; i >= 0; i--)
			{
				if (!this.IsLevelComplete(i))
				{
					LevelAiPlanLevel levelAiPlanLevel = this.Levels[i];
					outPlanStepId.LevelIndex = i;
					outPlanStepId.StepIndex = ((levelAiPlanLevel.Steps.Count > 0) ? (levelAiPlanLevel.Steps.Count - 1) : -1);
					return true;
				}
			}
			outPlanStepId.Reset();
			return false;
		}

		// Token: 0x06044699 RID: 280217 RVA: 0x011C560C File Offset: 0x011C380C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public IEnumerable<LevelAiStandaloneNode> GetNextNodes(LevelAiPlanStepId stepId)
		{
			LevelAiPlanLevel levelAiPlanLevel = this.Levels[stepId.LevelIndex];
			if (stepId.StepIndex != -1)
			{
				return levelAiPlanLevel.Steps[stepId.StepIndex].Node.NextNodes;
			}
			if (levelAiPlanLevel.ParentStepId.Equal(LevelAiPlanStepId.None))
			{
				return this.LevelAiAsset.StartNodes;
			}
			LevelAiPlanStep step = this.GetStep(levelAiPlanLevel.ParentStepId);
			if (step == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelAi, ELogAuthor.CJH, "子层的父节点未定义", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return step.Node.NextNodes;
		}

		// Token: 0x0604469A RID: 280218 RVA: 0x011C56A8 File Offset: 0x011C38A8
		public LevelAiWorldState GetWorldState(LevelAiPlanStepId stepId)
		{
			LevelAiPlanLevel levelAiPlanLevel = this.Levels[stepId.LevelIndex];
			if (stepId.StepIndex == -1)
			{
				return levelAiPlanLevel.WorldStateAtLevelStart;
			}
			return levelAiPlanLevel.Steps[stepId.StepIndex].WorldState;
		}

		// Token: 0x0604469B RID: 280219 RVA: 0x011C56F0 File Offset: 0x011C38F0
		public LevelAiPlan MakeCopy()
		{
			LevelAiPlan levelAiPlan = new LevelAiPlan(this.LevelAiAsset, null);
			levelAiPlan.Levels.Capacity = this.Levels.Count;
			for (int i = 0; i < this.Levels.Count; i++)
			{
				levelAiPlan.Levels.Add(this.Levels[i].MakeCopy());
			}
			levelAiPlan.Cost = this.Cost;
			return levelAiPlan;
		}

		// Token: 0x0604469C RID: 280220 RVA: 0x011C5760 File Offset: 0x011C3960
		public void GetSubNodesAtPlanStep(LevelAiPlanStepId stepId, List<SubNodesInfo> outSubNodesInfoGroup)
		{
			if (!this.HasStep(stepId, 0))
			{
				return;
			}
			LevelAiPlanStepId levelAiPlanStepId = stepId;
			for (;;)
			{
				LevelAiPlanLevel levelAiPlanLevel = this.Levels[levelAiPlanStepId.LevelIndex];
				LevelAiPlanStep levelAiPlanStep = levelAiPlanLevel.Steps[levelAiPlanStepId.StepIndex];
				outSubNodesInfoGroup.Add(levelAiPlanStep.SubNodesInfo);
				outSubNodesInfoGroup.Add(levelAiPlanLevel.RootSubNodesInfo);
				if (levelAiPlanStepId.LevelIndex <= 0)
				{
					break;
				}
				levelAiPlanStepId = levelAiPlanLevel.ParentStepId;
			}
		}

		// Token: 0x04026139 RID: 155961
		private readonly LevelAi LevelAiAsset;

		// Token: 0x0402613A RID: 155962
		public List<LevelAiPlanLevel> Levels = new List<LevelAiPlanLevel>();

		// Token: 0x0402613B RID: 155963
		public int Cost;
	}
}
