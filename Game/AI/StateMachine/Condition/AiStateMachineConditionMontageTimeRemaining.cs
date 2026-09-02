using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.AI.StateMachine.Task;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x02007100 RID: 28928
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionMontageTimeRemaining : AiStateMachineCondition
	{
		// Token: 0x060461C7 RID: 287175 RVA: 0x0126A6E5 File Offset: 0x012688E5
		public AiStateMachineConditionMontageTimeRemaining(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x060461C8 RID: 287176 RVA: 0x0126A6F0 File Offset: 0x012688F0
		protected override bool RegisterEvents()
		{
			if (base.RegisterEvents() && this.TaskMontage != null && !Singleton<EventSystem>.Instance.HasWithTarget(this.TaskMontage, EEventName.OnMontageRemain, new Action<float>(this.OnMontageRemain)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(this.TaskMontage, EEventName.OnMontageRemain, new Action<float>(this.OnMontageRemain));
				return true;
			}
			return false;
		}

		// Token: 0x060461C9 RID: 287177 RVA: 0x0126A758 File Offset: 0x01268958
		protected override bool UnregisterEvents()
		{
			if (base.UnregisterEvents() && this.TaskMontage != null && Singleton<EventSystem>.Instance.HasWithTarget(this.TaskMontage, EEventName.OnMontageRemain, new Action<float>(this.OnMontageRemain)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.TaskMontage, EEventName.OnMontageRemain, new Action<float>(this.OnMontageRemain));
				return true;
			}
			return false;
		}

		// Token: 0x060461CA RID: 287178 RVA: 0x0126A7C0 File Offset: 0x012689C0
		private void InitMontageRemain()
		{
			if (this.TaskMontage != null)
			{
				AiStateMachineTaskMontage aiStateMachineTaskMontage = this.TaskMontage as AiStateMachineTaskMontage;
				if (aiStateMachineTaskMontage != null)
				{
					aiStateMachineTaskMontage.RemainedTrigger = this.Time;
				}
				else
				{
					AiStateMachineTaskRandomMontage aiStateMachineTaskRandomMontage = this.TaskMontage as AiStateMachineTaskRandomMontage;
					if (aiStateMachineTaskRandomMontage != null)
					{
						aiStateMachineTaskRandomMontage.RemainedTrigger = this.Time;
					}
				}
				this.RegisterEvents();
			}
		}

		// Token: 0x060461CB RID: 287179 RVA: 0x0126A814 File Offset: 0x01268A14
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.HasTaskFinishCondition = true;
			this.Time = condition.CondMontageTimeRemaining.Time * 0.001f;
			AiStateMachineTask task = this.Node.Task;
			if (task != null && task.Type == CombatStateMachineDefine.Fsm.ETaskType.TaskMontage)
			{
				this.TaskMontage = (this.Node.Task as AiStateMachineTaskMontage);
				this.InitMontageRemain();
			}
			else
			{
				AiStateMachineTask task2 = this.Node.Task;
				if (task2 != null && task2.Type == CombatStateMachineDefine.Fsm.ETaskType.TaskRandomMontage)
				{
					this.TaskMontage = (this.Node.Task as AiStateMachineTaskRandomMontage);
					this.InitMontageRemain();
				}
				else
				{
					AiStateMachineTask task3 = this.Node.Task;
					if (task3 == null || task3.Type != CombatStateMachineDefine.Fsm.ETaskType.TaskBeHitMontage)
					{
						AiStateMachineGroup owner = this.Node.Owner;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 3);
						defaultInterpolatedStringHandler.AppendLiteral("初始化条件[动画剩余时间]失败，node[");
						defaultInterpolatedStringHandler.AppendFormatted(this.Node.Name);
						defaultInterpolatedStringHandler.AppendLiteral("|");
						defaultInterpolatedStringHandler.AppendFormatted<int>(this.Node.Uuid);
						defaultInterpolatedStringHandler.AppendLiteral("], to:");
						defaultInterpolatedStringHandler.AppendFormatted<int>(this.Transition.To);
						owner.PushErrorMessage(defaultInterpolatedStringHandler.ToStringAndClear());
						return true;
					}
					this.TaskMontage = (this.Node.Task as AiStateMachineTaskBeHitMontage);
					this.InitMontageRemain();
				}
			}
			return true;
		}

		// Token: 0x060461CC RID: 287180 RVA: 0x0126A974 File Offset: 0x01268B74
		protected override void OnEnter()
		{
			IAiTaskMontage taskMontage = this.TaskMontage;
			if (taskMontage == null || !taskMontage.HasResource)
			{
				this.ResultSelf = false;
				return;
			}
			if (this.Node.TaskFinished)
			{
				this.ResultSelf = true;
				return;
			}
			IAiTaskMontage taskMontage2 = this.TaskMontage;
			if (taskMontage2 != null && taskMontage2.Playing)
			{
				this.ResultSelf = (this.TaskMontage.GetTimeRemaining() <= (double)this.Time);
			}
		}

		// Token: 0x060461CD RID: 287181 RVA: 0x0126A9E8 File Offset: 0x01268BE8
		protected override void OnTick()
		{
			IAiTaskMontage taskMontage = this.TaskMontage;
			if (taskMontage == null || !taskMontage.HasResource)
			{
				this.ResultSelf = false;
				return;
			}
			if (this.Node.TaskFinished)
			{
				this.ResultSelf = true;
				return;
			}
			IAiTaskMontage taskMontage2 = this.TaskMontage;
			if (taskMontage2 != null && taskMontage2.Playing)
			{
				this.ResultSelf = (this.TaskMontage.GetTimeRemaining() <= (double)this.Time);
			}
		}

		// Token: 0x060461CE RID: 287182 RVA: 0x0126AA5A File Offset: 0x01268C5A
		protected override void OnExit()
		{
			this.ResultSelf = false;
		}

		// Token: 0x060461CF RID: 287183 RVA: 0x0126AA63 File Offset: 0x01268C63
		protected override void OnClear()
		{
			this.UnregisterEvents();
			this.TaskMontage = null;
		}

		// Token: 0x060461D0 RID: 287184 RVA: 0x0126AA74 File Offset: 0x01268C74
		private void OnMontageRemain(float remainTime)
		{
			this.ResultSelf = true;
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionMontageTimeRemaining", this.Node.Name);
			}
		}

		// Token: 0x060461D1 RID: 287185 RVA: 0x0126AAC4 File Offset: 0x01268CC4
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, outBuilder);
			appendInterpolatedStringHandler.AppendLiteral("动画剩余时间小于 [");
			appendInterpolatedStringHandler.AppendFormatted<float>(this.Time, "F1");
			appendInterpolatedStringHandler.AppendLiteral("\n");
			outBuilder.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x0402753C RID: 161084
		private float Time;

		// Token: 0x0402753D RID: 161085
		[Nullable(2)]
		private IAiTaskMontage TaskMontage;
	}
}
