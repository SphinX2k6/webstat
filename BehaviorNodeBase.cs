using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.GeneralLogicTree.BaseBehaviorTree;

// Token: 0x02001DC9 RID: 7625
[NullableContext(1)]
[Nullable(0)]
public abstract class BehaviorNodeBase : BehaviorTreeTagContainer
{
	// Token: 0x0600E1A9 RID: 57769 RVA: 0x003CC7FB File Offset: 0x003CA9FB
	protected BehaviorNodeBase(int nodeId)
	{
	}

	// Token: 0x1700119C RID: 4508
	// (get) Token: 0x0600E1AA RID: 57770
	public abstract EBtNode NodeType { get; }

	// Token: 0x1700119D RID: 4509
	// (get) Token: 0x0600E1AB RID: 57771 RVA: 0x003CC80A File Offset: 0x003CAA0A
	public ENodeTrackTextRule TrackTextRule
	{
		get
		{
			return this.TrackTextRuleInner;
		}
	}

	// Token: 0x1700119E RID: 4510
	// (get) Token: 0x0600E1AC RID: 57772 RVA: 0x003CC812 File Offset: 0x003CAA12
	public long TreeIncId
	{
		get
		{
			return this.InnerTreeIncId;
		}
	}

	// Token: 0x1700119F RID: 4511
	// (get) Token: 0x0600E1AD RID: 57773 RVA: 0x003CC81A File Offset: 0x003CAA1A
	public int TreeConfigId
	{
		get
		{
			return this.InnerTreeConfigId;
		}
	}

	// Token: 0x170011A0 RID: 4512
	// (get) Token: 0x0600E1AE RID: 57774 RVA: 0x003CC822 File Offset: 0x003CAA22
	public int NodeId
	{
		get
		{
			return this.InnerNodeId;
		}
	}

	// Token: 0x170011A1 RID: 4513
	// (get) Token: 0x0600E1AF RID: 57775 RVA: 0x003CC82A File Offset: 0x003CAA2A
	public NodeStatus Status
	{
		get
		{
			return this.InnerStatus;
		}
	}

	// Token: 0x170011A2 RID: 4514
	// (get) Token: 0x0600E1B0 RID: 57776 RVA: 0x003CC832 File Offset: 0x003CAA32
	public bool IsProcessing
	{
		get
		{
			return this.Status == NodeStatus.Activated || this.Status == NodeStatus.Completing;
		}
	}

	// Token: 0x170011A3 RID: 4515
	// (get) Token: 0x0600E1B1 RID: 57777 RVA: 0x003CC848 File Offset: 0x003CAA48
	public bool IsSuccess
	{
		get
		{
			return this.Status == NodeStatus.CompletedSuccess;
		}
	}

	// Token: 0x170011A4 RID: 4516
	// (get) Token: 0x0600E1B2 RID: 57778 RVA: 0x003CC853 File Offset: 0x003CAA53
	public bool IsFailure
	{
		get
		{
			return this.Status == NodeStatus.CompletedFailed || this.Status == NodeStatus.Destroy;
		}
	}

	// Token: 0x0600E1B3 RID: 57779 RVA: 0x003CC86C File Offset: 0x003CAA6C
	public virtual void Init(Blackboard blackboard, ENodeStatusUpdateReason reason, global::NodeInfo data, IBtNode config, BtType btType)
	{
		this.Blackboard = blackboard;
		this.InnerTreeIncId = blackboard.TreeIncId;
		this.InnerTreeConfigId = blackboard.TreeConfigId;
		this.BtType = btType;
		this.Context = this.CreateContext(null, this.InnerNodeId);
		if (!this.OnCreate(config))
		{
			return;
		}
		this.UpdateStatus(reason, data.Info.Status);
	}

	// Token: 0x0600E1B4 RID: 57780 RVA: 0x003CC8D8 File Offset: 0x003CAAD8
	public void Destroy()
	{
		this.OnDestroy();
		GeneralLogicTreeContext context = this.Context;
		if (context != null)
		{
			context.Release();
		}
		this.Context = null;
		this.Blackboard = null;
		this.TrackTextConfig = null;
		this.MultiTrackText = null;
	}

	// Token: 0x0600E1B5 RID: 57781 RVA: 0x003CC910 File Offset: 0x003CAB10
	public void UpdateStatus(ENodeStatusUpdateReason reason, NodeStatus status)
	{
		NodeStatus innerStatus = this.InnerStatus;
		this.InnerStatus = status;
		if (innerStatus == this.InnerStatus)
		{
			return;
		}
		switch (this.InnerStatus)
		{
		case NodeStatus.Activated:
			this.OnNodeActive();
			break;
		case NodeStatus.CompletedSuccess:
			this.OnNodeDeActive(true);
			break;
		case NodeStatus.CompletedFailed:
			this.OnNodeDeActive(false);
			break;
		case NodeStatus.Destroy:
			this.OnNodeDeActive(false);
			break;
		}
		if (reason <= ENodeStatusUpdateReason.Recover)
		{
			Singleton<EventSystem>.Instance.Emit<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(EEventName.OnLogicTreeNodeStatusChange, this.Context, innerStatus, this.InnerStatus, reason);
			Singleton<EventSystem>.Instance.EmitWithTarget<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.Blackboard, EEventName.OnLogicTreeNodeStatusChange, this.Context, innerStatus, this.InnerStatus, reason);
		}
	}

	// Token: 0x0600E1B6 RID: 57782 RVA: 0x003CC9C8 File Offset: 0x003CABC8
	[NullableContext(2)]
	public void UpdateProgress(ChildQuestNodeProgress progress)
	{
		if (progress == null)
		{
			return;
		}
		if (!this.OnUpdateProgress(progress))
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<GeneralContext, ChildQuestNodeProgress>(EEventName.OnLogicTreeNodeProgressChange, this.Context, progress);
		Singleton<EventSystem>.Instance.EmitWithTarget<GeneralContext, ChildQuestNodeProgress>(this.Blackboard, EEventName.OnLogicTreeNodeProgressChange, this.Context, progress);
	}

	// Token: 0x0600E1B7 RID: 57783 RVA: 0x003CCA17 File Offset: 0x003CAC17
	protected virtual bool OnUpdateProgress(ChildQuestNodeProgress data)
	{
		return false;
	}

	// Token: 0x0600E1B8 RID: 57784 RVA: 0x003CCA1A File Offset: 0x003CAC1A
	public virtual string GetProgress()
	{
		return "0";
	}

	// Token: 0x0600E1B9 RID: 57785 RVA: 0x003CCA21 File Offset: 0x003CAC21
	public virtual string GetProgressMax()
	{
		return "0";
	}

	// Token: 0x0600E1BA RID: 57786 RVA: 0x003CCA28 File Offset: 0x003CAC28
	[return: Nullable(2)]
	public virtual string GetCustomTrackText(string textTemplate)
	{
		return null;
	}

	// Token: 0x0600E1BB RID: 57787 RVA: 0x003CCA2B File Offset: 0x003CAC2B
	protected GeneralLogicTreeContext CreateContext(GameCtxType? contextType, int nodeId)
	{
		return GeneralLogicTreeContext.Create(this.BtType, this.TreeIncId, this.TreeConfigId, nodeId, contextType);
	}

	// Token: 0x0600E1BC RID: 57788 RVA: 0x003CCA46 File Offset: 0x003CAC46
	protected virtual bool OnCreate(IBtNode config)
	{
		return true;
	}

	// Token: 0x0600E1BD RID: 57789 RVA: 0x003CCA49 File Offset: 0x003CAC49
	protected virtual void OnNodeActive()
	{
	}

	// Token: 0x0600E1BE RID: 57790 RVA: 0x003CCA4B File Offset: 0x003CAC4B
	protected virtual void OnNodeDeActive(bool success)
	{
	}

	// Token: 0x0600E1BF RID: 57791 RVA: 0x003CCA4D File Offset: 0x003CAC4D
	protected virtual void OnDestroy()
	{
		if (this.IsProcessing)
		{
			this.UpdateStatus(ENodeStatusUpdateReason.NodeDestroy, NodeStatus.Destroy);
		}
	}

	// Token: 0x04006C2B RID: 27691
	protected BtType BtType;

	// Token: 0x04006C2C RID: 27692
	[Nullable(2)]
	protected GeneralLogicTreeContext Context;

	// Token: 0x04006C2D RID: 27693
	protected long InnerTreeIncId;

	// Token: 0x04006C2E RID: 27694
	protected int InnerTreeConfigId;

	// Token: 0x04006C2F RID: 27695
	protected int InnerNodeId = nodeId;

	// Token: 0x04006C30 RID: 27696
	protected NodeStatus InnerStatus;

	// Token: 0x04006C31 RID: 27697
	[Nullable(2)]
	protected Blackboard Blackboard;

	// Token: 0x04006C32 RID: 27698
	[Nullable(2)]
	public ITrackTarget TrackTarget;

	// Token: 0x04006C33 RID: 27699
	public bool ShowTipBeforeEnterActions;

	// Token: 0x04006C34 RID: 27700
	[Nullable(2)]
	public string TrackTextConfig;

	// Token: 0x04006C35 RID: 27701
	[Nullable(2)]
	public string MultiTrackText;

	// Token: 0x04006C36 RID: 27702
	public ENavigationStyle NavigationStyle;

	// Token: 0x04006C37 RID: 27703
	protected ENodeTrackTextRule TrackTextRuleInner;
}
