using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x0200710F RID: 28943
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionEnterFight : AiStateMachineAction
	{
		// Token: 0x06046218 RID: 287256 RVA: 0x0126B7FD File Offset: 0x012699FD
		public AiStateMachineActionEnterFight(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x06046219 RID: 287257 RVA: 0x0126B807 File Offset: 0x01269A07
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}
	}
}
