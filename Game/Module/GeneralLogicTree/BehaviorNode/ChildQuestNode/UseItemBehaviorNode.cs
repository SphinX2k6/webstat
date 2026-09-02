using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CF8 RID: 23800
	[NullableContext(1)]
	[Nullable(0)]
	public class UseItemBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BFEC RID: 245740 RVA: 0x00F36CF5 File Offset: 0x00F34EF5
		public UseItemBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BFED RID: 245741 RVA: 0x00F36D00 File Offset: 0x00F34F00
		protected override bool OnCreate(IBtNode config)
		{
			IChildQuestBtNode childQuestBtNode = config as IChildQuestBtNode;
			if (childQuestBtNode == null)
			{
				return false;
			}
			if (!base.OnCreate(config))
			{
				return false;
			}
			if (childQuestBtNode.Condition.Type != EChildQuest.UseItem)
			{
				return false;
			}
			this.TrackTextRuleInner = ENodeTrackTextRule.Progress;
			return true;
		}

		// Token: 0x0603BFEE RID: 245742 RVA: 0x00F36D3D File Offset: 0x00F34F3D
		protected override bool OnUpdateProgress(ChildQuestNodeProgress progress)
		{
			if (progress.UseItem == null)
			{
				return false;
			}
			this.Progress = progress.UseItem;
			return true;
		}

		// Token: 0x0603BFEF RID: 245743 RVA: 0x00F36D58 File Offset: 0x00F34F58
		public override string GetProgress()
		{
			UseItemProgress progress = this.Progress;
			return ((progress != null) ? progress.Count.ToString() : null) ?? "0";
		}

		// Token: 0x04021B4E RID: 138062
		[Nullable(2)]
		private UseItemProgress Progress;
	}
}
