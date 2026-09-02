using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;

namespace CSharpScript.Game.Module.GeneralLogicTree.BaseBehaviorTree.Express
{
	// Token: 0x02005D01 RID: 23809
	[NullableContext(1)]
	[Nullable(0)]
	public class TrackTextExpressController
	{
		// Token: 0x0603C066 RID: 245862 RVA: 0x00F39D41 File Offset: 0x00F37F41
		public TrackTextExpressController(Blackboard blackboard)
		{
			this.Blackboard = blackboard;
			this.UiBlackBoardTrackTextInfo = blackboard.UiTrackTextInfo;
		}

		// Token: 0x0603C067 RID: 245863 RVA: 0x00F39D80 File Offset: 0x00F37F80
		public void Clear()
		{
			this.UiCustomTrackTextInfo.Clear();
			this.UiBlackBoardTrackTextInfo.Clear();
			this.CustomUiConfigs.Clear();
			this.TextExpressUse.Clear();
			ModelBase<LevelPlayModel>.Instance.ChangeLevelPlayTrackRange(this.Blackboard.TreeConfigId, null);
			this.EndTextExpress(ETreeTextExpressReason.None);
		}

		// Token: 0x0603C068 RID: 245864 RVA: 0x00F39DE0 File Offset: 0x00F37FE0
		public void EnableTrack(bool value, ESetTrackReason reason = ESetTrackReason.None)
		{
			if (value)
			{
				this.StartTextExpress(ETreeTextExpressReason.None);
				return;
			}
			ETreeTextExpressReason reason2 = ETreeTextExpressReason.None;
			if (reason == ESetTrackReason.QuestFinished)
			{
				reason2 = ETreeTextExpressReason.QuestFinished;
			}
			this.EndTextExpress(reason2);
		}

		// Token: 0x0603C069 RID: 245865 RVA: 0x00F39E07 File Offset: 0x00F38007
		public void StartTextExpress(ETreeTextExpressReason reason = ETreeTextExpressReason.None)
		{
			this.TextExpressUse[(int)reason] = true;
			if (this.Blackboard.IsOccupied)
			{
				return;
			}
			if (this.Blackboard.IsTrackBoundToParent)
			{
				return;
			}
			this.StartShowTextImp(reason);
		}

		// Token: 0x0603C06A RID: 245866 RVA: 0x00F39E3C File Offset: 0x00F3803C
		private void StartShowTextImp(ETreeTextExpressReason reason)
		{
			if (this.Blackboard.IsTrackBoundToParent)
			{
				return;
			}
			if (this.TextExpressing)
			{
				return;
			}
			bool p = this.Blackboard.ContainTag(EBehaviorTreeTag.SkipMissionPanelAnim) || ModelBase<AutoRunModel>.Instance.GetAutoRunMode() > EAutoRunMode.Disabled;
			Singleton<EventSystem>.Instance.Emit<BehaviorTreeViewShowData, ETreeTextExpressReason, bool>(EEventName.GeneralLogicTreeStartShowTrackText, this.Blackboard.CreateShowData(true), reason, p);
			this.TextExpressing = true;
		}

		// Token: 0x0603C06B RID: 245867 RVA: 0x00F39EA5 File Offset: 0x00F380A5
		public void EndTextExpress(ETreeTextExpressReason reason = ETreeTextExpressReason.None)
		{
			if (reason == ETreeTextExpressReason.QuestFinished)
			{
				this.TextExpressUse.Clear();
			}
			else
			{
				this.TextExpressUse.Remove((int)reason);
			}
			if (this.TextExpressUse.Count != 0)
			{
				return;
			}
			this.EndShowTextImp(reason);
		}

		// Token: 0x0603C06C RID: 245868 RVA: 0x00F39EDC File Offset: 0x00F380DC
		public void UpdateOnNodeStatusChange(BehaviorNodeBase node, NodeStatus newStatus, ENodeStatusUpdateReason reason)
		{
			this.UpdateTrackTextData(node, newStatus);
			bool bSentUpdateTips = this.SendUpdateTips(node, newStatus, reason);
			this.UpdateTextExpress(bSentUpdateTips);
		}

		// Token: 0x0603C06D RID: 245869 RVA: 0x00F39F02 File Offset: 0x00F38102
		public void UpdateTextDataOnly()
		{
			this.SetCommonTextData();
		}

		// Token: 0x0603C06E RID: 245870 RVA: 0x00F39F0A File Offset: 0x00F3810A
		public void OnBtApplyExpressionOccupation(bool bSelf)
		{
			if (bSelf)
			{
				return;
			}
			this.EndShowTextImp(ETreeTextExpressReason.TextOccupation);
		}

		// Token: 0x0603C06F RID: 245871 RVA: 0x00F39F17 File Offset: 0x00F38117
		public void OnBtReleaseExpressionOccupation(bool bSelf)
		{
			if (bSelf)
			{
				return;
			}
			if (this.TextExpressUse.Count != 0)
			{
				this.StartShowTextImp(ETreeTextExpressReason.TextOccupation);
			}
		}

		// Token: 0x0603C070 RID: 245872 RVA: 0x00F39F31 File Offset: 0x00F38131
		public void OnSuspend(int nodeId, EBehaviorTreeSuspendType suspendType)
		{
			if (suspendType == EBehaviorTreeSuspendType.Occupation)
			{
				this.UpdateSuspendTrackTextData(nodeId, suspendType);
				return;
			}
			if (suspendType != EBehaviorTreeSuspendType.Online)
			{
				return;
			}
			this.EndShowTextImp(ETreeTextExpressReason.Online);
		}

		// Token: 0x0603C071 RID: 245873 RVA: 0x00F39F4C File Offset: 0x00F3814C
		public void OnCancelSuspend()
		{
			this.ProcessChallengeUi();
			if (this.TextExpressUse.Count != 0)
			{
				this.StartShowTextImp(ETreeTextExpressReason.TextOccupation);
			}
		}

		// Token: 0x0603C072 RID: 245874 RVA: 0x00F39F68 File Offset: 0x00F38168
		private void EndShowTextImp(ETreeTextExpressReason reason)
		{
			if (this.Blackboard.IsTrackBoundToParent)
			{
				return;
			}
			if (!this.TextExpressing)
			{
				return;
			}
			bool p = this.Blackboard.ContainTag(EBehaviorTreeTag.SkipMissionPanelAnim) || ModelBase<AutoRunModel>.Instance.GetAutoRunMode() > EAutoRunMode.Disabled;
			Singleton<EventSystem>.Instance.Emit<long, ETreeTextExpressReason, bool>(EEventName.GeneralLogicTreeEndShowTrackText, this.Blackboard.TreeIncId, reason, p);
			ControllerBase<GeneralLogicTreeController>.Instance.TryReleaseExpressionOccupation(this.Blackboard.TreeIncId);
			this.TextExpressing = false;
			if (TimerSystem.Instance.Has(this.UpdateTrackTextTimerHandle))
			{
				TimerSystem.Instance.Remove(this.UpdateTrackTextTimerHandle);
			}
		}

		// Token: 0x0603C073 RID: 245875 RVA: 0x00F3A008 File Offset: 0x00F38208
		private void UpdateTextExpress(bool bSentUpdateTips)
		{
			if (this.Blackboard.IsTrackBoundToParent)
			{
				return;
			}
			if (!this.TextExpressing || bSentUpdateTips)
			{
				return;
			}
			if (TimerSystem.Instance.Has(this.UpdateTrackTextTimerHandle))
			{
				TimerSystem.Instance.Remove(this.UpdateTrackTextTimerHandle);
			}
			this.UpdateTrackTextTimerHandle = this.DoDelayUpdate();
		}

		// Token: 0x0603C074 RID: 245876 RVA: 0x00F3A060 File Offset: 0x00F38260
		[NullableContext(2)]
		private TimerHandle DoDelayUpdate()
		{
			return TimerSystem.Instance.Delay(delegate(float _)
			{
				if (this.TextExpressing)
				{
					bool p = this.Blackboard.ContainTag(EBehaviorTreeTag.SkipMissionPanelAnim) || ModelBase<AutoRunModel>.Instance.GetAutoRunMode() > EAutoRunMode.Disabled;
					Singleton<EventSystem>.Instance.Emit<BehaviorTreeViewShowData, bool>(EEventName.GeneralLogicTreeUpdateShowTrackText, this.Blackboard.CreateShowData(true), p);
				}
			}, 100f, null, null, true, 1f);
		}

		// Token: 0x0603C075 RID: 245877 RVA: 0x00F3A088 File Offset: 0x00F38288
		private bool SendUpdateTips(BehaviorNodeBase node, NodeStatus newStatus, ENodeStatusUpdateReason reason)
		{
			if (reason != ENodeStatusUpdateReason.ServerUpdateNodeStatus || newStatus != NodeStatus.Activated || (this.Blackboard.BtType != BtType.Quest && this.Blackboard.BtType != BtType.Recall))
			{
				return false;
			}
			global::Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
			int? num = (curTrackedQuest != null) ? new int?(curTrackedQuest.Id) : null;
			int treeConfigId = this.Blackboard.TreeConfigId;
			int? num2 = num;
			if (treeConfigId == num2.GetValueOrDefault() & num2 != null)
			{
				return false;
			}
			if (!node.ContainTag(EBehaviorTreeTag.CanShow) || node.ContainTag(EBehaviorTreeTag.HideQuestUpdateTips))
			{
				return false;
			}
			if (string.IsNullOrEmpty(ControllerBase<GeneralLogicTreeController>.Instance.GetNodeTrackText(this.Blackboard.TreeIncId, node.NodeId)))
			{
				return false;
			}
			ModelBase<GeneralLogicTreeModel>.Instance.SaveUpdateInfo(this.Blackboard.TreeIncId, node.NodeId);
			return true;
		}

		// Token: 0x0603C076 RID: 245878 RVA: 0x00F3A154 File Offset: 0x00F38354
		private void UpdateTrackTextData(BehaviorNodeBase node, NodeStatus newStatus)
		{
			LogicNodeBase logicNodeBase = node as LogicNodeBase;
			if (logicNodeBase != null)
			{
				switch (newStatus)
				{
				case NodeStatus.Activated:
					if (logicNodeBase.ContainTag(EBehaviorTreeTag.CanShow))
					{
						this.SetCustomUiConfig(logicNodeBase.NodeId, logicNodeBase.CustomUiConfig);
						return;
					}
					break;
				case NodeStatus.Completing:
				case NodeStatus.Suspend:
					break;
				case NodeStatus.CompletedSuccess:
				case NodeStatus.CompletedFailed:
				case NodeStatus.Destroy:
					this.SetCustomUiConfig(logicNodeBase.NodeId, null);
					break;
				default:
					return;
				}
				return;
			}
			if (this.Blackboard.ContainTag(EBehaviorTreeTag.CustomUi))
			{
				return;
			}
			this.SetCommonTextData();
		}

		// Token: 0x0603C077 RID: 245879 RVA: 0x00F3A1CC File Offset: 0x00F383CC
		[NullableContext(2)]
		private void SetCustomUiConfig(int nodeId, IQuestScheduleConfig config)
		{
			int num = this.CustomUiConfigs.FindIndex((BtCustomUiConfig value) => value.SourceOfAdd == nodeId);
			if (config != null)
			{
				if (num < 0)
				{
					this.CustomUiConfigs.Add(new BtCustomUiConfig(nodeId, config));
				}
				else
				{
					this.CustomUiConfigs[num].CustomUiConfig = config;
				}
			}
			else
			{
				if (num < 0)
				{
					return;
				}
				this.CustomUiConfigs.RemoveAt(num);
			}
			this.Blackboard.RemoveTag(EBehaviorTreeTag.CustomUi, "");
			this.Blackboard.RemoveTag(EBehaviorTreeTag.ChallengeUi, "");
			int? trackRadius = null;
			if (this.CustomUiConfigs.Count != 0)
			{
				this.Blackboard.AddTag(EBehaviorTreeTag.CustomUi, "");
				List<BtCustomUiConfig> customUiConfigs = this.CustomUiConfigs;
				IQuestScheduleConfig customUiConfig = customUiConfigs[customUiConfigs.Count - 1].CustomUiConfig;
				this.UiCustomTrackTextInfo.CopyConfig(customUiConfig);
				ILevelPlayTrackRadius trackRadius2 = customUiConfig.TrackRadius;
				trackRadius = ((trackRadius2 != null) ? new int?(trackRadius2.TrackRadius) : null);
				if (customUiConfig.UiType == EQuestScheduleUiType.LevelPlay)
				{
					this.Blackboard.AddTag(EBehaviorTreeTag.ChallengeUi, "");
				}
				this.UiBlackBoardTrackTextInfo.Clear();
				this.UiBlackBoardTrackTextInfo.CopyConfig(customUiConfig);
			}
			else
			{
				this.SetCommonTextData();
			}
			ModelBase<LevelPlayModel>.Instance.ChangeLevelPlayTrackRange(this.Blackboard.TreeConfigId, trackRadius);
		}

		// Token: 0x0603C078 RID: 245880 RVA: 0x00F3A328 File Offset: 0x00F38528
		private void SetCommonTextData()
		{
			this.UiBlackBoardTrackTextInfo.Clear();
			Dictionary<int, BehaviorNodeBase> nodesByGroupId = this.Blackboard.GetNodesByGroupId(ENodeGroup.IsProcessing);
			if (nodesByGroupId == null)
			{
				return;
			}
			int num = 0;
			foreach (KeyValuePair<int, BehaviorNodeBase> keyValuePair in nodesByGroupId)
			{
				int num2;
				BehaviorNodeBase behaviorNodeBase;
				keyValuePair.Deconstruct(out num2, out behaviorNodeBase);
				int childQuestId = num2;
				BehaviorNodeBase behaviorNodeBase2 = behaviorNodeBase;
				if (behaviorNodeBase2.ContainTag(EBehaviorTreeTag.CanShow) && behaviorNodeBase2.TrackTextConfig != null)
				{
					this.UiBlackBoardTrackTextInfo.SetMainTitle(new IQuestScheduleMainTitle
					{
						TidTitle = behaviorNodeBase2.TrackTextConfig,
						QuestScheduleType = new IQuestScheduleChildQuestCompleted
						{
							Type = EQuestScheduleType.ChildQuestCompleted,
							ChildQuestId = childQuestId,
							ShowTracking = new bool?(true)
						}
					});
					this.UiBlackBoardTrackTextInfo.AddSubTitle(new IQuestScheduleSubTitle
					{
						TidTitle = behaviorNodeBase2.TrackTextConfig,
						QuestScheduleType = new IQuestScheduleChildQuestCompleted
						{
							Type = EQuestScheduleType.ChildQuestCompleted,
							ChildQuestId = childQuestId,
							ShowTracking = new bool?(true)
						}
					});
					num++;
				}
			}
			if (num == 1)
			{
				this.UiBlackBoardTrackTextInfo.ClearSubTitle();
				return;
			}
			this.UiBlackBoardTrackTextInfo.SetMainTitle(null);
		}

		// Token: 0x0603C079 RID: 245881 RVA: 0x00F3A464 File Offset: 0x00F38664
		private void UpdateSuspendTrackTextData(int nodeId, EBehaviorTreeSuspendType suspendType)
		{
			this.UiBlackBoardTrackTextInfo.Clear();
			if (suspendType == EBehaviorTreeSuspendType.Occupation && !StringUtils.IsBlank(Singleton<PublicUtil>.Instance.GetConfigTextByKey("TaskOccupyGeneralDes_1001")))
			{
				this.UiBlackBoardTrackTextInfo.SetMainTitle(new IQuestScheduleMainTitle
				{
					TidTitle = "TaskOccupyGeneralDes_1001",
					QuestScheduleType = new IQuestScheduleType
					{
						Type = EQuestScheduleType.None
					}
				});
				this.UiBlackBoardTrackTextInfo.ClearSubTitle();
				this.Blackboard.AddTag(EBehaviorTreeTag.SuspendingCanShow, "");
			}
		}

		// Token: 0x0603C07A RID: 245882 RVA: 0x00F3A4E0 File Offset: 0x00F386E0
		private void ProcessChallengeUi()
		{
			if (!this.Blackboard.ContainTag(EBehaviorTreeTag.CustomUi))
			{
				return;
			}
			this.UiBlackBoardTrackTextInfo.Clear();
			this.UiBlackBoardTrackTextInfo.CopyConfig(this.UiCustomTrackTextInfo);
		}

		// Token: 0x04021B84 RID: 138116
		private readonly Blackboard Blackboard;

		// Token: 0x04021B85 RID: 138117
		private readonly TreeTrackTextExpressionInfo UiBlackBoardTrackTextInfo;

		// Token: 0x04021B86 RID: 138118
		private readonly TreeTrackTextExpressionInfo UiCustomTrackTextInfo = new TreeTrackTextExpressionInfo();

		// Token: 0x04021B87 RID: 138119
		private readonly Dictionary<int, bool> TextExpressUse = new Dictionary<int, bool>();

		// Token: 0x04021B88 RID: 138120
		private readonly List<BtCustomUiConfig> CustomUiConfigs = new List<BtCustomUiConfig>();

		// Token: 0x04021B89 RID: 138121
		private bool TextExpressing;

		// Token: 0x04021B8A RID: 138122
		[Nullable(2)]
		private TimerHandle UpdateTrackTextTimerHandle;
	}
}
