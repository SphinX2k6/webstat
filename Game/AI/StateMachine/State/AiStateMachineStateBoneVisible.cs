using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;
using UnrealEngine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070E4 RID: 28900
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStateBoneVisible : AiStateMachineState
	{
		// Token: 0x0604611B RID: 287003 RVA: 0x01267402 File Offset: 0x01265602
		public AiStateMachineStateBoneVisible(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x0604611C RID: 287004 RVA: 0x0126740C File Offset: 0x0126560C
		protected override bool OnInit(CombatStateMachineDefine.Fsm.State state)
		{
			this.BoneName = new FName?(new FName(state.BindBoneVisible.BoneName));
			this.Visible = state.BindBoneVisible.Visible;
			return true;
		}

		// Token: 0x0604611D RID: 287005 RVA: 0x0126743B File Offset: 0x0126563B
		[NullableContext(2)]
		public override void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
			this.Node.AnimationComponent.HideBone(this.BoneName.Value, !this.Visible, false);
		}

		// Token: 0x0604611E RID: 287006 RVA: 0x01267464 File Offset: 0x01265664
		[NullableContext(2)]
		public override void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
			if (this.Node.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]))
			{
				return;
			}
			this.Node.AnimationComponent.HideBone(this.BoneName.Value, this.Visible, false);
		}

		// Token: 0x0604611F RID: 287007 RVA: 0x012674B5 File Offset: 0x012656B5
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x040274F2 RID: 161010
		private FName? BoneName;

		// Token: 0x040274F3 RID: 161011
		private bool Visible;
	}
}
