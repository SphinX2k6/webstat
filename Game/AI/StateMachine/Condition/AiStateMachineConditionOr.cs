using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x02007101 RID: 28929
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionOr : AiStateMachineCondition
	{
		// Token: 0x060461D2 RID: 287186 RVA: 0x0126AB19 File Offset: 0x01268D19
		public AiStateMachineConditionOr(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x060461D3 RID: 287187 RVA: 0x0126AB24 File Offset: 0x01268D24
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			int count = condition.CondOr.Conditions.Count;
			if (count > 0)
			{
				this.Conditions = new AiStateMachineCondition[count];
				for (int i = 0; i < count; i++)
				{
					int index = condition.CondOr.Conditions[i];
					CombatStateMachineDefine.Fsm.Condition condition2 = this.Transition.ConditionDatas[index];
					AiStateMachineCondition aiStateMachineCondition = ModelBase<AiStateMachineModel>.Instance.AiStateMachineFactory.CreateCondition(this.Transition, condition2, index, this);
					this.HasTaskFinishCondition = (this.HasTaskFinishCondition || aiStateMachineCondition.HasTaskFinishCondition);
					this.Conditions[i] = aiStateMachineCondition;
				}
			}
			return true;
		}

		// Token: 0x060461D4 RID: 287188 RVA: 0x0126ABC0 File Offset: 0x01268DC0
		protected override void OnEnter()
		{
			this.HasSignaled = false;
			AiStateMachineCondition[] conditions = this.Conditions;
			for (int i = 0; i < conditions.Length; i++)
			{
				conditions[i].Enter();
			}
		}

		// Token: 0x060461D5 RID: 287189 RVA: 0x0126ABF4 File Offset: 0x01268DF4
		protected override void OnExit()
		{
			this.HasSignaled = false;
			AiStateMachineCondition[] conditions = this.Conditions;
			for (int i = 0; i < conditions.Length; i++)
			{
				conditions[i].Exit();
			}
		}

		// Token: 0x060461D6 RID: 287190 RVA: 0x0126AC28 File Offset: 0x01268E28
		protected override void OnTick()
		{
			this.ResultSelf = false;
			foreach (AiStateMachineCondition aiStateMachineCondition in this.Conditions)
			{
				aiStateMachineCondition.Tick();
				this.ResultSelf = (this.ResultSelf || aiStateMachineCondition.Result);
			}
		}

		// Token: 0x060461D7 RID: 287191 RVA: 0x0126AC74 File Offset: 0x01268E74
		protected override void OnClear()
		{
			this.HasSignaled = false;
			AiStateMachineCondition[] conditions = this.Conditions;
			for (int i = 0; i < conditions.Length; i++)
			{
				conditions[i].Clear();
			}
			Array.Clear(this.Conditions, 0, this.Conditions.Length);
		}

		// Token: 0x060461D8 RID: 287192 RVA: 0x0126ACBC File Offset: 0x01268EBC
		public override void HandleServerDebugInfo(RepeatedField<bool> conditions)
		{
			this.ResultServer = conditions[this.Index.Value];
			int num = this.Conditions.Length;
			for (int i = 0; i < num; i++)
			{
				this.Conditions[i].HandleServerDebugInfo(conditions);
			}
		}

		// Token: 0x060461D9 RID: 287193 RVA: 0x0126AD04 File Offset: 0x01268F04
		public override void OnSignaled()
		{
			this.ResultSelf = false;
			foreach (AiStateMachineCondition aiStateMachineCondition in this.Conditions)
			{
				this.ResultSelf = (this.ResultSelf || aiStateMachineCondition.Result);
			}
			base.Signaled();
		}

		// Token: 0x060461DA RID: 287194 RVA: 0x0126AD50 File Offset: 0x01268F50
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			outBuilder.Append("或\n");
			int num = this.Conditions.Length;
			for (int i = 0; i < num; i++)
			{
				this.Conditions[i].ToString(outBuilder, depth + 1);
			}
		}

		// Token: 0x0402753E RID: 161086
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public AiStateMachineCondition[] Conditions;
	}
}
