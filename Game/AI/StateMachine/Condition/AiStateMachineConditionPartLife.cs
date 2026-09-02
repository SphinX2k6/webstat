using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x02007102 RID: 28930
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionPartLife : AiStateMachineCondition
	{
		// Token: 0x060461DB RID: 287195 RVA: 0x0126AD97 File Offset: 0x01268F97
		public AiStateMachineConditionPartLife(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x060461DC RID: 287196 RVA: 0x0126ADA2 File Offset: 0x01268FA2
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			return true;
		}

		// Token: 0x060461DD RID: 287197 RVA: 0x0126ADA5 File Offset: 0x01268FA5
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			outBuilder.Append("[部位血量]");
		}
	}
}
