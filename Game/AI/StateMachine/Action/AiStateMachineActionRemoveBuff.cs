using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x02007111 RID: 28945
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionRemoveBuff : AiStateMachineAction
	{
		// Token: 0x0604621D RID: 287261 RVA: 0x0126B83A File Offset: 0x01269A3A
		public AiStateMachineActionRemoveBuff(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x0604621E RID: 287262 RVA: 0x0126B844 File Offset: 0x01269A44
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			this.BuffId = new long?(action.ActionRemoveBuff.BuffId);
			return true;
		}

		// Token: 0x0604621F RID: 287263 RVA: 0x0126B85D File Offset: 0x01269A5D
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x04027553 RID: 161107
		public long? BuffId;
	}
}
