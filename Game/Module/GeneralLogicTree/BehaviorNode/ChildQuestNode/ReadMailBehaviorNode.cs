using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CEE RID: 23790
	[NullableContext(1)]
	[Nullable(0)]
	public class ReadMailBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BFA6 RID: 245670 RVA: 0x00F35DF4 File Offset: 0x00F33FF4
		public ReadMailBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BFA7 RID: 245671 RVA: 0x00F35E00 File Offset: 0x00F34000
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
			IReadMailCondition readMailCondition = childQuestBtNode.Condition as IReadMailCondition;
			if (readMailCondition == null)
			{
				return false;
			}
			this.MailId = readMailCondition.MailId;
			return true;
		}

		// Token: 0x0603BFA8 RID: 245672 RVA: 0x00F35E42 File Offset: 0x00F34042
		protected void OnStart()
		{
			this.SubmitFinished = false;
		}

		// Token: 0x0603BFA9 RID: 245673 RVA: 0x00F35E4B File Offset: 0x00F3404B
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.MailId = 0;
		}

		// Token: 0x0603BFAA RID: 245674 RVA: 0x00F35E5A File Offset: 0x00F3405A
		protected override void AddEventsOnChildQuestStart()
		{
			base.AddEventsOnChildQuestStart();
			Singleton<EventSystem>.Instance.Add<string, int>(EEventName.SelectedMail, new Action<string, int>(this.OnReadMail));
		}

		// Token: 0x0603BFAB RID: 245675 RVA: 0x00F35E7E File Offset: 0x00F3407E
		protected override void RemoveEventsOnChildQuestEnd()
		{
			Singleton<EventSystem>.Instance.Remove<string, int>(EEventName.SelectedMail, new Action<string, int>(this.OnReadMail));
			base.RemoveEventsOnChildQuestEnd();
		}

		// Token: 0x0603BFAC RID: 245676 RVA: 0x00F35EA2 File Offset: 0x00F340A2
		private void OnReadMail(string mailId, int configId)
		{
			if (this.Submitting || this.SubmitFinished)
			{
				return;
			}
			if (configId == this.MailId)
			{
				this.SubmitNode(null);
			}
		}

		// Token: 0x0603BFAD RID: 245677 RVA: 0x00F35EC5 File Offset: 0x00F340C5
		protected override void OnAfterSubmit(bool submitSuccess)
		{
			base.OnAfterSubmit(submitSuccess);
			if (submitSuccess)
			{
				this.SubmitFinished = true;
			}
		}

		// Token: 0x04021B36 RID: 138038
		private bool SubmitFinished;

		// Token: 0x04021B37 RID: 138039
		private int MailId;
	}
}
