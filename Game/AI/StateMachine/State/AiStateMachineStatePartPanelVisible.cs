using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Utils.CombatStateMachine;
using UnrealEngine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070EE RID: 28910
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStatePartPanelVisible : AiStateMachineState
	{
		// Token: 0x0604614B RID: 287051 RVA: 0x01268512 File Offset: 0x01266712
		public AiStateMachineStatePartPanelVisible(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x0604614C RID: 287052 RVA: 0x0126851C File Offset: 0x0126671C
		protected override bool OnInit(CombatStateMachineDefine.Fsm.State state)
		{
			this.PartName = new FName?(new FName(state.BindPartPanelVisible.PartName));
			this.Visible = state.BindPartPanelVisible.Visible;
			return true;
		}

		// Token: 0x0604614D RID: 287053 RVA: 0x0126854B File Offset: 0x0126674B
		[NullableContext(2)]
		public override void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
			Singleton<EventSystem>.Instance.Emit<int, FName?, bool>(EEventName.OnSetPartStateVisible, this.Node.Entity.Id, this.PartName, this.Visible);
		}

		// Token: 0x0604614E RID: 287054 RVA: 0x01268579 File Offset: 0x01266779
		[NullableContext(2)]
		public override void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
			Singleton<EventSystem>.Instance.Emit<int, FName?, bool>(EEventName.OnSetPartStateVisible, this.Node.Entity.Id, this.PartName, !this.Visible);
		}

		// Token: 0x0604614F RID: 287055 RVA: 0x012685AA File Offset: 0x012667AA
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x0402750E RID: 161038
		public FName? PartName;

		// Token: 0x0402750F RID: 161039
		public bool Visible;
	}
}
