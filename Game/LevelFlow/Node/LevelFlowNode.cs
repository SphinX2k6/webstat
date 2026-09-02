using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelFlow.Action;
using CSharpScript.Game.LevelFlow.Condition;

namespace CSharpScript.Game.LevelFlow.Node
{
	// Token: 0x02006F7F RID: 28543
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowNode : IStaticVariableResetter
	{
		// Token: 0x06045131 RID: 282929 RVA: 0x01203280 File Offset: 0x01201480
		static LevelFlowNode()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LevelFlowNode.CreateStaticDefaultValue), new Action(LevelFlowNode.ResetStaticDefaultValue));
		}

		// Token: 0x06045132 RID: 282930 RVA: 0x0120329F File Offset: 0x0120149F
		public LevelFlowNode([Nullable(2)] LevelFlowConditionBase condition, List<LevelFlowActionBase> actionList)
		{
			this.NodeId = LevelFlowNode.SelfIncrementId++;
			this.Condition = condition;
			this.ActionList = actionList;
		}

		// Token: 0x06045133 RID: 282931 RVA: 0x012032DE File Offset: 0x012014DE
		public void BindCompleteCallBack(Action<LevelFlowNode, bool> completeCallBack)
		{
			this.CompleteCallBack = completeCallBack;
		}

		// Token: 0x06045134 RID: 282932 RVA: 0x012032E8 File Offset: 0x012014E8
		public void Enter()
		{
			if (this.Condition != null)
			{
				this.NodeStateInternal = ELevelFlowNodeState.WaitingCondition;
				this.Condition.BindCompleteCallBack(new Action<bool>(this.OnConditionComplete));
				this.Condition.Enter();
				return;
			}
			this.NodeStateInternal = ELevelFlowNodeState.RunningAction;
			this.ExecuteActionList();
		}

		// Token: 0x06045135 RID: 282933 RVA: 0x01203334 File Offset: 0x01201534
		public void Exit()
		{
			this.CompleteCallBack = null;
		}

		// Token: 0x06045136 RID: 282934 RVA: 0x01203340 File Offset: 0x01201540
		public void Tick(float deltaTime)
		{
			if (this.NodeState == ELevelFlowNodeState.WaitingCondition)
			{
				this.Condition.Tick(deltaTime);
				return;
			}
			if (this.NodeState == ELevelFlowNodeState.RunningAction)
			{
				foreach (LevelFlowActionBase levelFlowActionBase in this.ActionSet)
				{
					levelFlowActionBase.Tick(deltaTime);
				}
			}
		}

		// Token: 0x06045137 RID: 282935 RVA: 0x012033B0 File Offset: 0x012015B0
		public void Reset()
		{
			if (this.NodeState == ELevelFlowNodeState.Idle)
			{
				return;
			}
			if (this.NodeState != ELevelFlowNodeState.WaitingCondition)
			{
				LevelFlowConditionBase condition = this.Condition;
				if (condition != null)
				{
					condition.Reset();
				}
				foreach (LevelFlowActionBase levelFlowActionBase in this.ActionList)
				{
					levelFlowActionBase.Reset();
				}
				return;
			}
			LevelFlowConditionBase condition2 = this.Condition;
			if (condition2 == null)
			{
				return;
			}
			condition2.Reset();
		}

		// Token: 0x06045138 RID: 282936 RVA: 0x01203434 File Offset: 0x01201634
		private void ExecuteActionList()
		{
			this.ActionSet.Clear();
			foreach (LevelFlowActionBase levelFlowActionBase in this.ActionList)
			{
				this.ActionSet.Add(levelFlowActionBase);
				levelFlowActionBase.BindCompleteCallBack(new Action<LevelFlowActionBase, bool>(this.OnActionComplete));
			}
			foreach (LevelFlowActionBase levelFlowActionBase2 in this.ActionList)
			{
				levelFlowActionBase2.Execute();
			}
		}

		// Token: 0x06045139 RID: 282937 RVA: 0x012034EC File Offset: 0x012016EC
		private void OnConditionComplete(bool isSuccess)
		{
			if (isSuccess)
			{
				this.NodeStateInternal = ELevelFlowNodeState.RunningAction;
				this.ExecuteActionList();
				return;
			}
			this.NodeStateInternal = ELevelFlowNodeState.Failure;
			Action<LevelFlowNode, bool> completeCallBack = this.CompleteCallBack;
			if (completeCallBack == null)
			{
				return;
			}
			completeCallBack(this, false);
		}

		// Token: 0x0604513A RID: 282938 RVA: 0x01203518 File Offset: 0x01201718
		private void OnActionComplete(LevelFlowActionBase action, bool isSuccess)
		{
			if (isSuccess)
			{
				this.ActionSet.Remove(action);
				if (this.ActionSet.Count == 0)
				{
					this.NodeStateInternal = ELevelFlowNodeState.Success;
					Action<LevelFlowNode, bool> completeCallBack = this.CompleteCallBack;
					if (completeCallBack == null)
					{
						return;
					}
					completeCallBack(this, true);
					return;
				}
			}
			else
			{
				this.NodeStateInternal = ELevelFlowNodeState.Failure;
				Action<LevelFlowNode, bool> completeCallBack2 = this.CompleteCallBack;
				if (completeCallBack2 == null)
				{
					return;
				}
				completeCallBack2(this, false);
			}
		}

		// Token: 0x1700A4A8 RID: 42152
		// (get) Token: 0x0604513B RID: 282939 RVA: 0x01203575 File Offset: 0x01201775
		public ELevelFlowNodeState NodeState
		{
			get
			{
				return this.NodeStateInternal;
			}
		}

		// Token: 0x0604513C RID: 282940 RVA: 0x0120357D File Offset: 0x0120177D
		public static void CreateStaticDefaultValue()
		{
			LevelFlowNode.SelfIncrementId = 0;
		}

		// Token: 0x0604513D RID: 282941 RVA: 0x01203585 File Offset: 0x01201785
		public static void ResetStaticDefaultValue()
		{
			LevelFlowNode.SelfIncrementId = 0;
		}

		// Token: 0x040268B9 RID: 157881
		public readonly int NodeId;

		// Token: 0x040268BA RID: 157882
		private static int SelfIncrementId;

		// Token: 0x040268BB RID: 157883
		private ELevelFlowNodeState NodeStateInternal;

		// Token: 0x040268BC RID: 157884
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<LevelFlowNode, bool> CompleteCallBack;

		// Token: 0x040268BD RID: 157885
		[Nullable(2)]
		private readonly LevelFlowConditionBase Condition;

		// Token: 0x040268BE RID: 157886
		private readonly List<LevelFlowActionBase> ActionList = new List<LevelFlowActionBase>();

		// Token: 0x040268BF RID: 157887
		private readonly HashSet<LevelFlowActionBase> ActionSet = new HashSet<LevelFlowActionBase>();
	}
}
