using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x02007110 RID: 28944
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionExitHit : AiStateMachineAction
	{
		// Token: 0x0604621A RID: 287258 RVA: 0x0126B810 File Offset: 0x01269A10
		public AiStateMachineActionExitHit(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x0604621B RID: 287259 RVA: 0x0126B81A File Offset: 0x01269A1A
		public override void DoAction(long? contextId = null)
		{
			this.Node.UnifiedStateComponent.ExitHitState("");
		}

		// Token: 0x0604621C RID: 287260 RVA: 0x0126B831 File Offset: 0x01269A31
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}
	}
}
