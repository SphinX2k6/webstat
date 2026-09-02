using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070EF RID: 28911
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStateTag : AiStateMachineState
	{
		// Token: 0x06046150 RID: 287056 RVA: 0x012685B3 File Offset: 0x012667B3
		public AiStateMachineStateTag(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x06046151 RID: 287057 RVA: 0x012685C8 File Offset: 0x012667C8
		protected override bool OnInit(CombatStateMachineDefine.Fsm.State state)
		{
			this.TagId = state.BindTag.TagId;
			return true;
		}

		// Token: 0x06046152 RID: 287058 RVA: 0x012685DC File Offset: 0x012667DC
		[NullableContext(2)]
		public override void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
			if (this.TagHandle == null)
			{
				this.TagHandle = new int?(this.Node.BuffComponent.AddTagWithReturnHandle(new <>z__ReadOnlySingleElementList<int>(this.TagId), -1f));
			}
		}

		// Token: 0x06046153 RID: 287059 RVA: 0x01268618 File Offset: 0x01266818
		[NullableContext(2)]
		public override void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
			bool flag = false;
			if (nextState != null && nextState.BindStates != null && nextState.BindStates.Count > 0)
			{
				foreach (AiStateMachineState aiStateMachineState in nextState.BindStates)
				{
					AiStateMachineStateTag aiStateMachineStateTag = aiStateMachineState as AiStateMachineStateTag;
					if (aiStateMachineStateTag != null && aiStateMachineStateTag.TagId == this.TagId)
					{
						aiStateMachineStateTag.TagHandle = this.TagHandle;
						flag = true;
					}
				}
			}
			if (this.TagHandle == null)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.StateMachineNew;
				Entity entity = this.Node.Entity;
				string message = "AiStateMachineStateTag移除Tag失败，TagHandle不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("node", this.Node.Name);
				instance.Error(flag2, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			if (!flag && this.TagHandle != null)
			{
				this.Node.BuffComponent.RemoveBuffByHandle(this.TagHandle.Value, -1, null, null, null, null);
			}
			this.TagHandle = null;
		}

		// Token: 0x06046154 RID: 287060 RVA: 0x01268744 File Offset: 0x01266944
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x04027510 RID: 161040
		public int TagId;

		// Token: 0x04027511 RID: 161041
		public string TagName = "";

		// Token: 0x04027512 RID: 161042
		public int? TagHandle;
	}
}
