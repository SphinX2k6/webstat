using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x02007113 RID: 28947
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionResetPart : AiStateMachineAction
	{
		// Token: 0x06046224 RID: 287268 RVA: 0x0126B991 File Offset: 0x01269B91
		public AiStateMachineActionResetPart(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x06046225 RID: 287269 RVA: 0x0126B99B File Offset: 0x01269B9B
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}
	}
}
