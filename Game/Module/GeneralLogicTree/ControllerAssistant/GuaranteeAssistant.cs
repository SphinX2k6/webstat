using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Guarantee;

namespace CSharpScript.Game.Module.GeneralLogicTree.ControllerAssistant
{
	// Token: 0x02005CD3 RID: 23763
	[NullableContext(1)]
	[Nullable(0)]
	public class GuaranteeAssistant : ControllerAssistantBase
	{
		// Token: 0x0603BEA5 RID: 245413 RVA: 0x00F2F75F File Offset: 0x00F2D95F
		protected override void OnDestroy()
		{
		}

		// Token: 0x0603BEA6 RID: 245414 RVA: 0x00F2F764 File Offset: 0x00F2D964
		public override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.AddGuaranteeAction, new Action<string, GeneralContext, GuaranteeActionInfo, bool?>(this.AddGuaranteeAction));
			Singleton<EventSystem>.Instance.Add<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, new Action<string, GeneralContext, GuaranteeActionInfo, bool?>(this.RemGuaranteeAction));
			Singleton<EventSystem>.Instance.Add<long, ETreeRemoveReason>(EEventName.OnGeneralLogicTreeRemove, new Action<long, ETreeRemoveReason>(this.OnGeneralLogicTreeRemove));
			Singleton<EventSystem>.Instance.Add<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnNodeStatusUpdate));
			Singleton<EventSystem>.Instance.Add<long, int, EBehaviorTreeSuspendType>(EEventName.GeneralLogicTreeSuspend, new Action<long, int, EBehaviorTreeSuspendType>(this.OnGeneralLogicTreeSuspend));
		}

		// Token: 0x0603BEA7 RID: 245415 RVA: 0x00F2F800 File Offset: 0x00F2DA00
		public override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.AddGuaranteeAction, new Action<string, GeneralContext, GuaranteeActionInfo, bool?>(this.AddGuaranteeAction));
			Singleton<EventSystem>.Instance.Remove<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, new Action<string, GeneralContext, GuaranteeActionInfo, bool?>(this.RemGuaranteeAction));
			Singleton<EventSystem>.Instance.Remove<long, ETreeRemoveReason>(EEventName.OnGeneralLogicTreeRemove, new Action<long, ETreeRemoveReason>(this.OnGeneralLogicTreeRemove));
			Singleton<EventSystem>.Instance.Remove<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnNodeStatusUpdate));
			Singleton<EventSystem>.Instance.Remove<long, int, EBehaviorTreeSuspendType>(EEventName.GeneralLogicTreeSuspend, new Action<long, int, EBehaviorTreeSuspendType>(this.OnGeneralLogicTreeSuspend));
		}

		// Token: 0x0603BEA8 RID: 245416 RVA: 0x00F2F89C File Offset: 0x00F2DA9C
		private void AddGuaranteeAction(string instigatorName, [Nullable(2)] GeneralContext instigatorContext, GuaranteeActionInfo guaranteeActionInfo, bool? bNeedGuaranteeInQuest = false)
		{
			GeneralContext generalContext = instigatorContext;
			DynamicInteractContext dynamicInteractContext = instigatorContext as DynamicInteractContext;
			if (dynamicInteractContext != null)
			{
				generalContext = dynamicInteractContext.FinalContext;
			}
			GeneralLogicTreeContext generalLogicTreeContext = generalContext as GeneralLogicTreeContext;
			if (generalLogicTreeContext == null || generalLogicTreeContext.TreeIncId == 0L)
			{
				return;
			}
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(generalLogicTreeContext.TreeIncId), false);
			if (behaviorTree == null)
			{
				return;
			}
			EActionFilterMode actionFilterMode = Singleton<GuaranteeActionCenter>.Instance.GetActionFilterMode(guaranteeActionInfo.Name);
			behaviorTree.AddGuaranteeActionInfo(instigatorName, generalLogicTreeContext.NodeId, guaranteeActionInfo, actionFilterMode);
		}

		// Token: 0x0603BEA9 RID: 245417 RVA: 0x00F2F90C File Offset: 0x00F2DB0C
		private void RemGuaranteeAction(string instigatorName, [Nullable(2)] GeneralContext instigatorContext, GuaranteeActionInfo guaranteeActionInfo, bool? bNeedGuaranteeInQuest = false)
		{
			GeneralContext generalContext = instigatorContext;
			DynamicInteractContext dynamicInteractContext = instigatorContext as DynamicInteractContext;
			if (dynamicInteractContext != null)
			{
				generalContext = dynamicInteractContext.FinalContext;
			}
			GeneralLogicTreeContext generalLogicTreeContext = generalContext as GeneralLogicTreeContext;
			if (generalLogicTreeContext == null || generalLogicTreeContext.TreeIncId == 0L)
			{
				return;
			}
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(generalLogicTreeContext.TreeIncId), false);
			if (behaviorTree == null)
			{
				return;
			}
			EActionFilterMode actionFilterMode = Singleton<GuaranteeActionCenter>.Instance.GetActionFilterMode(guaranteeActionInfo.Name);
			behaviorTree.PopGuaranteeActionInfo(instigatorName, guaranteeActionInfo, actionFilterMode);
			ModelBase<GeneralLogicTreeModel>.Instance.PopGuaranteeActionsWhenLogicTreeRemove(generalLogicTreeContext.TreeIncId, guaranteeActionInfo);
		}

		// Token: 0x0603BEAA RID: 245418 RVA: 0x00F2F98C File Offset: 0x00F2DB8C
		private void OnNodeStatusUpdate(GeneralContext context, NodeStatus oldStatus, NodeStatus newStatus, ENodeStatusUpdateReason reason)
		{
			GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
			if (generalLogicTreeContext == null || generalLogicTreeContext.TreeIncId == 0L)
			{
				return;
			}
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(generalLogicTreeContext.TreeIncId), false);
			if (behaviorTree == null)
			{
				return;
			}
			int rollbackPoint = behaviorTree.GetRollbackPoint();
			if (newStatus != NodeStatus.Activated)
			{
				if (newStatus - NodeStatus.CompletedSuccess > 1)
				{
					return;
				}
				if (rollbackPoint == 0)
				{
					behaviorTree.ClearGuaranteeActions(generalLogicTreeContext.NodeId);
				}
			}
			else if (rollbackPoint != 0 && generalLogicTreeContext.NodeId == rollbackPoint)
			{
				behaviorTree.ClearGuaranteeActions(0);
				return;
			}
		}

		// Token: 0x0603BEAB RID: 245419 RVA: 0x00F2F9FC File Offset: 0x00F2DBFC
		private void OnGeneralLogicTreeRemove(long treeIncId, ETreeRemoveReason removeReason)
		{
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
			if (behaviorTree == null)
			{
				return;
			}
			behaviorTree.ExecuteTreeGuaranteeActions(removeReason);
			Dictionary<long, List<GuaranteeActionInfo>> guaranteeActionsWhenLogicTreeRemove = ModelBase<GeneralLogicTreeModel>.Instance.GuaranteeActionsWhenLogicTreeRemove;
			List<GuaranteeActionInfo> list;
			if (guaranteeActionsWhenLogicTreeRemove != null && guaranteeActionsWhenLogicTreeRemove.Remove(treeIncId, out list))
			{
				if (list.Count == 0)
				{
					return;
				}
				GuaranteeContext context = (removeReason == ETreeRemoveReason.TreeRollback) ? GuaranteeContext.Create(null, EGuaranteeReason.TreeRollback) : GuaranteeContext.Create(null, EGuaranteeReason.TreeDestroy);
				ControllerBase<GuaranteeController>.Instance.ExecuteActions(list, context);
			}
		}

		// Token: 0x0603BEAC RID: 245420 RVA: 0x00F2FA7C File Offset: 0x00F2DC7C
		private void OnGeneralLogicTreeSuspend(long treeId, int nodeId, EBehaviorTreeSuspendType suspendType)
		{
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeId), false);
			if (behaviorTree == null)
			{
				return;
			}
			foreach (int sessionId in behaviorTree.GetBlackBoard().GetCurrentExecuteActions())
			{
				ControllerBase<LevelGeneralController>.Instance.StopActionsExecute(sessionId);
			}
			behaviorTree.ExecuteTreeGuaranteeActions(ETreeRemoveReason.TreeDestroy);
		}
	}
}
