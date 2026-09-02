using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x0200710E RID: 28942
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionDispatchGameEvent : AiStateMachineAction
	{
		// Token: 0x06046214 RID: 287252 RVA: 0x0126B7E5 File Offset: 0x012699E5
		public AiStateMachineActionDispatchGameEvent(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x06046215 RID: 287253 RVA: 0x0126B7EF File Offset: 0x012699EF
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			return true;
		}

		// Token: 0x06046216 RID: 287254 RVA: 0x0126B7F2 File Offset: 0x012699F2
		public override void DoAction(long? contextId = null)
		{
		}

		// Token: 0x06046217 RID: 287255 RVA: 0x0126B7F4 File Offset: 0x012699F4
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}
	}
}
