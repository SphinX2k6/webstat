using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CEF RID: 23791
	public class ReadPhoneMessageBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BFAE RID: 245678 RVA: 0x00F35ED8 File Offset: 0x00F340D8
		public ReadPhoneMessageBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BFAF RID: 245679 RVA: 0x00F35EE4 File Offset: 0x00F340E4
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
			IReadPhoneMessageQuestCondition readPhoneMessageQuestCondition = childQuestBtNode.Condition as IReadPhoneMessageQuestCondition;
			if (readPhoneMessageQuestCondition == null)
			{
				return false;
			}
			int valueOrDefault = readPhoneMessageQuestCondition.PhoneMessageId.GetValueOrDefault();
			if (valueOrDefault == 0)
			{
				return false;
			}
			this.ShortMessageId = valueOrDefault;
			return true;
		}

		// Token: 0x0603BFB0 RID: 245680 RVA: 0x00F35F35 File Offset: 0x00F34135
		protected void OnStart()
		{
			this.SubmitFinished = false;
			if (ModelBase<PhoneMsgModel>.Instance.IsShortMsgRead(this.ShortMessageId))
			{
				this.SubmitNode(null);
			}
		}

		// Token: 0x0603BFB1 RID: 245681 RVA: 0x00F35F57 File Offset: 0x00F34157
		protected override void AddEventsOnChildQuestStart()
		{
			base.AddEventsOnChildQuestStart();
			Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.OnPhoneMsgReadProgressUpdate, new Action<int, int, bool>(this.OnPhoneMsgReadProgressUpdate));
		}

		// Token: 0x0603BFB2 RID: 245682 RVA: 0x00F35F7B File Offset: 0x00F3417B
		protected override void RemoveEventsOnChildQuestEnd()
		{
			base.RemoveEventsOnChildQuestEnd();
			Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.OnPhoneMsgReadProgressUpdate, new Action<int, int, bool>(this.OnPhoneMsgReadProgressUpdate));
		}

		// Token: 0x0603BFB3 RID: 245683 RVA: 0x00F35F9F File Offset: 0x00F3419F
		private void OnPhoneMsgReadProgressUpdate(int shortMsgId, int newProgress, bool isFinish)
		{
			if (shortMsgId != this.ShortMessageId)
			{
				return;
			}
			if (this.Submitting || this.SubmitFinished)
			{
				return;
			}
			if (!isFinish)
			{
				return;
			}
			this.SubmitNode(null);
		}

		// Token: 0x0603BFB4 RID: 245684 RVA: 0x00F35FC7 File Offset: 0x00F341C7
		protected override void OnAfterSubmit(bool submitSuccess)
		{
			base.OnAfterSubmit(submitSuccess);
			if (submitSuccess)
			{
				this.SubmitFinished = true;
			}
		}

		// Token: 0x04021B38 RID: 138040
		private bool SubmitFinished;

		// Token: 0x04021B39 RID: 138041
		private int ShortMessageId;
	}
}
