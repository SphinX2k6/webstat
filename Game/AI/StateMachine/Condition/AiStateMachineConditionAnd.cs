using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070F1 RID: 28913
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionAnd : AiStateMachineCondition
	{
		// Token: 0x06046169 RID: 287081 RVA: 0x01268B33 File Offset: 0x01266D33
		public AiStateMachineConditionAnd(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x0604616A RID: 287082 RVA: 0x01268B40 File Offset: 0x01266D40
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			int count = condition.CondAnd.Conditions.Count;
			if (count > 0)
			{
				this.Conditions = new AiStateMachineCondition[count];
				for (int i = 0; i < count; i++)
				{
					int index = condition.CondAnd.Conditions[i];
					CombatStateMachineDefine.Fsm.Condition condition2 = this.Transition.ConditionDatas[index];
					AiStateMachineCondition aiStateMachineCondition = ModelBase<AiStateMachineModel>.Instance.AiStateMachineFactory.CreateCondition(this.Transition, condition2, index, this);
					this.HasTaskFinishCondition = (this.HasTaskFinishCondition || aiStateMachineCondition.HasTaskFinishCondition);
					this.Conditions[i] = aiStateMachineCondition;
				}
			}
			return true;
		}

		// Token: 0x0604616B RID: 287083 RVA: 0x01268BDC File Offset: 0x01266DDC
		protected override void OnEnter()
		{
			this.HasSignaled = false;
			AiStateMachineCondition[] conditions = this.Conditions;
			for (int i = 0; i < conditions.Length; i++)
			{
				conditions[i].Enter();
			}
		}

		// Token: 0x0604616C RID: 287084 RVA: 0x01268C10 File Offset: 0x01266E10
		protected override void OnExit()
		{
			this.HasSignaled = false;
			AiStateMachineCondition[] conditions = this.Conditions;
			for (int i = 0; i < conditions.Length; i++)
			{
				conditions[i].Exit();
			}
		}

		// Token: 0x0604616D RID: 287085 RVA: 0x01268C44 File Offset: 0x01266E44
		protected override void OnTick()
		{
			this.ResultSelf = true;
			foreach (AiStateMachineCondition aiStateMachineCondition in this.Conditions)
			{
				aiStateMachineCondition.Tick();
				this.ResultSelf &= aiStateMachineCondition.Result;
			}
		}

		// Token: 0x0604616E RID: 287086 RVA: 0x01268C8C File Offset: 0x01266E8C
		protected override void OnClear()
		{
			this.HasSignaled = false;
			AiStateMachineCondition[] conditions = this.Conditions;
			for (int i = 0; i < conditions.Length; i++)
			{
				conditions[i].Clear();
			}
			this.Conditions = null;
		}

		// Token: 0x0604616F RID: 287087 RVA: 0x01268CC4 File Offset: 0x01266EC4
		public override void HandleServerDebugInfo(RepeatedField<bool> conditions)
		{
			this.ResultServer = conditions[this.Index.Value];
			AiStateMachineCondition[] conditions2 = this.Conditions;
			for (int i = 0; i < conditions2.Length; i++)
			{
				conditions2[i].HandleServerDebugInfo(conditions);
			}
		}

		// Token: 0x06046170 RID: 287088 RVA: 0x01268D08 File Offset: 0x01266F08
		public override void OnSignaled()
		{
			this.ResultSelf = true;
			foreach (AiStateMachineCondition aiStateMachineCondition in this.Conditions)
			{
				this.ResultSelf &= aiStateMachineCondition.Result;
			}
			base.Signaled();
		}

		// Token: 0x06046171 RID: 287089 RVA: 0x01268D50 File Offset: 0x01266F50
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			outBuilder.Append("与\n");
			AiStateMachineCondition[] conditions = this.Conditions;
			for (int i = 0; i < conditions.Length; i++)
			{
				conditions[i].ToString(outBuilder, depth + 1);
			}
		}

		// Token: 0x04027520 RID: 161056
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public AiStateMachineCondition[] Conditions;
	}
}
