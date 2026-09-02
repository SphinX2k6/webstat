using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;

// Token: 0x02001DFA RID: 7674
[NullableContext(2)]
[Nullable(0)]
public abstract class LogicTreeContainer
{
	// Token: 0x170011B1 RID: 4529
	// (get) Token: 0x0600E28A RID: 57994
	public abstract int Id { get; }

	// Token: 0x170011B2 RID: 4530
	// (get) Token: 0x0600E28B RID: 57995
	public abstract bool IsInteractValid { get; }

	// Token: 0x170011B3 RID: 4531
	// (get) Token: 0x0600E28C RID: 57996
	[Nullable(1)]
	public abstract string Name { [NullableContext(1)] get; }

	// Token: 0x170011B4 RID: 4532
	// (get) Token: 0x0600E28D RID: 57997 RVA: 0x003D078D File Offset: 0x003CE98D
	public BaseBehaviorTree Tree
	{
		get
		{
			if (this.BehaviorTree == null)
			{
				return null;
			}
			return this.BehaviorTree;
		}
	}

	// Token: 0x170011B5 RID: 4533
	// (get) Token: 0x0600E28E RID: 57998 RVA: 0x003D07A0 File Offset: 0x003CE9A0
	public long? TreeId
	{
		get
		{
			BaseBehaviorTree tree = this.Tree;
			if (tree == null)
			{
				return null;
			}
			return new long?(tree.TreeIncId);
		}
	}

	// Token: 0x170011B6 RID: 4534
	// (get) Token: 0x0600E28F RID: 57999 RVA: 0x003D07CC File Offset: 0x003CE9CC
	public int? TreeConfigId
	{
		get
		{
			BaseBehaviorTree tree = this.Tree;
			if (tree == null)
			{
				return null;
			}
			return new int?(tree.TreeConfigId);
		}
	}

	// Token: 0x0600E290 RID: 58000 RVA: 0x003D07F7 File Offset: 0x003CE9F7
	public virtual void Destroy()
	{
		this.TearDownBehaviorTree();
	}

	// Token: 0x170011B7 RID: 4535
	// (get) Token: 0x0600E291 RID: 58001 RVA: 0x003D07FF File Offset: 0x003CE9FF
	public bool IsBelongPlayer
	{
		get
		{
			return this.IsBelongPlayerInternal;
		}
	}

	// Token: 0x0600E292 RID: 58002 RVA: 0x003D0807 File Offset: 0x003CEA07
	[NullableContext(1)]
	public virtual void SetUpBehaviorTree(BaseBehaviorTree behaviorTree)
	{
		this.BehaviorTree = behaviorTree;
		if (behaviorTree != null)
		{
			this.IsBelongPlayerInternal = true;
		}
	}

	// Token: 0x0600E293 RID: 58003 RVA: 0x003D081C File Offset: 0x003CEA1C
	private void TearDownBehaviorTree()
	{
		if (this.BehaviorTree == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<long, int?>(EEventName.TearDownGeneralLogicTree, this.TreeId.Value, this.TreeConfigId);
		this.BehaviorTree = null;
	}

	// Token: 0x0600E294 RID: 58004 RVA: 0x003D085D File Offset: 0x003CEA5D
	public BehaviorNodeBase GetNode(int nodeId)
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return tree.GetNode(nodeId);
	}

	// Token: 0x0600E295 RID: 58005 RVA: 0x003D0871 File Offset: 0x003CEA71
	public BehaviorNodeBase GetCurrentActiveChildQuestNode()
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return tree.GetCurrentActiveChildQuestNode(true);
	}

	// Token: 0x0600E296 RID: 58006 RVA: 0x003D0885 File Offset: 0x003CEA85
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<BehaviorNodeBase> GetCurrentActiveChildQuestNodes()
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return tree.GetCurrentActiveChildQuestNodes();
	}

	// Token: 0x0600E297 RID: 58007 RVA: 0x003D0898 File Offset: 0x003CEA98
	public List<int> GetActiveChildQuestNodesId()
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return tree.GetActiveChildQuestNodesId();
	}

	// Token: 0x0600E298 RID: 58008 RVA: 0x003D08AB File Offset: 0x003CEAAB
	public IReadOnlyList<int> GetCurrentCorrelativeEntities()
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return tree.GetCurrentCorrelativeEntities();
	}

	// Token: 0x0600E299 RID: 58009 RVA: 0x003D08BE File Offset: 0x003CEABE
	public ITrackCustomBoard GetCurrentTrackCustomBoard()
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return tree.GetCurrentNodeCustomTrackBoard();
	}

	// Token: 0x0600E29A RID: 58010 RVA: 0x003D08D1 File Offset: 0x003CEAD1
	public virtual void SetTrack(bool value, ESetTrackReason reason = ESetTrackReason.None)
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return;
		}
		tree.SetTrack(value, reason);
	}

	// Token: 0x0600E29B RID: 58011 RVA: 0x003D08E5 File Offset: 0x003CEAE5
	public Vector GetNodeTrackPosition(int nodeId)
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return tree.GetNodeTrackPosition(nodeId);
	}

	// Token: 0x0600E29C RID: 58012 RVA: 0x003D08FC File Offset: 0x003CEAFC
	public double? GetTrackDistance(int nodeId)
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return new double?(tree.GetTrackDistance(nodeId));
	}

	// Token: 0x0600E29D RID: 58013 RVA: 0x003D0928 File Offset: 0x003CEB28
	public int? GetDefaultMark(int nodeId)
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return tree.GetDefaultMark(nodeId);
	}

	// Token: 0x0600E29E RID: 58014 RVA: 0x003D0950 File Offset: 0x003CEB50
	public double? GetGuideLineHideDistance(int nodeId)
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return new double?(tree.GetGuideLineHideDistance(nodeId));
	}

	// Token: 0x0600E29F RID: 58015 RVA: 0x003D097C File Offset: 0x003CEB7C
	public virtual bool IsInTrackRange()
	{
		return this.Tree.IsInTrackRange();
	}

	// Token: 0x0600E2A0 RID: 58016 RVA: 0x003D0989 File Offset: 0x003CEB89
	public bool IsRangeTrack(int nodeId)
	{
		return this.Tree.IsRangeTrack(nodeId);
	}

	// Token: 0x0600E2A1 RID: 58017 RVA: 0x003D0997 File Offset: 0x003CEB97
	public void CreateMapMarks()
	{
		this.Tree.CreateMapMarks();
	}

	// Token: 0x0600E2A2 RID: 58018 RVA: 0x003D09A4 File Offset: 0x003CEBA4
	public virtual int GetUiPriority()
	{
		return 0;
	}

	// Token: 0x0600E2A3 RID: 58019 RVA: 0x003D09A7 File Offset: 0x003CEBA7
	public virtual bool CanShowInUiPanel()
	{
		BaseBehaviorTree tree = this.Tree;
		return tree != null && tree.CheckCanShow();
	}

	// Token: 0x0600E2A4 RID: 58020 RVA: 0x003D09BA File Offset: 0x003CEBBA
	public bool CanShowTrackExpression()
	{
		BaseBehaviorTree tree = this.Tree;
		return tree != null && tree.CanShowTrackExpression();
	}

	// Token: 0x0600E2A5 RID: 58021 RVA: 0x003D09CD File Offset: 0x003CEBCD
	public void StartTextExpress(ETreeTextExpressReason reason = ETreeTextExpressReason.None)
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return;
		}
		tree.StartTextExpress(reason);
	}

	// Token: 0x0600E2A6 RID: 58022 RVA: 0x003D09E0 File Offset: 0x003CEBE0
	public void EndTextExpress(ETreeTextExpressReason reason = ETreeTextExpressReason.None)
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return;
		}
		tree.EndTextExpress(reason);
	}

	// Token: 0x0600E2A7 RID: 58023 RVA: 0x003D09F3 File Offset: 0x003CEBF3
	public bool IsSuspend()
	{
		BaseBehaviorTree tree = this.Tree;
		return tree != null && tree.IsSuspend();
	}

	// Token: 0x0600E2A8 RID: 58024 RVA: 0x003D0A06 File Offset: 0x003CEC06
	public EBehaviorTreeSuspendType GetSuspendType()
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return EBehaviorTreeSuspendType.None;
		}
		return tree.GetSuspendType();
	}

	// Token: 0x0600E2A9 RID: 58025 RVA: 0x003D0A19 File Offset: 0x003CEC19
	public string GetSuspendText()
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return tree.GetSuspendText();
	}

	// Token: 0x0600E2AA RID: 58026 RVA: 0x003D0A2C File Offset: 0x003CEC2C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IReadOnlyList<IOccupationInfo> GetOccupations()
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return tree.GetOccupations();
	}

	// Token: 0x0600E2AB RID: 58027 RVA: 0x003D0A3F File Offset: 0x003CEC3F
	public bool HasRefOccupiedEntity()
	{
		BaseBehaviorTree tree = this.Tree;
		return tree != null && tree.HasRefOccupiedEntity();
	}

	// Token: 0x0600E2AC RID: 58028 RVA: 0x003D0A52 File Offset: 0x003CEC52
	public string GetRefOccupiedEntityText()
	{
		BaseBehaviorTree tree = this.Tree;
		if (tree == null)
		{
			return null;
		}
		return tree.GetRefOccupiedEntityText();
	}

	// Token: 0x0600E2AD RID: 58029 RVA: 0x003D0A65 File Offset: 0x003CEC65
	public bool HasBehaviorTree()
	{
		return this.BehaviorTree != null;
	}

	// Token: 0x0600E2AE RID: 58030 RVA: 0x003D0A70 File Offset: 0x003CEC70
	public bool CanShowGuideLine()
	{
		List<BehaviorNodeBase> currentActiveChildQuestNodes = this.GetCurrentActiveChildQuestNodes();
		if (currentActiveChildQuestNodes == null)
		{
			return false;
		}
		using (List<BehaviorNodeBase>.Enumerator enumerator = currentActiveChildQuestNodes.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.ContainTag(EBehaviorTreeTag.ShowNavigation))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600E2AF RID: 58031 RVA: 0x003D0AD4 File Offset: 0x003CECD4
	public bool IsAlwaysShowGuideLine()
	{
		List<BehaviorNodeBase> currentActiveChildQuestNodes = this.GetCurrentActiveChildQuestNodes();
		if (currentActiveChildQuestNodes == null)
		{
			return false;
		}
		using (List<BehaviorNodeBase>.Enumerator enumerator = currentActiveChildQuestNodes.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.ContainTag(EBehaviorTreeTag.AlwaysShowNavigation))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600E2B0 RID: 58032 RVA: 0x003D0B38 File Offset: 0x003CED38
	public BehaviorNodeBase GetShowGuideLineNode()
	{
		List<BehaviorNodeBase> currentActiveChildQuestNodes = this.GetCurrentActiveChildQuestNodes();
		if (currentActiveChildQuestNodes == null)
		{
			return null;
		}
		foreach (BehaviorNodeBase behaviorNodeBase in currentActiveChildQuestNodes)
		{
			if (behaviorNodeBase.ContainTag(EBehaviorTreeTag.ShowNavigation))
			{
				return behaviorNodeBase;
			}
		}
		return null;
	}

	// Token: 0x04006CFD RID: 27901
	protected BaseBehaviorTree BehaviorTree;

	// Token: 0x04006CFE RID: 27902
	private bool IsBelongPlayerInternal;
}
