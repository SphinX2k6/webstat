using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070FA RID: 28922
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionCheckState : AiStateMachineCondition
	{
		// Token: 0x0604619B RID: 287131 RVA: 0x01269837 File Offset: 0x01267A37
		public AiStateMachineConditionCheckState(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x0604619C RID: 287132 RVA: 0x01269844 File Offset: 0x01267A44
		protected override bool RegisterEvents()
		{
			if (base.RegisterEvents())
			{
				AiStateMachineBase targetNode = this.GetTargetNode();
				if (targetNode != null && !Singleton<EventSystem>.Instance.HasWithTarget(targetNode, EEventName.OnStateActivated, new Action<bool>(this.OnStateActivated)))
				{
					Singleton<EventSystem>.Instance.AddWithTarget(targetNode, EEventName.OnStateActivated, new Action<bool>(this.OnStateActivated));
					return true;
				}
			}
			return false;
		}

		// Token: 0x0604619D RID: 287133 RVA: 0x012698A4 File Offset: 0x01267AA4
		protected override bool UnregisterEvents()
		{
			if (base.UnregisterEvents())
			{
				AiStateMachineBase targetNode = this.GetTargetNode();
				if (targetNode != null && Singleton<EventSystem>.Instance.HasWithTarget(targetNode, EEventName.OnStateActivated, new Action<bool>(this.OnStateActivated)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(targetNode, EEventName.OnStateActivated, new Action<bool>(this.OnStateActivated));
					return true;
				}
			}
			return false;
		}

		// Token: 0x0604619E RID: 287134 RVA: 0x01269901 File Offset: 0x01267B01
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			if (condition.CondCheckState != null)
			{
				this.TargetNodeUuid = new int?(condition.CondCheckState.TargetState);
			}
			else if (condition.CondCheckStateByName != null)
			{
				this.TargetNodeName = condition.CondCheckStateByName.TargetStateName;
			}
			return true;
		}

		// Token: 0x0604619F RID: 287135 RVA: 0x01269940 File Offset: 0x01267B40
		[NullableContext(2)]
		private AiStateMachineBase GetTargetNode()
		{
			AiStateMachineBase result = null;
			if (this.TargetNodeUuid != null)
			{
				result = this.Node.Owner.GetNodeByUuid(this.TargetNodeUuid.Value);
			}
			else if (this.TargetNodeName != null)
			{
				result = this.Node.Owner.GetNodeByName(this.TargetNodeName);
			}
			return result;
		}

		// Token: 0x060461A0 RID: 287136 RVA: 0x0126999A File Offset: 0x01267B9A
		protected override void OnTick()
		{
			if (this.TargetNode == null)
			{
				this.TargetNode = this.GetTargetNode();
			}
			AiStateMachineBase targetNode = this.TargetNode;
			this.ResultSelf = (targetNode != null && targetNode.Activated);
		}

		// Token: 0x060461A1 RID: 287137 RVA: 0x012699C8 File Offset: 0x01267BC8
		private void OnStateActivated(bool value)
		{
			this.ResultSelf = value;
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionCheckState", this.Node.Name);
			}
		}

		// Token: 0x060461A2 RID: 287138 RVA: 0x01269A18 File Offset: 0x01267C18
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler;
			if (this.TargetNode == null)
			{
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(17, 1, outBuilder);
				appendInterpolatedStringHandler.AppendLiteral("检查节点状态 [");
				appendInterpolatedStringHandler.AppendFormatted(this.TargetNodeName);
				appendInterpolatedStringHandler.AppendLiteral("] 目标节点不存在");
				outBuilder.Append(ref appendInterpolatedStringHandler);
				return;
			}
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 1, outBuilder);
			appendInterpolatedStringHandler.AppendLiteral("检查节点状态 [");
			appendInterpolatedStringHandler.AppendFormatted(this.TargetNode.Name);
			appendInterpolatedStringHandler.AppendLiteral("]\n");
			outBuilder.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04027534 RID: 161076
		[Nullable(2)]
		private string TargetNodeName;

		// Token: 0x04027535 RID: 161077
		private int? TargetNodeUuid;

		// Token: 0x04027536 RID: 161078
		[Nullable(2)]
		private AiStateMachineBase TargetNode;
	}
}
