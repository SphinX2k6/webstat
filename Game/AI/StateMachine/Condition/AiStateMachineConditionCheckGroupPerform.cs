using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.NewWorld.Character.Monster.Controller;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070F6 RID: 28918
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionCheckGroupPerform : AiStateMachineCondition
	{
		// Token: 0x06046187 RID: 287111 RVA: 0x01269433 File Offset: 0x01267633
		public AiStateMachineConditionCheckGroupPerform(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x06046188 RID: 287112 RVA: 0x0126943E File Offset: 0x0126763E
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			return true;
		}

		// Token: 0x06046189 RID: 287113 RVA: 0x01269441 File Offset: 0x01267641
		protected override void OnTick()
		{
			this.ResultSelf = ControllerBase<MonsterGroupEcologyController>.Instance.CheckEntityInMonsterGroup(this.Node.Entity.Id);
		}

		// Token: 0x0604618A RID: 287114 RVA: 0x01269463 File Offset: 0x01267663
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			outBuilder.Append("可以集群表演\n");
		}
	}
}
