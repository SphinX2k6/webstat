using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CE5 RID: 23781
	public class GuideFinishBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BF69 RID: 245609 RVA: 0x00F34270 File Offset: 0x00F32470
		public GuideFinishBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BF6A RID: 245610 RVA: 0x00F3427C File Offset: 0x00F3247C
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
			IGuideCondition guideCondition = childQuestBtNode.Condition as IGuideCondition;
			if (guideCondition == null)
			{
				return false;
			}
			this.GuideGroupId = guideCondition.GuideGroupId;
			return true;
		}

		// Token: 0x0603BF6B RID: 245611 RVA: 0x00F342BE File Offset: 0x00F324BE
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.GuideGroupId = 0;
		}

		// Token: 0x0603BF6C RID: 245612 RVA: 0x00F342D0 File Offset: 0x00F324D0
		protected override void AddEventsOnChildQuestStart()
		{
			base.AddEventsOnChildQuestStart();
			Singleton<EventSystem>.Instance.Add(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideGroupFinish));
			Singleton<EventSystem>.Instance.Add(EEventName.ComboTeachingFinish, new Action(this.OnGuideGroupFinishByComboTeaching));
			if (ModelBase<GuideModel>.Instance.IsGroupFinished(this.GuideGroupId).GetValueOrDefault())
			{
				this.SubmitNode(null);
			}
		}

		// Token: 0x0603BF6D RID: 245613 RVA: 0x00F3433C File Offset: 0x00F3253C
		protected override void RemoveEventsOnChildQuestEnd()
		{
			if (Singleton<EventSystem>.Instance.Has<int>(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideGroupFinish)))
			{
				Singleton<EventSystem>.Instance.Remove<int>(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideGroupFinish));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.ComboTeachingFinish, new Action(this.OnGuideGroupFinishByComboTeaching)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.ComboTeachingFinish, new Action(this.OnGuideGroupFinishByComboTeaching));
			}
			base.RemoveEventsOnChildQuestEnd();
		}

		// Token: 0x0603BF6E RID: 245614 RVA: 0x00F343C1 File Offset: 0x00F325C1
		private void OnGuideGroupFinish(int guideGroupId)
		{
			if (this.Submitting)
			{
				return;
			}
			if (guideGroupId == this.GuideGroupId)
			{
				this.SubmitNode(null);
			}
		}

		// Token: 0x0603BF6F RID: 245615 RVA: 0x00F343DC File Offset: 0x00F325DC
		private void OnGuideGroupFinishByComboTeaching()
		{
			if (this.Submitting)
			{
				return;
			}
			this.SubmitNode(null);
		}

		// Token: 0x04021B06 RID: 137990
		private int GuideGroupId;
	}
}
