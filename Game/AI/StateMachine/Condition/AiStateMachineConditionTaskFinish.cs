using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x02007104 RID: 28932
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionTaskFinish : AiStateMachineCondition
	{
		// Token: 0x060461E4 RID: 287204 RVA: 0x0126AF1F File Offset: 0x0126911F
		public AiStateMachineConditionTaskFinish(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x060461E5 RID: 287205 RVA: 0x0126AF2C File Offset: 0x0126912C
		protected override bool RegisterEvents()
		{
			if (base.RegisterEvents())
			{
				AiStateMachineBase currentLeafNode = this.Node.CurrentLeafNode;
				if (currentLeafNode != null && !Singleton<EventSystem>.Instance.HasWithTarget(currentLeafNode, EEventName.OnStateTaskFinished, new Action<bool>(this.OnStateTaskFinished)))
				{
					Singleton<EventSystem>.Instance.AddWithTarget(currentLeafNode, EEventName.OnStateTaskFinished, new Action<bool>(this.OnStateTaskFinished));
					return true;
				}
			}
			return false;
		}

		// Token: 0x060461E6 RID: 287206 RVA: 0x0126AF90 File Offset: 0x01269190
		protected override bool UnregisterEvents()
		{
			if (base.UnregisterEvents())
			{
				AiStateMachineBase currentLeafNode = this.Node.CurrentLeafNode;
				if (currentLeafNode != null && Singleton<EventSystem>.Instance.HasWithTarget(currentLeafNode, EEventName.OnStateTaskFinished, new Action<bool>(this.OnStateTaskFinished)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(currentLeafNode, EEventName.OnStateTaskFinished, new Action<bool>(this.OnStateTaskFinished));
					return true;
				}
			}
			return false;
		}

		// Token: 0x060461E7 RID: 287207 RVA: 0x0126AFF2 File Offset: 0x012691F2
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.HasTaskFinishCondition = true;
			return true;
		}

		// Token: 0x060461E8 RID: 287208 RVA: 0x0126AFFC File Offset: 0x012691FC
		protected override void OnClear()
		{
			this.HasTaskFinishCondition = false;
		}

		// Token: 0x060461E9 RID: 287209 RVA: 0x0126B005 File Offset: 0x01269205
		protected override void OnEnter()
		{
			this.ResultSelf = this.Node.CurrentLeafNode.TaskFinished;
		}

		// Token: 0x060461EA RID: 287210 RVA: 0x0126B01D File Offset: 0x0126921D
		protected override void OnTick()
		{
			this.ResultSelf = this.Node.CurrentLeafNode.TaskFinished;
		}

		// Token: 0x060461EB RID: 287211 RVA: 0x0126B038 File Offset: 0x01269238
		private void OnStateTaskFinished(bool taskFinished)
		{
			this.ResultSelf = this.Node.CurrentLeafNode.TaskFinished;
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionTaskFinish", this.Node.Name);
			}
		}

		// Token: 0x060461EC RID: 287212 RVA: 0x0126B095 File Offset: 0x01269295
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			outBuilder.Append("节点任务完成\n");
		}
	}
}
