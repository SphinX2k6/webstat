using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.AI.StateMachine.Condition;
using CSharpScript.Game.Utils.CombatStateMachine;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.AI.StateMachine
{
	// Token: 0x020070D3 RID: 28883
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineTransition
	{
		// Token: 0x06046071 RID: 286833 RVA: 0x01263A78 File Offset: 0x01261C78
		public AiStateMachineTransition(AiStateMachineBase node, CombatStateMachineDefine.Fsm.Transition transition)
		{
			this.Node = node;
			CombatStateMachineDefine.Fsm.Node nodeData = node.Owner.GetNodeData(transition.From);
			this.From = ((nodeData != null) ? nodeData.Uuid : 0);
			CombatStateMachineDefine.Fsm.Node nodeData2 = node.Owner.GetNodeData(transition.To);
			this.To = ((nodeData2 != null) ? nodeData2.Uuid : 0);
			this.TransitionPredictionType = transition.TransitionPredictionType;
			this.Weight = transition.Weight;
			this.ConditionDatas = transition.Conditions;
			this.Condition = ModelBase<AiStateMachineModel>.Instance.AiStateMachineFactory.CreateCondition(this, transition.Conditions[0], 0, null);
			this.HasTaskFinishCondition = this.Condition.HasTaskFinishCondition;
		}

		// Token: 0x06046072 RID: 286834 RVA: 0x01263B31 File Offset: 0x01261D31
		public void Enter()
		{
			this.Condition.Enter();
		}

		// Token: 0x06046073 RID: 286835 RVA: 0x01263B3E File Offset: 0x01261D3E
		public void Exit()
		{
			this.Condition.Exit();
		}

		// Token: 0x06046074 RID: 286836 RVA: 0x01263B4B File Offset: 0x01261D4B
		public void Tick()
		{
			this.Condition.Tick();
		}

		// Token: 0x06046075 RID: 286837 RVA: 0x01263B58 File Offset: 0x01261D58
		public bool CheckPredictionCondition()
		{
			return ((this.TransitionPredictionType.GetValueOrDefault() == CombatStateMachineDefine.Fsm.ETransitionPredictionType.Autonomous && this.Node.ActorComponent.IsAutonomousProxy) || this.TransitionPredictionType.GetValueOrDefault() == CombatStateMachineDefine.Fsm.ETransitionPredictionType.Simulated) && this.Condition.Result;
		}

		// Token: 0x06046076 RID: 286838 RVA: 0x01263B95 File Offset: 0x01261D95
		public bool CanPrediction()
		{
			return (this.TransitionPredictionType.GetValueOrDefault() == CombatStateMachineDefine.Fsm.ETransitionPredictionType.Autonomous && this.Node.ActorComponent.IsAutonomousProxy) || this.TransitionPredictionType.GetValueOrDefault() == CombatStateMachineDefine.Fsm.ETransitionPredictionType.Simulated;
		}

		// Token: 0x06046077 RID: 286839 RVA: 0x01263BC7 File Offset: 0x01261DC7
		public bool GetResult()
		{
			return this.Condition.Result;
		}

		// Token: 0x06046078 RID: 286840 RVA: 0x01263BD4 File Offset: 0x01261DD4
		public void HandleServerDebugInfo(RepeatedField<bool> conditions)
		{
			this.Condition.HandleServerDebugInfo(conditions);
		}

		// Token: 0x06046079 RID: 286841 RVA: 0x01263BE2 File Offset: 0x01261DE2
		public void Clear()
		{
			this.Condition.Clear();
			this.Node = null;
			this.ConditionDatas = null;
			this.Condition = null;
			this.Conditions = null;
		}

		// Token: 0x04027484 RID: 160900
		[Nullable(2)]
		public AiStateMachineBase Node;

		// Token: 0x04027485 RID: 160901
		public int From;

		// Token: 0x04027486 RID: 160902
		public int To;

		// Token: 0x04027487 RID: 160903
		public CombatStateMachineDefine.Fsm.ETransitionPredictionType? TransitionPredictionType;

		// Token: 0x04027488 RID: 160904
		public int Weight;

		// Token: 0x04027489 RID: 160905
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<CombatStateMachineDefine.Fsm.Condition> ConditionDatas;

		// Token: 0x0402748A RID: 160906
		[Nullable(2)]
		public AiStateMachineCondition Condition;

		// Token: 0x0402748B RID: 160907
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<AiStateMachineCondition> Conditions;

		// Token: 0x0402748C RID: 160908
		public bool HasTaskFinishCondition;
	}
}
