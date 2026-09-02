using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070F9 RID: 28921
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionCheckPositionState : AiStateMachineCondition
	{
		// Token: 0x06046194 RID: 287124 RVA: 0x01269695 File Offset: 0x01267895
		public AiStateMachineConditionCheckPositionState(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x06046195 RID: 287125 RVA: 0x012696A0 File Offset: 0x012678A0
		protected override bool RegisterEvents()
		{
			if (base.RegisterEvents() && this.Node.Entity != null && !Singleton<EventSystem>.Instance.HasWithTarget(this.Node.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnCharPositionStateChanged)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(this.Node.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnCharPositionStateChanged));
				return true;
			}
			return false;
		}

		// Token: 0x06046196 RID: 287126 RVA: 0x01269714 File Offset: 0x01267914
		protected override bool UnregisterEvents()
		{
			if (base.UnregisterEvents() && this.Node.Entity != null && Singleton<EventSystem>.Instance.HasWithTarget(this.Node.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnCharPositionStateChanged)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.Node.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnCharPositionStateChanged));
				return true;
			}
			return false;
		}

		// Token: 0x06046197 RID: 287127 RVA: 0x01269788 File Offset: 0x01267988
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.PositionState = (ECharPositionState)condition.CondCheckPositionState.PositionState;
			return true;
		}

		// Token: 0x06046198 RID: 287128 RVA: 0x0126979C File Offset: 0x0126799C
		protected override void OnTick()
		{
			this.ResultSelf = (this.Node.UnifiedStateComponent.PositionState == this.PositionState);
		}

		// Token: 0x06046199 RID: 287129 RVA: 0x012697BC File Offset: 0x012679BC
		private void OnCharPositionStateChanged(ECharPositionState oldState, ECharPositionState newState)
		{
			this.ResultSelf = (this.Node.UnifiedStateComponent.PositionState == this.PositionState);
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionCheckPositionState", this.Node.Name);
			}
		}

		// Token: 0x0604619A RID: 287130 RVA: 0x01269821 File Offset: 0x01267A21
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			outBuilder.Append("有仇恨\n");
		}

		// Token: 0x04027533 RID: 161075
		private ECharPositionState PositionState;
	}
}
