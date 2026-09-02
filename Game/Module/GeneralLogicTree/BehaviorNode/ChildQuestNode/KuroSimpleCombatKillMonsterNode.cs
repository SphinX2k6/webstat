using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CE8 RID: 23784
	[NullableContext(1)]
	[Nullable(0)]
	public class KuroSimpleCombatKillMonsterNode : ChildQuestNodeBase
	{
		// Token: 0x0603BF80 RID: 245632 RVA: 0x00F34890 File Offset: 0x00F32A90
		public KuroSimpleCombatKillMonsterNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x0603BF81 RID: 245633 RVA: 0x00F3489C File Offset: 0x00F32A9C
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
			if (childQuestBtNode.Condition.Type != EChildQuest.FinishKuroSimpleCombatKillMonster)
			{
				return false;
			}
			this.CurrentKillNum = 0;
			this.TrackTextRuleInner = ENodeTrackTextRule.Progress;
			return true;
		}

		// Token: 0x0603BF82 RID: 245634 RVA: 0x00F348E0 File Offset: 0x00F32AE0
		protected override bool OnUpdateProgress(ChildQuestNodeProgress progress)
		{
			if (progress.GpuMonster == null)
			{
				return false;
			}
			this.CurrentKillNum = progress.GpuMonster.CurKillNum;
			return true;
		}

		// Token: 0x0603BF83 RID: 245635 RVA: 0x00F348FE File Offset: 0x00F32AFE
		public override string GetProgress()
		{
			return this.CurrentKillNum.ToString();
		}

		// Token: 0x0603BF84 RID: 245636 RVA: 0x00F3490B File Offset: 0x00F32B0B
		public override string GetProgressMax()
		{
			return "";
		}

		// Token: 0x04021B0E RID: 137998
		private int CurrentKillNum;
	}
}
