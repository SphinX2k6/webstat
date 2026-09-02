using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CDC RID: 23772
	[NullableContext(1)]
	[Nullable(0)]
	public class CheckPlayerInputBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BF09 RID: 245513 RVA: 0x00F32904 File Offset: 0x00F30B04
		public CheckPlayerInputBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BF0A RID: 245514 RVA: 0x00F32910 File Offset: 0x00F30B10
		protected override bool OnCreate(IBtNode nodeConfig)
		{
			if (!base.OnCreate(nodeConfig))
			{
				return false;
			}
			IChildQuestBtNode childQuestBtNode = nodeConfig as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return false;
			}
			ICheckPlayerInputCondition checkPlayerInputCondition = childQuestBtNode.Condition as ICheckPlayerInputCondition;
			if (checkPlayerInputCondition == null)
			{
				return false;
			}
			ICheckPlayerPressButton checkInput = checkPlayerInputCondition.CheckInput;
			if (checkInput == null)
			{
				return false;
			}
			this.ButtonType = checkInput.ButtonType;
			EPlayerButtonType buttonType = this.ButtonType;
			if (buttonType != EPlayerButtonType.ChallengeAgain)
			{
				if (buttonType == EPlayerButtonType.ExitChallenge)
				{
					this.ActionName = "玩法放弃";
				}
			}
			else
			{
				this.ActionName = "重新挑战";
			}
			return true;
		}

		// Token: 0x0603BF0B RID: 245515 RVA: 0x00F32988 File Offset: 0x00F30B88
		protected override void AddEventsOnChildQuestStart()
		{
			base.AddEventsOnChildQuestStart();
			if (string.IsNullOrEmpty(this.ActionName))
			{
				return;
			}
			ControllerBase<InputDistributeController>.Instance.UnBindAction(this.ActionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			ControllerBase<InputDistributeController>.Instance.BindAction(this.ActionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			Singleton<EventSystem>.Instance.Add<string>(EEventName.ChallengeAgain, new Action<string>(this.OnChallengeAgain));
			if (this.ActionName == "重新挑战")
			{
				this.Blackboard.AddTag(EBehaviorTreeTag.CanChallengeAgain, "");
			}
		}

		// Token: 0x0603BF0C RID: 245516 RVA: 0x00F32A24 File Offset: 0x00F30C24
		protected override void RemoveEventsOnChildQuestEnd()
		{
			base.RemoveEventsOnChildQuestEnd();
			if (string.IsNullOrEmpty(this.ActionName))
			{
				return;
			}
			ControllerBase<InputDistributeController>.Instance.UnBindAction(this.ActionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			Singleton<EventSystem>.Instance.Remove<string>(EEventName.ChallengeAgain, new Action<string>(this.OnChallengeAgain));
			if (this.ActionName == "重新挑战")
			{
				this.Blackboard.RemoveTag(EBehaviorTreeTag.CanChallengeAgain, "");
			}
		}

		// Token: 0x0603BF0D RID: 245517 RVA: 0x00F32AA1 File Offset: 0x00F30CA1
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification ii)
		{
			if (actionType != InputDistributeDefine.EActionType.Release)
			{
				return;
			}
			this.OnChallengeAgain(actionName);
		}

		// Token: 0x0603BF0E RID: 245518 RVA: 0x00F32AAF File Offset: 0x00F30CAF
		protected void OnChallengeAgain(string actionName)
		{
			if (this.Submitting)
			{
				return;
			}
			if (this.ActionName != actionName)
			{
				return;
			}
			this.SubmitNode(null);
		}

		// Token: 0x04021AE2 RID: 137954
		private EPlayerButtonType ButtonType;

		// Token: 0x04021AE3 RID: 137955
		[Nullable(2)]
		private string ActionName;
	}
}
