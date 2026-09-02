using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.AI.StateMachine.Task;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070FF RID: 28927
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionMontageTimeElapsing : AiStateMachineCondition
	{
		// Token: 0x060461BC RID: 287164 RVA: 0x0126A292 File Offset: 0x01268492
		public AiStateMachineConditionMontageTimeElapsing(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x060461BD RID: 287165 RVA: 0x0126A2A0 File Offset: 0x012684A0
		protected override bool RegisterEvents()
		{
			if (base.RegisterEvents() && this.TaskMontage != null && !Singleton<EventSystem>.Instance.HasWithTarget(this.TaskMontage, EEventName.OnMontageRemain, new Action<float>(this.OnMontageRemain)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(this.TaskMontage, EEventName.OnMontageRemain, new Action<float>(this.OnMontageRemain));
				return true;
			}
			return false;
		}

		// Token: 0x060461BE RID: 287166 RVA: 0x0126A308 File Offset: 0x01268508
		protected override bool UnregisterEvents()
		{
			if (base.UnregisterEvents() && this.TaskMontage != null && Singleton<EventSystem>.Instance.HasWithTarget(this.TaskMontage, EEventName.OnMontageRemain, new Action<float>(this.OnMontageRemain)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.TaskMontage, EEventName.OnMontageRemain, new Action<float>(this.OnMontageRemain));
				return true;
			}
			return false;
		}

		// Token: 0x060461BF RID: 287167 RVA: 0x0126A370 File Offset: 0x01268570
		private void InitMontageRemain()
		{
			if (this.TaskMontage != null)
			{
				double timeLength = this.TaskMontage.GetTimeLength();
				double num = (timeLength > 0.0 && timeLength >= this.TaskMontage.GetTimeElapsing()) ? (timeLength - this.TaskMontage.GetTimeElapsing()) : -1.0;
				this.TaskMontage.RemainedTrigger = (float)num;
				this.RegisterEvents();
			}
		}

		// Token: 0x060461C0 RID: 287168 RVA: 0x0126A3E0 File Offset: 0x012685E0
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.HasTaskFinishCondition = true;
			this.Time = condition.CondMontageTimeElapsing.Time * 0.001f;
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
						defaultInterpolatedStringHandler.AppendLiteral("初始化条件[动画播放时间]失败，node[");
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

		// Token: 0x060461C1 RID: 287169 RVA: 0x0126A540 File Offset: 0x01268740
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
				this.ResultSelf = (this.TaskMontage.GetTimeElapsing() >= (double)this.Time);
			}
		}

		// Token: 0x060461C2 RID: 287170 RVA: 0x0126A5B4 File Offset: 0x012687B4
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
				this.ResultSelf = (this.TaskMontage.GetTimeElapsing() >= (double)this.Time);
			}
		}

		// Token: 0x060461C3 RID: 287171 RVA: 0x0126A626 File Offset: 0x01268826
		protected override void OnExit()
		{
			this.ResultSelf = false;
		}

		// Token: 0x060461C4 RID: 287172 RVA: 0x0126A62F File Offset: 0x0126882F
		protected override void OnClear()
		{
			this.UnregisterEvents();
			this.TaskMontage = null;
		}

		// Token: 0x060461C5 RID: 287173 RVA: 0x0126A640 File Offset: 0x01268840
		private void OnMontageRemain(float remainTime)
		{
			this.ResultSelf = true;
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionMontageTimeElapsing", this.Node.Name);
			}
		}

		// Token: 0x060461C6 RID: 287174 RVA: 0x0126A690 File Offset: 0x01268890
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, outBuilder);
			appendInterpolatedStringHandler.AppendLiteral("动画播放时间大于 [");
			appendInterpolatedStringHandler.AppendFormatted<float>(this.Time, "F1");
			appendInterpolatedStringHandler.AppendLiteral("\n");
			outBuilder.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x0402753A RID: 161082
		private float Time;

		// Token: 0x0402753B RID: 161083
		[Nullable(2)]
		private IAiTaskMontage TaskMontage;
	}
}
