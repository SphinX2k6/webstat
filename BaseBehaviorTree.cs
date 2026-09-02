using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Guarantee;
using CSharpScript.Game.Module.GeneralLogicTree.BaseBehaviorTree;
using CSharpScript.Game.Module.GeneralLogicTree.BaseBehaviorTree.Express;
using CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode;
using CSharpScript.Game.Module.GeneralLogicTree.Define;
using CSharpScript.Game.Module.Sheriff;
using UnrealEngine;

// Token: 0x02001DB9 RID: 7609
[NullableContext(1)]
[Nullable(0)]
public class BaseBehaviorTree
{
	// Token: 0x1700118C RID: 4492
	// (get) Token: 0x0600E08E RID: 57486 RVA: 0x003C5DAF File Offset: 0x003C3FAF
	public BtType BtType
	{
		get
		{
			return this.BlackBoard.BtType;
		}
	}

	// Token: 0x1700118D RID: 4493
	// (get) Token: 0x0600E08F RID: 57487 RVA: 0x003C5DBC File Offset: 0x003C3FBC
	public long TreeIncId
	{
		get
		{
			return this.BlackBoard.TreeIncId;
		}
	}

	// Token: 0x1700118E RID: 4494
	// (get) Token: 0x0600E090 RID: 57488 RVA: 0x003C5DC9 File Offset: 0x003C3FC9
	public int TreeConfigId
	{
		get
		{
			return this.BlackBoard.TreeConfigId;
		}
	}

	// Token: 0x1700118F RID: 4495
	// (get) Token: 0x0600E091 RID: 57489 RVA: 0x003C5DD6 File Offset: 0x003C3FD6
	public int DungeonId
	{
		get
		{
			return this.BlackBoard.DungeonId;
		}
	}

	// Token: 0x17001190 RID: 4496
	// (get) Token: 0x0600E092 RID: 57490 RVA: 0x003C5DE3 File Offset: 0x003C3FE3
	public int FailNodeId
	{
		get
		{
			return this.InnerFailNodeId;
		}
	}

	// Token: 0x0600E093 RID: 57491 RVA: 0x003C5DEB File Offset: 0x003C3FEB
	public void ClearFailNodeId()
	{
		this.InnerFailNodeId = 0;
	}

	// Token: 0x0600E094 RID: 57492 RVA: 0x003C5DF4 File Offset: 0x003C3FF4
	public BaseBehaviorTree(long id, int configId, BtType btType, int dungeonId, int taskMarkTableId, string onlineType, int showPriority, bool? bNewQuest = null, bool? bDisableExpression = null)
	{
		this.BlackBoard.Init(btType, id, configId, dungeonId, taskMarkTableId, onlineType, showPriority, bDisableExpression.GetValueOrDefault());
		if (bNewQuest.GetValueOrDefault())
		{
			this.BlackBoard.AddTag(EBehaviorTreeTag.NewQuest, "");
		}
	}

	// Token: 0x0600E095 RID: 57493 RVA: 0x003C5E60 File Offset: 0x003C4060
	public void InitTree(TreeInfo treeInfo, bool bSleep = false)
	{
		this.InitComponents();
		this.SetSleep(bSleep);
		this.Recover(treeInfo);
		this.OnAddEvent();
	}

	// Token: 0x0600E096 RID: 57494 RVA: 0x003C5E7C File Offset: 0x003C407C
	public void Destroy()
	{
		this.OnRemoveEvent();
		this.BlackBoard.Dispose();
		BehaviorTreeExpressionComponent expression = this.Expression;
		if (expression != null)
		{
			expression.Dispose();
		}
		DynamicFlowInfo flowInfo = this.FlowInfo;
		if (flowInfo != null)
		{
			flowInfo.Dispose();
		}
		BehaviorTreeTimerCenter timerCenter = this.TimerCenter;
		if (timerCenter != null)
		{
			timerCenter.Dispose();
		}
		BindingExpressionComponentHolder bindingExpressionHolder = this.BindingExpressionHolder;
		if (bindingExpressionHolder == null)
		{
			return;
		}
		bindingExpressionHolder.Destroy();
	}

	// Token: 0x0600E097 RID: 57495 RVA: 0x003C5EE0 File Offset: 0x003C40E0
	[return: Nullable(2)]
	protected BehaviorNodeBase CreateNode(ENodeStatusUpdateReason reason, global::NodeInfo data)
	{
		if (this.BlackBoard.IsSleeping)
		{
			BtPendingCreateNode data2 = new BtPendingCreateNode
			{
				Reason = reason,
				NodeInfo = data
			};
			this.AddToPendingProcessList(data2);
			return null;
		}
		if (data == null)
		{
			return null;
		}
		IBtNode nodeConfig = this.BlackBoard.GetNodeConfig(data.NodeId);
		if (nodeConfig == null)
		{
			return null;
		}
		BehaviorNodeBase behaviorNodeBase = NodeTypeDefine.NewNodeObj(nodeConfig);
		if (behaviorNodeBase == null)
		{
			return null;
		}
		this.BlackBoard.AddNode(data.NodeId, behaviorNodeBase);
		this.BlackBoard.AddNodeToStatusGroup(behaviorNodeBase, data.Info.Status);
		behaviorNodeBase.Init(this.BlackBoard, reason, data, nodeConfig, this.BtType);
		return behaviorNodeBase;
	}

	// Token: 0x0600E098 RID: 57496 RVA: 0x003C5F7E File Offset: 0x003C417E
	private void AddToPendingProcessList(BehaviorTreePendingProcess data)
	{
		this.PendingProcess.Push(data);
	}

	// Token: 0x0600E099 RID: 57497 RVA: 0x003C5F8C File Offset: 0x003C418C
	private void InitComponents()
	{
		this.FlowInfo = new DynamicFlowInfo();
		this.TimerCenter = new BehaviorTreeTimerCenter(this.TreeIncId, this.BlackBoard);
		this.Suspend = new BehaviorTreeSuspendComponent(this.TreeIncId, this.BlackBoard);
		if (!this.BlackBoard.NoExpression)
		{
			this.Expression = new BehaviorTreeExpressionComponent(this.BlackBoard);
			this.Expression.Init();
			this.BindingExpressionHolder = new BindingExpressionComponentHolder(this.BlackBoard);
			this.BindingExpressionHolder.Init();
		}
	}

	// Token: 0x0600E09A RID: 57498 RVA: 0x003C6018 File Offset: 0x003C4218
	[NullableContext(2)]
	public void Recover(TreeInfo treeInfo)
	{
		if (treeInfo == null)
		{
			return;
		}
		this.RecoverNodes(treeInfo.Nodes);
		this.RecoverTimers(treeInfo.TimerInfos);
		this.RecoverVars(treeInfo.Vars);
		this.UpdateOccupations(treeInfo.SuspendNodeId, treeInfo.SuspendType, treeInfo.OccupationInfo);
		ControllerBase<PerformController>.Instance.RecoverTreeInfo(treeInfo.CharacterLookAtInfos);
	}

	// Token: 0x0600E09B RID: 57499 RVA: 0x003C6078 File Offset: 0x003C4278
	private void RecoverNodes(IDictionary<int, Aki.Protocol.NodeInfo> nodes)
	{
		foreach (int num in nodes.Keys)
		{
			global::NodeInfo nodeInfo = new global::NodeInfo
			{
				Info = nodes[num],
				NodeId = num
			};
			if (this.GetNode(nodeInfo.NodeId) != null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "创建节点时：节点已存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("节点Id", nodeInfo.NodeId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				this.CreateNode(ENodeStatusUpdateReason.Recover, nodeInfo);
			}
		}
	}

	// Token: 0x0600E09C RID: 57500 RVA: 0x003C6124 File Offset: 0x003C4324
	private void RecoverTimers(IList<TimerInfoPb> timerInfos)
	{
		foreach (TimerInfoPb timerInfo in timerInfos)
		{
			this.UpdateTimer(timerInfo);
		}
	}

	// Token: 0x0600E09D RID: 57501 RVA: 0x003C616C File Offset: 0x003C436C
	private void RecoverVars(IDictionary<string, VarDefinePb> vars)
	{
		foreach (string text in vars.Keys)
		{
			VarDefinePb varDefine = vars[text];
			this.BlackBoard.UpdateTreeVar(text, varDefine);
		}
	}

	// Token: 0x0600E09E RID: 57502 RVA: 0x003C61C8 File Offset: 0x003C43C8
	private void OnAddEvent()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(this.BlackBoard, EEventName.GeneralLogicTreeRollbackWaitingUpdate, new Action(this.OnGeneralLogicTreeRollbackWaitingUpdate));
	}

	// Token: 0x0600E09F RID: 57503 RVA: 0x003C61EC File Offset: 0x003C43EC
	private void OnRemoveEvent()
	{
		if (Singleton<EventSystem>.Instance.Has<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange)))
		{
			Singleton<EventSystem>.Instance.Remove<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget(this.BlackBoard, EEventName.GeneralLogicTreeRollbackWaitingUpdate, new Action(this.OnGeneralLogicTreeRollbackWaitingUpdate)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.BlackBoard, EEventName.GeneralLogicTreeRollbackWaitingUpdate, new Action(this.OnGeneralLogicTreeRollbackWaitingUpdate));
		}
	}

	// Token: 0x0600E0A0 RID: 57504 RVA: 0x003C6278 File Offset: 0x003C4478
	public void SetSleep(bool value)
	{
		this.BlackBoard.IsSleeping = value;
		if (value)
		{
			return;
		}
		if (this.PendingProcess.Size == 0)
		{
			return;
		}
		for (BehaviorTreePendingProcess behaviorTreePendingProcess = this.PendingProcess.Pop(); behaviorTreePendingProcess != null; behaviorTreePendingProcess = ((this.PendingProcess.Size > 0) ? this.PendingProcess.Pop() : null))
		{
			BtPendingCreateNode btPendingCreateNode = behaviorTreePendingProcess as BtPendingCreateNode;
			if (btPendingCreateNode == null)
			{
				BtPendingUpdateNodeStatus btPendingUpdateNodeStatus = behaviorTreePendingProcess as BtPendingUpdateNodeStatus;
				if (btPendingUpdateNodeStatus == null)
				{
					BtPendingUpdateNodeProgress btPendingUpdateNodeProgress = behaviorTreePendingProcess as BtPendingUpdateNodeProgress;
					if (btPendingUpdateNodeProgress == null)
					{
						BtPendingUpdateChildQuestNodeStatus btPendingUpdateChildQuestNodeStatus = behaviorTreePendingProcess as BtPendingUpdateChildQuestNodeStatus;
						if (btPendingUpdateChildQuestNodeStatus == null)
						{
							BtPendingUpdateSetTrack btPendingUpdateSetTrack = behaviorTreePendingProcess as BtPendingUpdateSetTrack;
							if (btPendingUpdateSetTrack == null)
							{
								BtPendingDoAction btPendingDoAction = behaviorTreePendingProcess as BtPendingDoAction;
								if (btPendingDoAction == null)
								{
									BtPendingUpdateUpdateTimer btPendingUpdateUpdateTimer = behaviorTreePendingProcess as BtPendingUpdateUpdateTimer;
									if (btPendingUpdateUpdateTimer == null)
									{
										BtPendingUpdateOccupations btPendingUpdateOccupations = behaviorTreePendingProcess as BtPendingUpdateOccupations;
										if (btPendingUpdateOccupations == null)
										{
											BtPendingUpdateTreeVars btPendingUpdateTreeVars = behaviorTreePendingProcess as BtPendingUpdateTreeVars;
											if (btPendingUpdateTreeVars != null)
											{
												this.UpdateTreeVars(btPendingUpdateTreeVars.Notify);
											}
										}
										else
										{
											this.UpdateOccupations(btPendingUpdateOccupations.SuspendNodeId, btPendingUpdateOccupations.SuspendType, btPendingUpdateOccupations.OccupationInfo);
										}
									}
									else
									{
										this.UpdateTimer(btPendingUpdateUpdateTimer.TimerInfo);
									}
								}
								else
								{
									this.DoAction(btPendingDoAction.Context, btPendingDoAction.NodeId, btPendingDoAction.PlayerId, btPendingDoAction.SessionId, btPendingDoAction.StartIndex, btPendingDoAction.EndIndex, btPendingDoAction.NeedFinishReq);
								}
							}
							else
							{
								this.SetTrack(btPendingUpdateSetTrack.Value, ESetTrackReason.None);
							}
						}
						else
						{
							this.UpdateChildQuestNodeState(btPendingUpdateChildQuestNodeStatus.NodeId, btPendingUpdateChildQuestNodeStatus.NodeStatus, btPendingUpdateChildQuestNodeStatus.Reason);
						}
					}
					else
					{
						this.UpdateNodeProgress(btPendingUpdateNodeProgress.NodeId, btPendingUpdateNodeProgress.NodeInfo);
					}
				}
				else
				{
					this.UpdateNodeState(btPendingUpdateNodeStatus.Reason, btPendingUpdateNodeStatus.NodeId, btPendingUpdateNodeStatus.NodeStatus);
				}
			}
			else
			{
				this.CreateNode(btPendingCreateNode.Reason, btPendingCreateNode.NodeInfo);
			}
		}
	}

	// Token: 0x0600E0A1 RID: 57505 RVA: 0x003C6448 File Offset: 0x003C4648
	public void UpdateNodeState(ENodeStatusUpdateReason reason, int nodeId, NodeStatus nodeStatus)
	{
		if (this.BlackBoard.IsSleeping)
		{
			BtPendingUpdateNodeStatus data = new BtPendingUpdateNodeStatus
			{
				Reason = reason,
				NodeId = nodeId,
				NodeStatus = nodeStatus
			};
			this.AddToPendingProcessList(data);
			return;
		}
		BehaviorNodeBase node = this.GetNode(nodeId);
		if (node != null)
		{
			this.BlackBoard.UpdateNodeInStatusGroup(node, node.Status, nodeStatus);
			node.UpdateStatus(reason, nodeStatus);
			return;
		}
		global::NodeInfo data2 = new global::NodeInfo
		{
			NodeId = nodeId,
			Info = new Aki.Protocol.NodeInfo
			{
				Status = nodeStatus
			}
		};
		this.CreateNode(reason, data2);
	}

	// Token: 0x0600E0A2 RID: 57506 RVA: 0x003C64D4 File Offset: 0x003C46D4
	[NullableContext(2)]
	public void UpdateNodeProgress(int nodeId, ChildQuestNodeProgress data)
	{
		if (this.BlackBoard.IsSleeping)
		{
			BtPendingUpdateNodeProgress data2 = new BtPendingUpdateNodeProgress
			{
				NodeId = nodeId,
				NodeInfo = data
			};
			this.AddToPendingProcessList(data2);
			return;
		}
		if (data == null)
		{
			return;
		}
		BehaviorNodeBase node = this.GetNode(nodeId);
		if (node == null)
		{
			return;
		}
		node.UpdateProgress(data);
	}

	// Token: 0x0600E0A3 RID: 57507 RVA: 0x003C6524 File Offset: 0x003C4724
	public void UpdateChildQuestNodeState(int nodeId, ChildQuestNodeStatus nodeStatus, ENodeStatusUpdateReason reason)
	{
		if (this.BlackBoard.IsSleeping)
		{
			BtPendingUpdateChildQuestNodeStatus data = new BtPendingUpdateChildQuestNodeStatus
			{
				NodeId = nodeId,
				NodeStatus = nodeStatus,
				Reason = reason
			};
			this.AddToPendingProcessList(data);
			return;
		}
		ChildQuestNodeBase childQuestNodeBase = this.GetNode(nodeId) as ChildQuestNodeBase;
		if (childQuestNodeBase == null)
		{
			return;
		}
		childQuestNodeBase.UpdateChildQuestStatus(nodeStatus, reason);
	}

	// Token: 0x0600E0A4 RID: 57508 RVA: 0x003C657A File Offset: 0x003C477A
	[NullableContext(2)]
	public BehaviorNodeBase GetNode(int nodeId)
	{
		return this.BlackBoard.GetNode(new int?(nodeId));
	}

	// Token: 0x0600E0A5 RID: 57509 RVA: 0x003C658D File Offset: 0x003C478D
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, BehaviorNodeBase> GetNodesByGroupId(ENodeGroup group)
	{
		return this.BlackBoard.GetNodesByGroupId(group);
	}

	// Token: 0x0600E0A6 RID: 57510 RVA: 0x003C659B File Offset: 0x003C479B
	[return: Nullable(2)]
	public VarDefinePb GetTreeVarByKey(string key)
	{
		return this.BlackBoard.GetTreeVar(key);
	}

	// Token: 0x0600E0A7 RID: 57511 RVA: 0x003C65A9 File Offset: 0x003C47A9
	public void AddTreeVarUpdateDelegate(string key, TTreeVarUpdateDelegate delegat)
	{
		this.BlackBoard.AddTreeVarUpdateDelegate(key, delegat);
	}

	// Token: 0x0600E0A8 RID: 57512 RVA: 0x003C65B8 File Offset: 0x003C47B8
	public void RemoveTreeVarUpdateDelegate(string key, TTreeVarUpdateDelegate @delegate)
	{
		this.BlackBoard.RemoveTreeVarUpdateDelegate(key, @delegate);
	}

	// Token: 0x0600E0A9 RID: 57513 RVA: 0x003C65C8 File Offset: 0x003C47C8
	public bool CheckCanGiveUp()
	{
		if (!ModelBase<CreatureModel>.Instance.IsMyWorld())
		{
			return false;
		}
		QuestFailedBehaviorNode processingCanGiveupFailedNode = this.GetProcessingCanGiveupFailedNode();
		if (processingCanGiveupFailedNode == null)
		{
			return false;
		}
		if (!processingCanGiveupFailedNode.CanGiveUp.GetValueOrDefault())
		{
			return false;
		}
		Dictionary<int, BehaviorNodeBase> nodesByGroupId = this.GetNodesByGroupId(ENodeGroup.IsProcessing);
		if (nodesByGroupId == null)
		{
			return false;
		}
		bool result = true;
		foreach (BehaviorNodeBase behaviorNodeBase in nodesByGroupId.Values)
		{
			if (behaviorNodeBase.NodeType == EBtNode.ChildQuest && behaviorNodeBase is ChildQuestNodeBase && !((ChildQuestNodeBase)behaviorNodeBase).CanGiveUp)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600E0AA RID: 57514 RVA: 0x003C6674 File Offset: 0x003C4874
	[NullableContext(2)]
	public QuestFailedBehaviorNode GetProcessingCanGiveupFailedNode()
	{
		Dictionary<int, BehaviorNodeBase> nodesByGroupId = this.GetNodesByGroupId(ENodeGroup.IsProcessing);
		if (nodesByGroupId == null)
		{
			return null;
		}
		QuestFailedBehaviorNode result = null;
		foreach (BehaviorNodeBase behaviorNodeBase in nodesByGroupId.Values)
		{
			QuestFailedBehaviorNode questFailedBehaviorNode = behaviorNodeBase as QuestFailedBehaviorNode;
			if (questFailedBehaviorNode != null && questFailedBehaviorNode.CanGiveUp.GetValueOrDefault())
			{
				result = questFailedBehaviorNode;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600E0AB RID: 57515 RVA: 0x003C66EC File Offset: 0x003C48EC
	[NullableContext(2)]
	public QuestFailedBehaviorNode GetProcessingFailedNode()
	{
		Dictionary<int, BehaviorNodeBase> nodesByGroupId = this.GetNodesByGroupId(ENodeGroup.IsProcessing);
		if (nodesByGroupId == null)
		{
			return null;
		}
		QuestFailedBehaviorNode result = null;
		foreach (BehaviorNodeBase behaviorNodeBase in nodesByGroupId.Values)
		{
			if (behaviorNodeBase.NodeType == EBtNode.QuestFailed)
			{
				result = (behaviorNodeBase as QuestFailedBehaviorNode);
				break;
			}
		}
		return result;
	}

	// Token: 0x0600E0AC RID: 57516 RVA: 0x003C675C File Offset: 0x003C495C
	[NullableContext(2)]
	public BehaviorNodeBase GetCurrentActiveChildQuestNode(bool bIgnoreNoTrackExpression = true)
	{
		return this.BlackBoard.GetCurrentActiveChildQuestNode(bIgnoreNoTrackExpression);
	}

	// Token: 0x0600E0AD RID: 57517 RVA: 0x003C676A File Offset: 0x003C496A
	[NullableContext(2)]
	public List<int> GetActiveChildQuestNodesId()
	{
		return this.BlackBoard.GetActiveChildQuestNodesId();
	}

	// Token: 0x0600E0AE RID: 57518 RVA: 0x003C6777 File Offset: 0x003C4977
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<BehaviorNodeBase> GetCurrentActiveChildQuestNodes()
	{
		return this.BlackBoard.GetActiveChildQuestNodes();
	}

	// Token: 0x0600E0AF RID: 57519 RVA: 0x003C6784 File Offset: 0x003C4984
	public List<BehaviorNodeBase> GetCurrentActiveLogicNodes()
	{
		Dictionary<int, BehaviorNodeBase> nodesByGroupId = this.BlackBoard.GetNodesByGroupId(ENodeGroup.IsProcessing);
		if (nodesByGroupId == null)
		{
			return new List<BehaviorNodeBase>();
		}
		List<BehaviorNodeBase> list = new List<BehaviorNodeBase>();
		foreach (BehaviorNodeBase behaviorNodeBase in nodesByGroupId.Values)
		{
			if (behaviorNodeBase.NodeType == EBtNode.ConditionSelector || behaviorNodeBase.NodeType == EBtNode.ParallelSelect || behaviorNodeBase.NodeType == EBtNode.Select || behaviorNodeBase.NodeType == EBtNode.Sequence)
			{
				list.Add(behaviorNodeBase);
			}
		}
		return list;
	}

	// Token: 0x0600E0B0 RID: 57520 RVA: 0x003C681C File Offset: 0x003C4A1C
	[NullableContext(2)]
	public IReadOnlyList<int> GetCurrentCorrelativeEntities()
	{
		Dictionary<int, BehaviorNodeBase> nodesByGroupId = this.GetNodesByGroupId(ENodeGroup.IsProcessing);
		if (nodesByGroupId == null)
		{
			return null;
		}
		this.CurrentCorrelativeEntities.Clear();
		foreach (BehaviorNodeBase behaviorNodeBase in nodesByGroupId.Values)
		{
			if (behaviorNodeBase.NodeType == EBtNode.ChildQuest)
			{
				ChildQuestNodeBase childQuestNodeBase = behaviorNodeBase as ChildQuestNodeBase;
				if (childQuestNodeBase != null)
				{
					List<int> correlativeEntities = childQuestNodeBase.GetCorrelativeEntities();
					if (correlativeEntities != null)
					{
						this.CurrentCorrelativeEntities.AddRange(correlativeEntities);
					}
				}
			}
		}
		return this.CurrentCorrelativeEntities;
	}

	// Token: 0x0600E0B1 RID: 57521 RVA: 0x003C68B4 File Offset: 0x003C4AB4
	public bool ContainTag(EBehaviorTreeTag tag)
	{
		return this.BlackBoard.ContainTag(tag);
	}

	// Token: 0x0600E0B2 RID: 57522 RVA: 0x003C68C2 File Offset: 0x003C4AC2
	public Blackboard GetBlackBoard()
	{
		return this.BlackBoard;
	}

	// Token: 0x0600E0B3 RID: 57523 RVA: 0x003C68CA File Offset: 0x003C4ACA
	public void AddDynamicFlowNpc(int npcPbDataId)
	{
		this.FlowInfo.AddDynamicFlowNpc(npcPbDataId);
	}

	// Token: 0x0600E0B4 RID: 57524 RVA: 0x003C68D8 File Offset: 0x003C4AD8
	public void PrepareRollback(FailReason? reason = null, int? failNodeId = null)
	{
		this.SetRollbackWaiting(true);
		this.InnerFailNodeId = failNodeId.GetValueOrDefault();
		foreach (int sessionId in this.BlackBoard.GetCurrentExecuteActions())
		{
			ControllerBase<LevelGeneralController>.Instance.StopActionsExecute(sessionId);
		}
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		ETeamLivingState groupLivingState = ModelBase<SceneTeamModel>.Instance.GetGroupLivingState(playerId, ETeamGroupType.Battle);
		if (reason.GetValueOrDefault() == FailReason.CharacterDieFail && groupLivingState == ETeamLivingState.Dead)
		{
			Singleton<EventSystem>.Instance.Add<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange));
			return;
		}
		this.TryRollback(reason);
	}

	// Token: 0x0600E0B5 RID: 57525 RVA: 0x003C698C File Offset: 0x003C4B8C
	public void StopCurrentActions()
	{
		foreach (int sessionId in this.BlackBoard.GetCurrentExecuteActions())
		{
			ControllerBase<LevelGeneralController>.Instance.StopActionsExecute(sessionId);
		}
	}

	// Token: 0x0600E0B6 RID: 57526 RVA: 0x003C69E4 File Offset: 0x003C4BE4
	public unsafe void ExecuteTreeGuaranteeActions(ETreeRemoveReason removeReason = ETreeRemoveReason.TreeDestroy)
	{
		List<GuaranteeActionInfo> guaranteeActions = this.BlackBoard.GetGuaranteeActions();
		if (guaranteeActions.Count == 0)
		{
			return;
		}
		List<GuaranteeActionInfo> list = new List<GuaranteeActionInfo>(guaranteeActions);
		list.Reverse();
		GuaranteeContext context = (removeReason == ETreeRemoveReason.TreeRollback) ? GuaranteeContext.Create(null, EGuaranteeReason.TreeRollback) : GuaranteeContext.Create(null, EGuaranteeReason.TreeDestroy);
		ControllerBase<GuaranteeController>.Instance.ExecuteActions(list, context);
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.LevelEvent;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "树保底行为已全部完成";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("treeIncId", this.BlackBoard.TreeConfigId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("保底行为列表", list);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x0600E0B7 RID: 57527 RVA: 0x003C6AA8 File Offset: 0x003C4CA8
	private void OnTeamLivingStateChange(bool isMyTeam, ETeamGroupType groupType, ETeamLivingState state, ETeamLivingState oldState)
	{
		if (isMyTeam && groupType == ETeamGroupType.Battle && state == ETeamLivingState.Alive)
		{
			Singleton<EventSystem>.Instance.Remove<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange));
			this.TryRollback(new FailReason?(FailReason.CharacterDieFail));
		}
	}

	// Token: 0x0600E0B8 RID: 57528 RVA: 0x003C6AE0 File Offset: 0x003C4CE0
	private void OnGeneralLogicTreeRollbackWaitingUpdate()
	{
		this.TryRollback(null);
	}

	// Token: 0x0600E0B9 RID: 57529 RVA: 0x003C6AFC File Offset: 0x003C4CFC
	private void TryRollback(FailReason? reason = null)
	{
		if (this.BlackBoard.ContainTag(EBehaviorTreeTag.RollbackWaiting))
		{
			ControllerBase<GeneralLogicTreeController>.Instance.RequestRollback(this.TreeIncId, reason);
		}
	}

	// Token: 0x0600E0BA RID: 57530 RVA: 0x003C6B20 File Offset: 0x003C4D20
	public void SetRollbackWaiting(bool value)
	{
		if (value && !this.BlackBoard.ContainTag(EBehaviorTreeTag.RollbackWaiting))
		{
			this.BlackBoard.AddTag(EBehaviorTreeTag.RollbackWaiting, "");
			return;
		}
		if (!value && this.BlackBoard.ContainTag(EBehaviorTreeTag.RollbackWaiting))
		{
			this.BlackBoard.RemoveTag(EBehaviorTreeTag.RollbackWaiting, "");
		}
	}

	// Token: 0x0600E0BB RID: 57531 RVA: 0x003C6B72 File Offset: 0x003C4D72
	public bool IsTracking()
	{
		return this.BlackBoard.IsTracking;
	}

	// Token: 0x0600E0BC RID: 57532 RVA: 0x003C6B80 File Offset: 0x003C4D80
	public unsafe void SetTrack(bool value, ESetTrackReason reason = ESetTrackReason.None)
	{
		if (value && this.BlackBoard.IsSuspend())
		{
			return;
		}
		if (this.BlackBoard.NoExpression)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.GeneralLogicTree;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "没有表现的行为树设置了追踪";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("btType", this.BtType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("treeConfigId", this.TreeConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("treeIncId", this.TreeIncId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		if (this.BlackBoard.IsSleeping)
		{
			BtPendingUpdateSetTrack data = new BtPendingUpdateSetTrack
			{
				Value = value
			};
			this.AddToPendingProcessList(data);
			return;
		}
		if (this.BlackBoard.IsTracking == value)
		{
			return;
		}
		this.BlackBoard.IsTracking = value;
		BindingExpressionComponentHolder bindingExpressionHolder = this.BindingExpressionHolder;
		if ((bindingExpressionHolder != null && bindingExpressionHolder.IsValid()) || !value)
		{
			BindingExpressionComponentHolder bindingExpressionHolder2 = this.BindingExpressionHolder;
			if (bindingExpressionHolder2 != null)
			{
				bindingExpressionHolder2.EnableTrack(value, reason, BindingExpressionComponentHolder.EUpdateTrackType.Text | BindingExpressionComponentHolder.EUpdateTrackType.TrackMark);
			}
		}
		BindingExpressionComponentHolder bindingExpressionHolder3 = this.BindingExpressionHolder;
		if (bindingExpressionHolder3 == null || !bindingExpressionHolder3.IsValid() || !value)
		{
			this.Expression.UpdateLevelPlayConditionalMarks();
			this.Expression.EnableTrack(value, reason, false);
		}
		Singleton<EventSystem>.Instance.Emit<BtType, long?>(EEventName.OnLogicTreeTrackUpdate, this.BtType, new long?(this.TreeIncId));
	}

	// Token: 0x0600E0BD RID: 57533 RVA: 0x003C6CF7 File Offset: 0x003C4EF7
	public void SetMapMarkResident(bool bResident)
	{
		this.BlackBoard.SetMapMarkResident(bResident);
	}

	// Token: 0x0600E0BE RID: 57534 RVA: 0x003C6D05 File Offset: 0x003C4F05
	public bool GetMapMarkResident()
	{
		return this.BlackBoard.GetMapMarkResident();
	}

	// Token: 0x0600E0BF RID: 57535 RVA: 0x003C6D12 File Offset: 0x003C4F12
	public void SetUseInnerTrackIconId(bool bUseInner)
	{
		this.BlackBoard.SetUseInnerTrackIconId(bUseInner);
	}

	// Token: 0x0600E0C0 RID: 57536 RVA: 0x003C6D20 File Offset: 0x003C4F20
	public void StartTextExpress(ETreeTextExpressReason reason = ETreeTextExpressReason.None)
	{
		BehaviorTreeExpressionComponent expression = this.Expression;
		if (expression == null)
		{
			return;
		}
		expression.StartTextExpress(reason);
	}

	// Token: 0x0600E0C1 RID: 57537 RVA: 0x003C6D33 File Offset: 0x003C4F33
	public void EndTextExpress(ETreeTextExpressReason reason = ETreeTextExpressReason.None)
	{
		BehaviorTreeExpressionComponent expression = this.Expression;
		if (expression == null)
		{
			return;
		}
		expression.EndTextExpress(reason);
	}

	// Token: 0x0600E0C2 RID: 57538 RVA: 0x003C6D46 File Offset: 0x003C4F46
	[NullableContext(2)]
	public SilentAreaShowInfo GetSilentAreaShowInfo()
	{
		return this.BlackBoard.GetSilentAreaShowInfo();
	}

	// Token: 0x0600E0C3 RID: 57539 RVA: 0x003C6D53 File Offset: 0x003C4F53
	[NullableContext(2)]
	public ModifyTrackAreaConfig GetModifyTrackAreaConfig()
	{
		return this.BlackBoard.GetModifyTrackAreaConfig();
	}

	// Token: 0x0600E0C4 RID: 57540 RVA: 0x003C6D60 File Offset: 0x003C4F60
	public int GetTrackIconId()
	{
		return this.BlackBoard.TaskMarkTableId;
	}

	// Token: 0x0600E0C5 RID: 57541 RVA: 0x003C6D6D File Offset: 0x003C4F6D
	public bool CheckCanShow()
	{
		BehaviorTreeExpressionComponent expression = this.Expression;
		return expression != null && expression.CheckCanShow(null);
	}

	// Token: 0x0600E0C6 RID: 57542 RVA: 0x003C6D81 File Offset: 0x003C4F81
	public bool CanShowTrackExpression()
	{
		BehaviorTreeExpressionComponent expression = this.Expression;
		return expression != null && expression.CheckCanShowTrackExpression();
	}

	// Token: 0x0600E0C7 RID: 57543 RVA: 0x003C6D94 File Offset: 0x003C4F94
	[NullableContext(2)]
	public global::Vector GetNodeTrackPosition(int nodeId)
	{
		BindingExpressionComponentHolder bindingExpressionHolder = this.BindingExpressionHolder;
		if (bindingExpressionHolder != null && bindingExpressionHolder.IsValid())
		{
			return this.BindingExpressionHolder.GetNodeTrackPosition();
		}
		BehaviorTreeExpressionComponent expression = this.Expression;
		if (expression == null)
		{
			return null;
		}
		return expression.GetNodeTrackPosition(nodeId);
	}

	// Token: 0x0600E0C8 RID: 57544 RVA: 0x003C6DC8 File Offset: 0x003C4FC8
	public int GetClosestMapMarkId()
	{
		BehaviorTreeExpressionComponent expression = this.Expression;
		if (expression == null)
		{
			return 0;
		}
		return expression.GetClosestMapMarkId();
	}

	// Token: 0x0600E0C9 RID: 57545 RVA: 0x003C6DDC File Offset: 0x003C4FDC
	public int? GetTrackAreaInfo(int nodeId)
	{
		BehaviorTreeExpressionComponent expression = this.Expression;
		if (expression == null)
		{
			return null;
		}
		return expression.GetTrackAreaInfo(nodeId);
	}

	// Token: 0x0600E0CA RID: 57546 RVA: 0x003C6E03 File Offset: 0x003C5003
	public double GetTrackDistance(int nodeId)
	{
		BindingExpressionComponentHolder bindingExpressionHolder = this.BindingExpressionHolder;
		if (bindingExpressionHolder != null && bindingExpressionHolder.IsValid())
		{
			return this.BindingExpressionHolder.GetTrackDistance();
		}
		BehaviorTreeExpressionComponent expression = this.Expression;
		if (expression == null)
		{
			return 0.0;
		}
		return expression.GetTrackDistance(nodeId);
	}

	// Token: 0x0600E0CB RID: 57547 RVA: 0x003C6E40 File Offset: 0x003C5040
	public int? GetDefaultMark(int nodeId)
	{
		BindingExpressionComponentHolder bindingExpressionHolder = this.BindingExpressionHolder;
		if (bindingExpressionHolder != null && bindingExpressionHolder.IsValid())
		{
			return new int?(this.BindingExpressionHolder.GetDefaultMark());
		}
		BehaviorTreeExpressionComponent expression = this.Expression;
		if (expression == null)
		{
			return null;
		}
		return expression.GetDefaultMark(nodeId);
	}

	// Token: 0x0600E0CC RID: 57548 RVA: 0x003C6E8C File Offset: 0x003C508C
	public bool IsInTrackRange()
	{
		return this.BlackBoard.ContainTag(EBehaviorTreeTag.InTrackRange);
	}

	// Token: 0x0600E0CD RID: 57549 RVA: 0x003C6E9B File Offset: 0x003C509B
	public bool IsRangeTrack(int nodeId)
	{
		return this.GetRangeMarkSize(nodeId) != 0.0;
	}

	// Token: 0x0600E0CE RID: 57550 RVA: 0x003C6EB2 File Offset: 0x003C50B2
	public double GetRangeMarkSize(int nodeId)
	{
		BindingExpressionComponentHolder bindingExpressionHolder = this.BindingExpressionHolder;
		if (bindingExpressionHolder != null && bindingExpressionHolder.IsValid())
		{
			return this.BindingExpressionHolder.GetRangeMarkSize();
		}
		BehaviorTreeExpressionComponent expression = this.Expression;
		if (expression == null)
		{
			return 0.0;
		}
		return expression.GetRangeMarkSize(nodeId);
	}

	// Token: 0x0600E0CF RID: 57551 RVA: 0x003C6EF0 File Offset: 0x003C50F0
	public double GetRangeMarkShowDis(int nodeId)
	{
		BindingExpressionComponentHolder bindingExpressionHolder = this.BindingExpressionHolder;
		if (bindingExpressionHolder != null && bindingExpressionHolder.IsValid())
		{
			return this.BindingExpressionHolder.GetRangeMarkShowDis();
		}
		BehaviorTreeExpressionComponent expression = this.Expression;
		return ((expression != null) ? expression.GetRangeMarkShowDis(nodeId) : null).GetValueOrDefault();
	}

	// Token: 0x0600E0D0 RID: 57552 RVA: 0x003C6F40 File Offset: 0x003C5140
	public double GetGuideLineHideDistance(int nodeId)
	{
		if (!this.IsInTrackRange())
		{
			return 0.0;
		}
		return this.GetRangeMarkSize(nodeId);
	}

	// Token: 0x0600E0D1 RID: 57553 RVA: 0x003C6F5C File Offset: 0x003C515C
	public EActiveNodeShortcutShow GetCurrentNodeShortcutShow()
	{
		if (this.BlackBoard.ContainTag(EBehaviorTreeTag.CanCommunicateAgain))
		{
			return EActiveNodeShortcutShow.Communicate;
		}
		if (this.BlackBoard.ContainTag(EBehaviorTreeTag.CanChallengeAgain))
		{
			return EActiveNodeShortcutShow.ChallengeAgain;
		}
		if (this.CheckCanGiveUp())
		{
			return EActiveNodeShortcutShow.GiveUp;
		}
		ITrackCustomBoard currentNodeCustomTrackBoard = this.GetCurrentNodeCustomTrackBoard();
		if (((currentNodeCustomTrackBoard != null) ? currentNodeCustomTrackBoard.TrackPhoneMessageBoard : null) != null)
		{
			return EActiveNodeShortcutShow.PhoneMessage;
		}
		if (FastReturnUtil.Resolve(this) != null)
		{
			return EActiveNodeShortcutShow.FastReturn;
		}
		if (((currentNodeCustomTrackBoard != null) ? currentNodeCustomTrackBoard.TrackQuestBranchBoard : null) != null)
		{
			return EActiveNodeShortcutShow.QuestMultiLineView;
		}
		if (((currentNodeCustomTrackBoard != null) ? currentNodeCustomTrackBoard.SheriffAnomalyProgressBoard : null) != null)
		{
			return EActiveNodeShortcutShow.SheriffAnomalyProgress;
		}
		if (((currentNodeCustomTrackBoard != null) ? currentNodeCustomTrackBoard.SheriffReasoningBoard : null) != null)
		{
			return EActiveNodeShortcutShow.SheriffReasoningBoard;
		}
		if (ModelBase<SheriffModel>.Instance.IsShortcutShowMainBoard(this))
		{
			return EActiveNodeShortcutShow.SheriffMainBoard;
		}
		if (((currentNodeCustomTrackBoard != null) ? currentNodeCustomTrackBoard.SheriffClueDetailBoard : null) != null)
		{
			return EActiveNodeShortcutShow.SheriffClueDetail;
		}
		return EActiveNodeShortcutShow.None;
	}

	// Token: 0x0600E0D2 RID: 57554 RVA: 0x003C7008 File Offset: 0x003C5208
	public string GetGiveUpText()
	{
		QuestFailedBehaviorNode processingCanGiveupFailedNode = this.GetProcessingCanGiveupFailedNode();
		if (processingCanGiveupFailedNode == null || string.IsNullOrEmpty(processingCanGiveupFailedNode.GiveUpText))
		{
			return "";
		}
		return Singleton<PublicUtil>.Instance.GetConfigTextByKey(processingCanGiveupFailedNode.GiveUpText);
	}

	// Token: 0x0600E0D3 RID: 57555 RVA: 0x003C7042 File Offset: 0x003C5242
	public void CreateMapMarks()
	{
		BehaviorTreeExpressionComponent expression = this.Expression;
		if (expression == null)
		{
			return;
		}
		expression.CreateMapMarks();
	}

	// Token: 0x0600E0D4 RID: 57556 RVA: 0x003C7054 File Offset: 0x003C5254
	[NullableContext(2)]
	public ITrackCustomBoard GetCurrentNodeCustomTrackBoard()
	{
		List<BehaviorNodeBase> currentActiveChildQuestNodes = this.GetCurrentActiveChildQuestNodes();
		if (currentActiveChildQuestNodes == null || currentActiveChildQuestNodes.Count == 0)
		{
			return null;
		}
		ITrackCustomBoard trackCustomBoard = null;
		ECustomTrackBoardPriority ecustomTrackBoardPriority = ECustomTrackBoardPriority.Undefined;
		foreach (BehaviorNodeBase behaviorNodeBase in currentActiveChildQuestNodes)
		{
			if (behaviorNodeBase.NodeType == EBtNode.ChildQuest)
			{
				ChildQuestNodeBase childQuestNodeBase = behaviorNodeBase as ChildQuestNodeBase;
				if (childQuestNodeBase != null && childQuestNodeBase.TrackCustomBoard != null)
				{
					ECustomTrackBoardPriority nodeCustomTrackBoardPriority = this.GetNodeCustomTrackBoardPriority(behaviorNodeBase);
					trackCustomBoard = ((nodeCustomTrackBoardPriority > ecustomTrackBoardPriority) ? childQuestNodeBase.TrackCustomBoard : trackCustomBoard);
					ecustomTrackBoardPriority = ((nodeCustomTrackBoardPriority > ecustomTrackBoardPriority) ? nodeCustomTrackBoardPriority : ecustomTrackBoardPriority);
				}
			}
		}
		return trackCustomBoard;
	}

	// Token: 0x0600E0D5 RID: 57557 RVA: 0x003C70FC File Offset: 0x003C52FC
	public ECustomTrackBoardPriority GetNodeCustomTrackBoardPriority(BehaviorNodeBase node)
	{
		if (node.NodeType != EBtNode.ChildQuest)
		{
			return ECustomTrackBoardPriority.Undefined;
		}
		ChildQuestNodeBase childQuestNodeBase = node as ChildQuestNodeBase;
		if (childQuestNodeBase == null)
		{
			return ECustomTrackBoardPriority.Undefined;
		}
		ITrackCustomBoard trackCustomBoard = childQuestNodeBase.TrackCustomBoard;
		if (((trackCustomBoard != null) ? trackCustomBoard.TrackReturnDungeon : null) != null)
		{
			return ECustomTrackBoardPriority.FastReturnDungeon;
		}
		ITrackCustomBoard trackCustomBoard2 = childQuestNodeBase.TrackCustomBoard;
		if (((trackCustomBoard2 != null) ? trackCustomBoard2.TrackPhoneMessageBoard : null) != null)
		{
			return ECustomTrackBoardPriority.PhoneMessage;
		}
		ITrackCustomBoard trackCustomBoard3 = childQuestNodeBase.TrackCustomBoard;
		if (((trackCustomBoard3 != null) ? trackCustomBoard3.SheriffAnomalyProgressBoard : null) != null)
		{
			return ECustomTrackBoardPriority.SheriffAnomalyProgress;
		}
		ITrackCustomBoard trackCustomBoard4 = childQuestNodeBase.TrackCustomBoard;
		if (((trackCustomBoard4 != null) ? trackCustomBoard4.SheriffReasoningBoard : null) != null)
		{
			return ECustomTrackBoardPriority.SheriffReasoning;
		}
		ITrackCustomBoard trackCustomBoard5 = childQuestNodeBase.TrackCustomBoard;
		if (((trackCustomBoard5 != null) ? trackCustomBoard5.SheriffClueDetailBoard : null) != null)
		{
			return ECustomTrackBoardPriority.SheriffClueDetail;
		}
		return ECustomTrackBoardPriority.Default;
	}

	// Token: 0x0600E0D6 RID: 57558 RVA: 0x003C7190 File Offset: 0x003C5390
	public unsafe void DoAction(GameCtxPb context, int nodeId, int playerId, int sessionId, int startIndex, int endIndex, bool needFinishReq)
	{
		if (this.BlackBoard.IsSleeping)
		{
			BtPendingDoAction data = new BtPendingDoAction
			{
				Context = context,
				NodeId = nodeId,
				PlayerId = playerId,
				SessionId = sessionId,
				StartIndex = startIndex,
				EndIndex = endIndex,
				NeedFinishReq = needFinishReq
			};
			this.AddToPendingProcessList(data);
			return;
		}
		IBtNode nodeConfig = this.BlackBoard.GetNodeConfig(nodeId);
		if (nodeConfig == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.GeneralLogicTree;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "服务器推送执行行为时，没有找到节点配置";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("context", context);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("treeConfigId", this.TreeConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("nodeId", nodeId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		List<ActionInfo> list = null;
		GameCtxType ctxType = context.CtxType;
		if (ctxType <= GameCtxType.CompositionConditionEnterAction)
		{
			switch (ctxType)
			{
			case GameCtxType.ChildQuestNodeEnterAction:
				if (nodeConfig.Type == EBtNode.ChildQuest)
				{
					IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
					if (childQuestBtNode != null)
					{
						list = childQuestBtNode.EnterActions;
					}
				}
				break;
			case GameCtxType.ChildQuestNodeFinishAction:
				if (nodeConfig.Type == EBtNode.ChildQuest)
				{
					IChildQuestBtNode childQuestBtNode2 = nodeConfig as IChildQuestBtNode;
					if (childQuestBtNode2 != null)
					{
						list = childQuestBtNode2.FinishActions;
					}
				}
				break;
			case GameCtxType.SuccessNodeAction:
				if (nodeConfig.Type == EBtNode.QuestSucceed)
				{
					IQuestSucceedBtNode questSucceedBtNode = nodeConfig as IQuestSucceedBtNode;
					if (questSucceedBtNode != null)
					{
						list = questSucceedBtNode.FinishActions;
					}
				}
				break;
			case GameCtxType.FailedNodeAction:
				if (nodeConfig.Type == EBtNode.QuestFailed)
				{
					IQuestFailedBtNode questFailedBtNode = nodeConfig as IQuestFailedBtNode;
					if (questFailedBtNode != null)
					{
						list = questFailedBtNode.FinishActions;
					}
				}
				break;
			case GameCtxType.CompositionEnterAction:
				if (nodeConfig.Type == EBtNode.ConditionSelector || nodeConfig.Type == EBtNode.ParallelSelect || nodeConfig.Type == EBtNode.Select || nodeConfig.Type == EBtNode.Sequence)
				{
					ILogicBtNode logicBtNode = nodeConfig as ILogicBtNode;
					if (logicBtNode != null)
					{
						ISaveConfig saveConfig = logicBtNode.SaveConfig;
						list = ((saveConfig != null) ? saveConfig.EnterActions : null);
					}
				}
				break;
			case GameCtxType.EntityConditionListeningAction:
			case GameCtxType.PlayFlowChildQuestNode:
			case GameCtxType.HandInItemChildQuestNode:
			case GameCtxType.DoInteractChildQuestNode:
				break;
			case GameCtxType.ActionGroupNodeAction:
				if (nodeConfig.Type == EBtNode.Action)
				{
					IActionBtNode actionBtNode = nodeConfig as IActionBtNode;
					if (actionBtNode != null)
					{
						list = actionBtNode.Actions;
					}
				}
				break;
			default:
				if (ctxType == GameCtxType.CompositionConditionEnterAction)
				{
					if (nodeConfig.Type == EBtNode.ConditionSelector || nodeConfig.Type == EBtNode.ParallelSelect || nodeConfig.Type == EBtNode.Select || nodeConfig.Type == EBtNode.Sequence)
					{
						ILogicBtNode logicBtNode2 = nodeConfig as ILogicBtNode;
						if (logicBtNode2 != null)
						{
							int conditionIndex = context.CompositionConditionEnterAction.ConditionIndex;
							ISaveConfig saveConfig2 = logicBtNode2.SaveConfig;
							object obj;
							if (saveConfig2 == null)
							{
								obj = null;
							}
							else
							{
								List<IInitConditionActions> initConditionActions = saveConfig2.InitConditionActions;
								obj = ((initConditionActions != null) ? initConditionActions.GetValueOrDefault(conditionIndex) : null);
							}
							object obj2 = obj;
							list = ((obj2 != null) ? obj2.Action : null);
						}
					}
				}
				break;
			}
		}
		else if (ctxType != GameCtxType.ChildQuestNodeStuckCheckAction)
		{
			if (ctxType == GameCtxType.RollBlockGamePlayActionCtx)
			{
				if (nodeConfig.Type == EBtNode.ChildQuest)
				{
					IChildQuestBtNode childQuestBtNode3 = nodeConfig as IChildQuestBtNode;
					if (childQuestBtNode3 != null && childQuestBtNode3.Condition.Type == EChildQuest.FinishRollBlock)
					{
						IFinishRollBlock finishRollBlock = childQuestBtNode3.Condition as IFinishRollBlock;
						if (finishRollBlock != null)
						{
							RollBlockGamePlayActionCtxPb rollBlockGamePlayActionCtxPb = context.RollBlockGamePlayActionCtxPb;
							if (rollBlockGamePlayActionCtxPb != null && rollBlockGamePlayActionCtxPb.Type == RollBlockGameActionType.RbEnter)
							{
								list = finishRollBlock.EnterActions;
							}
							else
							{
								RollBlockGamePlayActionCtxPb rollBlockGamePlayActionCtxPb2 = context.RollBlockGamePlayActionCtxPb;
								if (rollBlockGamePlayActionCtxPb2 != null && rollBlockGamePlayActionCtxPb2.Type == RollBlockGameActionType.RbMidWayExit)
								{
									list = finishRollBlock.ExitActions;
								}
								else
								{
									RollBlockGamePlayActionCtxPb rollBlockGamePlayActionCtxPb3 = context.RollBlockGamePlayActionCtxPb;
									if (rollBlockGamePlayActionCtxPb3 != null && rollBlockGamePlayActionCtxPb3.Type == RollBlockGameActionType.RbPass)
									{
										list = finishRollBlock.CompleteActions;
									}
								}
							}
						}
					}
				}
			}
		}
		else if (nodeConfig.Type == EBtNode.ChildQuest)
		{
			IChildQuestBtNode childQuestBtNode4 = nodeConfig as IChildQuestBtNode;
			if (childQuestBtNode4 != null)
			{
				list = childQuestBtNode4.StuckCheck[context.StuckCheckCtxPb.Index].Actions;
			}
		}
		if (list == null || list.Count == 0)
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.GeneralLogicTree;
			ELogAuthor author2 = ELogAuthor.YSQ;
			string message2 = "服务器推送执行行为时，没有找到行为配置";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("contextType", context.CtxType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("treeConfigId", this.TreeConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("nodeId", nodeId);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return;
		}
		this.BlackBoard.AddCurrentExecuteActions(sessionId);
		ControllerBase<LevelGeneralController>.Instance.ExecuteActionsByServerNotify(list, GeneralLogicTreeContext.Create(this.BtType, this.TreeIncId, this.TreeConfigId, nodeId, new GameCtxType?(context.CtxType)), playerId, sessionId, startIndex, endIndex, needFinishReq, delegate(ELevelEventState _)
		{
			this.BlackBoard.RemoveCurrentExecuteActions(sessionId);
		});
	}

	// Token: 0x0600E0D7 RID: 57559 RVA: 0x003C765C File Offset: 0x003C585C
	public void UpdateTimer(TimerInfoPb timerInfo)
	{
		if (this.BlackBoard.IsSleeping)
		{
			BtPendingUpdateUpdateTimer data = new BtPendingUpdateUpdateTimer
			{
				TimerInfo = timerInfo
			};
			this.AddToPendingProcessList(data);
			return;
		}
		this.TimerCenter.UpdateTimerInfo(timerInfo);
		Singleton<EventSystem>.Instance.Emit<long>(EEventName.OnGeneralLogicTreeTimerUpdate, this.TreeIncId);
	}

	// Token: 0x0600E0D8 RID: 57560 RVA: 0x003C76B0 File Offset: 0x003C58B0
	public double GetChallengeRemainTime(ETimerType? timerType = null)
	{
		ETimerType value = timerType.GetValueOrDefault();
		if (timerType == null)
		{
			value = ETimerType.CountDownChallenge;
			timerType = new ETimerType?(value);
		}
		return this.TimerCenter.GetRemainTime(timerType);
	}

	// Token: 0x0600E0D9 RID: 57561 RVA: 0x003C76E4 File Offset: 0x003C58E4
	public bool HasRunningTimers([Nullable(new byte[]
	{
		2,
		1
	})] List<string> includes = null, [Nullable(new byte[]
	{
		2,
		1
	})] List<string> excludes = null)
	{
		return this.TimerCenter.HasRunningTimers(includes, excludes);
	}

	// Token: 0x0600E0DA RID: 57562 RVA: 0x003C76F4 File Offset: 0x003C58F4
	public void UpdateTreeVars(BtVarUpdateNotify notify)
	{
		if (this.BlackBoard.IsSleeping)
		{
			BtPendingUpdateTreeVars data = new BtPendingUpdateTreeVars
			{
				Notify = notify
			};
			this.AddToPendingProcessList(data);
			return;
		}
		this.BlackBoard.UpdateTreeVar(notify.VarName, notify.VarDefine);
		Singleton<EventSystem>.Instance.Emit<long>(EEventName.GeneralLogicTreeViewForceRefresh, this.TreeIncId);
	}

	// Token: 0x0600E0DB RID: 57563 RVA: 0x003C7750 File Offset: 0x003C5950
	public bool IsSuspend()
	{
		return this.BlackBoard.IsSuspend();
	}

	// Token: 0x0600E0DC RID: 57564 RVA: 0x003C775D File Offset: 0x003C595D
	public EBehaviorTreeSuspendType GetSuspendType()
	{
		return this.Suspend.GetSuspendType();
	}

	// Token: 0x0600E0DD RID: 57565 RVA: 0x003C776A File Offset: 0x003C596A
	[NullableContext(2)]
	public string GetSuspendText()
	{
		return this.Suspend.GetSuspendText();
	}

	// Token: 0x0600E0DE RID: 57566 RVA: 0x003C7777 File Offset: 0x003C5977
	public IReadOnlyList<IOccupationInfo> GetOccupations()
	{
		return this.Suspend.GetOccupations();
	}

	// Token: 0x0600E0DF RID: 57567 RVA: 0x003C7784 File Offset: 0x003C5984
	public void UpdateOccupations(int suspendNodeId, int suspendType, IReadOnlyList<OccupationPbInfo> occupationInfo)
	{
		if (this.BlackBoard.IsSleeping)
		{
			BtPendingUpdateOccupations data = new BtPendingUpdateOccupations
			{
				SuspendNodeId = suspendNodeId,
				SuspendType = suspendType,
				OccupationInfo = occupationInfo
			};
			this.AddToPendingProcessList(data);
			return;
		}
		this.Suspend.UpdateOccupations(suspendNodeId, suspendType, occupationInfo);
	}

	// Token: 0x0600E0E0 RID: 57568 RVA: 0x003C77CF File Offset: 0x003C59CF
	public bool HasRefOccupiedEntity()
	{
		return this.BlackBoard.HasRefOccupiedEntity();
	}

	// Token: 0x0600E0E1 RID: 57569 RVA: 0x003C77DC File Offset: 0x003C59DC
	[NullableContext(2)]
	public string GetRefOccupiedEntityText()
	{
		return this.BlackBoard.GetRefOccupiedEntityText();
	}

	// Token: 0x0600E0E2 RID: 57570 RVA: 0x003C77E9 File Offset: 0x003C59E9
	[NullableContext(2)]
	public IBtNode GetNodeConfig(int nodeId)
	{
		return this.BlackBoard.GetNodeConfig(nodeId);
	}

	// Token: 0x0600E0E3 RID: 57571 RVA: 0x003C77F7 File Offset: 0x003C59F7
	public void AddGuaranteeActionInfo(string instigatorName, int nodeId, GuaranteeActionInfo targetActionInfo, EActionFilterMode compareMode)
	{
		this.BlackBoard.AddGuaranteeActionInfo(instigatorName, nodeId, targetActionInfo, compareMode);
	}

	// Token: 0x0600E0E4 RID: 57572 RVA: 0x003C7809 File Offset: 0x003C5A09
	[return: Nullable(2)]
	public GuaranteeActionInfo PopGuaranteeActionInfo(string instigatorName, GuaranteeActionInfo targetActionInfo, EActionFilterMode compareMode = EActionFilterMode.SameAction)
	{
		return this.BlackBoard.PopGuaranteeActionInfo(instigatorName, targetActionInfo, compareMode);
	}

	// Token: 0x0600E0E5 RID: 57573 RVA: 0x003C7819 File Offset: 0x003C5A19
	public void ClearGuaranteeActions(int nodeId = 0)
	{
		this.BlackBoard.ClearGuaranteeActions(nodeId);
	}

	// Token: 0x0600E0E6 RID: 57574 RVA: 0x003C7827 File Offset: 0x003C5A27
	public int GetRollbackPoint()
	{
		return this.BlackBoard.RollbackPoint;
	}

	// Token: 0x04006BC3 RID: 27587
	protected readonly Blackboard BlackBoard = new Blackboard();

	// Token: 0x04006BC4 RID: 27588
	[Nullable(2)]
	protected DynamicFlowInfo FlowInfo;

	// Token: 0x04006BC5 RID: 27589
	[Nullable(2)]
	public BehaviorTreeExpressionComponent Expression;

	// Token: 0x04006BC6 RID: 27590
	[Nullable(2)]
	public BindingExpressionComponentHolder BindingExpressionHolder;

	// Token: 0x04006BC7 RID: 27591
	[Nullable(2)]
	protected BehaviorTreeTimerCenter TimerCenter;

	// Token: 0x04006BC8 RID: 27592
	[Nullable(2)]
	protected BehaviorTreeSuspendComponent Suspend;

	// Token: 0x04006BC9 RID: 27593
	private readonly List<int> CurrentCorrelativeEntities = new List<int>();

	// Token: 0x04006BCA RID: 27594
	private readonly Queue<BehaviorTreePendingProcess> PendingProcess = new Queue<BehaviorTreePendingProcess>(4);

	// Token: 0x04006BCB RID: 27595
	protected int InnerFailNodeId;

	// Token: 0x04006BCC RID: 27596
	public bool IsPendingDestroy;
}
