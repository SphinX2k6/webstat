using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x0200710B RID: 28939
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionCameraLockOn : AiStateMachineAction
	{
		// Token: 0x06046209 RID: 287241 RVA: 0x0126B437 File Offset: 0x01269637
		public AiStateMachineActionCameraLockOn(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x0604620A RID: 287242 RVA: 0x0126B441 File Offset: 0x01269641
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			this.Enable = action.ActionCameraLockOn.Enable;
			return true;
		}

		// Token: 0x0604620B RID: 287243 RVA: 0x0126B458 File Offset: 0x01269658
		public override void DoAction(long? contextId = null)
		{
			AiStateMachineBase node = this.Node;
			CameraLockOnConfig cameraLockOnConfig;
			if (node == null)
			{
				cameraLockOnConfig = null;
			}
			else
			{
				CharacterActorComponent actorComponent = node.ActorComponent;
				cameraLockOnConfig = ((actorComponent != null) ? actorComponent.CameraLockOnConfig : null);
			}
			CameraLockOnConfig cameraLockOnConfig2 = cameraLockOnConfig;
			if (cameraLockOnConfig2 != null)
			{
				cameraLockOnConfig2.IsEnabled = this.Enable;
			}
		}

		// Token: 0x0604620C RID: 287244 RVA: 0x0126B493 File Offset: 0x01269693
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x0402754C RID: 161100
		public bool Enable;
	}
}
