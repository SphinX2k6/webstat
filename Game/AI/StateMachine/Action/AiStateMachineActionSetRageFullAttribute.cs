using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x02007116 RID: 28950
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionSetRageFullAttribute : AiStateMachineAction
	{
		// Token: 0x0604622D RID: 287277 RVA: 0x0126BA63 File Offset: 0x01269C63
		public AiStateMachineActionSetRageFullAttribute(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x0604622E RID: 287278 RVA: 0x0126BA6D File Offset: 0x01269C6D
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			return true;
		}

		// Token: 0x0604622F RID: 287279 RVA: 0x0126BA70 File Offset: 0x01269C70
		public override void DoAction(long? contextId = null)
		{
		}

		// Token: 0x06046230 RID: 287280 RVA: 0x0126BA72 File Offset: 0x01269C72
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}
	}
}
