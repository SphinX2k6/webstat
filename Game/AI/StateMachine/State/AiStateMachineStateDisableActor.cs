using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070EA RID: 28906
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStateDisableActor : AiStateMachineState
	{
		// Token: 0x06046138 RID: 287032 RVA: 0x01267E6C File Offset: 0x0126606C
		public AiStateMachineStateDisableActor(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x06046139 RID: 287033 RVA: 0x01267E76 File Offset: 0x01266076
		[NullableContext(2)]
		public override void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
			this.DisableActorHandle = this.Node.ActorComponent.DisableActor("状态机隐藏");
		}

		// Token: 0x0604613A RID: 287034 RVA: 0x01267E93 File Offset: 0x01266093
		[NullableContext(2)]
		public override void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
			this.Node.ActorComponent.EnableActor(this.DisableActorHandle);
			this.DisableActorHandle = 0;
		}

		// Token: 0x0604613B RID: 287035 RVA: 0x01267EB3 File Offset: 0x012660B3
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x04027506 RID: 161030
		private int DisableActorHandle;
	}
}
