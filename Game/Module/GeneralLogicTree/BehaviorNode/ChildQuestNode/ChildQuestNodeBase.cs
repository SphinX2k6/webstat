using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CDD RID: 23773
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class ChildQuestNodeBase : BehaviorNodeBase
	{
		// Token: 0x0603BF0F RID: 245519 RVA: 0x00F32AD0 File Offset: 0x00F30CD0
		protected ChildQuestNodeBase(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x17009846 RID: 38982
		// (get) Token: 0x0603BF10 RID: 245520 RVA: 0x00F32AE1 File Offset: 0x00F30CE1
		public override EBtNode NodeType
		{
			get
			{
				return EBtNode.ChildQuest;
			}
		}

		// Token: 0x17009847 RID: 38983
		// (get) Token: 0x0603BF11 RID: 245521 RVA: 0x00F32AE5 File Offset: 0x00F30CE5
		protected virtual List<int> CorrelativeEntities
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17009848 RID: 38984
		// (get) Token: 0x0603BF12 RID: 245522 RVA: 0x00F32AE8 File Offset: 0x00F30CE8
		public bool CanGiveUp
		{
			get
			{
				return this.ChildQuestStatus == ChildQuestNodeStatus.CqnsProgress;
			}
		}

		// Token: 0x17009849 RID: 38985
		// (get) Token: 0x0603BF13 RID: 245523 RVA: 0x00F32AF3 File Offset: 0x00F30CF3
		public bool InProgress
		{
			get
			{
				return this.ChildQuestStatus == ChildQuestNodeStatus.CqnsProgress;
			}
		}

		// Token: 0x1700984A RID: 38986
		// (get) Token: 0x0603BF14 RID: 245524 RVA: 0x00F32AFE File Offset: 0x00F30CFE
		public bool IsFinished
		{
			get
			{
				return this.ChildQuestStatus == ChildQuestNodeStatus.CqnsFinished;
			}
		}

		// Token: 0x1700984B RID: 38987
		// (get) Token: 0x0603BF15 RID: 245525 RVA: 0x00F32B09 File Offset: 0x00F30D09
		public ITrackLevelPlay TrackLevelPlay
		{
			get
			{
				ITrackTarget trackTarget = this.TrackTarget;
				if (trackTarget != null && trackTarget.TrackType.Type == Aki.TDConfigMgr.Quest.ETrackType.LevelPlay)
				{
					return this.TrackTarget.TrackType as ITrackLevelPlay;
				}
				return null;
			}
		}

		// Token: 0x0603BF16 RID: 245526 RVA: 0x00F32B3C File Offset: 0x00F30D3C
		[NullableContext(1)]
		public override void Init(Blackboard blackBoard, ENodeStatusUpdateReason reason, global::NodeInfo data, IBtNode config, BtType btType)
		{
			IChildQuestBtNode childQuestBtNode = config as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return;
			}
			base.Init(blackBoard, reason, data, config, btType);
			this.ChildQuestStatus = ChildQuestNodeStatus.CqnsNotActive;
			this.CustomTrackIconId = childQuestBtNode.CustomIcon.GetValueOrDefault();
			ChildQuestNodeInfo childQuestNodeInfo = data.Info.ChildQuestNodeInfo;
			if (childQuestNodeInfo != null)
			{
				this.UpdateChildQuestStatus(childQuestNodeInfo.Status, reason);
				base.UpdateProgress(childQuestNodeInfo.Progress);
			}
		}

		// Token: 0x0603BF17 RID: 245527 RVA: 0x00F32BA8 File Offset: 0x00F30DA8
		public void UpdateChildQuestStatus(ChildQuestNodeStatus status, ENodeStatusUpdateReason reason)
		{
			ChildQuestNodeStatus childQuestStatus = this.ChildQuestStatus;
			this.ChildQuestStatus = status;
			if (childQuestStatus == this.ChildQuestStatus)
			{
				return;
			}
			if (status != ChildQuestNodeStatus.CqnsProgress)
			{
				if (status == ChildQuestNodeStatus.CqnsFinished)
				{
					this.Finish();
				}
			}
			else
			{
				this.Start(reason);
			}
			Singleton<EventSystem>.Instance.Emit<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus, ENodeStatusUpdateReason>(EEventName.OnLogicTreeChildQuestNodeStatusChange, this.Context, childQuestStatus, status, reason);
			Singleton<EventSystem>.Instance.EmitWithTarget<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus, ENodeStatusUpdateReason>(this.Blackboard, EEventName.OnLogicTreeChildQuestNodeStatusChange, this.Context, childQuestStatus, status, reason);
			Singleton<EventSystem>.Instance.Emit<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus>(EEventName.AfterLogicTreeChildQuestNodeStatusChange, this.Context, childQuestStatus, status);
		}

		// Token: 0x0603BF18 RID: 245528 RVA: 0x00F32C38 File Offset: 0x00F30E38
		protected override void OnNodeActive()
		{
			this.AddTag(EBehaviorTreeTag.CanShow, base.NodeId.ToString());
			if (this.ModifyTrackAreaTextConfig != null)
			{
				Blackboard blackboard = this.Blackboard;
				if (blackboard != null)
				{
					blackboard.AddModifyTrackAreaConfig(base.NodeId, this.ModifyTrackAreaTextConfig);
				}
			}
			ITrackLevelPlay trackLevelPlay = this.TrackLevelPlay;
			if (trackLevelPlay != null)
			{
				ModelBase<GeneralLogicTreeModel>.Instance.AddLevelPlayTrackBinding(base.NodeId, base.TreeIncId, trackLevelPlay.LevelPlayId);
				Blackboard blackboard2 = this.Blackboard;
				if (blackboard2 == null)
				{
					return;
				}
				blackboard2.AddTag(EBehaviorTreeTag.BindingLevelPlayTrack, base.NodeId.ToString());
			}
		}

		// Token: 0x0603BF19 RID: 245529 RVA: 0x00F32CC5 File Offset: 0x00F30EC5
		private void Start(ENodeStatusUpdateReason reason)
		{
			this.AddEventsOnChildQuestStart();
			this.OnStart(reason);
		}

		// Token: 0x0603BF1A RID: 245530 RVA: 0x00F32CD4 File Offset: 0x00F30ED4
		private void Finish()
		{
			this.End(true);
		}

		// Token: 0x0603BF1B RID: 245531 RVA: 0x00F32CE0 File Offset: 0x00F30EE0
		protected override void OnNodeDeActive(bool success)
		{
			this.RemoveTag(EBehaviorTreeTag.CanShow, base.NodeId.ToString());
			if (!success)
			{
				this.End(false);
				this.ChildQuestStatus = ChildQuestNodeStatus.CqnsNotActive;
			}
			if (this.ModifyTrackAreaTextConfig != null)
			{
				Blackboard blackboard = this.Blackboard;
				if (blackboard != null)
				{
					blackboard.RemoveModifyTrackAreaConfig(base.NodeId);
				}
			}
			ITrackLevelPlay trackLevelPlay = this.TrackLevelPlay;
			if (trackLevelPlay != null)
			{
				ModelBase<GeneralLogicTreeModel>.Instance.RemoveLevelPlayTrackBinding(base.TreeIncId, trackLevelPlay.LevelPlayId);
				Blackboard blackboard2 = this.Blackboard;
				if (blackboard2 == null)
				{
					return;
				}
				blackboard2.RemoveTag(EBehaviorTreeTag.BindingLevelPlayTrack, base.NodeId.ToString());
			}
		}

		// Token: 0x0603BF1C RID: 245532 RVA: 0x00F32D72 File Offset: 0x00F30F72
		private void End(bool bFinished)
		{
			this.RemoveEventsOnChildQuestEnd();
			this.OnEnd(bFinished);
		}

		// Token: 0x0603BF1D RID: 245533 RVA: 0x00F32D84 File Offset: 0x00F30F84
		[NullableContext(1)]
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return false;
			}
			this.ChildQuestType = childQuestBtNode.Condition.Type;
			if (childQuestBtNode.HideTip.GetValueOrDefault())
			{
				this.AddTag(EBehaviorTreeTag.HideQuestUpdateTips, "");
			}
			if (childQuestBtNode.HideUiExceptTaskList.GetValueOrDefault())
			{
				this.AddTag(EBehaviorTreeTag.HideTrackExpression, "");
				this.AddTag(EBehaviorTreeTag.HideQuestUpdateTips, "");
			}
			if (childQuestBtNode.HideUi.GetValueOrDefault())
			{
				this.AddTag(EBehaviorTreeTag.HideTrackExpression, "");
				this.AddTag(EBehaviorTreeTag.HideQuestUpdateTips, "");
				this.AddTag(EBehaviorTreeTag.HideInAllView, "");
			}
			if (childQuestBtNode.ShowNavigation.GetValueOrDefault())
			{
				this.AddTag(EBehaviorTreeTag.ShowNavigation, "");
				this.NavigationStyle = childQuestBtNode.NavigationStyle.GetValueOrDefault();
			}
			if (childQuestBtNode.AlwaysShowNavigation.GetValueOrDefault())
			{
				this.AddTag(EBehaviorTreeTag.AlwaysShowNavigation, "");
			}
			this.TrackTarget = childQuestBtNode.TrackTarget;
			this.TrackTextConfig = childQuestBtNode.TidTip;
			this.MultiTrackText = Singleton<PublicUtil>.Instance.GetConfigTextByKey(this.TrackTextConfig);
			this.ModifyTrackAreaTextConfig = childQuestBtNode.ModifyTrackAreaText;
			this.ShowTipBeforeEnterActions = childQuestBtNode.ShowTipBeforeEnterActions.GetValueOrDefault();
			this.TrackCustomBoard = childQuestBtNode.TrackCustomBoard;
			return true;
		}

		// Token: 0x0603BF1E RID: 245534 RVA: 0x00F32ECD File Offset: 0x00F310CD
		protected virtual void OnStart(ENodeStatusUpdateReason reason)
		{
		}

		// Token: 0x0603BF1F RID: 245535 RVA: 0x00F32ECF File Offset: 0x00F310CF
		protected virtual void OnEnd(bool bFinished)
		{
		}

		// Token: 0x0603BF20 RID: 245536 RVA: 0x00F32ED1 File Offset: 0x00F310D1
		protected virtual void AddEventsOnChildQuestStart()
		{
		}

		// Token: 0x0603BF21 RID: 245537 RVA: 0x00F32ED3 File Offset: 0x00F310D3
		protected virtual void RemoveEventsOnChildQuestEnd()
		{
		}

		// Token: 0x0603BF22 RID: 245538 RVA: 0x00F32ED8 File Offset: 0x00F310D8
		protected virtual void SubmitNode(GeneralLogicTreeNodeExtraInfo parkourInfo = null)
		{
			if (this.Blackboard.ContainTag(EBehaviorTreeTag.RollbackWaiting))
			{
				return;
			}
			if (this.Submitting)
			{
				return;
			}
			if (this.Blackboard.IsSuspend())
			{
				return;
			}
			if (!this.CheckCanSubmitAboutFocusMode())
			{
				this.BecauseOfFocusModeNoSubmit();
				return;
			}
			this.OnBeforeSubmit();
			ControllerBase<GeneralLogicTreeController>.Instance.RequestSubmitNode(this.Context, new Action<bool>(this.OnAfterSubmit), parkourInfo);
		}

		// Token: 0x0603BF23 RID: 245539 RVA: 0x00F32F3E File Offset: 0x00F3113E
		protected virtual void OnBeforeSubmit()
		{
			this.Submitting = true;
		}

		// Token: 0x0603BF24 RID: 245540 RVA: 0x00F32F47 File Offset: 0x00F31147
		protected virtual void OnAfterSubmit(bool submitSuccess)
		{
			this.Submitting = false;
		}

		// Token: 0x0603BF25 RID: 245541 RVA: 0x00F32F50 File Offset: 0x00F31150
		protected virtual bool CheckCanSubmitAboutFocusMode()
		{
			return true;
		}

		// Token: 0x0603BF26 RID: 245542 RVA: 0x00F32F53 File Offset: 0x00F31153
		protected virtual void BecauseOfFocusModeNoSubmit()
		{
		}

		// Token: 0x0603BF27 RID: 245543 RVA: 0x00F32F55 File Offset: 0x00F31155
		public List<int> GetCorrelativeEntities()
		{
			return this.CorrelativeEntities;
		}

		// Token: 0x04021AE4 RID: 137956
		public EChildQuest ChildQuestType = EChildQuest.CheckEntityState;

		// Token: 0x04021AE5 RID: 137957
		public int CustomTrackIconId;

		// Token: 0x04021AE6 RID: 137958
		protected bool Submitting;

		// Token: 0x04021AE7 RID: 137959
		protected ChildQuestNodeStatus ChildQuestStatus;

		// Token: 0x04021AE8 RID: 137960
		public ITrackAreaText ModifyTrackAreaTextConfig;

		// Token: 0x04021AE9 RID: 137961
		public ITrackCustomBoard TrackCustomBoard;
	}
}
