using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070F4 RID: 28916
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionBuffStack : AiStateMachineCondition
	{
		// Token: 0x0604617C RID: 287100 RVA: 0x012691CB File Offset: 0x012673CB
		public AiStateMachineConditionBuffStack(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x0604617D RID: 287101 RVA: 0x012691D6 File Offset: 0x012673D6
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.BuffId = condition.CondBuffStack.BuffId;
			this.MinStack = condition.CondBuffStack.MinStack;
			this.MaxStack = condition.CondBuffStack.MaxStack;
			return true;
		}

		// Token: 0x0604617E RID: 287102 RVA: 0x0126920C File Offset: 0x0126740C
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(34, 3, outBuilder);
			appendInterpolatedStringHandler.AppendLiteral("有检查Buff层数 [BuffId:");
			appendInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
			appendInterpolatedStringHandler.AppendLiteral("] [Min:");
			appendInterpolatedStringHandler.AppendFormatted<int>(this.MinStack);
			appendInterpolatedStringHandler.AppendLiteral("] [Max:");
			appendInterpolatedStringHandler.AppendFormatted<int>(this.MaxStack);
			appendInterpolatedStringHandler.AppendLiteral("]\n");
			outBuilder.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x0402752B RID: 161067
		public long BuffId;

		// Token: 0x0402752C RID: 161068
		public int MinStack;

		// Token: 0x0402752D RID: 161069
		public int MaxStack;
	}
}
