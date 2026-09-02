using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CF0 RID: 23792
	public class RhythmGameNode : ChildQuestNodeBase
	{
		// Token: 0x0603BFB5 RID: 245685 RVA: 0x00F35FDA File Offset: 0x00F341DA
		public RhythmGameNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BFB6 RID: 245686 RVA: 0x00F35FE4 File Offset: 0x00F341E4
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
			if (childQuestBtNode.Condition.Type != EChildQuest.FinishRhythmSpaceship)
			{
				return false;
			}
			Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmGameFinish, new Action(this.OnRhythmGameFinish));
			return true;
		}

		// Token: 0x0603BFB7 RID: 245687 RVA: 0x00F36038 File Offset: 0x00F34238
		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnRhythmGameFinish, new Action(this.OnRhythmGameFinish)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmGameFinish, new Action(this.OnRhythmGameFinish));
			}
		}

		// Token: 0x0603BFB8 RID: 245688 RVA: 0x00F36084 File Offset: 0x00F34284
		private void OnRhythmGameFinish()
		{
			this.SubmitNode(null);
		}

		// Token: 0x0603BFB9 RID: 245689 RVA: 0x00F36090 File Offset: 0x00F34290
		protected override void OnAfterSubmit(bool submitSuccess)
		{
			base.OnAfterSubmit(submitSuccess);
			if (submitSuccess && Singleton<EventSystem>.Instance.Has(EEventName.OnRhythmGameFinish, new Action(this.OnRhythmGameFinish)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmGameFinish, new Action(this.OnRhythmGameFinish));
			}
		}
	}
}
