using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x02007109 RID: 28937
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionAddBuff : AiStateMachineAction
	{
		// Token: 0x06046202 RID: 287234 RVA: 0x0126B31D File Offset: 0x0126951D
		public AiStateMachineActionAddBuff(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x06046203 RID: 287235 RVA: 0x0126B327 File Offset: 0x01269527
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			this.BuffId = new long?(action.ActionAddBuff.BuffId);
			return true;
		}

		// Token: 0x06046204 RID: 287236 RVA: 0x0126B340 File Offset: 0x01269540
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x04027549 RID: 161097
		public long? BuffId;
	}
}
