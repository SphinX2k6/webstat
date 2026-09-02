using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CDB RID: 23771
	[NullableContext(1)]
	[Nullable(0)]
	public class CheckLevelPlayBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BF05 RID: 245509 RVA: 0x00F32898 File Offset: 0x00F30A98
		public CheckLevelPlayBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BF06 RID: 245510 RVA: 0x00F328A4 File Offset: 0x00F30AA4
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
			if (childQuestBtNode.Condition.Type != EChildQuest.CheckLevelPlay)
			{
				return false;
			}
			this.Progress = 0;
			this.TrackTextRuleInner = ENodeTrackTextRule.Progress;
			return true;
		}

		// Token: 0x0603BF07 RID: 245511 RVA: 0x00F328E8 File Offset: 0x00F30AE8
		protected override bool OnUpdateProgress(ChildQuestNodeProgress progress)
		{
			this.Progress = progress.LevelPlayCount;
			return true;
		}

		// Token: 0x0603BF08 RID: 245512 RVA: 0x00F328F7 File Offset: 0x00F30AF7
		public override string GetProgress()
		{
			return this.Progress.ToString();
		}

		// Token: 0x04021AE1 RID: 137953
		private int Progress;
	}
}
