using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E19 RID: 28185
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiPlanInstance
	{
		// Token: 0x060446A7 RID: 280231 RVA: 0x011C5905 File Offset: 0x011C3B05
		public void Initialize(CharacterPlanComponent ownerComponent)
		{
			this.OwnerComponent = ownerComponent;
		}

		// Token: 0x060446A8 RID: 280232 RVA: 0x011C590E File Offset: 0x011C3B0E
		public bool IsPlanning()
		{
			return this.CurrentPlanner != null;
		}

		// Token: 0x060446A9 RID: 280233 RVA: 0x011C5919 File Offset: 0x011C3B19
		public bool HasPlan()
		{
			return this.CurrentPlan != null && this.CurrentPlanStartedExecution;
		}

		// Token: 0x060446AA RID: 280234 RVA: 0x011C592B File Offset: 0x011C3B2B
		public bool HasActiveTasks()
		{
			return this.CurrentlyExecutingStepIds.Count > 0 || this.PendingExecutionStepIds.Count > 0 || this.CurrentlyAbortingStepIds.Count > 0;
		}

		// Token: 0x060446AB RID: 280235 RVA: 0x011C5959 File Offset: 0x011C3B59
		public bool HasActivePlan()
		{
			return this.HasPlan() && this.HasActiveTasks();
		}

		// Token: 0x060446AC RID: 280236 RVA: 0x011C596B File Offset: 0x011C3B6B
		public bool CanLoop()
		{
			return this.Loop && !this.OwnerComponent.Paused;
		}

		// Token: 0x060446AD RID: 280237 RVA: 0x011C5985 File Offset: 0x011C3B85
		public void Start()
		{
			if (this.Status == ELevelAiPlanInstanceStatus.InProgress)
			{
				return;
			}
			this.Status = ELevelAiPlanInstanceStatus.InProgress;
			this.SavedPlan = null;
			this.ClearCurrentPlan();
			this.CancelActivePlanning();
			this.StartPlanning();
		}

		// Token: 0x060446AE RID: 280238 RVA: 0x011C59B4 File Offset: 0x011C3BB4
		public void Tick(float deltaTime)
		{
			if (this.Status == ELevelAiPlanInstanceStatus.InProgress && !this.HasActivePlan() && !this.IsPlanning())
			{
				this.StartPlanning();
			}
			if (this.Status == ELevelAiPlanInstanceStatus.InProgress && !this.HasActivePlan() && this.IsPlanning())
			{
				this.CurrentPlanner.DoPlanning();
			}
			if (this.HasActivePlan())
			{
				this.TickCurrentPlan(deltaTime);
			}
		}

		// Token: 0x060446AF RID: 280239 RVA: 0x011C5A13 File Offset: 0x011C3C13
		public void Stop()
		{
			if (this.Status != ELevelAiPlanInstanceStatus.InProgress)
			{
				return;
			}
			this.CancelActivePlanning();
			this.AbortCurrentPlan();
		}

		// Token: 0x060446B0 RID: 280240 RVA: 0x011C5A2B File Offset: 0x011C3C2B
		public void Pause()
		{
			if (this.Status != ELevelAiPlanInstanceStatus.InProgress)
			{
				return;
			}
			if (!this.IsPlanning() && this.HasActiveTasks())
			{
				this.SavedPlan = this.CurrentPlan;
			}
			this.CancelActivePlanning();
			this.AbortCurrentPlan();
		}

		// Token: 0x060446B1 RID: 280241 RVA: 0x011C5A60 File Offset: 0x011C3C60
		public void Resume()
		{
			if (this.Status == ELevelAiPlanInstanceStatus.InProgress)
			{
				return;
			}
			this.Status = ELevelAiPlanInstanceStatus.InProgress;
			this.ClearCurrentPlan();
			this.CancelActivePlanning();
			if (this.CanReuseSavedPlan())
			{
				this.StartPlanExecution(this.SavedPlan);
			}
			else
			{
				this.StartPlanning();
			}
			this.SavedPlan = null;
		}

		// Token: 0x060446B2 RID: 280242 RVA: 0x011C5AB0 File Offset: 0x011C3CB0
		public bool RecheckCurrentPlan()
		{
			List<LevelAiPlanStepId> list;
			if (this.CurrentPlanStartedExecution)
			{
				list = this.CurrentlyExecutingStepIds.ToList<LevelAiPlanStepId>();
			}
			else
			{
				list = new List<LevelAiPlanStepId>();
				this.GetNextStepsInCurrentPlan(list, new LevelAiPlanStepId(0, -1), false);
			}
			while (list.Count > 0)
			{
				LevelAiPlanStepId planStepId = list.Pop<LevelAiPlanStepId>();
				if (!this.UpdateSubNodes(planStepId, false, true))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060446B3 RID: 280243 RVA: 0x011C5B0B File Offset: 0x011C3D0B
		public void RePlan()
		{
			if (this.Status != ELevelAiPlanInstanceStatus.InProgress)
			{
				return;
			}
			this.AbortCurrentPlan();
			if (!this.IsPlanning())
			{
				this.StartPlanning();
			}
		}

		// Token: 0x060446B4 RID: 280244 RVA: 0x011C5B2C File Offset: 0x011C3D2C
		public void AbortCurrentPlan()
		{
			if (this.HasPlan())
			{
				for (int i = this.PendingExecutionStepIds.Count - 1; i >= 0; i--)
				{
					LevelAiPlanStepId planStepId = this.PendingExecutionStepIds[i];
					this.PendingExecutionStepIds.RemoveAt(i);
					this.FinishSubNodesAtPlanStep(planStepId, ELevelAiNodeResult.Aborted);
				}
				if (this.CurrentlyExecutingStepIds.Count > 0)
				{
					for (int j = this.CurrentlyExecutingStepIds.Count - 1; j >= 0; j--)
					{
						this.AbortExecutingPlanStep(this.CurrentlyExecutingStepIds[j]);
					}
					return;
				}
				this.OnPlanAbortFinished();
			}
		}

		// Token: 0x060446B5 RID: 280245 RVA: 0x011C5BB9 File Offset: 0x011C3DB9
		public void CancelActivePlanning()
		{
			if (this.IsPlanning())
			{
				this.CurrentPlanner.CancelPlanning();
				if (this.CurrentPlanner != null)
				{
					this.CurrentPlanner.Clear();
					this.CurrentPlanner = null;
				}
			}
		}

		// Token: 0x060446B6 RID: 280246 RVA: 0x011C5BE8 File Offset: 0x011C3DE8
		private void StartPlanning()
		{
			if (this.IsPlanning())
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelAi, ELogAuthor.CJH, "[StartPlanning] 规划中，重复调用", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.OwnerComponent != null && this.OwnerComponent.GetCurrentLevelAiAsset() != null)
			{
				this.CurrentPlanner = new LevelAiPlanner();
				this.CurrentPlanner.SetUp(this.OwnerComponent.GetCurrentLevelAiAsset(), this.OwnerComponent);
				this.CurrentPlanner.OnPlanningFinished = new Action<LevelAiPlanner, LevelAiPlan>(this.OnPlanningTaskFinished);
				this.CurrentPlanner.StartPlanning();
			}
		}

		// Token: 0x060446B7 RID: 280247 RVA: 0x011C5C78 File Offset: 0x011C3E78
		private void OnPlanningTaskFinished(LevelAiPlanner sender, LevelAiPlan producedPlan)
		{
			if (this.OwnerComponent == null)
			{
				return;
			}
			if (sender != this.CurrentPlanner)
			{
				return;
			}
			bool wasCanceled = sender.WasCanceled;
			sender.Clear();
			this.CurrentPlanner = null;
			if (wasCanceled)
			{
				this.Stop();
				return;
			}
			if (this.Status != ELevelAiPlanInstanceStatus.InProgress)
			{
				return;
			}
			if (producedPlan != null)
			{
				if (!this.StartPlanExecution(producedPlan))
				{
					this.Stop();
					return;
				}
			}
			else
			{
				this.Stop();
			}
		}

		// Token: 0x060446B8 RID: 280248 RVA: 0x011C5CD8 File Offset: 0x011C3ED8
		private bool StartPlanExecution(LevelAiPlan plan)
		{
			if (plan == null)
			{
				return false;
			}
			if (this.OwnerComponent == null || this.OwnerComponent.GetCurrentLevelAiAsset() == null)
			{
				return false;
			}
			this.InitializeCurrentPlan(plan);
			if (!this.RecheckCurrentPlan())
			{
				this.ClearCurrentPlan();
				return false;
			}
			bool flag = this.GetNextStepsInCurrentPlan(this.PendingExecutionStepIds, new LevelAiPlanStepId(0, -1), true) > 0;
			this.CurrentPlanStartedExecution = true;
			if (flag)
			{
				this.StartTasksExecution();
			}
			else
			{
				this.OnPlanExecutionSuccessfullyFinished();
			}
			return true;
		}

		// Token: 0x060446B9 RID: 280249 RVA: 0x011C5D48 File Offset: 0x011C3F48
		private void StartTasksExecution()
		{
			List<LevelAiPlanStepId> list = new List<LevelAiPlanStepId>();
			while (this.PendingExecutionStepIds.Count > 0)
			{
				LevelAiPlanStepId levelAiPlanStepId = this.PendingExecutionStepIds[0];
				if (levelAiPlanStepId == null)
				{
					return;
				}
				if (list.Contains(levelAiPlanStepId))
				{
					break;
				}
				this.PendingExecutionStepIds.RemoveAt(0);
				this.StartExecuteTask(levelAiPlanStepId);
				list.Add(levelAiPlanStepId);
			}
		}

		// Token: 0x060446BA RID: 280250 RVA: 0x011C5DA0 File Offset: 0x011C3FA0
		private ELevelAiNodeResult StartExecuteTask(LevelAiPlanStepId planStepId)
		{
			if (!this.HasPlan())
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelAi, ELogAuthor.CJH, "[StartExecuteTask] 当前没有规划", default(ReadOnlySpan<ValueTuple<string, object>>));
				return ELevelAiNodeResult.Failed;
			}
			LevelAiTask levelAiTask = this.CurrentPlan.GetStep(planStepId).Node as LevelAiTask;
			if (levelAiTask == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelAi, ELogAuthor.CJH, "[StartExecuteTask] 执行了非Task节点", default(ReadOnlySpan<ValueTuple<string, object>>));
				return ELevelAiNodeResult.Failed;
			}
			List<SubNodesInfo> list = new List<SubNodesInfo>();
			this.GetSubNodesInCurrentPlanToStart(list, planStepId);
			for (int i = list.Count - 1; i >= 0; i--)
			{
				SubNodesInfo subNodesInfo = list[i];
				if (!this.CheckConditionsOfDecorators(subNodesInfo, ELevelAiDecoratorCheckType.PlanExecuting))
				{
					this.FinishSubNodesAtPlanStep(planStepId, ELevelAiNodeResult.Aborted);
					this.AbortCurrentPlan();
					return ELevelAiNodeResult.Failed;
				}
				this.StartSubNodesInSubNodeGroup(subNodesInfo);
			}
			this.CurrentlyExecutingStepIds.Add(planStepId);
			ELevelAiNodeResult elevelAiNodeResult = levelAiTask.WrappedExecuteTask();
			if (elevelAiNodeResult != ELevelAiNodeResult.InProgress)
			{
				this.OnTaskFinished(levelAiTask, planStepId, elevelAiNodeResult);
			}
			return elevelAiNodeResult;
		}

		// Token: 0x060446BB RID: 280251 RVA: 0x011C5E80 File Offset: 0x011C4080
		private void TickCurrentPlan(float deltaTime)
		{
			LevelAiPlanInstance.<>c__DisplayClass30_0 CS$<>8__locals1;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.deltaTime = deltaTime;
			this.StartTasksExecution();
			foreach (LevelAiPlanStepId levelAiPlanStepId in this.CurrentlyExecutingStepIds.ToList<LevelAiPlanStepId>())
			{
				if (this.CurrentlyExecutingStepIds.Contains(levelAiPlanStepId) && !this.<TickCurrentPlan>g__updateAtPlanStep|30_0(levelAiPlanStepId, ref CS$<>8__locals1))
				{
					break;
				}
			}
		}

		// Token: 0x060446BC RID: 280252 RVA: 0x011C5F04 File Offset: 0x011C4104
		private bool UpdateSubNodes(LevelAiPlanStepId planStepId, bool bCheckConditionsExecution, bool bCheckConditionsRecheck)
		{
			bool flag = bCheckConditionsExecution || bCheckConditionsRecheck;
			List<SubNodesInfo> list = new List<SubNodesInfo>();
			this.GetSubNodesInCurrentPlanToTick(list, planStepId);
			for (int i = list.Count - 1; i >= 0; i--)
			{
				SubNodesInfo subNodesInfo = list[i];
				if (flag)
				{
					ELevelAiDecoratorCheckType checkType = bCheckConditionsRecheck ? ELevelAiDecoratorCheckType.PlanRecheck : ELevelAiDecoratorCheckType.PlanExecuting;
					if (!this.CheckConditionsOfDecorators(subNodesInfo, checkType))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060446BD RID: 280253 RVA: 0x011C5F58 File Offset: 0x011C4158
		private void AbortExecutingPlanStep(LevelAiPlanStepId planStepId)
		{
			LevelAiTask taskInCurrentPlan = this.GetTaskInCurrentPlan(planStepId);
			int index = this.CurrentlyExecutingStepIds.IndexOf(planStepId);
			this.CurrentlyExecutingStepIds.RemoveAt(index);
			this.CurrentlyExecutingStepIds.Add(planStepId);
			ELevelAiNodeResult elevelAiNodeResult = taskInCurrentPlan.WrappedAbortTask();
			if (elevelAiNodeResult != ELevelAiNodeResult.Aborted)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelAi, ELogAuthor.CJH, "[AbortExecutingPlanStep] 失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (elevelAiNodeResult == ELevelAiNodeResult.Aborted)
			{
				this.OnTaskFinished(taskInCurrentPlan, planStepId, elevelAiNodeResult);
			}
		}

		// Token: 0x060446BE RID: 280254 RVA: 0x011C5FC8 File Offset: 0x011C41C8
		public void OnTaskFinished(LevelAiTask task, LevelAiPlanStepId finishStepId, ELevelAiNodeResult result)
		{
			if (task == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelAi, ELogAuthor.CJH, "[OnTaskFinished] Task无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (!this.HasPlan())
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelAi, ELogAuthor.CJH, "[OnTaskFinished] Plan无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			task.WrappedOnTaskFinished(result);
			this.NotifySubLevelStepFinishedIfNeeded(finishStepId, result);
			if (result == ELevelAiNodeResult.Succeeded)
			{
				this.GetNextStepsInCurrentPlan(this.PendingExecutionStepIds, finishStepId, true);
			}
			this.FinishSubNodesAtPlanStep(finishStepId, result);
			int num = this.CurrentlyExecutingStepIds.IndexOf(finishStepId);
			if (num >= 0)
			{
				this.CurrentlyExecutingStepIds.RemoveAt(num);
			}
			if (result == ELevelAiNodeResult.Succeeded)
			{
				if (!this.HasActiveTasks())
				{
					this.OnPlanExecutionSuccessfullyFinished();
					return;
				}
			}
			else if (result == ELevelAiNodeResult.Aborted)
			{
				int num2 = this.CurrentlyAbortingStepIds.IndexOf(finishStepId);
				if (num2 >= 0)
				{
					this.CurrentlyAbortingStepIds.RemoveAt(num2);
				}
				if (!this.HasActiveTasks())
				{
					this.OnPlanAbortFinished();
					return;
				}
			}
			else
			{
				this.AbortCurrentPlan();
			}
		}

		// Token: 0x060446BF RID: 280255 RVA: 0x011C60A8 File Offset: 0x011C42A8
		public bool NotifyEventBasedDecoratorCondition(LevelAiDecorator decorator, bool bFinalConditionValue)
		{
			if (!this.HasActivePlan())
			{
				return false;
			}
			if (!bFinalConditionValue)
			{
				decorator.PrintDescription("[NotifyEventBasedDecoratorCondition] Decorator通知RePlan", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.RePlan();
				return true;
			}
			return false;
		}

		// Token: 0x060446C0 RID: 280256 RVA: 0x011C60E0 File Offset: 0x011C42E0
		private void NotifySubLevelStepFinishedIfNeeded(LevelAiPlanStepId finishedStepId, ELevelAiNodeResult result)
		{
			if (this.CurrentlyExecutingStepIds.Count == 0)
			{
				return;
			}
			LevelAiPlanLevel levelAiPlanLevel = this.CurrentPlan.Levels[finishedStepId.LevelIndex];
			LevelAiPlanStepId parentStepId = levelAiPlanLevel.ParentStepId;
			bool bFinishedLevel = result == ELevelAiNodeResult.Succeeded && finishedStepId.StepIndex == levelAiPlanLevel.Steps.Count - 1;
			if (!parentStepId.Equal(LevelAiPlanStepId.None))
			{
				LevelAiPlanStep step = this.CurrentPlan.GetStep(parentStepId);
				if (step.Node != null && step.Node.OnSubLevelStepFinished(this, parentStepId, finishedStepId, result, bFinishedLevel))
				{
					this.NotifySubLevelStepFinishedIfNeeded(parentStepId, result);
				}
			}
		}

		// Token: 0x060446C1 RID: 280257 RVA: 0x011C6171 File Offset: 0x011C4371
		private void OnPlanAbortFinished()
		{
			if (this.CanLoop())
			{
				this.Status = ELevelAiPlanInstanceStatus.InProgress;
			}
			else
			{
				this.Status = ELevelAiPlanInstanceStatus.Failed;
			}
			this.ClearCurrentPlan();
		}

		// Token: 0x060446C2 RID: 280258 RVA: 0x011C6191 File Offset: 0x011C4391
		private void OnPlanExecutionSuccessfullyFinished()
		{
			if (this.CanLoop())
			{
				this.Status = ELevelAiPlanInstanceStatus.InProgress;
			}
			else
			{
				this.Status = ELevelAiPlanInstanceStatus.Succeeded;
			}
			this.ClearCurrentPlan();
		}

		// Token: 0x060446C3 RID: 280259 RVA: 0x011C61B4 File Offset: 0x011C43B4
		private void InitializeCurrentPlan(LevelAiPlan newPlan)
		{
			if (this.CurrentPlan != null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelAi, ELogAuthor.CJH, "[OnPlanningTaskFinished] 初始化规划失败，当前规划正在运行", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.CurrentPlan = newPlan;
			foreach (LevelAiPlanLevel levelAiPlanLevel in this.CurrentPlan.Levels)
			{
				foreach (LevelAiPlanStep levelAiPlanStep in levelAiPlanLevel.Steps)
				{
					levelAiPlanStep.SubNodesInfo.SubDecorators.Clear();
					foreach (LevelAiDecorator item in levelAiPlanStep.Node.Decorators)
					{
						levelAiPlanStep.SubNodesInfo.SubDecorators.Add(item);
					}
				}
			}
		}

		// Token: 0x060446C4 RID: 280260 RVA: 0x011C62D4 File Offset: 0x011C44D4
		private void ClearCurrentPlan()
		{
			if (this.CurrentPlan != null)
			{
				foreach (LevelAiPlanLevel levelAiPlanLevel in this.CurrentPlan.Levels)
				{
					foreach (LevelAiPlanStep levelAiPlanStep in levelAiPlanLevel.Steps)
					{
						levelAiPlanStep.SubNodesInfo.SubDecorators.Clear();
					}
				}
				this.CurrentPlan = null;
			}
			this.CurrentlyExecutingStepIds.Clear();
			this.PendingExecutionStepIds.Clear();
			this.CurrentlyAbortingStepIds.Clear();
			this.CurrentPlanStartedExecution = false;
		}

		// Token: 0x060446C5 RID: 280261 RVA: 0x011C63A4 File Offset: 0x011C45A4
		private LevelAiTask GetTaskInCurrentPlan(LevelAiPlanStepId executingStepId)
		{
			return this.CurrentPlan.GetStep(executingStepId).Node as LevelAiTask;
		}

		// Token: 0x060446C6 RID: 280262 RVA: 0x011C63BC File Offset: 0x011C45BC
		private int GetNextStepsInCurrentPlan(List<LevelAiPlanStepId> outStepIds, LevelAiPlanStepId stepId, bool bIsExecutingPlan = true)
		{
			GetNextStepsContext getNextStepsContext = new GetNextStepsContext(this.CurrentPlan, bIsExecutingPlan, outStepIds);
			getNextStepsContext.AddNextStepsAfter(stepId);
			return getNextStepsContext.GetNumSubmittedSteps();
		}

		// Token: 0x060446C7 RID: 280263 RVA: 0x011C63D8 File Offset: 0x011C45D8
		private void GetSubNodesInCurrentPlanToStart(List<SubNodesInfo> outSubNodesInfoGroup, LevelAiPlanStepId stepId)
		{
			if (this.CurrentPlan == null || !this.CurrentPlan.HasStep(stepId, 0))
			{
				return;
			}
			LevelAiPlanStepId levelAiPlanStepId = stepId;
			for (;;)
			{
				LevelAiPlanLevel levelAiPlanLevel = this.CurrentPlan.Levels[levelAiPlanStepId.LevelIndex];
				LevelAiPlanStep levelAiPlanStep = levelAiPlanLevel.Steps[levelAiPlanStepId.StepIndex];
				if (levelAiPlanStep.SubNodesInfo.SubNodesExecuting)
				{
					break;
				}
				outSubNodesInfoGroup.Add(levelAiPlanStep.SubNodesInfo);
				if (levelAiPlanStepId.LevelIndex <= 0)
				{
					break;
				}
				levelAiPlanStepId = levelAiPlanLevel.ParentStepId;
			}
		}

		// Token: 0x060446C8 RID: 280264 RVA: 0x011C6454 File Offset: 0x011C4654
		private void GetSubNodesInCurrentPlanToTick(List<SubNodesInfo> outSubNodesInfoGroup, LevelAiPlanStepId stepId)
		{
			if (this.CurrentPlan == null || !this.CurrentPlan.HasStep(stepId, 0))
			{
				return;
			}
			LevelAiPlanStepId levelAiPlanStepId = stepId;
			for (;;)
			{
				LevelAiPlanLevel levelAiPlanLevel = this.CurrentPlan.Levels[levelAiPlanStepId.LevelIndex];
				LevelAiPlanStep levelAiPlanStep = levelAiPlanLevel.Steps[levelAiPlanStepId.StepIndex];
				if (levelAiPlanStep.SubNodesInfo.LastFrameSubNodesTicked == Singleton<Time>.Instance.Frame)
				{
					break;
				}
				outSubNodesInfoGroup.Add(levelAiPlanStep.SubNodesInfo);
				if (levelAiPlanStepId.LevelIndex <= 0)
				{
					break;
				}
				levelAiPlanStepId = levelAiPlanLevel.ParentStepId;
			}
		}

		// Token: 0x060446C9 RID: 280265 RVA: 0x011C64DC File Offset: 0x011C46DC
		private void GetSubNodesInCurrentPlanToFinish(List<SubNodesInfo> outSubNodesInfoGroup, LevelAiPlanStepId stepId)
		{
			if (this.CurrentPlan == null || !this.CurrentPlan.HasStep(stepId, 0))
			{
				return;
			}
			LevelAiPlanStepId levelAiPlanStepId = stepId;
			for (;;)
			{
				LevelAiPlanLevel levelAiPlanLevel = this.CurrentPlan.Levels[levelAiPlanStepId.LevelIndex];
				LevelAiPlanStep levelAiPlanStep = levelAiPlanLevel.Steps[levelAiPlanStepId.StepIndex];
				if (!levelAiPlanStep.SubNodesInfo.SubNodesExecuting)
				{
					break;
				}
				outSubNodesInfoGroup.Add(levelAiPlanStep.SubNodesInfo);
				bool flag = true;
				foreach (LevelAiPlanStepId levelAiPlanStepId2 in this.PendingExecutionStepIds)
				{
					if ((levelAiPlanStepId2.LevelIndex != levelAiPlanStepId.LevelIndex || levelAiPlanStepId2.StepIndex > levelAiPlanStepId.StepIndex) && this.CurrentPlan.HasStep(levelAiPlanStepId2, levelAiPlanStepId.LevelIndex))
					{
						flag = false;
					}
				}
				if (!flag || levelAiPlanStepId.LevelIndex <= 0)
				{
					break;
				}
				levelAiPlanStepId = levelAiPlanLevel.ParentStepId;
			}
		}

		// Token: 0x060446CA RID: 280266 RVA: 0x011C65D8 File Offset: 0x011C47D8
		private void GetSubNodesInCurrentPlanToAbort(List<SubNodesInfo> outSubNodesInfoGroup, LevelAiPlanStepId stepId)
		{
			if (this.CurrentPlan == null || !this.CurrentPlan.HasStep(stepId, 0))
			{
				return;
			}
			LevelAiPlanStepId levelAiPlanStepId = stepId;
			for (;;)
			{
				LevelAiPlanLevel levelAiPlanLevel = this.CurrentPlan.Levels[levelAiPlanStepId.LevelIndex];
				LevelAiPlanStep levelAiPlanStep = levelAiPlanLevel.Steps[levelAiPlanStepId.StepIndex];
				if (!levelAiPlanStep.SubNodesInfo.SubNodesExecuting)
				{
					break;
				}
				outSubNodesInfoGroup.Add(levelAiPlanStep.SubNodesInfo);
				if (levelAiPlanStepId.LevelIndex <= 0)
				{
					break;
				}
				levelAiPlanStepId = levelAiPlanLevel.ParentStepId;
			}
		}

		// Token: 0x060446CB RID: 280267 RVA: 0x011C6654 File Offset: 0x011C4854
		private bool CheckConditionsOfDecorators(SubNodesInfo subNodesInfo, ELevelAiDecoratorCheckType checkType)
		{
			if (this.CurrentPlan == null)
			{
				return false;
			}
			using (List<LevelAiDecorator>.Enumerator enumerator = subNodesInfo.SubDecorators.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.WrappedCheckCondition(checkType) == ELevelAiDecoratorCheckResult.Failed)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060446CC RID: 280268 RVA: 0x011C66B8 File Offset: 0x011C48B8
		private void StartSubNodesInSubNodeGroup(SubNodesInfo subNodesInfo)
		{
			if (subNodesInfo.SubNodesExecuting)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelAi, ELogAuthor.CJH, "[StartSubNodesInSubNodeGroup] 错误的调用，子节点执行中", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			subNodesInfo.SubNodesExecuting = true;
			foreach (LevelAiDecorator subNode in subNodesInfo.SubDecorators)
			{
				LevelAiPlanInstance.<StartSubNodesInSubNodeGroup>g__startExecution|47_0(subNode);
			}
		}

		// Token: 0x060446CD RID: 280269 RVA: 0x011C6734 File Offset: 0x011C4934
		private void FinishSubNodesAtPlanStep(LevelAiPlanStepId planStepId, ELevelAiNodeResult result)
		{
			List<SubNodesInfo> list = new List<SubNodesInfo>();
			switch (result)
			{
			case ELevelAiNodeResult.Succeeded:
				this.GetSubNodesInCurrentPlanToFinish(list, planStepId);
				break;
			case ELevelAiNodeResult.Failed:
			case ELevelAiNodeResult.Aborted:
				this.GetSubNodesInCurrentPlanToAbort(list, planStepId);
				break;
			case ELevelAiNodeResult.InProgress:
				Singleton<Log>.Instance.Error(ELogModule.LevelAi, ELogAuthor.CJH, "[FinishSubNodesAtPlanStep] 错误的调用，结束时节点状态为InProgress", default(ReadOnlySpan<ValueTuple<string, object>>));
				break;
			}
			foreach (SubNodesInfo subNodesInfo in list)
			{
				this.FinishSubNodesInSubNodeGroup(subNodesInfo, result);
			}
		}

		// Token: 0x060446CE RID: 280270 RVA: 0x011C67D4 File Offset: 0x011C49D4
		private void FinishSubNodesInSubNodeGroup(SubNodesInfo subNodesInfo, ELevelAiNodeResult result)
		{
			LevelAiPlanInstance.<>c__DisplayClass49_0 CS$<>8__locals1;
			CS$<>8__locals1.result = result;
			if (!subNodesInfo.SubNodesExecuting)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelAi, ELogAuthor.CJH, "[FinishSubNodesInSubNodeGroup] 错误的调用，子节点非执行中", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			subNodesInfo.SubNodesExecuting = false;
			List<LevelAiDecorator> subDecorators = subNodesInfo.SubDecorators;
			for (int i = subDecorators.Count - 1; i >= 0; i--)
			{
				LevelAiPlanInstance.<FinishSubNodesInSubNodeGroup>g__finishExecution|49_0(subDecorators[i], ref CS$<>8__locals1);
			}
		}

		// Token: 0x060446CF RID: 280271 RVA: 0x011C6840 File Offset: 0x011C4A40
		[return: Nullable(2)]
		public ActiveTaskInfo FindActiveTaskInfo(LevelAiTask task)
		{
			if (!this.HasActivePlan())
			{
				return null;
			}
			LevelAiPlanStepId levelAiPlanStepId = this.CurrentlyExecutingStepIds.FirstOrDefault((LevelAiPlanStepId value) => task == this.GetTaskInCurrentPlan(value));
			if (levelAiPlanStepId != null)
			{
				return new ActiveTaskInfo
				{
					PlanInstance = this,
					PlanStepId = levelAiPlanStepId
				};
			}
			levelAiPlanStepId = this.CurrentlyAbortingStepIds.FirstOrDefault((LevelAiPlanStepId value) => task == this.GetTaskInCurrentPlan(value));
			if (levelAiPlanStepId != null)
			{
				return new ActiveTaskInfo
				{
					PlanInstance = this,
					PlanStepId = levelAiPlanStepId
				};
			}
			return null;
		}

		// Token: 0x060446D0 RID: 280272 RVA: 0x011C68CC File Offset: 0x011C4ACC
		[return: Nullable(2)]
		public ActiveTaskInfo FindActiveDecoratorInfo(LevelAiDecorator decorator)
		{
			LevelAiPlanInstance.<>c__DisplayClass51_0 CS$<>8__locals1 = new LevelAiPlanInstance.<>c__DisplayClass51_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.decorator = decorator;
			if (!this.HasActivePlan())
			{
				return null;
			}
			CS$<>8__locals1.subNodesInfoGroup = new List<SubNodesInfo>();
			LevelAiPlanStepId levelAiPlanStepId = this.CurrentlyExecutingStepIds.FirstOrDefault(new Func<LevelAiPlanStepId, bool>(CS$<>8__locals1.<FindActiveDecoratorInfo>g__findDecorator|0));
			if (levelAiPlanStepId != null)
			{
				return new ActiveTaskInfo
				{
					PlanInstance = this,
					PlanStepId = levelAiPlanStepId
				};
			}
			levelAiPlanStepId = this.CurrentlyAbortingStepIds.FirstOrDefault(new Func<LevelAiPlanStepId, bool>(CS$<>8__locals1.<FindActiveDecoratorInfo>g__findDecorator|0));
			if (levelAiPlanStepId != null)
			{
				return new ActiveTaskInfo
				{
					PlanInstance = this,
					PlanStepId = levelAiPlanStepId
				};
			}
			return null;
		}

		// Token: 0x060446D1 RID: 280273 RVA: 0x011C6963 File Offset: 0x011C4B63
		private bool CanReuseSavedPlan()
		{
			return this.SavedPlan != null;
		}

		// Token: 0x060446D3 RID: 280275 RVA: 0x011C699E File Offset: 0x011C4B9E
		[CompilerGenerated]
		private bool <TickCurrentPlan>g__updateAtPlanStep|30_0(LevelAiPlanStepId planStepId, ref LevelAiPlanInstance.<>c__DisplayClass30_0 A_2)
		{
			if (!this.UpdateSubNodes(planStepId, true, false))
			{
				this.AbortCurrentPlan();
				return false;
			}
			this.GetTaskInCurrentPlan(planStepId).WrappedTickTask(A_2.deltaTime);
			return true;
		}

		// Token: 0x060446D4 RID: 280276 RVA: 0x011C69C6 File Offset: 0x011C4BC6
		[CompilerGenerated]
		internal static void <StartSubNodesInSubNodeGroup>g__startExecution|47_0(LevelAiDecorator subNode)
		{
			if (subNode != null)
			{
				subNode.WrappedExecutionStart();
			}
		}

		// Token: 0x060446D5 RID: 280277 RVA: 0x011C69D1 File Offset: 0x011C4BD1
		[CompilerGenerated]
		internal static void <FinishSubNodesInSubNodeGroup>g__finishExecution|49_0(LevelAiDecorator subNode, ref LevelAiPlanInstance.<>c__DisplayClass49_0 A_1)
		{
			if (subNode != null)
			{
				subNode.WrappedExecutionFinish(A_1.result);
			}
		}

		// Token: 0x04026142 RID: 155970
		private ELevelAiPlanInstanceStatus Status;

		// Token: 0x04026143 RID: 155971
		[Nullable(2)]
		private CharacterPlanComponent OwnerComponent;

		// Token: 0x04026144 RID: 155972
		private readonly List<LevelAiPlanStepId> CurrentlyExecutingStepIds = new List<LevelAiPlanStepId>();

		// Token: 0x04026145 RID: 155973
		private readonly List<LevelAiPlanStepId> PendingExecutionStepIds = new List<LevelAiPlanStepId>();

		// Token: 0x04026146 RID: 155974
		private readonly List<LevelAiPlanStepId> CurrentlyAbortingStepIds = new List<LevelAiPlanStepId>();

		// Token: 0x04026147 RID: 155975
		[Nullable(2)]
		private LevelAiPlan CurrentPlan;

		// Token: 0x04026148 RID: 155976
		[Nullable(2)]
		private LevelAiPlanner CurrentPlanner;

		// Token: 0x04026149 RID: 155977
		private bool CurrentPlanStartedExecution;

		// Token: 0x0402614A RID: 155978
		private readonly bool Loop = true;

		// Token: 0x0402614B RID: 155979
		[Nullable(2)]
		private LevelAiPlan SavedPlan;
	}
}
