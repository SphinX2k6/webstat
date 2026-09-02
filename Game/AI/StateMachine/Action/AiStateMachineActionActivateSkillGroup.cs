using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x02007108 RID: 28936
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionActivateSkillGroup : AiStateMachineAction
	{
		// Token: 0x060461FE RID: 287230 RVA: 0x0126B2B8 File Offset: 0x012694B8
		public AiStateMachineActionActivateSkillGroup(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x060461FF RID: 287231 RVA: 0x0126B2C2 File Offset: 0x012694C2
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			this.ConfigId = action.ActionActivateSkillGroup.ConfigId;
			this.Activate = action.ActionActivateSkillGroup.Activate;
			return true;
		}

		// Token: 0x06046200 RID: 287232 RVA: 0x0126B2E7 File Offset: 0x012694E7
		public override void DoAction(long? contextId = null)
		{
			AiController aiController = this.Node.AiController;
			if (aiController == null)
			{
				return;
			}
			AiSkill aiSkill = aiController.AiSkill;
			if (aiSkill == null)
			{
				return;
			}
			aiSkill.ActivateSkillGroup(this.ConfigId, this.Activate);
		}

		// Token: 0x06046201 RID: 287233 RVA: 0x0126B314 File Offset: 0x01269514
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x04027547 RID: 161095
		public int ConfigId;

		// Token: 0x04027548 RID: 161096
		public bool Activate;
	}
}
