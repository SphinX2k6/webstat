using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CE7 RID: 23783
	[NullableContext(1)]
	[Nullable(0)]
	public class KillBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BF7A RID: 245626 RVA: 0x00F34720 File Offset: 0x00F32920
		public KillBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x17009852 RID: 38994
		// (get) Token: 0x0603BF7B RID: 245627 RVA: 0x00F34734 File Offset: 0x00F32934
		protected override List<int> CorrelativeEntities
		{
			get
			{
				return this.InnerCorrelativeEntities;
			}
		}

		// Token: 0x0603BF7C RID: 245628 RVA: 0x00F3473C File Offset: 0x00F3293C
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
			IKillChildQuestCondition killChildQuestCondition = childQuestBtNode.Condition as IKillChildQuestCondition;
			if (killChildQuestCondition == null)
			{
				return false;
			}
			this.TrackTextRuleInner = ENodeTrackTextRule.Progress;
			this.MaxCount = killChildQuestCondition.ExistTargets.Count + killChildQuestCondition.TargetsToAwake.Count;
			this.InnerCorrelativeEntities.Clear();
			this.InnerCorrelativeEntities.EnsureCapacity(this.MaxCount);
			this.InnerCorrelativeEntities.AddRange(killChildQuestCondition.ExistTargets);
			this.InnerCorrelativeEntities.AddRange(killChildQuestCondition.TargetsToAwake);
			return true;
		}

		// Token: 0x0603BF7D RID: 245629 RVA: 0x00F347D5 File Offset: 0x00F329D5
		protected override bool OnUpdateProgress(ChildQuestNodeProgress progress)
		{
			if (progress.Kill == null)
			{
				return false;
			}
			this.Progress = progress.Kill;
			Singleton<EventSystem>.Instance.Emit<int, IReadOnlyList<int>>(EEventName.GeneralLogicTreeEntityKilled, base.NodeId, this.Progress.MonId);
			return true;
		}

		// Token: 0x0603BF7E RID: 245630 RVA: 0x00F34810 File Offset: 0x00F32A10
		public override string GetProgress()
		{
			if (base.IsSuccess)
			{
				return this.GetProgressMax();
			}
			KillProgress progress = this.Progress;
			string text;
			if (progress == null)
			{
				text = null;
			}
			else
			{
				RepeatedField<int> monId = progress.MonId;
				text = ((monId != null) ? monId.Count.ToString() : null);
			}
			return text ?? "0";
		}

		// Token: 0x0603BF7F RID: 245631 RVA: 0x00F3485C File Offset: 0x00F32A5C
		public override string GetProgressMax()
		{
			if (this.Progress == null)
			{
				return this.MaxCount.ToString();
			}
			return this.Progress.TotalNum.ToString();
		}

		// Token: 0x04021B0B RID: 137995
		[Nullable(2)]
		private KillProgress Progress;

		// Token: 0x04021B0C RID: 137996
		private readonly List<int> InnerCorrelativeEntities = new List<int>();

		// Token: 0x04021B0D RID: 137997
		private int MaxCount;
	}
}
