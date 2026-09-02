using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x02007106 RID: 28934
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionTrue : AiStateMachineCondition
	{
		// Token: 0x060461F4 RID: 287220 RVA: 0x0126B251 File Offset: 0x01269451
		public AiStateMachineConditionTrue(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x060461F5 RID: 287221 RVA: 0x0126B25C File Offset: 0x0126945C
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.ResultSelf = true;
			return true;
		}

		// Token: 0x060461F6 RID: 287222 RVA: 0x0126B266 File Offset: 0x01269466
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			outBuilder.Append("[True]");
		}
	}
}
