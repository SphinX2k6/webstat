using System;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070E1 RID: 28897
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStateAiHateConfig : AiStateMachineState
	{
		// Token: 0x0604610C RID: 286988 RVA: 0x012670E7 File Offset: 0x012652E7
		public AiStateMachineStateAiHateConfig(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x0604610D RID: 286989 RVA: 0x012670F1 File Offset: 0x012652F1
		protected override bool OnInit(CombatStateMachineDefine.Fsm.State state)
		{
			this.ConfigId = state.BindAiHateConfig.ConfigId;
			return true;
		}

		// Token: 0x0604610E RID: 286990 RVA: 0x01267108 File Offset: 0x01265308
		[NullableContext(2)]
		public override void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
			AiHateList aiHateList = this.Node.AiController.AiHateList;
			AiHate? aiHate;
			this.LastConfigId = ((aiHateList != null) ? ((aiHateList.AiHate != null) ? new int?(aiHate.GetValueOrDefault().Id) : null) : null);
			if (this.ConfigId != 0)
			{
				this.Node.AiController.AiHateList.AiHate = ConfigBase<AiConfig>.Instance.LoadAiHate(this.ConfigId);
				return;
			}
			this.Node.AiController.AiHateList.AiHate = ConfigBase<AiConfig>.Instance.LoadAiHateByController(this.Node.AiController, null, null);
		}

		// Token: 0x0604610F RID: 286991 RVA: 0x012671D4 File Offset: 0x012653D4
		[NullableContext(2)]
		public override void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
			if (this.LastConfigId != null)
			{
				this.Node.AiController.AiHateList.AiHate = ConfigBase<AiConfig>.Instance.LoadAiHate(this.LastConfigId.Value);
			}
			else
			{
				this.Node.AiController.AiHateList.AiHate = ConfigBase<AiConfig>.Instance.LoadAiHateByController(this.Node.AiController, null, null);
			}
			this.LastConfigId = null;
		}

		// Token: 0x06046110 RID: 286992 RVA: 0x01267262 File Offset: 0x01265462
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x040274E6 RID: 160998
		private int ConfigId;

		// Token: 0x040274E7 RID: 160999
		private int? LastConfigId;
	}
}
