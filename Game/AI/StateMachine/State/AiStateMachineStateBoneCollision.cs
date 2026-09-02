using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070E3 RID: 28899
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStateBoneCollision : AiStateMachineState
	{
		// Token: 0x06046116 RID: 286998 RVA: 0x012672D8 File Offset: 0x012654D8
		public AiStateMachineStateBoneCollision(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x06046117 RID: 286999 RVA: 0x012672F0 File Offset: 0x012654F0
		protected override bool OnInit(CombatStateMachineDefine.Fsm.State state)
		{
			this.BoneName = state.BindBoneCollision.BoneName;
			this.IsBlockPawn = state.BindBoneCollision.IsBlockPawn;
			this.IsBulletDetect = state.BindBoneCollision.IsBulletDetect;
			this.IsBlockCamera = state.BindBoneCollision.IsBlockCamera;
			this.IsBlockPawnOnExit = state.BindBoneCollision.IsBlockPawnOnExit;
			this.IsBulletDetectOnExit = state.BindBoneCollision.IsBulletDetectOnExit;
			this.IsBlockCameraOnExit = state.BindBoneCollision.IsBlockCameraOnExit;
			this.IsActiveOcclusionDither = state.BindBoneCollision.IsActiveOcclusionDither;
			this.IsActiveOcclusionDitherOnExit = state.BindBoneCollision.IsActiveOcclusionDitherOnExit;
			return true;
		}

		// Token: 0x06046118 RID: 287000 RVA: 0x01267397 File Offset: 0x01265597
		[NullableContext(2)]
		public override void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
			this.Node.ActorComponent.SetPartCollisionSwitch(this.BoneName, this.IsBlockPawn, this.IsBulletDetect, this.IsBlockCamera, this.IsActiveOcclusionDither, false);
		}

		// Token: 0x06046119 RID: 287001 RVA: 0x012673C8 File Offset: 0x012655C8
		[NullableContext(2)]
		public override void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
			this.Node.ActorComponent.SetPartCollisionSwitch(this.BoneName, this.IsBlockPawnOnExit, this.IsBulletDetectOnExit, this.IsBlockCameraOnExit, this.IsActiveOcclusionDitherOnExit, false);
		}

		// Token: 0x0604611A RID: 287002 RVA: 0x012673F9 File Offset: 0x012655F9
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x040274E9 RID: 161001
		public string BoneName = "";

		// Token: 0x040274EA RID: 161002
		public bool IsBlockPawn;

		// Token: 0x040274EB RID: 161003
		public bool IsBulletDetect;

		// Token: 0x040274EC RID: 161004
		public bool IsBlockCamera;

		// Token: 0x040274ED RID: 161005
		public bool IsBlockPawnOnExit;

		// Token: 0x040274EE RID: 161006
		public bool IsBulletDetectOnExit;

		// Token: 0x040274EF RID: 161007
		public bool IsBlockCameraOnExit;

		// Token: 0x040274F0 RID: 161008
		public bool IsActiveOcclusionDither;

		// Token: 0x040274F1 RID: 161009
		public bool IsActiveOcclusionDitherOnExit;
	}
}
