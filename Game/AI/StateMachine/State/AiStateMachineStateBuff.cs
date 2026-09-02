using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070E5 RID: 28901
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStateBuff : AiStateMachineState
	{
		// Token: 0x06046120 RID: 287008 RVA: 0x012674BE File Offset: 0x012656BE
		public AiStateMachineStateBuff(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x06046121 RID: 287009 RVA: 0x012674C8 File Offset: 0x012656C8
		protected override bool OnInit(CombatStateMachineDefine.Fsm.State state)
		{
			this.BuffId = new long?(state.BindBuff.BuffId);
			return true;
		}

		// Token: 0x06046122 RID: 287010 RVA: 0x012674E1 File Offset: 0x012656E1
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x040274F4 RID: 161012
		public long? BuffId;
	}
}
