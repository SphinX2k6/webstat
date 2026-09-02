using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FA9 RID: 24489
	[NullableContext(1)]
	[Nullable(0)]
	public class DefaultTrackingRule : TrackingDisplayRuleBase
	{
		// Token: 0x17009A62 RID: 39522
		// (get) Token: 0x0603D898 RID: 252056 RVA: 0x00FAAC78 File Offset: 0x00FA8E78
		public override EMissionRuleId Id
		{
			get
			{
				return EMissionRuleId.Default;
			}
		}

		// Token: 0x17009A63 RID: 39523
		// (get) Token: 0x0603D899 RID: 252057 RVA: 0x00FAAC7B File Offset: 0x00FA8E7B
		public override bool Enabled
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17009A64 RID: 39524
		// (get) Token: 0x0603D89A RID: 252058 RVA: 0x00FAAC7E File Offset: 0x00FA8E7E
		public override int Priority
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0603D89B RID: 252059 RVA: 0x00FAAC84 File Offset: 0x00FA8E84
		public override EMissionItemView? CustomTypeCheck(IMissionItemViewShowData showData, ETreeTextExpressReason? reason = null)
		{
			EMissionItemView? result = null;
			EMissionItemViewDataSource dataSource = showData.DataSource;
			if (dataSource != EMissionItemViewDataSource.BehaviorTree)
			{
				if (dataSource == EMissionItemViewDataSource.FishingEntrust)
				{
					result = new EMissionItemView?(EMissionItemView.SecondRow);
				}
			}
			else
			{
				long id = showData.Id;
				BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(id), false);
				if (behaviorTree == null || behaviorTree.BtType == BtType.Invalid)
				{
					return null;
				}
				if (behaviorTree.BtType == BtType.Quest || behaviorTree.GetBlackBoard().IsTrackBoundToParent)
				{
					result = new EMissionItemView?((reason.GetValueOrDefault() == ETreeTextExpressReason.InRange) ? EMissionItemView.SecondRow : EMissionItemView.FirstRow);
				}
				else
				{
					result = new EMissionItemView?(EMissionItemView.SecondRow);
				}
			}
			return result;
		}

		// Token: 0x0603D89C RID: 252060 RVA: 0x00FAAD18 File Offset: 0x00FA8F18
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
