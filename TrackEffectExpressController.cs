using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.GeneralLogicTree.BaseBehaviorTree.Express;
using CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode;

// Token: 0x02001DBE RID: 7614
[NullableContext(1)]
[Nullable(0)]
public class TrackEffectExpressController
{
	// Token: 0x0600E137 RID: 57655 RVA: 0x003C8EBF File Offset: 0x003C70BF
	public TrackEffectExpressController(BehaviorTreeExpressionComponent owner, Blackboard blackboard)
	{
	}

	// Token: 0x0600E138 RID: 57656 RVA: 0x003C8EE0 File Offset: 0x003C70E0
	public void Clear()
	{
		foreach (KeyValuePair<int, NodeTrackEffect> keyValuePair in this.TrackEffects)
		{
			keyValuePair.Value.Destroy();
		}
		this.TrackEffects.Clear();
		this.Owner = null;
	}

	// Token: 0x0600E139 RID: 57657 RVA: 0x003C8F4C File Offset: 0x003C714C
	public void EnableTrack(bool value)
	{
		foreach (NodeTrackEffect nodeTrackEffect in this.TrackEffects.Values)
		{
			if (value)
			{
				nodeTrackEffect.Start();
			}
			else
			{
				nodeTrackEffect.End();
			}
		}
	}

	// Token: 0x0600E13A RID: 57658 RVA: 0x003C8FB0 File Offset: 0x003C71B0
	public void UpdateOnChildQuestNodeStatusChange(ChildQuestNodeBase node, bool bStart, bool bEnd)
	{
		ITrackTarget trackTarget = node.TrackTarget;
		if (((trackTarget != null) ? trackTarget.EffectOption : null) == null)
		{
			return;
		}
		if (bStart)
		{
			this.NodeTrackEffectStart(node.NodeId, trackTarget.EffectOption, this.<blackboard>P.IsTracking);
		}
		if (bEnd)
		{
			this.NodeTrackEffectEnd(node.NodeId);
		}
	}

	// Token: 0x0600E13B RID: 57659 RVA: 0x003C9004 File Offset: 0x003C7204
	private void NodeTrackEffectStart(int nodeId, ITrackEffectAutoChange effectOption, bool bTracking)
	{
		NodeTrackEffect nodeTrackEffect = this.AddNodeTrackMarkCreator(nodeId, effectOption);
		if (bTracking)
		{
			nodeTrackEffect.Start();
		}
	}

	// Token: 0x0600E13C RID: 57660 RVA: 0x003C9023 File Offset: 0x003C7223
	private void NodeTrackEffectEnd(int nodeId)
	{
		NodeTrackEffect nodeTrackMarkCreator = this.GetNodeTrackMarkCreator(nodeId);
		if (nodeTrackMarkCreator != null)
		{
			nodeTrackMarkCreator.End();
		}
		this.TrackEffects.Remove(nodeId);
	}

	// Token: 0x0600E13D RID: 57661 RVA: 0x003C9044 File Offset: 0x003C7244
	private NodeTrackEffect AddNodeTrackMarkCreator(int nodeId, ITrackEffectAutoChange effectOption)
	{
		NodeTrackEffect nodeTrackMarkCreator = this.GetNodeTrackMarkCreator(nodeId);
		if (nodeTrackMarkCreator != null)
		{
			return nodeTrackMarkCreator;
		}
		NodeTrackEffect nodeTrackEffect = new NodeTrackEffect(this.Owner, nodeId, effectOption);
		this.TrackEffects[nodeId] = nodeTrackEffect;
		return nodeTrackEffect;
	}

	// Token: 0x0600E13E RID: 57662 RVA: 0x003C907A File Offset: 0x003C727A
	[NullableContext(2)]
	public NodeTrackEffect GetNodeTrackMarkCreator(int nodeId)
	{
		return this.TrackEffects.GetValueOrDefault(nodeId);
	}

	// Token: 0x0600E13F RID: 57663 RVA: 0x003C9088 File Offset: 0x003C7288
	public void OnBattleViewActive()
	{
		foreach (NodeTrackEffect nodeTrackEffect in this.TrackEffects.Values)
		{
			nodeTrackEffect.OnBattleViewActive();
		}
	}

	// Token: 0x0600E140 RID: 57664 RVA: 0x003C90E0 File Offset: 0x003C72E0
	public void OnBattleViewHide()
	{
		foreach (NodeTrackEffect nodeTrackEffect in this.TrackEffects.Values)
		{
			nodeTrackEffect.OnBattleViewHide();
		}
	}

	// Token: 0x0600E141 RID: 57665 RVA: 0x003C9138 File Offset: 0x003C7338
	public void OnBtApplyExpressionOccupation(bool bSelf)
	{
		if (bSelf)
		{
			return;
		}
		foreach (NodeTrackEffect nodeTrackEffect in this.TrackEffects.Values)
		{
			nodeTrackEffect.OnExpressOccupied();
		}
	}

	// Token: 0x0600E142 RID: 57666 RVA: 0x003C9194 File Offset: 0x003C7394
	public void OnBtReleaseExpressionOccupation(bool bSelf)
	{
		if (bSelf)
		{
			return;
		}
		foreach (NodeTrackEffect nodeTrackEffect in this.TrackEffects.Values)
		{
			nodeTrackEffect.OnExpressOccupationRelease();
		}
	}

	// Token: 0x04006BEF RID: 27631
	[CompilerGenerated]
	private Blackboard <blackboard>P = blackboard;

	// Token: 0x04006BF0 RID: 27632
	[Nullable(2)]
	private BehaviorTreeExpressionComponent Owner = owner;

	// Token: 0x04006BF1 RID: 27633
	private readonly Dictionary<int, NodeTrackEffect> TrackEffects = new Dictionary<int, NodeTrackEffect>();
}
