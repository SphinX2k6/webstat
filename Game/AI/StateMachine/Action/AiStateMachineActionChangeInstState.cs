using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x0200710C RID: 28940
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionChangeInstState : AiStateMachineAction
	{
		// Token: 0x0604620D RID: 287245 RVA: 0x0126B49C File Offset: 0x0126969C
		public AiStateMachineActionChangeInstState(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x0604620E RID: 287246 RVA: 0x0126B4B1 File Offset: 0x012696B1
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			this.TagId = action.ActionInstChangeStateTag.TagId;
			this.TagName = GameplayTagUtils.GetNameByTagId(this.TagId);
			return true;
		}

		// Token: 0x0604620F RID: 287247 RVA: 0x0126B4D6 File Offset: 0x012696D6
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x0402754D RID: 161101
		public int TagId;

		// Token: 0x0402754E RID: 161102
		public string TagName = "";
	}
}
