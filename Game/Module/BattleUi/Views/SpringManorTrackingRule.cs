using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FAB RID: 24491
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorTrackingRule : TrackingDisplayRuleBase
	{
		// Token: 0x17009A68 RID: 39528
		// (get) Token: 0x0603D8A4 RID: 252068 RVA: 0x00FAAE5A File Offset: 0x00FA905A
		public override EMissionRuleId Id
		{
			get
			{
				return EMissionRuleId.SpringManor;
			}
		}

		// Token: 0x17009A69 RID: 39529
		// (get) Token: 0x0603D8A5 RID: 252069 RVA: 0x00FAAE5D File Offset: 0x00FA905D
		public override bool Enabled
		{
			get
			{
				return ModelBase<SpringManorModel>.Instance.CheckInInstance();
			}
		}

		// Token: 0x17009A6A RID: 39530
		// (get) Token: 0x0603D8A6 RID: 252070 RVA: 0x00FAAE69 File Offset: 0x00FA9069
		public override int Priority
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x0603D8A7 RID: 252071 RVA: 0x00FAAE6C File Offset: 0x00FA906C
		public override EMissionItemView? CustomTypeCheck(IMissionItemViewShowData showData, ETreeTextExpressReason? reason = null)
		{
			BehaviorTreeViewShowData behaviorTreeViewShowData = showData as BehaviorTreeViewShowData;
			if (behaviorTreeViewShowData == null)
			{
				return null;
			}
			long id = showData.Id;
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(id), false);
			if (behaviorTree == null || behaviorTree.BtType == BtType.Invalid)
			{
				return null;
			}
			if (behaviorTree.BtType != BtType.Quest && !behaviorTree.GetBlackBoard().IsTrackBoundToParent)
			{
				return new EMissionItemView?(EMissionItemView.ThirdRow);
			}
			if (ModelBase<SpringManorModel>.Instance.IsSubQuest(behaviorTreeViewShowData.TreeConfigId))
			{
				return new EMissionItemView?(EMissionItemView.SecondRow);
			}
			if (reason.GetValueOrDefault() == ETreeTextExpressReason.InRange)
			{
				return new EMissionItemView?(EMissionItemView.ThirdRow);
			}
			return new EMissionItemView?(EMissionItemView.FirstRow);
		}

		// Token: 0x0603D8A8 RID: 252072 RVA: 0x00FAAF08 File Offset: 0x00FA9108
		public override void SortShowData(List<IMissionItemViewShowData> showData)
		{
			showData.Sort(delegate(IMissionItemViewShowData a, IMissionItemViewShowData b)
			{
				if (a.DataSource != b.DataSource)
				{
					return a.DataSource - b.DataSource;
				}
				return a.ShowPriority - b.ShowPriority;
			});
		}
	}
}
