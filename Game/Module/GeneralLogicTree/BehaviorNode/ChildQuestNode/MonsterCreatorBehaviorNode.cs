using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode
{
	// Token: 0x02005CE9 RID: 23785
	[NullableContext(1)]
	[Nullable(0)]
	public class MonsterCreatorBehaviorNode : ChildQuestNodeBase
	{
		// Token: 0x0603BF85 RID: 245637 RVA: 0x00F34912 File Offset: 0x00F32B12
		public MonsterCreatorBehaviorNode(int nodeId) : base(nodeId)
		{
		}

		// Token: 0x17009853 RID: 38995
		// (get) Token: 0x0603BF86 RID: 245638 RVA: 0x00F34926 File Offset: 0x00F32B26
		protected override List<int> CorrelativeEntities
		{
			get
			{
				return this.InnerCorrelativeEntities;
			}
		}

		// Token: 0x0603BF87 RID: 245639 RVA: 0x00F34930 File Offset: 0x00F32B30
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
			IMonsterCreatorQuestCondition monsterCreatorQuestCondition = childQuestBtNode.Condition as IMonsterCreatorQuestCondition;
			if (monsterCreatorQuestCondition == null || monsterCreatorQuestCondition.MonsterCreatorEntityIds == null)
			{
				return false;
			}
			this.TrackTextRuleInner = ENodeTrackTextRule.Progress;
			this.InnerCorrelativeEntities.Clear();
			this.InnerCorrelativeEntities.AddRange(monsterCreatorQuestCondition.MonsterCreatorEntityIds);
			this.ShowMonsterMergedHpBar = monsterCreatorQuestCondition.ShowMonsterMergedHpBar.GetValueOrDefault();
			this.TidMonsterGroupName = monsterCreatorQuestCondition.TidMonsterGroupName;
			this.KilledCount = 0;
			return true;
		}

		// Token: 0x0603BF88 RID: 245640 RVA: 0x00F349B8 File Offset: 0x00F32BB8
		protected override bool OnUpdateProgress(ChildQuestNodeProgress progress)
		{
			if (progress.MonsterCreator == null)
			{
				return false;
			}
			this.KilledCount = 0;
			this.TotalCount = progress.MonsterCreator.TotalNum;
			foreach (MonsterCreatorProgressSlot monsterCreatorProgressSlot in progress.MonsterCreator.Slots)
			{
				this.KilledCount += monsterCreatorProgressSlot.KillMonIds.Count;
				Singleton<EventSystem>.Instance.Emit<int, IReadOnlyList<int>>(EEventName.GeneralLogicTreeEntityKilled, base.NodeId, monsterCreatorProgressSlot.KillMonIds);
			}
			return true;
		}

		// Token: 0x0603BF89 RID: 245641 RVA: 0x00F34A5C File Offset: 0x00F32C5C
		public override string GetProgress()
		{
			return this.KilledCount.ToString();
		}

		// Token: 0x0603BF8A RID: 245642 RVA: 0x00F34A69 File Offset: 0x00F32C69
		public override string GetProgressMax()
		{
			return this.TotalCount.ToString();
		}

		// Token: 0x0603BF8B RID: 245643 RVA: 0x00F34A76 File Offset: 0x00F32C76
		public bool GetShowMonsterMergedHpBar()
		{
			return this.ShowMonsterMergedHpBar;
		}

		// Token: 0x0603BF8C RID: 245644 RVA: 0x00F34A7E File Offset: 0x00F32C7E
		[NullableContext(2)]
		public string GetTidMonsterGroupName()
		{
			return this.TidMonsterGroupName;
		}

		// Token: 0x0603BF8D RID: 245645 RVA: 0x00F34A86 File Offset: 0x00F32C86
		public List<int> GetTest()
		{
			return this.InnerCorrelativeEntities;
		}

		// Token: 0x04021B0F RID: 137999
		private int KilledCount;

		// Token: 0x04021B10 RID: 138000
		private int TotalCount;

		// Token: 0x04021B11 RID: 138001
		private readonly List<int> InnerCorrelativeEntities = new List<int>();

		// Token: 0x04021B12 RID: 138002
		private bool ShowMonsterMergedHpBar;

		// Token: 0x04021B13 RID: 138003
		[Nullable(2)]
		private string TidMonsterGroupName;
	}
}
