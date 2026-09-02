using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070E2 RID: 28898
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStateAiSenseEnable : AiStateMachineState
	{
		// Token: 0x06046111 RID: 286993 RVA: 0x0126726B File Offset: 0x0126546B
		public AiStateMachineStateAiSenseEnable(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x06046112 RID: 286994 RVA: 0x01267275 File Offset: 0x01265475
		protected override bool OnInit(CombatStateMachineDefine.Fsm.State state)
		{
			this.ConfigId = state.BindAiSenseEnable.ConfigId;
			return true;
		}

		// Token: 0x06046113 RID: 286995 RVA: 0x01267289 File Offset: 0x01265489
		[NullableContext(2)]
		public override void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
			IAiPerception aiPerception = this.Node.AiController.AiPerception;
			if (aiPerception == null)
			{
				return;
			}
			aiPerception.SetAiSenseEnable(this.ConfigId, true);
		}

		// Token: 0x06046114 RID: 286996 RVA: 0x012672AC File Offset: 0x012654AC
		[NullableContext(2)]
		public override void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
			IAiPerception aiPerception = this.Node.AiController.AiPerception;
			if (aiPerception == null)
			{
				return;
			}
			aiPerception.SetAiSenseEnable(this.ConfigId, false);
		}

		// Token: 0x06046115 RID: 286997 RVA: 0x012672CF File Offset: 0x012654CF
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x040274E8 RID: 161000
		public int ConfigId;
	}
}
