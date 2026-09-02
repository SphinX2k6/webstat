using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002695 RID: 9877
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class QuestTreeController : ControllerBase<QuestTreeController>
{
	// Token: 0x17001884 RID: 6276
	// (get) Token: 0x060137DF RID: 79839 RVA: 0x0056FA3C File Offset: 0x0056DC3C
	public bool IsGmSetAllNodeFinish
	{
		get
		{
			bool result = false;
			UKuroVariableFunctionLibrary.GetBoolValue("Gm_QuestTreeNode_Finish", ref result);
			return result;
		}
	}

	// Token: 0x060137E0 RID: 79840 RVA: 0x0056FA59 File Offset: 0x0056DC59
	public void OpenMainView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestTreeMainView, null, null);
	}

	// Token: 0x060137E1 RID: 79841 RVA: 0x0056FA6C File Offset: 0x0056DC6C
	public void OpenChapterView(int chapterId, int? id)
	{
		QuestTreeChapterViewParam param = new QuestTreeChapterViewParam
		{
			ChapterId = chapterId,
			NodeId = id
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestTreeChapterView, param, null);
	}

	// Token: 0x060137E2 RID: 79842 RVA: 0x0056FAA0 File Offset: 0x0056DCA0
	public void OpenNodeDetailView(QuestTreeNodeData node)
	{
		QuestTreeNodeDetailView questTreeNodeDetailView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.QuestTreeNodeDetailView) as QuestTreeNodeDetailView;
		if (questTreeNodeDetailView != null)
		{
			questTreeNodeDetailView.ChangeData(node);
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestTreeNodeDetailView, node, null);
	}

	// Token: 0x060137E3 RID: 79843 RVA: 0x0056FADD File Offset: 0x0056DCDD
	public void CloseNodeDetailView()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.QuestTreeNodeDetailView, null);
	}

	// Token: 0x060137E4 RID: 79844 RVA: 0x0056FAEF File Offset: 0x0056DCEF
	public void OpenAvailableListView(List<QuestTreeNodeData> data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestTreeAvailableListView, data, null);
	}

	// Token: 0x060137E5 RID: 79845 RVA: 0x0056FB04 File Offset: 0x0056DD04
	public void TrackNode(QuestTreeNodeData node, bool gotoAfterTrack = true)
	{
		int questId = node.QuestId;
		ESetTrackResult esetTrackResult = ControllerBase<QuestNewController>.Instance.RequestTrackQuest(questId, true, ERequestTrackOperate.Manual, ESetTrackReason.None, null);
		Singleton<EventSystem>.Instance.Emit<QuestTreeNodeData>(EEventName.QuestTreeNodeDataUpdate, node);
		switch (esetTrackResult)
		{
		case ESetTrackResult.QuestNotExist:
			return;
		case ESetTrackResult.QuestIsSuspend:
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Task_NoSwitch_Tips", Array.Empty<object>());
			return;
		case ESetTrackResult.QuestNotCanShowTrackExpression:
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("FollowQuestStepGuide", Array.Empty<object>());
			return;
		case ESetTrackResult.FocusModeCanNotTrackOtherQuest:
			return;
		default:
			if (gotoAfterTrack)
			{
				this.GotoNode(node);
			}
			return;
		}
	}

	// Token: 0x060137E6 RID: 79846 RVA: 0x0056FB8A File Offset: 0x0056DD8A
	public bool GotoNode(QuestTreeNodeData node)
	{
		return this.GotoNodeByQuestId(node.QuestId);
	}

	// Token: 0x060137E7 RID: 79847 RVA: 0x0056FB98 File Offset: 0x0056DD98
	public bool GotoNodeNyQuestId(int questId)
	{
		return this.GotoNodeByQuestId(questId);
	}

	// Token: 0x060137E8 RID: 79848 RVA: 0x0056FBA4 File Offset: 0x0056DDA4
	public bool GotoNodeByQuestId(int questId)
	{
		global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(questId);
		if (quest == null)
		{
			return false;
		}
		List<BehaviorNodeBase> currentActiveChildQuestNodes = quest.GetCurrentActiveChildQuestNodes();
		if (currentActiveChildQuestNodes == null || currentActiveChildQuestNodes.Count == 0)
		{
			return false;
		}
		foreach (BehaviorNodeBase behaviorNodeBase in currentActiveChildQuestNodes)
		{
			QuestTreeController.<>c__DisplayClass10_0 CS$<>8__locals1 = new QuestTreeController.<>c__DisplayClass10_0();
			int? defaultMark = quest.GetDefaultMark(behaviorNodeBase.NodeId);
			bool flag = (defaultMark ?? 0) == 0;
			if (!flag)
			{
				if (MapUtil.GetDungeonsRelation(ModelBase<CreatureModel>.Instance.GetInstanceId(), quest.DungeonId) == EDungeonRelationType.SameDungeon)
				{
					float trackDistanceByMarkId = MapUtil.GetTrackDistanceByMarkId(defaultMark.GetValueOrDefault());
					if (trackDistanceByMarkId == 0f)
					{
						continue;
					}
					int valueOrDefault = ConfigCommonParamById.GetIntConfig("QuestTrackNeedOpenWordMapDistance").GetValueOrDefault(50);
					if (trackDistanceByMarkId < (float)valueOrDefault)
					{
						Singleton<UiManager>.Instance.ResetToBattleView(null);
						return true;
					}
				}
				CS$<>8__locals1.param = new WorldMapViewOpenParams();
				CS$<>8__locals1.param.MarkType = EMarkType.Quest;
				CS$<>8__locals1.param.MarkId = defaultMark;
				CS$<>8__locals1.param.IsNotFocusTween = new bool?(true);
				CS$<>8__locals1.param.OpenFogId = new int?(0);
				Singleton<UiLayer>.Instance.SetShowMaskLayer("QuestNodeGoto", true);
				if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.WorldMapView) != null)
				{
					Singleton<UiManager>.Instance.CloseViewAsync(EUiViewName.WorldMapView).ContinueWith(delegate(bool _)
					{
						base.<GotoNodeByQuestId>g__OpenWorldMapView|0();
					});
				}
				else
				{
					CS$<>8__locals1.<GotoNodeByQuestId>g__OpenWorldMapView|0();
				}
				Singleton<UiManager>.Instance.CloseView(EUiViewName.QuestTreeNodeDetailView, null);
				return true;
			}
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("FollowQuestStepGuide", Array.Empty<object>());
		return false;
	}

	// Token: 0x060137E9 RID: 79849 RVA: 0x0056FD80 File Offset: 0x0056DF80
	public void CancelTrackNode(QuestTreeNodeData node)
	{
		ControllerBase<QuestNewController>.Instance.RequestTrackQuest(node.QuestId, false, ERequestTrackOperate.Manual, ESetTrackReason.None, delegate
		{
			Singleton<EventSystem>.Instance.Emit<QuestTreeNodeData>(EEventName.QuestTreeNodeDataUpdate, node);
		});
	}

	// Token: 0x060137EA RID: 79850 RVA: 0x0056FDC0 File Offset: 0x0056DFC0
	public void TrackOrGotoNode(QuestTreeNodeData node)
	{
		QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
		int questId = node.QuestId;
		global::Quest quest = instance.GetQuest(questId);
		if (quest == null)
		{
			return;
		}
		switch (instance.GetQuestSpecialState(quest))
		{
		case EQuestSpecialState.LockByLackResource:
			ControllerBase<QuestNewController>.Instance.SetVideoResourceDownloadTriggerId(quest.Id);
			ModelBase<SubPackageDownLoadModel>.Instance.OpenSubPackageByQuest(quest.Id);
			return;
		case EQuestSpecialState.ResourceReadyButLock:
			ControllerBase<QuestNewController>.Instance.ConfirmQuestResourceRequest(quest.Id, delegate
			{
				Singleton<EventSystem>.Instance.Emit<QuestTreeNodeData>(EEventName.QuestTreeNodeDataUpdate, node);
			});
			return;
		case EQuestSpecialState.Suspend:
		{
			if (instance.IsInFocusMode() && !instance.IsInFocusOnQuest(questId))
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FocusModeSwitchToCommonQuest);
				Action <>9__6;
				Action <>9__5;
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					int curFocusQuestId = ModelBase<QuestNewModel>.Instance.GetCurFocusQuestId();
					QuestNewController instance2 = ControllerBase<QuestNewController>.Instance;
					int questId2 = curFocusQuestId;
					Action callback;
					if ((callback = <>9__5) == null)
					{
						callback = (<>9__5 = delegate()
						{
							GeneralLogicTreeController instance3 = ControllerBase<GeneralLogicTreeController>.Instance;
							long valueOrDefault = quest.TreeId.GetValueOrDefault();
							Action callback2;
							if ((callback2 = <>9__6) == null)
							{
								callback2 = (<>9__6 = delegate()
								{
									this.TrackNode(node, true);
								});
							}
							instance3.RequestForcedOccupation(valueOrDefault, callback2);
						});
					}
					instance2.RequestCancelQuestFocusMode(questId2, callback);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.QuestForceOccupy);
			Action <>9__8;
			confirmBoxDataNew2.FunctionMap[2] = delegate()
			{
				GeneralLogicTreeController instance2 = ControllerBase<GeneralLogicTreeController>.Instance;
				long valueOrDefault = quest.TreeId.GetValueOrDefault();
				Action callback;
				if ((callback = <>9__8) == null)
				{
					callback = (<>9__8 = delegate()
					{
						this.TrackNode(node, true);
					});
				}
				instance2.RequestForcedOccupation(valueOrDefault, callback);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
			return;
		}
		case EQuestSpecialState.LockByFocusMode:
		{
			ConfirmBoxDataNew confirmBoxDataNew3 = new ConfirmBoxDataNew(EConfirmBoxConfigId.FocusModeSwitchToCommonQuest);
			Action <>9__10;
			Action <>9__9;
			confirmBoxDataNew3.FunctionMap[2] = delegate()
			{
				int curFocusQuestId = ModelBase<QuestNewModel>.Instance.GetCurFocusQuestId();
				QuestNewController instance2 = ControllerBase<QuestNewController>.Instance;
				int questId2 = curFocusQuestId;
				Action callback;
				if ((callback = <>9__9) == null)
				{
					callback = (<>9__9 = delegate()
					{
						QuestNewController instance3 = ControllerBase<QuestNewController>.Instance;
						int id = quest.Id;
						Action callback2;
						if ((callback2 = <>9__10) == null)
						{
							callback2 = (<>9__10 = delegate()
							{
								this.GotoNode(node);
								Singleton<EventSystem>.Instance.Emit<QuestTreeNodeData>(EEventName.QuestTreeNodeDataUpdate, node);
							});
						}
						instance3.RequestAcceptFocusWaitQuest(id, callback2);
					});
				}
				instance2.RequestCancelQuestFocusMode(questId2, callback);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew3);
			return;
		}
		case EQuestSpecialState.NotInFocusModeButLock:
			ControllerBase<QuestNewController>.Instance.RequestAcceptFocusWaitQuest(quest.Id, delegate
			{
				Singleton<EventSystem>.Instance.Emit<QuestTreeNodeData>(EEventName.QuestTreeNodeDataUpdate, node);
			});
			return;
		case EQuestSpecialState.FocusOtherQuest:
		{
			ConfirmBoxDataNew confirmBoxDataNew4 = new ConfirmBoxDataNew(EConfirmBoxConfigId.FocusModeSwitchConfirm);
			Action<bool> <>9__11;
			confirmBoxDataNew4.FunctionMap[2] = delegate()
			{
				QuestNewController instance2 = ControllerBase<QuestNewController>.Instance;
				int id = quest.Id;
				Action<bool> callback;
				if ((callback = <>9__11) == null)
				{
					callback = (<>9__11 = delegate(bool _)
					{
						this.TrackNode(node, true);
					});
				}
				instance2.RequestSetQuestFocusMode(id, callback);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew4);
			return;
		}
		}
		if (node.IsTracking)
		{
			this.GotoNode(node);
			return;
		}
		this.TrackNode(node, true);
	}

	// Token: 0x060137EB RID: 79851 RVA: 0x0056FFBC File Offset: 0x0056E1BC
	public int? TryAddMapMarkForNode(QuestTreeNodeData node)
	{
		IQuest questConfig = ModelBase<QuestNewModel>.Instance.GetQuestConfig(node.QuestId);
		if (questConfig == null)
		{
			return null;
		}
		IAddInteractOption addInteractOption = questConfig.AddInteractOption;
		QuestType? questTypeConfig = ConfigBase<QuestNewConfig>.Instance.GetQuestTypeConfig((int)questConfig.Type);
		if (addInteractOption == null || questTypeConfig == null)
		{
			return null;
		}
		int? questMarkId = Singleton<QuestUtil>.Instance.GetQuestMarkId(questTypeConfig.Value.MainId, new int?(node.QuestId));
		bool flag = (questMarkId ?? 0) == 0;
		if (flag)
		{
			return null;
		}
		int num;
		if (ModelBase<QuestNewModel>.Instance.QuestIdToExternalAddedQuestMarkId.TryGetValue(node.QuestId, out num) && num != 0)
		{
			return new int?(num);
		}
		QuestMarkCreateInfo info = new QuestMarkCreateInfo(new QuestMarkCreateParams
		{
			TrackTarget = addInteractOption.EntityId,
			MarkConfigId = questMarkId.Value,
			MarkType = EMarkType.Quest,
			TrackSource = new ETrackSource?(ETrackSource.Quest),
			TreeId = (long)node.QuestId,
			NodeId = 0,
			EntityConfigId = new int?(addInteractOption.EntityId),
			MapAndDungeonInfo = new MapAndDungeonInfo
			{
				DungeonId = new int?(questConfig.DungeonId)
			}
		});
		int value = ModelBase<MapModel>.Instance.CreateMapMark(info);
		ModelBase<QuestNewModel>.Instance.QuestIdToExternalAddedQuestMarkId[node.QuestId] = value;
		return new int?(value);
	}

	// Token: 0x060137EC RID: 79852 RVA: 0x00570138 File Offset: 0x0056E338
	public void JumpToQuest(int questId)
	{
		QuestTreeNodeData nodeDataFromQuestId = ModelBase<QuestTreeModel>.Instance.GetNodeDataFromQuestId(questId);
		if (nodeDataFromQuestId == null)
		{
			if (!this.GotoNodeByQuestId(questId))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.WorldMapView, null, delegate(bool _, int _)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("QuestTree_NotTreeNode_Unavailable", Array.Empty<object>());
				});
				Singleton<UiManager>.Instance.CloseView(EUiViewName.QuestTreeNodeDetailView, null);
			}
			return;
		}
		if (nodeDataFromQuestId.State == EQuestTreeNodeState.None)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("QuestTree_NotTreeNode_Unavailable", Array.Empty<object>());
			return;
		}
		QuestTreeNodeData selectedData = ModelBase<QuestTreeModel>.Instance.ViewModelChapter.SelectedData;
		int? num = (selectedData != null) ? new int?(selectedData.ChapterId) : null;
		int chapterId = nodeDataFromQuestId.ChapterId;
		if (num.GetValueOrDefault() == chapterId & num != null)
		{
			ModelBase<QuestTreeModel>.Instance.ViewModelChapter.SelectData(nodeDataFromQuestId);
			this.OpenNodeDetailView(nodeDataFromQuestId);
			return;
		}
		this.JumpToQuestOutOfThisChapter(nodeDataFromQuestId).Forget();
	}

	// Token: 0x060137ED RID: 79853 RVA: 0x00570224 File Offset: 0x0056E424
	private UniTask JumpToQuestOutOfThisChapter(QuestTreeNodeData node)
	{
		QuestTreeController.<JumpToQuestOutOfThisChapter>d__15 <JumpToQuestOutOfThisChapter>d__;
		<JumpToQuestOutOfThisChapter>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<JumpToQuestOutOfThisChapter>d__.<>4__this = this;
		<JumpToQuestOutOfThisChapter>d__.node = node;
		<JumpToQuestOutOfThisChapter>d__.<>1__state = -1;
		<JumpToQuestOutOfThisChapter>d__.<>t__builder.Start<QuestTreeController.<JumpToQuestOutOfThisChapter>d__15>(ref <JumpToQuestOutOfThisChapter>d__);
		return <JumpToQuestOutOfThisChapter>d__.<>t__builder.Task;
	}

	// Token: 0x060137EE RID: 79854 RVA: 0x0057026F File Offset: 0x0056E46F
	public void GmSetAllNodeFinish()
	{
		UKuroVariableFunctionLibrary.RemoveBoolValue("Gm_QuestTreeNode_Finish");
		UKuroVariableFunctionLibrary.SetBoolValue("Gm_QuestTreeNode_Finish", true);
	}

	// Token: 0x060137EF RID: 79855 RVA: 0x00570288 File Offset: 0x0056E488
	public void GmResetAllNodeFinish()
	{
		UKuroVariableFunctionLibrary.RemoveBoolValue("Gm_QuestTreeNode_Finish");
		UKuroVariableFunctionLibrary.SetBoolValue("Gm_QuestTreeNode_Finish", false);
	}

	// Token: 0x060137F0 RID: 79856 RVA: 0x005702A1 File Offset: 0x0056E4A1
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.TsHandleQuestTreeNodeResponse, new Action<int, int>(this.OnTsHandleQuestTreeNodeResponse));
		return true;
	}

	// Token: 0x060137F1 RID: 79857 RVA: 0x005702C0 File Offset: 0x0056E4C0
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TsHandleQuestTreeNodeResponse, new Action<int, int>(this.OnTsHandleQuestTreeNodeResponse));
		return true;
	}

	// Token: 0x060137F2 RID: 79858 RVA: 0x005702E0 File Offset: 0x0056E4E0
	private void OnTsHandleQuestTreeNodeResponse(int type, int nodeId)
	{
		QuestTreeNodeData nodeDataFromNodeId = ModelBase<QuestTreeModel>.Instance.GetNodeDataFromNodeId(nodeId);
		if (nodeDataFromNodeId == null)
		{
			return;
		}
		switch (type)
		{
		case 1:
			ModelBase<QuestNewModel>.Instance.SetQuestTrackState(nodeDataFromNodeId.QuestId, true, ESetTrackReason.None);
			Singleton<EventSystem>.Instance.Emit<QuestTreeNodeData>(EEventName.QuestTreeNodeDataUpdate, nodeDataFromNodeId);
			return;
		case 2:
			Singleton<EventSystem>.Instance.Emit<QuestTreeNodeData>(EEventName.QuestTreeNodeDataUpdate, nodeDataFromNodeId);
			return;
		case 3:
		{
			global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(nodeDataFromNodeId.QuestId);
			if (quest != null && quest.LockByFocusMode)
			{
				ModelBase<QuestNewModel>.Instance.RemovePendingAcceptQuestOnFocusMode(nodeDataFromNodeId.QuestId);
				return;
			}
			break;
		}
		case 4:
			ModelBase<QuestNewModel>.Instance.RemoveLackResourceQuest(nodeDataFromNodeId.QuestId);
			break;
		default:
			return;
		}
	}

	// Token: 0x060137F3 RID: 79859 RVA: 0x00570390 File Offset: 0x0056E590
	public void ReportClickNode(QuestTreeNodeData node)
	{
		QuestTreeClickLogEvent questTreeClickLogEvent = new QuestTreeClickLogEvent();
		questTreeClickLogEvent.i_chapter_id = node.ChapterId;
		questTreeClickLogEvent.i_quest_id = node.QuestId;
		questTreeClickLogEvent.i_quest_status = (int)node.State;
		questTreeClickLogEvent.i_quest_type = node.Config.QuestType;
		ControllerBase<LogReportController>.Instance.LogReport(questTreeClickLogEvent);
	}

	// Token: 0x060137F4 RID: 79860 RVA: 0x005703E8 File Offset: 0x0056E5E8
	public void ReportJump(QuestTreeNodeData node, EQuestTreeLogReportJumpMotion motion)
	{
		QuestTreeJumpLogEvent questTreeJumpLogEvent = new QuestTreeJumpLogEvent();
		questTreeJumpLogEvent.i_chapter_id = node.ChapterId;
		questTreeJumpLogEvent.i_quest_id = node.QuestId;
		questTreeJumpLogEvent.i_quest_status = (int)node.State;
		questTreeJumpLogEvent.i_quest_type = node.Config.QuestType;
		questTreeJumpLogEvent.i_motion = (int)motion;
		ControllerBase<LogReportController>.Instance.LogReport(questTreeJumpLogEvent);
	}
}
