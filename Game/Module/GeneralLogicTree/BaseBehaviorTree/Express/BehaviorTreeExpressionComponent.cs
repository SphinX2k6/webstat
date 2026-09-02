using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode;

namespace CSharpScript.Game.Module.GeneralLogicTree.BaseBehaviorTree.Express
{
	// Token: 0x02005CFE RID: 23806
	[NullableContext(1)]
	[Nullable(0)]
	public class BehaviorTreeExpressionComponent
	{
		// Token: 0x0603C013 RID: 245779 RVA: 0x00F38038 File Offset: 0x00F36238
		public BehaviorTreeExpressionComponent(Blackboard blackboard)
		{
			this.Blackboard = blackboard;
			this.TrackTextController = new TrackTextExpressController(blackboard);
			this.TrackMarkController = new TrackMarkExpressController(blackboard);
			this.TrackEffectController = new TrackEffectExpressController(this, blackboard);
			this.CheckPointEffectController = new CheckPointEffectController(blackboard);
		}

		// Token: 0x0603C014 RID: 245780 RVA: 0x00F38078 File Offset: 0x00F36278
		public void Init()
		{
			this.OnAddEvent();
			this.IsValidInternal = true;
		}

		// Token: 0x0603C015 RID: 245781 RVA: 0x00F38088 File Offset: 0x00F36288
		public void Dispose()
		{
			this.EnableTrack(false, ESetTrackReason.TreeExpressionComponentDispose, false);
			this.TrackTextController.Clear();
			this.TrackMarkController.Clear();
			this.TrackEffectController.Clear();
			this.CheckPointEffectController.EnableAllEffects(false);
			this.OnRemoveEvent();
			this.IsValidInternal = false;
		}

		// Token: 0x0603C016 RID: 245782 RVA: 0x00F380D8 File Offset: 0x00F362D8
		public void EnableTrack(bool bTrack, ESetTrackReason reason = ESetTrackReason.None, bool calledFromBoundTree = false)
		{
			if (this.Blackboard.IsTrackBoundToParent && !calledFromBoundTree)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "当前玩法追踪绑定于父任务，不能独立设置追踪状态";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("当前玩法", this.Blackboard.TreeConfigId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.TrackTextController.EnableTrack(bTrack, reason);
			this.TrackMarkController.EnableTrack(bTrack);
			this.TrackEffectController.EnableTrack(bTrack);
			this.CheckPointEffectController.EnableAllEffects(bTrack);
		}

		// Token: 0x0603C017 RID: 245783 RVA: 0x00F38160 File Offset: 0x00F36360
		public void RefreshMapMark(bool bTrack)
		{
			this.TrackMarkController.EnableTrack(bTrack);
		}

		// Token: 0x0603C018 RID: 245784 RVA: 0x00F38170 File Offset: 0x00F36370
		public void ForceSetAllMapMarksVisible(bool visible)
		{
			foreach (NodeTrackMark nodeTrackMark in this.TrackMarkController.GetAllTrackMarkCreator().Values)
			{
				nodeTrackMark.ForceSetAllMarksVisible(visible);
			}
		}

		// Token: 0x0603C019 RID: 245785 RVA: 0x00F381CC File Offset: 0x00F363CC
		public void StartTextExpress(ETreeTextExpressReason reason = ETreeTextExpressReason.None)
		{
			this.TrackTextController.StartTextExpress(reason);
		}

		// Token: 0x0603C01A RID: 245786 RVA: 0x00F381DA File Offset: 0x00F363DA
		public void EndTextExpress(ETreeTextExpressReason reason = ETreeTextExpressReason.None)
		{
			this.TrackTextController.EndTextExpress(reason);
		}

		// Token: 0x0603C01B RID: 245787 RVA: 0x00F381E8 File Offset: 0x00F363E8
		[NullableContext(2)]
		public global::Vector GetNodeTrackPosition(int nodeId)
		{
			NodeTrackMark nodeTrackMarkCreator = this.TrackMarkController.GetNodeTrackMarkCreator(nodeId);
			if (nodeTrackMarkCreator == null)
			{
				return null;
			}
			return nodeTrackMarkCreator.GetDefaultTrackPosition();
		}

		// Token: 0x0603C01C RID: 245788 RVA: 0x00F38204 File Offset: 0x00F36404
		public int GetClosestMapMarkId()
		{
			global::Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
			if (playerLocation == null)
			{
				return 0;
			}
			Dictionary<int, NodeTrackMark> allTrackMarkCreator = this.TrackMarkController.GetAllTrackMarkCreator();
			double num = 3.402823466E+38;
			int result = 0;
			foreach (NodeTrackMark nodeTrackMark in allTrackMarkCreator.Values)
			{
				Dictionary<int, global::Vector> worldMapTrackPositions = nodeTrackMark.GetWorldMapTrackPositions();
				if (worldMapTrackPositions != null)
				{
					foreach (KeyValuePair<int, global::Vector> keyValuePair in worldMapTrackPositions)
					{
						int num2;
						global::Vector vector;
						keyValuePair.Deconstruct(out num2, out vector);
						int num3 = num2;
						global::Vector trackPosition = vector;
						double num4 = this.CalculateTrackDistance(playerLocation, trackPosition);
						if (num4 < num)
						{
							num = num4;
							result = num3;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0603C01D RID: 245789 RVA: 0x00F382E4 File Offset: 0x00F364E4
		public int? GetTrackAreaInfo(int nodeId)
		{
			NodeTrackMark nodeTrackMarkCreator = this.TrackMarkController.GetNodeTrackMarkCreator(nodeId);
			if (nodeTrackMarkCreator == null)
			{
				return null;
			}
			return nodeTrackMarkCreator.GetTrackAreaInfo();
		}

		// Token: 0x0603C01E RID: 245790 RVA: 0x00F38310 File Offset: 0x00F36510
		public int? GetDefaultMark(int nodeId)
		{
			NodeTrackMark nodeTrackMarkCreator = this.TrackMarkController.GetNodeTrackMarkCreator(nodeId);
			if (nodeTrackMarkCreator == null)
			{
				return null;
			}
			return nodeTrackMarkCreator.DefaultMapMarkId;
		}

		// Token: 0x0603C01F RID: 245791 RVA: 0x00F3833C File Offset: 0x00F3653C
		public double GetTrackDistance(int nodeId)
		{
			global::Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
			if (playerLocation == null)
			{
				return 0.0;
			}
			global::Vector nodeTrackPosition = this.GetNodeTrackPosition(nodeId);
			if (nodeTrackPosition == null)
			{
				return 0.0;
			}
			return this.CalculateTrackDistance(playerLocation, nodeTrackPosition);
		}

		// Token: 0x0603C020 RID: 245792 RVA: 0x00F38380 File Offset: 0x00F36580
		public double GetRangeMarkSize(int nodeId)
		{
			NodeTrackMark nodeTrackMarkCreator = this.TrackMarkController.GetNodeTrackMarkCreator(nodeId);
			if (nodeTrackMarkCreator == null)
			{
				return 0.0;
			}
			return (double)nodeTrackMarkCreator.MarkRange;
		}

		// Token: 0x0603C021 RID: 245793 RVA: 0x00F383B0 File Offset: 0x00F365B0
		public double? GetRangeMarkShowDis(int nodeId)
		{
			NodeTrackMark nodeTrackMarkCreator = this.TrackMarkController.GetNodeTrackMarkCreator(nodeId);
			float? num = (nodeTrackMarkCreator != null) ? new float?(nodeTrackMarkCreator.RangeMarkShowDis) : null;
			if (num == null)
			{
				return null;
			}
			return new double?((double)num.GetValueOrDefault());
		}

		// Token: 0x0603C022 RID: 245794 RVA: 0x00F38404 File Offset: 0x00F36604
		public bool CheckCanShow([Nullable(new byte[]
		{
			2,
			1
		})] Func<BehaviorNodeBase, bool> nodeExtraCondition = null)
		{
			if (this.Blackboard.ContainTag(EBehaviorTreeTag.SuspendingCanShow))
			{
				return true;
			}
			IReadOnlyDictionary<int, BehaviorNodeBase> allNodes = this.Blackboard.GetAllNodes();
			if (allNodes.Count == 0)
			{
				return false;
			}
			foreach (BehaviorNodeBase behaviorNodeBase in allNodes.Values)
			{
				if (!behaviorNodeBase.ContainTag(EBehaviorTreeTag.HideInAllView) && behaviorNodeBase.ContainTag(EBehaviorTreeTag.CanShow) && (nodeExtraCondition == null || nodeExtraCondition(behaviorNodeBase)))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603C023 RID: 245795 RVA: 0x00F38498 File Offset: 0x00F36698
		public bool CheckCanShowTrackExpression()
		{
			return this.CheckCanShow((BehaviorNodeBase node) => !node.ContainTag(EBehaviorTreeTag.HideTrackExpression));
		}

		// Token: 0x0603C024 RID: 245796 RVA: 0x00F384BF File Offset: 0x00F366BF
		public void CreateMapMarks()
		{
			this.TrackMarkController.CreateMapMarks();
		}

		// Token: 0x0603C025 RID: 245797 RVA: 0x00F384CC File Offset: 0x00F366CC
		public Blackboard GetBlackBoard()
		{
			return this.Blackboard;
		}

		// Token: 0x0603C026 RID: 245798 RVA: 0x00F384D4 File Offset: 0x00F366D4
		public BehaviorTreeViewShowData CreateShowData()
		{
			return this.Blackboard.CreateShowData(true);
		}

		// Token: 0x0603C027 RID: 245799 RVA: 0x00F384E2 File Offset: 0x00F366E2
		public void UpdateLevelPlayConditionalMarks()
		{
			this.TrackMarkController.UpdateLevelPlayConditionalMarks();
		}

		// Token: 0x17009855 RID: 38997
		// (get) Token: 0x0603C028 RID: 245800 RVA: 0x00F384EF File Offset: 0x00F366EF
		// (set) Token: 0x0603C029 RID: 245801 RVA: 0x00F384FC File Offset: 0x00F366FC
		public long? BoundParentTreeId
		{
			get
			{
				return this.Blackboard.BoundParentTreeId;
			}
			set
			{
				this.Blackboard.BoundParentTreeId = value;
			}
		}

		// Token: 0x17009856 RID: 38998
		// (get) Token: 0x0603C02A RID: 245802 RVA: 0x00F3850A File Offset: 0x00F3670A
		// (set) Token: 0x0603C02B RID: 245803 RVA: 0x00F38517 File Offset: 0x00F36717
		public int? BoundParentNodeId
		{
			get
			{
				return this.Blackboard.BoundParentNodeId;
			}
			set
			{
				this.Blackboard.BoundParentNodeId = value;
			}
		}

		// Token: 0x17009857 RID: 38999
		// (get) Token: 0x0603C02C RID: 245804 RVA: 0x00F38525 File Offset: 0x00F36725
		public bool IsValid
		{
			get
			{
				return this.IsValidInternal;
			}
		}

		// Token: 0x0603C02D RID: 245805 RVA: 0x00F38530 File Offset: 0x00F36730
		private void OnAddEvent()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.OnBattleViewActive));
			Singleton<EventSystem>.Instance.Add(EEventName.DisActiveBattleView, new Action(this.OnBattleViewHide));
			Singleton<EventSystem>.Instance.Add(EEventName.GeneralLogicTreeApplyExpressionOccupation, new Action<long>(this.OnBtApplyExpressionOccupation));
			Singleton<EventSystem>.Instance.Add(EEventName.GeneralLogicTreeReleaseExpressionOccupation, new Action<long>(this.OnBtReleaseExpressionOccupation));
			Singleton<EventSystem>.Instance.AddWithTarget<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus, ENodeStatusUpdateReason>(this.Blackboard, EEventName.OnLogicTreeChildQuestNodeStatusChange, new Action<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus, ENodeStatusUpdateReason>(this.OnChildQuestNodeStatusChange));
			Singleton<EventSystem>.Instance.AddWithTarget<GeneralContext, ChildQuestNodeProgress>(this.Blackboard, EEventName.OnLogicTreeNodeProgressChange, new Action<GeneralContext, ChildQuestNodeProgress>(this.OnNodeProgressChanged));
			Singleton<EventSystem>.Instance.AddWithTarget<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.Blackboard, EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnNodeStatusUpdate));
			Singleton<EventSystem>.Instance.AddWithTarget<long, int, EBehaviorTreeSuspendType>(this.Blackboard, EEventName.GeneralLogicTreeSuspend, new Action<long, int, EBehaviorTreeSuspendType>(this.OnNodeSuspend));
			Singleton<EventSystem>.Instance.AddWithTarget(this.Blackboard, EEventName.GeneralLogicTreeCancelSuspend, new Action<long>(this.OnNodeCancelSuspend));
		}

		// Token: 0x0603C02E RID: 245806 RVA: 0x00F38658 File Offset: 0x00F36858
		private void OnRemoveEvent()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.OnBattleViewActive));
			Singleton<EventSystem>.Instance.Remove(EEventName.DisActiveBattleView, new Action(this.OnBattleViewHide));
			Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeApplyExpressionOccupation, new Action<long>(this.OnBtApplyExpressionOccupation));
			Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeReleaseExpressionOccupation, new Action<long>(this.OnBtReleaseExpressionOccupation));
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.Blackboard, EEventName.OnLogicTreeChildQuestNodeStatusChange, new Action<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus, ENodeStatusUpdateReason>(this.OnChildQuestNodeStatusChange));
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.Blackboard, EEventName.OnLogicTreeNodeProgressChange, new Action<GeneralContext, ChildQuestNodeProgress>(this.OnNodeProgressChanged));
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.Blackboard, EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnNodeStatusUpdate));
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.Blackboard, EEventName.GeneralLogicTreeSuspend, new Action<long, int, EBehaviorTreeSuspendType>(this.OnNodeSuspend));
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.Blackboard, EEventName.GeneralLogicTreeCancelSuspend, new Action<long>(this.OnNodeCancelSuspend));
		}

		// Token: 0x0603C02F RID: 245807 RVA: 0x00F38780 File Offset: 0x00F36980
		private void OnNodeStatusUpdate(GeneralContext context, NodeStatus oldStatus, NodeStatus newStatus, ENodeStatusUpdateReason reason)
		{
			if (context.Type.GetValueOrDefault() != EGeneralContextType.GeneralLogicTree)
			{
				return;
			}
			BehaviorNodeBase node = this.Blackboard.GetNode(new int?(((GeneralLogicTreeContext)context).NodeId));
			if (node == null)
			{
				return;
			}
			this.TrackTextController.UpdateOnNodeStatusChange(node, newStatus, reason);
			if (node.ContainTag(EBehaviorTreeTag.HideTrackExpression))
			{
				return;
			}
			this.TrackMarkController.UpdateOnNodeStatusChange(this.Blackboard, node, newStatus);
			if (this.Blackboard.IsTrackBoundToParent && (newStatus == NodeStatus.Activated || newStatus == NodeStatus.CompletedSuccess || newStatus == NodeStatus.CompletedFailed))
			{
				BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.Blackboard.BoundParentTreeId.Value), false);
				if (behaviorTree != null)
				{
					BindingExpressionComponentHolder bindingExpressionHolder = behaviorTree.BindingExpressionHolder;
					int? num = (bindingExpressionHolder != null) ? new int?(bindingExpressionHolder.GetCurFocusLevelPlayId()) : null;
					int treeConfigId = this.Blackboard.TreeConfigId;
					if (num.GetValueOrDefault() == treeConfigId & num != null)
					{
						BindingExpressionComponentHolder bindingExpressionHolder2 = behaviorTree.BindingExpressionHolder;
						if (bindingExpressionHolder2 != null)
						{
							bindingExpressionHolder2.OnBindingNodeTextUpdate();
						}
						BindingExpressionComponentHolder bindingExpressionHolder3 = behaviorTree.BindingExpressionHolder;
						if (bindingExpressionHolder3 == null)
						{
							return;
						}
						bindingExpressionHolder3.OnBindingNodeTrackMarkUpdate();
					}
				}
			}
		}

		// Token: 0x0603C030 RID: 245808 RVA: 0x00F38890 File Offset: 0x00F36A90
		private void OnChildQuestNodeStatusChange(GeneralContext context, ChildQuestNodeStatus oldStatus, ChildQuestNodeStatus newStatus, ENodeStatusUpdateReason reason)
		{
			if (!(context is GeneralLogicTreeContext) || !(context.Type == EGeneralContextType.GeneralLogicTree))
			{
				return;
			}
			BehaviorNodeBase node = this.Blackboard.GetNode(new int?(((GeneralLogicTreeContext)context).NodeId));
			ChildQuestNodeBase childQuestNodeBase = node as ChildQuestNodeBase;
			if (childQuestNodeBase == null || !node.ContainTag(EBehaviorTreeTag.CanShow) || node.ContainTag(EBehaviorTreeTag.HideTrackExpression))
			{
				return;
			}
			bool flag2;
			if (reason == ENodeStatusUpdateReason.Recover)
			{
				bool flag = newStatus - ChildQuestNodeStatus.CqnsEnterAction <= 1;
				flag2 = flag;
			}
			else
			{
				flag2 = ((node.ShowTipBeforeEnterActions && newStatus == ChildQuestNodeStatus.CqnsEnterAction) || (!node.ShowTipBeforeEnterActions && newStatus == ChildQuestNodeStatus.CqnsProgress));
			}
			bool flag3 = newStatus == ChildQuestNodeStatus.CqnsFinished;
			this.TrackMarkController.UpdateOnChildQuestNodeStatusChange(childQuestNodeBase, flag2, flag3);
			this.CheckPointEffectController.UpdateOnChildQuestNodeStatusChange(childQuestNodeBase, flag2, flag3);
			this.TrackEffectController.UpdateOnChildQuestNodeStatusChange(childQuestNodeBase, flag2, flag3);
			if (this.Blackboard.IsBindingLevelPlayTrack)
			{
				this.EnableTrack(false, ESetTrackReason.None, false);
			}
			if (this.Blackboard.IsTrackBoundToParent && (flag2 || flag3))
			{
				BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.Blackboard.BoundParentTreeId.Value), false);
				if (behaviorTree != null)
				{
					BindingExpressionComponentHolder bindingExpressionHolder = behaviorTree.BindingExpressionHolder;
					int? num = (bindingExpressionHolder != null) ? new int?(bindingExpressionHolder.GetCurFocusLevelPlayId()) : null;
					int treeConfigId = this.Blackboard.TreeConfigId;
					if (num.GetValueOrDefault() == treeConfigId & num != null)
					{
						BindingExpressionComponentHolder bindingExpressionHolder2 = behaviorTree.BindingExpressionHolder;
						if (bindingExpressionHolder2 == null)
						{
							return;
						}
						bindingExpressionHolder2.OnBindingNodeTrackMarkUpdate();
					}
				}
			}
		}

		// Token: 0x0603C031 RID: 245809 RVA: 0x00F38A07 File Offset: 0x00F36C07
		private void OnNodeSuspend(long treeId, int nodeId, EBehaviorTreeSuspendType suspendType)
		{
			if (this.Blackboard.TreeIncId != treeId)
			{
				return;
			}
			this.TrackTextController.OnSuspend(nodeId, suspendType);
			this.TrackMarkController.OnSuspend(suspendType);
		}

		// Token: 0x0603C032 RID: 245810 RVA: 0x00F38A31 File Offset: 0x00F36C31
		private void OnNodeCancelSuspend(long treeId)
		{
			if (this.Blackboard.TreeIncId != treeId)
			{
				return;
			}
			this.TrackTextController.OnCancelSuspend();
			this.TrackMarkController.OnCancelSuspend();
		}

		// Token: 0x0603C033 RID: 245811 RVA: 0x00F38A58 File Offset: 0x00F36C58
		private void OnBattleViewActive()
		{
			this.TrackEffectController.OnBattleViewActive();
		}

		// Token: 0x0603C034 RID: 245812 RVA: 0x00F38A65 File Offset: 0x00F36C65
		private void OnBattleViewHide()
		{
			this.TrackEffectController.OnBattleViewHide();
		}

		// Token: 0x0603C035 RID: 245813 RVA: 0x00F38A74 File Offset: 0x00F36C74
		private void OnNodeProgressChanged(GeneralContext context, ChildQuestNodeProgress progress)
		{
			GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
			if (generalLogicTreeContext == null || !(context.Type == EGeneralContextType.GeneralLogicTree) || progress == null)
			{
				return;
			}
			if (generalLogicTreeContext.TreeIncId != this.Blackboard.TreeIncId)
			{
				return;
			}
			IReadOnlyList<int> readOnlyList = null;
			ChildQuestNodeProgress.ProgressOneofCase progressCase = progress.ProgressCase;
			if (progressCase <= ChildQuestNodeProgress.ProgressOneofCase.MonsterCreator)
			{
				if (progressCase == ChildQuestNodeProgress.ProgressOneofCase.Kill)
				{
					readOnlyList = progress.Kill.MonId;
					goto IL_DA;
				}
				if (progressCase != ChildQuestNodeProgress.ProgressOneofCase.MonsterCreator)
				{
					goto IL_DA;
				}
				List<int> list = new List<int>();
				readOnlyList = list;
				using (IEnumerator<MonsterCreatorProgressSlot> enumerator = progress.MonsterCreator.Slots.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						MonsterCreatorProgressSlot monsterCreatorProgressSlot = enumerator.Current;
						list.AddRange(monsterCreatorProgressSlot.KillMonIds);
					}
					goto IL_DA;
				}
			}
			else
			{
				if (progressCase == ChildQuestNodeProgress.ProgressOneofCase.Interact)
				{
					readOnlyList = progress.Interact.NpcId;
					goto IL_DA;
				}
				if (progressCase != ChildQuestNodeProgress.ProgressOneofCase.EntityStateList)
				{
					goto IL_DA;
				}
			}
			readOnlyList = progress.EntityStateList.EntityId;
			IL_DA:
			NodeTrackMark nodeTrackMarkCreator = this.TrackMarkController.GetNodeTrackMarkCreator(generalLogicTreeContext.NodeId);
			if (readOnlyList != null && nodeTrackMarkCreator != null)
			{
				nodeTrackMarkCreator.OnNodeProgressChanged(readOnlyList);
			}
		}

		// Token: 0x0603C036 RID: 245814 RVA: 0x00F38B8C File Offset: 0x00F36D8C
		private void OnBtApplyExpressionOccupation(long treeIncId)
		{
			bool bSelf = this.Blackboard.TreeIncId == treeIncId;
			this.TrackTextController.OnBtApplyExpressionOccupation(bSelf);
			this.TrackMarkController.OnBtApplyExpressionOccupation(bSelf);
			this.TrackEffectController.OnBtApplyExpressionOccupation(bSelf);
			this.CheckPointEffectController.OnBtApplyExpressionOccupation(bSelf);
		}

		// Token: 0x0603C037 RID: 245815 RVA: 0x00F38BD8 File Offset: 0x00F36DD8
		private void OnBtReleaseExpressionOccupation(long treeIncId)
		{
			bool bSelf = this.Blackboard.TreeIncId == treeIncId;
			this.TrackTextController.OnBtReleaseExpressionOccupation(bSelf);
			this.TrackMarkController.OnBtReleaseExpressionOccupation(bSelf);
			this.TrackEffectController.OnBtReleaseExpressionOccupation(bSelf);
			this.CheckPointEffectController.OnBtReleaseExpressionOccupation(bSelf);
		}

		// Token: 0x0603C038 RID: 245816 RVA: 0x00F38C24 File Offset: 0x00F36E24
		private double CalculateTrackDistance(global::Vector playerLocation, global::Vector trackPosition)
		{
			return Math.Round(global::Vector.Distance(trackPosition, playerLocation) * 0.009999999776482582);
		}

		// Token: 0x04021B6C RID: 138092
		private readonly TrackTextExpressController TrackTextController;

		// Token: 0x04021B6D RID: 138093
		private readonly TrackEffectExpressController TrackEffectController;

		// Token: 0x04021B6E RID: 138094
		private readonly TrackMarkExpressController TrackMarkController;

		// Token: 0x04021B6F RID: 138095
		private readonly CheckPointEffectController CheckPointEffectController;

		// Token: 0x04021B70 RID: 138096
		private bool IsValidInternal;

		// Token: 0x04021B71 RID: 138097
		private readonly Blackboard Blackboard;
	}
}
