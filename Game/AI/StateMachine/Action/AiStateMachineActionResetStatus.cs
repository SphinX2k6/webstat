using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x02007114 RID: 28948
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionResetStatus : AiStateMachineAction
	{
		// Token: 0x06046226 RID: 287270 RVA: 0x0126B9A4 File Offset: 0x01269BA4
		public AiStateMachineActionResetStatus(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x06046227 RID: 287271 RVA: 0x0126B9AE File Offset: 0x01269BAE
		public override void DoAction(long? contextId = null)
		{
			if (this.Node.AiController == null)
			{
				return;
			}
			ModelBase<CombatMessageModel>.Instance.AnyHateChange = true;
		}

		// Token: 0x06046228 RID: 287272 RVA: 0x0126B9C9 File Offset: 0x01269BC9
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}
	}
}
