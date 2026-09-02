using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x02007105 RID: 28933
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionTimer : AiStateMachineCondition
	{
		// Token: 0x060461ED RID: 287213 RVA: 0x0126B0AB File Offset: 0x012692AB
		public AiStateMachineConditionTimer(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x060461EE RID: 287214 RVA: 0x0126B0B6 File Offset: 0x012692B6
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.MinTime = (double)condition.CondTimer.MinTime;
			this.MaxTime = (double)condition.CondTimer.MaxTime;
			return true;
		}

		// Token: 0x060461EF RID: 287215 RVA: 0x0126B0E0 File Offset: 0x012692E0
		protected override void OnEnter()
		{
			if (!this.CheckForClient)
			{
				return;
			}
			this.ResultSelf = false;
			this.ClearTimer();
			double randomRange = Singleton<MathUtils>.Instance.GetRandomRange(this.MinTime, this.MaxTime);
			this.TimerHandle = TimerSystem.Instance.Delay(new TTimerAction(this.OnTimerTimeout), (float)randomRange, null, null, true, 1f);
		}

		// Token: 0x060461F0 RID: 287216 RVA: 0x0126B140 File Offset: 0x01269340
		private void OnTimerTimeout(float delta)
		{
			this.ResultSelf = true;
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionTimer", this.Node.Name);
			}
			this.TimerHandle = null;
		}

		// Token: 0x060461F1 RID: 287217 RVA: 0x0126B195 File Offset: 0x01269395
		protected override void OnClear()
		{
			this.ClearTimer();
		}

		// Token: 0x060461F2 RID: 287218 RVA: 0x0126B19D File Offset: 0x0126939D
		private void ClearTimer()
		{
			if (this.TimerHandle != null)
			{
				if (this.TimerHandle.Valid())
				{
					this.TimerHandle.Remove();
				}
				this.TimerHandle = null;
			}
		}

		// Token: 0x060461F3 RID: 287219 RVA: 0x0126B1C8 File Offset: 0x012693C8
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 2, outBuilder);
			appendInterpolatedStringHandler.AppendLiteral("延迟 [时间:");
			appendInterpolatedStringHandler.AppendFormatted<double>(this.MinTime * Singleton<TimeUtil>.Instance.Millisecond, "F1");
			appendInterpolatedStringHandler.AppendLiteral("-");
			appendInterpolatedStringHandler.AppendFormatted<double>(this.MaxTime * Singleton<TimeUtil>.Instance.Millisecond, "F1");
			appendInterpolatedStringHandler.AppendLiteral("]\n");
			outBuilder.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04027542 RID: 161090
		private double MinTime;

		// Token: 0x04027543 RID: 161091
		private double MaxTime;

		// Token: 0x04027544 RID: 161092
		[Nullable(2)]
		private TimerHandle TimerHandle;
	}
}
