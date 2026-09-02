using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070FD RID: 28925
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionLeaveFight : AiStateMachineCondition
	{
		// Token: 0x060461B3 RID: 287155 RVA: 0x0126A05F File Offset: 0x0126825F
		public AiStateMachineConditionLeaveFight(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x060461B4 RID: 287156 RVA: 0x0126A06A File Offset: 0x0126826A
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			outBuilder.Append("离开战斗\n");
		}
	}
}
