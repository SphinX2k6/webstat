using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode;

// Token: 0x02001DC7 RID: 7623
[NullableContext(1)]
[Nullable(0)]
public class TrackMarkExpressController
{
	// Token: 0x0600E164 RID: 57700 RVA: 0x003C9877 File Offset: 0x003C7A77
	public TrackMarkExpressController(Blackboard Blackboard)
	{
	}

	// Token: 0x0600E165 RID: 57701 RVA: 0x003C9891 File Offset: 0x003C7A91
	internal static bool IsLogicBtNodeType(EBtNode type)
	{
		return type == EBtNode.ConditionSelector || type == EBtNode.ParallelSelect || type == EBtNode.Sequence || type == EBtNode.Select;
	}

	// Token: 0x0600E166 RID: 57702 RVA: 0x003C98A8 File Offset: 0x003C7AA8
	internal unsafe static bool SanitizeOverrideChild(bool requested, Blackboard blackBoard, int nodeId, int treeConfigId)
	{
		if (!requested)
		{
			return false;
		}
		IBtNode nodeConfig = blackBoard.GetNodeConfig(nodeId);
		if (nodeConfig != null && TrackMarkExpressController.IsLogicBtNodeType(nodeConfig.Type))
		{
			return true;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GeneralLogicTree;
		ELogAuthor author = ELogAuthor.HYF;
		string message = "OverrideChildNodeTrackTarget 仅可配置在逻辑节点上，将被忽略";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("行为树Id", treeConfigId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("节点Id", nodeId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("节点类型", (nodeConfig != null) ? new EBtNode?(nodeConfig.Type) : null);
		instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		return false;
	}

	// Token: 0x0600E167 RID: 57703 RVA: 0x003C996C File Offset: 0x003C7B6C
	internal static IOutOfRangeRuntime BuildOutOfRangeRuntimeFromLocations(IOutOfRangeTrackTarget cfg, Blackboard blackBoard, int nodeId, int treeConfigId)
	{
		global::Vector value = global::Vector.Create((double)cfg.TrackPos.X.GetValueOrDefault(), (double)cfg.TrackPos.Y.GetValueOrDefault(), (double)cfg.TrackPos.Z.GetValueOrDefault());
		global::Vector center = global::Vector.Create((double)cfg.Center.X.GetValueOrDefault(), (double)cfg.Center.Y.GetValueOrDefault(), (double)cfg.Center.Z.GetValueOrDefault());
		bool overrideChildNodeTrackTarget = TrackMarkExpressController.SanitizeOverrideChild(cfg.OverrideChildNodeTrackTarget.GetValueOrDefault(), blackBoard, nodeId, treeConfigId);
		return new IOutOfRangeRuntime
		{
			Targets = new List<TEntityIdOrPos>
			{
				value
			},
			Center = center,
			RadiusSq = (double)cfg.Radius * (double)cfg.Radius,
			OverrideChildNodeTrackTarget = overrideChildNodeTrackTarget
		};
	}

	// Token: 0x0600E168 RID: 57704 RVA: 0x003C9A54 File Offset: 0x003C7C54
	internal static IOutOfRangeRuntime BuildOutOfRangeRuntimeFromEntities(IOutOfRangeTrackEntity cfg, Blackboard blackBoard, int nodeId, int treeConfigId)
	{
		global::Vector center = global::Vector.Create((double)cfg.Center.X.GetValueOrDefault(), (double)cfg.Center.Y.GetValueOrDefault(), (double)cfg.Center.Z.GetValueOrDefault());
		bool overrideChildNodeTrackTarget = TrackMarkExpressController.SanitizeOverrideChild(cfg.OverrideChildNodeTrackTarget.GetValueOrDefault(), blackBoard, nodeId, treeConfigId);
		return new IOutOfRangeRuntime
		{
			Targets = new List<TEntityIdOrPos>
			{
				cfg.TrackEntityId
			},
			Center = center,
			RadiusSq = (double)cfg.Radius * (double)cfg.Radius,
			OverrideChildNodeTrackTarget = overrideChildNodeTrackTarget
		};
	}

	// Token: 0x0600E169 RID: 57705 RVA: 0x003C9B00 File Offset: 0x003C7D00
	public void Clear()
	{
		foreach (NodeTrackMark nodeTrackMark in this.TrackMarks.Values)
		{
			nodeTrackMark.Destroy();
		}
		this.TrackMarks.Clear();
	}

	// Token: 0x0600E16A RID: 57706 RVA: 0x003C9B60 File Offset: 0x003C7D60
	[NullableContext(2)]
	public NodeTrackMark GetNodeTrackMarkCreator(int nodeId)
	{
		return this.TrackMarks.GetValueOrDefault(nodeId);
	}

	// Token: 0x0600E16B RID: 57707 RVA: 0x003C9B6E File Offset: 0x003C7D6E
	public Dictionary<int, NodeTrackMark> GetAllTrackMarkCreator()
	{
		return this.TrackMarks;
	}

	// Token: 0x0600E16C RID: 57708 RVA: 0x003C9B78 File Offset: 0x003C7D78
	public bool IsSuppressedByAncestor(int nodeId)
	{
		IBtNode nodeConfig = this.<Blackboard>P.GetNodeConfig(nodeId);
		IBtNode nodeConfig2;
		for (int? num = (nodeConfig != null) ? nodeConfig.ParentNodeId : null; num != null; num = ((nodeConfig2 != null) ? nodeConfig2.ParentNodeId : null))
		{
			int? num2 = num;
			int num3 = 0;
			if (num2.GetValueOrDefault() == num3 & num2 != null)
			{
				break;
			}
			NodeTrackMark valueOrDefault = this.TrackMarks.GetValueOrDefault(num.Value);
			if (valueOrDefault != null && valueOrDefault.HasOverrideChildNode() && valueOrDefault.IsCurrentlyOutOfRange())
			{
				return true;
			}
			nodeConfig2 = this.<Blackboard>P.GetNodeConfig(num.Value);
		}
		return false;
	}

	// Token: 0x0600E16D RID: 57709 RVA: 0x003C9C1C File Offset: 0x003C7E1C
	public void NotifyDescendantsRefreshSuppression(int ancestorNodeId)
	{
		foreach (KeyValuePair<int, NodeTrackMark> keyValuePair in this.TrackMarks)
		{
			int num;
			NodeTrackMark nodeTrackMark;
			keyValuePair.Deconstruct(out num, out nodeTrackMark);
			int num2 = num;
			NodeTrackMark nodeTrackMark2 = nodeTrackMark;
			if (num2 != ancestorNodeId && this.IsDescendantOf(num2, ancestorNodeId))
			{
				bool suppressedByAncestor = this.IsSuppressedByAncestor(num2);
				nodeTrackMark2.ApplyRangeState(suppressedByAncestor);
			}
		}
	}

	// Token: 0x0600E16E RID: 57710 RVA: 0x003C9C98 File Offset: 0x003C7E98
	private bool IsDescendantOf(int nodeId, int ancestorNodeId)
	{
		IBtNode nodeConfig = this.<Blackboard>P.GetNodeConfig(nodeId);
		IBtNode nodeConfig2;
		for (int? num = (nodeConfig != null) ? nodeConfig.ParentNodeId : null; num != null; num = ((nodeConfig2 != null) ? nodeConfig2.ParentNodeId : null))
		{
			int? num2 = num;
			int num3 = 0;
			if (num2.GetValueOrDefault() == num3 & num2 != null)
			{
				break;
			}
			num2 = num;
			if (num2.GetValueOrDefault() == ancestorNodeId & num2 != null)
			{
				return true;
			}
			nodeConfig2 = this.<Blackboard>P.GetNodeConfig(num.Value);
		}
		return false;
	}

	// Token: 0x0600E16F RID: 57711 RVA: 0x003C9D2C File Offset: 0x003C7F2C
	public void EnableTrack(bool value)
	{
		foreach (NodeTrackMark nodeTrackMark in this.TrackMarks.Values)
		{
			nodeTrackMark.EnableTrack(value);
		}
	}

	// Token: 0x0600E170 RID: 57712 RVA: 0x003C9D84 File Offset: 0x003C7F84
	public void CreateMapMarks()
	{
		foreach (NodeTrackMark nodeTrackMark in this.TrackMarks.Values)
		{
			nodeTrackMark.CreateMapMarks();
		}
	}

	// Token: 0x0600E171 RID: 57713 RVA: 0x003C9DDC File Offset: 0x003C7FDC
	public void UpdateLevelPlayConditionalMarks()
	{
		foreach (NodeTrackMark nodeTrackMark in this.TrackMarks.Values)
		{
			nodeTrackMark.UpdateLevelPlayConditionalMark();
		}
	}

	// Token: 0x0600E172 RID: 57714 RVA: 0x003C9E34 File Offset: 0x003C8034
	public void UpdateOnNodeStatusChange(Blackboard blackBoard, BehaviorNodeBase node, NodeStatus newStatus)
	{
		ITrackTarget trackTarget = node.TrackTarget;
		if (trackTarget == null)
		{
			return;
		}
		switch (newStatus)
		{
		case NodeStatus.Activated:
			if (node.NodeType != EBtNode.ChildQuest && node.ContainTag(EBehaviorTreeTag.CanShow))
			{
				this.NodeTrackMarkStart(node.NodeId, blackBoard, trackTarget, blackBoard.IsOccupied);
				return;
			}
			break;
		case NodeStatus.Completing:
		case NodeStatus.Suspend:
			break;
		case NodeStatus.CompletedSuccess:
		case NodeStatus.CompletedFailed:
			this.NodeTrackMarkEnd(node.NodeId);
			return;
		case NodeStatus.Destroy:
			this.RemoveNodeTrackMarkCreator(node.NodeId);
			break;
		default:
			return;
		}
	}

	// Token: 0x0600E173 RID: 57715 RVA: 0x003C9EB0 File Offset: 0x003C80B0
	public void UpdateOnChildQuestNodeStatusChange(ChildQuestNodeBase node, bool bStart, bool bEnd)
	{
		ITrackTarget trackTarget = node.TrackTarget;
		if (trackTarget == null)
		{
			return;
		}
		if (bStart)
		{
			bool isOccupied = this.<Blackboard>P.IsOccupied;
			this.NodeTrackMarkStart(node.NodeId, this.<Blackboard>P, trackTarget, isOccupied);
		}
		if (bEnd)
		{
			this.NodeTrackMarkEnd(node.NodeId);
		}
	}

	// Token: 0x0600E174 RID: 57716 RVA: 0x003C9EFC File Offset: 0x003C80FC
	public void OnBtApplyExpressionOccupation(bool bSelf)
	{
		if (bSelf)
		{
			return;
		}
		foreach (NodeTrackMark nodeTrackMark in this.TrackMarks.Values)
		{
			nodeTrackMark.OnExpressOccupied();
		}
	}

	// Token: 0x0600E175 RID: 57717 RVA: 0x003C9F58 File Offset: 0x003C8158
	public void OnBtReleaseExpressionOccupation(bool bSelf)
	{
		if (bSelf)
		{
			return;
		}
		foreach (NodeTrackMark nodeTrackMark in this.TrackMarks.Values)
		{
			nodeTrackMark.OnExpressOccupationRelease();
		}
	}

	// Token: 0x0600E176 RID: 57718 RVA: 0x003C9FB4 File Offset: 0x003C81B4
	public void OnSuspend(EBehaviorTreeSuspendType suspendType)
	{
		this.OnBtApplyExpressionOccupation(false);
	}

	// Token: 0x0600E177 RID: 57719 RVA: 0x003C9FBD File Offset: 0x003C81BD
	public void OnCancelSuspend()
	{
		if (!this.<Blackboard>P.IsOccupied)
		{
			this.OnBtReleaseExpressionOccupation(false);
		}
	}

	// Token: 0x0600E178 RID: 57720 RVA: 0x003C9FD3 File Offset: 0x003C81D3
	private void NodeTrackMarkStart(int nodeId, Blackboard blackBoard, ITrackTarget trackTarget, bool bOccupied)
	{
		this.TryAddNodeTrackMarkCreator(nodeId, blackBoard, trackTarget).OnNodeStart(bOccupied);
	}

	// Token: 0x0600E179 RID: 57721 RVA: 0x003C9FE5 File Offset: 0x003C81E5
	private void NodeTrackMarkEnd(int nodeId)
	{
		NodeTrackMark nodeTrackMarkCreator = this.GetNodeTrackMarkCreator(nodeId);
		if (nodeTrackMarkCreator != null)
		{
			nodeTrackMarkCreator.OnNodeEnd();
		}
		this.RemoveNodeTrackMarkCreator(nodeId);
	}

	// Token: 0x0600E17A RID: 57722 RVA: 0x003CA000 File Offset: 0x003C8200
	private NodeTrackMark TryAddNodeTrackMarkCreator(int nodeId, Blackboard blackBoard, ITrackTarget trackTarget)
	{
		NodeTrackMark nodeTrackMarkCreator = this.GetNodeTrackMarkCreator(nodeId);
		if (nodeTrackMarkCreator != null)
		{
			return nodeTrackMarkCreator;
		}
		int customIconId = 0;
		ChildQuestNodeBase childQuestNodeBase = blackBoard.GetNode(new int?(nodeId)) as ChildQuestNodeBase;
		if (childQuestNodeBase != null && childQuestNodeBase.CustomTrackIconId != 0)
		{
			customIconId = childQuestNodeBase.CustomTrackIconId;
		}
		NodeTrackMark nodeTrackMark = new NodeTrackMark(this, blackBoard, blackBoard.TreeIncId, blackBoard.TreeConfigId, nodeId, customIconId, trackTarget);
		this.TrackMarks[nodeId] = nodeTrackMark;
		return nodeTrackMark;
	}

	// Token: 0x0600E17B RID: 57723 RVA: 0x003CA065 File Offset: 0x003C8265
	private void RemoveNodeTrackMarkCreator(int nodeId)
	{
		NodeTrackMark nodeTrackMarkCreator = this.GetNodeTrackMarkCreator(nodeId);
		if (nodeTrackMarkCreator != null)
		{
			nodeTrackMarkCreator.Destroy();
		}
		this.TrackMarks.Remove(nodeId);
	}

	// Token: 0x04006C0E RID: 27662
	[CompilerGenerated]
	private Blackboard <Blackboard>P = Blackboard;

	// Token: 0x04006C0F RID: 27663
	private readonly Dictionary<int, NodeTrackMark> TrackMarks = new Dictionary<int, NodeTrackMark>();
}
