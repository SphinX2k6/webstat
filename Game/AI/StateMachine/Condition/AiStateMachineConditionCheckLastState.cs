using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070F8 RID: 28920
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionCheckLastState : AiStateMachineCondition
	{
		// Token: 0x06046190 RID: 287120 RVA: 0x012695BF File Offset: 0x012677BF
		public AiStateMachineConditionCheckLastState(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x06046191 RID: 287121 RVA: 0x012695CA File Offset: 0x012677CA
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.TargetNodeName = condition.CondCheckLastState.TargetStateName;
			return true;
		}

		// Token: 0x06046192 RID: 287122 RVA: 0x012695DE File Offset: 0x012677DE
		protected override void OnTick()
		{
			this.ResultSelf = this.Node.Owner.CheckLastActivatedNode(this.TargetNodeName);
		}

		// Token: 0x06046193 RID: 287123 RVA: 0x012695FC File Offset: 0x012677FC
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler;
			if (this.TargetNode == null)
			{
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(20, 1, outBuilder);
				appendInterpolatedStringHandler.AppendLiteral("检查上一帧节点激活 [");
				appendInterpolatedStringHandler.AppendFormatted(this.TargetNodeName);
				appendInterpolatedStringHandler.AppendLiteral("] 目标节点不存在");
				outBuilder.Append(ref appendInterpolatedStringHandler);
				return;
			}
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, outBuilder);
			appendInterpolatedStringHandler.AppendLiteral("检查上一帧节点激活 [");
			appendInterpolatedStringHandler.AppendFormatted(this.TargetNode.Name);
			appendInterpolatedStringHandler.AppendLiteral("]\n");
			outBuilder.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04027531 RID: 161073
		[Nullable(2)]
		private string TargetNodeName;

		// Token: 0x04027532 RID: 161074
		[Nullable(2)]
		private readonly AiStateMachineBase TargetNode;
	}
}
