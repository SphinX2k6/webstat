using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070EB RID: 28907
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStateDisableCollision : AiStateMachineState
	{
		// Token: 0x0604613C RID: 287036 RVA: 0x01267EBC File Offset: 0x012660BC
		public AiStateMachineStateDisableCollision(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x0604613D RID: 287037 RVA: 0x01267EC6 File Offset: 0x012660C6
		[NullableContext(2)]
		public override void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
			this.DisableCollisionHandle = this.Node.ActorComponent.DisableCollision("状态机隐藏碰撞");
		}

		// Token: 0x0604613E RID: 287038 RVA: 0x01267EE3 File Offset: 0x012660E3
		[NullableContext(2)]
		public override void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
			this.Node.ActorComponent.EnableCollision(this.DisableCollisionHandle);
			this.DisableCollisionHandle = 0;
		}

		// Token: 0x0604613F RID: 287039 RVA: 0x01267F03 File Offset: 0x01266103
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x04027507 RID: 161031
		private int DisableCollisionHandle;
	}
}
