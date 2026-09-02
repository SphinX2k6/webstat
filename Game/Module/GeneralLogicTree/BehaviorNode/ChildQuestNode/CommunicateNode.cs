using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CDF RID: 23775
	public class CommunicateNode : ChildQuestNodeBase
	{
		// Token: 0x0603BF34 RID: 245556 RVA: 0x00F3318B File Offset: 0x00F3138B
		public CommunicateNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BF35 RID: 245557 RVA: 0x00F33194 File Offset: 0x00F31394
		[NullableContext(1)]
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return false;
			}
			if (!base.OnCreate(nodeConfig))
			{
				return false;
			}
			IReceiveTelecomChildQuestCondition receiveTelecomChildQuestCondition = childQuestBtNode.Condition as IReceiveTelecomChildQuestCondition;
			if (receiveTelecomChildQuestCondition == null)
			{
				return false;
			}
			this.CommunicateId = receiveTelecomChildQuestCondition.TelecomId;
			return true;
		}

		// Token: 0x0603BF36 RID: 245558 RVA: 0x00F331D8 File Offset: 0x00F313D8
		protected override void OnStart(ENodeStatusUpdateReason reason)
		{
			base.OnStart(reason);
			this.AddedRedDot = false;
			Singleton<EventSystem>.Instance.Add<int>(EEventName.CommunicateFinished, new Action<int>(this.OnCommunicateFinished));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.CommunicateAgain, new Action<int>(this.OnCommunicateAgain));
			Singleton<EventSystem>.Instance.Add<BtType, long?>(EEventName.OnLogicTreeTrackUpdate, new Action<BtType, long?>(this.OnLogicTreeTrackUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.OnBattleViewShow));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Add(EEventName.ChangeMode, new Action(this.OnChangeMode));
			if (this.CheckCanSubmitAboutFocusMode())
			{
				this.OpenCommunicate();
			}
		}

		// Token: 0x0603BF37 RID: 245559 RVA: 0x00F332A8 File Offset: 0x00F314A8
		protected override void OnEnd(bool bFinished)
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.CommunicateFinished, new Action<int>(this.OnCommunicateFinished));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.CommunicateAgain, new Action<int>(this.OnCommunicateAgain));
			Singleton<EventSystem>.Instance.Remove<BtType, long?>(EEventName.OnLogicTreeTrackUpdate, new Action<BtType, long?>(this.OnLogicTreeTrackUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.OnBattleViewShow));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Remove(EEventName.ChangeMode, new Action(this.OnChangeMode));
			base.OnEnd(bFinished);
		}

		// Token: 0x0603BF38 RID: 245560 RVA: 0x00F33361 File Offset: 0x00F31561
		private void OnCommunicateFinished(int communicateId)
		{
			if (communicateId != this.CommunicateId)
			{
				return;
			}
			this.Blackboard.RemoveTag(EBehaviorTreeTag.CanCommunicateAgain, "");
			this.SubmitNode(null);
		}

		// Token: 0x0603BF39 RID: 245561 RVA: 0x00F33385 File Offset: 0x00F31585
		private void OnCommunicateAgain(int communicateId)
		{
			if (communicateId != this.CommunicateId)
			{
				return;
			}
			this.OpenCommunicate();
		}

		// Token: 0x0603BF3A RID: 245562 RVA: 0x00F33398 File Offset: 0x00F31598
		private void OnLogicTreeTrackUpdate(BtType btType, long? treeIncId)
		{
			long? num = treeIncId;
			long treeIncId2 = base.TreeIncId;
			if (!(num.GetValueOrDefault() == treeIncId2 & num != null))
			{
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView))
			{
				return;
			}
			this.TriggerTrack = this.Blackboard.IsTracking;
		}

		// Token: 0x0603BF3B RID: 245563 RVA: 0x00F333E6 File Offset: 0x00F315E6
		private void OnBattleViewShow()
		{
			if (this.TriggerTrack && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.CommunicateView))
			{
				this.OpenCommunicate();
				this.TriggerTrack = false;
			}
		}

		// Token: 0x0603BF3C RID: 245564 RVA: 0x00F33410 File Offset: 0x00F31610
		private void OnCloseView(EUiViewName viewName, int _)
		{
			if (viewName != EUiViewName.CommunicateView)
			{
				return;
			}
			if (this.ChildQuestStatus != ChildQuestNodeStatus.CqnsProgress)
			{
				return;
			}
			this.Blackboard.AddTag(EBehaviorTreeTag.CanCommunicateAgain, "");
			if (!this.AddedRedDot && this.BtType == BtType.Quest)
			{
				this.AddedRedDot = true;
				ControllerBase<QuestNewController>.Instance.RedDotRequest(base.TreeConfigId, EQuestRedDotOperate.Add);
			}
		}

		// Token: 0x0603BF3D RID: 245565 RVA: 0x00F3346F File Offset: 0x00F3166F
		private void OpenCommunicate()
		{
			this.Blackboard.RemoveTag(EBehaviorTreeTag.CanCommunicateAgain, "");
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommunicateView, this.CommunicateId, null);
		}

		// Token: 0x0603BF3E RID: 245566 RVA: 0x00F3349D File Offset: 0x00F3169D
		private void OnChangeMode()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.CommunicateView, null);
		}

		// Token: 0x0603BF3F RID: 245567 RVA: 0x00F334AF File Offset: 0x00F316AF
		protected override bool CheckCanSubmitAboutFocusMode()
		{
			return this.BtType != BtType.Quest || !ModelBase<QuestNewModel>.Instance.CheckNeedBanQuestPushByFocusMode(base.TreeConfigId);
		}

		// Token: 0x0603BF40 RID: 245568 RVA: 0x00F334CF File Offset: 0x00F316CF
		protected override void BecauseOfFocusModeNoSubmit()
		{
			this.TriggerTrack = this.Blackboard.IsTracking;
		}

		// Token: 0x04021AED RID: 137965
		public int CommunicateId;

		// Token: 0x04021AEE RID: 137966
		private bool TriggerTrack;

		// Token: 0x04021AEF RID: 137967
		private bool AddedRedDot;
	}
}
