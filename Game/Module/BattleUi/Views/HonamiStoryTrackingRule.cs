using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FAA RID: 24490
	[NullableContext(1)]
	[Nullable(0)]
	internal class HonamiStoryTrackingRule : TrackingDisplayRuleBase
	{
		// Token: 0x17009A65 RID: 39525
		// (get) Token: 0x0603D89E RID: 252062 RVA: 0x00FAAD47 File Offset: 0x00FA8F47
		public override EMissionRuleId Id
		{
			get
			{
				return EMissionRuleId.HonamiStory;
			}
		}

		// Token: 0x17009A66 RID: 39526
		// (get) Token: 0x0603D89F RID: 252063 RVA: 0x00FAAD4A File Offset: 0x00FA8F4A
		public override bool Enabled
		{
			get
			{
				return HonamiStoryUtil.CheckHonamiQuestOpen();
			}
		}

		// Token: 0x17009A67 RID: 39527
		// (get) Token: 0x0603D8A0 RID: 252064 RVA: 0x00FAAD51 File Offset: 0x00FA8F51
		public override int Priority
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x0603D8A1 RID: 252065 RVA: 0x00FAAD54 File Offset: 0x00FA8F54
		public override EMissionItemView? CustomTypeCheck(IMissionItemViewShowData showData, ETreeTextExpressReason? reason = null)
		{
			BehaviorTreeViewShowData behaviorTreeViewShowData = showData as BehaviorTreeViewShowData;
			if (behaviorTreeViewShowData == null)
			{
				return null;
			}
			long id = showData.Id;
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(id), false);
			int treeConfigId = behaviorTreeViewShowData.TreeConfigId;
			if (behaviorTree == null || behaviorTree.BtType == BtType.Invalid || behaviorTree.BtType == BtType.Quest)
			{
				return null;
			}
			int curAreaId = ModelBase<HonamiStoryModel>.Instance.CurAreaId;
			HonamiStoryArea? honamiStoryAreaConfig = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryAreaConfig(curAreaId);
			if (((honamiStoryAreaConfig != null) ? honamiStoryAreaConfig.GetValueOrDefault().MainBTId : 0) == treeConfigId)
			{
				return new EMissionItemView?(EMissionItemView.SecondRow);
			}
			return new EMissionItemView?(EMissionItemView.ThirdRow);
		}

		// Token: 0x0603D8A2 RID: 252066 RVA: 0x00FAADFC File Offset: 0x00FA8FFC
		public override void SortShowData(List<IMissionItemViewShowData> showData)
		{
			HonamiStoryQuestDataBase curTrackTaskData = ModelBase<HonamiStoryModel>.Instance.CurTrackTaskData;
			global::LevelPlayInfo levelPlayInfo = (curTrackTaskData != null) ? curTrackTaskData.GetLevelPlayInfo() : null;
			int? configId = (levelPlayInfo != null) ? levelPlayInfo.TreeConfigId : null;
			showData.Sort(delegate(IMissionItemViewShowData a, IMissionItemViewShowData b)
			{
				if (a.DataSource != b.DataSource)
				{
					return a.DataSource - b.DataSource;
				}
				BehaviorTreeViewShowData behaviorTreeViewShowData = a as BehaviorTreeViewShowData;
				int? configId;
				if (behaviorTreeViewShowData != null)
				{
					int treeConfigId = behaviorTreeViewShowData.TreeConfigId;
					configId = configId;
					if (treeConfigId == configId.GetValueOrDefault() & configId != null)
					{
						return 1;
					}
				}
				BehaviorTreeViewShowData behaviorTreeViewShowData2 = b as BehaviorTreeViewShowData;
				if (behaviorTreeViewShowData2 != null)
				{
					int treeConfigId2 = behaviorTreeViewShowData2.TreeConfigId;
					configId = configId;
					if (treeConfigId2 == configId.GetValueOrDefault() & configId != null)
					{
						return 1;
					}
				}
				return a.ShowPriority - b.ShowPriority;
			});
		}
	}
}
