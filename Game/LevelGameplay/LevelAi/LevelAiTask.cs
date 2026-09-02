using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelAi
{
	// Token: 0x02006E1E RID: 28190
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelAiTask : LevelAiStandaloneNode
	{
		// Token: 0x060446F6 RID: 280310 RVA: 0x011C71C2 File Offset: 0x011C53C2
		public override void Serialize(CharacterPlanComponent ownerComponent, CreatureDataComponent creatureDataComp, string description, [Nullable(2)] ActionParams @params = null)
		{
			base.Serialize(ownerComponent, creatureDataComp, description, null);
			this.Params = @params;
		}

		// Token: 0x060446F7 RID: 280311 RVA: 0x011C71D8 File Offset: 0x011C53D8
		public unsafe override void MakePlanExpansions(PlanningContext context, LevelAiWorldState worldState)
		{
			string reason = "Task Make Plan Expansions";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LevelIndex", context.CurrentLevelIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("StepIndex", context.CurrentStepIndex);
			base.PrintDescription(reason, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.CreatePlanSteps(context, worldState.MakeCopy());
		}

		// Token: 0x060446F8 RID: 280312 RVA: 0x011C7254 File Offset: 0x011C5454
		public ELevelAiNodeResult WrappedExecuteTask()
		{
			base.PrintDescription("Execute Task", default(ReadOnlySpan<ValueTuple<string, object>>));
			return this.ExecuteTask();
		}

		// Token: 0x060446F9 RID: 280313 RVA: 0x011C727C File Offset: 0x011C547C
		public ELevelAiNodeResult WrappedAbortTask()
		{
			base.PrintDescription("Abort Task", default(ReadOnlySpan<ValueTuple<string, object>>));
			return this.AbortTask();
		}

		// Token: 0x060446FA RID: 280314 RVA: 0x011C72A3 File Offset: 0x011C54A3
		public void WrappedTickTask(float deltaTime)
		{
			if (this.NotifyTick)
			{
				this.TickTask(deltaTime);
			}
		}

		// Token: 0x060446FB RID: 280315 RVA: 0x011C72B4 File Offset: 0x011C54B4
		public void WrappedOnTaskFinished(ELevelAiNodeResult result)
		{
			if (this.NotifyTaskFinished)
			{
				string reason = "Task Finished";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Result", result);
				base.PrintDescription(reason, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.OnTaskFinished(result);
			}
		}

		// Token: 0x060446FC RID: 280316 RVA: 0x011C72F4 File Offset: 0x011C54F4
		protected virtual void CreatePlanSteps(PlanningContext context, LevelAiWorldState worldStateAfterTask)
		{
			context.SubmitCandidatePlanStep(this, worldStateAfterTask, 0);
		}

		// Token: 0x060446FD RID: 280317 RVA: 0x011C7300 File Offset: 0x011C5500
		protected void FinishLatentTask(ELevelAiNodeResult taskResult)
		{
			ActiveTaskInfo activeTaskInfo = base.CharacterPlanComponent.FindActiveTaskInfo(this);
			if (activeTaskInfo == null)
			{
				return;
			}
			activeTaskInfo.PlanInstance.OnTaskFinished(this, activeTaskInfo.PlanStepId, taskResult);
		}

		// Token: 0x060446FE RID: 280318 RVA: 0x011C7331 File Offset: 0x011C5531
		protected virtual ELevelAiNodeResult ExecuteTask()
		{
			return ELevelAiNodeResult.Succeeded;
		}

		// Token: 0x060446FF RID: 280319 RVA: 0x011C7334 File Offset: 0x011C5534
		protected virtual ELevelAiNodeResult AbortTask()
		{
			return ELevelAiNodeResult.Aborted;
		}

		// Token: 0x06044700 RID: 280320 RVA: 0x011C7337 File Offset: 0x011C5537
		protected virtual void TickTask(float deltaTime)
		{
		}

		// Token: 0x06044701 RID: 280321 RVA: 0x011C7339 File Offset: 0x011C5539
		protected virtual void OnTaskFinished(ELevelAiNodeResult result)
		{
		}

		// Token: 0x0402615F RID: 155999
		protected bool NotifyTick;

		// Token: 0x04026160 RID: 156000
		protected bool NotifyTaskFinished;

		// Token: 0x04026161 RID: 156001
		[Nullable(2)]
		protected ActionParams Params;
	}
}
